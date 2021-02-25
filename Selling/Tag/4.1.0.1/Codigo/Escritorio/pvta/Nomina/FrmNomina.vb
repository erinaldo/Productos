Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmNomina
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
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnRecibo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTimbrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabGeneral As Janus.Windows.UI.Tab.UITabPage
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
    Friend WithEvents GrpRecibos As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblTot As System.Windows.Forms.Label
    Friend WithEvents GridRecibos As Janus.Windows.GridEX.GridEX
    Friend WithEvents mcPeriodo As System.Windows.Forms.MonthCalendar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtNumNomina As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNumDiasPagados As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents dtFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEditarRecibo As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoNomina As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNomina))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpRecibos = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblTot = New System.Windows.Forms.Label()
        Me.GridRecibos = New Janus.Windows.GridEX.GridEX()
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
        Me.BtnTimbrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnRecibo = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.mcPeriodo = New System.Windows.Forms.MonthCalendar()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtNumNomina = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNumDiasPagados = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.dtFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnEditarRecibo = New Janus.Windows.EditControls.UIButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.cmbTipoNomina = New Selling.StoreCombo()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        Me.GrpRecibos.SuspendLayout()
        CType(Me.GridRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Icon = CType(resources.GetObject("BtnImprimir.Icon"), System.Drawing.Icon)
        Me.BtnImprimir.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnImprimir.Location = New System.Drawing.Point(3, 141)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnImprimir.TabIndex = 18
        Me.BtnImprimir.Text = "Imprimir Recibo"
        Me.BtnImprimir.ToolTipText = "Imprime los recibos seleccionados"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Location = New System.Drawing.Point(2, 184)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(793, 332)
        Me.UiTab1.TabIndex = 21
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.GrpRecibos)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(791, 310)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "General"
        '
        'GrpRecibos
        '
        Me.GrpRecibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRecibos.BackColor = System.Drawing.Color.Transparent
        Me.GrpRecibos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpRecibos.Controls.Add(Me.LblTotal)
        Me.GrpRecibos.Controls.Add(Me.LblTot)
        Me.GrpRecibos.Controls.Add(Me.GridRecibos)
        Me.GrpRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpRecibos.ForeColor = System.Drawing.Color.Black
        Me.GrpRecibos.Location = New System.Drawing.Point(2, 3)
        Me.GrpRecibos.Name = "GrpRecibos"
        Me.GrpRecibos.Size = New System.Drawing.Size(787, 304)
        Me.GrpRecibos.TabIndex = 2
        Me.GrpRecibos.TabStop = False
        Me.GrpRecibos.Text = "Recibos"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 14)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(135, 19)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(603, 280)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(177, 18)
        Me.LblTotal.TabIndex = 48
        Me.LblTotal.Text = "0.00"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTot
        '
        Me.LblTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTot.ForeColor = System.Drawing.Color.Black
        Me.LblTot.Location = New System.Drawing.Point(555, 283)
        Me.LblTot.Name = "LblTot"
        Me.LblTot.Size = New System.Drawing.Size(43, 17)
        Me.LblTot.TabIndex = 47
        Me.LblTot.Text = "TOTAL"
        '
        'GridRecibos
        '
        Me.GridRecibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRecibos.ColumnAutoResize = True
        Me.GridRecibos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRecibos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRecibos.GroupByBoxVisible = False
        Me.GridRecibos.Location = New System.Drawing.Point(7, 35)
        Me.GridRecibos.Name = "GridRecibos"
        Me.GridRecibos.RecordNavigator = True
        Me.GridRecibos.Size = New System.Drawing.Size(773, 240)
        Me.GridRecibos.TabIndex = 4
        Me.GridRecibos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'BtnTimbrar
        '
        Me.BtnTimbrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTimbrar.Icon = CType(resources.GetObject("BtnTimbrar.Icon"), System.Drawing.Icon)
        Me.BtnTimbrar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnTimbrar.Location = New System.Drawing.Point(97, 141)
        Me.BtnTimbrar.Name = "BtnTimbrar"
        Me.BtnTimbrar.Size = New System.Drawing.Size(90, 37)
        Me.BtnTimbrar.TabIndex = 4
        Me.BtnTimbrar.Text = "Timbrar Recibos"
        Me.BtnTimbrar.ToolTipText = "Timbra los Recibos Seleccionados"
        Me.BtnTimbrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRecibo
        '
        Me.BtnRecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecibo.Icon = CType(resources.GetObject("BtnRecibo.Icon"), System.Drawing.Icon)
        Me.BtnRecibo.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnRecibo.Location = New System.Drawing.Point(285, 141)
        Me.BtnRecibo.Name = "BtnRecibo"
        Me.BtnRecibo.Size = New System.Drawing.Size(90, 37)
        Me.BtnRecibo.TabIndex = 3
        Me.BtnRecibo.Text = "Recibo Nómina"
        Me.BtnRecibo.ToolTipText = "Crear nuevo recibo de nómina"
        Me.BtnRecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnCancelar.Location = New System.Drawing.Point(191, 141)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cancelar Recibos"
        Me.BtnCancelar.ToolTipText = "Cancela los recibos seleccionados"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'mcPeriodo
        '
        Me.mcPeriodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcPeriodo.Enabled = False
        Me.mcPeriodo.Location = New System.Drawing.Point(547, 6)
        Me.mcPeriodo.MaxSelectionCount = 31
        Me.mcPeriodo.Name = "mcPeriodo"
        Me.mcPeriodo.TabIndex = 22
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 5)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(76, 15)
        Me.LblClave.TabIndex = 106
        Me.LblClave.Text = "Num. Nómina"
        '
        'TxtNumNomina
        '
        Me.TxtNumNomina.Location = New System.Drawing.Point(116, 5)
        Me.TxtNumNomina.Name = "TxtNumNomina"
        Me.TxtNumNomina.Size = New System.Drawing.Size(118, 20)
        Me.TxtNumNomina.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Dias de Pagados"
        '
        'TxtNumDiasPagados
        '
        Me.TxtNumDiasPagados.Location = New System.Drawing.Point(116, 34)
        Me.TxtNumDiasPagados.Name = "TxtNumDiasPagados"
        Me.TxtNumDiasPagados.Size = New System.Drawing.Size(118, 20)
        Me.TxtNumDiasPagados.TabIndex = 108
        Me.TxtNumDiasPagados.Text = "0"
        Me.TxtNumDiasPagados.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtNumDiasPagados.Value = 0
        Me.TxtNumDiasPagados.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'dtFechaInicial
        '
        Me.dtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInicial.Location = New System.Drawing.Point(347, 5)
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Size = New System.Drawing.Size(119, 20)
        Me.dtFechaInicial.TabIndex = 110
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFinal.Location = New System.Drawing.Point(347, 36)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(119, 20)
        Me.dtFechaFinal.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(252, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "F. Inicial"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(252, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "F. Final"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(704, 522)
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
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(608, 522)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 118
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(323, 39)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(18, 24)
        Me.PictureBox4.TabIndex = 116
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(323, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(18, 24)
        Me.PictureBox3.TabIndex = 115
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(77, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(28, 17)
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnEditarRecibo
        '
        Me.BtnEditarRecibo.Icon = CType(resources.GetObject("BtnEditarRecibo.Icon"), System.Drawing.Icon)
        Me.BtnEditarRecibo.Location = New System.Drawing.Point(379, 141)
        Me.BtnEditarRecibo.Name = "BtnEditarRecibo"
        Me.BtnEditarRecibo.Size = New System.Drawing.Size(90, 37)
        Me.BtnEditarRecibo.TabIndex = 120
        Me.BtnEditarRecibo.Text = "Modificar Recibo"
        Me.BtnEditarRecibo.ToolTipText = "Modificar datos del Recibo"
        Me.BtnEditarRecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Sucursal"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(59, 66)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(27, 17)
        Me.PictureBox5.TabIndex = 123
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.ItemHeight = 13
        Me.CmbSucursal.Location = New System.Drawing.Point(116, 62)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(350, 21)
        Me.CmbSucursal.TabIndex = 121
        '
        'cmbTipoNomina
        '
        Me.cmbTipoNomina.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoNomina.Location = New System.Drawing.Point(116, 89)
        Me.cmbTipoNomina.Name = "cmbTipoNomina"
        Me.cmbTipoNomina.Size = New System.Drawing.Size(350, 21)
        Me.cmbTipoNomina.TabIndex = 124
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(83, 93)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(27, 17)
        Me.PictureBox6.TabIndex = 127
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Tipo Nomina"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(86, 37)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 17)
        Me.PictureBox2.TabIndex = 130
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmNomina
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(798, 564)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbTipoNomina)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.BtnEditarRecibo)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtFechaFinal)
        Me.Controls.Add(Me.dtFechaInicial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNumDiasPagados)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtNumNomina)
        Me.Controls.Add(Me.mcPeriodo)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnImprimir)
        Me.Controls.Add(Me.BtnTimbrar)
        Me.Controls.Add(Me.BtnRecibo)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmNomina"
        Me.Text = "Nómina"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabGeneral.ResumeLayout(False)
        Me.GrpRecibos.ResumeLayout(False)
        CType(Me.GridRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public NOMClave As String = ""
    Public NumNomina As String = ""
    Public fechaInicial As Date = Today.Date
    Public fechaFinal As Date = Today.Date
    Public numDias As Integer = 0
    Public tipoEstado As Integer = 2
    Public SUCClave As String = ""
    Public eRFC As String = ""
    Public TipoNomina As String = "O"
    Public Padre As String

    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private dTotal As Double
    Private bload As Boolean = False
    Private guardado As Boolean = False

    Private dtParam, dtPAC, dtRecibos, dtPendientes As DataTable

    Public VersionNomina As Integer
    Private VersionCF As String

    Private ServidorCancelacion As String
    Private Customerkey As String
    Private sPendienteSelected As String
    Private PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private Moneda, eRegimenFiscal As String

    Private noCertificado, Certificado64, ContrasenaClave, LlaveFile As String

    Private Periodo, Mes As Integer


    Private Sub FrmNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_all_sucursal"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.cmbTipoNomina
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorSAT"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Nomina"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoNomina"
            .llenar()
        End With

        If Padre = "Agregar" Then
            BtnTimbrar.Enabled = False
            BtnImprimir.Enabled = False
            BtnCancelar.Enabled = False
            BtnRecibo.Enabled = False
            BtnEditarRecibo.Enabled = False

        Else
            Me.CmbSucursal.Enabled = False
        End If

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6


        Me.TxtNumNomina.Text = NumNomina
        Me.TxtNumDiasPagados.Text = numDias
        dtFechaInicial.Value = fechaInicial
        dtFechaFinal.Value = fechaFinal
        mcPeriodo.SelectionStart = dtFechaInicial.Value
        mcPeriodo.SelectionEnd = dtFechaFinal.Value
        Periodo = mcPeriodo.TodayDate.Year
        Mes = mcPeriodo.TodayDate.Month
        CmbSucursal.SelectedValue = SUCClave

        cmbTipoNomina.SelectedValue = TipoNomina

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)

        Dim i As Integer

        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "RegimenFiscal"
                        Dim dtmsg As DataTable
                        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", CInt(dtParam.Rows(i)("Valor")))
                        eRegimenFiscal = dtmsg.Rows(0)("ClaveSAT")
                        dtmsg.Dispose()
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "VersionCF"

                        Dim dtmsg As DataTable = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "VersionNomina"
                        If Padre <> "Modificar" Then
                            VersionNomina = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 1, dtParam.Rows(i)("Valor"))
                        End If
                End Select
            Next
        End With
        dtParam.Dispose()



        Me.actualizaGridRecibos()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.TxtNumNomina.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNumDiasPagados.Text <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.dtFechaFinal.Value > dtFechaFinal.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.dtFechaFinal.Value < dtFechaFinal.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipoNomina.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
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

    Private Sub FrmNomina_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoNomina Is Nothing Then
            If guardado = True Then
                ModPOS.MtoNomina.actualizaGrid()
            End If
        End If

        ModPOS.Nomina.Dispose()
        ModPOS.Nomina = Nothing
    End Sub

    Public Sub actualizaGridRecibos()
        Cursor.Current = Cursors.WaitCursor
        dtRecibos = ModPOS.Recupera_Tabla("sp_muestra_recibonomina", "@NOMClave", NOMClave)
        GridRecibos.DataSource = dtRecibos
        GridRecibos.RetrieveStructure(True)
        GridRecibos.RootTable.Columns("RENClave").Visible = False
        GridRecibos.RootTable.Columns("EMPClave").Visible = False
        GridRecibos.RootTable.Columns("TipoCambio").Visible = False
        GridRecibos.RootTable.Columns("Moneda").Visible = False


        GridRecibos.RootTable.Columns("Marca").Width = 5
        GridRecibos.RootTable.Columns("NumEmpleado").Width = 5
        GridRecibos.RootTable.Columns("NombreCompleto").Width = 50
        GridRecibos.RootTable.Columns("Folio").Width = 10
        GridRecibos.RootTable.Columns("FechaPago").Width = 12
        GridRecibos.RootTable.Columns("uuid").Width = 12
        GridRecibos.RootTable.Columns("Percepciones").Width = 9
        GridRecibos.RootTable.Columns("Deducciones").Width = 9
        GridRecibos.RootTable.Columns("OtrosPagos").Width = 9
        GridRecibos.RootTable.Columns("Total").Width = 10
        GridRecibos.RootTable.Columns("Estado").Width = 9


        GridRecibos.RootTable.Columns("NumEmpleado").Selectable = False
        GridRecibos.RootTable.Columns("NombreCompleto").Selectable = False
        GridRecibos.RootTable.Columns("Folio").Selectable = False
        GridRecibos.RootTable.Columns("FechaPago").Selectable = False
        GridRecibos.RootTable.Columns("uuid").Selectable = False
        GridRecibos.RootTable.Columns("Percepciones").Selectable = False
        GridRecibos.RootTable.Columns("Deducciones").Selectable = False
        GridRecibos.RootTable.Columns("Total").Selectable = False
        GridRecibos.RootTable.Columns("Estado").Selectable = False


        GridRecibos.RootTable.Columns("Percepciones").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridRecibos.RootTable.Columns("Deducciones").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridRecibos.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridRecibos.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelado")

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridRecibos.RootTable.FormatConditions.Add(fc)

        Dim TotalNomina As Double
        Dim ft As Janus.Windows.GridEX.GridEXFilterCondition
        Dim col As Janus.Windows.GridEX.GridEXColumn

        col = Me.GridRecibos.RootTable.Columns("Estado")
        ft = New Janus.Windows.GridEX.GridEXFilterCondition(col, Janus.Windows.GridEX.ConditionOperator.NotEqual, "Cancelado")


        TotalNomina = GridRecibos.GetTotal(GridRecibos.CurrentTable.Columns("Total"), Janus.Windows.GridEX.AggregateFunction.Sum, ft)
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalNomina, 2)), "Currency")
        Cursor.Current = Cursors.Default


    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtRecibos.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridRecibos.GetDataRows.Length - 1
                    GridRecibos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridRecibos.GetDataRows.Length - 1
                    GridRecibos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

        End If

    End Sub

    Private Sub dtFechaInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaInicial.Leave
        If dtFechaInicial.Value > dtFechaFinal.Value Then
            Beep()
            MessageBox.Show("La fecha inicial de pago no puede ser mayor a la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            mcPeriodo.SelectionStart = dtFechaInicial.Value
            mcPeriodo.SelectionEnd = dtFechaFinal.Value
        End If
    End Sub

    Private Sub dtFechaFinal_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaFinal.Leave
        If dtFechaInicial.Value > dtFechaFinal.Value Then
            Beep()
            MessageBox.Show("La fecha final de pago no puede ser menor a la fecha inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            mcPeriodo.SelectionStart = dtFechaInicial.Value
            mcPeriodo.SelectionEnd = dtFechaFinal.Value
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    NOMClave = ModPOS.obtenerLlave
                    NumNomina = TxtNumNomina.Text
                    numDias = TxtNumDiasPagados.Text
                    fechaInicial = dtFechaInicial.Value
                    fechaFinal = dtFechaFinal.Value
                    SUCClave = CmbSucursal.SelectedValue
                    TipoNomina = cmbTipoNomina.SelectedValue
                    

                    ModPOS.Ejecuta("sp_inserta_nomina", _
                    "@NOMClave", NOMClave, _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@NumNomina", NumNomina, _
                    "@FechaInicial", fechaInicial, _
                    "@FechaFinal", fechaFinal, _
                    "@NumDias", numDias, _
                    "@TipoEstado", 1, _
                    "@SUCClave", SUCClave, _
                    "@TipoNomina", TipoNomina, _
                    "@VersionNomina", VersionNomina, _
                    "@Usuario", ModPOS.UsuarioActual)

                    guardado = True

                    BtnTimbrar.Enabled = True
                    BtnImprimir.Enabled = True
                    BtnCancelar.Enabled = True
                    BtnRecibo.Enabled = True
                    BtnEditarRecibo.Enabled = True

                    Padre = "Modificar"

                Case "Modificar"

                    If Not ( _
                    NumNomina = TxtNumNomina.Text AndAlso _
                    numDias = TxtNumDiasPagados.Text AndAlso _
                    fechaInicial = dtFechaInicial.Value AndAlso _
                    SUCClave = CmbSucursal.SelectedValue AndAlso _
                     TipoNomina = cmbTipoNomina.SelectedValue AndAlso _
                    fechaFinal = dtFechaFinal.Value) Then

                        NumNomina = TxtNumNomina.Text
                        numDias = TxtNumDiasPagados.Text
                        fechaInicial = dtFechaInicial.Value
                        fechaFinal = dtFechaFinal.Value
                        SUCClave = CmbSucursal.SelectedValue
                        TipoNomina = cmbTipoNomina.SelectedValue
                        guardado = True

                        ModPOS.Ejecuta("sp_actualiza_nomina", _
                       "@NOMClave", NOMClave, _
                       "@NumNomina", NumNomina, _
                       "@FechaInicial", fechaInicial, _
                       "@FechaFinal", fechaFinal, _
                       "@NumDias", numDias, _
                       "@TipoEstado", tipoEstado, _
                       "@SUCClave", SUCClave, _
                       "@TipoNomina", TipoNomina, _
                       "@Usuario", ModPOS.UsuarioActual)

                    End If

                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnRecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecibo.Click

        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una Sucursal para identificar el lugar de expedición de la nómina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ModPOS.ReciboNomina Is Nothing Then
            ModPOS.ReciboNomina = New FrmReciboNomina
            With ModPOS.ReciboNomina
                .Text = "Agregar Recibo de Nómina"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .VersionCF = VersionCF
                .NOMClave = NOMClave
                .SUCClave = CmbSucursal.SelectedValue
                .regimenFiscal = eRegimenFiscal
                .versionnomina = VersionNomina
            End With
        End If
        ModPOS.ReciboNomina.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ReciboNomina.Show()
        If Not ModPOS.ReciboNomina Is Nothing Then
            ModPOS.ReciboNomina.BringToFront()
        End If
    End Sub

    Private Sub BtnTimbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimbrar.Click

        Dim dt As DataTable
        Dim bFallo As Boolean = False

        If Not dtRecibos Is Nothing Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If


            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                noCertificado = dt.Rows(0)("Serie")
                Certificado64 = dt.Rows(0)("Certificado")
                LlaveFile = dt.Rows(0)("Llave")
                ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(LlaveFile) Then
                    MessageBox.Show("El archivo " & LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try


            Dim i As Integer

            Dim foundRows() As DataRow
            foundRows = dtRecibos.Select("Marca=True and Estado='Pendiente'")

            If foundRows.GetLength(0) > 0 Then

                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se Timbraran todos los recibos marcados que se encuentren pendientes, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim frmStatusMessage As New frmStatus

                        frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales...")

                        Dim oCFD As New eCFD

                      

                        'Asigna información de certificado vigente

                        oCFD.noCertificado = noCertificado
                        oCFD.LlaveFile = LlaveFile
                        oCFD.ContrasenaClave = ContrasenaClave
                        oCFD.Certificado64 = Certificado64

                        'Verifica que exista el path
                        Try
                            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
                            End If
                        Catch ex As Exception
                        End Try

                        Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(oCFD.LlaveFile)

                        If Not System.IO.File.Exists(DirSello) Then
                            If System.IO.File.Exists(oCFD.LlaveFile) Then
                                System.IO.File.Copy(oCFD.LlaveFile, DirSello)
                            Else
                                MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If

                        Dim dir As String
                        Dim DirArchivoPEM As String = DirSello & ".pem"

                        dir = "C:\OpenSSL\bin\openssl.exe"

                        Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


                        Dim dtConcepto, dtImpuesto As DataTable


                        'carga datos de nomina 
                        dt = ModPOS.Recupera_Tabla("sp_recupera_nomina", "@NOMClave", NOMClave)
                        oCFD.FechaInicialPago = dt.Rows(0)("FechaInicialPago")
                        oCFD.FechaFinalPago = dt.Rows(0)("FechaFinalPago")
                        oCFD.NumDiasPagados = dt.Rows(0)("NumDiasPagados")
                        oCFD.TipoNomina = IIf(dt.Rows(0)("TipoNomina").GetType.Name = "DBNull", "O", dt.Rows(0)("TipoNomina"))
                        dt.Dispose()

                        'Recupera información del Emisor

                        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
                        oCFD.eRFC = dt.Rows(0)("id_Fiscal")
                        oCFD.ePais = dt.Rows(0)("Pais")
                        oCFD.eEntidad = dt.Rows(0)("Estado")
                        oCFD.eMnpio = dt.Rows(0)("Municipio")
                        oCFD.eColonia = dt.Rows(0)("Colonia")
                        oCFD.eCalle = dt.Rows(0)("Calle")
                        oCFD.eCodigoPostal = dt.Rows(0)("CodigoPostal")
                        oCFD.eReferencia = dt.Rows(0)("Referencia")
                        oCFD.eLocalidad = dt.Rows(0)("Localidad")
                        oCFD.enoExterior = dt.Rows(0)("noExterior")
                        oCFD.enoInterior = dt.Rows(0)("noInterior")
                        oCFD.RegistroPatronal = IIf(dt.Rows(0)("registroPatronal").GetType.Name = "DBNull", "", dt.Rows(0)("registroPatronal"))
                        oCFD.RiesgoPuesto = IIf(dt.Rows(0)("RiesgoPuesto").GetType.Name = "DBNull", 0, dt.Rows(0)("RiesgoPuesto"))
                        oCFD.eCURP = IIf(dt.Rows(0)("CURP").GetType.Name = "DBNull", "", dt.Rows(0)("CURP"))
                        dt.Dispose()


                        If oCFD.eReferencia = "" Then
                            oCFD.eReferencia = "SIN REFERENCIA"
                        End If

                        If oCFD.enoInterior <> "" Then
                            oCFD.benoInterior = True
                        Else
                            oCFD.benoInterior = False
                        End If

                        dt.Dispose()

                        'Recupera Información del Centro de Expedición


                        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

                        oCFD.iTipoSucursal = dt.Rows(0)("Tipo")
                        oCFD.sPais = dt.Rows(0)("Pais")
                        oCFD.sEntidad = dt.Rows(0)("Entidad")
                        oCFD.sMnpio = dt.Rows(0)("Municipio")
                        oCFD.sColonia = dt.Rows(0)("Colonia")
                        oCFD.sCalle = dt.Rows(0)("Calle")
                        oCFD.sCodigoPostal = dt.Rows(0)("CodigoPostal")
                        oCFD.sReferencia = dt.Rows(0)("Referencia")
                        oCFD.sLocalidad = dt.Rows(0)("Localidad")
                        oCFD.snoExterior = dt.Rows(0)("noExterior")
                        oCFD.snoInterior = dt.Rows(0)("noInterior")
                        dt.Dispose()

                        If oCFD.sReferencia = "" Then
                            oCFD.sReferencia = "SIN REFERENCIA"
                        End If

                        If oCFD.snoInterior <> "" Then
                            oCFD.bsnoInterior = True
                        Else
                            oCFD.bsnoInterior = False
                        End If

                        oCFD.LugarExpedicion = oCFD.sCalle & " " & oCFD.snoExterior & IIf(oCFD.bsnoInterior, " INT " & oCFD.snoInterior, "") & "," & oCFD.sMnpio & "," & oCFD.sEntidad

                        dt.Dispose()

                        For i = 0 To foundRows.GetUpperBound(0)

                            frmStatusMessage.Show("Generando Recibo " & CStr(i + 1) & "/" & CStr(foundRows.GetUpperBound(0) + 1))
                            'Carga datos Receptor

                            dt = ModPOS.Recupera_Tabla("st_recupera_empleado_sat", "@EMPClave", foundRows(i)("EMPClave"), "@FechaFinalPago", oCFD.FechaFinalPago)

                            oCFD.EMPClave = dt.Rows(0)("EMPClave")
                            oCFD.NumEmpleado = dt.Rows(0)("NumEmpleado")
                            oCFD.RazonSocial = dt.Rows(0)("NombreCompleto")
                            oCFD.RFC = dt.Rows(0)("id_Fiscal")
                            oCFD.NumSeguridadSocial = dt.Rows(0)("NumSeguridadSocial")
                            oCFD.CURP = dt.Rows(0)("CURP")
                            oCFD.TipoRegimen = IIf(dt.Rows(0)("TipoRegimen").GetType.Name = "DBNull", "", dt.Rows(0)("TipoRegimen"))
                            oCFD.Departamento = dt.Rows(0)("Departamento")
                            oCFD.Puesto = dt.Rows(0)("Puesto")
                            'oCFD.CLABE = dt.Rows(0)("CLABE")
                            oCFD.Banco = IIf(dt.Rows(0)("TipoBanco").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoBanco"))
                            oCFD.FechaInicioRelLaboral = String.Format("{0:yyyy-MM-dd}", dt.Rows(0)("FechaInicioRelLaboral"))
                            oCFD.SalarioBaseCotApor = dt.Rows(0)("SalarioBaseCotAport")
                            oCFD.SalarioDiarioIntegrado = dt.Rows(0)("SalarioDiarioIntegrado")
                            oCFD.Sindicalizado = IIf(dt.Rows(0)("Sindicalizado").GetType.Name = "DBNull", 0, dt.Rows(0)("Sindicalizado"))
                            oCFD.Pais = dt.Rows(0)("Pais")
                            oCFD.Entidad = dt.Rows(0)("Entidad")
                            oCFD.Mnpio = dt.Rows(0)("Municipio")
                            oCFD.Colonia = dt.Rows(0)("Colonia")
                            oCFD.Calle = dt.Rows(0)("Calle")
                            oCFD.noExterior = dt.Rows(0)("noExterior")
                            oCFD.noInterior = dt.Rows(0)("noInterior")
                            oCFD.codigoPostal = dt.Rows(0)("codigoPostal")
                            oCFD.ClaveEntFed = dt.Rows(0)("ClaveEntFed")
                            'oCFD.Contacto = dt.Rows(0)("Contacto")
                            'oCFD.Tel1 = dt.Rows(0)("Tel1")
                            'oCFD.Tel2 = dt.Rows(0)("Tel2")
                            'oCFD.email = dt.Rows(0)("Email")
                            oCFD.Antiguedad = dt.Rows(0)("Antiguedad")
                            oCFD.TipoJornada = dt.Rows(0)("TipoJornada")
                            oCFD.TipoContrato = dt.Rows(0)("TipoContrato")
                            oCFD.PeriodicidadPago = dt.Rows(0)("PeriodicidadPago")

                            If oCFD.noInterior <> "" Then
                                oCFD.brnoInterior = True
                            Else
                                oCFD.brnoInterior = False
                            End If

                            dt.Dispose()

                            If oCFD.TipoRegimen = "" Then
                                MessageBox.Show("El Empleado " & oCFD.NumEmpleado & " no cuenta con Regimen Fiscal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If oCFD.ClaveEntFed = "" Then
                                MessageBox.Show("El Empleado no cuenta con Clave de Entidad donde Lobora ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            'Fin receptor


                            'Carga datos Recibo

                            dt = ModPOS.Recupera_Tabla("st_recupera_reciboNomina_sat", "@RENClave", foundRows(i)("RENClave"))

                            oCFD.TipoCF = dt.Rows(0)("TipoCF")
                            oCFD.tipoDeComprobante = "ReciboNomina"
                            oCFD.VersionCF = dt.Rows(0)("VersionCF")
                            oCFD.regimenFiscal = dt.Rows(0)("RegimenFiscal")
                            oCFD.Serie = dt.Rows(0)("Serie")
                            oCFD.Folio = dt.Rows(0)("Folio")
                            oCFD.formaDePago = dt.Rows(0)("formaDePago")
                            oCFD.Fecha = Today.Date

                            
                                oCFD.Moneda = "MXN"
                            
                            oCFD.TipoCambio = dt.Rows(0)("TipoCambio")
                            oCFD.metodoDePago = dt.Rows(0)("MetodoPago")
                            oCFD.Banco = dt.Rows(0)("TipoBanco")
                            oCFD.NumCtaPago = dt.Rows(0)("Referencia")

                            oCFD.FechaPago = dt.Rows(0)("FechaPago")

                            oCFD.TotalGravadoP = dt.Rows(0)("TotalGravadoPercepciones")
                            oCFD.TotalExentoP = dt.Rows(0)("TotalExentoPercepciones")

                            oCFD.TotalDeducciones = dt.Rows(0)("TotalDeducciones")
                            oCFD.TotalOtrosPagos = dt.Rows(0)("TotalOtrosPagos")

                            oCFD.total = dt.Rows(0)("TotalNetoPagar")

                            oCFD.TotalHorasExtra = dt.Rows(0)("TotalHorasExtra")
                            oCFD.TotalIncapacidades = dt.Rows(0)("TotalIncapacidades")
                            oCFD.TotalSueldos = IIf(dt.Rows(0)("TotalSueldos").GetType.Name = "DBNull", 0, dt.Rows(0)("TotalSueldos"))
                            oCFD.TotalSeparacion = IIf(dt.Rows(0)("TotalSeparacion").GetType.Name = "DBNull", 0, dt.Rows(0)("TotalSeparacion"))
                            oCFD.TotalJubilacion = IIf(dt.Rows(0)("TotalJubilacion").GetType.Name = "DBNull", 0, dt.Rows(0)("TotalJubilacion"))

                            oCFD.VersionNomina = IIf(dt.Rows(0)("VersionNomina").GetType.Name = "DBNull", 1, dt.Rows(0)("VersionNomina"))
                            dt.Dispose()




                            dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 0, "@Clave", foundRows(i)("RENClave"))
                            dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 0, "@Clave", foundRows(i)("RENClave"))

                            Dim ISR As Double = 0
                            If dtImpuesto.Rows.Count > 0 Then
                                ISR = dtImpuesto.Rows(0)("Importe")
                            End If
                            oCFD.ISR = ISR

                            oCFD.subtotal = oCFD.TotalGravadoP + oCFD.TotalExentoP + oCFD.TotalOtrosPagos
                            oCFD.descuento = oCFD.TotalDeducciones
                            oCFD.total = oCFD.subtotal - oCFD.TotalDeducciones

                            oCFD.RENClave = foundRows(i)("RENClave")

                            If oCFD.TipoNomina = "E" Then
                                oCFD.PeriodicidadPago = "99"
                            End If

                            oCFD.cadenaOriginal = generarCadenaOriginalNomina(oCFD, dtConcepto, dtImpuesto, VersionNomina)

                            If VersionNomina = 1 Then
                                oCFD.cadenaOriginal &= generaCadenaOriginalComplemento(oCFD, dtConcepto, dtImpuesto)
                            ElseIf VersionNomina = 2 Then
                                oCFD.cadenaOriginal &= "|"
                            End If


                            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)

                            If oCFD.sello Is Nothing OrElse oCFD.sello = "" Then
                                frmStatusMessage.Close()

                                frmStatusMessage.Dispose()
                                Exit Sub
                            End If

                            Dim iPac As Integer

                            iPac = ModPOS.crearXMLNomina(dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.RENClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, oCFD.VersionNomina)

                            If iPac = 0 Then
                                bFallo = True
                            End If

                            dtConcepto.Dispose()
                            dtImpuesto.Dispose()
                        Next
                        frmStatusMessage.Close()
                        frmStatusMessage.Dispose()
                End Select
                Cursor.Current = Cursors.Default

                If bFallo = False Then
                    MessageBox.Show("Se regeneraron todos los comprobantes correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Se regeneraron algunos errores en los comprobantes", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Me.actualizaGridRecibos()
                Me.ChkMarcaTodos.Checked = False
            Else
                MessageBox.Show("¡Debe marcar por lo menos un registro en estado Pendiente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub BtnEditarRecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditarRecibo.Click
        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una Sucursal para identificar el lugar de expedición de la nómina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not GridRecibos.GetValue("RENClave") Is Nothing Then
            If ModPOS.ReciboNomina Is Nothing Then
                ModPOS.ReciboNomina = New FrmReciboNomina
                With ModPOS.ReciboNomina
                    .Text = "Editar Recibo de Nómina"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .NumEmpleado = GridRecibos.GetValue("NumEmpleado")
                    .RENClave = GridRecibos.GetValue("RENClave")
                    .NOMClave = NOMClave
                    .SUCClave = CmbSucursal.SelectedValue
                    .regimenFiscal = eRegimenFiscal
                    .TxtNumEmpleado.Enabled = False
                    .BtnBuscaEmp.Enabled = False
                    .BtnNuevo.Enabled = False
                    .VersionNomina = VersionNomina
                    If GridRecibos.GetValue("Estado") <> "Pendiente" Then
                        .BtnGuardar.Enabled = False
                        .BtnEliminar.Enabled = False
                        .BtnConcepto.Enabled = False
                        .BtnAbrir.Enabled = False
                    End If

                End With
            End If
            ModPOS.ReciboNomina.StartPosition = FormStartPosition.CenterScreen
            ModPOS.ReciboNomina.Show()
            ModPOS.ReciboNomina.BringToFront()
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtRecibos Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtRecibos.Select("Marca ='True'")

            If foundRows.GetLength(0) = 1 Then

                If foundRows(0)("Estado") = "Cancelado" Then
                    MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque ya se encuentra cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                

                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim Autoriza As String
                        Dim a As New MeAutorizacion
                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = foundRows(0)("Total")
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then
                                Autoriza = a.Autoriza
                                If foundRows(0)("Estado") = "Pendiente" Then 'Sin timbrar

                                    ModPOS.Ejecuta("sp_cancela_reciboNomina", "@RENClave", foundRows(0)("RENClave"), "@Usuario", ModPOS.UsuarioActual)

                                ElseIf foundRows(0)("Estado") = "Activo" Then 'Timbrado


                                    dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                                    If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                                        MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Me.Close()
                                    End If

                                    If ModPOS.cancelarXML(dtPAC, foundRows(0)("Folio"), foundRows(0)("uuid"), eRFC, foundRows(0)("VersionCF")) = False Then
                                        Exit Sub
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_reciboNomina", "@RENClave", foundRows(0)("RENClave"), "@Usuario", ModPOS.UsuarioActual)

                                End If
                            End If
                            Me.actualizaGridRecibos()
                        End If
                        a.Dispose()
                End Select

            Else
                MessageBox.Show("Debe marcar solo el documento que desea cancelar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        If Not dtRecibos Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtRecibos.Select("Marca=True and Estado = 'Activo'")
            If foundRows.GetLength(0) > 0 Then
                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se imprimiran todos los recibos Activos que se encuentren marcados , esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim frmStatusMessage As New frmStatus
                        Dim i As Integer
                        Dim sImpresora As String
                        Dim iCopias As Integer
                        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                            iCopias = PrintDialog1.PrinterSettings.Copies
                        Else
                            Exit Sub
                        End If

                        For i = 0 To foundRows.GetUpperBound(0)
                            frmStatusMessage.Show("Imprimiendo Recibo " & CStr(i + 1) & "/" & CStr(foundRows.GetUpperBound(0) + 1))

                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_reciboNomina", "@RENClave", foundRows(i)("RENClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_percepciones", "@RENClave", foundRows(i)("RENClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_deducciones", "@RENClave", foundRows(i)("RENClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", foundRows(i)("RENClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", foundRows(i)("RENClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_empleadoREC", "@RENClave", foundRows(i)("RENClave")))


                            OpenReport.Print(iCopias, "CRReciboNomina.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / foundRows(i)("TipoCambio"), 2), foundRows(i)("Moneda"), foundRows(i)("MonedaRef")).ToUpper, sImpresora)

                        Next

                        frmStatusMessage.Close()
                        frmStatusMessage.Dispose()

                End Select
                Cursor.Current = Cursors.Default
                Me.actualizaGridRecibos()
                Me.ChkMarcaTodos.Checked = False
            Else
                MessageBox.Show("¡Debe marcar por lo menos un registro en estado Activo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub GridRecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridRecibos.DoubleClick
        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una Sucursal para identificar el lugar de expedición de la nómina", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If ModPOS.ReciboNomina Is Nothing Then
            ModPOS.ReciboNomina = New FrmReciboNomina
            With ModPOS.ReciboNomina
                .Text = "Editar Recibo de Nómina"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .NumEmpleado = GridRecibos.GetValue("NumEmpleado")
                .RENClave = GridRecibos.GetValue("RENClave")
                .NOMClave = NOMClave
                .SUCClave = CmbSucursal.SelectedValue
                .regimenFiscal = eRegimenFiscal
                .TxtNumEmpleado.Enabled = False
                .BtnBuscaEmp.Enabled = False
                .BtnNuevo.Enabled = False

                If GridRecibos.GetValue("Estado") <> "Pendiente" Then
                    .BtnGuardar.Enabled = False
                    .BtnEliminar.Enabled = False
                    .BtnConcepto.Enabled = False
                    .BtnAbrir.Enabled = False
                End If

            End With
        End If
        ModPOS.ReciboNomina.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ReciboNomina.Show()
        ModPOS.ReciboNomina.BringToFront()

    End Sub
End Class
