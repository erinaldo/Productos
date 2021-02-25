<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntrada
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntrada))
        Me.BtnKey = New Janus.Windows.EditControls.UIButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.TxtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.LblBusqueda = New System.Windows.Forms.Label()
        Me.LblUnidadVenta = New System.Windows.Forms.Label()
        Me.GridPrecios = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrpConfiguración = New System.Windows.Forms.GroupBox()
        Me.cmbTipoImpuesto = New Selling.StoreCombo()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.cmbCompra = New Selling.StoreCombo()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbSubLinea = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbLinea = New Selling.StoreCombo()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridImpuestos = New Janus.Windows.GridEX.GridEX()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDiasGarantia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CmbSeguimiento = New Selling.StoreCombo()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.NumDec = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbTipoComision = New Selling.StoreCombo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCost = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.btnBusquedaUbc = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.BtnEditar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.CmbUnidadVenta = New Selling.StoreCombo()
        Me.TxtClaveSAT = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpConfiguración.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnKey
        '
        Me.BtnKey.Enabled = False
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(297, 34)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(32, 23)
        Me.BtnKey.TabIndex = 2
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNombre
        '
        Me.TxtNombre.Enabled = False
        Me.TxtNombre.Location = New System.Drawing.Point(106, 61)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(256, 20)
        Me.TxtNombre.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(4, 64)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(96, 16)
        Me.LblNombre.TabIndex = 102
        Me.LblNombre.Text = "Nombre Comun"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 38)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(85, 16)
        Me.LblClave.TabIndex = 101
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Location = New System.Drawing.Point(107, 35)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(184, 20)
        Me.TxtClave.TabIndex = 1
        '
        'TxtCodigoBarras
        '
        Me.TxtCodigoBarras.Enabled = False
        Me.TxtCodigoBarras.Location = New System.Drawing.Point(107, 113)
        Me.TxtCodigoBarras.Name = "TxtCodigoBarras"
        Me.TxtCodigoBarras.Size = New System.Drawing.Size(184, 20)
        Me.TxtCodigoBarras.TabIndex = 0
        '
        'LblBusqueda
        '
        Me.LblBusqueda.Location = New System.Drawing.Point(4, 7)
        Me.LblBusqueda.Name = "LblBusqueda"
        Me.LblBusqueda.Size = New System.Drawing.Size(96, 18)
        Me.LblBusqueda.TabIndex = 110
        Me.LblBusqueda.Text = "Busqueda"
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(4, 226)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(78, 16)
        Me.LblUnidadVenta.TabIndex = 109
        Me.LblUnidadVenta.Text = "Tipo Unidad"
        '
        'GridPrecios
        '
        Me.GridPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrecios.ColumnAutoResize = True
        Me.GridPrecios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrecios.Location = New System.Drawing.Point(8, 16)
        Me.GridPrecios.Name = "GridPrecios"
        Me.GridPrecios.RecordNavigator = True
        Me.GridPrecios.Size = New System.Drawing.Size(460, 99)
        Me.GridPrecios.TabIndex = 60
        Me.GridPrecios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.GridPrecios)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 270)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 123)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Precios"
        '
        'GrpConfiguración
        '
        Me.GrpConfiguración.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpConfiguración.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpConfiguración.Controls.Add(Me.cmbTipoImpuesto)
        Me.GrpConfiguración.Controls.Add(Me.CmbTipo)
        Me.GrpConfiguración.Controls.Add(Me.cmbCompra)
        Me.GrpConfiguración.Controls.Add(Me.Label5)
        Me.GrpConfiguración.Controls.Add(Me.CmbSubLinea)
        Me.GrpConfiguración.Controls.Add(Me.Label4)
        Me.GrpConfiguración.Controls.Add(Me.CmbLinea)
        Me.GrpConfiguración.Controls.Add(Me.PictureBox8)
        Me.GrpConfiguración.Controls.Add(Me.PictureBox10)
        Me.GrpConfiguración.Controls.Add(Me.PictureBox9)
        Me.GrpConfiguración.Controls.Add(Me.PictureBox7)
        Me.GrpConfiguración.Controls.Add(Me.PictureBox6)
        Me.GrpConfiguración.Controls.Add(Me.Label3)
        Me.GrpConfiguración.Controls.Add(Me.GroupBox2)
        Me.GrpConfiguración.Controls.Add(Me.Label6)
        Me.GrpConfiguración.Controls.Add(Me.TxtDiasGarantia)
        Me.GrpConfiguración.Controls.Add(Me.CmbSeguimiento)
        Me.GrpConfiguración.Controls.Add(Me.Label14)
        Me.GrpConfiguración.Controls.Add(Me.NumDec)
        Me.GrpConfiguración.Controls.Add(Me.Label17)
        Me.GrpConfiguración.Controls.Add(Me.Label15)
        Me.GrpConfiguración.Controls.Add(Me.CmbTipoComision)
        Me.GrpConfiguración.Controls.Add(Me.Label11)
        Me.GrpConfiguración.Controls.Add(Me.Label10)
        Me.GrpConfiguración.Enabled = False
        Me.GrpConfiguración.Location = New System.Drawing.Point(487, 2)
        Me.GrpConfiguración.Name = "GrpConfiguración"
        Me.GrpConfiguración.Size = New System.Drawing.Size(293, 391)
        Me.GrpConfiguración.TabIndex = 113
        Me.GrpConfiguración.TabStop = False
        Me.GrpConfiguración.Text = "Configuración General"
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(99, 156)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(183, 21)
        Me.cmbTipoImpuesto.TabIndex = 138
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(99, 72)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(183, 21)
        Me.CmbTipo.TabIndex = 136
        '
        'cmbCompra
        '
        Me.cmbCompra.Location = New System.Drawing.Point(99, 100)
        Me.cmbCompra.Name = "cmbCompra"
        Me.cmbCompra.Size = New System.Drawing.Size(183, 21)
        Me.cmbCompra.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Sub Linea"
        '
        'CmbSubLinea
        '
        Me.CmbSubLinea.Location = New System.Drawing.Point(99, 44)
        Me.CmbSubLinea.Name = "CmbSubLinea"
        Me.CmbSubLinea.Size = New System.Drawing.Size(183, 21)
        Me.CmbSubLinea.TabIndex = 132
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Linea"
        '
        'CmbLinea
        '
        Me.CmbLinea.Location = New System.Drawing.Point(99, 16)
        Me.CmbLinea.Name = "CmbLinea"
        Me.CmbLinea.Size = New System.Drawing.Size(183, 21)
        Me.CmbLinea.TabIndex = 131
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(76, 131)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox8.TabIndex = 128
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(77, 187)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox10.TabIndex = 130
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(76, 161)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox9.TabIndex = 129
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(76, 103)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox7.TabIndex = 127
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(77, 75)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.TabIndex = 126
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Tipo Compra"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GridImpuestos)
        Me.GroupBox2.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 120)
        Me.GroupBox2.TabIndex = 124
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Impuestos"
        '
        'GridImpuestos
        '
        Me.GridImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridImpuestos.AutoEdit = True
        Me.GridImpuestos.ColumnAutoResize = True
        Me.GridImpuestos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridImpuestos.Location = New System.Drawing.Point(7, 33)
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.RecordNavigator = True
        Me.GridImpuestos.Size = New System.Drawing.Size(265, 82)
        Me.GridImpuestos.TabIndex = 8
        Me.GridImpuestos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.GridImpuestos.UpdateOnLeave = False
        Me.GridImpuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(9, 12)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(104, 24)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 11)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Días de Garantía"
        '
        'TxtDiasGarantia
        '
        Me.TxtDiasGarantia.Enabled = False
        Me.TxtDiasGarantia.Location = New System.Drawing.Point(146, 212)
        Me.TxtDiasGarantia.Name = "TxtDiasGarantia"
        Me.TxtDiasGarantia.Size = New System.Drawing.Size(66, 20)
        Me.TxtDiasGarantia.TabIndex = 119
        Me.TxtDiasGarantia.Text = "0"
        Me.TxtDiasGarantia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtDiasGarantia.Value = 0
        Me.TxtDiasGarantia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'CmbSeguimiento
        '
        Me.CmbSeguimiento.Location = New System.Drawing.Point(99, 184)
        Me.CmbSeguimiento.Name = "CmbSeguimiento"
        Me.CmbSeguimiento.Size = New System.Drawing.Size(183, 21)
        Me.CmbSeguimiento.TabIndex = 117
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(9, 246)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 18)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "Numero de Decimales "
        '
        'NumDec
        '
        Me.NumDec.Location = New System.Drawing.Point(145, 239)
        Me.NumDec.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumDec.Name = "NumDec"
        Me.NumDec.Size = New System.Drawing.Size(66, 20)
        Me.NumDec.TabIndex = 118
        Me.NumDec.ThousandsSeparator = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(9, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 123
        Me.Label17.Text = "Seguimiento"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(9, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 16)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Tipo Comisión"
        '
        'CmbTipoComision
        '
        Me.CmbTipoComision.Location = New System.Drawing.Point(99, 128)
        Me.CmbTipoComision.Name = "CmbTipoComision"
        Me.CmbTipoComision.Size = New System.Drawing.Size(183, 21)
        Me.CmbTipoComision.TabIndex = 115
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 14)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "T. Impuesto"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "T. Producto"
        '
        'TxtCost
        '
        Me.TxtCost.Location = New System.Drawing.Point(107, 140)
        Me.TxtCost.Name = "TxtCost"
        Me.TxtCost.Size = New System.Drawing.Size(106, 20)
        Me.TxtCost.TabIndex = 4
        Me.TxtCost.Text = "0.00"
        Me.TxtCost.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCost.Value = 0.0R
        Me.TxtCost.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Icon = CType(resources.GetObject("BtnGuardar.Icon"), System.Drawing.Icon)
        Me.BtnGuardar.Location = New System.Drawing.Point(690, 399)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(594, 399)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 8
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Guardar cambios"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.Location = New System.Drawing.Point(4, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Cantidad"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(107, 168)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(106, 20)
        Me.TxtCantidad.TabIndex = 5
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(85, 38)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(84, 64)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 122
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(84, 92)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 123
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(84, 118)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 124
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(85, 143)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.TabIndex = 125
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(84, 226)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox11.TabIndex = 131
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Location = New System.Drawing.Point(107, 87)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(368, 20)
        Me.TxtDescripcion.TabIndex = 132
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(4, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 18)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Location = New System.Drawing.Point(4, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Costo Sin Imp."
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Location = New System.Drawing.Point(107, 7)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(184, 20)
        Me.TxtBusqueda.TabIndex = 134
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(4, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 18)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Código de Barras"
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Location = New System.Drawing.Point(106, 194)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(184, 20)
        Me.TxtUbicacion.TabIndex = 136
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 18)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Ubicación"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(297, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(32, 24)
        Me.BtnBuscar.TabIndex = 138
        Me.BtnBuscar.ToolTipText = "Busqueda de producto"
        Me.BtnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBusquedaUbc
        '
        Me.btnBusquedaUbc.Image = CType(resources.GetObject("btnBusquedaUbc.Image"), System.Drawing.Image)
        Me.btnBusquedaUbc.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBusquedaUbc.Location = New System.Drawing.Point(296, 192)
        Me.btnBusquedaUbc.Name = "btnBusquedaUbc"
        Me.btnBusquedaUbc.Size = New System.Drawing.Size(32, 24)
        Me.btnBusquedaUbc.TabIndex = 139
        Me.btnBusquedaUbc.ToolTipText = "Busqueda de ubicación"
        Me.btnBusquedaUbc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(85, 172)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox12.TabIndex = 140
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(84, 197)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox13.TabIndex = 141
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'BtnEditar
        '
        Me.BtnEditar.Enabled = False
        Me.BtnEditar.Icon = CType(resources.GetObject("BtnEditar.Icon"), System.Drawing.Icon)
        Me.BtnEditar.Location = New System.Drawing.Point(335, 35)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(41, 22)
        Me.BtnEditar.TabIndex = 142
        Me.BtnEditar.ToolTipText = "Editar información del producto"
        Me.BtnEditar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(459, 234)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox14.TabIndex = 143
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'CmbUnidadVenta
        '
        Me.CmbUnidadVenta.Location = New System.Drawing.Point(107, 222)
        Me.CmbUnidadVenta.Name = "CmbUnidadVenta"
        Me.CmbUnidadVenta.Size = New System.Drawing.Size(184, 21)
        Me.CmbUnidadVenta.TabIndex = 108
        '
        'TxtClaveSAT
        '
        Me.TxtClaveSAT.Location = New System.Drawing.Point(106, 249)
        Me.TxtClaveSAT.Name = "TxtClaveSAT"
        Me.TxtClaveSAT.Size = New System.Drawing.Size(154, 20)
        Me.TxtClaveSAT.TabIndex = 144
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(4, 252)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 15)
        Me.Label19.TabIndex = 145
        Me.Label19.Text = "Clave SAT"
        '
        'FrmEntrada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 442)
        Me.Controls.Add(Me.TxtClaveSAT)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PictureBox14)
        Me.Controls.Add(Me.BtnEditar)
        Me.Controls.Add(Me.PictureBox13)
        Me.Controls.Add(Me.PictureBox12)
        Me.Controls.Add(Me.btnBusquedaUbc)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.TxtUbicacion)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.TxtBusqueda)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox11)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpConfiguración)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmbUnidadVenta)
        Me.Controls.Add(Me.LblUnidadVenta)
        Me.Controls.Add(Me.TxtCodigoBarras)
        Me.Controls.Add(Me.LblBusqueda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCost)
        Me.Controls.Add(Me.BtnKey)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 469)
        Me.Name = "FrmEntrada"
        Me.Text = "Ingresos de Productos a Almacén"
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GrpConfiguración.ResumeLayout(False)
        Me.GrpConfiguración.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents LblBusqueda As System.Windows.Forms.Label
    Friend WithEvents CmbUnidadVenta As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents GridPrecios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpConfiguración As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCost As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoComision As Selling.StoreCombo
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasGarantia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbSeguimiento As Selling.StoreCombo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents NumDec As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbSubLinea As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbLinea As Selling.StoreCombo
    Friend WithEvents GridImpuestos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnBusquedaUbc As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEditar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbCompra As Selling.StoreCombo
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoImpuesto As Selling.StoreCombo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClaveSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
