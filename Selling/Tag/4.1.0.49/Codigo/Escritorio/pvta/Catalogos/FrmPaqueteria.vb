Public Class FrmPaqueteria
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
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabCliente As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabCobertura As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpCobertura As System.Windows.Forms.GroupBox
    Friend WithEvents gridCobertura As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpPaqueteria As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVolMaxCaja As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaEnvio As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPorcSeguro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents UiTabTarifas As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpTarifas As System.Windows.Forms.GroupBox
    Friend WithEvents gridTarifas As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabExtra As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpExtra As System.Windows.Forms.GroupBox
    Friend WithEvents gridExtra As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSeguro As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProductoSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents btnFlete As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProductoFlete As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnImporCobertura As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImporTarifa As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImportExtra As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEliminarCobertura As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEliminaTarifa As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEliminaExtra As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkCobertura As Selling.ChkStatus
    Friend WithEvents chkTarifas As Selling.ChkStatus
    Friend WithEvents chkExtra As Selling.ChkStatus
    Friend WithEvents chkPaqueteriaGenerica As Selling.ChkStatus
    Friend WithEvents chkTarifaPesoMin As Selling.ChkStatus
    Friend WithEvents txtCombustible As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaqueteria))
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCliente = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpPaqueteria = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.btnSeguro = New Janus.Windows.EditControls.UIButton()
        Me.txtProductoSeguro = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btnFlete = New Janus.Windows.EditControls.UIButton()
        Me.txtProductoFlete = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtCombustible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPorcSeguro = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVolMaxCaja = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblLimite = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFormaEnvio = New Selling.StoreCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.UiTabCobertura = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpCobertura = New System.Windows.Forms.GroupBox()
        Me.chkCobertura = New Selling.ChkStatus(Me.components)
        Me.btnEliminarCobertura = New Janus.Windows.EditControls.UIButton()
        Me.btnImporCobertura = New Janus.Windows.EditControls.UIButton()
        Me.gridCobertura = New Janus.Windows.GridEX.GridEX()
        Me.UiTabTarifas = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpTarifas = New System.Windows.Forms.GroupBox()
        Me.chkTarifas = New Selling.ChkStatus(Me.components)
        Me.btnEliminaTarifa = New Janus.Windows.EditControls.UIButton()
        Me.btnImporTarifa = New Janus.Windows.EditControls.UIButton()
        Me.gridTarifas = New Janus.Windows.GridEX.GridEX()
        Me.UiTabExtra = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpExtra = New System.Windows.Forms.GroupBox()
        Me.chkExtra = New Selling.ChkStatus(Me.components)
        Me.btnEliminaExtra = New Janus.Windows.EditControls.UIButton()
        Me.btnImportExtra = New Janus.Windows.EditControls.UIButton()
        Me.gridExtra = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.chkTarifaPesoMin = New Selling.ChkStatus(Me.components)
        Me.chkPaqueteriaGenerica = New Selling.ChkStatus(Me.components)
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GrpPaqueteria.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCobertura.SuspendLayout()
        Me.grpCobertura.SuspendLayout()
        CType(Me.gridCobertura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabTarifas.SuspendLayout()
        Me.grpTarifas.SuspendLayout()
        CType(Me.gridTarifas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabExtra.SuspendLayout()
        Me.grpExtra.SuspendLayout()
        CType(Me.gridExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Location = New System.Drawing.Point(7, 0)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(770, 521)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCliente, Me.UiTabCobertura, Me.UiTabTarifas, Me.UiTabExtra})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCliente
        '
        Me.UiTabCliente.Controls.Add(Me.Panel1)
        Me.UiTabCliente.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCliente.Name = "UiTabCliente"
        Me.UiTabCliente.Size = New System.Drawing.Size(768, 499)
        Me.UiTabCliente.TabStop = True
        Me.UiTabCliente.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GrpPaqueteria)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 498)
        Me.Panel1.TabIndex = 1
        '
        'GrpPaqueteria
        '
        Me.GrpPaqueteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPaqueteria.BackColor = System.Drawing.Color.Transparent
        Me.GrpPaqueteria.Controls.Add(Me.chkPaqueteriaGenerica)
        Me.GrpPaqueteria.Controls.Add(Me.chkTarifaPesoMin)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox6)
        Me.GrpPaqueteria.Controls.Add(Me.btnSeguro)
        Me.GrpPaqueteria.Controls.Add(Me.txtProductoSeguro)
        Me.GrpPaqueteria.Controls.Add(Me.Label17)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox5)
        Me.GrpPaqueteria.Controls.Add(Me.btnFlete)
        Me.GrpPaqueteria.Controls.Add(Me.txtProductoFlete)
        Me.GrpPaqueteria.Controls.Add(Me.Label3)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox4)
        Me.GrpPaqueteria.Controls.Add(Me.txtCombustible)
        Me.GrpPaqueteria.Controls.Add(Me.Label4)
        Me.GrpPaqueteria.Controls.Add(Me.txtPorcSeguro)
        Me.GrpPaqueteria.Controls.Add(Me.Label2)
        Me.GrpPaqueteria.Controls.Add(Me.txtVolMaxCaja)
        Me.GrpPaqueteria.Controls.Add(Me.Label1)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox3)
        Me.GrpPaqueteria.Controls.Add(Me.lblLimite)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox1)
        Me.GrpPaqueteria.Controls.Add(Me.ChkEstado)
        Me.GrpPaqueteria.Controls.Add(Me.PictureBox2)
        Me.GrpPaqueteria.Controls.Add(Me.TxtNombre)
        Me.GrpPaqueteria.Controls.Add(Me.Label11)
        Me.GrpPaqueteria.Controls.Add(Me.cmbFormaEnvio)
        Me.GrpPaqueteria.Controls.Add(Me.Label8)
        Me.GrpPaqueteria.Controls.Add(Me.LblClave)
        Me.GrpPaqueteria.Controls.Add(Me.TxtClave)
        Me.GrpPaqueteria.Location = New System.Drawing.Point(7, 0)
        Me.GrpPaqueteria.Name = "GrpPaqueteria"
        Me.GrpPaqueteria.Size = New System.Drawing.Size(750, 495)
        Me.GrpPaqueteria.TabIndex = 1
        Me.GrpPaqueteria.TabStop = False
        Me.GrpPaqueteria.Text = "Paqueteria"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(286, 266)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox6.TabIndex = 141
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'btnSeguro
        '
        Me.btnSeguro.Image = CType(resources.GetObject("btnSeguro.Image"), System.Drawing.Image)
        Me.btnSeguro.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnSeguro.Location = New System.Drawing.Point(312, 257)
        Me.btnSeguro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSeguro.Name = "btnSeguro"
        Me.btnSeguro.Size = New System.Drawing.Size(31, 30)
        Me.btnSeguro.TabIndex = 10
        Me.btnSeguro.ToolTipText = "Busqueda de Clasificación"
        Me.btnSeguro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtProductoSeguro
        '
        Me.txtProductoSeguro.Location = New System.Drawing.Point(126, 264)
        Me.txtProductoSeguro.Name = "txtProductoSeguro"
        Me.txtProductoSeguro.Size = New System.Drawing.Size(154, 20)
        Me.txtProductoSeguro.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(7, 269)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(103, 15)
        Me.Label17.TabIndex = 139
        Me.Label17.Text = "Producto Seguro"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(286, 230)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox5.TabIndex = 137
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'btnFlete
        '
        Me.btnFlete.Image = CType(resources.GetObject("btnFlete.Image"), System.Drawing.Image)
        Me.btnFlete.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFlete.Location = New System.Drawing.Point(312, 221)
        Me.btnFlete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFlete.Name = "btnFlete"
        Me.btnFlete.Size = New System.Drawing.Size(31, 30)
        Me.btnFlete.TabIndex = 8
        Me.btnFlete.ToolTipText = "Busqueda de Clasificación"
        Me.btnFlete.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtProductoFlete
        '
        Me.txtProductoFlete.Location = New System.Drawing.Point(126, 228)
        Me.txtProductoFlete.Name = "txtProductoFlete"
        Me.txtProductoFlete.Size = New System.Drawing.Size(154, 20)
        Me.txtProductoFlete.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 15)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Producto Flete"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(253, 159)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox4.TabIndex = 86
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'txtCombustible
        '
        Me.txtCombustible.Location = New System.Drawing.Point(126, 190)
        Me.txtCombustible.Name = "txtCombustible"
        Me.txtCombustible.Size = New System.Drawing.Size(121, 20)
        Me.txtCombustible.TabIndex = 6
        Me.txtCombustible.Text = "0.00"
        Me.txtCombustible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtCombustible.Value = 0.0R
        Me.txtCombustible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "% Seguro"
        '
        'txtPorcSeguro
        '
        Me.txtPorcSeguro.Location = New System.Drawing.Point(126, 127)
        Me.txtPorcSeguro.Name = "txtPorcSeguro"
        Me.txtPorcSeguro.Size = New System.Drawing.Size(120, 20)
        Me.txtPorcSeguro.TabIndex = 4
        Me.txtPorcSeguro.Text = "0.00"
        Me.txtPorcSeguro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPorcSeguro.Value = 0.0R
        Me.txtPorcSeguro.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 15)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "% Cargo Combustible"
        '
        'txtVolMaxCaja
        '
        Me.txtVolMaxCaja.Location = New System.Drawing.Point(126, 159)
        Me.txtVolMaxCaja.Name = "txtVolMaxCaja"
        Me.txtVolMaxCaja.Size = New System.Drawing.Size(121, 20)
        Me.txtVolMaxCaja.TabIndex = 5
        Me.txtVolMaxCaja.Text = "0.00"
        Me.txtVolMaxCaja.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtVolMaxCaja.Value = 0.0R
        Me.txtVolMaxCaja.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 61
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(388, 102)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lblLimite
        '
        Me.lblLimite.Location = New System.Drawing.Point(7, 162)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(108, 15)
        Me.lblLimite.TabIndex = 57
        Me.lblLimite.Text = "Vol. Max. Caja"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(280, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 19)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Enabled = False
        Me.ChkEstado.Location = New System.Drawing.Point(522, 31)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(66, 23)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(575, 73)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 23)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(124, 68)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(445, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Nombre"
        '
        'cmbFormaEnvio
        '
        Me.cmbFormaEnvio.Location = New System.Drawing.Point(126, 99)
        Me.cmbFormaEnvio.Name = "cmbFormaEnvio"
        Me.cmbFormaEnvio.Size = New System.Drawing.Size(256, 21)
        Me.cmbFormaEnvio.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "forma Envio"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 35)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(126, 32)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(153, 20)
        Me.TxtClave.TabIndex = 1
        '
        'UiTabCobertura
        '
        Me.UiTabCobertura.Controls.Add(Me.grpCobertura)
        Me.UiTabCobertura.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCobertura.Name = "UiTabCobertura"
        Me.UiTabCobertura.Size = New System.Drawing.Size(768, 499)
        Me.UiTabCobertura.TabStop = True
        Me.UiTabCobertura.Text = "Cobertura"
        '
        'grpCobertura
        '
        Me.grpCobertura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCobertura.BackColor = System.Drawing.Color.Transparent
        Me.grpCobertura.Controls.Add(Me.chkCobertura)
        Me.grpCobertura.Controls.Add(Me.btnEliminarCobertura)
        Me.grpCobertura.Controls.Add(Me.btnImporCobertura)
        Me.grpCobertura.Controls.Add(Me.gridCobertura)
        Me.grpCobertura.Location = New System.Drawing.Point(7, 7)
        Me.grpCobertura.Name = "grpCobertura"
        Me.grpCobertura.Size = New System.Drawing.Size(752, 485)
        Me.grpCobertura.TabIndex = 10
        Me.grpCobertura.TabStop = False
        Me.grpCobertura.Text = "Cobertura"
        '
        'chkCobertura
        '
        Me.chkCobertura.Location = New System.Drawing.Point(13, 29)
        Me.chkCobertura.Name = "chkCobertura"
        Me.chkCobertura.Size = New System.Drawing.Size(143, 27)
        Me.chkCobertura.TabIndex = 162
        Me.chkCobertura.Text = "Todos"
        '
        'btnEliminarCobertura
        '
        Me.btnEliminarCobertura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarCobertura.Image = CType(resources.GetObject("btnEliminarCobertura.Image"), System.Drawing.Image)
        Me.btnEliminarCobertura.Location = New System.Drawing.Point(553, 19)
        Me.btnEliminarCobertura.Name = "btnEliminarCobertura"
        Me.btnEliminarCobertura.Size = New System.Drawing.Size(90, 37)
        Me.btnEliminarCobertura.TabIndex = 161
        Me.btnEliminarCobertura.Text = "&Eliminar "
        Me.btnEliminarCobertura.ToolTipText = "Eliminar registros seleccionados"
        Me.btnEliminarCobertura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImporCobertura
        '
        Me.btnImporCobertura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImporCobertura.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImporCobertura.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImporCobertura.Location = New System.Drawing.Point(649, 19)
        Me.btnImporCobertura.Name = "btnImporCobertura"
        Me.btnImporCobertura.Size = New System.Drawing.Size(90, 37)
        Me.btnImporCobertura.TabIndex = 160
        Me.btnImporCobertura.Text = "Importar"
        Me.btnImporCobertura.ToolTipText = "Importar cobertura"
        Me.btnImporCobertura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridCobertura
        '
        Me.gridCobertura.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridCobertura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridCobertura.ColumnAutoResize = True
        Me.gridCobertura.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridCobertura.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridCobertura.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridCobertura.Location = New System.Drawing.Point(13, 62)
        Me.gridCobertura.Name = "gridCobertura"
        Me.gridCobertura.RecordNavigator = True
        Me.gridCobertura.Size = New System.Drawing.Size(726, 407)
        Me.gridCobertura.TabIndex = 2
        Me.gridCobertura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabTarifas
        '
        Me.UiTabTarifas.Controls.Add(Me.grpTarifas)
        Me.UiTabTarifas.Location = New System.Drawing.Point(1, 21)
        Me.UiTabTarifas.Name = "UiTabTarifas"
        Me.UiTabTarifas.Size = New System.Drawing.Size(768, 499)
        Me.UiTabTarifas.TabStop = True
        Me.UiTabTarifas.Text = "Tarifas"
        '
        'grpTarifas
        '
        Me.grpTarifas.BackColor = System.Drawing.Color.Transparent
        Me.grpTarifas.Controls.Add(Me.chkTarifas)
        Me.grpTarifas.Controls.Add(Me.btnEliminaTarifa)
        Me.grpTarifas.Controls.Add(Me.btnImporTarifa)
        Me.grpTarifas.Controls.Add(Me.gridTarifas)
        Me.grpTarifas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpTarifas.Location = New System.Drawing.Point(0, 0)
        Me.grpTarifas.Name = "grpTarifas"
        Me.grpTarifas.Size = New System.Drawing.Size(768, 499)
        Me.grpTarifas.TabIndex = 13
        Me.grpTarifas.TabStop = False
        Me.grpTarifas.Text = "Tarifas"
        '
        'chkTarifas
        '
        Me.chkTarifas.Location = New System.Drawing.Point(10, 24)
        Me.chkTarifas.Name = "chkTarifas"
        Me.chkTarifas.Size = New System.Drawing.Size(143, 27)
        Me.chkTarifas.TabIndex = 162
        Me.chkTarifas.Text = "Todos"
        '
        'btnEliminaTarifa
        '
        Me.btnEliminaTarifa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminaTarifa.Image = CType(resources.GetObject("btnEliminaTarifa.Image"), System.Drawing.Image)
        Me.btnEliminaTarifa.Location = New System.Drawing.Point(570, 14)
        Me.btnEliminaTarifa.Name = "btnEliminaTarifa"
        Me.btnEliminaTarifa.Size = New System.Drawing.Size(90, 37)
        Me.btnEliminaTarifa.TabIndex = 161
        Me.btnEliminaTarifa.Text = "&Eliminar "
        Me.btnEliminaTarifa.ToolTipText = "Eliminar registros seleccionados"
        Me.btnEliminaTarifa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImporTarifa
        '
        Me.btnImporTarifa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImporTarifa.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImporTarifa.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImporTarifa.Location = New System.Drawing.Point(666, 14)
        Me.btnImporTarifa.Name = "btnImporTarifa"
        Me.btnImporTarifa.Size = New System.Drawing.Size(90, 37)
        Me.btnImporTarifa.TabIndex = 160
        Me.btnImporTarifa.Text = "Importar"
        Me.btnImporTarifa.ToolTipText = "Importar tarifas"
        Me.btnImporTarifa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridTarifas
        '
        Me.gridTarifas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridTarifas.ColumnAutoResize = True
        Me.gridTarifas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridTarifas.Location = New System.Drawing.Point(10, 57)
        Me.gridTarifas.Name = "gridTarifas"
        Me.gridTarifas.RecordNavigator = True
        Me.gridTarifas.Size = New System.Drawing.Size(746, 437)
        Me.gridTarifas.TabIndex = 4
        Me.gridTarifas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabExtra
        '
        Me.UiTabExtra.Controls.Add(Me.grpExtra)
        Me.UiTabExtra.Location = New System.Drawing.Point(1, 21)
        Me.UiTabExtra.Name = "UiTabExtra"
        Me.UiTabExtra.Size = New System.Drawing.Size(768, 499)
        Me.UiTabExtra.TabStop = True
        Me.UiTabExtra.Text = "Cargos Extra"
        '
        'grpExtra
        '
        Me.grpExtra.BackColor = System.Drawing.Color.Transparent
        Me.grpExtra.Controls.Add(Me.chkExtra)
        Me.grpExtra.Controls.Add(Me.btnEliminaExtra)
        Me.grpExtra.Controls.Add(Me.btnImportExtra)
        Me.grpExtra.Controls.Add(Me.gridExtra)
        Me.grpExtra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpExtra.Location = New System.Drawing.Point(0, 0)
        Me.grpExtra.Name = "grpExtra"
        Me.grpExtra.Size = New System.Drawing.Size(768, 499)
        Me.grpExtra.TabIndex = 15
        Me.grpExtra.TabStop = False
        Me.grpExtra.Text = "Cargo Extra"
        '
        'chkExtra
        '
        Me.chkExtra.Location = New System.Drawing.Point(10, 29)
        Me.chkExtra.Name = "chkExtra"
        Me.chkExtra.Size = New System.Drawing.Size(143, 27)
        Me.chkExtra.TabIndex = 162
        Me.chkExtra.Text = "Todos"
        '
        'btnEliminaExtra
        '
        Me.btnEliminaExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminaExtra.Image = CType(resources.GetObject("btnEliminaExtra.Image"), System.Drawing.Image)
        Me.btnEliminaExtra.Location = New System.Drawing.Point(570, 19)
        Me.btnEliminaExtra.Name = "btnEliminaExtra"
        Me.btnEliminaExtra.Size = New System.Drawing.Size(90, 37)
        Me.btnEliminaExtra.TabIndex = 161
        Me.btnEliminaExtra.Text = "&Eliminar "
        Me.btnEliminaExtra.ToolTipText = "Eliminar registros seleccionados"
        Me.btnEliminaExtra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnImportExtra
        '
        Me.btnImportExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportExtra.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportExtra.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportExtra.Location = New System.Drawing.Point(666, 19)
        Me.btnImportExtra.Name = "btnImportExtra"
        Me.btnImportExtra.Size = New System.Drawing.Size(90, 37)
        Me.btnImportExtra.TabIndex = 160
        Me.btnImportExtra.Text = "Importar"
        Me.btnImportExtra.ToolTipText = "Importar cargos Extra"
        Me.btnImportExtra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridExtra
        '
        Me.gridExtra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridExtra.ColumnAutoResize = True
        Me.gridExtra.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridExtra.Location = New System.Drawing.Point(10, 62)
        Me.gridExtra.Name = "gridExtra"
        Me.gridExtra.RecordNavigator = True
        Me.gridExtra.Size = New System.Drawing.Size(746, 432)
        Me.gridExtra.TabIndex = 4
        Me.gridExtra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(588, 524)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(685, 524)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chkTarifaPesoMin
        '
        Me.chkTarifaPesoMin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTarifaPesoMin.Location = New System.Drawing.Point(10, 302)
        Me.chkTarifaPesoMin.Name = "chkTarifaPesoMin"
        Me.chkTarifaPesoMin.Size = New System.Drawing.Size(236, 24)
        Me.chkTarifaPesoMin.TabIndex = 154
        Me.chkTarifaPesoMin.Text = "Tarifa para peso minimo"
        '
        'chkPaqueteriaGenerica
        '
        Me.chkPaqueteriaGenerica.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPaqueteriaGenerica.Location = New System.Drawing.Point(9, 332)
        Me.chkPaqueteriaGenerica.Name = "chkPaqueteriaGenerica"
        Me.chkPaqueteriaGenerica.Size = New System.Drawing.Size(237, 24)
        Me.chkPaqueteriaGenerica.TabIndex = 155
        Me.chkPaqueteriaGenerica.Text = "Paqueteria Generica"
        '
        'FrmPaqueteria
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(780, 567)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTab1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 530)
        Me.Name = "FrmPaqueteria"
        Me.Text = "Paqueteria"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GrpPaqueteria.ResumeLayout(False)
        Me.GrpPaqueteria.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCobertura.ResumeLayout(False)
        Me.grpCobertura.ResumeLayout(False)
        CType(Me.gridCobertura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabTarifas.ResumeLayout(False)
        Me.grpTarifas.ResumeLayout(False)
        CType(Me.gridTarifas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabExtra.ResumeLayout(False)
        Me.grpExtra.ResumeLayout(False)
        CType(Me.gridExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"


    Public Padre As String
    Public PAQClave As String = ""
    Public Clave As String = ""
    Public Nombre As String = ""
    Public formaEnvio As Integer
    Public productoFlete As String = ""
    Public porSeguro As Decimal
    Public productoSeguro As String = ""
    Public volMaxCaja As Decimal
    Public porCombustible As Decimal
    Public Estado As Integer = 1
    Public TarifaPesoMin As Integer = 0
    Public PaqueteriaGenerica As Integer = 0

#End Region

#Region "Variables Privadas"


    Private Cnx As String
    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private TallaColor As Integer = 0
    Private cpyProductoSeguro As String, cpyProductoFlete As String
    Private dtExtra, dtTarifa, dtCobertura As DataTable

#End Region

#Region "paqueteria"

    Private Sub cargaCoberturas()
        If Padre = "Modificar" Then

            dtCobertura = ModPOS.Recupera_Tabla("st_muestra_cobertura_paq", "@PAQClave", PAQClave)

        Else

            dtCobertura = ModPOS.CrearTabla("Cobertura", _
               "PAQClave", "System.String", _
               "CP", "System.String", _
               "Zona", "System.Int32", _
               "Modificado", "System.Int32", _
               "Baja", "System.Int32")

        End If

        gridCobertura.DataSource = dtCobertura
        gridCobertura.RetrieveStructure(True)
        gridCobertura.GroupByBoxVisible = False
        gridCobertura.RootTable.Columns("PAQClave").Visible = False
        gridCobertura.RootTable.Columns("Modificado").Visible = False
        gridCobertura.RootTable.Columns("Baja").Visible = False


        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(gridCobertura.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridCobertura.RootTable.FormatConditions.Add(fc0)

    End Sub

    Private Sub cargaTarifas()
        If Padre = "Modificar" Then
            dtTarifa = ModPOS.Recupera_Tabla("st_muestra_tarifas_paq", "@PAQClave", PAQClave)
        Else
            dtTarifa = ModPOS.CrearTabla("Tarifas", _
               "PAQClave", "System.String", _
               "Zona", "System.Int32", _
                "pesoMinCaja", "System.Double", _
               "pesoMaxCaja", "System.Double", _
               "Importe", "System.Decimal", _
                "Excedente", "System.Decimal", _
               "Modificado", "System.Int32", _
               "Baja", "System.Int32")
        End If


        gridTarifas.DataSource = dtTarifa
        gridTarifas.RetrieveStructure(True)
        gridTarifas.GroupByBoxVisible = False
        gridTarifas.RootTable.Columns("PAQClave").Visible = False
        gridTarifas.RootTable.Columns("Modificado").Visible = False
        gridTarifas.RootTable.Columns("Baja").Visible = False


        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(gridTarifas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridTarifas.RootTable.FormatConditions.Add(fc0)
      End Sub

    Public Sub cargaExtra()
        If Padre = "Modificar" Then

            dtExtra = ModPOS.Recupera_Tabla("st_muestra_cargo_extra_paq", "@PAQClave", PAQClave)

        Else

            dtExtra = ModPOS.CrearTabla("Extra", _
               "PAQClave", "System.String", _
               "CP", "System.String", _
               "Importe", "System.Decimal", _
               "Modificado", "System.Int32", _
               "Baja", "System.Int32")

        End If

        gridExtra.DataSource = dtExtra
        gridExtra.RetrieveStructure(True)
        gridExtra.GroupByBoxVisible = False
        gridExtra.RootTable.Columns("PAQClave").Visible = False
        gridExtra.RootTable.Columns("Modificado").Visible = False
        gridExtra.RootTable.Columns("Baja").Visible = False


        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(gridExtra.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridExtra.RootTable.FormatConditions.Add(fc0)

    End Sub


    Private Sub recuperaProductoFlete(ByVal sClave As String, ByVal esProclave As Boolean)
        Dim dtProducto As DataTable

        If esProclave = True Then
            dtProducto = ModPOS.SiExisteRecupera("sp_recupera_producto", "@PROClave", sClave.Replace("'", "''"))
        Else
            dtProducto = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
        End If

        If Not dtProducto Is Nothing Then
            cpyProductoFlete = dtProducto.Rows(0)("PROClave")
            txtProductoFlete.Text = dtProducto.Rows(0)("Clave")
            dtProducto.Dispose()




        Else
            cpyProductoFlete = productoFlete
            txtProductoFlete.Text = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub recuperaProductoSeguro(ByVal sClave As String, ByVal esProclave As Boolean)
        Dim dtProducto As DataTable

        If esProclave = True Then
            dtProducto = ModPOS.SiExisteRecupera("sp_recupera_producto", "@PROClave", sClave.Replace("'", "''"))
        Else
            dtProducto = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
        End If

        If Not dtProducto Is Nothing Then
            cpyProductoSeguro = dtProducto.Rows(0)("PROClave")
            txtProductoSeguro.Text = dtProducto.Rows(0)("Clave")
            dtProducto.Dispose()

        Else
            cpyProductoSeguro = productoSeguro
            txtProductoSeguro.Text = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub FrmPaqueteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        Cnx = ModPOS.BDConexion


        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                End Select
            Next
        End With


        With Me.cmbFormaEnvio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With

        If Padre = "Agregar" Then
            PAQClave = obtenerLlave()
        End If

        ChkEstado.Estado = Estado
        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        cmbFormaEnvio.SelectedValue = formaEnvio
        txtPorcSeguro.Text = porSeguro
        txtVolMaxCaja.Text = volMaxCaja
        txtCombustible.Text = porCombustible
        chkTarifaPesoMin.Estado = TarifaPesoMin
        chkPaqueteriaGenerica.Estado = PaqueteriaGenerica

        If productoFlete <> "" Then
            recuperaProductoFlete(productoFlete, True)
       
        End If

        If productoSeguro <> "" Then
            recuperaProductoSeguro(productoSeguro, True)
        End If

        cargaCoberturas()
        cargaTarifas()
        cargaExtra()


        If PAQClave = Clave Then
            GrpPaqueteria.Enabled = False
            grpCobertura.Enabled = False
            grpTarifas.Enabled = False
            grpCobertura.Enabled = False
        End If

    End Sub

    Public Sub reinicializa()
        PAQClave = ""
        Clave = ""
        Nombre = ""
        formaEnvio = 0
        volMaxCaja = 0
        porCombustible = 0
        porSeguro = 0
        cpyProductoFlete = ""
        cpyProductoSeguro = ""

        Estado = 1

        productoFlete = cpyProductoFlete
        productoSeguro = cpyProductoSeguro

        PAQClave = obtenerLlave()
        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        cmbFormaEnvio.SelectedValue = formaEnvio
        txtVolMaxCaja.Text = volMaxCaja
        txtCombustible.Text = porCombustible
        txtPorcSeguro.Text = porSeguro
        ChkEstado.Estado = Estado

        txtProductoFlete.Text = ""
        txtProductoSeguro.Text = ""

        TxtClave.Focus()


        cargaCoberturas()
        cargaTarifas()
        cargaExtra()


    End Sub

    Private Sub FrmPaqueteria_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoPaqueteria Is Nothing Then
            If Padre = "Agregar" Then
                ModPOS.MtoPaqueteria.refrescaGrid()
            End If
        End If
        ModPOS.Paqueteria.Dispose()
        ModPOS.Paqueteria = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim foundRows() As System.Data.DataRow
            Dim z As Integer
            Select Case Me.Padre
                Case "Agregar"

                    Clave = TxtClave.Text.ToUpper.Trim
                    Nombre = TxtNombre.Text.ToUpper.Trim
                    formaEnvio = cmbFormaEnvio.SelectedValue
                    porSeguro = txtPorcSeguro.Text
                    volMaxCaja = txtVolMaxCaja.Text
                    porCombustible = txtCombustible.Text
                    productoFlete = cpyProductoFlete
                    productoSeguro = cpyProductoSeguro
                    TarifaPesoMin = chkTarifaPesoMin.GetEstado
                    PaqueteriaGenerica = chkPaqueteriaGenerica.GetEstado

                    Dim msg As String = ""
                    msg = ModPOS.Ejecuta("st_inserta_paqueteria", _
                                        "@PAQClave", PAQClave, _
                                        "@Clave", Clave, _
                                        "@Nombre", Nombre, _
                                        "@formaEnvio", formaEnvio, _
                                        "@porSeguro", porSeguro, _
                                        "@volMaxCaja", volMaxCaja, _
                                        "@porCombustible", porCombustible, _
                                        "@productoFlete", productoFlete, _
                                        "@productoSeguro", productoSeguro, _
                                        "@tarifaPesoMinimo", TarifaPesoMin, _
                                        "@paqueteriaGenerica", PaqueteriaGenerica, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    
                    foundRows = dtCobertura.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length > 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_agrega_cobertura_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"), "@Zona", foundRows(z)("Zona"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If
                   

                    foundRows = dtTarifa.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_agrega_tarifa_paq", "@PAQClave", PAQClave, "@Zona", foundRows(z)("Zona"), "@Minimo", foundRows(z)("pesoMinCaja"), "@Peso", foundRows(z)("pesoMaxCaja"), "@Importe", foundRows(z)("Importe"), "@Excedente", foundRows(z)("Excedente"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtExtra.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_extra_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"), "@Importe", foundRows(z)("Importe"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                 
                    Me.reinicializa()

                Case "Modificar"

                    If Not (
                        Nombre = TxtNombre.Text.ToUpper.Trim AndAlso _
                        formaEnvio = cmbFormaEnvio.SelectedValue AndAlso _
                        porSeguro = txtPorcSeguro.Text AndAlso _
                        volMaxCaja = txtVolMaxCaja.Text AndAlso _
                        porCombustible = txtCombustible.Text AndAlso _
                        productoFlete = cpyProductoFlete AndAlso _
                        productoSeguro = cpyProductoSeguro AndAlso _
                         chkTarifaPesoMin.GetEstado = TarifaPesoMin AndAlso _
                        chkPaqueteriaGenerica.GetEstado = PaqueteriaGenerica AndAlso _
                        Estado = Me.ChkEstado.GetEstado) Then

                        Estado = ChkEstado.GetEstado
                        Nombre = TxtNombre.Text.ToUpper.Trim
                        formaEnvio = cmbFormaEnvio.SelectedValue
                        porSeguro = txtPorcSeguro.Text
                        volMaxCaja = txtVolMaxCaja.Text
                        porCombustible = txtCombustible.Text
                        productoFlete = cpyProductoFlete
                        productoSeguro = cpyProductoSeguro
                        TarifaPesoMin = chkTarifaPesoMin.GetEstado
                        PaqueteriaGenerica = chkPaqueteriaGenerica.GetEstado

                        ModPOS.Ejecuta("st_modifica_paqueteria", _
                                        "@PAQClave", PAQClave, _
                                        "@Estado", Estado, _
                                        "@Nombre", Nombre, _
                                        "@formaEnvio", formaEnvio, _
                                        "@porSeguro", porSeguro, _
                                        "@volMaxCaja", volMaxCaja, _
                                        "@porCombustible", porCombustible, _
                                        "@productoFlete", productoFlete, _
                                        "@productoSeguro", productoSeguro, _
                                         "@tarifaPesoMinimo", TarifaPesoMin, _
                                        "@paqueteriaGenerica", PaqueteriaGenerica, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    End If



                    foundRows = dtCobertura.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_cobertura_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"))
                        Next
                    End If

                    foundRows = dtTarifa.Select("  Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_tarifa_paq", "@PAQClave", PAQClave, "@Zona", foundRows(z)("Zona"))
                        Next
                    End If

                    foundRows = dtExtra.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_extra_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"))
                        Next
                    End If

                    foundRows = dtCobertura.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length > 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_agrega_cobertura_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"), "@Zona", foundRows(z)("Zona"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtTarifa.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_agrega_tarifa_paq", "@PAQClave", PAQClave, "@Zona", foundRows(z)("Zona"), "@Minimo", foundRows(z)("pesoMinCaja"), "@Peso", foundRows(z)("pesoMaxCaja"), "@Importe", foundRows(z)("Importe"), "@Excedente", foundRows(z)("Excedente"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtExtra.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_extra_paq", "@PAQClave", PAQClave, "@CP", foundRows(z)("CP"), "@Importe", foundRows(z)("Importe"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 60 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 60)
        End If

        If Me.cmbFormaEnvio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(txtVolMaxCaja.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cpyProductoFlete = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(txtPorcSeguro.Text) > 0 AndAlso cpyProductoSeguro = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Paqueteria", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
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

#End Region

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown, TxtNombre.KeyDown, txtPorcSeguro.KeyDown, txtCombustible.KeyDown, txtVolMaxCaja.KeyDown, cmbFormaEnvio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnFlete_Click(sender As Object, e As EventArgs) Handles btnFlete.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
            a.NumColDes3 = 3
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
            recuperaProductoFlete(a.valor, False)
        End If
        a.Dispose()


    End Sub

    Private Sub btnSeguro_Click(sender As Object, e As EventArgs) Handles btnSeguro.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
            a.NumColDes3 = 3
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
            recuperaProductoSeguro(a.valor, False)
        End If
        a.Dispose()
    End Sub

    Private Sub txtProductoFlete_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoFlete.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProductoFlete.Text <> "" Then
                recuperaProductoFlete(txtProductoFlete.Text.Trim, False)
            End If
        End If
    End Sub

    Private Sub txtProductoSeguro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoSeguro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProductoSeguro.Text <> "" Then
                recuperaProductoSeguro(txtProductoSeguro.Text.Trim, False)
            End If
        End If
    End Sub

    Private Sub chkCobertura_CheckedChanged(sender As Object, e As EventArgs) Handles chkCobertura.CheckedChanged
        If dtCobertura.Rows.Count > 0 Then
            Dim i As Integer

            If chkCobertura.Checked Then
                For i = 0 To gridCobertura.GetDataRows.Length - 1
                    gridCobertura.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To gridCobertura.GetDataRows.Length - 1
                    gridCobertura.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtCobertura.AcceptChanges()

            gridCobertura.Refresh()
        End If
    End Sub

    Private Sub chkTarifas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTarifas.CheckedChanged
        If dtTarifa.Rows.Count > 0 Then
            Dim i As Integer

            If chkTarifas.Checked Then
                For i = 0 To gridTarifas.GetDataRows.Length - 1
                    gridTarifas.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To gridTarifas.GetDataRows.Length - 1
                    gridTarifas.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtTarifa.AcceptChanges()

            gridTarifas.Refresh()
        End If
    End Sub

    Private Sub chkExtra_CheckedChanged(sender As Object, e As EventArgs) Handles chkExtra.CheckedChanged
        If dtExtra.Rows.Count > 0 Then
            Dim i As Integer
            If chkExtra.Checked Then
                For i = 0 To gridExtra.GetDataRows.Length - 1
                    gridExtra.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To gridExtra.GetDataRows.Length - 1
                    gridExtra.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtExtra.AcceptChanges()
            gridExtra.Refresh()
        End If
    End Sub

    Private Sub btnEliminaExtra_Click(sender As Object, e As EventArgs) Handles btnEliminaExtra.Click
        If Not dtExtra Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtExtra.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    foundRows(i)("Baja") = 1
                Next

            End If
        End If
    End Sub

    Private Sub gridCobertura_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridCobertura.CurrentCellChanged
        If Not gridCobertura.CurrentColumn Is Nothing Then
            If gridCobertura.CurrentColumn.Caption = "Marca" Then
                gridCobertura.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridCobertura.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub gridExtra_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridExtra.CurrentCellChanged
        If Not gridExtra.CurrentColumn Is Nothing Then
            If gridExtra.CurrentColumn.Caption = "Marca" OrElse gridExtra.CurrentColumn.Caption = "Importe" Then
                gridExtra.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridExtra.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub gridTarifas_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridTarifas.CurrentCellChanged
        If Not gridTarifas.CurrentColumn Is Nothing Then
            If gridTarifas.CurrentColumn.Caption = "Marca" OrElse gridTarifas.CurrentColumn.Caption = " Zona" OrElse gridTarifas.CurrentColumn.Caption = "pesoMaxCaja" OrElse gridTarifas.CurrentColumn.Caption = "Importe" Then
                gridTarifas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridTarifas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub btnImporCobertura_Click(sender As Object, e As EventArgs) Handles btnImporCobertura.Click
        Dim curFileName As String = ""
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 2)

                If dtTemporal.Rows.Count > 0 Then

                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i, Zona As Integer
                    Dim codigoPostal As String

                    Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                              "Fila", "System.String", _
                                              "CP", "System.String", _
                                              "Zona", "System.String", _
                                              "Error", "System.String")

                    Dim dt As DataTable


                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                        ' valida el producto
                        If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then

                            codigoPostal = CStr(dtTemporal.Rows(i)("GTIN")).Trim

                            If dtTemporal.Rows(i)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                If IsNumeric(dtTemporal.Rows(i)("Cantidad")) AndAlso CDbl(dtTemporal.Rows(i)("Cantidad")) >= 0 Then
                                    Zona = CDbl(dtTemporal.Rows(i)("Cantidad"))


                                    Dim foundRows() As System.Data.DataRow
                                    foundRows = dtCobertura.Select("CP = '" & codigoPostal & "'")

                                    If foundRows.Length = 0 Then
                                        Dim row1 As DataRow
                                        row1 = dtCobertura.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("PAQClave") = PAQClave
                                        row1.Item("CP") = codigoPostal
                                        row1.Item("Zona") = Zona
                                        row1.Item("Modificado") = 1
                                        row1.Item("Baja") = 0
                                        dtCobertura.Rows.Add(row1)
                                    ElseIf foundRows.Length = 1 Then
                                        foundRows(0)("Zona") = Zona
                                        foundRows(0)("Modificado") = 1
                                    End If
                                Else
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                                    row1.Item("Zona") = dtTemporal.Rows(i)("Cantidad")
                                    row1.Item("Error") = "El registro actual no cuenta con una Zona valida"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Zona") = dtTemporal.Rows(i)("Cantidad")
                                row1.Item("Error") = "El registro actual no cuenta con una Zona valida"
                                dtError.Rows.Add(row1)
                            End If
                        Else
                            Dim row1 As DataRow
                            row1 = dtError.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Fila") = i + 1
                            row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                            row1.Item("Zona") = dtTemporal.Rows(i)("Cantidad")
                            row1.Item("Error") = "El código postal no es valido"
                            dtError.Rows.Add(row1)
                        End If

                      
                    Next

                    If dtError.Rows.Count > 0 Then
                        MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim b As New FrmConsultaGen
                        b.Text = "Errores"
                        b.GridConsultaGen.DataSource = dtError
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtError.Dispose()
                    Else
                        MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: CodigoPostal,Zona", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnEliminarCobertura_Click(sender As Object, e As EventArgs) Handles btnEliminarCobertura.Click
        If Not dtCobertura Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtCobertura.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    foundRows(i)("Baja") = 1
                Next

            End If
        End If
    End Sub

    Private Sub btnEliminaTarifa_Click(sender As Object, e As EventArgs) Handles btnEliminaTarifa.Click
        If Not dtTarifa Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtTarifa.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    foundRows(i)("Baja") = 1
                Next

            End If
        End If
    End Sub

    Private Sub btnImporTarifa_Click(sender As Object, e As EventArgs) Handles btnImporTarifa.Click
        Dim curFileName As String = ""
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 5)

                If dtTemporal.Rows.Count > 0 Then

                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i, Zona As Integer
                    Dim peso, minimo As Double
                    Dim Importe, excedente As Decimal

                    Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                              "Fila", "System.String", _
                                              "Zona", "System.String", _
                                              "pesoMinCaja", "System.String", _
                                              "pesoMaxCaja", "System.String", _
                                              "Importe", "System.String", _
                                              "Excedente", "System.String", _
                                              "Error", "System.String")

                    Dim dt As DataTable

                    Cursor.Current = Cursors.WaitCursor
                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                        ' valida el producto
                        If dtTemporal.Rows(i)("Serie").GetType.FullName <> "System.DBNull" Then
                            If IsNumeric(dtTemporal.Rows(i)("Serie")) AndAlso CDbl(dtTemporal.Rows(i)("Serie")) >= 0 Then
                                Zona = CDbl(dtTemporal.Rows(i)("Serie"))

                                If dtTemporal.Rows(i)("Folio").GetType.FullName <> "System.DBNull" Then
                                    If IsNumeric(dtTemporal.Rows(i)("Folio")) AndAlso CDbl(dtTemporal.Rows(i)("Folio")) >= 0 Then
                                        minimo = CDbl(dtTemporal.Rows(i)("Folio"))

                                        If dtTemporal.Rows(i)("ClaveProducto").GetType.FullName <> "System.DBNull" Then
                                            If IsNumeric(dtTemporal.Rows(i)("ClaveProducto")) AndAlso CDbl(dtTemporal.Rows(i)("ClaveProducto")) >= 0 Then
                                                peso = CDbl(dtTemporal.Rows(i)("ClaveProducto"))

                                                If dtTemporal.Rows(i)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                                    If IsNumeric(dtTemporal.Rows(i)("Cantidad")) AndAlso CDbl(dtTemporal.Rows(i)("Cantidad")) >= 0 Then
                                                        Importe = CDbl(dtTemporal.Rows(i)("Cantidad"))

                                                        If dtTemporal.Rows(i)("IdMotivo").GetType.FullName <> "System.DBNull" Then
                                                            If IsNumeric(dtTemporal.Rows(i)("IdMotivo")) AndAlso CDbl(dtTemporal.Rows(i)("IdMotivo")) >= 0 Then
                                                                excedente = CDbl(dtTemporal.Rows(i)("IdMotivo"))

                                                                Dim foundRows() As System.Data.DataRow
                                                                foundRows = dtTarifa.Select("Zona = " & CStr(Zona) & " and pesoMaxCaja = " & CStr(peso))

                                                                If foundRows.Length = 0 Then
                                                                    Dim row1 As DataRow
                                                                    row1 = dtTarifa.NewRow()
                                                                    'declara el nombre de la fila
                                                                    row1.Item("PAQClave") = PAQClave
                                                                    row1.Item("Zona") = Zona
                                                                    row1.Item("pesoMinCaja") = minimo
                                                                    row1.Item("pesoMaxCaja") = peso
                                                                    row1.Item("Importe") = Importe
                                                                    row1.Item("Excedente") = Importe
                                                                    row1.Item("Modificado") = 1
                                                                    row1.Item("Baja") = 0
                                                                    dtTarifa.Rows.Add(row1)

                                                                ElseIf foundRows.Length = 1 Then
                                                                    foundRows(i)("pesoMaxCaja") = peso
                                                                    foundRows(i)("Importe") = Importe
                                                                    foundRows(i)("pesoMinCaja") = peso
                                                                    foundRows(i)("Excedente") = Importe
                                                                    foundRows(i)("Modificado") = 1
                                                                End If
                                                            Else
                                                                Dim row1 As DataRow
                                                                row1 = dtError.NewRow()
                                                                'declara el nombre de la fila
                                                                row1.Item("Fila") = i + 1
                                                                row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                                                row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                                                row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                                                row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                                                row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                                                row1.Item("Error") = "La tarifa excedente no es valida"
                                                                dtError.Rows.Add(row1)
                                                            End If
                                                        Else
                                                            Dim row1 As DataRow
                                                            row1 = dtError.NewRow()
                                                            'declara el nombre de la fila
                                                            row1.Item("Fila") = i + 1
                                                            row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                                            row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                                            row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                                            row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                                            row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                                            row1.Item("Error") = "La tarifa excedente no es valida"
                                                            dtError.Rows.Add(row1)
                                                        End If
                                                    Else
                                                        Dim row1 As DataRow
                                                        row1 = dtError.NewRow()
                                                        'declara el nombre de la fila
                                                        row1.Item("Fila") = i + 1
                                                        row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                                        row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                                        row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                                        row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                                        row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                                        row1.Item("Error") = "El Importe no es valido"
                                                        dtError.Rows.Add(row1)
                                                    End If
                                                Else
                                                    Dim row1 As DataRow
                                                    row1 = dtError.NewRow()
                                                    'declara el nombre de la fila
                                                    row1.Item("Fila") = i + 1
                                                    row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                                    row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                                    row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                                    row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                                    row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                                    row1.Item("Error") = "El Importe no es valido"
                                                    dtError.Rows.Add(row1)
                                                End If
                                            Else
                                                Dim row1 As DataRow
                                                row1 = dtError.NewRow()
                                                'declara el nombre de la fila
                                                row1.Item("Fila") = i + 1
                                                row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                                row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                                row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                                row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                                row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                                row1.Item("Error") = "El peso maximo no es valido"
                                                dtError.Rows.Add(row1)
                                            End If
                                        Else
                                            Dim row1 As DataRow
                                            row1 = dtError.NewRow()
                                            'declara el nombre de la fila
                                            row1.Item("Fila") = i + 1
                                            row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                            row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                            row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                            row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                            row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                            row1.Item("Error") = "El peso maximo no es valido"
                                            dtError.Rows.Add(row1)
                                        End If
                                    Else
                                        'minimo
                                        Dim row1 As DataRow
                                        row1 = dtError.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("Fila") = i + 1
                                        row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                        row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                        row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                        row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                        row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                        row1.Item("Error") = "El peso minimo es valido"
                                        dtError.Rows.Add(row1)
                                    End If
                                Else
                                    'minimo
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                    row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                    row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                    row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                    row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                    row1.Item("Error") = "El peso minimo es valido"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                                row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                                row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                                row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                                row1.Item("Error") = "El registro actual no cuenta con una Zona valida"
                                dtError.Rows.Add(row1)
                            End If
                        Else
                            Dim row1 As DataRow
                            row1 = dtError.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Fila") = i + 1
                            row1.Item("Zona") = dtTemporal.Rows(i)("Serie").ToString
                            row1.Item("pesoMinCaja") = dtTemporal.Rows(i)("Folio")
                            row1.Item("pesoMaxCaja") = dtTemporal.Rows(i)("ClaveProducto")
                            row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                            row1.Item("Excedente") = dtTemporal.Rows(i)("IdMotivo")
                            row1.Item("Error") = "El registro actual no cuenta con una Zona valida"
                            dtError.Rows.Add(row1)
                        End If

                    Next

                    If dtError.Rows.Count > 0 Then
                        MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim b As New FrmConsultaGen
                        b.Text = "Errores"
                        b.GridConsultaGen.DataSource = dtError
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtError.Dispose()
                    Else
                        MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: Zona,PesoMinimo, PesoMaximo, Importe, Excedente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnImportExtra_Click(sender As Object, e As EventArgs) Handles btnImportExtra.Click
        Dim curFileName As String = ""
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 2)

                If dtTemporal.Rows.Count > 0 Then

                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i As Integer
                    Dim importe As Decimal
                    Dim codigoPostal As String

                    Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                              "Fila", "System.String", _
                                              "CP", "System.String", _
                                              "Importe", "System.String", _
                                              "Error", "System.String")

                    Dim dt As DataTable


                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                        ' valida el producto
                        If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then

                            codigoPostal = dtTemporal.Rows(i)("GTIN")

                            If dtTemporal.Rows(i)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                If IsNumeric(dtTemporal.Rows(i)("Cantidad")) AndAlso CDbl(dtTemporal.Rows(i)("Cantidad")) >= 0 Then
                                    importe = CDbl(dtTemporal.Rows(i)("Cantidad"))


                                    Dim foundRows() As System.Data.DataRow
                                    foundRows = dtExtra.Select("CP = '" & codigoPostal & "'")

                                    If foundRows.Length = 0 Then
                                        Dim row1 As DataRow
                                        row1 = dtExtra.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("PAQClave") = PAQClave
                                        row1.Item("CP") = codigoPostal
                                        row1.Item("Importe") = importe
                                        row1.Item("Modificado") = 1
                                        row1.Item("Baja") = 0
                                        dtExtra.Rows.Add(row1)
                                    ElseIf foundRows.Length = 1 Then
                                        foundRows(i)("Importe") = importe
                                        foundRows(i)("Modificado") = 1
                                    End If
                                Else
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                                    row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                    row1.Item("Error") = "El Importe No es valido"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                                row1.Item("Error") = "El Importe no es valido"
                                dtError.Rows.Add(row1)
                            End If
                        Else
                            Dim row1 As DataRow
                            row1 = dtError.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Fila") = i + 1
                            row1.Item("CP") = dtTemporal.Rows(i)("GTIN").ToString
                            row1.Item("Importe") = dtTemporal.Rows(i)("Cantidad")
                            row1.Item("Error") = "El registro actual no cuenta con una Zona valida"
                            dtError.Rows.Add(row1)
                        End If


                    Next

                    If dtError.Rows.Count > 0 Then
                        MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim b As New FrmConsultaGen
                        b.Text = "Errores"
                        b.GridConsultaGen.DataSource = dtError
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtError.Dispose()
                    Else
                        MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: CodigoPostal,Importe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
