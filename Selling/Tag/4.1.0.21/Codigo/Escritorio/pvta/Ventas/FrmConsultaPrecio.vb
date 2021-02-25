Public Class FrmConsultaPrecio
    Inherits System.Windows.Forms.Form

    Private url_imagen As String
    Public SUCClave As String
    Private Cliente As String

    Private ListaPrecio As String
    Private TImpuesto As Integer

    Private PROClave As String
    Private Cantidad As Double
    Private Tipo As Integer

    Private ALMClave As String
    Private SourceToImage As Bitmap
    Private Puntos, Ahorro, PrecioNeto, Normal As Double

    Private ultimaX, indiceSelected As Integer
    Private indice As Integer = 0
    Private iAvanceMenu As Integer
    Private PictureSelected As String
    Public dPuntos, dAhorro, dPrecioNeto, dNormal As Double
    Public arrayFoto(0) As Foto

    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents BtnBusqueda As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtMostrador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents PicProducto As System.Windows.Forms.PictureBox



    Public WriteOnly Property Producto() As String
        Set(ByVal Value As String)
            PROClave = Value
        End Set
    End Property


    Public WriteOnly Property Cant() As Double
        Set(ByVal Value As Double)
            Cantidad = Value
        End Set
    End Property

    Public WriteOnly Property TipoDisplay() As Integer
        Set(ByVal Value As Integer)
            Tipo = Value
        End Set
    End Property


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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblAhorro As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblNormal As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblCantidad As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaPrecio))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblNormal = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblAhorro = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.PicProducto = New System.Windows.Forms.PictureBox()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnIzqMenu = New Janus.Windows.EditControls.UIButton()
        Me.btnDerMenu = New Janus.Windows.EditControls.UIButton()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.BtnBusqueda = New Janus.Windows.EditControls.UIButton()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtMostrador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(7, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 22)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "CÓDIGO DE PRODUCTO:"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(175, 75)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(173, 22)
        Me.TxtProducto.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.MintCream
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.LblNormal)
        Me.Panel6.Location = New System.Drawing.Point(509, 189)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(215, 44)
        Me.Panel6.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "NORMAL"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gold
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Location = New System.Drawing.Point(7, 104)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(166, 59)
        Me.Panel7.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(7, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 37)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "CANTIDAD PRODUCTOS"
        '
        'LblNormal
        '
        Me.LblNormal.BackColor = System.Drawing.Color.Transparent
        Me.LblNormal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNormal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblNormal.Location = New System.Drawing.Point(92, 7)
        Me.LblNormal.Name = "LblNormal"
        Me.LblNormal.Size = New System.Drawing.Size(115, 30)
        Me.LblNormal.TabIndex = 10
        Me.LblNormal.Text = "14"
        Me.LblNormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.MintCream
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Location = New System.Drawing.Point(509, 297)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(216, 44)
        Me.Panel4.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(7, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 30)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "AHORRO"
        '
        'LblAhorro
        '
        Me.LblAhorro.BackColor = System.Drawing.Color.Transparent
        Me.LblAhorro.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAhorro.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblAhorro.Location = New System.Drawing.Point(95, 7)
        Me.LblAhorro.Name = "LblAhorro"
        Me.LblAhorro.Size = New System.Drawing.Size(113, 30)
        Me.LblAhorro.TabIndex = 9
        Me.LblAhorro.Text = "$353.45"
        Me.LblAhorro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.MintCream
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Location = New System.Drawing.Point(509, 350)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(216, 77)
        Me.Panel3.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(7, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "PRECIO NETO"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotal.Location = New System.Drawing.Point(22, 29)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(186, 37)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblClave.Location = New System.Drawing.Point(90, 107)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(280, 25)
        Me.LblClave.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(7, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "CLAVE:"
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblNombre.Location = New System.Drawing.Point(7, 140)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(736, 45)
        Me.LblNombre.TabIndex = 57
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.LblCantidad)
        Me.Panel5.Location = New System.Drawing.Point(509, 243)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(216, 44)
        Me.Panel5.TabIndex = 62
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(7, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 22)
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
        'LblCantidad
        '
        Me.LblCantidad.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCantidad.Location = New System.Drawing.Point(148, 7)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(60, 30)
        Me.LblCantidad.TabIndex = 10
        Me.LblCantidad.Text = "14"
        Me.LblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PicProducto
        '
        Me.PicProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicProducto.Location = New System.Drawing.Point(11, 188)
        Me.PicProducto.Name = "PicProducto"
        Me.PicProducto.Size = New System.Drawing.Size(470, 355)
        Me.PicProducto.TabIndex = 64
        Me.PicProducto.TabStop = False
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(635, 600)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 41)
        Me.BtnOK.TabIndex = 65
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnIzqMenu)
        Me.GroupBox1.Controls.Add(Me.btnDerMenu)
        Me.GroupBox1.Controls.Add(Me.pnlMenu)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 549)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 92)
        Me.GroupBox1.TabIndex = 142
        Me.GroupBox1.TabStop = False
        '
        'btnIzqMenu
        '
        Me.btnIzqMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqMenu.Icon = CType(resources.GetObject("btnIzqMenu.Icon"), System.Drawing.Icon)
        Me.btnIzqMenu.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqMenu.Location = New System.Drawing.Point(3, 11)
        Me.btnIzqMenu.Name = "btnIzqMenu"
        Me.btnIzqMenu.Size = New System.Drawing.Size(50, 75)
        Me.btnIzqMenu.TabIndex = 61
        Me.btnIzqMenu.ToolTipText = "Anterior"
        Me.btnIzqMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerMenu
        '
        Me.btnDerMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerMenu.Icon = CType(resources.GetObject("btnDerMenu.Icon"), System.Drawing.Icon)
        Me.btnDerMenu.Location = New System.Drawing.Point(416, 11)
        Me.btnDerMenu.Name = "btnDerMenu"
        Me.btnDerMenu.Size = New System.Drawing.Size(50, 75)
        Me.btnDerMenu.TabIndex = 60
        Me.btnDerMenu.ToolTipText = "Siguiente"
        Me.btnDerMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.AutoScroll = True
        Me.pnlMenu.Location = New System.Drawing.Point(56, 11)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(357, 77)
        Me.pnlMenu.TabIndex = 0
        '
        'BtnBusqueda
        '
        Me.BtnBusqueda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBusqueda.Icon = CType(resources.GetObject("BtnBusqueda.Icon"), System.Drawing.Icon)
        Me.BtnBusqueda.Location = New System.Drawing.Point(354, 70)
        Me.BtnBusqueda.Name = "BtnBusqueda"
        Me.BtnBusqueda.Size = New System.Drawing.Size(62, 30)
        Me.BtnBusqueda.TabIndex = 143
        Me.BtnBusqueda.ToolTipText = "Busqueda de Productos"
        Me.BtnBusqueda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblCliente
        '
        Me.LblCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCliente.Location = New System.Drawing.Point(264, 20)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(461, 19)
        Me.LblCliente.TabIndex = 180
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(219, 12)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaCte.TabIndex = 178
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtMostrador
        '
        Me.TxtMostrador.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMostrador.Location = New System.Drawing.Point(93, 17)
        Me.TxtMostrador.Name = "TxtMostrador"
        Me.TxtMostrador.Size = New System.Drawing.Size(120, 22)
        Me.TxtMostrador.TabIndex = 179
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 22)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "AGENTE:"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 22)
        Me.Label4.TabIndex = 182
        Me.Label4.Text = "CLIENTE:"
        '
        'LblUsuario
        '
        Me.LblUsuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblUsuario.Location = New System.Drawing.Point(90, 47)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(626, 19)
        Me.LblUsuario.TabIndex = 183
        '
        'FrmConsultaPrecio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(753, 653)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.TxtMostrador)
        Me.Controls.Add(Me.BtnBusqueda)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.PicProducto)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.Label12)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsultaPrecio"
        Me.Text = "Consulta de Precio"
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picFoto As Foto
        picFoto = sender
        PictureSelected = picFoto.IMGClave
        indiceSelected = picFoto.indice
        PicProducto.Image = picFoto.Image
    End Sub

    Private Sub RecuperaImagenProducto(ByVal sPROClave As String)
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

        myCommand = New System.Data.SqlClient.SqlCommand("sp_recupera_imagenes", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@PROClave", SqlDbType.VarChar).Value = sPROClave
        myCommand.CommandTimeout = ModPOS.myTimeOut
        '  myCommand.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = sperfil

        dr = myCommand.ExecuteReader()

        Dim y As Integer
        ultimaX = 2
        y = 2


        While dr.Read
            Dim picFoto As Foto
            picFoto = New Foto(dr("IMGClave"))

            arrayFoto(indice) = picFoto

            arrayFoto(indice).Nuevo = False
            arrayFoto(indice).SizeMode = PictureBoxSizeMode.StretchImage
            arrayFoto(indice).Width = 90
            arrayFoto(indice).Height = 60
            arrayFoto(indice).Location = New Point(ultimaX, y)
            arrayFoto(indice).indice = indice

            If Not dr("Imagen") Is System.DBNull.Value Then
                arrayFoto(indice).Image = ModPOS.RecuperaImagen(url_imagen & CStr(dr("Imagen")))
                arrayFoto(indice).NombreImagen = CStr(dr("Imagen"))
            End If

            ultimaX += 95
            pnlMenu.Controls.Add(arrayFoto(indice))
            AddHandler arrayFoto(indice).Click, AddressOf Menu_Click
            indice += 1
            ReDim Preserve arrayFoto(indice)

        End While

        myCommand.Dispose()
        dr.Close()

        pnlMenu.HorizontalScroll.Enabled = False
        pnlMenu.HorizontalScroll.Visible = False
        iAvanceMenu = pnlMenu.HorizontalScroll.LargeChange

        If arrayFoto(0) IsNot Nothing Then
            PictureSelected = arrayFoto(0).IMGClave
            indiceSelected = arrayFoto(0).indice
            PicProducto.Image = arrayFoto(0).Image
        End If

    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, TxtProducto.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.Close()
            Case Is = Keys.Right

                'Busca y recupera los datos del producto
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_producto"
                a.bReplace = True
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtProducto.Text.Trim.ToUpper
                a.AlmRequerido = True
                a.ALMClave = ALMClave
                a.CompaniaRequerido = True
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    recuperaProducto(2, a.valor, 1)
                End If
                a.Dispose()

        End Select
    End Sub

    Private Sub recuperaProducto(ByVal TipoBusqueda As Integer, ByVal Texto As String, ByVal Cantidad As Double)

        'Si es el primer articulo, recupera la lista de precio del cliente actual
        Dim dtCliente As DataTable
        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", Cliente)
        ListaPrecio = dtCliente.Rows(0)("PREClave")
        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
        dtCliente.Dispose()

        'Busca y recupera los datos del producto
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "CTEClave", Cliente, "@SUCClave", SUCClave, "@Tipo", TipoBusqueda, "@Busca", Texto.Trim.ToUpper.Replace("'", "''"), "@PREClave", ListaPrecio, "@Cantidad", Cantidad, "@Char", cReplace)
        If Not dtProducto Is Nothing Then

            PROClave = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre")
            Dim dCantidad As Double = dtProducto.Rows(0)("Cantidad")
            Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")
            Dim dDescPorc As Double = dtProducto.Rows(0)("DescPorc")

            Dim dCosto As Double = dtProducto.Rows(0)("Costo")
            Dim dDescGeneralPor As Double = dtProducto.Rows(0)("DescGeneral")


            Dim dGeneralNeto As Double = TruncateToDecimal(dtProducto.Rows(0)("PrecioNeto"), 2)


            Dim UnidadesKilo As Double = 0
            Dim dDescGeneralImp As Double = dPrecioBruto * (dDescGeneralPor / 100)
            Dim dDescuentoImp As Double = (dPrecioBruto - dDescGeneralImp) * dDescPorc
            PrecioNeto = dGeneralNeto


            dtProducto.Dispose()

            Dim PorcImpProducto As Double = ModPOS.RecuperaImpuesto(SUCClave, PROClave, TImpuesto)

            Normal = dPrecioBruto * (1 + PorcImpProducto)
            Ahorro = ((dDescuentoImp) * dCantidad)

            LblNormal.Text = Format(CStr(ModPOS.Redondear(Normal, 2)), "Currency")
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(Ahorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(PrecioNeto, 2)), "Currency")
            LblClave.Text = sClave
            LblNombre.Text = sNombre
            LblCantidad.Text = CStr(dCantidad)

            RecuperaImagenProducto(PROClave)

        Else
            Beep()
            MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TxtProducto.Text = ""

    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Valida que el campo producto no se encuentre vacio
            If Not TxtProducto.Text = vbNullString Then
                recuperaProducto(1, TxtProducto.Text, 1)
            End If
        End If
    End Sub

    Private Sub FrmConsultaPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer
        Dim dtParam As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                If CStr(dtParam.Rows(i)("PARClave")) = "Imagenes" Then
                    url_imagen = CStr(dtParam.Rows(i)("Valor"))
                    If Not url_imagen.Substring(url_imagen.Length - 1, 1) = "\" Then
                        url_imagen &= "\"
                    End If
                    Exit For
                End If
            Next
        End With
        dtParam.Dispose()


        Me.StartPosition = FormStartPosition.CenterScreen

     
        If Tipo > 3 Then
            recuperaProducto(3, PROClave, Cantidad)
            Puntos = dPuntos
            Ahorro = dAhorro
            PrecioNeto = dPrecioNeto
            Normal = dNormal
        Else
            Normal = 0
            Puntos = 0
            Ahorro = 0
            PrecioNeto = 0
            Cantidad = 0
        End If

        LblNormal.Text = Format(CStr(ModPOS.Redondear(Normal, 2)), "Currency")
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(Ahorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(PrecioNeto, 2)), "Currency")
        LblCantidad.Text = Cantidad

        If Cliente <> "" Then
            cambiaCliente(Cliente)
        End If

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub

    Private Sub btnIzqMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzqMenu.Click
        If pnlMenu.HorizontalScroll.Value > 0 AndAlso (pnlMenu.HorizontalScroll.Value - iAvanceMenu) >= pnlMenu.HorizontalScroll.Minimum Then
            pnlMenu.HorizontalScroll.Value -= iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnDerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerMenu.Click
        If (pnlMenu.HorizontalScroll.Value + iAvanceMenu) <= pnlMenu.HorizontalScroll.Maximum Then
            pnlMenu.HorizontalScroll.Value += iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Maximum
        End If
    End Sub



    Private Sub BtnBusqueda_Click(sender As Object, e As EventArgs) Handles BtnBusqueda.Click
        'Busca y recupera los datos del producto
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_producto"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.BusquedaInicial = True
        a.Busqueda = TxtProducto.Text.Trim.ToUpper
        a.AlmRequerido = True
        a.ALMClave = ALMClave
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            recuperaProducto(2, a.valor, 1)
        End If
        a.Dispose()
    End Sub

    Private Function cambiaCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al intentar cargar información de domicilios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Cliente = sCTEClave
        TxtMostrador.Text = dt.Rows(0)("Clave")
        LblCliente.Text = dt.Rows(0)("RazonSocial")


            Dim USRClave As String = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
            If USRClave <> "" Then
                Dim dtUsr As DataTable
                dtUsr = ModPOS.Recupera_Tabla("sp_recupera_UsuarioActual", "@Usuario", USRClave)
                If dtUsr.Rows.Count > 0 Then
                    LblUsuario.Text = dtUsr.Rows(0)("Nombre")
            End If
                dtUsr.Dispose()
            End If
      
        dt.Dispose()

        TxtProducto.Focus()

        Return True
    End Function

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
                cambiaCliente(a.valor)

                If PROClave <> "" Then
                    recuperaProducto(2, PROClave, 1)
                End If
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtMostrador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMostrador.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtMostrador.Text = vbNullString Then
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtMostrador.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    cambiaCliente(dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                Else
                    MessageBox.Show("No se encontro registro que coincida con la clave proporcionada", "Información", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub
End Class
