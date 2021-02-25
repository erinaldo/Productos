Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmConfirmacion
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNotas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpDocumentos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDoc As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaDoc As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDoctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTransporte As System.Windows.Forms.TextBox
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents BtnTransporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents BtnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtOperador As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnAnden As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtAnden As System.Windows.Forms.TextBox
    Friend WithEvents btnFinalizar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbMotivo As Selling.StoreCombo
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    Friend WithEvents LblEstrategia As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAddEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents UiTabRecibo As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabDetalle As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabSobrante As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSobrantes As System.Windows.Forms.GroupBox
    Friend WithEvents GridSobrante As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnParcial As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfirmacion))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnBuscaUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.BtnAnden = New Janus.Windows.EditControls.UIButton()
        Me.TxtAnden = New System.Windows.Forms.TextBox()
        Me.BtnOperador = New Janus.Windows.EditControls.UIButton()
        Me.TxtOperador = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTransporte = New System.Windows.Forms.TextBox()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.BtnTransporte = New Janus.Windows.EditControls.UIButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtNotas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnAddEst = New Janus.Windows.EditControls.UIButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.LblEstrategia = New System.Windows.Forms.Label()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.cmbMotivo = New Selling.StoreCombo()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpDocumentos = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.TxtDoc = New System.Windows.Forms.TextBox()
        Me.BtnBuscaDoc = New Janus.Windows.EditControls.UIButton()
        Me.GridDoctos = New Janus.Windows.GridEX.GridEX()
        Me.btnFinalizar = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.UiTabRecibo = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabDetalle = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabSobrante = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpSobrantes = New System.Windows.Forms.GroupBox()
        Me.GridSobrante = New Janus.Windows.GridEX.GridEX()
        Me.btnParcial = New Janus.Windows.EditControls.UIButton()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDocumentos.SuspendLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTabRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabRecibo.SuspendLayout()
        Me.UiTabDetalle.SuspendLayout()
        Me.UiTabSobrante.SuspendLayout()
        Me.GrpSobrantes.SuspendLayout()
        CType(Me.GridSobrante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label3)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaUbicacion)
        Me.GrpGeneral.Controls.Add(Me.TxtUbicacion)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.dtFecha)
        Me.GrpGeneral.Controls.Add(Me.cmbEstado)
        Me.GrpGeneral.Controls.Add(Me.BtnAnden)
        Me.GrpGeneral.Controls.Add(Me.TxtAnden)
        Me.GrpGeneral.Controls.Add(Me.BtnOperador)
        Me.GrpGeneral.Controls.Add(Me.TxtOperador)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.lblFecha)
        Me.GrpGeneral.Controls.Add(Me.LblEstado)
        Me.GrpGeneral.Controls.Add(Me.Label9)
        Me.GrpGeneral.Controls.Add(Me.txtNombre)
        Me.GrpGeneral.Controls.Add(Me.Label14)
        Me.GrpGeneral.Controls.Add(Me.txtTransporte)
        Me.GrpGeneral.Controls.Add(Me.txtPlacas)
        Me.GrpGeneral.Controls.Add(Me.BtnTransporte)
        Me.GrpGeneral.Controls.Add(Me.Label10)
        Me.GrpGeneral.Controls.Add(Me.TxtFolio)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.Label8)
        Me.GrpGeneral.Controls.Add(Me.TxtNotas)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(870, 188)
        Me.GrpGeneral.TabIndex = 2
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(510, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 18)
        Me.Label3.TabIndex = 167
        Me.Label3.Text = "Ubicación de Recibo"
        '
        'BtnBuscaUbicacion
        '
        Me.BtnBuscaUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaUbicacion.Image = CType(resources.GetObject("BtnBuscaUbicacion.Image"), System.Drawing.Image)
        Me.BtnBuscaUbicacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaUbicacion.Location = New System.Drawing.Point(821, 145)
        Me.BtnBuscaUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaUbicacion.Name = "BtnBuscaUbicacion"
        Me.BtnBuscaUbicacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaUbicacion.TabIndex = 166
        Me.BtnBuscaUbicacion.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(684, 150)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(131, 21)
        Me.TxtUbicacion.TabIndex = 165
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(84, 113)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox4.TabIndex = 164
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(83, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox3.TabIndex = 163
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(83, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 162
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(83, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox1.TabIndex = 161
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'dtFecha
        '
        Me.dtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtFecha.CustomFormat = "MMMM yyyy"
        Me.dtFecha.Enabled = False
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(689, 15)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.ShowUpDown = True
        Me.dtFecha.Size = New System.Drawing.Size(147, 20)
        Me.dtFecha.TabIndex = 149
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.Location = New System.Drawing.Point(689, 44)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(147, 21)
        Me.cmbEstado.TabIndex = 148
        '
        'BtnAnden
        '
        Me.BtnAnden.Image = CType(resources.GetObject("BtnAnden.Image"), System.Drawing.Image)
        Me.BtnAnden.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnAnden.Location = New System.Drawing.Point(218, 45)
        Me.BtnAnden.Name = "BtnAnden"
        Me.BtnAnden.Size = New System.Drawing.Size(35, 22)
        Me.BtnAnden.TabIndex = 147
        Me.BtnAnden.ToolTipText = "Busqueda de Anden"
        Me.BtnAnden.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtAnden
        '
        Me.TxtAnden.Enabled = False
        Me.TxtAnden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAnden.Location = New System.Drawing.Point(116, 45)
        Me.TxtAnden.Name = "TxtAnden"
        Me.TxtAnden.ReadOnly = True
        Me.TxtAnden.Size = New System.Drawing.Size(98, 21)
        Me.TxtAnden.TabIndex = 146
        '
        'BtnOperador
        '
        Me.BtnOperador.Image = CType(resources.GetObject("BtnOperador.Image"), System.Drawing.Image)
        Me.BtnOperador.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnOperador.Location = New System.Drawing.Point(218, 113)
        Me.BtnOperador.Name = "BtnOperador"
        Me.BtnOperador.Size = New System.Drawing.Size(35, 22)
        Me.BtnOperador.TabIndex = 145
        Me.BtnOperador.ToolTipText = "Busqueda de Operador"
        Me.BtnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtOperador
        '
        Me.TxtOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtOperador.Location = New System.Drawing.Point(116, 115)
        Me.TxtOperador.Name = "TxtOperador"
        Me.TxtOperador.Size = New System.Drawing.Size(96, 21)
        Me.TxtOperador.TabIndex = 144
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(274, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 143
        Me.Label4.Text = "Nombre"
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(635, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(59, 15)
        Me.lblFecha.TabIndex = 100
        Me.lblFecha.Text = "Fecha:"
        '
        'LblEstado
        '
        Me.LblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.Location = New System.Drawing.Point(635, 47)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(59, 14)
        Me.LblEstado.TabIndex = 101
        Me.LblEstado.Text = "Estado:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(18, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Operador"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(335, 115)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(501, 20)
        Me.txtNombre.TabIndex = 140
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(274, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 15)
        Me.Label14.TabIndex = 139
        Me.Label14.Text = "Placas"
        '
        'txtTransporte
        '
        Me.txtTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtTransporte.Location = New System.Drawing.Point(116, 79)
        Me.txtTransporte.Name = "txtTransporte"
        Me.txtTransporte.Size = New System.Drawing.Size(96, 21)
        Me.txtTransporte.TabIndex = 135
        '
        'txtPlacas
        '
        Me.txtPlacas.Enabled = False
        Me.txtPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.Location = New System.Drawing.Point(335, 79)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.ReadOnly = True
        Me.txtPlacas.Size = New System.Drawing.Size(114, 21)
        Me.txtPlacas.TabIndex = 138
        '
        'BtnTransporte
        '
        Me.BtnTransporte.Image = CType(resources.GetObject("BtnTransporte.Image"), System.Drawing.Image)
        Me.BtnTransporte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnTransporte.Location = New System.Drawing.Point(218, 79)
        Me.BtnTransporte.Name = "BtnTransporte"
        Me.BtnTransporte.Size = New System.Drawing.Size(35, 22)
        Me.BtnTransporte.TabIndex = 136
        Me.BtnTransporte.ToolTipText = "Busqueda de Transporte"
        Me.BtnTransporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(18, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 15)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "Transporte"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(116, 16)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(221, 21)
        Me.TxtFolio.TabIndex = 134
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Anden"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(18, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Comentarios"
        '
        'TxtNotas
        '
        Me.TxtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotas.Location = New System.Drawing.Point(114, 151)
        Me.TxtNotas.Name = "TxtNotas"
        Me.TxtNotas.Size = New System.Drawing.Size(385, 21)
        Me.TxtNotas.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Folio"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(499, 551)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(787, 551)
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
        Me.GrpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.GrpDetalle.Controls.Add(Me.PictureBox5)
        Me.GrpDetalle.Controls.Add(Me.btnAddEst)
        Me.GrpDetalle.Controls.Add(Me.Label12)
        Me.GrpDetalle.Controls.Add(Me.Label11)
        Me.GrpDetalle.Controls.Add(Me.Label7)
        Me.GrpDetalle.Controls.Add(Me.Label6)
        Me.GrpDetalle.Controls.Add(Me.LblCantidad)
        Me.GrpDetalle.Controls.Add(Me.LblEstrategia)
        Me.GrpDetalle.Controls.Add(Me.LblDescripcion)
        Me.GrpDetalle.Controls.Add(Me.LblClave)
        Me.GrpDetalle.Controls.Add(Me.cmbMotivo)
        Me.GrpDetalle.Controls.Add(Me.ChkTodos)
        Me.GrpDetalle.Controls.Add(Me.BtnRefresh)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.lblProducto)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(3, 5)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(701, 317)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(482, 39)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox5.TabIndex = 165
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'btnAddEst
        '
        Me.btnAddEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEst.Icon = CType(resources.GetObject("btnAddEst.Icon"), System.Drawing.Icon)
        Me.btnAddEst.Location = New System.Drawing.Point(648, 77)
        Me.btnAddEst.Name = "btnAddEst"
        Me.btnAddEst.Size = New System.Drawing.Size(47, 23)
        Me.btnAddEst.TabIndex = 177
        Me.btnAddEst.ToolTipText = "Agregar estrategia"
        Me.btnAddEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(507, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 15)
        Me.Label12.TabIndex = 176
        Me.Label12.Text = "Estrategia"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(443, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = "Cantidad"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(156, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(334, 15)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "Descripción"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 15)
        Me.Label6.TabIndex = 173
        Me.Label6.Text = "Clave"
        '
        'LblCantidad
        '
        Me.LblCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblCantidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.Location = New System.Drawing.Point(443, 84)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(58, 15)
        Me.LblCantidad.TabIndex = 172
        Me.LblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblEstrategia
        '
        Me.LblEstrategia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblEstrategia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblEstrategia.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstrategia.Location = New System.Drawing.Point(507, 84)
        Me.LblEstrategia.Name = "LblEstrategia"
        Me.LblEstrategia.Size = New System.Drawing.Size(135, 15)
        Me.LblEstrategia.TabIndex = 171
        Me.LblEstrategia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDescripcion
        '
        Me.LblDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblDescripcion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.Location = New System.Drawing.Point(156, 84)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(281, 15)
        Me.LblDescripcion.TabIndex = 170
        '
        'LblClave
        '
        Me.LblClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblClave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.Location = New System.Drawing.Point(10, 84)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(135, 15)
        Me.LblClave.TabIndex = 169
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.Location = New System.Drawing.Point(515, 39)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(180, 21)
        Me.cmbMotivo.TabIndex = 168
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(264, 38)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(104, 22)
        Me.ChkTodos.TabIndex = 167
        Me.ChkTodos.Text = "Confirmar Todo"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(659, 12)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 166
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.Visible = False
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(65, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 15)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 40)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(53, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(223, 38)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaProd.TabIndex = 3
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblProducto
        '
        Me.lblProducto.Location = New System.Drawing.Point(92, 19)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 15)
        Me.lblProducto.TabIndex = 98
        Me.lblProducto.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(92, 39)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(125, 21)
        Me.TxtProducto.TabIndex = 0
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
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 102)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(688, 209)
        Me.GridDetalle.TabIndex = 6
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpDocumentos
        '
        Me.GrpDocumentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpDocumentos.Controls.Add(Me.cmbTipo)
        Me.GrpDocumentos.Controls.Add(Me.BtnDel)
        Me.GrpDocumentos.Controls.Add(Me.TxtDoc)
        Me.GrpDocumentos.Controls.Add(Me.BtnBuscaDoc)
        Me.GrpDocumentos.Controls.Add(Me.GridDoctos)
        Me.GrpDocumentos.Location = New System.Drawing.Point(7, 198)
        Me.GrpDocumentos.Name = "GrpDocumentos"
        Me.GrpDocumentos.Size = New System.Drawing.Size(155, 348)
        Me.GrpDocumentos.TabIndex = 159
        Me.GrpDocumentos.TabStop = False
        Me.GrpDocumentos.Text = "Documentos"
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Traslado", "Compra", "Traspaso"})
        Me.cmbTipo.Location = New System.Drawing.Point(6, 40)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(144, 21)
        Me.cmbTipo.TabIndex = 139
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(75, 15)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(35, 22)
        Me.BtnDel.TabIndex = 17
        Me.BtnDel.ToolTipText = "Remueve el Ticket Seleccionado "
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDoc
        '
        Me.TxtDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDoc.Location = New System.Drawing.Point(6, 16)
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.Size = New System.Drawing.Size(63, 21)
        Me.TxtDoc.TabIndex = 15
        '
        'BtnBuscaDoc
        '
        Me.BtnBuscaDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaDoc.Image = CType(resources.GetObject("BtnBuscaDoc.Image"), System.Drawing.Image)
        Me.BtnBuscaDoc.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaDoc.Location = New System.Drawing.Point(114, 15)
        Me.BtnBuscaDoc.Name = "BtnBuscaDoc"
        Me.BtnBuscaDoc.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaDoc.TabIndex = 16
        Me.BtnBuscaDoc.ToolTipText = "Busqueda de Documentos"
        Me.BtnBuscaDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDoctos
        '
        Me.GridDoctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDoctos.ColumnAutoResize = True
        Me.GridDoctos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDoctos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDoctos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDoctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDoctos.Location = New System.Drawing.Point(6, 67)
        Me.GridDoctos.Name = "GridDoctos"
        Me.GridDoctos.RecordNavigator = True
        Me.GridDoctos.Size = New System.Drawing.Size(143, 276)
        Me.GridDoctos.TabIndex = 7
        Me.GridDoctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinalizar.Icon = CType(resources.GetObject("btnFinalizar.Icon"), System.Drawing.Icon)
        Me.btnFinalizar.Location = New System.Drawing.Point(691, 551)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(90, 37)
        Me.btnFinalizar.TabIndex = 160
        Me.btnFinalizar.Text = "&Finalizar"
        Me.btnFinalizar.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recolección"
        Me.btnFinalizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.Icon = CType(resources.GetObject("BtnImprimir.Icon"), System.Drawing.Icon)
        Me.BtnImprimir.Location = New System.Drawing.Point(595, 551)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnImprimir.TabIndex = 161
        Me.BtnImprimir.Text = "&Preliminar"
        Me.BtnImprimir.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recolección"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 180000
        '
        'UiTabRecibo
        '
        Me.UiTabRecibo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabRecibo.BackColor = System.Drawing.Color.Transparent
        Me.UiTabRecibo.Location = New System.Drawing.Point(167, 198)
        Me.UiTabRecibo.Name = "UiTabRecibo"
        Me.UiTabRecibo.Size = New System.Drawing.Size(710, 348)
        Me.UiTabRecibo.TabIndex = 162
        Me.UiTabRecibo.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabDetalle, Me.UiTabSobrante})
        Me.UiTabRecibo.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabDetalle
        '
        Me.UiTabDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabDetalle.Controls.Add(Me.GrpDetalle)
        Me.UiTabDetalle.Location = New System.Drawing.Point(1, 21)
        Me.UiTabDetalle.Name = "UiTabDetalle"
        Me.UiTabDetalle.Size = New System.Drawing.Size(708, 326)
        Me.UiTabDetalle.TabStop = True
        Me.UiTabDetalle.Text = "Detalle"
        '
        'UiTabSobrante
        '
        Me.UiTabSobrante.Controls.Add(Me.GrpSobrantes)
        Me.UiTabSobrante.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSobrante.Name = "UiTabSobrante"
        Me.UiTabSobrante.Size = New System.Drawing.Size(708, 326)
        Me.UiTabSobrante.TabStop = True
        Me.UiTabSobrante.Text = "Sobrantes"
        '
        'GrpSobrantes
        '
        Me.GrpSobrantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSobrantes.BackColor = System.Drawing.Color.Transparent
        Me.GrpSobrantes.Controls.Add(Me.GridSobrante)
        Me.GrpSobrantes.Location = New System.Drawing.Point(2, 3)
        Me.GrpSobrantes.Name = "GrpSobrantes"
        Me.GrpSobrantes.Size = New System.Drawing.Size(703, 318)
        Me.GrpSobrantes.TabIndex = 8
        Me.GrpSobrantes.TabStop = False
        '
        'GridSobrante
        '
        Me.GridSobrante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSobrante.ColumnAutoResize = True
        Me.GridSobrante.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSobrante.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSobrante.GroupByBoxVisible = False
        Me.GridSobrante.Location = New System.Drawing.Point(7, 15)
        Me.GridSobrante.Name = "GridSobrante"
        Me.GridSobrante.RecordNavigator = True
        Me.GridSobrante.Size = New System.Drawing.Size(691, 296)
        Me.GridSobrante.TabIndex = 1
        Me.GridSobrante.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnParcial
        '
        Me.btnParcial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParcial.Icon = CType(resources.GetObject("btnParcial.Icon"), System.Drawing.Icon)
        Me.btnParcial.Location = New System.Drawing.Point(403, 551)
        Me.btnParcial.Name = "btnParcial"
        Me.btnParcial.Size = New System.Drawing.Size(90, 37)
        Me.btnParcial.TabIndex = 163
        Me.btnParcial.Text = "&Parcial"
        Me.btnParcial.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recolección"
        Me.btnParcial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmConfirmacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 595)
        Me.Controls.Add(Me.btnParcial)
        Me.Controls.Add(Me.UiTabRecibo)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.GrpDocumentos)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmConfirmacion"
        Me.Text = "Confirmación de Recepción de Productos"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDocumentos.ResumeLayout(False)
        Me.GrpDocumentos.PerformLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTabRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabRecibo.ResumeLayout(False)
        Me.UiTabDetalle.ResumeLayout(False)
        Me.UiTabSobrante.ResumeLayout(False)
        Me.GrpSobrantes.ResumeLayout(False)
        CType(Me.GridSobrante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Public Padre As String
    Public ALMClave As String
    Public Folio As String = ""
    Public FechaRecibo As DateTime = Today.Date
    Public Chofer As String
    Public Transporte As String
    Public UBCClave As String
    Public IdRecibo As String = ""
    Public Estado As Integer = 0
    Public Notas As String = ""


    Private ubicacionRecibo As String = ""

    Private InterfazSalida As String = ""
    Private TallaColor As Integer = 0
    Private Movilidad, Packing As Boolean

    Private DOCClave As String
    Public SUCClave As String

    Public Tipo As String
    Public DescripcionEstado As String

    Public FecRegistro As DateTime
    Public Documentos As String = ""


    Private dtDoctos, dtDetalle, dtVentaDetalle, dtTipoRechazo, dtSobrante As DataTable
    Private bConfirmado As Boolean = False

    Private sPROClave As String
    Private iTProducto As Integer
    Private dCantidad As Double
    Private iNumDecimales As Integer
    Private iFactor As Integer
    Private iSeguimiento As Integer
    Private iDiasGarantia As Integer
    Private bload As Boolean
    Private TCosto As Integer
    Private ArrPaquete(0) As String


    Private Function validaForm(Optional ByVal validaGrid As Boolean = True) As Boolean
        Dim i As Integer = 0

        If TxtFolio.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtAnden.Text = "" OrElse UBCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If txtTransporte.Text = "" OrElse Transporte = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtOperador.Text = "" OrElse Chofer = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 And validaGrid Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
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

    Private Sub CargaDatosEmpleado(ByVal sEMPClave As String, ByVal iTipo As Integer)
        Dim dt As DataTable
        If iTipo = 1 Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_empleado", "@EMPClave", sEMPClave)
        Else
            dt = ModPOS.SiExisteRecupera("sp_consulta_empleado", "@NumEmpleado", sEMPClave, "@COMClave", ModPOS.CompanyActual)
        End If

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Chofer = dt.Rows(0)("EMPClave")
            TxtOperador.Text = dt.Rows(0)("NumEmpleado")
            txtNombre.Text = dt.Rows(0)("NombreCompleto")
            dt.Dispose()
            ModPOS.Ejecuta("sp_act_operador_recibo", "@IdRecibo", IdRecibo, "@Operador", Chofer, "@Usuario", ModPOS.UsuarioActual)

        Else
            Chofer = ""
            TxtOperador.Text = ""
            txtNombre.Text = ""
            MessageBox.Show("La información del Operador no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub CargaDatosTransporte(ByVal sTRAClave As String, ByVal iTipo As Integer)
        Dim dt As DataTable
        If iTipo = 1 Then
            dt = ModPOS.SiExisteRecupera("sp_recupera_transporte", "@TRAClave", sTRAClave)
        Else
            dt = ModPOS.SiExisteRecupera("sp_consulta_transporte", "@Economico", sTRAClave, "@COMClave", ModPOS.CompanyActual)
        End If
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            Transporte = dt.Rows(0)("TRAClave")
            txtTransporte.Text = dt.Rows(0)("noEconomico")
            txtPlacas.Text = dt.Rows(0)("Placa")
            dt.Dispose()
            ModPOS.Ejecuta("sp_act_transporte_recibo", "@IdRecibo", IdRecibo, "@Transporte", Transporte, "@Usuario", ModPOS.UsuarioActual)

        Else
            MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Function AddDocto( _
     ByVal sDOCClave As String, _
     ByVal iTipoDocumento As Integer, _
     ByVal sT As String, _
     ByVal sFolio As String, _
     ByVal dFecha As Date) As Boolean


        Dim dt As DataTable

        dt = Recupera_Tabla("st_valida_reciboAlmacen", "@IdRecibo", IdRecibo, "@DOCClave", sDOCClave, "@Tipo", iTipoDocumento)

        If dt.Rows.Count = 0 Then

            'Dim foundRows() As Data.DataRow
            'foundRows = dtDoctos.Select("DOCClave = '" & sDOCClave & "'")

            'If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDoctos.NewRow()
            'declara el nombre de la fila
            row1.Item("DOCClave") = sDOCClave
            row1.Item("TipoDocumento") = iTipoDocumento
            row1.Item("T") = sT
            row1.Item("Folio") = sFolio
            row1.Item("Fecha") = dFecha

            dtDoctos.Rows.Add(row1)
            'agrega la fila completo a la tabla

            Return True

        Else
            Beep()
            MessageBox.Show("¡El documento " & sFolio & ", que intenta agregar ya esta siendo procesado en un recibo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function

    Private Sub addDetalle(ByVal sDOCClave As String, _
                           ByVal iTipoDocumento As Integer, _
                           ByVal sDETClave As String, _
                           ByVal iFila As Integer, _
                           ByVal sFolio As String, _
                           ByVal dFecha As Date, _
                           ByVal sPROClave As String, _
                           ByVal iTProducto As Integer, _
                           ByVal iSeguimiento As Integer, _
                           ByVal iDiasGarantia As Integer, _
                           ByVal dCosto As Double, _
                           ByVal dTotal As Double, _
                           ByVal sClave As String, _
                           ByVal sNombre As String, _
                           ByVal dCantidad As Double, _
                           ByVal dRecibido As Double, _
                           ByVal iTipoRechazo As Integer, _
                           ByVal sUBCClave As String, _
                           ByVal sArea As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("DOCClave = '" & sDOCClave & "' and PROClave = '" & sPROClave & "' and fila = " & CStr(iFila))

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("DOCClave") = sDOCClave
            row1.Item("Tipo") = iTipoDocumento
            row1.Item("DETClave") = sDETClave
            row1.Item("fila") = iFila
            row1.Item("Folio") = sFolio
            row1.Item("Fecha") = dFecha
            row1.Item("PROClave") = sPROClave
            row1.Item("TProducto") = iTProducto
            row1.Item("Seguimiento") = iSeguimiento
            row1.Item("DiasGarantia") = iDiasGarantia
            row1.Item("Costo") = dCosto
            row1.Item("Total") = dTotal
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Cantidad") = dCantidad
            row1.Item("Recibido") = dRecibido
            row1.Item("TipoRechazo") = iTipoRechazo
            row1.Item("Estrategia") = ""
            row1.Item("UBCClave") = sUBCClave
            row1.Item("Area") = sArea
            row1.Item("Almacenado") = 0
            row1.Item("TipoRechazoAlmacenado") = 0

            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

            ModPOS.Ejecuta("sp_agrega_reciboAlmacenD", "@IdRecibo", IdRecibo, "@DOCClave", sDOCClave, "@Tipo", iTipoDocumento, "@DETClave", sDETClave, "@Fila", iFila, "@Folio", sFolio, "@Fecha", dFecha, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Costo", dCosto, "@Cantidad", dCantidad, "@TipoRechazo", iTipoRechazo, "@Usuario", ModPOS.UsuarioActual)


        End If
    End Sub

    Public Sub cargaDocto(ByVal sDOCClave As String, iTipo As Integer)

        Dim bCargarDetalle As Boolean

        If Movilidad = False Then
            Clock.Stop()
        End If

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


        myCommand = New System.Data.SqlClient.SqlCommand("sp_encabezado_recibo", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave
        myCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = iTipo

        dr = myCommand.ExecuteReader()

        Dim dFecha As Date

        While dr.Read

            dFecha = dr("Fecha")

            bCargarDetalle = AddDocto( _
            dr("DOCClave"), _
            iTipo, _
            dr("T"), _
            dr("Folio"), _
            dr("Fecha")) 

        End While

        myCommand.Dispose()
        dr.Close()


        If bCargarDetalle = True Then

            myCommand = New System.Data.SqlClient.SqlCommand("sp_reciboalmacen_detalle", Cnx)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandTimeout = ModPOS.myTimeOut
            myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave
            myCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = iTipo

            dr = myCommand.ExecuteReader()

            While dr.Read
                If IsDBNull(dr("Costo")) Then
                    MessageBox.Show("El producto " & dr("Clave") & " no tiene Costo valido, favor de reportar a soporte tecnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Dim foundRows() As System.Data.DataRow

                    'Elimina Detalle
                    foundRows = dtDetalle.Select("DOCClave = '" & dr("DOCClave") & "'")

                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            dtDetalle.Rows.Remove(foundRows(i))
                        Next

                    End If

                    'Elimina Pedido
                    foundRows = dtDoctos.Select("DOCClave = '" & dr("DOCClave") & "'")
                    If foundRows.GetLength(0) > 0 Then
                        ModPOS.Ejecuta("sp_elimina_reciboAlmacen", "@IdRecibo", IdRecibo, "@DOCClave", foundRows(0)("DOCClave"), "@Tipo", foundRows(0)("TipoDocumento"))
                        dtDoctos.Rows.Remove(foundRows(0))
                    End If

                    Exit Sub

                Else
                    addDetalle(dr("DOCClave"), _
                                 iTipo, _
                                dr("DETClave"), _
                                 dr("fila"), _
                                 dr("Folio"), _
                                 dFecha, _
                                 dr("PROClave"), _
                                 dr("TProducto"), _
                                 dr("Seguimiento"), _
                                 dr("DiasGarantia"), _
                                 dr("Costo"), _
                                 dr("Total"), _
                                 dr("Clave"), _
                                 dr("Nombre"), _
                                 dr("Cantidad"), _
                                 dr("Recibido"), _
                                 dr("TipoRechazo"), _
                                 dr("UBCClave"), _
                                 dr("Area"))
                End If
            End While

            myCommand.Dispose()
            dr.Close()
            Cnx.Close()
        End If

        If Movilidad = False Then
            Clock.Start()
        End If
    End Sub

    Private Function cargaDatosDocto(ByVal sDOCClave As String, ByVal Periodo As Integer, ByVal Mes As Integer, ByVal sTipo As String) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable
        If sTipo = "Compra" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 2, "@Periodo", Periodo, "@Mes", Mes, "@Folio", sDOCClave, "@ALMClave", ALMClave, "@Estado", 1)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("COMClave"), 2)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Compra introducido no esta disponible para Recibir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        ElseIf sTipo = "Traslado" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 8, "@Periodo", Periodo, "@Mes", Mes, "@Folio", sDOCClave, "@ALMClave", ALMClave, "@Estado", 7)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("TRSClave"), 8)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Traslado introducido no esta disponible para Recibir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        ElseIf sTipo = "Traspaso" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 6, "@Periodo", Periodo, "@Mes", Mes, "@Folio", sDOCClave, "@ALMClave", ALMClave, "@Estado", 2)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("MVAClave"), 6)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Traspaso introducido no esta disponible para Recibir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If
    End Function

    Public Sub actEstrategia(ByVal sPROClave As String, ByVal sUBC As String, ByVal sEstrategia As String, ByVal sArea As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("PROClave = '" & sPROClave & "'")
        If foundRows.Length >= 1 Then
            Dim i As Integer
            For i = 0 To foundRows.Length - 1
                foundRows(i)("Estrategia") = sEstrategia
                foundRows(i)("UBCClave") = sUBC
                foundRows(i)("Area") = sArea

            Next
        End If
    End Sub


    Private Function recibirProducto(ByVal dtProducto As DataTable, ByVal dCantidad As Decimal) As Boolean
        sPROClave = dtProducto.Rows(0)("PROClave")
        iTProducto = dtProducto.Rows(0)("TProducto")
        iSeguimiento = dtProducto.Rows(0)("Seguimiento")
        iDiasGarantia = dtProducto.Rows(0)("DiasGarantia")
        iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
        iFactor = dtProducto.Rows(0)("Factor")

        dtProducto.Dispose()


        'Actualiza Surtido
        Dim foundRows() As System.Data.DataRow

        foundRows = dtDetalle.Select("PROClave Like '" & sPROClave & "' and Cantidad > Recibido")
        If foundRows.Length >= 1 Then

            Dim sUBCClave As String = ""
            Dim sArea As String = ""

            Dim porRecibir, dRecibido As Double

            dRecibido = dtDetalle.Compute("SUM(Recibido)", "PROClave = '" & sPROClave & "'")
            porRecibir = dtDetalle.Compute("SUM(Cantidad)", "PROClave = '" & sPROClave & "'")
            porRecibir -= dRecibido

            LblClave.Text = foundRows(0)("Clave")
            LblDescripcion.Text = foundRows(0)("Nombre")
            LblCantidad.Text = dRecibido + dCantidad

            If dRecibido > 0 Then
                LblEstrategia.Text = foundRows(0)("Estrategia")
            Else
                Dim dtEstrategia As DataTable = ModPOS.Recupera_Tabla("st_recupera_estrategia", "@PROClave", sPROClave, "@ALMClave", ALMClave)
                If dtEstrategia.Rows.Count > 0 Then
                    LblEstrategia.Text = dtEstrategia.Rows(0)("Estrategia")
                    sUBCClave = dtEstrategia.Rows(0)("UBCClave")
                    sArea = dtEstrategia.Rows(0)("Area")
                Else
                    LblEstrategia.Text = ""
                    sUBCClave = ""
                    sArea = ""
                End If
            End If


            If porRecibir >= dCantidad Then
                Dim i As Integer
                For i = 0 To foundRows.Length - 1
                    foundRows(i)("Estrategia") = LblEstrategia.Text
                    foundRows(i)("UBCClave") = sUBCClave
                    foundRows(i)("Area") = sArea
                    Select Case dCantidad
                        Case Is >= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Recibido"))
                            dCantidad -= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Recibido"))
                            foundRows(i)("Recibido") = foundRows(i)("Cantidad")
                            If dCantidad <= 0 Then
                                Exit For
                            End If
                        Case Is < CDbl(foundRows(i)("Cantidad") - foundRows(i)("Recibido"))
                            foundRows(i)("Recibido") += dCantidad
                            Exit For
                    End Select
                Next

                GridDetalle.Refresh()


                Return True
            Else
                Beep()
                MessageBox.Show("La cantidad  a recibir excede a la cantidad solicitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Else
            Beep()
            MessageBox.Show("La cantidad  o producto excede a la solicitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function


    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            Dim mensaje As String = ""
            If dtDoctos.Rows.Count = 0 Then
                MessageBox.Show("Error no existen documentos asociados al recibo actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Movilidad = False Then
                'Busca y recupera los datos del producto
                Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
                If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                    iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                    iFactor = dtProducto.Rows(0)("Factor")

                    TxtCantidad.DecimalDigits = iNumDecimales

                    If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                        dCantidad = 1 * iFactor
                        TxtCantidad.Text = "1"
                    Else
                        dCantidad = CDbl(TxtCantidad.Text) * iFactor
                    End If

                    recibirProducto(dtProducto, dCantidad)

                    dtProducto.Dispose()

                    TxtCantidad.Text = "1"
                    TxtProducto.Text = ""

                    TxtProducto.Focus()
                Else
                    sPROClave = 0
                    iTProducto = 0
                    iSeguimiento = 0
                    iDiasGarantia = 0
                    iNumDecimales = 0
                    iFactor = 0
                    TxtProducto.Text = ""
                    LblClave.Text = ""
                    LblDescripcion.Text = ""
                    LblCantidad.Text = ""
                    LblEstrategia.Text = ""
                    Beep()
                    mensaje = "La Clave o Código de Barras no esta registrada o esta inactiva"
                    'MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            End If
            If mensaje <> "" Then
                If Codigo.Trim.Length >= 14 AndAlso IsNumeric(Codigo.Substring(Codigo.Length - 12, 12)) = True Then
                    ' Si es un codigo de paquete
                    Dim dt As DataTable = Recupera_Tabla("sp_valida_PK", "@tabla", "Sucursal", "@clave", Codigo.Substring(0, Codigo.Length - 12).ToUpper, "@COMClave", ModPOS.CompanyActual)

                    If dt.Rows.Count = 1 Then


                        dt = Recupera_Tabla("st_recupera_paquetedetalle", "@idPaquete", Codigo)


                        If dt.Rows.Count > 0 AndAlso Array.IndexOf(ArrPaquete, Codigo) = -1 Then

                            Dim i As Integer = 0
                            Dim dtPaquete As DataTable
                            Dim foundRows() As System.Data.DataRow
                            Dim bError As Boolean = False
                            Dim porRecibir As Double

                            'Valida Paquete corresponda a documentos por recibir
                            For i = 0 To dt.Rows.Count - 1
                                foundRows = dtDetalle.Select("PROClave = '" & dt.Rows(i)("PROClave") & "'")
                                If foundRows.Length = 0 Then
                                    bError = True
                                    Exit For
                                Else
                                    porRecibir = dtDetalle.Compute("SUM(Cantidad)", "PROClave = '" & dt.Rows(i)("PROClave") & "'")
                                    If porRecibir < dt.Rows(i)("Cantidad") Then
                                        bError = False
                                        Exit For
                                    End If
                                End If
                            Next

                            If bError = True Then
                                MessageBox.Show("EL contenido del paquete no coincide con el detalle de los documentos seleccionados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            Dim contError As Integer = 0
                            For i = 0 To dt.Rows.Count - 1
                                dtPaquete = ModPOS.SiExisteRecupera("st_recupera_producto", "@Tipo", 3, "@Busca", dt.Rows(i)("PROClave"), "@SUCClave", SUCClave)
                                If recibirProducto(dtPaquete, dt.Rows(i)("Cantidad")) = False Then
                                    contError += 1
                                End If
                                dtPaquete.Dispose()
                            Next

                            If contError = 0 Then
                                ArrPaquete(UBound(ArrPaquete)) = Codigo
                                ReDim Preserve ArrPaquete(UBound(ArrPaquete) + 1)

                                'ModPOS.Ejecuta("st_recibe_paquete", "@IdRecibo", IdRecibo, "@idPaquete", Codigo, "@Usuario", ModPOS.UsuarioActual)
                            End If


                            Exit Sub
                        Else
                            MessageBox.Show("El IdPaquete ya fue recibo o no esta disponible para esta sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                    dt.Dispose()

                End If

            End If

        End If
    End Sub

    Private Sub registraSeguimiento(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal dCantidad As Double, ByVal iSeguimiento As Integer, ByVal iDiasGarantia As Integer)
        'SI REQUIERE SEGUIMIENTO DE SERIAL
        If iSeguimiento = 2 Then
            Dim SerialReg As Integer = 0
            Dim PorRegistrar As Double
            PorRegistrar = dCantidad
            Do
                Dim a As New FrmSerial
                a.DOCClave = DOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.Cantidad = PorRegistrar
                a.Dias = iDiasGarantia
                a.TipoDoc = 1
                a.TipoMov = 9
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
                a.DOCClave = DOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.CantXRegistrar = PorRegistrar
                a.TipoDoc = 1
                a.TipoMov = 9
                a.ShowDialog()
                LoteReg = LoteReg + a.NumSerialRegistrados
                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                a.Dispose()
            Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
        End If

    End Sub

    Private Sub BtnAnden_Click(sender As Object, e As EventArgs) Handles BtnAnden.Click
        Dim a As New FrmConsulta
        a.Campo = "UBCClave"
        a.Campo2 = "Anden"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_recibo", "@ALMClave", ALMClave)
        a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ID <> "" Then
                UBCClave = a.ID
                Me.TxtAnden.Text = a.ID2
                ModPOS.Ejecuta("sp_act_anden_recibo", "@IdRecibo", IdRecibo, "@Anden", UBCClave, "@Usuario", ModPOS.UsuarioActual)
            End If
        End If
        a.Dispose()

    End Sub

    Private Sub BtnBusquedaTransporte_Click(sender As Object, e As EventArgs) Handles BtnTransporte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_transporte"
        a.TablaCmb = "Transporte"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.BusquedaInicial = True
        a.Busqueda = IIf(txtTransporte.Text = "", "%", txtTransporte.Text)
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosTransporte(a.valor, 1)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnOperador_Click(sender As Object, e As EventArgs) Handles BtnOperador.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_empleado"
        a.TablaCmb = "Empleado"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.NumColDes = 1
        a.CompaniaRequerido = True
        a.BusquedaInicial = True
        a.Busqueda = IIf(TxtOperador.Text = "", "%", TxtOperador.Text)
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Descripcion Is Nothing Then
                CargaDatosEmpleado(a.valor, 1)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub txtTransporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransporte.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtTransporte.Text <> "" Then

                    CargaDatosTransporte(txtTransporte.Text, 2)

                End If
            Case Is = Keys.Right
                BtnTransporte.PerformClick()
        End Select

    End Sub

    Private Sub TxtOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOperador.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtOperador.Text <> "" Then
                    CargaDatosEmpleado(TxtOperador.Text, 2)
                End If
            Case Is = Keys.Right
                BtnOperador.PerformClick()
        End Select

    End Sub



    Private Sub BtnBuscaDoc_Click(sender As Object, e As EventArgs) Handles BtnBuscaDoc.Click
        If validaForm(False) Then
            If cmbTipo.SelectedItem Is Nothing Then
                MessageBox.Show("No se ha seleccionado tipo de documento para realizar la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim iTipo As Integer

            Select Case CStr(cmbTipo.SelectedItem)
                Case Is = "Compra"
                    iTipo = 2
                Case Is = "Traslado"
                    iTipo = 8
                Case Is = "Traspaso"
                    iTipo = 6
            End Select

            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_recupera_docto_recibo"
            a.AlmRequerido = True
            a.TipoRequerido = True
            a.BusquedaInicial = True
            a.Busqueda = TxtDoc.Text
            a.Tipo = iTipo
            a.ALMClave = Me.ALMClave
            a.TablaCmb = "Recibo"
            a.CampoCmb = "Busqueda"
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If Not a.valor Is Nothing Then
                    If a.foundRows.GetLength(0) > 0 Then
                        For i As Integer = 0 To a.foundRows.Length - 1
                            a.valor = a.foundRows(i)("ID")
                            cargaDocto(a.valor, iTipo)
                        Next
                    End If
                End If
            End If
            a.Dispose()
            TxtDoc.Focus()
        End If

    End Sub

    Private Sub FrmConfirmacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bConfirmado = False AndAlso Estado = 0 Then

            Beep()
            Select Case MessageBox.Show("Se perderan todos los cambios ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                    Exit Sub
            End Select

            ModPOS.Ejecuta("sp_libera_reciboDocumentos", "@IdRecibo", IdRecibo)


        End If


        If Not ModPOS.Recibo Is Nothing Then
            ModPOS.Recibo.AgregarFolio()
        End If
        ModPOS.Confirmacion.Dispose()
        ModPOS.Confirmacion = Nothing



    End Sub

    Private Sub actualizaGrid()

        GridDoctos.DataSource = dtDoctos
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.RootTable.Columns("DOCClave").Visible = False
        GridDoctos.RootTable.Columns("TipoDocumento").Visible = False
        GridDoctos.CurrentTable.Columns("T").Selectable = False
        GridDoctos.CurrentTable.Columns("Folio").Selectable = False
        GridDoctos.CurrentTable.Columns("Fecha").Selectable = False


        GridDoctos.RootTable.Columns("T").Width = 2
        GridDoctos.RootTable.Columns("Folio").Width = 20
        GridDoctos.RootTable.Columns("Fecha").Width = 20

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DOCClave").Visible = False
        GridDetalle.RootTable.Columns("Tipo").Visible = False
        GridDetalle.CurrentTable.Columns("Fecha").Visible = False
        GridDetalle.RootTable.Columns("DETClave").Visible = False
        GridDetalle.RootTable.Columns("fila").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
        GridDetalle.CurrentTable.Columns("Costo").Visible = False
        GridDetalle.CurrentTable.Columns("Total").Visible = False
        GridDetalle.RootTable.Columns("UBCClave").Visible = False
        GridDetalle.RootTable.Columns("Almacenado").Visible = False
        GridDetalle.RootTable.Columns("TipoRechazoAlmacenado").Visible = False




        GridDetalle.RootTable.Columns("Folio").Width = 40
        GridDetalle.RootTable.Columns("Clave").Width = 70
        GridDetalle.RootTable.Columns("Cantidad").Width = 30
        GridDetalle.RootTable.Columns("Recibido").Width = 30
        GridDetalle.RootTable.Columns("TipoRechazo").Width = 70
        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Recibido").FormatString = "0.00"

        GridDetalle.CurrentTable.Columns("TipoRechazo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("TipoRechazo").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoRechazo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Recibo", "@Campo", "TipoRechazo")

            Dim i As Integer
            For i = 0 To dtTipoRechazo.Rows.Count - 1
                .Add(dtTipoRechazo.Rows(i)("valor"), dtTipoRechazo.Rows(i)("descripcion"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("TipoRechazo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Recibido"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmConfirmacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Dim dt As DataTable

        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Costeo"
                        TCosto = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                End Select
            Next
        End With
        dt.Dispose()

        With cmbEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "Recibo"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Estado"
            .llenar()
        End With

        With cmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Recibo"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoRechazo"
            .llenar()
        End With

        If Padre = "Agregar" Then
            IdRecibo = ModPOS.obtenerLlave
            ModPOS.Ejecuta("sp_crea_reciboalmacen", "@IdRecibo", IdRecibo, "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)

            dtDoctos = ModPOS.CrearTabla("Documentos", _
                                         "DOCClave", "System.String", _
                                         "TipoDocumento", "System.Int32", _
                                         "T", "System.String", _
                                         "Folio", "System.String", _
                                         "Fecha", "System.DateTime")


            dtDetalle = ModPOS.CrearTabla("Detalle", _
                                          "DOCClave", "System.String", _
                                          "Tipo", "System.Int32", _
                                          "DETClave", "System.String", _
                                          "fila", "System.Int32", _
                                          "Folio", "System.String", _
                                          "Fecha", "System.DateTime", _
                                          "PROClave", "System.String", _
                                          "TProducto", "System.Int32", _
                                          "Seguimiento", "System.Int32", _
                                          "DiasGarantia", "System.Int32", _
                                          "Costo", "System.Double", _
                                          "Total", "System.Double", _
                                          "Clave", "System.String", _
                                          "Nombre", "System.String", _
                                          "Cantidad", "System.Double", _
                                          "Recibido", "System.Double", _
                                          "Almacenado", "System.Double", _
                                          "TipoRechazo", "System.Int32", _
                                          "TipoRechazoAlmacenado", "System.Int32", _
                                          "Estrategia", "System.String", _
                                          "UBCClave", "System.String", _
                                          "Area", "System.String")


        Else

            BtnRefresh.Visible = True
            BtnAnden.Enabled = False
            TxtFolio.Enabled = False

            CargaDatosEmpleado(Chofer, 1)
            CargaDatosTransporte(Transporte, 1)

            dt = ModPOS.SiExisteRecupera("sp_recupera_ubicacion", "@UBCClave", UBCClave)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                TxtAnden.Text = dt.Rows(0)("Ubicacion")
                dt.Dispose()
            End If

            If Estado > 1 Then
                BtnBuscaDoc.Enabled = False
                BtnDel.Enabled = False
                TxtDoc.Enabled = False
                TxtCantidad.Enabled = False
                TxtProducto.Enabled = False
                BtnBuscaProd.Enabled = False
                btnFinalizar.Enabled = False
            End If

            dtDoctos = ModPOS.Recupera_Tabla("sp_recupera_recibodocumentos", "@IdRecibo", IdRecibo)

            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_reciboAlmacenD", "@IdRecibo", IdRecibo)

        End If

        cmbTipo.SelectedItem = "Traslado"

        TxtFolio.Text = Folio
        TxtNotas.Text = Notas
        cmbEstado.SelectedValue = Estado
        dtFecha.Value = FechaRecibo

        actualizaGrid()


        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Movilidad = IIf(dt.Rows(0)("ReciboRF").GetType.Name = "DBNull", False, dt.Rows(0)("ReciboRF"))
        Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))

        dt.Dispose()

        If Movilidad = True Then
            ChkTodos.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            BtnBuscaProd.Enabled = False

            If Packing = True Then
                TxtProducto.Enabled = True
                lblProducto.Text = "Paquete"
            End If

            'GridDetalle.RootTable.Columns("Estrategia").Visible = False
            'GridDetalle.RootTable.Columns("Area").Visible = False

        End If

        If InterfazSalida <> "" AndAlso Movilidad = True Then
            btnParcial.Visible = True
        Else
            btnParcial.Visible = False
        End If

        bload = True


    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If Not GridDoctos.GetValue(0) Is Nothing Then

            If MessageBox.Show("¿Esta seguro de remover el documento: " & GridDoctos.GetValue("Folio") & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim foundRows() As System.Data.DataRow


                Dim dRecibidos As Integer

                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_reciboAlmacenD", "@IdRecibo", IdRecibo, "@DOCClave", GridDoctos.GetValue("DOCClave"), "@Tipo", GridDoctos.GetValue("TipoDocumento"), "@Modo", 1)
                dRecibidos = dt.Rows.Count
                dt.Dispose()

                If dRecibidos > 0 Then
                    MessageBox.Show("El documento no puede ser removido o eliminado debido a que ya se recibio material", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                'Cambia Estado
                ModPOS.Ejecuta("sp_elimina_reciboAlmacen", "@IdRecibo", IdRecibo, "@DOCClave", GridDoctos.GetValue("DOCClave"), "@Tipo", GridDoctos.GetValue("TipoDocumento"))


                'Elimina Detalle
                foundRows = dtDetalle.Select("DOCClave = '" & GridDoctos.GetValue("DOCClave") & "'")

                If foundRows.GetLength(0) > 0 Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        dtDetalle.Rows.Remove(foundRows(i))
                    Next

                End If

                'Elimina Pedido
                foundRows = dtDoctos.Select("DOCClave = '" & GridDoctos.GetValue("DOCClave") & "'")
                If foundRows.GetLength(0) > 0 Then
                    dtDoctos.Rows.Remove(foundRows(0))
                End If


                If dtDoctos.Rows.Count = 0 AndAlso Movilidad = False Then
                    Clock.Stop()
                End If

            End If

        Else
            MessageBox.Show("No se encuentra algun documento seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
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
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    dCantidad = 1
                    TxtCantidad.Text = CStr(dCantidad)
                Else
                    dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            End If
            TxtProducto.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) <= 0 Then
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            dCantidad = 1
            TxtCantidad.Text = CStr(dCantidad)
        End If

        TxtProducto.Focus()

    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Recibido" Then
            If IsNumeric(GridDetalle.GetValue("Recibido")) Then
                Select Case CDbl(GridDetalle.GetValue("Recibido"))
                    Case Is > CDbl(GridDetalle.GetValue("Recibido"))
                        Beep()
                        MessageBox.Show("¡La cantidad a recibir no debe ser mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridDetalle.SetValue("Recibido", CDbl(GridDetalle.GetValue("Cantidad")))
                    Case Is < 0
                        GridDetalle.SetValue("Recibido", 0)
                End Select
            Else
                GridDetalle.SetValue("Recibido", 0)
            End If
            GridDetalle.SetValue("Total", GridDetalle.GetValue("Costo") * GridDetalle.GetValue("Recibido"))
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Estado < 2 Then
            If validaForm() Then
                'If dtDetalle.Select("(Estrategia = '') or (Estrategia is Null)").GetLength(0) <= 0 Then
                Dim dRegistrado, dRecibido As Double
                Dim i, iDoctos As Integer

                iDoctos = dtDoctos.Rows.Count
                dRecibido = dtDetalle.Compute("SUM(Recibido)", "")
                dRegistrado = dtDetalle.Compute("SUM(Cantidad)", "")

                If Movilidad = True Then
                    Dim dtReciboDet As DataTable
                    Dim dReciboMovil As Double

                    dtReciboDet = ModPOS.Recupera_Tabla("sp_recupera_reciboAlmacenD", "@IdRecibo", IdRecibo)
                    dReciboMovil = dtReciboDet.Compute("SUM(Recibido)", "")
                    dtReciboDet.Dispose()

                    If dRecibido <> dReciboMovil Then
                        MessageBox.Show("Se encontraron diferencias en pantalla. Se iniciara actualizacón de la información", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        BtnRefresh.PerformClick()
                        Exit Sub
                    End If

                End If

                BtnGuardar.Enabled = False
                Estado = 1

                If dRecibido > 0 OrElse Movilidad = True Then

                    Folio = TxtFolio.Text.ToUpper.Trim

                    ModPOS.Ejecuta("sp_act_reciboalmacen", "@IdRecibo", IdRecibo, "@Folio", Folio, _
                                                          "@NoDocumentos", iDoctos, _
                                                          "@CantidadSolicitada", dRegistrado, _
                                                          "@CantidadRecibida", dRecibido, _
                                                          "@Notas", TxtNotas.Text.Trim, _
                                                          "@Estado", Estado, _
                                                          "@Usuario", ModPOS.UsuarioActual)

                    Dim foundRows() As DataRow
                    foundRows = dtDetalle.Select("(Recibido <> Almacenado) or (TipoRechazo <> TipoRechazoAlmacenado)")
                    Dim msg As String
                    For i = 0 To foundRows.GetUpperBound(0)
                        msg = ModPOS.Ejecuta("sp_act_reciboAlmacenD", "@IdRecibo", IdRecibo, "@DOCClave", foundRows(i)("DOCClave"), "@Tipo", foundRows(i)("Tipo"), "@DETClave", foundRows(i)("DETClave"), "@Recibido", foundRows(i)("Recibido"), "@TipoRechazo", foundRows(i)("TipoRechazo"), "@Usuario", ModPOS.UsuarioActual, "@UBCClave", foundRows(i)("UBCClave"))
                    Next

                    bConfirmado = True

                    For i = 0 To ArrPaquete.Length - 2
                        ModPOS.Ejecuta("st_recibe_paquete", "@IdRecibo", IdRecibo, "@idPaquete", ArrPaquete(i), "@Usuario", ModPOS.UsuarioActual)
                    Next i

                    If Not dtDoctos Is Nothing Then
                        dtDoctos.Dispose()
                    End If

                    If Not dtDetalle Is Nothing Then
                        dtDetalle.Dispose()
                    End If

                    dtDoctos = ModPOS.SiExisteRecupera("sp_recupera_recibodocumentos", "@IdRecibo", IdRecibo)
                    dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_reciboAlmacenD", "@IdRecibo", IdRecibo)

                    actualizaGrid()
                    BtnGuardar.Enabled = True
                Else
                    BtnGuardar.Enabled = True
                    Beep()
                    MessageBox.Show("!No se encontro producto registrado para recibir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If
                'Else
                '    Beep()
                '    MessageBox.Show("¡Algunos de los productos relacionados a los documentos no cuentan con una estrategia definida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else

            bConfirmado = True
            Me.Close()
        End If
    End Sub

    'Pendientes


    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If Estado = 1 OrElse Estado = 0 Then


            btnFinalizar.Enabled = False

            BtnGuardar.PerformClick()


            If Movilidad = False AndAlso ubicacionRecibo = "" Then
                MessageBox.Show("No se ha especificado el Stage ó Ubicación de Recibo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                btnFinalizar.Enabled = True
                Exit Sub
            End If


            Dim dRegistrado, dRecibido As Double
            Dim foundRows() As DataRow

            dRecibido = dtDetalle.Compute("SUM(Recibido)", "")

            If dRecibido = 0 Then
                MessageBox.Show("No se ha registrado la recepcion de por lo menos un producto o material", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnFinalizar.Enabled = True
                Exit Sub
            End If

            If Movilidad = True Then
                foundRows = dtDetalle.Select("(Estrategia = '' or Estrategia is Null)")
                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("No se ha especificado ninguna Estrategia para los materiales o productos contenidos en los documentos relacionados al recibo actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFinalizar.Enabled = True
                    Exit Sub
                End If
            End If

            dRegistrado = dtDetalle.Compute("SUM(Cantidad)", "")

            If dRegistrado > dRecibido Then
                Beep()
                Select Case MessageBox.Show("Existen materiales o productos pendientes de recibir. ¿Desea continuar y dar por finalizado el recibo actual?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.No
                        btnFinalizar.Enabled = True
                        Exit Sub
                End Select

                foundRows = dtDetalle.Select("Cantidad > Recibido and (TipoRechazo = 0 or TipoRechazo is Null)")
                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("No se ha especificado tipo de Rechazo de los materiales o productos que no fueron recibidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    btnFinalizar.Enabled = True
                    Exit Sub
                End If

            End If

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_valida_reciboalmacen", "@IdRecibo", IdRecibo)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("No es posible realizar la recepción de materiales debido a que excenden a los solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt.Dispose()
                Dim c As New FrmConsultaGen
                c.Text = "Excedentes en Recibo"
                ModPOS.ActualizaGrid(False, c.GridConsultaGen, "sp_valida_reciboalmacen", "@IdRecibo", IdRecibo)
                c.ShowDialog()
                c.Dispose()

                If Movilidad = True Then
                    GridDetalle.RootTable.Columns("Recibido").Selectable = True
                End If
                btnFinalizar.Enabled = True
                Exit Sub
            End If
            dt.Dispose()

            If Movilidad = False Then
                ' Valida que exista estrategia de amacenaje

                dt = ModPOS.Recupera_Tabla("sp_ubicaciones_recibo", "@IdRecibo", IdRecibo, "@ALMClave", ALMClave)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("No es posible realizar la recepción de materiales debido a que existen materiales sin estrategia de almacenaje definida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt.Dispose()
                    Dim c As New FrmConsultaGen
                    c.Text = "Materiales sin estrategia de almacenaje"
                    ModPOS.ActualizaGrid(False, c.GridConsultaGen, "sp_ubicaciones_recibo", "@IdRecibo", IdRecibo, "@ALMClave", ALMClave)
                    c.ShowDialog()
                    c.Dispose()
                    btnFinalizar.Enabled = True
                    Exit Sub
                End If
                dt.Dispose()

            End If



            Dim bAutorizado As Boolean
            Dim sAutoriza As String

            If TallaColor = 1 Then
                bAutorizado = True
                sAutoriza = ModPOS.UsuarioActual
            Else
                Dim au As New MeAutorizacion
                au.Sucursal = SUCClave
                au.MontodeAutorizacion = dtDetalle.Compute("SUM(Total)", "")
                au.StartPosition = FormStartPosition.CenterScreen
                au.ShowDialog()
                If au.DialogResult = DialogResult.OK Then
                    bAutorizado = True
                    sAutoriza = au.Autoriza
                Else
                    bAutorizado = False
                    sAutoriza = ""
                End If
                au.Dispose()
            End If

            If bAutorizado = True Then
                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Procesando información...")

                If Movilidad = False Then
                    'Ingresa a ubicacion asignada en la estrategia.
                    ' Ingresa mercancia a almacen 
                    ModPOS.GeneraMovInv(1, 9, 9, IdRecibo, ALMClave, Folio, sAutoriza, False, 1, ubicacionRecibo)
                Else
                    ModPOS.GeneraMovInv(1, 9, 9, IdRecibo, ALMClave, Folio, sAutoriza, False, 0)
                End If

                'Busca productos con seguimiento

                Dim fila As Integer

                dt = ModPOS.Recupera_Tabla("sp_contabiliza_recibo", "@IdRecibo", IdRecibo)

                For fila = 0 To dt.Rows.Count - 1

                    ModPOS.Ejecuta("sp_actualiza_costo", _
                                               "@SUCClave", SUCClave, _
                                               "@PROClave", dt.Rows(fila)("PROClave"), _
                                               "@TCosto", TCosto, _
                                               "@Costo", dt.Rows(fila)("Costo"), _
                                               "@Cantidad", dt.Rows(fila)("Recibido"), _
                                               "@Usuario", sAutoriza)

                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If dt.Rows(fila)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dt.Rows(fila)("Recibido")
                        Do
                            Dim a As New FrmSerial
                            a.DOCClave = dt.Rows(fila)("DOCClave")
                            a.PROClave = dt.Rows(fila)("PROClave")
                            a.Clave = dt.Rows(fila)("Clave")
                            a.Nombre = dt.Rows(fila)("Nombre")
                            a.Cantidad = PorRegistrar
                            a.Dias = dt.Rows(fila)("DiasGarantia")
                            a.TipoDoc = dt.Rows(fila)("TipoDocumento")
                            a.TipoMov = 1
                            a.ShowDialog()
                            SerialReg = SerialReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until SerialReg = dt.Rows(fila)("Recibido") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If dt.Rows(fila)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dt.Rows(fila)("Recibido")
                        Do
                            Dim a As New FrmLote
                            a.DOCClave = dt.Rows(fila)("DOCClave")
                            a.PROClave = dt.Rows(fila)("PROClave")
                            a.Clave = dt.Rows(fila)("Clave")
                            a.Nombre = dt.Rows(fila)("Nombre")
                            a.CantXRegistrar = PorRegistrar
                            a.TipoDoc = dt.Rows(fila)("TipoDocumento")
                            a.TipoMov = 1
                            a.ShowDialog()
                            LoteReg = LoteReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until LoteReg = dt.Rows(fila)("Recibido") OrElse PorRegistrar = 0
                    End If


                Next

                'Actualiza estado del recibo
                ModPOS.Ejecuta("sp_act_edo_recibo", "@IdRecibo", IdRecibo, "@Estado", 2)

                ModPOS.Ejecuta("st_act_reciboalmacent", "@IdRecibo", IdRecibo, "@Estado", 2)

                foundRows = dtDetalle.Select("Recibido > 0")
                If foundRows.GetLength(0) > 0 Then
                    For fila = 0 To foundRows.GetUpperBound(0)

                        ModPOS.Ejecuta("st_act_doc_recibo", _
                                                   "@DOCClave", foundRows(fila)("DOCClave"), _
                                                   "@Tipo", foundRows(fila)("Tipo"), _
                                                   "@DETClave", foundRows(fila)("DETClave"), _
                                                   "@Recibido", foundRows(fila)("Recibido"), _
                                                   "@Usuario", sAutoriza)
                    Next

                End If


                Dim i As Integer


                For i = 0 To dtDoctos.Rows.Count - 1
                    If CStr(dtDoctos.Rows(i)("T")) = "T" OrElse CStr(dtDoctos.Rows(i)("T")) = "TL" Then
                        ModPOS.Ejecuta("st_act_edo_traslado", "@TRSClave", CStr(dtDoctos.Rows(i)("DOCClave")))
                        ModPOS.Ejecuta("st_act_apartado_vta", "@IdRecibo", IdRecibo, "@TRSClave", CStr(dtDoctos.Rows(i)("DOCClave")))
                    End If
                Next

                bConfirmado = True


                If Movilidad = False Then
                    Clock.Stop()
                    If PrintDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        ImprimirColocacion(IdRecibo, PrintDialog1.PrinterSettings.PrinterName, False)
                    End If
                End If

                If bConfirmado = True AndAlso InterfazSalida <> "" Then

                    Dim iTipoDocumento As Integer
                    Dim sTipo, sFolio, sFecha As String
                    Dim dtInterfaz As DataTable


                    For i = 0 To dtDoctos.Rows.Count - 1
                        If CStr(dtDoctos.Rows(i)("T")) = "C" Then
                            sTipo = "Compra"
                            iTipoDocumento = 2
                            sFolio = dtDoctos.Rows(i)("DOCClave")
                        ElseIf CStr(dtDoctos.Rows(i)("T")) = "CM" Then
                            sTipo = "Compra"
                            iTipoDocumento = 2
                            sFolio = dtDoctos.Rows(i)("DOCClave")
                        ElseIf CStr(dtDoctos.Rows(i)("T")) = "T" Then
                            sTipo = "Traslado"
                            iTipoDocumento = 8
                            sFolio = dtDoctos.Rows(i)("DOCClave")
                        ElseIf CStr(dtDoctos.Rows(i)("T")) = "TL" Then
                            sTipo = "Traslado"
                            iTipoDocumento = 8
                            sFolio = dtDoctos.Rows(i)("DOCClave")
                        End If
                        sFecha = DateTime.Now.AddMinutes(i).ToString("yyyyMMdd_HHmmssfff")
                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", sTipo, "@COMClave", ModPOS.CompanyActual)
                        If dtInterfaz.Rows.Count > 0 Then
                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", iTipoDocumento, "@Path", InterfazSalida, "@Fecha", sFecha, "@IdRecibo", IdRecibo)
                        End If
                    Next
                End If
                frmStatusMessage.Close()
            End If
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡No es posible finalizar el recibo debido a que no se encuentra en PROCESO!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtDoc_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtDoc.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not TxtDoc.Text = vbNullString Then
                If cmbTipo.SelectedItem Is Nothing Then
                    MessageBox.Show("No se ha seleccionado tipo de documento para realizar la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                cargaDatosDocto(TxtDoc.Text.ToUpper.Trim.Replace("'", "''"), DateTime.Today.Year(), DateTime.Today.Month(), cmbTipo.SelectedItem)
                TxtDoc.Text = ""
            End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaDoc.PerformClick()
        End If
    End Sub

    Private Sub TxtProducto_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtProducto.KeyUp
        If e.KeyCode = Keys.Enter Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaProd.PerformClick()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If Not dtDoctos Is Nothing Then
            dtDoctos.Dispose()
        End If

        If Not dtDetalle Is Nothing Then
            dtDetalle.Dispose()
        End If

        dtDoctos = ModPOS.SiExisteRecupera("sp_recupera_recibodocumentos", "@IdRecibo", IdRecibo)
        dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_reciboAlmacenD", "@IdRecibo", IdRecibo)

        actualizaGrid()


    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtDetalle.Rows.Count > 0 Then
            Dim i As Integer

            If ChkTodos.Checked Then
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Recibido") = GridDetalle.GetDataRows(i).DataRow("Cantidad")
                Next
            Else
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Recibido") = 0
                Next
            End If
            dtDetalle.AcceptChanges()

            GridDetalle.Refresh()
        End If
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        If Estado >= 1 Then
            If GridDetalle.RowCount > 0 Then
                If PrintDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    ImprimirColocacion(IdRecibo, PrintDialog1.PrinterSettings.PrinterName, True)
                End If
            End If
        Else
            MessageBox.Show("Debe de guardar los cambios para poder visualizar el documento de recolección", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub



    Private Sub cmbMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivo.SelectedValueChanged
        If bload = True Then
            If dtDetalle.Rows.Count > 0 AndAlso Not cmbMotivo.SelectedValue Is Nothing Then
                Dim i As Integer
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    If GridDetalle.GetDataRows(i).DataRow("Recibido") = 0 Then
                        GridDetalle.GetDataRows(i).DataRow("TipoRechazo") = cmbMotivo.SelectedValue
                    End If
                Next
                dtDetalle.AcceptChanges()

            End If
        End If
    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Recibido" OrElse GridDetalle.CurrentColumn.Caption = "Tipo Rechazo" Then
                If GridDetalle.CurrentColumn.Caption = "Recibido" AndAlso Movilidad = True Then
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                Else
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                End If
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub btnAddEst_Click(sender As Object, e As EventArgs) Handles btnAddEst.Click
        If GridDetalle.RowCount > 0 Then
            If Not GridDetalle.GetValue("PROClave") Is Nothing Then
                Dim dtEstrategia As DataTable = ModPOS.Recupera_Tabla("st_recupera_estrategia", "@PROClave", GridDetalle.GetValue("PROClave"), "@ALMClave", ALMClave)
                If dtEstrategia.Rows.Count = 0 Then
                    If ModPOS.AddEstrategia Is Nothing Then
                        ModPOS.AddEstrategia = New FrmAddEstrategia
                        With ModPOS.AddEstrategia
                            .TallaColor = TallaColor
                            .StartPosition = FormStartPosition.CenterScreen
                            .ALMClave = ALMClave
                            .Form = "Confirmacion"
                        End With
                    End If
                    ModPOS.AddEstrategia.recuperaProducto(GridDetalle.GetValue("Clave"))
                    ModPOS.AddEstrategia.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.AddEstrategia.Show()
                    ModPOS.AddEstrategia.BringToFront()
                Else
                    MessageBox.Show("El producto seleccionado ya cuenta con una estrategia definida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Debe seleccionar el producto al que desea agregar una estrategia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Debe seleccionar el producto al que desea agregar una estrategia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    
    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        If BtnGuardar.Enabled = True AndAlso Estado < 2 AndAlso Movilidad = False AndAlso GridDetalle.RowCount > 0 Then
            If validaForm() Then
                Dim foundRows() As DataRow
                foundRows = dtDetalle.Select("Recibido <> Almacenado")
                If foundRows.GetLength(0) > 0 Then
                    BtnGuardar.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub UiTabRecibo_SelectedTabChanged(sender As Object, e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTabRecibo.SelectedTabChanged
        If e.Page.Name = "UiTabSobrante" Then
            If Not dtSobrante Is Nothing Then
                dtSobrante.Dispose()
            End If
            dtSobrante = Recupera_Tabla("st_recupera_sobrantes", "@IdRecibo", IdRecibo)
            GridSobrante.DataSource = dtSobrante
            GridSobrante.RetrieveStructure(True)
            GridSobrante.GroupByBoxVisible = False
        End If
    End Sub

    Private Sub btnParcial_Click(sender As Object, e As EventArgs) Handles btnParcial.Click
        If Estado = 1 Then

            Dim dtReciboDet As DataTable
            Dim dReciboMovil As Double
            Dim dRecibido As Double

            dtReciboDet = ModPOS.Recupera_Tabla("sp_recupera_reciboAlmacenD", "@IdRecibo", IdRecibo)
            dReciboMovil = dtReciboDet.Compute("SUM(Recibido)", "")
            dtReciboDet.Dispose()

            dRecibido = dtDetalle.Compute("SUM(Recibido)", "")

            If dRecibido <> dReciboMovil Then
                MessageBox.Show("Se encontraron diferencias en pantalla. Se iniciara actualizacón de la información", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BtnRefresh.PerformClick()
                Exit Sub
            End If

            If dRecibido > 0 Then

                Dim dtValida As DataTable

                dtValida = ModPOS.Recupera_Tabla("st_valida_parcial", "@IdRecibo", IdRecibo)

                If dtValida.Rows.Count > 0 Then

                    If MessageBox.Show("¿Esta seguro de que desea realizar el envio parcial del Recibo actual?.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then


                        Dim i, iTipoDocumento As Integer
                        Dim sTipo, sFolio, sFecha As String
                        Dim dtInterfaz As DataTable
                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                        For i = 0 To dtDoctos.Rows.Count - 1

                            If CStr(dtDoctos.Rows(i)("T")) = "C" Then
                                sTipo = "Compra"
                                iTipoDocumento = 2
                                sFolio = dtDoctos.Rows(i)("DOCClave")
                            ElseIf CStr(dtDoctos.Rows(i)("T")) = "CM" Then
                                sTipo = "Compra"
                                iTipoDocumento = 2
                                sFolio = dtDoctos.Rows(i)("DOCClave")
                            ElseIf CStr(dtDoctos.Rows(i)("T")) = "T" Then
                                sTipo = "Traslado"
                                iTipoDocumento = 8
                                sFolio = dtDoctos.Rows(i)("DOCClave")
                            ElseIf CStr(dtDoctos.Rows(i)("T")) = "TL" Then
                                sTipo = "Traslado"
                                iTipoDocumento = 8
                                sFolio = dtDoctos.Rows(i)("DOCClave")

                            End If

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", sTipo, "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", iTipoDocumento, "@Path", InterfazSalida, "@Fecha", sFecha, "@IdRecibo", IdRecibo)
                            End If
                        Next

                        ModPOS.Ejecuta("st_act_reciboalmacent", "@IdRecibo", IdRecibo, "@Estado", 2)

                        MessageBox.Show("!Proceso ejecutado correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        dtValida.Dispose()
                        Exit Sub
                    End If
                Else
                    Beep()
                    MessageBox.Show("!No se encontraron registros pendientes de Enviar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                End If
                dtValida.Dispose()

            Else
                Beep()
                MessageBox.Show("!No se encontro producto registrado para recibir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End If
        Else
            Beep()
            MessageBox.Show("!No es posible iniciar el proceso debido a que el documento se encuentra finalizado en o en estado de captura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
    End Sub


  
    Private Sub GridDetalle_FormattingRow(sender As Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridDetalle.FormattingRow
        Dim row As Janus.Windows.GridEX.GridEXRow = e.Row
        row.RowStyle = New Janus.Windows.GridEX.GridEXFormatStyle

        If row.Cells("Recibido").Value >= row.Cells("Cantidad").Value Then
            row.RowStyle.ForeColor = Color.Black
        Else
            row.RowStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub BtnBuscaUbicacion_Click(sender As Object, e As EventArgs) Handles BtnBuscaUbicacion.Click
            Dim a As New FrmConsulta
            a.Campo = "UBCClave"
            a.Campo2 = "Stage"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_aduana", "@ALMClave", ALMClave)
            a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                ubicacionRecibo = a.ID
                TxtUbicacion.Text = a.ID2
            Else
                ubicacionRecibo = ""
                TxtUbicacion.Text = ""
            End If
        End If
            a.Dispose()
    End Sub

    Private Sub TxtUbicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtUbicacion.Text <> "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_aduana", "@ALMClave", ALMClave)

                Dim foundRows() As Data.DataRow
                foundRows = dt.Select("Ubicacion = '" & TxtUbicacion.Text & "'")

                If foundRows.Length = 1 Then
                    ubicacionRecibo = foundRows(0)("UBCClave")
                Else
                    ubicacionRecibo = ""
                    MessageBox.Show("La clave de ubicación no existe o no pertenece a un Stage", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                dt.Dispose()
            End If
        
        End If
    End Sub
End Class
