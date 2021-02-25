
Public Class FrmEnvio
    Inherits System.Windows.Forms.Form
    Implements ITeclado

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
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents dtFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpEnvio As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDestinatario As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaEnvio As Selling.StoreCombo
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDireccion As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEntrega As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbZonaReparto As Selling.StoreCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnStage As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtStage As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lblNomOperador As System.Windows.Forms.Label
    Friend WithEvents TxtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents BtnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBusquedaTransporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblEconomico As System.Windows.Forms.Label
    Friend WithEvents txtEconomico As System.Windows.Forms.TextBox
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvio))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.dtFechaPrevista = New System.Windows.Forms.DateTimePicker()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrpEnvio = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmbZonaReparto = New Selling.StoreCombo()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnDireccion = New Janus.Windows.EditControls.UIButton()
        Me.LstDomicilio = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpDestinatario = New System.Windows.Forms.GroupBox()
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnStage = New Janus.Windows.EditControls.UIButton()
        Me.TxtStage = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoEntrega = New Selling.StoreCombo()
        Me.CmbFormaEnvio = New Selling.StoreCombo()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblNomOperador = New System.Windows.Forms.Label()
        Me.TxtEmpleado = New System.Windows.Forms.TextBox()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.BtnOperador = New Janus.Windows.EditControls.UIButton()
        Me.BtnBusquedaTransporte = New Janus.Windows.EditControls.UIButton()
        Me.lblEconomico = New System.Windows.Forms.Label()
        Me.txtEconomico = New System.Windows.Forms.TextBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpEnvio.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDestinatario.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSaldos.Controls.Add(Me.Label26)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(8, 8)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(757, 349)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(392, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 16)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Location = New System.Drawing.Point(496, 16)
        Me.NumSaldo.Name = "NumSaldo"
        Me.NumSaldo.ReadOnly = True
        Me.NumSaldo.Size = New System.Drawing.Size(160, 20)
        Me.NumSaldo.TabIndex = 60
        Me.NumSaldo.Text = "0.00"
        Me.NumSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumSaldo.Value = 0.0R
        Me.NumSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(16, 16)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(104, 16)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Crédito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(128, 16)
        Me.NumDisponible.Name = "NumDisponible"
        Me.NumDisponible.ReadOnly = True
        Me.NumDisponible.Size = New System.Drawing.Size(160, 20)
        Me.NumDisponible.TabIndex = 58
        Me.NumDisponible.Text = "0.00"
        Me.NumDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumDisponible.Value = 0.0R
        Me.NumDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GridSaldos
        '
        Me.GridSaldos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSaldos.ColumnAutoResize = True
        Me.GridSaldos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSaldos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSaldos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSaldos.Location = New System.Drawing.Point(16, 40)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(725, 293)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMetodos.Controls.Add(Me.BtnAgregar)
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Controls.Add(Me.BtnElimina)
        Me.GrpMetodos.Controls.Add(Me.BtnModifica)
        Me.GrpMetodos.Location = New System.Drawing.Point(3, 3)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(768, 359)
        Me.GrpMetodos.TabIndex = 5
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(680, 16)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nuevo Metodo de Pago"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMetodos
        '
        Me.GridMetodos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetodos.ColumnAutoResize = True
        Me.GridMetodos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMetodos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMetodos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMetodos.Location = New System.Drawing.Point(8, 16)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(664, 335)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(680, 104)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(80, 24)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Eliminar "
        Me.BtnElimina.ToolTipText = "Elimina el Metodo de Pago seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(680, 64)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(80, 24)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.Text = "&Modificar "
        Me.BtnModifica.ToolTipText = "Modifica el Metodo de Pago seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 23)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(77, 15)
        Me.LblClave.TabIndex = 106
        Me.LblClave.Text = "Cliente"
        '
        'dtFechaPrevista
        '
        Me.dtFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaPrevista.Location = New System.Drawing.Point(128, 71)
        Me.dtFechaPrevista.Name = "dtFechaPrevista"
        Me.dtFechaPrevista.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaPrevista.TabIndex = 110
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(648, 490)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 117
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(550, 490)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar Envio"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 34)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Dirección de Envío"
        '
        'GrpEnvio
        '
        Me.GrpEnvio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEnvio.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpEnvio.Controls.Add(Me.PictureBox3)
        Me.GrpEnvio.Controls.Add(Me.cmbZonaReparto)
        Me.GrpEnvio.Controls.Add(Me.Label28)
        Me.GrpEnvio.Controls.Add(Me.btnDireccion)
        Me.GrpEnvio.Controls.Add(Me.LstDomicilio)
        Me.GrpEnvio.Controls.Add(Me.Label4)
        Me.GrpEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpEnvio.ForeColor = System.Drawing.Color.Black
        Me.GrpEnvio.Location = New System.Drawing.Point(8, 217)
        Me.GrpEnvio.Name = "GrpEnvio"
        Me.GrpEnvio.Size = New System.Drawing.Size(731, 128)
        Me.GrpEnvio.TabIndex = 124
        Me.GrpEnvio.TabStop = False
        Me.GrpEnvio.Text = "Datos de Envío:"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(91, 94)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(26, 17)
        Me.PictureBox3.TabIndex = 142
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 16
        Me.cmbZonaReparto.Location = New System.Drawing.Point(120, 91)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(512, 24)
        Me.cmbZonaReparto.TabIndex = 128
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(4, 94)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(115, 15)
        Me.Label28.TabIndex = 129
        Me.Label28.Text = "Zona de Reparto"
        '
        'btnDireccion
        '
        Me.btnDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDireccion.Icon = CType(resources.GetObject("btnDireccion.Icon"), System.Drawing.Icon)
        Me.btnDireccion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnDireccion.Location = New System.Drawing.Point(635, 21)
        Me.btnDireccion.Name = "btnDireccion"
        Me.btnDireccion.Size = New System.Drawing.Size(90, 30)
        Me.btnDireccion.TabIndex = 127
        Me.btnDireccion.Text = "&Cambiar"
        Me.btnDireccion.ToolTipText = "Permite elegir una dirección de Envío distinta"
        Me.btnDireccion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LstDomicilio
        '
        Me.LstDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstDomicilio.Enabled = False
        Me.LstDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDomicilio.ItemHeight = 15
        Me.LstDomicilio.Location = New System.Drawing.Point(120, 21)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(509, 64)
        Me.LstDomicilio.TabIndex = 124
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(99, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 17)
        Me.PictureBox1.TabIndex = 138
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.Location = New System.Drawing.Point(15, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 15)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Forma de Envío"
        '
        'GrpDestinatario
        '
        Me.GrpDestinatario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDestinatario.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDestinatario.Controls.Add(Me.BtnAbrir)
        Me.GrpDestinatario.Controls.Add(Me.TxtClave)
        Me.GrpDestinatario.Controls.Add(Me.TxtRazonSocial)
        Me.GrpDestinatario.Controls.Add(Me.Label1)
        Me.GrpDestinatario.Controls.Add(Me.LblClave)
        Me.GrpDestinatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDestinatario.ForeColor = System.Drawing.Color.Black
        Me.GrpDestinatario.Location = New System.Drawing.Point(7, 132)
        Me.GrpDestinatario.Name = "GrpDestinatario"
        Me.GrpDestinatario.Size = New System.Drawing.Size(731, 79)
        Me.GrpDestinatario.TabIndex = 125
        Me.GrpDestinatario.TabStop = False
        Me.GrpDestinatario.Text = "Destinatario:"
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(312, 13)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(90, 30)
        Me.BtnAbrir.TabIndex = 125
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Modificar datos del Cliente"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(120, 20)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(142, 21)
        Me.TxtClave.TabIndex = 124
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(119, 53)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(592, 19)
        Me.TxtRazonSocial.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 17)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Razón Social"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(15, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Fecha Prevista"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtReferencia.Location = New System.Drawing.Point(128, 103)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(352, 21)
        Me.TxtReferencia.TabIndex = 129
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(17, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Referencia"
        '
        'TxtNota
        '
        Me.TxtNota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(128, 387)
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(590, 89)
        Me.TxtNota.TabIndex = 132
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(9, 387)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 15)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Observaciones"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(9, 499)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 32)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 134
        Me.picKeyboard.TabStop = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(15, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 20)
        Me.Label8.TabIndex = 140
        Me.Label8.Text = "Tipo de Entrega"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(99, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 18)
        Me.PictureBox2.TabIndex = 141
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnStage
        '
        Me.BtnStage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnStage.Image = CType(resources.GetObject("BtnStage.Image"), System.Drawing.Image)
        Me.BtnStage.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnStage.Location = New System.Drawing.Point(234, 355)
        Me.BtnStage.Name = "BtnStage"
        Me.BtnStage.Size = New System.Drawing.Size(35, 22)
        Me.BtnStage.TabIndex = 150
        Me.BtnStage.ToolTipText = "Busqueda de Anden"
        Me.BtnStage.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtStage
        '
        Me.TxtStage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtStage.Enabled = False
        Me.TxtStage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStage.Location = New System.Drawing.Point(128, 356)
        Me.TxtStage.Name = "TxtStage"
        Me.TxtStage.ReadOnly = True
        Me.TxtStage.Size = New System.Drawing.Size(98, 21)
        Me.TxtStage.TabIndex = 149
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 361)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 15)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Ubicación de Entrega"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(99, 359)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(26, 17)
        Me.PictureBox4.TabIndex = 151
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'cmbTipoEntrega
        '
        Me.cmbTipoEntrega.Location = New System.Drawing.Point(127, 9)
        Me.cmbTipoEntrega.Name = "cmbTipoEntrega"
        Me.cmbTipoEntrega.Size = New System.Drawing.Size(249, 21)
        Me.cmbTipoEntrega.TabIndex = 139
        '
        'CmbFormaEnvio
        '
        Me.CmbFormaEnvio.Location = New System.Drawing.Point(128, 40)
        Me.CmbFormaEnvio.Name = "CmbFormaEnvio"
        Me.CmbFormaEnvio.Size = New System.Drawing.Size(249, 21)
        Me.CmbFormaEnvio.TabIndex = 125
        Me.CmbFormaEnvio.Text = " "
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(469, 9)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox5.TabIndex = 179
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'lblNomOperador
        '
        Me.lblNomOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomOperador.Location = New System.Drawing.Point(391, 68)
        Me.lblNomOperador.Name = "lblNomOperador"
        Me.lblNomOperador.Size = New System.Drawing.Size(341, 15)
        Me.lblNomOperador.TabIndex = 178
        Me.lblNomOperador.Text = "Nombre:"
        Me.lblNomOperador.Visible = False
        '
        'TxtEmpleado
        '
        Me.TxtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtEmpleado.Location = New System.Drawing.Point(499, 38)
        Me.TxtEmpleado.Name = "TxtEmpleado"
        Me.TxtEmpleado.Size = New System.Drawing.Size(73, 21)
        Me.TxtEmpleado.TabIndex = 176
        Me.TxtEmpleado.Visible = False
        '
        'lblPlacas
        '
        Me.lblPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.Location = New System.Drawing.Point(619, 11)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(124, 15)
        Me.lblPlacas.TabIndex = 175
        Me.lblPlacas.Text = "Placas:"
        Me.lblPlacas.Visible = False
        '
        'BtnOperador
        '
        Me.BtnOperador.Image = CType(resources.GetObject("BtnOperador.Image"), System.Drawing.Image)
        Me.BtnOperador.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnOperador.Location = New System.Drawing.Point(578, 37)
        Me.BtnOperador.Name = "BtnOperador"
        Me.BtnOperador.Size = New System.Drawing.Size(35, 22)
        Me.BtnOperador.TabIndex = 174
        Me.BtnOperador.ToolTipText = "Busqueda de Operador o Chofer"
        Me.BtnOperador.Visible = False
        Me.BtnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBusquedaTransporte
        '
        Me.BtnBusquedaTransporte.Image = CType(resources.GetObject("BtnBusquedaTransporte.Image"), System.Drawing.Image)
        Me.BtnBusquedaTransporte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaTransporte.Location = New System.Drawing.Point(578, 6)
        Me.BtnBusquedaTransporte.Name = "BtnBusquedaTransporte"
        Me.BtnBusquedaTransporte.Size = New System.Drawing.Size(35, 22)
        Me.BtnBusquedaTransporte.TabIndex = 172
        Me.BtnBusquedaTransporte.ToolTipText = "Busqueda de Transporte o Vehiculo"
        Me.BtnBusquedaTransporte.Visible = False
        Me.BtnBusquedaTransporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblEconomico
        '
        Me.lblEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEconomico.Location = New System.Drawing.Point(392, 11)
        Me.lblEconomico.Name = "lblEconomico"
        Me.lblEconomico.Size = New System.Drawing.Size(101, 15)
        Me.lblEconomico.TabIndex = 177
        Me.lblEconomico.Text = "No. Economico"
        Me.lblEconomico.Visible = False
        '
        'txtEconomico
        '
        Me.txtEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEconomico.Location = New System.Drawing.Point(499, 6)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(73, 21)
        Me.txtEconomico.TabIndex = 171
        Me.txtEconomico.Visible = False
        '
        'lblOperador
        '
        Me.lblOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.Location = New System.Drawing.Point(392, 41)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(88, 15)
        Me.lblOperador.TabIndex = 173
        Me.lblOperador.Text = "Operador"
        Me.lblOperador.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(469, 39)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox6.TabIndex = 180
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'FrmEnvio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(743, 534)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.lblNomOperador)
        Me.Controls.Add(Me.TxtEmpleado)
        Me.Controls.Add(Me.lblPlacas)
        Me.Controls.Add(Me.BtnOperador)
        Me.Controls.Add(Me.BtnBusquedaTransporte)
        Me.Controls.Add(Me.txtEconomico)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.BtnStage)
        Me.Controls.Add(Me.TxtStage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbTipoEntrega)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CmbFormaEnvio)
        Me.Controls.Add(Me.GrpDestinatario)
        Me.Controls.Add(Me.GrpEnvio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.TxtReferencia)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtFechaPrevista)
        Me.Controls.Add(Me.lblEconomico)
        Me.Controls.Add(Me.lblOperador)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(667, 516)
        Me.Name = "FrmEnvio"
        Me.Text = "Detalle de Entrega "
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpEnvio.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDestinatario.ResumeLayout(False)
        Me.GrpDestinatario.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Tipo As String = ""
    Public Packing As Boolean = False
    Public CTEClave As String
    Public VENClave As String
    Public VentaCerrada As Boolean
    Public ALMClave As String

    Private ENVClave As String

    Private formaEnvio As Integer
    Private Observaciones As String
    Private fechaPrevista As Date = Today.Date
    Private ZonaReparto As Integer
    Private ZonaRepartoCte As Integer
    Private Referencia As String
    Private tipoEntrega As Integer
    Private UBCClave, oUBCClave As String

    Private Clave As String
    Private RazonSocial As String

    Private DomicilioClave As String
    Private DCTEClave As String
    Private Entidad As String
    Private noExterior As String
    Private noInterior As String
    Private Colonia As String
    Private Mnpio As String
    Private Calle As String
    Private codigoPostal As String

    Public Padre As String

    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False
    Private bError As Boolean = False

    Private EMPClave, oEMPClave As String
    Private TRAClave, oTRAClave As String
    Private textBoxActual As Control

    Public Sub CargaDatosCliente(ByVal CTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            Clave = dt.Rows(0)("Clave")
            RazonSocial = dt.Rows(0)("RazonSocial")
            DCTEClave = dt.Rows(0)("DCTEClave")

            Entidad = dt.Rows(0)("Entidad")
            Mnpio = dt.Rows(0)("Municipio")
            Colonia = dt.Rows(0)("Colonia")
            Calle = dt.Rows(0)("Calle")
            noExterior = dt.Rows(0)("noExterior")
            noInterior = dt.Rows(0)("noInterior")
            codigoPostal = dt.Rows(0)("codigoPostal")
            ZonaRepartoCte = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))


            dt.Dispose()

            DomicilioClave = DCTEClave



            TxtClave.Text = Clave
            TxtRazonSocial.Text = RazonSocial

            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(Calle & " " & noExterior & " " & noInterior)
            LstDomicilio.Items.Add(Colonia & ", " & codigoPostal)
            LstDomicilio.Items.Add(Mnpio & ", " & Entidad)
            cmbZonaReparto.SelectedValue = ZonaRepartoCte


        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub CargaDatosDomicilio(ByVal DCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_domiciliocliente", "@DCTEClave", DCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            Entidad = dt.Rows(0)("Entidad")
            Mnpio = dt.Rows(0)("Municipio")
            Colonia = dt.Rows(0)("Colonia")
            Calle = dt.Rows(0)("Calle")
            noExterior = dt.Rows(0)("noExterior")
            noInterior = dt.Rows(0)("noInterior")
            codigoPostal = dt.Rows(0)("codigoPostal")
            ZonaRepartoCte = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", -1, dt.Rows(0)("ZonaReparto"))

            cmbZonaReparto.SelectedValue = ZonaRepartoCte
            dt.Dispose()

            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(Calle & " " & noExterior & " " & noInterior)
            LstDomicilio.Items.Add(Colonia & ", " & codigoPostal)
            LstDomicilio.Items.Add(Mnpio & ", " & Entidad)

        Else
            MessageBox.Show("La información del Domicilio no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        If Tipo = "TPV" Then
            lblEconomico.Visible = True
            txtEconomico.Visible = True
            BtnBusquedaTransporte.Visible = True
            lblPlacas.Visible = True

            lblOperador.Visible = True
            TxtEmpleado.Visible = True
            BtnOperador.Visible = True
            lblNomOperador.Visible = True
        Else
            TRAClave = Nothing
            EMPClave = Nothing
        End If

        With Me.cmbTipoEntrega
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "tipoEntrega"
            .llenar()
        End With

        With Me.CmbFormaEnvio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With

        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With


        CargaDatosCliente(CTEClave)


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

        If dt.Rows.Count > 0 Then
            Padre = "Modificar"

            ENVClave = dt.Rows(0)("ENVClave")

            DCTEClave = dt.Rows(0)("DCTEClave")

            tipoEntrega = dt.Rows(0)("tipoEntrega")
            formaEnvio = dt.Rows(0)("formaEnvio")
            Observaciones = dt.Rows(0)("Observaciones")
            fechaPrevista = dt.Rows(0)("fechaPrevista")
            ZonaReparto = dt.Rows(0)("ZonaReparto")
            Referencia = dt.Rows(0)("Referencia")
            tipoEntrega = dt.Rows(0)("tipoEntrega")
            UBCClave = IIf(dt.Rows(0)("UBCClave").GetType.Name = "DBNull", "", dt.Rows(0)("UBCClave"))
            TxtStage.Text = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))

            TRAClave = IIf(dt.Rows(0)("TRAClave").GetType.Name = "DBNull", "", dt.Rows(0)("TRAClave"))
            EMPClave = IIf(dt.Rows(0)("EMPClave").GetType.Name = "DBNull", "", dt.Rows(0)("EMPClave"))
            oTRAClave = TRAClave
            oEMPClave = EMPClave

            oUBCClave = UBCClave

            dt.Dispose()

            CargaDatosDomicilio(DCTEClave)

            If Tipo = "TPV" Then
                CargaDatosTransporte(TRAClave)
                CargaDatosEmpleado(EMPClave)
            End If

            DomicilioClave = DCTEClave

            cmbTipoEntrega.SelectedValue = tipoEntrega

            actTipoEngrega()

            CmbFormaEnvio.SelectedValue = formaEnvio
            cmbZonaReparto.SelectedValue = ZonaReparto
            TxtNota.Text = Observaciones
            dtFechaPrevista.Value = fechaPrevista



            TxtReferencia.Text = Referencia
        Else
            Padre = "Agregar"
            ENVClave = ModPOS.obtenerLlave


            actTipoEngrega()
            oUBCClave = ""
            If Not CmbFormaEnvio.SelectedValue Is Nothing Then

                dt = ModPOS.Recupera_Tabla("st_obtener_stage", "@ALMClave", ALMClave, "@FormaEnvio", CmbFormaEnvio.SelectedValue)

                If dt.Rows.Count > 0 Then
                    UBCClave = dt.Rows(0)("UBCClave")
                    Me.TxtStage.Text = dt.Rows(0)("Ubicacion")
                Else
                    UBCClave = ""
                    TxtStage.Text = ""
                End If
                dt.Dispose()
            End If
        End If

        bload = True
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0



        If Me.cmbTipoEntrega.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        Else
            If cmbTipoEntrega.SelectedValue = 3 AndAlso CmbFormaEnvio.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
            ElseIf cmbTipoEntrega.SelectedValue = 2 AndAlso (cmbZonaReparto.SelectedValue Is Nothing OrElse cmbZonaReparto.SelectedValue = 0) Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
            End If

            If Tipo = "TPV" Then
                If cmbTipoEntrega.SelectedValue = 2 Then

                    'If TRAClave = "" Then
                    '    i += 1
                    '    reloj = New parpadea(Me.alerta(4))
                    '    reloj.Enabled = True
                    '    reloj.Start()
                    'End If

                    If EMPClave = "" Then
                        i += 1
                        reloj = New parpadea(Me.alerta(5))
                        reloj.Enabled = True
                        reloj.Start()
                    End If

                End If
            End If


        End If

        If UBCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub FrmEnvio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not ModPOS.Teclado Is Nothing Then
            ModPOS.Teclado.Close()
        End If
        If validaForm() Then

            If dtFechaPrevista.Value < Today Then
                bError = True
                Beep()
                MessageBox.Show("La fecha prevista de entrega no puede ser menor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"

                    DCTEClave = DomicilioClave
                    tipoEntrega = cmbTipoEntrega.SelectedValue
                    formaEnvio = CmbFormaEnvio.SelectedValue
                    Observaciones = TxtNota.Text
                    fechaPrevista = dtFechaPrevista.Value
                    ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue)
                    Referencia = TxtReferencia.Text
                    oUBCClave = UBCClave
                    oTRAClave = TRAClave
                    oEMPClave = EMPClave

                    ModPOS.Ejecuta("sp_inserta_envio", _
                                   "@ENVClave", ENVClave, _
                                   "@VENClave", VENClave, _
                                   "@tipoEntrega", tipoEntrega, _
                                   "@DCTEClave", DCTEClave, _
                                   "@formaEnvio", formaEnvio, _
                                   "@Observaciones", Observaciones, _
                                   "@fechaPrevista", fechaPrevista, _
                                   "@TRAClave", TRAClave, _
                                   "@EMPClave", EMPClave, _
                                   "@ZonaReparto", ZonaReparto, _
                                   "@Referencia", Referencia, _
                                   "@VentaCerrada", VentaCerrada, _
                                   "@UBCClave", UBCClave, _
                                   "@Packing", Packing, _
                                   "@Usuario", ModPOS.UsuarioActual)


                Case "Modificar"
                    If Not (DomicilioClave = DCTEClave AndAlso _
                        formaEnvio = CmbFormaEnvio.SelectedValue AndAlso _
                        Observaciones = TxtNota.Text AndAlso _
                        fechaPrevista = dtFechaPrevista.Value AndAlso _
                        Referencia = TxtReferencia.Text AndAlso _
                        oUBCClave = UBCClave AndAlso _
                         oTRAClave = TRAClave AndAlso _
                        oEMPClave = EMPClave AndAlso _
                        ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue) AndAlso _
                        tipoEntrega = cmbTipoEntrega.SelectedValue) Then

                        DCTEClave = DomicilioClave
                        tipoEntrega = cmbTipoEntrega.SelectedValue
                        formaEnvio = CmbFormaEnvio.SelectedValue
                        Observaciones = TxtNota.Text
                        fechaPrevista = dtFechaPrevista.Value
                        Referencia = TxtReferencia.Text
                        ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue)
                        oUBCClave = UBCClave
                        oTRAClave = TRAClave
                        oEMPClave = EMPClave

                        ModPOS.Ejecuta("sp_modifica_envio", _
                                       "@ENVClave", ENVClave, _
                                       "@tipoEntrega", tipoEntrega, _
                                       "@DCTEClave", DCTEClave, _
                                       "@formaEnvio", formaEnvio, _
                                       "@Observaciones", Observaciones, _
                                       "@fechaPrevista", fechaPrevista, _
                                       "@TRAClave", TRAClave, _
                                       "@EMPClave", EMPClave, _
                                       "@ZonaReparto", ZonaReparto, _
                                       "@Referencia", Referencia, _
                                       "@VentaCerrada", VentaCerrada, _
                                       "@UBCClave", UBCClave, _
                                       "@VENClave", VENClave, _
                                        "@Packing", Packing, _
                                       "@Usuario", ModPOS.UsuarioActual)

                    End If





            End Select
            bError = False
            Me.Close()
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Modificar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtClave.ReadOnly = True
                .fromForm = "Envio"
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
                .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
               
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
                .fechaNacimiento = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
                .Genero = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 0, dt.Rows(0)("Genero"))
                .tipoTel1 = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))
                .tipoTel2 = IIf(dt.Rows(0)("tipoTel2").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel2"))

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
                .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()

    End Sub

    Private Sub btnDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDireccion.Click
        Dim a As New FrmConsulta
        a.Intro = False
        a.Campo = "DCTEClave"
        a.AutoSizeForm = False
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_domiciliocte", "@CTEClave", CTEClave)
        a.GridConsultaGen.RootTable.Columns("DCTEClave").Visible = False
        a.GridConsultaGen.RootTable.Columns("Pais").Visible = False
        a.GridConsultaGen.RootTable.Columns("NombreCorto").Visible = False
        a.GridConsultaGen.RootTable.Columns("Clave").Width = 95
        a.GridConsultaGen.RootTable.Columns("Consignatario").Width = 250
        a.GridConsultaGen.RootTable.Columns("Calle").Width = 250
        a.GridConsultaGen.RootTable.Columns("noExterior").Width = 40
        a.GridConsultaGen.RootTable.Columns("noInterior").Width = 30
        a.GridConsultaGen.RootTable.Columns("Colonia").Width = 150
        a.GridConsultaGen.RootTable.Columns("CodigoPostal").Width = 40
        a.GridConsultaGen.RootTable.Columns("Municipio").Width = 80
        a.GridConsultaGen.RootTable.Columns("Estado").Width = 60
        a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal


        a.GridConsultaGen.CurrentTable.Columns("TImpuesto").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = a.GridConsultaGen.Tables(0).Columns("TImpuesto").ValueList
        With AircraftTypeValueListItemCollection2

            Dim dtImpuesto As DataTable = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Impuesto", "@Campo", "Tipo")

            Dim i As Integer

            For i = 0 To dtImpuesto.Rows.Count - 1
                .Add(dtImpuesto.Rows(i)("valor"), dtImpuesto.Rows(i)("descripcion"))
            Next

        End With
        a.GridConsultaGen.CurrentTable.Columns("TImpuesto").EditType = Janus.Windows.GridEX.EditType.Combo





        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ID <> "" Then
                DomicilioClave = a.ID
                CargaDatosDomicilio(DomicilioClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        AbrirTeclado(Me)
    End Sub


    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar
        Dim texto As String = textBoxActual.Text
        If dato = "DESHACER" OrElse dato = "" And texto.Length > 0 Then
            textBoxActual.Text = textBoxActual.Text.Remove(texto.Length - 1, 1)
        Else
            textBoxActual.Text &= dato
            Clock.Start()
        End If

    End Sub

    Private Sub actTipoEngrega()
        If bload = True AndAlso Not cmbTipoEntrega.SelectedValue Is Nothing Then
            If cmbTipoEntrega.SelectedValue = 3 Then
                CmbFormaEnvio.Enabled = True
                TxtReferencia.Enabled = True
                cmbZonaReparto.Enabled = False
                CmbFormaEnvio.SelectedValue = 2
                cmbZonaReparto.SelectedValue = -1

            ElseIf cmbTipoEntrega.SelectedValue = 2 Then
                CmbFormaEnvio.Enabled = False
                CmbFormaEnvio.SelectedValue = 1
                cmbZonaReparto.Enabled = False
                TxtReferencia.Enabled = True
                cmbZonaReparto.SelectedValue = ZonaRepartoCte
            Else
                cmbZonaReparto.Enabled = False
                cmbZonaReparto.SelectedValue = -1
                TxtReferencia.Enabled = False
                TxtReferencia.Text = ""
                CmbFormaEnvio.Enabled = False
                CmbFormaEnvio.SelectedValue = 0
            End If
        End If
    End Sub

    Private Sub cmbTipoEntrega_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoEntrega.SelectedValueChanged
        actTipoEngrega()
    End Sub

    Private Sub BtnStage_Click(sender As Object, e As EventArgs) Handles BtnStage.Click
        Dim a As New FrmConsulta
        a.Campo = "UBCClave"
        a.Campo2 = "Stage"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_stage", "@ALMClave", ALMClave)
        a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ID <> "" Then

                Dim dtubc As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", a.ID)
                If CInt(dtubc.Rows(0)("Estado")) <> 1 Then
                    MessageBox.Show("El  Estado del Stage o Ubicación seleccionada debe ser Disponible ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    UBCClave = ""
                    TxtStage.Text = ""
                    dtubc.Dispose()
                    Exit Sub
                End If
                dtubc.Dispose()

                UBCClave = a.ID
                Me.TxtStage.Text = a.ID2
            End If
        End If
        a.Dispose()

    End Sub


    Private Sub CmbFormaEnvio_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbFormaEnvio.SelectedValueChanged
        If bload = True Then
            If Not CmbFormaEnvio.SelectedValue Is Nothing Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("st_obtener_stage", "@ALMClave", ALMClave, "@FormaEnvio", CmbFormaEnvio.SelectedValue)

                If dt.Rows.Count > 0 Then
                    UBCClave = dt.Rows(0)("UBCClave")
                    Me.TxtStage.Text = dt.Rows(0)("Ubicacion")
                Else
                    UBCClave = ""
                    TxtStage.Text = ""
                End If
                dt.Dispose()
            End If
        End If
    End Sub


    Private Sub CargaDatosTransporte(ByVal sTRAClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_transporte", "@TRAClave", sTRAClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TRAClave = dt.Rows(0)("TRAClave")
            txtEconomico.Text = dt.Rows(0)("noEconomico")
            lblPlacas.Text = dt.Rows(0)("Placa")
            dt.Dispose()
        Else
            TRAClave = ""
            txtEconomico.Text = ""
            lblPlacas.Text = ""
     
            MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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

    Private Sub BtnBusquedaTransporte_Click(sender As Object, e As EventArgs) Handles BtnBusquedaTransporte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_transporte"
        a.TablaCmb = "Transporte"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.BusquedaInicial = True
        a.Busqueda = "%"
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosTransporte(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnOperador_Click(sender As Object, e As EventArgs) Handles BtnOperador.Click
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

    Private Sub txtEconomico_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEconomico.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtEconomico.Text <> "" Then
                    Dim dtTransporte As DataTable
                    dtTransporte = ModPOS.SiExisteRecupera("sp_consulta_transporte", "@Economico", txtEconomico.Text.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtTransporte Is Nothing AndAlso dtTransporte.Rows.Count > 0 Then
                        Dim sTRAClave As String = dtTransporte.Rows(0)("TRAClave")
                        dtTransporte.Dispose()
                        CargaDatosTransporte(sTRAClave)
                    Else
                        TRAClave = ""
                        txtEconomico.Text = ""
                        lblPlacas.Text = ""
                  
                        MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)

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

    Private Sub TxtEmpleado_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtEmpleado.KeyUp
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

    Private Sub txtEconomico_Enter(sender As Object, e As EventArgs) Handles txtEconomico.Enter
        textBoxActual = Me.txtEconomico
    End Sub

    Private Sub TxtEmpleado_Enter(sender As Object, e As EventArgs) Handles TxtEmpleado.Enter
        textBoxActual = Me.TxtEmpleado
    End Sub

    Private Sub TxtReferencia_Enter(sender As Object, e As EventArgs) Handles TxtReferencia.Enter
        textBoxActual = Me.TxtReferencia
    End Sub

    Private Sub TxtNota_Enter(sender As Object, e As EventArgs) Handles TxtNota.Enter
        textBoxActual = Me.TxtNota
    End Sub
End Class
