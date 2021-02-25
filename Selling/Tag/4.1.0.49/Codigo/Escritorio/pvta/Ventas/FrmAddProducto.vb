

Public Class FrmAddProducto
    Inherits System.Windows.Forms.Form

    Public url_imagen As String
    Public VENClave As String
    Public CTEClave As String
    Public GrupoMaterial As Integer
    Public Sector As Integer
    Public SUCClave As String
    Public bTouch As Boolean = False
    Public ALMClave As String
    Public PDVClave As String
    Public PREClave As String
    Public PROClave As String
    Public YaExiste As Boolean
    Private dPrecioNetoUni As Decimal
    Public dBase As Decimal
    Public bValidaMinimo As Boolean = False
    Public NombreCliente As String
    Public Clave As String
    Public Nombre As String
    Public Costo As Decimal

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

    Public NumDecimal As Integer
    Public Tipo As Integer = 1
    Public TImpuesto As Integer = 1
    Public iKgLt As Integer = 0
    Public Peso As Decimal = 0
    Public UnidadesKilo As Decimal = 0

    Public ModificaPrecioServicio As Boolean
    Public iTProducto As Integer


    Public CambiaPrecio As Boolean
    Public PorcMaxDesc As Decimal
    Public sAutoriza As String
    Public MinimoNeto As Decimal
    Public sTipoDesc As String
    Public BloquearPrecio As Integer = 0
   
    Private NumRedondeo As Integer = 6
    Private dtPrecio As DataTable
    Private dAutorizado As Decimal = 0.0
    Private bError As Boolean = False
    Private StrucVol As DescVol
    
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnImagen As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents TxtUndKg As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents btnLista As Janus.Windows.EditControls.UIButton
    Friend WithEvents pDescImp As System.Windows.Forms.Panel
    Friend WithEvents TxtDescImp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecioNetoUnitario As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnStock As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label14 As System.Windows.Forms.Label


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
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblNombreCte As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridPrecio As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDesc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddProducto))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TxtPrecioNetoUnitario = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblNombreCte = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TxtDesc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridPrecio = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnImagen = New Janus.Windows.EditControls.UIButton()
        Me.BtnUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.TxtUndKg = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.btnLista = New Janus.Windows.EditControls.UIButton()
        Me.pDescImp = New System.Windows.Forms.Panel()
        Me.TxtDescImp = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnStock = New Janus.Windows.EditControls.UIButton()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.pDescImp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.MintCream
        Me.Panel6.Controls.Add(Me.TxtPrecioNetoUnitario)
        Me.Panel6.Controls.Add(Me.lblNormal)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Location = New System.Drawing.Point(7, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(172, 55)
        Me.Panel6.TabIndex = 0
        '
        'TxtPrecioNetoUnitario
        '
        Me.TxtPrecioNetoUnitario.DecimalDigits = 6
        Me.TxtPrecioNetoUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecioNetoUnitario.Location = New System.Drawing.Point(11, 24)
        Me.TxtPrecioNetoUnitario.Name = "TxtPrecioNetoUnitario"
        Me.TxtPrecioNetoUnitario.Size = New System.Drawing.Size(149, 24)
        Me.TxtPrecioNetoUnitario.TabIndex = 12
        Me.TxtPrecioNetoUnitario.Text = "0.000000"
        Me.TxtPrecioNetoUnitario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPrecioNetoUnitario.Value = New Decimal(New Integer() {0, 0, 0, 393216})
        '
        'lblNormal
        '
        Me.lblNormal.BackColor = System.Drawing.Color.Transparent
        Me.lblNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblNormal.Location = New System.Drawing.Point(12, 6)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(149, 28)
        Me.lblNormal.TabIndex = 11
        Me.lblNormal.Text = "Precio Neto Unitario"
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
        'LblClave
        '
        Me.LblClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.Black
        Me.LblClave.Location = New System.Drawing.Point(94, 9)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(413, 26)
        Me.LblClave.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 26)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "CLAVE:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(4, 366)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 29)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "PARA:"
        '
        'LblNombreCte
        '
        Me.LblNombreCte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombreCte.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreCte.ForeColor = System.Drawing.Color.Black
        Me.LblNombreCte.Location = New System.Drawing.Point(65, 366)
        Me.LblNombreCte.Name = "LblNombreCte"
        Me.LblNombreCte.Size = New System.Drawing.Size(525, 29)
        Me.LblNombreCte.TabIndex = 61
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.TxtCantidad)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Location = New System.Drawing.Point(241, 75)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(104, 54)
        Me.Panel5.TabIndex = 1
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 23)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(89, 24)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(10, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 22)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Cantidad"
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
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.MintCream
        Me.Panel9.Controls.Add(Me.TxtDesc)
        Me.Panel9.Controls.Add(Me.Label11)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel9.Location = New System.Drawing.Point(461, 75)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(121, 54)
        Me.Panel9.TabIndex = 3
        '
        'TxtDesc
        '
        Me.TxtDesc.DecimalDigits = 4
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc.Location = New System.Drawing.Point(6, 23)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(108, 24)
        Me.TxtDesc.TabIndex = 3
        Me.TxtDesc.Text = "0.0000"
        Me.TxtDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDesc.Value = New Decimal(New Integer() {0, 0, 0, 262144})
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(8, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 22)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "% Descuento"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Gold
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Location = New System.Drawing.Point(7, 104)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(166, 59)
        Me.Panel10.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(7, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 37)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "CANTIDAD PRODUCTOS"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.MintCream
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblTotal)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(588, 135)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 220)
        Me.Panel4.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(7, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(185, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotal.Location = New System.Drawing.Point(6, 175)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(186, 37)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox1.Controls.Add(Me.GridPrecio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(7, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 220)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Text = "Detalle de Precio"
        '
        'GridPrecio
        '
        Me.GridPrecio.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPrecio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrecio.ColumnAutoResize = True
        Me.GridPrecio.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPrecio.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPrecio.Location = New System.Drawing.Point(7, 19)
        Me.GridPrecio.Name = "GridPrecio"
        Me.GridPrecio.RecordNavigator = True
        Me.GridPrecio.Size = New System.Drawing.Size(560, 193)
        Me.GridPrecio.TabIndex = 60
        Me.GridPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(698, 362)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar [F9]"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(602, 362)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir [Esc]"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnImagen
        '
        Me.BtnImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImagen.Image = CType(resources.GetObject("BtnImagen.Image"), System.Drawing.Image)
        Me.BtnImagen.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnImagen.Location = New System.Drawing.Point(698, 6)
        Me.BtnImagen.Name = "BtnImagen"
        Me.BtnImagen.Size = New System.Drawing.Size(90, 37)
        Me.BtnImagen.TabIndex = 7
        Me.BtnImagen.Text = "&Imagen"
        Me.BtnImagen.ToolTipText = "Muestra la Imagen del Producto"
        Me.BtnImagen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnUbicacion
        '
        Me.BtnUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUbicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUbicacion.Image = CType(resources.GetObject("BtnUbicacion.Image"), System.Drawing.Image)
        Me.BtnUbicacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnUbicacion.Location = New System.Drawing.Point(604, 6)
        Me.BtnUbicacion.Name = "BtnUbicacion"
        Me.BtnUbicacion.Size = New System.Drawing.Size(90, 37)
        Me.BtnUbicacion.TabIndex = 8
        Me.BtnUbicacion.Text = "&Ubicación"
        Me.BtnUbicacion.ToolTipText = "Muestra la localización del producto"
        Me.BtnUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(554, 362)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(42, 36)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 68
        Me.picKeyboard.TabStop = False
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.MintCream
        Me.Panel11.Controls.Add(Me.TxtUndKg)
        Me.Panel11.Controls.Add(Me.Label12)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Location = New System.Drawing.Point(351, 75)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(104, 54)
        Me.Panel11.TabIndex = 2
        '
        'TxtUndKg
        '
        Me.TxtUndKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUndKg.Enabled = False
        Me.TxtUndKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUndKg.Location = New System.Drawing.Point(7, 23)
        Me.TxtUndKg.Name = "TxtUndKg"
        Me.TxtUndKg.Size = New System.Drawing.Size(89, 24)
        Me.TxtUndKg.TabIndex = 2
        Me.TxtUndKg.Text = "0.00"
        Me.TxtUndKg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtUndKg.Value = New Decimal(New Integer() {0, 0, 0, 131072})
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(9, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 25)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Und/kg"
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Gold
        Me.Panel12.Controls.Add(Me.Label14)
        Me.Panel12.Location = New System.Drawing.Point(7, 104)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(166, 59)
        Me.Panel12.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(7, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 37)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "CANTIDAD PRODUCTOS"
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.BackColor = System.Drawing.Color.Transparent
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.ForeColor = System.Drawing.Color.Black
        Me.LblNombre.Location = New System.Drawing.Point(7, 42)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(589, 26)
        Me.LblNombre.TabIndex = 70
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'btnLista
        '
        Me.btnLista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLista.Icon = CType(resources.GetObject("btnLista.Icon"), System.Drawing.Icon)
        Me.btnLista.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnLista.Location = New System.Drawing.Point(185, 74)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(50, 55)
        Me.btnLista.TabIndex = 95
        Me.btnLista.Text = "F1"
        Me.btnLista.ToolTipText = "Muestra las diferentes listas de precio"
        Me.btnLista.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pDescImp
        '
        Me.pDescImp.BackColor = System.Drawing.Color.MintCream
        Me.pDescImp.Controls.Add(Me.TxtDescImp)
        Me.pDescImp.Controls.Add(Me.Label3)
        Me.pDescImp.Controls.Add(Me.Panel2)
        Me.pDescImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pDescImp.Location = New System.Drawing.Point(588, 75)
        Me.pDescImp.Name = "pDescImp"
        Me.pDescImp.Size = New System.Drawing.Size(199, 54)
        Me.pDescImp.TabIndex = 96
        '
        'TxtDescImp
        '
        Me.TxtDescImp.DecimalDigits = 6
        Me.TxtDescImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescImp.Location = New System.Drawing.Point(10, 23)
        Me.TxtDescImp.Name = "TxtDescImp"
        Me.TxtDescImp.Size = New System.Drawing.Size(182, 24)
        Me.TxtDescImp.TabIndex = 3
        Me.TxtDescImp.Text = "0.000000"
        Me.TxtDescImp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescImp.Value = New Decimal(New Integer() {0, 0, 0, 393216})
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Desc. Importe (+Impts)"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(7, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 59)
        Me.Panel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(7, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 37)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CANTIDAD PRODUCTOS"
        '
        'BtnStock
        '
        Me.BtnStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStock.Icon = CType(resources.GetObject("BtnStock.Icon"), System.Drawing.Icon)
        Me.BtnStock.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnStock.Location = New System.Drawing.Point(503, 6)
        Me.BtnStock.Name = "BtnStock"
        Me.BtnStock.Size = New System.Drawing.Size(97, 37)
        Me.BtnStock.TabIndex = 97
        Me.BtnStock.Text = "Existencia"
        Me.BtnStock.ToolTipText = "Muestra la Existencia en otras Sucursales"
        Me.BtnStock.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 404)
        Me.Controls.Add(Me.BtnStock)
        Me.Controls.Add(Me.pDescImp)
        Me.Controls.Add(Me.btnLista)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.BtnUbicacion)
        Me.Controls.Add(Me.BtnImagen)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.LblNombreCte)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 371)
        Me.Name = "FrmAddProducto"
        Me.Text = "Agregar Producto"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.pDescImp.ResumeLayout(False)
        Me.pDescImp.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RecalculaPrecio(ByVal obj As String)
        Dim bActualiza As Boolean = False

        Select Case obj
            Case Is = "Precio"
                If dPrecioNetoUni <> TxtPrecioNetoUnitario.Text Then

                    If TxtPrecioNetoUnitario.Text > dPrecioNetoUni Then
                        Dim incremento As Double

                        incremento = TxtPrecioNetoUnitario.Text / dPrecioNetoUni

                        dPrecioUnitario = ModPOS.Redondear(dPrecioUnitario * incremento, 6)

                        If iKgLt = 1 Then
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
                        If dVolumen > 0 Then
                            dVolumenImp = Math.Round((dBase - DescGeneralImporte) * (dVolumen / 100), 2)
                        Else
                            dVolumenImp = 0
                        End If
                        DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                        dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                        ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp

                        bActualiza = True
                    Else


                        Dim dPorcDesc As Decimal = Math.Round(((dPrecioNetoUni - TxtPrecioNetoUnitario.Text) / dPrecioNetoUni) * 100, 6)


                        If dPorcDesc > PorcMaxDesc Then
                            If Math.Round(dAutorizado, 6) < dPorcDesc Then
                                Dim a As New MeAutorizacion
                                a.Sucursal = SUCClave
                                a.MontodeAutorizacion = dPorcDesc
                                a.StartPosition = FormStartPosition.CenterScreen
                                a.StoreProcedure = "sp_filtra_descuento"
                                a.NivelSucursal = 0
                                a.ShowDialog()
                                If a.DialogResult = DialogResult.OK Then
                                    If Not a.Autorizado Then
                                        a.Dispose()
                                        dPorcDesc = Redondear(PorcMaxDesc, 6)
                                        dAutorizado = 0
                                    End If
                                    dAutorizado = dPorcDesc
                                    sAutoriza = a.Autoriza
                                ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                                    a.Dispose()
                                    dAutorizado = 0
                                    dPorcDesc = Redondear(PorcMaxDesc, 6)
                                End If
                                a.Dispose()

                            End If
                        Else
                            sAutoriza = ModPOS.UsuarioActual
                        End If

                        If bValidaMinimo Then
                            If dPrecioNetoUni / (1 + (dPorcDesc / 100)) < MinimoNeto Then
                                Select Case MessageBox.Show("El producto actual cuenta con un Precio Minimo definido de $" & CStr(MinimoNeto) & ", Desea continuar y aplicar el descuento por debajo del mínimo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Case DialogResult.No
                                        dPorcDesc = PorcDesc
                                End Select
                            End If
                        End If

                        PorcDesc = dPorcDesc
                        DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                        dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                        ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp
                        bActualiza = True
                    End If



                    End If
            Case Is = "Cantidad"
                If dCantidad <> CDec(TxtCantidad.Text) Then

                    If CDbl(TxtCantidad.Text) <= 0 Then
                        TxtCantidad.Text = "1"
                    End If

                    dCantidad = CDec(TxtCantidad.Text)

                    If iKgLt = 1 Then
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
            Case Is = "Unidad"
                If iKgLt = 1 AndAlso UnidadesKilo <> CDec(TxtUndKg.Text) Then

                    If CDec(TxtUndKg.Text) <= 1 Then
                        TxtUndKg.Text = "1"
                    End If

                    UnidadesKilo = CDec(TxtUndKg.Text)
                 

                ElseIf iKgLt = 0 Then

                    UnidadesKilo = 0
                End If
                bActualiza = False
            Case Is = "Descuento"
                    If PorcDesc <> CDec(TxtDesc.Text) Then


                        If CDec(TxtDesc.Text) > PorcMaxDesc Then
                            If Math.Round(dAutorizado, 6) < Math.Round(CDec(TxtDesc.Text), 6) Then
                                Dim a As New MeAutorizacion
                                a.Sucursal = SUCClave
                                a.MontodeAutorizacion = CDec(TxtDesc.Text)
                                a.StartPosition = FormStartPosition.CenterScreen
                            a.StoreProcedure = "sp_filtra_descuento"
                            a.NivelSucursal = 0
                                a.ShowDialog()
                                If a.DialogResult = DialogResult.OK Then
                                    If Not a.Autorizado Then
                                        a.Dispose()
                                        TxtDesc.Text = Redondear(PorcMaxDesc, 6)
                                        dAutorizado = 0
                                    End If
                                    dAutorizado = CDec(TxtDesc.Text)
                                    sAutoriza = a.Autoriza
                                ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                                    a.Dispose()
                                    dAutorizado = 0
                                    TxtDesc.Text = Redondear(PorcMaxDesc, 6)
                                End If
                                a.Dispose()

                            End If
                        Else
                            sAutoriza = ModPOS.UsuarioActual
                        End If

                       
                    If bValidaMinimo Then
                        If dPrecioNetoUni / (1 + (Math.Abs(CDec(TxtDesc.Text)) / 100)) < MinimoNeto Then
                            Select Case MessageBox.Show("El producto actual cuenta con un Precio Minimo definido de $" & CStr(MinimoNeto) & ", Desea continuar y aplicar el descuento por debajo del mínimo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.No
                                    TxtDesc.Text = PorcDesc
                            End Select
                        End If
                    End If


                    PorcDesc = Math.Abs(CDec(TxtDesc.Text))
                    DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                    dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                    ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp
                    bActualiza = True
                End If
            Case Is = "Importe"
                    If CDec(TxtDescImp.Text) > 0 Then

                        Dim dPorcDesc As Decimal = ModPOS.Redondear((CDec(TxtDescImp.Text) * 100) / dPrecioNetoUni, 6)
                        If PorcDesc <> dPorcDesc Then

                            If dPorcDesc > PorcMaxDesc Then
                                If Math.Round(dAutorizado, 6) < dPorcDesc Then
                                    Dim a As New MeAutorizacion
                                    a.Sucursal = SUCClave
                                    a.MontodeAutorizacion = dPorcDesc
                                    a.StartPosition = FormStartPosition.CenterScreen
                                a.StoreProcedure = "sp_filtra_descuento"
                                a.NivelSucursal = 0
                                    a.ShowDialog()
                                    If a.DialogResult = DialogResult.OK Then
                                        If Not a.Autorizado Then
                                            a.Dispose()
                                        dPorcDesc = Redondear(PorcMaxDesc, 6)
                                            dAutorizado = 0
                                        End If
                                        dAutorizado = dPorcDesc
                                        sAutoriza = a.Autoriza
                                    ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                                        a.Dispose()
                                        dAutorizado = 0
                                    dPorcDesc = Redondear(PorcMaxDesc, 6)
                                    End If
                                    a.Dispose()

                                End If
                            Else
                                sAutoriza = ModPOS.UsuarioActual
                            End If

                        If bValidaMinimo Then
                            If dPrecioNetoUni / (1 + (dPorcDesc / 100)) < MinimoNeto Then
                                Select Case MessageBox.Show("El producto actual cuenta con un Precio Minimo definido de $" & CStr(MinimoNeto) & ", Desea continuar y aplicar el descuento por debajo del mínimo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Case DialogResult.No
                                        dPorcDesc = PorcDesc
                                End Select
                            End If
                        End If
                      

                            PorcDesc = dPorcDesc
                            DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                            dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                            ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp
                        bActualiza = True
                    End If
                Else
                    PorcDesc = 0
                    DescImp = Math.Round((dBase - DescGeneralImporte - dVolumenImp) * (PorcDesc / 100), 2)
                    dImpuestoimp = Math.Round((dBase - DescGeneralImporte - dVolumenImp - DescImp) * FactorImpuesto, 2)
                    ImporteNeto = dBase - DescGeneralImporte - dVolumenImp - DescImp + dImpuestoimp
                    bActualiza = True
                End If

        End Select

        If bActualiza = True Then
            
            dPrecioNetoUni = ModPOS.Redondear(ImporteNeto / dCantidad, 6)

            TxtPrecioNetoUnitario.Text = dPrecioNetoUni
            TxtUndKg.Text = UnidadesKilo
            TxtDesc.Text = PorcDesc
            TxtDescImp.Text = dPrecioNetoUni * (PorcDesc / 100)
            LblTotal.Text = Format(CStr(ImporteNeto), "Currency")

            dtPrecio.Clear()

            'Precio Base
            Dim row1 As DataRow
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "P.Unitario"
            row1.Item("Importe") = "$ " & CStr(ModPOS.Redondear(dPrecioUnitario, 6))
            dtPrecio.Rows.Add(row1)

            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Cantidad"
            row1.Item("Importe") = CStr(dCantidad)
            dtPrecio.Rows.Add(row1)

            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Subtotal"
            row1.Item("Importe") = Format(CStr(dBase), "Currency")
            dtPrecio.Rows.Add(row1)


            'General
            If DescGeneral > 0 Then
                row1 = dtPrecio.NewRow()
                row1.Item("Concepto") = "Desc.General"
                row1.Item("Importe") = "(- " & ModPOS.Redondear(DescGeneral, 2) & "%) " & Format(CStr(DescGeneralImporte), "Currency")
                dtPrecio.Rows.Add(row1)

            End If
            'Volumen
            If dVolumen > 0 Then
                row1 = dtPrecio.NewRow()
                row1.Item("Concepto") = "Desc.Volumen"
                row1.Item("Importe") = "(- " & ModPOS.Redondear(dVolumen, 2) & "%) " & Format(CStr(dVolumenImp), "Currency")
                dtPrecio.Rows.Add(row1)
            End If

            'Descuentos
            If PorcDesc > 0 Then
                row1 = dtPrecio.NewRow()
                row1.Item("Concepto") = "Descuento"
                row1.Item("Importe") = "(- " & ModPOS.Redondear(PorcDesc, 2) & "%) " & Format(CStr(DescImp), "Currency")
                dtPrecio.Rows.Add(row1)
            End If

            'Precio
            If PorcDesc > 0 OrElse dVolumen > 0 OrElse DescGeneral > 0 Then
                row1 = dtPrecio.NewRow()
                row1.Item("Concepto") = "Precio Bruto"
                row1.Item("Importe") = Format(CStr(dBase - (DescImp + dVolumenImp + DescGeneralImporte)), "Currency")
                dtPrecio.Rows.Add(row1)
            End If

            'Impuestos
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Impuesto"
            row1.Item("Importe") = Format(CStr(dImpuestoimp), "Currency")
            dtPrecio.Rows.Add(row1)

            'Precio Neto
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Total"
            row1.Item("Importe") = Format(CStr(ImporteNeto), "Currency")
            dtPrecio.Rows.Add(row1)

        End If
    End Sub

 
    Private Sub TxtCantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Cantidad"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtCantidad.Text = a.Cantidad
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub TxtDesc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDesc.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Porcentaje de Descuento"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtDesc.Text = a.Cantidad
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub TxtPrecioNetoUnitario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPrecioNetoUnitario.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Normal"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtPrecioNetoUnitario.Text = a.Cantidad
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub TxtKgLt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtUndKg.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Kg/Lt"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtUndKg.Text = a.Cantidad
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not ModPOS.Teclado Is Nothing Then
            ModPOS.Teclado.Close()
        End If
        If iKgLt = 1 Then
            If UnidadesKilo = 0 Then
                bError = True
                Beep()
                MessageBox.Show("El número de unidades (Und/Kg) debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.DialogResult = DialogResult.Cancel
            Else
                bError = False
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Else
            bError = False
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmAddProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, GridPrecio.KeyUp, TxtDesc.KeyUp, BtnCancelar.KeyUp, BtnGuardar.KeyUp, TxtCantidad.KeyUp, TxtDesc.KeyUp, TxtUndKg.KeyUp, TxtPrecioNetoUnitario.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F9
                Me.BtnGuardar.PerformClick()
        End Select
    End Sub

    Private Sub FrmAddProducto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmAddProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If BloquearPrecio = 1 Then
            TxtPrecioNetoUnitario.ReadOnly = True
            btnLista.Visible = False
            SendKeys.Send("{TAB}")
        End If

        If YaExiste OrElse PorcMaxDesc = 0 Then
            TxtDesc.Enabled = False
            TxtDescImp.Enabled = False
        End If

        
            dPrecioNetoUni = ImporteNeto / dCantidad


       
        TxtUndKg.Text = UnidadesKilo
        TxtCantidad.DecimalDigits = NumDecimal
        LblNombreCte.Text = NombreCliente
        LblClave.Text = Clave
        LblNombre.Text = Nombre


        TxtPrecioNetoUnitario.Text = dPrecioNetoUni
        TxtCantidad.Text = dCantidad
        TxtDesc.Text = PorcDesc
        TxtDescImp.Text = DescImp + Math.Round((DescImp * FactorImpuesto), 2)
        LblTotal.Text = Format(CStr(ImporteNeto), "Currency")


        dtPrecio = ModPOS.CrearTabla("Precio", _
           "Concepto", "System.String", _
           "Importe", "System.String")

        GridPrecio.DataSource = dtPrecio
        GridPrecio.RetrieveStructure(True)
        GridPrecio.GroupByBoxVisible = False
        GridPrecio.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        'Precio Base
        Dim row1 As DataRow
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "P.Unitario"
        row1.Item("Importe") = "$ " & CStr(ModPOS.Redondear(dPrecioUnitario, 6))
        dtPrecio.Rows.Add(row1)

        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Cantidad"
        row1.Item("Importe") = CStr(dCantidad)
        dtPrecio.Rows.Add(row1)

        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Subtotal"
        row1.Item("Importe") = Format(CStr(dBase), "Currency")
        dtPrecio.Rows.Add(row1)


        'General
        If DescGeneral > 0 Then
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Desc.General"
            row1.Item("Importe") = "(- " & ModPOS.Redondear(DescGeneral, 2) & "%) " & Format(CStr(DescGeneralImporte), "Currency")
            dtPrecio.Rows.Add(row1)

        End If
        'Volumen
        If dVolumen > 0 Then
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Desc.Volumen"
            row1.Item("Importe") = "(- " & ModPOS.Redondear(dVolumen, 2) & "%) " & Format(CStr(dVolumenImp), "Currency")
            dtPrecio.Rows.Add(row1)
        End If

        'Descuentos
        If PorcDesc > 0 Then
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Descuento"
            row1.Item("Importe") = "(- " & ModPOS.Redondear(PorcDesc, 2) & "%) " & Format(CStr(DescImp), "Currency")
            dtPrecio.Rows.Add(row1)
        End If


        'Precio
        If PorcDesc > 0 OrElse dVolumen > 0 OrElse DescGeneral > 0 Then
            row1 = dtPrecio.NewRow()
            row1.Item("Concepto") = "Precio Bruto"
            row1.Item("Importe") = Format(CStr(dBase - (DescImp + dVolumenImp + DescGeneralImporte)), "Currency")
            dtPrecio.Rows.Add(row1)
        End If

        'Impuestos
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Impuesto"
        row1.Item("Importe") = Format(CStr(dImpuestoimp), "Currency")
        dtPrecio.Rows.Add(row1)

        'Precio Neto
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Total"
        row1.Item("Importe") = Format(CStr(ImporteNeto), "Currency")
        dtPrecio.Rows.Add(row1)


        If iKgLt = 1 Then
            TxtUndKg.Enabled = True
        Else
            TxtUndKg.Text = 0
        End If

    End Sub

    Private Sub Txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDesc.KeyDown, TxtCantidad.KeyDown, TxtUndKg.KeyDown, btnLista.KeyDown, TxtPrecioNetoUnitario.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F1
                btnLista.PerformClick()
            Case Is = Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select
    End Sub

   

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagen.Click
        Dim a As New FrmPicture
        a.url_imagen = Me.url_imagen
        a.ClaveProducto = LblClave.Text
        a.NombreProducto = LblNombre.Text
        a.PROClave = Me.PROClave
        a.btnRemover.Visible = False
        a.btnAgregar.Visible = False
        a.BtnGuardar.Visible = False
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub BtnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicacion.Click
        Dim a As New FrmConsultaGen
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_ubcproducto", "@PROClave", PROClave, "@ALMClave", ALMClave)
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        AbrirTeclado(Me)
    End Sub

   

    Private Sub btnLista_Click(sender As Object, e As EventArgs) Handles btnLista.Click

        Dim a As New FrmConsulta
        a.Text = "Listas de Precio"
        a.Campo = "PrecioNeto"
        a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
        a.GridConsultaGen.GroupByBoxVisible = False
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_muestra_otros_precios", "@SUCClave", SUCClave, "@PREClave", PREClave, "@CTEClave", CTEClave, "@PROClave", PROClave)
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If IsNumeric(a.ID) AndAlso CDbl(a.ID) > 0 Then
                TxtPrecioNetoUnitario.Text = a.ID
                RecalculaPrecio("Precio")
            End If
        End If
        a.Dispose()
    End Sub

   
    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        RecalculaPrecio("Cantidad")
    End Sub

    Private Sub TxtUndKg_Leave(sender As Object, e As EventArgs) Handles TxtUndKg.Leave
        RecalculaPrecio("Unidad")
    End Sub

    Private Sub TxtDesc_Leave(sender As Object, e As EventArgs) Handles TxtDesc.Leave
        RecalculaPrecio("Descuento")
    End Sub

    Private Sub TxtDescImp_Leave(sender As Object, e As EventArgs) Handles TxtDescImp.Leave
        RecalculaPrecio("Importe")
    End Sub

    Private Sub TxtPrecioNetoUnitario_Leave(sender As Object, e As EventArgs) Handles TxtPrecioNetoUnitario.Leave
        RecalculaPrecio("Precio")
    End Sub

    Private Sub BtnStock_Click(sender As Object, e As EventArgs) Handles BtnStock.Click
        Dim a As New FrmConsultaGen
        a.Text = "Existencia en Otros Almacenes"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_exist_alm", "@PROClave", PROClave, "@ALMClave", ALMClave)
        a.ShowDialog()
        a.Dispose()
    End Sub
End Class
