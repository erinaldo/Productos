Public Class FrmDescuento
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
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClass As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents ChkCascada As Selling.ChkStatus
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbAplicacion As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumUPDGerarquia As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbNivel As Selling.StoreCombo
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDescuentos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescuento))
        Me.GrpClass = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbNivel = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NumUPDGerarquia = New System.Windows.Forms.NumericUpDown()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.cmbAplicacion = New Selling.StoreCombo()
        Me.ChkCascada = New Selling.ChkStatus(Me.components)
        Me.cmbTipo = New Selling.StoreCombo()
        Me.LblFactura = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GridDescuentos = New Janus.Windows.GridEX.GridEX()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpClass.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUPDGerarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClass
        '
        Me.GrpClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClass.Controls.Add(Me.PictureBox5)
        Me.GrpClass.Controls.Add(Me.PictureBox4)
        Me.GrpClass.Controls.Add(Me.PictureBox3)
        Me.GrpClass.Controls.Add(Me.PictureBox2)
        Me.GrpClass.Controls.Add(Me.cmbNivel)
        Me.GrpClass.Controls.Add(Me.Label1)
        Me.GrpClass.Controls.Add(Me.cmbTipoCanal)
        Me.GrpClass.Controls.Add(Me.LblDestino)
        Me.GrpClass.Controls.Add(Me.PictureBox1)
        Me.GrpClass.Controls.Add(Me.NumUPDGerarquia)
        Me.GrpClass.Controls.Add(Me.LblTipo)
        Me.GrpClass.Controls.Add(Me.cmbAplicacion)
        Me.GrpClass.Controls.Add(Me.ChkCascada)
        Me.GrpClass.Controls.Add(Me.cmbTipo)
        Me.GrpClass.Controls.Add(Me.LblFactura)
        Me.GrpClass.Controls.Add(Me.ChkEstado)
        Me.GrpClass.Controls.Add(Me.TxtNombre)
        Me.GrpClass.Controls.Add(Me.LblNombre)
        Me.GrpClass.Controls.Add(Me.Label7)
        Me.GrpClass.Location = New System.Drawing.Point(7, 7)
        Me.GrpClass.Name = "GrpClass"
        Me.GrpClass.Size = New System.Drawing.Size(778, 192)
        Me.GrpClass.TabIndex = 1
        Me.GrpClass.TabStop = False
        Me.GrpClass.Text = "Configuración "
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(629, 131)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox5.TabIndex = 143
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(335, 103)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox4.TabIndex = 142
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(335, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox3.TabIndex = 141
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(335, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox2.TabIndex = 140
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbNivel
        '
        Me.cmbNivel.Location = New System.Drawing.Point(111, 73)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(211, 21)
        Me.cmbNivel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Nivel"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.Location = New System.Drawing.Point(111, 17)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipoCanal.TabIndex = 2
        '
        'LblDestino
        '
        Me.LblDestino.Location = New System.Drawing.Point(13, 20)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(82, 16)
        Me.LblDestino.TabIndex = 136
        Me.LblDestino.Text = "Canal de Venta"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(335, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox1.TabIndex = 135
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'NumUPDGerarquia
        '
        Me.NumUPDGerarquia.Enabled = False
        Me.NumUPDGerarquia.Location = New System.Drawing.Point(111, 158)
        'Me.NumUPDGerarquia.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumUPDGerarquia.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumUPDGerarquia.Name = "NumUPDGerarquia"
        Me.NumUPDGerarquia.Size = New System.Drawing.Size(80, 20)
        Me.NumUPDGerarquia.TabIndex = 6
        Me.NumUPDGerarquia.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(13, 48)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(80, 15)
        Me.LblTipo.TabIndex = 72
        Me.LblTipo.Text = "Tipo"
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.Location = New System.Drawing.Point(111, 102)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(211, 21)
        Me.cmbAplicacion.TabIndex = 5
        '
        'ChkCascada
        '
        Me.ChkCascada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCascada.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkCascada.Checked = True
        Me.ChkCascada.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCascada.Location = New System.Drawing.Point(214, 156)
        Me.ChkCascada.Name = "ChkCascada"
        Me.ChkCascada.Size = New System.Drawing.Size(108, 22)
        Me.ChkCascada.TabIndex = 7
        Me.ChkCascada.Text = "Aplica Cascada"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(111, 45)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'LblFactura
        '
        Me.LblFactura.Location = New System.Drawing.Point(13, 108)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(87, 15)
        Me.LblFactura.TabIndex = 62
        Me.LblFactura.Text = "Tipo Aplicación"
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(566, 17)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(57, 22)
        Me.ChkEstado.TabIndex = 8
        Me.ChkEstado.Text = "Activo"
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(111, 130)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(512, 20)
        Me.TxtNombre.TabIndex = 4
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 135)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(13, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 16)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Jerarquía"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 481)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 9
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 481)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.btnAgregar)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtMaxHits)
        Me.GrpDetalle.Controls.Add(Me.CmbCampo)
        Me.GrpDetalle.Controls.Add(Me.TxtBuscar)
        Me.GrpDetalle.Controls.Add(Me.BtnModificar)
        Me.GrpDetalle.Controls.Add(Me.BtnEliminar)
        Me.GrpDetalle.Controls.Add(Me.GridDescuentos)
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 205)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 266)
        Me.GrpDetalle.TabIndex = 148
        Me.GrpDetalle.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(688, 44)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(84, 30)
        Me.btnAgregar.TabIndex = 151
        Me.btnAgregar.Text = "&Vigencia"
        Me.btnAgregar.ToolTipText = "Agregar vigencia de descuento"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(583, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(715, 16)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 20)
        Me.TxtMaxHits.TabIndex = 149
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(8, 16)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 148
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(179, 16)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(335, 20)
        Me.TxtBuscar.TabIndex = 147
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(688, 80)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(82, 29)
        Me.BtnModificar.TabIndex = 5
        Me.BtnModificar.Text = "&Descuento"
        Me.BtnModificar.ToolTipText = "Modifica la vigencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(688, 115)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(82, 30)
        Me.BtnEliminar.TabIndex = 9
        Me.BtnEliminar.Text = "&Eliminar "
        Me.BtnEliminar.ToolTipText = "Elimina la vigencia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDescuentos
        '
        Me.GridDescuentos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDescuentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDescuentos.ColumnAutoResize = True
        Me.GridDescuentos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDescuentos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDescuentos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDescuentos.Location = New System.Drawing.Point(8, 43)
        Me.GridDescuentos.Name = "GridDescuentos"
        Me.GridDescuentos.RecordNavigator = True
        Me.GridDescuentos.Size = New System.Drawing.Size(674, 217)
        Me.GridDescuentos.TabIndex = 1
        Me.GridDescuentos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmDescuento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpClass)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmDescuento"
        Me.Text = "Descuento"
        Me.GrpClass.ResumeLayout(False)
        Me.GrpClass.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUPDGerarquia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public DESClave As String = ""
    Public Clave As String
    Public Nombre As String
    Public Tipo As Integer = 1
    Public TipoCanal As Integer
    Public Nivel As Integer = 1
    Public Cascada As Integer
    Public Estado As Integer = 1
    Public TipoAplicacion As Integer = 1
    Public Jerarquia As Integer = 1
    Private sId As String
    Private TallaColor As Integer = 0
    Private dt As DataTable
    Private alerta(4) As PictureBox
    Private reloj As parpadea
    Private bCargado As Boolean = False


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbTipoCanal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbNivel.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_descuento", "@COMClave", ModPOS.CompanyActual, "@Canal", cmbTipoCanal.SelectedValue, "@Tipo", cmbTipo.SelectedValue, "@Nivel", cmbNivel.SelectedValue, "@Aplicacion", cmbAplicacion.SelectedValue) > 0 Then
                Beep()
                MessageBox.Show("La política de descuento que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub FrmDescuento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()


        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With

        cmbTipoCanal.SelectedValue = TipoCanal

        With cmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Descuento"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        cmbTipo.SelectedValue = Tipo

        If Not cmbTipo.SelectedValue Is Nothing Then
            With Me.cmbNivel
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_nivel_desc"
                .NombreParametro1 = "Tipo"
                .Parametro1 = cmbTipo.SelectedValue
                .llenar()
            End With
        End If

        cmbNivel.SelectedValue = Nivel

        With cmbAplicacion
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Descuento"
            .NombreParametro2 = "campo"
            .Parametro2 = "Aplicacion"
            .llenar()
        End With

        cmbAplicacion.SelectedValue = TipoAplicacion

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        bCargado = True

        
        TxtNombre.Text = Nombre
        ChkEstado.Estado = Estado
        ChkCascada.Estado = Math.Abs(Cascada)
        NumUPDGerarquia.Value = Jerarquia


        If Padre = "Agregar" Then
            GrpDetalle.Enabled = False
            DESClave = ModPOS.obtenerLlave
        Else
            cmbTipoCanal.Enabled = False
            cmbTipo.Enabled = False
            cmbNivel.Enabled = False
            cmbAplicacion.Enabled = False
        End If

        If Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, DESClave, cmbNivel.SelectedValue)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmDescuento_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.DesCte.Dispose()
        ModPOS.DesCte = Nothing
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"
                    DESClave = ModPOS.obtenerLlave
                    TipoCanal = cmbTipoCanal.SelectedValue
                    Tipo = cmbTipo.SelectedValue
                    Nivel = cmbNivel.SelectedValue
                    Nombre = TxtNombre.Text.Trim.ToUpper
                    TipoAplicacion = cmbAplicacion.SelectedValue
                    Jerarquia = NumUPDGerarquia.Value
                    Cascada = ChkCascada.GetEstado

                    Dim dtValor As DataTable
                    dtValor = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Descuento", "@Campo", "Tipo", "@Valor", Tipo)

                    If dtValor.Rows.Count > 0 Then
                        Clave = dtValor.Rows(0)("Clave")
                    End If
                    dtValor.Dispose()


                    ModPOS.Ejecuta("sp_inserta_descuento", _
                    "@DESClave", DESClave, _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@TipoCanal", TipoCanal, _
                    "@Tipo", Tipo, _
                    "@Nivel", Nivel, _
                    "@Clave", Clave, _
                    "@Nombre", Nombre, _
                    "@TipoAplicacion", TipoAplicacion, _
                    "@Jerarquia", Jerarquia, _
                    "@Cascada", Cascada, _
                    "@Usuario", ModPOS.UsuarioActual)


                    Padre = "Modificar"
                    GrpDetalle.Enabled = True



                    If Not ModPOS.MtoDesCte Is Nothing Then
                        ModPOS.ActualizaGrid(True, MtoDesCte.GridDescuentos, "sp_muestra_descuentos", "@COMClave", ModPOS.CompanyActual)
                        MtoDesCte.GridDescuentos.RootTable.Columns("ID").Visible = False
                    End If


                Case "Modificar"
                    If Not (Nombre = TxtNombre.Text.Trim.ToUpper AndAlso _
                        Cascada = ChkCascada.GetEstado AndAlso _
                        Jerarquia = NumUPDGerarquia.Value AndAlso _
                        Estado = ChkEstado.GetEstado) Then


                        Nombre = TxtNombre.Text.Trim.ToUpper
                        Cascada = ChkCascada.GetEstado
                        Estado = ChkEstado.GetEstado
                        Jerarquia = NumUPDGerarquia.Value


                        ModPOS.Ejecuta("sp_actualiza_descuento", _
                                    "@DESClave", DESClave, _
                                    "@Nombre", Nombre, _
                                    "@Cascada", Cascada, _
                                    "@Estado", Estado, _
                                    "@Jerarquia", Jerarquia, _
                                    "@Usuario", ModPOS.UsuarioActual)





                        If Not ModPOS.MtoDesCte Is Nothing Then
                            ModPOS.ActualizaGrid(True, MtoDesCte.GridDescuentos, "sp_muestra_descuentos", "@COMClave", ModPOS.CompanyActual)
                            MtoDesCte.GridDescuentos.RootTable.Columns("ID").Visible = False
                        End If

                    End If


                    Me.Close()


            End Select



        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub cmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedValueChanged
        If bCargado = True AndAlso Not cmbTipo.SelectedValue Is Nothing Then
            With Me.cmbNivel
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_nivel_desc"
                .NombreParametro1 = "Tipo"
                .Parametro1 = cmbTipo.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub actGrid(ByVal MaxHits As Integer, ByVal iCampo As Integer, ByVal sBusqueda As String, ByVal sDESClave As String, ByVal iNivel As Integer)
        Clock.Stop()

        If bCargado Then

            If Not dt Is Nothing Then
                dt.Dispose()
            End If

            dt = ModPOS.Recupera_Tabla("sp_muestra_detalledesc", "@Max", MaxHits, "@Campo", iCampo, "@Busqueda", sBusqueda, "@DESClave", sDESClave, "@Nivel", iNivel, "@Char", cReplace)

            GridDescuentos.DataSource = dt
            GridDescuentos.RetrieveStructure(True)
            GridDescuentos.GroupByBoxVisible = False
            GridDescuentos.RootTable.Columns("Id").Visible = False
            GridDescuentos.RootTable.Columns("Importe").Width = 40

            Select Case iNivel
                Case 1, 9 ' Cliente\Material
                    GridDescuentos.RootTable.Columns("PROClave").Visible = False
                    GridDescuentos.RootTable.Columns("Material").Width = 60

                    GridDescuentos.RootTable.Columns("CTEClave").Visible = False
                    GridDescuentos.RootTable.Columns("Cliente").Width = 60

                Case 2, 5 'Cliente\Grupo
                    GridDescuentos.RootTable.Columns("GrupoMaterial").Visible = False
                    GridDescuentos.RootTable.Columns("Grupo").Width = 60

                    GridDescuentos.RootTable.Columns("CTEClave").Visible = False
                    GridDescuentos.RootTable.Columns("Cliente").Width = 60
                Case 3, 10 'Material
                    GridDescuentos.RootTable.Columns("PROClave").Visible = False
                    GridDescuentos.RootTable.Columns("Material").Width = 60

                Case Is = 4 ' Descuento\Material
                    GridDescuentos.RootTable.Columns("DescuentoDirecto").Visible = False
                    GridDescuentos.RootTable.Columns("Descuento").Width = 60

                    GridDescuentos.RootTable.Columns("PROClave").Visible = False
                    GridDescuentos.RootTable.Columns("Material").Width = 60

                Case 6, 11 ' Sector\Descuento
                    GridDescuentos.RootTable.Columns("DescuentoDirecto").Visible = False
                    GridDescuentos.RootTable.Columns("Descuento").Width = 60


                    GridDescuentos.RootTable.Columns("TipoSector").Visible = False
                    GridDescuentos.RootTable.Columns("Sector").Width = 60

                Case 7, 12 'Grupo\Descuento
                    GridDescuentos.RootTable.Columns("GrupoMaterial").Visible = False
                    GridDescuentos.RootTable.Columns("Grupo").Width = 60

                    GridDescuentos.RootTable.Columns("DescuentoDirecto").Visible = False
                    GridDescuentos.RootTable.Columns("Descuento").Width = 60


                Case Is = 8 ' Grupo

                    GridDescuentos.RootTable.Columns("GrupoMaterial").Visible = False
                    GridDescuentos.RootTable.Columns("Grupo").Width = 60

                Case Is = 13 'Sector y Desuento postventa
                    GridDescuentos.RootTable.Columns("TipoSector").Visible = False
                    GridDescuentos.RootTable.Columns("Sector").Width = 60
                    GridDescuentos.RootTable.Columns("DescuentoPostVenta").Visible = False
                    GridDescuentos.RootTable.Columns("Descuento").Width = 60

                Case Is = 14 'Desuento postventa
                    GridDescuentos.RootTable.Columns("DescuentoPostVenta").Visible = False
                    GridDescuentos.RootTable.Columns("Descuento").Width = 60
            End Select


            Select Case iNivel
                Case 1, 3, 4, 9, 10
                    CmbCampo.Enabled = True
                    TxtBuscar.Enabled = True
                    TxtMaxHits.Enabled = True
                Case Else
                    CmbCampo.Enabled = False
                    TxtBuscar.Enabled = False
                    TxtMaxHits.Enabled = False
            End Select



        End If

    End Sub

    Private Sub CmbCampo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCampo.SelectedValueChanged
        If Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, DESClave, cmbNivel.SelectedValue)
            End If
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub TxtBuscar_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.Leave
        Clock.Stop()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, DESClave, cmbNivel.SelectedValue)
        End If
    End Sub

    Public Sub modificaDescuento()
        If Not cmbTipo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            If sId <> "" Then
                If ModPOS.ModDescuento Is Nothing Then
                    ModPOS.ModDescuento = New FrmModDescuento
                    With ModPOS.ModDescuento
                        .TipoCanal = cmbTipoCanal.SelectedValue
                        .TallaColor = TallaColor
                        .Text = "Modificar Vigencia de Descuento"
                        .Padre = "Modificar"
                        .DESClave = Me.DESClave
                        .Tipo = cmbTipo.SelectedValue
                        .Nivel = cmbNivel.SelectedValue
                        .Id = GridDescuentos.GetValue("Id")

                        Select Case CInt(cmbNivel.SelectedValue)
                            Case 1, 9 ' Cliente\Material
                                .Cliente = GridDescuentos.GetValue("Cliente")
                                .Producto = GridDescuentos.GetValue("Material")

                            Case 2, 5 'Cliente\Grupo
                                .Cliente = GridDescuentos.GetValue("Cliente")
                                .GrupoMaterial = GridDescuentos.GetValue("GrupoMaterial")

                            Case 3, 10 'Material
                                .Producto = GridDescuentos.GetValue("Material")

                            Case Is = 4 ' Descuento\Material
                                .DescuentoDirecto = GridDescuentos.GetValue("DescuentoDirecto")
                                .Producto = GridDescuentos.GetValue("Material")

                            Case 6, 11 ' Sector\Descuento
                                .DescuentoDirecto = GridDescuentos.GetValue("DescuentoDirecto")
                                .TipoSector = GridDescuentos.GetValue("TipoSector")

                            Case 7, 12 'Grupo\Descuento
                                .GrupoMaterial = GridDescuentos.GetValue("GrupoMaterial")
                                .DescuentoDirecto = GridDescuentos.GetValue("DescuentoDirecto")

                            Case Is = 8 ' Grupo
                                .GrupoMaterial = GridDescuentos.GetValue("GrupoMaterial")

                            Case Is = 13 'Sector\Postventa
                                .TipoSector = GridDescuentos.GetValue("TipoSector")
                                .DescuentoDirecto = GridDescuentos.GetValue("DescuentoPostVenta")

                            Case Is = 14 ' Postventa 
                                .DescuentoDirecto = GridDescuentos.GetValue("DescuentoPostVenta")

                        End Select

                        If CInt(cmbTipo.SelectedValue) = 2 Then
                            .RangoFinal = GridDescuentos.GetValue("RangoFinal")
                            .RangoInicial = GridDescuentos.GetValue("RangoInicial")
                        End If

                        .Inicio = GridDescuentos.GetValue("Inicio")
                        .Fin = GridDescuentos.GetValue("Fin")
                        .Importe = GridDescuentos.GetValue("Importe")
                        .StartPosition = FormStartPosition.CenterScreen

                    End With
                End If
                ModPOS.ModDescuento.StartPosition = FormStartPosition.CenterScreen
                ModPOS.ModDescuento.Show()
                ModPOS.ModDescuento.BringToFront()

            End If
        Else
            MessageBox.Show("Debe seleccionar un Tipo y Nivel valido", "Invormación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Not cmbTipo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            If ModPOS.ModDescuento Is Nothing Then
                ModPOS.ModDescuento = New FrmModDescuento
                With ModPOS.ModDescuento
                    .TipoCanal = cmbTipoCanal.SelectedValue
                    .TallaColor = TallaColor
                    .DESClave = Me.DESClave
                    .Text = "Agregar Nueva Vigencia de Descuento"
                    .Padre = "Nuevo"
                    .Tipo = cmbTipo.SelectedValue
                    .Nivel = cmbNivel.SelectedValue
                    .StartPosition = FormStartPosition.CenterScreen
                End With
            End If
            ModPOS.ModDescuento.StartPosition = FormStartPosition.CenterScreen
            ModPOS.ModDescuento.Show()
            ModPOS.ModDescuento.BringToFront()
        Else
            MessageBox.Show("Debe seleccionar un Tipo y Nivel valido", "Invormación", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmbNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedValueChanged
        If bCargado = True AndAlso Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbNivel.SelectedValue Is Nothing Then
            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, DESClave, cmbNivel.SelectedValue)
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If sId <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la vigencia seleccionada de la política de descuentos actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_desdet", "@Id", sId, "@DESClave", DESClave)

                    Dim foundRows() As System.Data.DataRow

                    foundRows = dt.Select("Id = '" & sId & "'")

                    If foundRows.GetLength(0) > 0 Then
                        dt.Rows.Remove(foundRows(0))
                    End If




            End Select
        End If

    End Sub

    Private Sub GridDescuentos_DoubleClick(sender As Object, e As EventArgs) Handles GridDescuentos.DoubleClick
        modificaDescuento()
    End Sub

    Private Sub GridDescuentos_SelectionChanged(sender As Object, e As EventArgs) Handles GridDescuentos.SelectionChanged
        If Not GridDescuentos.GetValue(0) Is Nothing AndAlso Not GridDescuentos.GetValue(0).GetType.Name = "DBNull" Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sId = GridDescuentos.GetValue("Id")
        Else
            BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.sId = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        Me.modificaDescuento()
    End Sub

    Public Function addVigencia(ByVal iTipo As Integer, ByVal iNivel As Integer, _
                           ByVal sMaterial As String, ByVal sPROClave As String,
                           ByVal sCliente As String, ByVal sCTEClave As String, _
                           ByVal sGpoMaterial As String, ByVal iGrupo As Integer,
                           ByVal sDescuento As String, ByVal dDescuento As Double, _
                           ByVal sSector As String, ByVal iSector As Integer, _
                           ByVal dRangoInicial As Double, ByVal dRangoFinal As Double, _
                           ByVal dImporte As Double, _
                           ByVal dInicio As Date, ByVal dFin As Date) As Boolean


        Dim id As String = ""
        Dim row1 As DataRow
        row1 = dt.NewRow()
        Dim sNivel As String = ""
        Dim sTipo As String = ""

        Dim dtValor As DataTable
        dtValor = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Descuento", "@Campo", "Nivel", "@Valor", iNivel)

        If dtValor.Rows.Count > 0 Then
            sNivel = dtValor.Rows(0)("Clave")
        End If
        dtValor.Dispose()

        dtValor = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Descuento", "@Campo", "Tipo", "@Valor", iTipo)

        If dtValor.Rows.Count > 0 Then
            sTipo = dtValor.Rows(0)("Clave")
        End If
        dtValor.Dispose()


        Select Case iNivel
            Case 1, 9 ' Cliente\Material
                id = sTipo & "-" & sNivel & "-" & sCliente & "-" & sMaterial & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("Material") = sMaterial
                row1.Item("PROClave") = sPROClave
                row1.Item("Cliente") = sCliente
                row1.Item("CTEClave") = sCTEClave

            Case 2, 5 'Cliente\Grupo
                id = sTipo & "-" & sNivel & "-" & sCliente & "-" & sGpoMaterial & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("GrupoMaterial") = iGrupo
                row1.Item("Grupo") = sGpoMaterial
                row1.Item("Cliente") = sCliente
                row1.Item("CTEClave") = sCTEClave

            Case 3, 10 'Material
                id = sTipo & "-" & sNivel & "-" & sMaterial & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("Material") = sMaterial
                row1.Item("PROClave") = sPROClave

            Case Is = 4 ' Descuento\Material
                id = sTipo & "-" & sNivel & "-" & sDescuento & "-" & sMaterial & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("DescuentoDirecto") = dDescuento
                row1.Item("Descuento") = sDescuento
                row1.Item("Material") = sMaterial
                row1.Item("PROClave") = sPROClave

            Case 6, 11 ' Sector\Descuento
                id = sTipo & "-" & sNivel & "-" & sSector & "-" & sDescuento & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("DescuentoDirecto") = dDescuento
                row1.Item("Descuento") = sDescuento
                row1.Item("TipoSector") = iSector
                row1.Item("Sector") = sSector

            Case 7, 12 'Grupo\Descuento
                id = sTipo & "-" & sNivel & "-" & sGpoMaterial & "-" & sDescuento & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("GrupoMaterial") = iGrupo
                row1.Item("Grupo") = sGpoMaterial
                row1.Item("DescuentoDirecto") = dDescuento
                row1.Item("Descuento") = sDescuento


            Case Is = 8 ' Grupo
                id = sTipo & "-" & sNivel & "-" & sGpoMaterial & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("GrupoMaterial") = iGrupo
                row1.Item("Grupo") = sGpoMaterial


            Case Is = 13 ' Sector\PostVenta
                id = sTipo & "-" & sNivel & "-" & sSector & "-" & sDescuento & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("DescuentoPostVenta") = dDescuento
                row1.Item("Descuento") = sDescuento
                row1.Item("TipoSector") = iSector
                row1.Item("Sector") = sSector

            Case Is = 14 ' PostVenta
                id = sTipo & "-" & sNivel & "-" & sSector & "-" & sDescuento & "-" & String.Format("{0:dd/MM/yyyy}", dInicio)

                row1.Item("DescuentoPostVenta") = dDescuento
                row1.Item("Descuento") = sDescuento


        End Select

        If iTipo = 2 Then
            id &= "-" & CStr(dRangoInicial)
            row1.Item("RangoInicial") = dRangoInicial
            row1.Item("RangoFinal") = dRangoFinal
        End If

        row1.Item("Id") = id

        row1.Item("Importe") = dImporte
        row1.Item("Inicio") = dInicio
        row1.Item("Fin") = dFin.AddHours(23.9999)

        If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_desdet_nvo", _
         "@DESClave", DESClave, _
         "@TipoCanal", TipoCanal, _
         "@Nivel", iNivel, _
         "@Tipo", iTipo, _
         "@CTEClave", sCTEClave, _
         "@PROClave", sPROClave, _
         "@TipoSector", iSector, _
         "@DescuentoDirecto", dDescuento, _
         "@GrupoMaterial", iGrupo, _
         "@Inicio", dInicio, _
         "@Fin", dFin.AddHours(23.9999), _
         "@COMClave", ModPOS.CompanyActual) > 0 Then


            Beep()
            MessageBox.Show("La política de descuento que intenta agregar tiene conflicto de vigencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            dt.Rows.Add(row1)
            ModPOS.Ejecuta("sp_agrega_desdet", _
         "@Id", id, _
         "@DESClave", DESClave, _
         "@CTEClave", sCTEClave, _
         "@PROClave", sPROClave, _
         "@TipoSector", iSector, _
         "@DescuentoDirecto", IIf(Nivel > 12, Nothing, dDescuento), _
         "@DescuentoPostVenta", IIf(Nivel < 12, Nothing, dDescuento), _
         "@GrupoMaterial", iGrupo, _
         "@Inicio", dInicio, _
         "@Fin", dFin.AddHours(23.9999), _
         "@Importe", dImporte, _
         "@Inicial", dRangoInicial, _
         "@Final", dRangoFinal, _
         "@Usuario", ModPOS.UsuarioActual)

            Return True
        End If

    End Function


    Public Function updVigencia(ByVal sId As String, _
                                ByVal iTipo As Integer, _
                                ByVal dRangoInicial As Double, ByVal dRangoFinal As Double, _
                                ByVal dImporte As Double, _
                                ByVal dInicio As Date, ByVal dFin As Date) As Boolean


        Dim foundRows() As System.Data.DataRow

        foundRows = dt.Select("Id = '" & sId & "'")

        If foundRows.GetLength(0) > 0 Then

            If iTipo = 2 Then
                foundRows(0)("RangoInicial") = dRangoInicial
                foundRows(0)("RangoFinal") = dRangoFinal
            End If

            foundRows(0)("Importe") = dImporte
            foundRows(0)("Inicio") = dInicio
            foundRows(0)("Fin") = dFin.AddHours(23.9999)
        End If

        ModPOS.Ejecuta("sp_actualiza_desdet", _
         "@Id", sId, _
         "@DESClave", DESClave, _
         "@Inicio", dInicio, _
         "@Fin", dFin.AddHours(23.9999), _
         "@Importe", dImporte, _
         "@Inicial", dRangoInicial, _
         "@Final", dRangoFinal, _
         "@Usuario", ModPOS.UsuarioActual)

        Return True
        
    End Function

End Class
