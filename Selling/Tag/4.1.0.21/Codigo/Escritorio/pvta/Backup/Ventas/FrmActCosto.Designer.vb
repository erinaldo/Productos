<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActCosto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActCosto))
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.GridPrecios = New Janus.Windows.GridEX.GridEX
        Me.GrpPrecios = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCost = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnSiguiente = New Janus.Windows.EditControls.UIButton
        Me.BtnAnterior = New Janus.Windows.EditControls.UIButton
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.cmbGrupo = New Selling.StoreCombo
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.TxtContador = New System.Windows.Forms.TextBox
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpPrecios.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpClas.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNombre
        '
        Me.TxtNombre.Enabled = False
        Me.TxtNombre.Location = New System.Drawing.Point(409, 52)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(429, 20)
        Me.TxtNombre.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(295, 55)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(112, 21)
        Me.LblNombre.TabIndex = 102
        Me.LblNombre.Text = "Nombre Comun"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(294, 16)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(99, 20)
        Me.LblClave.TabIndex = 101
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(409, 12)
        Me.TxtClave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(214, 20)
        Me.TxtClave.TabIndex = 1
        '
        'GridPrecios
        '
        Me.GridPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrecios.ColumnAutoResize = True
        Me.GridPrecios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrecios.Location = New System.Drawing.Point(9, 20)
        Me.GridPrecios.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridPrecios.Name = "GridPrecios"
        Me.GridPrecios.RecordNavigator = True
        Me.GridPrecios.Size = New System.Drawing.Size(534, 358)
        Me.GridPrecios.TabIndex = 1
        Me.GridPrecios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpPrecios
        '
        Me.GrpPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPrecios.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPrecios.Controls.Add(Me.GridPrecios)
        Me.GrpPrecios.Location = New System.Drawing.Point(293, 128)
        Me.GrpPrecios.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpPrecios.Name = "GrpPrecios"
        Me.GrpPrecios.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpPrecios.Size = New System.Drawing.Size(554, 388)
        Me.GrpPrecios.TabIndex = 5
        Me.GrpPrecios.TabStop = False
        Me.GrpPrecios.Text = "Precios "
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Location = New System.Drawing.Point(294, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Costo Sin Imp."
        '
        'TxtCost
        '
        Me.TxtCost.Location = New System.Drawing.Point(409, 96)
        Me.TxtCost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtCost.Name = "TxtCost"
        Me.TxtCost.Size = New System.Drawing.Size(196, 20)
        Me.TxtCost.TabIndex = 4
        Me.TxtCost.Text = "0.00"
        Me.TxtCost.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCost.Value = 0
        Me.TxtCost.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Icon = CType(resources.GetObject("BtnGuardar.Icon"), System.Drawing.Icon)
        Me.BtnGuardar.Location = New System.Drawing.Point(721, 521)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(126, 39)
        Me.BtnGuardar.TabIndex = 7
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(579, 521)
        Me.BtnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(126, 39)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Guardar cambios"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(385, 98)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.TabIndex = 122
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(385, 16)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 124
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnSiguiente
        '
        Me.BtnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSiguiente.Icon = CType(resources.GetObject("BtnSiguiente.Icon"), System.Drawing.Icon)
        Me.BtnSiguiente.Location = New System.Drawing.Point(437, 521)
        Me.BtnSiguiente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSiguiente.Name = "BtnSiguiente"
        Me.BtnSiguiente.Size = New System.Drawing.Size(126, 39)
        Me.BtnSiguiente.TabIndex = 135
        Me.BtnSiguiente.Text = "&Siguiente"
        Me.BtnSiguiente.ToolTipText = "Muestra el siguiente registro"
        Me.BtnSiguiente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAnterior
        '
        Me.BtnAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAnterior.Icon = CType(resources.GetObject("BtnAnterior.Icon"), System.Drawing.Icon)
        Me.BtnAnterior.Location = New System.Drawing.Point(293, 521)
        Me.BtnAnterior.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnAnterior.Name = "BtnAnterior"
        Me.BtnAnterior.Size = New System.Drawing.Size(126, 39)
        Me.BtnAnterior.TabIndex = 136
        Me.BtnAnterior.Text = "A&nterior"
        Me.BtnAnterior.ToolTipText = "Muestra el registro anterior"
        Me.BtnAnterior.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(3, 5)
        Me.GrpClas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpClas.Size = New System.Drawing.Size(280, 555)
        Me.GrpClas.TabIndex = 137
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(9, 19)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(261, 21)
        Me.cmbGrupo.TabIndex = 9
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(9, 47)
        Me.TreeViewClass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(261, 498)
        Me.TreeViewClass.TabIndex = 0
        '
        'TxtContador
        '
        Me.TxtContador.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.TxtContador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtContador.Location = New System.Drawing.Point(657, 14)
        Me.TxtContador.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtContador.Name = "TxtContador"
        Me.TxtContador.Size = New System.Drawing.Size(180, 20)
        Me.TxtContador.TabIndex = 138
        Me.TxtContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmActCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(854, 565)
        Me.Controls.Add(Me.TxtContador)
        Me.Controls.Add(Me.GrpClas)
        Me.Controls.Add(Me.BtnAnterior)
        Me.Controls.Add(Me.BtnSiguiente)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpPrecios)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCost)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtClave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(870, 603)
        Me.Name = "FrmActCosto"
        Me.Text = "Actualización de Costos"
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpPrecios.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpClas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GridPrecios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCost As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSiguiente As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAnterior As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents TxtContador As System.Windows.Forms.TextBox
    Friend WithEvents cmbGrupo As Selling.StoreCombo
End Class
