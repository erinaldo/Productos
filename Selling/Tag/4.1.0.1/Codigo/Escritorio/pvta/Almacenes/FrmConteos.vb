Public Class FrmConteos
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
    Friend WithEvents UiTabConteos As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabGeneral As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpConteo As System.Windows.Forms.GroupBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabUbicaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridEstrategia As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As Selling.StoreCombo
    Friend WithEvents btnAddEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelEst As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents chkUbicaciones As Selling.ChkStatus
    Friend WithEvents btnAddUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAsignacion As Janus.Windows.EditControls.UIButton

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConteos))
        Me.UiTabConteos = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New Selling.StoreCombo()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.GrpConteo = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.btnAddEst = New Janus.Windows.EditControls.UIButton()
        Me.btnDelEst = New Janus.Windows.EditControls.UIButton()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UiTabUbicaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkUbicaciones = New Selling.ChkStatus(Me.components)
        Me.btnAddUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.btnDelUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.GridEstrategia = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.btnAsignacion = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTabConteos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabConteos.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpConteo.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUbicaciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridEstrategia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTabConteos
        '
        Me.UiTabConteos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabConteos.BackColor = System.Drawing.Color.Transparent
        Me.UiTabConteos.Location = New System.Drawing.Point(2, 3)
        Me.UiTabConteos.Name = "UiTabConteos"
        Me.UiTabConteos.Size = New System.Drawing.Size(788, 421)
        Me.UiTabConteos.TabIndex = 23
        Me.UiTabConteos.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral, Me.UiTabUbicaciones})
        Me.UiTabConteos.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.PictureBox4)
        Me.UiTabGeneral.Controls.Add(Me.CmbTipo)
        Me.UiTabGeneral.Controls.Add(Me.Label2)
        Me.UiTabGeneral.Controls.Add(Me.PictureBox3)
        Me.UiTabGeneral.Controls.Add(Me.PictureBox2)
        Me.UiTabGeneral.Controls.Add(Me.PictureBox1)
        Me.UiTabGeneral.Controls.Add(Me.Label1)
        Me.UiTabGeneral.Controls.Add(Me.cmbSucursal)
        Me.UiTabGeneral.Controls.Add(Me.LblClave)
        Me.UiTabGeneral.Controls.Add(Me.GrpConteo)
        Me.UiTabGeneral.Controls.Add(Me.TxtClave)
        Me.UiTabGeneral.Controls.Add(Me.CmbAlmacen)
        Me.UiTabGeneral.Controls.Add(Me.Label9)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(786, 399)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "General"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(76, 95)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 142
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(106, 93)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(197, 21)
        Me.CmbTipo.TabIndex = 140
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(10, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Tipo de Conteo"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(76, 67)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 139
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(76, 37)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 138
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(76, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 137
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(10, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursal.Location = New System.Drawing.Point(106, 36)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(306, 21)
        Me.cmbSucursal.TabIndex = 135
        '
        'LblClave
        '
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Location = New System.Drawing.Point(10, 14)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(71, 15)
        Me.LblClave.TabIndex = 126
        Me.LblClave.Text = "Clave"
        '
        'GrpConteo
        '
        Me.GrpConteo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpConteo.BackColor = System.Drawing.Color.Transparent
        Me.GrpConteo.Controls.Add(Me.PictureBox5)
        Me.GrpConteo.Controls.Add(Me.ChkTodos)
        Me.GrpConteo.Controls.Add(Me.btnAddEst)
        Me.GrpConteo.Controls.Add(Me.btnDelEst)
        Me.GrpConteo.Controls.Add(Me.GridProductos)
        Me.GrpConteo.Location = New System.Drawing.Point(3, 125)
        Me.GrpConteo.Name = "GrpConteo"
        Me.GrpConteo.Size = New System.Drawing.Size(780, 271)
        Me.GrpConteo.TabIndex = 1
        Me.GrpConteo.TabStop = False
        Me.GrpConteo.Text = "Productos a Contar"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(648, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 162
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(7, 19)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(142, 22)
        Me.ChkTodos.TabIndex = 161
        Me.ChkTodos.Text = "Seleccionar Todo"
        '
        'btnAddEst
        '
        Me.btnAddEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddEst.Icon = CType(resources.GetObject("btnAddEst.Icon"), System.Drawing.Icon)
        Me.btnAddEst.Location = New System.Drawing.Point(670, 14)
        Me.btnAddEst.Name = "btnAddEst"
        Me.btnAddEst.Size = New System.Drawing.Size(47, 23)
        Me.btnAddEst.TabIndex = 159
        Me.btnAddEst.ToolTipText = "Agregar producto a conteo"
        Me.btnAddEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelEst
        '
        Me.btnDelEst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelEst.Icon = CType(resources.GetObject("btnDelEst.Icon"), System.Drawing.Icon)
        Me.btnDelEst.Location = New System.Drawing.Point(723, 14)
        Me.btnDelEst.Name = "btnDelEst"
        Me.btnDelEst.Size = New System.Drawing.Size(47, 23)
        Me.btnDelEst.TabIndex = 160
        Me.btnDelEst.ToolTipText = "Eliminar producto  seleccionado del conteo"
        Me.btnDelEst.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 43)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(767, 222)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Location = New System.Drawing.Point(106, 11)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(239, 20)
        Me.TxtClave.TabIndex = 125
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(106, 62)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(306, 21)
        Me.CmbAlmacen.TabIndex = 114
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(10, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 115
        Me.Label9.Text = "Almacén"
        '
        'UiTabUbicaciones
        '
        Me.UiTabUbicaciones.Controls.Add(Me.GroupBox1)
        Me.UiTabUbicaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabUbicaciones.Name = "UiTabUbicaciones"
        Me.UiTabUbicaciones.Size = New System.Drawing.Size(786, 399)
        Me.UiTabUbicaciones.TabStop = True
        Me.UiTabUbicaciones.Text = "Asignar Ubicaciones"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAsignacion)
        Me.GroupBox1.Controls.Add(Me.chkUbicaciones)
        Me.GroupBox1.Controls.Add(Me.btnAddUbicacion)
        Me.GroupBox1.Controls.Add(Me.btnDelUbicacion)
        Me.GroupBox1.Controls.Add(Me.GridEstrategia)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 372)
        Me.GroupBox1.TabIndex = 139
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicaciones a Contar"
        '
        'chkUbicaciones
        '
        Me.chkUbicaciones.Location = New System.Drawing.Point(7, 19)
        Me.chkUbicaciones.Name = "chkUbicaciones"
        Me.chkUbicaciones.Size = New System.Drawing.Size(142, 22)
        Me.chkUbicaciones.TabIndex = 164
        Me.chkUbicaciones.Text = "Seleccionar Todo"
        '
        'btnAddUbicacion
        '
        Me.btnAddUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddUbicacion.Icon = CType(resources.GetObject("btnAddUbicacion.Icon"), System.Drawing.Icon)
        Me.btnAddUbicacion.Location = New System.Drawing.Point(676, 15)
        Me.btnAddUbicacion.Name = "btnAddUbicacion"
        Me.btnAddUbicacion.Size = New System.Drawing.Size(47, 23)
        Me.btnAddUbicacion.TabIndex = 162
        Me.btnAddUbicacion.ToolTipText = "Agregar ubicación a conteo"
        Me.btnAddUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelUbicacion
        '
        Me.btnDelUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelUbicacion.Icon = CType(resources.GetObject("btnDelUbicacion.Icon"), System.Drawing.Icon)
        Me.btnDelUbicacion.Location = New System.Drawing.Point(729, 15)
        Me.btnDelUbicacion.Name = "btnDelUbicacion"
        Me.btnDelUbicacion.Size = New System.Drawing.Size(47, 23)
        Me.btnDelUbicacion.TabIndex = 163
        Me.btnDelUbicacion.ToolTipText = "Eliminar ubicación seleccionada del conteo"
        Me.btnDelUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEstrategia
        '
        Me.GridEstrategia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstrategia.AutoEdit = True
        Me.GridEstrategia.ColumnAutoResize = True
        Me.GridEstrategia.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstrategia.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstrategia.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEstrategia.GroupByBoxVisible = False
        Me.GridEstrategia.Location = New System.Drawing.Point(7, 44)
        Me.GridEstrategia.Name = "GridEstrategia"
        Me.GridEstrategia.RecordNavigator = True
        Me.GridEstrategia.Size = New System.Drawing.Size(769, 321)
        Me.GridEstrategia.TabIndex = 1
        Me.GridEstrategia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(696, 430)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(600, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAsignacion
        '
        Me.btnAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAsignacion.Icon = CType(resources.GetObject("btnAsignacion.Icon"), System.Drawing.Icon)
        Me.btnAsignacion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnAsignacion.Location = New System.Drawing.Point(623, 15)
        Me.btnAsignacion.Name = "btnAsignacion"
        Me.btnAsignacion.Size = New System.Drawing.Size(47, 23)
        Me.btnAsignacion.TabIndex = 165
        Me.btnAsignacion.ToolTipText = "Asignar usuario al conteo"
        Me.btnAsignacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmConteos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTabConteos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmConteos"
        Me.Text = "Configurar Conteo"
        CType(Me.UiTabConteos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabConteos.ResumeLayout(False)
        Me.UiTabGeneral.ResumeLayout(False)
        Me.UiTabGeneral.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpConteo.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUbicaciones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridEstrategia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public SUCClave As String
    Public ALMClave As String
    Public CONClave As String = ""
    Public Clave As String
    Public Tipo As Integer
    Public Estado As Integer = 1

    Private EstadoActual As Integer
    Private dtConteo, dtAsignacion As DataTable
    Private Cargado As Boolean = False
    Private Guardado As Boolean = False
    Private alerta(4) As PictureBox
    Private reloj As parpadea


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If cmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()

        End If

        If Not CmbTipo.SelectedValue Is Nothing Then
            If CmbTipo.SelectedValue = 2 AndAlso dtConteo.Rows.Count = 0 Then
                i += 1
                reloj = New parpadea(Me.alerta(4))
                reloj.Enabled = True
                reloj.Start()
            End If

        End If


        If i > 0 Then
            Return False

        ElseIf Me.Padre = "Nuevo" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_PK", "@tabla", "Conteo", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


    Private Sub ActualizaDetalle()
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("st_conteo_config", "@CONClave", CONClave)

        GridProductos.DataSource = dtConteo
        GridProductos.RetrieveStructure()
        GridProductos.AutoSizeColumns()
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("Marca").Width = 20
    End Sub

    Private Sub recuperaAlmacen()
        If Not cmbSucursal.SelectedValue Is Nothing Then
            SUCClave = cmbSucursal.SelectedValue
            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        Else
            SUCClave = ""
        End If
    End Sub

    Private Sub FrmConteos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        TxtClave.Text = Clave

        With cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Conteo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        If Padre = "Nuevo" Then

            CONClave = ModPOS.obtenerLlave
            TxtClave.Enabled = True

            ModPOS.Ejecuta("sp_crea_conteo", "@CONClave", CONClave, "@Usuario", ModPOS.UsuarioActual)

            If ModPOS.SucursalPredeterminada <> "" Then
                cmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
            End If

            recuperaAlmacen()

            If CmbAlmacen.SelectedValue Is Nothing Then
                ALMClave = ""
            Else
                ALMClave = CmbAlmacen.SelectedItem(0)
            End If



        End If

        EstadoActual = Estado
        Cargado = True


        If Not CmbTipo.SelectedValue Is Nothing Then
            If CmbTipo.SelectedValue = 1 Then
                GrpConteo.Enabled = False
            Else
                GrpConteo.Enabled = True
            End If
        Else
            GrpConteo.Enabled = False
        End If

        ActualizaDetalle()

        If Padre = "Modificar" Then
            cmbSucursal.SelectedValue = SUCClave
            CmbAlmacen.SelectedValue = ALMClave
            CmbTipo.SelectedValue = Tipo
            TxtClave.Enabled = False
        End If


        Cursor.Current = Cursors.Default

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmConteos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing


        If Padre = "Nuevo" AndAlso EstadoActual = 1 AndAlso Guardado = False Then
            If MessageBox.Show("¿Esta seguro de salir sin guardar los cambios?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                ModPOS.Ejecuta("st_elimina_conteo", "@CONClave", CONClave)
            Else
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not ModPOS.MtoConteo Is Nothing Then
            If Not ModPOS.MtoConteo.cmbSucursal.SelectedValue Is Nothing AndAlso ModPOS.MtoConteo.Periodo > 0 AndAlso ModPOS.MtoConteo.Mes > 0 Then
                ModPOS.MtoConteo.ActualizarGrid()
            End If
        End If

        ModPOS.Conteo.Dispose()
        ModPOS.Conteo = Nothing
    End Sub




 
    Private Sub ActualizaAsignacion()
        If Not dtAsignacion Is Nothing Then
            dtAsignacion.Dispose()
        End If

        dtAsignacion = ModPOS.Recupera_Tabla("st_conteo_asignacion", "@CONClave", CONClave)


        GridEstrategia.DataSource = dtAsignacion
        GridEstrategia.RetrieveStructure()
        GridEstrategia.AutoSizeColumns()
        GridEstrategia.RootTable.Columns("ASGClave").Visible = False
        GridEstrategia.RootTable.Columns("Marca").Width = 20
        GridEstrategia.RootTable.Columns("Automatica").Visible = False
        GridEstrategia.RootTable.Columns("UBCClave").Visible = False




    End Sub

    Private Sub cmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursal.SelectedValueChanged
        If Cargado = True Then
            recuperaAlmacen()
        End If
    End Sub


    Private Sub btnAddEst_Click(sender As Object, e As EventArgs) Handles btnAddEst.Click
        Dim a As New FrmAddProdConteo
        a.Sucursal = Me.SUCClave
        a.Almacen = ALMClave
        a.Conteo = CONClave
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ActualizaDetalle()
        End If
        a.Dispose()
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtConteo.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = 1
                Next
            Else
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = 0
                Next
            End If
            dtConteo.AcceptChanges()

            GridProductos.Refresh()
        End If
    End Sub

    Private Sub CmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbTipo.SelectedValueChanged
        If Cargado = True Then
            If Not CmbTipo.SelectedValue Is Nothing Then
                If CmbTipo.SelectedValue = 1 Then
                    GrpConteo.Enabled = False
                Else
                    GrpConteo.Enabled = True
                End If
            Else
                GrpConteo.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click_1(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

           

            If Padre = "Nuevo" Then
                Clave = TxtClave.Text.ToUpper.Trim
                SUCClave = cmbSucursal.SelectedValue
                ALMClave = CmbAlmacen.SelectedValue
                Tipo = CmbTipo.SelectedValue

                ModPOS.Ejecuta("sp_crea_conteo", "@CONClave", CONClave, _
                                                 "@Usuario", ModPOS.UsuarioActual, _
                                                 "@Clave", Clave, _
                                                 "@SUCClave", SUCClave, _
                                                 "@ALMClave", ALMClave, _
                                                 "@Tipo", Tipo)

            ElseIf Not (SUCClave = cmbSucursal.SelectedValue AndAlso _
                ALMClave = CmbAlmacen.SelectedValue AndAlso _
                Tipo = CmbTipo.SelectedValue) Then


                Clave = TxtClave.Text.ToUpper.Trim
                SUCClave = cmbSucursal.SelectedValue
                ALMClave = CmbAlmacen.SelectedValue
                Tipo = CmbTipo.SelectedValue


                ModPOS.Ejecuta("sp_crea_conteo", "@CONClave", CONClave, _
                                               "@Usuario", ModPOS.UsuarioActual, _
                                               "@Clave", Clave, _
                                               "@SUCClave", SUCClave, _
                                               "@ALMClave", ALMClave, _
                                               "@Tipo", Tipo)


            End If
            Guardado = True
            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click_1(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnDelEst_Click(sender As Object, e As EventArgs) Handles btnDelEst.Click
        Dim z As Integer
        Dim foundRows() As DataRow
        foundRows = dtConteo.Select(" Marca = 1 ")
        If foundRows.Length > 0 Then

            If Not validaForm() Then

                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

                If MessageBox.Show("¿Esta seguro de Eliminar todos los productos seleccionados del conteo actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                    For z = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Ejecuta("st_elimina_ConfigConteo", _
                                        "@CONClave", CONClave, _
                                        "@PROClave", foundRows(z)("PROClave"))
                    Next
                    ModPOS.Ejecuta("st_act_conteo_asig", "@CONClave", CONClave, "@Tipo", CmbTipo.SelectedValue, "@ALMClave", CmbAlmacen.SelectedValue, "@Usuario", ModPOS.UsuarioActual)

                    ActualizaDetalle()
                End If

            End If
        End If
    End Sub

    Private Sub UiTabConteos_SelectedTabChanged(sender As Object, e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTabConteos.SelectedTabChanged

        If e.Page.Name = "UiTabUbicaciones" Then
            If Not validaForm() Then
                UiTabConteos.SelectedIndex = 0
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                ModPOS.Ejecuta("st_act_conteo_asig", "@CONClave", CONClave, "@Tipo", CmbTipo.SelectedValue, "@ALMClave", CmbAlmacen.SelectedValue, "@Usuario", ModPOS.UsuarioActual)
                ActualizaAsignacion()
            End If
        End If


    End Sub

    Private Sub GridProductos_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridProductos.CurrentCellChanged
        If Not GridProductos.CurrentColumn Is Nothing Then
            If GridProductos.CurrentColumn.Caption = "Marca" Then
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub chkUbicaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chkUbicaciones.CheckedChanged
        If dtAsignacion.Rows.Count > 0 Then
            Dim i As Integer
            If chkUbicaciones.Checked Then
                For i = 0 To GridEstrategia.GetDataRows.Length - 1
                    GridEstrategia.GetDataRows(i).DataRow("Marca") = 1
                Next
            Else
                For i = 0 To GridEstrategia.GetDataRows.Length - 1
                    GridEstrategia.GetDataRows(i).DataRow("Marca") = 0
                Next
            End If
            dtAsignacion.AcceptChanges()

            GridEstrategia.Refresh()
        End If
    End Sub

    Private Sub GridEstrategia_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridEstrategia.CurrentCellChanged
        If Not GridEstrategia.CurrentColumn Is Nothing Then
            If GridEstrategia.CurrentColumn.Caption = "Marca" Then
                GridEstrategia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridEstrategia.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

   
    Private Sub btnDelUbicacion_Click(sender As Object, e As EventArgs) Handles btnDelUbicacion.Click
        Dim z As Integer
        Dim foundRows() As DataRow
        foundRows = dtAsignacion.Select(" Marca = 1 and Automatica= 0")
        If foundRows.Length > 0 Then

           
                If MessageBox.Show("¿Esta seguro de Eliminar todas las ubicaciones seleccionadas del conteo actual?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                    For z = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("st_elimina_ConfigAsignacion", _
                                        "@CONClave", CONClave, _
                                        "@UBCClave", foundRows(z)("UBCClave"))
                    Next
                   
                ActualizaAsignacion()
                End If
        Else
            MessageBox.Show("Solo es posible eliminar ubicaciones seleccionadas y que se hayan agregado manualmente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAddUbicacion_Click(sender As Object, e As EventArgs) Handles btnAddUbicacion.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.BusquedaInicial = False

            a.AlmRequerido = True
            a.ALMClave = CmbAlmacen.SelectedValue
            a.NumColDes = 1
            a.OcultaCol = True
            a.OcultaColNum = 0

            a.ShowDialog()

            If a.DialogResult = DialogResult.OK Then
                Dim foundRows() As DataRow
                foundRows = dtAsignacion.Select(" UBCClave = '" & a.valor & "'")
                If foundRows.Length = 0 Then
                    ModPOS.Ejecuta("st_agrega_ConfigAsignacion", _
                                       "@CONClave", CONClave, _
                                       "@UBCClave", a.valor, _
                                       "@Usuario", ModPOS.UsuarioActual)

                    ActualizaAsignacion()
                Else
                    Beep()
                    MessageBox.Show("La ubicación seleccionada ya existe en el conteo actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("¡El Almacén no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub btnAsignacion_Click(sender As Object, e As EventArgs) Handles btnAsignacion.Click
        Dim z As Integer
        Dim foundRows() As DataRow
        foundRows = dtAsignacion.Select(" Marca = 1 ")
        If foundRows.Length > 0 Then


            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_usuario"
            a.TablaCmb = "Usuario"
            a.CampoCmb = "Filtro"
            a.OcultaID = True
            a.CompaniaRequerido = False
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If Not a.valor Is Nothing Then
                    For z = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Ejecuta("st_asigna_ConfigAsignacion", _
                                            "@CONClave", CONClave, _
                                            "@UBCClave", foundRows(z)("UBCClave"),
                                            "@USRClave", a.valor,
                                            "@Usuario", ModPOS.UsuarioActual)
                    Next


                    ActualizaAsignacion()

                End If
            End If
            a.Dispose()
         


        Else
        MessageBox.Show("Debe seleccionar las ubicaciones que desea asignar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
