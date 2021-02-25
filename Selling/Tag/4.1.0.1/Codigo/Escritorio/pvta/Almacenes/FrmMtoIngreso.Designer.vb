<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMtoIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoIngreso))
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnIngreso = New Janus.Windows.EditControls.UIButton()
        Me.GrpIngresos = New System.Windows.Forms.GroupBox()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnEtiquetas = New Janus.Windows.EditControls.UIButton()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridIngresos = New Janus.Windows.GridEX.GridEX()
        Me.GrpIngresos.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(623, 537)
        Me.BtnReimpresion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 15
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de ingreso seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(335, 537)
        Me.BtnSalir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 14
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnIngreso
        '
        Me.BtnIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnIngreso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnIngreso.Image = CType(resources.GetObject("BtnIngreso.Image"), System.Drawing.Image)
        Me.BtnIngreso.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnIngreso.Location = New System.Drawing.Point(815, 537)
        Me.BtnIngreso.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnIngreso.Name = "BtnIngreso"
        Me.BtnIngreso.Size = New System.Drawing.Size(90, 37)
        Me.BtnIngreso.TabIndex = 13
        Me.BtnIngreso.Text = "&Ingreso"
        Me.BtnIngreso.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnIngreso.ToolTipText = "Registro de Ingreso de Productos"
        Me.BtnIngreso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpIngresos
        '
        Me.GrpIngresos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpIngresos.Controls.Add(Me.BtnSalir)
        Me.GrpIngresos.Controls.Add(Me.BtnEliminar)
        Me.GrpIngresos.Controls.Add(Me.Label3)
        Me.GrpIngresos.Controls.Add(Me.BtnEtiquetas)
        Me.GrpIngresos.Controls.Add(Me.dtPicker)
        Me.GrpIngresos.Controls.Add(Me.BtnReimpresion)
        Me.GrpIngresos.Controls.Add(Me.BtnModificar)
        Me.GrpIngresos.Controls.Add(Me.PictureBox4)
        Me.GrpIngresos.Controls.Add(Me.Label4)
        Me.GrpIngresos.Controls.Add(Me.CmbSucursal)
        Me.GrpIngresos.Controls.Add(Me.BtnIngreso)
        Me.GrpIngresos.Controls.Add(Me.PictureBox1)
        Me.GrpIngresos.Controls.Add(Me.CmbAlmacen)
        Me.GrpIngresos.Controls.Add(Me.Label1)
        Me.GrpIngresos.Controls.Add(Me.GridIngresos)
        Me.GrpIngresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpIngresos.ForeColor = System.Drawing.Color.Black
        Me.GrpIngresos.Location = New System.Drawing.Point(0, 0)
        Me.GrpIngresos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpIngresos.Name = "GrpIngresos"
        Me.GrpIngresos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpIngresos.Size = New System.Drawing.Size(915, 582)
        Me.GrpIngresos.TabIndex = 12
        Me.GrpIngresos.TabStop = False
        Me.GrpIngresos.Text = "Ingresos"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(431, 537)
        Me.BtnEliminar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 18
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar Ingreso seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(645, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Periodo"
        '
        'BtnEtiquetas
        '
        Me.BtnEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEtiquetas.Icon = CType(resources.GetObject("BtnEtiquetas.Icon"), System.Drawing.Icon)
        Me.BtnEtiquetas.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEtiquetas.Location = New System.Drawing.Point(527, 537)
        Me.BtnEtiquetas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnEtiquetas.Name = "BtnEtiquetas"
        Me.BtnEtiquetas.Size = New System.Drawing.Size(90, 37)
        Me.BtnEtiquetas.TabIndex = 17
        Me.BtnEtiquetas.Text = "&Etiquetas"
        Me.BtnEtiquetas.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnEtiquetas.ToolTipText = "Imprime etiquetas de código de barras de los productos de la compra"
        Me.BtnEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(648, 40)
        Me.dtPicker.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(257, 22)
        Me.dtPicker.TabIndex = 130
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(719, 537)
        Me.BtnModificar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 16
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transferencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(93, 16)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox4.TabIndex = 129
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 20)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.Location = New System.Drawing.Point(9, 38)
        Me.CmbSucursal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(218, 24)
        Me.CmbSucursal.TabIndex = 127
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(317, 16)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 124
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(239, 38)
        Me.CmbAlmacen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(377, 24)
        Me.CmbAlmacen.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(236, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Almacén"
        '
        'GridIngresos
        '
        Me.GridIngresos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridIngresos.ColumnAutoResize = True
        Me.GridIngresos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridIngresos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridIngresos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridIngresos.Location = New System.Drawing.Point(9, 66)
        Me.GridIngresos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridIngresos.Name = "GridIngresos"
        Me.GridIngresos.RecordNavigator = True
        Me.GridIngresos.Size = New System.Drawing.Size(897, 465)
        Me.GridIngresos.TabIndex = 2
        Me.GridIngresos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(915, 582)
        Me.Controls.Add(Me.GrpIngresos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmMtoIngreso"
        Me.Text = "Ingresos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpIngresos.ResumeLayout(False)
        Me.GrpIngresos.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnIngreso As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpIngresos As System.Windows.Forms.GroupBox
    Friend WithEvents GridIngresos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
End Class
