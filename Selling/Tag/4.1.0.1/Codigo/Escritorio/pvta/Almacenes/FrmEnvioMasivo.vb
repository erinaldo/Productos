
Public Class FrmEnvioMasivo
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
    Friend WithEvents dtFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaEnvio As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
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
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvioMasivo))
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
        Me.dtFechaPrevista = New System.Windows.Forms.DateTimePicker()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmbZonaReparto = New Selling.StoreCombo()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnStage = New Janus.Windows.EditControls.UIButton()
        Me.TxtStage = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoEntrega = New Selling.StoreCombo()
        Me.CmbFormaEnvio = New Selling.StoreCombo()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'dtFechaPrevista
        '
        Me.dtFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaPrevista.Location = New System.Drawing.Point(128, 75)
        Me.dtFechaPrevista.Name = "dtFechaPrevista"
        Me.dtFechaPrevista.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaPrevista.TabIndex = 110
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(310, 209)
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
        Me.btnSalir.Location = New System.Drawing.Point(212, 209)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar Envio"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(104, 144)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 15)
        Me.PictureBox3.TabIndex = 142
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 13
        Me.cmbZonaReparto.Location = New System.Drawing.Point(127, 140)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(261, 21)
        Me.cmbZonaReparto.TabIndex = 128
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(17, 143)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(108, 15)
        Me.Label28.TabIndex = 129
        Me.Label28.Text = "Zona de Reparto"
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
        Me.Label12.Location = New System.Drawing.Point(15, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 15)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Forma de Envío"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(15, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Fecha Prevista"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtReferencia.Location = New System.Drawing.Point(128, 107)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(260, 21)
        Me.TxtReferencia.TabIndex = 129
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(17, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 17)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Referencia"
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
        Me.BtnStage.Location = New System.Drawing.Point(353, 173)
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
        Me.TxtStage.Location = New System.Drawing.Point(128, 173)
        Me.TxtStage.Name = "TxtStage"
        Me.TxtStage.ReadOnly = True
        Me.TxtStage.Size = New System.Drawing.Size(209, 21)
        Me.TxtStage.TabIndex = 149
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 15)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Ubicación de Entrega"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(127, 444)
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
        Me.cmbTipoEntrega.Size = New System.Drawing.Size(261, 21)
        Me.cmbTipoEntrega.TabIndex = 139
        '
        'CmbFormaEnvio
        '
        Me.CmbFormaEnvio.Location = New System.Drawing.Point(128, 42)
        Me.CmbFormaEnvio.Name = "CmbFormaEnvio"
        Me.CmbFormaEnvio.Size = New System.Drawing.Size(260, 21)
        Me.CmbFormaEnvio.TabIndex = 125
        Me.CmbFormaEnvio.Text = " "
        '
        'FrmEnvioMasivo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(406, 252)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cmbZonaReparto)
        Me.Controls.Add(Me.BtnStage)
        Me.Controls.Add(Me.TxtStage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbTipoEntrega)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CmbFormaEnvio)
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
        Me.Name = "FrmEnvioMasivo"
        Me.Text = "Detalle de Entrega "
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public ALMClave As String
    Public formaEnvio As Integer
    Public fechaPrevista As Date = Today.Date.AddDays(1)
    Public ZonaReparto As Integer
    Public Referencia As String
    Public tipoEntrega As Integer
    Public UBCClave As String
    Private oUBCClave As String


    Private alerta(3) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False
    Private bError As Boolean = False

    Private Sub FrmEnvio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

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






        oUBCClave = ""
        If Not CmbFormaEnvio.SelectedValue Is Nothing Then

            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_obtener_stage", "@ALMClave", ALMClave, "@FormaEnvio", CmbFormaEnvio.SelectedValue)

            If dt.Rows.Count > 0 Then
                UBCClave = dt.Rows(0)("UBCClave")
                Me.TxtStage.Text = dt.Rows(0)("Ubicacion")
            Else
                UBCClave = ""
                TxtStage.Text = ""
            End If
            dt.Dispose()
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
        If validaForm() Then

            If dtFechaPrevista.Value < Today Then
                bError = True
                Beep()
                MessageBox.Show("La fecha prevista de entrega no puede ser menor a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

                    tipoEntrega = cmbTipoEntrega.SelectedValue
                    formaEnvio = CmbFormaEnvio.SelectedValue
                    fechaPrevista = dtFechaPrevista.Value
                    ZonaReparto = IIf(cmbZonaReparto.SelectedValue Is Nothing, -1, cmbZonaReparto.SelectedValue)
                    Referencia = TxtReferencia.Text
                    oUBCClave = UBCClave


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

   
    Private Sub cmbTipoEntrega_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoEntrega.SelectedValueChanged
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

    Private Sub BtnStage_Click(sender As Object, e As EventArgs) Handles BtnStage.Click
        Dim a As New FrmConsulta
        a.Campo = "UBCClave"
        a.Campo2 = "Stage"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_stage", "@ALMClave", ALMClave)
        a.GridConsultaGen.RootTable.Columns("UBCClave").Visible = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ID <> "" Then
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
End Class
