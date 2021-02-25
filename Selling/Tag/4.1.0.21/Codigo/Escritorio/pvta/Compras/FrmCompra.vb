Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCompra
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
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProv As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtClaveProv As System.Windows.Forms.TextBox
    Friend WithEvents TxtIVA As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtFolioFactura As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnAddProv As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbFechaCompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFechaVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaPedido As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCreditoDisp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtSugerido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Selling.StoreCombo
    Friend WithEvents ChkFase As Selling.ChkStatus
    Friend WithEvents BtnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As Selling.StoreCombo
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents chkImpuesto As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCosto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDscto As System.Windows.Forms.TextBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtTotalPza As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtClaveSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompra))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtSolicita = New System.Windows.Forms.TextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.cmbAlmacen = New Selling.StoreCombo()
        Me.cmbSucursal = New Selling.StoreCombo()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ChkFase = New Selling.ChkStatus(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtCreditoDisp = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BtnBuscaPedido = New Janus.Windows.EditControls.UIButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFechaVencimiento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbFechaCompra = New System.Windows.Forms.DateTimePicker()
        Me.BtnAddProv = New Janus.Windows.EditControls.UIButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFolioFactura = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.BtnBuscaProv = New Janus.Windows.EditControls.UIButton()
        Me.TxtOrden = New System.Windows.Forms.TextBox()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClaveProv = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.chkImpuesto = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCosto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.BtnImportar = New Janus.Windows.EditControls.UIButton()
        Me.cmbUnidad = New Selling.StoreCombo()
        Me.TxtSugerido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnAddProd = New Janus.Windows.EditControls.UIButton()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtSubtotal = New System.Windows.Forms.TextBox()
        Me.TxtIVA = New System.Windows.Forms.TextBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblIVA = New System.Windows.Forms.Label()
        Me.LblSubtotal = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDscto = New System.Windows.Forms.TextBox()
        Me.txtTotalPza = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtClaveSAT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label15)
        Me.GrpGeneral.Controls.Add(Me.TxtNota)
        Me.GrpGeneral.Controls.Add(Me.Label14)
        Me.GrpGeneral.Controls.Add(Me.TxtSolicita)
        Me.GrpGeneral.Controls.Add(Me.PictureBox5)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.TxtMotivo)
        Me.GrpGeneral.Controls.Add(Me.cmbAlmacen)
        Me.GrpGeneral.Controls.Add(Me.cmbSucursal)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.ChkFase)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.TxtCreditoDisp)
        Me.GrpGeneral.Controls.Add(Me.Label10)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaPedido)
        Me.GrpGeneral.Controls.Add(Me.Label8)
        Me.GrpGeneral.Controls.Add(Me.TxtDiasCredito)
        Me.GrpGeneral.Controls.Add(Me.Label7)
        Me.GrpGeneral.Controls.Add(Me.TxtFechaVencimiento)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.CmbFechaCompra)
        Me.GrpGeneral.Controls.Add(Me.BtnAddProv)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.TxtFolioFactura)
        Me.GrpGeneral.Controls.Add(Me.LblNombre)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaProv)
        Me.GrpGeneral.Controls.Add(Me.TxtOrden)
        Me.GrpGeneral.Controls.Add(Me.TxtRazonSocial)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.TxtClaveProv)
        Me.GrpGeneral.Controls.Add(Me.Label9)
        Me.GrpGeneral.Controls.Add(Me.Label13)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(778, 201)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(7, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 15)
        Me.Label15.TabIndex = 127
        Me.Label15.Text = "Nota"
        '
        'TxtNota
        '
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(104, 173)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(542, 21)
        Me.TxtNota.TabIndex = 126
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(399, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "Solicita"
        '
        'TxtSolicita
        '
        Me.TxtSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSolicita.Location = New System.Drawing.Point(468, 147)
        Me.TxtSolicita.Name = "TxtSolicita"
        Me.TxtSolicita.Size = New System.Drawing.Size(290, 21)
        Me.TxtSolicita.TabIndex = 124
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(76, 148)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(30, 18)
        Me.PictureBox5.TabIndex = 118
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Motivo"
        '
        'TxtMotivo
        '
        Me.TxtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotivo.Location = New System.Drawing.Point(104, 146)
        Me.TxtMotivo.Name = "TxtMotivo"
        Me.TxtMotivo.Size = New System.Drawing.Size(290, 21)
        Me.TxtMotivo.TabIndex = 122
        '
        'cmbAlmacen
        '
        Me.cmbAlmacen.Location = New System.Drawing.Point(468, 121)
        Me.cmbAlmacen.Name = "cmbAlmacen"
        Me.cmbAlmacen.Size = New System.Drawing.Size(290, 21)
        Me.cmbAlmacen.TabIndex = 121
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Location = New System.Drawing.Point(104, 121)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(290, 21)
        Me.cmbSucursal.TabIndex = 119
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(437, 121)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 22)
        Me.PictureBox4.TabIndex = 117
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'ChkFase
        '
        Me.ChkFase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkFase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkFase.Location = New System.Drawing.Point(562, 19)
        Me.ChkFase.Name = "ChkFase"
        Me.ChkFase.Size = New System.Drawing.Size(84, 15)
        Me.ChkFase.TabIndex = 95
        Me.ChkFase.Text = "Confirmada"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(76, 121)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 21)
        Me.PictureBox3.TabIndex = 116
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(76, 71)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 24)
        Me.PictureBox2.TabIndex = 115
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(76, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtCreditoDisp
        '
        Me.TxtCreditoDisp.Enabled = False
        Me.TxtCreditoDisp.Location = New System.Drawing.Point(104, 96)
        Me.TxtCreditoDisp.Name = "TxtCreditoDisp"
        Me.TxtCreditoDisp.ReadOnly = True
        Me.TxtCreditoDisp.Size = New System.Drawing.Size(113, 20)
        Me.TxtCreditoDisp.TabIndex = 111
        Me.TxtCreditoDisp.Text = "0.00"
        Me.TxtCreditoDisp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCreditoDisp.Value = 0.0R
        Me.TxtCreditoDisp.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 16)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Crédito Disponible"
        '
        'BtnBuscaPedido
        '
        Me.BtnBuscaPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaPedido.Image = CType(resources.GetObject("BtnBuscaPedido.Image"), System.Drawing.Image)
        Me.BtnBuscaPedido.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaPedido.Location = New System.Drawing.Point(655, 41)
        Me.BtnBuscaPedido.Name = "BtnBuscaPedido"
        Me.BtnBuscaPedido.Size = New System.Drawing.Size(40, 24)
        Me.BtnBuscaPedido.TabIndex = 109
        Me.BtnBuscaPedido.ToolTipText = "Busqueda de Orden de Compra"
        Me.BtnBuscaPedido.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.Location = New System.Drawing.Point(399, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 16)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Fecha Vencimiento"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Enabled = False
        Me.TxtDiasCredito.Location = New System.Drawing.Point(320, 95)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.ReadOnly = True
        Me.TxtDiasCredito.Size = New System.Drawing.Size(54, 20)
        Me.TxtDiasCredito.TabIndex = 101
        Me.TxtDiasCredito.Text = "0"
        Me.TxtDiasCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDiasCredito.Value = 0
        Me.TxtDiasCredito.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(230, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Dias de Crédito"
        '
        'TxtFechaVencimiento
        '
        Me.TxtFechaVencimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFechaVencimiento.Enabled = False
        Me.TxtFechaVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFechaVencimiento.Location = New System.Drawing.Point(518, 96)
        Me.TxtFechaVencimiento.Multiline = True
        Me.TxtFechaVencimiento.Name = "TxtFechaVencimiento"
        Me.TxtFechaVencimiento.ReadOnly = True
        Me.TxtFechaVencimiento.Size = New System.Drawing.Size(128, 19)
        Me.TxtFechaVencimiento.TabIndex = 104
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Fecha Factura"
        '
        'CmbFechaCompra
        '
        Me.CmbFechaCompra.CustomFormat = "yyyyMMdd"
        Me.CmbFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaCompra.Location = New System.Drawing.Point(104, 46)
        Me.CmbFechaCompra.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaCompra.Name = "CmbFechaCompra"
        Me.CmbFechaCompra.Size = New System.Drawing.Size(113, 20)
        Me.CmbFechaCompra.TabIndex = 1
        Me.CmbFechaCompra.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnAddProv
        '
        Me.BtnAddProv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddProv.Image = CType(resources.GetObject("BtnAddProv.Image"), System.Drawing.Image)
        Me.BtnAddProv.Location = New System.Drawing.Point(704, 68)
        Me.BtnAddProv.Name = "BtnAddProv"
        Me.BtnAddProv.Size = New System.Drawing.Size(40, 24)
        Me.BtnAddProv.TabIndex = 4
        Me.BtnAddProv.ToolTipText = "Agregar Nuevo Proveedor"
        Me.BtnAddProv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(410, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Num. Orden de Compra"
        '
        'TxtFolioFactura
        '
        Me.TxtFolioFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolioFactura.Location = New System.Drawing.Point(104, 21)
        Me.TxtFolioFactura.Name = "TxtFolioFactura"
        Me.TxtFolioFactura.Size = New System.Drawing.Size(113, 21)
        Me.TxtFolioFactura.TabIndex = 5
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 23)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(57, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Factura"
        '
        'BtnBuscaProv
        '
        Me.BtnBuscaProv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProv.Image = CType(resources.GetObject("BtnBuscaProv.Image"), System.Drawing.Image)
        Me.BtnBuscaProv.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProv.Location = New System.Drawing.Point(655, 68)
        Me.BtnBuscaProv.Name = "BtnBuscaProv"
        Me.BtnBuscaProv.Size = New System.Drawing.Size(40, 24)
        Me.BtnBuscaProv.TabIndex = 3
        Me.BtnBuscaProv.ToolTipText = "Busqueda de Proveedor"
        Me.BtnBuscaProv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtOrden
        '
        Me.TxtOrden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrden.Location = New System.Drawing.Point(548, 43)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(98, 21)
        Me.TxtOrden.TabIndex = 0
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(223, 71)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(423, 19)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Prov. Cve."
        '
        'TxtClaveProv
        '
        Me.TxtClaveProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProv.Location = New System.Drawing.Point(104, 70)
        Me.TxtClaveProv.Name = "TxtClaveProv"
        Me.TxtClaveProv.Size = New System.Drawing.Size(113, 21)
        Me.TxtClaveProv.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(7, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 15)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Sucursal Destino"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(399, 124)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 15)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Almacén"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(10, 68)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 21)
        Me.PictureBox6.TabIndex = 128
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(598, 630)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 630)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.Label18)
        Me.GrpDetalle.Controls.Add(Me.txtClaveSAT)
        Me.GrpDetalle.Controls.Add(Me.BtnDel)
        Me.GrpDetalle.Controls.Add(Me.chkImpuesto)
        Me.GrpDetalle.Controls.Add(Me.Label16)
        Me.GrpDetalle.Controls.Add(Me.txtCosto)
        Me.GrpDetalle.Controls.Add(Me.PictureBox6)
        Me.GrpDetalle.Controls.Add(Me.BtnImportar)
        Me.GrpDetalle.Controls.Add(Me.cmbUnidad)
        Me.GrpDetalle.Controls.Add(Me.TxtSugerido)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnAddProd)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.Label11)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 211)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 311)
        Me.GrpDetalle.TabIndex = 2
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(732, 63)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(40, 24)
        Me.BtnDel.TabIndex = 133
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chkImpuesto
        '
        Me.chkImpuesto.AutoSize = True
        Me.chkImpuesto.Location = New System.Drawing.Point(204, 45)
        Me.chkImpuesto.Name = "chkImpuesto"
        Me.chkImpuesto.Size = New System.Drawing.Size(118, 17)
        Me.chkImpuesto.TabIndex = 5
        Me.chkImpuesto.Text = "Impuestos incluidos"
        Me.chkImpuesto.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 17)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "Precio"
        '
        'txtCosto
        '
        Me.txtCosto.DecimalDigits = 6
        Me.txtCosto.Location = New System.Drawing.Point(73, 42)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(123, 20)
        Me.txtCosto.TabIndex = 1
        Me.txtCosto.Text = "0.000000"
        Me.txtCosto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCosto.Value = 0.0R
        Me.txtCosto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnImportar
        '
        Me.BtnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImportar.Icon = CType(resources.GetObject("BtnImportar.Icon"), System.Drawing.Icon)
        Me.BtnImportar.Location = New System.Drawing.Point(683, 63)
        Me.BtnImportar.Name = "BtnImportar"
        Me.BtnImportar.Size = New System.Drawing.Size(40, 24)
        Me.BtnImportar.TabIndex = 130
        Me.BtnImportar.ToolTipText = "Importar el contenido de Compra desde un archico (*.csv)"
        Me.BtnImportar.Visible = False
        Me.BtnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbUnidad
        '
        Me.cmbUnidad.Location = New System.Drawing.Point(73, 66)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(123, 21)
        Me.cmbUnidad.TabIndex = 4
        '
        'TxtSugerido
        '
        Me.TxtSugerido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSugerido.Enabled = False
        Me.TxtSugerido.Location = New System.Drawing.Point(591, 67)
        Me.TxtSugerido.Name = "TxtSugerido"
        Me.TxtSugerido.Size = New System.Drawing.Size(89, 20)
        Me.TxtSugerido.TabIndex = 119
        Me.TxtSugerido.Text = "0.00"
        Me.TxtSugerido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtSugerido.Value = 0.0R
        Me.TxtSugerido.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(202, 67)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(90, 20)
        Me.TxtCantidad.TabIndex = 2
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnAddProd
        '
        Me.BtnAddProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddProd.Image = CType(resources.GetObject("BtnAddProd.Image"), System.Drawing.Image)
        Me.BtnAddProd.Location = New System.Drawing.Point(732, 13)
        Me.BtnAddProd.Name = "BtnAddProd"
        Me.BtnAddProd.Size = New System.Drawing.Size(40, 24)
        Me.BtnAddProd.TabIndex = 2
        Me.BtnAddProd.ToolTipText = "Agregar Nuevo Producto"
        Me.BtnAddProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(683, 12)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(40, 24)
        Me.BtnBuscaProd.TabIndex = 1
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(202, 15)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(478, 19)
        Me.TxtDescripcion.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Prod. Cve."
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(73, 15)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(123, 21)
        Me.TxtClaveProd.TabIndex = 0
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 96)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(765, 207)
        Me.GridDetalle.TabIndex = 3
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(518, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 17)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Cant. Max. "
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(639, 528)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(140, 21)
        Me.TxtSubtotal.TabIndex = 4
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIVA
        '
        Me.TxtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIVA.Enabled = False
        Me.TxtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIVA.Location = New System.Drawing.Point(639, 578)
        Me.TxtIVA.Name = "TxtIVA"
        Me.TxtIVA.ReadOnly = True
        Me.TxtIVA.Size = New System.Drawing.Size(140, 21)
        Me.TxtIVA.TabIndex = 16
        Me.TxtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(639, 603)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(140, 21)
        Me.TxtTotal.TabIndex = 17
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(583, 608)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(33, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(583, 583)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(57, 15)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Impuesto"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(583, 533)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(54, 15)
        Me.LblSubtotal.TabIndex = 92
        Me.LblSubtotal.Text = "Subtotal"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(583, 558)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 15)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Dsc."
        '
        'TxtDscto
        '
        Me.TxtDscto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDscto.Enabled = False
        Me.TxtDscto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDscto.Location = New System.Drawing.Point(639, 553)
        Me.TxtDscto.Name = "TxtDscto"
        Me.TxtDscto.ReadOnly = True
        Me.TxtDscto.Size = New System.Drawing.Size(140, 21)
        Me.TxtDscto.TabIndex = 93
        Me.TxtDscto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPza
        '
        Me.txtTotalPza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPza.Enabled = False
        Me.txtTotalPza.Location = New System.Drawing.Point(80, 530)
        Me.txtTotalPza.Name = "txtTotalPza"
        Me.txtTotalPza.Size = New System.Drawing.Size(87, 20)
        Me.txtTotalPza.TabIndex = 137
        Me.txtTotalPza.Text = "0.00"
        Me.txtTotalPza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalPza.Value = 0.0R
        Me.txtTotalPza.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(4, 533)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 18)
        Me.Label17.TabIndex = 138
        Me.Label17.Text = "Total Piezas"
        '
        'txtClaveSAT
        '
        Me.txtClaveSAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClaveSAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveSAT.Location = New System.Drawing.Point(375, 67)
        Me.txtClaveSAT.Name = "txtClaveSAT"
        Me.txtClaveSAT.Size = New System.Drawing.Size(123, 21)
        Me.txtClaveSAT.TabIndex = 134
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.Location = New System.Drawing.Point(312, 70)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 17)
        Me.Label18.TabIndex = 135
        Me.Label18.Text = "Cve. SAT"
        '
        'FrmCompra
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 673)
        Me.Controls.Add(Me.txtTotalPza)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDscto)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.TxtIVA)
        Me.Controls.Add(Me.TxtSubtotal)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.LblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmCompra"
        Me.Text = "Compra"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String
    Public SUCClave As String
    Public ALMClave As String
    Public COMClave As String
    Public ORDClave As String = ""
    Public Folio As String
    Public ORDFolio As String
    Public PRVClave As String
    Public Credito As Integer
    Public DiasCredito As Integer
    Public FechaCompra As DateTime
    Public FechaVencimiento As DateTime
    Public CostoTot As Double
    Public SubTotal As Double
    Public Descuento As Double
    Public Impuesto As Double
    Public Total As Double
    Public Saldo As Double
    Public Estado As Integer
    Public Fase As Boolean = True
    Public Motivo, Solicita, Nota As String

    Private ActPreCompra As Integer = 0
    Private InterfazSalida As String
    Private sORDClave As String
    Private sPRVClave As String
    Private bUpdDetalle As Boolean = False

    Private Cantidad As Double
    Private PROClave As String
    Private Clave As String
    Private Costo As Double
    Private Nombre, ClaveSAT As String
    Private IVA As Double
    Private Seguimiento As Integer
    Private DiasGarantia As Integer
    Private TProducto As Integer
    Private TCosto As Integer
    Private CostoVigente As Double
    Private Aduana As String
    Private NumDecimales As Integer
    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private TImpuesto As Integer
    Private bload As Boolean = False
    Private dtDetalle As DataTable

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If TxtFolioFactura.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If sPRVClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtMotivo.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 AndAlso Total <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
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

    Public Sub recuperaProducto(ByVal sClave As String)

        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace)
        If Not dtProducto Is Nothing Then


            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            IVA = ModPOS.RecuperaImpuesto(cmbSucursal.SelectedValue, PROClave, TImpuesto)
            Seguimiento = dtProducto.Rows(0)("Seguimiento")
            DiasGarantia = dtProducto.Rows(0)("DiasGarantia")
            TProducto = dtProducto.Rows(0)("TProducto")
            NumDecimales = dtProducto.Rows(0)("Num_Decimales")
            ClaveSAT = dtProducto.Rows(0)("ClaveSAT")
            dtProducto.Dispose()
            Me.TxtDescripcion.Text = Nombre
            TxtCantidad.DecimalDigits = NumDecimales

            Dim dtRec As DataTable = ModPOS.SiExisteRecupera("sp_obtener_maximo_recomendado", "@SUCClave", cmbSucursal.SelectedValue, "@ALMClave", cmbAlmacen.SelectedValue, "@PROClave", PROClave)
            If Not dtRec Is Nothing Then
                TxtSugerido.Text = CStr(Redondear(dtRec.Rows(0)("Recomendado"), 2))
                dtRec.Dispose()
            Else
                TxtSugerido.Text = "0.00"
            End If


            txtClaveSAT.Text = ClaveSAT
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre
            txtCosto.Focus()

            With Me.cmbUnidad
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_unidad_vta"
                .NombreParametro1 = "PROClave"
                .Parametro1 = PROClave
                .llenar()
            End With


            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("Clave = '" & sClave & "'")

            If foundRows.Length = 1 Then
                txtCosto.Text = foundRows(0)("Costo")
                txtCosto.ReadOnly = True
            Else
                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_obtener_costo", "@SUCClave", SUCClave, "@PROClave", PROClave)
                Me.txtCosto.Text = dt.Rows(0)("CostoVigente")
                dt.Dispose()
                txtCosto.ReadOnly = False
            End If

        Else
            ClaveSAT = ""
            PROClave = ""
            Cantidad = 0
            Clave = ""
            IVA = 0
            txtCosto.ReadOnly = False

            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If



    End Sub

    Public Sub CargaDatosProveedor(ByVal Clave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_proveedor", "@Clave", Clave, "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            sPRVClave = dt.Rows(0)("PRVClave")
            TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
            DiasCredito = dt.Rows(0)("DiasCredito")
            TxtDiasCredito.Text = DiasCredito
            TxtCreditoDisp.Text = dt.Rows(0)("LimiteCredito") - dt.Rows(0)("Saldo")
            CmbFechaCompra.Focus()
            TxtClaveProv.Text = Clave
            TImpuesto = dt.Rows(0)("TImpuesto")
        Else
            MsgBox("No se encontro un proveedor que coincida con la clave proporcionada")
            TxtRazonSocial.Text = ""
            sPRVClave = ""
            TxtCreditoDisp.Text = ""
            TxtDiasCredito.Text = ""
        End If
        dt.Dispose()
    End Sub

    Private Sub FrmCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Costeo"
                        TCosto = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))

                    Case "ActPreCompra"
                        ActPreCompra = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        With cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        bload = True

        With cmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_alm_def"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(cmbSucursal.SelectedValue Is Nothing, "", cmbSucursal.SelectedValue)
            .llenar()
        End With


        ChkFase.Checked = Fase

      

        If Padre = "Nuevo" Then

            If ModPOS.SucursalPredeterminada <> "" Then
                cmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
            End If

            TxtSolicita.Text = MPrincipal.StUsuario.Text
            CmbFechaCompra.Value = Today
            TxtFechaVencimiento.Text = CmbFechaCompra.Value.ToShortDateString
            dtDetalle = ModPOS.CrearTabla("CompraDetalle", "ID", "System.String", _
                                         "fila", "System.Int32", _
                                        "Cantidad", "System.Double", _
                                        "Clave", "System.String", _
                                        "Nombre", "System.String", _
                                        "Costo", "System.Double", _
                                        "Precio", "System.Double", _
                                        "Dsc1", "System.Double", _
                                        "Dsc2", "System.Double", _
                                        "Dsc3", "System.Double", _
                                        "Dsc4", "System.Double", _
                                        "Bon", "System.Double", _
                                        "PorcIVA", "System.Double", _
                                        "Dscto", "System.Double", _
                                        "IVA", "System.Double", _
                                        "Importe", "System.Double", _
                                        "Seguimiento", "System.Int32", _
                                        "DiasGarantia", "System.Int32", _
                                        "TProducto", "System.Int32", _
                                        "CostoTot", "System.Double", _
                                        "Subtotal", "System.Double", _
                                        "Descuento", "System.Double", _
                                        "Impuesto", "System.Double")

        Else



            If Fase = True Then
                ChkFase.Enabled = False
            End If

            sORDClave = ORDClave
            sPRVClave = PRVClave

            Me.TxtFolioFactura.Text = Folio

            cmbSucursal.SelectedValue = SUCClave
            cmbAlmacen.SelectedValue = ALMClave

            Me.CmbFechaCompra.Value = FechaCompra
            TxtFechaVencimiento.Text = FechaVencimiento.ToShortDateString

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_compra", "@COMClave", COMClave)


            TxtMotivo.Text = Motivo
            TxtSolicita.Text = Solicita
            TxtNota.Text = Nota

            If dtDetalle.Rows.Count > 0 Then
                cmbSucursal.Enabled = False
                TxtClaveProv.Enabled = False
                BtnBuscaProv.Enabled = False
                BtnAddProv.Enabled = False
                TxtOrden.Enabled = False
                BtnBuscaPedido.Enabled = False
            End If

            GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False


            If dtDetalle.Rows.Count > 0 Then
                txtTotalPza.Text = dtDetalle.Compute("Sum(Cantidad)", "Cantidad > 0")
            Else
                txtTotalPza.Text = 0
            End If

        End If


        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False

        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.CurrentTable.Columns("Dscto").Selectable = False
        GridDetalle.RootTable.Columns("PorcIVA").Visible = False
        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.CurrentTable.Columns("CostoTot").Visible = False
        GridDetalle.CurrentTable.Columns("Subtotal").Visible = False
        GridDetalle.CurrentTable.Columns("Descuento").Visible = False
        GridDetalle.CurrentTable.Columns("Impuesto").Visible = False
        '  GridDetalle.CurrentTable.Columns("fila").Visible = True

        GridDetalle.CurrentTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Precio").Selectable = False
        GridDetalle.CurrentTable.Columns("IVA").Selectable = False
        GridDetalle.RootTable.Columns("Importe").Selectable = False

        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Dsc1").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Dsc2").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Dsc3").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Dsc4").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Bon").FormatString = "0.00"


        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Descuento = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
        SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTot"), Janus.Windows.GridEX.AggregateFunction.Sum)

        TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
        TxtDscto.Text = Format(CStr(ModPOS.TruncateToDecimal(Descuento, 2)), "Currency")
        TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
        TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")


    End Sub

    Private Sub FrmCompra_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCompras Is Nothing Then

            If Not ModPOS.MtoCompras.CmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoCompras.Periodo > 0 AndAlso MtoCompras.Mes > 0 Then
                ModPOS.MtoCompras.refrescaGrid()
            End If
        End If

        ModPOS.Compras.Dispose()
        ModPOS.Compras = Nothing
    End Sub

    Private Sub BtnBuscaProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProv.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_proveedor"
        a.TablaCmb = "Proveedor"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.NumColDes2 = 4
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            CargaDatosProveedor(a.Descripcion)
        End If
        a.Dispose()
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()

        Else
            MessageBox.Show("¡la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If

    End Sub

    Private Sub BtnAddProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProv.Click
        If ModPOS.Proveedor Is Nothing Then
            ModPOS.Proveedor = New FrmProveedor
            With ModPOS.Proveedor
                .Text = "Agregar Proveedor"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .FromForm = "Compra"
                .UiTabSaldos.Enabled = False
            End With
        End If
        ModPOS.Proveedor.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Proveedor.Show()
        ModPOS.Proveedor.BringToFront()

    End Sub

    Private Sub BtnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProd.Click
        If ModPOS.Producto Is Nothing Then
            ModPOS.Producto = New FrmProducto
            With ModPOS.Producto
                .Text = "Agregar Producto"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabCosto.Enabled = False
                .UiTabKits.Enabled = True
                .UiTabEquivalentes.Enabled = True
                .ChkEstado.Enabled = False
                .TxtClave.Focus()
                .FromForm = "Compra"
            End With
        End If
        ModPOS.Producto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Producto.Show()
        ModPOS.Producto.BringToFront()

    End Sub

    Private Sub CmbFechaCompra_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFechaCompra.ValueChanged
        FechaVencimiento = CmbFechaCompra.Value.AddDays(DiasCredito)
        TxtFechaVencimiento.Text = FechaVencimiento.ToShortDateString
    End Sub

    Private Sub TxtClaveProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProv.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TxtClaveProv.Text = vbNullString Then
                CargaDatosProveedor(TxtClaveProv.Text.ToUpper.Trim.Replace("'", "''"))
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del proveedor
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_proveedor"
            a.TablaCmb = "Proveedor"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.NumColDes2 = 4
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProv.Text.Trim.ToUpper
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                CargaDatosProveedor(a.Descripcion)
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" AndAlso Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            Else
                MessageBox.Show("¡Clave de producto, la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If Not cmbSucursal.SelectedValue Is Nothing AndAlso sPRVClave <> "" Then
                'Busca y recupera los datos del producto


                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.bReplace = True
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
                a.CompaniaRequerido = True
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    recuperaProducto(a.valor)
                End If
                a.Dispose()

            Else
                MessageBox.Show("¡la sucursal y el proveedor son requeridos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub cmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedValueChanged
        If Not cmbSucursal.SelectedValue Is Nothing AndAlso bload Then
            With cmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_filtra_alm_def"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = cmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TxCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown

        If e.KeyCode = Keys.Enter Then

            If System.String.IsNullOrEmpty(PROClave) Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("ID = '" & PROClave & "'")

                If foundRows.Length = 0 Then

                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))

                    If Cantidad > 0 Then

                        If chkImpuesto.Checked = True Then
                            Costo = Math.Abs(CDbl(txtCosto.Text) / (1 + IVA))
                        Else
                            Costo = Math.Abs(CDbl(txtCosto.Text))
                        End If

                        If Not cmbUnidad.SelectedValue Is Nothing Then
                            Cantidad = CDbl(cmbUnidad.SelectedValue) * Cantidad
                        End If

                        bUpdDetalle = True
                        Dim row1 As DataRow
                        row1 = dtDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("ID") = PROClave
                        row1.Item("fila") = (dtDetalle.Rows.Count + 1) * 10
                        row1.Item("Cantidad") = Cantidad
                        row1.Item("Clave") = Clave
                        row1.Item("Nombre") = Nombre
                        row1.Item("Costo") = Redondear(Costo, 6)
                        row1.Item("Precio") = Redondear(Costo, 6)
                        row1.Item("Dsc1") = 0.0
                        row1.Item("Dsc2") = 0.0
                        row1.Item("Dsc3") = 0.0
                        row1.Item("Dsc4") = 0.0
                        row1.Item("Bon") = 0.0
                        row1.Item("Dscto") = 0.0
                        row1.Item("PorcIVA") = IVA
                        row1.Item("IVA") = Redondear(Costo * IVA, 6)
                        row1.Item("Importe") = Redondear(Cantidad * (Costo * (1 + IVA)), 6)
                        row1.Item("Seguimiento") = Seguimiento
                        row1.Item("DiasGarantia") = DiasGarantia
                        row1.Item("TProducto") = TProducto
                        'Totalizar 
                        row1.Item("Subtotal") = Redondear(Cantidad * Costo, 6)
                        row1.Item("Descuento") = 0.0
                        row1.Item("Impuesto") = Redondear(Cantidad * (Costo * IVA), 6)

                        dtDetalle.Rows.Add(row1)
                        'agrega la fila completo a la tabla

                        If txtClaveSAT.Text <> ClaveSAT Then
                            ModPOS.Ejecuta("st_act_cvesat", "@PROClave", PROClave, "@ClaveSAT", txtClaveSAT.Text, "@Usuario", ModPOS.UsuarioActual)
                        End If


                        txtClaveSAT.Text = ""
                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        txtCosto.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        IVA = 0

                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
                        TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
                        TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")



                        If dtDetalle.Rows.Count = 1 Then
                            cmbSucursal.Enabled = False
                            TxtClaveProv.Enabled = False
                            BtnBuscaProv.Enabled = False
                            BtnAddProv.Enabled = False
                            TxtOrden.Enabled = False
                            BtnBuscaPedido.Enabled = False
                        End If

                        If dtDetalle.Rows.Count > 0 Then
                            txtTotalPza.Text = dtDetalle.Compute("Sum(Cantidad)", "Cantidad > 0")
                        Else
                            txtTotalPza.Text = 0
                        End If

                        TxtClaveProd.Focus()

                    Else
                        MessageBox.Show("¡La Cantidad de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    MessageBox.Show("¡El producto que intenta agregar ya existe en la compara actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            End If
        End If

    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        Dim dPrecio, dCostoNeto, dCantidadNeta, dCostoTot, dDscto, dIVA, dImporte, dSubtotal, dDescuento, dImpuesto As Double

        Select Case GridDetalle.CurrentColumn.Caption
            Case "Costo"
                If Not (IsNumeric(GridDetalle.GetValue("Costo")) AndAlso CDbl(GridDetalle.GetValue("Costo")) > 0) Then
                    GridDetalle.SetValue("Costo", GridDetalle.GetValue("Precio"))
                Else
                    GridDetalle.SetValue("Precio", GridDetalle.GetValue("Costo"))
                End If

            Case "Cantidad"
                If Not (IsNumeric(GridDetalle.GetValue("Cantidad")) AndAlso CDbl(GridDetalle.GetValue("Cantidad")) > 0) Then
                    GridDetalle.SetValue("Cantidad", 1)
                End If

            Case "Dsc1"
                If Not (IsNumeric(GridDetalle.GetValue("Dsc1")) AndAlso CDbl(GridDetalle.GetValue("Dsc1")) > 0) Then
                    GridDetalle.SetValue("Dsc1", 0)
                ElseIf CDbl(GridDetalle.GetValue("Costo")) <= 0 Then
                    GridDetalle.SetValue("Dsc1", 0)
                End If

            Case "Dsc2"
                If Not (IsNumeric(GridDetalle.GetValue("Dsc2")) AndAlso CDbl(GridDetalle.GetValue("Dsc2")) > 0) Then
                    GridDetalle.SetValue("Dsc2", 0)
                ElseIf CDbl(GridDetalle.GetValue("Costo")) <= 0 Then
                    GridDetalle.SetValue("Dsc2", 0)

                End If

            Case "Dsc3"
                If Not (IsNumeric(GridDetalle.GetValue("Dsc3")) AndAlso CDbl(GridDetalle.GetValue("Dsc3")) > 0) Then
                    GridDetalle.SetValue("Dsc3", 0)
                ElseIf CDbl(GridDetalle.GetValue("Costo")) <= 0 Then
                    GridDetalle.SetValue("Dsc3", 0)

                End If

            Case "Dsc4"
                If Not (IsNumeric(GridDetalle.GetValue("Dsc4")) AndAlso CDbl(GridDetalle.GetValue("Dsc4")) > 0) Then
                    GridDetalle.SetValue("Dsc4", 0)
                ElseIf CDbl(GridDetalle.GetValue("Costo")) <= 0 Then
                    GridDetalle.SetValue("Dsc4", 0)

                End If

            Case "Bon"
                If Not (IsNumeric(GridDetalle.GetValue("Bon")) AndAlso CDbl(GridDetalle.GetValue("Bon")) > 0) Then
                    GridDetalle.SetValue("Bon", 0)
                ElseIf CDbl(GridDetalle.GetValue("Costo")) <= 0 Then
                    GridDetalle.SetValue("Bon", 0)

                End If
        End Select



        dCantidadNeta = GridDetalle.GetValue("Cantidad") + GridDetalle.GetValue("Bon")
        dPrecio = Math.Abs(CDbl(GridDetalle.GetValue("Precio")))

        dCostoNeto = dPrecio

        If dCostoNeto > 0 Then
            If Math.Abs(CDbl(GridDetalle.GetValue("Dsc1"))) > 0 Then
                dCostoNeto = dCostoNeto - (dCostoNeto * (Math.Abs(CDbl(GridDetalle.GetValue("Dsc1"))) / 100))
                If Math.Abs(CDbl(GridDetalle.GetValue("Dsc2"))) > 0 Then
                    dCostoNeto = dCostoNeto - (dCostoNeto * (Math.Abs(CDbl(GridDetalle.GetValue("Dsc2"))) / 100))
                    If Math.Abs(CDbl(GridDetalle.GetValue("Dsc3"))) > 0 Then
                        dCostoNeto = dCostoNeto - (dCostoNeto * (Math.Abs(CDbl(GridDetalle.GetValue("Dsc3"))) / 100))
                        If Math.Abs(CDbl(GridDetalle.GetValue("Dsc4"))) > 0 Then
                            dCostoNeto = dCostoNeto - (dCostoNeto * (Math.Abs(CDbl(GridDetalle.GetValue("Dsc4"))) / 100))
                        End If
                    Else
                        GridDetalle.SetValue("Dsc4", 0)
                    End If
                Else
                    GridDetalle.SetValue("Dsc3", 0)
                    GridDetalle.SetValue("Dsc4", 0)
                End If
            Else
                GridDetalle.SetValue("Dsc2", 0)
                GridDetalle.SetValue("Dsc3", 0)
                GridDetalle.SetValue("Dsc4", 0)
            End If

            If GridDetalle.GetValue("Bon") > 0 Then
                dCostoNeto = dCostoNeto - (dCostoNeto / dCantidadNeta)
            End If

        End If

        dIVA = dCostoNeto * CDbl(GridDetalle.GetValue("PorcIVA"))

        dCostoTot = dCantidadNeta * dCostoNeto
        dSubtotal = dCantidadNeta * dPrecio
        dDscto = dPrecio - dCostoNeto
        dDescuento = dCantidadNeta * dDscto
        dImpuesto = dCantidadNeta * dIVA
        dImporte = dCantidadNeta * (dCostoNeto + dIVA)

        GridDetalle.SetValue("CostoTot", Redondear(dCostoTot, 6))
        GridDetalle.SetValue("Costo", Redondear(dCostoNeto, 6))
        GridDetalle.SetValue("Dscto", Redondear(dDscto, 6))
        GridDetalle.SetValue("IVA", Redondear(dIVA, 6))
        GridDetalle.SetValue("Subtotal", Redondear(dSubtotal, 6))
        GridDetalle.SetValue("Descuento", Redondear(dDescuento, 6))
        GridDetalle.SetValue("Impuesto", Redondear(dImpuesto, 6))
        GridDetalle.SetValue("Importe", Redondear(dImporte, 6))



    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Descuento = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
        SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
        CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTot"), Janus.Windows.GridEX.AggregateFunction.Sum)

        TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
        TxtDscto.Text = Format(CStr(ModPOS.TruncateToDecimal(Descuento, 2)), "Currency")
        TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
        TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")

    End Sub

    Private Sub BtnBuscaPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaPedido.Click
        If Not cmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_orden"
            a.TablaCmb = "Orden"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = cmbAlmacen.SelectedValue
            a.OcultaID = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                sORDClave = a.valor
                TxtOrden.Text = a.Descripcion
                CargaDatosOrden(a.valor, 2)
            End If
            a.Dispose()
        Else
            MsgBox("Debe seleccionar un almacén valido")
        End If
    End Sub

  

    Private Sub txtCosto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCantidad.Focus()
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount >= 0 AndAlso Not GridDetalle.GetValue("ID") Is Nothing Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el producto: " & GridDetalle.GetValue("Clave") & ", " & GridDetalle.GetValue("Nombre"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes


                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("ID = '" & GridDetalle.GetValue("ID") & "'")

                    If foundRows.Length = 1 Then
                        bUpdDetalle = True
                        'Elimina
                        dtDetalle.Rows.Remove(foundRows(0))


                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        IVA = 0

                        If dtDetalle.Rows.Count = 0 Then
                            cmbSucursal.Enabled = True
                            TxtClaveProv.Enabled = True
                            BtnBuscaProv.Enabled = True
                            BtnAddProv.Enabled = True
                            TxtOrden.Enabled = True
                            BtnBuscaPedido.Enabled = True
                        End If

                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Descuento = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTot"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
                        TxtDscto.Text = Format(CStr(ModPOS.TruncateToDecimal(Descuento, 2)), "Currency")
                        TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
                        TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")

                        If dtDetalle.Rows.Count > 0 Then
                            txtTotalPza.Text = dtDetalle.Compute("Sum(Cantidad)", "Cantidad > 0")
                        Else
                            txtTotalPza.Text = 0
                        End If

                    End If
            End Select
        End If

    End Sub

    Private Sub ActualizaPrecio(ByVal sPROClave As String, ByVal dCosto As Double)

        ModPOS.Ejecuta("st_act_costo_producto", _
                               "@PROClave", sPROClave, _
                               "@Costo", dCosto,
                               "@Usuario", ModPOS.UsuarioActual)


        Dim dtPrecios As DataTable = ModPOS.Recupera_Tabla("st_recupera_precios", "@COMClave", ModPOS.CompanyActual, "@PROClave", sPROClave)
        If dtPrecios.Rows.Count > 0 Then
            Dim z As Integer
            For z = 0 To dtPrecios.Rows.Count - 1
                ModPOS.Ejecuta("sp_modifica_precio", _
                                "@PREClave", dtPrecios.Rows(z)("PREClave"), _
                                "@PROClave", sPROClave, _
                                "@Inicio", dtPrecios.Rows(z)("Inicio"), _
                                "@Precio", Redondear(dCosto * dtPrecios.Rows(z)("Utilidad"), 2), _
                                "@Minimo", Redondear(dCosto * dtPrecios.Rows(z)("Utilidad"), 2), _
                                "@Usuario", ModPOS.UsuarioActual)
            Next
        End If


    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim frmStatusMessage As New frmStatus
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
            Dim Picking As Boolean = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
            dt.Dispose()


            Select Case Padre
                Case Is = "Nuevo"

                   

                    COMClave = ModPOS.obtenerLlave
                    Fase = ChkFase.Checked
                    SUCClave = cmbSucursal.SelectedValue
                    ALMClave = cmbAlmacen.SelectedValue
                    FechaCompra = CmbFechaCompra.Value
                    Folio = TxtFolioFactura.Text
                    ORDClave = sORDClave
                    PRVClave = sPRVClave
                    Motivo = TxtMotivo.Text
                    Solicita = TxtSolicita.Text
                    Nota = TxtNota.Text

                    If DiasCredito > 0 Then
                        Credito = 1
                    Else
                        Credito = 0
                    End If

                    ModPOS.Ejecuta("sp_inserta_compra", _
                                "@COMClave", COMClave, _
                                "@SUCClave", SUCClave, _
                                "@ALMClave", ALMClave, _
                                "@ORDClave", ORDClave, _
                                "@Factura", Folio, _
                                "@PRVClave", PRVClave, _
                                "@Credito", Credito, _
                                "@DiasCredito", DiasCredito, _
                                "@FechaFactura", FechaCompra, _
                                "@FechaVencimiento", FechaVencimiento, _
                                "@CostoTot", CostoTot, _
                                "@DescuentoTot", Descuento, _
                                "@ImpuestoTot", Impuesto, _
                                "@SubTotal", SubTotal, _
                                "@Total", Total, _
                                "@Motivo", Motivo, _
                                "@Solicita", Solicita, _
                                "@Nota", Nota, _
                                "@Fase", Fase, _
                                "@Usuario", ModPOS.UsuarioActual)

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1

                        ModPOS.Ejecuta("sp_inserta_detallecompra", _
                        "@COMClave", COMClave, _
                        "@PROClave", dtDetalle.Rows(fila)("ID"), _
                        "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                        "@Costo", dtDetalle.Rows(fila)("Costo"), _
                        "@Precio", dtDetalle.Rows(fila)("Precio"), _
                        "@DescPorc1", dtDetalle.Rows(fila)("Dsc1"), _
                        "@DescPorc2", dtDetalle.Rows(fila)("Dsc2"), _
                        "@DescPorc3", dtDetalle.Rows(fila)("Dsc3"), _
                        "@DescPorc4", dtDetalle.Rows(fila)("Dsc4"), _
                        "@Bonificacion", dtDetalle.Rows(fila)("Bon"), _
                        "@DescuentoImp", dtDetalle.Rows(fila)("Dscto"), _
                        "@ImpuestoPorc", dtDetalle.Rows(fila)("PorcIVA"), _
                        "@ImpuestoImp", dtDetalle.Rows(fila)("IVA"), _
                        "@SubTotalPartida", dtDetalle.Rows(fila)("Costo") + dtDetalle.Rows(fila)("IVA"), _
                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                        "@TotalPartida", dtDetalle.Rows(fila)("Importe"), _
                        "@fila", dtDetalle.Rows(fila)("fila"), _
                        "@Usuario", ModPOS.UsuarioActual)


                        If Fase = True Then

                            If ORDClave <> "" Then
                                ModPOS.Ejecuta("sp_actualiza_cantidad_surtida", "@fila", dtDetalle.Rows(fila)("fila"), "@ORDClave", ORDClave, "@PROClave", dtDetalle.Rows(fila)("ID"), "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), "@Suma", 1)
                            End If

                            If Picking = False Then

                                ModPOS.Ejecuta("sp_actualiza_costo", _
                                                            "@SUCClave", SUCClave, _
                                                            "@PROClave", dtDetalle.Rows(fila)("ID"), _
                                                            "@TCosto", TCosto, _
                                                            "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                                            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                                            "@Usuario", ModPOS.UsuarioActual)

                                If ActPreCompra = 1 And TCosto = 2 Then
                                    ActualizaPrecio(dtDetalle.Rows(fila)("ID"), dtDetalle.Rows(fila)("Costo"))
                                End If


                                'SI REQUIERE SEGUIMIENTO DE SERIAL
                                If dtDetalle.Rows(fila)("Seguimiento") = 2 Then
                                    Dim SerialReg As Integer = 0
                                    Dim PorRegistrar As Double
                                    PorRegistrar = dtDetalle.Rows(fila)("Cantidad")
                                    Do
                                        Dim a As New FrmSerial
                                        a.DOCClave = COMClave
                                        a.PROClave = dtDetalle.Rows(fila)("ID")
                                        a.Clave = dtDetalle.Rows(fila)("Clave")
                                        a.Nombre = dtDetalle.Rows(fila)("Nombre")
                                        a.Cantidad = PorRegistrar
                                        a.Dias = dtDetalle.Rows(fila)("DiasGarantia")
                                        a.TipoDoc = 5
                                        a.TipoMov = 1
                                        a.ShowDialog()
                                        SerialReg = SerialReg + a.NumSerialRegistrados
                                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                        a.Dispose()
                                    Loop Until SerialReg = dtDetalle.Rows(fila)("Cantidad") OrElse PorRegistrar = 0
                                End If

                                'SI REQUIERE SEGUIMIENTO DE LOTE
                                If dtDetalle.Rows(fila)("Seguimiento") = 3 Then
                                    Dim LoteReg As Integer = 0
                                    Dim PorRegistrar As Double
                                    PorRegistrar = dtDetalle.Rows(fila)("Cantidad")
                                    Do
                                        Dim a As New FrmLote
                                        a.DOCClave = COMClave
                                        a.PROClave = dtDetalle.Rows(fila)("ID")
                                        a.Clave = dtDetalle.Rows(fila)("Clave")
                                        a.Nombre = dtDetalle.Rows(fila)("Nombre")
                                        a.CantXRegistrar = PorRegistrar
                                        a.TipoDoc = 5
                                        a.TipoMov = 1
                                        a.ShowDialog()
                                        LoteReg = LoteReg + a.NumSerialRegistrados
                                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                        a.Dispose()
                                    Loop Until LoteReg = dtDetalle.Rows(fila)("Cantidad") OrElse PorRegistrar = 0
                                End If



                            End If

                        End If
                    Next

                    If Fase = True Then

                        frmStatusMessage.Show("Procesando información...")

                        If ORDClave <> "" Then
                            ModPOS.Ejecuta("sp_actualiza_estado_orden", "@ORDClave", ORDClave, "@Estado", 2)
                        End If

                        ModPOS.Ejecuta("sp_actualiza_saldo_proveedor", "@PRVClave", PRVClave, "@Tipo", 1, "@Saldo", Total)


                        If Picking = False Then

                            ModPOS.Ejecuta("sp_recibo_compra", "@COMClave", COMClave)

                            ModPOS.GeneraMovInv(1, 2, 5, COMClave, ALMClave, Folio, ModPOS.UsuarioActual)
                          
                            If InterfazSalida <> "" Then

                                Dim iTipoDocumento As Integer
                                Dim sTipo, sFolio, sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                sTipo = "Compra"
                                iTipoDocumento = 2
                                sFolio = COMClave

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", sTipo, "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", iTipoDocumento, "@Path", InterfazSalida, "@Fecha", sFecha, "@IdRecibo", "")
                                End If
                            End If


                        End If

                        frmStatusMessage.Close()

                        If MessageBox.Show("¿Desea imprimir la Compra?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            imprimirCompra()
                        End If

                    End If


                    If Fase = False AndAlso Picking = False Then
                        MessageBox.Show("La Compra No ha sido Confirmada, por lo que no sera afectado el inventario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    Me.Close()

                Case Is = "Modificar"

                    If Not (bUpdDetalle = False AndAlso _
                        Fase = ChkFase.Checked AndAlso _
                        SUCClave = cmbSucursal.SelectedValue AndAlso _
                        ALMClave = cmbAlmacen.SelectedValue AndAlso _
                        FechaCompra = CmbFechaCompra.Value AndAlso _
                        Folio = TxtFolioFactura.Text AndAlso _
                        ORDClave = sORDClave AndAlso _
                        PRVClave = sPRVClave AndAlso _
                        Motivo = TxtMotivo.Text AndAlso _
                        Solicita = TxtSolicita.Text AndAlso _
                        Nota = TxtNota.Text) Then



                        Fase = ChkFase.Checked
                        SUCClave = cmbSucursal.SelectedValue
                        ALMClave = cmbAlmacen.SelectedValue
                        FechaCompra = CmbFechaCompra.Value
                        Folio = TxtFolioFactura.Text
                        ORDClave = sORDClave
                        PRVClave = sPRVClave
                        Motivo = TxtMotivo.Text
                        Solicita = TxtSolicita.Text
                        Nota = TxtNota.Text

                        If DiasCredito > 0 Then
                            Credito = 1
                        Else
                            Credito = 0
                        End If

                        ModPOS.Ejecuta("sp_actualiza_compra", _
                                "@COMClave", COMClave, _
                                "@SUCClave", SUCClave, _
                                "@ALMClave", ALMClave, _
                                "@ORDClave", ORDClave, _
                                "@Factura", Folio, _
                                "@PRVClave", PRVClave, _
                                "@Credito", Credito, _
                                "@DiasCredito", DiasCredito, _
                                "@FechaFactura", FechaCompra, _
                                "@FechaVencimiento", FechaVencimiento, _
                                "@CostoTot", CostoTot, _
                                "@DescuentoTot", Descuento, _
                                "@ImpuestoTot", Impuesto, _
                                "@SubTotal", SubTotal, _
                                "@Total", Total, _
                                "@Motivo", Motivo, _
                                "@Solicita", Solicita, _
                                "@Nota", Nota, _
                                "@Fase", Fase, _
                                "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_elimina_detallecompra", "@COMClave", COMClave)

                        Dim fila As Integer

                        For fila = 0 To dtDetalle.Rows.Count - 1


                            ModPOS.Ejecuta("sp_inserta_detallecompra", _
                        "@COMClave", COMClave, _
                        "@PROClave", dtDetalle.Rows(fila)("ID"), _
                        "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                        "@Costo", dtDetalle.Rows(fila)("Costo"), _
                        "@Precio", dtDetalle.Rows(fila)("Precio"), _
                        "@DescPorc1", dtDetalle.Rows(fila)("Dsc1"), _
                        "@DescPorc2", dtDetalle.Rows(fila)("Dsc2"), _
                        "@DescPorc3", dtDetalle.Rows(fila)("Dsc3"), _
                        "@DescPorc4", dtDetalle.Rows(fila)("Dsc4"), _
                        "@Bonificacion", dtDetalle.Rows(fila)("Bon"), _
                        "@DescuentoImp", dtDetalle.Rows(fila)("Dscto"), _
                        "@ImpuestoPorc", dtDetalle.Rows(fila)("PorcIVA"), _
                        "@ImpuestoImp", dtDetalle.Rows(fila)("IVA"), _
                        "@SubTotalPartida", dtDetalle.Rows(fila)("Costo") + dtDetalle.Rows(fila)("IVA"), _
                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                        "@TotalPartida", dtDetalle.Rows(fila)("Importe"), _
                        "@fila", dtDetalle.Rows(fila)("fila"), _
                        "@Usuario", ModPOS.UsuarioActual)


                            If Fase = True Then


                                If ORDClave <> "" Then
                                    ModPOS.Ejecuta("sp_actualiza_cantidad_surtida", "@fila", dtDetalle.Rows(fila)("fila"), "@ORDClave", ORDClave, "@PROClave", dtDetalle.Rows(fila)("ID"), "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), "@Suma", 1)
                                End If

                                ModPOS.Ejecuta("sp_actualiza_costo", _
                                                            "@SUCClave", SUCClave, _
                                                            "@PROClave", dtDetalle.Rows(fila)("ID"), _
                                                            "@TCosto", TCosto, _
                                                            "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                                            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                                            "@Usuario", ModPOS.UsuarioActual)


                                If ActPreCompra = 1 And TCosto = 2 Then
                                    ActualizaPrecio(dtDetalle.Rows(fila)("ID"), dtDetalle.Rows(fila)("Costo"))
                                End If

                                If Picking = False Then

                                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                                    If dtDetalle.Rows(fila)("Seguimiento") = 2 Then
                                        Dim SerialReg As Integer = 0
                                        Dim PorRegistrar As Double
                                        PorRegistrar = dtDetalle.Rows(fila)("Cantidad")
                                        Do
                                            Dim a As New FrmSerial
                                            a.DOCClave = COMClave
                                            a.PROClave = dtDetalle.Rows(fila)("ID")
                                            a.Clave = dtDetalle.Rows(fila)("Clave")
                                            a.Nombre = dtDetalle.Rows(fila)("Nombre")
                                            a.Cantidad = PorRegistrar
                                            a.Dias = dtDetalle.Rows(fila)("DiasGarantia")
                                            a.TipoDoc = 5
                                            a.TipoMov = 1
                                            a.ShowDialog()
                                            SerialReg = SerialReg + a.NumSerialRegistrados
                                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                            a.Dispose()
                                        Loop Until SerialReg = dtDetalle.Rows(fila)("Cantidad") OrElse PorRegistrar = 0
                                    End If

                                    'SI REQUIERE SEGUIMIENTO DE LOTE
                                    If dtDetalle.Rows(fila)("Seguimiento") = 3 Then
                                        Dim LoteReg As Integer = 0
                                        Dim PorRegistrar As Double
                                        PorRegistrar = dtDetalle.Rows(fila)("Cantidad")
                                        Do
                                            Dim a As New FrmLote
                                            a.DOCClave = COMClave
                                            a.PROClave = dtDetalle.Rows(fila)("ID")
                                            a.Clave = dtDetalle.Rows(fila)("Clave")
                                            a.Nombre = dtDetalle.Rows(fila)("Nombre")
                                            a.CantXRegistrar = PorRegistrar
                                            a.TipoDoc = 5
                                            a.TipoMov = 1
                                            a.ShowDialog()
                                            LoteReg = LoteReg + a.NumSerialRegistrados
                                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                            a.Dispose()
                                        Loop Until LoteReg = dtDetalle.Rows(fila)("Cantidad") OrElse PorRegistrar = 0
                                    End If



                                End If

                            End If
                        Next

                        If Fase = True Then

                            frmStatusMessage.Show("Procesando información...")

                            If ORDClave <> "" Then
                                ModPOS.Ejecuta("sp_actualiza_estado_orden", "@ORDClave", ORDClave, "@Estado", 3)
                            End If

                            ModPOS.Ejecuta("sp_actualiza_saldo_proveedor", "@PRVClave", PRVClave, "@Tipo", 1, "@Saldo", Total)


                            If Picking = False Then

                                ModPOS.Ejecuta("sp_recibo_compra", "@COMClave", COMClave)

                                ModPOS.GeneraMovInv(1, 2, 5, COMClave, ALMClave, Folio, ModPOS.UsuarioActual)
                               
                                If InterfazSalida <> "" Then

                                    Dim iTipoDocumento As Integer
                                    Dim sTipo, sFolio, sFecha As String
                                    Dim dtInterfaz As DataTable
                                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                    sTipo = "Compra"
                                    iTipoDocumento = 2
                                    sFolio = COMClave

                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", sTipo, "@COMClave", ModPOS.CompanyActual)
                                    If dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", iTipoDocumento, "@Path", InterfazSalida, "@Fecha", sFecha, "@IdRecibo", "")
                                    End If
                                End If


                            End If

                            frmStatusMessage.Close()

                            If MessageBox.Show("¿Desea imprimir la Compra?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                                imprimirCompra()
                            End If

                        End If

                        If Fase = False AndAlso Picking = False Then
                            MessageBox.Show("La Compra No ha sido Confirmada, por lo que no sera afectado el inventario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


                    End If

                    Me.Close()

                Case Is = "Eliminar"

                    Fase = ChkFase.Checked

                    If Fase = True Then
                        MessageBox.Show("No es posible cancelar, la compra no ha sido confirmada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If Estado = 0 Then
                        MessageBox.Show("No es posible cancelar, la compra ya fue cancelada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf Total > Saldo Then
                        MessageBox.Show("No es posible cancelar, la compra debido a que tiene pagos aplicados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = Total
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            ModPOS.Ejecuta("sp_elimina_compra", "@COMClave", COMClave, "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If

                    Me.Close()
            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub CargaDatosOrden(ByVal Orden As String, ByVal iTipo As Integer)

        If Not cmbSucursal.SelectedValue Is Nothing Then

            Dim dt As DataTable = Nothing
            
            dt = ModPOS.Recupera_Tabla("st_recupera_orden", "@Tipo", iTipo, "@ORDClave", Orden, "@SUCClave", cmbSucursal.SelectedValue)

            If dt.Rows.Count > 0 Then

                If dt.Rows(0)("Estado") = 4 Then
                    MsgBox("No es posible agregar la orden de compra ya que se encuentra Cancelada")
                    Exit Sub
                End If

                TImpuesto = dt.Rows(0)("TImpuesto")
                sORDClave = dt.Rows(0)("ORDClave")
                TxtOrden.Text = dt.Rows(0)("Folio")
                TxtClaveProv.Text = dt.Rows(0)("CProveedor")
                sPRVClave = dt.Rows(0)("PRVClave")
                TxtRazonSocial.Text = dt.Rows(0)("NProveedor")
                DiasCredito = dt.Rows(0)("DiasCredito")
                TxtDiasCredito.Text = dt.Rows(0)("DiasCredito")
                TxtCreditoDisp.Text = dt.Rows(0)("Disponible")
                Solicita = dt.Rows(0)("Solicita")
                Motivo = dt.Rows(0)("Motivo")
                Nota = dt.Rows(0)("Nota")

                TxtSolicita.Text = Solicita
                TxtMotivo.Text = Motivo
                TxtNota.Text = Nota

                FechaVencimiento = CmbFechaCompra.Value.AddDays(dt.Rows(0)("DiasCredito"))
                TxtFechaVencimiento.Text = FechaVencimiento.ToShortDateString

                dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_ordenCompra", "@ORDClave", sORDClave)
                GridDetalle.DataSource = dtDetalle
                GridDetalle.RetrieveStructure(True)
                GridDetalle.GroupByBoxVisible = False

                GridDetalle.RootTable.Columns("ID").Visible = False
                GridDetalle.CurrentTable.Columns("Dscto").Selectable = False
                GridDetalle.RootTable.Columns("PorcIVA").Visible = False
                GridDetalle.RootTable.Columns("Seguimiento").Visible = False
                GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
                GridDetalle.RootTable.Columns("TProducto").Visible = False
                GridDetalle.CurrentTable.Columns("CostoTot").Visible = False
                GridDetalle.CurrentTable.Columns("Subtotal").Visible = False
                GridDetalle.CurrentTable.Columns("Descuento").Visible = False
                GridDetalle.CurrentTable.Columns("Impuesto").Visible = False


                GridDetalle.CurrentTable.Columns("Clave").Selectable = False
                GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
                GridDetalle.CurrentTable.Columns("Precio").Selectable = False
                GridDetalle.CurrentTable.Columns("IVA").Selectable = False
                GridDetalle.RootTable.Columns("Importe").Selectable = False

              

                Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                Descuento = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
                Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)
                CostoTot = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("CostoTot"), Janus.Windows.GridEX.AggregateFunction.Sum)

                TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
                TxtDscto.Text = Format(CStr(ModPOS.TruncateToDecimal(Descuento, 2)), "Currency")
                TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
                TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")
            Else
                MsgBox("La orden de compra no se encuentra disponible o ya fue completamente surtida")
            End If
            dt.Dispose()
        Else
            MsgBox("Debe seleccionar una sucursal valida")
        End If

    End Sub

    'pendiente de revisar 

    Private Sub imprimirCompra()
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_compra", "@COMClave", COMClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_compra", "@COMClave", COMClave))
        OpenReport.PrintPreview("Compra", "CRCompra.rpt", pvtaDataSet, "")

    End Sub

  
    Private Sub BtnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImportar.Click
        If sPRVClave <> "" Then
            Dim FullPath As String
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If (result = DialogResult.OK) Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                FullPath = OpenFileDialog1.FileName

                If FullPath.Contains(".CSV") Then
                    Dim dtTemporal As DataTable = LeerCSV(FullPath)
                    If Not dtTemporal Is Nothing AndAlso dtTemporal.Rows.Count > 0 Then

                        Dim dtProducto As DataTable

                        Dim i As Integer
                        For i = 0 To dtTemporal.Rows.Count - 1
                            'Valida si existen datos para comparar
                            If Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" Then
                                'Verifica que el producto exista
                                dtProducto = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", dtTemporal.Rows(i)(0).ToString.Trim)
                                If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count >= 1 Then
                                    'Verifica que la cantidad sea numerica
                                    If IsNumeric(dtTemporal.Rows(i)(1)) Then

                                        PROClave = dtProducto.Rows(0)("PROClave")
                                        Clave = dtProducto.Rows(0)("Clave")
                                        Nombre = dtProducto.Rows(0)("Nombre")
                                        Costo = 0
                                        IVA = ModPOS.RecuperaImpuesto(SUCClave, PROClave, TImpuesto)
                                        Seguimiento = dtProducto.Rows(0)("Seguimiento")
                                        DiasGarantia = dtProducto.Rows(0)("DiasGarantia")
                                        TProducto = dtProducto.Rows(0)("TProducto")
                                        NumDecimales = dtProducto.Rows(0)("Num_Decimales")

                                        Cantidad = CDbl(dtTemporal.Rows(i)(1))

                                        Dim foundRows() As System.Data.DataRow
                                        foundRows = dtDetalle.Select("ID Like '" & PROClave & "'")

                                        If foundRows.Length = 0 Then
                                            If Cantidad > 0 Then
                                                Dim row1 As DataRow
                                                row1 = dtDetalle.NewRow()
                                                'declara el nombre de la fila
                                                row1.Item("ID") = PROClave
                                                row1.Item("Cantidad") = Cantidad
                                                row1.Item("Solicitado") = 0.0
                                                row1.Item("Clave") = Clave
                                                row1.Item("Nombre") = Nombre
                                                row1.Item("Costo") = Redondear(Costo, 6)
                                                row1.Item("Precio") = Redondear(Costo, 6)
                                                row1.Item("Dsc1") = 0.0
                                                row1.Item("Dsc2") = 0.0
                                                row1.Item("Dsc3") = 0.0
                                                row1.Item("Dsc4") = 0.0
                                                row1.Item("Bonific.") = 0.0
                                                row1.Item("DsctoImp") = 0.0
                                                row1.Item("PorcIVA") = IVA
                                                row1.Item("IVA") = Redondear(Costo * IVA, 6)
                                                row1.Item("Importe") = Redondear(Cantidad * (Costo * (1 + IVA)), 6)
                                                row1.Item("Seguimiento") = Seguimiento
                                                row1.Item("DiasGarantia") = DiasGarantia
                                                row1.Item("TProducto") = TProducto
                                                row1.Item("Subtotal") = Redondear(Cantidad * Costo, 6)
                                                row1.Item("Descuento") = 0.0
                                                row1.Item("Impuesto") = Redondear(Cantidad * (Costo * IVA), 6)
                                                dtDetalle.Rows.Add(row1)
                                            End If
                                            'agrega la fila completo a la tabla
                                        ElseIf Cantidad = 0 AndAlso foundRows(0)("Surtido") = 0 Then
                                            'Elimina
                                            dtDetalle.Rows.Remove(foundRows(0))
                                        ElseIf Cantidad >= foundRows(0)("Surtido") Then
                                            'actualiza
                                            foundRows(0)("Cantidad") = Cantidad
                                            foundRows(0)("Subtotal") = Redondear(Cantidad * foundRows(0)("Precio"), 6)
                                            foundRows(0)("Descuento") = Redondear(Cantidad * (foundRows(0)("Dsc1") + foundRows(0)("Dsc2") + foundRows(0)("Dsc3") + foundRows(0)("Dsc4")), 6)
                                            foundRows(0)("Impuesto") = Redondear(Cantidad * foundRows(0)("IVA"), 6)
                                            foundRows(0)("Importe") = Redondear(Cantidad * ((foundRows(0)("Precio") - (foundRows(0)("Dsc1") + foundRows(0)("Dsc2") + foundRows(0)("Dsc3") + foundRows(0)("Dsc4"))) + foundRows(0)("IVA")), 6)

                                        End If


                                    End If
                                    dtProducto.Dispose()
                                End If

                            End If
                        Next

                        Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Descuento = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Descuento"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        Impuesto = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Impuesto"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        SubTotal = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        TxtSubtotal.Text = Format(CStr(ModPOS.TruncateToDecimal(SubTotal, 2)), "Currency")
                        TxtDscto.Text = Format(CStr(ModPOS.TruncateToDecimal(Descuento, 2)), "Currency")
                        TxtIVA.Text = Format(CStr(ModPOS.TruncateToDecimal(Impuesto, 2)), "Currency")
                        TxtTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(Total, 2)), "Currency")

                        dtTemporal.Dispose()

                        If dtDetalle.Rows.Count = 0 Then
                            MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Else
                        MessageBox.Show("El archivo seleccionado no tiene registros validos para ser procesados o no se encuentran en el formato esperado (Código Barras,Cantidad)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If

            End If
        Else
            MessageBox.Show("No se ha especificado el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

  
    Private Sub TxtOrden_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtOrden.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not TxtOrden.Text = vbNullString Then
                CargaDatosOrden(TxtOrden.Text.ToUpper.Trim.Replace("'", "''"), 1)
            End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaPedido.PerformClick()
        End If
    End Sub

 
    Private Sub TxtFolioFactura_Leave(sender As Object, e As EventArgs) Handles TxtFolioFactura.Leave
        If Padre = "Nuevo" AndAlso TxtFolioFactura.Text.Trim <> "" Then
            If Not SiExisteRecupera("st_valida_compra", "@Folio", TxtFolioFactura.Text.Trim) Is Nothing Then
                If MessageBox.Show("La referencia de factura que intenta registrar ya Existe en el sistema, ¿Desea ignorar y continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.No Then
                    TxtFolioFactura.Text = ""
                End If
            End If
        End If
    End Sub
End Class
