Public Class FrmPedido
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
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBusquedaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As Selling.StoreCombo
    Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents lblNivelDesc As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFechaPrevista As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPedido))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblNivelDesc = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.cmbTipo = New Selling.StoreCombo()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.TxtVendedor = New System.Windows.Forms.TextBox()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.BtnBusquedaProducto = New Janus.Windows.EditControls.UIButton()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.cmbAccion = New System.Windows.Forms.ComboBox()
        Me.cmbMotivo = New Selling.StoreCombo()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFechaPrevista = New System.Windows.Forms.DateTimePicker()
        Me.GrpCliente.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(789, 519)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(693, 519)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar sin guardar cambios"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.dtFechaPrevista)
        Me.GrpCliente.Controls.Add(Me.Label4)
        Me.GrpCliente.Controls.Add(Me.BtnConsultar)
        Me.GrpCliente.Controls.Add(Me.lblStatus)
        Me.GrpCliente.Controls.Add(Me.lblNivelDesc)
        Me.GrpCliente.Controls.Add(Me.Label5)
        Me.GrpCliente.Controls.Add(Me.cmbTipoCanal)
        Me.GrpCliente.Controls.Add(Me.lblSaldo)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.txtSaldo)
        Me.GrpCliente.Controls.Add(Me.txtLimite)
        Me.GrpCliente.Controls.Add(Me.txtDias)
        Me.GrpCliente.Controls.Add(Me.btnCliente)
        Me.GrpCliente.Controls.Add(Me.LblTipoCambio)
        Me.GrpCliente.Controls.Add(Me.cmbEstado)
        Me.GrpCliente.Controls.Add(Me.cmbTipo)
        Me.GrpCliente.Controls.Add(Me.TxtFolio)
        Me.GrpCliente.Controls.Add(Me.TxtVendedor)
        Me.GrpCliente.Controls.Add(Me.BtnTC)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtFecha)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.Label12)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.TxtCliente)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Location = New System.Drawing.Point(12, 4)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(867, 152)
        Me.GrpCliente.TabIndex = 121
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "General"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(773, 117)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(87, 30)
        Me.BtnConsultar.TabIndex = 128
        Me.BtnConsultar.Text = "Rechazos"
        Me.BtnConsultar.ToolTipText = "Consultar rechazados"
        Me.BtnConsultar.Visible = False
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Enabled = False
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(10, 19)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(379, 15)
        Me.lblStatus.TabIndex = 127
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNivelDesc
        '
        Me.lblNivelDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNivelDesc.Location = New System.Drawing.Point(519, 124)
        Me.lblNivelDesc.Name = "lblNivelDesc"
        Me.lblNivelDesc.Size = New System.Drawing.Size(248, 17)
        Me.lblNivelDesc.TabIndex = 126
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(412, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "Tipo Canal"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.Enabled = False
        Me.cmbTipoCanal.ItemHeight = 13
        Me.cmbTipoCanal.Location = New System.Drawing.Point(499, 68)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(204, 21)
        Me.cmbTipoCanal.TabIndex = 124
        '
        'lblSaldo
        '
        Me.lblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSaldo.Location = New System.Drawing.Point(339, 124)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(40, 17)
        Me.lblSaldo.TabIndex = 122
        Me.lblSaldo.Text = "Saldo"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(197, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Dias de Crédito"
        '
        'txtSaldo
        '
        Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(395, 121)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(107, 20)
        Me.txtSaldo.TabIndex = 119
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.Value = 0.0R
        Me.txtSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtLimite
        '
        Me.txtLimite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLimite.Enabled = False
        Me.txtLimite.Location = New System.Drawing.Point(102, 121)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(89, 20)
        Me.txtLimite.TabIndex = 117
        Me.txtLimite.Text = "0.00"
        Me.txtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimite.Value = 0.0R
        Me.txtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtDias
        '
        Me.txtDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDias.Enabled = False
        Me.txtDias.Location = New System.Drawing.Point(285, 121)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(48, 20)
        Me.txtDias.TabIndex = 118
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDias.Value = 0
        Me.txtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'btnCliente
        '
        Me.btnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCliente.Enabled = False
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCliente.Location = New System.Drawing.Point(275, 93)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(58, 24)
        Me.btnCliente.TabIndex = 116
        Me.btnCliente.ToolTipText = "Busqueda de Producto"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.Location = New System.Drawing.Point(773, 68)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(88, 15)
        Me.LblTipoCambio.TabIndex = 115
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.Location = New System.Drawing.Point(636, 41)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(131, 21)
        Me.cmbEstado.TabIndex = 114
        '
        'cmbTipo
        '
        Me.cmbTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.Location = New System.Drawing.Point(499, 41)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(131, 21)
        Me.cmbTipo.TabIndex = 113
        '
        'TxtFolio
        '
        Me.TxtFolio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFolio.Enabled = False
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(81, 42)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.ReadOnly = True
        Me.TxtFolio.Size = New System.Drawing.Size(186, 21)
        Me.TxtFolio.TabIndex = 112
        '
        'TxtVendedor
        '
        Me.TxtVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtVendedor.Enabled = False
        Me.TxtVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendedor.Location = New System.Drawing.Point(81, 68)
        Me.TxtVendedor.Multiline = True
        Me.TxtVendedor.Name = "TxtVendedor"
        Me.TxtVendedor.ReadOnly = True
        Me.TxtVendedor.Size = New System.Drawing.Size(308, 21)
        Me.TxtVendedor.TabIndex = 3
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Enabled = False
        Me.BtnTC.Location = New System.Drawing.Point(773, 38)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(88, 28)
        Me.BtnTC.TabIndex = 110
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(412, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Tipo/Estado"
        '
        'TxtFecha
        '
        Me.TxtFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(273, 42)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.ReadOnly = True
        Me.TxtFecha.Size = New System.Drawing.Size(116, 21)
        Me.TxtFecha.TabIndex = 94
        '
        'lblRFC
        '
        Me.lblRFC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRFC.Location = New System.Drawing.Point(7, 99)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "Cliente"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(7, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Atendio"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(7, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 15)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Folio/Fecha"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(337, 94)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(523, 21)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCliente.Location = New System.Drawing.Point(81, 94)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(186, 21)
        Me.TxtCliente.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(7, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Limite de Crédito"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtProducto.Location = New System.Drawing.Point(383, 19)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(141, 21)
        Me.TxtProducto.TabIndex = 0
        '
        'BtnBusquedaProducto
        '
        Me.BtnBusquedaProducto.Image = CType(resources.GetObject("BtnBusquedaProducto.Image"), System.Drawing.Image)
        Me.BtnBusquedaProducto.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaProducto.Location = New System.Drawing.Point(531, 17)
        Me.BtnBusquedaProducto.Name = "BtnBusquedaProducto"
        Me.BtnBusquedaProducto.Size = New System.Drawing.Size(58, 24)
        Me.BtnBusquedaProducto.TabIndex = 1
        Me.BtnBusquedaProducto.ToolTipText = "Busqueda de Producto"
        Me.BtnBusquedaProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblCantidad
        '
        Me.lblCantidad.Location = New System.Drawing.Point(170, 24)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(53, 15)
        Me.lblCantidad.TabIndex = 24
        Me.lblCantidad.Text = "Cantidad"
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.cmbAccion)
        Me.GrpDetalle.Controls.Add(Me.cmbMotivo)
        Me.GrpDetalle.Controls.Add(Me.lblProducto)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Controls.Add(Me.BtnBusquedaProducto)
        Me.GrpDetalle.Controls.Add(Me.lblCantidad)
        Me.GrpDetalle.Location = New System.Drawing.Point(12, 162)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(867, 351)
        Me.GrpDetalle.TabIndex = 0
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'cmbAccion
        '
        Me.cmbAccion.FormattingEnabled = True
        Me.cmbAccion.Items.AddRange(New Object() {"Quitar", "Agregar"})
        Me.cmbAccion.Location = New System.Drawing.Point(7, 19)
        Me.cmbAccion.Name = "cmbAccion"
        Me.cmbAccion.Size = New System.Drawing.Size(149, 21)
        Me.cmbAccion.TabIndex = 138
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.Location = New System.Drawing.Point(654, 18)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(207, 21)
        Me.cmbMotivo.TabIndex = 130
        '
        'lblProducto
        '
        Me.lblProducto.Location = New System.Drawing.Point(324, 23)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(53, 15)
        Me.lblProducto.TabIndex = 98
        Me.lblProducto.Text = "Producto"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(229, 20)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 2
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 47)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(854, 296)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(412, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 15)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "F. Prevista"
        '
        'dtFechaPrevista
        '
        Me.dtFechaPrevista.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaPrevista.Location = New System.Drawing.Point(499, 11)
        Me.dtFechaPrevista.Name = "dtFechaPrevista"
        Me.dtFechaPrevista.Size = New System.Drawing.Size(131, 20)
        Me.dtFechaPrevista.TabIndex = 130
        '
        'FrmPedido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmPedido"
        Me.Text = "Pedido"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String = "Modificar"
    Public FormPadre As String = "CAJA"
    Public Imprimir As Boolean = False
    Public StageSurtido As String = ""
    Public FormatoPedido As String
    Public sImpresora As String = ""
    Public Generic As Boolean = False

    Private fechaPrevista As Date = Today.Date
    Private FechaPedido As Date = Today.Date

    Private Moneda As String = ""
    Private CTEClaveActual As String = ""
    Private CTEClaveInicial As String = ""
    Private PDVClave As String = ""
    Private LimitaCompraEmp As Integer = 0

    Private Referencia As String = ""
    Private TipoCanal As Integer = 0
    Private bError As Boolean = False
    Public VENClave As String = ""
    Public CAJClave As String

    Private SUCClave As String
    Private ALMClave As String
    Private StageLU, StageCancelacion As String

    Private MaskCte As Integer = 0
    Private TallaColor As Integer = 0
    'Private CTECLave As String
    Private ListaPrecio As String
    Private TImpuesto As Integer
    Private EstadoDocumento As Integer
    Private Cantidad As Double
    Private MONClave As String
    Private TipoCambio As Double
    Private TipoDocumento As Integer
    Private dtCombo As DataTable

    Private dtDetalle, dtTipoRechazo As DataTable

    Private TotalAnterior, TotalNuevo As Decimal

    Private CtaMaestra As String
    Private LimiteCredito As Decimal
    Private DiasCredito As Integer
    Private SaldoCte As Decimal

    Private Folio, Periodo, Mes As Integer

    Private Sub ObtenerFolio()
        Dim dt As DataTable
        dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 1, "@PDVClave", PDVClave)
            Folio = 1
            Periodo = Today.Year
            Mes = Today.Month
        Else
            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 1, "@PDVClave", PDVClave, "@Incremento", 1)
            dt.Dispose()
        End If

        TxtFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)

    End Sub


    Private Function recuperaCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al intentar cargar información de domicilios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If CInt(dt.Rows(0)("Estado")) = 0 Then
            MessageBox.Show("Error al intentar cargar información del cliente, ya que se encuentra Inactivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        CTEClaveActual = sCTEClave
        CtaMaestra = dt.Rows(0)("CtaMaestra")
        TxtCliente.Text = dt.Rows(0)("Clave")
        TxtRazonSocial.Text = dt.Rows(0)("RazonSocial")
        lblNivelDesc.Text = IIf(dt.Rows(0)("NivelDesc").GetType.Name = "DBNull", "", dt.Rows(0)("NivelDesc"))
        LimiteCredito = dt.Rows(0)("LimiteCredito")
        DiasCredito = dt.Rows(0)("DiasCredito")
        SaldoCte = dt.Rows(0)("Saldo")
        dt.Dispose()

        Dim dtCliente As DataTable
        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTEClaveActual, "@TipoCanal", TipoCanal)
        ListaPrecio = dtCliente.Rows(0)("PREClave")
        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
        dtCliente.Dispose()


        Dim foundRows() As System.Data.DataRow
        dt = Recupera_Tabla("sp_recupera_domiciliocte", "@CTEClave", sCTEClave)
        foundRows = dt.Select("TImpuesto <> " & CStr(TImpuesto))

        If CTEClaveActual <> CtaMaestra Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CtaMaestra)
            LimiteCredito = dt.Rows(0)("LimiteCredito")
            DiasCredito = dt.Rows(0)("DiasCredito")
            SaldoCte = dt.Rows(0)("Saldo")
            dt.Dispose()
        End If

        txtLimite.Text = LimiteCredito
        txtDias.Text = DiasCredito
        txtSaldo.Text = SaldoCte

        If CTEClaveActual = CTEClaveInicial Then
            txtSaldo.Visible = False
            lblSaldo.Visible = False
        Else
            txtSaldo.Visible = True
            lblSaldo.Visible = True
        End If

        Return True
    End Function

    Private Function cambiaCliente(ByVal sCTEClave As String) As Boolean

        If PDVClave = "" OrElse PDVClave Is Nothing Then
            Beep()
            MessageBox.Show("No es posible realizar una venta ya que no existe un punto de venta asociado a la caja actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If ALMClave = "" OrElse ALMClave Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbTipoCanal.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If dtDetalle.Rows.Count = 0 OrElse TotalNuevo = 0 Then

            ModPOS.Ejecuta("st_elimina_envio", "@VENClave", VENClave)

            If recuperaCliente(sCTEClave) = False Then
                Return False
            End If

            If LimiteCredito > 0 Then

                'Valida condiciones de credito

                Dim iValidaCredito As Integer
                Dim bCreditoValido As Boolean = False

                iValidaCredito = ModPOS.ValidaCredido(CtaMaestra, LimiteCredito, DiasCredito, 0, TipoCambio)

                If iValidaCredito = 0 Then
                    bCreditoValido = False
                ElseIf iValidaCredito = -1 Then
                    Dim CreditoDisponible As Decimal = ModPOS.recuperaDatosCredito(CtaMaestra)
                    If CreditoDisponible = 0 Then
                        bCreditoValido = False
                    End If
                    If DiasCredito <= 0 Then
                        bCreditoValido = False
                    End If
                End If


                If bCreditoValido = True Then
                    TipoDocumento = 3
                Else
                    MessageBox.Show("No se cumplieron las condiciones para crear una venta a Crédito", "Pregunta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TipoDocumento = 1
                End If

            Else
                TipoDocumento = 1
            End If

            EstadoDocumento = 1

            'Crea Venta Cerrada
            If VENClave = "" Then

                ObtenerFolio()

                VENClave = ModPOS.obtenerLlave()

                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
                If dt.Rows.Count = 1 Then
                    VENClave = ModPOS.obtenerLlave
                End If
                dt.Dispose()

                ModPOS.Ejecuta("st_crea_venta_cerrada", _
                "@VENClave", VENClave, _
                "@PDVClave", PDVClave, _
                "@Folio", TxtFolio.Text, _
                "@Cliente", CTEClaveActual, _
                "@Cajero", ModPOS.UsuarioActual, _
                "@CAJClave", CAJClave, _
                "@Tipo", TipoDocumento, _
                "@ALMClave", ALMClave, _
                 "@TipoCanal", cmbTipoCanal.SelectedValue, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@MONClave", MONClave, _
                "@TipoCambio", TipoCambio)

            Else
                'Actualiza Venta Cerrada

                ModPOS.Ejecuta("st_actualiza_venta_cerrada", _
                            "@VENClave", VENClave, _
                            "@Cliente", CTEClaveActual, _
                            "@Tipo", TipoDocumento, _
                            "@Usuario", ModPOS.UsuarioActual)
            End If

            modificaStatus(TipoDocumento, EstadoDocumento)


            TxtProducto.Focus()

            Return True
        Else
            MessageBox.Show("No es posible cambiar al cliente debido a que ya que el pedido actual cuenta con productos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If
    End Function

    Public Function AgregaGTIN(ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, Optional ByVal dCant As Decimal = 0, Optional ByVal bShortCut As Boolean = False, Optional ByVal sDVEClave As String = "", Optional ByVal PREClaveKIT As String = "", Optional ByVal PrecioBrutoKIT As Decimal = 0, Optional ByVal IdKit As String = "", Optional ByVal PROClaveKIT As String = "", Optional ByVal sCombo As String = "") As Boolean
        Dim backToSearch As Boolean
        backToSearch = leeCodigoBarras(Codigo, Suma, Busca, bShortCut, sDVEClave, dCant, PREClaveKIT, PrecioBrutoKIT, IdKit, PROClaveKIT, sCombo)
        Return backToSearch
    End Function

    Private Sub FrmPedido_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Me.DialogResult <> System.Windows.Forms.DialogResult.OK Then

            CancelaProducto()
        End If

        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub cambiaStatus(ByVal Texto As String, ByVal Status As Integer)
        Select Case Status
            Case 1
                lblStatus.BackColor = Color.Green
                lblStatus.ForeColor = Color.White
                lblStatus.Text = Texto

            Case 2
                lblStatus.BackColor = Color.Red
                lblStatus.ForeColor = Color.White
                lblStatus.Text = Texto

            Case 3
                lblStatus.BackColor = Color.LightBlue
                lblStatus.ForeColor = Color.Black
                lblStatus.Text = Texto

            Case 4
                lblStatus.BackColor = Color.Black
                lblStatus.ForeColor = Color.White
                lblStatus.Text = Texto

            Case 6
                lblStatus.BackColor = Color.Green
                lblStatus.ForeColor = Color.White
                lblStatus.Text = Texto

            Case 7
                lblStatus.BackColor = Color.Orange
                lblStatus.ForeColor = Color.Black
                lblStatus.Text = Texto
            Case 9
                lblStatus.BackColor = Color.Black
                lblStatus.ForeColor = Color.White
                lblStatus.Text = Texto
        End Select
    End Sub

    Private Sub modificaStatus(ByVal iTipoDocumento As Integer, ByVal Status As Integer)

        Dim sTexto As String = ""

        Select Case Status
            Case 1
                sTexto = "ABIERTA"
            Case 2
                sTexto = "CERRADA"
            Case 3
                sTexto = "PAGADA"
            Case 4
                sTexto = "CANCELADA"
            Case 6
                sTexto = "ABIERTA"
            Case 7
                sTexto = "PICKING"
            Case 9
                sTexto = "REMOTO"
            Case 11
                sTexto = "BACKORDER"
        End Select

        Select Case iTipoDocumento
            Case 1
                cambiaStatus("VTA. CONTADO (" & sTexto & ")", Status)
            Case 2
                cambiaStatus("COTIZACIÓN (" & sTexto & ")", Status)
            Case 3
                cambiaStatus("VTA. CRÉDITO (" & sTexto & ")", Status)
            Case 4
                cambiaStatus("APARTADO (" & sTexto & ")", Status)
        End Select

    End Sub

    Private Sub FrmPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer
        Dim dt As DataTable


        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me

            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "LimitaCompraEmp"
                        LimitaCompraEmp = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "MascaraCte"
                        MaskCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With

        dtTipoRechazo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Surtido", "@Campo", "TipoRechazo")
        With cmbMotivo
            .dt = dtTipoRechazo
            .llenar()
        End With

        With cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With cmbEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Venta"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With

        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        StageLU = IIf(dt.Rows(0)("StageLU").GetType.Name = "DBNull", "", dt.Rows(0)("StageLU"))
        StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name = "DBNull", "", dt.Rows(0)("StageCancelacion"))
        SUCClave = dt.Rows(0)("SUCClave")
        ALMClave = dt.Rows(0)("ALMClave")
        dt.Dispose()


        If Padre = "Nuevo" Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            CTEClaveInicial = IIf(dt.Rows(0)("Mostrador").GetType.Name <> "DBNull", dt.Rows(0)("Mostrador"), "")
            PDVClave = IIf(dt.Rows(0)("PDVClave").GetType.Name <> "DBNull", dt.Rows(0)("PDVClave"), "")
            dt.Dispose()
            EstadoDocumento = 1
            TotalAnterior = 0
            TotalNuevo = 0

            TxtCliente.Enabled = True
            btnCliente.Enabled = True


            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            BtnTC.Text = dt.Rows(0)("Referencia")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
            dt.Dispose()

            MONClave = Moneda


            If PDVClave <> "" Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_puntodeventa", "@PDVClave", PDVClave)
                Referencia = dt.Rows(0)("Referencia")
                TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                dt.Dispose()
            End If

            cmbTipoCanal.SelectedValue = TipoCanal

            If TallaColor = 0 Then
                CTEClaveActual = CTEClaveInicial
                cambiaCliente(CTEClaveActual)
            End If

            cmbAccion.SelectedItem = "Agregar"

        Else
            dt = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", VENClave)

            TipoCanal = dt.Rows(0)("TipoCanal")
            TxtFolio.Text = dt.Rows(0)("Folio")
            FechaPedido = CDate(dt.Rows(0)("Fecha"))
            TxtFecha.Text = FechaPedido.ToShortDateString
            TxtVendedor.Text = dt.Rows(0)("NombreUsuario")
            TipoDocumento = dt.Rows(0)("Tipo")
            cmbTipo.SelectedValue = TipoDocumento
            EstadoDocumento = dt.Rows(0)("Estado")
            cmbEstado.SelectedValue = EstadoDocumento
            CTEClaveActual = dt.Rows(0)("Cliente")
            MONClave = dt.Rows(0)("MONClave")
            TipoCambio = dt.Rows(0)("TipoCambio")
            TotalAnterior = dt.Rows(0)("Total") * TipoCambio
            cmbTipoCanal.SelectedValue = TipoCanal

            Dim dtMon As DataTable = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MONClave)
            BtnTC.Text = dtMon.Rows(0)("Referencia")
            dtMon.Dispose()
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")

            dt.Dispose()

            recuperaCliente(CTEClaveActual)

            BtnConsultar.Visible = True

            modificaStatus(TipoDocumento, EstadoDocumento)

            cmbAccion.SelectedItem = "Quitar"

            dt = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

            If dt.Rows.Count > 0 Then
                fechaPrevista = dt.Rows(0)("fechaPrevista")

            Else
                fechaPrevista = FechaPedido
            End If

            dtFechaPrevista.Value = fechaPrevista

        End If

            dtCombo = ModPOS.CrearTabla("Combo", _
                              "Clave", "System.String", _
                              "Cantidad", "System.Decimal", _
                               "Precio", "System.Decimal", _
                               "PREClave", "System.String"
                              )


            If StageLU = "" OrElse StageCancelacion = "" Then
                MessageBox.Show("La Caja Actual no cuenta con Ubicación de Libre Utilización o de Cancelación Asociada.")
                bError = False
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If

            dtDetalle = ModPOS.Recupera_Tabla("st_muestra_ventaDet", "@VENClave", VENClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.RootTable.Columns("DVEClave").Visible = False
            GridDetalle.RootTable.Columns("Nuevo").Visible = False
            GridDetalle.RootTable.Columns("KgLt").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("PorcDesc").Visible = False
            GridDetalle.RootTable.Columns("GrupoMaterial").Visible = False
            GridDetalle.RootTable.Columns("Sector").Visible = False
            GridDetalle.RootTable.Columns("IdKIT").Visible = False

            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("Precio Unitario").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Dscto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Impuesto").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"

            GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            GridDetalle.RootTable.Columns("Subtotal").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Dscto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Impuesto").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Cantidad").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Cancelar").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum


            GridDetalle.RootTable.Columns("Subtotal").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Dscto").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Impuesto").TotalFormatString = "c"
            GridDetalle.RootTable.Columns("Total").TotalFormatString = "c"

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Nuevo"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)
            fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
            GridDetalle.RootTable.FormatConditions.Add(fc)

            GridDetalle.CurrentTable.Columns("TipoRechazo").HasValueList = True
            Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
            AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("TipoRechazo").ValueList
            With AircraftTypeValueListItemCollection

                For i = 0 To dtTipoRechazo.Rows.Count - 1
                    .Add(dtTipoRechazo.Rows(i)("valor"), dtTipoRechazo.Rows(i)("descripcion"))
                Next

            End With
            GridDetalle.CurrentTable.Columns("TipoRechazo").EditType = Janus.Windows.GridEX.EditType.Combo

            If EstadoDocumento = 4 Then
                GrpDetalle.Enabled = False
            End If

            If StageSurtido <> "" Then
                cmbAccion.Enabled = False
                cmbMotivo.Visible = True
            End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If EstadoDocumento <> 4 Then

            If StageSurtido <> "" Then
                StageCancelacion = StageSurtido
            End If

            Dim dt As DataTable
            Dim i As Integer
            Dim ImporteCancelar As Decimal = 0
            Dim foundRows() As System.Data.DataRow


            foundRows = dtDetalle.Select("Cancelar > 0 and (TipoRechazo = 0 or TipoRechazo is Null)")
            If foundRows.GetLength(0) > 0 Then
                MessageBox.Show("No se ha especificado tipo de Rechazo de la mercancia devuelta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            foundRows = dtDetalle.Select("Cancelar >  0 ")

            'Cancela producto
            If foundRows.Length >= 1 Then

                For i = 0 To foundRows.Length - 1
                    ImporteCancelar += foundRows(i)("Cancelar") * foundRows(i)("Precio Unitario")
                Next


                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.sp = "st_filtra_devoluciones"
                a.MontodeAutorizacion = 0
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado = True Then
                        Dim dtVentaDetalle As DataTable
                        Dim dtStage As DataTable
                        Dim stageAnt As String = StageCancelacion
                        For i = 0 To foundRows.Length - 1
                            If foundRows(i)("Nuevo") = 0 Then
                                ModPOS.Ejecuta("st_registra_negado_surtido", "@VENClave", VENClave, "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cancelar"), "@TipoRechazo", foundRows(i)("TipoRechazo"), "@Usuario", ModPOS.UsuarioActual)
                            End If
                            dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", 1, "@DOCClave", VENClave, "@PROClave", foundRows(i)("PROClave"))
                            recalculaPartidaPedido(dtVentaDetalle, VENClave, foundRows(i)("DVEClave"), foundRows(i)("Cantidad"), foundRows(i)("Cancelar"), foundRows(i)("KgLt"), foundRows(i)("UndKilo"))
                            dtStage = ModPOS.Recupera_Tabla("st_valida_stage_area", "@VENClave", VENClave, "@PROClave", foundRows(i)("PROClave"))
                            If dtStage.Rows.Count > 0 AndAlso Me.FormPadre = "SURTIDO" Then
                                StageCancelacion = dtStage.Rows(0)("Stage")
                            End If
                            ModPOS.Ejecuta("st_cancelar_producto_vta", "@VENClave", VENClave, "@ALMClave", ALMClave, "TProducto", foundRows(i)("TProducto"), "@PROClave", foundRows(i)("PROClave"), "@UBCClave", StageCancelacion, "@Cancelar", foundRows(i)("Cancelar"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual, "@Autoriza", a.Autoriza)
                            StageCancelacion = stageAnt
                        Next
                        ModPOS.Ejecuta("sp_elimina_detalle_picking", "@Tipo", 1, "@DOCClave", VENClave)
                        Imprimir = True
                    End If
                End If

            End If


            'AplicaPromociones
            ModPOS.Ejecuta("st_aplicar_promociones_cerrada", _
             "@SUCClave", SUCClave, _
             "@VENClave", VENClave, _
             "@Usuario", ModPOS.UsuarioActual)


            ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", 2, "@ActSaldo", 1)


            dt = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", VENClave)
            TotalNuevo = dt.Rows(0)("Total") * dt.Rows(0)("TipoCambio")
            dt.Dispose()


            If fechaPrevista <> dtFechaPrevista.Value Then
                ModPOS.Ejecuta("st_actualiza_fechaenvio", "@VENClave", VENClave, "@FechaPrevista", dtFechaPrevista.Value)
            End If

            If TotalAnterior > TotalNuevo Then
                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClaveActual, "@Importe", TotalAnterior - TotalNuevo)

            ElseIf TotalAnterior < TotalNuevo Then

                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", (TotalNuevo - TotalAnterior))


            End If


            If Imprimir = True AndAlso sImpresora <> "" AndAlso TotalNuevo > 0 Then
                Select Case MessageBox.Show("¿Desea imprimir el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        previewPedido(FormatoPedido, VENClave, TotalNuevo, SUCClave, sImpresora, True, 1, True, True, "", "", Generic)
                End Select
            ElseIf TotalNuevo = 0 Then
                Imprimir = False
            End If


        End If
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        'CancelaProducto()
        bError = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Cancelar" Then
            If IsNumeric(GridDetalle.GetValue("Cancelar")) AndAlso GridDetalle.GetValue("Nuevo") = 0 Then
                If CDbl(GridDetalle.GetValue("Cancelar")) > CDbl(GridDetalle.GetValue("Cantidad")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad a cancelar no de ser mayor a la actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Cancelar", GridDetalle.GetValue("Cantidad"))
                ElseIf CDbl(GridDetalle.GetValue("Cancelar")) < 0 Then
                    GridDetalle.SetValue("Cancelar", 0)
                End If
                If GridDetalle.GetValue("TipoRechazo") <> 0 AndAlso GridDetalle.GetValue("IdKIT") <> "" Then
                    Dim foundRows2() As System.Data.DataRow
                    foundRows2 = dtDetalle.Select("IdKIT = '" & GridDetalle.GetValue("IdKIT") & "'")
                    Dim x As Integer
                    For x = 0 To foundRows2.Length - 1
                        foundRows2(x)("Cancelar") = GridDetalle.GetValue("Cancelar")
                        foundRows2(x)("TipoRechazo") = GridDetalle.GetValue("TipoRechazo")
                    Next
                End If
            Else
                GridDetalle.SetValue("Cancelar", 0)
            End If
        ElseIf GridDetalle.CurrentColumn.Caption = "Tipo Rechazo" Then
            If GridDetalle.GetValue("Cancelar") > 0 AndAlso GridDetalle.GetValue("IdKIT") <> "" Then
                Dim foundRows2() As System.Data.DataRow
                foundRows2 = dtDetalle.Select("IdKIT = '" & GridDetalle.GetValue("IdKIT") & "'")
                Dim x As Integer
                For x = 0 To foundRows2.Length - 1
                    foundRows2(x)("Cancelar") = GridDetalle.GetValue("Cancelar")
                    foundRows2(x)("TipoRechazo") = GridDetalle.GetValue("TipoRechazo")
                Next
            End If
        End If



    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Cancelar" Then
                If GridDetalle.GetValue("Nuevo") = 0 Then
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                Else
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            ElseIf GridDetalle.CurrentColumn.Caption = "Tipo Rechazo" Then
                If GridDetalle.GetValue("Cancelar") > 0 Then
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                Else
                    GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridDetalle_FormattingRow(sender As Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridDetalle.FormattingRow
        Dim row As Janus.Windows.GridEX.GridEXRow = e.Row
        row.RowStyle = New Janus.Windows.GridEX.GridEXFormatStyle

        If row.Cells("Nuevo").Value = 0 Then
            row.RowStyle.ForeColor = Color.Gray
        Else
            row.RowStyle.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If
            TxtProducto.Focus()

        End If
    End Sub

    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) <= 0 Then
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            Else
                Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            Cantidad = 1
            TxtCantidad.Text = CStr(Cantidad)
        End If

        TxtProducto.Focus()
    End Sub

    Public Sub AgregarProducto(ByVal DVEClave As String, ByVal TProducto As Integer, ByVal PROClave As String, ByVal kglt As Integer, ByVal UnidadesKilo As Double, ByVal GrupoMaterial As Integer, ByVal Sector As Integer, ByVal Partida As Integer, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal ImpuestoPor As Decimal, ByVal Descuento As Decimal, ByVal IdKIT As String, ByVal Combo As String)
        Dim dBase, dImpts, dTotal, DescPor As Decimal

        dBase = Math.Round(Precio * Cantidad, 2)
        dImpts = Math.Round((dBase - Descuento) * ImpuestoPor, 2)
        dTotal = dBase - Descuento + dImpts

        DescPor = (Descuento / dBase) * 100

        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select(" DVEClave = '" & DVEClave & "'")

        If foundRows.Length = 1 Then

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If


            foundRows(0)("Nombre") = Nombre
            foundRows(0)("Cantidad") = Cantidad
            foundRows(0)("UndKilo") = UnidadesKilo

            foundRows(0)("Precio Unitario") = TruncateToDecimal(Precio, 2)
            foundRows(0)("Subtotal") = dBase
            foundRows(0)("PorcDesc") = TruncateToDecimal(DescPor, 2)
            foundRows(0)("Dscto") = Descuento
            foundRows(0)("Impuesto") = dImpts
            foundRows(0)("Total") = dTotal

            foundRows(0)("Nuevo") = foundRows(0)("Nuevo") + 1
            foundRows(0)("IdKIT") = IdKIT
            foundRows(0)("Combo") = Combo
        Else

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If

            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("DVEClave") = DVEClave
            row1.Item("TProducto") = TProducto
            row1.Item("KgLt") = kglt
            row1.Item("PROClave") = PROClave
            row1.Item("UndKilo") = UnidadesKilo
            row1.Item("GrupoMaterial") = GrupoMaterial
            row1.Item("Sector") = Sector
            row1.Item("Partida") = Partida
            row1.Item("Clave") = GTIN
            row1.Item("Nombre") = Nombre
            row1.Item("Cantidad") = Cantidad
            row1.Item("Cancelar") = 0
            row1.Item("TipoRechazo") = 0
            row1.Item("Precio Unitario") = TruncateToDecimal(Precio, 2)
            row1.Item("Subtotal") = dBase
            row1.Item("PorcDesc") = TruncateToDecimal(DescPor, 2)
            row1.Item("Dscto") = Descuento
            row1.Item("Impuesto") = dImpts
            row1.Item("Total") = dTotal
            row1.Item("IdKIT") = IdKIT
            row1.Item("Combo") = Combo
            row1.Item("Nuevo") = 1
            dtDetalle.Rows.Add(row1)
        End If

    End Sub


    Public Function AgregaPartida(ByVal dtProducto As DataTable, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalculaInventario As Boolean, ByVal bShortCut As Boolean, ByVal sIdKIT As String, ByVal sPREClaveKIT As String, ByVal sPROClaveKIT As String, ByVal sCombo As String) As Boolean

        If Not dtProducto Is Nothing Then
            Dim YaExiste As Boolean = False
            Dim DVEClave As String = ""
            Dim sAutoriza As String = Nothing
            Dim sSUCClave As String = dtProducto.Rows(0)("SUCClave")
            Dim sPROClave As String = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre")
            Dim dCosto As Decimal = dtProducto.Rows(0)("Costo") / TipoCambio
            Dim dCantidad As Decimal = dtProducto.Rows(0)("Cantidad")
            Dim dApartar As Decimal = dCantidad
            Dim dPrecioUnitario As Decimal = dtProducto.Rows(0)("PrecioBruto") / TipoCambio
            Dim dDescPorc As Decimal = dtProducto.Rows(0)("DescPorc")
            Dim dDescGeneralPor As Decimal = dtProducto.Rows(0)("DescGeneral")

            Dim iTProducto As Integer = dtProducto.Rows(0)("TProducto")
            Dim iSeguimiento As Integer = dtProducto.Rows(0)("Seguimiento")
            Dim iDiasGarantia As Integer = dtProducto.Rows(0)("DiasGarantia")
            Dim iNumDecimales As Integer = dtProducto.Rows(0)("Num_Decimales")

            Dim dGeneralNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("PrecioNeto") / TipoCambio, 6)
            Dim dMinimoNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("MinimoNeto") / TipoCambio, 6)

            Dim iKgLt As Integer = IIf(dtProducto.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("KgLt"))
            Dim dPeso As Decimal = IIf(dtProducto.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("Peso"))
            Dim bVtaPaquete As Boolean = dtProducto.Rows(0)("vtaPaquete")

            dtProducto.Dispose()

            If dCantidad <= 0 Then
                TxtProducto.Text = ""
                Cantidad = 1
                TxtCantidad.Text = "1"
                MessageBox.Show("El producto " & sClave & " no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If dPrecioUnitario = 0 Then
                MessageBox.Show("El producto " & sClave & " no cuenta con precio definido en la lista de precios actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Dim Disponible, Existencia, Apartado, Bloqueado As Double
            Dim dtDisponible As DataTable
            dtDisponible = ModPOS.SiExisteRecupera("st_recupera_peu", "@PROClave", sPROClave, "@UBCClave", StageLU)
            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Existencia = dtDisponible.Rows(0)("Existencia")
                Apartado = dtDisponible.Rows(0)("Apartado")
                Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                dtDisponible.Dispose()

                Disponible = Existencia - Apartado - Bloqueado
            Else
                Disponible = 0
            End If

            If dCantidad > Disponible Then
                MessageBox.Show("El producto " & sClave & " no cuenta con existencia disponible en la ubicación de Caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If


            'Aparta producto en Ubicacion de Caja

            ModPOS.Ejecuta("st_act_existencia_pue", _
                          "@VENClave", VENClave,
                          "@ALMClave", ALMClave, _
                          "@UBCClave", StageLU, _
                          "@PROClave", sPROClave, _
                          "@TProducto", iTProducto, _
                          "@Cantidad", dCantidad, _
                          "@Usuario", ModPOS.UsuarioActual
                           )


            Dim UnidadesKilo As Double

            If iKgLt = 1 Then
                If dPeso > 0 Then
                    UnidadesKilo = dCantidad / dPeso
                Else
                    UnidadesKilo = 1
                End If
            Else
                UnidadesKilo = 0
            End If

            Dim iGrupoMaterial As Integer = 0
            Dim iSector As Integer = 0
            Dim iPartida As Integer
            Dim dVolumen As Decimal = 0
            Dim dVolumenImp As Decimal = 0
            Dim PorcImpProducto As Decimal = ModPOS.RecuperaImpuesto(sSUCClave, sPROClave, TImpuesto)

            'Recupera GrupoMaterial
            dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 1, "@PROClave", sPROClave) 'GrupoMaterial
            If dtProducto.Rows.Count = 1 Then
                iGrupoMaterial = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
            End If
            dtProducto.Dispose()
            'Recupera Sector
            dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 3, "@PROClave", sPROClave) 'Sector
            If dtProducto.Rows.Count = 1 Then
                iSector = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
            End If
            dtProducto.Dispose()

            Dim dOriginal As Decimal

            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select(" PROClave = '" & sPROClave & "'")

            If foundRows.Length = 1 Then
                YaExiste = True
                DVEClave = foundRows(0)("DVEClave")

                dOriginal = foundRows(0)("Cantidad")

                If Suma = True Then
                    dCantidad += foundRows(0)("Cantidad")
                    UnidadesKilo += foundRows(0)("UndKilo")
                ElseIf bShortCut = False Then
                    dCantidad = foundRows(0)("Cantidad")
                    UnidadesKilo = foundRows(0)("UndKilo")
                End If

                dPrecioUnitario = foundRows(0)("Precio Unitario")

                If foundRows(0)("PorcDesc") > 0 Then
                    Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", DVEClave)
                    If Not dtDescuento Is Nothing Then
                        'Descuento General
                        foundRows = dtDescuento.Select(" Tipo = 1 ")
                        If foundRows.Length = 1 Then
                            dDescGeneralPor = foundRows(0)("DescuentoPorc") * 100
                        End If

                        'Descuento Volumen
                        foundRows = dtDescuento.Select(" Tipo = 2")
                        If foundRows.Length = 1 Then
                            dVolumen = foundRows(0)("DescuentoPorc") * 100
                        End If


                        'Descuento Gerencial
                        foundRows = dtDescuento.Select(" Tipo = 3 ")
                        If foundRows.Length = 1 Then
                            dDescPorc = foundRows(0)("DescuentoPorc") * 100
                        End If
                        dtDescuento.Dispose()
                    End If
                End If
            Else
                YaExiste = False
                dOriginal = 0
            End If

            Dim oVolumen As Decimal = dVolumen

            Dim StrucVol As DescVol
            Dim sTipoDesc As String

            Dim dBase As Decimal

            dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

            Dim dDescGeneralImp As Decimal = Math.Round(dBase * (dDescGeneralPor / 100), 2)

            StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, sPROClave, dBase - dDescGeneralImp, True)

            dVolumen = StrucVol.Descuento
            sTipoDesc = StrucVol.Tipo

            If dVolumen > 0 Then
                dVolumenImp = Math.Round((dBase - dDescGeneralImp) * (dVolumen / 100), 2)
            Else
                dVolumenImp = 0
            End If

            Dim dDescuentoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * (dDescPorc / 100), 2)
            Dim dImpuestoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * PorcImpProducto, 2)

            Dim dImporteNeto As Decimal = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


            'Modifica pedido

            If YaExiste Then

                'Actualiza Cantidad de producto
                'IIf(dOriginal >= dCantidad, dCantidad, dCantidad - dOriginal), _
                ModPOS.Ejecuta("sp_actualiza_detalle", _
                "@ALMClave", ALMClave, _
                "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@PrecioBruto", dPrecioUnitario, _
                "@Cantidad", dCantidad, _
                "@Importe", dBase, _
                "@DescGenPor", dDescGeneralPor / 100, _
                "@DescGenImp", dDescGeneralImp, _
                "@DescVolPor", dVolumen / 100, _
                "@DescVolImp", dVolumenImp, _
                "@DescuentoPor", dDescPorc / 100, _
                "@DescuentoImp", dDescuentoImp, _
                "@ImpuestoImp", dImpuestoImp, _
                "@TProducto", iTProducto, _
                "@TipoDoc", TipoDocumento, _
                "@Picking", Picking, _
                "@UndKilo", UnidadesKilo, _
                "@DVEClave", DVEClave, _
                "@PorcImp", PorcImpProducto, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@TipoDesc", sTipoDesc, _
                "@Autoriza", sAutoriza, _
                "@Total", dImporteNeto, _
                "@PREClaveKIT", sPREClaveKIT, _
                "@IdKIT", sIdKIT, _
                "@PROClaveKIT", sPROClaveKIT, _
                "@Cerrado", 1)

                Dim dtDet As DataTable
                dtDet = ModPOS.SiExisteRecupera("st_vent_det_closed", "@DVEClave", DVEClave)
                If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                    ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                    dtDet.Dispose()
                End If


            Else
                'Inserta Producto
                DVEClave = ModPOS.obtenerLlave

                If dtDetalle.Compute("MAX(Partida)", "").GetType.FullName = "System.DBNull" Then
                    iPartida = 10
                Else
                    iPartida = CInt(dtDetalle.Compute("MAX(Partida)", "")) + 10
                End If

                ModPOS.Ejecuta("sp_inserta_detalle", _
                "@DVEClave", DVEClave, _
                "@VENTA", VENClave, _
                "@PROClave", sPROClave, _
                "@Costo", dCosto, _
                "@PREClave", ListaPrecio, _
                "@PrecioBruto", dPrecioUnitario, _
                "@Cantidad", dCantidad, _
                "@Importe", dBase, _
                "@DescGenPor", dDescGeneralPor / 100, _
                "@DescGenImp", dDescGeneralImp, _
                "@DescVolPor", dVolumen / 100, _
                "@DescVolImp", dVolumenImp, _
                "@DescuentoPor", dDescPorc / 100, _
                "@DescuentoImp", dDescuentoImp, _
                "@PorcImp", PorcImpProducto, _
                "@ImpuestoImp", dImpuestoImp, _
                "@Total", dImporteNeto, _
                "@ALMClave", ALMClave, _
                "@TipoDoc", TipoDocumento, _
                "@TProducto", iTProducto, _
                "@Picking", Picking, _
                "@Autoriza", sAutoriza, _
                "@UndKilo", UnidadesKilo, _
                "@GrupoMaterial", iGrupoMaterial, _
                "@Sector", iSector, _
                "@Partida", iPartida, _
                "@TipoDesc", sTipoDesc, _
                "@Usuario", ModPOS.UsuarioActual,
                "@PREClaveKIT", sPREClaveKIT, _
                "@IdKIT", sIdKIT, _
                "@PROClaveKIT", sPROClaveKIT, _
                "@Cerrado", 1)

                If iPartida = 10 Then
                    ModPOS.Ejecuta("st_actualiza_canal_vta", "@VENClave", VENClave, "@TipoCanal", TipoCanal)
                End If

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaImpuesto(DVEClave, sPROClave, (dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp), TImpuesto, sSUCClave, 1)

            End If

            Imprimir = True

            'SI REQUIERE SEGUIMIENTO DE SERIAL
            If iSeguimiento = 2 Then
                Dim SerialReg As Integer = 0
                Dim PorRegistrar As Double
                PorRegistrar = dCantidad
                Do
                    Dim a As New FrmSerial
                    a.DOCClave = VENClave
                    a.PROClave = sPROClave
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.Cantidad = PorRegistrar
                    a.Dias = iDiasGarantia
                    a.TipoDoc = 1
                    a.TipoMov = 2
                    a.ShowDialog()
                    SerialReg = SerialReg + a.NumSerialRegistrados
                    PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                    a.Dispose()
                Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
            End If

            'SI REQUIERE SEGUIMIENTO DE LOTE
            If iSeguimiento = 3 Then
                Dim LoteReg As Integer = 0
                Dim PorRegistrar As Double
                PorRegistrar = dCantidad
                Do
                    Dim a As New FrmLote
                    a.DOCClave = VENClave
                    a.PROClave = sPROClave
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.CantXRegistrar = PorRegistrar
                    a.TipoDoc = 1
                    a.TipoMov = 2
                    a.ShowDialog()
                    LoteReg = LoteReg + a.NumSerialRegistrados
                    PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                    a.Dispose()
                Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
            End If


            'recalcula productos que tengan descuento de volumen
            If oVolumen <> dVolumen Then
                Dim dtVolumen As DataTable
                dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                If dtVolumen.Rows.Count > 0 Then
                    Dim y As Integer
                    For y = 0 To dtVolumen.Rows.Count - 1
                        ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                    Next
                End If
            End If


            ' AGREGAR PRODUCTO A LISTA
            AgregarProducto(DVEClave, iTProducto, sPROClave, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida, sClave, sNombre, dCantidad, dPrecioUnitario, PorcImpProducto, dDescGeneralImp + dVolumenImp + dDescuentoImp, sIdKIT, sCombo)

        Else
            Beep()
            MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TxtProducto.Text = ""
        Cantidad = 1
        TxtCantidad.Text = "1"
        Return False
    End Function

    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal, ByVal iKgLt As Integer, ByVal PesoUnidad As Double)
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

    Public Function AddCombo(ByVal sPROClave As String, ByVal sClave As String, ByVal dCantidad As Decimal, ByVal dPrecio As Decimal, ByVal sPREClave As String, ByVal bPreventa As Boolean) As Boolean
        If bPreventa = True Then

            'Agrega a Combo
            Dim row1 As DataRow
            row1 = dtCombo.NewRow()
            'declara el nombre de la fila
            row1.Item("Clave") = sClave
            row1.Item("Precio") = dPrecio
            row1.Item("Cantidad") = dCantidad
            row1.Item("PREClave") = sPREClave
            dtCombo.Rows.Add(row1)
            Return True

        Else
            Dim Disponible, Existencia, Apartado, Bloqueado As Decimal

            Dim dtDisponible As DataTable
            dtDisponible = ModPOS.SiExisteRecupera("st_recupera_peu", "@PROClave", sPROClave, "@UBCClave", StageLU)
            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Existencia = dtDisponible.Rows(0)("Existencia")
                Apartado = dtDisponible.Rows(0)("Apartado")
                Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                dtDisponible.Dispose()

                Disponible = Existencia - Apartado - Bloqueado
            Else
                Disponible = 0
            End If

            If Disponible >= dCantidad Then

                'Agrega a Combo
                Dim row1 As DataRow
                row1 = dtCombo.NewRow()
                'declara el nombre de la fila
                row1.Item("Clave") = sClave
                row1.Item("Precio") = dPrecio
                row1.Item("Cantidad") = dCantidad
                row1.Item("PREClave") = sPREClave
                dtCombo.Rows.Add(row1)
                Return True
            Else
                Return False
            End If

        End If
        
    End Function


    Private Function AddModelo(ByVal Modelo As String, ByVal dCantidad As Double) As Boolean

        Dim msg As String = ""
        Dim esModelo As Boolean = False
        Dim cancelar As Boolean = False

        'Busca y recupera los datos del producto

        Dim dt As DataTable

        Dim PROClaveKIT As String = ""
        Dim Combo As String = ""

        If Modelo <> "" Then
            dt = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Modelo)
            If dt.Rows.Count > 0 Then
                ' Valida si es producto es un combo o kit o duo
                If CInt(dt.Rows(0)("TProducto")) >= 7 Then
                    'dCantidad = 1
                    For q As Integer = 0 To dCantidad - 1
                        PROClaveKIT = CStr(dt.Rows(0)("PROClave"))
                        Combo = CStr(dt.Rows(0)("Clave"))

                        Dim dtMultiproducto As DataTable = ModPOS.Recupera_Tabla("sp_muestra_multiproductos", "@ProductoPadre", dt.Rows(0)("PROClave"))
                        ' Si el produto es combo  TProducto = 7
                        If dtMultiproducto.Rows.Count > 0 Then
                            Dim j, iTalla As Integer
                            Dim dPendienteSurtir As Integer = dtMultiproducto.Rows.Count
                            Dim ListaCombo As String
                            Dim dtListaCombo As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

                            ListaCombo = IIf(dtListaCombo.Rows(0)("PREClave").GetType.Name = "DBNull", "", dtListaCombo.Rows(0)("PREClave"))
                            dtListaCombo.Dispose()

                            dtCombo.Clear()

                            Dim dtProducto As DataTable
                            'Recorremos cada uno de los detalles del producto
                            For j = 0 To dtMultiproducto.Rows.Count - 1

                                dtProducto = ModPOS.Recupera_Tabla("st_venta_modelo", "@Modelo", dtMultiproducto.Rows(j)("Modelo"), "@SUCClave", SUCClave, "@PREClave", ListaCombo, "@CTEClave", CTEClaveActual)


                                'Si es Combo
                                If CInt(dt.Rows(0)("TProducto")) = 7 Then

                                    If dtProducto.Rows.Count = 1 Then

                                        If AddCombo(dtProducto.Rows(0)("PROClave"), dtProducto.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProducto.Rows(0)("PrecioBruto"), ListaCombo, dtProducto.Rows(0)("Preventa")) = False Then
                                            dtCombo.Clear()
                                            Exit For
                                        End If

                                    Else
                                        Dim a As New FrmTallaColor
                                        a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                        a.SUCClave = SUCClave
                                        a.CTEClave = CTEClaveActual
                                        a.PREClave = ListaCombo
                                        a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                        a.ALMClave = ALMClave
                                        a.ShowDialog()
                                        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            'Valida existencia 
                                            If AddCombo(a.PROClave, a.Clave, dtMultiproducto.Rows(j)("Cantidad"), a.PrecioBruto, ListaCombo, a.Preventa) = False Then
                                                dtCombo.Clear()
                                                Exit For
                                            End If
                                        Else
                                            cancelar = True
                                            dtCombo.Clear()
                                            Exit For
                                        End If

                                    End If

                                Else

                                    If j = 0 Then

                                        If dtProducto.Rows.Count = 1 Then

                                            If AddCombo(dtProducto.Rows(0)("PROClave"), dtProducto.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProducto.Rows(0)("PrecioBruto"), ListaCombo, dtProducto.Rows(0)("Preventa")) = False Then
                                                dtCombo.Clear()
                                                Exit For
                                            End If

                                        Else
                                            Dim a As New FrmTallaColor
                                            a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                            a.SUCClave = SUCClave
                                            a.CTEClave = CTEClaveActual
                                            a.PREClave = ListaCombo
                                            a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                            a.ALMClave = ALMClave
                                            a.ShowDialog()
                                            If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                                iTalla = a.Talla
                                                'Valida existencia 
                                                If AddCombo(a.PROClave, a.Clave, dtMultiproducto.Rows(j)("Cantidad"), a.PrecioBruto, ListaCombo, a.Preventa) = False Then
                                                    dtCombo.Clear()
                                                    Exit For
                                                End If
                                            Else
                                                cancelar = True
                                                dtCombo.Clear()
                                                Exit For
                                            End If

                                        End If
                                    Else
                                        'Recupera el valor de la talla del otro producto
                                        Dim dtProd As DataTable = ModPOS.Recupera_Tabla("st_recupera_modelo", "@Modelo", dtMultiproducto.Rows(j)("Modelo"), "@Talla", iTalla, "@Color", dtMultiproducto.Rows(j)("iColor"), "@SUCClave", SUCClave, "@PREClave", ListaCombo, "@CTEClave", CTEClaveActual)

                                        If dtProd.Rows.Count > 0 Then
                                            If AddCombo(dtProd.Rows(0)("PROClave"), dtProd.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProd.Rows(0)("PrecioBruto"), ListaCombo, dtProd.Rows(0)("Preventa")) = False Then
                                                dtProd.Dispose()
                                                dtCombo.Clear()
                                                Exit For
                                            End If
                                        Else
                                            dtProd.Dispose()
                                            dtCombo.Clear()
                                            Exit For
                                        End If
                                        dtProd.Dispose()

                                    End If



                                End If
                            Next

                            dtProducto.Dispose()

                            'Si se completa el combo entonces 
                            If dtCombo.Rows.Count = dPendienteSurtir Then
                                Dim IdKit As String = ModPOS.obtenerLlave
                                Dim frmStatusMessage As New frmStatus

                                frmStatusMessage.Show("Estamos procesando su solicitud...")
                                frmStatusMessage.BringToFront()

                                For j = 0 To dtCombo.Rows.Count - 1
                                    AgregaGTIN(dtCombo.Rows(j)("Clave"), True, False, dtCombo.Rows(j)("Cantidad"), True, "", dtCombo.Rows(j)("PREClave"), dtCombo.Rows(j)("Precio"), IdKit, PROClaveKIT, Combo)
                                Next

                                frmStatusMessage.Dispose()

                                msg = "OK"
                            Else
                                dtCombo.Clear()
                                msg = "No se encontro existencia disponible suficiente para el paquete actual"
                                Exit For
                            End If
                            esModelo = True
                        Else
                            msg = "El Modelo no cuenta con detalle de productos definidos"
                            esModelo = True
                            Exit For
                        End If
                    Next
                Else
                    'Si es un producto convencional 

                    If CDbl(dt.Rows(0)("Talla")) = 0 AndAlso CDbl(dt.Rows(0)("Color")) = 0 Then


                        AgregaGTIN(CStr(dt.Rows(0)("Clave")), True, False, dCantidad, True)

                        msg = "OK"
                        esModelo = True
                    Else
                        Dim a As New FrmTallaColor
                        a.sModelo = dt.Rows(0)("Modelo")
                        a.SUCClave = SUCClave
                        a.CTEClave = CTEClaveActual
                        a.PREClave = ListaPrecio
                        a.ALMClave = ALMClave
                        a.ShowDialog()
                        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            AgregaGTIN(a.Clave, True, False, dCantidad, True)

                            msg = "OK"
                            esModelo = True
                        Else
                            cancelar = True
                        End If
                    End If
                End If
            Else
                msg = "El Modelo no es valido o no existe"
                esModelo = False
            End If
        Else
            msg = "No se ha especificado algun Producto o Modelo"
            esModelo = True
        End If


        If esModelo = True AndAlso msg <> "OK" AndAlso cancelar = False Then
            MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return esModelo

    End Function

    Private Function leeCodigoBarras(ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bShortCut As Boolean, Optional ByVal sDVEClave As String = "", Optional ByVal dCant As Decimal = 0, Optional ByVal PREClaveKIT As String = "", Optional ByVal PrecioBrutoKIT As Decimal = 0, Optional ByVal IdKit As String = "", Optional ByVal PROClaveKIT As String = "", Optional ByVal sCombo As String = "") As Boolean
        Dim dt As DataTable = Nothing

        'Valida que el campo producto no se encuentre vacio
        If Not Codigo = vbNullString Then

            If cmbAccion.SelectedItem Is Nothing Then
                MessageBox.Show("Debe seleccionar el tipo de Acción a realizar (Agregar/Quitar)", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtProducto.Text = ""
                Cantidad = 1
                TxtCantidad.Text = "1"
                Return False

            ElseIf cmbAccion.SelectedItem = "Quitar" Then
                If cmbMotivo.SelectedValue Is Nothing Then
                    MessageBox.Show("Debe seleccionar el Motivo del Rechazo", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    Return False
                End If
            End If


            'Si el campo cantidad esta vacio lo cambia a 1 por defecto

            If dCant = 0 Then
                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                Else
                    Cantidad = CDbl(TxtCantidad.Text)
                End If
            Else
                Cantidad = dCant
            End If

            'Busca y recupera los datos del producto

            dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClaveActual, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", 0, "@TallaColor", TallaColor)

            If dt Is Nothing Then
                Beep()
                MessageBox.Show("El Código " & Codigo & " no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtProducto.Text = ""
                Cantidad = 1
                TxtCantidad.Text = "1"
                Return False
            Else

                Dim YaExiste As Boolean = False
                Dim DVEClave As String = ""
                Dim sAutoriza As String = Nothing

                Dim BacktoSearh As Boolean = False

                Dim sPROClave As String = dt.Rows(0)("PROClave")
                Dim sClave As String = CStr(dt.Rows(0)("Clave"))
                Dim sAlterno2 As String = CStr(dt.Rows(0)("Alterno2"))
                Dim sNombre As String = dt.Rows(0)("Nombre")
                Dim dCosto As Decimal = dt.Rows(0)("Costo") / TipoCambio
                Dim dPrecioUnitario As Decimal = dt.Rows(0)("PrecioBruto") / TipoCambio
                Dim dDescPorc As Decimal = dt.Rows(0)("DescPorc")
                Dim dDescGeneralPor As Decimal = dt.Rows(0)("DescGeneral")

                Dim iTProducto As Integer = dt.Rows(0)("TProducto")
                Dim iSeguimiento As Integer = dt.Rows(0)("Seguimiento")
                Dim iDiasGarantia As Integer = dt.Rows(0)("DiasGarantia")
                Dim iNumDecimales As Integer = dt.Rows(0)("Num_Decimales")

                Dim dGeneralNeto As Decimal = TruncateToDecimal(dt.Rows(0)("PrecioNeto") / TipoCambio, 6)
                Dim dMinimoNeto As Decimal = TruncateToDecimal(dt.Rows(0)("MinimoNeto") / TipoCambio, 6)

                Dim iKgLt As Integer = IIf(dt.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("KgLt"))
                Dim dPeso As Decimal = IIf(dt.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("Peso"))

                Dim bVtaPaquete As Boolean = dt.Rows(0)("vtaPaquete")
                Dim bPreventa As Boolean = dt.Rows(0)("Preventa")

                Dim dBackOrder As Decimal = 0
                Dim dCantidad As Decimal = dt.Rows(0)("Cantidad")
                Dim dOriginal As Decimal = 0
                Dim dPendiente As Decimal = 0
                Dim centroSuministro As String = ""
                Dim iGrupoMaterial As Integer = 0
                Dim iSector As Integer = 0
                Dim iPartida As Integer
                Dim dVolumen As Decimal = 0
                Dim dVolumenImp As Decimal = 0

                Dim bValidaMinimo As Boolean = IIf(dGeneralNeto = dMinimoNeto, False, True)

                Dim PorcImpProducto As Decimal = ModPOS.RecuperaImpuesto(SUCClave, sPROClave, TImpuesto)

                Dim sTalla As String = dt.Rows(0)("Talla")
                Dim sTallaUSA As String = dt.Rows(0)("TallaUSA")
                Dim sColor As String = dt.Rows(0)("Color")

                Dim sModelo As String = dt.Rows(0)("Modelo")

                If sTallaUSA <> "" Then
                    sTalla &= " (" & sTallaUSA & ")"
                End If

                If dCantidad <= 0 Then
                    MessageBox.Show("El producto " & sClave & " no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    dt.Dispose()
                    Return Busca
                End If

                'valida Accion 

                Dim foundRows() As System.Data.DataRow

                If cmbAccion.SelectedItem = "Quitar" Then

                    foundRows = dtDetalle.Select("PROClave = '" & CStr(dt.Rows(0)("PROClave")) & "'")

                    If foundRows.Length = 1 Then

                        If foundRows(0)("IdKIT") = "" Then

                            If (CDec(foundRows(0)("Cancelar")) + CDec(TxtCantidad.Text)) <= CDec(foundRows(0)("Cantidad")) Then
                                foundRows(0)("Cancelar") += CDec(TxtCantidad.Text)
                                foundRows(0)("TipoRechazo") = cmbMotivo.SelectedValue
                            End If
                        Else

                            Dim foundRows2() As System.Data.DataRow
                            foundRows2 = dtDetalle.Select("IdKIT = '" & foundRows(0)("IdKIT") & "'")

                            Dim x As Integer
                            For x = 0 To foundRows2.Length - 1
                                foundRows2(x)("Cancelar") = foundRows2(x)("Cantidad")
                                foundRows2(x)("TipoRechazo") = cmbMotivo.SelectedValue
                            Next
                        End If

                    ElseIf foundRows.Length = 0 Then
                        Beep()
                        MessageBox.Show("El Código " & Codigo & " no se encuentra en el Pedido Actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TxtProducto.Text = ""
                        Cantidad = 1
                        TxtCantidad.Text = "1"
                        Return False
                    End If

                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    TxtProducto.Focus()
                    Return True
                End If


                If iTProducto >= 7 Then
                    AddModelo(sModelo, dCantidad)
                    Return Busca
                End If

                If bVtaPaquete = True AndAlso IdKit = "" Then

                    Dim sPaquetes As String = ""

                    Dim dtPaq As DataTable = ModPOS.Recupera_Tabla("st_recupera_clave_kit", "@PROClave", sPROClave, "@TallaColor", TallaColor)

                    If dtPaq.Rows.Count = 1 Then
                        sPaquetes = dtPaq.Rows(0)("Paquetes")
                    End If

                    MessageBox.Show("El producto " & sClave & ", su venta es exclusiva en Paquete(s): " & sPaquetes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt.Dispose()
                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    Return Busca
                End If


                If CDec(dt.Rows(0)("PrecioBruto")) = 0 Then
                    MessageBox.Show("El producto " & sClave & " no cuenta con precio definido en la lista de precios actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt.Dispose()
                    TxtProducto.Text = ""
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    Return Busca
                End If

                dt.Dispose()

                Dim UnidadesKilo As Double

                If iKgLt = 1 Then
                    If dPeso > 0 Then
                        UnidadesKilo = dCantidad / dPeso
                    Else
                        UnidadesKilo = 1
                    End If
                Else
                    UnidadesKilo = 0
                End If


                If IdKit = "" Then
                    If sDVEClave = "" Then
                        foundRows = dtDetalle.Select(" PROClave = '" & sPROClave & "' and IdKit=''")
                    Else
                        foundRows = dtDetalle.Select(" DVEClave = '" & sDVEClave & "'")
                    End If
                End If

                If Not foundRows Is Nothing AndAlso foundRows.Length > 1 Then

                    Dim a As New FrmConsultaT
                    a.Text = "Selecciona la Partida que desea Modificar"
                    a.Campo = "DVEClave"
                    a.GridConsultaGen.Font = New Font("Arial", 14)
                    ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_partida_prod", "@VENClave", VENClave, "@PROClave", sPROClave, "@Cerrada", 1)
                    a.GridConsultaGen.RootTable.Columns("DVEClave").Visible = False
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.ID <> "" Then
                            sDVEClave = a.ID
                        Else
                            Return Busca
                        End If
                    End If
                    a.Dispose()

                    foundRows = dtDetalle.Select(" DVEClave = '" & sDVEClave & "'")
                End If


                If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then
                    YaExiste = True
                    dOriginal = foundRows(0)("Cantidad")
                    sDVEClave = foundRows(0)("DVEClave")
                    dPrecioUnitario = foundRows(0)("Precio Unitario")

                    If Suma = True Then
                        dCantidad += foundRows(0)("Cantidad")
                        UnidadesKilo += foundRows(0)("UndKilo")
                    ElseIf bShortCut = False Then
                        dCantidad = foundRows(0)("Cantidad")
                        UnidadesKilo = foundRows(0)("UndKilo")
                    End If

                    centroSuministro = IIf(foundRows(0)("centroSuministro").GetType.FullName = "System.DBNull", "", foundRows(0)("centroSuministro"))

                    iGrupoMaterial = foundRows(0)("GrupoMaterial")
                    iSector = foundRows(0)("Sector")

                    If foundRows(0)("PorcDesc") > 0 Then
                        Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", sDVEClave)
                        If Not dtDescuento Is Nothing Then
                            'Descuento General
                            foundRows = dtDescuento.Select(" Tipo = 1 ")
                            If foundRows.Length = 1 Then
                                dDescGeneralPor = foundRows(0)("DescuentoPorc") * 100
                            End If

                            'Descuento Volumen
                            foundRows = dtDescuento.Select(" Tipo = 2")
                            If foundRows.Length = 1 Then
                                dVolumen = foundRows(0)("DescuentoPorc") * 100
                            End If

                            'Descuento Gerencial
                            foundRows = dtDescuento.Select(" Tipo = 3 ")
                            If foundRows.Length = 1 Then
                                dDescPorc = foundRows(0)("DescuentoPorc") * 100
                            End If
                            dtDescuento.Dispose()
                        End If
                    End If

                Else
                    YaExiste = False
                    dOriginal = 0

                    Dim dtProducto As DataTable
                    'Recupera GrupoMaterial
                    dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 1, "@PROClave", sPROClave) 'GrupoMaterial
                    If dtProducto.Rows.Count = 1 Then
                        iGrupoMaterial = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
                    End If
                    dtProducto.Dispose()
                    'Recupera Sector
                    dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 3, "@PROClave", sPROClave) 'Sector
                    If dtProducto.Rows.Count = 1 Then
                        iSector = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
                    End If
                    dtProducto.Dispose()


                End If

                If IdKit <> "" Then
                    dPrecioUnitario = PrecioBrutoKIT
                End If

                Dim oVolumen As Decimal = dVolumen

                Dim StrucVol As DescVol
                Dim sTipoDesc As String

                Dim dBase As Decimal

                dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

                Dim dDescGeneralImp As Decimal = Math.Round(dBase * (dDescGeneralPor / 100), 2)

                StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, sPROClave, dBase - dDescGeneralImp)

                dVolumen = StrucVol.Descuento
                sTipoDesc = StrucVol.Tipo

                If dVolumen > 0 Then
                    dVolumenImp = Math.Round((dBase - dDescGeneralImp) * (dVolumen / 100), 2)
                Else
                    dVolumenImp = 0
                End If

                Dim dDescuentoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * (dDescPorc / 100), 2)
                Dim dImpuestoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * PorcImpProducto, 2)

                Dim dImporteNeto As Decimal = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp

                If bPreventa = False Then
                    'Valida disponibilidad en stage
                    Dim Disponible, Existencia, Apartado, Bloqueado As Double
                    Dim dtDisponible As DataTable
                    dtDisponible = ModPOS.SiExisteRecupera("st_recupera_peu", "@PROClave", sPROClave, "@UBCClave", StageLU)
                    If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                        Existencia = dtDisponible.Rows(0)("Existencia")
                        Apartado = dtDisponible.Rows(0)("Apartado")
                        Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                        dtDisponible.Dispose()

                        Disponible = Existencia - Apartado - Bloqueado
                    Else
                        Disponible = 0
                    End If

                    If dCantidad > Disponible Then
                        MessageBox.Show("El producto " & sClave & " no cuenta con existencia disponible en la ubicación de Caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                Else
                        dBackOrder = dCantidad
                End If

                If LimitaCompraEmp > 0 AndAlso dPendiente > 0 Then

                    If TallaColor = 0 OrElse (TallaColor = 1 AndAlso sAlterno2 <> "CKLASS LIBROS" AndAlso sAlterno2 <> "CKLASS MULTIMARCAS" AndAlso iSector <> 509 AndAlso iSector <> 510 AndAlso iSector <> 511) Then

                        'valida si el cliente es empleado
                        Dim Acumulado As Decimal

                        If IdKit <> "" Then
                            Acumulado = 1
                        Else
                            Acumulado = dPendiente
                        End If


                        Dim dtEmpleado As DataTable = ModPOS.Recupera_Tabla("st_valida_compra_emp", "@CTEClave", CTEClaveActual, "@IDKIT", IdKit)
                        Acumulado += CDec(dtEmpleado.Rows(0)("Acumulado"))
                        dtEmpleado.Dispose()

                        If Acumulado > LimitaCompraEmp Then
                            MessageBox.Show("Lo sentimos, la cantidad solicitada excede el número de compras permitidas por mes para Empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return Busca
                        End If
                    End If
                End If

                'Aparta producto en Ubicacion de Caja
                If bPreventa = False Then
                    ModPOS.Ejecuta("st_act_existencia_pue", _
                                  "@VENClave", VENClave,
                                  "@ALMClave", ALMClave, _
                                  "@UBCClave", StageLU, _
                                  "@PROClave", sPROClave, _
                                  "@TProducto", iTProducto, _
                                  "@Cantidad", dCantidad, _
                                  "@Usuario", ModPOS.UsuarioActual
                                   )

                End If

                'Modifica pedido

                If YaExiste Then

                    'Actualiza Cantidad de producto
                    'IIf(dOriginal >= dCantidad, dCantidad, dCantidad - dOriginal), _
                    ModPOS.Ejecuta("sp_actualiza_detalle", _
                    "@ALMClave", ALMClave, _
                    "@VENTA", VENClave, _
                    "@PROClave", sPROClave, _
                    "@PrecioBruto", dPrecioUnitario, _
                    "@Cantidad", dCantidad, _
                    "@Importe", dBase, _
                    "@DescGenPor", dDescGeneralPor / 100, _
                    "@DescGenImp", dDescGeneralImp, _
                    "@DescVolPor", dVolumen / 100, _
                    "@DescVolImp", dVolumenImp, _
                    "@DescuentoPor", dDescPorc / 100, _
                    "@DescuentoImp", dDescuentoImp, _
                    "@ImpuestoImp", dImpuestoImp, _
                    "@TProducto", iTProducto, _
                    "@TipoDoc", TipoDocumento, _
                    "@Picking", Picking, _
                    "@UndKilo", UnidadesKilo, _
                    "@DVEClave", DVEClave, _
                    "@PorcImp", PorcImpProducto, _
                    "@Usuario", ModPOS.UsuarioActual, _
                    "@TipoDesc", sTipoDesc, _
                    "@Autoriza", sAutoriza, _
                    "@Total", dImporteNeto, _
                    "@BackOrder", dBackOrder, _
                    "@PREClaveKIT", PREClaveKIT, _
                    "@IdKIT", IdKit, _
                    "@PROClaveKIT", PROClaveKIT, _
                    "@Cerrado", 1)

                    Dim dtDet As DataTable
                    dtDet = ModPOS.SiExisteRecupera("st_vent_det_closed", "@DVEClave", DVEClave)
                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                        ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 1)
                        dtDet.Dispose()
                    End If


                Else
                    'Inserta Producto
                    DVEClave = ModPOS.obtenerLlave

                    If dtDetalle.Compute("MAX(Partida)", "").GetType.FullName = "System.DBNull" Then
                        iPartida = 10
                    Else
                        iPartida = CInt(dtDetalle.Compute("MAX(Partida)", "")) + 10
                    End If

                    ModPOS.Ejecuta("sp_inserta_detalle", _
                    "@DVEClave", DVEClave, _
                    "@VENTA", VENClave, _
                    "@PROClave", sPROClave, _
                    "@Costo", dCosto, _
                    "@PREClave", ListaPrecio, _
                    "@PrecioBruto", dPrecioUnitario, _
                    "@Cantidad", dCantidad, _
                    "@Importe", dBase, _
                    "@DescGenPor", dDescGeneralPor / 100, _
                    "@DescGenImp", dDescGeneralImp, _
                    "@DescVolPor", dVolumen / 100, _
                    "@DescVolImp", dVolumenImp, _
                    "@DescuentoPor", dDescPorc / 100, _
                    "@DescuentoImp", dDescuentoImp, _
                    "@PorcImp", PorcImpProducto, _
                    "@ImpuestoImp", dImpuestoImp, _
                    "@Total", dImporteNeto, _
                    "@ALMClave", ALMClave, _
                    "@TipoDoc", TipoDocumento, _
                    "@TProducto", iTProducto, _
                    "@Picking", Picking, _
                    "@Autoriza", sAutoriza, _
                    "@UndKilo", UnidadesKilo, _
                    "@GrupoMaterial", iGrupoMaterial, _
                    "@Sector", iSector, _
                    "@Partida", iPartida, _
                    "@TipoDesc", sTipoDesc, _
                    "@Usuario", ModPOS.UsuarioActual,
                    "@BackOrder", dBackOrder, _
                    "@PREClaveKIT", PREClaveKIT, _
                    "@IdKIT", IdKit, _
                    "@PROClaveKIT", PROClaveKIT, _
                    "@Cerrado", 1)

                    If iPartida = 10 Then
                        ModPOS.Ejecuta("st_actualiza_canal_vta", "@VENClave", VENClave, "@TipoCanal", TipoCanal)
                    End If

                    'Inserta detalle de Impuestos por partida
                    ModPOS.InsertaImpuesto(DVEClave, sPROClave, (dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp), TImpuesto, SUCClave, 1)

                End If

                Imprimir = True

                'SI REQUIERE SEGUIMIENTO DE SERIAL
                If iSeguimiento = 2 Then
                    Dim SerialReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = dCantidad
                    Do
                        Dim a As New FrmSerial
                        a.DOCClave = VENClave
                        a.PROClave = sPROClave
                        a.Clave = sClave
                        a.Nombre = sNombre
                        a.Cantidad = PorRegistrar
                        a.Dias = iDiasGarantia
                        a.TipoDoc = 1
                        a.TipoMov = 2
                        a.ShowDialog()
                        SerialReg = SerialReg + a.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                        a.Dispose()
                    Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
                End If

                'SI REQUIERE SEGUIMIENTO DE LOTE
                If iSeguimiento = 3 Then
                    Dim LoteReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = dCantidad
                    Do
                        Dim a As New FrmLote
                        a.DOCClave = VENClave
                        a.PROClave = sPROClave
                        a.Clave = sClave
                        a.Nombre = sNombre
                        a.CantXRegistrar = PorRegistrar
                        a.TipoDoc = 1
                        a.TipoMov = 2
                        a.ShowDialog()
                        LoteReg = LoteReg + a.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                        a.Dispose()
                    Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
                End If


                'recalcula productos que tengan descuento de volumen
                If oVolumen <> dVolumen Then
                    Dim dtVolumen As DataTable
                    dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "", "@Cerrado", 1)
                    If dtVolumen.Rows.Count > 0 Then
                        Dim y As Integer
                        For y = 0 To dtVolumen.Rows.Count - 1
                            ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)
                        Next
                    End If
                End If


                ' AGREGAR PRODUCTO A LISTA
                AgregarProducto(DVEClave, iTProducto, sPROClave, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida, sClave, sNombre, dCantidad, dPrecioUnitario, PorcImpProducto, dDescGeneralImp + dVolumenImp + dDescuentoImp, IdKit, sCombo)



                End If
        End If

        TxtProducto.Text = ""
        Cantidad = 1
        TxtCantidad.Text = "1"
        Return False

    End Function


    'Private Function leeCodigoBarras(ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalcular As Boolean, ByVal bValidaOpen As Boolean, ByVal bShortCut As Boolean, Optional ByVal sIdKIT As String = "", Optional ByVal sPREClaveKIT As String = "", Optional ByVal sPROClaveKIT As String = "", Optional ByVal sCombo As String = "") As Boolean
    '    'Valida que el campo producto no se encuentre vacio
    '    If Not Codigo = vbNullString Then

    '        If cmbAccion.SelectedItem Is Nothing Then
    '            MessageBox.Show("Debe seleccionar el tipo de Acción a realizar (Agregar/Quitar)", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Return False

    '        ElseIf cmbAccion.SelectedItem = "Quitar" Then
    '            If cmbMotivo.SelectedValue Is Nothing Then
    '                MessageBox.Show("Debe seleccionar el Motivo del Rechazo", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                Return False
    '            End If
    '        End If

    '        'Si el campo cantidad esta vacio lo cambia a 1 por defecto
    '        If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
    '            Cantidad = 1
    '            TxtCantidad.Text = "1"
    '        Else
    '            Cantidad = CDbl(TxtCantidad.Text)
    '        End If
    '        Dim dt As DataTable = Nothing


    '        'Busca y recupera los datos del producto
    '        Dim BacktoSearh As Boolean

    '        'Si Modulo TallaColor 
    '        If TallaColor = 1 Then
    '            Dim dtModelo As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Codigo)
    '            If dtModelo.Rows.Count > 0 Then
    '                Dim a As New FrmTallaColor
    '                a.SUCClave = SUCClave
    '                a.PREClave = ListaPrecio
    '                a.CTEClave = CTECLave
    '                a.sModelo = dtModelo.Rows(0)("Modelo")
    '                a.ALMClave = ALMClave
    '                a.StartPosition = FormStartPosition.CenterScreen
    '                a.ShowDialog()
    '                If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
    '                    Codigo = a.Clave
    '                Else
    '                    dtModelo.Dispose()
    '                    Return False
    '                End If
    '                dtModelo.Dispose()
    '            End If

    '        End If

    '        dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTECLave, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", False, "@TallaColor", TallaColor)


    '        If dt Is Nothing Then
    '            Beep()
    '            MessageBox.Show("El Código " & Codigo & " no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            TxtProducto.Text = ""
    '            Return False
    '        Else

    '            If cmbAccion.SelectedItem = "Quitar" Then
    '                Dim foundRows() As System.Data.DataRow

    '                foundRows = dtDetalle.Select("PROClave = '" & CStr(dt.Rows(0)("PROClave")) & "'")

    '                If foundRows.Length = 1 Then

    '                    If foundRows(0)("IdKIT") = "" Then

    '                        If (CDec(foundRows(0)("Cancelar")) + CDec(TxtCantidad.Text)) <= CDec(foundRows(0)("Cantidad")) Then
    '                            foundRows(0)("Cancelar") += CDec(TxtCantidad.Text)
    '                            foundRows(0)("TipoRechazo") = cmbMotivo.SelectedValue
    '                        End If
    '                    Else

    '                        Dim foundRows2() As System.Data.DataRow
    '                        foundRows2 = dtDetalle.Select("IdKIT = '" & foundRows(0)("IdKIT") & "'")

    '                        Dim x As Integer
    '                        For x = 0 To foundRows2.Length - 1
    '                            foundRows2(x)("Cancelar") = foundRows2(x)("Cantidad")
    '                            foundRows2(x)("TipoRechazo") = cmbMotivo.SelectedValue
    '                        Next
    '                    End If

    '                ElseIf foundRows.Length = 0 Then
    '                    Beep()
    '                    MessageBox.Show("El Código " & Codigo & " no se encuentra en el Pedido Actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    TxtProducto.Text = ""
    '                    Return False
    '                End If

    '                TxtProducto.Text = ""
    '                TxtProducto.Focus()
    '                Return True
    '            Else

    '                If dt.Rows(0)("vtaPaquete") = True AndAlso sIdKIT = "" Then

    '                    Dim sPaquetes As String = ""

    '                    Dim dtPaq As DataTable = ModPOS.Recupera_Tabla("st_recupera_clave_kit", "@PROClave", dt.Rows(0)("PROClave"), "@TallaColor", TallaColor)

    '                    If dtPaq.Rows.Count = 1 Then
    '                        sPaquetes = dtPaq.Rows(0)("Paquetes")
    '                    End If

    '                    MessageBox.Show("El producto " & CStr(dt.Rows(0)("Clave")) & ", su venta es exclusiva en Paquete(s): " & sPaquetes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    dt.Dispose()
    '                    Return Busca
    '                End If

    '                If dt.Rows(0)("TProducto") >= 7 Then
    '                    AddModelo(dt.Rows(0)("Modelo"), Cantidad)
    '                    Return Busca
    '                End If


    '                BacktoSearh = AgregaPartida(dt, Suma, Busca, bCopy, bRecalcular, bShortCut, sIdKIT, sPREClaveKIT, sPROClaveKIT, sCombo)
    '            End If

    '            dt.Dispose()

    '            Return BacktoSearh

    '        End If

    '    End If
    'End Function



    Private Sub TxtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                ElseIf CDbl(TxtCantidad.Text) <> Cantidad Then
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If

            If TallaColor = 1 Then
                If AddModelo(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), Cantidad) = False Then
                    AgregaGTIN(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), True, False, Cantidad, True)
                End If
            Else
                AgregaGTIN(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), True, False, Cantidad, True)
            End If


        End If
    End Sub

    Private Sub BtnBusquedaProducto_Click(sender As Object, e As EventArgs) Handles BtnBusquedaProducto.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_producto_ubc"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.AlmRequerido = True
        a.ALMClave = StageLU
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If TallaColor = 1 Then
                If AddModelo(a.valor, 1) = False Then
                    AgregaGTIN(a.valor, True, False, 1, True)
                End If
            Else
                AgregaGTIN(a.valor, True, False, 1, True)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub CancelaProducto()
        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("Nuevo  >  0 ")

        'Cancela producto
        If foundRows.Length >= 1 Then

            Dim dtVentaDetalle As DataTable
            Dim dtStage As DataTable
            Dim stageAnt As String = StageCancelacion

            For i As Integer = 0 To foundRows.Length - 1

                dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", 1, "@DOCClave", VENClave, "@PROClave", foundRows(i)("PROClave"))
                recalculaPartidaPedido(dtVentaDetalle, VENClave, foundRows(i)("DVEClave"), foundRows(i)("Cantidad"), foundRows(i)("Nuevo"), foundRows(i)("KgLt"), foundRows(i)("UndKilo"))
                dtStage = ModPOS.Recupera_Tabla("st_valida_stage_area", "@VENClave", VENClave, "@PROClave", foundRows(i)("PROClave"))
                If dtStage.Rows.Count > 0 AndAlso FormPadre = "SURTIDO" Then
                    StageCancelacion = dtStage.Rows(0)("Stage")
                End If
                ModPOS.Ejecuta("st_cancelar_producto_vta", "@VENClave", VENClave, "@ALMClave", ALMClave, "TProducto", foundRows(i)("TProducto"), "@PROClave", foundRows(i)("PROClave"), "@UBCClave", StageCancelacion, "@Cancelar", foundRows(i)("Nuevo"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual, "@Autoriza", ModPOS.UsuarioActual)
                StageCancelacion = stageAnt
            Next

            ModPOS.Ejecuta("sp_elimina_detalle_picking", "@Tipo", 1, "@DOCClave", VENClave)

        End If

        If Padre = "Nuevo" Then
            ModPOS.Ejecuta("st_elimina_venta_cerrada", "@VENClave", VENClave)
        End If

    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim a As New MeSearch
        a.MaskCte = MaskCte
        a.Prefijo = SUCClave
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                cambiaCliente(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then

                If MaskCte = 1 Then
                    If TxtCliente.Text.Split("-").Length = 2 Then
                        If IsNumeric(TxtCliente.Text.Split("-")(0)) AndAlso IsNumeric(TxtCliente.Text.Split("-")(1)) Then

                            Dim sSucursal As String
                            Dim sClaveCte As String

                            sSucursal = String.Format("{0:000}", Val(CDbl(TxtCliente.Text.Split("-")(0))))
                            sClaveCte = String.Format("{0:0000000}", Val(CDbl(TxtCliente.Text.Split("-")(1))))


                            TxtCliente.Text = sSucursal & "-" & sClaveCte
                        End If
                    End If
                End If

                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    cambiaCliente(dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                Else
                    MessageBox.Show("No se encontro registro que coincida con la clave proporcionada", "Información", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        Dim a As New FrmConsultaGen
        a.Text = "Detalle de productos rechazados"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_rechazados", "@DOCClave", VENClave, "@TallaColor", TallaColor)
        a.GridConsultaGen.GroupByBoxVisible = False
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        End If

    End Sub
End Class
