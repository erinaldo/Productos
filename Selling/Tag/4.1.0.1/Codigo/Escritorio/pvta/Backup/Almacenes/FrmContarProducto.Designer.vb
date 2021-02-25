<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContarProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContarProducto))
        Me.GrpProductos = New System.Windows.Forms.GroupBox
        Me.LblFile = New System.Windows.Forms.Label
        Me.BtnFile = New Janus.Windows.EditControls.UIButton
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.lblPorc = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpClas = New System.Windows.Forms.GroupBox
        Me.TreeViewClass = New System.Windows.Forms.TreeView
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GrpProductos.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpClas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.Controls.Add(Me.LblFile)
        Me.GrpProductos.Controls.Add(Me.BtnFile)
        Me.GrpProductos.Controls.Add(Me.CmbCampo)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Location = New System.Drawing.Point(287, 0)
        Me.GrpProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpProductos.Size = New System.Drawing.Size(539, 476)
        Me.GrpProductos.TabIndex = 1
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Detalle de Conteo"
        '
        'LblFile
        '
        Me.LblFile.Location = New System.Drawing.Point(280, 32)
        Me.LblFile.Name = "LblFile"
        Me.LblFile.Size = New System.Drawing.Size(194, 22)
        Me.LblFile.TabIndex = 126
        Me.LblFile.Text = "Importar conteo desde Arch."
        '
        'BtnFile
        '
        Me.BtnFile.Image = CType(resources.GetObject("BtnFile.Image"), System.Drawing.Image)
        Me.BtnFile.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnFile.Location = New System.Drawing.Point(481, 15)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(47, 39)
        Me.BtnFile.TabIndex = 125
        Me.BtnFile.ToolTipText = "Importar conteo desde archivo (*.CSV con  C. Barras, Cantidad)"
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(9, 55)
        Me.CmbCampo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(224, 21)
        Me.CmbCampo.TabIndex = 7
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(241, 57)
        Me.TxtBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(286, 20)
        Me.TxtBuscar.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(9, 89)
        Me.GridProductos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(520, 378)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblPorc
        '
        Me.lblPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorc.Location = New System.Drawing.Point(510, 495)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(51, 22)
        Me.lblPorc.TabIndex = 121
        Me.lblPorc.Text = "0 %"
        '
        'PBar
        '
        Me.PBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBar.Location = New System.Drawing.Point(80, 489)
        Me.PBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(422, 28)
        Me.PBar.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(10, 495)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 22)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Guardando"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(640, 484)
        Me.BtnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 118
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y Cerrar Ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(736, 484)
        Me.BtnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 117
        Me.BtnGuardar.Text = "&Guardar"
        Me.BtnGuardar.ToolTipText = "Guarda los cambios realizados en la ubicación seleccionada"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(0, 1)
        Me.GrpClas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GrpClas.Size = New System.Drawing.Size(280, 475)
        Me.GrpClas.TabIndex = 122
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Lineas"
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(9, 20)
        Me.TreeViewClass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(261, 445)
        Me.TreeViewClass.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmContarProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(828, 528)
        Me.Controls.Add(Me.GrpClas)
        Me.Controls.Add(Me.lblPorc)
        Me.Controls.Add(Me.PBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpProductos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmContarProducto"
        Me.Text = "Contar"
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpClas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents LblFile As System.Windows.Forms.Label
    Friend WithEvents BtnFile As Janus.Windows.EditControls.UIButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
