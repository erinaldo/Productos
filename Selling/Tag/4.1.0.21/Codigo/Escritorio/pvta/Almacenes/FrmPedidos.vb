Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPedidos
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
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents GrpPorSurtir As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridPicking As Janus.Windows.GridEX.GridEX
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSurtir As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnRecortar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedidos))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
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
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.btnRecortar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSurtir = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.GridPicking = New Janus.Windows.GridEX.GridEX()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpPorSurtir.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(716, 521)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 18
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Consulta el Pedido seleccionado"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.BtnElimina.Location = New System.Drawing.Point(16, 16)
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
        'GrpPorSurtir
        '
        Me.GrpPorSurtir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox2)
        Me.GrpPorSurtir.Controls.Add(Me.CmbSucursal)
        Me.GrpPorSurtir.Controls.Add(Me.btnRecortar)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
        Me.GrpPorSurtir.Controls.Add(Me.ChkTodos)
        Me.GrpPorSurtir.Controls.Add(Me.BtnCancelar)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox1)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSurtir)
        Me.GrpPorSurtir.Controls.Add(Me.BtnConsultar)
        Me.GrpPorSurtir.Controls.Add(Me.CmbAlmacen)
        Me.GrpPorSurtir.Controls.Add(Me.Label1)
        Me.GrpPorSurtir.Controls.Add(Me.dtPicker)
        Me.GrpPorSurtir.Controls.Add(Me.BtnRefresh)
        Me.GrpPorSurtir.Controls.Add(Me.GridPicking)
        Me.GrpPorSurtir.Controls.Add(Me.Label2)
        Me.GrpPorSurtir.Controls.Add(Me.Label3)
        Me.GrpPorSurtir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPorSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPorSurtir.ForeColor = System.Drawing.Color.Black
        Me.GrpPorSurtir.Location = New System.Drawing.Point(0, 0)
        Me.GrpPorSurtir.Name = "GrpPorSurtir"
        Me.GrpPorSurtir.Size = New System.Drawing.Size(910, 564)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Pedidos "
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(37, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(74, 17)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 124
        '
        'btnRecortar
        '
        Me.btnRecortar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecortar.Image = Global.Selling.My.Resources.Resources._1433820223_content_cut
        Me.btnRecortar.Location = New System.Drawing.Point(524, 521)
        Me.btnRecortar.Name = "btnRecortar"
        Me.btnRecortar.Size = New System.Drawing.Size(90, 37)
        Me.btnRecortar.TabIndex = 123
        Me.btnRecortar.Text = "&Recortar"
        Me.btnRecortar.ToolTipText = "Realiza la modificacion de pedido"
        Me.btnRecortar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(428, 521)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(10, 45)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(129, 19)
        Me.ChkTodos.TabIndex = 122
        Me.ChkTodos.Text = "Todos"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(620, 521)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 86
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(354, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnSurtir
        '
        Me.BtnSurtir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSurtir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSurtir.Icon = CType(resources.GetObject("BtnSurtir.Icon"), System.Drawing.Icon)
        Me.BtnSurtir.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnSurtir.Location = New System.Drawing.Point(812, 521)
        Me.BtnSurtir.Name = "BtnSurtir"
        Me.BtnSurtir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSurtir.TabIndex = 25
        Me.BtnSurtir.Text = "Surtir"
        Me.BtnSurtir.ToolTipText = "Surtir pedido seleccionado"
        Me.BtnSurtir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(332, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(397, 17)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(656, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(718, 19)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 24
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(616, 17)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPicking
        '
        Me.GridPicking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPicking.ColumnAutoResize = True
        Me.GridPicking.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPicking.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPicking.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPicking.GroupByBoxVisible = False
        Me.GridPicking.Location = New System.Drawing.Point(7, 66)
        Me.GridPicking.Name = "GridPicking"
        Me.GridPicking.RecordNavigator = True
        Me.GridPicking.Size = New System.Drawing.Size(896, 449)
        Me.GridPicking.TabIndex = 4
        Me.GridPicking.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmPedidos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(910, 564)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPedidos"
        Me.Text = "Administración de Pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpPorSurtir.ResumeLayout(False)
        Me.GrpPorSurtir.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ALMClave As String
    ' Private VENClave As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtPicking As DataTable
    Private bload As Boolean = False
    Private Periodo, Mes As Integer
    Private SUCClave As String
    Private Picking, SurtidoRF, MostradorRF As Boolean
    Private FormatoPedido As String

    Private Sub FrmPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Dim dt As DataTable
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        Me.StartPosition = FormStartPosition.CenterScreen


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If


        If Not CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = CmbSucursal.SelectedValue

            dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
            Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
            SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
            MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))

            dt.Dispose()



            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With

        Else
            SUCClave = ""
        End If

        If Not CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = CmbAlmacen.SelectedValue
        Else
            ALMClave = ""
        End If


        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month


        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select CStr(dtParam.Rows(i)("PARClave"))
                    Case "FormatPedido"
                        FormatoPedido = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With

        bload = True


        Me.AgregarFolio()

    End Sub

    Private Function validaExistencia(ByVal VENClave As String, ByVal sFolio As String) As Boolean
        Dim dtVentaDetalle, dtDisponible As DataTable
        Dim Disponible As Double
        Dim result As Boolean = True

        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_cerrada", "@VENClave", VENClave)

        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtVentaDetalle.Rows.Count - 1

                dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", dtVentaDetalle.Rows(i)("PROClave"), "@ALMClave", ALMClave)

                If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                    Disponible = dtDisponible.Rows(0)("Disponible")
                    dtDisponible.Dispose()
                Else
                    Disponible = 0
                End If

                If dtVentaDetalle.Rows(i)("Cantidad") > Disponible Then
                    result = False
                    MessageBox.Show("Pedido: " & sFolio & ", La cantidad registrada del producto " & CStr(dtVentaDetalle.Rows(i)("Clave")) & " excede la cantidad disponible (" & CStr(Disponible) & "), por lo que no es posible cambiar el tipo de documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit For
                Else
                    result = True
                End If
            Next
            dtVentaDetalle.Dispose()
        End If

        Return result

    End Function

    Private Sub actualizaExistencia(ByVal VENClave As String, ByVal Tipo As Integer)
        Dim dtVentaDetalle As DataTable
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_cerrada", "@VENClave", VENClave)
        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtVentaDetalle.Rows.Count - 1
                ModPOS.Ejecuta("sp_actualiza_exist_producto", "@ALMClave", ALMClave, "@PROClave", dtVentaDetalle.Rows(i)("PROClave"), "@TProducto", dtVentaDetalle.Rows(i)("TProducto"), "@Cantidad", dtVentaDetalle.Rows(i)("Cantidad"), "@Mov", Tipo)
            Next
            dtVentaDetalle.Dispose()
        End If
    End Sub

    Private Function recuperaDatosCredito(ByVal Cliente As String) As Double
        Dim dt As DataTable
        Dim CreditoDisponible As Double

        dt = ModPOS.SiExisteRecupera("sp_recupera_credito", "@CTEClave", Cliente)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                CreditoDisponible = dt.Rows(0)("Disponible")
            Else
                CreditoDisponible = 0.0

            End If
            dt.Dispose()
        Else
            CreditoDisponible = 0.0
        End If

        Return CreditoDisponible
    End Function


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If SUCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ALMClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Public Sub AgregarFolio()
        If validaForm() Then

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            dtPicking = ModPOS.Recupera_Tabla("sp_obtener_pedidos", "@ALMClave", ALMClave, "@Periodo", Periodo, "@Mes", Mes)
            GridPicking.DataSource = dtPicking
            GridPicking.RetrieveStructure()
            GridPicking.AutoSizeColumns()
            GridPicking.RootTable.Columns("VENClave").Visible = False
            GridPicking.RootTable.Columns("CTEClave").Visible = False
            GridPicking.RootTable.Columns("USRClave").Visible = False
            GridPicking.RootTable.Columns("CAJClave").Visible = False
            GridPicking.RootTable.Columns("LimiteCredito").Visible = False

            GridPicking.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            If Me.ChkTodos.Checked = True Then
                ChkTodos.Checked = False
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmPedidos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Pedidos.Dispose()
        ModPOS.Pedidos = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedIndexChanged
        If bload = True AndAlso CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = ""
        ElseIf bload = True Then
            ALMClave = CmbAlmacen.SelectedItem(0)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub GridPicking_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPicking.CellEdited
        If GridPicking.CurrentColumn.Caption = "Prioridad" Then
            If Not IsNumeric(GridPicking.GetValue("Prioridad")) Then
                GridPicking.SetValue("Prioridad", 1)
            End If
        End If
    End Sub

    Private Sub GridPicking_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.CurrentCellChanged
        If Not GridPicking.CurrentColumn Is Nothing Then
            If GridPicking.CurrentColumn.Caption = "Marca" OrElse GridPicking.CurrentColumn.Caption = "Prioridad" Then
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    'Private Sub GridPicking_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridPicking.FormattingRow
    '    GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    'End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        AgregarFolio()
    End Sub

    Private Sub GridPicking_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.SelectionChanged
        If Not GridPicking.GetValue(0) Is Nothing Then
            Me.BtnConsultar.Enabled = True
            Me.BtnSurtir.Enabled = True

        Else
            Me.BtnConsultar.Enabled = False
            Me.BtnSurtir.Enabled = False
        End If
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                previewPedido(FormatoPedido, foundRows(i)("VENClave"), foundRows(i)("Total"), SUCClave)
            Next
        Else
            MessageBox.Show("¡Debe Marcar el documento(s) que desea Consultar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub surtirPedido()

        Dim foundRows() As DataRow

        Dim i As Integer
        Dim TipoDocumento As Integer
        Dim dt As DataTable

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then

            Dim formaEnvio As Integer
            Dim fechaPrevista As Date
            Dim ZonaReparto As Integer
            Dim Referencia As String = ""
            Dim tipoEntrega As Integer
            Dim UBCClave As String = ""

            If Picking = True Then
                Dim a As New FrmEnvioMasivo
                a.ALMClave = ALMClave
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()

                If a.DialogResult = DialogResult.OK Then

                    formaEnvio = a.formaEnvio
                    fechaPrevista = a.fechaPrevista
                    ZonaReparto = a.ZonaReparto
                    Referencia = a.Referencia
                    tipoEntrega = a.tipoEntrega
                    UBCClave = a.UBCClave
                Else
                    Exit Sub
                End If
            End If

            Dim dtPicking As DataTable = ModPOS.CrearTabla("Picking", _
                                                 "VENClave", "System.String")

            Dim row1 As DataRow
            Dim valExist As Boolean
            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("VENClave"))
                If dt.Rows.Count > 0 Then

                    If validaExistencia(foundRows(i)("VENClave"), foundRows(i)("Folio")) = False Then
                        If ModPOS.Recorte Is Nothing Then
                            ModPOS.Recorte = New FrmRecorte
                            With ModPOS.Recorte
                                .StartPosition = FormStartPosition.CenterScreen
                                .VENClave = foundRows(i)("VENClave")
                                .ALMClave = Me.ALMClave
                                .SUCClave = Me.SUCClave
                                .FormatoPedido = Me.FormatoPedido
                            End With
                        End If

                        ModPOS.Recorte.StartPosition = FormStartPosition.CenterScreen
                        ModPOS.Recorte.ShowDialog()

                        If validaExistencia(foundRows(i)("VENClave"), foundRows(i)("Folio")) = True Then
                            valExist = True
                        Else
                            valExist = False
                        End If

                    Else
                        valExist = True
                    End If




                    If valExist = True Then

                        If foundRows(i)("LimiteCredito") > 0 Then
                            TipoDocumento = 3
                        Else
                            TipoDocumento = 1
                        End If

                        'Validar Limite de Credito
                        If TipoDocumento = 3 Then
                            Dim CreditoDisponible As Double = recuperaDatosCredito(foundRows(i)("CTEClave"))
                            If CreditoDisponible < foundRows(i)("Total") Then
                                MessageBox.Show("El limite de crédito disponible para el cliente: " & foundRows(i)("Clave") & ", es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(foundRows(i)("Total") - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                                Exit For
                            End If
                        End If


                        'Actualiza Existencia a nivel almacen
                        actualizaExistencia(foundRows(i)("VENClave"), 1)

                        ModPOS.Ejecuta("st_recalcula_imp_venta", "@VENClave", foundRows(i)("VENClave"))

                        ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                                    "@VENClave", foundRows(i)("VENClave"), _
                                    "@Cliente", foundRows(i)("CTEClave"), _
                                    "@Tipo", TipoDocumento, _
                                    "@Cajero", foundRows(i)("USRClave"), _
                                    "@CAJClave", foundRows(i)("CAJClave"), _
                                    "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", foundRows(i)("VENClave"))


                        If Picking = True Then


                            ModPOS.Ejecuta("st_inserta_envio", _
                          "@VENClave", foundRows(i)("VENClave"), _
                          "@Prioridad", foundRows(i)("Prioridad"), _
                          "@tipoEntrega", tipoEntrega, _
                          "@CTEClave", foundRows(i)("CTEClave"), _
                          "@formaEnvio", formaEnvio, _
                          "@fechaPrevista", fechaPrevista, _
                          "@ZonaReparto", ZonaReparto, _
                          "@Referencia", Referencia, _
                          "@UBCClave", UBCClave, _
                          "@Usuario", ModPOS.UsuarioActual)

                            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", foundRows(i)("VENClave"), "@Estado", 7)

                            ModPOS.calculaRecoleccion(1, foundRows(i)("VENClave"), ALMClave, UBCClave, IIf(SurtidoRF = True, 1, 0))

                            ' ModPOS.ImprimirSurtido(1, foundRows(i)("VENClave"), False)

                            row1 = dtPicking.NewRow()
                            row1.Item("VENClave") = foundRows(i)("VENClave")
                            dtPicking.Rows.Add(row1)

                        Else
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Total"))

                            ModPOS.GeneraMovInv(2, 1, 1, foundRows(i)("VENClave"), ALMClave, foundRows(i)("Folio"), Nothing)
                        End If

                    End If
                    dt.Dispose()
                End If
            Next

            If dtPicking.Rows.Count > 0 Then
                If MessageBox.Show("¿Desea imprimir?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    Dim dtCompania As DataTable

                    'Recupera información del Emisor

                    dtCompania = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                    ' define el tamaño de la etiqueta
                    Dim lsPickingLabels As New PickingPrinting.PickingSet(New System.Drawing.Printing.PaperSize("Carta", ModPOS.Redondear(21.59 * 100 * 0.3937, 0), ModPOS.Redondear(27.94 * 100 * 0.3937, 0)), _
                                                                           True, _
                                                                           ModPOS.Redondear(13.87 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(21.39 * 100 * 0.3937, 0), _
                                                                           2, _
                                                                           ModPOS.Redondear(0 * 100 * 0.3937, 0), _
                                                                           1, _
                                                                           ModPOS.Redondear(0 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0.1 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0.1 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0.1 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0.1 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0 * 100 * 0.3937, 0), _
                                                                           ModPOS.Redondear(0 * 100 * 0.3937, 0), _
                                                                          ModPOS.Redondear(0 * 100 * 0.3937, 0))

                    lsPickingLabels.PickingFontBold = New Font("Arial", 9, FontStyle.Bold)
                    lsPickingLabels.PickingFont = New Font("Arial", 7, FontStyle.Regular)


                    For i = 0 To dtPicking.Rows.Count - 1

                        ' Create label objects... 

                        Dim lblPickingLabel As New PickingPrinting.PickingSheet()

                        lblPickingLabel.AddPicking(dtPicking.Rows(i)("VENClave"))
                        lblPickingLabel.AddCompania(dtCompania)
                        lsPickingLabels.AddPickingSheet(lblPickingLabel)

                    Next



                    ' Create a PrintDialog to allow the user to choose a printer:

                    PrintDialog1.Document = lsPickingLabels
                    PrintDialog1.AllowSomePages = True

                    ' Offer the user a preview, or print directly to paper:

                    If PrintDialog1.ShowDialog() = DialogResult.OK Then
                        PrintDialog1.Document.Print()
                    End If


                    dtCompania.Dispose()


                End If
            End If


            AgregarFolio()

        End If



    End Sub

    Private Sub BtnSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSurtir.Click
        surtirPedido()
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtPicking.Rows.Count > 0 Then
            Dim i As Integer

            If ChkTodos.Checked Then
                For i = 0 To GridPicking.GetDataRows.Length - 1
                    GridPicking.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridPicking.GetDataRows.Length - 1
                    GridPicking.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            GridPicking.Refresh()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim dTotal As Double = IIf(dtPicking.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(Total)", "Marca = True"))

            Select Case MessageBox.Show("¿Esta seguro de Cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = dTotal
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim Autoriza As String = a.Autoriza
                            Dim i As Integer
                            Dim bmotivo As Boolean = False
                            Dim motCancelacion As Integer = -1

                            Do
                                Dim m As New FrmMotivo
                                m.Tabla = "Venta"
                                m.Campo = "Cancelacion"
                                m.ShowDialog()
                                If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    bmotivo = True
                                    motCancelacion = m.Motivo
                                End If
                                m.Dispose()
                            Loop While bmotivo = False

                            For i = 0 To foundRows.GetUpperBound(0)

                                ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("VENClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento(s) que desea Cancelar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub



    Private Sub btnRecortar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecortar.Click
        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True'")


        If foundRows.GetLength(0) = 1 Then

            If ModPOS.Recorte Is Nothing Then
                ModPOS.Recorte = New FrmRecorte
                With ModPOS.Recorte
                    .StartPosition = FormStartPosition.CenterScreen
                    .VENClave = foundRows(0)("VENClave")
                    .ALMClave = Me.ALMClave
                    .SUCClave = Me.SUCClave
                    .FormatoPedido = Me.FormatoPedido
                End With
            End If

            ModPOS.Recorte.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Recorte.Show()
            ModPOS.Recorte.BringToFront()

        Else
            MessageBox.Show("¡Debe Marcar el documento que desee recortar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Sub

    
    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bload = True AndAlso CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = ""

        ElseIf bload = True Then
            SUCClave = CmbSucursal.SelectedValue
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
            Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))

            SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
            MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))


            dt.Dispose()
            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        End If
    End Sub
End Class
