Public Class FrmBuscaProducto
    Inherits System.Windows.Forms.Form
    Implements ITeclado

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
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnImagen As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnStock As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnTransito As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPromocion As Janus.Windows.EditControls.UIButton
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAplicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents TxtUltimaVta As System.Windows.Forms.TextBox
    Friend WithEvents btnClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLista As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkLimitar As System.Windows.Forms.CheckBox
    Friend WithEvents BtnEquivalente As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaProducto))
        Me.GrpProductos = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnLista = New Janus.Windows.EditControls.UIButton()
        Me.btnClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.TxtAlmacen = New System.Windows.Forms.TextBox()
        Me.TxtUltimaVta = New System.Windows.Forms.TextBox()
        Me.TxtPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAplicacion = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GrpClas = New System.Windows.Forms.GroupBox()
        Me.cmbGrupo = New Selling.StoreCombo()
        Me.TreeViewClass = New System.Windows.Forms.TreeView()
        Me.btnPromocion = New Janus.Windows.EditControls.UIButton()
        Me.btnTransito = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnStock = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEquivalente = New Janus.Windows.EditControls.UIButton()
        Me.BtnUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.BtnImagen = New Janus.Windows.EditControls.UIButton()
        Me.ChkLimitar = New System.Windows.Forms.CheckBox()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpProductos.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpClas.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpProductos.Controls.Add(Me.Label5)
        Me.GrpProductos.Controls.Add(Me.btnLista)
        Me.GrpProductos.Controls.Add(Me.btnClasificacion)
        Me.GrpProductos.Controls.Add(Me.picKeyboard)
        Me.GrpProductos.Controls.Add(Me.TxtAlmacen)
        Me.GrpProductos.Controls.Add(Me.TxtUltimaVta)
        Me.GrpProductos.Controls.Add(Me.TxtPrecio)
        Me.GrpProductos.Controls.Add(Me.Label4)
        Me.GrpProductos.Controls.Add(Me.Label3)
        Me.GrpProductos.Controls.Add(Me.Label2)
        Me.GrpProductos.Controls.Add(Me.btnAplicacion)
        Me.GrpProductos.Controls.Add(Me.Label1)
        Me.GrpProductos.Controls.Add(Me.TxtMaxHits)
        Me.GrpProductos.Controls.Add(Me.GrpClas)
        Me.GrpProductos.Controls.Add(Me.btnPromocion)
        Me.GrpProductos.Controls.Add(Me.btnTransito)
        Me.GrpProductos.Controls.Add(Me.BtnCancelar)
        Me.GrpProductos.Controls.Add(Me.BtnStock)
        Me.GrpProductos.Controls.Add(Me.BtnAgregar)
        Me.GrpProductos.Controls.Add(Me.BtnEquivalente)
        Me.GrpProductos.Controls.Add(Me.BtnUbicacion)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Controls.Add(Me.BtnImagen)
        Me.GrpProductos.Controls.Add(Me.ChkLimitar)
        Me.GrpProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpProductos.ForeColor = System.Drawing.Color.Black
        Me.GrpProductos.Location = New System.Drawing.Point(7, 2)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(821, 554)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Busqueda"
        '
        'btnLista
        '
        Me.btnLista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLista.Icon = CType(resources.GetObject("btnLista.Icon"), System.Drawing.Icon)
        Me.btnLista.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnLista.Location = New System.Drawing.Point(76, 44)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(65, 28)
        Me.btnLista.TabIndex = 94
        Me.btnLista.Text = "F1"
        Me.btnLista.ToolTipText = "Muestra las diferentes listas de precio"
        Me.btnLista.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnClasificacion
        '
        Me.btnClasificacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClasificacion.Icon = CType(resources.GetObject("btnClasificacion.Icon"), System.Drawing.Icon)
        Me.btnClasificacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnClasificacion.Location = New System.Drawing.Point(7, 44)
        Me.btnClasificacion.Name = "btnClasificacion"
        Me.btnClasificacion.Size = New System.Drawing.Size(65, 28)
        Me.btnClasificacion.TabIndex = 93
        Me.btnClasificacion.ToolTipText = "Mostrar Clasificaciones"
        Me.btnClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(577, 10)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 13
        Me.picKeyboard.TabStop = False
        '
        'TxtAlmacen
        '
        Me.TxtAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAlmacen.Location = New System.Drawing.Point(78, 87)
        Me.TxtAlmacen.Name = "TxtAlmacen"
        Me.TxtAlmacen.ReadOnly = True
        Me.TxtAlmacen.Size = New System.Drawing.Size(347, 22)
        Me.TxtAlmacen.TabIndex = 92
        '
        'TxtUltimaVta
        '
        Me.TxtUltimaVta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUltimaVta.Location = New System.Drawing.Point(509, 87)
        Me.TxtUltimaVta.Name = "TxtUltimaVta"
        Me.TxtUltimaVta.ReadOnly = True
        Me.TxtUltimaVta.Size = New System.Drawing.Size(80, 22)
        Me.TxtUltimaVta.TabIndex = 91
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrecio.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtPrecio.Location = New System.Drawing.Point(658, 86)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.ReadOnly = True
        Me.TxtPrecio.Size = New System.Drawing.Size(156, 26)
        Me.TxtPrecio.TabIndex = 90
        Me.TxtPrecio.Text = "$0.00"
        Me.TxtPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPrecio.Value = 0.0R
        Me.TxtPrecio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(605, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Precio"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(431, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Ultima Vta."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Almacén"
        '
        'btnAplicacion
        '
        Me.btnAplicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAplicacion.Image = Global.Selling.My.Resources.Resources._1431714849_application
        Me.btnAplicacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnAplicacion.Location = New System.Drawing.Point(559, 44)
        Me.btnAplicacion.Name = "btnAplicacion"
        Me.btnAplicacion.Size = New System.Drawing.Size(65, 28)
        Me.btnAplicacion.TabIndex = 86
        Me.btnAplicacion.Text = "F10"
        Me.btnAplicacion.ToolTipText = "Busqueda por Aplicación Automotriz"
        Me.btnAplicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(627, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(759, 15)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 22)
        Me.TxtMaxHits.TabIndex = 84
        Me.TxtMaxHits.Text = "10,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 10000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 114)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(220, 434)
        Me.GrpClas.TabIndex = 14
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        Me.GrpClas.Visible = False
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(7, 17)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(207, 24)
        Me.cmbGrupo.TabIndex = 8
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 44)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(207, 383)
        Me.TreeViewClass.TabIndex = 0
        '
        'btnPromocion
        '
        Me.btnPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPromocion.Icon = CType(resources.GetObject("btnPromocion.Icon"), System.Drawing.Icon)
        Me.btnPromocion.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnPromocion.Location = New System.Drawing.Point(490, 44)
        Me.btnPromocion.Name = "btnPromocion"
        Me.btnPromocion.Size = New System.Drawing.Size(65, 28)
        Me.btnPromocion.TabIndex = 12
        Me.btnPromocion.Text = "F8"
        Me.btnPromocion.ToolTipText = "Muestra los productos con promoción"
        Me.btnPromocion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnTransito
        '
        Me.btnTransito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTransito.Icon = CType(resources.GetObject("btnTransito.Icon"), System.Drawing.Icon)
        Me.btnTransito.ImageSize = New System.Drawing.Size(28, 24)
        Me.btnTransito.Location = New System.Drawing.Point(421, 44)
        Me.btnTransito.Name = "btnTransito"
        Me.btnTransito.Size = New System.Drawing.Size(65, 28)
        Me.btnTransito.TabIndex = 11
        Me.btnTransito.Text = "F7"
        Me.btnTransito.ToolTipText = "Muestra la Existencia en Transito"
        Me.btnTransito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(680, 44)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(65, 28)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "[Esc]"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnStock
        '
        Me.BtnStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStock.Icon = CType(resources.GetObject("BtnStock.Icon"), System.Drawing.Icon)
        Me.BtnStock.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnStock.Location = New System.Drawing.Point(352, 44)
        Me.BtnStock.Name = "BtnStock"
        Me.BtnStock.Size = New System.Drawing.Size(65, 28)
        Me.BtnStock.TabIndex = 10
        Me.BtnStock.Text = "F6 "
        Me.BtnStock.ToolTipText = "Muestra la Existencia en otras Sucursales"
        Me.BtnStock.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(749, 44)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(65, 28)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "F9 "
        Me.BtnAgregar.ToolTipText = "Agrega el producto a la venta actual"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEquivalente
        '
        Me.BtnEquivalente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEquivalente.Icon = CType(resources.GetObject("BtnEquivalente.Icon"), System.Drawing.Icon)
        Me.BtnEquivalente.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnEquivalente.Location = New System.Drawing.Point(283, 44)
        Me.BtnEquivalente.Name = "BtnEquivalente"
        Me.BtnEquivalente.Size = New System.Drawing.Size(65, 28)
        Me.BtnEquivalente.TabIndex = 8
        Me.BtnEquivalente.Text = "F4"
        Me.BtnEquivalente.ToolTipText = "Muestra productos equivalentes"
        Me.BtnEquivalente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnUbicacion
        '
        Me.BtnUbicacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUbicacion.Icon = CType(resources.GetObject("BtnUbicacion.Icon"), System.Drawing.Icon)
        Me.BtnUbicacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnUbicacion.Location = New System.Drawing.Point(214, 44)
        Me.BtnUbicacion.Name = "BtnUbicacion"
        Me.BtnUbicacion.Size = New System.Drawing.Size(65, 28)
        Me.BtnUbicacion.TabIndex = 7
        Me.BtnUbicacion.Text = "F3 "
        Me.BtnUbicacion.ToolTipText = "Muestra la localización del producto"
        Me.BtnUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(82, 15)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(366, 22)
        Me.TxtBuscar.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.CardViewGridlines = Janus.Windows.GridEX.CardViewGridlines.Vertical
        Me.GridProductos.CardWidth = 726
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 114)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(807, 436)
        Me.GridProductos.TabIndex = 3
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnImagen
        '
        Me.BtnImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImagen.Icon = CType(resources.GetObject("BtnImagen.Icon"), System.Drawing.Icon)
        Me.BtnImagen.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnImagen.Location = New System.Drawing.Point(145, 44)
        Me.BtnImagen.Name = "BtnImagen"
        Me.BtnImagen.Size = New System.Drawing.Size(65, 28)
        Me.BtnImagen.TabIndex = 3
        Me.BtnImagen.Text = "F2"
        Me.BtnImagen.ToolTipText = "Muestra la Imagen del Producto"
        Me.BtnImagen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkLimitar
        '
        Me.ChkLimitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkLimitar.Location = New System.Drawing.Point(454, 18)
        Me.ChkLimitar.Name = "ChkLimitar"
        Me.ChkLimitar.Size = New System.Drawing.Size(135, 19)
        Me.ChkLimitar.TabIndex = 96
        Me.ChkLimitar.Text = "Limitar a Clave"
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmBuscaProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(834, 561)
        Me.Controls.Add(Me.GrpProductos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmBuscaProducto"
        Me.Text = "Busqueda de Productos"
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpClas.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    
    Private PDVClave As String
    Private ALMClave As String
    Private sProdSelected As String
    Private sClave As String
    Private sGTIN As String
    '  Private sImg As String
    Private ListaPrecio As String
    Private VentaCerrada As Boolean
    Private Tipo As Integer = 1
    Private CTEClave As String
    Private dataSetArbol As Data.DataSet
    Private bLoad As Boolean = False
    Private bClasLoad As Boolean = False
    Private bClasVisible As Boolean = False
    Private bError As Boolean = False

    Public ModificaPrecioServicio As Boolean
    Public numMostrador As Integer
    Public SUCClave As String
    Public TImpuesto As Integer = 1
    Public bVentaConvencional As Boolean = False
    Public url_imagen As String
    Public BusquedaInicial As Boolean = False
    Public Busqueda As String
    Public TipoCambio As Decimal = 1
    Public Padre As String = ""
    Private dt As DataTable

    Public bMessage As Boolean = True
    ' Private dataSetArbol As Data.DataSet

    Private Sub fechaUltimaVenta()
        If GridProductos.RowCount > 0 AndAlso Not GridProductos.GetValue("ID") Is Nothing Then
            dt = ModPOS.Recupera_Tabla("sp_obtenerFecUltVenta", "@Almacen", ALMClave, "@PROClave", GridProductos.GetValue("ID"))
            Me.TxtUltimaVta.Text = String.Format("{0:dd/MM/yyyy}", dt.Rows(0)(0))
            dt.Dispose()
        End If
    End Sub


    Private Sub obtenerPrecio()
        If GridProductos.RowCount > 0 AndAlso Not GridProductos.GetValue("ID") Is Nothing Then
            dt = ModPOS.Recupera_Tabla("sp_obtener_precioNeto", "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClave, "@PROClave", GridProductos.GetValue("ID"))

            Me.TxtPrecio.Text = ModPOS.TruncateToDecimal(dt.Rows(0)(0) / TipoCambio, 2)
            dt.Dispose()
        End If
    End Sub


    Public Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 3, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACIÓN"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()
    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Clasificacion"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("Clasificacion").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeViewClass.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent



    End Sub


    Private Sub actGrid(ByVal MaxHits As Integer, ByVal Tag As Integer, ByVal sBusqueda As String, ByVal sAlmacen As String, ByVal sPrecio As String, ByVal iTipoImpuesto As Integer)

        sBusqueda = sBusqueda.Replace("'", "")

        bLoad = False

        If Tag = 0 Then
            ModPOS.ActualizaGrid(False, Me.GridProductos, "sp_busca_VentaProductos", "@Max", MaxHits, "@Busqueda", sBusqueda, "@ALMClave", sAlmacen, "@COMClave", ModPOS.CompanyActual, "@Char", cReplace, "@Limitar", ChkLimitar.Checked, "@Servicio", ModificaPrecioServicio)
        Else
            ModPOS.ActualizaGrid(False, Me.GridProductos, "sp_busca_VentaClasProd", "@Class", Tag, "@ALMClave", sAlmacen, "@COMClave", ModPOS.CompanyActual, "@Servicio", ModificaPrecioServicio)
        End If

        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("Descripción").Width = 270
        Me.GridProductos.RootTable.Columns("Exist").Width = 20
        Me.GridProductos.RootTable.Columns("Apart").Width = 20
        Me.GridProductos.RootTable.Columns("Bloq").Width = 20

        Me.GridProductos.RootTable.Columns("Nombre").Width = 60
        Me.GridProductos.RootTable.Columns("ID").Visible = False

        Me.GridProductos.RootTable.Columns("Exist").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Apart").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Bloq").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

    
        bLoad = True

        fechaUltimaVenta()
        obtenerPrecio()

        'Me.GridProductos.CardCaptionPrefix = "Producto:"
        'Me.GridProductos.RootTable.Columns("Clave").CardCaption = True

    End Sub


    Private Sub actGridAplicacion(ByVal MaxHits As Integer, ByVal sAlmacen As String, ByVal sPrecio As String, ByVal iTipoImpuesto As Integer, ByVal sMarca As String, ByVal sModelo As String, ByVal iAño As Integer, ByVal iFamilia As Integer, ByVal iSector As Integer)

        bLoad = False

        ModPOS.ActualizaGrid(False, Me.GridProductos, "sp_busca_aplicacion", "@Max", MaxHits, "@Marca", sMarca, "@Modelo", sModelo, "@Año", iAño, "@Familia", iFamilia, "@Sector", iSector, "@ALMClave", sAlmacen, "@COMClave", ModPOS.CompanyActual)

        Me.GridProductos.RootTable.Columns("Clave").Width = 70
        Me.GridProductos.RootTable.Columns("Descripción").Width = 270
        Me.GridProductos.RootTable.Columns("Exist").Width = 20
        Me.GridProductos.RootTable.Columns("Apart").Width = 20
        Me.GridProductos.RootTable.Columns("Nombre").Width = 60
        Me.GridProductos.RootTable.Columns("ID").Visible = False
        'Me.GridProductos.RootTable.Columns("GTIN").Visible = False
        Me.GridProductos.RootTable.Columns("Exist").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridProductos.RootTable.Columns("Apart").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

      

        bLoad = True

        fechaUltimaVenta()
        obtenerPrecio()
        'Me.GridProductos.CardCaptionPrefix = "Producto:"
        'Me.GridProductos.RootTable.Columns("Clave").CardCaption = True

    End Sub


    Public WriteOnly Property TipoVenta() As Integer
        Set(ByVal value As Integer)
            Tipo = value
        End Set
    End Property

    Public WriteOnly Property ListadePrecio() As String
        Set(ByVal Value As String)
            ListaPrecio = Value
        End Set
    End Property

    Public WriteOnly Property Almacen() As String
        Set(ByVal Value As String)
            ALMClave = Value
        End Set
    End Property

    Public WriteOnly Property StatusVenta() As Boolean
        Set(ByVal Value As Boolean)
            VentaCerrada = Value
        End Set
    End Property

    Public WriteOnly Property PuntodeVenta() As String
        Set(ByVal Value As String)
            PDVClave = Value
        End Set
    End Property

    Public WriteOnly Property ClienteActual() As String
        Set(ByVal Value As String)
            CTEClave = Value
        End Set
    End Property

    Private Sub GridProductos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub FrmBuscaProducto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bError Then
            e.Cancel = True

        End If
    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnAgregar.KeyUp, BtnCancelar.KeyUp, BtnEquivalente.KeyUp, BtnImagen.KeyUp, BtnUbicacion.KeyUp, GridProductos.KeyUp, BtnStock.KeyUp, btnTransito.KeyUp, btnPromocion.KeyUp, btnAplicacion.KeyUp, cmbGrupo.KeyUp, TreeViewClass.KeyUp, TxtMaxHits.KeyUp, btnLista.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F1
                Me.btnLista.PerformClick()
            Case Is = Keys.F9
                Me.BtnAgregar.PerformClick()
            Case Is = Keys.F2
                Me.BtnImagen.PerformClick()
            Case Is = Keys.F3
                Me.BtnUbicacion.PerformClick()
            Case Is = Keys.F4
                Me.BtnEquivalente.PerformClick()
            Case Is = Keys.F6
                Me.BtnStock.PerformClick()
            Case Is = Keys.F7
                Me.btnTransito.PerformClick()
            Case Is = Keys.F8
                Me.btnPromocion.PerformClick()
            Case Is = Keys.F10
                Me.btnAplicacion.PerformClick()

        End Select

    End Sub


    Private Sub FrmBuscaProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        If ModPOS.AplicacionAutomotriz = 0 Then
            Me.btnAplicacion.Visible = False
        End If

        Dim frmstatusmessage As frmStatus = Nothing

        If bMessage = True Then
            frmstatusmessage = New frmStatus
            frmstatusmessage.Show("Estamos haciendo magia...")
        End If

        Me.StartPosition = FormStartPosition.CenterScreen

       

        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "3"
            .llenar()
        End With



        If BusquedaInicial Then
            TxtBuscar.Text = Busqueda
            TxtBuscar.Focus()
            If TxtBuscar.Text <> "" Then
                Me.actGrid(CInt(TxtMaxHits.Text), 0, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
                actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))
            End If
        End If


        If bMessage = True Then
            frmstatusmessage.Close()
        End If

        bLoad = True
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If GridProductos.RowCount > 0 AndAlso Not GridProductos.GetValue(0) Is Nothing Then
            BtnImagen.Enabled = True
            BtnAgregar.Enabled = True
            BtnUbicacion.Enabled = True
            BtnEquivalente.Enabled = True
            BtnStock.Enabled = True

            sProdSelected = GridProductos.GetValue("ID")
            sClave = GridProductos.GetValue("Clave")

            If bLoad = True Then
                fechaUltimaVenta()
                obtenerPrecio()
            End If

        Else
            Me.sProdSelected = ""
            sClave = ""
            Me.BtnImagen.Enabled = False
            Me.BtnAgregar.Enabled = False
            Me.BtnEquivalente.Enabled = False
            Me.BtnUbicacion.Enabled = False
            Me.BtnStock.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not ModPOS.Teclado Is Nothing Then
            ModPOS.Teclado.Close()
        End If
        If VentaCerrada Then
            If bVentaConvencional = False Then
                If Tipo = 1 Then
                    Select Case MessageBox.Show("La venta actual se encuentra cerrada ¿Desea crear un nuevo Ticket?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.Mostradores(numMostrador).btnVentaPerformClick(sClave)
                    End Select
                End If
            Else
                MessageBox.Show("El pedido actual se encuentra cerrado, cree un nuevo pedido para agregar el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            If bVentaConvencional = False Then
                If Tipo = 1 Then
                    bError = ModPOS.Mostradores(numMostrador).AgregaGTIN(sClave, True, True, True)
                End If
            Else
                If Padre = "" Then
                    bError = ModPOS.PreVenta.AgregaGTIN(sClave, True, True, True)
                Else
                    bError = ModPOS.TouchCK.AgregaGTIN(True, sClave, True, True)
                End If
            End If
        End If
        Me.Close()
    End Sub

    Private Sub BtnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagen.Click
        If sProdSelected <> "" Then
            Dim a As FrmPicture = New FrmPicture
            a.url_imagen = Me.url_imagen
            a.ClaveProducto = GridProductos.GetValue("Clave")
            a.NombreProducto = GridProductos.GetValue("Descripción")
            a.PROClave = sProdSelected
            a.btnRemover.Visible = False
            a.btnAgregar.Visible = False
            a.BtnGuardar.Visible = False
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub BtnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbicacion.Click
        If sProdSelected <> "" Then
            Dim a As New FrmConsultaGen
            a.Text = "Localización dentro del Almacén"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_ubcproducto", "@PROClave", sProdSelected, "@ALMClave", ALMClave)
           
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub BtnEquivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEquivalente.Click
        If sProdSelected <> "" Then
            Dim b As New FrmConsultaGen
            b.Text = "Productos Equivalentes"
            ModPOS.ActualizaGrid(False, b.GridConsultaGen, "sp_busca_VentaProductosEquivalentes", "@ALMClave", ALMClave, "@PROClave", sProdSelected)
            b.GridConsultaGen.RootTable.Columns("ID").Visible = False
            b.GridConsultaGen.RootTable.Columns("GTIN").Visible = False
           
            b.ShowDialog()
            b.Dispose()
        End If
    End Sub


    Private Sub BtnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStock.Click
        If sProdSelected <> "" Then
            Dim a As New FrmConsultaGen
            a.Text = "Existencia en Otros Almacenes"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_exist_alm", "@PROClave", sProdSelected, "@ALMClave", ALMClave)
        
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub btnTransito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransito.Click
        If sProdSelected <> "" Then
            Dim a As New FrmConsultaGen
            a.Text = "Existencia en Transito"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_exist_tran", "@PROClave", sProdSelected, "@ALMClave", ALMClave)

            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub btnPromocion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPromocion.Click
        Dim a As New FrmConsultaGen
        a.Text = "Promociones Vigentes"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_filtra_promocion_vigente", "@CTEClave", CTEClave)
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        AbrirTeclado(Me)
    End Sub

    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar

        If dato = "DESHACER" OrElse dato = "" And TxtBuscar.TextLength > 0 Then
            TxtBuscar.Text = TxtBuscar.Text.Remove(TxtBuscar.TextLength - 1, 1)
        Else
            TxtBuscar.Text &= dato
            Clock.Start()
        End If

    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bLoad = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            actGrid(CInt(TxtMaxHits.Text), TreeViewClass.SelectedNode.Tag, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not e.Node.Tag Is Nothing Then
            actGrid(CInt(TxtMaxHits.Text), e.Node.Tag, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
        End If
    End Sub

    Private Sub btnAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAplicacion.Click
        Dim a As New MeFiltroAplicacion
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.actGridAplicacion(CInt(TxtMaxHits.Text), ALMClave, ListaPrecio, TImpuesto, a.Marca, a.Modelo, a.Año, a.Familia, a.Sector)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Clock.Stop()

        If TxtBuscar.Text <> "" Then
            Me.actGrid(CInt(TxtMaxHits.Text), 0, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
        End If
       
    End Sub

    Private Sub btnClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClasificacion.Click
        If bClasVisible = True Then
            'Oculta GrpClass
            bClasVisible = False
            GrpClas.Visible = bClasVisible
            GridProductos.Location = New Point(7, 114)
            GridProductos.Width += 226

        Else
            'Muestra GrpClass
            bClasVisible = True
            GrpClas.Visible = bClasVisible
            GridProductos.Location = New Point(233, 114)
            GridProductos.Width -= 226
            If bClasLoad = False Then
                actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))
                Me.actGrid(CInt(TxtMaxHits.Text), TreeViewClass.TopNode.Tag, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
                bClasLoad = True
            End If
        End If
    End Sub

    Private Sub TxtMaxHits_Leave(sender As Object, e As EventArgs) Handles TxtMaxHits.Leave
        If TxtBuscar.Text <> "" Then
            Me.actGrid(CInt(TxtMaxHits.Text), 0, TxtBuscar.Text, ALMClave, ListaPrecio, TImpuesto)
        End If
    End Sub

    

    Private Sub btnLista_Click(sender As Object, e As EventArgs) Handles btnLista.Click
        If sProdSelected <> "" Then
            Dim a As New FrmConsultaGen
            a.Text = "Listas de Precio"
            a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
            a.GridConsultaGen.GroupByBoxVisible = False
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_muestra_otros_precios", "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClave, "@PROClave", sProdSelected)
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub
End Class
