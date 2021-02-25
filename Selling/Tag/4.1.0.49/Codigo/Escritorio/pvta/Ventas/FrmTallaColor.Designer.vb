<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTallaColor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTallaColor))
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.cmbColor = New Selling.StoreCombo()
        Me.cmbTalla = New Selling.StoreCombo()
        Me.lblModelo = New System.Windows.Forms.Label()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(17, 41)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox18.TabIndex = 127
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(3, 48)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(57, 15)
        Me.lblColor.TabIndex = 126
        Me.lblColor.Text = "Color"
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(294, 41)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox17.TabIndex = 124
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'lblTalla
        '
        Me.lblTalla.Location = New System.Drawing.Point(285, 46)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(37, 15)
        Me.lblTalla.TabIndex = 123
        Me.lblTalla.Text = "Talla"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(403, 76)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(307, 76)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar Envio"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.SystemColors.Window
        Me.cmbColor.Location = New System.Drawing.Point(43, 41)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(236, 22)
        Me.cmbColor.TabIndex = 1
        '
        'cmbTalla
        '
        Me.cmbTalla.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTalla.Location = New System.Drawing.Point(320, 41)
        Me.cmbTalla.Name = "cmbTalla"
        Me.cmbTalla.Size = New System.Drawing.Size(173, 22)
        Me.cmbTalla.TabIndex = 2
        '
        'lblModelo
        '
        Me.lblModelo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelo.Location = New System.Drawing.Point(12, 9)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(385, 15)
        Me.lblModelo.TabIndex = 128
        Me.lblModelo.Text = "MODELO"
        '
        'FrmTallaColor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(505, 125)
        Me.Controls.Add(Me.lblModelo)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.PictureBox18)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.cmbTalla)
        Me.Controls.Add(Me.PictureBox17)
        Me.Controls.Add(Me.lblTalla)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(521, 164)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(521, 164)
        Me.Name = "FrmTallaColor"
        Me.Text = "Talla y Color"
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbColor As Selling.StoreCombo
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents cmbTalla As Selling.StoreCombo
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblModelo As System.Windows.Forms.Label
End Class
