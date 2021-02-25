Public Class MeFiltroVenta
    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private Sucursal As String
    Public Titulo As String
    Private Tipo As Integer
    Private Estado As Integer
    Private Todos As Integer
    Private bError As Boolean = False
    Private TallaColor As Integer = 0

    Public Tabla As String = "Venta"
    Public Campo As String = "Tipo"
    Public bFactura As Boolean = False

    Public CTEClave As String = ""
    Public PROClave As String = ""
    Public USRClave As String = ""

    Private alerta(3) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbVenta As Selling.StoreCombo
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents ChkCanceladas As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents ChkVendedores As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClientes As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProductos As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscaVen As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaPro As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Private reloj As parpadea

    Public ReadOnly Property SucursalOrigen() As String
        Get
            SucursalOrigen = Sucursal
        End Get
    End Property

    Public ReadOnly Property FechaInicio() As String
        Get
            FechaInicio = FechaIni
        End Get
    End Property

    Public ReadOnly Property FechaFinal() As String
        Get
            FechaFinal = FechaFin
        End Get
    End Property


    Public ReadOnly Property VentaTipo() As Integer
        Get
            VentaTipo = Tipo
        End Get
    End Property

    Public ReadOnly Property VentaEstado() As Integer
        Get
            VentaEstado = Estado
        End Get
    End Property

    Public ReadOnly Property VentasTodos() As Integer
        Get
            VentasTodos = Todos
        End Get
    End Property



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroVenta))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.ChkCanceladas = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.ChkVendedores = New System.Windows.Forms.CheckBox()
        Me.ChkClientes = New System.Windows.Forms.CheckBox()
        Me.ChkProductos = New System.Windows.Forms.CheckBox()
        Me.btnBuscaVen = New Janus.Windows.EditControls.UIButton()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBuscaPro = New Janus.Windows.EditControls.UIButton()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbVenta = New Selling.StoreCombo()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.CmbFechaFin)
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(495, 44)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(306, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "AL"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(458, 17)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(153, 16)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(334, 15)
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Size = New System.Drawing.Size(119, 20)
        Me.CmbFechaFin.TabIndex = 69
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(46, 15)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 20)
        Me.cmbFechaInicio.TabIndex = 68
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "DEL"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(414, 249)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(314, 249)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(6, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Sucursal"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(489, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 17)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblTipo.Location = New System.Drawing.Point(127, 162)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(39, 17)
        Me.lblTipo.TabIndex = 79
        Me.lblTipo.Text = "Tipo "
        '
        'ChkCanceladas
        '
        Me.ChkCanceladas.Location = New System.Drawing.Point(395, 160)
        Me.ChkCanceladas.Name = "ChkCanceladas"
        Me.ChkCanceladas.Size = New System.Drawing.Size(119, 19)
        Me.ChkCanceladas.TabIndex = 80
        Me.ChkCanceladas.Text = "Incluir Canceladas"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(150, 159)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 17)
        Me.PictureBox2.TabIndex = 81
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ChkTodos
        '
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(9, 159)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(112, 20)
        Me.ChkTodos.TabIndex = 82
        Me.ChkTodos.Text = "Todos los Tipos"
        '
        'ChkVendedores
        '
        Me.ChkVendedores.Checked = True
        Me.ChkVendedores.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkVendedores.Location = New System.Drawing.Point(9, 51)
        Me.ChkVendedores.Name = "ChkVendedores"
        Me.ChkVendedores.Size = New System.Drawing.Size(144, 20)
        Me.ChkVendedores.TabIndex = 83
        Me.ChkVendedores.Text = "Todos los Vendedores"
        '
        'ChkClientes
        '
        Me.ChkClientes.Checked = True
        Me.ChkClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkClientes.Location = New System.Drawing.Point(9, 83)
        Me.ChkClientes.Name = "ChkClientes"
        Me.ChkClientes.Size = New System.Drawing.Size(124, 20)
        Me.ChkClientes.TabIndex = 84
        Me.ChkClientes.Text = "Todos los Clientes"
        '
        'ChkProductos
        '
        Me.ChkProductos.Checked = True
        Me.ChkProductos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkProductos.Location = New System.Drawing.Point(9, 117)
        Me.ChkProductos.Name = "ChkProductos"
        Me.ChkProductos.Size = New System.Drawing.Size(194, 20)
        Me.ChkProductos.TabIndex = 85
        Me.ChkProductos.Text = "Todos los Productos"
        '
        'btnBuscaVen
        '
        Me.btnBuscaVen.Icon = CType(resources.GetObject("btnBuscaVen.Icon"), System.Drawing.Icon)
        Me.btnBuscaVen.Image = CType(resources.GetObject("btnBuscaVen.Image"), System.Drawing.Image)
        Me.btnBuscaVen.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaVen.Location = New System.Drawing.Point(445, 43)
        Me.btnBuscaVen.Name = "btnBuscaVen"
        Me.btnBuscaVen.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaVen.TabIndex = 129
        Me.btnBuscaVen.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaVen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Location = New System.Drawing.Point(317, 48)
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(120, 20)
        Me.TxtVendedor.TabIndex = 131
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(238, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 14)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "Vendedor"
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(445, 78)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaCte.TabIndex = 132
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(317, 83)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(120, 20)
        Me.TxtCliente.TabIndex = 134
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(238, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Cliente"
        '
        'btnBuscaPro
        '
        Me.btnBuscaPro.Icon = CType(resources.GetObject("btnBuscaPro.Icon"), System.Drawing.Icon)
        Me.btnBuscaPro.Image = CType(resources.GetObject("btnBuscaPro.Image"), System.Drawing.Image)
        Me.btnBuscaPro.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaPro.Location = New System.Drawing.Point(445, 112)
        Me.btnBuscaPro.Name = "btnBuscaPro"
        Me.btnBuscaPro.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaPro.TabIndex = 135
        Me.btnBuscaPro.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaPro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtProducto
        '
        Me.TxtProducto.Location = New System.Drawing.Point(317, 117)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.ReadOnly = True
        Me.TxtProducto.Size = New System.Drawing.Size(120, 20)
        Me.TxtProducto.TabIndex = 137
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(238, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Producto"
        '
        'CmbVenta
        '
        Me.CmbVenta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbVenta.BackColor = System.Drawing.SystemColors.Window
        Me.CmbVenta.Enabled = False
        Me.CmbVenta.Location = New System.Drawing.Point(172, 159)
        Me.CmbVenta.Name = "CmbVenta"
        Me.CmbVenta.Size = New System.Drawing.Size(206, 21)
        Me.CmbVenta.TabIndex = 78
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(55, 11)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(428, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'MeFiltroVenta
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(510, 291)
        Me.Controls.Add(Me.btnBuscaPro)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscaVen)
        Me.Controls.Add(Me.TxtVendedor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ChkProductos)
        Me.Controls.Add(Me.ChkClientes)
        Me.Controls.Add(Me.ChkVendedores)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ChkCanceladas)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.CmbVenta)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 214)
        Me.Name = "MeFiltroVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub MeFiltroFac_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            Sucursal = CmbSucursal.SelectedValue
            Tipo = CmbVenta.SelectedValue
            If ChkCanceladas.Checked Then
                Estado = 1
            Else
                Estado = 0
            End If
            If ChkTodos.Checked Then
                Todos = 1
            Else
                Todos = 0
            End If
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox1
        alerta(3) = Me.PictureBox2

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        With CmbVenta
            .Conexion = ModPOS.BDConexion
            If bFactura = True Then

                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Factura"
                .NombreParametro2 = "campo"
                .Parametro2 = "Tipo"
            Else
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = Tabla
                .NombreParametro2 = "campo"
                .Parametro2 = Campo
            End If
            .llenar()
        End With



        Me.Text = Titulo

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
    End Sub


    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.Checked Then
            CmbVenta.Enabled = False
        Else
            CmbVenta.Enabled = True
        End If
    End Sub


    Private Sub btnBuscaCte_Click(sender As Object, e As EventArgs) Handles btnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                TxtCliente.Text = a.Descripcion
                ChkClientes.Checked = False
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub ChkClientes_CheckedChanged(sender As Object, e As EventArgs) Handles ChkClientes.CheckedChanged
        If ChkClientes.Checked = True Then
            TxtCliente.Text = ""
            CTEClave = ""
        End If
    End Sub

    Private Sub btnBuscaVen_Click(sender As Object, e As EventArgs) Handles btnBuscaVen.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.BusquedaInicial = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                TxtVendedor.Text = a.Descripcion2
                USRClave = a.valor
                ChkVendedores.Checked = False
              End If
        End If
        a.Dispose()

    End Sub


    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_found_producto", "@Clave", sClave)
        If Not dtProducto Is Nothing Then
            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta
            PROClave = dtProducto.Rows(0)("PROClave")
            TxtProducto.Text = dtProducto.Rows(0)("Clave")
            ChkProductos.Checked = False
            dtProducto.Dispose()
        Else
            PROClave = ""
            TxtProducto.Text = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnBuscaPro_Click(sender As Object, e As EventArgs) Handles btnBuscaPro.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then

            recuperaProducto(a.valor)
        End If
        a.Dispose()

    End Sub

    Private Sub ChkProductos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkProductos.CheckedChanged
        If ChkProductos.Checked = True Then
            TxtProducto.Text = ""
            PROClave = ""
        End If
    End Sub

    Private Sub ChkVendedores_CheckedChanged(sender As Object, e As EventArgs) Handles ChkVendedores.CheckedChanged
        If ChkVendedores.Checked = True Then
            TxtVendedor.Text = ""
            USRClave = ""
        End If
    End Sub
End Class
