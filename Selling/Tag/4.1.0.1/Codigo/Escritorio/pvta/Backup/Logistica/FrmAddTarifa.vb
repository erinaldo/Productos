Public Class FrmAddTarifa
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbPaisOrigen As Selling.StoreCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpDestino As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPaisDestino As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents txtTarifa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbImpuesto As Selling.StoreCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbLocalidadOrigen As Selling.StoreCombo
    Friend WithEvents cmbEntidadOrigen As Selling.StoreCombo
    Friend WithEvents cmbLocalidadDestino As Selling.StoreCombo
    Friend WithEvents CmbEntidadDestino As Selling.StoreCombo
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtISR As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTarifaRefrigerado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtTotalRefrigerado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpOrigen As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddTarifa))
        Me.GrpOrigen = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbLocalidadOrigen = New Selling.StoreCombo
        Me.cmbEntidadOrigen = New Selling.StoreCombo
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbPaisOrigen = New Selling.StoreCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.GrpDestino = New System.Windows.Forms.GroupBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.cmbLocalidadDestino = New Selling.StoreCombo
        Me.CmbEntidadDestino = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbPaisDestino = New Selling.StoreCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblLimite = New System.Windows.Forms.Label
        Me.txtTarifa = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbImpuesto = New Selling.StoreCombo
        Me.Label13 = New System.Windows.Forms.Label
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtISR = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTarifaRefrigerado = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtTotalRefrigerado = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.GrpOrigen.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDestino.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpOrigen
        '
        Me.GrpOrigen.Controls.Add(Me.PictureBox3)
        Me.GrpOrigen.Controls.Add(Me.PictureBox2)
        Me.GrpOrigen.Controls.Add(Me.PictureBox1)
        Me.GrpOrigen.Controls.Add(Me.cmbLocalidadOrigen)
        Me.GrpOrigen.Controls.Add(Me.cmbEntidadOrigen)
        Me.GrpOrigen.Controls.Add(Me.Label6)
        Me.GrpOrigen.Controls.Add(Me.Label7)
        Me.GrpOrigen.Controls.Add(Me.cmbPaisOrigen)
        Me.GrpOrigen.Controls.Add(Me.Label8)
        Me.GrpOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpOrigen.Location = New System.Drawing.Point(7, 7)
        Me.GrpOrigen.Name = "GrpOrigen"
        Me.GrpOrigen.Size = New System.Drawing.Size(539, 77)
        Me.GrpOrigen.TabIndex = 1
        Me.GrpOrigen.TabStop = False
        Me.GrpOrigen.Text = "Origen"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(464, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 138
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(257, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 137
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(37, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 136
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbLocalidadOrigen
        '
        Me.cmbLocalidadOrigen.Location = New System.Drawing.Point(363, 37)
        Me.cmbLocalidadOrigen.Name = "cmbLocalidadOrigen"
        Me.cmbLocalidadOrigen.Size = New System.Drawing.Size(167, 21)
        Me.cmbLocalidadOrigen.TabIndex = 3
        '
        'cmbEntidadOrigen
        '
        Me.cmbEntidadOrigen.Location = New System.Drawing.Point(180, 37)
        Me.cmbEntidadOrigen.Name = "cmbEntidadOrigen"
        Me.cmbEntidadOrigen.Size = New System.Drawing.Size(167, 21)
        Me.cmbEntidadOrigen.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(361, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 14)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Localidad/Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(177, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 14)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Entidad/Estado"
        '
        'cmbPaisOrigen
        '
        Me.cmbPaisOrigen.Location = New System.Drawing.Point(8, 37)
        Me.cmbPaisOrigen.Name = "cmbPaisOrigen"
        Me.cmbPaisOrigen.Size = New System.Drawing.Size(167, 21)
        Me.cmbPaisOrigen.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 15)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "País"
        '
        'GrpDestino
        '
        Me.GrpDestino.Controls.Add(Me.PictureBox6)
        Me.GrpDestino.Controls.Add(Me.PictureBox5)
        Me.GrpDestino.Controls.Add(Me.PictureBox4)
        Me.GrpDestino.Controls.Add(Me.cmbLocalidadDestino)
        Me.GrpDestino.Controls.Add(Me.CmbEntidadDestino)
        Me.GrpDestino.Controls.Add(Me.Label1)
        Me.GrpDestino.Controls.Add(Me.Label2)
        Me.GrpDestino.Controls.Add(Me.cmbPaisDestino)
        Me.GrpDestino.Controls.Add(Me.Label3)
        Me.GrpDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpDestino.Location = New System.Drawing.Point(8, 89)
        Me.GrpDestino.Name = "GrpDestino"
        Me.GrpDestino.Size = New System.Drawing.Size(539, 76)
        Me.GrpDestino.TabIndex = 2
        Me.GrpDestino.TabStop = False
        Me.GrpDestino.Text = "Destino"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(462, 19)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox6.TabIndex = 141
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(256, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox5.TabIndex = 140
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(36, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 139
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'cmbLocalidadDestino
        '
        Me.cmbLocalidadDestino.Location = New System.Drawing.Point(362, 36)
        Me.cmbLocalidadDestino.Name = "cmbLocalidadDestino"
        Me.cmbLocalidadDestino.Size = New System.Drawing.Size(166, 21)
        Me.cmbLocalidadDestino.TabIndex = 3
        '
        'CmbEntidadDestino
        '
        Me.CmbEntidadDestino.Location = New System.Drawing.Point(180, 37)
        Me.CmbEntidadDestino.Name = "CmbEntidadDestino"
        Me.CmbEntidadDestino.Size = New System.Drawing.Size(167, 21)
        Me.CmbEntidadDestino.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(361, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 14)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Localidad/Municipio"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(177, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 14)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Entidad/Estado"
        '
        'cmbPaisDestino
        '
        Me.cmbPaisDestino.Location = New System.Drawing.Point(8, 37)
        Me.cmbPaisDestino.Name = "cmbPaisDestino"
        Me.cmbPaisDestino.Size = New System.Drawing.Size(167, 21)
        Me.cmbPaisDestino.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "País"
        '
        'lblLimite
        '
        Me.lblLimite.Location = New System.Drawing.Point(14, 214)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(73, 14)
        Me.lblLimite.TabIndex = 59
        Me.lblLimite.Text = "Tarifa Seco"
        '
        'txtTarifa
        '
        Me.txtTarifa.Location = New System.Drawing.Point(117, 210)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(77, 20)
        Me.txtTarifa.TabIndex = 6
        Me.txtTarifa.Text = "0.00"
        Me.txtTarifa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTarifa.Value = 0
        Me.txtTarifa.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(361, 278)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(457, 278)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 8
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(14, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Impuesto"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbImpuesto
        '
        Me.cmbImpuesto.Location = New System.Drawing.Point(117, 177)
        Me.cmbImpuesto.Name = "cmbImpuesto"
        Me.cmbImpuesto.Size = New System.Drawing.Size(129, 21)
        Me.cmbImpuesto.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(211, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 15)
        Me.Label13.TabIndex = 135
        Me.Label13.Text = "Total Seco"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(87, 214)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox7.TabIndex = 142
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(87, 180)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox8.TabIndex = 143
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(256, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "% Retención I.S.R"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtISR
        '
        Me.txtISR.Location = New System.Drawing.Point(358, 177)
        Me.txtISR.Name = "txtISR"
        Me.txtISR.Size = New System.Drawing.Size(40, 20)
        Me.txtISR.TabIndex = 5
        Me.txtISR.Text = "4.00"
        Me.txtISR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtISR.Value = 4
        Me.txtISR.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(321, 212)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(77, 20)
        Me.txtTotal.TabIndex = 148
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = 0
        Me.txtTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(14, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 15)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Tarifa Refrigerado"
        '
        'txtTarifaRefrigerado
        '
        Me.txtTarifaRefrigerado.Location = New System.Drawing.Point(117, 238)
        Me.txtTarifaRefrigerado.Name = "txtTarifaRefrigerado"
        Me.txtTarifaRefrigerado.Size = New System.Drawing.Size(77, 20)
        Me.txtTarifaRefrigerado.TabIndex = 7
        Me.txtTarifaRefrigerado.Text = "0.00"
        Me.txtTarifaRefrigerado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTarifaRefrigerado.Value = 0
        Me.txtTarifaRefrigerado.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtTotalRefrigerado
        '
        Me.txtTotalRefrigerado.Enabled = False
        Me.txtTotalRefrigerado.Location = New System.Drawing.Point(321, 237)
        Me.txtTotalRefrigerado.Name = "txtTotalRefrigerado"
        Me.txtTotalRefrigerado.Size = New System.Drawing.Size(77, 20)
        Me.txtTotalRefrigerado.TabIndex = 152
        Me.txtTotalRefrigerado.Text = "0.00"
        Me.txtTotalRefrigerado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotalRefrigerado.Value = 0
        Me.txtTotalRefrigerado.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(211, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "Total Refrigerado"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(87, 241)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox9.TabIndex = 153
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'FrmAddTarifa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(553, 327)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.txtTotalRefrigerado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTarifaRefrigerado)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtISR)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmbImpuesto)
        Me.Controls.Add(Me.lblLimite)
        Me.Controls.Add(Me.txtTarifa)
        Me.Controls.Add(Me.GrpDestino)
        Me.Controls.Add(Me.GrpOrigen)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label10)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddTarifa"
        Me.Text = "Trayecto"
        Me.GrpOrigen.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDestino.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String
    Public DTARClave As String
    Public estadoOrigen, mnpioOrigen, estadoDestino, mnpioDestino As String
    Public ImpuestoActual As String
    Public Tasa, dTarifa, dISR, dTarifaR As Double

    Private dTotal, dTotalR As Double
    Private ImpuestoDef As String
    Private alerta(8) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.cmbPaisOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbEntidadOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbLocalidadOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbPaisDestino.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbEntidadDestino.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbLocalidadDestino.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(Me.txtTarifa.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If



        If CDbl(Me.txtTarifaRefrigerado.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length - 1
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub reinicializa()
        txtTarifa.Text = 0
        txtTotal.Text = 0
        txtTotalRefrigerado.Text = 0
        txtISR.Text = 4
        txtTarifaRefrigerado.Text = 0
        cmbImpuesto.SelectedValue = ImpuestoDef
    End Sub

    Private Sub FrmAddTarifa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9

        With Me.cmbImpuesto
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impuesto"
            .llenar()
        End With

        With Me.cmbPaisOrigen
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With Me.cmbPaisDestino
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        If cmbPaisOrigen.SelectedValue IsNot Nothing Then
            With Me.cmbEntidadOrigen
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_estado"
                .NombreParametro1 = "Pais"
                .Parametro1 = cmbPaisOrigen.SelectedValue
                .llenar()
            End With
        End If

        If cmbPaisDestino.SelectedValue IsNot Nothing Then
            With Me.CmbEntidadDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_estado"
                .NombreParametro1 = "Pais"
                .Parametro1 = cmbPaisDestino.SelectedValue
                .llenar()
            End With
        End If

        If CmbEntidadDestino.SelectedValue IsNot Nothing Then

            With Me.cmbLocalidadDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_mnpio"
                .NombreParametro1 = "Estado"
                .Parametro1 = CmbEntidadDestino.SelectedValue
                .llenar()
            End With

        End If


        If cmbEntidadOrigen.SelectedValue IsNot Nothing Then

            With Me.cmbLocalidadOrigen
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_mnpio"
                .NombreParametro1 = "Estado"
                .Parametro1 = cmbEntidadOrigen.SelectedValue
                .llenar()
            End With

        End If

        cargado = True


        If Padre = "Agregar" Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_filtra_impuestos_def", "@COMClave", ModPOS.CompanyActual)
            ImpuestoDef = dt.Rows(0)("IMPClave")

            cmbImpuesto.SelectedValue = ImpuestoDef

        Else
            Me.GrpOrigen.Enabled = False
            Me.GrpDestino.Enabled = False

            cmbEntidadOrigen.SelectedValue = estadoOrigen
            cmbLocalidadOrigen.SelectedValue = mnpioOrigen
            CmbEntidadDestino.SelectedValue = estadoOrigen
            cmbLocalidadDestino.SelectedValue = mnpioOrigen
            txtISR.Text = dISR
            txtTarifa.Text = dTarifa
            txtTarifaRefrigerado.Text = dTarifaR
            cmbImpuesto.SelectedValue = ImpuestoActual
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"
                    DTARClave = ModPOS.obtenerLlave
                    dTarifa = txtTarifa.Text
                    dTarifaR = txtTarifaRefrigerado.Text
                    ImpuestoActual = cmbImpuesto.SelectedValue
                    dISR = txtISR.Text
                    estadoOrigen = cmbEntidadOrigen.SelectedValue
                    mnpioOrigen = cmbLocalidadOrigen.SelectedValue
                    estadoDestino = CmbEntidadDestino.SelectedValue
                    mnpioDestino = cmbLocalidadDestino.SelectedValue

                    dTotal = txtTotal.Text
                    dTotalR = txtTotalRefrigerado.Text

                    If ModPOS.Tarifa IsNot Nothing Then

                        If ModPOS.Tarifa.AddTarifa(Padre, DTARClave, _
                                                      estadoOrigen, _
                                                      mnpioOrigen, _
                                                      cmbLocalidadOrigen.SelectedItem(1) & ", " & cmbEntidadOrigen.SelectedItem(1), _
                                                      estadoDestino, _
                                                      mnpioDestino, _
                                                      cmbLocalidadDestino.SelectedItem(1) & ", " & CmbEntidadDestino.SelectedItem(1), _
                                                      ImpuestoActual, _
                                                       dISR, _
                                                       Tasa, _
                                                       dTarifa, _
                                                      dTarifaR, _
                                                       dTotal, _
                                                      dTotalR) = True Then
                            reinicializa()

                        End If


                    End If
                Case "Modificar"

                    If Not (dTarifa = txtTarifa.Text AndAlso _
                        dTarifaR = txtTarifaRefrigerado.Text AndAlso _
                        ImpuestoActual = cmbImpuesto.SelectedValue AndAlso _
                        dISR = txtISR.Text AndAlso _
                        estadoOrigen = cmbEntidadOrigen.SelectedValue AndAlso _
                        mnpioOrigen = cmbLocalidadOrigen.SelectedValue AndAlso _
                        estadoDestino = CmbEntidadDestino.SelectedValue AndAlso _
                        mnpioDestino = cmbLocalidadDestino.SelectedValue) Then

                        dTarifa = txtTarifa.Text
                        dTarifaR = txtTarifaRefrigerado.Text
                        ImpuestoActual = cmbImpuesto.SelectedValue
                        dISR = txtISR.Text
                        estadoOrigen = cmbEntidadOrigen.SelectedValue
                        mnpioOrigen = cmbLocalidadOrigen.SelectedValue
                        estadoDestino = CmbEntidadDestino.SelectedValue
                        mnpioDestino = cmbLocalidadDestino.SelectedValue


                        dTotal = txtTotal.Text
                        dTotalR = txtTotalRefrigerado.Text

                        ModPOS.Tarifa.AddTarifa(Padre, DTARClave, _
                                                         estadoOrigen, _
                                                         mnpioOrigen, _
                                                         cmbLocalidadOrigen.SelectedItem(1) & ", " & cmbEntidadOrigen.SelectedItem(1), _
                                                         estadoDestino, _
                                                         mnpioDestino, _
                                                         cmbLocalidadDestino.SelectedItem(1) & ", " & CmbEntidadDestino.SelectedItem(1), _
                                                         ImpuestoActual, _
                                                          dISR, _
                                                          Tasa, _
                                                          dTarifa, _
                                                         dTarifaR, _
                                                          dTotal, _
                                                         dTotalR)
                    End If

                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbPaisOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaisOrigen.SelectedIndexChanged
        If cargado = True AndAlso Not cmbPaisOrigen.SelectedValue Is Nothing Then

            With Me.cmbEntidadOrigen
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_estado"
                .NombreParametro1 = "Pais"
                .Parametro1 = cmbPaisOrigen.SelectedValue
                .llenar()
            End With

        End If

    End Sub

    Private Sub cmbPaisDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaisDestino.SelectedIndexChanged
        If cargado = True AndAlso Not cmbPaisDestino.SelectedValue Is Nothing Then

            With Me.CmbEntidadDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_estado"
                .NombreParametro1 = "Pais"
                .Parametro1 = cmbPaisDestino.SelectedValue
                .llenar()
            End With

        End If
    End Sub

    Private Sub cmbEntidadOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEntidadOrigen.SelectedIndexChanged

        If cargado = True AndAlso Not cmbEntidadOrigen.SelectedValue Is Nothing Then

            With Me.cmbLocalidadOrigen
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_mnpio"
                .NombreParametro1 = "Estado"
                .Parametro1 = cmbEntidadOrigen.SelectedValue
                .llenar()
            End With

        End If


    End Sub

    Private Sub CmbEntidadDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbEntidadDestino.SelectedIndexChanged
        If cargado = True AndAlso Not CmbEntidadDestino.SelectedValue Is Nothing Then

            With Me.cmbLocalidadDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_mnpio"
                .NombreParametro1 = "Estado"
                .Parametro1 = CmbEntidadDestino.SelectedValue
                .llenar()
            End With
        End If

    End Sub

    Private Sub recuperaImpuesto(ByVal IMPClave As String)
        If IMPClave <> ImpuestoActual Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_impuesto", "@Impuesto", IMPClave)
            Tasa = dt.Rows(0)("Valor")
            ImpuestoActual = IMPClave
            dt.Dispose()
        End If
        txtTotal.Text = (CDbl(txtTarifa.Text) * (1 + Tasa)) - ((CDbl(txtISR.Text) / 100) * CDbl(txtTarifa.Text))
        txtTotalRefrigerado.Text = (CDbl(txtTarifaRefrigerado.Text) * (1 + Tasa)) - ((CDbl(txtISR.Text) / 100) * CDbl(txtTarifaRefrigerado.Text))
    End Sub

    Private Sub txtTarifa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarifa.Leave
        If CDbl(txtTarifa.Text) > 0 Then
            If Not cmbImpuesto.SelectedValue Is Nothing Then
                recuperaImpuesto(cmbImpuesto.SelectedValue)
            End If
        End If
    End Sub

    Private Sub cmbImpuesto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbImpuesto.SelectedValueChanged
        If cargado AndAlso Not cmbImpuesto.SelectedValue Is Nothing Then
            If CDbl(txtTarifa.Text) > 0 Then
                recuperaImpuesto(cmbImpuesto.SelectedValue)
            End If
        End If
    End Sub

    Private Sub txtISR_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtISR.Leave
        txtTotal.Text = (CDbl(txtTarifa.Text) * (1 + Tasa)) - ((CDbl(txtISR.Text) / 100) * CDbl(txtTarifa.Text))
        txtTotalRefrigerado.Text = (CDbl(txtTarifaRefrigerado.Text) * (1 + Tasa)) - ((CDbl(txtISR.Text) / 100) * CDbl(txtTarifaRefrigerado.Text))
    End Sub

    Private Sub txtTarifaRefrigerado_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarifaRefrigerado.Leave
        If CDbl(txtTarifaRefrigerado.Text) > 0 Then
            If Not cmbImpuesto.SelectedValue Is Nothing Then
                recuperaImpuesto(cmbImpuesto.SelectedValue)
            End If
        End If
    End Sub
End Class
