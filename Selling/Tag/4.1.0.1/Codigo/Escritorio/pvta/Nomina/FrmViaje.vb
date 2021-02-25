Public Class FrmViaje
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtNoViaje As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCobranza As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaFactura As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents CmbFechaViaje As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents BtnModificaCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRemueveCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregaCaja As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbMarca As Selling.StoreCombo
    Friend WithEvents cmbTipoLicencia As Selling.StoreCombo
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtVencimientoLicencia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbPropietario As Selling.StoreCombo
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents txtEconomico As System.Windows.Forms.TextBox
    Friend WithEvents btnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnBusquedaTransporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents chkPagada As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmViaje))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.CmbFechaViaje = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.BtnModificaCaja = New Janus.Windows.EditControls.UIButton
        Me.BtnRemueveCaja = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregaCaja = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbMarca = New Selling.StoreCombo
        Me.cmbTipoLicencia = New Selling.StoreCombo
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtVencimientoLicencia = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbPropietario = New Selling.StoreCombo
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtVencimiento = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPoliza = New System.Windows.Forms.TextBox
        Me.txtEconomico = New System.Windows.Forms.TextBox
        Me.btnOperador = New Janus.Windows.EditControls.UIButton
        Me.txtPlacas = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnBusquedaTransporte = New Janus.Windows.EditControls.UIButton
        Me.txtOperador = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtModelo = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtNoViaje = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.TxtBusqueda = New System.Windows.Forms.TextBox
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.TxtRFC = New System.Windows.Forms.TextBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtTotal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cmbFechaPago = New System.Windows.Forms.DateTimePicker
        Me.cmbCobranza = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.cmbFechaFactura = New System.Windows.Forms.DateTimePicker
        Me.cmbVencimiento = New System.Windows.Forms.DateTimePicker
        Me.txtFactura = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.chkPagada = New Selling.ChkStatus(Me.components)
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabPage1.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(594, 531)
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
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(693, 532)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 6
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
        Me.UiTab1.Location = New System.Drawing.Point(0, 3)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(791, 523)
        Me.UiTab1.TabIndex = 164
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabPage1, Me.UiTabPage2})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.CmbFechaViaje)
        Me.UiTabPage1.Controls.Add(Me.Label3)
        Me.UiTabPage1.Controls.Add(Me.GrpDetalle)
        Me.UiTabPage1.Controls.Add(Me.GroupBox1)
        Me.UiTabPage1.Controls.Add(Me.PictureBox1)
        Me.UiTabPage1.Controls.Add(Me.txtNoViaje)
        Me.UiTabPage1.Controls.Add(Me.Label12)
        Me.UiTabPage1.Controls.Add(Me.GrpCliente)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(789, 501)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "General"
        '
        'CmbFechaViaje
        '
        Me.CmbFechaViaje.CustomFormat = "yyyyMMdd"
        Me.CmbFechaViaje.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaViaje.Location = New System.Drawing.Point(98, 6)
        Me.CmbFechaViaje.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaViaje.Name = "CmbFechaViaje"
        Me.CmbFechaViaje.Size = New System.Drawing.Size(114, 20)
        Me.CmbFechaViaje.TabIndex = 182
        Me.CmbFechaViaje.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(7, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 15)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "Fecha de Viaje"
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.GrpDetalle.Controls.Add(Me.BtnModificaCaja)
        Me.GrpDetalle.Controls.Add(Me.BtnRemueveCaja)
        Me.GrpDetalle.Controls.Add(Me.BtnAgregaCaja)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(6, 279)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(777, 219)
        Me.GrpDetalle.TabIndex = 181
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Cajas"
        '
        'BtnModificaCaja
        '
        Me.BtnModificaCaja.Icon = CType(resources.GetObject("BtnModificaCaja.Icon"), System.Drawing.Icon)
        Me.BtnModificaCaja.Location = New System.Drawing.Point(7, 17)
        Me.BtnModificaCaja.Name = "BtnModificaCaja"
        Me.BtnModificaCaja.Size = New System.Drawing.Size(53, 24)
        Me.BtnModificaCaja.TabIndex = 1
        Me.BtnModificaCaja.ToolTipText = "Modifica la Caja seleccionada"
        Me.BtnModificaCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRemueveCaja
        '
        Me.BtnRemueveCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRemueveCaja.Icon = CType(resources.GetObject("BtnRemueveCaja.Icon"), System.Drawing.Icon)
        Me.BtnRemueveCaja.Location = New System.Drawing.Point(127, 16)
        Me.BtnRemueveCaja.Name = "BtnRemueveCaja"
        Me.BtnRemueveCaja.Size = New System.Drawing.Size(54, 24)
        Me.BtnRemueveCaja.TabIndex = 3
        Me.BtnRemueveCaja.ToolTipText = "Remueve la Caja seleccionada "
        Me.BtnRemueveCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregaCaja
        '
        Me.BtnAgregaCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAgregaCaja.Icon = CType(resources.GetObject("BtnAgregaCaja.Icon"), System.Drawing.Icon)
        Me.BtnAgregaCaja.Location = New System.Drawing.Point(67, 16)
        Me.BtnAgregaCaja.Name = "BtnAgregaCaja"
        Me.BtnAgregaCaja.Size = New System.Drawing.Size(54, 24)
        Me.BtnAgregaCaja.TabIndex = 2
        Me.BtnAgregaCaja.ToolTipText = "Agrega una Caja"
        Me.BtnAgregaCaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 45)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(763, 169)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.cmbMarca)
        Me.GroupBox1.Controls.Add(Me.cmbTipoLicencia)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TxtVencimientoLicencia)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbPropietario)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtVencimiento)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtPoliza)
        Me.GroupBox1.Controls.Add(Me.txtEconomico)
        Me.GroupBox1.Controls.Add(Me.btnOperador)
        Me.GroupBox1.Controls.Add(Me.txtPlacas)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.BtnBusquedaTransporte)
        Me.GroupBox1.Controls.Add(Me.txtOperador)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtModelo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(777, 128)
        Me.GroupBox1.TabIndex = 180
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transporte"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(82, 76)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 26)
        Me.PictureBox4.TabIndex = 114
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(80, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 25)
        Me.PictureBox3.TabIndex = 113
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.Location = New System.Drawing.Point(98, 43)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(139, 21)
        Me.cmbMarca.TabIndex = 109
        '
        'cmbTipoLicencia
        '
        Me.cmbTipoLicencia.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoLicencia.Enabled = False
        Me.cmbTipoLicencia.Location = New System.Drawing.Point(98, 97)
        Me.cmbTipoLicencia.Name = "cmbTipoLicencia"
        Me.cmbTipoLicencia.Size = New System.Drawing.Size(139, 21)
        Me.cmbTipoLicencia.TabIndex = 108
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(241, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(111, 15)
        Me.Label18.TabIndex = 107
        Me.Label18.Text = "Vencimiento Licencia"
        '
        'TxtVencimientoLicencia
        '
        Me.TxtVencimientoLicencia.Enabled = False
        Me.TxtVencimientoLicencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVencimientoLicencia.Location = New System.Drawing.Point(356, 98)
        Me.TxtVencimientoLicencia.Name = "TxtVencimientoLicencia"
        Me.TxtVencimientoLicencia.ReadOnly = True
        Me.TxtVencimientoLicencia.Size = New System.Drawing.Size(113, 21)
        Me.TxtVencimientoLicencia.TabIndex = 106
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(7, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 15)
        Me.Label17.TabIndex = 105
        Me.Label17.Text = "Tipo Licencia"
        '
        'cmbPropietario
        '
        Me.cmbPropietario.Enabled = False
        Me.cmbPropietario.Location = New System.Drawing.Point(462, 14)
        Me.cmbPropietario.Name = "cmbPropietario"
        Me.cmbPropietario.Size = New System.Drawing.Size(177, 21)
        Me.cmbPropietario.TabIndex = 104
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(419, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 15)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "Prop."
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(474, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 102
        Me.Label15.Text = "Venc."
        '
        'txtVencimiento
        '
        Me.txtVencimiento.Enabled = False
        Me.txtVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVencimiento.Location = New System.Drawing.Point(526, 43)
        Me.txtVencimiento.Name = "txtVencimiento"
        Me.txtVencimiento.ReadOnly = True
        Me.txtVencimiento.Size = New System.Drawing.Size(113, 21)
        Me.txtVencimiento.TabIndex = 101
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(7, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Operador"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(248, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 15)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "Placas"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(302, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 15)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Poliza"
        '
        'txtPoliza
        '
        Me.txtPoliza.Enabled = False
        Me.txtPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPoliza.Location = New System.Drawing.Point(352, 43)
        Me.txtPoliza.Name = "txtPoliza"
        Me.txtPoliza.ReadOnly = True
        Me.txtPoliza.Size = New System.Drawing.Size(114, 21)
        Me.txtPoliza.TabIndex = 97
        '
        'txtEconomico
        '
        Me.txtEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEconomico.Location = New System.Drawing.Point(98, 16)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(96, 21)
        Me.txtEconomico.TabIndex = 1
        '
        'btnOperador
        '
        Me.btnOperador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOperador.Icon = CType(resources.GetObject("btnOperador.Icon"), System.Drawing.Icon)
        Me.btnOperador.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnOperador.Location = New System.Drawing.Point(718, 67)
        Me.btnOperador.Name = "btnOperador"
        Me.btnOperador.Size = New System.Drawing.Size(53, 24)
        Me.btnOperador.TabIndex = 3
        Me.btnOperador.ToolTipText = "Cambiar Operador"
        Me.btnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtPlacas
        '
        Me.txtPlacas.Enabled = False
        Me.txtPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.Location = New System.Drawing.Point(298, 16)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.ReadOnly = True
        Me.txtPlacas.Size = New System.Drawing.Size(114, 21)
        Me.txtPlacas.TabIndex = 93
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Marca/Modelo"
        '
        'BtnBusquedaTransporte
        '
        Me.BtnBusquedaTransporte.Image = CType(resources.GetObject("BtnBusquedaTransporte.Image"), System.Drawing.Image)
        Me.BtnBusquedaTransporte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaTransporte.Location = New System.Drawing.Point(202, 14)
        Me.BtnBusquedaTransporte.Name = "BtnBusquedaTransporte"
        Me.BtnBusquedaTransporte.Size = New System.Drawing.Size(27, 22)
        Me.BtnBusquedaTransporte.TabIndex = 2
        Me.BtnBusquedaTransporte.ToolTipText = "Busqueda de Transporte"
        Me.BtnBusquedaTransporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtOperador
        '
        Me.txtOperador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOperador.Enabled = False
        Me.txtOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperador.Location = New System.Drawing.Point(98, 71)
        Me.txtOperador.Multiline = True
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(608, 20)
        Me.txtOperador.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "No. Economico"
        '
        'txtModelo
        '
        Me.txtModelo.Enabled = False
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(243, 43)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(54, 21)
        Me.txtModelo.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(223, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 26)
        Me.PictureBox1.TabIndex = 164
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtNoViaje
        '
        Me.txtNoViaje.Enabled = False
        Me.txtNoViaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtNoViaje.Location = New System.Drawing.Point(567, 7)
        Me.txtNoViaje.Name = "txtNoViaje"
        Me.txtNoViaje.Size = New System.Drawing.Size(83, 21)
        Me.txtNoViaje.TabIndex = 177
        Me.txtNoViaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(497, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 15)
        Me.Label12.TabIndex = 179
        Me.Label12.Text = "No. Viaje"
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.BackColor = System.Drawing.Color.Transparent
        Me.GrpCliente.Controls.Add(Me.TxtBusqueda)
        Me.GrpCliente.Controls.Add(Me.BtnAbrir)
        Me.GrpCliente.Controls.Add(Me.BtnAgregar)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label5)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label6)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Controls.Add(Me.PictureBox5)
        Me.GrpCliente.Location = New System.Drawing.Point(2, 29)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(780, 115)
        Me.GrpCliente.TabIndex = 163
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(98, 17)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(114, 21)
        Me.TxtBusqueda.TabIndex = 1
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(656, 13)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(53, 24)
        Me.BtnAbrir.TabIndex = 3
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(714, 13)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(58, 24)
        Me.BtnAgregar.TabIndex = 4
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(98, 43)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(142, 21)
        Me.TxtRFC.TabIndex = 93
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 48)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC/Clave"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 39)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(221, 16)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(26, 22)
        Me.BtnBuscaCte.TabIndex = 2
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(98, 69)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(674, 37)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(247, 43)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(114, 21)
        Me.TxtClave.TabIndex = 3
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(80, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 25)
        Me.PictureBox5.TabIndex = 142
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.GrpSinAsignar)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(789, 501)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "Facturación"
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.BackColor = System.Drawing.Color.Transparent
        Me.GrpSinAsignar.Controls.Add(Me.Label28)
        Me.GrpSinAsignar.Controls.Add(Me.txtTotal)
        Me.GrpSinAsignar.Controls.Add(Me.cmbFechaPago)
        Me.GrpSinAsignar.Controls.Add(Me.cmbCobranza)
        Me.GrpSinAsignar.Controls.Add(Me.Label31)
        Me.GrpSinAsignar.Controls.Add(Me.Label32)
        Me.GrpSinAsignar.Controls.Add(Me.Label33)
        Me.GrpSinAsignar.Controls.Add(Me.cmbFechaFactura)
        Me.GrpSinAsignar.Controls.Add(Me.cmbVencimiento)
        Me.GrpSinAsignar.Controls.Add(Me.txtFactura)
        Me.GrpSinAsignar.Controls.Add(Me.Label34)
        Me.GrpSinAsignar.Controls.Add(Me.chkPagada)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(2, 4)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(780, 438)
        Me.GrpSinAsignar.TabIndex = 6
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Facturación"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(7, 212)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 15)
        Me.Label28.TabIndex = 173
        Me.Label28.Text = "Total"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(125, 208)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(115, 20)
        Me.txtTotal.TabIndex = 172
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTotal.Value = 0
        Me.txtTotal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'cmbFechaPago
        '
        Me.cmbFechaPago.CustomFormat = "yyyyMMdd"
        Me.cmbFechaPago.Enabled = False
        Me.cmbFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaPago.Location = New System.Drawing.Point(126, 162)
        Me.cmbFechaPago.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaPago.Name = "cmbFechaPago"
        Me.cmbFechaPago.Size = New System.Drawing.Size(114, 20)
        Me.cmbFechaPago.TabIndex = 130
        Me.cmbFechaPago.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbCobranza
        '
        Me.cmbCobranza.CustomFormat = "yyyyMMdd"
        Me.cmbCobranza.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbCobranza.Location = New System.Drawing.Point(126, 101)
        Me.cmbCobranza.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbCobranza.Name = "cmbCobranza"
        Me.cmbCobranza.Size = New System.Drawing.Size(99, 20)
        Me.cmbCobranza.TabIndex = 8
        Me.cmbCobranza.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 105)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(105, 15)
        Me.Label31.TabIndex = 122
        Me.Label31.Text = "Fecha de Cobranza"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(8, 77)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(83, 15)
        Me.Label32.TabIndex = 109
        Me.Label32.Text = "F. Vencimiento"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 51)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(114, 15)
        Me.Label33.TabIndex = 95
        Me.Label33.Text = "Fecha de Facturación"
        '
        'cmbFechaFactura
        '
        Me.cmbFechaFactura.CustomFormat = "yyyyMMdd"
        Me.cmbFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaFactura.Location = New System.Drawing.Point(126, 46)
        Me.cmbFechaFactura.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaFactura.Name = "cmbFechaFactura"
        Me.cmbFechaFactura.Size = New System.Drawing.Size(99, 20)
        Me.cmbFechaFactura.TabIndex = 6
        Me.cmbFechaFactura.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbVencimiento
        '
        Me.cmbVencimiento.CustomFormat = "yyyyMMdd"
        Me.cmbVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbVencimiento.Location = New System.Drawing.Point(126, 73)
        Me.cmbVencimiento.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbVencimiento.Name = "cmbVencimiento"
        Me.cmbVencimiento.Size = New System.Drawing.Size(99, 20)
        Me.cmbVencimiento.TabIndex = 7
        Me.cmbVencimiento.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'txtFactura
        '
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtFactura.Location = New System.Drawing.Point(126, 15)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(96, 21)
        Me.txtFactura.TabIndex = 5
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(8, 20)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(55, 15)
        Me.Label34.TabIndex = 117
        Me.Label34.Text = "Factura"
        '
        'chkPagada
        '
        Me.chkPagada.Location = New System.Drawing.Point(8, 162)
        Me.chkPagada.Name = "chkPagada"
        Me.chkPagada.Size = New System.Drawing.Size(104, 20)
        Me.chkPagada.TabIndex = 129
        Me.chkPagada.Text = "Factura Pagada"
        '
        'FrmViaje
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmViaje"
        Me.Text = "Viaje"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabPage1.ResumeLayout(False)
        Me.UiTabPage1.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpSinAsignar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public VIAClave As String
    Public noViaje As String
    Public fechaViaje As Date = DateTime.Today
    Public TRAClave As String
    Public EMPClave As String
    Public CTEClave As String
    Public Factura As String
    Public fechaFactura As Date = #1/1/2000#
    Public fechaVencimiento As Date = #1/1/2000#
    Public fechaCobranza As Date = #1/1/2000#
    Public Pagado As Integer
    Public fechaPago As Date = #1/1/2000#
    Public TotalViaje As Double = 0

    Private sTRAClave, sEMPClave, sCTEClave As String
    Private DiasCredito As Integer
    Private dTotalViaje As Double

    Private dtDetalle As DataTable
    Private sCajaSelected As String
    Private sEconomico As String

    Private cargado As Boolean = False
    Private Grabado As Boolean = False


    Private alerta(2) As PictureBox
    Private reloj As parpadea


    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If TRAClave = "" OrElse txtEconomico.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If EMPClave = "" OrElse txtOperador.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CTEClave = "" OrElse TxtBusqueda.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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

    Private Sub CargaDatosTransporte(ByVal sTRAClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_transporte", "@TRAClave", sTRAClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TRAClave = dt.Rows(0)("TRAClave")
            txtEconomico.Text = dt.Rows(0)("noEconomico")
            txtModelo.Text = dt.Rows(0)("Modelo")
            cmbMarca.SelectedValue = dt.Rows(0)("Marca")
            txtPlacas.Text = dt.Rows(0)("Placa")
            txtPoliza.Text = dt.Rows(0)("noPoliza")
            txtVencimiento.Text = CDate(dt.Rows(0)("Vencimiento")).ToShortDateString
            cmbPropietario.SelectedValue = dt.Rows(0)("Propietario")
            dt.Dispose()


            If Padre = "Agregar" Then
                dt = ModPOS.SiExisteRecupera("sp_recupera_ult_operador", "@TRAClave", sTRAClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    Me.CargaDatosEmpleado(dt.Rows(0)("EMPClave"))
                    dt.Dispose()
                End If

                dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_ult_caja", "@TRAClave", sTRAClave)
                GridDetalle.DataSource = dtDetalle
                GridDetalle.RetrieveStructure(True)
                GridDetalle.GroupByBoxVisible = False
                GridDetalle.RootTable.Columns("CONClave").Visible = False
                GridDetalle.RootTable.Columns("Tasa").Visible = False
                GridDetalle.RootTable.Columns("Impuesto").Visible = False
                GridDetalle.RootTable.Columns("Importe").Visible = False
                GridDetalle.RootTable.Columns("DTARClave").Visible = False

                GridDetalle.RootTable.Columns("ISR").Visible = False

                GridDetalle.RootTable.Columns("Nuevo").Visible = False
                GridDetalle.RootTable.Columns("Update").Visible = False
                GridDetalle.RootTable.Columns("Baja").Visible = False

                GridDetalle.RootTable.Columns("Papeles").Visible = False
                GridDetalle.RootTable.Columns("fechaPapeles").Visible = False
                GridDetalle.RootTable.Columns("Observaciones").Visible = False


                Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

                fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
                fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
                GridDetalle.RootTable.FormatConditions.Add(fc)


            End If
        Else
            MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub CargaDatosEmpleado(ByVal sEMPClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_empleado", "@EMPClave", sEMPClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            EMPClave = dt.Rows(0)("EMPClave")
            txtOperador.Text = dt.Rows(0)("NombreCompleto")
            cmbTipoLicencia.SelectedValue = IIf(dt.Rows(0)("TipoLicencia").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoLicencia"))
            TxtVencimientoLicencia.Text = IIf(dt.Rows(0)("Vencimiento").GetType.Name = "DBNull", DateTime.Today.ToShortDateString, CDate(dt.Rows(0)("Vencimiento")).ToShortDateString)
            dt.Dispose()
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            CTEClave = dt.Rows(0)("CTEClave")

            TxtBusqueda.Text = dt.Rows(0)("Clave")
            TxtClave.Text = dt.Rows(0)("Clave")
            TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
            TxtRFC.Text = dt.Rows(0)("id_Fiscal")
            DiasCredito = dt.Rows(0)("DiasCredito")
            dt.Dispose()

            Me.BtnAgregaCaja.Enabled = True
            Me.BtnModificaCaja.Enabled = True
            Me.BtnRemueveCaja.Enabled = True
            cargado = True
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarCTE()
        If CTEClave <> "" Then
            If ModPOS.Cliente Is Nothing Then
                ModPOS.Cliente = New FrmCliente
                With ModPOS.Cliente
                    .Text = "Modificar Cliente"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .fromForm = "Viaje"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClave)
                    .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                    .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                    .CTEClave = dt.Rows(0)("CTEClave")
                    .TPersona = dt.Rows(0)("TPersona")
                    .Clave = dt.Rows(0)("Clave")
                    .NombreCorto = dt.Rows(0)("NombreCorto")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .CURP = dt.Rows(0)("CURP")
                    .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                    .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                    .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                    .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                    .FechaReg = dt.Rows(0)("FechaRegistro")
                    .Estado = dt.Rows(0)("Estado")
                    .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                    .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                    .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                    .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                    .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

                    .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                    .LCredito = dt.Rows(0)("LimiteCredito")
                    .DiasCredito = dt.Rows(0)("DiasCredito")

                    .PaisF = dt.Rows(0)("Pais")
                    .EntidadF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .ColoniaF = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .LocalidadF = dt.Rows(0)("Localidad")
                    .referenciaF = dt.Rows(0)("referencia")
                    .noExteriorF = dt.Rows(0)("noExterior")
                    .noInteriorF = dt.Rows(0)("noInterior")
                    .codigoPostalF = dt.Rows(0)("codigoPostal")
                    .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                    .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")

                    .Saldo = dt.Rows(0)("Saldo")
                    .CreditoDisponible = dt.Rows(0)("Disponible")

                    .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                    .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                    .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                    .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                    .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                    .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()

        End If
    End Sub

    Private Sub FrmViaje_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Viaje.Dispose()
        ModPOS.Viaje = Nothing
        If Grabado = True AndAlso ModPOS.MtoViaje IsNot Nothing Then
            ModPOS.MtoViaje.refrescaGrid()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmViaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox5


        With cmbMarca
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Transporte"
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

        With Me.cmbTipoLicencia
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoLicencia"
            .llenar()
        End With


        If Padre = "Agregar" Then
            cmbMarca.SelectedValue = 0
            cmbTipoLicencia.SelectedValue = 0
            cmbPropietario.SelectedValue = 0


            dtDetalle = ModPOS.CrearTabla("Cajas", _
                                         "CONClave", "System.String", _
                                         "Embarque", "System.String", _
                                         "NoCarga", "System.String", _
                                         "ECO", "System.String", _
                                         "Placa", "System.String", _
                                         "Origen", "System.String", _
                                         "Destino", "System.String", _
                                         "Destinatario", "System.String", _
                                         "Carga", "System.DateTime", _
                                         "Descarga", "System.DateTime", _
                                         "Total", "System.Double", _
                                         "ISR", "System.Double", _
                                         "Impuesto", "System.Double", _
                                         "Importe", "System.Double", _
                                         "Tasa", "System.Double", _
                                         "DTARClave", "System.String", _
                                         "Nuevo", "System.Int32", _
                                         "Update", "System.Int32", _
                                         "Baja", "System.Int32", _
                                         "Papeles", "System.Int32", _
                                         "fechaPapeles", "System.DateTime", _
                                         "Observaciones", "System.String")

            Me.BtnAgregaCaja.Enabled = False
            Me.BtnModificaCaja.Enabled = False
            Me.BtnRemueveCaja.Enabled = False

        Else
            sCTEClave = CTEClave
            sEMPClave = EMPClave
            sTRAClave = TRAClave
            dTotalViaje = TotalViaje
            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_viajeDetalle", "@VIAClave", VIAClave)
            CargaDatosTransporte(TRAClave)
            CargaDatosEmpleado(EMPClave)
            CargaDatosCliente(CTEClave)
        End If


        txtNoViaje.Text = noViaje
        txtFactura.Text = Factura
        cmbFechaFactura.Value = fechaFactura
        cmbVencimiento.Value = fechaVencimiento
        cmbCobranza.Value = fechaCobranza
        chkPagada.Estado = Math.Abs(Pagado)
        cmbFechaPago.Value = fechaPago

        CmbFechaViaje.Value = fechaViaje

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("CONClave").Visible = False
        GridDetalle.RootTable.Columns("Tasa").Visible = False
        GridDetalle.RootTable.Columns("Impuesto").Visible = False
        GridDetalle.RootTable.Columns("Importe").Visible = False
        GridDetalle.RootTable.Columns("DTARClave").Visible = False

        GridDetalle.RootTable.Columns("ISR").Visible = False

        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Update").Visible = False
        GridDetalle.RootTable.Columns("Baja").Visible = False

        GridDetalle.RootTable.Columns("Papeles").Visible = False
        GridDetalle.RootTable.Columns("fechaPapeles").Visible = False
        GridDetalle.RootTable.Columns("Observaciones").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc)


        TxtTotal.Text = Format(CStr(ModPOS.Redondear(TotalViaje, 2)), "Currency")

    End Sub

    Public Function AddCaja(ByVal sRemision As String, ByVal sNoCarga As String, ByVal sCONClave As String, ByVal sECO As String, _
    ByVal sPlaca As String, ByVal sOrigen As String, ByVal sDestino As String, _
    ByVal sDestinatario As String, _
    ByVal tCarga As Date, _
    ByVal tDescarga As Date, ByVal dTotal As Double, ByVal dImpuesto As Double, ByVal dImporte As Double, _
    ByVal dTasa As Double, ByVal sDTARClave As String, ByVal iPapeles As Integer, ByVal tPapeles As Date, ByVal dISR As Double, ByVal sObservaciones As String) As Boolean

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("CONClave = '" & sCONClave & "' and Baja = 0")

        If foundRows.Length = 0 Then


            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("CONClave") = sCONClave
            row1.Item("Embarque") = sRemision
            row1.Item("NoCarga") = sNoCarga
            row1.Item("ECO") = sECO
            row1.Item("Placa") = sPlaca
            row1.Item("Origen") = sOrigen
            row1.Item("Destino") = sDestino
            row1.Item("Destinatario") = sDestinatario
            row1.Item("Carga") = tCarga
            row1.Item("Descarga") = tDescarga
            row1.Item("Total") = dTotal
            row1.Item("Impuesto") = dImpuesto
            row1.Item("Importe") = dImporte
            row1.Item("Tasa") = dTasa
            row1.Item("DTARClave") = sDTARClave
            row1.Item("Nuevo") = 1
            row1.Item("Update") = 0
            row1.Item("Baja") = 0

            row1.Item("Papeles") = iPapeles
            row1.Item("fechaPapeles") = tPapeles
            row1.Item("Observaciones") = sObservaciones
            row1.Item("ISR") = dISR


            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

        Else
            foundRows(0)("Embarque") = sRemision
            foundRows(0)("NoCarga") = sNoCarga
            foundRows(0)("Origen") = sOrigen
            foundRows(0)("Destino") = sDestino
            foundRows(0)("DTARClave") = sDTARClave
            foundRows(0)("Destinatario") = sDestinatario
            foundRows(0)("Carga") = tCarga
            foundRows(0)("Descarga") = tDescarga
            foundRows(0)("Total") = dTotal
            foundRows(0)("Impuesto") = dImpuesto
            foundRows(0)("Importe") = dImporte
            foundRows(0)("Update") = 1
            foundRows(0)("Papeles") = iPapeles
            foundRows(0)("fechaPapeles") = tPapeles
            foundRows(0)("Observaciones") = sObservaciones
            foundRows(0)("ISR") = dISR


        End If

        Dim TotalViaje As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
        txtTotal.Text = Format(CStr(ModPOS.Redondear(TotalViaje, 2)), "Currency")
        Return True

    End Function

    Private Sub btnOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperador.Click
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

    Private Sub BtnBusquedaTransporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaTransporte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_transporte"
        a.TablaCmb = "Transporte"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosTransporte(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub txtEconomico_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEconomico.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtEconomico.Text <> "" Then
                    Dim dtTransporte As DataTable
                    dtTransporte = ModPOS.SiExisteRecupera("sp_consulta_transporte", "@Economico", txtEconomico.Text.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtTransporte Is Nothing AndAlso dtTransporte.Rows.Count > 0 Then
                        Dim sTRAClave As String = dtTransporte.Rows(0)("TRAClave")
                        dtTransporte.Dispose()
                        CargaDatosTransporte(sTRAClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_transporte"
                a.TablaCmb = "Transporte"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = txtEconomico.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CargaDatosTransporte(a.valor)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Private Sub BtnRemueveCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemueveCaja.Click
        If Me.sCajaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la caja: " & sEconomico, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("CONClave Like '" & sCajaSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        ModificaCaja()
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not Me.GridDetalle.GetValue("CONClave") Is Nothing Then
            Me.BtnRemueveCaja.Enabled = True
            Me.BtnModificaCaja.Enabled = True
            Me.sCajaSelected = GridDetalle.GetValue("CONClave")
            sEconomico = GridDetalle.GetValue("ECO")
        Else
            Me.sCajaSelected = ""
            sEconomico = ""
            Me.BtnModificaCaja.Enabled = False
            Me.BtnRemueveCaja.Enabled = False
        End If
    End Sub

    Private Sub ModificaCaja()
        If sCajaSelected <> "" Then
            If ModPOS.AddCaja Is Nothing Then
                ModPOS.AddCaja = New FrmAddCaja
                With ModPOS.AddCaja
                    .Padre = "Modificar"
                    .CONClave = sCajaSelected
                    .CTEClave = Me.CTEClave
                    .Embarque = IIf(GridDetalle.GetValue("Embarque").GetType.Name = "DBNull", "", GridDetalle.GetValue("Embarque"))
                    .NoCarga = IIf(GridDetalle.GetValue("NoCarga").GetType.Name = "DBNull", "", GridDetalle.GetValue("NoCarga"))

                    .sDTARClave = GridDetalle.GetValue("DTARClave")
                    .Total = GridDetalle.GetValue("Total")
                    .Impuesto = GridDetalle.GetValue("Impuesto")
                    .Importe = GridDetalle.GetValue("Importe")
                    .Destinatario = GridDetalle.GetValue("Destinatario")

                    .Carga = IIf(GridDetalle.GetValue("Carga").GetType.Name = "DBNull", #1/1/2000#, GridDetalle.GetValue("Carga"))
                   
                    .Descarga = IIf(GridDetalle.GetValue("Descarga").GetType.Name = "DBNull", #1/1/2000#, GridDetalle.GetValue("Descarga"))
                   
                    .Papeles = IIf(GridDetalle.GetValue("Papeles").GetType.Name = "DBNull", 0, GridDetalle.GetValue("Papeles"))
                    .fechaPapeles = IIf(GridDetalle.GetValue("fechaPapeles").GetType.Name = "DBNull", #1/1/2000#, GridDetalle.GetValue("fechaPapeles"))
                    .Observacion = IIf(GridDetalle.GetValue("Observaciones").GetType.Name = "DBNull", "", GridDetalle.GetValue("Observaciones"))
                End With
            End If
            ModPOS.AddCaja.StartPosition = FormStartPosition.CenterScreen
            ModPOS.AddCaja.ShowDialog()
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnModificaCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificaCaja.Click
        ModificaCaja()
    End Sub

    Private Sub BtnAgregaCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaCaja.Click
        If ModPOS.AddCaja Is Nothing Then
            ModPOS.AddCaja = New FrmAddCaja
            With ModPOS.AddCaja
                .Padre = "Agregar"
                .CTEClave = Me.CTEClave
            End With
        End If
        ModPOS.AddCaja.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddCaja.ShowDialog()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim foundRows() As System.Data.DataRow

            If dtDetalle Is Nothing OrElse dtDetalle.Rows.Count = 0 Then
                Beep()
                MessageBox.Show("¡Debe asignar por lo menos una caja al viaje actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"
                    TotalViaje = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)

                    VIAClave = ModPOS.obtenerLlave
                    fechaViaje = CmbFechaViaje.Value

                    Factura = txtFactura.Text
                    fechaFactura = cmbFechaFactura.Value
                    fechaVencimiento = cmbVencimiento.Value
                    fechaCobranza = cmbCobranza.Value
                    Pagado = chkPagada.GetEstado
                    fechaPago = cmbFechaPago.Value

                    ModPOS.Ejecuta("sp_inserta_viaje", _
                    "@VIAClave", VIAClave, _
                    "@fechaViaje", fechaViaje, _
                    "@CTEClave", CTEClave, _
                    "@TRAClave", TRAClave, _
                    "@EMPClave", EMPClave, _
                    "@Factura", Factura, _
                    "@fechaFactura", fechaFactura, _
                    "@fechaVencimiento", fechaVencimiento, _
                    "@fechaCobranza", fechaCobranza, _
                    "@Pagado", Pagado, _
                    "@fechaPago", fechaPago, _
                    "@Total", TotalViaje, _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@Usuario", ModPOS.UsuarioActual)


                    foundRows = dtDetalle.Select(" Nuevo = 1 and Baja = 0 ")



                    If foundRows.Length <> 0 Then
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_viaje_detatalle", _
                            "@VIAClave", VIAClave, _
                            "@CONClave", foundRows(z)("CONClave"), _
                            "@Embarque", foundRows(z)("Embarque"), _
                             "@NoCarga", foundRows(z)("NoCarga"), _
                            "@Origen", foundRows(z)("Origen"), _
                            "@Destino", foundRows(z)("Destino"), _
                            "@Destinatario", foundRows(z)("Destinatario"), _
                            "@Carga", foundRows(z)("Carga"), _
                            "@Descarga", foundRows(z)("Descarga"), _
                            "@Papeles", foundRows(z)("Papeles"), _
                            "@fechaPapeles", foundRows(z)("fechaPapeles"), _
                            "@Observaciones", foundRows(z)("Observaciones"), _
                            "@Importe", foundRows(z)("Importe"), _
                            "@Impuesto", foundRows(z)("Impuesto"), _
                            "@Tasa", foundRows(z)("Tasa"), _
                            "@ISR", foundRows(z)("ISR"), _
                            "@Total", foundRows(z)("Total"), _
                            "@DTARClave", foundRows(z)("DTARClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Grabado = True
                    Me.Close()

                Case "Modificar"

                    If Not (fechaViaje = CmbFechaViaje.Value AndAlso _
                    sEMPClave = EMPClave AndAlso _
                    sCTEClave = CTEClave AndAlso _
                    dTotalViaje = TotalViaje AndAlso _
                    Factura = txtFactura.Text AndAlso _
                    fechaFactura = cmbFechaFactura.Value AndAlso _
                    fechaVencimiento = cmbVencimiento.Value AndAlso _
                    fechaCobranza = cmbCobranza.Value AndAlso _
                    Pagado = chkPagada.GetEstado AndAlso _
                    fechaPago = cmbFechaPago.Value AndAlso _
                    sTRAClave = TRAClave) Then

                        fechaViaje = CmbFechaViaje.Value
                        TotalViaje = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        Factura = txtFactura.Text
                        fechaFactura = cmbFechaFactura.Value
                        fechaVencimiento = cmbVencimiento.Value
                        fechaCobranza = cmbCobranza.Value
                        Pagado = chkPagada.GetEstado
                        fechaPago = cmbFechaPago.Value


                        ModPOS.Ejecuta("sp_modificar_viaje", _
                            "@VIAClave", VIAClave, _
                            "@fechaViaje", fechaViaje, _
                            "@TRAClave", TRAClave, _
                            "@EMPClave", EMPClave, _
                            "@CTEClave", CTEClave, _
                            "@Factura", Factura, _
                            "@fechaFactura", fechaFactura, _
                            "@fechaVencimiento", fechaVencimiento, _
                            "@fechaCobranza", fechaCobranza, _
                            "@Pagado", Pagado, _
                            "@fechaPago", fechaPago, _
                            "@Total", TotalViaje, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Grabado = True
                    End If


                    foundRows = dtDetalle.Select(" Nuevo = 0 and Baja = 1 ")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_elimina_viaje_detatalle", _
                             "@VIAClave", VIAClave, _
                             "@CONClave", foundRows(z)("CONClave"))
                        Next
                    End If


                    foundRows = dtDetalle.Select(" Update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_viaje_detatalle", _
                              "@VIAClave", VIAClave, _
                              "@CONClave", foundRows(z)("CONClave"), _
                              "@Embarque", foundRows(z)("Embarque"), _
                               "@NoCarga", foundRows(z)("NoCarga"), _
                              "@Origen", foundRows(z)("Origen"), _
                              "@Destino", foundRows(z)("Destino"), _
                              "@Destinatario", foundRows(z)("Destinatario"), _
                              "@Carga", foundRows(z)("Carga"), _
                              "@Descarga", foundRows(z)("Descarga"), _
                              "@Papeles", foundRows(z)("Papeles"), _
                              "@fechaPapeles", foundRows(z)("fechaPapeles"), _
                              "@Observaciones", foundRows(z)("Observaciones"), _
                              "@Importe", foundRows(z)("Importe"), _
                              "@Impuesto", foundRows(z)("Impuesto"), _
                              "@Total", foundRows(z)("Total"), _
                              "@Tasa", foundRows(z)("Tasa"), _
                              "@ISR", foundRows(z)("ISR"), _
                              "@DTARClave", foundRows(z)("DTARClave"), _
                              "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtDetalle.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_viaje_detatalle", _
                           "@VIAClave", VIAClave, _
                           "@CONClave", foundRows(z)("CONClave"), _
                           "@Embarque", foundRows(z)("Embarque"), _
                            "@NoCarga", foundRows(z)("NoCarga"), _
                           "@Origen", foundRows(z)("Origen"), _
                           "@Destino", foundRows(z)("Destino"), _
                           "@Destinatario", foundRows(z)("Destinatario"), _
                           "@Carga", foundRows(z)("Carga"), _
                           "@Descarga", foundRows(z)("Descarga"), _
                           "@Papeles", foundRows(z)("Papeles"), _
                           "@fechaPapeles", foundRows(z)("fechaPapeles"), _
                           "@Observaciones", foundRows(z)("Observaciones"), _
                           "@Importe", foundRows(z)("Importe"), _
                           "@Impuesto", foundRows(z)("Impuesto"), _
                           "@Tasa", foundRows(z)("Tasa"), _
                           "@ISR", foundRows(z)("ISR"), _
                           "@Total", foundRows(z)("Total"), _
                           "@DTARClave", foundRows(z)("DTARClave"), _
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

    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosCliente(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            ModPOS.Cliente.fromForm = "Viaje"
            With ModPOS.Cliente
                .Text = "Agregar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabSaldos.Enabled = False

            End With
        End If
        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()
    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If Me.TxtClave.Text <> "" Then
            modificarCTE()
        End If
    End Sub

    Private Sub chkPagada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPagada.CheckedChanged
        If chkPagada.Checked = True Then
            cmbFechaPago.Enabled = True
        Else
            cmbFechaPago.Enabled = False
        End If
    End Sub

    Private Sub TxtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtBusqueda.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        Dim sCTEClave As String = dtCliente.Rows(0)("CTEClave")
                        dtCliente.Dispose()
                        CargaDatosCliente(sCTEClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CargaDatosCliente(a.valor)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Private Sub cmbFechaFactura_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFechaFactura.Leave
        If cargado = True Then
            Dim dVencimiento As Date
            dVencimiento = cmbFechaFactura.Value
            cmbVencimiento.Value = dVencimiento.AddDays(DiasCredito)
        End If
    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab1.SelectedTabChanged
        If GridDetalle.RowCount > 0 Then
            TotalViaje = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum)
            txtTotal.Text = String.Format(CStr(ModPOS.Redondear(TotalViaje, 2)), "Currency")
        End If
    End Sub

End Class
