Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSurtido
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
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLiberar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnAuditoria As Janus.Windows.EditControls.UIButton
    Friend WithEvents bthPicking As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSurtido))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.bthPicking = New Janus.Windows.EditControls.UIButton()
        Me.BtnAuditoria = New Janus.Windows.EditControls.UIButton()
        Me.txtFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnLiberar = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSurtir = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.GridPicking = New Janus.Windows.GridEX.GridEX()
        Me.GrpPorSurtir.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 60000
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(784, 568)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 18
        Me.BtnReimpresion.Text = "Imprimir"
        Me.BtnReimpresion.ToolTipText = "Reimpresión de documento seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GrpPorSurtir
        '
        Me.GrpPorSurtir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPorSurtir.Controls.Add(Me.BtnConsultar)
        Me.GrpPorSurtir.Controls.Add(Me.bthPicking)
        Me.GrpPorSurtir.Controls.Add(Me.BtnAuditoria)
        Me.GrpPorSurtir.Controls.Add(Me.txtFinal)
        Me.GrpPorSurtir.Controls.Add(Me.Label6)
        Me.GrpPorSurtir.Controls.Add(Me.Label5)
        Me.GrpPorSurtir.Controls.Add(Me.TxtInicial)
        Me.GrpPorSurtir.Controls.Add(Me.Label4)
        Me.GrpPorSurtir.Controls.Add(Me.dtFinal)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox2)
        Me.GrpPorSurtir.Controls.Add(Me.Label2)
        Me.GrpPorSurtir.Controls.Add(Me.CmbAlmacen)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
        Me.GrpPorSurtir.Controls.Add(Me.btnLiberar)
        Me.GrpPorSurtir.Controls.Add(Me.ChkTodos)
        Me.GrpPorSurtir.Controls.Add(Me.BtnCancelar)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox1)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSurtir)
        Me.GrpPorSurtir.Controls.Add(Me.Label3)
        Me.GrpPorSurtir.Controls.Add(Me.BtnReimpresion)
        Me.GrpPorSurtir.Controls.Add(Me.CmbSucursal)
        Me.GrpPorSurtir.Controls.Add(Me.Label1)
        Me.GrpPorSurtir.Controls.Add(Me.dtPicker)
        Me.GrpPorSurtir.Controls.Add(Me.BtnRefresh)
        Me.GrpPorSurtir.Controls.Add(Me.GridPicking)
        Me.GrpPorSurtir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPorSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPorSurtir.ForeColor = System.Drawing.Color.Black
        Me.GrpPorSurtir.Location = New System.Drawing.Point(0, 0)
        Me.GrpPorSurtir.Name = "GrpPorSurtir"
        Me.GrpPorSurtir.Size = New System.Drawing.Size(976, 611)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Pedidos por Surtir"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(594, 568)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 134
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Reimpresión de documento seleccionado"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'bthPicking
        '
        Me.bthPicking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bthPicking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bthPicking.Icon = CType(resources.GetObject("bthPicking.Icon"), System.Drawing.Icon)
        Me.bthPicking.Location = New System.Drawing.Point(688, 568)
        Me.bthPicking.Name = "bthPicking"
        Me.bthPicking.Size = New System.Drawing.Size(90, 37)
        Me.bthPicking.TabIndex = 133
        Me.bthPicking.Text = "Picking"
        Me.bthPicking.ToolTipText = "Cambia el estado a los documentos no iniciados para que esten disponibles para pi" & _
    "cking"
        Me.bthPicking.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAuditoria
        '
        Me.BtnAuditoria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAuditoria.Icon = CType(resources.GetObject("BtnAuditoria.Icon"), System.Drawing.Icon)
        Me.BtnAuditoria.Location = New System.Drawing.Point(402, 568)
        Me.BtnAuditoria.Name = "BtnAuditoria"
        Me.BtnAuditoria.Size = New System.Drawing.Size(90, 37)
        Me.BtnAuditoria.TabIndex = 132
        Me.BtnAuditoria.Text = "Auditoria"
        Me.BtnAuditoria.ToolTipText = "Consulta de auditoria de pedidos o ventas"
        Me.BtnAuditoria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtFinal
        '
        Me.txtFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFinal.Location = New System.Drawing.Point(878, 41)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.Size = New System.Drawing.Size(92, 22)
        Me.txtFinal.TabIndex = 131
        Me.txtFinal.Text = "99"
        Me.txtFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFinal.Value = 99
        Me.txtFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(853, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 16)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "al"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(686, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Prioridad"
        '
        'TxtInicial
        '
        Me.TxtInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtInicial.Location = New System.Drawing.Point(755, 41)
        Me.TxtInicial.Name = "TxtInicial"
        Me.TxtInicial.Size = New System.Drawing.Size(92, 22)
        Me.TxtInicial.TabIndex = 128
        Me.TxtInicial.Text = "0"
        Me.TxtInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtInicial.Value = 0
        Me.TxtInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(853, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "al"
        '
        'dtFinal
        '
        Me.dtFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtFinal.CustomFormat = "MMMM yyyy"
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(878, 16)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.ShowUpDown = True
        Me.dtFinal.Size = New System.Drawing.Size(92, 22)
        Me.dtFinal.TabIndex = 126
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(377, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 125
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(342, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(416, 14)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 123
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(306, 568)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnLiberar
        '
        Me.btnLiberar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLiberar.Icon = CType(resources.GetObject("btnLiberar.Icon"), System.Drawing.Icon)
        Me.btnLiberar.Location = New System.Drawing.Point(688, 568)
        Me.btnLiberar.Name = "btnLiberar"
        Me.btnLiberar.Size = New System.Drawing.Size(90, 37)
        Me.btnLiberar.TabIndex = 87
        Me.btnLiberar.Text = "&Liberar"
        Me.btnLiberar.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recolección"
        Me.btnLiberar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.BtnCancelar.Location = New System.Drawing.Point(498, 568)
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
        Me.PictureBox1.Location = New System.Drawing.Point(53, 19)
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
        Me.BtnSurtir.Location = New System.Drawing.Point(880, 568)
        Me.BtnSurtir.Name = "BtnSurtir"
        Me.BtnSurtir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSurtir.TabIndex = 25
        Me.BtnSurtir.Text = "Surtir"
        Me.BtnSurtir.ToolTipText = "Surtir pedido seleccionado"
        Me.BtnSurtir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(84, 14)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(686, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker.Location = New System.Drawing.Point(755, 16)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(92, 22)
        Me.dtPicker.TabIndex = 24
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(633, 14)
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
        Me.GridPicking.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridPicking.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPicking.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPicking.GroupByBoxVisible = False
        Me.GridPicking.Location = New System.Drawing.Point(10, 70)
        Me.GridPicking.Name = "GridPicking"
        Me.GridPicking.RecordNavigator = True
        Me.GridPicking.Size = New System.Drawing.Size(960, 492)
        Me.GridPicking.TabIndex = 4
        Me.GridPicking.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmSurtido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 611)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "FrmSurtido"
        Me.Text = "Surtido de Pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPorSurtir.ResumeLayout(False)
        Me.GrpPorSurtir.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Private VENClave As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtPicking As DataTable
    Private bload As Boolean = False
    Private PIN, PFN As Integer
    Private Inicio, Fin As Date
    Private SUCClave As String
    Private ALMClave As String
    Private SurtidoRF As Boolean
    Private MostradorRF As Boolean
    Private FormatoPedido As String
    Private InterfazSalida As String
    Private ticketPicking As Boolean
    Private TIKClave As String


    Public Sub AgregarFolio()
        If validaForm() Then
            Me.Clock.Stop()
            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            dtPicking = ModPOS.Recupera_Tabla("sp_obtener_picking", "@COMClave", ModPOS.CompanyActual, "@ALMClave", ALMClave, "@Inicio", Inicio, "@Fin", Fin.AddHours(23.9999), "@PIN", PIN, "@PFN", PFN, "@SurtidoRF", SurtidoRF, "@MostradorRF", MostradorRF)
            GridPicking.DataSource = dtPicking
            GridPicking.RetrieveStructure()
            GridPicking.AutoSizeColumns()
            GridPicking.RootTable.Columns("iTipo").Visible = False
            GridPicking.RootTable.Columns("DOCClave").Visible = False
            GridPicking.RootTable.Columns("CTEClave").Visible = False
            GridPicking.RootTable.Columns("iEstado").Visible = False
            GridPicking.RootTable.Columns("PICClave").Visible = False
            GridPicking.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridPicking.RootTable.Columns("Saldo").Visible = False
            GridPicking.RootTable.Columns("SaldoBase").Visible = False
            GridPicking.RootTable.Columns("RFC").Visible = False
            GridPicking.RootTable.Columns("EdoSurtido").Visible = False
            GridPicking.RootTable.Columns("Movilidad").Visible = False
            Me.GridPicking.HorizontalScroll.Enabled = True

            If Me.ChkTodos.Checked = True Then
                ChkTodos.Checked = False
            End If

            Clock.Start()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmSurtido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        dtPicker.Value = Today.Date
        dtFinal.Value = Today.Date

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2



        Me.StartPosition = FormStartPosition.CenterScreen



        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        For i = 0 To dt.Rows.Count - 1
            Select Case CStr(dt.Rows(i)("PARClave"))
                Case "InterfazSalida"
                    InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                Case "FormatPedido"
                    FormatoPedido = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dt.Rows(i)("Valor"))

            End Select
        Next
        dt.Dispose()


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
            SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
            MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))

            ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
            TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))

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

        Inicio = dtPicker.Value
        Fin = dtFinal.Value

        PIN = CInt(TxtInicial.Text)
        PFN = CInt(txtFinal.Text)

        bload = True


        Me.AgregarFolio()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If SUCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If



        If ALMClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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

    Private Sub FrmSurtido_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Surtido.Dispose()
        ModPOS.Surtido = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Inicio <> dtPicker.Value) Then
            If dtPicker.Value > Fin Then
                dtPicker.Value = Fin
            End If

            Inicio = dtPicker.Value

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub GridPicking_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.CurrentCellChanged
        If Not GridPicking.CurrentColumn Is Nothing Then
            If GridPicking.CurrentColumn.Caption = "Marca" Then
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        AgregarFolio()
    End Sub

    Private Sub GridPicking_DoubleClick(sender As Object, e As EventArgs) Handles GridPicking.DoubleClick
        BtnConsultar.PerformClick()
    End Sub

    Private Sub GridPicking_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.SelectionChanged
        If Not GridPicking.GetValue(0) Is Nothing Then
            Me.BtnReimpresion.Enabled = True
            Me.BtnSurtir.Enabled = True
            bthPicking.Enabled = True
            btnLiberar.Enabled = True
            BtnConsultar.Enabled = True
            If GridPicking.GetValue("Movilidad") = 1 Then
                Me.bthPicking.Visible = True
                btnLiberar.Visible = False
            Else
                Me.bthPicking.Visible = False
                btnLiberar.Visible = True
            End If

        Else
            Me.BtnReimpresion.Enabled = False
            Me.BtnSurtir.Enabled = False
            bthPicking.Enabled = False
            btnLiberar.Enabled = False
            BtnConsultar.Enabled = False
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.ImprimirSurtido(foundRows(i)("iTipo"), foundRows(i)("DOCClave"), True, True)
                Next
            End If
        End If
    End Sub

    Private Sub modificaSurtido()

        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado= 6)")

        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que No se encuentran disponibles para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim i As Integer

        Dim dt As DataTable
        Dim sDoctos As String = ""

        Dim Procesar As Integer = 0

        foundRows = dtPicking.Select("Marca ='True' and EdoSurtido=3 and Movilidad=1")

        If foundRows.GetLength(0) > 0 Then

            Procesar = foundRows.GetLength(0)
            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("PICClave").GetType.Name <> "DBNull" OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                        MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra en proceso de recolección será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        If sDoctos = "" Then
                            sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        Else
                            sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        End If

                    End If
                End If
                dt.Dispose()
            Next
        End If

        foundRows = dtPicking.Select("Marca ='True' and Movilidad=0")

        If foundRows.GetLength(0) > 0 Then
            Procesar += foundRows.GetLength(0)
            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("PICClave").GetType.Name <> "DBNull" OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                        MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra en proceso de recolección será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        Ejecuta("st_act_transito", "@TipoDocumento", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))

                        If sDoctos = "" Then
                            sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        Else
                            sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        End If

                    End If
                End If
                dt.Dispose()
            Next
        End If

        If Procesar > 0 Then
            If ModPOS.Picking Is Nothing Then
                ModPOS.Picking = New FrmPicking
                With ModPOS.Picking
                    .StartPosition = FormStartPosition.CenterScreen
                    .Documentos = sDoctos
                    .ALMClave = Me.ALMClave
                    .SUCClave = Me.SUCClave
                    .FormatoPedido = Me.FormatoPedido
                    .InterfazSalida = Me.InterfazSalida
                    .ticketPicking = ticketPicking
                    .TIKClave = TIKClave

                End With
            End If

            ModPOS.Picking.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Picking.Show()
            ModPOS.Picking.BringToFront()

        Else
            MessageBox.Show("¡No fue posible procesar algun documento. Debe de marcar los documentos a procesar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSurtir.Click
        modificaSurtido()
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

            dtPicking.AcceptChanges()

            GridPicking.Refresh()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and Total <> Saldo")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser Cancelados debido a que tienen un abono asociado")
            Exit Sub
        End If


        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado=6)")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser Cancelados debido a que se encuentran en Proceso de Recolección o Picking")
            Exit Sub
        End If

        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Ha seleccionado una sucursal invalida o es requerida")
            Exit Sub
        End If

        foundRows = dtPicking.Select("Marca ='True' and EdoSurtido <=1 ")

        If foundRows.GetLength(0) > 0 Then

            Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(SaldoBase)", "Marca = True"))

            Select Case MessageBox.Show("¿Esta seguro de Cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then


                        If a.Autorizado Then
                            Dim Autoriza As String = a.Autoriza
                            Dim i As Integer
                            Dim dt As DataTable

                            For i = 0 To foundRows.GetUpperBound(0)
                                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                                If dt.Rows.Count > 0 Then
                                    If dt.Rows(0)("PICClave").GetType.Name <> "DBNull" Then
                                        MessageBox.Show("El documento " & foundRows(i)("Surtido") & " se encuentra en proceso de recolección será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Else
                                        If foundRows(i)("iTipo") = 1 Then

                                            If dt.Rows(0)("Estado") = 4 Then
                                                MessageBox.Show("Error al cancelar el documento " & foundRows(i)("Surtido") & ", ya se encuentra cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                AgregarFolio()
                                                Exit Sub
                                            End If

                                            Dim bmotivo As Boolean
                                            Dim motCancelacion As Integer

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


                                            ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", Autoriza)
                                            ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                                            If foundRows(i)("iEstado") = 2 Then
                                                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("SaldoBase"))
                                            End If

                                        ElseIf foundRows(i)("iTipo") = 8 Then
                                            ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@USRClave", ModPOS.UsuarioActual)
                                        ElseIf foundRows(i)("iTipo") = 6 Then
                                            ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                        ElseIf foundRows(i)("iTipo") = 10 Then
                                            ModPOS.Ejecuta("st_cancela_devcompra", "@DEVClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                        End If

                                        ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)

                                    End If
                                End If
                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe marcar solo registros en estado Picking o que no hayan iniciado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 7 or iEstado=5)")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser liberados debido a que no se encuentran en Proceso")
            Exit Sub
        End If

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_ip", "@Tipo", foundRows(0)("iTipo"), "@DOCClave", foundRows(0)("DOCClave"))

            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("IP") <> IPAddress Then
                    MessageBox.Show("No es posible liberar el documento seleccionado ya que se encuentra abierto en un equipo diferente (" & dt.Rows(0)("IP") & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt.Dispose()
                    Exit Sub
                End If
            End If
            dt.Dispose()

            Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(Saldo)", "Marca = True"))

            Select Case MessageBox.Show("¿Esta seguro de Liberar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim Autoriza As String = a.Autoriza
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)

                                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                                If dt.Rows.Count > 0 Then
                                    If dt.Rows(0)("EdoSurtido") = 5 Then
                                        MessageBox.Show("El docuemnto " & foundRows(i)("Surtido") & " ya se encuentra surtido por lo que sera removido del proceso actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Else
                                        'Liberar Pedido
                                        ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", foundRows(i)("iTipo"), "@PICClave", Nothing, "@DOCClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)

                                        If foundRows(i)("iTipo") = 1 Then
                                            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", foundRows(i)("DOCClave"), "@Estado", 7)
                                        ElseIf foundRows(i)("iTipo") = 8 Then
                                            ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@Estado", 5)
                                        ElseIf foundRows(i)("iTipo") = 6 Then
                                            ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", foundRows(i)("DOCClave"), "@Estado", 5)
                                        ElseIf foundRows(i)("iTipo") = 10 Then
                                            ModPOS.Ejecuta("st_actualiza_estado_devcompra", "@DEVClave", foundRows(i)("DOCClave"), "@Estado", 5)

                                        End If
                                    End If
                                   
                                End If
                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento que desea Liberar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bload = True AndAlso CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = ""

        ElseIf bload = True Then
            SUCClave = CmbSucursal.SelectedValue
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

            SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
            MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))

            ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
            TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))


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

    Private Sub dtFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtFinal.ValueChanged
        If bload = True AndAlso (Fin <> dtFinal.Value) Then
            If dtFinal.Value < Inicio Then
                dtFinal.Value = Inicio
            End If

            Fin = dtFinal.Value

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub TxtInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtInicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFinal.Focus()
        End If
    End Sub

    Private Sub TxtInicial_Leave(sender As Object, e As EventArgs) Handles TxtInicial.Leave
        If bload = True AndAlso (PIN <> Math.Abs(CInt(TxtInicial.Text))) Then
            If Math.Abs(CInt(TxtInicial.Text)) > PFN Then
                TxtInicial.Text = PFN
            End If

            PIN = Math.Abs(CInt(TxtInicial.Text))

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub txtFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridPicking.Focus()
        End If

    End Sub

    Private Sub txtFinal_Leave(sender As Object, e As EventArgs) Handles txtFinal.Leave
        If bload = True AndAlso (PIN <> Math.Abs(CInt(txtFinal.Text))) Then
            If Math.Abs(CInt(txtFinal.Text)) < PIN Then
                txtFinal.Text = PIN
            End If

            PFN = Math.Abs(CInt(txtFinal.Text))

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub


    Private Sub BtnAuditoria_Click(sender As Object, e As EventArgs) Handles BtnAuditoria.Click
        Dim a As New FrmAuditoria
        a.SUCClave = SUCClave
        a.FormatoPedido = Me.formatoPedido
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim b As New FrmConsultaGen
            b.Text = "Auditoría de Pedidos/Ventas"
            ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_muestra_auditoria", "@VENClave", a.valor)
            b.ShowDialog()
            b.Dispose()
        End If
        a.Dispose()

    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bload = True AndAlso CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = ""
        ElseIf bload = True Then
            ALMClave = CmbAlmacen.SelectedValue
        End If
    End Sub

    Private Sub bthPicking_Click(sender As Object, e As EventArgs) Handles bthPicking.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and EdoSurtido = 0")
        If foundRows.GetLength(0) = 0 Then
            MessageBox.Show("Solo debe seleccionar documentos que no hayan sido iniciados previamente")
            Exit Sub
        End If
        ModPOS.Ejecuta("st_act_edo_surtido", "@Tipo", foundRows(0)("iTipo"), "@DOCClave", foundRows(0)("DOCClave"), "@Estado", 1, "@Usuario", ModPOS.UsuarioActual)
        Me.AgregarFolio()


    End Sub

    Public Sub ImprimirPicking(ByVal sDocumento As String, ByVal iTipo As Integer)
        Dim sError As String = ""


        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Solicitando Información...")
        'Recupera impresoras por area de surtido

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_surtidodetalle", "@AREClave", "", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_envio", "@Tipo", iTipo, "@DOCClave", sDocumento))
        If iTipo = 1 Then
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento", "@VENClave", sDocumento))
        End If

        pvtaDataSet.DataSetName = "pvtaDataSet"

        Try
            OpenReport.PrintPreview("Hoja de Recolección", "CRSurtidoDetalle.rpt", pvtaDataSet, "Consulta")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sError = ex.Message

        End Try




        frmStatusMessage.Dispose()

    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        If Not GridPicking.DataSource Is Nothing Then
            If Not GridPicking.GetValue(0) Is Nothing Then


                ImprimirPicking(GridPicking.GetValue("DOCClave"), GridPicking.GetValue("iTipo"))

            End If

        Else
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        BtnRefresh.PerformClick()
    End Sub
End Class
