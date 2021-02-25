Public Class FrmAddCaja
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
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents txtRemision As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents cmbPropietario As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents BtnBusquedaCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents txtEconomico As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents LblDestinatario As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDestino As Selling.StoreCombo
    Friend WithEvents cmbOrigen As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbCarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbDescarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbRecibidos As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents chkRecibidos As Selling.ChkStatus
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtISR As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtImpuesto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents txtTarifa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtNoCarga As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddCaja))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.TxtNoCarga = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtISR = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtImpuesto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLimite = New System.Windows.Forms.Label()
        Me.txtTarifa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.cmbRecibidos = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.chkRecibidos = New Selling.ChkStatus(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtRemision = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.cmbPropietario = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMarca = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.BtnBusquedaCaja = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbTipo = New Selling.StoreCombo()
        Me.txtEconomico = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrpOrigen = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.cmbDescarga = New System.Windows.Forms.DateTimePicker()
        Me.cmbCarga = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtDestinatario = New System.Windows.Forms.TextBox()
        Me.LblDestinatario = New System.Windows.Forms.Label()
        Me.cmbDestino = New Selling.StoreCombo()
        Me.cmbOrigen = New Selling.StoreCombo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpOrigen.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(474, 467)
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
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(570, 467)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Location = New System.Drawing.Point(-3, 1)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(665, 458)
        Me.UiTab1.TabIndex = 163
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.TxtNoCarga)
        Me.UiTabPage1.Controls.Add(Me.Label3)
        Me.UiTabPage1.Controls.Add(Me.Label21)
        Me.UiTabPage1.Controls.Add(Me.txtISR)
        Me.UiTabPage1.Controls.Add(Me.txtImpuesto)
        Me.UiTabPage1.Controls.Add(Me.Label13)
        Me.UiTabPage1.Controls.Add(Me.txtTotal)
        Me.UiTabPage1.Controls.Add(Me.Label10)
        Me.UiTabPage1.Controls.Add(Me.lblLimite)
        Me.UiTabPage1.Controls.Add(Me.txtTarifa)
        Me.UiTabPage1.Controls.Add(Me.cmbRecibidos)
        Me.UiTabPage1.Controls.Add(Me.Label20)
        Me.UiTabPage1.Controls.Add(Me.txtObservacion)
        Me.UiTabPage1.Controls.Add(Me.chkRecibidos)
        Me.UiTabPage1.Controls.Add(Me.PictureBox1)
        Me.UiTabPage1.Controls.Add(Me.txtRemision)
        Me.UiTabPage1.Controls.Add(Me.Label12)
        Me.UiTabPage1.Controls.Add(Me.txtPlaca)
        Me.UiTabPage1.Controls.Add(Me.cmbPropietario)
        Me.UiTabPage1.Controls.Add(Me.Label2)
        Me.UiTabPage1.Controls.Add(Me.cmbMarca)
        Me.UiTabPage1.Controls.Add(Me.Label1)
        Me.UiTabPage1.Controls.Add(Me.txtModelo)
        Me.UiTabPage1.Controls.Add(Me.BtnBusquedaCaja)
        Me.UiTabPage1.Controls.Add(Me.PictureBox2)
        Me.UiTabPage1.Controls.Add(Me.lblTipo)
        Me.UiTabPage1.Controls.Add(Me.cmbTipo)
        Me.UiTabPage1.Controls.Add(Me.txtEconomico)
        Me.UiTabPage1.Controls.Add(Me.LblClave)
        Me.UiTabPage1.Controls.Add(Me.Label4)
        Me.UiTabPage1.Controls.Add(Me.GrpOrigen)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(663, 436)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "General"
        '
        'TxtNoCarga
        '
        Me.TxtNoCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtNoCarga.Location = New System.Drawing.Point(521, 3)
        Me.TxtNoCarga.Name = "TxtNoCarga"
        Me.TxtNoCarga.Size = New System.Drawing.Size(96, 21)
        Me.TxtNoCarga.TabIndex = 192
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(435, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "No. Carga"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Location = New System.Drawing.Point(273, 347)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 15)
        Me.Label21.TabIndex = 191
        Me.Label21.Text = "Retención I.S.R"
        '
        'txtISR
        '
        Me.txtISR.Enabled = False
        Me.txtISR.Location = New System.Drawing.Point(450, 347)
        Me.txtISR.Name = "txtISR"
        Me.txtISR.Size = New System.Drawing.Size(167, 20)
        Me.txtISR.TabIndex = 190
        Me.txtISR.Text = "0.00"
        Me.txtISR.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtISR.Value = 0.0R
        Me.txtISR.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtImpuesto
        '
        Me.txtImpuesto.Enabled = False
        Me.txtImpuesto.Location = New System.Drawing.Point(449, 321)
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.ReadOnly = True
        Me.txtImpuesto.Size = New System.Drawing.Size(168, 20)
        Me.txtImpuesto.TabIndex = 189
        Me.txtImpuesto.Text = "0.00"
        Me.txtImpuesto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtImpuesto.Value = 0.0R
        Me.txtImpuesto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(273, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "Total"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(449, 371)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(168, 20)
        Me.txtTotal.TabIndex = 187
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = 0.0R
        Me.txtTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(273, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 15)
        Me.Label10.TabIndex = 186
        Me.Label10.Text = "Impuesto"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLimite
        '
        Me.lblLimite.BackColor = System.Drawing.Color.Transparent
        Me.lblLimite.Location = New System.Drawing.Point(273, 295)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(51, 15)
        Me.lblLimite.TabIndex = 185
        Me.lblLimite.Text = "Importe"
        '
        'txtTarifa
        '
        Me.txtTarifa.Enabled = False
        Me.txtTarifa.Location = New System.Drawing.Point(450, 295)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(167, 20)
        Me.txtTarifa.TabIndex = 184
        Me.txtTarifa.Text = "0.00"
        Me.txtTarifa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTarifa.Value = 0.0R
        Me.txtTarifa.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'cmbRecibidos
        '
        Me.cmbRecibidos.CustomFormat = "yyyyMMdd"
        Me.cmbRecibidos.Enabled = False
        Me.cmbRecibidos.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbRecibidos.Location = New System.Drawing.Point(182, 268)
        Me.cmbRecibidos.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbRecibidos.Name = "cmbRecibidos"
        Me.cmbRecibidos.Size = New System.Drawing.Size(84, 20)
        Me.cmbRecibidos.TabIndex = 183
        Me.cmbRecibidos.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(273, 272)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 15)
        Me.Label20.TabIndex = 181
        Me.Label20.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(365, 268)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(252, 21)
        Me.txtObservacion.TabIndex = 180
        '
        'chkRecibidos
        '
        Me.chkRecibidos.BackColor = System.Drawing.Color.Transparent
        Me.chkRecibidos.Location = New System.Drawing.Point(49, 269)
        Me.chkRecibidos.Name = "chkRecibidos"
        Me.chkRecibidos.Size = New System.Drawing.Size(127, 18)
        Me.chkRecibidos.TabIndex = 182
        Me.chkRecibidos.Text = "Papeles Recibidos"
        Me.chkRecibidos.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(126, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtRemision
        '
        Me.txtRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtRemision.Location = New System.Drawing.Point(160, 3)
        Me.txtRemision.Name = "txtRemision"
        Me.txtRemision.Size = New System.Drawing.Size(83, 21)
        Me.txtRemision.TabIndex = 177
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(53, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 15)
        Me.Label12.TabIndex = 179
        Me.Label12.Text = "Remisión/Embarque"
        '
        'txtPlaca
        '
        Me.txtPlaca.Enabled = False
        Me.txtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaca.Location = New System.Drawing.Point(497, 67)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.ReadOnly = True
        Me.txtPlaca.Size = New System.Drawing.Size(120, 21)
        Me.txtPlaca.TabIndex = 176
        '
        'cmbPropietario
        '
        Me.cmbPropietario.Enabled = False
        Me.cmbPropietario.Location = New System.Drawing.Point(406, 40)
        Me.cmbPropietario.Name = "cmbPropietario"
        Me.cmbPropietario.Size = New System.Drawing.Size(211, 21)
        Me.cmbPropietario.TabIndex = 174
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(292, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 14)
        Me.Label2.TabIndex = 175
        Me.Label2.Text = "Propietario"
        '
        'cmbMarca
        '
        Me.cmbMarca.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.Location = New System.Drawing.Point(160, 69)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(139, 21)
        Me.cmbMarca.TabIndex = 173
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(53, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Marca/Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.Enabled = False
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(305, 69)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(54, 21)
        Me.txtModelo.TabIndex = 171
        '
        'BtnBusquedaCaja
        '
        Me.BtnBusquedaCaja.Image = CType(resources.GetObject("BtnBusquedaCaja.Image"), System.Drawing.Image)
        Me.BtnBusquedaCaja.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaCaja.Location = New System.Drawing.Point(256, 37)
        Me.BtnBusquedaCaja.Name = "BtnBusquedaCaja"
        Me.BtnBusquedaCaja.Size = New System.Drawing.Size(27, 22)
        Me.BtnBusquedaCaja.TabIndex = 170
        Me.BtnBusquedaCaja.ToolTipText = "Busqueda de Caja"
        Me.BtnBusquedaCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(126, 41)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox2.TabIndex = 137
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.BackColor = System.Drawing.Color.Transparent
        Me.lblTipo.Location = New System.Drawing.Point(53, 99)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(46, 15)
        Me.lblTipo.TabIndex = 169
        Me.lblTipo.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.Location = New System.Drawing.Point(160, 96)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(212, 21)
        Me.cmbTipo.TabIndex = 168
        '
        'txtEconomico
        '
        Me.txtEconomico.Location = New System.Drawing.Point(160, 42)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(83, 20)
        Me.txtEconomico.TabIndex = 165
        Me.txtEconomico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'LblClave
        '
        Me.LblClave.BackColor = System.Drawing.Color.Transparent
        Me.LblClave.Location = New System.Drawing.Point(53, 45)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(97, 14)
        Me.LblClave.TabIndex = 166
        Me.LblClave.Text = "No. Económico"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(419, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "Placa"
        '
        'GrpOrigen
        '
        Me.GrpOrigen.BackColor = System.Drawing.Color.Transparent
        Me.GrpOrigen.Controls.Add(Me.PictureBox6)
        Me.GrpOrigen.Controls.Add(Me.PictureBox5)
        Me.GrpOrigen.Controls.Add(Me.cmbDescarga)
        Me.GrpOrigen.Controls.Add(Me.cmbCarga)
        Me.GrpOrigen.Controls.Add(Me.Label26)
        Me.GrpOrigen.Controls.Add(Me.Label5)
        Me.GrpOrigen.Controls.Add(Me.PictureBox4)
        Me.GrpOrigen.Controls.Add(Me.txtDestinatario)
        Me.GrpOrigen.Controls.Add(Me.LblDestinatario)
        Me.GrpOrigen.Controls.Add(Me.cmbDestino)
        Me.GrpOrigen.Controls.Add(Me.cmbOrigen)
        Me.GrpOrigen.Controls.Add(Me.Label7)
        Me.GrpOrigen.Controls.Add(Me.Label8)
        Me.GrpOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpOrigen.Location = New System.Drawing.Point(48, 121)
        Me.GrpOrigen.Name = "GrpOrigen"
        Me.GrpOrigen.Size = New System.Drawing.Size(569, 132)
        Me.GrpOrigen.TabIndex = 8
        Me.GrpOrigen.TabStop = False
        Me.GrpOrigen.Text = "Trayecto"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(326, 41)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox6.TabIndex = 212
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(52, 42)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox5.TabIndex = 211
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'cmbDescarga
        '
        Me.cmbDescarga.CustomFormat = ""
        Me.cmbDescarga.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbDescarga.Location = New System.Drawing.Point(399, 100)
        Me.cmbDescarga.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbDescarga.Name = "cmbDescarga"
        Me.cmbDescarga.Size = New System.Drawing.Size(134, 20)
        Me.cmbDescarga.TabIndex = 207
        Me.cmbDescarga.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbCarga
        '
        Me.cmbCarga.CustomFormat = ""
        Me.cmbCarga.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbCarga.Location = New System.Drawing.Point(130, 101)
        Me.cmbCarga.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbCarga.Name = "cmbCarga"
        Me.cmbCarga.Size = New System.Drawing.Size(143, 20)
        Me.cmbCarga.TabIndex = 203
        Me.cmbCarga.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(279, 104)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 15)
        Me.Label26.TabIndex = 186
        Me.Label26.Text = "Descarga"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 15)
        Me.Label5.TabIndex = 145
        Me.Label5.Text = "Carga"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(78, 17)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox4.TabIndex = 143
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'txtDestinatario
        '
        Me.txtDestinatario.Location = New System.Drawing.Point(130, 17)
        Me.txtDestinatario.Name = "txtDestinatario"
        Me.txtDestinatario.Size = New System.Drawing.Size(403, 20)
        Me.txtDestinatario.TabIndex = 138
        '
        'LblDestinatario
        '
        Me.LblDestinatario.Location = New System.Drawing.Point(14, 21)
        Me.LblDestinatario.Name = "LblDestinatario"
        Me.LblDestinatario.Size = New System.Drawing.Size(72, 15)
        Me.LblDestinatario.TabIndex = 139
        Me.LblDestinatario.Text = "Destinatario"
        '
        'cmbDestino
        '
        Me.cmbDestino.Location = New System.Drawing.Point(279, 61)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(254, 21)
        Me.cmbDestino.TabIndex = 63
        '
        'cmbOrigen
        '
        Me.cmbOrigen.Location = New System.Drawing.Point(12, 61)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(261, 21)
        Me.cmbOrigen.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(279, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "Destino"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(12, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Origen"
        '
        'FrmAddCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(663, 512)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddCaja"
        Me.Text = "Detalle del Viaje"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.UiTabPage1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpOrigen.ResumeLayout(False)
        Me.GrpOrigen.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public Papeles As Integer
    Public fechaPapeles As Date = #1/1/2000#
    Public CTEClave As String
    Public Observacion As String

    Public CONClave As String
    Public Embarque As String
    Public NoCarga As String

    Public sDTARClave As String

    Public Carga As Date = DateTime.Today
   
    Public Descarga As Date = DateTime.Today
   
    Public Destinatario As String
    Public Importe, Impuesto, Retencion, Total As Double
    Private dTasa, dTarifa, dTarifaR, dISR, dSeco, dRefrigerado As Double

    Private DTARClave As String
    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False
    Private Origen As String

    Private Sub FrmAddCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddCaja.Dispose()
        ModPOS.AddCaja = Nothing
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If txtRemision.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CONClave = "" OrElse txtEconomico.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If txtDestinatario.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Me.cmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbDestino.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
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

    Private Sub CargaDatosTarifa(ByVal sDTARClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_tarifa_detalle", "@DTARClave", sDTARClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            DTARClave = dt.Rows(0)("DTARClave")
            Origen = dt.Rows(0)("Origen")

            dTarifa = dt.Rows(0)("Tarifa")
            dTarifaR = dt.Rows(0)("TarifaR")
            dTasa = dt.Rows(0)("Tasa")
            dISR = dt.Rows(0)("ISR")
            dSeco = dt.Rows(0)("Seco")
            dRefrigerado = dt.Rows(0)("Refrigerado")

            If cmbTipo.SelectedValue IsNot Nothing Then
                If cmbTipo.SelectedValue = 1 Then
                    txtTarifa.Text = dTarifa
                    txtImpuesto.Text = dTarifa * dTasa
                    txtISR.Text = dTarifa * (dISR / 100)
                    txtTotal.Text = dSeco
                ElseIf cmbTipo.SelectedValue = 2 Then
                    txtTarifa.Text = dTarifaR
                    txtImpuesto.Text = dTarifaR * dTasa
                    txtISR.Text = dTarifaR * (dISR / 100)
                    txtTotal.Text = dRefrigerado
                End If
            End If
        Else
            MessageBox.Show("La información de la Tarifa no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub CargaDatosCaja(ByVal sCONClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_contenedor", "@CONClave", sCONClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CONClave = dt.Rows(0)("CONClave")
            txtEconomico.Text = dt.Rows(0)("noEconomico")
            txtModelo.Text = dt.Rows(0)("Modelo")
            cmbMarca.SelectedValue = dt.Rows(0)("Marca")
            txtPlaca.Text = dt.Rows(0)("Placa")
            cmbTipo.SelectedValue = dt.Rows(0)("Tipo")
            cmbPropietario.SelectedValue = dt.Rows(0)("Propietario")
            dt.Dispose()

            If CTEClave <> "" Then
                If cmbTipo.SelectedValue IsNot Nothing Then
                    If cmbTipo.SelectedValue = 1 Then
                        txtTarifa.Text = dTarifa
                        txtImpuesto.Text = dTarifa * dTasa
                        txtISR.Text = dTarifa * (dISR / 100)
                        txtTotal.Text = dSeco
                    ElseIf cmbTipo.SelectedValue = 2 Then
                        txtTarifa.Text = dTarifaR
                        txtImpuesto.Text = dTarifaR * dTasa
                        txtISR.Text = dTarifaR * (dISR / 100)
                        txtTotal.Text = dRefrigerado
                    End If
                End If
            End If

        Else
            MessageBox.Show("La información de la Caja no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmAddCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox4
        alerta(3) = Me.PictureBox5
        alerta(4) = Me.PictureBox6



        With cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contenedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With cmbMarca
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contenedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Marca"
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



        With Me.cmbOrigen
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_obtiene_tarifa_origen"
            .NombreParametro1 = "CTEClave"
            .Parametro1 = CTEClave
            .llenar()
        End With

        If cmbOrigen.SelectedValue IsNot Nothing Then
            With Me.cmbDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_tarifa_destino"
                .NombreParametro1 = "CTEClave"
                .Parametro1 = CTEClave
                .NombreParametro2 = "Origen"
                .Parametro2 = cmbOrigen.SelectedValue
                .llenar()
            End With
        End If

        If cmbOrigen.SelectedValue IsNot Nothing Then
            Me.CargaDatosTarifa(cmbDestino.SelectedValue)
        End If

        cargado = True

        txtRemision.Text = Embarque


        cmbCarga.Value = Carga
      
        cmbDescarga.Value = Descarga
  

        chkRecibidos.Estado = Math.Abs(Papeles)
        cmbRecibidos.Value = fechaPapeles

        txtObservacion.Text = Observacion


        txtDestinatario.Text = Destinatario

        If Padre = "Agregar" Then
            cmbPropietario.SelectedValue = 0
            cmbTipo.SelectedValue = 0
            cmbMarca.SelectedValue = 0
        Else

            Me.CargaDatosCaja(CONClave)

            cmbOrigen.SelectedValue = Origen
            DTARClave = sDTARClave
            cmbDestino.SelectedValue = DTARClave



            txtTarifa.Text = Importe
            txtImpuesto.Text = Impuesto
            txtISR.Text = Retencion
            txtTotal.Text = Total

        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If ModPOS.Viaje IsNot Nothing Then

                Importe = txtTarifa.Text
                Impuesto = txtImpuesto.Text
                Retencion = txtISR.Text
                Total = txtTotal.Text

                Papeles = chkRecibidos.GetEstado
                fechaPapeles = cmbRecibidos.Value

                Observacion = txtObservacion.Text

                If ModPOS.Viaje.AddCaja(txtRemision.Text, txtNoCarga.text, CONClave, txtEconomico.Text, _
                                              txtPlaca.Text, cmbOrigen.SelectedItem(1), _
                                               cmbDestino.SelectedItem(1), _
                                               txtDestinatario.Text, _
                                               cmbCarga.Value, _
                                               cmbDescarga.Value, _
                                               Total, Impuesto, Importe, _
                                               dTasa, _
                                               cmbDestino.SelectedValue, _
                                               Papeles, fechaPapeles, _
                                               Retencion, _
                                               Observacion) = True Then
                    Me.Close()
                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkRecibidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecibidos.CheckedChanged
        If chkRecibidos.Checked = True Then
            cmbRecibidos.Enabled = True
        Else
            cmbRecibidos.Enabled = False
        End If
    End Sub

    Private Sub cmbDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDestino.SelectedIndexChanged
        If cargado = True AndAlso cmbDestino.SelectedValue IsNot Nothing Then
            Me.CargaDatosTarifa(cmbDestino.SelectedValue)
        End If
    End Sub

    Private Sub txtEconomico_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEconomico.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtEconomico.Text <> "" Then
                    Dim dtCaja As DataTable
                    dtCaja = ModPOS.SiExisteRecupera("sp_consulta_contenedor", "@Economico", txtEconomico.Text.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCaja Is Nothing AndAlso dtCaja.Rows.Count > 0 Then
                        Dim sCONClave As String = dtCaja.Rows(0)("CONClave")
                        dtCaja.Dispose()
                        CargaDatosCaja(sCONClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_contenedor"
                a.TablaCmb = "Contenedor"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = txtEconomico.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CargaDatosCaja(a.valor)
                    End If
                End If
                a.Dispose()
        End Select
    End Sub

    Private Sub BtnBusquedaCaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBusquedaCaja.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_contenedor"
        a.TablaCmb = "Contenedor"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosCaja(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub cmbOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOrigen.SelectedIndexChanged
        If cargado = True AndAlso cmbOrigen.SelectedValue IsNot Nothing Then
            With Me.cmbDestino
                .Conexion = BDConexion
                .ProcedimientoAlmacenado = "sp_obtiene_tarifa_destino"
                .NombreParametro1 = "CTEClave"
                .Parametro1 = CTEClave
                .NombreParametro2 = "Origen"
                .Parametro2 = cmbOrigen.SelectedValue
                .llenar()
            End With
        End If
    End Sub

End Class
