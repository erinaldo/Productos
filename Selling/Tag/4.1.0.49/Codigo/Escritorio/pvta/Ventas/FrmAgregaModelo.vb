

Public Class FrmAgregaModelo
    Inherits System.Windows.Forms.Form

    Private arrayFoto(0) As Foto

    Private iAvanceMenu As Integer
    Private indice As Integer = 0
    Private ultimaX, indiceSelected As Integer
    Private PictureSelected As String
    Private dPrecioNetoUni As Decimal

    Public url_imagen As String
    Public VENClave As String
    Public CTEClave As String
    Public GrupoMaterial As Integer
    Public Sector As Integer
    Public PROClave As String

    Public dBase As Decimal
    Public Clave As String
    Public Modelo As String
    Public Nombre As String
    Public Talla As String
    Public Color As String
    Public KgLt As Decimal = 0
    Public UnidadesKilo As Decimal = 0
    Public Peso As Decimal = 0
  
    Public dPrecioUnitario As Decimal
    Public dCantidad As Decimal
    Public DescGeneral As Decimal
    Public DescGeneralImporte As Decimal = 0.0
    Public dVolumen As Decimal
    Public dVolumenImp As Decimal
    Public PorcDesc As Decimal
    Public DescImp As Decimal
    Public FactorImpuesto As Decimal
    Public dImpuestoimp As Decimal
    Public ImporteNeto As Double

    Public sTipoDesc As String
   
    Private NumRedondeo As Integer = 6
    Private dAutorizado As Decimal = 0.0
    Private bError As Boolean = False
    Private StrucVol As DescVol

    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents PicProducto As System.Windows.Forms.PictureBox
    Friend WithEvents btnMas As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnMenos As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtPrecioNetoUnitario As Janus.Windows.GridEX.EditControls.NumericEditBox


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
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents LblModelo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAgregaModelo))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TxtPrecioNetoUnitario = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.LblModelo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnIzqMenu = New Janus.Windows.EditControls.UIButton()
        Me.btnDerMenu = New Janus.Windows.EditControls.UIButton()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.PicProducto = New System.Windows.Forms.PictureBox()
        Me.btnMas = New Janus.Windows.EditControls.UIButton()
        Me.btnMenos = New Janus.Windows.EditControls.UIButton()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Controls.Add(Me.TxtPrecioNetoUnitario)
        Me.Panel6.Controls.Add(Me.lblNormal)
        Me.Panel6.Location = New System.Drawing.Point(573, 154)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(207, 73)
        Me.Panel6.TabIndex = 0
        '
        'TxtPrecioNetoUnitario
        '
        Me.TxtPrecioNetoUnitario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPrecioNetoUnitario.DecimalDigits = 2
        Me.TxtPrecioNetoUnitario.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecioNetoUnitario.Location = New System.Drawing.Point(20, 35)
        Me.TxtPrecioNetoUnitario.Name = "TxtPrecioNetoUnitario"
        Me.TxtPrecioNetoUnitario.ReadOnly = True
        Me.TxtPrecioNetoUnitario.Size = New System.Drawing.Size(168, 29)
        Me.TxtPrecioNetoUnitario.TabIndex = 12
        Me.TxtPrecioNetoUnitario.Text = "0.00"
        Me.TxtPrecioNetoUnitario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPrecioNetoUnitario.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'lblNormal
        '
        Me.lblNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNormal.BackColor = System.Drawing.Color.Transparent
        Me.lblNormal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.ForeColor = System.Drawing.Color.Black
        Me.lblNormal.Location = New System.Drawing.Point(20, 4)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(127, 28)
        Me.lblNormal.TabIndex = 11
        Me.lblNormal.Text = "PRECIO NETO"
        '
        'LblModelo
        '
        Me.LblModelo.BackColor = System.Drawing.Color.Transparent
        Me.LblModelo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModelo.ForeColor = System.Drawing.Color.Black
        Me.LblModelo.Location = New System.Drawing.Point(111, 9)
        Me.LblModelo.Name = "LblModelo"
        Me.LblModelo.Size = New System.Drawing.Size(133, 26)
        Me.LblModelo.TabIndex = 59
        Me.LblModelo.Text = "MODELO"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 26)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "MODELO:"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Controls.Add(Me.TxtCantidad)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Location = New System.Drawing.Point(630, 65)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(94, 75)
        Me.Panel5.TabIndex = 1
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 32)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(79, 29)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "1"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "CANTIDAD"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblTotal)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(573, 240)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(207, 220)
        Me.Panel4.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(7, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(6, 175)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(186, 37)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.Location = New System.Drawing.Point(676, 475)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnGuardar.Office2007CustomColor = System.Drawing.Color.ForestGreen
        Me.BtnGuardar.Size = New System.Drawing.Size(104, 74)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(580, 475)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCancelar.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 74)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblNombre
        '
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.Black
        Me.LblNombre.Location = New System.Drawing.Point(12, 35)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(551, 26)
        Me.LblNombre.TabIndex = 70
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'lblTalla
        '
        Me.lblTalla.BackColor = System.Drawing.Color.Transparent
        Me.lblTalla.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalla.ForeColor = System.Drawing.Color.Black
        Me.lblTalla.Location = New System.Drawing.Point(307, 9)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(89, 26)
        Me.lblTalla.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(235, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 26)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "TALLA:"
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Transparent
        Me.lblColor.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.ForeColor = System.Drawing.Color.Black
        Me.lblColor.Location = New System.Drawing.Point(489, 9)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(291, 26)
        Me.lblColor.TabIndex = 74
        Me.lblColor.Text = "COLOR"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(402, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 26)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "COLOR:"
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 464)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 92)
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
        Me.btnIzqMenu.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
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
        Me.btnDerMenu.Location = New System.Drawing.Point(506, 11)
        Me.btnDerMenu.Name = "btnDerMenu"
        Me.btnDerMenu.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
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
        Me.pnlMenu.Size = New System.Drawing.Size(447, 77)
        Me.pnlMenu.TabIndex = 0
        '
        'PicProducto
        '
        Me.PicProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicProducto.Location = New System.Drawing.Point(7, 64)
        Me.PicProducto.Name = "PicProducto"
        Me.PicProducto.Size = New System.Drawing.Size(560, 396)
        Me.PicProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProducto.TabIndex = 143
        Me.PicProducto.TabStop = False
        '
        'btnMas
        '
        Me.btnMas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMas.Icon = CType(resources.GetObject("btnMas.Icon"), System.Drawing.Icon)
        Me.btnMas.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnMas.Location = New System.Drawing.Point(730, 65)
        Me.btnMas.Name = "btnMas"
        Me.btnMas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnMas.Size = New System.Drawing.Size(50, 75)
        Me.btnMas.TabIndex = 144
        Me.btnMas.ToolTipText = "Siguiente"
        Me.btnMas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnMenos
        '
        Me.btnMenos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenos.Icon = CType(resources.GetObject("btnMenos.Icon"), System.Drawing.Icon)
        Me.btnMenos.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnMenos.Location = New System.Drawing.Point(573, 66)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnMenos.Size = New System.Drawing.Size(50, 75)
        Me.btnMenos.TabIndex = 145
        Me.btnMenos.ToolTipText = "Siguiente"
        Me.btnMenos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAgregaModelo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.btnMenos)
        Me.Controls.Add(Me.btnMas)
        Me.Controls.Add(Me.PicProducto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTalla)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.LblModelo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 371)
        Me.Name = "FrmAgregaModelo"
        Me.Text = "Agregar Producto"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picFoto As Foto
        picFoto = sender
        PictureSelected = picFoto.IMGClave
        indiceSelected = picFoto.indice
        PicProducto.Image = picFoto.Image

        PicProducto.SizeMode = PictureBoxSizeMode.Zoom
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

            arrayFoto(indice) = New Foto(dr("IMGClave"))

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

    Private Sub RecalculaPrecio(ByVal obj As String)
        Dim bActualiza As Boolean = False

        Select Case obj
            Case Is = "Cantidad"
                If dCantidad <> CDec(TxtCantidad.Text) Then

                    If CDbl(TxtCantidad.Text) <= 0 Then
                        TxtCantidad.Text = "1"
                    End If

                    dCantidad = CDec(TxtCantidad.Text)

                    If KgLt = 1 Then
                        If Peso > 0 Then
                            UnidadesKilo = dCantidad / Peso
                        Else
                            UnidadesKilo = 1

                        End If

                    Else
                        UnidadesKilo = 0

                    End If

                    dBase = Math.Round(dPrecioUnitario * dCantidad, 2)


                    DescGeneralImporte = Math.Round(dBase * (DescGeneral / 100), 2)

                    StrucVol = obtenerDescuentoVolumen(CTEClave, GrupoMaterial, Sector, VENClave, PROClave, dBase - DescGeneralImporte)
                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - DescGeneralImporte) * (dVolumen / 100), 2)
                    Else
                        dVolumenImp = 0
                    End If

                    DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                    dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                    ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp
                    bActualiza = True
                End If

        End Select

        If bActualiza = True Then
            dPrecioNetoUni = ModPOS.Redondear(ImporteNeto / dCantidad, 6)

            TxtPrecioNetoUnitario.Text = dPrecioNetoUni
            LblTotal.Text = Format(CStr(ImporteNeto), "Currency")


        End If
    End Sub

    Private Sub TxtCantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Click
        Dim a As New FrmTecladoNum
        a.Text = "Cantidad"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtCantidad.Text = a.Cantidad
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        bError = False
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmAgregaModelo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        Else
            PicProducto.Image = Nothing
        End If
    End Sub

    Private Sub FrmAgregaModelo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LblModelo.Text = Modelo
        LblNombre.Text = Nombre
        lblTalla.Text = Talla
        lblColor.Text = Color

        dPrecioNetoUni = ImporteNeto / dCantidad

        TxtPrecioNetoUnitario.Text = dPrecioNetoUni
        TxtCantidad.Text = dCantidad
        LblTotal.Text = Format(CStr(ImporteNeto), "Currency")

        RecuperaImagenProducto(PROClave)

    End Sub

    Private Sub btnIzqMenu_Click(sender As Object, e As EventArgs) Handles btnIzqMenu.Click
        If pnlMenu.HorizontalScroll.Value > 0 AndAlso (pnlMenu.HorizontalScroll.Value - iAvanceMenu) >= pnlMenu.HorizontalScroll.Minimum Then
            pnlMenu.HorizontalScroll.Value -= iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnDerMenu_Click(sender As Object, e As EventArgs) Handles btnDerMenu.Click
        If (pnlMenu.HorizontalScroll.Value + iAvanceMenu) <= pnlMenu.HorizontalScroll.Maximum Then
            pnlMenu.HorizontalScroll.Value += iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Maximum
        End If
    End Sub

    Private Sub FrmAgregaModelo_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PicProducto.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        If CInt(TxtCantidad.Text) > 1 Then
            TxtCantidad.Text = CInt(TxtCantidad.Text) - 1
            RecalculaPrecio("Cantidad")
        End If
    End Sub

    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        TxtCantidad.Text = CInt(TxtCantidad.Text) + 1
        RecalculaPrecio("Cantidad")
    End Sub

   
    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        RecalculaPrecio("Cantidad")
    End Sub

  
End Class
