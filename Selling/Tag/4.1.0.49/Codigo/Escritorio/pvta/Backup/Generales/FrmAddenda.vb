Public Class FrmAddenda
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
    Friend WithEvents BtnEliminaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpClass As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSubCte As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnAddCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblConexion As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbConexion As Selling.StoreCombo
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpFirma As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCorreo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpFTP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFTP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFirma As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddenda))
        Me.GrpClass = New System.Windows.Forms.GroupBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.TxtProveedor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.GrpCorreo = New System.Windows.Forms.GroupBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.TxtCorreo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GrpFTP = New System.Windows.Forms.GroupBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.TxtPwd = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtUsuario = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtFTP = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpFirma = New System.Windows.Forms.GroupBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.TxtFirma = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblTipo = New System.Windows.Forms.Label
        Me.cmbTipo = New Selling.StoreCombo
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbConexion = New Selling.StoreCombo
        Me.LblConexion = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpSubCte = New System.Windows.Forms.GroupBox
        Me.BtnAddCte = New Janus.Windows.EditControls.UIButton
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
        Me.BtnEliminaCte = New Janus.Windows.EditControls.UIButton
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpClass.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCorreo.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFTP.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFirma.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSubCte.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClass
        '
        Me.GrpClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClass.Controls.Add(Me.TxtCompany)
        Me.GrpClass.Controls.Add(Me.Label8)
        Me.GrpClass.Controls.Add(Me.PictureBox10)
        Me.GrpClass.Controls.Add(Me.TxtProveedor)
        Me.GrpClass.Controls.Add(Me.Label7)
        Me.GrpClass.Controls.Add(Me.PictureBox4)
        Me.GrpClass.Controls.Add(Me.GrpCorreo)
        Me.GrpClass.Controls.Add(Me.GrpFTP)
        Me.GrpClass.Controls.Add(Me.GrpFirma)
        Me.GrpClass.Controls.Add(Me.LblTipo)
        Me.GrpClass.Controls.Add(Me.cmbTipo)
        Me.GrpClass.Controls.Add(Me.PictureBox3)
        Me.GrpClass.Controls.Add(Me.cmbConexion)
        Me.GrpClass.Controls.Add(Me.LblConexion)
        Me.GrpClass.Controls.Add(Me.PictureBox1)
        Me.GrpClass.Controls.Add(Me.ChkEstado)
        Me.GrpClass.Controls.Add(Me.PictureBox2)
        Me.GrpClass.Controls.Add(Me.TxtDescripcion)
        Me.GrpClass.Controls.Add(Me.LblDescripcion)
        Me.GrpClass.Controls.Add(Me.TxtClave)
        Me.GrpClass.Controls.Add(Me.LblClave)
        Me.GrpClass.Controls.Add(Me.Label4)
        Me.GrpClass.Location = New System.Drawing.Point(7, 7)
        Me.GrpClass.Name = "GrpClass"
        Me.GrpClass.Size = New System.Drawing.Size(778, 298)
        Me.GrpClass.TabIndex = 1
        Me.GrpClass.TabStop = False
        Me.GrpClass.Text = "Configuración de Addenda"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(94, 14)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(512, 20)
        Me.TxtCompany.TabIndex = 98
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Compañia"
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(612, 132)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox10.TabIndex = 87
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'TxtProveedor
        '
        Me.TxtProveedor.Location = New System.Drawing.Point(387, 127)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(219, 20)
        Me.TxtProveedor.TabIndex = 82
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(295, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "No. Proveedor"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(404, 127)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox4.TabIndex = 81
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'GrpCorreo
        '
        Me.GrpCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCorreo.Controls.Add(Me.PictureBox9)
        Me.GrpCorreo.Controls.Add(Me.TxtCorreo)
        Me.GrpCorreo.Controls.Add(Me.Label6)
        Me.GrpCorreo.Location = New System.Drawing.Point(9, 246)
        Me.GrpCorreo.Name = "GrpCorreo"
        Me.GrpCorreo.Size = New System.Drawing.Size(760, 45)
        Me.GrpCorreo.TabIndex = 80
        Me.GrpCorreo.TabStop = False
        Me.GrpCorreo.Text = "Correo Electronico"
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(494, 19)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox9.TabIndex = 86
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'TxtCorreo
        '
        Me.TxtCorreo.Location = New System.Drawing.Point(85, 16)
        Me.TxtCorreo.Name = "TxtCorreo"
        Me.TxtCorreo.Size = New System.Drawing.Size(352, 20)
        Me.TxtCorreo.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Cuenta"
        '
        'GrpFTP
        '
        Me.GrpFTP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFTP.Controls.Add(Me.PictureBox8)
        Me.GrpFTP.Controls.Add(Me.PictureBox7)
        Me.GrpFTP.Controls.Add(Me.PictureBox6)
        Me.GrpFTP.Controls.Add(Me.TxtPwd)
        Me.GrpFTP.Controls.Add(Me.Label5)
        Me.GrpFTP.Controls.Add(Me.TxtUsuario)
        Me.GrpFTP.Controls.Add(Me.Label3)
        Me.GrpFTP.Controls.Add(Me.TxtFTP)
        Me.GrpFTP.Controls.Add(Me.Label2)
        Me.GrpFTP.Location = New System.Drawing.Point(9, 201)
        Me.GrpFTP.Name = "GrpFTP"
        Me.GrpFTP.Size = New System.Drawing.Size(760, 44)
        Me.GrpFTP.TabIndex = 80
        Me.GrpFTP.TabStop = False
        Me.GrpFTP.Text = "FTP"
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(655, 17)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox8.TabIndex = 85
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(471, 18)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox7.TabIndex = 84
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(200, 16)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 83
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtPwd
        '
        Me.TxtPwd.Location = New System.Drawing.Point(541, 14)
        Me.TxtPwd.Name = "TxtPwd"
        Me.TxtPwd.Size = New System.Drawing.Size(113, 20)
        Me.TxtPwd.TabIndex = 29
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(473, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Contraseña"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(357, 15)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(112, 20)
        Me.TxtUsuario.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(293, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Usuario"
        '
        'TxtFTP
        '
        Me.TxtFTP.Location = New System.Drawing.Point(86, 16)
        Me.TxtFTP.Name = "TxtFTP"
        Me.TxtFTP.Size = New System.Drawing.Size(202, 20)
        Me.TxtFTP.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Servidor"
        '
        'GrpFirma
        '
        Me.GrpFirma.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFirma.Controls.Add(Me.PictureBox5)
        Me.GrpFirma.Controls.Add(Me.TxtFirma)
        Me.GrpFirma.Controls.Add(Me.Label1)
        Me.GrpFirma.Location = New System.Drawing.Point(9, 150)
        Me.GrpFirma.Name = "GrpFirma"
        Me.GrpFirma.Size = New System.Drawing.Size(760, 45)
        Me.GrpFirma.TabIndex = 79
        Me.GrpFirma.TabStop = False
        Me.GrpFirma.Text = "Servicio Web"
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(592, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox5.TabIndex = 82
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'TxtFirma
        '
        Me.TxtFirma.Location = New System.Drawing.Point(57, 17)
        Me.TxtFirma.Name = "TxtFirma"
        Me.TxtFirma.Size = New System.Drawing.Size(529, 20)
        Me.TxtFirma.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Firma"
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(12, 42)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(80, 15)
        Me.LblTipo.TabIndex = 72
        Me.LblTipo.Text = "Tipo Addenda"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(94, 38)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipo.TabIndex = 71
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(612, 97)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox3.TabIndex = 64
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbConexion
        '
        Me.cmbConexion.Location = New System.Drawing.Point(94, 124)
        Me.cmbConexion.Name = "cmbConexion"
        Me.cmbConexion.Size = New System.Drawing.Size(160, 21)
        Me.cmbConexion.TabIndex = 4
        '
        'LblConexion
        '
        Me.LblConexion.Location = New System.Drawing.Point(13, 127)
        Me.LblConexion.Name = "LblConexion"
        Me.LblConexion.Size = New System.Drawing.Size(87, 15)
        Me.LblConexion.TabIndex = 62
        Me.LblConexion.Text = "Tipo Conexión"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(260, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(705, 14)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(64, 22)
        Me.ChkEstado.TabIndex = 2
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(368, 68)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Location = New System.Drawing.Point(94, 97)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(512, 20)
        Me.TxtDescripcion.TabIndex = 3
        '
        'LblDescripcion
        '
        Me.LblDescripcion.Location = New System.Drawing.Point(13, 104)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(80, 15)
        Me.LblDescripcion.TabIndex = 26
        Me.LblDescripcion.Text = "Descripcion"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(94, 68)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(259, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 73)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(371, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 20 Caracteres"
        '
        'GrpSubCte
        '
        Me.GrpSubCte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSubCte.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSubCte.Controls.Add(Me.BtnAddCte)
        Me.GrpSubCte.Controls.Add(Me.GridClientes)
        Me.GrpSubCte.Controls.Add(Me.BtnEliminaCte)
        Me.GrpSubCte.Location = New System.Drawing.Point(7, 310)
        Me.GrpSubCte.Name = "GrpSubCte"
        Me.GrpSubCte.Size = New System.Drawing.Size(778, 164)
        Me.GrpSubCte.TabIndex = 2
        Me.GrpSubCte.TabStop = False
        Me.GrpSubCte.Text = "Clientes con Addenda"
        '
        'BtnAddCte
        '
        Me.BtnAddCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddCte.Image = CType(resources.GetObject("BtnAddCte.Image"), System.Drawing.Image)
        Me.BtnAddCte.Location = New System.Drawing.Point(683, 15)
        Me.BtnAddCte.Name = "BtnAddCte"
        Me.BtnAddCte.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddCte.TabIndex = 2
        Me.BtnAddCte.Text = "&Agregar"
        Me.BtnAddCte.ToolTipText = "Agregar nuevo cliente al descuento actual"
        Me.BtnAddCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClientes
        '
        Me.GridClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.GroupByBoxVisible = False
        Me.GridClientes.Location = New System.Drawing.Point(7, 15)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(669, 141)
        Me.GridClientes.TabIndex = 1
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaCte
        '
        Me.BtnEliminaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaCte.Image = CType(resources.GetObject("BtnEliminaCte.Image"), System.Drawing.Image)
        Me.BtnEliminaCte.Location = New System.Drawing.Point(682, 52)
        Me.BtnEliminaCte.Name = "BtnEliminaCte"
        Me.BtnEliminaCte.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaCte.TabIndex = 3
        Me.BtnEliminaCte.Text = "&Eliminar "
        Me.BtnEliminaCte.ToolTipText = "Eliminar cliente seleccionado del descuento"
        Me.BtnEliminaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(695, 483)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 11
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 483)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 12
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddenda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpClass)
        Me.Controls.Add(Me.GrpSubCte)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmAddenda"
        Me.Text = "Descuento o Bonificación"
        Me.GrpClass.ResumeLayout(False)
        Me.GrpClass.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCorreo.ResumeLayout(False)
        Me.GrpCorreo.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFTP.ResumeLayout(False)
        Me.GrpFTP.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFirma.ResumeLayout(False)
        Me.GrpFirma.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSubCte.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public ADDClave As String = ""
    Public Clave As String
    Public Descripcion As String
    Public Tipo As Integer = 1
    Public TipoConexion As Integer = 1
    Public UsuarioFTP As String
    Public PwdFTP As String
    Public FTP As String
    Public Estado As Integer = 1
    Public Firma As String
    Public email As String
    Public NoProveedor As String

    Private sClienteSelected As String
    Private sNombre As String
    Private ClienteEdited As Boolean = False

    Private alerta(9) As PictureBox
    Private reloj As parpadea
    Private bCargado As Boolean = False
    Private dtCliente As DataTable

#Region "Metodos Internos"


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtProveedor.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If

        If Me.cmbConexion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Not cmbConexion.SelectedValue Is Nothing Then

            Select Case CInt(cmbConexion.SelectedValue)
                Case 1 'Servicio Web

                    If TxtFirma.Text = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(4))
                        reloj.Enabled = True
                        reloj.Start()
                    End If

                Case 2 'FTP
                    If TxtFTP.Text = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(5))
                        reloj.Enabled = True
                        reloj.Start()
                    End If

                    If TxtUsuario.Text = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(6))
                        reloj.Enabled = True
                        reloj.Start()
                    End If

                    If TxtPwd.Text = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(7))
                        reloj.Enabled = True
                        reloj.Start()
                    End If
                Case 3 'Correo
                    If TxtCorreo.Text = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(8))
                        reloj.Enabled = True
                        reloj.Start()
                    End If
            End Select

        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Addenda", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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


    Private Sub FrmAddenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.TxtCompany.Text = ModPOS.CompanyName

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

        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With cmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Addenda"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With cmbConexion
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Addenda"
            .NombreParametro2 = "campo"
            .Parametro2 = "Conexion"
            .llenar()
        End With

        cmbTipo.SelectedValue = Tipo
        TxtClave.Text = Clave
        TxtDescripcion.Text = Descripcion
        cmbConexion.SelectedValue = Tipo
        TxtFirma.Text = Firma
        TxtFTP.Text = FTP
        TxtUsuario.Text = UsuarioFTP
        TxtPwd.Text = PwdFTP
        TxtCorreo.Text = email
        TxtProveedor.Text = NoProveedor
        ChkEstado.Estado = Estado

        If cmbConexion.SelectedValue Is Nothing Then
            GrpFirma.Enabled = False
            GrpFTP.Enabled = False
            GrpCorreo.Enabled = False
        Else
            Select Case CInt(cmbConexion.SelectedValue)
                Case Is = 1
                    GrpFirma.Enabled = True
                    GrpFTP.Enabled = False
                    GrpCorreo.Enabled = False
                Case Is = 2
                    GrpFirma.Enabled = False
                    GrpFTP.Enabled = True
                    GrpCorreo.Enabled = False
                Case Is = 3
                    GrpFirma.Enabled = False
                    GrpFTP.Enabled = False
                    GrpCorreo.Enabled = True
            End Select
        End If


        If Padre = "Modificar" Then

            dtCliente = ModPOS.Recupera_Tabla("sp_muestra_addcte", "@ADDClave", ADDClave)



        Else
            dtCliente = ModPOS.CrearTabla("AddendaCliente", _
                                           "ID", "System.String", _
                                           "Clave", "System.String", _
                                           "Razon Social", "System.String", _
                                           "RFC", "System.String", _
                                           "Status", "System.Int32")
        End If

        GridClientes.DataSource = dtCliente
        GridClientes.RetrieveStructure(True)
        GridClientes.RootTable.Columns("ID").Visible = False
        GridClientes.RootTable.Columns("Status").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClientes.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClientes.RootTable.FormatConditions.Add(fc)

        bCargado = True

    End Sub

    Private Sub GridClientes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClientes.SelectionChanged
        If Not Me.GridClientes.GetValue(0) Is Nothing Then
            Me.BtnEliminaCte.Enabled = True
            Me.sClienteSelected = GridClientes.GetValue("ID")
            Me.sNombre = GridClientes.GetValue(1)
        Else
            Me.sClienteSelected = ""
            Me.sNombre = ""
            Me.BtnEliminaCte.Enabled = False
        End If
    End Sub

    Private Sub FrmAddenda_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Addenda.Dispose()
        ModPOS.Addenda = Nothing
    End Sub

    Public Sub addClienteDetalle(ByVal ID As String, ByVal Clave As String, ByVal RazonSocial As String, ByVal RFC As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtCliente.Select("ID Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtCliente.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ID
            row1.Item("Clave") = Clave
            row1.Item("Razon Social") = RazonSocial
            row1.Item("RFC") = RFC
            row1.Item("Status") = 0


            dtCliente.Rows.Add(row1)

            ClienteEdited = True
        End If

    End Sub

    
    Private Sub BtnAddCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCte.Click
        If ModPOS.AddCtes Is Nothing Then
            ModPOS.AddCtes = New FrmAddCtes
            With ModPOS.AddCtes
                .Text = "Agregar Cliente a la Lista de Addenda"
                .StartPosition = FormStartPosition.CenterScreen
                .Clave = Me.ADDClave
                .WindowsForm = "Addenda"
            End With
        End If
        ModPOS.AddCtes.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddCtes.Show()
        ModPOS.AddCtes.BringToFront()
    End Sub

    Private Sub BtnEliminaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaCte.Click
        If sClienteSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Cliente :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCliente.Select("ID Like '" & sClienteSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1
                        ClienteEdited = True
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub cmbConexion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConexion.SelectedValueChanged
        If bCargado Then
            If Not cmbConexion.SelectedValue Is Nothing Then
                Select Case CInt(cmbConexion.SelectedValue)
                    Case Is = 1
                        GrpFirma.Enabled = True
                        GrpFTP.Enabled = False
                        GrpCorreo.Enabled = False
                    Case Is = 2
                        GrpFirma.Enabled = False
                        GrpFTP.Enabled = True
                        GrpCorreo.Enabled = False
                    Case Is = 3
                        GrpFirma.Enabled = False
                        GrpFTP.Enabled = False
                        GrpCorreo.Enabled = True
                End Select

            Else

            End If
        End If

    End Sub



    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then

            
            
            If dtCliente.Rows.Count = 0 Then
                MessageBox.Show("¡Debe agregar por lo menos un cliente a la Addenda!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"

                    ADDClave = ModPOS.obtenerLlave
                    Clave = TxtClave.Text.Trim.ToUpper
                    Descripcion = TxtDescripcion.Text.Trim
                    Tipo = cmbTipo.SelectedValue
                    TipoConexion = cmbConexion.SelectedValue
                    UsuarioFTP = TxtUsuario.Text.Trim
                    PwdFTP = TxtPwd.Text.Trim
                    FTP = TxtFTP.Text.Trim
                    Firma = TxtFirma.Text.Trim
                    email = TxtCorreo.Text.Trim
                    NoProveedor = TxtProveedor.Text.Trim


                    ModPOS.Ejecuta("sp_inserta_addenda", _
                    "@ADDClave", ADDClave, _
                    "@Clave", Clave, _
                    "@Descripcion", Descripcion, _
                    "@Tipo", Tipo, _
                    "@TipoConexion", TipoConexion, _
                    "@UsuarioFTP", UsuarioFTP, _
                    "@PwdFTP", PwdFTP, _
                    "@FTP", FTP, _
                    "@FirmaWeb", Firma, _
                    "@email", email, _
                    "@NoProveedor", NoProveedor, _
                    "@Usuario", ModPOS.UsuarioActual, _
                        "@COMClave", ModPOS.CompanyActual)


                    Dim fila As Integer

                    Dim foundRows() As DataRow
                    foundRows = dtCliente.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        Cursor.Current = Cursors.WaitCursor
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_addcte", _
                            "@ADDClave", ADDClave, _
                            "@CTEClave", foundRows(fila)("ID"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                        Cursor.Current = Cursors.Default
                    End If


                    If Not ModPOS.MtoAddenda Is Nothing Then
                        ModPOS.ActualizaGrid(True, MtoAddenda.GridAddendas, "sp_muestra_addendas", "@COMClave", ModPOS.CompanyActual)
                        MtoAddenda.GridAddendas.RootTable.Columns("ADDClave").Visible = False
                    End If

                Case "Modificar"
                    If Not (Descripcion = TxtDescripcion.Text.Trim AndAlso _
                        Tipo = cmbTipo.SelectedValue AndAlso _
                        TipoConexion = cmbConexion.SelectedValue AndAlso _
                        UsuarioFTP = TxtUsuario.Text.Trim AndAlso _
                        PwdFTP = TxtPwd.Text.Trim AndAlso _
                        FTP = TxtFTP.Text.Trim AndAlso _
                        Firma = TxtFirma.Text.Trim AndAlso _
                        email = TxtCorreo.Text.Trim AndAlso _
                        NoProveedor = TxtProveedor.Text.Trim AndAlso _
                        Estado = ChkEstado.GetEstado) Then


                        Descripcion = TxtDescripcion.Text.Trim
                        Tipo = cmbTipo.SelectedValue
                        TipoConexion = cmbConexion.SelectedValue
                        UsuarioFTP = TxtUsuario.Text.Trim
                        PwdFTP = TxtPwd.Text.Trim
                        FTP = TxtFTP.Text.Trim
                        Firma = TxtFirma.Text.Trim
                        email = TxtCorreo.Text.Trim
                        NoProveedor = TxtProveedor.Text.Trim
                        Estado = ChkEstado.GetEstado


                        ModPOS.Ejecuta("sp_actualiza_addenda", _
                                        "@ADDClave", ADDClave, _
                                        "@Descripcion", Descripcion, _
                                        "@Tipo", Tipo, _
                                        "@TipoConexion", TipoConexion, _
                                        "@UsuarioFTP", UsuarioFTP, _
                                        "@PwdFTP", PwdFTP, _
                                        "@FTP", FTP, _
                                        "@FirmaWeb", Firma, _
                                        "@email", email, _
                                        "@NoProveedor", NoProveedor, _
                                        "@Estado", Estado, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@COMClave", ModPOS.CompanyActual)


                        If Not ModPOS.MtoAddenda Is Nothing Then
                            ModPOS.ActualizaGrid(True, MtoAddenda.GridAddendas, "sp_muestra_addendas", "@COMClave", ModPOS.CompanyActual)
                            MtoAddenda.GridAddendas.RootTable.Columns("ADDClave").Visible = False
                        End If

                    End If


                    If ClienteEdited = True Then
                        Dim fila As Integer
                        Dim foundRows() As DataRow

                        Cursor.Current = Cursors.WaitCursor
                        foundRows = dtCliente.Select("Status=0")

                        If foundRows.GetLength(0) > 0 Then
                            For fila = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_addcte", _
                                "@ADDClave", ADDClave, _
                                "@CTEClave", foundRows(fila)("ID"), _
                                "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        foundRows = dtCliente.Select("Status=-1")
                        If foundRows.GetLength(0) > 0 Then
                            Cursor.Current = Cursors.WaitCursor
                            For fila = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_elimina_addcte", "@CTEClave", foundRows(fila)("ID"), "@ADDCLAVE", ADDClave)
                            Next
                        End If
                        Cursor.Current = Cursors.Default

                    End If


            End Select

            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

End Class
