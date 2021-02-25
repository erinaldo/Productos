

Public Class FrmAgregaPreventa
    Inherits System.Windows.Forms.Form

    Public Padre As String = ""
    Public numMostrador As Integer
    Public VENClave As String
    Public TipoCambio As Double
    Public CTEClave As String
    Public SUCClave As String
    Public TImpuesto As Integer
    Public dtPreventa As DataTable

    Private arrayFoto(0) As Foto
    Private iAvanceMenu As Integer
    Private indice As Integer = 0
    Private ultimaX, indiceSelected As Integer
    Private PictureSelected As String
    Private dPrecioNetoUni As Decimal

    Private GrupoMaterial As Integer
    Private Sector As Integer
    Public url_imagen As String

    Private PROClave As String
    Private TProducto As Integer
    Private dBase As Decimal
    Private Clave As String
    Private Modelo As String
    Private Nombre As String
    Private Talla As String
    Private Color As String
    Private KgLt As Decimal = 0
    Private UnidadesKilo As Decimal = 0
    Private Peso As Decimal = 0

    Private dPrecioUnitario As Decimal
    Private dCantidad As Decimal
    Private DescGeneral As Decimal
    Private DescGeneralImporte As Decimal = 0.0
    Private dVolumen As Decimal
    Private dVolumenImp As Decimal
    Private PorcDesc As Decimal
    Private DescImp As Decimal
    Private FactorImpuesto As Decimal
    Private dImpuestoimp As Decimal
    Private ImporteNeto As Double

    Private sTipoDesc As String

    Private NumRedondeo As Integer = 6
    Private dAutorizado As Decimal = 0.0
    Private bError As Boolean = False
    Private StrucVol As DescVol

    Private foundRows() As System.Data.DataRow

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
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents LblModelo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAgregaPreventa))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TxtPrecioNetoUnitario = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblModelo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
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
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Location = New System.Drawing.Point(658, 154)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(207, 73)
        Me.Panel6.TabIndex = 0
        '
        'TxtPrecioNetoUnitario
        '
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
        Me.lblNormal.BackColor = System.Drawing.Color.Transparent
        Me.lblNormal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.ForeColor = System.Drawing.Color.Black
        Me.lblNormal.Location = New System.Drawing.Point(20, 4)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(127, 28)
        Me.lblNormal.TabIndex = 11
        Me.lblNormal.Text = "PRECIO NETO"
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
        'LblModelo
        '
        Me.LblModelo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblModelo.BackColor = System.Drawing.Color.Transparent
        Me.LblModelo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModelo.ForeColor = System.Drawing.Color.Black
        Me.LblModelo.Location = New System.Drawing.Point(111, 9)
        Me.LblModelo.Name = "LblModelo"
        Me.LblModelo.Size = New System.Drawing.Size(218, 26)
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
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Location = New System.Drawing.Point(715, 65)
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
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "CANTIDAD"
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
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblTotal)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(658, 233)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(207, 77)
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
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(10, 30)
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
        Me.BtnGuardar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.Location = New System.Drawing.Point(658, 316)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnGuardar.Office2007CustomColor = System.Drawing.Color.ForestGreen
        Me.BtnGuardar.Size = New System.Drawing.Size(207, 93)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "Agregar al Pedido"
        Me.BtnGuardar.ToolTipText = "Agrega al Pedido"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(658, 516)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCancelar.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.BtnCancelar.Size = New System.Drawing.Size(207, 92)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "Ignorar y Continuar"
        Me.BtnCancelar.ToolTipText = "Finaliza y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.Black
        Me.LblNombre.Location = New System.Drawing.Point(12, 35)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(636, 26)
        Me.LblNombre.TabIndex = 70
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'lblTalla
        '
        Me.lblTalla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTalla.BackColor = System.Drawing.Color.Transparent
        Me.lblTalla.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalla.ForeColor = System.Drawing.Color.Black
        Me.lblTalla.Location = New System.Drawing.Point(307, 9)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(174, 26)
        Me.lblTalla.TabIndex = 72
        Me.lblTalla.Text = "GDL"
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
        Me.lblColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColor.BackColor = System.Drawing.Color.Transparent
        Me.lblColor.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.ForeColor = System.Drawing.Color.Black
        Me.lblColor.Location = New System.Drawing.Point(489, 9)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(376, 26)
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
        Me.GroupBox1.Location = New System.Drawing.Point(7, 487)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 123)
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
        Me.btnIzqMenu.Size = New System.Drawing.Size(50, 108)
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
        Me.btnDerMenu.Location = New System.Drawing.Point(591, 11)
        Me.btnDerMenu.Name = "btnDerMenu"
        Me.btnDerMenu.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnDerMenu.Size = New System.Drawing.Size(50, 108)
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
        Me.pnlMenu.Size = New System.Drawing.Size(532, 108)
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
        Me.PicProducto.Size = New System.Drawing.Size(645, 431)
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
        Me.btnMas.Location = New System.Drawing.Point(815, 65)
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
        Me.btnMenos.Location = New System.Drawing.Point(658, 66)
        Me.btnMenos.Name = "btnMenos"
        Me.btnMenos.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnMenos.Size = New System.Drawing.Size(50, 75)
        Me.btnMenos.TabIndex = 145
        Me.btnMenos.ToolTipText = "Siguiente"
        Me.btnMenos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.UiButton1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiButton1.Location = New System.Drawing.Point(658, 415)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.UiButton1.Office2007CustomColor = System.Drawing.Color.LightSkyBlue
        Me.UiButton1.Size = New System.Drawing.Size(207, 92)
        Me.UiButton1.TabIndex = 146
        Me.UiButton1.Text = "Regresar al Pedido"
        Me.UiButton1.ToolTipText = "Cancelar y regresar al pedido"
        Me.UiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAgregaPreventa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(869, 615)
        Me.Controls.Add(Me.UiButton1)
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
        Me.Name = "FrmAgregaPreventa"
        Me.Text = "Agregar Productos en Preventa"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub cargaDatosProducto(ByVal PROClave As String)
        foundRows = dtPreventa.Select("PROClave = '" & PROClave & "'")
        PROClave = PROClave
        TProducto = foundRows(0)("TProducto")
        Modelo = foundRows(0)("Modelo")
        Nombre = foundRows(0)("Nombre")
        Talla = foundRows(0)("Talla")
        Color = foundRows(0)("Color")
        Clave = foundRows(0)("Clave")
        DescGeneral = foundRows(0)("DescGeneral")
        Peso = foundRows(0)("Peso")
        KgLt = foundRows(0)("KgLt")
        dCantidad = foundRows(0)("Cantidad")
        dPrecioUnitario = foundRows(0)("PrecioBruto") / TipoCambio
        PorcDesc = foundRows(0)("DescPorc")

        FactorImpuesto = ModPOS.RecuperaImpuesto(SUCClave, PROClave, TImpuesto)
      
        sTipoDesc = sTipoDesc

        LblModelo.Text = Modelo
        LblNombre.Text = Nombre
        lblTalla.Text = Talla
        lblColor.Text = Color

        dBase = Math.Round(dPrecioUnitario * dCantidad, 2)
        DescGeneralImporte = Math.Round(dBase * (DescGeneral / 100), 2)


        Dim dtProducto As DataTable
        'Recupera GrupoMaterial
        dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 1, "@PROClave", PROClave) 'GrupoMaterial
        If dtProducto.Rows.Count = 1 Then
            GrupoMaterial = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
        End If
        dtProducto.Dispose()
        'Recupera Sector
        dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 3, "@PROClave", PROClave) 'Sector
        If dtProducto.Rows.Count = 1 Then
            Sector = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
        End If
        dtProducto.Dispose()


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


        If KgLt = 1 Then
            If Peso > 0 Then
                UnidadesKilo = dCantidad / Peso
            Else
                UnidadesKilo = 1
            End If
        Else
            UnidadesKilo = 0
        End If

        ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp


        If TProducto >= 7 AndAlso CDec(TxtCantidad.Text) = 1 Then
            dCantidad = 1
            TxtCantidad.Enabled = False
            btnMenos.Enabled = False
            btnMenos.Enabled = False
        Else
            TxtCantidad.Enabled = True
            btnMenos.Enabled = True
            btnMenos.Enabled = True
        End If

        dPrecioNetoUni = ImporteNeto / dCantidad

        TxtPrecioNetoUnitario.Text = dPrecioNetoUni
        TxtCantidad.Text = dCantidad
        LblTotal.Text = Format(CStr(ImporteNeto), "Currency")
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picFoto As Foto
        picFoto = sender
        PictureSelected = picFoto.IMGClave
        indiceSelected = picFoto.indice
        PicProducto.Image = picFoto.Image
        PROClave = picFoto.PROClave
        PicProducto.SizeMode = PictureBoxSizeMode.Zoom
        cargaDatosProducto(picFoto.PROClave)
    End Sub

    Private Sub CargaProductosPreventa()

        Dim i As Integer

        Dim y As Integer
        ultimaX = 2
        y = 2

        For i = 0 To dtPreventa.Rows.Count - 1

            arrayFoto(indice) = New Foto(dtPreventa.Rows(i)("IMGClave"))

            arrayFoto(indice).Nuevo = False
            arrayFoto(indice).SizeMode = PictureBoxSizeMode.StretchImage
            arrayFoto(indice).Width = 130
            arrayFoto(indice).Height = 100
            arrayFoto(indice).Location = New Point(ultimaX, y)
            arrayFoto(indice).indice = indice

            If Not dtPreventa.Rows(i)("IMGClave") Is System.DBNull.Value Then
                arrayFoto(indice).Image = ModPOS.RecuperaImagen(url_imagen & CStr(dtPreventa.Rows(i)("IMGClave")) & ".jpg")
                arrayFoto(indice).NombreImagen = CStr(dtPreventa.Rows(i)("IMGClave")) & ".jpg"
                arrayFoto(indice).PROClave = CStr(dtPreventa.Rows(i)("PROClave"))
               
            End If

            ultimaX += 135
            pnlMenu.Controls.Add(arrayFoto(indice))
            AddHandler arrayFoto(indice).Click, AddressOf Menu_Click
            indice += 1
            ReDim Preserve arrayFoto(indice)

        Next


        pnlMenu.HorizontalScroll.Enabled = False
        pnlMenu.HorizontalScroll.Visible = False
        iAvanceMenu = pnlMenu.HorizontalScroll.LargeChange

        If arrayFoto(0) IsNot Nothing Then
            PictureSelected = arrayFoto(0).IMGClave
            indiceSelected = arrayFoto(0).indice
            PicProducto.Image = arrayFoto(0).Image
            PicProducto.SizeMode = PictureBoxSizeMode.Zoom
            cargaDatosProducto(arrayFoto(0).PROClave)
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
        bError = True
        If Padre = "Touch" Then
            ModPOS.TouchCK.AddModelo(Clave, dCantidad, False)

        ElseIf Padre = "Venta" Then
            ModPOS.Mostradores(Me.numMostrador).AgregaGTIN(Clave, True, False, True, dCantidad, #1/1/1900#, #1/1/1900#, True, True)

        ElseIf Padre = "Preventa" Then

            ModPOS.PreVenta.AgregaGTIN(Clave, True, False, True, dCantidad, #1/1/1900#, #1/1/1900#, True, True)


        End If

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
        CargaProductosPreventa()

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


            If TProducto >= 7 AndAlso CInt(TxtCantidad.Text) = 1 Then
                TxtCantidad.Enabled = False
                btnMenos.Enabled = False
                btnMenos.Enabled = False
            Else
                TxtCantidad.Enabled = True
                btnMenos.Enabled = True
                btnMenos.Enabled = True
            End If

            RecalculaPrecio("Cantidad")
        End If
    End Sub

    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        TxtCantidad.Text = CInt(TxtCantidad.Text) + 1

        If TProducto >= 7 AndAlso CInt(TxtCantidad.Text) = 1 Then
            TxtCantidad.Enabled = False
            btnMenos.Enabled = False
            btnMenos.Enabled = False
        Else
            TxtCantidad.Enabled = True
            btnMenos.Enabled = True
            btnMenos.Enabled = True
        End If

        RecalculaPrecio("Cantidad")
    End Sub


    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        RecalculaPrecio("Cantidad")
    End Sub


End Class
