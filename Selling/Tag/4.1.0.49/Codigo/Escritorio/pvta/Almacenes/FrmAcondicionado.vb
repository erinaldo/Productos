Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAcondicionado
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    Friend WithEvents cmbOrigen As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrden As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecRegistro As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaDestino As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDestino As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaOrigen As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents LblExistencia As System.Windows.Forms.Label
    Friend WithEvents cmbUnidad As Selling.StoreCombo
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabParam As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GridMateriales As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtOrigen As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAcondicionado))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnBuscaDestino = New Janus.Windows.EditControls.UIButton
        Me.TxtDestino = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscaOrigen = New Janus.Windows.EditControls.UIButton
        Me.TxtOrigen = New System.Windows.Forms.TextBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.LblAlmacen = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtEstado = New System.Windows.Forms.TextBox
        Me.TxtOrden = New System.Windows.Forms.TextBox
        Me.TxtFecRegistro = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtnKey = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GridMateriales = New Janus.Windows.GridEX.GridEX
        Me.LblExistencia = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage
        Me.UiTabParam = New Janus.Windows.UI.Tab.UITabPage
        Me.cmbUnidad = New Selling.StoreCombo
        Me.cmbOrigen = New Selling.StoreCombo
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCompania.SuspendLayout()
        Me.UiTabParam.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaDestino)
        Me.GrpGeneral.Controls.Add(Me.TxtDestino)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.BtnBuscaOrigen)
        Me.GrpGeneral.Controls.Add(Me.TxtOrigen)
        Me.GrpGeneral.Controls.Add(Me.PictureBox6)
        Me.GrpGeneral.Controls.Add(Me.cmbOrigen)
        Me.GrpGeneral.Controls.Add(Me.LblAlmacen)
        Me.GrpGeneral.Location = New System.Drawing.Point(8, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(616, 141)
        Me.GrpGeneral.TabIndex = 1
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(8, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 18)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Ubicación Destino"
        '
        'BtnBuscaDestino
        '
        Me.BtnBuscaDestino.Image = CType(resources.GetObject("BtnBuscaDestino.Image"), System.Drawing.Image)
        Me.BtnBuscaDestino.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaDestino.Location = New System.Drawing.Point(309, 95)
        Me.BtnBuscaDestino.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaDestino.Name = "BtnBuscaDestino"
        Me.BtnBuscaDestino.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaDestino.TabIndex = 136
        Me.BtnBuscaDestino.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaDestino.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDestino
        '
        Me.TxtDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestino.Location = New System.Drawing.Point(120, 102)
        Me.TxtDestino.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.Size = New System.Drawing.Size(183, 21)
        Me.TxtDestino.TabIndex = 135
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Ubicación Origen"
        '
        'BtnBuscaOrigen
        '
        Me.BtnBuscaOrigen.Image = CType(resources.GetObject("BtnBuscaOrigen.Image"), System.Drawing.Image)
        Me.BtnBuscaOrigen.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaOrigen.Location = New System.Drawing.Point(309, 50)
        Me.BtnBuscaOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaOrigen.Name = "BtnBuscaOrigen"
        Me.BtnBuscaOrigen.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaOrigen.TabIndex = 132
        Me.BtnBuscaOrigen.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaOrigen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtOrigen
        '
        Me.TxtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrigen.Location = New System.Drawing.Point(120, 57)
        Me.TxtOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtOrigen.Name = "TxtOrigen"
        Me.TxtOrigen.Size = New System.Drawing.Size(183, 21)
        Me.TxtOrigen.TabIndex = 131
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(98, 26)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.TabIndex = 130
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'LblAlmacen
        '
        Me.LblAlmacen.Location = New System.Drawing.Point(8, 26)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(56, 16)
        Me.LblAlmacen.TabIndex = 95
        Me.LblAlmacen.Text = "Almacén"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(597, 551)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(694, 551)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtEstado)
        Me.GroupBox1.Controls.Add(Me.TxtOrden)
        Me.GroupBox1.Controls.Add(Me.TxtFecRegistro)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.BtnKey)
        Me.GroupBox1.Location = New System.Drawing.Point(630, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 141)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'TxtEstado
        '
        Me.TxtEstado.Enabled = False
        Me.TxtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstado.Location = New System.Drawing.Point(13, 74)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.ReadOnly = True
        Me.TxtEstado.Size = New System.Drawing.Size(131, 26)
        Me.TxtEstado.TabIndex = 93
        Me.TxtEstado.Text = "En Captura"
        Me.TxtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtOrden
        '
        Me.TxtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrden.Location = New System.Drawing.Point(13, 46)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(131, 21)
        Me.TxtOrden.TabIndex = 0
        '
        'TxtFecRegistro
        '
        Me.TxtFecRegistro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFecRegistro.Enabled = False
        Me.TxtFecRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecRegistro.Location = New System.Drawing.Point(13, 107)
        Me.TxtFecRegistro.Multiline = True
        Me.TxtFecRegistro.Name = "TxtFecRegistro"
        Me.TxtFecRegistro.ReadOnly = True
        Me.TxtFecRegistro.Size = New System.Drawing.Size(131, 21)
        Me.TxtFecRegistro.TabIndex = 108
        Me.TxtFecRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(78, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 99
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 18)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "FOLIO"
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(114, 15)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(32, 27)
        Me.BtnKey.TabIndex = 114
        Me.BtnKey.ToolTipText = "Genera clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.GrpDetalle.Controls.Add(Me.UiTab1)
        Me.GrpDetalle.Controls.Add(Me.LblExistencia)
        Me.GrpDetalle.Controls.Add(Me.cmbUnidad)
        Me.GrpDetalle.Controls.Add(Me.PictureBox4)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.TxtDescripcion)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtClaveProd)
        Me.GrpDetalle.Location = New System.Drawing.Point(6, 151)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 394)
        Me.GrpDetalle.TabIndex = 3
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'UiTab1
        '
        Me.UiTab1.Location = New System.Drawing.Point(8, 70)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(762, 299)
        Me.UiTab1.TabIndex = 133
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabParam})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(3, 7)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(753, 264)
        Me.GridDetalle.TabIndex = 5
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GridMateriales
        '
        Me.GridMateriales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMateriales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMateriales.ColumnAutoResize = True
        Me.GridMateriales.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMateriales.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMateriales.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridMateriales.Location = New System.Drawing.Point(4, 6)
        Me.GridMateriales.Name = "GridMateriales"
        Me.GridMateriales.RecordNavigator = True
        Me.GridMateriales.Size = New System.Drawing.Size(753, 264)
        Me.GridMateriales.TabIndex = 6
        Me.GridMateriales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblExistencia
        '
        Me.LblExistencia.Location = New System.Drawing.Point(388, 46)
        Me.LblExistencia.Name = "LblExistencia"
        Me.LblExistencia.Size = New System.Drawing.Size(195, 16)
        Me.LblExistencia.TabIndex = 131
        Me.LblExistencia.Text = "Disponible: "
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(361, 46)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 126
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(221, 44)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(137, 20)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 18)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(665, 15)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaProd.TabIndex = 1
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(221, 19)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(439, 21)
        Me.TxtDescripcion.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Prod. Cve."
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(71, 19)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(149, 21)
        Me.TxtClaveProd.TabIndex = 0
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.GridDetalle)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(760, 277)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "Producto Terminado"
        '
        'UiTabParam
        '
        Me.UiTabParam.Controls.Add(Me.GridMateriales)
        Me.UiTabParam.Location = New System.Drawing.Point(1, 21)
        Me.UiTabParam.Name = "UiTabParam"
        Me.UiTabParam.Size = New System.Drawing.Size(760, 277)
        Me.UiTabParam.TabStop = True
        Me.UiTabParam.Text = "Materiales"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.Location = New System.Drawing.Point(71, 43)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(149, 21)
        Me.cmbUnidad.TabIndex = 127
        '
        'cmbOrigen
        '
        Me.cmbOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOrigen.Location = New System.Drawing.Point(120, 23)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(402, 21)
        Me.cmbOrigen.TabIndex = 128
        '
        'FrmAcondicionado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FrmAcondicionado"
        Me.Text = "Acondicionado"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCompania.ResumeLayout(False)
        Me.UiTabParam.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public FormPadre As String = ""
    Public ACOClave As String
    Public Folio As String
    Public ALMClave As String
    Public SUCClave As String
    Public UBCOrigen, UBCDestino As String

    Public Tipo As Integer
    Public Motivo As Integer
    Public FecRegistro As DateTime
    Public DescripcionEstado As String
    Public Autorizo As String = ""
    Public Nombre As String
    Public Notas As String = ""
    Public Estado As Integer = 1
    Public EstadoActual As Integer


    Private dtDetalle As DataTable
    Private bLoad As Boolean = False
    Private PROClave As String
    Private TProducto As Integer
    Private Cantidad As Double
    Private Clave As String
    Private Costo As Double
    Private NumDecimales As Integer
    Private Disponible As Double
    Private Autoriza As String
    Private TallaColor As Integer = 0
    Private alerta(5) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtOrden.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Me.cmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If GridDetalle.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub BtnKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "DigitoOrd", "@COMClave", ModPOS.CompanyActual)
        Dim len As Integer = CInt(dt.Rows(0)("Valor"))
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_calcula_acoclave", "@ALMClave", ALMClave, "@len", len)

        TxtOrden.Text = dt.Rows(0)("Clave")
        dt.Dispose()

    End Sub

    Private Sub FrmAcondicionado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox6


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With cmbOrigen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With



        bLoad = True

        If Padre = "Nuevo" Then
            Me.TxtFecRegistro.Text = DateTime.Now.ToShortDateString 'ToString("MMMM dd, yyyy")
            dtDetalle = ModPOS.CrearTabla("AcondicionadoDetalle", _
                                          "ID", "System.String", _
                                          "PROClave", "System.String", _
                                          "TProducto", "System.Int32", _
                                          "Costo", "System.Double", _
                                          "Total", "System.Double", _
                                          "Cantidad", "System.Double", _
                                          "Clave", "System.String", _
                                          "Nombre", "System.String")
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("Total").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"

        Else
            Me.TxtOrden.Text = Folio
            TxtOrden.Enabled = False

            TxtEstado.Text = DescripcionEstado
            Me.TxtFecRegistro.Text = FecRegistro.ToShortDateString

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_acondicionado", "@ACOClave", ACOClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("Total").Visible = False
            GridDetalle.CurrentTable.Columns("Clave").Selectable = False
            GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"

        End If

        cmbOrigen.SelectedValue = ALMClave

        EstadoActual = Estado
        If EstadoActual = 2 Then
            Me.cmbOrigen.Enabled = False
            Me.cmbUnidad.Enabled = False

            Me.TxtCantidad.Enabled = False
            Me.TxtClaveProd.Enabled = False
            Me.BtnKey.Enabled = False
            Me.BtnGuardar.Enabled = False
            Me.BtnBuscaProd.Enabled = False


        End If
    End Sub

    Private Sub FrmAcondicionado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If FormPadre = "" AndAlso Not ModPOS.MtoAcondicionado Is Nothing Then

            If Not ModPOS.MtoAcondicionado.CmbAlmacen.SelectedValue Is Nothing AndAlso ModPOS.MtoAcondicionado.Periodo > 0 AndAlso ModPOS.MtoAcondicionado.Mes > 0 Then
                ModPOS.MtoAcondicionado.refrescaGrid()
            End If

        End If
        ModPOS.Acondicionado.Dispose()
        ModPOS.Acondicionado = Nothing
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
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
            TxtClaveProd.Text = a.valor
            TxtDescripcion.Text = a.Descripcion
            recuperaProducto(a.valor)
            TxtCantidad.Focus()
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtClaveProd.Text) Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de producto y Tipo de documento son Requeridos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            If TallaColor = 1 Then
                a.ProcedimientoAlmacenado = "st_search_producto_tc"
                a.CampoCmb = "FiltroTC"
            Else
                a.ProcedimientoAlmacenado = "sp_search_producto"
                a.CampoCmb = "Filtro"
            End If
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)


            End If
            a.Dispose()

        End If
    End Sub

    Private Sub recuperaProducto(ByVal sClave As String)

        If UBCDestino = "" OrElse UBCOrigen = "" OrElse cmbOrigen.SelectedValue Is Nothing Then
            MessageBox.Show("Las ubicaciones de almacén son requeridas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            PROClave = ""
            TProducto = 0
            Cantidad = 0
            Clave = ""
            Costo = 0
            Disponible = 0
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = ""
            LblExistencia.Text = "Existencia: " & CStr(Disponible)
            Exit Sub
        End If


        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

            PROClave = dtProducto.Rows(0)("PROClave")
            TProducto = dtProducto.Rows(0)("TProducto")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            Costo = dtProducto.Rows(0)("Costo")

            NumDecimales = dtProducto.Rows(0)("Num_Decimales")

            dtProducto.Dispose()


            dtProducto = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", PROClave, "@ALMClave", ALMClave)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                Disponible = dtProducto.Rows(0)("Disponible")
                dtProducto.Dispose()
            Else
                Disponible = 0
            End If


            LblExistencia.Text = "Existencia: " & CStr(Disponible)

            Me.TxtDescripcion.Text = Nombre

            TxtCantidad.DecimalDigits = NumDecimales

            TxtClaveProd.Text = Clave

            TxtCantidad.Focus()

            With Me.cmbUnidad
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_unidad_vta"
                .NombreParametro1 = "PROClave"
                .Parametro1 = PROClave
                .llenar()
            End With

        Else
            PROClave = ""
            TProducto = 0
            Cantidad = 0
            Clave = ""
            Costo = 0
            Disponible = 0
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = ""
            LblExistencia.Text = "Existencia: " & CStr(Disponible)
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            If Not cmbUnidad.SelectedValue Is Nothing Then
                Cantidad = CDbl(cmbUnidad.SelectedValue) * Cantidad
            End If
            If System.String.IsNullOrEmpty(PROClave) Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else



                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("PROClave Like '" & PROClave & "'")

                If foundRows.Length = 0 Then
                    If Cantidad > 0 Then
                        Dim row1 As DataRow
                        row1 = dtDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("ID") = ModPOS.obtenerLlave
                        row1.Item("PROClave") = PROClave
                        row1.Item("TProducto") = TProducto
                        row1.Item("Cantidad") = Cantidad
                        row1.Item("Costo") = Costo
                        row1.Item("Total") = Cantidad * Costo
                        row1.Item("Clave") = Clave
                        row1.Item("Nombre") = Nombre
                        dtDetalle.Rows.Add(row1)
                        'agrega la fila completo a la tabla

                        cmbOrigen.Enabled = False
                        TxtDestino.Enabled = False
                        TxtOrigen.Enabled = False
                        BtnBuscaOrigen.Enabled = False
                        BtnBuscaDestino.Enabled = False

                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        TProducto = 0
                        Cantidad = 0
                        Costo = 0
                        Clave = ""
                        Nombre = ""
                        LblExistencia.Text = "Existencia:"
                        TxtClaveProd.Focus()
                    Else
                        MessageBox.Show("¡La Cantidad de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                ElseIf Cantidad = 0 Then
                    'Elimina
                    dtDetalle.Rows.Remove(foundRows(0))

                    TxtClaveProd.Text = ""
                    TxtDescripcion.Text = ""
                    TxtCantidad.Text = 0
                    PROClave = ""
                    TProducto = 0
                    Cantidad = 0
                    Costo = 0
                    Clave = ""
                    Nombre = ""
                    LblExistencia.Text = "Existencia:"
                    TxtClaveProd.Focus()

                    If dtDetalle.Rows.Count = 0 Then
                        cmbOrigen.Enabled = True
                        TxtDestino.Enabled = True
                        TxtOrigen.Enabled = True
                        BtnBuscaOrigen.Enabled = True
                        BtnBuscaDestino.Enabled = True

                    End If

                ElseIf Cantidad <> foundRows(0)("Cantidad") Then
                    'actualiza
                    foundRows(0)("Cantidad") = Cantidad
                    foundRows(0)("Total") = Costo * Cantidad
                    TxtClaveProd.Text = ""
                    TxtDescripcion.Text = ""
                    TxtCantidad.Text = 0
                    PROClave = ""
                    TProducto = 0
                    Cantidad = 0
                    Costo = 0
                    Clave = ""
                    Nombre = ""
                    LblExistencia.Text = "Existencia:"
                    TxtClaveProd.Focus()
                End If
            End If
        End If
    End Sub
  
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            ALMClave = cmbOrigen.SelectedValue



            If GridDetalle.RowCount > 0 Then

                If EstadoActual = 1 Then
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autorizo = a.cmbAutoriza.SelectedValue
                            Autoriza = a.Autoriza

                            Dim dtmsg As DataTable
                            dtmsg = Recupera_Tabla("sp_recupera_valorref", "@tabla", "MOVALM", "@campo", "Estado", "@estado", EstadoActual)
                            TxtEstado.Text = dtmsg.Rows(0)("Descripcion")
                            dtmsg.Dispose()
                        End If
                    End If
                    a.Dispose()
                End If

                If Padre = "Nuevo" Then

                    Folio = TxtOrden.Text.Trim.ToUpper

                    ACOClave = ModPOS.obtenerLlave

                    ModPOS.Ejecuta("sp_crea_acondicionado", _
                                "@MVAClave", ACOClave, _
                                "@ALMClave", ALMClave, _
                                "@Tipo", Tipo, _
                                "@Motivo", Motivo, _
                                                    "@Folio", Folio, _
                                "@FechaRegistro", Today, _
                                "@Registro", ModPOS.UsuarioActual, _
                                "@Autorizo", Autorizo, _
                                "@Notas", Notas, _
                                "@Estado", EstadoActual, _
                                "@Usuario", ModPOS.UsuarioActual)

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1

                        ModPOS.Ejecuta("sp_inserta_detalletransferencia", _
                        "@DMVAClave", dtDetalle.Rows(fila)("ID"), _
                        "@MVAClave", ACOClave, _
                        "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                        "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                        "@Costo", dtDetalle.Rows(fila)("Costo"), _
                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                        "@fila", fila + 1)
                    Next

                 
                    If (EstadoActual = 2 OrElse EstadoActual = 4) AndAlso Estado = 1 Then
                        If Tipo = 3 Then
                            ModPOS.GeneraMovInv(2, 8, 6, ACOClave, ALMClave, Folio, Autoriza, False)
                        Else
                            ModPOS.GeneraMovInv(Tipo, 8, 6, ACOClave, ALMClave, Folio, Autoriza, False)
                        End If
                        Estado = EstadoActual
                    End If

                    Padre = "Modificar"

                Else
                    If Estado = 1 Then
                        If Not (Estado = EstadoActual) Then


                            ModPOS.Ejecuta("sp_actualiza_transferencia", _
                                                 "@MVAClave", ACOClave, _
                                                 "@Tipo", Tipo, _
                                                 "@Motivo", Motivo, _
                                                 "@Autorizo", Autorizo, _
                                                 "@Notas", Notas, _
                                                 "@Estado", EstadoActual, _
                                                 "@Usuario", ModPOS.UsuarioActual)

                        End If

                        ModPOS.Ejecuta("sp_elimina_transferenciaDet", "@MVAClave", ACOClave)

                        Dim fila As Integer

                        For fila = 0 To dtDetalle.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_detalletransferencia", _
                            "@DMVAClave", dtDetalle.Rows(fila)("ID"), _
                            "@MVAClave", ACOClave, _
                            "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                            "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                            "@Costo", dtDetalle.Rows(fila)("Costo"), _
                            "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                            "@fila", fila + 1)
                        Next

                      
                    ElseIf (EstadoActual = 2 OrElse EstadoActual = 4) AndAlso Estado = 1 Then
                        If Tipo = 3 Then
                            ModPOS.GeneraMovInv(2, 8, 6, ACOClave, ALMClave, Folio, Autoriza, False)
                        Else
                            ModPOS.GeneraMovInv(Tipo, 8, 6, ACOClave, ALMClave, Folio, Autoriza, False)
                        End If
                        Estado = EstadoActual
                    End If
                End If


                If MessageBox.Show("¿Desea Imprimir Transferencia?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    imprimirTransferencia()
                End If

            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub imprimirTransferencia()
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", ACOClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", ACOClave))
        OpenReport.PrintPreview("Transferencia de Almacén", "CRTransferencia.rpt", pvtaDataSet, "")
    End Sub

    Private Sub leeUbcOrigen(ByVal Codigo As String, ByVal UBC As String)

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            If UBC = "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", cmbOrigen.SelectedValue, "@Ubicacion", Codigo)

                If dt.Rows.Count > 0 Then
                    UBCOrigen = dt.Rows(0)("UBCClave")
                Else
                    UBCOrigen = ""
                    TxtOrigen.Text = ""
                    Beep()
                    MessageBox.Show("La Clave o Código de Barras no registrada o esta inactiva en el almacén seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                UBCOrigen = UBC
                TxtOrigen.Text = Codigo
            End If

        Else
            UBCOrigen = ""
            TxtOrigen.Text = ""
            Beep()
            MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub leeUbcDestino(ByVal Codigo As String, ByVal UBC As String)

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            If UBC = "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", cmbOrigen.SelectedValue, "@Ubicacion", Codigo)

                If dt.Rows.Count > 0 Then
                    UBCDestino = dt.Rows(0)("UBCClave")
                Else
                    UBCDestino = ""
                    TxtDestino.Text = ""
                    Beep()
                    MessageBox.Show("La Clave o Código de Barras no registrada o esta inactiva en el almacén seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                UBCDestino = UBC
                TxtDestino.Text = Codigo
            End If

        Else
            UBCDestino = ""
            TxtDestino.Text = ""
            Beep()
            MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnBuscaOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaOrigen.Click
        Dim a As New MeSearch
        If Not cmbOrigen.SelectedValue Is Nothing Then
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = cmbOrigen.SelectedValue
            a.OcultaCol = True
            a.OcultaColNum = 0
        Else
            MessageBox.Show("¡El Almacén no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        a.NumColDes = 1
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If Not cmbOrigen.SelectedValue Is Nothing Then

                leeUbcOrigen(a.Descripcion, a.valor)
            Else
                UBCOrigen = ""
                TxtOrden.Text = ""
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
        a.Dispose()

    End Sub

    Private Sub BtnBuscaDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaDestino.Click
        Dim a As New MeSearch
        If Not cmbOrigen.SelectedValue Is Nothing Then
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = cmbOrigen.SelectedValue
            a.OcultaCol = True
            a.OcultaColNum = 0
        Else
            MessageBox.Show("¡El Almacén no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        a.NumColDes = 1
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If Not cmbOrigen.SelectedValue Is Nothing Then

                leeUbcDestino(a.Descripcion, a.valor)
            Else
                UBCDestino = ""
                TxtDestino.Text = ""
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
        a.Dispose()


    End Sub

End Class
