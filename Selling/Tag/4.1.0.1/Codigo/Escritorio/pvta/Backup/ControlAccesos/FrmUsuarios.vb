Public Class FrmUsuarios
    Inherits System.Windows.Forms.Form

    Public USRClave As String
    Public PERClave As String = ""
    Public Referencia As String = ""
    Public Nombre As String = ""
    Public CMIClave As String = ""
    Public PorcMaxDesc As Double = 0
    Public CambiaPrecio As Integer
    Public ModCosto As Integer = 0
    Public Login As String = ""
    Public Password As String = ""
    Public SUCClave As String = ""
    Public MaxCredito As Double = 0
    Public CambiaLista As Integer

    Private updAccesos As Boolean = False
    Private bload As Boolean = False
    Private dtAcceso As DataTable

    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbTipoComision As Selling.StoreCombo
    Friend WithEvents GrpSucursales As System.Windows.Forms.GroupBox
    Friend WithEvents ChkListSucursales As System.Windows.Forms.CheckedListBox
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnQuitar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkModCosto As Selling.ChkStatus
    Friend WithEvents TxtMaxCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ChkCambiaLista As Selling.ChkStatus
    Public Estado As Integer = 1



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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbPerfil As Selling.StoreCombo
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblTArea As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents GrpAcceso As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkCambiaPrecios As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuarios))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GrpAcceso = New System.Windows.Forms.GroupBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.TxtConfirmar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.TxtContraseña = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtLogin = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpDatos = New System.Windows.Forms.GroupBox
        Me.ChkCambiaLista = New Selling.ChkStatus(Me.components)
        Me.TxtMaxCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ChkModCosto = New Selling.ChkStatus(Me.components)
        Me.CmbTipoComision = New Selling.StoreCombo
        Me.ChkCambiaPrecios = New Selling.ChkStatus(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmbPerfil = New Selling.StoreCombo
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblTArea = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.GrpSucursales = New System.Windows.Forms.GroupBox
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.BtnQuitar = New Janus.Windows.EditControls.UIButton
        Me.ChkListSucursales = New System.Windows.Forms.CheckedListBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.Panel1.SuspendLayout()
        Me.GrpAcceso.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDatos.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSucursales.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GrpAcceso)
        Me.Panel1.Controls.Add(Me.GrpDatos)
        Me.Panel1.Controls.Add(Me.GrpSucursales)
        Me.Panel1.Location = New System.Drawing.Point(7, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(579, 504)
        Me.Panel1.TabIndex = 6
        '
        'GrpAcceso
        '
        Me.GrpAcceso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAcceso.Controls.Add(Me.PictureBox7)
        Me.GrpAcceso.Controls.Add(Me.PictureBox5)
        Me.GrpAcceso.Controls.Add(Me.TxtConfirmar)
        Me.GrpAcceso.Controls.Add(Me.Label6)
        Me.GrpAcceso.Controls.Add(Me.Label7)
        Me.GrpAcceso.Controls.Add(Me.PictureBox6)
        Me.GrpAcceso.Controls.Add(Me.TxtContraseña)
        Me.GrpAcceso.Controls.Add(Me.Label4)
        Me.GrpAcceso.Controls.Add(Me.Label5)
        Me.GrpAcceso.Controls.Add(Me.TxtLogin)
        Me.GrpAcceso.Controls.Add(Me.Label2)
        Me.GrpAcceso.Controls.Add(Me.Label3)
        Me.GrpAcceso.Location = New System.Drawing.Point(7, 229)
        Me.GrpAcceso.Name = "GrpAcceso"
        Me.GrpAcceso.Size = New System.Drawing.Size(570, 104)
        Me.GrpAcceso.TabIndex = 2
        Me.GrpAcceso.TabStop = False
        Me.GrpAcceso.Text = "Acceso"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(293, 83)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox7.TabIndex = 75
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(293, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox5.TabIndex = 39
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'TxtConfirmar
        '
        Me.TxtConfirmar.Location = New System.Drawing.Point(87, 74)
        Me.TxtConfirmar.Name = "TxtConfirmar"
        Me.TxtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmar.Size = New System.Drawing.Size(201, 20)
        Me.TxtConfirmar.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Confirmar"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(301, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Max. 20 Caracteres"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(293, 48)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 65
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtContraseña
        '
        Me.TxtContraseña.Location = New System.Drawing.Point(87, 45)
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtContraseña.Size = New System.Drawing.Size(201, 20)
        Me.TxtContraseña.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Contraseña"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(301, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 15)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Max. 20 Caracteres"
        '
        'TxtLogin
        '
        Me.TxtLogin.Location = New System.Drawing.Point(87, 15)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(201, 20)
        Me.TxtLogin.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Login"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(301, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Max. 20 Caracteres"
        '
        'GrpDatos
        '
        Me.GrpDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDatos.Controls.Add(Me.ChkCambiaLista)
        Me.GrpDatos.Controls.Add(Me.TxtMaxCredito)
        Me.GrpDatos.Controls.Add(Me.Label8)
        Me.GrpDatos.Controls.Add(Me.ChkModCosto)
        Me.GrpDatos.Controls.Add(Me.CmbTipoComision)
        Me.GrpDatos.Controls.Add(Me.ChkCambiaPrecios)
        Me.GrpDatos.Controls.Add(Me.PictureBox4)
        Me.GrpDatos.Controls.Add(Me.Label9)
        Me.GrpDatos.Controls.Add(Me.PictureBox3)
        Me.GrpDatos.Controls.Add(Me.TxtDescuento)
        Me.GrpDatos.Controls.Add(Me.Label10)
        Me.GrpDatos.Controls.Add(Me.Label1)
        Me.GrpDatos.Controls.Add(Me.ChkEstado)
        Me.GrpDatos.Controls.Add(Me.PictureBox1)
        Me.GrpDatos.Controls.Add(Me.PictureBox2)
        Me.GrpDatos.Controls.Add(Me.CmbPerfil)
        Me.GrpDatos.Controls.Add(Me.TxtNombre)
        Me.GrpDatos.Controls.Add(Me.TxtClave)
        Me.GrpDatos.Controls.Add(Me.LblTArea)
        Me.GrpDatos.Controls.Add(Me.LblNombre)
        Me.GrpDatos.Controls.Add(Me.LblClave)
        Me.GrpDatos.Location = New System.Drawing.Point(7, 7)
        Me.GrpDatos.Name = "GrpDatos"
        Me.GrpDatos.Size = New System.Drawing.Size(570, 217)
        Me.GrpDatos.TabIndex = 1
        Me.GrpDatos.TabStop = False
        Me.GrpDatos.Text = "Datos"
        '
        'ChkCambiaLista
        '
        Me.ChkCambiaLista.Checked = True
        Me.ChkCambiaLista.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCambiaLista.Location = New System.Drawing.Point(365, 195)
        Me.ChkCambiaLista.Name = "ChkCambiaLista"
        Me.ChkCambiaLista.Size = New System.Drawing.Size(200, 15)
        Me.ChkCambiaLista.TabIndex = 76
        Me.ChkCambiaLista.Text = "Cambiar Lista de Precios a Clientes"
        '
        'TxtMaxCredito
        '
        Me.TxtMaxCredito.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtMaxCredito.Location = New System.Drawing.Point(192, 171)
        Me.TxtMaxCredito.Name = "TxtMaxCredito"
        Me.TxtMaxCredito.Size = New System.Drawing.Size(96, 20)
        Me.TxtMaxCredito.TabIndex = 74
        Me.TxtMaxCredito.Text = "$0.00"
        Me.TxtMaxCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMaxCredito.Value = 0
        Me.TxtMaxCredito.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 14)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "Limite Max. Crédito a Otorgar"
        '
        'ChkModCosto
        '
        Me.ChkModCosto.Checked = True
        Me.ChkModCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkModCosto.Location = New System.Drawing.Point(196, 195)
        Me.ChkModCosto.Name = "ChkModCosto"
        Me.ChkModCosto.Size = New System.Drawing.Size(163, 15)
        Me.ChkModCosto.TabIndex = 73
        Me.ChkModCosto.Text = "Edita Costos y Precios"
        '
        'CmbTipoComision
        '
        Me.CmbTipoComision.Location = New System.Drawing.Point(93, 113)
        Me.CmbTipoComision.Name = "CmbTipoComision"
        Me.CmbTipoComision.Size = New System.Drawing.Size(195, 21)
        Me.CmbTipoComision.TabIndex = 4
        '
        'ChkCambiaPrecios
        '
        Me.ChkCambiaPrecios.Checked = True
        Me.ChkCambiaPrecios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCambiaPrecios.Location = New System.Drawing.Point(16, 195)
        Me.ChkCambiaPrecios.Name = "ChkCambiaPrecios"
        Me.ChkCambiaPrecios.Size = New System.Drawing.Size(165, 15)
        Me.ChkCambiaPrecios.TabIndex = 6
        Me.ChkCambiaPrecios.Text = "Cambia Precios en la Venta"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(293, 118)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox4.TabIndex = 38
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(293, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 15)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "%"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(293, 82)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 37
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Location = New System.Drawing.Point(192, 146)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(96, 20)
        Me.TxtDescuento.TabIndex = 5
        Me.TxtDescuento.Text = "0.00"
        Me.TxtDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescuento.Value = 0
        Me.TxtDescuento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(13, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 15)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Porc. Descuento Max."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Tipo Comisión"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(495, 18)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(64, 23)
        Me.ChkEstado.TabIndex = 7
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(240, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(294, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 63
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbPerfil
        '
        Me.CmbPerfil.Location = New System.Drawing.Point(93, 77)
        Me.CmbPerfil.Name = "CmbPerfil"
        Me.CmbPerfil.Size = New System.Drawing.Size(195, 21)
        Me.CmbPerfil.TabIndex = 3
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(93, 45)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(195, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(93, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblTArea
        '
        Me.LblTArea.Location = New System.Drawing.Point(13, 82)
        Me.LblTArea.Name = "LblTArea"
        Me.LblTArea.Size = New System.Drawing.Size(80, 15)
        Me.LblTArea.TabIndex = 62
        Me.LblTArea.Text = "Perfil"
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 52)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 61
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 60
        Me.LblClave.Text = "Clave"
        '
        'GrpSucursales
        '
        Me.GrpSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSucursales.Controls.Add(Me.BtnAdd)
        Me.GrpSucursales.Controls.Add(Me.BtnQuitar)
        Me.GrpSucursales.Controls.Add(Me.ChkListSucursales)
        Me.GrpSucursales.Location = New System.Drawing.Point(6, 339)
        Me.GrpSucursales.Name = "GrpSucursales"
        Me.GrpSucursales.Size = New System.Drawing.Size(567, 162)
        Me.GrpSucursales.TabIndex = 3
        Me.GrpSucursales.TabStop = False
        Me.GrpSucursales.Text = "Accesos a Sucursales"
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(470, 20)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(90, 30)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "&Agregar"
        Me.BtnAdd.ToolTipText = "Agregar Accesos a Sucursales"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnQuitar
        '
        Me.BtnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnQuitar.Image = CType(resources.GetObject("BtnQuitar.Image"), System.Drawing.Image)
        Me.BtnQuitar.Location = New System.Drawing.Point(470, 59)
        Me.BtnQuitar.Name = "BtnQuitar"
        Me.BtnQuitar.Size = New System.Drawing.Size(90, 30)
        Me.BtnQuitar.TabIndex = 3
        Me.BtnQuitar.Text = "&Remover"
        Me.BtnQuitar.ToolTipText = "Remueve Accesos a Sucursales"
        Me.BtnQuitar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkListSucursales
        '
        Me.ChkListSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkListSucursales.Location = New System.Drawing.Point(7, 19)
        Me.ChkListSucursales.Name = "ChkListSucursales"
        Me.ChkListSucursales.Size = New System.Drawing.Size(456, 139)
        Me.ChkListSucursales.TabIndex = 1
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(391, 521)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(489, 521)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 4
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmUsuarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(591, 566)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUsuarios"
        Me.Text = "Usuarios"
        Me.Panel1.ResumeLayout(False)
        Me.GrpAcceso.ResumeLayout(False)
        Me.GrpAcceso.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDatos.ResumeLayout(False)
        Me.GrpDatos.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSucursales.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Private alerta(6) As PictureBox
    Private reloj As parpadea
    Private PorComision, PorDescMax As Double

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmUsuarios_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Usuarios.Dispose()
        ModPOS.Usuarios = Nothing
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0
        Dim existeLogin As Integer
        Dim Con As String = ModPOS.BDConexion


        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)
        End If


        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)
        End If


        If Me.CmbPerfil.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbTipoComision.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLogin.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtLogin.Text.Length > 20 Then
            Me.TxtLogin.Text = Me.TxtLogin.Text.Substring(0, 20)
        End If


        If Me.TxtContraseña.Text <> Me.TxtConfirmar.Text Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()

            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtContraseña.Text.Length > 60 Then
            Me.TxtContraseña.Text = Me.TxtConfirmar.Text.Substring(0, 60)
        End If

        If i > 0 Then
            Return False

        ElseIf Me.Padre = "Agregar" AndAlso ModPOS.SiExite(Con, "sp_valida_PK", "@Tabla", "Usuario", "@Clave", UCase(Trim(TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) Then
            Beep()
            MessageBox.Show("La clave de usuario que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
            Return False
        Else
            existeLogin = ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Login", "@clave", UCase(Trim(Me.TxtLogin.Text)), "@COMClave", ModPOS.CompanyActual)
            If (existeLogin > 0 AndAlso Me.Padre = "Agregar") OrElse _
            (existeLogin > 0 AndAlso Me.Padre = "Modificar" AndAlso Login <> UCase(Trim(Me.TxtLogin.Text))) Then
                Beep()
                MessageBox.Show("El Login que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(4))
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
        End If
    End Function

    Private Sub FrmUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7

        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With CmbPerfil
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_perfil"
            .llenar()
        End With


        With CmbTipoComision
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_comision_vendedor"
            .llenar()
        End With

        Me.TxtClave.Text = Referencia
        Me.CmbPerfil.SelectedValue = PERClave
        Me.TxtNombre.Text = Nombre
        Me.CmbTipoComision.SelectedValue = CMIClave
        Me.TxtDescuento.Text = CStr(PorcMaxDesc)
        Me.TxtLogin.Text = Login
        Me.TxtContraseña.Text = Me.Password
        Me.TxtConfirmar.Text = Me.Password
        Me.ChkEstado.Estado = Estado
        Me.ChkCambiaPrecios.Estado = CambiaPrecio
        Me.ChkModCosto.Estado = ModCosto
        Me.TxtMaxCredito.Text = MaxCredito
        Me.ChkCambiaLista.Estado = CambiaLista

        If Padre = "Agregar" Then
            actualizaAccesos(1)
        Else
            actualizaAccesos(2)
        End If
        bload = True
    End Sub

    Public Sub reinicializa()

        Referencia = ""
        PERClave = ""
        Nombre = ""
        CMIClave = ""
        PorcMaxDesc = 0
        Login = ""
        Password = ""
        Estado = 1
        CambiaPrecio = 0
        ModCosto = 0
        MaxCredito = 0
        CambiaLista = 0

        Me.TxtClave.Text = Referencia
        Me.CmbPerfil.SelectedValue = PERClave
        Me.TxtNombre.Text = Nombre
        Me.CmbTipoComision.SelectedValue = CMIClave
        Me.TxtDescuento.Text = CStr(PorcMaxDesc)
        Me.TxtLogin.Text = Login
        Me.TxtContraseña.Text = Me.Password
        Me.TxtConfirmar.Text = Me.Password
        Me.ChkEstado.Estado = Estado
        Me.ChkCambiaPrecios.Estado = CambiaPrecio
        Me.ChkCambiaLista.Estado = CambiaLista
        ChkModCosto.Estado = ModCosto
        Me.TxtMaxCredito.Text = MaxCredito

        dtAcceso.Dispose()
        actualizaAccesos(1)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If validaForm() Then
            If ChkListSucursales.CheckedItems.Count = 1 Then
                Select Case ModPOS.Usuarios.Padre
                    Case "Agregar"

                        USRClave = ModPOS.obtenerLlave
                        Me.Referencia = UCase(Trim(Me.TxtClave.Text))
                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                        CMIClave = CmbTipoComision.SelectedValue
                        Me.PERClave = Me.CmbPerfil.SelectedValue
                        Me.Login = UCase(Trim(Me.TxtLogin.Text))
                        Me.Password = Me.TxtContraseña.Text.Trim
                        CambiaPrecio = Me.ChkCambiaPrecios.GetEstado
                        SUCClave = ChkListSucursales.CheckedItems(0).row.itemarray(0)
                        ModCosto = Me.ChkCambiaPrecios.GetEstado
                        CambiaLista = ChkCambiaLista.GetEstado

                        If TxtDescuento.Text = "" Then
                            PorcMaxDesc = 0
                        Else
                            PorcMaxDesc = Math.Abs(CDbl(TxtDescuento.Text))
                        End If

                        If PorcMaxDesc >= 100 Then
                            PorcMaxDesc = 99
                        End If

                        If TxtMaxCredito.Text = "" Then
                            MaxCredito = 0
                        Else
                            MaxCredito = Math.Abs(CDbl(TxtMaxCredito.Text))
                        End If


                        ModPOS.Ejecuta("sp_inserta_usuario", _
                        "@USRClave", USRClave, _
                        "@Referencia", Referencia, _
                        "@Perfil", PERClave, _
                        "@Nombre", Nombre, _
                        "@CMIClave", CMIClave, _
                        "@PorcMaxDesc", PorcMaxDesc, _
                        "@CambiaPrecio", CambiaPrecio, _
                        "@Login", Login, _
                        "@Pass", EW.Encrypt.HashPass.CreateHash(Password), _
                        "@SUCClave", SUCClave, _
                        "@ModCosto", ModCosto, _
                        "@MaxCredito", MaxCredito, _
                        "@CambiaLista", CambiaLista, _
                        "@Usuario", ModPOS.UsuarioActual)

                        Dim i As Integer
                        For i = 0 To Me.ChkListSucursales.Items.Count - 1
                            ModPOS.Ejecuta("sp_actualiza_acceso", "@USRClave", Me.USRClave, "@SUCClave", dtAcceso.Rows(i).ItemArray(0))
                        Next

                        ModPOS.ActualizaGrid(True, ModPOS.MtoUsuario.GridUsuarios, "sp_muestra_usuarios", Nothing)

                        reinicializa()

                    Case "Modificar"
                        If TxtDescuento.Text = "" Then
                            PorDescMax = 0
                        Else
                            PorDescMax = Math.Abs(CDbl(TxtDescuento.Text))
                        End If

                        If PorDescMax >= 100 Then
                            PorDescMax = 99
                        End If

                       

                        If Not (Nombre = UCase(Trim(TxtNombre.Text)) AndAlso _
                                CMIClave = CmbTipoComision.SelectedValue AndAlso _
                                PorcMaxDesc = PorDescMax AndAlso _
                                PERClave = UCase(Trim(CmbPerfil.SelectedValue)) AndAlso _
                                Login = UCase(Trim(TxtLogin.Text)) AndAlso _
                                Trim(TxtContraseña.Text) = Me.Password AndAlso _
                                CambiaPrecio = Me.ChkCambiaPrecios.GetEstado AndAlso _
                                CambiaLista = Me.ChkCambiaLista.GetEstado AndAlso _
                                ModCosto = Me.ChkModCosto.GetEstado AndAlso _
                                SUCClave = ChkListSucursales.CheckedItems(0).row.itemarray(0) AndAlso _
                                updAccesos = False AndAlso _
                                MaxCredito = Math.Abs(CDbl(TxtMaxCredito.Text)) AndAlso _
                                Estado = ChkEstado.GetEstado) Then

                            CMIClave = CmbTipoComision.SelectedValue
                            PorcMaxDesc = PorDescMax
                            Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                            Me.PERClave = Me.CmbPerfil.SelectedValue
                            Me.Login = UCase(Trim(Me.TxtLogin.Text))
                            If Trim(TxtContraseña.Text) <> Me.Password Then
                                Password = EW.Encrypt.HashPass.CreateHash(TxtContraseña.Text.Trim)
                            End If
                            MaxCredito = Math.Abs(CDbl(TxtMaxCredito.Text))
                            Me.Estado = ChkEstado.GetEstado
                            CambiaPrecio = Me.ChkCambiaPrecios.GetEstado
                            CambiaLista = ChkCambiaLista.GetEstado
                            SUCClave = ChkListSucursales.CheckedItems(0).row.itemarray(0)
                            ModCosto = Me.ChkModCosto.GetEstado

                            
                            ModPOS.Ejecuta("sp_actualiza_usuario", _
                            "@Clave", USRClave, _
                            "@Perfil", PERClave, _
                            "@Nombre", Nombre, _
                            "@CMIClave", CMIClave, _
                            "@PorcMaxDesc", PorcMaxDesc, _
                            "@CambiaPrecio", CambiaPrecio, _
                            "@Login", Login, _
                            "@Pass", Password, _
                            "@Estado", Estado, _
                            "@SUCClave", SUCClave, _
                            "@ModCosto", ModCosto, _
                            "@MaxCredito", MaxCredito, _
                            "@CambiaLista", CambiaLista, _
                            "@Usuario", ModPOS.UsuarioActual)

                            ModPOS.Ejecuta("sp_elimina_acceso", "@USRClave", USRClave)

                            Dim i As Integer
                            For i = 0 To Me.ChkListSucursales.Items.Count - 1
                                ModPOS.Ejecuta("sp_actualiza_acceso", "@USRClave", USRClave, "@SUCClave", dtAcceso.Rows(i).ItemArray(0))
                            Next

                            ModPOS.ActualizaGrid(True, ModPOS.MtoUsuario.GridUsuarios, "sp_muestra_usuarios", Nothing)

                        End If
                        Me.Close()
                End Select
            Else
                MessageBox.Show("Debe tener acceso por lo menos a una Sucursal y marcar una de ellas que elija como predeterminada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If ModPOS.AddAccesos Is Nothing Then
            ModPOS.AddAccesos = New FrmAddAccesos
            With ModPOS.AddAccesos
                .StartPosition = FormStartPosition.CenterScreen
                .USRClave = Me.USRClave
            End With
        End If
        ModPOS.AddAccesos.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddAccesos.Show()
        ModPOS.AddAccesos.BringToFront()
    End Sub

    Private Sub BtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        If Not ChkListSucursales.SelectedItem Is Nothing Then
            Select Case MessageBox.Show("Se eliminara el acceso a la Sucursal :" & Me.ChkListSucursales.SelectedItem(1), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtAcceso.Select("ID Like '" & ChkListSucursales.SelectedItem(0) & "'")
                    dtAcceso.Rows.Remove(foundRows(0))
                    updAccesos = True
                Case DialogResult.No
            End Select
        Else
            MessageBox.Show("Debe seleccionar una Sucursal", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub updateAlmacenes(ByVal SUCClave As String, ByVal Nombre As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtAcceso.Select("ID Like '" & SUCClave & "'")
        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtAcceso.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = SUCClave
            row1.Item("Nombre") = Nombre
            dtAcceso.Rows.Add(row1)
            updAccesos = True
            'agrega la fila completo a la tabla
        End If
    End Sub

    Public Sub actualizaAccesos(ByVal Tipo As Integer)
        Dim dtPredeterminado As DataTable
        'Recupera Accesos a almacen
        If Tipo = 1 Then
            dtAcceso = ModPOS.CrearTabla("Accesos", _
                   "ID", "System.String", _
                   "Nombre", "System.String")

            ChkListSucursales.DataSource = dtAcceso
            ChkListSucursales.DisplayMember = dtAcceso.Columns(1).ColumnName
            ChkListSucursales.ValueMember = dtAcceso.Columns(0).ColumnName

        Else
            dtAcceso = ModPOS.Recupera_Tabla("sp_recupera_accesos", "@USRClave", Me.USRClave)
            If Not dtAcceso Is Nothing Then
                ChkListSucursales.DataSource = dtAcceso
                ChkListSucursales.DisplayMember = dtAcceso.Columns(1).ColumnName
                ChkListSucursales.ValueMember = dtAcceso.Columns(0).ColumnName

                'Recupera Predeterminado
                dtPredeterminado = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", Me.Referencia)

                If Not dtPredeterminado Is Nothing Then
                    If dtPredeterminado.Rows.Count > 0 Then
                        Dim y As Integer
                        Dim fila As System.Data.DataRowView
                        For y = 0 To ChkListSucursales.Items.Count - 1
                            fila = ChkListSucursales.Items.Item(y)
                            If fila.Row.ItemArray(0) = dtPredeterminado.Rows(0)("SUCClave") Then
                                ChkListSucursales.SetItemCheckState(y, CheckState.Checked)
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ChkListSucursales_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ChkListSucursales.ItemCheck
        If bload = True Then
            updAccesos = True
        End If
    End Sub
End Class
