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
    Friend WithEvents btnPicking As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnGuia As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnMesa As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPedido As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkCerrados As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkTransito As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSurtido))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox()
        Me.chkTransito = New System.Windows.Forms.CheckBox()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkCerrados = New System.Windows.Forms.CheckBox()
        Me.btnPedido = New Janus.Windows.EditControls.UIButton()
        Me.btnGuia = New Janus.Windows.EditControls.UIButton()
        Me.btnMesa = New Janus.Windows.EditControls.UIButton()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.btnPicking = New Janus.Windows.EditControls.UIButton()
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
        Me.BtnReimpresion.Location = New System.Drawing.Point(796, 568)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(85, 37)
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
        Me.GrpPorSurtir.Controls.Add(Me.chkTransito)
        Me.GrpPorSurtir.Controls.Add(Me.TxtFolio)
        Me.GrpPorSurtir.Controls.Add(Me.Label7)
        Me.GrpPorSurtir.Controls.Add(Me.chkCerrados)
        Me.GrpPorSurtir.Controls.Add(Me.btnPedido)
        Me.GrpPorSurtir.Controls.Add(Me.btnGuia)
        Me.GrpPorSurtir.Controls.Add(Me.btnMesa)
        Me.GrpPorSurtir.Controls.Add(Me.BtnConsultar)
        Me.GrpPorSurtir.Controls.Add(Me.btnPicking)
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
        'chkTransito
        '
        Me.chkTransito.Location = New System.Drawing.Point(319, 46)
        Me.chkTransito.Name = "chkTransito"
        Me.chkTransito.Size = New System.Drawing.Size(183, 19)
        Me.chkTransito.TabIndex = 141
        Me.chkTransito.Text = "Ver  pedidos en Transito"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(135, 42)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(178, 21)
        Me.TxtFolio.TabIndex = 139
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(81, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 18)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "Folio"
        '
        'chkCerrados
        '
        Me.chkCerrados.Location = New System.Drawing.Point(508, 45)
        Me.chkCerrados.Name = "chkCerrados"
        Me.chkCerrados.Size = New System.Drawing.Size(162, 19)
        Me.chkCerrados.TabIndex = 138
        Me.chkCerrados.Text = "Ver  pedidos Surtidos"
        '
        'btnPedido
        '
        Me.btnPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPedido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPedido.Icon = CType(resources.GetObject("btnPedido.Icon"), System.Drawing.Icon)
        Me.btnPedido.Location = New System.Drawing.Point(617, 568)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(85, 37)
        Me.btnPedido.TabIndex = 137
        Me.btnPedido.Text = "Editar"
        Me.btnPedido.ToolTipText = "Modificar Pedido Confirmado o Cerrado"
        Me.btnPedido.Visible = False
        Me.btnPedido.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnGuia
        '
        Me.btnGuia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuia.Icon = CType(resources.GetObject("btnGuia.Icon"), System.Drawing.Icon)
        Me.btnGuia.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnGuia.Location = New System.Drawing.Point(437, 568)
        Me.btnGuia.Name = "btnGuia"
        Me.btnGuia.Size = New System.Drawing.Size(85, 37)
        Me.btnGuia.TabIndex = 136
        Me.btnGuia.Text = "Guias"
        Me.btnGuia.ToolTipText = "Asignar guias de paqueteria"
        Me.btnGuia.Visible = False
        Me.btnGuia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnMesa
        '
        Me.btnMesa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMesa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMesa.Image = Global.Selling.My.Resources.Resources.iconfinder_table_83022
        Me.btnMesa.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnMesa.Location = New System.Drawing.Point(527, 568)
        Me.btnMesa.Name = "btnMesa"
        Me.btnMesa.Size = New System.Drawing.Size(85, 37)
        Me.btnMesa.TabIndex = 135
        Me.btnMesa.Text = "Mesa"
        Me.btnMesa.ToolTipText = "Asignar mesa de empaque"
        Me.btnMesa.Visible = False
        Me.btnMesa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(98, 568)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(52, 37)
        Me.BtnConsultar.TabIndex = 134
        Me.BtnConsultar.ToolTipText = "Visualizar documento seleccionado"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPicking
        '
        Me.btnPicking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPicking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPicking.Icon = CType(resources.GetObject("btnPicking.Icon"), System.Drawing.Icon)
        Me.btnPicking.Location = New System.Drawing.Point(707, 568)
        Me.btnPicking.Name = "btnPicking"
        Me.btnPicking.Size = New System.Drawing.Size(85, 37)
        Me.btnPicking.TabIndex = 133
        Me.btnPicking.Text = "Picking"
        Me.btnPicking.ToolTipText = "Cambia el estado a los documentos no iniciados para que esten disponibles para pi" & _
    "cking"
        Me.btnPicking.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAuditoria
        '
        Me.BtnAuditoria.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAuditoria.Icon = CType(resources.GetObject("BtnAuditoria.Icon"), System.Drawing.Icon)
        Me.BtnAuditoria.Location = New System.Drawing.Point(266, 568)
        Me.BtnAuditoria.Name = "BtnAuditoria"
        Me.BtnAuditoria.Size = New System.Drawing.Size(52, 37)
        Me.BtnAuditoria.TabIndex = 132
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
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(10, 568)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(85, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnLiberar
        '
        Me.btnLiberar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLiberar.Icon = CType(resources.GetObject("btnLiberar.Icon"), System.Drawing.Icon)
        Me.btnLiberar.Location = New System.Drawing.Point(154, 568)
        Me.btnLiberar.Name = "btnLiberar"
        Me.btnLiberar.Size = New System.Drawing.Size(52, 37)
        Me.btnLiberar.TabIndex = 87
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
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(210, 568)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(52, 37)
        Me.BtnCancelar.TabIndex = 86
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
        Me.BtnSurtir.Location = New System.Drawing.Point(885, 568)
        Me.BtnSurtir.Name = "BtnSurtir"
        Me.BtnSurtir.Size = New System.Drawing.Size(85, 37)
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
        Me.GridPicking.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
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

    Public filtroUbicacion As String = ""
    Public filtroEmpacador As String = ""

    ' Private VENClave As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtPicking As DataTable
    Private bload As Boolean = False
    Private PIN, PFN As Integer
    Private Inicio, Fin As Date
    Private MaskCte As Integer = 0
    Private SUCClave, ClaveSucursal, NombreSucursal, ClaveUsuario, NombreUsuario As String
    Private ALMClave As String
    Private SurtidoRF As Boolean
    Private MostradorRF, Packing As Boolean
    Private FormatoPedido As String
    Private InterfazSalida As String
    Private ticketPicking As Boolean
    Private TIKClave As String
    Private TallaColor As Integer = 0


    Public Sub AgregarFolio()
        If validaForm() Then
            Me.Clock.Stop()
            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            dtPicking = ModPOS.Recupera_Tabla("sp_obtener_picking", "@COMClave", ModPOS.CompanyActual, "@ALMClave", ALMClave, "@Inicio", Inicio, "@Fin", Fin.AddHours(23.9999), "@PIN", PIN, "@PFN", PFN, "@SurtidoRF", SurtidoRF, "@MostradorRF", MostradorRF, "@Cerrado", chkCerrados.Checked, "@Transito", chkTransito.Checked, "@Filtro", filtroUbicacion, "@Usuario", ModPOS.UsuarioActual)
            GridPicking.DataSource = dtPicking
            GridPicking.RetrieveStructure()
            GridPicking.AutoSizeColumns()
            GridPicking.RootTable.Columns("iTipo").Visible = False
            GridPicking.RootTable.Columns("UBCClave").Visible = False
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
            GridPicking.RootTable.Columns("iformaEnvio").Visible = False
            GridPicking.RootTable.Columns("itipoEntrega").Visible = False
            GridPicking.RootTable.Columns("TipoAplicacion").Visible = False

            If TallaColor = 1 Then
                GridPicking.RootTable.Columns("Surtido").Visible = False
                GridPicking.RootTable.Columns("Zona").Visible = False
                GridPicking.RootTable.Columns("Total").Visible = False
                GridPicking.RootTable.Columns("MON").Visible = False
                GridPicking.RootTable.Columns("Consignatario").Visible = False
                GridPicking.RootTable.Columns("Referencia").Visible = False
            End If


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
                Case "TallaColor"
                    TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                Case "MascaraCte"
                    MaskCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

            End Select
        Next
        dt.Dispose()

        If TallaColor = 1 Then
            BtnAuditoria.Visible = False
            BtnReimpresion.Text = "Faltantes"
        End If

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
            ClaveSucursal = dt.Rows(0)("Clave")
            NombreSucursal = dt.Rows(0)("Nombre")
            SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
            MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))

            ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
            TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))
            Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))
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


        If Packing = True Then

            dt = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

            If Not dt Is Nothing Then
                ClaveUsuario = dt.Rows(0)("Referencia")
                NombreUsuario = dt.Rows(0)("Nombre")
            End If

            btnMesa.Visible = True
            btnGuia.Visible = True

        End If

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

            If chkCerrados.Checked = True Then
                btnMesa.Enabled = False
                btnPicking.Enabled = False
                btnLiberar.Enabled = False
                BtnSurtir.Enabled = False
            Else
                btnMesa.Enabled = True
                btnPicking.Enabled = True
                btnLiberar.Enabled = True
                BtnSurtir.Enabled = True
            End If

            BtnConsultar.Enabled = True

        Else
            Me.BtnReimpresion.Enabled = False
            Me.BtnSurtir.Enabled = False
            btnPicking.Enabled = False
            btnLiberar.Enabled = False
            BtnConsultar.Enabled = False
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            If chkTransito.Checked = True Then
                MessageBox.Show("No se puede imprimir los faltantes de pedidos que se encuentren en transito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim i As Integer
            Dim sImpresora As String = ""

            For i = 0 To foundRows.GetUpperBound(0)

                If chkCerrados.Checked = True Then

                    If sImpresora = "" Then
                        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                            previewPedido(FormatoPedido, foundRows(i)("DOCClave"), foundRows(i)("Total"), SUCClave, sImpresora, True, 1, True, True, "", "", IIf(TallaColor = 1, True, False))
                        End If
                    Else
                        previewPedido(FormatoPedido, foundRows(i)("DOCClave"), foundRows(i)("Total"), SUCClave, sImpresora, True, 1, True, True, "", "", IIf(TallaColor = 1, True, False))
                    End If

                Else
                    sImpresora = ""
                    If foundRows(i)("iTipo") = 8 Then
                        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                        End If
                    End If
                    ModPOS.ImprimirSurtido(foundRows(i)("iTipo"), foundRows(i)("DOCClave"), True, True, SUCClave, TIKClave, ticketPicking, TallaColor, TallaColor, sImpresora)

                    End If
            Next

        End If
    End Sub

    Private Sub modificaSurtido()

        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado= 6 or iEstado=4)")

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

            If Packing = True Then
                Dim foundRows1() As DataRow
                foundRows1 = dtPicking.Select("Marca ='True' and EdoSurtido=3 and iTipo <> " & CStr(foundRows(0)("iTipo")) & " and Movilidad=1")

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben ser del mismo Tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                foundRows1 = dtPicking.Select("Marca ='True' and EdoSurtido=3 and iFormaEnvio <> " & CStr(foundRows(0)("iFormaEnvio")) & " and  itipoEntrega <> " & CStr(foundRows(0)("itipoEntrega")) & " and Movilidad=1")

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben tener la misma forma de Envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If foundRows(0)("iTipoEntrega") = 3 Then
                    foundRows1 = dtPicking.Select("Marca ='True' and EdoSurtido=3 and Destino <> '" & CStr(foundRows(0)("Destino")) & "' and Movilidad=1")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener el mismo Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    foundRows1 = dtPicking.Select("Marca ='True' and Stage =''")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener un Stage asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    foundRows1 = dtPicking.Select("Marca ='True' and Stage <> '" & CStr(foundRows(0)("Stage")) & "'")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener el mismo Stage asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If




            End If



            Procesar = foundRows.GetLength(0)
            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                If dt.Rows.Count > 0 Then
                    If CStr(dt.Rows(0)("PICClave")) <> "" AndAlso dt.Rows(0)("EdoSurtido") = 5 Then
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


            If Packing = True Then
                Dim foundRows1() As DataRow
                foundRows1 = dtPicking.Select("Marca ='True' and iTipo <> " & CStr(foundRows(0)("iTipo")) & " and Movilidad=0")

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben ser del mismo Tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                foundRows1 = dtPicking.Select("Marca ='True' and iFormaEnvio <> " & CStr(foundRows(0)("iFormaEnvio")) & " and  itipoEntrega <> " & CStr(foundRows(0)("itipoEntrega")) & " and Movilidad=0")

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben tener la misma forma de Envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If foundRows(0)("iTipoEntrega") = 3 Then
                    foundRows1 = dtPicking.Select("Marca ='True' and Destino <> '" & CStr(foundRows(0)("Destino")) & "' and Movilidad=0")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener el mismo Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    foundRows1 = dtPicking.Select("Marca ='True' and Stage =''")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener un Stage asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    foundRows1 = dtPicking.Select("Marca ='True' and Stage <> '" & CStr(foundRows(0)("Stage")) & "'")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener el mismo Stage asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If



                End If


            End If




            Procesar += foundRows.GetLength(0)
            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("IP") <> "" OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                        MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra surtido o en proceso de recolección, será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            Dim Empacador As String
            If foundRows.Length = 0 Then
                foundRows = dtPicking.Select("Marca ='True' and EdoSurtido=3 and Movilidad=1")
            End If
            If Packing = True AndAlso CInt(foundRows(0)("iTipoEntrega")) >= 3 Then
                If filtroEmpacador = "" Then
                    Dim a As New FrmSolicitaUsuario
                    a.LblAtiende.Text = "Confirmar Usuario"
                    a.lblNota.Text = "Escriba la Clave de Usuario (Empacando o Confirmando) al que se le registrara la confirmación del surtido y presione [Enter] ó Lea el codígo de barras de la tarjeta de identificación del usuario"
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        Empacador = a.AtiendeClave
                    Else
                        MessageBox.Show("No es posible confirmar el Surtido debido a que no existe usuario que Confirme", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    a.Dispose()
                Else
                    Empacador = filtroEmpacador
                End If

            Else
                Empacador = ModPOS.UsuarioActual
            End If


            If ModPOS.Picking Is Nothing Then
                ModPOS.Picking = New FrmPicking
                With ModPOS.Picking
                    .TallaColor = TallaColor
                    .Empacador = Empacador
                    .StartPosition = FormStartPosition.CenterScreen
                    .Documentos = sDoctos
                    .ALMClave = Me.ALMClave
                    .SUCClave = Me.SUCClave
                    .ClaveSucursal = ClaveSucursal
                    .NombreSucursal = NombreSucursal
                    .ClaveUsuario = ClaveUsuario
                    .NombreUsuario = NombreUsuario
                    .FormatoPedido = Me.FormatoPedido
                    .InterfazSalida = Me.InterfazSalida
                    .ticketPicking = ticketPicking
                    .TIKClave = TIKClave
                    .Packing = Packing
                End With
            End If
            ModPOS.Picking.Width = Screen.PrimaryScreen.Bounds.Width
            ModPOS.Picking.Height = Screen.PrimaryScreen.Bounds.Height
            ModPOS.Picking.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Picking.WindowState = FormWindowState.Maximized
            ModPOS.Picking.Show()
            ModPOS.Picking.BringToFront()

        Else
            MessageBox.Show("¡No fue posible procesar algun documento. Debe de marcar los documentos a procesar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal, ByVal iKgLt As Integer, ByVal PesoUnidad As Double, ByVal TipoCanal As Integer)
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("DETClave = '" & DETClave & "'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer

            Dim sTipoDesc As String = ""

            Dim TImpuesto As Integer
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", foundRows(0)("Cliente"), "@TipoCanal", TipoCanal)
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()

            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")


                dCantidad = dCantidadOriginal - dFaltante



                dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

                Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", foundRows(i)("DETClave"))
                If Not dtDescuento Is Nothing Then
                    'Descuento General
                    Dim foundRows1() As DataRow = dtDescuento.Select(" Tipo = 1 ")
                    If foundRows1.Length = 1 Then
                        dDescGeneralPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescGeneralPorc = 0
                    End If

                    'Descuento Volumen
                    foundRows1 = dtDescuento.Select(" Tipo = 2")
                    If foundRows1.Length = 1 Then
                        oVolumen = foundRows1(0)("DescuentoPorc")
                    Else
                        oVolumen = 0
                    End If


                    'Descuento Gerencial
                    foundRows1 = dtDescuento.Select(" Tipo = 3 ")
                    If foundRows1.Length = 1 Then
                        dDescPorc = foundRows1(0)("DescuentoPorc")
                    Else
                        dDescPorc = 0
                    End If
                    dtDescuento.Dispose()
                Else
                    dDescPorc = 0
                    oVolumen = 0
                    dDescGeneralPorc = 0
                End If

                dDescGeneralImp = Math.Round(dBase * dDescGeneralPorc, 2)

                If oVolumen > 0 Then

                    Dim StrucVol As DescVol

                    StrucVol = obtenerDescuentoVolumen(foundRows(i)("Cliente"), iGrupoMaterial, iSector, DOCClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - dDescGeneralImp) * dVolumen, 2)
                    Else
                        dVolumenImp = 0
                    End If


                    'recalcula productos que tengan descuento de volumen
                    If oVolumen <> dVolumen Then
                        Dim dtVolumen As DataTable
                        dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", DOCClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                        If dtVolumen.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtVolumen.Rows.Count - 1
                                ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                            Next


                        End If
                    End If
                End If

                dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                Select Case dFaltante

                    Case Is = dCantidadOriginal
                        'Elimina partida y libera apartado
                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                        "@ALMClave", ALMClave, _
                                        "@VENTA", DOCClave, _
                                        "@PROClave", foundRows(i)("PROClave"), _
                                        "@PrecioBruto", dPrecioUnitario, _
                                        "@Cantidad", 0, _
                                        "@Importe", dBase, _
                                        "@DescGenPor", dDescGeneralPorc, _
                                        "@DescGenImp", dDescGeneralImp, _
                                        "@DescVolPor", dVolumen, _
                                        "@DescVolImp", dVolumenImp, _
                                        "@DescuentoPor", dDescPorc, _
                                        "@DescuentoImp", dDescuentoImp, _
                                        "@ImpuestoImp", dImpuestoImp, _
                                        "@TProducto", foundRows(i)("TProducto"), _
                                        "@TipoDoc", 1, _
                                        "@Picking", Picking, _
                                        "@UndKilo", 0, _
                                        "@DVEClave", foundRows(i)("DVEClave"), _
                                        "@PorcImp", dPorcImp, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@TipoDesc", sTipoDesc, _
                                        "@Autoriza", "", _
                                        "@Total", dImporteNeto, _
                                        "@Cerrado", 1)

                    Case Else
                        'Actualiza total de la partida y libera apartado

                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                                          "@ALMClave", ALMClave, _
                                          "@VENTA", DOCClave, _
                                          "@PROClave", foundRows(i)("PROClave"), _
                                          "@PrecioBruto", dPrecioUnitario, _
                                          "@Cantidad", dCantidad, _
                                          "@Importe", dBase, _
                                          "@DescGenPor", dDescGeneralPorc, _
                                          "@DescGenImp", dDescGeneralImp, _
                                          "@DescVolPor", dVolumen, _
                                          "@DescVolImp", dVolumenImp, _
                                          "@DescuentoPor", dDescPorc, _
                                          "@DescuentoImp", dDescuentoImp, _
                                          "@ImpuestoImp", dImpuestoImp, _
                                          "@TProducto", foundRows(i)("TProducto"), _
                                          "@TipoDoc", 1, _
                                          "@Picking", Picking, _
                                          "@UndKilo", IIf(PesoUnidad = 0, 0, dCantidad / PesoUnidad), _
                                          "@DVEClave", foundRows(i)("DVEClave"), _
                                          "@PorcImp", dPorcImp, _
                                          "@Usuario", ModPOS.UsuarioActual, _
                                          "@TipoDesc", sTipoDesc, _
                                          "@Autoriza", "", _
                                          "@Total", dImporteNeto, _
                                          "@Cerrado", 1)




                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("st_vent_det_closed", "@DVEClave", foundRows(i)("DVEClave"))
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                            dtDet.Dispose()
                        End If


                End Select






            Next



        End If
    End Sub

    Private Sub BtnSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSurtir.Click
        If chkTransito.Checked = True Then

            Dim foundRows() As DataRow
            foundRows = dtPicking.Select("Marca ='True'")

            If foundRows.GetLength(0) = 0 Then
                MessageBox.Show("Debe marcar los pedidos que desea confirmar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else

                Dim bmotivo As Boolean
                Dim motCancelacion, motRechazo As Integer

                Dim foundRows1() As DataRow
                foundRows1 = dtPicking.Select("Marca ='True' and Recibidas = 0 ")

                '1) si el pedido en traslado tiene 0% de recibido y se intenta confirmar será cancelado.

                If foundRows1.GetLength(0) > 0 Then
                    If MessageBox.Show("¿Se detectaron pedidos que tienen 0 % de recepción. ¿Desea continuar y cancelar completamente estos pedidos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                        bmotivo = False
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
                    Else
                        Exit Sub
                    End If
                End If

                '2) Cuando se seleccione un pedido cuyo porcentaje de recibido sea Menor a 100%, el sistema solicitara mediante un mensaje la confirmación de surtir parcialmente dicho pedido. en caso de no aceptar, el sistema cancelara la acción y no realizara ningún cambio. en caso de aceptar surtir el pedido con un porcentaje menor a 100%, el sistema marcara como rechazado por existencia todo aquello que no se haya recibido y 
                'el resto solicitara la confirmación en el flujo normal surtido.  

                foundRows1 = dtPicking.Select("Marca ='True' and Recibidas <>  Solicitadas and Recibidas > 0 ")

                If foundRows1.GetLength(0) > 0 Then
                    If MessageBox.Show("¿Se detectaron pedidos que no han sido 100 % recibidos. ¿Desea continuar y cancelar los productos faltantes?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        bmotivo = False
                        Do
                            Dim m As New FrmMotivo
                            m.Tabla = "Surtido"
                            m.Campo = "TipoRechazo"
                            m.ShowDialog()
                            If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                bmotivo = True
                                motRechazo = m.Motivo
                            End If
                            m.Dispose()
                        Loop While bmotivo = False
                    Else
                        Exit Sub
                    End If
                End If

                ' Realizar un ciclo de todos los pedidos marcados

                Dim Procesar, i As Integer
                Dim sDoctos As String = ""
                Procesar = foundRows.GetLength(0)

                For i = 0 To foundRows.GetUpperBound(0)

                    If foundRows(i)("Recibidas") = 0 Then  ' Si cantidad Recibidas es 0
                        ' se cancela el pedido.

                        ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual, "@TipoAplicacion", foundRows(i)("TipoAplicacion"))
                        ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                    ElseIf foundRows(i)("Recibidas") < foundRows(i)("Solicitadas") Then ' Si cantidad Recibidas es mayor a cero y menor a Solicitdas, 
                        'Actualiza BackOrder
                        'se realizara el registro de producto negado con tipo de rechazo no recibido en traslado.
                        'se quitaran los productos no recibidos del pedido.

                        Dim dtFaltantes As DataTable = ModPOS.Recupera_Tabla("st_recupera_faltantes", "@VENClave", foundRows(i)("DOCClave"))
                        Dim k, j As Integer
                        Dim dtVentaDetalle As DataTable
                        Dim Faltante As Decimal

                        For k = 0 To dtFaltantes.Rows.Count - 1
                            dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", 1, "@DOCClave", foundRows(i)("DOCClave"), "@PROClave", dtFaltantes.Rows(k)("PROClave"))

                            Faltante = dtFaltantes.Rows(k)("Faltante")

                            For j = 0 To dtVentaDetalle.Rows.Count - 1
                                If dtVentaDetalle.Rows(j)("Cantidad") >= Faltante Then


                                    ModPOS.Ejecuta("st_quitar_no_recibidos", _
                                                                "@SUCClave", SUCClave, _
                                                                "@ALMClave", ALMClave,
                                                                "@VENClave", foundRows(i)("DOCClave"), _
                                                                "@DVEClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                                 "@PROClave", dtFaltantes.Rows(k)("PROClave"), _
                                                                 "@Faltante", Faltante, _
                                                                 "@Motivo", motRechazo, _
                                                                 "@Usuario", ModPOS.UsuarioActual, _
                                                                 "@Borra", False)

                                    'Recalcular Partida

                                    recalculaPartidaPedido(dtVentaDetalle, foundRows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), Faltante, dtFaltantes.Rows(k)("KgLt"), dtVentaDetalle.Rows(j)("UndKilo"), dtFaltantes.Rows(k)("TipoCanal"))


                                    Exit For
                                Else

                                    ModPOS.Ejecuta("st_quitar_no_recibidos", _
                                                               "@SUCClave", SUCClave, _
                                                               "@ALMClave", ALMClave,
                                                               "@VENClave", foundRows(i)("DOCClave"), _
                                                               "@DVEClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                                "@PROClave", dtFaltantes.Rows(k)("PROClave"), _
                                                                "@Faltante", dtVentaDetalle.Rows(j)("Cantidad"), _
                                                                "@Motivo", motRechazo, _
                                                                "@Usuario", ModPOS.UsuarioActual, _
                                                                "@Borra", True)

                                    Faltante -= dtVentaDetalle.Rows(j)("Cantidad")
                                End If
                            Next
                        Next


                        ModPOS.Ejecuta("st_quitar_backorder", "@VENClave", foundRows(i)("DOCClave"))
                        'se generara el calculo de recoleccion.
                        ModPOS.calculaRecoleccion(1, foundRows(i)("DOCClave"), ALMClave, "", 0)

                        '   'Se agrega a el pedido a la lista de surtido.
                        If sDoctos = "" Then
                            sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        Else
                            sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        End If

                    Else 'Si cantidad Recibidas = Solicitas
                        'Actualiza BackOrder

                        ModPOS.Ejecuta("st_quitar_backorder", "@VENClave", foundRows(i)("DOCClave"))

                        'Se genera el calculo de recoleccion.
                        ModPOS.calculaRecoleccion(1, foundRows(i)("DOCClave"), ALMClave, "", 0)

                        'Se agrega a el pedido a la lista de surtido.
                        If sDoctos = "" Then
                            sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        Else
                            sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                        End If

                    End If
                Next

                If sDoctos <> "" Then

                    Dim Empacador As String
                    If foundRows.Length = 0 Then
                        foundRows = dtPicking.Select("Marca ='True' and EdoSurtido=3 and Movilidad=1")
                    End If
                    If Packing = True AndAlso CInt(foundRows(0)("iTipoEntrega")) >= 3 Then
                        If filtroEmpacador = "" Then
                            Dim a As New FrmSolicitaUsuario
                            a.LblAtiende.Text = "Confirmar Usuario"
                            a.lblNota.Text = "Escriba la Clave de Usuario (Empacando o Confirmando) al que se le registrara la confirmación del surtido y presione [Enter] ó Lea el codígo de barras de la tarjeta de identificación del usuario"
                            a.ShowDialog()
                            If a.DialogResult = DialogResult.OK Then
                                Empacador = a.AtiendeClave
                            Else
                                MessageBox.Show("No es posible confirmar el Surtido debido a que no existe usuario que Confirme", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                            a.Dispose()
                        Else
                            Empacador = filtroEmpacador
                        End If

                    Else
                        Empacador = ModPOS.UsuarioActual
                    End If

                    If ModPOS.Picking Is Nothing Then
                        ModPOS.Picking = New FrmPicking
                        With ModPOS.Picking
                            .TallaColor = TallaColor
                            .Empacador = Empacador
                            .StartPosition = FormStartPosition.CenterScreen
                            .Documentos = sDoctos
                            .ALMClave = Me.ALMClave
                            .SUCClave = Me.SUCClave
                            .ClaveSucursal = ClaveSucursal
                            .NombreSucursal = NombreSucursal
                            .ClaveUsuario = ClaveUsuario
                            .NombreUsuario = NombreUsuario
                            .FormatoPedido = Me.FormatoPedido
                            .InterfazSalida = Me.InterfazSalida
                            .ticketPicking = ticketPicking
                            .TIKClave = TIKClave
                            .Packing = Packing
                        End With
                    End If
                    ModPOS.Picking.Width = Screen.PrimaryScreen.Bounds.Width
                    ModPOS.Picking.Height = Screen.PrimaryScreen.Bounds.Height
                    ModPOS.Picking.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Picking.WindowState = FormWindowState.Maximized
                    ModPOS.Picking.Show()
                    ModPOS.Picking.BringToFront()
                End If


            End If

        Else
            modificaSurtido()
        End If
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


        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Ha seleccionado una sucursal invalida o es requerida")
            Exit Sub
        End If

        If chkCerrados.Checked = False Then


            foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado=6 or iEstado=4)")
            If foundRows.GetLength(0) > 0 Then
                MessageBox.Show("Ha seleccionado documentos que no pueden ser Cancelados debido a que se encuentran en Proceso de Recolección o Picking o Cancelado")
                Exit Sub
            End If


            foundRows = dtPicking.Select("Marca ='True' and EdoSurtido <=1 ")

            If foundRows.GetLength(0) > 0 Then

                Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(SaldoBase)", "Marca = True"))

                Select Case MessageBox.Show("¿Esta seguro de Cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        
                                Dim i As Integer
                                Dim dt As DataTable
                        Dim msg As String = ""
                                For i = 0 To foundRows.GetUpperBound(0)
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                                    If dt.Rows.Count > 0 Then
                                If CStr(dt.Rows(0)("PICClave")) <> "" Then
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



                                        msg = ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual, "@TipoAplicacion", foundRows(i)("TipoAplicacion"))
                                        msg = ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                                        If foundRows(i)("iEstado") = 2 Then
                                            msg = ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("SaldoBase"))
                                        End If

                                    ElseIf foundRows(i)("iTipo") = 8 Then
                                        Dim dtCargo As DataTable = ModPOS.SiExisteRecupera("st_verificarCargoProveedor", "@TRSClave", foundRows(i)("DOCClave"))
                                        If Not dtCargo Is Nothing Then
                                            If dtCargo.Rows(0)("Cantidad") > 0 Then
                                                MessageBox.Show("No se puede eliminar el traslado debido a que cuenta con cargos a proveedor asociados", "Información", MessageBoxButtons.OK)
                                                AgregarFolio()
                                                Exit Sub
                                            End If
                                        End If
                                        msg = ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@USRClave", ModPOS.UsuarioActual)
                                       
                                    ElseIf foundRows(i)("iTipo") = 6 Then
                                        msg = ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    ElseIf foundRows(i)("iTipo") = 10 Then
                                        msg = ModPOS.Ejecuta("st_cancela_devcompra", "@DEVClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    End If

                                    msg = ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)

                                End If
                                    End If
                                Next
                                AgregarFolio()
                          
                End Select
            Else
                MessageBox.Show("¡Debe marcar solo registros en estado Picking o que no hayan iniciado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            ' Agrear codigo para cancelar pedidos cerrados
            foundRows = dtPicking.Select("Marca ='True' ")
            If foundRows.GetLength(0) > 0 Then
                Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(SaldoBase)", "Marca = True"))

                Select Case MessageBox.Show("¿Esta seguro de Cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                       
                                Dim sImpresora As String = ""

                                If TallaColor = 1 Then
                                    If PrintDialog1.ShowDialog() = DialogResult.OK Then
                                        sImpresora = PrintDialog1.PrinterSettings.PrinterName
                                    End If
                                End If

                                Dim i As Integer
                                Dim dt As DataTable

                                For i = 0 To foundRows.GetUpperBound(0)

                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("DOCClave"))
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0)("Estado") <> 2 OrElse dt.Rows(0)("Total") <> dt.Rows(0)("Saldo") Then
                                            MessageBox.Show("El pedido seleccionado no puede ser cancelado ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            AgregarFolio()
                                            Exit Sub
                                        End If
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

                                    Dim msg As String = ""

                            msg = ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)("DOCClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual, "@TipoAplicacion", foundRows(i)("TipoAplicacion"))

                            Dim dtStage As DataTable = ModPOS.Recupera_Tabla("st_valida_stage_area", "@VENClave", foundRows(0)("DOCClave"))

                            If dtStage.Rows.Count = 0 Then
                                devolucionPorArea(foundRows(0)("DOCClave"), ALMClave)
                            Else
                                ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("DOCClave"), ALMClave, foundRows(0)("Folio"), ModPOS.UsuarioActual, True, 1, foundRows(0)("UBCClave"))
                            End If

                            
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * dt.Rows(0)("TipoCambio"))

                            ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("DOCClave"), "@Tipo", 1)

                            If TallaColor = 1 AndAlso sImpresora <> "" Then
                                previewPedido(FormatoPedido, foundRows(0)("DOCClave"), foundRows(0)("Total"), SUCClave, sImpresora, True, 1, True, True, "", "", True)
                            End If

                        Next
                                AgregarFolio()
                        
                End Select
            Else
                MessageBox.Show("¡Debe marcar los registros que desea cancelar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 7 or iEstado=5) and Movilidad <> 1")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser liberados debido a que no se encuentran en Proceso")
            Exit Sub
        End If

        foundRows = dtPicking.Select("Marca ='True' and Movilidad <> 1")

        If foundRows.GetLength(0) > 0 Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_ip", "@Tipo", foundRows(0)("iTipo"), "@DOCClave", foundRows(0)("DOCClave"))

            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("IPAdress") <> "" Then
                    If dt.Rows(0)("IPAdress") <> IPAddress Then
                        MessageBox.Show("No es posible liberar el documento seleccionado ya que se encuentra abierto en un equipo diferente (" & dt.Rows(0)("IP") & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dt.Dispose()
                        Exit Sub
                    End If
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
            Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))


            dt.Dispose()
            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With

            If Packing = True Then

                dt = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

                If Not dt Is Nothing Then
                    ClaveUsuario = dt.Rows(0)("Referencia")
                    NombreUsuario = dt.Rows(0)("Nombre")
                End If

                btnMesa.Visible = True
                btnGuia.Visible = True

            End If
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
        a.MaskCte = MaskCte
        a.Prefijo = ClaveSucursal
        a.SUCClave = SUCClave
        a.FormatoPedido = Me.FormatoPedido
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

    Private Sub bthPicking_Click(sender As Object, e As EventArgs) Handles btnPicking.Click
        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True' and EdoSurtido = 0 and Movilidad = 1")
        If foundRows.GetLength(0) = 0 Then

            Dim a As New FrmSolicitaUsuario
            a.LblAtiende.Text = "Iniciar Surtido"
            a.lblNota.Text = "Lea el codígo de la tarjeta de identificación del surtidor y despues Lea el código QR impreso en el ticket de Surtido"
            a.lblPicking.Visible = True
            a.txtQR.Visible = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
            End If
            a.Dispose()

        Else
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("st_act_edo_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@Estado", 1, "@Usuario", ModPOS.UsuarioActual)
            Next
        End If
        Me.AgregarFolio()
    End Sub

    Public Sub ImprimirPicking(ByVal sDocumento As String, ByVal iTipo As Integer)
        Dim sError As String = ""


        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Solicitando Información...")
        'Recupera impresoras por area de surtido

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_surtidodetalle", "@AREClave", "", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_envio", "@Tipo", iTipo, "@DOCClave", sDocumento))

        If iTipo = 1 Then
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento", "@VENClave", sDocumento))
        End If


        Dim dtImagen As DataTable = ModPOS.CrearTabla("TablaQR", "QR", "System.Byte[]")

        Dim row1 As DataRow
        row1 = dtImagen.NewRow()
        'declara el nombre de la fila
        row1.Item("QR") = ModPOS.crearQR(sDocumento)
        dtImagen.Rows.Add(row1)

        pvtaDataSet.Tables.Add(dtImagen)

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
                If chkTransito.Checked = True Then
                    Dim a As New FrmConsultaGen
                    a.Text = "Detalle de piezas recibidas"
                    ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_det_recibido", "@VENClave", GridPicking.GetValue("DOCClave"))
                    a.GridConsultaGen.GroupByBoxVisible = False
                    a.ShowDialog()
                    a.Dispose()
                Else
                    ImprimirPicking(GridPicking.GetValue("DOCClave"), GridPicking.GetValue("iTipo"))
                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        BtnRefresh.PerformClick()
    End Sub


    Private Sub btnMesa_Click(sender As Object, e As EventArgs) Handles btnMesa.Click
        If ALMClave = "" Then
            MessageBox.Show("No hay un almacen seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True' and Stage =''")

        If foundRows.GetLength(0) = 0 Then
            MessageBox.Show("Los documentos seleccionados ya tienen Stage o Mesa de empaque asignada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim i As Integer

        'Solicitar Stage
        Dim Stage As String = ""

        Dim p As New FrmStage
        p.TipoAplicacion = 2
        p.ALMClave = ALMClave
        p.ShowDialog()
        Stage = p.UBCClave
        p.Dispose()

        If Stage = "" OrElse Stage.ToString = "NULL" Then
            Exit Sub
        End If


        For i = 0 To foundRows.GetUpperBound(0)

            ModPOS.Ejecuta("st_act_stage_envio", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@Stage", Stage)

            Dim sImpresora As String = ""
            If foundRows(i)("iTipo") = 8 Then
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
                    sImpresora = PrintDialog1.PrinterSettings.PrinterName
                End If
            End If

            ModPOS.ImprimirSurtido(foundRows(i)("iTipo"), foundRows(i)("DOCClave"), False, True, SUCClave, TIKClave, ticketPicking, TallaColor, 0, sImpresora)
        Next
        AgregarFolio()

    End Sub

    Private Sub btnGuia_Click(sender As Object, e As EventArgs) Handles btnGuia.Click
        Dim p As New FrmGuias
        p.SUCClave = SUCClave
        p.ShowDialog()
        p.Dispose()
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        If Not GridPicking.DataSource Is Nothing Then

            Dim foundRows() As DataRow
            foundRows = dtPicking.Select("Marca ='True'")



            If foundRows.GetLength(0) = 0 Then
                MessageBox.Show("Debe marcar un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf foundRows.GetLength(0) > 1 Then
                MessageBox.Show("Ha seleccionado más de un documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else

                Dim errorEdicion As Boolean = False
                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)("DOCClave"))
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("Estado") = 2 AndAlso dt.Rows(0)("Total") = dt.Rows(0)("Saldo") Then

                        Dim dtPic As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", 1, "@DOCClave", foundRows(0)("DOCClave"))
                        If dtPic.Rows.Count > 0 Then
                            If dtPic.Rows(0)("IP").GetType.Name <> "DBNull" And dtPic.Rows(0)("IP") <> "" Then
                                If dtPic.Rows(0)("IP") <> IPAddress Then
                                    errorEdicion = True
                                    MessageBox.Show("El pedido ya se encuentra abierto en otro equipo (IP:" & CStr(dtPic.Rows(0)("IP")) & ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If

                        If errorEdicion = False Then
                            Dim p As New FrmPedido

                            Dim myPICClave As String = ModPOS.obtenerLlave

                            ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", 1, "@PICClave", myPICClave, "@DOCClave", foundRows(0)("DOCClave"), "@Usuario", ModPOS.UsuarioActual, "@IP", IPAddress)

                            p.StageSurtido = foundRows(0)("UBCClave")
                            p.FormatoPedido = Me.FormatoPedido
                            p.sImpresora = ""
                            p.VENClave = foundRows(0)("DOCClave")
                            p.CAJClave = dt.Rows(0)("CAJClave")
                            p.FormPadre = "SURTIDO"
                            p.ShowDialog()
                            If p.Imprimir = True Then
                                Select Case MessageBox.Show("¿Desea imprimir el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Case DialogResult.Yes
                                        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                                            Dim sImpresora As String = PrintDialog1.PrinterSettings.PrinterName
                                            previewPedido(FormatoPedido, foundRows(0)("DOCClave"), dt.Rows(0)("Total"), SUCClave, sImpresora, True, 1, True, True, "", "", IIf(TallaColor = 1, True, False))
                                        End If
                                End Select
                            End If
                            p.Dispose()
                            ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", 1, "@PICClave", Nothing, "@DOCClave", foundRows(0)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)

                        End If

                    Else
                        MessageBox.Show("Solo es posible modificar documentos que se encuentren en Estado igual a CERRADO", "Error", MessageBoxButtons.OK)
                    End If
                End If
                End If
        Else
                Beep()
                MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub chkCerrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrados.CheckedChanged
        If chkCerrados.Checked = False Then
            btnMesa.Enabled = True
            btnPedido.Visible = False
            BtnSurtir.Enabled = True
            btnPicking.Enabled = True
            btnLiberar.Enabled = True
        Else

            If chkTransito.Checked = True Then
                chkTransito.Checked = False
            End If

            btnMesa.Enabled = False
            btnPedido.Visible = True
            BtnSurtir.Enabled = False
            btnPicking.Enabled = False
            btnLiberar.Enabled = False

        End If
        AgregarFolio()
    End Sub

    Private Sub TxtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFolio.Text = TxtFolio.Text.ToUpper.Replace("'", "-")
            If TxtFolio.Text <> "" Then

                If Split(TxtFolio.Text, "-").Length = 3 Then
                    TxtFolio.Text = Split(TxtFolio.Text, "-")(1) & "-" & Split(TxtFolio.Text, "-")(2)
                End If

                Dim foundRows() As DataRow
                foundRows = dtPicking.Select("Folio = '" & TxtFolio.Text.ToUpper.Replace("'", "-") & "'")
                If foundRows.GetLength(0) = 1 Then
                    foundRows(0)("Marca") = True
                    If chkCerrados.Checked = True Then
                        btnPedido.PerformClick()
                    Else
                        BtnSurtir.PerformClick()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub chkTransito_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransito.CheckedChanged
        If chkTransito.Checked = False Then
            btnMesa.Enabled = True
            btnPedido.Visible = False
            BtnSurtir.Enabled = True
            btnPicking.Enabled = True
            btnLiberar.Enabled = True
            BtnReimpresion.Enabled = True
            btnGuia.Enabled = True
            BtnCancelar.Enabled = True
        Else
           
            If chkCerrados.Checked = True Then
                chkCerrados.Checked = False
            End If

            btnMesa.Enabled = False
            btnPedido.Visible = False
            BtnSurtir.Enabled = True
            btnPicking.Enabled = False
            btnLiberar.Enabled = False
            BtnReimpresion.Enabled = False
            btnGuia.Enabled = False
            BtnCancelar.Enabled = False
        End If
        AgregarFolio()
    End Sub
End Class
