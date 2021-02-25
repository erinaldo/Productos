

Public Class FrmFacGlobal
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnNoFacturable As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents TxtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtPorc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnNotaCredito As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacGlobal))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDesc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtPorc = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblSubtotal = New System.Windows.Forms.Label()
        Me.LblIVA = New System.Windows.Forms.Label()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.TxtSubtotal = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.btnNoFacturable = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.TxtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnNotaCredito = New Janus.Windows.EditControls.UIButton()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.btnNotaCredito)
        Me.GrpTickets.Controls.Add(Me.CmbTipo)
        Me.GrpTickets.Controls.Add(Me.Label9)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.txtDesc)
        Me.GrpTickets.Controls.Add(Me.txtPorc)
        Me.GrpTickets.Controls.Add(Me.LblSubtotal)
        Me.GrpTickets.Controls.Add(Me.LblIVA)
        Me.GrpTickets.Controls.Add(Me.TxtTotal)
        Me.GrpTickets.Controls.Add(Me.TxtSubtotal)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.PictureBox3)
        Me.GrpTickets.Controls.Add(Me.TxtBusqueda)
        Me.GrpTickets.Controls.Add(Me.TxtRFC)
        Me.GrpTickets.Controls.Add(Me.Label11)
        Me.GrpTickets.Controls.Add(Me.BtnBuscaCte)
        Me.GrpTickets.Controls.Add(Me.TxtRazonSocial)
        Me.GrpTickets.Controls.Add(Me.TxtClave)
        Me.GrpTickets.Controls.Add(Me.btnNoFacturable)
        Me.GrpTickets.Controls.Add(Me.BtnGuardar)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.btnSalir)
        Me.GrpTickets.Controls.Add(Me.TxtMonto)
        Me.GrpTickets.Controls.Add(Me.Label2)
        Me.GrpTickets.Controls.Add(Me.CmbCaja)
        Me.GrpTickets.Controls.Add(Me.Label12)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.dtFinal)
        Me.GrpTickets.Controls.Add(Me.Label5)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(3, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(1000, 556)
        Me.GrpTickets.TabIndex = 121
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Documentos"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 12)
        Me.Label9.TabIndex = 158
        Me.Label9.Text = "Tipo Impuesto"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(682, 505)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Desc [$]"
        '
        'txtDesc
        '
        Me.txtDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.DecimalDigits = 2
        Me.txtDesc.Location = New System.Drawing.Point(769, 502)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(223, 20)
        Me.txtDesc.TabIndex = 155
        Me.txtDesc.Text = "0.00"
        Me.txtDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDesc.Value = 0.0R
        Me.txtDesc.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtPorc
        '
        Me.txtPorc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPorc.DecimalDigits = 2
        Me.txtPorc.Location = New System.Drawing.Point(769, 477)
        Me.txtPorc.Name = "txtPorc"
        Me.txtPorc.Size = New System.Drawing.Size(223, 20)
        Me.txtPorc.TabIndex = 154
        Me.txtPorc.Text = "0.00"
        Me.txtPorc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtPorc.Value = 0.0R
        Me.txtPorc.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(682, 455)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(46, 15)
        Me.LblSubtotal.TabIndex = 151
        Me.LblSubtotal.Text = "Subtotal"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(682, 482)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(60, 15)
        Me.LblIVA.TabIndex = 150
        Me.LblIVA.Text = "Desc [%]"
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(769, 526)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(223, 21)
        Me.TxtTotal.TabIndex = 148
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSubtotal
        '
        Me.TxtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubtotal.Enabled = False
        Me.TxtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubtotal.Location = New System.Drawing.Point(770, 450)
        Me.TxtSubtotal.Name = "TxtSubtotal"
        Me.TxtSubtotal.ReadOnly = True
        Me.TxtSubtotal.Size = New System.Drawing.Size(223, 21)
        Me.TxtSubtotal.TabIndex = 146
        Me.TxtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(681, 531)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(93, 15)
        Me.LblTotal.TabIndex = 149
        Me.LblTotal.Text = "Total a Facturar"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(653, 527)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox3.TabIndex = 145
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(130, 45)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(141, 21)
        Me.TxtBusqueda.TabIndex = 144
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(351, 45)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(141, 21)
        Me.TxtRFC.TabIndex = 143
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 20)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(283, 44)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(58, 24)
        Me.BtnBuscaCte.TabIndex = 137
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(130, 74)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(580, 23)
        Me.TxtRazonSocial.TabIndex = 138
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(503, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(207, 21)
        Me.TxtClave.TabIndex = 139
        '
        'btnNoFacturable
        '
        Me.btnNoFacturable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNoFacturable.Icon = CType(resources.GetObject("btnNoFacturable.Icon"), System.Drawing.Icon)
        Me.btnNoFacturable.Location = New System.Drawing.Point(806, 122)
        Me.btnNoFacturable.Name = "btnNoFacturable"
        Me.btnNoFacturable.Size = New System.Drawing.Size(90, 37)
        Me.btnNoFacturable.TabIndex = 123
        Me.btnNoFacturable.Text = "&No Facturable"
        Me.btnNoFacturable.ToolTipText = "Se cambia el estado de las ventas a No Facturables"
        Me.btnNoFacturable.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(902, 122)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Facturar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Monto a Facturar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(710, 122)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtMonto
        '
        Me.TxtMonto.DecimalDigits = 2
        Me.TxtMonto.Location = New System.Drawing.Point(221, 135)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(132, 20)
        Me.TxtMonto.TabIndex = 135
        Me.TxtMonto.Text = "0.00"
        Me.TxtMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMonto.Value = 0.0R
        Me.TxtMonto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(584, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "al"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Caja"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(86, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'dtFinal
        '
        Me.dtFinal.CustomFormat = "MMMM yyyy"
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(618, 16)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.ShowUpDown = True
        Me.dtFinal.Size = New System.Drawing.Size(92, 20)
        Me.dtFinal.TabIndex = 133
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker.Location = New System.Drawing.Point(473, 16)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(92, 20)
        Me.dtPicker.TabIndex = 128
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(86, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox2.TabIndex = 84
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(359, 134)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(43, 22)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Calcular"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 138)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 163)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(985, 281)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 15)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Cliente a Facturar"
        '
        'btnNotaCredito
        '
        Me.btnNotaCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotaCredito.Icon = CType(resources.GetObject("btnNotaCredito.Icon"), System.Drawing.Icon)
        Me.btnNotaCredito.Location = New System.Drawing.Point(806, 16)
        Me.btnNotaCredito.Name = "btnNotaCredito"
        Me.btnNotaCredito.Size = New System.Drawing.Size(186, 37)
        Me.btnNotaCredito.TabIndex = 159
        Me.btnNotaCredito.Text = "&Notas de Crédito"
        Me.btnNotaCredito.ToolTipText = "Notas de Crédito Pendientes"
        Me.btnNotaCredito.Visible = False
        Me.btnNotaCredito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(130, 105)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipo.TabIndex = 157
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(130, 16)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(252, 21)
        Me.CmbCaja.TabIndex = 101
        '
        'FrmFacGlobal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmFacGlobal"
        Me.Text = "Selección de Documentos"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public CAJClave As String = ""

    Private oCFD As CFD
    Private FACClave As String
    Private Inicio, Fin As Date
    Private dtCxC As DataTable

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private dtDetalle As DataTable
    Private iTipoPAC As Integer

    Private TipoCambio, dSubtotal, dPorc, dDesc, dTotal, SaldoCliente As Decimal
    Private bload As Boolean = False
    Private dtPAC, dtPendientes, dtAnticipos, dtContrarecibos As DataTable
    Private cobranzaGeneral As Boolean = True
    '  Private CTEClave As String = ""
    Private sRazonSocial As String = ""
    Private MailSSL As Boolean
    Private TipoCF, Periodo, PeriodoContra, Mes, MesContra, MailPort As Integer
    Private CobranzaVenta As Boolean = False
    Private Moneda, MonedaDesc, MonedaRef, CTEClaveActual, CTENombreActual, ServidorCancelacion, Autoriza, PathXML, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF As String
    Private InterfazSalida As String = ""
    Private iRegimenFiscal As Integer
    Private TallaColor As Integer = 0

    Private Sub FrmFacGlobal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        dtPicker.Value = Today.Date
        dtFinal.Value = Today.Date

        Inicio = dtPicker.Value
        Fin = dtPicker.Value

        oCFD = New CFD

        oCFD.UsoCFDI = "P01"

        oCFD.tipoDeComprobante = "ingreso"

        FACClave = ModPOS.obtenerLlave


        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = SUCClave
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        Dim dtmsg As DataTable
        Dim dtParam As DataTable

        If CAJClave <> "" Then

            CmbCaja.SelectedValue = CAJClave
            CmbCaja.Enabled = False

            dtmsg = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            oCFD.CTEClave = IIf(dtmsg.Rows(0)("Mostrador").GetType.Name <> "DBNull", dtmsg.Rows(0)("Mostrador"), "")
            dtmsg.Dispose()

            CargaDatosCliente(oCFD.CTEClave)

        End If


        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "CobranzaVenta"
                        CobranzaVenta = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", False, dtParam.Rows(i)("Valor"))
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatCargo"
                        FormatCargo = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "VersionCF"

                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
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
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()


        If TallaColor = 1 Then
            txtPorc.Enabled = False
            txtDesc.Enabled = False
            btnNotaCredito.Visible = True
        End If


        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If VersionCF = "3.3" Then
            oCFD.regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            oCFD.regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()


        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        bload = True



        AgregarFolio()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.CmbCaja.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If oCFD.CTEClave Is Nothing OrElse oCFD.CTEClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If dTotal <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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


    Private Function VerificaDatoFiscalCte(ByVal oCFD As CFD) As Boolean
        Dim Cadena As String = ""
        Dim Valido As Boolean = True

        If oCFD.Pais = "" Then
            Cadena &= "Pais,"
        End If

        If oCFD.Entidad = "" Then
            Cadena &= "Entidad,"
        End If

        If oCFD.Mnpio = "" Then
            Cadena &= "Municipio,"
        End If
        If oCFD.Colonia = "" Then
            Cadena &= "Colonia,"
        End If

        If oCFD.Calle = "" Then
            Cadena &= "Calle,"
        End If

        If oCFD.noExterior = "" Then
            Cadena &= "No. Exterior,"
        End If

        If oCFD.codigoPostal = "" Then
            Cadena &= "Código Postal,"
        End If

        If oCFD.RazonSocial = "" Then
            Cadena &= "Razón Social,"
        End If


        If oCFD.RFC <> "" AndAlso oCFD.RFC.Length >= 12 AndAlso oCFD.RFC.Length <= 13 Then
            If oCFD.TPersona = 1 Then
                If ModPOS.soloLetras(oCFD.RFC.Substring(3, 1)) = False Then
                    Cadena &= "RFC,"
                End If
            End If
        Else
            Cadena &= "RFC,"
        End If


        If Cadena = "" Then
            Valido = True
        Else
            '      MessageBox.Show("La siguiente información del cliente No es valida ó es requerida para facturar: " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Valido = False
        End If

        Return Valido
    End Function

    Private Sub recalculaImpuestos(ByVal sFACClave As String, ByVal sDETClave As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)

        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        Dim Base As Double
        Dim PorcImp As Double = 0

        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = PrecioImp
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = dPrecio
                End If


                ModPOS.Ejecuta("sp_desglosa_impuestos", _
                           "@DFAClave", sDETClave, _
                           "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), _
                           "@Base", Base, _
                           "@PorcImp", dtImpuesto.Rows(i)("Valor"), _
                           "@Importe", Math.Round(ImpImporte, 2), _
                           "@Usuario", ModPOS.UsuarioActual)

                PrecioImp += Math.Round(ImpImporte, 2)

            Next
            dtImpuesto.Dispose()

        End If

    End Sub


    Public Sub AgregarFolio()
        If bload Then

            If CmbTipo.SelectedValue Is Nothing Then
                MessageBox.Show("Debe seleccionar Tipo de Impuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            oCFD.TImpuesto = CmbTipo.SelectedValue

            dSubtotal = 0
            dPorc = 0
            dDesc = 0
            dTotal = dSubtotal


            TxtSubtotal.Text = dSubtotal
            txtPorc.Text = dPorc
            txtDesc.Text = dDesc
            TxtTotal.Text = dTotal

            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If

            dtCxC = ModPOS.Recupera_Tabla("st_recupera_global", "@SUCClave", SUCClave, "@Inicio", Inicio, "@Fin", Fin.AddHours(23.9999), "@CobranzaVenta", CobranzaVenta, "@TipoImpuesto", CmbTipo.SelectedValue, "@TallaColor", TallaColor)
            GridCxC.DataSource = dtCxC
            GridCxC.RetrieveStructure()
            GridCxC.AutoSizeColumns()

            GridCxC.RootTable.Columns("ID").Visible = False
            GridCxC.CurrentTable.Columns("CTEClave").Visible = False
            GridCxC.CurrentTable.Columns("Email").Visible = False

            GridCxC.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridCxC.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            GridCxC.RootTable.Columns("Folio").Width = 45
            GridCxC.RootTable.Columns("Cve. Cte.").Width = 45
            GridCxC.CurrentTable.Columns("MONClave").Visible = False
            ChkMarcaTodos.Enabled = True


        End If
    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim impresora As String
            'Inicia Sección de Validaciones 
            CAJClave = CmbCaja.SelectedValue

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            impresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()



            Dim foundRows() As DataRow
            Dim fr() As DataRow

            foundRows = dtCxC.Select("Marca ='True' ")
            If foundRows.GetLength(0) > 0 Then


                fr = dtCxC.Select("Marca ='True'  and MONClave <> '" & foundRows(0)("MONClave") & "'")

                If fr.GetLength(0) >= 1 Then
                    MessageBox.Show("No es posible incluir ventas de diferentes Monedas en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                fr = dtCxC.Select("Marca ='True' and MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

                If fr.GetLength(0) >= 1 Then
                    MessageBox.Show("No es posible incluir ventas de Tipo de Cambio Diferente en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se generara una Factura Global con todos los documentos seleccionados por " & Format(TxtTotal.Text, "Currency") & " para el Cliente: " & TxtRazonSocial.Text & ", esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim iTipoPac As Integer
                        Dim Vencimiento As DateTime
                        Dim dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable

                        Dim ImprimeFactura As Boolean = False
                        Dim EnviaFactura As Boolean = False
                        Dim FacturaId As String = ""
                        Dim FACClave As String
                        Dim Logo As Integer = 1
                        oCFD.VersionCF = VersionCF

                        If oCFD.VersionCF = "3.3" Then
                            oCFD.tipoDeComprobante = "I"
                        Else
                            oCFD.tipoDeComprobante = "ingreso"
                        End If

                        oCFD.TipoCF = TipoCF

                        'Verifica Timbres
                        If oCFD.TipoCF = 2 Then
                            dtPac = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                            If dtPac Is Nothing OrElse dtPac.Rows.Count <= 0 Then
                                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If

                        ' Verifica Certificado
                        dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                            oCFD.noCertificado = dt.Rows(0)("Serie")
                            oCFD.Certificado64 = dt.Rows(0)("Certificado")
                            oCFD.LlaveFile = dt.Rows(0)("Llave")
                            oCFD.ContrasenaClave = dt.Rows(0)("Password")
                            dt.Dispose()
                        Else
                            MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        'Verifica que exista el path
                        Try
                            If Not System.IO.Directory.Exists(PathXML) Then
                                MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Catch ex As Exception
                        End Try

                        'Verifica que exista el path del .Key
                        Try
                            If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                                MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Catch ex As Exception
                        End Try

                        Dim NumFacturas As Integer = foundRows.GetLength(0)
                        If Not ModPOS.validaFolio(SUCClave, CAJClave, 1, NumFacturas) Then
                            Exit Sub
                        End If

                        'Recupera la llave 
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



                        'Recupera información del Emisor

                        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
                        oCFD.eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
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

                        dt.Dispose()


                        If oCFD.eReferencia = "" Then
                            oCFD.eReferencia = "SIN REFERENCIA"
                        End If

                        If oCFD.enoInterior <> "" Then
                            oCFD.benoInterior = True
                        Else
                            oCFD.benoInterior = False
                        End If

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


                        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
                        MonedaRef = dt.Rows(0)("Referencia")
                        MonedaDesc = dt.Rows(0)("Descripcion")
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        dt.Dispose()


                        If MessageBox.Show("¿Desea imprimir el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            ImprimeFactura = True
                        End If

                        If MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            EnviaFactura = True
                        End If


                        If VerificaDatoFiscalCte(oCFD) = True Then

                            Vencimiento = Today.Date
                            FacturaId = ModPOS.obtenerLlave
                            FACClave = ModPOS.obtenerLlave
                            oCFD.DOCClave = FACClave
                            FormatoFactura = "Global"

                            If oCFD.VersionCF = "3.3" Then
                                oCFD.formaDePago = "PUE"
                            Else
                                oCFD.formaDePago = "Pago en una sola exhibición"
                            End If


                            ModPOS.Ejecuta("sp_crea_factura", _
                                              "@FACClave", FACClave, _
                                              "@idFactura", FacturaId, _
                                              "@CAJClave", CmbCaja.SelectedValue, _
                                              "@tipo", oCFD.tipoDeComprobante, _
                                              "@Usuario", ModPOS.UsuarioActual)

                            'Carga Folios
                            Dim i As Integer

                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_agrega_tickfac", "@idFactura", FacturaId, "@VENClave", foundRows(i)("ID"))

                                'recalcula impuesto detalle de la venta

                                ModPOS.Ejecuta("st_recalcula_imp_venta", "@VENClave", foundRows(i)("ID"))


                            Next


                            dtDetalle = ModPOS.Recupera_Tabla("sp_muestra_detallefactura", "@idFactura", FacturaId, "@TallaColor", TallaColor)

                            Dim fila As Integer
                            Dim contador As Integer = 0

                            'Recalcula decimales de porcentaje de descuento

                            If dPorc > 0 Then
                                dPorc = (dDesc * 100) / dSubtotal
                            End If

                            Dim iPartida As Integer
                            Dim sDFAClave As String

                            Dim dPorcDesc, dDescImp, dImpuestoImp As Decimal

                            For fila = 0 To dtDetalle.Rows.Count - 1


                                If dPorc > 0 Then
                                    dDescImp = dtDetalle.Rows(fila)("Dscto") + Redondear(((dtDetalle.Rows(fila)("Subtotal") - dtDetalle.Rows(fila)("Dscto")) * (dPorc / 100)), 2)
                                Else
                                    dDescImp = dtDetalle.Rows(fila)("Dscto")
                                End If

                                If dDescImp > 0 Then
                                    dPorcDesc = dDescImp / dtDetalle.Rows(fila)("Subtotal")
                                Else
                                    dPorcDesc = 0
                                End If

                                dImpuestoImp = Math.Round((dtDetalle.Rows(fila)("Subtotal") - dDescImp) * dtDetalle.Rows(fila)("PorcImp"), 2)

                                iPartida = (contador + 1) * 10

                                sDFAClave = ModPOS.obtenerLlave


                                ModPOS.Ejecuta("sp_inserta_detallefactura", _
                                               "@DFAClave", sDFAClave, _
                                               "@FACClave", FACClave, _
                                               "@Partida", iPartida, _
                                               "@Producto", dtDetalle.Rows(fila)("PROClave"), _
                                               "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                                               "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                               "@PrecioBruto", dtDetalle.Rows(fila)("Precio Unitario"), _
                                               "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                               "@Subtotal", dtDetalle.Rows(fila)("SubTotal"), _
                                               "@PorcDesc", dPorcDesc, _
                                               "@DescuentoImp", dDescImp, _
                                               "@PorcImp", dtDetalle.Rows(fila)("PorcImp"), _
                                               "@ImpuestoImp", dImpuestoImp, _
                                               "@PuntosImp", dtDetalle.Rows(fila)("PuntosImp"), _
                                               "@ZDGE", dtDetalle.Rows(fila)("ZDGE"), _
                                               "@Und", dtDetalle.Rows(fila)("UndKilo"), _
                                               "@PREClave", dtDetalle.Rows(fila)("PREClave"), _
                                               "@Total", dtDetalle.Rows(fila)("SubTotal") - dDescImp + dImpuestoImp)


                                ' recalculaImpuestos(FACClave, sDFAClave, dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal") - dDescImp, oCFD.TImpuesto, SUCClave)


                                contador += 1
                            Next
                            dtDetalle.Dispose()

                            ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)


                            Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave)
                            Logo = dtLogo.Rows(0)("Logo")
                            dtLogo.Dispose()

                            ModPOS.Ejecuta("sp_actualiza_factura", _
                                            "@FACClave", FACClave, _
                                            "@TipoImpuesto", oCFD.TImpuesto, _
                                            "@TipoCF", oCFD.TipoCF, _
                                            "@VersionCF", oCFD.VersionCF, _
                                            "@RegimenFiscal", oCFD.regimenFiscal, _
                                            "@fechaAprobacion", oCFD.fechaAprobacion, _
                                            "@Serie", oCFD.Serie, _
                                            "@Folio", oCFD.Folio, _
                                            "@CTEClave", oCFD.CTEClave, _
                                            "@Credito", 0, _
                                            "@DiasCredito", oCFD.DiasCredito, _
                                            "@FechaVencimiento", Vencimiento, _
                                            "@CAJClave", CmbCaja.SelectedValue, _
                                            "@Vendio", ModPOS.UsuarioActual, _
                                            "@Facturo", ModPOS.UsuarioActual, _
                                            "@Desglosar", oCFD.NoDesglosaIEPS, _
                                            "@formaDePago", oCFD.formaDePago, _
                                            "@MONClave", Moneda, _
                                            "@TipoCambio", TipoCambio, _
                                            "@Formato", FormatoFactura, _
                                            "@UsoCFDI", oCFD.UsoCFDI, _
                                            "@Nota", "", _
                                            "@Logo", Logo, _
                                            "@fechaFactura", Fin)


                            Dim FolioInicial As String


                            FolioInicial = oCFD.Serie & CStr(oCFD.Folio)


                            If oCFD.VersionCF = "3.3" Then
                                ModPOS.Ejecuta("st_crea_detalleGlobal", "@FacturaId", FacturaId, "@FACClave", FACClave, "@Desc", IIf(dPorc > 0, dPorc / 100, 0), "@TallaColor", TallaColor)
                                Dim dtm As DataTable = Recupera_Tabla("st_metodopago_global", "@FacturaId", FacturaId, "@Desc", IIf(dPorc > 0, dPorc / 100, 0))
                                oCFD.metodoDePago = dtm.Rows(0)("MetodoPagoSAT")

                                ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                               "@FacturaID", FacturaId, _
                                               "@MetodoPago", dtm.Rows(0)("Tipo"), _
                                               "@Banco", "", _
                                               "@SAT", dtm.Rows(0)("MetodoPagoSAT"), _
                                               "@Referencia", "")
                                dtm.Dispose()
                            Else

                                If ModPOS.MetodoPago Is Nothing Then
                                    ModPOS.MetodoPago = New FrmMetodoPago
                                    With ModPOS.MetodoPago
                                        .bGlobal = True
                                        .CTEClave = oCFD.CTEClave
                                        .FacturaId = FacturaId
                                        .VersionCF = oCFD.VersionCF
                                    End With
                                End If

                                ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

                                If ModPOS.MetodoPago.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                    If ModPOS.MetodoPago.MetodoDePago <> "" Then
                                        oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                                        oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago

                                    End If
                                End If

                                ModPOS.MetodoPago.Dispose()
                                ModPOS.MetodoPago = Nothing

                            End If

                            ModPOS.Ejecuta("st_actualiza_facglobal", "@FacturaID", FacturaId)

                            'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
                            dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaId)

                            If oCFD.VersionCF = "3.3" Then

                                dtConcepto = ModPOS.Recupera_Tabla("st_recupera_concepto_global", "@FACClave", oCFD.DOCClave)
                                dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", oCFD.DOCClave)
                                dtImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_global", "@FACClave", oCFD.DOCClave)


                            Else
                                dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaId)
                                dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaId)
                            End If




                            oCFD.Serie = dt.Rows(0)("Serie")
                            oCFD.Folio = dt.Rows(0)("Folio")
                            oCFD.descuento = dt.Rows(0)("descuentoTot")
                            oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fechaFactura"))
                            oCFD.Moneda = dt.Rows(0)("Moneda")
                            oCFD.TipoCambio = dt.Rows(0)("TipoCambio")
                            oCFD.total = dt.Rows(0)("Total")



                            If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then

                                oCFD.DOCClave = dt.Rows(0)("FACClave")

                                If oCFD.VersionCF = "3.3" Then

                                    ' dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", "I", "@Tipo", 1, "@Clave", oCFD.DOCClave)

                                    oCFD.cadenaOriginal = generarCadenaOriginalGlobal(oCFD, dtConcepto, dtImpuesto, dtDetalleImpuesto)
                                    oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                                    iTipoPac = crearXMLGlobal(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, dtConcepto, dtImpuesto, dtDetalleImpuesto, oCFD, InterfazSalida)

                                Else
                                    If oCFD.TipoCF = 1 Then
                                        oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                    Else
                                        oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto)
                                    End If

                                    oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                                    iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto)

                                End If



                            Else
                                actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
                            End If


                            dt.Dispose()
                            dtConcepto.Dispose()
                            dtImpuesto.Dispose()


                            If CobranzaVenta = True AndAlso iTipoPac <> 0 Then
                                Dim dtDevolucion As DataTable = ModPOS.Recupera_Tabla("st_nc_pendientes", "@DOCClave", oCFD.DOCClave)
                                If dtDevolucion.Rows.Count > 0 Then
                                    Dim frmStatusMessage As New frmStatus
                                    For i = 0 To dtDevolucion.Rows.Count - 1
                                        frmStatusMessage.Show("Generando CFD: " & dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")) & ". Procesando: " & CStr(i + 1) & "/" & CStr(dtDevolucion.Rows.Count))
                                        frmStatusMessage.BringToFront()

                                        ModPOS.regenerarCFD(dtDevolucion.Rows(i)("TipoCF"), dtDevolucion.Rows(i)("NCClave"), SUCClave)

                                        ModPOS.crearXML(2, dtPac, PathXML, dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")), dtDevolucion.Rows(i)("NCClave"), dtDevolucion.Rows(i)("tipoCertificado"), Nothing, Nothing, Nothing, dtDevolucion.Rows(i)("Tipo"), InterfazSalida)
                                    Next
                                    frmStatusMessage.Dispose()
                                End If
                            End If

                            If ImprimeFactura = True Then

                                Dim sImpresora As String
                                Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", impresora)
                                sImpresora = dtPrinter.Rows(0)("Referencia")
                                dtPrinter.Dispose()

                                ModPOS.imprimirFactura(oCFD.TipoCF, FormatoFactura, FACClave, oCFD.total, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, 1, oCFD.VersionCF, Logo)

                            End If

                            If EnviaFactura = True Then
                                If oCFD.email <> "" Then
                                    ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo)
                                End If
                            End If

                            System.Threading.Thread.Sleep(1000)



                        End If
                End Select
                Cursor.Current = Cursors.Default
                Me.Close()
            Else
                MessageBox.Show("Debe seleccionar por lo menos un documento a facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Alguno de los datos es requerido o no es valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If dtCxC.Rows.Count > 0 Then
            If CDbl(TxtMonto.Text) > 0 Then
                Dim Monto, Acumulado As Double
                Monto = CDbl(TxtMonto.Text)
                Acumulado = 0
                Dim i As Integer
                For i = 0 To GridCxC.GetDataRows.Length - 1

                    If Acumulado < Monto Then
                        If (Acumulado + GridCxC.GetDataRows(i).DataRow("Total")) <= Monto Then
                            Acumulado += GridCxC.GetDataRows(i).DataRow("Total")
                            GridCxC.GetDataRows(i).DataRow("Marca") = True
                        Else
                            GridCxC.GetDataRows(i).DataRow("Marca") = False
                        End If
                    Else
                        GridCxC.GetDataRows(i).DataRow("Marca") = False
                    End If
                Next
                GridCxC.Refresh()

                dSubtotal = IIf(dtCxC.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Total)", "Marca = True"))
                If dSubtotal = 0 Then
                    dPorc = 0
                    dDesc = 0
                    dTotal = dSubtotal

                Else
                    If dPorc > 0 Then
                        dDesc = Redondear(dSubtotal * (dPorc / 100), 2)
                        dTotal = Redondear(dSubtotal - dDesc, 2)
                    Else
                        dPorc = 0
                        dDesc = 0
                        dTotal = dSubtotal
                    End If
                End If


                TxtSubtotal.Text = dSubtotal
                txtPorc.Text = dPorc
                txtDesc.Text = dDesc
                TxtTotal.Text = dTotal

            End If
        End If
    End Sub

    Private Sub chkIncluir_CheckedChanged(sender As Object, e As EventArgs)
        AgregarFolio()
    End Sub



    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                dSubtotal = 0
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                    dSubtotal += GridCxC.GetDataRows(i).DataRow("Total")
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
                dSubtotal = 0
            End If
            dtCxC.AcceptChanges()
            GridCxC.Refresh()


            '            dSubtotal = IIf(dtCxC.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Total)", "Marca = True"))
            If dSubtotal = 0 Then
                dPorc = 0
                dDesc = 0
                dTotal = dSubtotal

            Else
                If dPorc > 0 Then
                    dDesc = TruncateToDecimal(dSubtotal * (dPorc / 100), 2)
                    dTotal = TruncateToDecimal(dSubtotal - dDesc, 2)

                Else
                    dPorc = 0
                    dDesc = 0
                    dTotal = dSubtotal
                End If
            End If


            TxtSubtotal.Text = TruncateToDecimal(dSubtotal, 2)
            txtPorc.Text = dPorc
            txtDesc.Text = dDesc
            TxtTotal.Text = TruncateToDecimal(dTotal, 2)

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles btnNoFacturable.Click
        Dim foundRows() As DataRow
        foundRows = dtCxC.Select("Marca ='True' ")
        If foundRows.GetLength(0) > 0 Then
            Select Case MessageBox.Show("Esta a punto de marcar las ventas seleccionadas como No Facturables, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim frmStatusMessage As New frmStatus
                    Cursor.Current = Cursors.WaitCursor
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)

                        frmStatusMessage.Show("Documentos " & CStr(i + 1) & "/" & CStr(foundRows.GetLength(0)))

                        ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", foundRows(i)("ID"), "@Estado", 10)
                    Next
                    frmStatusMessage.Dispose()
                    Cursor.Current = Cursors.Default
                    AgregarFolio()
            End Select
        End If

    End Sub

    Private Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            sCTEClave = dt.Rows(0)("CTEClave")
            oCFD.CTEClave = sCTEClave
            oCFD.CURP = dt.Rows(0)("CURP")
            oCFD.Clave = dt.Rows(0)("Clave")
            CmbTipo.SelectedValue = dt.Rows(0)("TImpuesto")
            oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
            oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
            oCFD.TPersona = dt.Rows(0)("TPersona")
            oCFD.RFC = dt.Rows(0)("id_Fiscal")
            oCFD.LCredito = dt.Rows(0)("LimiteCredito")
            oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
            oCFD.Contacto = dt.Rows(0)("Contacto")
            oCFD.Tel1 = dt.Rows(0)("Tel1")
            oCFD.Tel2 = dt.Rows(0)("Tel2")
            oCFD.email = dt.Rows(0)("Email")
            oCFD.listaPrecio = dt.Rows(0)("PREClave")
            oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
            oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

            oCFD.GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))

            oCFD.FechaReg = dt.Rows(0)("FechaRegistro")
            oCFD.Estado = dt.Rows(0)("Estado")
            oCFD.DCTEClave = dt.Rows(0)("DCTEClave")

            oCFD.Pais = dt.Rows(0)("Pais")
            oCFD.Entidad = dt.Rows(0)("Entidad")
            oCFD.Mnpio = dt.Rows(0)("Municipio")
            oCFD.Colonia = dt.Rows(0)("Colonia")
            oCFD.Calle = dt.Rows(0)("Calle")
            oCFD.Localidad = dt.Rows(0)("Localidad")
            oCFD.Referencia = dt.Rows(0)("referencia")
            oCFD.noExterior = dt.Rows(0)("noExterior")
            oCFD.noInterior = dt.Rows(0)("noInterior")
            oCFD.codigoPostal = dt.Rows(0)("codigoPostal")

            If oCFD.Referencia = "" Then
                oCFD.Referencia = "SIN REFERENCIA"
            End If

            If oCFD.noInterior <> "" Then
                oCFD.brnoInterior = True
            Else
                oCFD.brnoInterior = False
            End If

            SaldoCliente = dt.Rows(0)("Disponible")


            dt.Dispose()

            TxtClave.Text = oCFD.Clave
            TxtRazonSocial.Text = oCFD.RazonSocial
            TxtRFC.Text = oCFD.RFC


            dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

            If Not dt Is Nothing Then
                oCFD.tieneAddenda = True
                oCFD.Tipo = dt.Rows(0)("Tipo")
                oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                oCFD.FTP = dt.Rows(0)("FTP")
                oCFD.Firma = dt.Rows(0)("FirmaWeb")
                oCFD.emailAdd = dt.Rows(0)("email")
                oCFD.NoProveedor = dt.Rows(0)("NoProveedor")
                FormatoFactura = dt.Rows(0)("FormatoFactura")
            End If



        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnBuscaCte_Click(sender As Object, e As EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                oCFD.CTEClave = a.valor
                CargaDatosCliente(oCFD.CTEClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Inicio <> dtPicker.Value) Then
            If dtPicker.Value > Fin Then
                dtPicker.Value = Fin
            End If

            Inicio = dtPicker.Value

            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub



    Private Sub GridCxC_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        dtCxC.AcceptChanges()

        GridCxC.Refresh()

        If GridCxC.GetValue("Marca") = True Then
            dSubtotal += CDbl(IIf(GridCxC.GetValue("Total").GetType.Name = "DBNull", 0, GridCxC.GetValue("Total")))
        Else
            dSubtotal -= CDbl(IIf(GridCxC.GetValue("Total").GetType.Name = "DBNull", 0, GridCxC.GetValue("Total")))
        End If

        If dSubtotal = 0 Then
            dPorc = 0
            dDesc = 0
            dTotal = dSubtotal

        Else
            If dPorc > 0 Then
                dDesc = ModPOS.TruncateToDecimal(dSubtotal * (dPorc / 100), 2)
                dTotal = ModPOS.TruncateToDecimal(dSubtotal - dDesc, 2)
            Else
                dPorc = 0
                dDesc = 0
                dTotal = dSubtotal
            End If
        End If


        TxtSubtotal.Text = dSubtotal
        txtPorc.Text = dPorc
        txtDesc.Text = dDesc
        TxtTotal.Text = dTotal

    End Sub

    Private Sub txtPorc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPorc.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select
    End Sub


    Private Sub txtPorc_Leave(sender As Object, e As EventArgs) Handles txtPorc.Leave
        dPorc = Math.Abs(CDbl(txtPorc.Text))
        If dSubtotal > 0 Then
            If dPorc > 0 Then
                dDesc = Redondear(dSubtotal * (dPorc / 100), 2)
                dTotal = Redondear(dSubtotal - dDesc, 2)
            Else
                dPorc = 0
                dDesc = 0
                dTotal = dSubtotal
            End If
        Else
            dPorc = 0
            dDesc = 0
            dTotal = dSubtotal
        End If
        txtPorc.Text = dPorc
        txtDesc.Text = dDesc
        TxtTotal.Text = dTotal


    End Sub

    Private Sub txtDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesc.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                e.Handled = True
                SendKeys.Send("{TAB}")
        End Select
    End Sub



    Private Sub txtDesc_Leave(sender As Object, e As EventArgs) Handles txtDesc.Leave
        dDesc = Math.Abs(CDbl(txtDesc.Text))
        If dSubtotal > 0 Then
            If dDesc > 0 Then
                dPorc = Redondear((dDesc * 100) / dSubtotal, 2)
                dTotal = Redondear(dSubtotal - dDesc, 2)

            Else
                dPorc = 0
                dDesc = 0
                dTotal = dSubtotal
            End If
        Else
            dPorc = 0
            dDesc = 0
            dTotal = dSubtotal
        End If
        txtPorc.Text = dPorc
        txtDesc.Text = dDesc
        TxtTotal.Text = dTotal
    End Sub

    Private Sub TxtBusqueda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBusqueda.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtBusqueda.Text = vbNullString Then
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    CargaDatosCliente(dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                Else
                    MessageBox.Show("No se encontro registro que coincida con la clave proporcionada", "Información", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub

    Private Sub dtFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtFinal.ValueChanged
        If bload = True AndAlso (Fin <> dtFinal.Value) Then
            If dtFinal.Value < Inicio Then
                dtFinal.Value = Inicio
            End If

            Fin = dtFinal.Value

            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub btnNotaCredito_Click(sender As Object, e As EventArgs) Handles btnNotaCredito.Click
        Dim dtDevolucion As DataTable = ModPOS.Recupera_Tabla("st_nc_pendientes")
        If dtDevolucion.Rows.Count > 0 Then

            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim frmStatusMessage As New frmStatus
            Dim i As Integer
            For i = 0 To dtDevolucion.Rows.Count - 1

                frmStatusMessage.Show("Generando CFD: " & dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")) & ". Procesando: " & CStr(i + 1) & "/" & CStr(dtDevolucion.Rows.Count))
                frmStatusMessage.BringToFront()

                ModPOS.regenerarCFD(dtDevolucion.Rows(i)("TipoCF"), dtDevolucion.Rows(i)("NCClave"), SUCClave)

                ModPOS.crearXML(2, dtPAC, PathXML, dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")), dtDevolucion.Rows(i)("NCClave"), dtDevolucion.Rows(i)("tipoCertificado"), Nothing, Nothing, Nothing, dtDevolucion.Rows(i)("Tipo"), InterfazSalida)
            Next
            frmStatusMessage.Dispose()
        End If
    End Sub
End Class
