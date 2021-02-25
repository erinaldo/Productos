Public Class FrmCambios
    Inherits System.Windows.Forms.Form


    Public CAJClave As String
    Public PDVClave As String
    Public Generic As Boolean
    Public Ticket As String
    Public Impresora As String
    Public Cajon As Boolean = False
    Public Cajero As String
    Public Referencia As String
    Public SUCClave As String

    Private CARClave, ClaveCaja As String
    Private Cliente As String
    Private ListaPrecio As String
    Private TImpuesto As Integer
    Private PorcImpProducto As Double
    Private PorcImpProductoCambio As Double
    Private NombreCte As String
    Private ALMClave As String
    Private PrecioRecibe As Double
    Private PrecioCambio As Double
    Private bError As Boolean = False
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private Folio As String
    Private TotalRecibido As Double
    Private TotalCambio As Double
    Private Saldo As Double
    Private NoPagar As Boolean
    Private TipoDocumento As Integer

    Private sPROClaveR As String
    Private iTProductoR As Integer
    Private dCantidadR As Double

    Private sPROClaveC As String
    Private iTProductoC As Integer
    Private dCantidadC As Double
    Private Periodo As Integer
    Private Mes As Integer

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblCodigoProd1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo1 As System.Windows.Forms.TextBox
    Friend WithEvents LblClave1 As System.Windows.Forms.Label
    Friend WithEvents LblProducto1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblPrecio1 As System.Windows.Forms.Label
    Friend WithEvents LblDiferencia As System.Windows.Forms.Label
    Friend WithEvents LblMotivo As System.Windows.Forms.Label
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblClaveR As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents LblDiferenciaCambio As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblCantidad2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblCantidad1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblImporte1 As System.Windows.Forms.Label

    Public WriteOnly Property Almacen() As String
        Set(ByVal Value As String)
            ALMClave = Value
        End Set
    End Property

    Public WriteOnly Property ClienteActual() As String
        Set(ByVal Value As String)
            Cliente = Value
        End Set
    End Property

    Public WriteOnly Property NombreClienteActual() As String
        Set(ByVal Value As String)
            NombreCte = Value
        End Set
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
    Friend WithEvents LblCodigoProd2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LblPrecio2 As System.Windows.Forms.Label
    Friend WithEvents LblImporte2 As System.Windows.Forms.Label
    Friend WithEvents LblClaveC As System.Windows.Forms.Label
    Friend WithEvents LblClave2 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblPara As System.Windows.Forms.Label
    Friend WithEvents LblNombreCte As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCambios))
        Me.LblCodigoProd2 = New System.Windows.Forms.Label
        Me.TxtCodigo2 = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblPrecio2 = New System.Windows.Forms.Label
        Me.LblImporte2 = New System.Windows.Forms.Label
        Me.LblClaveC = New System.Windows.Forms.Label
        Me.LblClave2 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblPara = New System.Windows.Forms.Label
        Me.LblNombreCte = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblCantidad2 = New System.Windows.Forms.Label
        Me.LblDiferenciaCambio = New System.Windows.Forms.Label
        Me.LblDiferencia = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblCantidad1 = New System.Windows.Forms.Label
        Me.CmbMotivo = New Selling.StoreCombo
        Me.LblClaveR = New System.Windows.Forms.Label
        Me.LblMotivo = New System.Windows.Forms.Label
        Me.LblCodigoProd1 = New System.Windows.Forms.Label
        Me.TxtCodigo1 = New System.Windows.Forms.TextBox
        Me.LblClave1 = New System.Windows.Forms.Label
        Me.LblProducto1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblPrecio1 = New System.Windows.Forms.Label
        Me.LblImporte1 = New System.Windows.Forms.Label
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblCodigoProd2
        '
        Me.LblCodigoProd2.BackColor = System.Drawing.Color.Transparent
        Me.LblCodigoProd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigoProd2.ForeColor = System.Drawing.Color.White
        Me.LblCodigoProd2.Location = New System.Drawing.Point(10, 19)
        Me.LblCodigoProd2.Name = "LblCodigoProd2"
        Me.LblCodigoProd2.Size = New System.Drawing.Size(233, 18)
        Me.LblCodigoProd2.TabIndex = 42
        Me.LblCodigoProd2.Text = "CÓDIGO DE PRODUCTO:"
        '
        'TxtCodigo2
        '
        Me.TxtCodigo2.Location = New System.Drawing.Point(13, 40)
        Me.TxtCodigo2.Name = "TxtCodigo2"
        Me.TxtCodigo2.Size = New System.Drawing.Size(174, 20)
        Me.TxtCodigo2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.MintCream
        Me.Panel3.Controls.Add(Me.LblPrecio2)
        Me.Panel3.Controls.Add(Me.LblImporte2)
        Me.Panel3.Location = New System.Drawing.Point(13, 174)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 66)
        Me.Panel3.TabIndex = 44
        '
        'LblPrecio2
        '
        Me.LblPrecio2.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecio2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblPrecio2.Location = New System.Drawing.Point(7, 7)
        Me.LblPrecio2.Name = "LblPrecio2"
        Me.LblPrecio2.Size = New System.Drawing.Size(113, 24)
        Me.LblPrecio2.TabIndex = 7
        Me.LblPrecio2.Text = "IMPORTE"
        '
        'LblImporte2
        '
        Me.LblImporte2.BackColor = System.Drawing.Color.Transparent
        Me.LblImporte2.Font = New System.Drawing.Font("Lucida Sans Unicode", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImporte2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblImporte2.Location = New System.Drawing.Point(5, 27)
        Me.LblImporte2.Name = "LblImporte2"
        Me.LblImporte2.Size = New System.Drawing.Size(187, 37)
        Me.LblImporte2.TabIndex = 8
        Me.LblImporte2.Text = "$353.45 M.N"
        Me.LblImporte2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblClaveC
        '
        Me.LblClaveC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClaveC.BackColor = System.Drawing.Color.Transparent
        Me.LblClaveC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClaveC.ForeColor = System.Drawing.Color.White
        Me.LblClaveC.Location = New System.Drawing.Point(82, 69)
        Me.LblClaveC.Name = "LblClaveC"
        Me.LblClaveC.Size = New System.Drawing.Size(227, 28)
        Me.LblClaveC.TabIndex = 59
        '
        'LblClave2
        '
        Me.LblClave2.BackColor = System.Drawing.Color.Transparent
        Me.LblClave2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave2.ForeColor = System.Drawing.Color.White
        Me.LblClave2.Location = New System.Drawing.Point(10, 69)
        Me.LblClave2.Name = "LblClave2"
        Me.LblClave2.Size = New System.Drawing.Size(76, 28)
        Me.LblClave2.TabIndex = 58
        Me.LblClave2.Text = "CLAVE:"
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.White
        Me.LblNombre.Location = New System.Drawing.Point(13, 98)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(298, 56)
        Me.LblNombre.TabIndex = 57
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'LblPara
        '
        Me.LblPara.BackColor = System.Drawing.Color.Transparent
        Me.LblPara.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPara.ForeColor = System.Drawing.Color.White
        Me.LblPara.Location = New System.Drawing.Point(10, 8)
        Me.LblPara.Name = "LblPara"
        Me.LblPara.Size = New System.Drawing.Size(70, 30)
        Me.LblPara.TabIndex = 60
        Me.LblPara.Text = "PARA"
        '
        'LblNombreCte
        '
        Me.LblNombreCte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombreCte.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreCte.ForeColor = System.Drawing.Color.White
        Me.LblNombreCte.Location = New System.Drawing.Point(70, 8)
        Me.LblNombreCte.Name = "LblNombreCte"
        Me.LblNombreCte.Size = New System.Drawing.Size(581, 30)
        Me.LblNombreCte.TabIndex = 61
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.LblDiferenciaCambio)
        Me.GroupBox1.Controls.Add(Me.LblClaveC)
        Me.GroupBox1.Controls.Add(Me.LblDiferencia)
        Me.GroupBox1.Controls.Add(Me.LblCodigoProd2)
        Me.GroupBox1.Controls.Add(Me.TxtCodigo2)
        Me.GroupBox1.Controls.Add(Me.LblClave2)
        Me.GroupBox1.Controls.Add(Me.LblNombre)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Location = New System.Drawing.Point(332, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 302)
        Me.GroupBox1.TabIndex = 63
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cambiar Por:"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(192, 40)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox3.TabIndex = 70
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MintCream
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.LblCantidad2)
        Me.Panel2.Location = New System.Drawing.Point(225, 174)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(81, 67)
        Me.Panel2.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 23)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "CANT."
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gold
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(7, 104)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(166, 59)
        Me.Panel4.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(7, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 37)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "CANTIDAD PRODUCTOS"
        '
        'LblCantidad2
        '
        Me.LblCantidad2.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidad2.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCantidad2.Location = New System.Drawing.Point(9, 32)
        Me.LblCantidad2.Name = "LblCantidad2"
        Me.LblCantidad2.Size = New System.Drawing.Size(60, 29)
        Me.LblCantidad2.TabIndex = 10
        Me.LblCantidad2.Text = "14"
        Me.LblCantidad2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDiferenciaCambio
        '
        Me.LblDiferenciaCambio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDiferenciaCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblDiferenciaCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferenciaCambio.ForeColor = System.Drawing.Color.White
        Me.LblDiferenciaCambio.Location = New System.Drawing.Point(149, 264)
        Me.LblDiferenciaCambio.Name = "LblDiferenciaCambio"
        Me.LblDiferenciaCambio.Size = New System.Drawing.Size(129, 28)
        Me.LblDiferenciaCambio.TabIndex = 60
        Me.LblDiferenciaCambio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDiferencia
        '
        Me.LblDiferencia.BackColor = System.Drawing.Color.Transparent
        Me.LblDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiferencia.ForeColor = System.Drawing.Color.White
        Me.LblDiferencia.Location = New System.Drawing.Point(16, 268)
        Me.LblDiferencia.Name = "LblDiferencia"
        Me.LblDiferencia.Size = New System.Drawing.Size(127, 22)
        Me.LblDiferencia.TabIndex = 59
        Me.LblDiferencia.Text = "DIFERENCIA:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.CmbMotivo)
        Me.GroupBox2.Controls.Add(Me.LblClaveR)
        Me.GroupBox2.Controls.Add(Me.LblMotivo)
        Me.GroupBox2.Controls.Add(Me.LblCodigoProd1)
        Me.GroupBox2.Controls.Add(Me.TxtCodigo1)
        Me.GroupBox2.Controls.Add(Me.LblClave1)
        Me.GroupBox2.Controls.Add(Me.LblProducto1)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(323, 302)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Recibir"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(290, 244)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(192, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.LblCantidad1)
        Me.Panel5.Location = New System.Drawing.Point(228, 174)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(81, 67)
        Me.Panel5.TabIndex = 68
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(12, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 23)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "CANT."
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gold
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Location = New System.Drawing.Point(7, 104)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(166, 59)
        Me.Panel8.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(7, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 37)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "CANTIDAD PRODUCTOS"
        '
        'LblCantidad1
        '
        Me.LblCantidad1.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidad1.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCantidad1.Location = New System.Drawing.Point(9, 32)
        Me.LblCantidad1.Name = "LblCantidad1"
        Me.LblCantidad1.Size = New System.Drawing.Size(60, 29)
        Me.LblCantidad1.TabIndex = 10
        Me.LblCantidad1.Text = "14"
        Me.LblCantidad1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbMotivo
        '
        Me.CmbMotivo.Location = New System.Drawing.Point(94, 269)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(220, 21)
        Me.CmbMotivo.TabIndex = 67
        '
        'LblClaveR
        '
        Me.LblClaveR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClaveR.BackColor = System.Drawing.Color.Transparent
        Me.LblClaveR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClaveR.ForeColor = System.Drawing.Color.White
        Me.LblClaveR.Location = New System.Drawing.Point(90, 69)
        Me.LblClaveR.Name = "LblClaveR"
        Me.LblClaveR.Size = New System.Drawing.Size(219, 28)
        Me.LblClaveR.TabIndex = 60
        '
        'LblMotivo
        '
        Me.LblMotivo.BackColor = System.Drawing.Color.Transparent
        Me.LblMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotivo.ForeColor = System.Drawing.Color.White
        Me.LblMotivo.Location = New System.Drawing.Point(12, 272)
        Me.LblMotivo.Name = "LblMotivo"
        Me.LblMotivo.Size = New System.Drawing.Size(89, 19)
        Me.LblMotivo.TabIndex = 59
        Me.LblMotivo.Text = "MOTIVO:"
        '
        'LblCodigoProd1
        '
        Me.LblCodigoProd1.BackColor = System.Drawing.Color.Transparent
        Me.LblCodigoProd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigoProd1.ForeColor = System.Drawing.Color.White
        Me.LblCodigoProd1.Location = New System.Drawing.Point(10, 19)
        Me.LblCodigoProd1.Name = "LblCodigoProd1"
        Me.LblCodigoProd1.Size = New System.Drawing.Size(238, 18)
        Me.LblCodigoProd1.TabIndex = 42
        Me.LblCodigoProd1.Text = "CÓDIGO DE PRODUCTO:"
        '
        'TxtCodigo1
        '
        Me.TxtCodigo1.Location = New System.Drawing.Point(13, 40)
        Me.TxtCodigo1.Name = "TxtCodigo1"
        Me.TxtCodigo1.Size = New System.Drawing.Size(174, 20)
        Me.TxtCodigo1.TabIndex = 0
        '
        'LblClave1
        '
        Me.LblClave1.BackColor = System.Drawing.Color.Transparent
        Me.LblClave1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave1.ForeColor = System.Drawing.Color.White
        Me.LblClave1.Location = New System.Drawing.Point(10, 70)
        Me.LblClave1.Name = "LblClave1"
        Me.LblClave1.Size = New System.Drawing.Size(91, 28)
        Me.LblClave1.TabIndex = 58
        Me.LblClave1.Text = "CLAVE:"
        '
        'LblProducto1
        '
        Me.LblProducto1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblProducto1.BackColor = System.Drawing.Color.Transparent
        Me.LblProducto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto1.ForeColor = System.Drawing.Color.White
        Me.LblProducto1.Location = New System.Drawing.Point(13, 98)
        Me.LblProducto1.Name = "LblProducto1"
        Me.LblProducto1.Size = New System.Drawing.Size(301, 56)
        Me.LblProducto1.TabIndex = 57
        Me.LblProducto1.Text = "PRODUCTO:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.LblPrecio1)
        Me.Panel1.Controls.Add(Me.LblImporte1)
        Me.Panel1.Location = New System.Drawing.Point(16, 175)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 66)
        Me.Panel1.TabIndex = 44
        '
        'LblPrecio1
        '
        Me.LblPrecio1.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblPrecio1.Location = New System.Drawing.Point(7, 7)
        Me.LblPrecio1.Name = "LblPrecio1"
        Me.LblPrecio1.Size = New System.Drawing.Size(113, 23)
        Me.LblPrecio1.TabIndex = 7
        Me.LblPrecio1.Text = "IMPORTE"
        '
        'LblImporte1
        '
        Me.LblImporte1.BackColor = System.Drawing.Color.Transparent
        Me.LblImporte1.Font = New System.Drawing.Font("Lucida Sans Unicode", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImporte1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblImporte1.Location = New System.Drawing.Point(5, 26)
        Me.LblImporte1.Name = "LblImporte1"
        Me.LblImporte1.Size = New System.Drawing.Size(187, 37)
        Me.LblImporte1.TabIndex = 8
        Me.LblImporte1.Text = "$353.45 M.N"
        Me.LblImporte1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(562, 344)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 66
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(466, 344)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 65
        Me.BtnSalir.Text = "Cancelar"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCambios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 384)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblNombreCte)
        Me.Controls.Add(Me.LblPara)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(662, 413)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(662, 413)
        Me.Name = "FrmCambios"
        Me.Text = "Cambio de Productos"
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Function imprimeTicketCambio(ByVal Motivo As String, ByVal Cajero As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("TICKET DE CAMBIO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJERO: " & Cajero, 0, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderLine("AUTORIZO: " & Autorizo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("MOTIVO: " & Motivo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 3)

        Tickets.AddItemRecibo("RECIBE", LblProducto1.Text, PrecioRecibe)
        Tickets.AddItemRecibo("ENTREGA", LblNombre.Text, PrecioCambio)




        Tickets.AddTotalTicket(PrecioCambio - PrecioRecibe, Imprimir.FontEstilo.Negrita)
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        'valida que se encuentre una forma de pago seleccionada
        If CmbMotivo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If PrecioRecibe = 0 OrElse TxtCodigo1.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If PrecioCambio = 0 OrElse TxtCodigo2.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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

    Private Sub FrmCambio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

  

    Private Sub FrmCambios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        Me.StartPosition = FormStartPosition.CenterScreen

        With Me.CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Devolucion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With

        LblNombreCte.Text = NombreCte

        TipoDocumento = 3
        PrecioCambio = 0
        PrecioRecibe = 0
        LblCantidad1.Text = "0"
        LblCantidad2.Text = "0"
        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioRecibe, 2)), "Currency")
        LblImporte2.Text = Format(CStr(ModPOS.Redondear(PrecioCambio, 2)), "Currency")

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        ClaveCaja = dt.Rows(0)("Clave")
        dt.Dispose()

    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            
            LblDiferenciaCambio.Text = Format(CStr(ModPOS.Redondear(PrecioCambio - PrecioRecibe, 2)), "Currency")

            If PrecioCambio > PrecioRecibe Then
                'Genera Cargo y solicita pago

                Dim dt As DataTable

                If PDVClave <> "" Then
                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 3, "@PDVClave", PDVClave)
                    If dt Is Nothing Then
                        ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 3, "@PDVClave", PDVClave)
                        Folio = 1
                        Periodo = Today.Year
                        Mes = Today.Month
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        ModPOS.Ejecuta("sp_act_folio", "@Tipo", 3, "@PDVClave", PDVClave, "@Incremento", 1)
                        dt.Dispose()
                    End If
                Else
                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                    If dt Is Nothing Then
                        ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                        Folio = 1
                        Mes = Today.Month
                        Periodo = Today.Year
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        ModPOS.Ejecuta("sp_act_folio", "@Tipo", 2, "@PDVClave", CAJClave, "@Incremento", 1)
                        dt.Dispose()
                    End If
                End If


                CARClave = ModPOS.obtenerLlave

                Dim Subtotal As Double = ModPOS.Redondear((PrecioCambio - PrecioRecibe) / (1 + PorcImpProductoCambio), 2)
                Dim ImpuestoTot As Double = ModPOS.Redondear(Subtotal * PorcImpProductoCambio, 2)

                Dim sFolio As String = Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)

                ModPOS.Ejecuta("sp_crea_cargo", _
                "@CARClave", CARClave, _
                "@CTEClave", Cliente, _
                "@Folio", sFolio, _
                "@CAJClave", CAJClave, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@Motivo", 2, _
                "@Descripcion", "CARGO POR CAMBIO, MOTIVO: " & CmbMotivo.SelectedItem(1), _
                "@Subtotal", Subtotal, _
                "@ImpuestoTot", ImpuestoTot, _
                "@Total", Subtotal + ImpuestoTot)

                Do
                    Dim a As New FrmAbono
                    a.TipoDocumento = TipoDocumento
                    a.CAJA = CAJClave
                    a.ClaveCaja = ClaveCaja
                    a.ClaveCte = Cliente
                    a.ClaveDocumento = CARClave
                    a.AperturaCajon = Cajon
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then

                        Dim i As Integer


                        TotalRecibido += a.TotalAbono
                        TotalCambio += a.TotalCambio
                        Saldo -= (a.TotalAbono - a.TotalCambio)

                        Dim dtVenta As DataTable = ModPOS.CrearTabla("Venta", _
                                                                          "ID", "System.String", _
                                                                          "TipoDocumento", "System.Int32", _
                                                                          "Saldo", "System.Double")
                        Dim row1 As DataRow
                        row1 = dtVenta.NewRow()
                        row1.Item("ID") = CARClave
                        row1.Item("TipoDocumento") = TipoDocumento
                        row1.Item("Saldo") = a.SaldoVenta
                        dtVenta.Rows.Add(row1)


                        For i = 0 To a.detallePago.Rows.Count - 1
                            ModPOS.Aplica_Pagos(dtVenta, Cliente, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("Saldo"), CAJClave, 1)
                        Next


                        
                        a.Dispose()
                    Else
                        a.Dispose()
                    End If

                    If Saldo > 0 Then
                        MessageBox.Show("El cargo actual no ha sido totalmente cubierto, su saldo es: " & Format(CStr(ModPOS.Redondear(Saldo, 2)), "Currency"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        NoPagar = False
                    End If

                Loop While Saldo > 0 AndAlso Not NoPagar

                If TotalRecibido > 0 Then
                    Dim msg As New FrmMeMsg
                    msg.TxtTiulo = "Su Cambio es:"
                    msg.TxtMsg = Format(CStr(Math.Round(TotalCambio, 2)), "Currency")
                    msg.TxtMsg2 = Letras(CStr(Math.Round(TotalCambio, 2))).ToUpper
                    msg.ShowDialog()
                    msg.Dispose()
                End If
            ElseIf PrecioCambio < PrecioRecibe Then
                'Retiro de Caja

                Dim Importe As Double = ModPOS.Redondear(PrecioRecibe - PrecioCambio, 2)

                ModPOS.Ejecuta("sp_inserta_retiro", _
                               "@CAJClave", CAJClave, _
                               "@Usuario", ModPOS.UsuarioActual, _
                               "@Importe", Importe, _
                               "@Motivo", "Devolución por Cambio", _
                               "@Tipo", 1, _
                               "@TipoMotivo", 2)

                Dim msg As New FrmMeMsg
                msg.TxtTiulo = "Su Cambio es:"
                msg.TxtMsg = Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency")
                msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(Importe, 2))).ToUpper
                msg.ShowDialog()
                msg.Dispose()

                If Cajon = True Then
                    AbrirCajon(Impresora)
                End If

            End If

                'Genera Movimiento de Entrada por Recibe y Movimiento de Salida por cambio

                Dim dtValor As DataTable
                dtValor = Recupera_Tabla("sp_obtener_valorref", "@Tabla", "Devolucion", "@Campo", "Motivo", "@Valor", CmbMotivo.SelectedValue)

                Dim GeneraSalida As Integer

                If Not dtValor Is Nothing Then
                    If dtValor.Rows.Count > 0 Then
                        GeneraSalida = CInt(dtValor.Rows(0)("Grupo"))
                        dtValor.Dispose()
                    End If
                End If

                'TipoMov 1= Entrada, 2=Salida

                If GeneraSalida = 1 Then
                ModPOS.Ejecuta("sp_genera_movimiento_producto", _
                                "@TipoMov", 1, _
                                "@Motivo", 10, _
                                "@ALMClave", ALMClave, _
                                "@Referencia", "CAMBIO", _
                                "@TProducto", iTProductoR, _
                                "@PROClave", sPROClaveR, _
                                "@Cantidad", dCantidadR, _
                                "@Usuario", ModPOS.UsuarioActual)

                ModPOS.ActualizaExistUbcProducto(1, iTProductoR, sPROClaveR, dCantidadR, ALMClave)
                End If

            ModPOS.Ejecuta("sp_genera_movimiento_producto", _
                            "@TipoMov", 2, _
                            "@Motivo", 10, _
                            "@ALMClave", ALMClave, _
                            "@Referencia", "CAMBIO", _
                            "@TProducto", iTProductoC, _
                            "@PROClave", sPROClaveC, _
                            "@Cantidad", dCantidadC, _
                            "@Usuario", ModPOS.UsuarioActual)


            ModPOS.ActualizaExistUbcProducto(2, iTProductoC, sPROClaveC, dCantidadC, ALMClave)

                Select Case MessageBox.Show("¿Desea Imprimir Ticket de Cambio", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        imprimeTicketCambio(CmbMotivo.SelectedItem(1), Cajero, Impresora, Generic, Ticket)
                End Select


                bError = False
                Me.DialogResult = DialogResult.OK
                Me.Close()

            Else
                bError = True
                Me.DialogResult = DialogResult.Cancel
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtCodigo1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo1.KeyUp
        Select Case e.KeyCode

            Case Is = Keys.Enter
                'Valida que el campo producto no se encuentre vacio
                If Not TxtCodigo1.Text = vbNullString Then
                    'Si es el primer articulo, recupera la lista de precio del cliente actual
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()

                    'Busca y recupera los datos del producto
                    Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", TxtCodigo1.Text.Trim.ToUpper.Replace("'", "''"), "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", Cliente, "@Cantidad", 1, "@Char", cReplace)
                    If Not dtProducto Is Nothing Then

                        sPROClaveR = dtProducto.Rows(0)("PROClave")
                        Dim sClave As String = dtProducto.Rows(0)("Clave")
                        Dim sNombre As String = dtProducto.Rows(0)("Nombre")
                        dCantidadR = dtProducto.Rows(0)("Cantidad")
                        iTProductoR = dtProducto.Rows(0)("TProducto")
                        Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")

                        dtProducto.Dispose()

                        PorcImpProducto = ModPOS.RecuperaImpuesto(SUCClave, sPROClaveR, TImpuesto)

                        PrecioRecibe = (dPrecioBruto * (1 + PorcImpProducto)) * dCantidadR

                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioRecibe, 2)), "Currency")
                        LblClaveR.Text = sClave
                        LblProducto1.Text = sNombre
                        LblCantidad1.Text = CStr(dCantidadR)

                    Else
                        TxtCodigo1.Text = ""
                        PrecioRecibe = 0
                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioRecibe, 2)), "Currency")
                        LblClaveR.Text = ""
                        LblProducto1.Text = ""
                        LblCantidad1.Text = "0"
                        Beep()
                        MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Case Is = Keys.Right
                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                ListaPrecio = dtCliente.Rows(0)("PREClave")
                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()

                'Busca y recupera los datos del producto
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_producto_vta"
                a.bReplace = True
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtCodigo1.Text.Trim.ToUpper
                a.AlmRequerido = True
                a.ALMClave = ALMClave
                a.TipoRequerido = False
                a.Tipo = TImpuesto
                a.CompaniaRequerido = True
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then

                    TxtCodigo1.Text = a.valor

                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()

                    'Busca y recupera los datos del producto

                    Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", TxtCodigo1.Text.Trim.ToUpper.Replace("'", "''"), "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", Cliente, "@Cantidad", 1, "@Char", cReplace)

                    If Not dtProducto Is Nothing Then

                        sPROClaveR = dtProducto.Rows(0)("PROClave")
                        Dim sClave As String = dtProducto.Rows(0)("Clave")
                        Dim sNombre As String = dtProducto.Rows(0)("Nombre")
                        dCantidadR = dtProducto.Rows(0)("Cantidad")
                        iTProductoR = dtProducto.Rows(0)("TProducto")
                        Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")

                        dtProducto.Dispose()

                        PorcImpProducto = ModPOS.RecuperaImpuesto(SUCClave, sPROClaveR, TImpuesto)

                        PrecioRecibe = (dPrecioBruto * (1 + PorcImpProducto)) * dCantidadR

                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioRecibe, 2)), "Currency")
                        LblClaveR.Text = sClave
                        LblProducto1.Text = sNombre
                        LblCantidad1.Text = CStr(dCantidadR)

                    Else
                        TxtCodigo1.Text = ""
                        PrecioRecibe = 0
                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioRecibe, 2)), "Currency")
                        LblClaveR.Text = ""
                        LblProducto1.Text = ""
                        LblCantidad1.Text = "0"
                        Beep()
                        MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
                a.Dispose()

        End Select
    End Sub

    Private Sub TxtCodigo2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigo2.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If Not TxtCodigo2.Text = vbNullString Then
                    'Si es el primer articulo, recupera la lista de precio del cliente actual
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()

                    'Busca y recupera los datos del producto
                    Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", TxtCodigo2.Text.Trim.ToUpper.Replace("'", "''"), "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", Cliente, "@Cantidad", 1, "@Char", cReplace)
                    If Not dtProducto Is Nothing Then

                        sPROClaveC = dtProducto.Rows(0)("PROClave")
                        Dim sClave As String = dtProducto.Rows(0)("Clave")
                        Dim sNombre As String = dtProducto.Rows(0)("Nombre")
                        dCantidadC = dtProducto.Rows(0)("Cantidad")
                        iTProductoC = dtProducto.Rows(0)("TProducto")
                        Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")

                        dtProducto.Dispose()

                        PorcImpProductoCambio = ModPOS.RecuperaImpuesto(SUCClave, sPROClaveC, TImpuesto)

                        PrecioCambio = (dPrecioBruto * (1 + PorcImpProductoCambio)) * dCantidadC

                        LblImporte2.Text = Format(CStr(ModPOS.Redondear(PrecioCambio, 2)), "Currency")
                        LblClaveC.Text = sClave
                        LblNombre.Text = sNombre
                        LblCantidad2.Text = CStr(dCantidadC)

                    Else
                        TxtCodigo2.Text = ""
                        PrecioCambio = 0
                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioCambio, 2)), "Currency")
                        LblClaveC.Text = ""
                        LblNombre.Text = ""
                        LblCantidad2.Text = "0"
                        Beep()
                        MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Case Is = Keys.Right

                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                ListaPrecio = dtCliente.Rows(0)("PREClave")
                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()

                'Busca y recupera los datos del producto
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_producto_vta"
                a.bReplace = True
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtCodigo2.Text.Trim.ToUpper
                a.AlmRequerido = True
                a.ALMClave = ALMClave
                a.TipoRequerido = False
                a.Tipo = TImpuesto
                a.CompaniaRequerido = True
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then

                    TxtCodigo2.Text = a.valor

                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()

                    'Busca y recupera los datos del producto

                    Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", TxtCodigo2.Text.Trim.ToUpper.Replace("'", "''"), "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", Cliente, "@Cantidad", 1, "@Char", cReplace)

                    If Not dtProducto Is Nothing Then

                        sPROClaveC = dtProducto.Rows(0)("PROClave")
                        Dim sClave As String = dtProducto.Rows(0)("Clave")
                        Dim sNombre As String = dtProducto.Rows(0)("Nombre")
                        dCantidadC = dtProducto.Rows(0)("Cantidad")
                        iTProductoC = dtProducto.Rows(0)("TProducto")
                        Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")

                        dtProducto.Dispose()

                        PorcImpProductoCambio = ModPOS.RecuperaImpuesto(SUCClave, sPROClaveC, TImpuesto)

                        PrecioCambio = (dPrecioBruto * (1 + PorcImpProductoCambio)) * dCantidadC

                        LblImporte2.Text = Format(CStr(ModPOS.Redondear(PrecioCambio, 2)), "Currency")
                        LblClaveC.Text = sClave
                        LblNombre.Text = sNombre
                        LblCantidad2.Text = CStr(dCantidadC)

                    Else
                        TxtCodigo2.Text = ""
                        PrecioCambio = 0
                        LblImporte1.Text = Format(CStr(ModPOS.Redondear(PrecioCambio, 2)), "Currency")
                        LblClaveC.Text = ""
                        LblNombre.Text = ""
                        LblCantidad2.Text = "0"
                        Beep()
                        MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If


                End If
                a.Dispose()

        End Select

    End Sub
End Class
