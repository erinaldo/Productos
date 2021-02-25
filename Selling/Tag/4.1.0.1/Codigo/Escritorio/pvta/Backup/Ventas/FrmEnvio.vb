
Public Class FrmEnvio
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
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvio))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpSaldos = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblCredito = New System.Windows.Forms.Label
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX
        Me.GrpMetodos = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.LblClave = New System.Windows.Forms.Label
        Me.dtFechaPrevista = New System.Windows.Forms.DateTimePicker
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.btnSalir = New Janus.Windows.EditControls.UIButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpEnvio = New System.Windows.Forms.GroupBox
        Me.btnDireccion = New Janus.Windows.EditControls.UIButton
        Me.LstDomicilio = New System.Windows.Forms.ListBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpDestinatario = New System.Windows.Forms.GroupBox
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbTipoEntrega = New Selling.StoreCombo
        Me.CmbFormaEnvio = New Selling.StoreCombo
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmbZonaReparto = New Selling.StoreCombo
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpEnvio.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDestinatario.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.NumSaldo.Value = 0
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
        Me.NumDisponible.Value = 0
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
        Me.BtnGuardar.Location = New System.Drawing.Point(600, 490)
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
        Me.btnSalir.Location = New System.Drawing.Point(502, 490)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
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
        Me.GrpEnvio.Size = New System.Drawing.Size(683, 128)
        Me.GrpEnvio.TabIndex = 124
        Me.GrpEnvio.TabStop = False
        Me.GrpEnvio.Text = "Datos de Envío:"
        '
        'btnDireccion
        '
        Me.btnDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDireccion.Icon = CType(resources.GetObject("btnDireccion.Icon"), System.Drawing.Icon)
        Me.btnDireccion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnDireccion.Location = New System.Drawing.Point(587, 21)
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
        Me.LstDomicilio.Size = New System.Drawing.Size(461, 64)
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
        Me.GrpDestinatario.Size = New System.Drawing.Size(683, 79)
        Me.GrpDestinatario.TabIndex = 125
        Me.GrpDestinatario.TabStop = False
        Me.GrpDestinatario.Text = "Destinatario:"
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.TxtRazonSocial.Size = New System.Drawing.Size(544, 19)
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
        Me.TxtNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNota.Location = New System.Drawing.Point(125, 387)
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(545, 89)
        Me.TxtNota.TabIndex = 132
        '
        'Label7
        '
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
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(4, 94)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(115, 15)
        Me.Label28.TabIndex = 129
        Me.Label28.Text = "Zona de Reparto"
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 16
        Me.cmbZonaReparto.Location = New System.Drawing.Point(120, 91)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(261, 24)
        Me.cmbZonaReparto.TabIndex = 128
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
        'FrmEnvio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(695, 534)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDestinatario.ResumeLayout(False)
        Me.GrpDestinatario.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public CTEClave As String
    Public VENClave As String
    Public VentaCerrada As Boolean
    Public ALMClave As String

    Private ENVClave As String

    Private formaEnvio As Integer
    Private Observaciones As String
    Private fechaPrevista As Date = Today.Date
    Private ZonaReparto As Integer
    Private Referencia As String
    Private tipoEntrega As Integer

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

    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False
    Private bError As Boolean = False

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



            dt.Dispose()

            DomicilioClave = DCTEClave



            TxtClave.Text = Clave
            TxtRazonSocial.Text = RazonSocial

            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(Calle & " " & noExterior & " " & noInterior)
            LstDomicilio.Items.Add(Colonia & ", " & codigoPostal)
            LstDomicilio.Items.Add(Mnpio & ", " & Entidad)


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
            cmbZonaReparto.SelectedValue = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", -1, dt.Rows(0)("ZonaReparto"))

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
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "formaEnvio"
            .llenar()
        End With

        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
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



            dt.Dispose()

            CargaDatosDomicilio(DCTEClave)

            DomicilioClave = DCTEClave

            cmbTipoEntrega.SelectedValue = tipoEntrega
            CmbFormaEnvio.SelectedValue = formaEnvio
            cmbZonaReparto.SelectedValue = ZonaReparto
            TxtNota.Text = Observaciones
            dtFechaPrevista.Value = fechaPrevista



            TxtReferencia.Text = Referencia
        Else
            Padre = "Agregar"
            ENVClave = ModPOS.obtenerLlave
        End If

        If Not cmbTipoEntrega.SelectedValue Is Nothing Then
            If cmbTipoEntrega.SelectedValue = 3 Then
                CmbFormaEnvio.Enabled = True
                TxtReferencia.Enabled = True
                cmbZonaReparto.Enabled = False
                cmbZonaReparto.SelectedValue = -1

            ElseIf cmbTipoEntrega.SelectedValue = 2 Then
                CmbFormaEnvio.Enabled = False
                CmbFormaEnvio.SelectedValue = 0
                cmbZonaReparto.Enabled = True
            Else
                cmbZonaReparto.Enabled = False
                cmbZonaReparto.SelectedValue = -1


                TxtReferencia.Enabled = False
                TxtReferencia.Text = ""

                CmbFormaEnvio.Enabled = False
                CmbFormaEnvio.SelectedValue = 0
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
            ElseIf cmbTipoEntrega.SelectedValue = 2 AndAlso cmbZonaReparto.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
            End If
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


                    ModPOS.Ejecuta("sp_inserta_envio", _
                                   "@ENVClave", ENVClave, _
                                   "@VENClave", VENClave, _
                                   "@tipoEntrega", tipoEntrega, _
                                   "@DCTEClave", DCTEClave, _
                                   "@formaEnvio", formaEnvio, _
                                   "@Observaciones", Observaciones, _
                                   "@fechaPrevista", fechaPrevista, _
                                   "@ZonaReparto", ZonaReparto, _
                                   "@Referencia", Referencia, _
                                   "@VentaCerrada", VentaCerrada, _
                                   "@Usuario", ModPOS.UsuarioActual)


                Case "Modificar"
                    If Not (DomicilioClave = DCTEClave AndAlso _
                        formaEnvio = CmbFormaEnvio.SelectedValue AndAlso _
                        Observaciones = TxtNota.Text AndAlso _
                        fechaPrevista = dtFechaPrevista.Value AndAlso _
                        Referencia = TxtReferencia.Text AndAlso _
                        ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue) AndAlso _
                        tipoEntrega = cmbTipoEntrega.SelectedValue) Then

                        DCTEClave = DomicilioClave
                        tipoEntrega = cmbTipoEntrega.SelectedValue
                        formaEnvio = CmbFormaEnvio.SelectedValue
                        Observaciones = TxtNota.Text
                        fechaPrevista = dtFechaPrevista.Value
                        Referencia = TxtReferencia.Text
                        ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue)


                        ModPOS.Ejecuta("sp_modifica_envio", _
                                       "@ENVClave", ENVClave, _
                                       "@tipoEntrega", tipoEntrega, _
                                       "@DCTEClave", DCTEClave, _
                                       "@formaEnvio", formaEnvio, _
                                       "@Observaciones", Observaciones, _
                                       "@fechaPrevista", fechaPrevista, _
                                       "@ZonaReparto", ZonaReparto, _
                                       "@Referencia", Referencia, _
                                       "@VentaCerrada", VentaCerrada, _
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

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClave)

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
                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()

    End Sub




    Private Sub btnDireccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDireccion.Click
        Dim a As New FrmConsulta
        a.Campo = "DCTEClave"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_domiciliocte", "@CTEClave", CTEClave)
        a.GridConsultaGen.RootTable.Columns("DCTEClave").Visible = False
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
        Process.Start("osk.exe")
    End Sub

    Private Sub cmbTipoEntrega_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoEntrega.SelectedValueChanged
        If bload = True AndAlso Not cmbTipoEntrega.SelectedValue Is Nothing Then
            If cmbTipoEntrega.SelectedValue = 3 Then
                CmbFormaEnvio.Enabled = True
                TxtReferencia.Enabled = True
                cmbZonaReparto.Enabled = False
                cmbZonaReparto.SelectedValue = -1

            ElseIf cmbTipoEntrega.SelectedValue = 2 Then
                CmbFormaEnvio.Enabled = False
                CmbFormaEnvio.SelectedValue = 0
                cmbZonaReparto.Enabled = True
                TxtReferencia.Enabled = True
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

   


    
    

End Class
