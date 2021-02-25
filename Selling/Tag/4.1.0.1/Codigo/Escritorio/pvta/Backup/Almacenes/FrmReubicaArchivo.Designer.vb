<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReubicaArchivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReubicaArchivo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscar = New Janus.Windows.EditControls.UIButton
        Me.TxtUbcOrigen = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lblPorc = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.BtnFile = New Janus.Windows.EditControls.UIButton
        Me.TxtPath = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.GridDestino = New Janus.Windows.GridEX.GridEX
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.CmbOrigen = New Selling.StoreCombo
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnBuscar)
        Me.GroupBox1.Controls.Add(Me.TxtUbcOrigen)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 55)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(906, 65)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(69, 23)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.TabIndex = 124
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 25)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Ubicación"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(385, 18)
        Me.BtnBuscar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscar.TabIndex = 99
        Me.BtnBuscar.ToolTipText = "Busqueda"
        Me.BtnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbcOrigen
        '
        Me.TxtUbcOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbcOrigen.Location = New System.Drawing.Point(93, 20)
        Me.TxtUbcOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbcOrigen.Name = "TxtUbcOrigen"
        Me.TxtUbcOrigen.ReadOnly = True
        Me.TxtUbcOrigen.Size = New System.Drawing.Size(284, 21)
        Me.TxtUbcOrigen.TabIndex = 98
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.lblPorc)
        Me.GroupBox2.Controls.Add(Me.PBar)
        Me.GroupBox2.Controls.Add(Me.BtnFile)
        Me.GroupBox2.Controls.Add(Me.TxtPath)
        Me.GroupBox2.Controls.Add(Me.LblClave)
        Me.GroupBox2.Controls.Add(Me.GridDestino)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 128)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(906, 472)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 25)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "Progreso"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(90, 23)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox3.TabIndex = 124
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lblPorc
        '
        Me.lblPorc.Location = New System.Drawing.Point(812, 55)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(51, 22)
        Me.lblPorc.TabIndex = 125
        Me.lblPorc.Text = "0 %"
        Me.lblPorc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(115, 52)
        Me.PBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(686, 28)
        Me.PBar.TabIndex = 124
        '
        'BtnFile
        '
        Me.BtnFile.Image = CType(resources.GetObject("BtnFile.Image"), System.Drawing.Image)
        Me.BtnFile.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnFile.Location = New System.Drawing.Point(818, 16)
        Me.BtnFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnFile.Name = "BtnFile"
        Me.BtnFile.Size = New System.Drawing.Size(47, 39)
        Me.BtnFile.TabIndex = 122
        Me.BtnFile.ToolTipText = "Seleccionar y procesar el archivo con el detalle de los productos a reubicar"
        '
        'TxtPath
        '
        Me.TxtPath.Location = New System.Drawing.Point(115, 21)
        Me.TxtPath.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.ReadOnly = True
        Me.TxtPath.Size = New System.Drawing.Size(685, 20)
        Me.TxtPath.TabIndex = 120
        Me.TxtPath.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 28)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(77, 25)
        Me.LblClave.TabIndex = 121
        Me.LblClave.Text = "Archivo"
        '
        'GridDestino
        '
        Me.GridDestino.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDestino.ColumnAutoResize = True
        Me.GridDestino.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDestino.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDestino.GroupByBoxVisible = False
        Me.GridDestino.Location = New System.Drawing.Point(8, 87)
        Me.GridDestino.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridDestino.Name = "GridDestino"
        Me.GridDestino.RecordNavigator = True
        Me.GridDestino.Size = New System.Drawing.Size(891, 377)
        Me.GridDestino.TabIndex = 103
        Me.GridDestino.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(93, 23)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 123
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Almacén"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(830, 608)
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
        Me.BtnCancel.Location = New System.Drawing.Point(733, 608)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 68
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "CSV|*.csv"
        '
        'CmbOrigen
        '
        Me.CmbOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbOrigen.Location = New System.Drawing.Point(107, 20)
        Me.CmbOrigen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CmbOrigen.Name = "CmbOrigen"
        Me.CmbOrigen.Size = New System.Drawing.Size(439, 21)
        Me.CmbOrigen.TabIndex = 97
        '
        'FrmReubicaArchivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(924, 650)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.CmbOrigen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(940, 688)
        Me.Name = "FrmReubicaArchivo"
        Me.Text = "Reubicación de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbOrigen As Selling.StoreCombo
    Friend WithEvents BtnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUbcOrigen As System.Windows.Forms.TextBox
    Friend WithEvents GridDestino As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnFile As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtPath As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
