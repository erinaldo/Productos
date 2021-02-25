Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.IO.Ports

Public Class FrmTPDV
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
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LstVenta As System.Windows.Forms.ListView
    Friend WithEvents BtnCancelaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBusquedaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnVenta As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGarantia As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOtrosDocumentos As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnApartados As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblCantidadPuntos As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblCantidadArticulos As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnWait As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemApartado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCotizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCambio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEnvio As Janus.Windows.EditControls.UIButton
    Friend WithEvents picSalir As System.Windows.Forms.PictureBox
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents txtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents SpdetalleopenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SellingDataSet As Selling.SellingDataSet
    Friend WithEvents Sp_detalle_openTableAdapter As Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter
    Friend WithEvents btnPromocion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxCliente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemEditarCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemNuevoCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbSucursal As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Columna As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTPDV))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.LstVenta = New System.Windows.Forms.ListView
        Me.Columna = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblCantidadPuntos = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.btnPromocion = New Janus.Windows.EditControls.UIButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblAhorro = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.picSalir = New System.Windows.Forms.PictureBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblFolio = New System.Windows.Forms.Label
        Me.LblFechaHora = New System.Windows.Forms.Label
        Me.LblTitulo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblUsuario = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblCantidadArticulos = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.BtnWait = New Janus.Windows.EditControls.UIButton
        Me.LblStatus = New System.Windows.Forms.Label
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtTicket = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemApartado = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemCotizacion = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemCambio = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnApartados = New Janus.Windows.EditControls.UIButton
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton
        Me.BtnGarantia = New Janus.Windows.EditControls.UIButton
        Me.BtnOtrosDocumentos = New Janus.Windows.EditControls.UIButton
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton
        Me.BtnVenta = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelaProducto = New Janus.Windows.EditControls.UIButton
        Me.BtnBusquedaProducto = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelaTicket = New Janus.Windows.EditControls.UIButton
        Me.LblSubTitulo = New System.Windows.Forms.Label
        Me.btnEnvio = New Janus.Windows.EditControls.UIButton
        Me.txtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.btnCliente = New Janus.Windows.EditControls.UIButton
        Me.CtxCliente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemEditarCte = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemNuevoCte = New System.Windows.Forms.ToolStripMenuItem
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblCliente = New System.Windows.Forms.Label
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.SpdetalleopenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SellingDataSet = New Selling.SellingDataSet
        Me.Sp_detalle_openTableAdapter = New Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbSucursal = New Selling.StoreCombo
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.picSalir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.CtxDocumentos.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.CtxCliente.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpdetalleopenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SellingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LstVenta
        '
        Me.LstVenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Columna})
        Me.LstVenta.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstVenta.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstVenta.Location = New System.Drawing.Point(2, 99)
        Me.LstVenta.Name = "LstVenta"
        Me.LstVenta.Size = New System.Drawing.Size(552, 439)
        Me.LstVenta.TabIndex = 4
        Me.LstVenta.UseCompatibleStateImageBehavior = False
        Me.LstVenta.View = System.Windows.Forms.View.Details
        '
        'Columna
        '
        Me.Columna.Text = "Columna"
        Me.Columna.Width = 750
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel1.Location = New System.Drawing.Point(557, 420)
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
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Controls.Add(Me.picKeyboard)
        Me.Panel3.Location = New System.Drawing.Point(557, 512)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 87)
        Me.Panel3.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TOTAL"
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
        Me.picKeyboard.Location = New System.Drawing.Point(3, 52)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(42, 35)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 49
        Me.picKeyboard.TabStop = False
        '
        'btnPromocion
        '
        Me.btnPromocion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPromocion.Icon = CType(resources.GetObject("btnPromocion.Icon"), System.Drawing.Icon)
        Me.btnPromocion.Location = New System.Drawing.Point(557, 569)
        Me.btnPromocion.Name = "btnPromocion"
        Me.btnPromocion.Size = New System.Drawing.Size(110, 30)
        Me.btnPromocion.TabIndex = 57
        Me.btnPromocion.Text = "Promo"
        Me.btnPromocion.ToolTipText = "Consulta de Promociones y Descuentos Aplicadas"
        Me.btnPromocion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.MintCream
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Location = New System.Drawing.Point(557, 462)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 48)
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
        Me.Panel5.Controls.Add(Me.picSalir)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LblFolio)
        Me.Panel5.Location = New System.Drawing.Point(557, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(240, 57)
        Me.Panel5.TabIndex = 9
        '
        'picSalir
        '
        Me.picSalir.BackColor = System.Drawing.Color.MintCream
        Me.picSalir.Image = Global.Selling.My.Resources.Resources._1403660273_exit
        Me.picSalir.Location = New System.Drawing.Point(207, 0)
        Me.picSalir.Name = "picSalir"
        Me.picSalir.Size = New System.Drawing.Size(32, 32)
        Me.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSalir.TabIndex = 89
        Me.picSalir.TabStop = False
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
        Me.LblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LblFolio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblFolio.Location = New System.Drawing.Point(8, 24)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(224, 29)
        Me.LblFolio.TabIndex = 8
        Me.LblFolio.Text = "1-0001"
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFechaHora
        '
        Me.LblFechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaHora.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblFechaHora.ForeColor = System.Drawing.Color.White
        Me.LblFechaHora.Location = New System.Drawing.Point(254, 60)
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
        Me.Label2.Location = New System.Drawing.Point(4, 60)
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
        Me.LblUsuario.Location = New System.Drawing.Point(81, 60)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(174, 17)
        Me.LblUsuario.TabIndex = 15
        Me.LblUsuario.Text = "JUAN PEREZ"
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Location = New System.Drawing.Point(597, 73)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 20)
        Me.TxtCliente.TabIndex = 2
        '
        'TxtProducto
        '
        Me.TxtProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProducto.Location = New System.Drawing.Point(629, 327)
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
        Me.Label11.Location = New System.Drawing.Point(555, 306)
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
        Me.Label12.Location = New System.Drawing.Point(630, 306)
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
        Me.Label13.Location = New System.Drawing.Point(608, 327)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 16)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Location = New System.Drawing.Point(559, 326)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(48, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
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
        Me.Panel6.Location = New System.Drawing.Point(557, 370)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(240, 49)
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
        Me.Label14.Location = New System.Drawing.Point(560, 353)
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
        Me.BtnWait.Location = New System.Drawing.Point(335, 569)
        Me.BtnWait.Name = "BtnWait"
        Me.BtnWait.Size = New System.Drawing.Size(110, 30)
        Me.BtnWait.TabIndex = 39
        Me.BtnWait.Text = "F10- Espera (0)"
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
        Me.LblStatus.Size = New System.Drawing.Size(365, 57)
        Me.LblStatus.TabIndex = 40
        Me.LblStatus.Text = "P U N T O - D E - V E N T A"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.MintCream
        Me.LblTipoCambio.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTipoCambio.Location = New System.Drawing.Point(560, 572)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(229, 24)
        Me.LblTipoCambio.TabIndex = 41
        Me.LblTipoCambio.Text = "PUNTO DE VENTA"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(553, 273)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 23)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "PEDIDO"
        '
        'TxtTicket
        '
        Me.TxtTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(629, 273)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(120, 21)
        Me.TxtTicket.TabIndex = 43
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(332, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(221, 16)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Presione <Ctrl+R> para retiro de Caja"
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemApartado, Me.ItemCotizacion, Me.ItemCambio})
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(131, 70)
        '
        'ItemApartado
        '
        Me.ItemApartado.Image = CType(resources.GetObject("ItemApartado.Image"), System.Drawing.Image)
        Me.ItemApartado.Name = "ItemApartado"
        Me.ItemApartado.Size = New System.Drawing.Size(130, 22)
        Me.ItemApartado.Text = "Apartado"
        Me.ItemApartado.ToolTipText = "Crea una venta de tipo Apartado"
        '
        'ItemCotizacion
        '
        Me.ItemCotizacion.Image = CType(resources.GetObject("ItemCotizacion.Image"), System.Drawing.Image)
        Me.ItemCotizacion.Name = "ItemCotizacion"
        Me.ItemCotizacion.Size = New System.Drawing.Size(130, 22)
        Me.ItemCotizacion.Text = "Cotización"
        Me.ItemCotizacion.ToolTipText = "Crea una Cotización"
        '
        'ItemCambio
        '
        Me.ItemCambio.Image = CType(resources.GetObject("ItemCambio.Image"), System.Drawing.Image)
        Me.ItemCambio.Name = "ItemCambio"
        Me.ItemCambio.Size = New System.Drawing.Size(130, 22)
        Me.ItemCambio.Text = "Cambio"
        Me.ItemCambio.ToolTipText = "Realiza Cambio de Producto"
        '
        'BtnApartados
        '
        Me.BtnApartados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnApartados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnApartados.Icon = CType(resources.GetObject("BtnApartados.Icon"), System.Drawing.Icon)
        Me.BtnApartados.Location = New System.Drawing.Point(2, 569)
        Me.BtnApartados.Name = "BtnApartados"
        Me.BtnApartados.Size = New System.Drawing.Size(110, 30)
        Me.BtnApartados.TabIndex = 14
        Me.BtnApartados.Text = "F11- Apartados"
        Me.BtnApartados.ToolTipText = "Mantenimiento de Productos Apartados"
        Me.BtnApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Icon = CType(resources.GetObject("BtnDevolucion.Icon"), System.Drawing.Icon)
        Me.BtnDevolucion.Location = New System.Drawing.Point(113, 569)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(110, 30)
        Me.BtnDevolucion.TabIndex = 13
        Me.BtnDevolucion.Text = "F6- Devolución"
        Me.BtnDevolucion.ToolTipText = "Devolución de Venta"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGarantia
        '
        Me.BtnGarantia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGarantia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGarantia.Icon = CType(resources.GetObject("BtnGarantia.Icon"), System.Drawing.Icon)
        Me.BtnGarantia.Location = New System.Drawing.Point(224, 569)
        Me.BtnGarantia.Name = "BtnGarantia"
        Me.BtnGarantia.Size = New System.Drawing.Size(110, 30)
        Me.BtnGarantia.TabIndex = 9
        Me.BtnGarantia.Text = "F4- Garantía"
        Me.BtnGarantia.ToolTipText = "Consulta de Garantía"
        Me.BtnGarantia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOtrosDocumentos
        '
        Me.BtnOtrosDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOtrosDocumentos.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnOtrosDocumentos.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnOtrosDocumentos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOtrosDocumentos.Icon = CType(resources.GetObject("BtnOtrosDocumentos.Icon"), System.Drawing.Icon)
        Me.BtnOtrosDocumentos.Location = New System.Drawing.Point(335, 539)
        Me.BtnOtrosDocumentos.Name = "BtnOtrosDocumentos"
        Me.BtnOtrosDocumentos.Size = New System.Drawing.Size(110, 30)
        Me.BtnOtrosDocumentos.TabIndex = 10
        Me.BtnOtrosDocumentos.Text = "Otros Documentos"
        Me.BtnOtrosDocumentos.ToolTipText = "Crea documentos de Apartado, Cotización "
        Me.BtnOtrosDocumentos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.Location = New System.Drawing.Point(446, 569)
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
        Me.BtnVenta.Location = New System.Drawing.Point(446, 539)
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
        Me.BtnCancelaProducto.Location = New System.Drawing.Point(113, 539)
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
        Me.BtnBusquedaProducto.Location = New System.Drawing.Point(752, 317)
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
        Me.BtnCancelaTicket.Location = New System.Drawing.Point(2, 539)
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
        Me.LblSubTitulo.Size = New System.Drawing.Size(336, 16)
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
        Me.btnEnvio.Location = New System.Drawing.Point(224, 539)
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
        Me.txtLimite.Location = New System.Drawing.Point(694, 147)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(94, 20)
        Me.txtLimite.TabIndex = 52
        Me.txtLimite.Text = "0.00"
        Me.txtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimite.Value = 0
        Me.txtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtDias
        '
        Me.txtDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDias.Enabled = False
        Me.txtDias.Location = New System.Drawing.Point(694, 174)
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
        Me.txtSaldo.Location = New System.Drawing.Point(694, 201)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(94, 20)
        Me.txtSaldo.TabIndex = 54
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.Value = 0
        Me.txtSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.MintCream
        Me.Panel8.Controls.Add(Me.btnCliente)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.LblCliente)
        Me.Panel8.Location = New System.Drawing.Point(557, 62)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(241, 197)
        Me.Panel8.TabIndex = 55
        '
        'btnCliente
        '
        Me.btnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCliente.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.btnCliente.ContextMenuStrip = Me.CtxCliente
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Icon = CType(resources.GetObject("btnCliente.Icon"), System.Drawing.Icon)
        Me.btnCliente.Location = New System.Drawing.Point(186, 5)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(52, 32)
        Me.btnCliente.TabIndex = 58
        Me.btnCliente.ToolTipText = "Agrega / Editar Cliente"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(1, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "CTE:"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(5, 140)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 24)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Saldo "
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(5, 113)
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
        Me.Label1.Location = New System.Drawing.Point(5, 86)
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
        Me.LblCliente.Location = New System.Drawing.Point(-1, 40)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(239, 40)
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
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.DataSource = Me.SpdetalleopenBindingSource
        GridDetalle_DesignTimeLayout.LayoutString = resources.GetString("GridDetalle_DesignTimeLayout.LayoutString")
        Me.GridDetalle.DesignTimeLayout = GridDetalle_DesignTimeLayout
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(2, 99)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(552, 439)
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
        'btnBuscaCte
        '
        Me.btnBuscaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(696, 67)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(44, 32)
        Me.btnBuscaCte.TabIndex = 47
        Me.btnBuscaCte.Text = "F3"
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Icon = CType(resources.GetObject("BtnBuscaTicket.Icon"), System.Drawing.Icon)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(752, 265)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(46, 31)
        Me.BtnBuscaTicket.TabIndex = 44
        Me.BtnBuscaTicket.Text = "F1"
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Pedido"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(4, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 17)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "SURTIR EN:"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursal.Location = New System.Drawing.Point(98, 77)
        Me.cmbSucursal.MaximumSize = New System.Drawing.Size(298, 0)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(228, 21)
        Me.cmbSucursal.TabIndex = 58
        '
        'FrmTPDV
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnPromocion)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.txtLimite)
        Me.Controls.Add(Me.btnEnvio)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.LblSubTitulo)
        Me.Controls.Add(Me.BtnBuscaTicket)
        Me.Controls.Add(Me.TxtTicket)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LblTipoCambio)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.BtnWait)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.BtnDevolucion)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnApartados)
        Me.Controls.Add(Me.BtnGarantia)
        Me.Controls.Add(Me.BtnOtrosDocumentos)
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
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LstVenta)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTPDV"
        Me.Text = "Punto de Venta"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.picSalir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.CtxDocumentos.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
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
    Private bMessage As Boolean = True

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
    Public NoVtaOpen As Integer

    Public CorteDetallado As Integer = 0
    Public GridView As Integer = 0
    Public sFrase As String
    Public Display As Boolean = False
    Public BaudRate As Integer
    Public MaxCaracteres As Integer
    Public NoLineas As Integer
    Public Port As String
    Public ActivarCotizacion As Boolean = True
    Public Picking As Boolean
    Public Movilidad As Boolean
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
    Public PRNClavePic As String
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
    Public AtiendeClave As String ' Identificador del Cajero
    Public PorcMaxDesc As Double 'Porcentaje Maximo descuento del vendedor
    Public USRCambiaPrecio As Boolean 'Si se le permite cambiar precios al vendedor
    Public AtiendeNombre As String ' Nombre del Cajero
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
    Public TotalPuntos As Double = 0.0
    Public TotalVenta As Double = 0.0
    Public VentaCerrada As Boolean = True
    Public ListaPrecio As String
    Public TImpuesto As Integer
    Public DescuentoCliente As Integer
    Public PorcDescCliente As Double
    Public TotalRecibido As Double = 0.0
    Public TotalCambio As Double = 0.0
    Public FormaPago As Integer
    Public TipoDesCte As Integer
    Public DESClave As String
    Public TipoDocumento As Integer
    Public EstadoDocumento As Integer
    Public CambiarCliente As Boolean = False
    Public sFolio As String = "-"

    Private AlmacenSurtido As String  'Clave del almacén surtido
    Private SUCClave As String = "" 'SUCURSAL
    Private bLoad As Boolean = False
    Private Cantidad As Double = 1
    Private PorcImpProducto As Double
    Private Autoriza As String
    Private MaxEfectivo As Double 'Maximo Efectivo en Caja
    Private MaxCheques As Double 'Maximo Cheques en Caja
    Private MaxVales As Double 'Maximo Vales en Caja
    Private CajaClave As String
    Private CajaTICDevolucion As String
    Private CajaNombre As String
    Private Manual As Integer
    Private Cajon As Boolean = False
    Private CreditoDisponible As Double = 0.0
    Private sGTIN As String = ""
    Private NotaCreditos As String = ""
    Private MonedaCambio As String
    Private Moneda As String
    Private MonedaRef As String
    Private TipoCambio As Double
    Private Aplicacion As String = ""
    Private mySerialPort As New SerialPort
    Private sAlmacen As String = ""

    Private Periodo, Mes As Integer
    Private bCierreApertura As Boolean = False
    Private dtPedidoDetalle As DataTable

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

        LblFolio.Text = Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)

    End Sub

    Private Sub VentaContado()
        If VentaCerrada Then

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
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.AtiendeClave = a.AtiendeClave
                    LblUsuario.Text = AtiendeNombre
                Else
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

            End If



            TipoDocumento = 1

            EstadoDocumento = 1

            modificaStatus(TipoDocumento, EstadoDocumento)

            If CambiarCliente = False Then
                btnCliente.Enabled = True
                cmbSucursal.Enabled = True
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                CambiarCliente = True
            End If


            dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClaveActual)
            txtLimite.Text = dt.Rows(0)("LimiteCredito")
            txtDias.Text = dt.Rows(0)("DiasCredito")
            txtSaldo.Text = dt.Rows(0)("Saldo")
            dt.Dispose()


            ObtenerFolio()

            VENClave = ModPOS.obtenerLlave()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@Usuario", ModPOS.UsuarioActual)



            btnCliente.Enabled = True
            btnBuscaCte.Enabled = True
            cmbSucursal.Enabled = True
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True

            If GridView = 1 Then
                dtPedidoDetalle.Clear()
            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)

                If sFrase <> "" Then
                    LstVenta.Items.Add(sFrase)
                End If
            End If

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
                AgregaGTIN(sGTIN)
                sGTIN = ""
            End If

            If TipoVenta = 0 Then
                If CTEClaveActual <> CTEClaveInicial Then
                    cambiaCliente(CTEClaveInicial)
                End If
            End If

        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub VentaCredito()
        If VentaCerrada Then

            Dim dt As DataTable

            If SolicitaVendedor Then
                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
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


            If CambiarCliente = False Then
                btnCliente.Enabled = True
                cmbSucursal.Enabled = True
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                CambiarCliente = True
            End If

            ObtenerFolio()

            VENClave = ModPOS.obtenerLlave()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@Usuario", ModPOS.UsuarioActual)

            btnCliente.Enabled = True
            cmbSucursal.Enabled = True
            btnBuscaCte.Enabled = True
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True


            If GridView = 1 Then
                dtPedidoDetalle.Clear()
            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)

                If sFrase <> "" Then
                    LstVenta.Items.Add(sFrase)
                End If
                LstVenta.Items.Add("********** VENTA A CRÉDITO **********")
                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Blue
            End If

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

                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClaveActual)
                    txtLimite.Text = dt.Rows(0)("LimiteCredito")
                    txtDias.Text = dt.Rows(0)("DiasCredito")
                    txtSaldo.Text = dt.Rows(0)("Saldo")
                    dt.Dispose()

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


            If TipoVenta = 0 Then
                If CTEClaveActual <> CTEClaveInicial Then
                    cambiaCliente(CTEClaveInicial)
                End If
            End If

        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub FrmTPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If VentaCerrada Then
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
            ModPOS.Venta.Dispose()
            ModPOS.Venta = Nothing

        Else
            Beep()
            Select Case MessageBox.Show("La Venta actual no ha sido Cerrada, ¿Desea Cancelarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                Case DialogResult.Yes
                    BtnCancelaTicket.PerformClick()
                    If VentaCerrada Then
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
                        ModPOS.Venta.Dispose()
                        ModPOS.Venta = Nothing
                    Else
                        e.Cancel = True
                    End If
            End Select

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


    Private Sub convierteDocumento(ByVal NuevoDocumento As Integer)
        Select Case NuevoDocumento
            Case 1

                If TipoDocumento = 2 Then
                    If ValidaInventario = True Then
                        If validaExistencia() = False Then
                            Exit Sub
                        End If
                    End If
                    actualizaExistencia(TipoMov.Entrada)
                End If


                btnEnvio.Enabled = True

                If VentaCerrada = False Then

                    TipoDocumento = 1

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)



                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("VTA. CONTADO (ABIERTA)", Status.Abierto)

                ElseIf TipoDocumento = 2 Then

                    If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                        TipoDocumento = 1

                        aplicarPromociones(SUCClave)

                        ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                        "@VENClave", VENClave, _
                        "@Cliente", CTEClaveActual, _
                        "@Tipo", TipoDocumento, _
                        "@Cajero", AtiendeClave, _
                        "@CAJClave", CAJClave, _
                        "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)

                        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)

                        If Picking = False Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                            ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                            ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                        Else
                            EstadoDocumento = iEstado.Picking
                            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                            ModPOS.calculaRecoleccion(1, VENClave, ALMClave)

                        End If

                        modificaStatus(TipoDocumento, EstadoDocumento)
                        'cambiaStatus("VTA. CONTADO (CERRADA)", Status.Cerrado)


                    End If

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


                If TipoDocumento = 2 Then
                    If ValidaInventario = True Then
                        If validaExistencia() = False Then
                            Exit Sub
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
                        Exit Sub
                    End If
                    b.Dispose()
                Else
                    Dim dt As DataTable
                    Dim CreditoDisp As Double
                    Dim LimiteCred As Double

                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", Me.CTEClaveActual)
                    CreditoDisp = dt.Rows(0)("Disponible")
                    LimiteCred = dt.Rows(0)("LimiteCredito")
                    dt.Dispose()

                    If Not (LimiteCred > 0 AndAlso CreditoDisp >= Me.TotalVenta) Then
                        MessageBox.Show("El cliente no cuenta con crédito ó ha sobrepasado su limite disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                End If

                If TipoDocumento = 2 Then
                    actualizaExistencia(TipoMov.Entrada)
                End If


                btnEnvio.Enabled = True

                If VentaCerrada = False Then

                    TipoDocumento = 3

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)

                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("VTA. CRÉDITO (ABIERTA)", Status.Abierto)
                ElseIf TipoDocumento = 2 Then

                    If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                        TipoDocumento = 3

                        aplicarPromociones(SUCClave)

                        ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                                            "@VENClave", VENClave, _
                                            "@Cliente", CTEClaveActual, _
                                            "@Tipo", TipoDocumento, _
                                            "@Cajero", AtiendeClave, _
                                            "@CAJClave", CAJClave, _
                                            "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)

                        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)


                        If Picking = False Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                            ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                            ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                        Else
                            EstadoDocumento = iEstado.Picking
                            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                            ModPOS.calculaRecoleccion(1, VENClave, ALMClave)

                        End If

                        modificaStatus(TipoDocumento, EstadoDocumento)
                        'cambiaStatus("VTA. CRÉDITO (CERRADA)", Status.Cerrado)


                    End If
                End If
            Case 4

                If TipoDocumento = 2 Then
                    If ValidaInventario = True Then
                        If validaExistencia() = False Then
                            Exit Sub
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
                        Exit Sub
                    End If
                    b.Dispose()
                Else
                End If

                btnEnvio.Enabled = False

                If TipoDocumento = 2 Then
                    actualizaExistencia(TipoMov.Entrada)
                End If


                If VentaCerrada = False Then
                    TipoDocumento = 4

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)

                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("APARTADO (ABIERTO)", Status.Abierto)
                ElseIf TipoDocumento = 2 Then
                    If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                        TipoDocumento = 4



                        aplicarPromociones(SUCClave)

                        ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                                            "@VENClave", VENClave, _
                                            "@Cliente", CTEClaveActual, _
                                            "@Tipo", TipoDocumento, _
                                            "@Cajero", AtiendeClave, _
                                            "@CAJClave", CAJClave, _
                                            "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)

                        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)

                        If Picking = False Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                            ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                            ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                        Else
                            EstadoDocumento = iEstado.Picking
                            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                            ModPOS.calculaRecoleccion(1, VENClave, ALMClave)

                        End If

                        modificaStatus(TipoDocumento, EstadoDocumento)
                        'cambiaStatus("APARTADO (CERRADO)", Status.Cerrado)
                    End If
                End If
        End Select

    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, LstVenta.KeyUp, BtnBusquedaProducto.KeyUp, BtnCancelaProducto.KeyUp, BtnCerrar.KeyUp, BtnOtrosDocumentos.KeyUp, BtnGarantia.KeyUp, BtnVenta.KeyUp, BtnDevolucion.KeyUp, BtnApartados.KeyUp, TxtCantidad.KeyUp, TxtCliente.KeyUp, BtnCancelaTicket.KeyUp, TxtTicket.KeyUp, BtnBuscaTicket.KeyUp, btnBuscaCte.KeyUp, TxtProducto.KeyUp, BtnWait.KeyUp, btnEnvio.KeyUp, GridDetalle.KeyUp

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
                a.SUCClave = SucursalSurtido
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
        Else
            Select Case e.KeyCode
                Case Is = Keys.Escape
                    Me.Close()
                Case Is = Keys.F2
                    Me.BtnBusquedaProducto.PerformClick()
                Case Is = Keys.F3
                    Me.btnBuscaCte.PerformClick()
                Case Is = Keys.F4
                    Me.BtnGarantia.PerformClick()
                Case Is = Keys.F5
                    Me.BtnVenta.PerformClick()
                Case Is = Keys.F6
                    Me.BtnDevolucion.PerformClick()
                Case Is = Keys.F7
                    Me.BtnCancelaTicket.PerformClick()
                Case Is = Keys.F8
                    Me.btnEnvio.PerformClick()
                Case Is = Keys.F9
                    BtnCerrar.PerformClick()
                Case Is = Keys.F10
                    Me.BtnWait.PerformClick()
                Case Is = Keys.F11
                    Me.BtnApartados.PerformClick()
                Case Is = Keys.F12
                    Me.BtnCancelaProducto.PerformClick()
                Case Is = Keys.F1
                    Me.BtnBuscaTicket.PerformClick()
                Case Is = Keys.Right
                    If CStr(sender.Name) = "TxtProducto" Then
                        If VentaCerrada = False Then
                            'Si el campo cantidad esta vacio lo cambia a 1 por defecto
                            If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                                Cantidad = 1
                                TxtCantidad.Text = "1"
                            End If
                            'Si es el primer articulo, recupera la lista de precio del cliente actual
                            If TotalArticulos = 0 Then
                                Dim dtCliente As DataTable
                                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
                                ListaPrecio = dtCliente.Rows(0)("PREClave")
                                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                                dtCliente.Dispose()
                                'Recupera los descuentos de cliente
                                Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
                                If Not dtDescCte Is Nothing Then
                                    DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(0)("Cascada")))
                                    PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                                    TipoDesCte = dtDescCte.Rows(0)("TipoAplicacion")
                                    DESClave = dtDescCte.Rows(0)("DESClave")
                                    dtDescCte.Dispose()
                                Else
                                    DescuentoCliente = -1
                                    PorcDescCliente = 0
                                    TipoDesCte = 0
                                    DESClave = ""
                                End If
                            End If
                            'Busca y recupera los datos del producto

                            Dim a As New FrmBuscaProducto
                            a.SUCClave = Me.SUCClave
                            a.ClienteActual = CTEClaveActual
                            a.PuntodeVenta = PDVClave
                            a.Almacen = AlmacenSurtido
                            a.ListadePrecio = ListaPrecio
                            a.StatusVenta = VentaCerrada
                            a.TImpuesto = TImpuesto
                            a.BusquedaInicial = True
                            a.Busqueda = TxtProducto.Text.Trim.ToUpper
                            a.TxtAlmacen.Text = sAlmacen
                            a.bMessage = Me.bMessage
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

        If GridView = 1 Then


            dtPedidoDetalle = ModPOS.Recupera_Tabla("sp_detalle_open", "@VENClave", VENClave)
            GridDetalle.DataSource = dtPedidoDetalle

            GridDetalle.RootTable.Columns("Cantidad").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("% Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Desc"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
            fc.FormatStyle.ForeColor = System.Drawing.Color.Red
            GridDetalle.RootTable.FormatConditions.Add(fc)


            Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
            fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

            fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            GridDetalle.RootTable.FormatConditions.Add(fc1)

        Else
            GridDetalle.Visible = False
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


        With Me.cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        SUCClave = SucursalSurtido
        cmbSucursal.SelectedValue = SUCClave
        AlmacenSurtido = ALMClave
        sAlmacen = AlmacenClave & " - " & AlmacenNombre

        bLoad = True



        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
        Movilidad = IIf(dt.Rows(0)("Movilidad").GetType.Name = "DBNull", False, dt.Rows(0)("Movilidad"))


        If Picking = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", PRNClavePic)
            PRNClavePic = dt.Rows(0)("Referencia")
        End If

        If Moneda <> MonedaCambio Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        Else
            LblTipoCambio.Text = ""
        End If

        If Caja Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
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
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.IDCorte = IDCorte
                    a.Cajon = Cajon
                    a.Impresora = Impresora
                    a.ShowDialog()
                Else
                    Dim a As New FrmAperturaSimple
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.IDCorte = IDCorte
                    a.Cajon = Cajon
                    a.Impresora = Impresora
                    a.ShowDialog()
                End If


            End If
        End If


        LblTitulo.Text = PuntodeVenta
        BtnDevolucion.Enabled = Caja
        BtnApartados.Enabled = Caja

        If Caja = False And ActivaDevolucion = True Then
            BtnDevolucion.Enabled = True
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

        If VentaAbierta = True Then
            recuperaVentaOpen(VENClave, sFolio, CTEClaveActual, CTENombreActual, AtiendeClave, AtiendeNombre, SaldoVenta, TotalVenta, TipoDocumento, EstadoDocumento, txtLimite.Text, txtDias.Text, txtSaldo.Text, NoVtaOpen, AlmacenOpen)
        End If

        If VentaNueva Then
            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
        End If

        LblCliente.Text = CTENombreActual
        LblUsuario.Text = AtiendeNombre
        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        TxtCantidad.Text = CStr(ModPOS.Redondear(Cantidad, 2))
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        If Moneda <> MonedaCambio Then
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        Dim dtventa As DataTable
        dtventa = ModPOS.SiExisteRecupera("sp_recupera_ventawait", "@PDVClave", PDVClave)

        If Not dtventa Is Nothing AndAlso dtventa.Rows.Count > 0 Then
            BtnWait.Text = "F10- Espera(" & CStr(dtventa.Rows.Count) & ")"
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

    Private Sub BtnVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVenta.Click

        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If CDbl(txtLimite.Text) > 0 Then
            VentaCredito()
        Else
            VentaContado()
        End If
    End Sub

    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If VentaCerrada = False Then

            If cmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

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
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()
                End If
                'Busca y recupera los datos del producto
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClaveActual, "@Cantidad", Cantidad)
                AgregaPartida(dt)
                'Sugerido
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    sugerido(dt.Rows(0)("PROClave"), AlmacenSurtido, VENClave, Picking)
                End If

                If Not dt Is Nothing Then
                    dt.Dispose()
                End If

            End If
        End If
    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub

    Public Sub AgregaGTIN(ByVal sGTIN As String)
        leeCodigoBarras(sGTIN)
    End Sub

    Public Sub AgregaPartida(ByVal dtProducto As DataTable)

        If Not dtProducto Is Nothing Then

            Dim sAutoriza As String = Nothing
            Dim sSUCClave As String = dtProducto.Rows(0)("SUCClave")
            Dim sPROClave As String = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre")
            Dim dCantidad As Double = dtProducto.Rows(0)("Cantidad")
            Dim dCosto As Double = dtProducto.Rows(0)("Costo")
            Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")

            Dim dDescPorc As Double = dtProducto.Rows(0)("DescPorc")
            Dim iTProducto As Integer = dtProducto.Rows(0)("TProducto")
            Dim iSeguimiento As Integer = dtProducto.Rows(0)("Seguimiento")
            Dim iDiasGarantia As Integer = dtProducto.Rows(0)("DiasGarantia")
            Dim iNumDecimales As Integer = dtProducto.Rows(0)("Num_Decimales")
            
            Dim dGeneralNeto As Double = dtProducto.Rows(0)("PrecioNeto")
            Dim dMinimoNeto As Double = dtProducto.Rows(0)("MinimoNeto")

            Dim iKgLt As Integer = IIf(dtProducto.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("KgLt"))
            Dim dPeso As Double = IIf(dtProducto.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("Peso"))
            Dim UnidadesKilo As Double = 0

            dtProducto.Dispose()


            If dCantidad = 0 Then
                TxtProducto.Text = ""
                Cantidad = 1
                TxtCantidad.Text = "1"
                MessageBox.Show("El producto no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            PorcImpProducto = ModPOS.RecuperaImpuesto(sSUCClave, sPROClave, TImpuesto)

            Dim dImporteNeto As Double

            If TImpuesto = 1 Then
                dImporteNeto = dGeneralNeto
            End If

            Dim dDescuentoImp As Double = dImporteNeto * dDescPorc

            If ModificaPrecioServicio AndAlso iTProducto >= 4 Then
                Dim a As New FrmAddProducto
                a.PDVClave = PDVClave
                a.TImpuesto = TImpuesto
                a.PREClave = ListaPrecio
                a.PROClave = sPROClave
                a.NombreCliente = CTENombreActual
                a.Clave = sClave
                a.Nombre = sNombre
                a.ImporteNeto = dImporteNeto
                a.Cantidad = dCantidad
                a.Costo = dCosto
                a.PrecioBruto = dPrecioBruto
                a.FactorImpuesto = PorcImpProducto
                a.DescImp = dDescuentoImp
                a.PorcDesc = dDescPorc
                a.NumDecimal = iNumDecimales
                a.ModificaPrecioServicio = Me.ModificaPrecioServicio
                a.iTProducto = iTProducto
                a.CambiaPrecio = USRCambiaPrecio
                a.PorcMaxDesc = PorcMaxDesc
                a.MinimoNeto = dMinimoNeto
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    dCantidad = a.Cantidad
                    dDescPorc = a.PorcDesc
                    dDescuentoImp = a.DescImp
                    dImporteNeto = a.ImporteNeto
                    dPrecioBruto = a.PrecioBruto
                    sAutoriza = a.sAutoriza
                    a.Dispose()
                    TxtProducto.Focus()
                Else
                    sautoriza = ""
                    a.Dispose()
                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    TxtProducto.Focus()
                    Exit Sub
                End If
            ElseIf CambiaPrecio Then
                'Si Cambia Precio = True 
                Dim a As New FrmAddProducto
                a.SUCClave = SucursalSurtido
                a.ALMClave = AlmacenSurtido
                a.PDVClave = PDVClave
                a.TImpuesto = TImpuesto
                a.PREClave = ListaPrecio
                a.PROClave = sPROClave
                a.NombreCliente = CTENombreActual
                a.Clave = sClave
                a.Nombre = sNombre
                a.ImporteNeto = dImporteNeto
                a.Cantidad = dCantidad
                a.Costo = dCosto
                a.PrecioBruto = dPrecioBruto
                a.FactorImpuesto = PorcImpProducto
                a.DescImp = dDescuentoImp
                a.PorcDesc = dDescPorc
                a.NumDecimal = iNumDecimales
                a.ModificaPrecioServicio = Me.ModificaPrecioServicio
                a.iTProducto = iTProducto
                a.CambiaPrecio = USRCambiaPrecio
                a.PorcMaxDesc = PorcMaxDesc
                a.MinimoNeto = dMinimoNeto
                a.KgLt = iKgLt
                a.Peso = dPeso
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    dCantidad = a.Cantidad
                    dDescPorc = a.PorcDesc
                    dDescuentoImp = a.DescImp 'a.ImporteNeto * a.PorcDesc
                    dImporteNeto = a.ImporteNeto
                    dPrecioBruto = a.PrecioBruto
                    sAutoriza = a.sAutoriza
                    UnidadesKilo = a.UnidadesKilo
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
                    Exit Sub
                End If
            End If

            'SI VALIDA INVENTARIO

            If ValidaInventario = True AndAlso TipoDocumento <> 2 Then

                Dim Disponible, Existencia As Double
                Dim dtDisponible As DataTable
                dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
                If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                    Disponible = dtDisponible.Rows(0)("Disponible")
                    Existencia = dtDisponible.Rows(0)("Existencia")

                    dtDisponible.Dispose()
                Else
                    Disponible = 0
                End If

                If dCantidad > Disponible Then
                    If MessageBox.Show("La cantidad solicitad excede el disponible (" & CStr(Disponible) & "), ¿Desea registrar el Producto Negado?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        'Registro de Producto Negado
                        ModPOS.Ejecuta("sp_registra_negado", "@SUCClave", sSUCClave, "@CTEClave", CTEClaveActual, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Cantidad", dCantidad - Disponible, "@Existencia", Existencia, "@Disponible", Disponible, "@Usuario", AtiendeClave)
                    End If

                    If Disponible <= 0 Then
                        Exit Sub
                    Else
                        dCantidad = Disponible
                    End If
                End If

            End If

            Dim YaExiste As Boolean = False
            Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle", "@VENTA", VENClave, "@PROClave", sPROClave, "@Subtotal", (dImporteNeto - dDescuentoImp))

            If dtDetalle Is Nothing Then
                YaExiste = False
            Else
                YaExiste = True
                dtDetalle.Dispose()
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

            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta
            If CambiarCliente = True Then
                btnCliente.Enabled = False
                cmbSucursal.Enabled = False
                btnBuscaCte.Enabled = False
                TxtCliente.Enabled = False
                CambiarCliente = False
                cmbSucursal.Enabled = False
            End If


            Dim dPrecioNeto As Double = ModPOS.Redondear((dPrecioBruto - (dPrecioBruto * dDescPorc)) * (1 + PorcImpProducto), 2)

            Dim DVEClave As String

            If YaExiste Then

                DVEClave = dtDetalle.Rows(0)("DVEClave")

                'Actualiza Cantidad de producto
                ModPOS.Ejecuta("sp_actualiza_detalle", _
                "@ALMClave", AlmacenSurtido, _
                 "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@TProducto", iTProducto, _
                "@Cantidad", dCantidad, _
                "@TipoDoc", TipoDocumento, _
                "@Picking", Picking, _
                "@kglt", iKgLt, _
                "@UndKilo", UnidadesKilo)

            Else
                'Inserta Producto
                DVEClave = ModPOS.obtenerLlave

                ModPOS.Ejecuta("sp_inserta_detalle", _
                "@DVEClave", DVEClave, _
                "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@Costo", dCosto, _
                "@PREClave", ListaPrecio, _
                "@PrecioBruto", dPrecioBruto, _
                "@PorcImp", PorcImpProducto, _
                "@DescuentoPor", dDescPorc, _
                "@DescuentoImp", dPrecioBruto * dDescPorc, _
                "@ImpuestoImp", (dPrecioBruto - (dPrecioBruto * dDescPorc)) * PorcImpProducto, _
                "@Cantidad", dCantidad, _
                "@ALMClave", ALMClave, _
                "@TipoDoc", TipoDocumento, _
                "@TProducto", iTProducto, _
                "@Picking", Picking, _
                "@Autoriza", sAutoriza, _
                "@kglt", iKgLt, _
                "@UndKilo", UnidadesKilo, _
                "@Usuario", ModPOS.UsuarioActual)

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaImpuesto(DVEClave, sPROClave, dPrecioBruto - (dPrecioBruto * dDescPorc), TImpuesto, sSUCClave)

                TotalArticulos += 1

            End If

            ' AGREGAR PRODUCTO A LISTA
            AgregarProducto(DVEClave, sPROClave, sClave, sNombre, dCantidad, dPrecioBruto, PorcImpProducto, dDescPorc, dDescuentoImp, iKgLt, UnidadesKilo)

           
            TotalAhorro += ((dDescuentoImp * (1 + PorcImpProducto)) * dCantidad)
            TotalVenta += dPrecioNeto * dCantidad

            SaldoVenta = TotalVenta

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


            If Agotamiento Then
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_agotamiento", "@ALMClave", AlmacenSurtido, "@PROClave", sPROClave, "@Cantidad", dCantidad)
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
        TxtCantidad.Text = "1"
    End Sub

    Private Sub sugerido(ByVal sPROClave As String, ByVal sALMClave As String, ByVal sVENClave As String, ByVal bPicking As Boolean)
        Dim dataSetPortafolio As DataSet = ModPOS.recuperaTabla_DTS("sp_recupera_portafolio_prod", "Portafolio", "@PROClave", sPROClave)
        If dataSetPortafolio.Tables(0).Rows.Count > 0 Then
            Dim a As New FrmSugerido
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


    Public Sub AgregarProducto(ByVal DVEClave As String, ByVal PROClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Double, ByVal Precio As Double, ByVal ImpuestoPor As Double, ByVal DescPor As Double, ByVal Descuento As Double, ByVal kglt As Integer, ByVal UnidadesKilo As Double)

        If GridView = 1 Then

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
            row1.Item("Precio") = Precio * (1 + ImpuestoPor)
            row1.Item("Desc") = Descuento * (1 + ImpuestoPor)
            row1.Item("% Desc") = DescPor * 100
            row1.Item("Subtotal") = (Precio - Descuento) * (1 + ImpuestoPor)
            row1.Item("Total") = Cantidad * ((Precio - Descuento) * (1 + ImpuestoPor))
            row1.Item("Baja") = 0
            dtPedidoDetalle.Rows.Add(row1)
        Else

            Dim dSubtotal As Double
            If kglt = 1 Then
                Nombre &= CStr(UnidadesKilo) & " Unds"
           End If

            LstVenta.Items.Add(FormateaCadena(True, GTIN & " " & Nombre, 53))

            If Descuento = 0 Then
                'si no tiene descuento de cliente ni de producto
                dSubtotal = Cantidad * (Precio * (1 + ImpuestoPor))

                LstVenta.Items.Add(FormateaCadena(False, ModPOS.Redondear(Cantidad, 2).ToString, 8) & _
                "  @  " & _
                FormateaCadena(False, Format(ModPOS.Redondear(Precio * (1 + ImpuestoPor), 2).ToString, "Currency"), 12) & _
                FormateaCadena(False, "", 12) & _
                FormateaCadena(False, Format(ModPOS.Redondear(dSubtotal, 2).ToString, "Currency"), 14))
                LstVenta.Items(LstVenta.Items.Count - 2).ForeColor = System.Drawing.Color.Black
                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Black

            ElseIf Descuento > 0 Then
                'Si no tiene descuento de cliente pero si tiene descuento de producto
                Dim DescuentoNeto As Double = Descuento * (1 + ImpuestoPor)
                dSubtotal = Cantidad * ((Precio - Descuento) * (1 + ImpuestoPor))

                LstVenta.Items.Add(FormateaCadena(False, ModPOS.Redondear(Cantidad, 2).ToString, 8) & "  @  " & FormateaCadena(False, Format(ModPOS.Redondear(Precio * (1 + ImpuestoPor), 2).ToString, "Currency"), 12))
                LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(DescPor * 100, 2).ToString & "%-", 8) & "OFER." & FormateaCadena(False, Format(ModPOS.Redondear(DescuentoNeto, 2).ToString, "Currency"), 12) & FormateaCadena(False, Format(ModPOS.Redondear((Precio - Descuento) * (1 + ImpuestoPor), 2).ToString, "Currency"), 12) & FormateaCadena(False, Format(ModPOS.Redondear(dSubtotal, 2).ToString, "Currency"), 14))
                LstVenta.Items(LstVenta.Items.Count - 3).ForeColor = System.Drawing.Color.Red
                LstVenta.Items(LstVenta.Items.Count - 2).ForeColor = System.Drawing.Color.Red
                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
            End If
        End If

        If Display = True Then
            Try
                'limpiar
                Dim LimpiarDisplay As String = Chr(12)
                mySerialPort.Write(LimpiarDisplay)

                If NoLineas > 1 Then
                    mySerialPort.Write(FormateaCadena(True, Nombre, MaxCaracteres))

                    'Bajar Cursor
                    Dim BajarCursor As String = Chr(10)
                    mySerialPort.Write(BajarCursor)

                End If


                'Recorrer Izq
                Dim MoverIzq As String = Chr(13)
                mySerialPort.Write(MoverIzq)

                'Escribe segunda linea
                Dim Linea2 As String

                Dim dSubtotal, dCantidad As Double
                dCantidad = Cantidad
                dSubtotal = ((Precio - Descuento) * (1 + ImpuestoPor)) * Cantidad

                Linea2 = FormateaCadena(False, ModPOS.Redondear(dCantidad, 2).ToString, 2) & _
                " @ " & _
                FormateaCadena(False, Format(ModPOS.Redondear((Precio - Descuento) * (1 + ImpuestoPor), 2).ToString, "Currency"), 7) & _
                FormateaCadena(False, Format(ModPOS.Redondear(dSubtotal, 2).ToString, "Currency"), 8)

                mySerialPort.Write(Linea2)

            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Sub AgregaCancelado(ByVal sDVEClave As String, ByVal Descripcion As String, ByVal Cantidad As Double, ByVal Precio As Double)

        If GridView = 0 Then
            LstVenta.Items.Add(FormateaCadena(True, "CANCELADO " & Descripcion, 53))
            LstVenta.Items.Add(FormateaCadena(False, ModPOS.Redondear(Cantidad, 2).ToString, 8) & _
            "  @  " & _
            FormateaCadena(False, Format(ModPOS.Redondear(Precio, 2).ToString, "Currency"), 12) & _
            FormateaCadena(False, "", 12) & _
            FormateaCadena(False, "-" & Format(ModPOS.Redondear((Precio) * Cantidad, 2).ToString, "Currency"), 14))
            LstVenta.Items(LstVenta.Items.Count - 2).ForeColor = System.Drawing.Color.Red
            LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
        Else

            Dim foundRows() As System.Data.DataRow
            foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "'")

            If foundRows.Length <> 0 Then
                Dim i As Integer
                Dim dCantidad As Double

                dCantidad = Cantidad
                For i = 0 To foundRows.GetUpperBound(0)
                    If foundRows(i)("Cantidad") > dCantidad Then
                        Dim dCant As Double = foundRows(i)("Cantidad") - dCantidad
                        foundRows(i)("Cantidad") = dCant
                        foundRows(i)("Total") = foundRows(i)("Subtotal") * dCant
                        Exit For
                    ElseIf foundRows(i)("Cantidad") = dCantidad Then
                        foundRows(i)("Baja") = 1
                        Exit For
                    ElseIf foundRows(i)("Cantidad") < dCantidad Then
                        foundRows(i)("Baja") = 1
                        dCantidad -= foundRows(i)("Cantidad")
                    End If
                Next
            End If


        End If

        If Display = True Then
            Try
                'limpiar
                Dim LimpiarDisplay As String = Chr(12)
                mySerialPort.Write(LimpiarDisplay)

                If NoLineas > 1 Then
                    mySerialPort.Write(FormateaCadena(True, "CANCELADO " & Descripcion, MaxCaracteres))

                    'Bajar Cursor
                    Dim BajarCursor As String = Chr(10)
                    mySerialPort.Write(BajarCursor)

                End If


                'Recorrer Izq
                Dim MoverIzq As String = Chr(13)
                mySerialPort.Write(MoverIzq)

                'Escribe segunda linea
                Dim Linea2 As String

                Linea2 = FormateaCadena(False, ModPOS.Redondear(Cantidad, 2).ToString, 2) & _
                " @ " & _
                FormateaCadena(False, Format(ModPOS.Redondear(Precio, 2).ToString, "Currency"), 7) & _
                FormateaCadena(False, Format(ModPOS.Redondear((Precio * Cantidad), 2).ToString, "Currency"), 8)

                mySerialPort.Write(Linea2)

            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"))
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    cambiaCliente(dt.Rows(0)("CTEClave"))
                    dt.Dispose()

                Else
                    LblCliente.Text = ""
                    TxtCliente.Text = ""
                End If
            End If
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
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave)
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

                If GridView = 0 Then

                    If TotalImporteNetoPromocion > 0 Then
                        LstVenta.Items.Add("PROMO: " & FormateaCadena(False, dt.Rows(0)("Descripcion"), 32) & FormateaCadena(False, Format(ModPOS.Redondear(TotalImporteNetoPromocion, 2).ToString, "Currency"), 12))
                        LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
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
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave)
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

                If GridView = 0 Then

                    If TotalImportePromocion > 0 Then
                        LstVenta.Items.Add("PROMO: " & FormateaCadena(False, dt.Rows(0)("Descripcion"), 32) & FormateaCadena(False, Format(ModPOS.Redondear(TotalImportePromocion, 2).ToString, "Currency"), 12))
                        LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
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
                Dim DVEClave As String

                For j = 0 To dtRegalo.Rows.Count - 1

                    Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle", "@VENTA", VENClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

                    If Not dtDetalle Is Nothing Then
                        'Actualiza Cantidad de producto

                        DVEClave = dtRegalo.Rows(j)("DVEClave")

                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                        "@ALMClave", AlmacenSurtido, _
                         "@VENTA", VENClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"), _
                        "@TipoDoc", TipoDocumento, _
                        "@Picking", Picking)

                        dtDetalle.Dispose()
                    Else
                        'Inserta Producto
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

                    AgregarProducto(DVEClave, dtRegalo.Rows(j)("PROClave"), dtRegalo.Rows(j)("Clave"), dtRegalo.Rows(j)("Nombre"), dMonto * dtRegalo.Rows(j)("Cantidad"), 0, 0, 0, 0, 0, 0)


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
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave)
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
        Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
        If Not dtDescCte Is Nothing Then
            Dim i As Integer = 0

            Dim TipoAplicacion As Integer
            Dim ImporteInicial As Double
            Dim ImporteFinal As Double
            Dim GerarquiaDesc As Integer

            For i = 0 To dtDescCte.Rows.Count - 1

                DESClave = dtDescCte.Rows(i)("DESClave")
                TipoAplicacion = dtDescCte.Rows(i)("Tipo")
                TipoDesCte = dtDescCte.Rows(i)("TipoAplicacion")
                PorcDescCliente = dtDescCte.Rows(i)("DescuentoPorc")
                DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(i)("Cascada")))
                ImporteInicial = dtDescCte.Rows(i)("ImporteInicial")
                ImporteFinal = dtDescCte.Rows(i)("ImporteFinal")
                GerarquiaDesc = dtDescCte.Rows(i)("Gerarquia")

                If TotalVenta >= ImporteInicial AndAlso TotalVenta <= ImporteFinal Then
                    Select Case TipoAplicacion
                        Case Is = 1 'Descuento

                            Dim ImpDesCte As Double = PorcDescCliente * TotalVenta

                            TotalAhorro += ImpDesCte
                            TotalVenta -= ImpDesCte
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

                            If GridView = 0 Then
                                LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(PorcDescCliente * 100, 2).ToString & "%-", 8) & "DESC. CTE." & FormateaCadena(False, "", 21) & FormateaCadena(False, Format(ModPOS.Redondear(ImpDesCte, 2).ToString, "Currency"), 12))
                                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
                            End If

                            ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)

                            Dim dt As DataTable
                            dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                            If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
                                ModPOS.RecalculaImpuesto(dt, TImpuesto, sSUCClave)
                                dt.Dispose()
                            End If

                        Case Is = 2 'Bonificación
                            Dim Porcentaje As Double = PorcDescCliente / TotalVenta

                            TotalAhorro += PorcDescCliente
                            TotalVenta -= PorcDescCliente
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

                            If GridView = 0 Then
                                LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(Porcentaje * 100, 2).ToString & "%-", 8) & "BONI. CTE." & FormateaCadena(False, "", 21) & FormateaCadena(False, Format(ModPOS.Redondear(PorcDescCliente, 2).ToString, "Currency"), 12))
                                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
                            End If

                            ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", Porcentaje, "@Usuario", ModPOS.UsuarioActual)

                            Dim dt As DataTable
                            dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                            If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
                                ModPOS.RecalculaImpuesto(dt, TImpuesto, sSUCClave)
                                dt.Dispose()
                            End If

                        Case Is = 3 'Puntos
                            Dim ImpPuntos As Double = PorcDescCliente * TotalVenta

                            TotalPuntos += ImpPuntos
                            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")

                            ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)

                            '      LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(PorcDescCliente * 100, 2).ToString & "%-", 8) & "PTOS. CTE." & FormateaCadena(False, "", 27) & FormateaCadena(False, Format(ModPOS.Redondear(ImpPuntos, 2).ToString, "Currency"), 12))
                            '     LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red

                    End Select

                    ' Si no aplica en cascada deja de aplicar descuentos
                    If DescuentoCliente = 0 Then
                        Exit For
                    End If

                End If
            Next
            dtDescCte.Dispose()
        Else
            DescuentoCliente = -1
            PorcDescCliente = 0
            TipoDesCte = 0
            DESClave = ""
        End If


        'Si el descuento se aplica 1 sola vez por venta se elimina al cliente de dicho descuento despues de aplicarlo
        If TipoDocumento <> 2 AndAlso TipoDesCte = 1 Then
            ModPOS.Ejecuta("sp_elimina_descte", _
                           "@DESClave", DESClave, _
                           "@CTEClave", CTEClaveActual)
        End If

        If Redondeo Then
            Dim a As New FrmSplashRedondeo
            a.url_imagen = Me.Url_Redondeo
            a.VENClave = VENClave
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                ImpRedondeo = a.ImpRedondeo
            Else
                ImpRedondeo = 0
            End If
            a.Dispose()
        End If

        If GridView = 1 Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_desglose_promocion", "@VENClave", VENClave)

            If dt.Rows.Count > 0 Then
                Dim a As New FrmConsultaGen
                a.Text = "Promociones y Descuentos Aplicados"
                ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_desglose_promocion", "@VENClave", VENClave)
                a.GridConsultaGen.GroupByBoxVisible = False
                a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
                a.ShowDialog()
                a.Dispose()
            End If
            dt.Dispose()
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

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Dim NoPagar As Boolean = False

        If TotalArticulos > 0 Then

            'Si la venta no ha sido cerrada
            If VentaCerrada = False Then

                If cmbSucursal.SelectedValue Is Nothing Then
                    MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = False Then
                        Exit Sub
                    End If
                End If

                'Validar Limite de Credito
                If TipoDocumento = 3 Then
                    recuperaDatosCredito(CTEClaveActual)
                    If CreditoDisponible < TotalVenta Then
                        MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(TotalVenta - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If

                If TipoDocumento <> 2 Then
                    aplicarPromociones(SUCClave)


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

                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido)

                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)


                modificaStatus(TipoDocumento, EstadoDocumento)


                If VentaNueva AndAlso (TipoDocumento <> 2) Then '= 3 OrElse TipoDocumento = 4)
                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                End If

                If Picking = False Then
                    If (TipoDocumento = 1 OrElse TipoDocumento = 3) AndAlso GeneraMovSalida Then
                        ModPOS.GeneraMovInv(2, 1, 1, VENClave, AlmacenSurtido, LblFolio.Text, Nothing)
                        ModPOS.ActualizaExistAlm(2, 1, VENClave, AlmacenSurtido)
                        ModPOS.ActualizaExistUbc(2, 1, VENClave, AlmacenSurtido)
                        GeneraMovSalida = False
                    End If
                ElseIf TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If EstadoDocumento = iEstado.Picking Then
                        ModPOS.calculaRecoleccion(1, VENClave, AlmacenSurtido)
                    End If
                End If

            End If ' Si VentaCerrada=False

            If VentaCerrada = True Then

                If EstadoDocumento = 1 Then
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

                ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", EstadoDocumento)

                modificaStatus(TipoDocumento, EstadoDocumento)

            End If


            If Picking = False Then
                If ((TipoDocumento = 3 AndAlso VentaNueva = False) OrElse (TipoDocumento = 1 OrElse TipoDocumento = 4)) AndAlso Caja AndAlso SaldoVenta > 0 Then
                    Do
                        Dim a As New FrmAbono
                        a.Aplicacion = Aplicacion
                        a.TipoDocumento = 1
                        a.CAJA = CAJClave
                        a.ClaveCte = CTEClaveActual
                        a.ClaveDocumento = VENClave
                        a.AperturaCajon = Cajon
                        a.ImpresoraCajon = Impresora
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then

                            Dim AcumulaPuntos As Integer

                            If CTEClaveActual <> a.CTEClave Then
                                CTEClaveActual = a.CTEClave
                                'Actualiza Cliente del documento, actualiza saldo
                            End If

                            If CTEClaveInicial = a.CTEClave Then
                                AcumulaPuntos = 0
                            Else
                                AcumulaPuntos = 1
                            End If

                            TotalRecibido += a.TotalAbono
                            TotalCambio += a.TotalCambio
                            FormaPago = a.TPago
                            SaldoVenta = a.SaldoVenta

                            Dim TotalPagoAplicar As Double

                            Select Case Redondear(a.TotalAbono, 2)
                                Case Is > Redondear(a.SaldoVenta, 2)
                                    TotalPagoAplicar = a.SaldoVenta

                                    ModPOS.Ejecuta("sp_paga_documento", _
                                                                  "@ABNClave", a.AbonoClave, _
                                                                  "@TipoDoc", 1, _
                                                                  "@Documento", VENClave, _
                                                                  "@Pago", TotalPagoAplicar, _
                                                                  "@AcumulaPuntos", AcumulaPuntos, _
                                                                  "Tipo", 0, _
                                                                  "@Usuario", ModPOS.UsuarioActual)
                                Case Is < Redondear(a.SaldoVenta, 2)
                                    TotalPagoAplicar = a.TotalAbono

                                    ModPOS.Ejecuta("sp_actualiza_saldo", _
                                                    "@ABNClave", a.AbonoClave, _
                                                   "@Pago", TotalPagoAplicar, _
                                                   "@TipoDoc", 1, _
                                                   "@Documento", VENClave, _
                                                   "Tipo", 0, _
                                                   "@Usuario", ModPOS.UsuarioActual)

                                Case Is = Redondear(a.SaldoVenta, 2)
                                    TotalPagoAplicar = a.SaldoVenta

                                    ModPOS.Ejecuta("sp_paga_documento", _
                                                    "@ABNClave", a.AbonoClave, _
                                                   "@TipoDoc", 1, _
                                                   "@Documento", VENClave, _
                                                   "@Pago", TotalPagoAplicar, _
                                                   "@AcumulaPuntos", AcumulaPuntos, _
                                                   "Tipo", 0, _
                                                   "@Usuario", ModPOS.UsuarioActual)
                            End Select

                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClaveActual, "@Importe", TotalPagoAplicar)

                            SaldoVenta -= TotalPagoAplicar

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

                        EstadoDocumento = iEstado.Pagado

                        modificaStatus(TipoDocumento, EstadoDocumento)

                        Dim msg As New FrmMeMsg
                        If FormaPago = 1 Then
                            msg.TxtTiulo = "Su Cambio es:"
                        Else
                            msg.TxtTiulo = "Su Saldo a favor es:"
                        End If
                        msg.TxtMsg = Format(CStr(ModPOS.Redondear(TotalCambio, 2)), "Currency")
                        msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(TotalCambio, 2))).ToUpper
                        msg.ShowDialog()
                        msg.Dispose()


                        If Display = True Then
                            Try
                                'limpiar
                                Dim LimpiarDisplay As String = Chr(12)
                                mySerialPort.Write(LimpiarDisplay)
                                mySerialPort.Write("RECIBIDO: " & Format(CStr(ModPOS.Redondear(TotalRecibido, 2)), "Currency"))
                                If NoLineas > 1 AndAlso TotalAhorro > 0 Then
                                    Dim BajarCursor As String = Chr(10)
                                    mySerialPort.Write(BajarCursor)
                                    'Recorrer Izq
                                    Dim MoverIzq As String = Chr(13)
                                    mySerialPort.Write(MoverIzq)
                                    mySerialPort.Write("CAMBIO: " & Format(CStr(ModPOS.Redondear(TotalCambio, 2)), "Currency"))
                                End If
                            Catch ex As Exception
                            End Try
                        End If

                    End If

                End If

            End If

            Dim frmStatusMessage As New frmStatus

            If Picking = False OrElse TipoDocumento = 2 OrElse TipoDocumento = 4 Then
                If VentaNueva Then
                    frmStatusMessage.Show("Imprimiendo...")
                    imprimeTicket(TipoDocumento, VENClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, SaldoVenta, VentaNueva)

                    'Ciclo para impresion de copias
                    If NumCopias > 0 Then
                        Dim i As Integer
                        For i = 1 To NumCopias
                            imprimeTicket(TipoDocumento, VENClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, SaldoVenta, VentaNueva)
                        Next
                    End If

                    frmStatusMessage.Dispose()

                Else
                    Select Case MessageBox.Show("¿Desea Reimprimir el Ticket?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            frmStatusMessage.Show("Imprimiendo...")
                            imprimeTicket(TipoDocumento, VENClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, SaldoVenta, VentaNueva)
                            frmStatusMessage.Dispose()
                    End Select
                End If

            Else
                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    'Imprime hoja de picking
                    If EstadoDocumento = iEstado.Picking AndAlso Movilidad = False Then
                        If VentaNueva Then
                            ModPOS.ImprimirSurtido(1, VENClave, PRNClavePic)
                        Else
                            Select Case MessageBox.Show("¿Desea Reimprimir la Hoja de Recolección?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.Yes
                                    ModPOS.ImprimirSurtido(1, VENClave, PRNClavePic)
                            End Select
                        End If
                    End If
                End If
            End If

            VentaCerrada = True
            btnCliente.Enabled = False
            btnBuscaCte.Enabled = False
            cmbSucursal.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = False
            btnEnvio.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            VentaNueva = False



            'Solicita Retiro de Caja
            If Picking = False Then
                If VentaCerrada AndAlso Caja AndAlso TotalRecibido > 0 Then
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
                                a.SUCClave = SucursalSurtido
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

        'AGREGA DESCUENTOS DE CLIENTE
        Dim dtDescuentoCte As DataTable = ModPOS.SiExisteRecupera("sp_descuentos_venta_close", "@VENClave", Venta)
        If Not dtDescuentoCte Is Nothing Then

            Dim iTipo, i As Integer
            Dim dDescuentoPorc, dImporte As Double

            lineasImpresas += dtDescuentoCte.Rows.Count

            For i = 0 To dtDescuentoCte.Rows.Count - 1

                iTipo = dtDescuentoCte.Rows(i)("Tipo")
                dDescuentoPorc = dtDescuentoCte.Rows(i)("DescuentoPorc")
                dImporte = dtDescuentoCte.Rows(i)("Importe")

                Tickets.AddItem(iTipo, dDescuentoPorc, dImporte)
            Next
            dtDescuentoCte.Dispose()

        End If


        dTotalVenta += Redondeo

        Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, TotalCambio, Saldo, 1)

        lineasImpresas += 5


        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, lineasImpresas)

    End Function

    Private Function imprimeTicket(ByVal TipoDoc As Integer, ByVal Venta As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Redondeo As Double, ByVal Saldo As Double, ByVal NuevaVenta As Boolean) As Boolean
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


        If TipoDoc = 2 Then
            Tickets.AddHeaderLine("*** COTIZACION ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
            lineasImpresas += 1
        ElseIf TipoDoc = 3 Then
            Tickets.AddHeaderLine("***  CREDITO  ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
            lineasImpresas += 1
        ElseIf TipoDoc = 4 Then
            Tickets.AddHeaderLine("***  APARTADO  ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
            lineasImpresas += 1
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

        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_vta_open", "@VENClave", Venta)


        Tickets.AddSubHeaderLine(" TICKET # " & dtVenta.Rows(0)("Folio"), 1, 3)
        lineasImpresas += 1

        If TipoDoc = 3 AndAlso CTEClaveActual = CreditoGeneral AndAlso NotaCreditos <> "" Then
            Tickets.AddSubHeaderLine("CTE: " & NotaCreditos, 0, 3)
            lineasImpresas += 1
        Else
            Tickets.AddSubHeaderLine("CTE: " & dtVenta.Rows(0)("RazonSocial"), 0, 3)
            lineasImpresas += 1
        End If

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
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", Venta)

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
                Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
                Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")
                Dim kglt As Integer = dtVentaDetalle.Rows(i)("KgLt")
                Dim UnidadesKilo As Double = dtVentaDetalle.Rows(i)("UndKilo")

                If kglt = 1 Then
                    sNombre &= " " & CStr(UnidadesKilo) & "Und(s)"
                End If

                Dim dImporteNeto As Double = ModPOS.Redondear(dPrecioBruto * (1 + dImpuestoPorc), 2)

                ' AGREGAR PRODUCTO A LISTA
                Tickets.AddItem(sDVEClave, sGTIN, sNombre, dCantidad, dImporteNeto, dDescuentoImp)

                dTotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)
                ' dTotalPuntos += (dPuntosImp * dCantidad)
                dTotalVenta += (dTotal)
            Next
            dtVentaDetalle.Dispose()
        End If

        'AGREGA DESCUENTOS DE CLIENTE
        Dim dtDescuentoCte As DataTable = ModPOS.SiExisteRecupera("sp_descuentos_venta", "@VENClave", Venta)
        If Not dtDescuentoCte Is Nothing Then

            Dim iTipo, i As Integer
            Dim dDescuentoPorc, dImporte As Double

            lineasImpresas += dtDescuentoCte.Rows.Count

            For i = 0 To dtDescuentoCte.Rows.Count - 1

                iTipo = dtDescuentoCte.Rows(i)("Tipo")
                dDescuentoPorc = dtDescuentoCte.Rows(i)("DescuentoPorc")
                dImporte = dtDescuentoCte.Rows(i)("Importe")

                Tickets.AddItem(iTipo, dDescuentoPorc, dImporte)
            Next
            dtDescuentoCte.Dispose()

        End If


        dTotalVenta += Redondeo

        Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, TotalCambio, Saldo, 1)

        lineasImpresas += 5

        If TotalRecibido > 0 Then
            Dim i As Integer
            Dim sTipo, sBanco, sReferencia As String
            Dim dtMetodospago As DataTable
            dtMetodospago = ModPOS.Recupera_Tabla("sp_metodospago_venta", "@VENClave", Venta)
            For i = 0 To dtMetodospago.Rows.Count - 1

                sTipo = dtMetodospago.Rows(i)("Tipo")
                sBanco = IIf(dtMetodospago.Rows(i)("Banco").GetType.Name = "DBNull", "", dtMetodospago.Rows(i)("Banco"))
                sReferencia = IIf(dtMetodospago.Rows(i)("Referencia").GetType.Name = "DBNull", "", dtMetodospago.Rows(i)("Referencia"))

                Tickets.AddMetodoPago(sTipo, sBanco, sReferencia, i)

                If sBanco = "" Then
                    lineasImpresas += 2
                Else
                    lineasImpresas += 3
                End If
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

    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaTicket.Click
        Dim SeCancela As Boolean = False
        If TotalArticulos > 0 Then
            If TotalVenta = SaldoVenta Then

                Dim a As New MeAutorizacion
                a.Sucursal = SucursalSurtido
                a.MontodeAutorizacion = TotalVenta
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


                EstadoDocumento = iEstado.Cancelada

                If Not VentaCerrada Then
                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido)
                    ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento)
                    ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                Else

                    If Picking = True Then
                        'Verifica si esta en proceso de picking
                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0)("Estado") = 8 Then
                                MessageBox.Show("El pedido seleccionado No puede ser Cancelado debido a que se encuentra en proceso de recolección", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If
                    End If

                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", TipoDocumento)

                    If (TipoDocumento = 1 OrElse TipoDocumento = 3) Then
                        If Picking = False Then
                            ModPOS.GeneraMovInv(1, 5, 1, VENClave, AlmacenSurtido, LblFolio.Text, Autoriza)
                            ModPOS.ActualizaExistAlm(1, 1, VENClave, AlmacenSurtido)
                            ModPOS.ActualizaExistUbc(1, 1, VENClave, AlmacenSurtido)
                        ElseIf ALMClave = AlmacenSurtido Then
                            ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", 1, "@DOCClave", VENClave, "@ALMClave", ALMClave)
                        End If
                    End If

                    If TipoDocumento <> 2 Then
                        ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", VENClave, "@Tipo", 1)
                        If TipoDocumento = 1 OrElse TipoDocumento = 3 OrElse TipoDocumento = 4 Then
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                        End If
                    End If
                End If

                Dim frmStatusMessage As New frmStatus

                frmStatusMessage.Show("Imprimiendo...")
                imprimeCancelado(VENClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, SaldoVenta, VentaNueva)

                frmStatusMessage.Dispose()


                SeCancela = True

            Else
                MsgBox("No se puede cancelar el ticket debido a que tiene pagos aplicados. Realice una devolución de producto", MsgBoxStyle.Information, "Información")
                Exit Sub
            End If
        Else

            EstadoDocumento = iEstado.Cancelada

            Dim NextFolio As Integer
            Dim strFolio() As String = Split(LblFolio.Text, "-")
            Dim iFolio As Integer

            Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

            If Not dt Is Nothing Then
                NextFolio = CInt(dt.Rows(0)("UltimoConsecutivo"))
                dt.Dispose()
            End If

            If strFolio(1) <> "" Then
                iFolio = CInt(strFolio(1))
            Else
                iFolio = NextFolio
            End If


            If NextFolio = iFolio Then
                ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
            Else
                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido)
                ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento)
                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)
            End If
            SeCancela = True
        End If

        If SeCancela Then
            VentaCerrada = True
            btnCliente.Enabled = False
            cmbSucursal.Enabled = False
            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = False
            btnEnvio.Enabled = False
            BtnCerrar.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            GeneraMovSalida = False

            If GridView = 1 Then
                dtPedidoDetalle.Clear()
            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)
            End If

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
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim
                End If
            End If

            LblFolio.Text = Referencia & "-0"

            cambiaStatus("", iEstado.Original)

            MsgBox("La Venta o Cotización ha sido cancelada exitosamente", MsgBoxStyle.Information, "Información")


        End If
    End Sub



    Private Sub BtnCancelaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaProducto.Click
        If Not VentaCerrada Then
            If TotalArticulos > 0 Then
                Dim a As New FrmCancelaProducto
                a.TipoDoc = TipoDocumento
                a.Almacen = AlmacenSurtido
                a.VentaClave = VENClave
                a.Picking = Me.Picking
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.SeCancela Then

                        TotalPuntos -= a.PuntosDetalle * a.CantidadCancelada
                        TotalAhorro -= (a.DescuentoDetalle * (1 + a.PorcImp)) * a.CantidadCancelada
                        TotalVenta -= a.PrecioNetoDetalle * a.CantidadCancelada
                        SaldoVenta = TotalVenta

                        If a.RestaArticulo Then
                            TotalArticulos -= 1
                        End If

                        AgregaCancelado(a.Partida, a.Descripcion, a.CantidadCancelada, a.PrecioNetoDetalle)

                        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                        LblCantidadArticulos.Text = CStr(TotalArticulos)
                        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                        If TotalArticulos = 0 Then
                            btnCliente.Enabled = True
                            cmbSucursal.Enabled = True
                            btnBuscaCte.Enabled = True
                            TxtCliente.Enabled = True
                            CambiarCliente = True
                        End If

                        If Moneda <> MonedaCambio Then
                            If TotalVenta > 0 Then
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                            End If
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
        If VentaCerrada OrElse TotalArticulos = 0 Then
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()
        End If
        Dim a As New FrmBuscaProducto
        a.SUCClave = Me.SUCClave
        a.ClienteActual = CTEClaveActual
        a.PuntodeVenta = PDVClave
        a.Almacen = AlmacenSurtido
        a.ListadePrecio = ListaPrecio
        a.StatusVenta = VentaCerrada
        a.TImpuesto = TImpuesto
        a.BusquedaInicial = True
        a.Busqueda = TxtProducto.Text.Trim.ToUpper
        a.TxtAlmacen.Text = sAlmacen
        a.bMessage = Me.bMessage


        a.ShowDialog()
        a.Dispose()

        TxtProducto.Focus()

        Me.bMessage = False

    End Sub

    Private Sub BtnGarantia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGarantia.Click
        Dim a As New FrmBuscaSerial
        a.ShowDialog()
        a.Dispose()
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
            ModPOS.Devolucion.ActivaDevolucion = ActivaDevolucion
        End If
        ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Devolucion.ShowDialog()
    End Sub

    Private Sub BtnOtrosDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtrosDocumentos.Click
        If VentaCerrada Then
            Me.CtxDocumentos.Items(1).Enabled = ActivarCotizacion
            BtnOtrosDocumentos.ContextMenuStrip.Show(BtnOtrosDocumentos, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
        Else
            Beep()
            MessageBox.Show("El documento actual no ha sido Cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()

    End Sub
    Private Sub BtnWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWait.Click
        Dim dtventa As DataTable

        dtventa = ModPOS.Recupera_Tabla("sp_recupera_ventawait", "@PDVClave", PDVClave)


        If Not VentaCerrada AndAlso TotalArticulos > 0 Then
            ModPOS.Ejecuta("sp_venta_wait", "@VENClave", VENClave)

            VentaCerrada = True
            btnCliente.Enabled = False
            cmbSucursal.Enabled = False
            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = False
            btnEnvio.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            BtnCerrar.Enabled = False

            cambiaStatus("", iEstado.Original)

            MsgBox("La Venta o Cotización ha sido puesta en espera exitosamente", MsgBoxStyle.Information, "Información")
            BtnWait.Text = "F10- Espera(" & CStr(dtventa.Rows.Count + 1) & ")"

        ElseIf VentaCerrada AndAlso dtventa.Rows.Count > 0 Then
            If dtventa.Rows.Count = 1 Then
                If dtventa.Rows(0)("ALMClave").GetType.Name = "DBNull" Then
                    AlmacenSurtido = ALMClave
                Else
                    AlmacenSurtido = dtventa.Rows(0)("ALMClave")
                End If
                recuperaVentaOpen(dtventa.Rows(0)("VENClave"), dtventa.Rows(0)("Folio"), dtventa.Rows(0)("Cliente"), dtventa.Rows(0)("RazonSocial"), dtventa.Rows(0)("Cajero"), dtventa.Rows(0)("NombreUsuario"), dtventa.Rows(0)("Saldo"), dtventa.Rows(0)("Total"), dtventa.Rows(0)("Tipo"), dtventa.Rows(0)("Estado"), dtventa.Rows(0)("LimiteCredito"), dtventa.Rows(0)("DiasCredito"), dtventa.Rows(0)("SaldoCliente"), dtventa.Rows.Count, AlmacenSurtido)
            Else
                Dim a As New FrmPedidosOpen
                a.dtVenta = dtventa
                a.Text = "Documentos en espera"
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    AlmacenSurtido = a.AlmacenSurtido
                    recuperaVentaOpen(a.VENClave, a.Folio, a.Cliente, a.RazonSocial, a.Cajero, a.NombreUsuario, a.Saldo, a.Total, a.Tipo, a.Estado, a.Limite, a.Dias, a.SaldoCliente, dtventa.Rows.Count, AlmacenSurtido)
            End If
                a.Dispose()
            End If
        End If
    End Sub


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
    ByVal Open As Integer, _
    ByVal sAlmacen As String)

        

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacen)

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


        txtLimite.Text = Limite
        txtDias.Text = Dias
        txtSaldo.Text = SaldoCliente

        Dim dtventadetalle As DataTable

        With Me
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0


            If GridView = 1 Then
                dtPedidoDetalle.Clear()
            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)
            End If

            'recupera ticket
            .VentaNueva = False
            .VENClave = sVENClave
            .LblFolio.Text = sFolio
            .CTEClaveActual = sCTEClave
            .CTENombreActual = sRazonSocial
            .LblCliente.Text = .CTENombreActual

            Dim sFol As String = sFolio

            .Folio = CInt(sFol.Split("-")(1))

            .AtiendeClave = sCajero
            .AtiendeNombre = sNombreUsuario
            .LblUsuario.Text = .AtiendeNombre
            .SaldoVenta = dSaldo
            .TotalVenta = Total
            .TipoDocumento = iTipo
            .EstadoDocumento = iEstado

            modificaStatus(TipoDocumento, EstadoDocumento)

            .VentaCerrada = False
            .GeneraMovSalida = True
            'recupera partida

            dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", .VENClave)
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
                    Dim dDescPorc, dDescImp As Double


                    Dim dImporteNeto As Double = ModPOS.Redondear((dPrecioBruto - dDescuentoImp) * (1 + dImpuestoPorc), 2)


                    Dim iKgLt As Integer = IIf(dtventadetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("KgLt"))
                    Dim dUndKilo As Double = IIf(dtventadetalle.Rows(0)("UndKilo").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("UndKilo"))

                    If dDescuentoImp > 0 Then
                        Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", sDVEClave)
                        If Not dtDescuento Is Nothing Then
                            dDescPorc = dtDescuento.Rows(0)("DescuentoPorc")
                            dDescImp = dtDescuento.Rows(0)("DescuentoImp")
                            dtDescuento.Dispose()
                        End If
                    Else
                        dDescPorc = 0
                        dDescImp = 0
                    End If

                    ' AGREGAR PRODUCTO A LISTA
                    .AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dPrecioBruto, dImpuestoPorc, dDescPorc, dDescImp, iKgLt, dUndKilo)
                    .TotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)
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

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If

                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", .CTEClaveActual)
                .ListaPrecio = dtCliente.Rows(0)("PREClave")
                .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()
                'Recupera los descuentos de cliente
                Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", .CTEClaveActual)
                If Not dtDescCte Is Nothing Then
                    .DescuentoCliente = dtDescCte.Rows(0)("Cascada")
                    .PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                    dtDescCte.Dispose()
                Else
                    .DescuentoCliente = -1
                    .PorcDescCliente = 0
                End If

                If .CambiarCliente = False Then
                    .btnCliente.Enabled = False
                    .cmbSucursal.Enabled = False
                    .btnBuscaCte.Enabled = False
                    .TxtCliente.Enabled = False
                End If

            End If
            ModPOS.Ejecuta("sp_venta_estado", "@VENClave", VENClave, "@Estado", 1)

            btnCliente.Enabled = True
            cmbSucursal.Enabled = True
            btnBuscaCte.Enabled = True
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            VentaCerrada = False
            VentaNueva = True
            GeneraMovSalida = True
            MsgBox("La Venta o Cotización  en espera ha sido recuperada exitosamente", MsgBoxStyle.Information, "Información")
            BtnWait.Text = "F10- Espera(" & CStr(Open - 1) & ")"

        End With
    End Sub

    Private Sub TxtTicket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTicket.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If VentaCerrada Then
                If Not TxtTicket.Text = vbNullString Then
                    recuperaTicket(1, TxtTicket.Text.Trim.ToUpper)
                    TxtTicket.Text = ""
                End If
            Else
                MsgBox("No es posible recuperar el ticket debido a que existe una venta activa", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

    Public Sub recuperaTicket(ByVal Tipo As Integer, ByVal Cadena As String)

        'Tipo 1 = Folio 2= VENClave

        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_venta_cerrada", "@Tipo", Tipo, "@Cadena", Cadena)

        If Not dtVenta Is Nothing Then

            btnCliente.Enabled = False
            cmbSucursal.Enabled = False
            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = True

            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True

            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False

            TxtCliente.Enabled = False
            VentaCerrada = True
            GeneraMovSalida = False
            VentaNueva = False

            If GridView = 1 Then
                dtPedidoDetalle.Clear()

            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)
            End If

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
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()

            If TipoDocumento = 2 OrElse TipoDocumento = 4 Then
                btnEnvio.Enabled = False
            End If

            If CambiarCliente = False Then
                btnCliente.Enabled = False
                cmbSucursal.Enabled = False
                btnBuscaCte.Enabled = False
                TxtCliente.Enabled = False
            End If

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
                    Dim dImpuestoImp As Double = dtVentaDetalle.Rows(i)("ImpuestoImp")
                    Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
                    Dim dPuntosImp As Double = dtVentaDetalle.Rows(i)("PuntosImp")
                    Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
                    Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")
                    Dim dDescPorc, dDescImp As Double

                    Dim dImporteNeto As Double = (dPrecioBruto - dDescuentoImp) * (1 + dImpuestoPorc)

                    Dim iKgLt As Integer = IIf(dtVentaDetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("KgLt"))
                    Dim dPeso As Double = IIf(dtVentaDetalle.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("Peso"))

                    If dDescuentoImp > 0 Then
                        Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", sDVEClave)
                        If Not dtDescuento Is Nothing Then
                            dDescPorc = dtDescuento.Rows(0)("DescuentoPorc")
                            dDescImp = dtDescuento.Rows(0)("DescuentoImp")
                            dtDescuento.Dispose()
                        End If
                    Else
                        dDescPorc = 0
                        dDescImp = 0
                    End If

                    ' AGREGAR PRODUCTO A LISTA
                    AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dImporteNeto, PorcImpProducto, dDescPorc, dImporteNeto * dDescPorc, iKgLt, dPeso)
                    TotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)

                Next
                dtVentaDetalle.Dispose()

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
            ModPOS.Ejecuta("sp_agrega_tmp_venta", "@VENClave", VENClave, "@PDVClave", PDVClave)
        Else
            MessageBox.Show("El ticket que intenta recuperar no existe o se encuentra totalmente pagado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaTicket.Click
        Dim a As New MeSearchCte
        a.ProcedimientoAlmacenado = "sp_search_ticket_venta"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.RequiereCaja = True
        a.Caja = Caja
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            recuperaTicket(2, a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub ItemApartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemApartado.Click

        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        If Moneda <> MonedaCambio Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        Else
            LblTipoCambio.Text = ""
        End If

        If CambiarCliente = False Then
            btnCliente.Enabled = True
            cmbSucursal.Enabled = True
            btnBuscaCte.Enabled = True
            TxtCliente.Enabled = True
            CambiarCliente = True
        End If

        ObtenerFolio()

        TipoDocumento = 4
        EstadoDocumento = 1


        modificaStatus(TipoDocumento, EstadoDocumento)

        VENClave = ModPOS.obtenerLlave()

        ModPOS.Ejecuta("sp_crea_venta", _
        "@VENClave", VENClave, _
        "@PDVClave", PDVClave, _
        "@Folio", LblFolio.Text, _
        "@Cliente", CTEClaveActual, _
        "@Cajero", AtiendeClave, _
        "@CAJClave", CAJClave, _
        "@Tipo", TipoDocumento, _
        "@Usuario", ModPOS.UsuarioActual)

        btnCliente.Enabled = True
        cmbSucursal.Enabled = True
        btnBuscaCte.Enabled = True
        BtnCancelaProducto.Enabled = True
        BtnCancelaTicket.Enabled = True
        btnEnvio.Enabled = False
        BtnCerrar.Enabled = True
        TxtCantidad.Enabled = True
        TxtProducto.Enabled = True
        TxtCliente.Enabled = True
        VentaCerrada = False
        GeneraMovSalida = False
        VentaNueva = True


        If GridView = 1 Then
            dtPedidoDetalle.Clear()
        Else
            LstVenta.Clear()
            LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)

            If sFrase <> "" Then
                LstVenta.Items.Add(sFrase)
            End If
            LstVenta.Items.Add("********** APARTADO DE PRODUCTOS **********")
            LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Blue

        End If

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

    Private Sub ItemCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCotizacion.Click
        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If ActivarCotizacion = True Then
            If SolicitaVendedor Then

                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
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
                btnCliente.Enabled = True
                cmbSucursal.Enabled = True
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                CambiarCliente = True
            End If

            ObtenerFolio()

            TipoDocumento = 2

            EstadoDocumento = 1


            modificaStatus(TipoDocumento, EstadoDocumento)


            VENClave = ModPOS.obtenerLlave()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@Usuario", ModPOS.UsuarioActual)

            btnCliente.Enabled = True
            btnBuscaCte.Enabled = True
            cmbSucursal.Enabled = True

            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = False
            VentaNueva = True

            If GridView = 1 Then
                dtPedidoDetalle.Clear()
            Else
                LstVenta.Clear()
                LstVenta.Columns.Add("Columna", 750, HorizontalAlignment.Left)

                If sFrase <> "" Then
                    LstVenta.Items.Add(sFrase)
                End If
                LstVenta.Items.Add("********** COTIZACIÓN **********")
                LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Blue
            End If

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



    Private Sub BtnApartados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApartados.Click
        Dim a As New FrmApartado
        a.CAJClave = CAJClave
        a.SUCClave = SucursalSurtido
        a.ALMClave = ALMClave
        a.AtiendeNombre = AtiendeNombre
        a.Impresora = Impresora
        a.PrintGeneric = PrintGeneric
        a.Recibo = Ticket
        a.Cajon = Cajon
        a.Picking = Picking
        a.PRNClavePic = PRNClavePic
        a.ShowDialog()
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


    Private Sub ItemCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCambio.Click
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
                        cambiaCliente(a.valor)
                    Else
                        MessageBox.Show("No es posible cambiar el cliente debido a que existen productos en el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
        a.Dispose()

    End Sub

    Private Sub btnEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnvio.Click
        Dim a As New FrmEnvio
        a.VENClave = Me.VENClave
        a.CTEClave = Me.CTEClaveActual
        a.ALMClave = Me.AlmacenSurtido
        a.VentaCerrada = Me.VentaCerrada
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        a.Dispose()

    End Sub

    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSalir.Click
        Me.Close()
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub



    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        If Not GridDetalle.GetValue(0) Is Nothing Then
            Dim a As New FrmConsultaGen
            a.Text = "Desglose de Precio"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_desglose_precio", "@DVEClave", GridDetalle.GetValue("DVEClave"))
            a.GridConsultaGen.GroupByBoxVisible = False
            a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
            a.GridConsultaGen.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub btnPromocion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPromocion.Click
        Dim a As New FrmConsultaGen
        a.Text = "Promociones y Descuentos Aplicados"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_desglose_promocion", "@VENClave", VENClave)
        a.GridConsultaGen.GroupByBoxVisible = False
        a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        btnCliente.ContextMenuStrip.Show(btnCliente, New Point(0, 0), ToolStripDropDownDirection.BelowLeft)
    End Sub

    Private Sub ItemEditarCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemEditarCte.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Modificar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtClave.ReadOnly = True
                .fromForm = "Venta"
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClaveActual)

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
                .Tel1 = dt.Rows(0)("Tel1")
                .Tel2 = dt.Rows(0)("Tel2")
                .email = dt.Rows(0)("Email")

                .Saldo = dt.Rows(0)("Saldo")
                .CreditoDisponible = dt.Rows(0)("Disponible")

                .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()

    End Sub

    Private Sub ItemNuevoCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemNuevoCte.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False
                .fromForm = "Venta"
                .ClienteInicial = Me.CTEClaveInicial
            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Public Sub cambiaCliente(ByVal sCTEClave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        TxtCliente.Text = ""
        CTEClaveActual = sCTEClave

        CTENombreActual = dt.Rows(0)("RazonSocial")
        LblCliente.Text = CTENombreActual

        txtLimite.Text = dt.Rows(0)("LimiteCredito")
        txtDias.Text = dt.Rows(0)("DiasCredito")
        txtSaldo.Text = dt.Rows(0)("Saldo")

        If CDbl(dt.Rows(0)("LimiteCredito")) > 0 Then
            convierteDocumento(3)
        Else
            convierteDocumento(1)
        End If

        dt.Dispose()

        ModPOS.Ejecuta("sp_actualiza_PDVCliente", _
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
                cambiaCliente(CTEClaveInicial)
            End If
        End If

        TxtProducto.Focus()

    End Sub

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
End Class
