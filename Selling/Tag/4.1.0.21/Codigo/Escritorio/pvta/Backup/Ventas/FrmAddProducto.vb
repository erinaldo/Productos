

Public Class FrmAddProducto
    Inherits System.Windows.Forms.Form

    Public SUCClave As String
    Public bTouch As Boolean = False
    Public ALMClave As String
    Public PDVClave As String
    Public PREClave As String
    Public PROClave As String
    Public YaExiste As Boolean
    Public dNormal As Double
    Public dPrecioBruto As Double

    Public NombreCliente As String
    Public Clave As String
    Public Nombre As String
    Public ImporteNeto As Double
    Public Cantidad As Double
    Public Costo As Double
    Public PrecioBruto As Double
    Public DescImp As Double
    Public PorcDesc As Double
    'Public PorcPts As Double
    Public NumDecimal As Integer
    Public Tipo As Integer = 1
    Public TImpuesto As Integer = 1
    Public KgLt As Integer = 0
    Public Peso As Double = 0
    Public UnidadesKilo As Double = 0

    Public ModificaPrecioServicio As Boolean
    Public iTProducto As Integer


    Public CambiaPrecio As Boolean
    Public PorcMaxDesc As Double
    Public sAutoriza As String
    Public MinimoNeto As Double
    Public FactorImpuesto As Double

    Private dtPrecio As DataTable
    Private dAutorizado As Double = 0.0
    Private dPriceSelected As Double
    Private CantEntered As Boolean
    Private PrecioEntered As Boolean
    Private bError As Boolean = False

    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtNormal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Private DescEntered As Boolean
    Friend WithEvents BtnImagen As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents TxtUndKg As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents LblNombre As System.Windows.Forms.Label
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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblNeto As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddProducto))
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.TxtNormal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblNeto = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblNombreCte = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.TxtDesc = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblSubtotal = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridPrecio = New Janus.Windows.GridEX.GridEX
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnImagen = New Janus.Windows.EditControls.UIButton
        Me.BtnUbicacion = New Janus.Windows.EditControls.UIButton
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.TxtUndKg = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel12 = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.LblNombre = New System.Windows.Forms.Label
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.MintCream
        Me.Panel6.Controls.Add(Me.TxtNormal)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Location = New System.Drawing.Point(0, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(218, 45)
        Me.Panel6.TabIndex = 0
        '
        'TxtNormal
        '
        Me.TxtNormal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNormal.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtNormal.Location = New System.Drawing.Point(90, 10)
        Me.TxtNormal.Name = "TxtNormal"
        Me.TxtNormal.Size = New System.Drawing.Size(115, 24)
        Me.TxtNormal.TabIndex = 0
        Me.TxtNormal.Text = "$0.00"
        Me.TxtNormal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtNormal.Value = 0
        Me.TxtNormal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(4, 15)
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.MintCream
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblNeto)
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(588, 126)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 91)
        Me.Panel3.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(7, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "PRECIO NETO"
        '
        'LblNeto
        '
        Me.LblNeto.BackColor = System.Drawing.Color.Transparent
        Me.LblNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNeto.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblNeto.Location = New System.Drawing.Point(7, 30)
        Me.LblNeto.Name = "LblNeto"
        Me.LblNeto.Size = New System.Drawing.Size(186, 37)
        Me.LblNeto.TabIndex = 8
        Me.LblNeto.Text = "$353.45 M.N"
        Me.LblNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.White
        Me.LblClave.Location = New System.Drawing.Point(107, 7)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(405, 26)
        Me.LblClave.TabIndex = 59
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 26)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "CLAVE:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(7, 301)
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
        Me.LblNombreCte.ForeColor = System.Drawing.Color.White
        Me.LblNombreCte.Location = New System.Drawing.Point(65, 301)
        Me.LblNombreCte.Name = "LblNombreCte"
        Me.LblNombreCte.Size = New System.Drawing.Size(517, 29)
        Me.LblNombreCte.TabIndex = 61
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.TxtCantidad)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Location = New System.Drawing.Point(239, 74)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(153, 45)
        Me.Panel5.TabIndex = 1
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(68, 11)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(65, 24)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(4, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 22)
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
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.MintCream
        Me.Panel9.Controls.Add(Me.TxtDesc)
        Me.Panel9.Controls.Add(Me.Label11)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel9.Location = New System.Drawing.Point(586, 74)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(199, 45)
        Me.Panel9.TabIndex = 3
        '
        'TxtDesc
        '
        Me.TxtDesc.DecimalDigits = 4
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc.Location = New System.Drawing.Point(86, 10)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(72, 24)
        Me.TxtDesc.TabIndex = 3
        Me.TxtDesc.Text = "0.0000"
        Me.TxtDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDesc.Value = 0
        Me.TxtDesc.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(2, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 22)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "% DESC."
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
        Me.Panel4.Controls.Add(Me.LblSubtotal)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(588, 223)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 67)
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
        Me.Label6.Text = "SUB TOTAL"
        '
        'LblSubtotal
        '
        Me.LblSubtotal.BackColor = System.Drawing.Color.Transparent
        Me.LblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubtotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblSubtotal.Location = New System.Drawing.Point(7, 30)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(186, 37)
        Me.LblSubtotal.TabIndex = 8
        Me.LblSubtotal.Text = "$353.45 M.N"
        Me.LblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.MintCream
        Me.GroupBox1.Controls.Add(Me.GridPrecio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(0, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 164)
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
        Me.GridPrecio.Size = New System.Drawing.Size(567, 137)
        Me.GridPrecio.TabIndex = 60
        Me.GridPrecio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(697, 297)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(586, 297)
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
        Me.BtnImagen.Location = New System.Drawing.Point(697, 4)
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
        Me.BtnUbicacion.Location = New System.Drawing.Point(601, 4)
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
        Me.picKeyboard.Location = New System.Drawing.Point(558, 6)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 32)
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
        Me.Panel11.Location = New System.Drawing.Point(415, 74)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(153, 45)
        Me.Panel11.TabIndex = 2
        '
        'TxtUndKg
        '
        Me.TxtUndKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUndKg.Enabled = False
        Me.TxtUndKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUndKg.Location = New System.Drawing.Point(70, 11)
        Me.TxtUndKg.Name = "TxtUndKg"
        Me.TxtUndKg.Size = New System.Drawing.Size(65, 24)
        Me.TxtUndKg.TabIndex = 2
        Me.TxtUndKg.Text = "0.00"
        Me.TxtUndKg.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtUndKg.Value = 0
        Me.TxtUndKg.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(4, 16)
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
        Me.LblNombre.ForeColor = System.Drawing.Color.White
        Me.LblNombre.Location = New System.Drawing.Point(7, 33)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(561, 26)
        Me.LblNombre.TabIndex = 70
        Me.LblNombre.Text = "PRODUCTO:"
        '
        'FrmAddProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(794, 342)
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
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 371)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 371)
        Me.Name = "FrmAddProducto"
        Me.Text = "Agregar Producto"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
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
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RecalculaPrecio()

        Dim Descuento As Double
        Dim dModificado As Double

        If TxtCantidad.Text = "" OrElse CDbl(TxtCantidad.Text) <= 0 Then
            TxtCantidad.Text = "1"
            Cantidad = 1
        Else
            Cantidad = CDbl(TxtCantidad.Text)
        End If

        If TxtNormal.Text = "" Then
            TxtNormal.Text = "0.0"
        End If

        If KgLt = 1 Then
            If TxtUndKg.Text = "" OrElse CDbl(TxtUndKg.Text) <= 0 Then
                If Peso > 0 AndAlso Cantidad > 0 Then
                    TxtUndKg.Text = Cantidad / Peso
                    UnidadesKilo = Cantidad / Peso
                Else
                    UnidadesKilo = 0
                End If
            Else
                UnidadesKilo = CDbl(TxtUndKg.Text)
            End If
        End If


        dModificado = CDbl(TxtNormal.Text) / (1 + FactorImpuesto)
        PrecioBruto = dNormal / (1 + FactorImpuesto)

        Select Case dModificado
            Case Is <= PrecioBruto

                If dModificado < PrecioBruto Then
                    Descuento = (PrecioBruto - dModificado) / PrecioBruto
                Else
                    Descuento = Math.Abs(CDbl(TxtDesc.Text) / 100)
                End If

                If Math.Round(MinimoNeto, 2) < Math.Round(ImporteNeto, 2) Then
                    If Math.Round(dModificado * (1 + FactorImpuesto), 2) < Math.Round(MinimoNeto, 2) Then
                        Select Case MessageBox.Show("El producto actual cuenta con un Precio Minimo definido de $" & CStr(Math.Round(MinimoNeto, 2)) & ", Desea continuar y aplicar el descuento por debajo del mínimo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.No
                                TxtNormal.Text = Math.Round(MinimoNeto, 2)
                                Exit Sub

                        End Select
                    End If
                End If


                If (Descuento * 100) > PorcMaxDesc Then

                    If Math.Round(dAutorizado, 4) < Math.Round((Descuento * 100), 4) Then
                        Dim a As New MeAutorizacion
                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = Descuento * 100
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.StoreProcedure = "sp_filtra_descuento"
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If Not a.Autorizado Then
                                a.Dispose()
                                Descuento = Redondear(PorcMaxDesc / 100, 2)
                                dAutorizado = 0
                            End If
                            dAutorizado = Descuento * 100
                            sAutoriza = a.Autoriza
                        ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                            a.Dispose()
                            dAutorizado = 0
                            Descuento = Redondear(PorcMaxDesc / 100, 2)
                        End If
                        a.Dispose()

                    End If


                Else
                    sAutoriza = ModPOS.UsuarioActual
                End If

                If Descuento > 0 Then
                    '  PrecioBruto = dNormal / (1 + FactorImpuesto)
                    PorcDesc = Descuento
                    DescImp = PrecioBruto * PorcDesc
                    ImporteNeto = (PrecioBruto - DescImp) * (1 + FactorImpuesto)

                Else
                    ' PrecioBruto = dNormal / (1 + FactorImpuesto)
                    PorcDesc = 0
                    DescImp = 0
                    ImporteNeto = dNormal
                End If

                TxtNormal.Text = dNormal
                TxtDesc.Text = CStr(PorcDesc * 100)
                LblNeto.Text = Format(CStr(ModPOS.Redondear(ImporteNeto, 2)), "Currency")

                LblSubtotal.Text = Format(CStr(ModPOS.Redondear(ImporteNeto * Cantidad, 2)), "Currency")


            Case Is > PrecioBruto

                If TxtDesc.Text = "" OrElse CDbl(TxtDesc.Text) = 0 Then
                    Descuento = 0
                Else
                    If CDbl(TxtDesc.Text) > PorcMaxDesc Then
                        Descuento = Redondear(PorcMaxDesc / 100, 2)
                    Else
                        Descuento = Math.Abs(CDbl(TxtDesc.Text) / 100)
                    End If
                End If


                PorcDesc = Descuento
                PrecioBruto = dModificado
                DescImp = PrecioBruto * PorcDesc
                ImporteNeto = (PrecioBruto - DescImp) * (1 + FactorImpuesto)

                TxtNormal.Text = dModificado * (1 + FactorImpuesto)
                TxtDesc.Text = CStr(PorcDesc * 100)
                LblNeto.Text = Format(CStr(ModPOS.Redondear(ImporteNeto, 2)), "Currency")
                LblSubtotal.Text = Format(CStr(ModPOS.Redondear(ImporteNeto * Cantidad, 2)), "Currency")



        End Select

        Dim foundRows() As Data.DataRow
        foundRows = dtPrecio.Select("Concepto = 'P.Base'")
        foundRows(0)("Importe") = Format(CStr(ModPOS.Redondear(PrecioBruto, 2)), "Currency")


        foundRows = dtPrecio.Select("Concepto = 'Descuento'")
        foundRows(0)("Importe") = Format(CStr(ModPOS.Redondear(DescImp, 2)), "Currency")

        foundRows = dtPrecio.Select("Concepto = 'Impuesto'")
        foundRows(0)("Importe") = Format(CStr(ModPOS.Redondear((PrecioBruto - DescImp) * FactorImpuesto, 2)), "Currency")


        foundRows = dtPrecio.Select("Concepto = 'P.Neto'")
        foundRows(0)("Importe") = Format(CStr(ModPOS.Redondear(ImporteNeto, 2)), "Currency")


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

    Private Sub TxtNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNormal.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Normal"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtNormal.Text = a.Cantidad
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
        If KgLt = 1 Then
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

    Private Sub FrmAddProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, GridPrecio.KeyUp, TxtDesc.KeyUp, BtnCancelar.KeyUp, BtnGuardar.KeyUp, TxtCantidad.KeyUp, TxtDesc.KeyUp, TxtNormal.KeyUp, TxtUndKg.KeyUp
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
        row1.Item("Concepto") = "P.Base"
        row1.Item("Importe") = Format(CStr(ModPOS.Redondear(PrecioBruto, 2)), "Currency")

        'Descuentos
        dtPrecio.Rows.Add(row1)
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Descuento"
        row1.Item("Importe") = Format(CStr(ModPOS.Redondear(DescImp, 2)), "Currency")

        'Impuestos
        dtPrecio.Rows.Add(row1)
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "Impuesto"
        row1.Item("Importe") = Format(CStr(ModPOS.Redondear((PrecioBruto - DescImp) * FactorImpuesto, 2)), "Currency")

        'Precio Neto
        dtPrecio.Rows.Add(row1)
        row1 = dtPrecio.NewRow()
        row1.Item("Concepto") = "P.Neto"
        row1.Item("Importe") = Format(CStr(ModPOS.Redondear(ImporteNeto, 2)), "Currency")
        dtPrecio.Rows.Add(row1)

        If YaExiste OrElse PorcMaxDesc = 0 Then
            TxtDesc.Enabled = False
        End If

        TxtCantidad.DecimalDigits = NumDecimal

        LblNombreCte.Text = NombreCliente

        LblClave.Text = Clave
        LblNombre.Text = Nombre
        dNormal = ModPOS.Redondear(ImporteNeto, 2)
        TxtNormal.Text = dNormal
        TxtCantidad.Text = Cantidad
        TxtDesc.Text = PorcDesc * 100
        LblNeto.Text = Format(CStr(ModPOS.Redondear((ImporteNeto - DescImp), 2)), "Currency")
        LblSubtotal.Text = Format(CStr(ModPOS.Redondear((ImporteNeto - DescImp) * Cantidad, 2)), "Currency")


        dPrecioBruto = PrecioBruto
        If KgLt = 1 Then
            TxtUndKg.Enabled = True
            If Peso > 0 AndAlso Cantidad > 0 Then
                TxtUndKg.Text = Cantidad / Peso
            Else
                TxtUndKg.Text = 0
            End If
        End If

    End Sub

    Private Sub Txt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDesc.KeyDown, TxtCantidad.KeyDown, TxtUndKg.KeyDown, TxtNormal.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select
    End Sub

    Private Sub Txt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDesc.Leave, TxtCantidad.Leave, TxtUndKg.Leave, TxtNormal.Leave
        RecalculaPrecio()
    End Sub

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagen.Click
        Dim a As New FrmPicture
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
        Process.Start("osk.exe")
    End Sub

    Private Sub TxtCantidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.ValueChanged
        If KgLt = 1 Then
            If TxtCantidad.Text > 0 Then
                TxtUndKg.Text = CDbl(TxtCantidad.Text) * Peso
            End If
        End If
    End Sub

   
End Class
