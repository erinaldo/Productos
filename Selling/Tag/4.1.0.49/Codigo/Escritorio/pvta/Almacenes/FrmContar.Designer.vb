<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContar))
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.GrpUsuario = New System.Windows.Forms.GroupBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.btnBuscaUsr = New Janus.Windows.EditControls.UIButton()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpUbicaciones = New System.Windows.Forms.GroupBox()
        Me.GridUbicaciones = New Janus.Windows.GridEX.GridEX()
        Me.GridConteo = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.lblPorc = New System.Windows.Forms.Label()
        Me.LblUbicacion = New System.Windows.Forms.Label()
        Me.BtnFile = New Janus.Windows.EditControls.UIButton()
        Me.LblFile = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpUsuario.SuspendLayout()
        Me.GrpUbicaciones.SuspendLayout()
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridConteo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Location = New System.Drawing.Point(506, 85)
        Me.TxtCantidad.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(160, 20)
        Me.TxtCantidad.TabIndex = 103
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(432, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 22)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Enabled = False
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(887, 44)
        Me.BtnBuscaProd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(33, 30)
        Me.BtnBuscaProd.TabIndex = 102
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(673, 46)
        Me.TxtDescripcion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(206, 25)
        Me.TxtDescripcion.TabIndex = 104
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(430, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 20)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Prod. Cve."
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Enabled = False
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(507, 46)
        Me.TxtClaveProd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(158, 21)
        Me.TxtClaveProd.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(430, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 20)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Ubc. Cve."
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Enabled = False
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(507, 12)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(158, 21)
        Me.TxtUbicacion.TabIndex = 107
        '
        'GrpUsuario
        '
        Me.GrpUsuario.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpUsuario.Controls.Add(Me.LblUsuario)
        Me.GrpUsuario.Controls.Add(Me.btnBuscaUsr)
        Me.GrpUsuario.Controls.Add(Me.TxtUsuario)
        Me.GrpUsuario.Controls.Add(Me.Label8)
        Me.GrpUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpUsuario.ForeColor = System.Drawing.Color.Black
        Me.GrpUsuario.Location = New System.Drawing.Point(3, 5)
        Me.GrpUsuario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpUsuario.Name = "GrpUsuario"
        Me.GrpUsuario.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpUsuario.Size = New System.Drawing.Size(420, 114)
        Me.GrpUsuario.TabIndex = 109
        Me.GrpUsuario.TabStop = False
        Me.GrpUsuario.Text = "Usuario"
        '
        'LblUsuario
        '
        Me.LblUsuario.Location = New System.Drawing.Point(5, 63)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(408, 19)
        Me.LblUsuario.TabIndex = 136
        '
        'btnBuscaUsr
        '
        Me.btnBuscaUsr.Icon = CType(resources.GetObject("btnBuscaUsr.Icon"), System.Drawing.Icon)
        Me.btnBuscaUsr.Image = CType(resources.GetObject("btnBuscaUsr.Image"), System.Drawing.Image)
        Me.btnBuscaUsr.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaUsr.Location = New System.Drawing.Point(226, 22)
        Me.btnBuscaUsr.Name = "btnBuscaUsr"
        Me.btnBuscaUsr.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaUsr.TabIndex = 133
        Me.btnBuscaUsr.ToolTipText = "Busqueda de Usuarios"
        Me.btnBuscaUsr.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(98, 29)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(120, 22)
        Me.TxtUsuario.TabIndex = 135
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 14)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "Usuario"
        '
        'GrpUbicaciones
        '
        Me.GrpUbicaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUbicaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpUbicaciones.Controls.Add(Me.GridUbicaciones)
        Me.GrpUbicaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpUbicaciones.ForeColor = System.Drawing.Color.Black
        Me.GrpUbicaciones.Location = New System.Drawing.Point(3, 124)
        Me.GrpUbicaciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpUbicaciones.Name = "GrpUbicaciones"
        Me.GrpUbicaciones.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpUbicaciones.Size = New System.Drawing.Size(420, 572)
        Me.GrpUbicaciones.TabIndex = 110
        Me.GrpUbicaciones.TabStop = False
        Me.GrpUbicaciones.Text = "Ubicaciones"
        '
        'GridUbicaciones
        '
        Me.GridUbicaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUbicaciones.ColumnAutoResize = True
        Me.GridUbicaciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridUbicaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUbicaciones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridUbicaciones.GroupByBoxVisible = False
        Me.GridUbicaciones.Location = New System.Drawing.Point(8, 26)
        Me.GridUbicaciones.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridUbicaciones.Name = "GridUbicaciones"
        Me.GridUbicaciones.RecordNavigator = True
        Me.GridUbicaciones.Size = New System.Drawing.Size(404, 539)
        Me.GridUbicaciones.TabIndex = 4
        Me.GridUbicaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GridConteo
        '
        Me.GridConteo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConteo.ColumnAutoResize = True
        Me.GridConteo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridConteo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConteo.GroupByBoxVisible = False
        Me.GridConteo.Location = New System.Drawing.Point(429, 127)
        Me.GridConteo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridConteo.Name = "GridConteo"
        Me.GridConteo.RecordNavigator = True
        Me.GridConteo.Size = New System.Drawing.Size(488, 520)
        Me.GridConteo.TabIndex = 111
        Me.GridConteo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(731, 659)
        Me.BtnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 113
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y Cerrar Ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(827, 659)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 112
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.ToolTipText = "Guarda los cambios realizados en la ubicación seleccionada"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(427, 666)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 22)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Guardando"
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(498, 662)
        Me.PBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(166, 28)
        Me.PBar.TabIndex = 115
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(670, 666)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(51, 22)
        Me.lblPorc.TabIndex = 116
        Me.lblPorc.Text = "0 %"
        '
        'LblUbicacion
        '
        Me.LblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUbicacion.Location = New System.Drawing.Point(673, 12)
        Me.LblUbicacion.Name = "LblUbicacion"
        Me.LblUbicacion.Size = New System.Drawing.Size(246, 26)
        Me.LblUbicacion.TabIndex = 117
        Me.LblUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFile
        '
        Me.BtnFile.Image = CType(resources.GetObject("BtnFile.Image"), System.Drawing.Image)
        Me.BtnFile.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnFile.Location = New System.Drawing.Point(870, 80)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(47, 39)
        Me.BtnFile.TabIndex = 123
        Me.BtnFile.ToolTipText = "Importar conteo desde archivo (*.CSV con Ubicación, C. Barras, Cantidad)"
        '
        'LblFile
        '
        Me.LblFile.Location = New System.Drawing.Point(670, 89)
        Me.LblFile.Name = "LblFile"
        Me.LblFile.Size = New System.Drawing.Size(194, 22)
        Me.LblFile.TabIndex = 124
        Me.LblFile.Text = "Importar conteo desde Arch."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmContar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(924, 705)
        Me.Controls.Add(Me.LblFile)
        Me.Controls.Add(Me.BtnFile)
        Me.Controls.Add(Me.LblUbicacion)
        Me.Controls.Add(Me.lblPorc)
        Me.Controls.Add(Me.PBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GridConteo)
        Me.Controls.Add(Me.GrpUbicaciones)
        Me.Controls.Add(Me.GrpUsuario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtUbicacion)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnBuscaProd)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtClaveProd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(931, 726)
        Me.Name = "FrmContar"
        Me.Text = "Contar"
        Me.GrpUsuario.ResumeLayout(False)
        Me.GrpUsuario.PerformLayout()
        Me.GrpUbicaciones.ResumeLayout(False)
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridConteo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents GrpUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents GrpUbicaciones As System.Windows.Forms.GroupBox
    Friend WithEvents GridUbicaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridConteo As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents LblUbicacion As System.Windows.Forms.Label
    Friend WithEvents BtnFile As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblFile As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents btnBuscaUsr As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
