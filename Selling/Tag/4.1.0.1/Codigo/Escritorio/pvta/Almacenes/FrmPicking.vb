Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmPicking
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
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFprevista As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblEnvio As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents BtnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEconomico As System.Windows.Forms.TextBox
    Friend WithEvents BtnBusquedaTransporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridDoctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblNomOperador As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtFechaEfectiva As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEfectiva As System.Windows.Forms.Label
    Friend WithEvents txtOrden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents cmbMotivo As Selling.StoreCombo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPicking))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblEnvio = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.cmbMotivo = New Selling.StoreCombo()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.txtOrden = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFechaEfectiva = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblNomOperador = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TxtEmpleado = New System.Windows.Forms.TextBox()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblEfectiva = New System.Windows.Forms.Label()
        Me.lblFprevista = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.BtnOperador = New Janus.Windows.EditControls.UIButton()
        Me.BtnBusquedaTransporte = New Janus.Windows.EditControls.UIButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEconomico = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton()
        Me.GridDoctos = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.TxtNota)
        Me.GrpGeneral.Controls.Add(Me.lblRazonSocial)
        Me.GrpGeneral.Controls.Add(Me.lblEnvio)
        Me.GrpGeneral.Controls.Add(Me.lblCiudad)
        Me.GrpGeneral.Controls.Add(Me.lblColonia)
        Me.GrpGeneral.Controls.Add(Me.lblCalle)
        Me.GrpGeneral.Controls.Add(Me.lblCliente)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(406, 186)
        Me.GrpGeneral.TabIndex = 2
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Información de Envío"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Obs:"
        '
        'TxtNota
        '
        Me.TxtNota.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNota.Location = New System.Drawing.Point(54, 133)
        Me.TxtNota.Multiline = True
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(346, 44)
        Me.TxtNota.TabIndex = 133
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(11, 34)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(390, 17)
        Me.lblRazonSocial.TabIndex = 106
        Me.lblRazonSocial.Text = "Razón Social:"
        '
        'lblEnvio
        '
        Me.lblEnvio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnvio.Location = New System.Drawing.Point(11, 111)
        Me.lblEnvio.Name = "lblEnvio"
        Me.lblEnvio.Size = New System.Drawing.Size(390, 16)
        Me.lblEnvio.TabIndex = 105
        Me.lblEnvio.Text = "Envío:"
        '
        'lblCiudad
        '
        Me.lblCiudad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiudad.Location = New System.Drawing.Point(11, 91)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(390, 17)
        Me.lblCiudad.TabIndex = 104
        Me.lblCiudad.Text = "Localidad:"
        '
        'lblColonia
        '
        Me.lblColonia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblColonia.Location = New System.Drawing.Point(11, 72)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(390, 17)
        Me.lblColonia.TabIndex = 103
        Me.lblColonia.Text = "Colonia/CP:"
        '
        'lblCalle
        '
        Me.lblCalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCalle.Location = New System.Drawing.Point(11, 54)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(390, 16)
        Me.lblCalle.TabIndex = 102
        Me.lblCalle.Text = "Calle:"
        '
        'lblCliente
        '
        Me.lblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(11, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(390, 16)
        Me.lblCliente.TabIndex = 101
        Me.lblCliente.Text = "Cliente:"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 555)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 555)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.cmbMotivo)
        Me.GrpDetalle.Controls.Add(Me.ChkTodos)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(168, 196)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(617, 353)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.Location = New System.Drawing.Point(431, 35)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(180, 21)
        Me.cmbMotivo.TabIndex = 129
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(275, 35)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(142, 22)
        Me.ChkTodos.TabIndex = 128
        Me.ChkTodos.Text = "Confirmar Todo"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(63, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 22)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 36)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(53, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(223, 34)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaProd.TabIndex = 3
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(92, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(92, 35)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(125, 21)
        Me.TxtProducto.TabIndex = 0
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 61)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(604, 287)
        Me.GridDetalle.TabIndex = 6
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtReferencia)
        Me.GroupBox1.Controls.Add(Me.txtOrden)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtFechaEfectiva)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lblNomOperador)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.TxtEmpleado)
        Me.GroupBox1.Controls.Add(Me.lblPlacas)
        Me.GroupBox1.Controls.Add(Me.lblEfectiva)
        Me.GroupBox1.Controls.Add(Me.lblFprevista)
        Me.GroupBox1.Controls.Add(Me.lblRuta)
        Me.GroupBox1.Controls.Add(Me.BtnOperador)
        Me.GroupBox1.Controls.Add(Me.BtnBusquedaTransporte)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtEconomico)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(419, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(363, 186)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "Referencia:"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtReferencia.Location = New System.Drawing.Point(113, 161)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(118, 21)
        Me.TxtReferencia.TabIndex = 135
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(113, 138)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(53, 20)
        Me.txtOrden.TabIndex = 173
        Me.txtOrden.Text = "1"
        Me.txtOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtOrden.Value = 1
        Me.txtOrden.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Orden Reparto:"
        '
        'dtFechaEfectiva
        '
        Me.dtFechaEfectiva.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaEfectiva.Location = New System.Drawing.Point(113, 116)
        Me.dtFechaEfectiva.Name = "dtFechaEfectiva"
        Me.dtFechaEfectiva.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaEfectiva.TabIndex = 171
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(83, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox1.TabIndex = 170
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblNomOperador
        '
        Me.lblNomOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomOperador.Location = New System.Drawing.Point(5, 73)
        Me.lblNomOperador.Name = "lblNomOperador"
        Me.lblNomOperador.Size = New System.Drawing.Size(341, 15)
        Me.lblNomOperador.TabIndex = 169
        Me.lblNomOperador.Text = "Nombre:"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(83, 46)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox3.TabIndex = 156
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtEmpleado
        '
        Me.TxtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtEmpleado.Location = New System.Drawing.Point(113, 43)
        Me.TxtEmpleado.Name = "TxtEmpleado"
        Me.TxtEmpleado.Size = New System.Drawing.Size(73, 21)
        Me.TxtEmpleado.TabIndex = 166
        '
        'lblPlacas
        '
        Me.lblPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.Location = New System.Drawing.Point(233, 16)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(124, 15)
        Me.lblPlacas.TabIndex = 164
        Me.lblPlacas.Text = "Placas:"
        '
        'lblEfectiva
        '
        Me.lblEfectiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectiva.Location = New System.Drawing.Point(5, 119)
        Me.lblEfectiva.Name = "lblEfectiva"
        Me.lblEfectiva.Size = New System.Drawing.Size(76, 15)
        Me.lblEfectiva.TabIndex = 104
        Me.lblEfectiva.Text = "F. Efectiva:"
        '
        'lblFprevista
        '
        Me.lblFprevista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFprevista.Location = New System.Drawing.Point(5, 98)
        Me.lblFprevista.Name = "lblFprevista"
        Me.lblFprevista.Size = New System.Drawing.Size(328, 15)
        Me.lblFprevista.TabIndex = 103
        Me.lblFprevista.Text = "F. Prevista:"
        '
        'lblRuta
        '
        Me.lblRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(176, 141)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(181, 15)
        Me.lblRuta.TabIndex = 102
        Me.lblRuta.Text = "Ruta:"
        '
        'BtnOperador
        '
        Me.BtnOperador.Image = CType(resources.GetObject("BtnOperador.Image"), System.Drawing.Image)
        Me.BtnOperador.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnOperador.Location = New System.Drawing.Point(192, 42)
        Me.BtnOperador.Name = "BtnOperador"
        Me.BtnOperador.Size = New System.Drawing.Size(35, 22)
        Me.BtnOperador.TabIndex = 161
        Me.BtnOperador.ToolTipText = "Busqueda de Operador o Chofer"
        Me.BtnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBusquedaTransporte
        '
        Me.BtnBusquedaTransporte.Image = CType(resources.GetObject("BtnBusquedaTransporte.Image"), System.Drawing.Image)
        Me.BtnBusquedaTransporte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaTransporte.Location = New System.Drawing.Point(192, 11)
        Me.BtnBusquedaTransporte.Name = "BtnBusquedaTransporte"
        Me.BtnBusquedaTransporte.Size = New System.Drawing.Size(35, 22)
        Me.BtnBusquedaTransporte.TabIndex = 158
        Me.BtnBusquedaTransporte.ToolTipText = "Busqueda de Transporte o Vehiculo"
        Me.BtnBusquedaTransporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 15)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "No. Economico"
        '
        'txtEconomico
        '
        Me.txtEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEconomico.Location = New System.Drawing.Point(113, 11)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(73, 21)
        Me.txtEconomico.TabIndex = 157
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 160
        Me.Label9.Text = "Operador"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmbTipo)
        Me.GroupBox2.Controls.Add(Me.BtnDel)
        Me.GroupBox2.Controls.Add(Me.TxtTicket)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaTicket)
        Me.GroupBox2.Controls.Add(Me.GridDoctos)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 353)
        Me.GroupBox2.TabIndex = 158
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Venta", "Traslado", "Salida", "Devolución"})
        Me.cmbTipo.Location = New System.Drawing.Point(5, 38)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(144, 21)
        Me.cmbTipo.TabIndex = 138
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(75, 13)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(35, 22)
        Me.BtnDel.TabIndex = 17
        Me.BtnDel.ToolTipText = "Remueve el Ticket Seleccionado "
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(6, 14)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(63, 21)
        Me.TxtTicket.TabIndex = 15
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(114, 13)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaTicket.TabIndex = 16
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Ticket"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDoctos
        '
        Me.GridDoctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDoctos.ColumnAutoResize = True
        Me.GridDoctos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDoctos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDoctos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDoctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDoctos.Location = New System.Drawing.Point(6, 61)
        Me.GridDoctos.Name = "GridDoctos"
        Me.GridDoctos.RecordNavigator = True
        Me.GridDoctos.Size = New System.Drawing.Size(143, 287)
        Me.GridDoctos.TabIndex = 7
        Me.GridDoctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmPicking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmPicking"
        Me.Text = "Surtido de Pedido"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Documentos As String
    Public SUCClave As String
    Public ALMClave As String
    Public FecRegistro As DateTime
    ' Private SurtidoRF As Boolean
    Private PICClave, InterfazSalida As String
    Private fechaEfectiva As Date = Today.Date
    Private TRAClave As String
    Private VencimientoPoliza As Date
    Private EMPClave As String
    Private VencimientoLicencia As Date
    Private dtDoctos, dtDetalle, dtVentaDetalle, dtTipoRechazo As DataTable
    Private bSurtido As Boolean = False
    Private DOCClave As String = ""
    Private Tipo As Integer
    Private sPROClave As String
    Private iTProducto As Integer
    Private dCantidad As Double
    Private iNumDecimales As Integer
    Private iFactor As Integer
    Private iSeguimiento As Integer
    Private iDiasGarantia As Integer
    Private bLoad As Boolean
    Private reloj As parpadea
    Private alerta(1) As PictureBox


    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal)
        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("DETClave = '" & DETClave & "'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
        
            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, UnidadesKilo, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer

            Dim iKgLt As Integer
            Dim sTipoDesc As String = ""



            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")


                dCantidad = dCantidadOriginal - dFaltante


                If foundRows(i)("UndKilo") > 0 Then
                    iKgLt = 1
                    UnidadesKilo = (foundRows(i)("UndKilo") / dCantidadOriginal) * dCantidad
                    dBase = Math.Round(dPrecioUnitario * UnidadesKilo, 2)
                Else
                    iKgLt = 0
                    UnidadesKilo = 0
                    dBase = Math.Round(dPrecioUnitario * dCantidad, 2)
                End If


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
                                        "@UndKilo", UnidadesKilo, _
                                        "@DVEClave", foundRows(i)("DVEClave"), _
                                        "@PorcImp", dPorcImp, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@TipoDesc", sTipoDesc, _
                                        "@Autoriza", "", _
                                        "@Total", dImporteNeto, _
                                        "@Cerrado", 1)
                       
                    Case Is < dCantidadOriginal
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
                                          "@UndKilo", UnidadesKilo, _
                                          "@DVEClave", foundRows(i)("DVEClave"), _
                                          "@PorcImp", dPorcImp, _
                                          "@Usuario", ModPOS.UsuarioActual, _
                                          "@TipoDesc", sTipoDesc, _
                                          "@Autoriza", "", _
                                          "@Total", dImporteNeto, _
                                          "@Cerrado", 1)




                End Select






            Next



        End If
    End Sub

    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

                sPROClave = dtProducto.Rows(0)("PROClave")
                iTProducto = dtProducto.Rows(0)("TProducto")
                iSeguimiento = dtProducto.Rows(0)("Seguimiento")
                iDiasGarantia = dtProducto.Rows(0)("DiasGarantia")
                iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                iFactor = dtProducto.Rows(0)("Factor")

                dtProducto.Dispose()

                TxtCantidad.DecimalDigits = iNumDecimales

                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                    dCantidad = 1 * iFactor
                    TxtCantidad.Text = "1"
                Else
                    dCantidad = CDbl(TxtCantidad.Text) * iFactor
                End If

                'Actualiza Surtido
                Dim foundRows() As System.Data.DataRow

                foundRows = dtDetalle.Select("PROClave Like '" & sPROClave & "' and Cantidad > Surtido")
                If foundRows.Length >= 1 Then
                    Dim porSurtir As Double

                    porSurtir = dtDetalle.Compute("SUM(Cantidad)", "PROClave Like '" & sPROClave & "'")
                    porSurtir -= dtDetalle.Compute("SUM(Surtido)", "PROClave Like '" & sPROClave & "'")

                    If porSurtir >= dCantidad Then
                        Dim i As Integer
                        For i = 0 To foundRows.Length - 1

                            Select Case dCantidad
                                Case Is >= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))
                                    dCantidad -= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))
                                    foundRows(i)("Surtido") = foundRows(i)("Cantidad")
                                    If dCantidad <= 0 Then
                                        Exit For
                                    End If
                                Case Is < CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))
                                    foundRows(i)("Surtido") += dCantidad
                                    Exit For
                            End Select
                        Next

                        If GridDetalle.RootTable.FormatConditions.Count = 1 Then
                            Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
                            fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Surtido"), Janus.Windows.GridEX.ConditionOperator.Equal, GridDetalle.GetValue("Cantidad"))
                            fc1.FormatStyle.ForeColor = System.Drawing.Color.Black
                            GridDetalle.RootTable.FormatConditions.Add(fc1)
                        End If

                        GridDetalle.Refresh()
                    Else
                        Beep()
                        MessageBox.Show("La cantidad  a surtir es mayor a la solicitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Beep()
                    MessageBox.Show("La cantidad  o producto excede lo solicitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                TxtCantidad.Text = "1"
                TxtProducto.Text = ""

                TxtProducto.Focus()
            Else
                sPROClave = 0
                iTProducto = 0
                iSeguimiento = 0
                iDiasGarantia = 0
                iNumDecimales = 0
                iFactor = 0
                TxtProducto.Text = ""
                Beep()
                MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        End If
    End Sub

    Private Sub cargaDatosDocto(ByVal sDOCClave As String, ByVal iTipo As Integer)
        If sDOCClave <> DOCClave Then

            Dim foundRows() As Data.DataRow
            foundRows = dtDoctos.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & sDOCClave & "'")

            If foundRows.Length = 1 Then

                With Me


                    .DOCClave = foundRows(0)("DOCClave")
                    '.sFolio = foundRows(0)("Folio")
                    .lblCliente.Text = "Cliente: " & foundRows(0)("Clave") & "   RFC: " & foundRows(0)("id_Fiscal")
                    .lblRazonSocial.Text = foundRows(0)("RazonSocial")


                    .lblFprevista.Text = "F. Prevista: " & CDate(foundRows(0)("fechaPrevista")).ToString("dd/MM/yyyy")
                    .dtFechaEfectiva.Value = foundRows(0)("fechaEfectiva")

                    .lblRuta.Text = "Ruta: " & foundRows(0)("Ruta")
                    .TxtReferencia.Text = foundRows(0)("Referencia")
                    .lblCalle.Text = foundRows(0)("Calle")
                    .lblColonia.Text = foundRows(0)("Domicilio1")
                    .lblCiudad.Text = foundRows(0)("Domicilio2")
                    .lblEnvio.Text = "Envío: " & foundRows(0)("formaEnvio")
                    .TxtNota.Text = foundRows(0)("Observaciones")
                    .txtOrden.Text = foundRows(0)("Orden")

                End With
            End If
        End If
    End Sub

    Private Sub AddDocto( _
    ByVal sENVClave As String, _
    ByVal sDOCClave As String, _
    ByVal iTipo As Integer, _
    ByVal sT As String, _
    ByVal sFolio As String, _
    ByVal dFecha As String, _
    ByVal itipoEntrega As Integer, _
    ByVal sClave As String, _
    ByVal sRFC As String, _
    ByVal sRazonSocial As String, _
    ByVal dTotal As Double, _
    ByVal sCalle As String, _
    ByVal sDomicilio1 As String, _
    ByVal sDomicilio2 As String, _
    ByVal sReferencia As String, _
    ByVal sformaEnvio As String, _
    ByVal sObservaciones As String, _
    ByVal dfechaPrevista As Date, _
    ByVal dfechaEfectiva As Date, _
    ByVal sRuta As String, _
    ByVal sStage As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDoctos.Select("Tipo = " & CStr(iTipo) & "and  DOCClave = '" & sDOCClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDoctos.NewRow()
            'declara el nombre de la fila
            row1.Item("ENVClave") = sENVClave
            row1.Item("DOCClave") = sDOCClave
            row1.Item("Tipo") = iTipo
            row1.Item("T") = sT
            row1.Item("Folio") = sFolio
            row1.Item("Fecha") = dFecha
            row1.Item("TipoEntrega") = itipoEntrega
            row1.Item("Clave") = sClave
            row1.Item("Id_Fiscal") = sRFC
            row1.Item("RazonSocial") = sRazonSocial
            row1.Item("Total") = dTotal
            row1.Item("Calle") = sCalle
            row1.Item("Domicilio1") = sDomicilio1
            row1.Item("Domicilio2") = sDomicilio2
            row1.Item("Referencia") = sReferencia
            row1.Item("formaEnvio") = sformaEnvio
            row1.Item("Observaciones") = sObservaciones
            row1.Item("fechaPrevista") = dfechaPrevista
            row1.Item("fechaEfectiva") = dfechaEfectiva
            row1.Item("Ruta") = sRuta
            row1.Item("Orden") = GridDoctos.GetTotal(GridDoctos.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1
            row1.Item("Stage") = sStage
            dtDoctos.Rows.Add(row1)
            'agrega la fila completo a la tabla

            ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", iTipo, "@PICClave", PICClave, "@DOCClave", sDOCClave, "@Usuario", ModPOS.UsuarioActual, "@IP", IPAddress)
            If iTipo = 1 Then
                ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", sDOCClave, "@Estado", 8)
            ElseIf iTipo = 8 Then
                ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", sDOCClave, "@Estado", 6)
            ElseIf iTipo = 6 Then
                ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", DOCClave, "@Estado", 6)
            ElseIf iTipo = 10 Then
                ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", DOCClave, "@Estado", 6)
            End If
        Else
            Beep()
            MessageBox.Show("¡El documento " & sFolio & ", que intenta agregar ya existe en la recolección actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub cargaDocto(ByVal sDOCClave As String, ByVal iTipo As Integer)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand
        Dim RF As Integer

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        myCommand = New System.Data.SqlClient.SqlCommand("sp_encabezado_envio", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = iTipo
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave

        dr = myCommand.ExecuteReader()

        While dr.Read

            AddDocto( _
            dr("ENVClave"), _
            dr("DOCClave"), _
            dr("Tipo"), _
            dr("T"), _
            dr("Folio"), _
            dr("Fecha"), _
            dr("tipoEntrega"), _
            dr("Clave"), _
            dr("Id_Fiscal"), _
            dr("RazonSocial"), _
            dr("Total"), _
            dr("Calle"), _
            dr("Domicilio1"), _
            dr("Domicilio2"), _
            dr("Referencia"), _
            dr("formaEnvio"), _
            IIf(dr("Observaciones").GetType.Name = "DBNull", "", dr("Observaciones")), _
            dr("fechaPrevista"), _
            IIf(dr("fechaEfectiva").GetType.Name = "DBNull", Today.Date, dr("fechaEfectiva")), _
            IIf(dr("Ruta").GetType.Name = "DBNull", "", dr("Ruta")),
            dr("Stage"))

            RF = dr("RF")

        End While

        myCommand.Dispose()
        dr.Close()


        myCommand = New System.Data.SqlClient.SqlCommand("sp_surtido_detalle", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = iTipo
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave
        myCommand.Parameters.Add("@Movilidad", SqlDbType.Int).Value = RF
        dr = myCommand.ExecuteReader()

        While dr.Read
            addDetalle(dr("DOCClave"), _
                         dr("Tipo"), _
                         dr("T"), _
                         dr("Folio"), _
                         dr("PROClave"), _
                         dr("TProducto"), _
                         dr("Seguimiento"), _
                         dr("DiasGarantia"), _
                         dr("Clave"), _
                         dr("Nombre"), _
                         dr("Ubicación"), _
                         dr("Cantidad"), _
                         dr("Surtido"), _
                         dr("TipoRechazo"), _
                         dr("VolSolicitado"), _
                         dr("Volumen"), _
                         dr("UBCClave"), _
                         IIf(dr("Und").GetType.ToString = "System.DBNull", 0, dr("Und")), _
                         RF, _
                          IIf(dr("RechazoRF").GetType.ToString = "System.DBNull", 0, dr("RechazoRF")))
        End While

        myCommand.Dispose()
        dr.Close()
        Cnx.Close()






        Dim dt As DataTable
        dt = Recupera_Tabla("st_valida_surtido", "@TipoDocumento", iTipo, "@DOCClave", sDOCClave)

        If dt.Rows.Count > 0 Then
            MessageBox.Show("Se encontro una diferencia entre la cantidad solicitada y la surtida en un documento, el cual se eliminara de este surtido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", iTipo, "@PICClave", Nothing, "@DOCClave", sDOCClave, "@Usuario", ModPOS.UsuarioActual)

            If iTipo = 1 Then
                ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", sDOCClave, "@Estado", 7)
            ElseIf iTipo = 8 Then
                ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", sDOCClave, "@Estado", 5)
            ElseIf iTipo = 6 Then
                ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", sDOCClave, "@Estado", 5)
            ElseIf iTipo = 10 Then
                ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", sDOCClave, "@Estado", 5)
            End If

            Dim foundRows() As System.Data.DataRow
            'Elimina Detalle
            foundRows = dtDetalle.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & sDOCClave & "'")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    dtDetalle.Rows.Remove(foundRows(i))
                Next

            End If

            'Elimina Pedido
            foundRows = dtDoctos.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & sDOCClave & "'")
            If foundRows.GetLength(0) > 0 Then
                dtDoctos.Rows.Remove(foundRows(0))
            End If
        End If


    End Sub

    Private Sub reiniciaRuta()
        EMPClave = ""
        TRAClave = ""
        txtEconomico.Text = ""
        lblPlacas.Text = ""
        TxtEmpleado.Text = ""
        lblNomOperador.Text = ""
    End Sub

    Private Sub CargaDatosTransporte(ByVal sTRAClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_transporte", "@TRAClave", sTRAClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TRAClave = dt.Rows(0)("TRAClave")
            txtEconomico.Text = dt.Rows(0)("noEconomico")
            lblPlacas.Text = dt.Rows(0)("Placa")
            VencimientoPoliza = CDate(dt.Rows(0)("Vencimiento"))
            dt.Dispose()
        Else
            TRAClave = ""
            txtEconomico.Text = ""
            lblPlacas.Text = ""
            VencimientoPoliza = Date.Today.ToShortDateString

            MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub CargaDatosEmpleado(ByVal sEMPClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_empleado", "@EMPClave", sEMPClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            EMPClave = dt.Rows(0)("EMPClave")
            TxtEmpleado.Text = dt.Rows(0)("NumEmpleado")
            lblNomOperador.Text = dt.Rows(0)("NombreCompleto")
            VencimientoLicencia = IIf(dt.Rows(0)("Vencimiento").GetType.Name = "DBNull", DateTime.Today.ToShortDateString, CDate(dt.Rows(0)("Vencimiento")))
            dt.Dispose()
        Else
            EMPClave = ""
            TxtEmpleado.Text = ""
            lblNomOperador.Text = ""
            VencimientoLicencia = DateTime.Today.ToShortDateString
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub addDetalle(ByVal sDOCClave As String, _
        ByVal iTipo As Integer, _
        ByVal sT As String, _
        ByVal sFolio As String, _
        ByVal sPROClave As String, _
        ByVal iTProducto As Integer, _
        ByVal iSeguimiento As Integer, _
        ByVal iDiasGarantia As Integer, _
        ByVal sClave As String, _
        ByVal sNombre As String, _
        ByVal sUbicacion As String, _
        ByVal dCantidad As Double, _
        ByVal dSurtido As Double, _
        ByVal iTipoRechazo As Integer, _
        ByVal dVolSolicitado As Double, _
        ByVal dVol As Double, _
        ByVal sUBCClave As String, _
        ByVal dUnd As Double, _
        ByVal iRF As Integer, _
        ByVal iRechazoRF As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & sDOCClave & "' and PROClave = '" & sPROClave & "' and UBCClave='" & sUBCClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("DOCClave") = sDOCClave
            row1.Item("Tipo") = iTipo
            row1.Item("T") = sT
            row1.Item("Folio") = sFolio
            row1.Item("PROClave") = sPROClave
            row1.Item("TProducto") = iTProducto
            row1.Item("Seguimiento") = iSeguimiento
            row1.Item("DiasGarantia") = iDiasGarantia
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Ubicación") = sUbicacion
            row1.Item("Cantidad") = dCantidad
            row1.Item("TipoRechazo") = iTipoRechazo
            row1.Item("VolSolicitado") = dVolSolicitado
            If ChkTodos.Checked = True Then
                row1.Item("VolSurtido") = dVolSolicitado
                row1.Item("Surtido") = dCantidad
                row1.Item("SurtidoStage") = dCantidad
            Else
                row1.Item("Surtido") = dSurtido
                row1.Item("SurtidoStage") = dSurtido
                row1.Item("VolSurtido") = 0
            End If
            row1.Item("Vol") = dVol
            row1.Item("UBCClave") = sUBCClave
            row1.Item("Und") = dUnd
            row1.Item("RF") = iRF
            row1.Item("RechazoRF") = iRechazoRF

            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

        End If



    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TRAClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If EMPClave = "" Then
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

    Private Sub FrmPicking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bLoad = False

        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        For i = 0 To dt.Rows.Count - 1
            Select Case CStr(dt.Rows(i)("PARClave"))
                Case "InterfazSalida"
                    InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Exit Select
            End Select
        Next
        dt.Dispose()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox3

        cmbTipo.SelectedItem = "Venta"

        PICClave = ModPOS.obtenerLlave

        dtDoctos = ModPOS.CrearTabla("Documentos", _
            "ENVClave", "System.String", _
            "DOCClave", "System.String", _
            "Tipo", "System.Int32", _
            "T", "System.String", _
            "Folio", "System.String", _
            "Fecha", "System.DateTime", _
            "TipoEntrega", "System.Int32", _
            "Clave", "System.String", _
            "id_Fiscal", "System.String", _
            "RazonSocial", "System.String", _
            "Total", "System.Double", _
            "Calle", "System.String", _
            "Domicilio1", "System.String", _
            "Domicilio2", "System.String", _
            "Referencia", "System.String", _
            "formaEnvio", "System.String", _
            "Observaciones", "System.String", _
            "fechaPrevista", "System.DateTime", _
            "fechaEfectiva", "System.DateTime", _
            "Orden", "System.Int32", _
            "Ruta", "System.String", _
            "Stage", "System.String")


        GridDoctos.DataSource = dtDoctos
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.RootTable.Columns("ENVClave").Visible = False
        GridDoctos.RootTable.Columns("DOCClave").Visible = False
        GridDoctos.RootTable.Columns("Tipo").Visible = False
        GridDoctos.CurrentTable.Columns("T").Selectable = False
        GridDoctos.CurrentTable.Columns("Folio").Selectable = False
        GridDoctos.CurrentTable.Columns("Fecha").Selectable = False

        GridDoctos.RootTable.Columns("TipoEntrega").Visible = False
        GridDoctos.RootTable.Columns("Clave").Visible = False
        GridDoctos.RootTable.Columns("id_Fiscal").Visible = False
        GridDoctos.RootTable.Columns("RazonSocial").Visible = False
        GridDoctos.RootTable.Columns("Total").Visible = False
        GridDoctos.RootTable.Columns("Calle").Visible = False
        GridDoctos.RootTable.Columns("Domicilio1").Visible = False
        GridDoctos.RootTable.Columns("Domicilio2").Visible = False
        GridDoctos.RootTable.Columns("Referencia").Visible = False
        GridDoctos.RootTable.Columns("formaEnvio").Visible = False
        GridDoctos.RootTable.Columns("Observaciones").Visible = False
        GridDoctos.RootTable.Columns("fechaPrevista").Visible = False
        GridDoctos.RootTable.Columns("fechaEfectiva").Visible = False
        GridDoctos.RootTable.Columns("Ruta").Visible = False
        GridDoctos.RootTable.Columns("Orden").Visible = False
        GridDoctos.RootTable.Columns("Stage").Visible = False
        GridDoctos.CurrentTable.Columns("T").Selectable = False

        GridDoctos.RootTable.Columns("T").Width = 4
        GridDoctos.RootTable.Columns("Folio").Width = 20
        GridDoctos.RootTable.Columns("Fecha").Width = 20

        dtDetalle = ModPOS.CrearTabla("Detalle", _
        "DOCClave", "System.String", _
        "Tipo", "System.Int32", _
        "T", "System.String", _
        "Folio", "System.String", _
        "PROClave", "System.String", _
        "TProducto", "System.Int32", _
        "Seguimiento", "System.Int32", _
        "DiasGarantia", "System.Int32", _
        "Clave", "System.String", _
        "Nombre", "System.String", _
        "Ubicación", "System.String", _
        "Cantidad", "System.Double", _
        "Surtido", "System.Double", _
        "SurtidoStage", "System.Double", _
        "TipoRechazo", "System.Int32", _
        "VolSolicitado", "System.Double", _
        "VolSurtido", "System.Double", _
        "Vol", "System.Double", _
        "UBCClave", "System.String", _
        "Und", "System.Double", _
        "RF", "System.Int32", _
        "RechazoRF", "System.Int32")

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DOCClave").Visible = False
        GridDetalle.RootTable.Columns("Tipo").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
        GridDetalle.RootTable.Columns("VolSolicitado").Visible = False
        GridDetalle.RootTable.Columns("VolSurtido").Visible = False
        GridDetalle.RootTable.Columns("Vol").Visible = False
        GridDetalle.RootTable.Columns("UBCClave").Visible = False
        GridDetalle.RootTable.Columns("SurtidoStage").Visible = False
        GridDetalle.RootTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Ubicación").Selectable = False
        GridDetalle.CurrentTable.Columns("Cantidad").Selectable = False
        GridDetalle.CurrentTable.Columns("T").Selectable = False
        GridDetalle.CurrentTable.Columns("Folio").Selectable = False
        GridDetalle.RootTable.Columns("RechazoRF").Visible = False

        GridDetalle.RootTable.Columns("T").Width = 6
        GridDetalle.RootTable.Columns("Folio").Width = 40
        GridDetalle.RootTable.Columns("Clave").Width = 70
        GridDetalle.RootTable.Columns("Cantidad").Width = 30
        GridDetalle.RootTable.Columns("Surtido").Width = 30
        GridDetalle.RootTable.Columns("Ubicación").Width = 60
        GridDetalle.RootTable.Columns("TipoRechazo").Width = 60
        GridDetalle.RootTable.Columns("RF").Visible = False

        GridDetalle.CurrentTable.Columns("TipoRechazo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("TipoRechazo").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoRechazo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Surtido", "@Campo", "TipoRechazo")


            For i = 0 To dtTipoRechazo.Rows.Count - 1
                .Add(dtTipoRechazo.Rows(i)("valor"), dtTipoRechazo.Rows(i)("descripcion"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("TipoRechazo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Surtido"), Janus.Windows.GridEX.ConditionOperator.NotEqual, GridDetalle.GetValue("Cantidad"))
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

        If Documentos <> "" Then
            If Documentos.Split("|").Length >= 1 Then
                Dim Docto As String
                For i = 0 To Documentos.Split("|").Length - 1
                    Docto = Documentos.Split("|")(i)
                    cargaDocto(CStr(Docto.Split(",")(0)), CInt(Docto.Split(",")(1)))
                Next
            End If
            If GridDoctos.RowCount > 0 Then
                cargaDatosDocto(GridDoctos.GetValue("DOCClave"), CInt(GridDoctos.GetValue("Tipo")))
            End If
        End If


        With cmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Surtido"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoRechazo"
            .llenar()
        End With

     

        bLoad = True

        If Me.TRAClave <> "" Then
            CargaDatosTransporte(TRAClave)
            If Me.EMPClave <> "" Then
                CargaDatosEmpleado(EMPClave)
            End If
        End If

       


    End Sub

    Private Sub FrmPikcing_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bSurtido = False Then

            If dtDoctos.Rows.Count > 0 Then
                Beep()
                Select Case MessageBox.Show("Se perderan todos los cambios ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.No
                        e.Cancel = True
                        Exit Sub
                End Select

                ModPOS.Ejecuta("sp_libera_picking", "@PICClave", PICClave)
            End If

        Else
            If Not ModPOS.Surtido Is Nothing Then

                ModPOS.Surtido.AgregarFolio()

            End If
        End If

        ModPOS.Picking.Dispose()
        ModPOS.Picking = Nothing

    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Valida si existen productos pendientes de surtir
        If bSurtido = False Then

            If dtDetalle.Rows.Count = 0 Then
                MessageBox.Show("No se encuntraron partidas de producto por surtir,falta agregar un documento", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim dSolicitado, dSurtido As Double
            Dim foundRows() As DataRow
            Dim i, j As Integer

            If dtDoctos.Rows.Count > 0 Then
                For i = 0 To dtDoctos.Rows.Count - 1
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("PICClave") <> PICClave OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                            MessageBox.Show("El docuemnto " & dtDoctos.Rows(i)("Folio") & " ya se encuentra abierto en otro surtido por lo que sera removido del proceso actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            remueveDocumento(dtDoctos.Rows(i)("Tipo"), dtDoctos.Rows(i)("DOCClave"))
                        End If
                    End If
                Next
            End If

            dSurtido = dtDetalle.Compute("SUM(Surtido)", "")

            If dSurtido = 0 Then

                Select Case MessageBox.Show("No es posible confirmar el surtido sin por lo menos una mercancia entregada. ¿Desea continuar y cancelar el(los) documentos actuales?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case System.Windows.Forms.DialogResult.No
                        Exit Sub
                    Case System.Windows.Forms.DialogResult.Yes
                        Dim a As New MeAutorizacion
                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = dtDoctos.Compute("SUM(Total)", "")
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then
                                Dim Autoriza As String = a.Autoriza
                                Dim bmotivo As Boolean
                                Dim motCancelacion As Integer
                                foundRows = dtDoctos.Select()
                                For i = 0 To foundRows.GetUpperBound(0)
                                    If foundRows(i)("Tipo") = 1 Then

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
                                        'ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Total"))
                                        ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                                    ElseIf foundRows(i)("Tipo") = 8 Then
                                        ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@USRClave", ModPOS.UsuarioActual)
                                    ElseIf foundRows(i)("iTipo") = 6 Then
                                        ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    ElseIf foundRows(i)("iTipo") = 10 Then
                                        ModPOS.Ejecuta("st_cancela_devcompra", "@DEVClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", foundRows(i)("Tipo"), "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)
                                Next
                                bSurtido = True
                                Me.Close()
                            End If
                        End If

                End Select
            Else


                dSolicitado = dtDetalle.Compute("SUM(Cantidad)", "")
                If dSolicitado > dSurtido Then
                    Beep()
                    Select Case MessageBox.Show("Existe mercancia pendiente de recolectar. ¿Desea continuar y cancelar la mercancia faltante?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Case DialogResult.No
                            Exit Sub
                    End Select

                    foundRows = dtDetalle.Select("Cantidad > Surtido and (TipoRechazo = 0 or TipoRechazo is Null)")
                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("No se ha especificado tipo de Rechazo de la mercancia no surtida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

                'Valida que el cliente haya revisado la mercancia
                foundRows = dtDoctos.Select("TipoEntrega = 1 and Tipo = 1")
                If foundRows.GetLength(0) > 0 Then
                    Beep()
                    Select Case MessageBox.Show("¿El Cliente reviso la mercancia?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.No
                            Exit Sub
                    End Select
                End If


                foundRows = dtDoctos.Select("TipoEntrega = 2 and Tipo = 1")
                If foundRows.GetLength(0) > 0 Then
                    If validaForm() = False Then
                        Beep()
                        MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                'Confirmación de recolección
                Beep()
                Select Case MessageBox.Show("¿Desea confirmar el Surtido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        Exit Sub
                End Select

                BtnGuardar.Enabled = False

                'Busca productos con seguimiento
                Dim Faltante As Double

                foundRows = dtDetalle.Select("Tipo=1 and Seguimiento > 1 and Surtido > 0")
                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        registraSeguimiento(foundRows(i)("Tipo"), foundRows(i)("DOCClave"), foundRows(i)("PROClave"), foundRows(i)("Clave"), foundRows(i)("Nombre"), foundRows(i)("Surtido"), foundRows(i)("Seguimiento"), foundRows(i)("DiasGarantia"))
                    Next
                End If


                'Actualiza Detalle y Libera apartados
                Dim Stage As String

                For i = 0 To dtDetalle.Rows.Count - 1

                    foundRows = dtDoctos.Select("DOCClave='" & dtDetalle.Rows(i)("DOCClave") & "' and Tipo = " & CStr(dtDetalle.Rows(i)("Tipo")) & "")

                    'Recupera las partidas del pedido que corresponden al producto actual
                    dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", dtDetalle.Rows(i)("Tipo"), "@DOCClave", dtDetalle.Rows(i)("DOCClave"), "@PROClave", dtDetalle.Rows(i)("PROClave"))

                    'Obtiene el faltante para la ubicacion y producto actual
                    Faltante = dtDetalle.Rows(i)("Cantidad") - dtDetalle.Rows(i)("Surtido")

                    'Si existe faltante, libera el apartado del faltante y actualiza partida del pedido


                    If Faltante > 0 Then

                        If dtDetalle.Rows(i)("RF") = 1 Then
                            If dtDetalle.Rows(i)("RechazoRF") = 1 Then
                                Stage = dtDetalle.Rows(i)("UBCClave")
                            Else
                                Stage = foundRows(0)("Stage")
                            End If
                        Else
                            Stage = dtDetalle.Rows(i)("UBCClave")
                        End If

                        For j = 0 To dtVentaDetalle.Rows.Count - 1
                            If dtVentaDetalle.Rows(j)("Cantidad") >= Faltante Then

                                If dtDetalle.Rows(i)("Tipo") = 1 Then
                                    recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), Faltante)
                                End If

                                ModPOS.Ejecuta("sp_actualiza_detalle_picking", _
                                                              "@ALMClave", ALMClave, _
                                                              "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                              "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                              "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                              "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                              "@Faltante", Faltante, _
                                                              "@UBCClave", Stage, _
                                                              "@TipoRechazo", dtDetalle.Rows(i)("TipoRechazo"), _
                                                              "@RF", dtDetalle.Rows(i)("RF"))
                                Exit For
                            Else

                                If dtDetalle.Rows(i)("Tipo") = 1 Then
                                    recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), dtVentaDetalle.Rows(j)("Cantidad"))
                                End If

                                ModPOS.Ejecuta("sp_actualiza_detalle_picking", _
                                                                          "@ALMClave", ALMClave, _
                                                                          "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                                          "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                                          "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                                          "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                                          "@Faltante", dtVentaDetalle.Rows(j)("Cantidad"), _
                                                                          "@UBCClave", Stage, _
                                                                          "@TipoRechazo", dtDetalle.Rows(i)("TipoRechazo"), _
                                                                          "@RF", dtDetalle.Rows(i)("RF"))

                                Faltante -= dtVentaDetalle.Rows(j)("Cantidad")
                            End If
                        Next
                    End If

                    ' Si hay producto surtido, actualiza la existencia del almacen y de la ubicacion
                    If dtDetalle.Rows(i)("Surtido") > 0 Then
                        ModPOS.Ejecuta("sp_surtido_picking", "@Tipo", dtDetalle.Rows(i)("Tipo"), "@DOCClave", dtDetalle.Rows(i)("DOCClave"), "@ALMClave", ALMClave, "@PROClave", dtDetalle.Rows(i)("PROClave"), "@UBCClave", dtDetalle.Rows(i)("UBCClave"), "@Cantidad", dtDetalle.Rows(i)("Surtido"), "@Stage", foundRows(0)("Stage"), "@Usuario", ModPOS.UsuarioActual, "@RF", dtDetalle.Rows(i)("RF"), "@DETClave", dtVentaDetalle.Rows(0)("DETClave"), "@Und", dtDetalle.Rows(i)("Und"))
                    End If

                Next
                'Elimina partidas con cantidad = cero
                Dim dtVenta, dtEliminados, dtRecalcula As DataTable

                If dtDoctos.Rows.Count > 0 Then
                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.Show("Procesando información...")

                    For i = 0 To dtDoctos.Rows.Count - 1

                        ModPOS.Ejecuta("st_actualiza_surtido", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)


                        dtEliminados = ModPOS.Recupera_Tabla("st_busca_eliminados_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                        If dtEliminados.Rows.Count > 0 Then
                            ModPOS.Ejecuta("sp_elimina_detalle_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                            dtRecalcula = ModPOS.Recupera_Tabla("st_recupera_doc_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                            If dtRecalcula.Rows.Count > 0 Then
                                Dim z As Integer
                                For z = 0 To dtRecalcula.Rows.Count - 1
                                    'Recalcula partidas
                                    ModPOS.Ejecuta("st_ac_partida_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@DETClave", dtRecalcula.Rows(z)("DETClave"), "@Partida", (z + 1) * 10)
                                Next
                            End If
                            dtRecalcula.Dispose()
                        End If
                        dtEliminados.Dispose()


                        If dtDoctos.Rows(i)("Tipo") = 1 Then 'Venta
                            ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", dtDoctos.Rows(i)("DOCClave"), "@Estado", 2)

                            dtVenta = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", dtDoctos.Rows(i)("DOCClave"))
                            If dtVenta.Rows.Count > 0 Then
                                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", dtVenta.Rows(0)("Cliente"), "@Importe", dtVenta.Rows(0)("Total"))
                            End If
                            dtVenta.Dispose()

                            ModPOS.GeneraMovInv(2, 1, 1, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual)


                            ModPOS.ActualizaExistUbc(2, 1, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Stage"))


                        ElseIf dtDoctos.Rows(i)("Tipo") = 8 Then ' Traslado
                            ModPOS.GeneraMovInv(2, 8, 8, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual)

                            ModPOS.ActualizaExistUbc(2, 8, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Stage"))


                            If InterfazSalida <> "" Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "TrasladoOUT", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("DOCClave"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                End If
                            End If


                        ElseIf dtDoctos.Rows(i)("Tipo") = 6 Then ' Traspaso
                            ModPOS.GeneraMovInv(2, 8, 6, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual)

                            ModPOS.ActualizaExistUbc(2, 6, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Stage"))

                        ElseIf dtDoctos.Rows(i)("Tipo") = 10 Then 'Devolucion Compra
                            ModPOS.GeneraMovInv(2, 2, 10, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual)

                            ModPOS.ActualizaExistUbc(2, 10, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Stage"))


                            If InterfazSalida <> "" Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "DevCompra", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("DOCClave"), "@TipoDocumento", 10, "@Path", InterfazSalida, "@Fecha", sFecha)
                                End If
                            End If


                        End If

                        ModPOS.Ejecuta("sp_modifica_envio_pic", _
                                                               "@Tipo", dtDoctos.Rows(i)("Tipo"), _
                                                               "@ENVClave", dtDoctos.Rows(i)("ENVClave"), _
                                                               "@Orden", dtDoctos.Rows(i)("Orden"), _
                                                               "@fechaEfectiva", dtDoctos.Rows(i)("fechaEfectiva"), _
                                                               "@TRAClave", TRAClave, _
                                                               "@Observaciones", dtDoctos.Rows(i)("Observaciones"), _
                                                               "@Referencia", dtDoctos.Rows(i)("Referencia"), _
                                                               "@EMPClave", EMPClave)
                    Next

                    frmStatusMessage.Close()

                End If

                'Actualiza Estado Picking



                bSurtido = True


                Select Case MessageBox.Show("¿Desea imprimir los documentos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        ImprimirDocumentos()
                End Select

                Me.Close()
            End If
        End If
    End Sub

    Private Sub ImprimirDocumentos()
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            Dim sImpresora As String = PrintDialog1.PrinterSettings.PrinterName
            Dim iCopias As String = PrintDialog1.PrinterSettings.Copies
            Dim i As Integer

            If dtDoctos.Rows.Count > 0 Then
                For i = 0 To dtDoctos.Rows.Count - 1
                    If dtDoctos.Rows(i)("Tipo") = 1 Then
                        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", dtDoctos.Rows(i)("DOCClave"))
                        Dim TotalVenta As Double = dt.Rows(0)("Total")
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", dtDoctos.Rows(i)("DOCClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", dtDoctos.Rows(i)("DOCClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.Print(iCopias, "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(dtDoctos.Rows(i)("Total"), 2)).ToUpper, sImpresora)
                    ElseIf dtDoctos.Rows(i)("Tipo") = 8 Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_traslado", "@TRSClave", dtDoctos.Rows(i)("DOCClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", dtDoctos.Rows(i)("DOCClave")))
                        OpenReport.Print(iCopias, "CRTraslado.rpt", pvtaDataSet, "", sImpresora)

                    ElseIf dtDoctos.Rows(i)("Tipo") = 6 Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", dtDoctos.Rows(i)("DOCClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", dtDoctos.Rows(i)("DOCClave")))
                        OpenReport.Print(iCopias, "CRTransferencia.rpt", pvtaDataSet, "", sImpresora)


                    ElseIf dtDoctos.Rows(i)("Tipo") = 10 Then
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_devcompra", "@DEVClave", dtDoctos.Rows(i)("DOCClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_devcompra", "@DEVClave", dtDoctos.Rows(i)("DOCClave")))
                        OpenReport.Print(iCopias, "CRDevCompra.rpt", pvtaDataSet, "", sImpresora)



                    End If
                Next
            End If

        End If
    End Sub

    Private Sub registraSeguimiento(ByVal iTipo As Integer, ByVal sDOCClave As String, ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal dCantidad As Double, ByVal iSeguimiento As Integer, ByVal iDiasGarantia As Integer)
        'SI REQUIERE SEGUIMIENTO DE SERIAL
        If iSeguimiento = 2 Then
            Dim SerialReg As Integer = 0
            Dim PorRegistrar As Double
            PorRegistrar = dCantidad
            Do
                Dim a As New FrmSerial
                a.TipoDoc = iTipo
                a.TipoMov = 2
                a.DOCClave = sDOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.Cantidad = PorRegistrar
                a.Dias = iDiasGarantia
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
                a.DOCClave = sDOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.CantXRegistrar = PorRegistrar
                a.TipoDoc = iTipo
                a.TipoMov = 2
                a.ShowDialog()
                LoteReg = LoteReg + a.NumSerialRegistrados
                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                a.Dispose()
            Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
        End If

    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Surtido" Then
            If IsNumeric(GridDetalle.GetValue("Surtido")) Then
                Select Case CDbl(GridDetalle.GetValue("Surtido"))
                    Case Is > CDbl(GridDetalle.GetValue("Cantidad"))
                        Beep()
                        MessageBox.Show("¡La cantidad a surtir no de ser mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If CInt(GridDetalle.GetValue("RF")) = 1 Then
                            GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("SurtidoStage")))
                        Else
                            GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("Cantidad")))
                        End If
                    Case Is < 0
                        GridDetalle.SetValue("Surtido", 0)
                    Case Is > CDbl(GridDetalle.GetValue("SurtidoStage"))
                        If CInt(GridDetalle.GetValue("RF")) = 1 Then
                            Beep()
                            MessageBox.Show("¡La cantidad a surtir no de ser mayor a la recolectada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("SurtidoStage")))
                        End If
                End Select

                If GridDetalle.RootTable.FormatConditions.Count = 1 Then
                    Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
                    fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Surtido"), Janus.Windows.GridEX.ConditionOperator.Equal, GridDetalle.GetValue("Cantidad"))
                    fc1.FormatStyle.ForeColor = System.Drawing.Color.Black
                    GridDetalle.RootTable.FormatConditions.Add(fc1)
                End If

            Else
                GridDetalle.SetValue("Surtido", 0)
            End If
        ElseIf GridDetalle.CurrentColumn.Caption = "Und" Then
            If Not IsNumeric(GridDetalle.GetValue("Und")) Then
                GridDetalle.SetValue("Und", 0)
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) = 0 Then
                    dCantidad = 1
                    TxtCantidad.Text = CStr(dCantidad)
                Else
                    dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            End If
            TxtProducto.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) = 0 Then
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            dCantidad = 1
            TxtCantidad.Text = CStr(dCantidad)
        End If

        TxtProducto.Focus()

    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub

    Private Sub BtnBusquedaTransporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaTransporte.Click
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

    Private Sub BtnOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOperador.Click
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
                    Else
                        TRAClave = ""
                        txtEconomico.Text = ""
                        lblPlacas.Text = ""
                        VencimientoPoliza = Date.Today.ToShortDateString

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

    Private Sub GridPedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDoctos.Click
        If bLoad = True AndAlso Not GridDoctos.GetValue(0) Is Nothing Then
            Me.cargaDatosDocto(CStr(GridDoctos.GetValue("DOCClave")), CInt(GridDoctos.GetValue("Tipo")))
        End If
    End Sub

    Private Sub GridPedidos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDoctos.SelectionChanged
        If bLoad = True AndAlso Not GridDoctos.GetValue(0) Is Nothing Then
            Me.cargaDatosDocto(CStr(GridDoctos.GetValue("DOCClave")), CInt(GridDoctos.GetValue("Tipo")))

        End If
    End Sub


    Private Sub remueveDocumento(ByVal Tipo As Integer, ByVal DOCClave As String)
        ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", GridDoctos.GetValue("Tipo"), "@PICClave", Nothing, "@DOCClave", DOCClave, "@Usuario", ModPOS.UsuarioActual)

        If Tipo = 1 Then
            ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", DOCClave, "@Estado", 7)
        ElseIf Tipo = 8 Then
            ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", DOCClave, "@Estado", 5)
        ElseIf Tipo = 6 Then
            ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", DOCClave, "@Estado", 5)
        ElseIf Tipo = 10 Then
            ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", DOCClave, "@Estado", 5)
        End If
        'Elimina Detalle

        Dim foundRows() As System.Data.DataRow

        foundRows = dtDetalle.Select("Tipo = " & CStr(Tipo) & " and DOCClave = '" & DOCClave & "'")

        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                dtDetalle.Rows.Remove(foundRows(i))
            Next

        End If

        'Elimina Pedido
        foundRows = dtDoctos.Select("Tipo = " & CStr(Tipo) & " and DOCClave = '" & DOCClave & "'")
        If foundRows.GetLength(0) > 0 Then
            dtDoctos.Rows.Remove(foundRows(0))
        End If

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If DOCClave <> "" Then

            If MessageBox.Show("¿Esta seguro de remover el ticket " & GridDoctos.GetValue("Folio") & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                'Cambia Estado
                remueveDocumento(GridDoctos.GetValue("Tipo"), DOCClave)
            End If

        Else
            MessageBox.Show("No se encuentra algun ticket seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TxtTicket_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTicket.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If Not TxtTicket.Text = vbNullString Then
                If cmbTipo.SelectedItem Is Nothing Then
                    MessageBox.Show("No se ha seleccionado tipo de documento para realizar la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                CargaDatosTicket(cmbTipo.SelectedItem, DateTime.Today.Year(), DateTime.Today.Month(), TxtTicket.Text.ToUpper.Trim.Replace("'", "''"))
                TxtTicket.Text = ""
            End If
        End If
    End Sub

    Private Sub txtOrden_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrden.ValueChanged

        If DOCClave <> "" Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDoctos.Select("DOCClave = '" & DOCClave & "'")
            foundRows(0)("Orden") = txtOrden.Text

        End If
    End Sub

    Private Sub dtFechaEfectiva_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaEfectiva.ValueChanged
        If DOCClave <> "" Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDoctos.Select("DOCClave = '" & DOCClave & "'")
            foundRows(0)("fechaEfectiva") = dtFechaEfectiva.Value
        End If
    End Sub

    Private Sub TxtNota_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNota.Leave
        If DOCClave <> "" Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDoctos.Select("DOCClave = '" & DOCClave & "'")
            foundRows(0)("Observaciones") = TxtNota.Text

        End If
    End Sub

    Private Sub TxtReferencia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReferencia.Leave
        If DOCClave <> "" Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDoctos.Select("DOCClave = '" & DOCClave & "'")
            foundRows(0)("Referencia") = TxtReferencia.Text

        End If
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaTicket.Click
        If cmbTipo.SelectedItem Is Nothing Then
            MessageBox.Show("No se ha seleccionado tipo de documento para realizar la busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim iTipo As Integer

        Select Case CStr(cmbTipo.SelectedItem)
            Case Is = "Venta"
                iTipo = 1
            Case Is = "Traslado"
                iTipo = 8
            Case Is = "Salida"
                iTipo = 6
            Case Is = "Devolución"
                iTipo = 10
        End Select

        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_recupera_docto_surtido"
        a.AlmRequerido = True
        a.TipoRequerido = True
        a.BusquedaInicial = True
        a.Tipo = iTipo
        a.ALMClave = Me.ALMClave
        a.TablaCmb = "Surtido"
        a.CampoCmb = "Busqueda"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then

                cargaDocto(a.valor, iTipo)
            End If
        End If
        a.Dispose()
        TxtTicket.Focus()
    End Sub

    Private Function CargaDatosTicket(ByVal sTipo As String, ByVal Periodo As Integer, ByVal Mes As Integer, ByVal Folio As String) As Boolean
        'Valida que el campo Ticket no se encuentre vacio
        Dim dt As DataTable
        If sTipo = "Venta" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 1, "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@ALMClave", ALMClave, "@Estado", 7)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("VENClave"), 1)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Venta introducido no esta disponible para Recolectar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        ElseIf sTipo = "Traslado" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 8, "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@ALMClave", ALMClave, "@Estado", 5)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("TRSClave"), 8)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Traslado introducido no esta disponible para Recolectar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        ElseIf sTipo = "Salida" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 6, "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@ALMClave", ALMClave, "@Estado", 5)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("MVAClave"), 6)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio del documento introducido no esta disponible para Recolectar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

        ElseIf sTipo = "Devolución" Then
            dt = ModPOS.SiExisteRecupera("sp_busca_ticket_edo", "@Tipo", 10, "@Periodo", Periodo, "@Mes", Mes, "@Folio", Folio, "@ALMClave", ALMClave, "@Estado", 5)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Me.cargaDocto(dt.Rows(0)("DEVClave"), 10)
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("El folio de Devolución introducido no esta disponible para Recolectar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        End If

    End Function

    Private Sub TxtEmpleado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmpleado.KeyUp
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
                        VencimientoLicencia = DateTime.Today.ToShortDateString
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

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtDetalle.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    If CInt(GridDetalle.GetDataRows(i).DataRow("RF")) = 0 Then
                        GridDetalle.GetDataRows(i).DataRow("Surtido") = GridDetalle.GetDataRows(i).DataRow("Cantidad")
                    End If
                Next
            Else
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    If CInt(GridDetalle.GetDataRows(i).DataRow("RF")) = 0 Then
                        GridDetalle.GetDataRows(i).DataRow("Surtido") = 0
                    End If
                Next
            End If
            dtDetalle.AcceptChanges()

            GridDetalle.Refresh()
        End If
    End Sub

    Private Sub cmbMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivo.SelectedValueChanged
        If bLoad = True Then
            If dtDetalle.Rows.Count > 0 AndAlso Not cmbMotivo.SelectedValue Is Nothing Then
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("Surtido") = 0 AndAlso CInt(dtDetalle.Rows(i)("RF")) = 0 Then
                        dtDetalle.Rows(i)("TipoRechazo") = cmbMotivo.SelectedValue
                    End If
                Next
                dtDetalle.AcceptChanges()

            End If
        End If
    End Sub
End Class
