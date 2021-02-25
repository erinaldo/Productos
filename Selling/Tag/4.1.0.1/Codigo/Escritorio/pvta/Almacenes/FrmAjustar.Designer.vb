<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjustar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustar))
        Me.GrpDiferencias = New System.Windows.Forms.GroupBox()
        Me.GridResumen = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.lblPorc = New System.Windows.Forms.Label()
        Me.PBarGuardando = New System.Windows.Forms.ProgressBar()
        Me.lblGuardando = New System.Windows.Forms.Label()
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.GrpDiferencias.SuspendLayout()
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDiferencias
        '
        Me.GrpDiferencias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDiferencias.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDiferencias.Controls.Add(Me.GridResumen)
        Me.GrpDiferencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDiferencias.ForeColor = System.Drawing.Color.Black
        Me.GrpDiferencias.Location = New System.Drawing.Point(3, 4)
        Me.GrpDiferencias.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpDiferencias.Name = "GrpDiferencias"
        Me.GrpDiferencias.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpDiferencias.Size = New System.Drawing.Size(906, 453)
        Me.GrpDiferencias.TabIndex = 1
        Me.GrpDiferencias.TabStop = False
        Me.GrpDiferencias.Text = "Diferencias en el Inventario"
        '
        'GridResumen
        '
        Me.GridResumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridResumen.ColumnAutoResize = True
        Me.GridResumen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridResumen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridResumen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridResumen.GroupByBoxVisible = False
        Me.GridResumen.Location = New System.Drawing.Point(9, 23)
        Me.GridResumen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridResumen.Name = "GridResumen"
        Me.GridResumen.RecordNavigator = True
        Me.GridResumen.Size = New System.Drawing.Size(890, 422)
        Me.GridResumen.TabIndex = 4
        Me.GridResumen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.GridDetalle)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(5, 464)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(906, 181)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicaciones con Diferencias"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.AutoEdit = True
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(9, 26)
        Me.GridDetalle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(890, 148)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(627, 654)
        Me.BtnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(819, 653)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "&Ajustar"
        Me.BtnGuardar.ToolTipText = "Realiza el ajuste de los productos seleccionados "
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(554, 663)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(51, 22)
        Me.lblPorc.TabIndex = 119
        Me.lblPorc.Text = "0 %"
        '
        'PBarGuardando
        '
        Me.PBarGuardando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBarGuardando.Location = New System.Drawing.Point(85, 657)
        Me.PBarGuardando.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PBarGuardando.Name = "PBarGuardando"
        Me.PBarGuardando.Size = New System.Drawing.Size(448, 28)
        Me.PBarGuardando.TabIndex = 118
        '
        'lblGuardando
        '
        Me.lblGuardando.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGuardando.Location = New System.Drawing.Point(9, 663)
        Me.lblGuardando.Name = "lblGuardando"
        Me.lblGuardando.Size = New System.Drawing.Size(75, 21)
        Me.lblGuardando.TabIndex = 117
        Me.lblGuardando.Text = "Guardando"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnImprimir.Location = New System.Drawing.Point(723, 653)
        Me.BtnImprimir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnImprimir.TabIndex = 120
        Me.BtnImprimir.Text = "&Imprimir"
        Me.BtnImprimir.ToolTipText = "Imprimir Ajustes"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAjustar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(924, 697)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.lblPorc)
        Me.Controls.Add(Me.PBarGuardando)
        Me.Controls.Add(Me.lblGuardando)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpDiferencias)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAjustar"
        Me.Text = "Ajustar"
        Me.GrpDiferencias.ResumeLayout(False)
        CType(Me.GridResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpDiferencias As System.Windows.Forms.GroupBox
    Friend WithEvents GridResumen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents PBarGuardando As System.Windows.Forms.ProgressBar
    Friend WithEvents lblGuardando As System.Windows.Forms.Label
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
End Class
