Imports System.IO.Ports

Public Class FrmPDV
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
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbImpresora As StoreCombo
    Friend WithEvents GrpPDV As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtNombre As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cmbUsuario As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbFase As Selling.StoreCombo
    Friend WithEvents ChkPagos As Selling.ChkStatus
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtFrase As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTicket As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Almacen As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents ChkRedondeo As Selling.ChkStatus
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnRedondeo As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtImgRedondeo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents ChkPrecios As Selling.ChkStatus
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkAgotamiento As Selling.ChkStatus
    Friend WithEvents TxtProcesador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnAsociar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ChkSolicitaVendedor As Selling.ChkStatus
    Friend WithEvents ChkPrecioServicio As Selling.ChkStatus
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkActivaDevolucion As Selling.ChkStatus
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents NumCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkValidaInventario As Selling.ChkStatus
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NumLineas As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbPuerto As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents NumCaracteres As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtBaudRate As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ChkDisplay As Selling.ChkStatus
    Friend WithEvents ChkActivarCotizacion As Selling.ChkStatus
    Friend WithEvents cmbPicking As Selling.StoreCombo
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtCredito As System.Windows.Forms.TextBox
    Friend WithEvents TxtMostrador As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscaCredito As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoVenta As System.Windows.Forms.ComboBox
    Friend WithEvents ChkGridView As Selling.ChkStatus
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPDV))
        Me.GrpPDV = New System.Windows.Forms.GroupBox
        Me.ChkGridView = New Selling.ChkStatus(Me.components)
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.cmbTipoVenta = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.LblCredito = New System.Windows.Forms.Label
        Me.LblCliente = New System.Windows.Forms.Label
        Me.btnBuscaCredito = New Janus.Windows.EditControls.UIButton
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.TxtCredito = New System.Windows.Forms.TextBox
        Me.TxtMostrador = New System.Windows.Forms.TextBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbPicking = New Selling.StoreCombo
        Me.Label19 = New System.Windows.Forms.Label
        Me.ChkActivarCotizacion = New Selling.ChkStatus(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkDisplay = New Selling.ChkStatus(Me.components)
        Me.TxtBaudRate = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.NumCaracteres = New System.Windows.Forms.NumericUpDown
        Me.Label17 = New System.Windows.Forms.Label
        Me.NumLineas = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbPuerto = New System.Windows.Forms.ComboBox
        Me.ChkValidaInventario = New Selling.ChkStatus(Me.components)
        Me.NumCopias = New System.Windows.Forms.NumericUpDown
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ChkActivaDevolucion = New Selling.ChkStatus(Me.components)
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label12 = New System.Windows.Forms.Label
        Me.ChkPrecioServicio = New Selling.ChkStatus(Me.components)
        Me.ChkSolicitaVendedor = New Selling.ChkStatus(Me.components)
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.BtnAsociar = New Janus.Windows.EditControls.UIButton
        Me.TxtProcesador = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ChkAgotamiento = New Selling.ChkStatus(Me.components)
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.ChkPrecios = New Selling.ChkStatus(Me.components)
        Me.CmbCaja = New Selling.StoreCombo
        Me.BtnRedondeo = New Janus.Windows.EditControls.UIButton
        Me.TxtImgRedondeo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ChkRedondeo = New Selling.ChkStatus(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Almacen = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbTicket = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbFase = New Selling.StoreCombo
        Me.ChkPagos = New Selling.ChkStatus(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbUsuario = New Selling.StoreCombo
        Me.TxtNombre = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.cmbImpresora = New Selling.StoreCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFrase = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GrpPDV.SuspendLayout()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumCaracteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPDV
        '
        Me.GrpPDV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPDV.Controls.Add(Me.ChkGridView)
        Me.GrpPDV.Controls.Add(Me.PictureBox23)
        Me.GrpPDV.Controls.Add(Me.cmbTipoVenta)
        Me.GrpPDV.Controls.Add(Me.Label20)
        Me.GrpPDV.Controls.Add(Me.LblCredito)
        Me.GrpPDV.Controls.Add(Me.LblCliente)
        Me.GrpPDV.Controls.Add(Me.btnBuscaCredito)
        Me.GrpPDV.Controls.Add(Me.btnBuscaCte)
        Me.GrpPDV.Controls.Add(Me.TxtCredito)
        Me.GrpPDV.Controls.Add(Me.TxtMostrador)
        Me.GrpPDV.Controls.Add(Me.PictureBox3)
        Me.GrpPDV.Controls.Add(Me.cmbPicking)
        Me.GrpPDV.Controls.Add(Me.Label19)
        Me.GrpPDV.Controls.Add(Me.ChkActivarCotizacion)
        Me.GrpPDV.Controls.Add(Me.GroupBox1)
        Me.GrpPDV.Controls.Add(Me.ChkValidaInventario)
        Me.GrpPDV.Controls.Add(Me.NumCopias)
        Me.GrpPDV.Controls.Add(Me.PictureBox14)
        Me.GrpPDV.Controls.Add(Me.Label14)
        Me.GrpPDV.Controls.Add(Me.ChkActivaDevolucion)
        Me.GrpPDV.Controls.Add(Me.PictureBox13)
        Me.GrpPDV.Controls.Add(Me.Label13)
        Me.GrpPDV.Controls.Add(Me.PictureBox12)
        Me.GrpPDV.Controls.Add(Me.CmbSucursal)
        Me.GrpPDV.Controls.Add(Me.Label12)
        Me.GrpPDV.Controls.Add(Me.ChkPrecioServicio)
        Me.GrpPDV.Controls.Add(Me.ChkSolicitaVendedor)
        Me.GrpPDV.Controls.Add(Me.PictureBox9)
        Me.GrpPDV.Controls.Add(Me.Label7)
        Me.GrpPDV.Controls.Add(Me.PictureBox11)
        Me.GrpPDV.Controls.Add(Me.Label6)
        Me.GrpPDV.Controls.Add(Me.CmbTipo)
        Me.GrpPDV.Controls.Add(Me.BtnAsociar)
        Me.GrpPDV.Controls.Add(Me.TxtProcesador)
        Me.GrpPDV.Controls.Add(Me.Label3)
        Me.GrpPDV.Controls.Add(Me.ChkAgotamiento)
        Me.GrpPDV.Controls.Add(Me.PictureBox10)
        Me.GrpPDV.Controls.Add(Me.PictureBox8)
        Me.GrpPDV.Controls.Add(Me.PictureBox7)
        Me.GrpPDV.Controls.Add(Me.PictureBox6)
        Me.GrpPDV.Controls.Add(Me.ChkPrecios)
        Me.GrpPDV.Controls.Add(Me.CmbCaja)
        Me.GrpPDV.Controls.Add(Me.BtnRedondeo)
        Me.GrpPDV.Controls.Add(Me.TxtImgRedondeo)
        Me.GrpPDV.Controls.Add(Me.Label11)
        Me.GrpPDV.Controls.Add(Me.ChkRedondeo)
        Me.GrpPDV.Controls.Add(Me.PictureBox4)
        Me.GrpPDV.Controls.Add(Me.Almacen)
        Me.GrpPDV.Controls.Add(Me.CmbAlmacen)
        Me.GrpPDV.Controls.Add(Me.Label10)
        Me.GrpPDV.Controls.Add(Me.CmbTicket)
        Me.GrpPDV.Controls.Add(Me.PictureBox1)
        Me.GrpPDV.Controls.Add(Me.Label8)
        Me.GrpPDV.Controls.Add(Me.Label5)
        Me.GrpPDV.Controls.Add(Me.cmbFase)
        Me.GrpPDV.Controls.Add(Me.ChkPagos)
        Me.GrpPDV.Controls.Add(Me.Label1)
        Me.GrpPDV.Controls.Add(Me.cmbUsuario)
        Me.GrpPDV.Controls.Add(Me.TxtNombre)
        Me.GrpPDV.Controls.Add(Me.ChkEstado)
        Me.GrpPDV.Controls.Add(Me.cmbImpresora)
        Me.GrpPDV.Controls.Add(Me.Label2)
        Me.GrpPDV.Controls.Add(Me.TxtDescripcion)
        Me.GrpPDV.Controls.Add(Me.LblClave)
        Me.GrpPDV.Controls.Add(Me.Label4)
        Me.GrpPDV.Controls.Add(Me.TxtFrase)
        Me.GrpPDV.Controls.Add(Me.Label9)
        Me.GrpPDV.Controls.Add(Me.PictureBox2)
        Me.GrpPDV.Controls.Add(Me.PictureBox5)
        Me.GrpPDV.Controls.Add(Me.LblNombre)
        Me.GrpPDV.Location = New System.Drawing.Point(7, 6)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(770, 506)
        Me.GrpPDV.TabIndex = 1
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Punto de Venta"
        '
        'ChkGridView
        '
        Me.ChkGridView.Checked = True
        Me.ChkGridView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkGridView.Location = New System.Drawing.Point(684, 314)
        Me.ChkGridView.Name = "ChkGridView"
        Me.ChkGridView.Size = New System.Drawing.Size(80, 23)
        Me.ChkGridView.TabIndex = 139
        Me.ChkGridView.Text = "Grid View"
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(689, 64)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox23.TabIndex = 138
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'cmbTipoVenta
        '
        Me.cmbTipoVenta.FormattingEnabled = True
        Me.cmbTipoVenta.Items.AddRange(New Object() {"Cte. Mostrador", "Ultimo Cliente"})
        Me.cmbTipoVenta.Location = New System.Drawing.Point(457, 58)
        Me.cmbTipoVenta.Name = "cmbTipoVenta"
        Me.cmbTipoVenta.Size = New System.Drawing.Size(227, 21)
        Me.cmbTipoVenta.TabIndex = 11
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(365, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 20)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "Predeterminada"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(269, 177)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(408, 20)
        Me.LblCredito.TabIndex = 133
        '
        'LblCliente
        '
        Me.LblCliente.Location = New System.Drawing.Point(266, 148)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(411, 19)
        Me.LblCliente.TabIndex = 132
        '
        'btnBuscaCredito
        '
        Me.btnBuscaCredito.Icon = CType(resources.GetObject("btnBuscaCredito.Icon"), System.Drawing.Icon)
        Me.btnBuscaCredito.Image = CType(resources.GetObject("btnBuscaCredito.Image"), System.Drawing.Image)
        Me.btnBuscaCredito.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCredito.Location = New System.Drawing.Point(221, 173)
        Me.btnBuscaCredito.Name = "btnBuscaCredito"
        Me.btnBuscaCredito.Size = New System.Drawing.Size(39, 28)
        Me.btnBuscaCredito.TabIndex = 7
        Me.btnBuscaCredito.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCredito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(221, 140)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaCte.TabIndex = 6
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCredito
        '
        Me.TxtCredito.Location = New System.Drawing.Point(93, 175)
        Me.TxtCredito.Name = "TxtCredito"
        Me.TxtCredito.ReadOnly = True
        Me.TxtCredito.Size = New System.Drawing.Size(120, 20)
        Me.TxtCredito.TabIndex = 129
        '
        'TxtMostrador
        '
        Me.TxtMostrador.Location = New System.Drawing.Point(93, 145)
        Me.TxtMostrador.Name = "TxtMostrador"
        Me.TxtMostrador.ReadOnly = True
        Me.TxtMostrador.Size = New System.Drawing.Size(120, 20)
        Me.TxtMostrador.TabIndex = 128
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(72, 90)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 32
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbPicking
        '
        Me.cmbPicking.Location = New System.Drawing.Point(93, 259)
        Me.cmbPicking.Name = "cmbPicking"
        Me.cmbPicking.Size = New System.Drawing.Size(227, 21)
        Me.cmbPicking.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(14, 262)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 15)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "Imp. Picking"
        '
        'ChkActivarCotizacion
        '
        Me.ChkActivarCotizacion.Checked = True
        Me.ChkActivarCotizacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivarCotizacion.Location = New System.Drawing.Point(684, 291)
        Me.ChkActivarCotizacion.Name = "ChkActivarCotizacion"
        Me.ChkActivarCotizacion.Size = New System.Drawing.Size(80, 22)
        Me.ChkActivarCotizacion.TabIndex = 21
        Me.ChkActivarCotizacion.Text = "Cotización"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkDisplay)
        Me.GroupBox1.Controls.Add(Me.TxtBaudRate)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.NumCaracteres)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.NumLineas)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmbPuerto)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 410)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 83)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pole Display (Tipo de Comandos ESC/POS)"
        '
        'ChkDisplay
        '
        Me.ChkDisplay.Checked = True
        Me.ChkDisplay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDisplay.Location = New System.Drawing.Point(569, 22)
        Me.ChkDisplay.Name = "ChkDisplay"
        Me.ChkDisplay.Size = New System.Drawing.Size(113, 22)
        Me.ChkDisplay.TabIndex = 128
        Me.ChkDisplay.Text = "Activar Display"
        '
        'TxtBaudRate
        '
        Me.TxtBaudRate.Location = New System.Drawing.Point(379, 26)
        Me.TxtBaudRate.Name = "TxtBaudRate"
        Me.TxtBaudRate.Size = New System.Drawing.Size(98, 20)
        Me.TxtBaudRate.TabIndex = 127
        Me.TxtBaudRate.Text = "9,600"
        Me.TxtBaudRate.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtBaudRate.Value = 9600
        Me.TxtBaudRate.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(243, 58)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 13)
        Me.Label18.TabIndex = 126
        Me.Label18.Text = "Max. Caracteres/Linea"
        '
        'NumCaracteres
        '
        Me.NumCaracteres.Location = New System.Drawing.Point(379, 57)
        Me.NumCaracteres.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCaracteres.Name = "NumCaracteres"
        Me.NumCaracteres.Size = New System.Drawing.Size(100, 20)
        Me.NumCaracteres.TabIndex = 125
        Me.NumCaracteres.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "No. Lineas"
        '
        'NumLineas
        '
        Me.NumLineas.Location = New System.Drawing.Point(72, 57)
        Me.NumLineas.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumLineas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLineas.Name = "NumLineas"
        Me.NumLineas.Size = New System.Drawing.Size(100, 20)
        Me.NumLineas.TabIndex = 122
        Me.NumLineas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(243, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(135, 15)
        Me.Label16.TabIndex = 123
        Me.Label16.Text = "Velocidad de Transmición"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "No. Puerto"
        '
        'cmbPuerto
        '
        Me.cmbPuerto.FormattingEnabled = True
        Me.cmbPuerto.Location = New System.Drawing.Point(72, 26)
        Me.cmbPuerto.Name = "cmbPuerto"
        Me.cmbPuerto.Size = New System.Drawing.Size(100, 21)
        Me.cmbPuerto.TabIndex = 3
        '
        'ChkValidaInventario
        '
        Me.ChkValidaInventario.Checked = True
        Me.ChkValidaInventario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkValidaInventario.Location = New System.Drawing.Point(527, 314)
        Me.ChkValidaInventario.Name = "ChkValidaInventario"
        Me.ChkValidaInventario.Size = New System.Drawing.Size(180, 23)
        Me.ChkValidaInventario.TabIndex = 25
        Me.ChkValidaInventario.Text = "Validar Inventario en Venta"
        '
        'NumCopias
        '
        Me.NumCopias.Location = New System.Drawing.Point(450, 234)
        Me.NumCopias.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumCopias.Name = "NumCopias"
        Me.NumCopias.Size = New System.Drawing.Size(100, 20)
        Me.NumCopias.TabIndex = 15
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(555, 238)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox14.TabIndex = 122
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(353, 236)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 15)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "Copias de Ticket"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkActivaDevolucion
        '
        Me.ChkActivaDevolucion.Checked = True
        Me.ChkActivaDevolucion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActivaDevolucion.Location = New System.Drawing.Point(527, 292)
        Me.ChkActivaDevolucion.Name = "ChkActivaDevolucion"
        Me.ChkActivaDevolucion.Size = New System.Drawing.Size(180, 22)
        Me.ChkActivaDevolucion.TabIndex = 20
        Me.ChkActivaDevolucion.Text = "Devolución Sin Caja Activa"
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(72, 175)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox13.TabIndex = 118
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(14, 178)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Crédito Gral."
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(70, 118)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox12.TabIndex = 115
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.ItemHeight = 13
        Me.CmbSucursal.Location = New System.Drawing.Point(93, 115)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(227, 21)
        Me.CmbSucursal.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(14, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 114
        Me.Label12.Text = "Sucursal"
        '
        'ChkPrecioServicio
        '
        Me.ChkPrecioServicio.Checked = True
        Me.ChkPrecioServicio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecioServicio.Location = New System.Drawing.Point(339, 314)
        Me.ChkPrecioServicio.Name = "ChkPrecioServicio"
        Me.ChkPrecioServicio.Size = New System.Drawing.Size(194, 23)
        Me.ChkPrecioServicio.TabIndex = 24
        Me.ChkPrecioServicio.Text = "Modificar Precios de Servicios"
        '
        'ChkSolicitaVendedor
        '
        Me.ChkSolicitaVendedor.Checked = True
        Me.ChkSolicitaVendedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSolicitaVendedor.Location = New System.Drawing.Point(339, 292)
        Me.ChkSolicitaVendedor.Name = "ChkSolicitaVendedor"
        Me.ChkSolicitaVendedor.Size = New System.Drawing.Size(173, 22)
        Me.ChkSolicitaVendedor.TabIndex = 19
        Me.ChkSolicitaVendedor.Text = "Solicitar Vendedor"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(69, 236)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox9.TabIndex = 101
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(327, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Caja predeterminada"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(689, 34)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox11.TabIndex = 109
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(400, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Tipo"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(457, 32)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(227, 21)
        Me.CmbTipo.TabIndex = 2
        '
        'BtnAsociar
        '
        Me.BtnAsociar.Icon = CType(resources.GetObject("BtnAsociar.Icon"), System.Drawing.Icon)
        Me.BtnAsociar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnAsociar.Location = New System.Drawing.Point(574, 379)
        Me.BtnAsociar.Name = "BtnAsociar"
        Me.BtnAsociar.Size = New System.Drawing.Size(35, 30)
        Me.BtnAsociar.TabIndex = 27
        Me.BtnAsociar.ToolTipText = "Asociar punto de venta a una PC"
        '
        'TxtProcesador
        '
        Me.TxtProcesador.Enabled = False
        Me.TxtProcesador.Location = New System.Drawing.Point(170, 382)
        Me.TxtProcesador.Name = "TxtProcesador"
        Me.TxtProcesador.Size = New System.Drawing.Size(386, 20)
        Me.TxtProcesador.TabIndex = 104
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 384)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 23)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Asociar a una PC"
        '
        'ChkAgotamiento
        '
        Me.ChkAgotamiento.Checked = True
        Me.ChkAgotamiento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAgotamiento.Location = New System.Drawing.Point(134, 314)
        Me.ChkAgotamiento.Name = "ChkAgotamiento"
        Me.ChkAgotamiento.Size = New System.Drawing.Size(216, 23)
        Me.ChkAgotamiento.TabIndex = 23
        Me.ChkAgotamiento.Text = "Notificar Agotamiento de Productos"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(681, 258)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox10.TabIndex = 102
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(682, 208)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox8.TabIndex = 100
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(689, 89)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox7.TabIndex = 99
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(70, 203)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 98
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'ChkPrecios
        '
        Me.ChkPrecios.Checked = True
        Me.ChkPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrecios.Location = New System.Drawing.Point(15, 314)
        Me.ChkPrecios.Name = "ChkPrecios"
        Me.ChkPrecios.Size = New System.Drawing.Size(126, 23)
        Me.ChkPrecios.TabIndex = 22
        Me.ChkPrecios.Text = "Modificar Precios"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(450, 258)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(227, 21)
        Me.CmbCaja.TabIndex = 16
        '
        'BtnRedondeo
        '
        Me.BtnRedondeo.Image = CType(resources.GetObject("BtnRedondeo.Image"), System.Drawing.Image)
        Me.BtnRedondeo.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnRedondeo.Location = New System.Drawing.Point(574, 343)
        Me.BtnRedondeo.Name = "BtnRedondeo"
        Me.BtnRedondeo.Size = New System.Drawing.Size(35, 30)
        Me.BtnRedondeo.TabIndex = 26
        Me.BtnRedondeo.ToolTipText = "Elegir imagen"
        '
        'TxtImgRedondeo
        '
        Me.TxtImgRedondeo.Enabled = False
        Me.TxtImgRedondeo.Location = New System.Drawing.Point(170, 349)
        Me.TxtImgRedondeo.Name = "TxtImgRedondeo"
        Me.TxtImgRedondeo.Size = New System.Drawing.Size(386, 20)
        Me.TxtImgRedondeo.TabIndex = 92
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 352)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(142, 22)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "Img. Programa Redondeo"
        '
        'ChkRedondeo
        '
        Me.ChkRedondeo.Checked = True
        Me.ChkRedondeo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkRedondeo.Location = New System.Drawing.Point(134, 292)
        Me.ChkRedondeo.Name = "ChkRedondeo"
        Me.ChkRedondeo.Size = New System.Drawing.Size(189, 22)
        Me.ChkRedondeo.TabIndex = 18
        Me.ChkRedondeo.Text = "Aplicar Programa Redondeo"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(70, 146)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 76
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(14, 233)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(69, 15)
        Me.Almacen.TabIndex = 89
        Me.Almacen.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(93, 230)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(227, 21)
        Me.CmbAlmacen.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(400, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 15)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Ticket"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbTicket
        '
        Me.CmbTicket.Location = New System.Drawing.Point(450, 204)
        Me.CmbTicket.Name = "CmbTicket"
        Me.CmbTicket.Size = New System.Drawing.Size(227, 21)
        Me.CmbTicket.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(72, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 14)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Cte. Mostrador"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(384, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 12)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Fase"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFase
        '
        Me.cmbFase.Location = New System.Drawing.Point(457, 84)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(227, 21)
        Me.cmbFase.TabIndex = 12
        '
        'ChkPagos
        '
        Me.ChkPagos.Checked = True
        Me.ChkPagos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPagos.Location = New System.Drawing.Point(14, 292)
        Me.ChkPagos.Name = "ChkPagos"
        Me.ChkPagos.Size = New System.Drawing.Size(92, 22)
        Me.ChkPagos.TabIndex = 17
        Me.ChkPagos.Text = "Activar Caja"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(357, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 19)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Supervisor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUsuario
        '
        Me.cmbUsuario.Location = New System.Drawing.Point(457, 115)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(227, 21)
        Me.cmbUsuario.TabIndex = 13
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(93, 32)
        Me.TxtNombre.Mask = "0#########"
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(120, 20)
        Me.TxtNombre.TabIndex = 1
        Me.TxtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(626, 10)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(68, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.Location = New System.Drawing.Point(93, 203)
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(227, 21)
        Me.cmbImpresora.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(14, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Imp. Ticket"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(93, 59)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(275, 20)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(14, 32)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(218, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'TxtFrase
        '
        Me.TxtFrase.Location = New System.Drawing.Point(93, 86)
        Me.TxtFrase.Name = "TxtFrase"
        Me.TxtFrase.Size = New System.Drawing.Size(275, 20)
        Me.TxtFrase.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Saludo Inicial"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(72, 63)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(689, 121)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox5.TabIndex = 77
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(14, 62)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Descripción"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(589, 518)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 16
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(687, 518)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 15
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPDV
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(723, 557)
        Me.Name = "FrmPDV"
        Me.Text = "Punto de Venta"
        Me.GrpPDV.ResumeLayout(False)
        Me.GrpPDV.PerformLayout()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumCaracteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumLineas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String = ""
    Public PDVClave As String = ""
    Public Referencia As String = ""
    Public Descripcion As String = ""
    Public Estado As Integer = 1
    Public Fase As Integer = 0
    Public Supervisor As String = ""
    Public Mostrador As String = ""
    Public CreditoGeneral As String = ""
    Public Caja As Integer = 0
    Public CAJClave As String = ""
    Public ModPrecio As Integer = 0
    Public ModPrecioServicio As Integer
    Public Redondeo As Integer = 0
    Public Devolucion As Integer = 0
    Public ValidaInventario As Integer = 0
    Public Agotamiento As Integer = 0
    Public Url_Redondeo As String = ""
    Public Frase As String = ""
    Public TIKClave As String = ""
    Public ALMClave As String = ""
    Public Procesador As String = ""
    Public Tipo As Integer = 1
    Public SolicitaVendedor As Integer
    Public SUCClave As String = ""
    Public PRNClave As String = ""
    Public PRNClavePic As String = ""
    Public NumTickets As Integer = 0

    Public Port As String = "COM5"
    Public BaudRate As Integer = 9600
    Public MaxCaracteres As Integer = 20
    Public NoLineas As Integer = 2
    Public Display As Integer = 0
    Public ActivarCotizacion As Integer = 1
    Public GridView As Integer = 0

    Public TipoVenta As Integer = 1

    Private alerta(13) As PictureBox
    Private reloj As parpadea
    Private bLoad As Boolean = False


    Private sMostrador, sCredito As String


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 10 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 10)

        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If

        If Me.TxtFrase.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 100 Then
            Me.TxtFrase.Text = Me.TxtFrase.Text.Substring(0, 100)

        End If


        If sMostrador = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbUsuario.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbImpresora.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFase.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTicket.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbCaja.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbTipoVenta.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "PuntodeVenta", "@clave", UCase(Trim(Me.TxtNombre.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox23

        Dim Cnx As String

        Cnx = ModPOS.BDConexion


        With Me.cmbUsuario
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_usuario"
            .llenar()
        End With

        With Me.cmbFase
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "PuntodeVenta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Fase"
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "PuntodeVenta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        bLoad = True

        Dim dt As DataTable


        With Me.CmbTicket
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_ticket"
            .NombreParametro1 = "Tipo"
            .Parametro1 = 1
            .NombreParametro2 = "SUCClave"
            .Parametro2 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        With Me.cmbImpresora
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With


        With Me.cmbPicking
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_impresora"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With


        TxtNombre.Text = Referencia
        TxtDescripcion.Text = Descripcion
        cmbImpresora.SelectedValue = PRNClave
        cmbPicking.SelectedValue = PRNClavePic
        cmbUsuario.SelectedValue = Supervisor
        sMostrador = Mostrador
        sCredito = CreditoGeneral
        cmbFase.SelectedValue = Fase
        CmbCaja.SelectedValue = CAJClave
        CmbTipo.SelectedValue = Tipo
        ChkPagos.Estado = Caja
        ChkRedondeo.Estado = Redondeo
        ChkEstado.Estado = Estado
        ChkAgotamiento.Estado = Agotamiento
        TxtFrase.Text = Frase
        CmbTicket.SelectedValue = TIKClave
        CmbSucursal.SelectedValue = SUCClave
        CmbAlmacen.SelectedValue = ALMClave
        TxtImgRedondeo.Text = Url_Redondeo
        TxtProcesador.Text = Procesador
        ChkPrecios.Estado = ModPrecio
        ChkPrecioServicio.Estado = ModPrecioServicio
        ChkSolicitaVendedor.Estado = SolicitaVendedor
        ChkActivaDevolucion.Estado = Devolucion
        ChkValidaInventario.Estado = ValidaInventario
        NumCopias.Value = NumTickets

        cmbPuerto.DataSource = SerialPort.GetPortNames

        TxtBaudRate.Text = BaudRate
        NumCaracteres.Value = MaxCaracteres
        NumLineas.Value = NoLineas
        cmbPuerto.SelectedItem = Port
        ChkDisplay.Estado = Display
        ChkActivarCotizacion.Estado = ActivarCotizacion
        ChkGridView.Estado = GridView

        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", Mostrador)
        If dt.Rows.Count > 0 Then
            TxtMostrador.Text = dt.Rows(0)("Clave")
            LblCliente.Text = dt.Rows(0)("RazonSocial")
        Else
            TxtMostrador.Text = ""
            LblCliente.Text = ""

        End If
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CreditoGeneral)
        If dt.Rows.Count > 0 Then
            TxtCredito.Text = dt.Rows(0)("Clave")
            LblCredito.Text = dt.Rows(0)("RazonSocial")
        Else
            TxtCredito.Text = ""
            LblCredito.Text = ""
        End If

        cmbTipoVenta.SelectedItem = IIf(TipoVenta = 0, "Cte. Mostrador", "Ultimo Cliente")


        dt.Dispose()

    End Sub

    Public Sub reinicializa()

        Referencia = ""
        Descripcion = ""
        PRNClave = ""
        PRNClavePic = ""
        Supervisor = ""
        Mostrador = ""
        CreditoGeneral = ""
        Fase = 0
        Estado = 1
        Caja = 0
        CAJClave = ""
        ModPrecio = 0
        ModPrecioServicio = 0
        Redondeo = 0
        Agotamiento = 0
        Devolucion = 0
        Url_Redondeo = ""
        Frase = ""
        TIKClave = ""
        ALMClave = ""
        SUCClave = ""
        Procesador = ""
        Tipo = 1
        SolicitaVendedor = 0
        NumTickets = 0
        ValidaInventario = 0
        GridView = 0

        Port = "COM5"
        BaudRate = 9600
        MaxCaracteres = 20
        NoLineas = 2
        Display = 0
        ActivarCotizacion = 1


        TxtMostrador.Text = ""
        TxtCredito.Text = ""
        LblCliente.Text = ""
        LblCredito.Text = ""

        TxtNombre.Text = Referencia
        TxtDescripcion.Text = Descripcion
        cmbImpresora.SelectedValue = PRNClave
        cmbUsuario.SelectedValue = Supervisor
        sMostrador = Mostrador
        sCredito = CreditoGeneral
        cmbFase.SelectedValue = Fase
        CmbCaja.SelectedValue = CAJClave
        CmbTipo.SelectedValue = Tipo
        ChkPagos.Estado = Caja
        ChkRedondeo.Estado = Redondeo
        ChkEstado.Estado = Estado
        ChkAgotamiento.Estado = Agotamiento
        TxtFrase.Text = Frase
        CmbTicket.SelectedValue = TIKClave
        CmbAlmacen.SelectedValue = ALMClave
        CmbSucursal.SelectedValue = SUCClave
        TxtImgRedondeo.Text = Url_Redondeo
        TxtProcesador.Text = Procesador
        ChkPrecios.Estado = ModPrecio
        ChkPrecioServicio.Estado = ModPrecioServicio
        ChkSolicitaVendedor.Estado = SolicitaVendedor
        ChkActivaDevolucion.Estado = Devolucion
        ChkValidaInventario.Estado = ValidaInventario
        NumCopias.Value = NumTickets

        ChkGridView.Estado = GridView

        cmbPuerto.SelectedItem = Port
        TxtBaudRate.Text = BaudRate
        NumCaracteres.Value = MaxCaracteres
        NumLineas.Value = NoLineas
        ChkDisplay.Estado = Display
        ChkActivarCotizacion.Estado = ActivarCotizacion
        cmbPicking.SelectedValue = PRNClavePic
    End Sub

    Private Sub FrmPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.PDV.Dispose()
        ModPOS.PDV = Nothing
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"
                    TipoVenta = IIf(cmbTipoVenta.SelectedItem = "Cte. Mostrador", 0, 1)

                    CreditoGeneral = sCredito
                    PDVClave = ModPOS.obtenerLlave
                    Referencia = UCase(Trim(Me.TxtNombre.Text))
                    Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                    PRNClave = cmbImpresora.SelectedValue
                    PRNClavePic = cmbPicking.SelectedValue
                    Frase = UCase(Trim(Me.TxtFrase.Text))
                    TIKClave = CmbTicket.SelectedValue
                    ALMClave = CmbAlmacen.SelectedValue
                    SUCClave = CmbSucursal.SelectedValue
                    ModPrecio = ChkPrecios.GetEstado
                    ModPrecioServicio = ChkPrecioServicio.GetEstado
                    Supervisor = cmbUsuario.SelectedValue
                    Fase = cmbFase.SelectedValue
                    Caja = ChkPagos.GetEstado
                    Redondeo = ChkRedondeo.GetEstado
                    Agotamiento = ChkAgotamiento.GetEstado
                    Url_Redondeo = TxtImgRedondeo.Text
                    Mostrador = sMostrador
                    Procesador = TxtProcesador.Text
                    Tipo = CmbTipo.SelectedValue
                    CAJClave = CmbCaja.SelectedValue
                    SolicitaVendedor = ChkSolicitaVendedor.GetEstado
                    NumTickets = NumCopias.Value
                    Devolucion = ChkActivaDevolucion.GetEstado
                    ValidaInventario = ChkValidaInventario.GetEstado
                    GridView = ChkGridView.GetEstado

                    BaudRate = TxtBaudRate.Text
                    MaxCaracteres = NumCaracteres.Value
                    NoLineas = NumLineas.Value
                    Port = cmbPuerto.SelectedItem
                    Display = ChkDisplay.GetEstado
                    ActivarCotizacion = ChkActivarCotizacion.GetEstado

                    ModPOS.Ejecuta("sp_inserta_pdv", _
                    "@PDVClave", PDVClave, _
                    "@PRNClave", PRNClave, _
                    "@Referencia", Referencia, _
                    "@Descripcion", Descripcion, _
                    "@Supervisor", Supervisor, _
                    "@Mostrador", Mostrador, _
                    "@Fase", Fase, _
                    "@Caja", Caja, _
                    "@CAJClave", CAJClave, _
                    "@Frase", Frase, _
                    "@TIKClave", TIKClave, _
                    "@ALMClave", ALMClave, _
                    "@Redondeo", Redondeo, _
                    "@ImgRedondeo", Url_Redondeo, _
                    "@CambiaPrecio", ModPrecio, _
                    "@Agotamiento", Agotamiento, _
                    "@ModPrecioServicio", ModPrecioServicio, _
                    "@Procesador", Procesador, _
                    "@Tipo", Tipo, _
                    "@SolicitaVendedor", SolicitaVendedor, _
                    "@SUCClave", SUCClave, _
                    "@CreditoGeneral", CreditoGeneral, _
                    "@Devolucion", Devolucion, _
                    "@ValidaInventario", ValidaInventario, _
                    "@NumTickets", NumTickets, _
                    "@Display", Display, _
                    "@Puerto", Port, _
                    "@BaudRate", BaudRate, _
                    "NoLineas", NoLineas, _
                    "@MaxCaracteres", MaxCaracteres, _
                    "@ActivarCotizacion", ActivarCotizacion, _
                    "@PRNClavePic", PRNClavePic, _
                    "@TipoVenta", TipoVenta, _
                    "@GridView", GridView, _
                    "@Usuario", ModPOS.UsuarioActual)


                    If Not ModPOS.MtoPDV Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoPDV.GridPDV, "sp_muestra_pdv", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoPDV.GridPDV.RootTable.Columns("PDVClave").Visible = False
                    End If


                    reinicializa()

                Case "Modificar"
                   
                    If Not (Estado = ChkEstado.GetEstado AndAlso _
                    Descripcion = TxtDescripcion.Text AndAlso _
                    PRNClave = cmbImpresora.SelectedValue AndAlso _
                    CAJClave = CmbCaja.SelectedValue AndAlso _
                    Supervisor = cmbUsuario.SelectedValue AndAlso _
                    Mostrador = sMostrador AndAlso _
                    CreditoGeneral = sCredito AndAlso _
                    Devolucion = ChkActivaDevolucion.GetEstado AndAlso _
                    ValidaInventario = ChkValidaInventario.GetEstado AndAlso _
                    Fase = cmbFase.SelectedValue AndAlso _
                    Frase = UCase(Trim(Me.TxtFrase.Text)) AndAlso _
                    TIKClave = CmbTicket.SelectedValue AndAlso _
                    ALMClave = CmbAlmacen.SelectedValue AndAlso _
                    Redondeo = ChkRedondeo.GetEstado AndAlso _
                    Url_Redondeo = TxtImgRedondeo.Text AndAlso _
                    ModPrecio = ChkPrecios.GetEstado AndAlso _
                    Agotamiento = ChkAgotamiento.GetEstado AndAlso _
                    ModPrecioServicio = ChkPrecioServicio.GetEstado AndAlso _
                    Procesador = TxtProcesador.Text AndAlso _
                    Tipo = CmbTipo.SelectedValue AndAlso _
                    SolicitaVendedor = ChkSolicitaVendedor.GetEstado AndAlso _
                    SUCClave = CmbSucursal.SelectedValue AndAlso _
                    NumTickets = NumCopias.Value AndAlso _
                    Caja = ChkPagos.GetEstado AndAlso _
                    BaudRate = TxtBaudRate.Text AndAlso _
                    MaxCaracteres = NumCaracteres.Value AndAlso _
                    NoLineas = NumLineas.Value AndAlso _
                    Port = cmbPuerto.SelectedItem AndAlso _
                    Display = ChkDisplay.GetEstado AndAlso _
                    PRNClavePic = cmbPicking.SelectedValue AndAlso _
                    TipoVenta = IIf(cmbTipoVenta.SelectedItem = "Cte. Mostrador", 0, 1) AndAlso _
                    ActivarCotizacion = ChkActivarCotizacion.GetEstado AndAlso _
                    GridView = ChkGridView.GetEstado) Then


                        TipoVenta = IIf(cmbTipoVenta.SelectedItem = "Cte. Mostrador", 0, 1)
                        Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                        Estado = ChkEstado.GetEstado
                        PRNClave = cmbImpresora.SelectedValue
                        PRNClavePic = cmbPicking.SelectedValue
                        Mostrador = sMostrador
                        CAJClave = CmbCaja.SelectedValue
                        Supervisor = cmbUsuario.SelectedValue
                        Fase = cmbFase.SelectedValue
                        Caja = ChkPagos.GetEstado
                        Frase = UCase(Trim(Me.TxtFrase.Text))
                        TIKClave = CmbTicket.SelectedValue
                        ALMClave = CmbAlmacen.SelectedValue
                        SUCClave = CmbSucursal.SelectedValue
                        Redondeo = ChkRedondeo.GetEstado
                        Agotamiento = ChkAgotamiento.GetEstado
                        ModPrecioServicio = ChkPrecioServicio.GetEstado
                        Url_Redondeo = TxtImgRedondeo.Text
                        ModPrecio = ChkPrecios.GetEstado
                        Procesador = TxtProcesador.Text
                        Tipo = CmbTipo.SelectedValue
                        SolicitaVendedor = ChkSolicitaVendedor.GetEstado
                        CreditoGeneral = sCredito
                        Devolucion = ChkActivaDevolucion.GetEstado
                        NumTickets = NumCopias.Value
                        ValidaInventario = ChkValidaInventario.GetEstado
                        GridView = ChkGridView.GetEstado

                        BaudRate = TxtBaudRate.Text
                        MaxCaracteres = NumCaracteres.Value
                        NoLineas = NumLineas.Value
                        Port = cmbPuerto.SelectedItem
                        Display = ChkDisplay.GetEstado

                        ActivarCotizacion = ChkActivarCotizacion.GetEstado

                        ModPOS.Ejecuta("sp_actualiza_pdv", _
                        "@PDVClave", PDVClave, _
                        "@Descripcion", Descripcion, _
                        "@Supervisor", Supervisor, _
                        "@Mostrador", Mostrador, _
                        "@CAJClave", CAJClave, _
                        "@Fase", Fase, _
                        "@Caja", Caja, _
                        "@Frase", Frase, _
                        "@TIKClave", TIKClave, _
                        "@ALMClave", ALMClave, _
                        "@Redondeo", Redondeo, _
                        "@CambiaPrecio", ModPrecio, _
                        "@ImgRedondeo", Url_Redondeo, _
                        "@Estado", Estado, _
                        "@PRNClave", PRNClave, _
                        "@Agotamiento", Agotamiento, _
                        "@ModPrecioServicio", ModPrecioServicio, _
                        "@Procesador", Procesador, _
                        "@Tipo", Tipo, _
                        "@SolicitaVendedor", SolicitaVendedor, _
                        "@SUCClave", SUCClave, _
                        "@CreditoGeneral", CreditoGeneral, _
                        "@Devolucion", Devolucion, _
                        "@NumTickets", NumTickets, _
                        "@ValidaInventario", ValidaInventario, _
                        "@Display", Display, _
                        "@Puerto", Port, _
                        "@BaudRate", BaudRate, _
                        "NoLineas", NoLineas, _
                        "@MaxCaracteres", MaxCaracteres, _
                        "@ActivarCotizacion", ActivarCotizacion, _
                        "@PRNClavePic", PRNClavePic, _
                        "@TipoVenta", TipoVenta, _
                        "@GridView", GridView, _
                        "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoPDV Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoPDV.GridPDV, "sp_muestra_pdv", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoPDV.GridPDV.RootTable.Columns("PDVClave").Visible = False
                        End If
                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnRedondeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRedondeo.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        If (result = DialogResult.OK) Then

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.SuspendLayout()

            TxtImgRedondeo.Text = OpenFileDialog1.FileName

        End If

    End Sub


    Private Sub BtnAsociar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsociar.Click
        Me.TxtProcesador.Text = ModPOS.GetProcessorId
    End Sub


    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then


            With Me.CmbTicket
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_ticket"
                .NombreParametro1 = "Tipo"
                .Parametro1 = 1
                .NombreParametro2 = "SUCClave"
                .Parametro2 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With Me.cmbImpresora
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_impresora"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With


            With Me.cmbPicking
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_impresora"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With CmbCaja
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

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
                sMostrador = a.valor
                TxtMostrador.Text = a.Descripcion
                LblCliente.Text = a.Descripcion2
            End If
        End If
        a.Dispose()

    End Sub

    Private Sub btnBuscaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCredito.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                sCredito = a.valor
                TxtCredito.Text = a.Descripcion
                LblCredito.Text = a.Descripcion2
            End If
        End If
        a.Dispose()


    End Sub

End Class
