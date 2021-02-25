Public Class FrmTransporte
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
    Friend WithEvents UiTab As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabGeneral As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpTransporte As System.Windows.Forms.GroupBox
    Friend WithEvents txtSerieChasis As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlaca As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbMarca As Selling.StoreCombo
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbPropietario As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents txtEconomico As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents cmbModelo As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSerieMotor As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPoliza As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents UiTabCombustible As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpRendimiento As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtFechaEvento As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelCombustible As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtOdometro As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtLitros As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCombustible As Selling.StoreCombo
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtViaje As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAddCombustible As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents BtnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblNomOperador As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransporte))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.UiTab = New Janus.Windows.UI.Tab.UITab
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbVencimiento = New System.Windows.Forms.DateTimePicker
        Me.txtPoliza = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrpTransporte = New System.Windows.Forms.GroupBox
        Me.txtSerieChasis = New System.Windows.Forms.TextBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.txtPlaca = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.cmbMarca = New Selling.StoreCombo
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbPropietario = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbEstado = New Selling.StoreCombo
        Me.txtEconomico = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.cmbModelo = New Selling.StoreCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSerieMotor = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.LblSerie = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.UiTabCombustible = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpRendimiento = New System.Windows.Forms.GroupBox
        Me.lblNomOperador = New System.Windows.Forms.Label
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.TxtEmpleado = New System.Windows.Forms.TextBox
        Me.BtnOperador = New Janus.Windows.EditControls.UIButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.BtnAddCombustible = New Janus.Windows.EditControls.UIButton
        Me.TxtViaje = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtOdometro = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtLitros = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.btnDelCombustible = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtFechaEvento = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbCombustible = New Selling.StoreCombo
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTransporte.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCombustible.SuspendLayout()
        Me.GrpRendimiento.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(510, 389)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(606, 389)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab
        '
        Me.UiTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab.Location = New System.Drawing.Point(1, 12)
        Me.UiTab.Name = "UiTab"
        Me.UiTab.Size = New System.Drawing.Size(704, 371)
        Me.UiTab.TabIndex = 6
        Me.UiTab.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral, Me.UiTabCombustible})
        Me.UiTab.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.GroupBox1)
        Me.UiTabGeneral.Controls.Add(Me.GrpTransporte)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(702, 349)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "Transporte"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbVencimiento)
        Me.GroupBox1.Controls.Add(Me.txtPoliza)
        Me.GroupBox1.Controls.Add(Me.PictureBox9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 269)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 52)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seguro"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(473, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 15)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Vencimiento"
        '
        'cmbVencimiento
        '
        Me.cmbVencimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVencimiento.CustomFormat = "yyyyMMdd"
        Me.cmbVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbVencimiento.Location = New System.Drawing.Point(550, 21)
        Me.cmbVencimiento.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbVencimiento.Name = "cmbVencimiento"
        Me.cmbVencimiento.Size = New System.Drawing.Size(120, 20)
        Me.cmbVencimiento.TabIndex = 2
        Me.cmbVencimiento.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'txtPoliza
        '
        Me.txtPoliza.Location = New System.Drawing.Point(91, 20)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.Size = New System.Drawing.Size(120, 20)
        Me.txtPoliza.TabIndex = 1
        Me.txtPoliza.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(66, 25)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox9.TabIndex = 125
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(5, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 126
        Me.Label7.Text = "No. Poliza"
        '
        'GrpTransporte
        '
        Me.GrpTransporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTransporte.BackColor = System.Drawing.Color.Transparent
        Me.GrpTransporte.Controls.Add(Me.txtSerieChasis)
        Me.GrpTransporte.Controls.Add(Me.PictureBox6)
        Me.GrpTransporte.Controls.Add(Me.txtPlaca)
        Me.GrpTransporte.Controls.Add(Me.PictureBox7)
        Me.GrpTransporte.Controls.Add(Me.cmbMarca)
        Me.GrpTransporte.Controls.Add(Me.PictureBox8)
        Me.GrpTransporte.Controls.Add(Me.PictureBox5)
        Me.GrpTransporte.Controls.Add(Me.PictureBox4)
        Me.GrpTransporte.Controls.Add(Me.PictureBox3)
        Me.GrpTransporte.Controls.Add(Me.cmbPropietario)
        Me.GrpTransporte.Controls.Add(Me.Label1)
        Me.GrpTransporte.Controls.Add(Me.PictureBox1)
        Me.GrpTransporte.Controls.Add(Me.Label5)
        Me.GrpTransporte.Controls.Add(Me.cmbEstado)
        Me.GrpTransporte.Controls.Add(Me.txtEconomico)
        Me.GrpTransporte.Controls.Add(Me.cmbModelo)
        Me.GrpTransporte.Controls.Add(Me.Label2)
        Me.GrpTransporte.Controls.Add(Me.txtSerieMotor)
        Me.GrpTransporte.Controls.Add(Me.LblClave)
        Me.GrpTransporte.Controls.Add(Me.PictureBox2)
        Me.GrpTransporte.Controls.Add(Me.LblSerie)
        Me.GrpTransporte.Controls.Add(Me.Label4)
        Me.GrpTransporte.Controls.Add(Me.Label3)
        Me.GrpTransporte.Controls.Add(Me.Label6)
        Me.GrpTransporte.Location = New System.Drawing.Point(10, 7)
        Me.GrpTransporte.Name = "GrpTransporte"
        Me.GrpTransporte.Size = New System.Drawing.Size(689, 256)
        Me.GrpTransporte.TabIndex = 2
        Me.GrpTransporte.TabStop = False
        Me.GrpTransporte.Text = "Datos Generales"
        '
        'txtSerieChasis
        '
        Me.txtSerieChasis.Location = New System.Drawing.Point(90, 123)
        Me.txtSerieChasis.Name = "txtSerieChasis"
        Me.txtSerieChasis.Size = New System.Drawing.Size(256, 20)
        Me.txtSerieChasis.TabIndex = 4
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(67, 199)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox6.TabIndex = 121
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(90, 90)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(120, 20)
        Me.txtPlaca.TabIndex = 3
        Me.txtPlaca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(67, 227)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.Location = New System.Drawing.Point(90, 158)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(212, 21)
        Me.cmbMarca.TabIndex = 5
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(520, 33)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox8.TabIndex = 108
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(67, 162)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox5.TabIndex = 106
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(67, 126)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox4.TabIndex = 105
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(67, 95)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox3.TabIndex = 104
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbPropietario
        '
        Me.cmbPropietario.Location = New System.Drawing.Point(90, 224)
        Me.cmbPropietario.Name = "cmbPropietario"
        Me.cmbPropietario.Size = New System.Drawing.Size(212, 21)
        Me.cmbPropietario.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Propietario"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(67, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(490, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Location = New System.Drawing.Point(537, 30)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(133, 21)
        Me.cmbEstado.TabIndex = 8
        '
        'txtEconomico
        '
        Me.txtEconomico.Location = New System.Drawing.Point(90, 30)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(120, 20)
        Me.txtEconomico.TabIndex = 1
        Me.txtEconomico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'cmbModelo
        '
        Me.cmbModelo.Location = New System.Drawing.Point(90, 191)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.Size = New System.Drawing.Size(212, 21)
        Me.cmbModelo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Modelo"
        '
        'txtSerieMotor
        '
        Me.txtSerieMotor.Location = New System.Drawing.Point(90, 59)
        Me.txtSerieMotor.Name = "txtSerieMotor"
        Me.txtSerieMotor.Size = New System.Drawing.Size(256, 20)
        Me.txtSerieMotor.TabIndex = 2
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 32)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "No. Económico"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(67, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'LblSerie
        '
        Me.LblSerie.Location = New System.Drawing.Point(4, 62)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(72, 15)
        Me.LblSerie.TabIndex = 26
        Me.LblSerie.Text = "Serie Motor"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Placa"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 14)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Marca"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Serie Chasis"
        '
        'UiTabCombustible
        '
        Me.UiTabCombustible.Controls.Add(Me.GrpRendimiento)
        Me.UiTabCombustible.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCombustible.Name = "UiTabCombustible"
        Me.UiTabCombustible.Size = New System.Drawing.Size(702, 349)
        Me.UiTabCombustible.TabStop = True
        Me.UiTabCombustible.Text = "Compra de combustible"
        '
        'GrpRendimiento
        '
        Me.GrpRendimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRendimiento.BackColor = System.Drawing.Color.Transparent
        Me.GrpRendimiento.Controls.Add(Me.lblNomOperador)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox14)
        Me.GrpRendimiento.Controls.Add(Me.TxtEmpleado)
        Me.GrpRendimiento.Controls.Add(Me.BtnOperador)
        Me.GrpRendimiento.Controls.Add(Me.Label15)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox13)
        Me.GrpRendimiento.Controls.Add(Me.BtnAddCombustible)
        Me.GrpRendimiento.Controls.Add(Me.TxtViaje)
        Me.GrpRendimiento.Controls.Add(Me.Label14)
        Me.GrpRendimiento.Controls.Add(Me.TxtReferencia)
        Me.GrpRendimiento.Controls.Add(Me.LblNombre)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox12)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox11)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox10)
        Me.GrpRendimiento.Controls.Add(Me.TxtImporte)
        Me.GrpRendimiento.Controls.Add(Me.Label13)
        Me.GrpRendimiento.Controls.Add(Me.Label12)
        Me.GrpRendimiento.Controls.Add(Me.txtOdometro)
        Me.GrpRendimiento.Controls.Add(Me.Label11)
        Me.GrpRendimiento.Controls.Add(Me.TxtLitros)
        Me.GrpRendimiento.Controls.Add(Me.btnDelCombustible)
        Me.GrpRendimiento.Controls.Add(Me.GridDetalle)
        Me.GrpRendimiento.Controls.Add(Me.Label9)
        Me.GrpRendimiento.Controls.Add(Me.dtFechaEvento)
        Me.GrpRendimiento.Controls.Add(Me.Label10)
        Me.GrpRendimiento.Controls.Add(Me.CmbCombustible)
        Me.GrpRendimiento.Location = New System.Drawing.Point(6, 6)
        Me.GrpRendimiento.Name = "GrpRendimiento"
        Me.GrpRendimiento.Size = New System.Drawing.Size(688, 329)
        Me.GrpRendimiento.TabIndex = 4
        Me.GrpRendimiento.TabStop = False
        Me.GrpRendimiento.Text = "Rendimiento de Combustible"
        '
        'lblNomOperador
        '
        Me.lblNomOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomOperador.Location = New System.Drawing.Point(237, 28)
        Me.lblNomOperador.Name = "lblNomOperador"
        Me.lblNomOperador.Size = New System.Drawing.Size(435, 15)
        Me.lblNomOperador.TabIndex = 171
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(76, 25)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox14.TabIndex = 170
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'TxtEmpleado
        '
        Me.TxtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtEmpleado.Location = New System.Drawing.Point(101, 25)
        Me.TxtEmpleado.Name = "TxtEmpleado"
        Me.TxtEmpleado.Size = New System.Drawing.Size(73, 21)
        Me.TxtEmpleado.TabIndex = 1
        '
        'BtnOperador
        '
        Me.BtnOperador.Image = CType(resources.GetObject("BtnOperador.Image"), System.Drawing.Image)
        Me.BtnOperador.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnOperador.Location = New System.Drawing.Point(180, 24)
        Me.BtnOperador.Name = "BtnOperador"
        Me.BtnOperador.Size = New System.Drawing.Size(35, 22)
        Me.BtnOperador.TabIndex = 168
        Me.BtnOperador.ToolTipText = "Busqueda de Operador o Chofer"
        Me.BtnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 15)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "Operador"
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(76, 116)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox13.TabIndex = 145
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'BtnAddCombustible
        '
        Me.BtnAddCombustible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddCombustible.Icon = CType(resources.GetObject("BtnAddCombustible.Icon"), System.Drawing.Icon)
        Me.BtnAddCombustible.Location = New System.Drawing.Point(651, 125)
        Me.BtnAddCombustible.Name = "BtnAddCombustible"
        Me.BtnAddCombustible.Size = New System.Drawing.Size(31, 30)
        Me.BtnAddCombustible.TabIndex = 9
        Me.BtnAddCombustible.ToolTipText = "Agregar registro actual"
        Me.BtnAddCombustible.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtViaje
        '
        Me.TxtViaje.Location = New System.Drawing.Point(101, 116)
        Me.TxtViaje.Name = "TxtViaje"
        Me.TxtViaje.Size = New System.Drawing.Size(239, 20)
        Me.TxtViaje.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 15)
        Me.Label14.TabIndex = 142
        Me.Label14.Text = "Trayecto o Viaje"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(552, 88)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(120, 20)
        Me.TxtReferencia.TabIndex = 5
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(482, 91)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(96, 15)
        Me.LblNombre.TabIndex = 140
        Me.LblNombre.Text = "Referencia"
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(321, 87)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox12.TabIndex = 139
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(76, 84)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox11.TabIndex = 138
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(76, 53)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox10.TabIndex = 125
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(552, 54)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(120, 20)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtImporte.Value = 0
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(482, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "Importe"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Combustible"
        '
        'txtOdometro
        '
        Me.txtOdometro.Location = New System.Drawing.Point(346, 84)
        Me.txtOdometro.Name = "txtOdometro"
        Me.txtOdometro.Size = New System.Drawing.Size(120, 20)
        Me.txtOdometro.TabIndex = 4
        Me.txtOdometro.Text = "0.00"
        Me.txtOdometro.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtOdometro.Value = 0
        Me.txtOdometro.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(234, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 15)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Litros"
        '
        'TxtLitros
        '
        Me.TxtLitros.Location = New System.Drawing.Point(346, 52)
        Me.TxtLitros.Name = "TxtLitros"
        Me.TxtLitros.Size = New System.Drawing.Size(120, 20)
        Me.TxtLitros.TabIndex = 2
        Me.TxtLitros.Text = "0.00"
        Me.TxtLitros.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLitros.Value = 0
        Me.TxtLitros.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'btnDelCombustible
        '
        Me.btnDelCombustible.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCombustible.Icon = CType(resources.GetObject("btnDelCombustible.Icon"), System.Drawing.Icon)
        Me.btnDelCombustible.Location = New System.Drawing.Point(612, 125)
        Me.btnDelCombustible.Name = "btnDelCombustible"
        Me.btnDelCombustible.Size = New System.Drawing.Size(31, 30)
        Me.btnDelCombustible.TabIndex = 10
        Me.btnDelCombustible.ToolTipText = "Elimina el ultimo registro"
        Me.btnDelCombustible.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.Location = New System.Drawing.Point(6, 161)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(676, 162)
        Me.GridDetalle.TabIndex = 129
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 15)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Fecha de evento"
        '
        'dtFechaEvento
        '
        Me.dtFechaEvento.CustomFormat = "yyyyMMdd"
        Me.dtFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaEvento.Location = New System.Drawing.Point(101, 85)
        Me.dtFechaEvento.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtFechaEvento.Name = "dtFechaEvento"
        Me.dtFechaEvento.Size = New System.Drawing.Size(120, 20)
        Me.dtFechaEvento.TabIndex = 7
        Me.dtFechaEvento.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(234, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 15)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Lectura Odómetro"
        '
        'CmbCombustible
        '
        Me.CmbCombustible.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCombustible.Location = New System.Drawing.Point(101, 52)
        Me.CmbCombustible.Name = "CmbCombustible"
        Me.CmbCombustible.Size = New System.Drawing.Size(120, 21)
        Me.CmbCombustible.TabIndex = 8
        '
        'FrmTransporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(706, 429)
        Me.Controls.Add(Me.UiTab)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(602, 338)
        Me.Name = "FrmTransporte"
        Me.Text = "Transporte"
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab.ResumeLayout(False)
        Me.UiTabGeneral.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTransporte.ResumeLayout(False)
        Me.GrpTransporte.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCombustible.ResumeLayout(False)
        Me.GrpRendimiento.ResumeLayout(False)
        Me.GrpRendimiento.PerformLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public TRAClave As String = ""
    Public noEconomico As String
    Public serieChasis As String
    Public serieMotor As String
    Public Marca As Integer
    Public Modelo As Integer
    Public Placa As String
    Public Propietario As Integer
    Public Estado As Integer = 1
    Public noPoliza As String
    Public Vencimiento As DateTime = Today

    Private alerta(12) As PictureBox
    Private reloj As parpadea
    Private bCombustible As Boolean = False
    Private bLoad As Boolean = False
    Private dtDetalle, dtTipoCombustible As DataTable
    Private odometroAnterior As Double = 0
    Private EMPClave As String = ""

    Private Sub cargaRendimiento()
        dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_rendimiento", "@TRAClave", TRAClave)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("nvo").Visible = False
        GridDetalle.RootTable.Columns("EMPClave").Visible = False

        GridDetalle.CurrentTable.Columns("Combustible").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("Combustible").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoCombustible = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Transporte", "@Campo", "Combustible")

            Dim i As Integer

            For i = 0 To dtTipoCombustible.Rows.Count - 1
                .Add(dtTipoCombustible.Rows(i)("valor"), dtTipoCombustible.Rows(i)("descripcion"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("Combustible").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("nvo"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

        bCombustible = True

    End Sub


    Private Function validaRendimiento() As Boolean
        Dim i As Integer = 0

        If Me.CmbCombustible.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtViaje.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(txtOdometro.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If


        If EMPClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If



        Dim foundRows() As System.Data.DataRow

        foundRows = dtDetalle.Select("id = " & CStr(dtDetalle.Rows.Count))
        If foundRows.Length = 1 Then

            odometroAnterior = foundRows(0)("Odometro(Km)")

            If dtFechaEvento.Value < foundRows(0)("Fecha") Then
                i += 1
                reloj = New parpadea(Me.alerta(9))
                reloj.Enabled = True
                reloj.Start()
            End If

            If CDbl(txtOdometro.Text) <= foundRows(0)("Odometro(Km)") Then
                i += 1
                reloj = New parpadea(Me.alerta(10))
                reloj.Enabled = True
                reloj.Start()
            End If

        Else
            odometroAnterior = 0
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

        If Me.txtEconomico.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtSerieMotor.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtPlaca.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If txtSerieChasis.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbMarca.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbModelo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbPropietario.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbEstado.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Transporte", "@clave", UCase(Trim(Me.txtEconomico.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8

        alerta(8) = Me.PictureBox10
        alerta(9) = Me.PictureBox11
        alerta(10) = Me.PictureBox12
        alerta(11) = Me.PictureBox13
        alerta(12) = Me.PictureBox14


        dtFechaEvento.Value = DateTime.Today


        With cmbMarca
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Transporte"
            .NombreParametro2 = "campo"
            .Parametro2 = "Marca"
            .llenar()
        End With

        With Me.cmbEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Transporte"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With


        With Me.cmbModelo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Activo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Modelo"
            .llenar()
        End With

        With Me.cmbPropietario
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Activo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Propietario"
            .llenar()
        End With


        With CmbCombustible
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Transporte"
            .NombreParametro2 = "campo"
            .Parametro2 = "Combustible"
            .llenar()
        End With


        bLoad = True


        txtEconomico.Text = noEconomico
        txtSerieMotor.Text = serieMotor
        txtPlaca.Text = Placa
        txtSerieChasis.Text = serieChasis
        txtPoliza.Text = noPoliza
        Me.cmbVencimiento.Value = Vencimiento

        cmbMarca.SelectedValue = Marca
        cmbModelo.SelectedValue = Modelo
        cmbEstado.SelectedValue = Estado
        cmbPropietario.SelectedValue = Propietario


        If Padre = "Agregar" Then
            Me.UiTabCombustible.Enabled = False
        End If

    End Sub

    Public Sub reinicializar()
        noEconomico = ""
        serieMotor = ""
        serieChasis = ""
        noPoliza = ""
        Vencimiento = Today
        Placa = ""
        Estado = 1
        Marca = 0
        Modelo = 0
        Propietario = 0

        txtEconomico.Text = noEconomico
        txtSerieMotor.Text = serieMotor
        txtPlaca.Text = Placa
        txtSerieChasis.Text = serieChasis
        txtPoliza.Text = noPoliza
        Me.cmbVencimiento.Value = Vencimiento
        cmbMarca.SelectedValue = Marca
        cmbModelo.SelectedValue = Modelo
        cmbEstado.SelectedValue = Estado
        cmbPropietario.SelectedValue = Propietario
    End Sub

    Private Sub FrmTransporte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Transporte.Dispose()
        ModPOS.Transporte = Nothing
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Select Case Me.Padre
                Case "Agregar"
                    TRAClave = ModPOS.obtenerLlave
                    noEconomico = txtEconomico.Text
                    serieMotor = txtSerieMotor.Text
                    Placa = txtPlaca.Text
                    serieChasis = txtSerieChasis.Text
                    Marca = cmbMarca.SelectedValue
                    noPoliza = txtPoliza.Text
                    Vencimiento = cmbVencimiento.Value
                    Modelo = cmbModelo.SelectedValue
                    Estado = cmbEstado.SelectedValue
                    Propietario = cmbPropietario.SelectedValue


                    ModPOS.Ejecuta("sp_inserta_transporte", _
                        "@TRAClave", TRAClave, _
                        "@Economico", noEconomico, _
                        "@serieMotor", serieMotor, _
                        "@serieChasis", serieChasis, _
                        "@Placa", Placa, _
                        "@Marca", Marca, _
                        "@Modelo", Modelo, _
                        "@noPoliza", noPoliza, _
                        "@Vencimiento", Vencimiento, _
                        "@Propietario", Propietario, _
                        "@Estado", Estado, _
                        "@COMClave", ModPOS.CompanyActual, _
                        "@Usuario", ModPOS.UsuarioActual)

                    reinicializar()

                    If Not ModPOS.MtoTransporte Is Nothing Then

                        ModPOS.ActualizaGrid(True, ModPOS.MtoTransporte.GridTransporte, "sp_muestra_transportes", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoTransporte.GridTransporte.RootTable.Columns("TRAClave").Visible = False
                    End If


                Case "Modificar"


                    If Not (txtEconomico.Text = noEconomico AndAlso _
                        txtSerieMotor.Text = serieMotor AndAlso _
                        serieChasis = txtSerieChasis.Text AndAlso _
                        txtPlaca.Text = Placa AndAlso _
                        noPoliza = txtPoliza.Text AndAlso _
                        Vencimiento = cmbVencimiento.Value AndAlso _
                        cmbMarca.SelectedValue = Marca AndAlso _
                        cmbModelo.SelectedValue = Modelo AndAlso _
                        cmbEstado.SelectedValue = Estado AndAlso _
                        cmbPropietario.SelectedValue = Propietario) Then


                        noEconomico = txtEconomico.Text
                        serieMotor = txtSerieMotor.Text
                        serieChasis = txtSerieChasis.Text
                        Placa = txtPlaca.Text
                        noPoliza = txtPoliza.Text
                        Vencimiento = cmbVencimiento.Value
                        Marca = cmbMarca.SelectedValue
                        Modelo = cmbModelo.SelectedValue
                        Estado = cmbEstado.SelectedValue
                        Propietario = cmbPropietario.SelectedValue



                        ModPOS.Ejecuta("sp_modificar_transporte", _
                        "@TRAClave", TRAClave, _
                        "@SerieMotor", serieMotor, _
                        "@serieChasis", serieChasis, _
                        "@Placa", Placa, _
                        "@Marca", Marca, _
                        "@Modelo", Modelo, _
                        "@noPoliza", noPoliza, _
                        "@Vencimiento", Vencimiento, _
                        "@Propietario", Propietario, _
                        "@Estado", Estado, _
                        "@Usuario", ModPOS.UsuarioActual)


                      
                        If Not ModPOS.MtoTransporte Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoTransporte.GridTransporte, "sp_muestra_transportes", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoTransporte.GridTransporte.RootTable.Columns("TRAClave").Visible = False
                        End If

                    End If

                    Dim foundRows() As DataRow
                    foundRows = dtDetalle.Select("nvo = 1")
                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            ' Agrega
                            ModPOS.Ejecuta("sp_inserta_rendimiento", _
                                                   "@TRAClave", TRAClave, _
                                                   "@id", foundRows(i)("id"), _
                                                   "@Fecha", foundRows(i)("Fecha"), _
                                                   "@Odometro", foundRows(i)("Odometro(Km)"), _
                                                   "@Tipo", foundRows(i)("Combustible"), _
                                                   "@Importe", foundRows(i)("Importe"), _
                                                   "@Litros", foundRows(i)("Litros"), _
                                                   "@Referencia", foundRows(i)("Referencia"), _
                                                   "@Viaje", foundRows(i)("Viaje"), _
                                                    "@EMPClave", foundRows(i)("EMPClave"), _
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



    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub UiTab_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab.SelectedTabChanged
        If e.Page.Name = "UiTabCombustible" Then
            If bCombustible = False Then
                cargaRendimiento()
            End If

        End If
    End Sub

    Private Sub BtnAddCombustible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCombustible.Click
        If validaRendimiento() Then


            'Agrega a dtDetalle

            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("id") = dtDetalle.Rows.Count + 1
            row1.Item("Fecha") = dtFechaEvento.Value
            row1.Item("Referencia") = TxtReferencia.Text
            row1.Item("Combustible") = CmbCombustible.SelectedValue
            row1.Item("Importe") = TxtImporte.Text
            row1.Item("Litros") = TxtLitros.Text
            row1.Item("Odometro(Km)") = txtOdometro.Text
            row1.Item("Recorrido(Km)") = IIf(odometroAnterior > 0, CDbl(txtOdometro.Text) - odometroAnterior, 0)
            row1.Item("Rendimiento") = IIf(CDbl(TxtLitros.Text) > 0, (CDbl(txtOdometro.Text) - odometroAnterior) / CDbl(TxtLitros.Text), 0)
            row1.Item("Viaje") = TxtViaje.Text
            row1.Item("nvo") = 1
            row1.Item("EMPClave") = EMPClave
            row1.Item("Chofer") = TxtEmpleado.Text

            dtDetalle.Rows.Add(row1)

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDelCombustible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelCombustible.Click
        If dtDetalle.Rows.Count > 0 Then

            If MessageBox.Show("¿Esta seguro de remover el id " & CStr(dtDetalle.Rows.Count) & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim foundRows() As System.Data.DataRow


              
                'Elimina Detalle

                ModPOS.Ejecuta("sp_elimina_rendimiento", "@id", dtDetalle.Rows.Count, "@TRAClave", TRAClave)

                foundRows = dtDetalle.Select("id = " & CStr(dtDetalle.Rows.Count))

                If foundRows.GetLength(0) > 0 Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        dtDetalle.Rows.Remove(foundRows(i))
                    Next

                End If

              

            End If

        Else
            MessageBox.Show("No se encontro registro para ser eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargaDatosEmpleado(ByVal sEMPClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_empleado", "@EMPClave", sEMPClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            EMPClave = dt.Rows(0)("EMPClave")
            TxtEmpleado.Text = dt.Rows(0)("NumEmpleado")
            lblNomOperador.Text = dt.Rows(0)("NombreCompleto")
            dt.Dispose()
        Else
            EMPClave = ""
            TxtEmpleado.Text = ""
            lblNomOperador.Text = ""
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnOperador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOperador.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_empleado"
        a.TablaCmb = "Empleado"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.NumColDes = 1
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = "%"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Descripcion Is Nothing Then
                CargaDatosEmpleado(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtEmpleado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmpleado.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtEmpleado.Text <> "" Then
                    Dim dtEmpleado As DataTable
                    dtEmpleado = ModPOS.SiExisteRecupera("sp_consulta_empleado", "@NumEmpleado", TxtEmpleado.Text, "@COMClave", ModPOS.CompanyActual)
                    If Not dtEmpleado Is Nothing AndAlso dtEmpleado.Rows.Count > 0 Then
                        Dim sEMPClave As String = dtEmpleado.Rows(0)("EMPClave")
                        dtEmpleado.Dispose()
                        CargaDatosEmpleado(sEMPClave)


                    Else
                        EMPClave = ""
                        TxtEmpleado.Text = ""
                        lblNomOperador.Text = ""

                        MessageBox.Show("No se encontraron coincidencias para el Número de Empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_empleado"
                a.TablaCmb = "Empleado"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.NumColDes = 1
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = "%"
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Descripcion Is Nothing Then
                        CargaDatosEmpleado(a.valor)
                    End If
                End If
                a.Dispose()

        End Select

    End Sub
End Class
