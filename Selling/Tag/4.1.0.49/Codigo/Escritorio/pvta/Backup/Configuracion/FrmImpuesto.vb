Public Class FrmImpuesto
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GrpImpuesto As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents numJerarquia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkCalcular As Selling.ChkStatus
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTAplicacion As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoCte As Selling.StoreCombo
    Friend WithEvents TxtValor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoPrd As Selling.StoreCombo
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents dtVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImpuesto))
        Me.GrpImpuesto = New System.Windows.Forms.GroupBox
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.lblInicio = New System.Windows.Forms.Label
        Me.dtVigencia = New System.Windows.Forms.DateTimePicker
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbTipoPrd = New Selling.StoreCombo
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtValor = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbTipoCte = New Selling.StoreCombo
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ChkCalcular = New Selling.ChkStatus(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbTAplicacion = New Selling.StoreCombo
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.numJerarquia = New System.Windows.Forms.NumericUpDown
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpImpuesto.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJerarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpImpuesto
        '
        Me.GrpImpuesto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpImpuesto.Controls.Add(Me.GrpDetalle)
        Me.GrpImpuesto.Controls.Add(Me.PictureBox3)
        Me.GrpImpuesto.Controls.Add(Me.ChkCalcular)
        Me.GrpImpuesto.Controls.Add(Me.Label1)
        Me.GrpImpuesto.Controls.Add(Me.cmbTAplicacion)
        Me.GrpImpuesto.Controls.Add(Me.PictureBox2)
        Me.GrpImpuesto.Controls.Add(Me.ChkEstado)
        Me.GrpImpuesto.Controls.Add(Me.Label2)
        Me.GrpImpuesto.Controls.Add(Me.numJerarquia)
        Me.GrpImpuesto.Controls.Add(Me.TxtDescripcion)
        Me.GrpImpuesto.Controls.Add(Me.LblNombre)
        Me.GrpImpuesto.Controls.Add(Me.TxtNombre)
        Me.GrpImpuesto.Controls.Add(Me.LblClave)
        Me.GrpImpuesto.Controls.Add(Me.PictureBox1)
        Me.GrpImpuesto.Controls.Add(Me.Label4)
        Me.GrpImpuesto.Location = New System.Drawing.Point(5, 3)
        Me.GrpImpuesto.Name = "GrpImpuesto"
        Me.GrpImpuesto.Size = New System.Drawing.Size(677, 330)
        Me.GrpImpuesto.TabIndex = 1
        Me.GrpImpuesto.TabStop = False
        Me.GrpImpuesto.Text = "Impuesto"
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDetalle.Controls.Add(Me.PictureBox7)
        Me.GrpDetalle.Controls.Add(Me.lblInicio)
        Me.GrpDetalle.Controls.Add(Me.dtVigencia)
        Me.GrpDetalle.Controls.Add(Me.PictureBox6)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.CmbTipoPrd)
        Me.GrpDetalle.Controls.Add(Me.BtnDel)
        Me.GrpDetalle.Controls.Add(Me.PictureBox4)
        Me.GrpDetalle.Controls.Add(Me.PictureBox5)
        Me.GrpDetalle.Controls.Add(Me.BtnAdd)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.Label9)
        Me.GrpDetalle.Controls.Add(Me.TxtValor)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.CmbTipoCte)
        Me.GrpDetalle.Location = New System.Drawing.Point(8, 102)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(662, 217)
        Me.GrpDetalle.TabIndex = 67
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Regla de Aplicación"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(479, 19)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox7.TabIndex = 139
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(385, 22)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(136, 16)
        Me.lblInicio.TabIndex = 138
        Me.lblInicio.Text = "Inicio Vigencia"
        '
        'dtVigencia
        '
        Me.dtVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVigencia.Location = New System.Drawing.Point(385, 40)
        Me.dtVigencia.Name = "dtVigencia"
        Me.dtVigencia.Size = New System.Drawing.Size(118, 20)
        Me.dtVigencia.TabIndex = 137
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(355, 22)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox6.TabIndex = 69
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(150, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "T. Imp. Prd"
        '
        'CmbTipoPrd
        '
        Me.CmbTipoPrd.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoPrd.Location = New System.Drawing.Point(150, 40)
        Me.CmbTipoPrd.Name = "CmbTipoPrd"
        Me.CmbTipoPrd.Size = New System.Drawing.Size(134, 21)
        Me.CmbTipoPrd.TabIndex = 67
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(614, 30)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(39, 30)
        Me.BtnDel.TabIndex = 1
        Me.BtnDel.ToolTipText = "Eliminar regla seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(123, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox4.TabIndex = 65
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(261, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox5.TabIndex = 66
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(569, 30)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(39, 30)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.ToolTipText = "Agregar regla de aplicación"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.Location = New System.Drawing.Point(6, 67)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(650, 136)
        Me.GridDetalle.TabIndex = 2
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "T. Imp. Cte"
        '
        'TxtValor
        '
        Me.TxtValor.DecimalDigits = 3
        Me.TxtValor.Location = New System.Drawing.Point(294, 41)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(81, 20)
        Me.TxtValor.TabIndex = 63
        Me.TxtValor.Text = "0.000"
        Me.TxtValor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtValor.Value = 0
        Me.TxtValor.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(294, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 16)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Valor"
        '
        'CmbTipoCte
        '
        Me.CmbTipoCte.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoCte.Location = New System.Drawing.Point(6, 40)
        Me.CmbTipoCte.Name = "CmbTipoCte"
        Me.CmbTipoCte.Size = New System.Drawing.Size(134, 21)
        Me.CmbTipoCte.TabIndex = 57
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(233, 75)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox3.TabIndex = 64
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'ChkCalcular
        '
        Me.ChkCalcular.Checked = True
        Me.ChkCalcular.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCalcular.Location = New System.Drawing.Point(416, 74)
        Me.ChkCalcular.Name = "ChkCalcular"
        Me.ChkCalcular.Size = New System.Drawing.Size(212, 22)
        Me.ChkCalcular.TabIndex = 62
        Me.ChkCalcular.Text = "Calcular despues de impuestos"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Aplicación"
        '
        'cmbTAplicacion
        '
        Me.cmbTAplicacion.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTAplicacion.Location = New System.Drawing.Point(77, 74)
        Me.cmbTAplicacion.Name = "cmbTAplicacion"
        Me.cmbTAplicacion.Size = New System.Drawing.Size(153, 21)
        Me.cmbTAplicacion.TabIndex = 59
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(403, 49)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(330, 20)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(67, 23)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(243, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Jerarquía"
        '
        'numJerarquia
        '
        Me.numJerarquia.Location = New System.Drawing.Point(311, 74)
        Me.numJerarquia.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numJerarquia.Name = "numJerarquia"
        Me.numJerarquia.Size = New System.Drawing.Size(87, 20)
        Me.numJerarquia.TabIndex = 3
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(75, 48)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(322, 20)
        Me.TxtDescripcion.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(5, 52)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Descripción"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(75, 22)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(150, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(5, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(230, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(230, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(495, 339)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(592, 339)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmImpuesto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(687, 383)
        Me.Controls.Add(Me.GrpImpuesto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImpuesto"
        Me.Text = "Impuesto"
        Me.GrpImpuesto.ResumeLayout(False)
        Me.GrpImpuesto.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJerarquia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public IMPClave As String
    Public Nombre As String
    Public Descripcion As String
    Public Estado As Integer = 1
    Public Jerarquia As Integer
    Public TAplicacion As Integer
    Public SobreImpuesto As Boolean


    Private alerta(6) As PictureBox
    Private reloj As parpadea

    Private dtImpuestoDetalle, dtTipoImpuesto As DataTable

    Private sImpVigente As String

    Private Function validaRegla() As Boolean
        Dim i As Integer = 0


        If Me.CmbTipoCte.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoPrd.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(TxtValor.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If dtVigencia.Value < Today Then
            MessageBox.Show("El inicio de vigencia del impuesto actual no puede ser menor al día actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If



        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 10 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 10)

        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)
        End If

        If Me.cmbTAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Impuesto", "@clave", UCase(Trim(Me.TxtNombre.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function



    Private Sub addRegla(ByVal iTipoCte As Integer, ByVal iTipoPrd As Integer, ByVal dValor As Double, ByVal dInicio As Date)
        Dim foundRows() As Data.DataRow
        foundRows = dtImpuestoDetalle.Select("TipoImpCte = " & iTipoCte & " and TipoImpPrd = " & iTipoPrd & " and Baja = 0  and Inicio =#" & dInicio.Date.ToString("MM/dd/yyyy") & "#")

        If foundRows.Length = 0 Then
            foundRows = dtImpuestoDetalle.Select("TipoImpCte = " & iTipoCte & " and TipoImpPrd = " & iTipoPrd & " and Baja = 0  and Fin =#12/31/9999#")

            If foundRows.Length > 0 Then
                foundRows(0)("Fin") = dInicio.AddMinutes(-1)
                foundRows(0)("Nuevo") = IIf(foundRows(0)("Nuevo") = 0, 2, 1)
            End If

            Dim row1 As DataRow
            row1 = dtImpuestoDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("TipoImpCte") = iTipoCte
            row1.Item("TipoImpPrd") = iTipoPrd
            row1.Item("Valor") = dValor
            row1.Item("Inicio") = dInicio
            row1.Item("Fin") = CDate("#9999/12/31#")
            row1.Item("Nuevo") = 1
            row1.Item("Baja") = 0


            dtImpuestoDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

        Else
            Beep()
            MessageBox.Show("Se encontro una regla con inicio de vigencia el mismo día!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub FrmImpuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7

        With Me.CmbTipoCte
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbTipoPrd
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.cmbTAplicacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Aplicacion"
            .llenar()
        End With

        dtVigencia.Value = Today.Date

        If Padre <> "Agregar" Then

            dtImpuestoDetalle = ModPOS.Recupera_Tabla("sp_recupera_impuestodetalle", "@IMPClave", IMPClave)
        Else
            dtImpuestoDetalle = ModPOS.CrearTabla("ImpuestoDetalle", _
             "ID", "System.String", _
             "TipoImpCte", "System.Int32", _
             "TipoImpPrd", "System.Int32", _
             "Valor", "System.Double", _
             "Inicio", "System.DateTime", _
             "Fin", "System.DateTime", _
             "Nuevo", "System.Int32", _
             "Baja", "System.Int32")
        End If

        GridDetalle.DataSource = dtImpuestoDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Baja").Visible = False


        dtTipoImpuesto = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Impuesto", "@Campo", "Tipo")


        GridDetalle.CurrentTable.Columns("TipoImpCte").HasValueList = True
        GridDetalle.CurrentTable.Columns("TipoImpPrd").HasValueList = True

        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("TipoImpCte").ValueList


        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = GridDetalle.Tables(0).Columns("TipoImpPrd").ValueList

        With AircraftTypeValueListItemCollection
            Dim i As Integer
            For i = 0 To dtTipoImpuesto.Rows.Count - 1
                .Add(dtTipoImpuesto.Rows(i)("Valor"), dtTipoImpuesto.Rows(i)("Descripcion"))
            Next
        End With

        With AircraftTypeValueListItemCollection2
            Dim i As Integer
            For i = 0 To dtTipoImpuesto.Rows.Count - 1
                .Add(dtTipoImpuesto.Rows(i)("Valor"), dtTipoImpuesto.Rows(i)("Descripcion"))
            Next
        End With

        GridDetalle.CurrentTable.Columns("TipoImpCte").EditType = Janus.Windows.GridEX.EditType.Combo
        GridDetalle.CurrentTable.Columns("TipoImpPrd").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc1)

        TxtNombre.Text = Nombre
        TxtDescripcion.Text = Descripcion
        cmbTAplicacion.SelectedValue = TAplicacion
        numJerarquia.Value = Jerarquia
        ChkCalcular.Checked = SobreImpuesto
        ChkEstado.Estado = Estado


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim i As Integer
            Dim foundRows() As DataRow

            Select Case Me.Padre
                Case "Agregar"

                    IMPClave = ModPOS.obtenerLlave
                    Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                    TAplicacion = cmbTAplicacion.SelectedValue
                    Jerarquia = numJerarquia.Value
                    SobreImpuesto = ChkCalcular.Checked



                    ModPOS.Ejecuta("sp_inserta_impuesto", _
                    "@IMPClave", IMPClave, _
                    "@Nombre", Nombre, _
                    "@Descripcion", Descripcion, _
                    "@Jerarquia", Jerarquia, _
                    "@TAplicacion", TAplicacion, _
                    "@SobreImp", SobreImpuesto, _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@Usuario", ModPOS.UsuarioActual)



                    foundRows = dtImpuestoDetalle.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_impdet", _
                                           "@DIPClave", foundRows(i)("ID"), _
                                           "@IMPClave", IMPClave, _
                                           "@TipoImpCte", foundRows(i)("TipoImpCte"), _
                                           "@TipoImpPrd", foundRows(i)("TipoImpPrd"), _
                                           "@Valor", foundRows(i)("Valor"), _
                                           "@Inicio", foundRows(i)("Inicio"), _
                                           "@Fin", foundRows(i)("Fin"), _
                                           "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If Not ModPOS.MtoImp Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoImp.GridImpuestos, "sp_muestra_impuestos", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoImp.GridImpuestos.RootTable.Columns("IMPClave").Visible = False
                    End If


                    TxtNombre.Text = ""
                    TxtDescripcion.Text = ""
                    numJerarquia.Value = 0

                Case "Modificar"
                    If Not (Estado = ChkEstado.GetEstado AndAlso _
                        Descripcion = TxtDescripcion.Text AndAlso _
                        TAplicacion = cmbTAplicacion.SelectedValue AndAlso _
                        Jerarquia = numJerarquia.Value AndAlso _
                        SobreImpuesto = ChkCalcular.Checked) Then

                        Me.Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                        Me.Estado = ChkEstado.GetEstado
                        TAplicacion = cmbTAplicacion.SelectedValue
                        Jerarquia = numJerarquia.Value
                        SobreImpuesto = ChkCalcular.Checked

                        ModPOS.Ejecuta("sp_actualiza_impuesto", _
                        "@IMPClave", IMPClave, _
                        "@Descripcion", Descripcion, _
                        "@Jerarquia", Jerarquia, _
                        "@TAplicacion", TAplicacion, _
                        "@SobreImp", SobreImpuesto, _
                        "@Estado", Estado, _
                        "@Usuario", ModPOS.UsuarioActual)

                       
                        If Not ModPOS.MtoImp Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoImp.GridImpuestos, "sp_muestra_impuestos", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoImp.GridImpuestos.RootTable.Columns("IMPClave").Visible = False
                        End If
                    End If


                    foundRows = dtImpuestoDetalle.Select("Nuevo=1 and Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_impdet", _
                                      "@DIPClave", foundRows(i)("ID"), _
                                      "@IMPClave", IMPClave, _
                                      "@TipoImpCte", foundRows(i)("TipoImpCte"), _
                                      "@TipoImpPrd", foundRows(i)("TipoImpPrd"), _
                                      "@Valor", foundRows(i)("Valor"), _
                                      "@Inicio", foundRows(i)("Inicio"), _
                                      "@Fin", foundRows(i)("Fin"), _
                                      "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtImpuestoDetalle.Select("Nuevo= 2 and Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_actualiza_impdet", _
                                        "@DIPClave", foundRows(i)("ID"), _
                                        "@Fin", foundRows(i)("Fin"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtImpuestoDetalle.Select("Baja = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_impdet", _
                                      "@DIPClave", foundRows(i)("ID"), _
                                      "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmImpuesto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Impuesto.Dispose()
        ModPOS.Impuesto = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If validaRegla() Then

            addRegla(CmbTipoCte.SelectedValue, CmbTipoPrd.SelectedValue, TxtValor.Text, dtVigencia.Value)

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If sImpVigente <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la vigencia seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtImpuestoDetalle.Select(" ID = '" & sImpVigente & "'")
                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If
            End Select
        End If
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not GridDetalle.GetValue("ID") Is Nothing Then
            Me.BtnDel.Enabled = True
            Me.sImpVigente = GridDetalle.GetValue("ID")
        Else
            Me.BtnDel.Enabled = False
            Me.sImpVigente = ""
        End If

    End Sub
End Class
