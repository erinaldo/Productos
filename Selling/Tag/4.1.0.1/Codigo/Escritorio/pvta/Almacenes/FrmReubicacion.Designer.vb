<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReubicacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReubicacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkSinUbicar = New System.Windows.Forms.CheckBox()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.GridOrigen = New Janus.Windows.GridEX.GridEX()
        Me.BtnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridDestino = New Janus.Windows.GridEX.GridEX()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.BtnBuscaUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UiTabUbica = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabManual = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabArchivo = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GridFile = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BtnFile = New Janus.Windows.EditControls.UIButton()
        Me.cmbSucursalO = New Selling.StoreCombo()
        Me.CmbOrigen = New Selling.StoreCombo()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUbica.SuspendLayout()
        Me.UiTabManual.SuspendLayout()
        Me.UiTabArchivo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ChkSinUbicar)
        Me.GroupBox1.Controls.Add(Me.CmbTipo)
        Me.GroupBox1.Controls.Add(Me.GridOrigen)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtClave)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(899, 280)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'ChkSinUbicar
        '
        Me.ChkSinUbicar.AutoSize = True
        Me.ChkSinUbicar.Location = New System.Drawing.Point(499, 25)
        Me.ChkSinUbicar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChkSinUbicar.Name = "ChkSinUbicar"
        Me.ChkSinUbicar.Size = New System.Drawing.Size(271, 17)
        Me.ChkSinUbicar.TabIndex = 103
        Me.ChkSinUbicar.Text = "Ver Todos los Productos que No han sido Ubicados"
        Me.ChkSinUbicar.UseVisualStyleBackColor = True
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(7, 22)
        Me.CmbTipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(154, 21)
        Me.CmbTipo.TabIndex = 102
        '
        'GridOrigen
        '
        Me.GridOrigen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOrigen.ColumnAutoResize = True
        Me.GridOrigen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridOrigen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridOrigen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridOrigen.GroupByBoxVisible = False
        Me.GridOrigen.Location = New System.Drawing.Point(7, 55)
        Me.GridOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridOrigen.Name = "GridOrigen"
        Me.GridOrigen.RecordNavigator = True
        Me.GridOrigen.Size = New System.Drawing.Size(885, 217)
        Me.GridOrigen.TabIndex = 101
        Me.GridOrigen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(461, 18)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscar.TabIndex = 99
        Me.BtnBuscar.ToolTipText = "Busqueda"
        Me.BtnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClave
        '
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(169, 22)
        Me.TxtClave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(284, 21)
        Me.TxtClave.TabIndex = 98
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(830, 605)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 67
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(734, 605)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 68
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.GridDestino)
        Me.GroupBox2.Controls.Add(Me.lblDestino)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaUbicacion)
        Me.GroupBox2.Controls.Add(Me.TxtUbicacion)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 292)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(899, 238)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 18)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Ubicación"
        '
        'GridDestino
        '
        Me.GridDestino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDestino.ColumnAutoResize = True
        Me.GridDestino.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDestino.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDestino.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDestino.GroupByBoxVisible = False
        Me.GridDestino.Location = New System.Drawing.Point(8, 53)
        Me.GridDestino.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridDestino.Name = "GridDestino"
        Me.GridDestino.RecordNavigator = True
        Me.GridDestino.Size = New System.Drawing.Size(884, 177)
        Me.GridDestino.TabIndex = 103
        Me.GridDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblDestino
        '
        Me.lblDestino.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblDestino.Location = New System.Drawing.Point(363, 23)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(258, 18)
        Me.lblDestino.TabIndex = 102
        Me.lblDestino.Text = "Ubicación"
        '
        'BtnBuscaUbicacion
        '
        Me.BtnBuscaUbicacion.Image = CType(resources.GetObject("BtnBuscaUbicacion.Image"), System.Drawing.Image)
        Me.BtnBuscaUbicacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaUbicacion.Location = New System.Drawing.Point(323, 16)
        Me.BtnBuscaUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaUbicacion.Name = "BtnBuscaUbicacion"
        Me.BtnBuscaUbicacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaUbicacion.TabIndex = 101
        Me.BtnBuscaUbicacion.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(90, 21)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(227, 21)
        Me.TxtUbicacion.TabIndex = 100
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(319, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Almacén"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(2, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Sucursal"
        '
        'UiTabUbica
        '
        Me.UiTabUbica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabUbica.Location = New System.Drawing.Point(5, 42)
        Me.UiTabUbica.Name = "UiTabUbica"
        Me.UiTabUbica.Size = New System.Drawing.Size(915, 556)
        Me.UiTabUbica.TabIndex = 134
        Me.UiTabUbica.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabManual, Me.UiTabArchivo})
        Me.UiTabUbica.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabManual
        '
        Me.UiTabManual.Controls.Add(Me.GroupBox1)
        Me.UiTabManual.Controls.Add(Me.GroupBox2)
        Me.UiTabManual.Location = New System.Drawing.Point(1, 21)
        Me.UiTabManual.Name = "UiTabManual"
        Me.UiTabManual.Size = New System.Drawing.Size(913, 534)
        Me.UiTabManual.TabStop = True
        Me.UiTabManual.Text = "Manual"
        '
        'UiTabArchivo
        '
        Me.UiTabArchivo.Controls.Add(Me.GroupBox3)
        Me.UiTabArchivo.Controls.Add(Me.GroupBox4)
        Me.UiTabArchivo.Location = New System.Drawing.Point(1, 21)
        Me.UiTabArchivo.Name = "UiTabArchivo"
        Me.UiTabArchivo.Size = New System.Drawing.Size(913, 534)
        Me.UiTabArchivo.TabStop = True
        Me.UiTabArchivo.Text = "Archivo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.GridFile)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 77)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(898, 453)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Destino"
        '
        'GridFile
        '
        Me.GridFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridFile.ColumnAutoResize = True
        Me.GridFile.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridFile.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridFile.GroupByBoxVisible = False
        Me.GridFile.Location = New System.Drawing.Point(8, 21)
        Me.GridFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridFile.Name = "GridFile"
        Me.GridFile.RecordNavigator = True
        Me.GridFile.Size = New System.Drawing.Size(883, 424)
        Me.GridFile.TabIndex = 103
        Me.GridFile.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.BtnFile)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(898, 65)
        Me.GroupBox4.TabIndex = 71
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Origen"
        '
        'BtnFile
        '
        Me.BtnFile.Image = CType(resources.GetObject("BtnFile.Image"), System.Drawing.Image)
        Me.BtnFile.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnFile.Location = New System.Drawing.Point(8, 18)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(83, 39)
        Me.BtnFile.TabIndex = 122
        Me.BtnFile.Text = "Importar"
        Me.BtnFile.ToolTipText = "Seleccionar y procesar el archivo con el detalle de los productos a reubicar"
        Me.BtnFile.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbSucursalO
        '
        Me.cmbSucursalO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalO.Location = New System.Drawing.Point(70, 12)
        Me.cmbSucursalO.Name = "cmbSucursalO"
        Me.cmbSucursalO.Size = New System.Drawing.Size(234, 21)
        Me.cmbSucursalO.TabIndex = 133
        '
        'CmbOrigen
        '
        Me.CmbOrigen.Location = New System.Drawing.Point(382, 12)
        Me.CmbOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(234, 21)
        Me.CmbOrigen.TabIndex = 97
        '
        'FrmReubicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(924, 650)
        Me.Controls.Add(Me.UiTabUbica)
        Me.Controls.Add(Me.cmbSucursalO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.CmbOrigen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(940, 688)
        Me.Name = "FrmReubicacion"
        Me.Text = "Reubicación de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUbica.ResumeLayout(False)
        Me.UiTabManual.ResumeLayout(False)
        Me.UiTabArchivo.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbOrigen As Selling.StoreCombo
    Friend WithEvents BtnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents GridOrigen As Janus.Windows.GridEX.GridEX
    Friend WithEvents GridDestino As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents ChkSinUbicar As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalO As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiTabUbica As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabManual As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabArchivo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GridFile As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFile As Janus.Windows.EditControls.UIButton
End Class
