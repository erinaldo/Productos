<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMtoConteo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoConteo))
        Me.GrpIngresos = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridConteos = New Janus.Windows.GridEX.GridEX
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAjustar = New Janus.Windows.EditControls.UIButton
        Me.BtnFinalizar = New Janus.Windows.EditControls.UIButton
        Me.BtnConteo = New Janus.Windows.EditControls.UIButton
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.BtnContar = New Janus.Windows.EditControls.UIButton
        Me.GrpIngresos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridConteos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpIngresos
        '
        Me.GrpIngresos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpIngresos.Controls.Add(Me.BtnSalir)
        Me.GrpIngresos.Controls.Add(Me.BtnEliminar)
        Me.GrpIngresos.Controls.Add(Me.Label3)
        Me.GrpIngresos.Controls.Add(Me.BtnAjustar)
        Me.GrpIngresos.Controls.Add(Me.BtnFinalizar)
        Me.GrpIngresos.Controls.Add(Me.dtPicker)
        Me.GrpIngresos.Controls.Add(Me.BtnConteo)
        Me.GrpIngresos.Controls.Add(Me.PictureBox1)
        Me.GrpIngresos.Controls.Add(Me.BtnImprimir)
        Me.GrpIngresos.Controls.Add(Me.CmbAlmacen)
        Me.GrpIngresos.Controls.Add(Me.Label1)
        Me.GrpIngresos.Controls.Add(Me.BtnContar)
        Me.GrpIngresos.Controls.Add(Me.GridConteos)
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
        Me.GrpIngresos.Text = "Conteos"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(648, 19)
        Me.dtPicker.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(257, 22)
        Me.dtPicker.TabIndex = 130
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(62, 24)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 124
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(87, 19)
        Me.CmbAlmacen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(377, 24)
        Me.CmbAlmacen.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Almacén"
        '
        'GridConteos
        '
        Me.GridConteos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridConteos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConteos.ColumnAutoResize = True
        Me.GridConteos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridConteos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConteos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConteos.Location = New System.Drawing.Point(9, 52)
        Me.GridConteos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridConteos.Name = "GridConteos"
        Me.GridConteos.RecordNavigator = True
        Me.GridConteos.Size = New System.Drawing.Size(897, 468)
        Me.GridConteos.TabIndex = 2
        Me.GridConteos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEliminar.Location = New System.Drawing.Point(335, 538)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 28
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Borra el Conteo Seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAjustar
        '
        Me.BtnAjustar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAjustar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAjustar.Icon = CType(resources.GetObject("BtnAjustar.Icon"), System.Drawing.Icon)
        Me.BtnAjustar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnAjustar.Location = New System.Drawing.Point(431, 538)
        Me.BtnAjustar.Name = "BtnAjustar"
        Me.BtnAjustar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAjustar.TabIndex = 27
        Me.BtnAjustar.Text = "&Ajustar"
        Me.BtnAjustar.ToolTipText = "Ajustar"
        Me.BtnAjustar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFinalizar
        '
        Me.BtnFinalizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFinalizar.Icon = CType(resources.GetObject("BtnFinalizar.Icon"), System.Drawing.Icon)
        Me.BtnFinalizar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnFinalizar.Location = New System.Drawing.Point(527, 538)
        Me.BtnFinalizar.Name = "BtnFinalizar"
        Me.BtnFinalizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnFinalizar.TabIndex = 26
        Me.BtnFinalizar.Text = "&Finalizar"
        Me.BtnFinalizar.ToolTipText = "Termina el Conteo Seleccionado"
        Me.BtnFinalizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConteo
        '
        Me.BtnConteo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConteo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConteo.Icon = CType(resources.GetObject("BtnConteo.Icon"), System.Drawing.Icon)
        Me.BtnConteo.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConteo.Location = New System.Drawing.Point(815, 538)
        Me.BtnConteo.Name = "BtnConteo"
        Me.BtnConteo.Size = New System.Drawing.Size(90, 37)
        Me.BtnConteo.TabIndex = 25
        Me.BtnConteo.Text = "&Conteo"
        Me.BtnConteo.ToolTipText = "Crear nuevo conteo"
        Me.BtnConteo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnImprimir.Location = New System.Drawing.Point(623, 538)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnImprimir.TabIndex = 24
        Me.BtnImprimir.Text = "&Imprimir"
        Me.BtnImprimir.ToolTipText = "Imprimir formatos de conteo"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(239, 538)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 23
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnContar
        '
        Me.BtnContar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnContar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContar.Icon = CType(resources.GetObject("BtnContar.Icon"), System.Drawing.Icon)
        Me.BtnContar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnContar.Location = New System.Drawing.Point(719, 538)
        Me.BtnContar.Name = "BtnContar"
        Me.BtnContar.Size = New System.Drawing.Size(90, 37)
        Me.BtnContar.TabIndex = 22
        Me.BtnContar.Text = "&Contar"
        Me.BtnContar.ToolTipText = "Contar"
        Me.BtnContar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(915, 582)
        Me.Controls.Add(Me.GrpIngresos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmMtoConteo"
        Me.Text = "Ingresos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpIngresos.ResumeLayout(False)
        Me.GrpIngresos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridConteos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpIngresos As System.Windows.Forms.GroupBox
    Friend WithEvents GridConteos As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAjustar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnFinalizar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConteo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnContar As Janus.Windows.EditControls.UIButton
End Class
