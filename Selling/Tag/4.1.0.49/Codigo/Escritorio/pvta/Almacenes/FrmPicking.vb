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
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents cmbMotivo As Selling.StoreCombo
    Friend WithEvents btnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDoctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents gridPaquete As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnEditar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelPaq As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddPaq As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPrnLabel As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbRecolector As Selling.StoreCombo
    Friend WithEvents btnParcial As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnReiniciar As Janus.Windows.EditControls.UIButton
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
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbRecolector = New Selling.StoreCombo()
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
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GridDoctos = New Janus.Windows.GridEX.GridEX()
        Me.BtnBuscaTicket = New Janus.Windows.EditControls.UIButton()
        Me.TxtTicket = New System.Windows.Forms.TextBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gridPaquete = New Janus.Windows.GridEX.GridEX()
        Me.btnEditar = New Janus.Windows.EditControls.UIButton()
        Me.btnDelPaq = New Janus.Windows.EditControls.UIButton()
        Me.btnAddPaq = New Janus.Windows.EditControls.UIButton()
        Me.btnPrnLabel = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnParcial = New Janus.Windows.EditControls.UIButton()
        Me.btnReiniciar = New Janus.Windows.EditControls.UIButton()
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPaquete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.lblEnvio.Size = New System.Drawing.Size(207, 16)
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
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.Label7)
        Me.GrpDetalle.Controls.Add(Me.cmbRecolector)
        Me.GrpDetalle.Controls.Add(Me.cmbMotivo)
        Me.GrpDetalle.Controls.Add(Me.ChkTodos)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(195, 196)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(590, 353)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(281, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Recolector"
        '
        'cmbRecolector
        '
        Me.cmbRecolector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRecolector.Location = New System.Drawing.Point(377, 8)
        Me.cmbRecolector.Name = "cmbRecolector"
        Me.cmbRecolector.Size = New System.Drawing.Size(207, 21)
        Me.cmbRecolector.TabIndex = 130
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.Location = New System.Drawing.Point(377, 35)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(207, 21)
        Me.cmbMotivo.TabIndex = 129
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(264, 35)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(107, 22)
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
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 61)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(577, 287)
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Icon = CType(resources.GetObject("btnImprimir.Icon"), System.Drawing.Icon)
        Me.btnImprimir.Location = New System.Drawing.Point(502, 555)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.btnImprimir.TabIndex = 159
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir filas seleccionadas"
        Me.btnImprimir.Visible = False
        Me.btnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        'GridDoctos
        '
        Me.GridDoctos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDoctos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridDoctos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDoctos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDoctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDoctos.Location = New System.Drawing.Point(6, 61)
        Me.GridDoctos.Name = "GridDoctos"
        Me.GridDoctos.Size = New System.Drawing.Size(170, 154)
        Me.GridDoctos.TabIndex = 7
        Me.GridDoctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnBuscaTicket
        '
        Me.BtnBuscaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaTicket.Image = CType(resources.GetObject("BtnBuscaTicket.Image"), System.Drawing.Image)
        Me.BtnBuscaTicket.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaTicket.Location = New System.Drawing.Point(141, 13)
        Me.BtnBuscaTicket.Name = "BtnBuscaTicket"
        Me.BtnBuscaTicket.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaTicket.TabIndex = 16
        Me.BtnBuscaTicket.ToolTipText = "Busqueda de Ticket"
        Me.BtnBuscaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(6, 14)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(90, 21)
        Me.TxtTicket.TabIndex = 15
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(102, 13)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(35, 22)
        Me.BtnDel.TabIndex = 17
        Me.BtnDel.ToolTipText = "Remueve el Ticket Seleccionado "
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Venta", "Traslado", "Salida", "Devolución"})
        Me.cmbTipo.Location = New System.Drawing.Point(5, 38)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(171, 21)
        Me.cmbTipo.TabIndex = 138
        '
        'gridPaquete
        '
        Me.gridPaquete.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridPaquete.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.gridPaquete.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridPaquete.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.gridPaquete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridPaquete.Location = New System.Drawing.Point(6, 249)
        Me.gridPaquete.Name = "gridPaquete"
        Me.gridPaquete.Size = New System.Drawing.Size(170, 99)
        Me.gridPaquete.TabIndex = 139
        Me.gridPaquete.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Icon = CType(resources.GetObject("btnEditar.Icon"), System.Drawing.Icon)
        Me.btnEditar.Location = New System.Drawing.Point(102, 221)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(35, 22)
        Me.btnEditar.TabIndex = 141
        Me.btnEditar.ToolTipText = "Busqueda de Ticket"
        Me.btnEditar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelPaq
        '
        Me.btnDelPaq.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelPaq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelPaq.Icon = CType(resources.GetObject("btnDelPaq.Icon"), System.Drawing.Icon)
        Me.btnDelPaq.Location = New System.Drawing.Point(20, 221)
        Me.btnDelPaq.Name = "btnDelPaq"
        Me.btnDelPaq.Size = New System.Drawing.Size(35, 22)
        Me.btnDelPaq.TabIndex = 142
        Me.btnDelPaq.ToolTipText = "Remueve el paquete Seleccionado "
        Me.btnDelPaq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddPaq
        '
        Me.btnAddPaq.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPaq.Icon = CType(resources.GetObject("btnAddPaq.Icon"), System.Drawing.Icon)
        Me.btnAddPaq.Location = New System.Drawing.Point(141, 221)
        Me.btnAddPaq.Name = "btnAddPaq"
        Me.btnAddPaq.Size = New System.Drawing.Size(35, 22)
        Me.btnAddPaq.TabIndex = 143
        Me.btnAddPaq.ToolTipText = "Agregar nuevo contenedor o paquete"
        Me.btnAddPaq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPrnLabel
        '
        Me.btnPrnLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrnLabel.Icon = CType(resources.GetObject("btnPrnLabel.Icon"), System.Drawing.Icon)
        Me.btnPrnLabel.Location = New System.Drawing.Point(61, 221)
        Me.btnPrnLabel.Name = "btnPrnLabel"
        Me.btnPrnLabel.Size = New System.Drawing.Size(35, 22)
        Me.btnPrnLabel.TabIndex = 160
        Me.btnPrnLabel.ToolTipText = "Reimprimir Etiqueta"
        Me.btnPrnLabel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnPrnLabel)
        Me.GroupBox2.Controls.Add(Me.btnAddPaq)
        Me.GroupBox2.Controls.Add(Me.btnDelPaq)
        Me.GroupBox2.Controls.Add(Me.btnEditar)
        Me.GroupBox2.Controls.Add(Me.gridPaquete)
        Me.GroupBox2.Controls.Add(Me.cmbTipo)
        Me.GroupBox2.Controls.Add(Me.BtnDel)
        Me.GroupBox2.Controls.Add(Me.TxtTicket)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaTicket)
        Me.GroupBox2.Controls.Add(Me.GridDoctos)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(182, 353)
        Me.GroupBox2.TabIndex = 158
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'btnParcial
        '
        Me.btnParcial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParcial.Icon = CType(resources.GetObject("btnParcial.Icon"), System.Drawing.Icon)
        Me.btnParcial.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnParcial.Location = New System.Drawing.Point(406, 555)
        Me.btnParcial.Name = "btnParcial"
        Me.btnParcial.Size = New System.Drawing.Size(90, 37)
        Me.btnParcial.TabIndex = 160
        Me.btnParcial.Text = "&Parcial"
        Me.btnParcial.ToolTipText = "Guarda el Surtido Parcialmente"
        Me.btnParcial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnReiniciar
        '
        Me.btnReiniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReiniciar.Icon = CType(resources.GetObject("btnReiniciar.Icon"), System.Drawing.Icon)
        Me.btnReiniciar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnReiniciar.Location = New System.Drawing.Point(310, 555)
        Me.btnReiniciar.Name = "btnReiniciar"
        Me.btnReiniciar.Size = New System.Drawing.Size(90, 37)
        Me.btnReiniciar.TabIndex = 161
        Me.btnReiniciar.Text = "&Reiniciar"
        Me.btnReiniciar.ToolTipText = "Remover Confirmación"
        Me.btnReiniciar.Visible = False
        Me.btnReiniciar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPicking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.btnReiniciar)
        Me.Controls.Add(Me.btnParcial)
        Me.Controls.Add(Me.btnImprimir)
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
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPaquete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Picking As Boolean = True

    Public TallaColor As Integer = 0
    Public Empacador As String
    Public FormatoPedido As String
    Public InterfazSalida As String
    Public Documentos As String
    Public SUCClave As String
    Public ALMClave As String
    Public FecRegistro As DateTime
    Public ticketPicking As Boolean = False
    Public TIKClave As String
    Public Packing As Boolean = False
    Public ClaveSucursal, NombreSucursal, ClaveUsuario, NombreUsuario As String
    ' Private SurtidoRF As Boolean
    Private PICClave As String
    Private fechaEfectiva As Date = Today.Date
    Private TRAClave As String
    Private VencimientoPoliza As Date
    Private EMPClave As String
    Private VencimientoLicencia As Date
    Private dtPaquete, dtDoctos, dtDetalle, dtVentaDetalle, dtTipoRechazo, dtRecolector As DataTable
    Private bSurtido As Boolean = False
    Private DOCClave As String = ""
    Private Tipo As Integer
    Private sPROClave As String
    Private iTProducto As Integer
    Private dCantidad As Double
    Private iNumDecimales As Integer
    Private iFactor, iKgLt As Integer
    Private iSeguimiento As Integer
    Private iDiasGarantia As Integer
    Private bLoad As Boolean
    Private reloj As parpadea
    Private alerta(1) As PictureBox

    Private idSheet As String = ""
    Private TipoPapel As String = ""
    Private AnchoPapel As Integer
    Private AltoPapel As Integer
    Private mpSuperior As Integer
    Private mpInferior As Integer
    Private mpIzquierdo As Integer
    Private mpDerecho As Integer
    Private Horizontal As Boolean = False
    Private Columnas As Integer
    Private Filas As Integer
    Private EspacioColumna As Integer
    Private EspacioFila As Integer
    Private AnchoEtiqueta As Integer
    Private AltoEtiqueta As Integer
    Private meSuperior As Integer
    Private meInferior As Integer
    Private meIzquierdo As Integer
    Private meDerecho As Integer
    Private TipoLetra As String = ""
    Private SizeLetra As Single
    Private SizeCodigo As Single
    Private iFormaEnvio As Integer = 1


    Private Sub recalculaPartidaPedido(ByVal dtDetalle As DataTable, ByVal DOCClave As String, ByVal DETClave As String, ByVal dCantidadOriginal As Decimal, ByVal dFaltante As Decimal, ByVal iKgLt As Integer, ByVal PesoUnidad As Double)
        Dim foundRows() As DataRow
        Dim iTipoCanal As Integer = 0
        Dim msg As String = ""

        foundRows = dtDoctos.Select("DOCClave = '" & DOCClave & "'")
        If foundRows.GetLength(0) > 0 Then
            iTipoCanal = foundRows(0)("TipoCanal")
        End If

        foundRows = dtDetalle.Select("DETClave = '" & DETClave & "'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer

            Dim sTipoDesc As String = ""




            Dim TImpuesto As Integer
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", foundRows(0)("Cliente"), "@TipoCanal", iTipoCanal)
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
                                msg = ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual, "@Cerrado", 1)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

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
                        msg = ModPOS.Ejecuta("sp_actualiza_detalle", _
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

                        msg = ModPOS.Ejecuta("sp_actualiza_detalle", _
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

                If msg <> "OK" Then
                    MessageBox.Show(msg)
                End If




            Next



        End If
    End Sub

    Public Function surtirProducto(ByVal dtProducto As DataTable, ByVal dCantidad As Decimal, ByVal idPaquete As String, ByVal Recolector As String) As Boolean
        Dim msg As String = ""
        Dim dCantOriginal As Decimal = dCantidad

        Dim sClave As String = dtProducto.Rows(0)("Clave")
        sPROClave = dtProducto.Rows(0)("PROClave")
        iTProducto = dtProducto.Rows(0)("TProducto")
        iSeguimiento = dtProducto.Rows(0)("Seguimiento")
        iDiasGarantia = dtProducto.Rows(0)("DiasGarantia")
        iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
        iFactor = dtProducto.Rows(0)("Factor")
        iKgLt = dtProducto.Rows(0)("KgLt")
        dtProducto.Dispose()


        'Actualiza Surtido
        Dim foundRows() As System.Data.DataRow
        Dim result As DialogResult

        foundRows = dtDetalle.Select("PROClave = '" & sPROClave & "' and Cantidad > Surtido")
        If foundRows.Length >= 1 OrElse iKgLt = 1 Then
            Dim porSurtir As Double

            porSurtir = dtDetalle.Compute("SUM(Cantidad)", "PROClave = '" & sPROClave & "'")
            porSurtir -= dtDetalle.Compute("SUM(Surtido)", "PROClave = '" & sPROClave & "'")

            If porSurtir >= dCantidad OrElse iKgLt = 1 Then
                Dim i As Integer
                For i = 0 To foundRows.Length - 1

                    If foundRows(i)("RF") = 0 AndAlso foundRows(i)("Recolector") = "" Then
                        foundRows(i)("Recolector") = Recolector
                    End If

                    Select Case dCantidad
                        Case Is >= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))

                            If i = foundRows.Length - 1 Then
                                foundRows(i)("Surtido") += dCantidad
                                dCantidad = 0

                            Else
                                dCantidad -= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))
                                foundRows(i)("Surtido") = foundRows(i)("Cantidad")
                            End If

                            If dCantidad <= 0 Then
                                Exit For
                            End If
                        Case Is < CDbl(foundRows(i)("Cantidad") - foundRows(i)("Surtido"))
                            foundRows(i)("Surtido") += dCantidad
                            Exit For
                    End Select
                Next
                GridDetalle.Refresh()

                If idPaquete <> "" Then
                    'Agrega detalle de paquete
                    msg = Ejecuta("st_inserta_paqdet", "@IdPaquete", idPaquete, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Cantidad", dCantOriginal, "@Usuario", ModPOS.UsuarioActual)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If
                End If

                Return True
            Else
                Beep()
                Do
                    result = MessageBox.Show("La cantidad a surtir  del producto " & sClave & " es mayor a la solicitada", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                Loop While result = DialogResult.Cancel
                
                Return False
            End If
        Else
            Beep()
            Do
                result = MessageBox.Show("La cantidad  o producto " & sClave & " excede lo solicitado", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
            Loop While result = DialogResult.Cancel

            Return False
        End If
    End Function


    Public Function removerProducto(ByVal sPROClave As String, ByVal dCantidad As Decimal, ByVal idPaquete As String) As Boolean
        Dim msg As String = ""
        'Actualiza Surtido
        Dim foundRows() As System.Data.DataRow

        foundRows = dtDetalle.Select("PROClave = '" & sPROClave & "' and Surtido > 0")
        If foundRows.Length >= 1 OrElse iKgLt = 1 Then
            Dim porRemover As Decimal

            porRemover = dtDetalle.Compute("SUM(Cantidad)", "PROClave = '" & sPROClave & "'")

            If porRemover >= dCantidad OrElse iKgLt = 1 Then
                Dim i As Integer
                For i = 0 To foundRows.Length - 1

                    Select Case dCantidad
                        Case Is >= CDbl(foundRows(i)("Surtido"))

                            dCantidad -= foundRows(i)("Surtido")
                            foundRows(i)("Surtido") = 0

                            If dCantidad <= 0 Then
                                Exit For
                            End If
                        Case Is < CDbl(foundRows(i)("Surtido"))
                            foundRows(i)("Surtido") -= dCantidad
                            dCantidad = 0
                            Exit For
                    End Select
                Next
                GridDetalle.Refresh()

                If idPaquete <> "" AndAlso dCantidad = 0 Then
                    'Agrega detalle de paquete
                    msg = Ejecuta("st_elimina_paqdet", "@IdPaquete", idPaquete, "@PROClave", sPROClave)
                End If

                If msg <> "OK" Then
                    MessageBox.Show(msg)
                End If

                Return True
            Else
                Beep()
                MessageBox.Show("La cantidad  a remover es mayor a la surtida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Else
            Beep()
            MessageBox.Show("La cantidad  o producto excede lo surtido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function


    Private Sub leeCodigoBarras(ByVal Codigo As String)
        'valida surtidor
        If cmbRecolector.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un Recolector", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto
            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then



                iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                iFactor = dtProducto.Rows(0)("Factor")

                TxtCantidad.DecimalDigits = iNumDecimales

                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                    dCantidad = 1 * iFactor
                    TxtCantidad.Text = "1"
                Else
                    dCantidad = CDbl(TxtCantidad.Text) * iFactor
                End If

                If dtProducto.Rows(0)("TProducto") >= 7 Then
                    Dim dtMultiproducto As DataTable = ModPOS.Recupera_Tabla("sp_muestra_multiproductos", "@ProductoPadre", dtProducto.Rows(0)("PROClave"))
                    Dim j As Integer
                    For j = 0 To dtMultiproducto.Rows.Count - 1
                        If TallaColor = 1 Then
                            dtProducto = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", dtMultiproducto.Rows(j)("Modelo"), "@Char", cReplace, "@TallaColor", TallaColor)
                        Else
                            dtProducto = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", dtMultiproducto.Rows(j)("Clave"), "@Char", cReplace, "@TallaColor", TallaColor)
                        End If
                        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                            surtirProducto(dtProducto, dtMultiproducto.Rows(j)("Cantidad") * dCantidad, "", cmbRecolector.SelectedValue)
                        End If
                    Next

                Else
                    surtirProducto(dtProducto, dCantidad, "", cmbRecolector.SelectedValue)
                End If

                dtProducto.Dispose()

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
                Dim result As DialogResult
                Do
                    result = MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)
                Loop While result = System.Windows.Forms.DialogResult.Cancel

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

    Private Function AddDocto( _
    ByVal sPICClave As String, _
    ByVal sENVClave As String, _
    ByVal sDOCClave As String, _
    ByVal iTipo As Integer, _
    ByVal iTipoCanal As Integer, _
    ByVal iTipoAplicacion As Integer, _
    ByVal sT As String, _
    ByVal sFolio As String, _
    ByVal dFecha As String, _
    ByVal itipoEntrega As Integer, _
    ByVal sClave As String, _
    ByVal sRFC As String, _
    ByVal sRazonSocial As String, _
    ByVal dTotal As Double, _
    ByVal sMON As String, _
    ByVal sCalle As String, _
    ByVal sDomicilio1 As String, _
    ByVal sDomicilio2 As String, _
    ByVal sReferencia As String, _
    ByVal sformaEnvio As String, _
    ByVal sObservaciones As String, _
    ByVal dfechaPrevista As Date, _
    ByVal dfechaEfectiva As Date, _
    ByVal sRuta As String, _
    ByVal sStage As String, _
    ByVal dSaldoBase As Decimal, _
    ByVal sDestino As String) As Boolean

        Dim msg As String = ""

        Dim foundRows() As Data.DataRow
        foundRows = dtDoctos.Select("Tipo = " & CStr(iTipo) & "and  DOCClave = '" & sDOCClave & "'")

        If foundRows.Length = 0 Then

            If dtDetalle.Rows.Count = 0 Then

                If sPICClave <> "" Then
                    PICClave = sPICClave
                Else
                    PICClave = obtenerLlave()
                End If
            Else
                If sPICClave <> "" AndAlso sPICClave <> PICClave Then
                    MessageBox.Show("El documento " & sFolio & " se encuentra asignado a otro Surtido o esta siendo procesado en otro equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If


            If Packing = True Then
                Dim foundRows1() As DataRow
                foundRows1 = dtDoctos.Select("Tipo <> " & CStr(iTipo))

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben ser del mismo Tipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                foundRows1 = dtDoctos.Select("formaEnvio <> '" & sformaEnvio & "' and  TipoEntrega <> " & CStr(itipoEntrega))

                If foundRows1.GetLength(0) > 0 Then
                    MessageBox.Show("Todos los documentos seleccionados deben tener la misma forma de Envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If itipoEntrega = 3 Then
                    foundRows1 = dtDoctos.Select("Destino <> '" & sDestino & "'")

                    If foundRows1.GetLength(0) > 0 Then
                        MessageBox.Show("Todos los documentos seleccionados deben tener el mismo Destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If

                    If TxtProducto.Enabled = True Then
                        ChkTodos.Enabled = False
                        BtnBuscaProd.Enabled = False
                        TxtCantidad.Enabled = False
                        TxtProducto.Enabled = False
                        GridDetalle.CurrentTable.Columns("Surtido").Selectable = False
                        btnDelPaq.Enabled = True
                        btnPrnLabel.Enabled = True
                        btnEditar.Enabled = True
                        btnAddPaq.Enabled = True
                        gridPaquete.Enabled = True
                        btnParcial.Visible = True
                    End If
                Else
                    If btnDelPaq.Enabled = True Then
                        btnDelPaq.Enabled = False
                        btnPrnLabel.Enabled = False
                        btnEditar.Enabled = False
                        btnAddPaq.Enabled = False
                        gridPaquete.Enabled = False
                        btnParcial.Visible = True
                    End If
                End If




            End If


            Dim row1 As DataRow
            row1 = dtDoctos.NewRow()
            'declara el nombre de la fila
            row1.Item("ENVClave") = sENVClave
            row1.Item("DOCClave") = sDOCClave
            row1.Item("Tipo") = iTipo
            row1.Item("TipoCanal") = iTipoCanal
            row1.Item("TipoAplicacion") = iTipoAplicacion
            row1.Item("T") = sT
            row1.Item("Folio") = sFolio
            row1.Item("MON") = sMON
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
            row1.Item("SaldoBase") = dSaldoBase
            row1.Item("Destino") = sDestino

            dtDoctos.Rows.Add(row1)

            GridDoctos.AutoSizeColumns()
            GridDoctos.HorizontalScroll.Enabled = True
            'agrega la fila completo a la tabla

            msg = ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", iTipo, "@PICClave", PICClave, "@DOCClave", sDOCClave, "@Usuario", ModPOS.UsuarioActual, "@IP", IPAddress)

            If msg <> "OK" Then
                MessageBox.Show(msg)
            End If

            If iTipo = 1 Then
                msg = ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", sDOCClave, "@Estado", 8)
            ElseIf iTipo = 8 Then
                msg = ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", sDOCClave, "@Estado", 6)
            ElseIf iTipo = 6 Then
                msg = ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", DOCClave, "@Estado", 6)
            ElseIf iTipo = 10 Then
                msg = ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", DOCClave, "@Estado", 6)
            End If

            If msg <> "OK" Then
                MessageBox.Show(msg)
            End If

            Return True
        Else
            MessageBox.Show("¡El documento " & sFolio & ", que intenta agregar ya existe en la recolección actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Public Sub cargaDocto(ByVal sDOCClave As String, ByVal iTipo As Integer)

        Dim msg As String = ""
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


        Dim bCargaDetalle As Boolean

        myCommand = New System.Data.SqlClient.SqlCommand("sp_encabezado_envio", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@COMClave", SqlDbType.VarChar).Value = ModPOS.CompanyActual
        myCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = iTipo
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave

        dr = myCommand.ExecuteReader()

        While dr.Read

            iFormaEnvio = dr("iFormaEnvio")

            bCargaDetalle = AddDocto( _
            dr("PICClave"), _
            dr("ENVClave"), _
            dr("DOCClave"), _
            dr("Tipo"), _
            dr("TipoCanal"), _
            dr("TipoAplicacion"), _
            dr("T"), _
            dr("Folio"), _
            dr("Fecha"), _
            dr("tipoEntrega"), _
            dr("Clave"), _
            IIf(dr("Id_Fiscal").GetType.Name = "DBNull", "", dr("Id_Fiscal")), _
            dr("RazonSocial"), _
            dr("Total"), _
            dr("MON"), _
            dr("Calle"), _
            dr("Domicilio1"), _
            dr("Domicilio2"), _
            dr("Referencia"), _
            dr("formaEnvio"), _
            IIf(dr("Observaciones").GetType.Name = "DBNull", "", dr("Observaciones")), _
            IIf(dr("fechaPrevista").GetType.Name = "DBNull", Today.Date, dr("fechaPrevista")), _
            IIf(dr("fechaEfectiva").GetType.Name = "DBNull", Today.Date, dr("fechaEfectiva")), _
            IIf(dr("Ruta").GetType.Name = "DBNull", "", dr("Ruta")),
            dr("Stage"), _
            dr("SaldoBase"), _
            dr("Destino"))

            RF = dr("RF")

        End While

        myCommand.Dispose()
        dr.Close()

        If bCargaDetalle = True Then

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
                            IIf(dr("RechazoRF").GetType.ToString = "System.DBNull", 0, dr("RechazoRF")), _
                            dr("KgLt"), _
                            dr("Recolector"), _
                            dr("TipoProducto"))
            End While

            myCommand.Dispose()
            dr.Close()
            Cnx.Close()






            Dim dt As DataTable
            dt = Recupera_Tabla("st_valida_surtido", "@TipoDocumento", iTipo, "@DOCClave", sDOCClave)

            If dt.Rows.Count > 0 Then
                MessageBox.Show("Se encontro una diferencia entre la cantidad solicitada y la surtida en un documento, el cual se eliminara de este surtido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                msg = ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", iTipo, "@PICClave", Nothing, "@DOCClave", sDOCClave, "@Usuario", ModPOS.UsuarioActual)

                If msg <> "OK" Then
                    MessageBox.Show(msg)
                End If

                If iTipo = 1 Then
                    msg = ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", sDOCClave, "@Estado", 7)
                ElseIf iTipo = 8 Then
                    msg = ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", sDOCClave, "@Estado", 5)
                ElseIf iTipo = 6 Then
                    msg = ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", sDOCClave, "@Estado", 5)
                ElseIf iTipo = 10 Then
                    msg = ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", sDOCClave, "@Estado", 5)
                End If

                If msg <> "OK" Then
                    MessageBox.Show(msg)
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
            MessageBox.Show("La información del Empleado no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
        ByVal iRechazoRF As Integer, _
        ByVal iKgLt As Integer, _
        ByVal sRecolector As String, _
        ByVal sTipo As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & sDOCClave & "' and PROClave = '" & sPROClave & "' and UBCClave='" & sUBCClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("Marca") = 0
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
            row1.Item("KgLt") = iKgLt
            row1.Item("Recolector") = sRecolector
            row1.Item("TipoProducto") = sTipo
            dtDetalle.Rows.Add(row1)

            GridDetalle.AutoSizeColumns()
            GridDetalle.HorizontalScroll.Enabled = True
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


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox3

        cmbTipo.SelectedItem = "Venta"


        dtPaquete = ModPOS.CrearTabla("Paquete", _
                                      "T", "System.String", _
                                      "IdPaquete", "System.String", _
                                       "guia", "System.String", _
                                        "nota", "System.String"
                                      )

        gridPaquete.DataSource = dtPaquete
        gridPaquete.RetrieveStructure(True)
        gridPaquete.GroupByBoxVisible = False
        gridPaquete.AutoSizeColumns()
        gridPaquete.CurrentTable.Columns("guia").Visible = False
        gridPaquete.CurrentTable.Columns("nota").Visible = False
        gridPaquete.CurrentTable.Columns("T").Selectable = False
        gridPaquete.CurrentTable.Columns("IdPaquete").Selectable = False
        gridPaquete.RootTable.Columns("T").Width = 40
        gridPaquete.RootTable.Columns("IdPaquete").Width = 160
        Me.gridPaquete.HorizontalScroll.Enabled = True




        dtDoctos = ModPOS.CrearTabla("Documentos", _
            "ENVClave", "System.String", _
            "DOCClave", "System.String", _
            "TipoCanal", "System.Int32", _
            "TipoAplicacion", "System.Int32", _
            "Tipo", "System.Int32", _
            "T", "System.String", _
            "Folio", "System.String", _
            "Fecha", "System.DateTime", _
            "TipoEntrega", "System.Int32", _
            "Clave", "System.String", _
            "id_Fiscal", "System.String", _
            "RazonSocial", "System.String", _
            "Total", "System.Double", _
            "MON", "System.String", _
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
            "Stage", "System.String", _
            "SaldoBase", "System.Decimal", _
            "Destino", "System.String")


        GridDoctos.DataSource = dtDoctos
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.AutoSizeColumns()
        GridDoctos.RootTable.Columns("ENVClave").Visible = False
        GridDoctos.RootTable.Columns("DOCClave").Visible = False
        GridDoctos.RootTable.Columns("TipoCanal").Visible = False
        GridDoctos.RootTable.Columns("TipoAplicacion").Visible = False
        GridDoctos.RootTable.Columns("Tipo").Visible = False
        GridDoctos.CurrentTable.Columns("T").Selectable = False
        GridDoctos.CurrentTable.Columns("Folio").Selectable = False
        GridDoctos.CurrentTable.Columns("Fecha").Selectable = False

        GridDoctos.RootTable.Columns("Destino").Visible = False
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
        GridDoctos.RootTable.Columns("SaldoBase").Visible = False
        GridDoctos.CurrentTable.Columns("T").Selectable = False
        GridDoctos.CurrentTable.Columns("MON").Visible = False

        'GridDoctos.RootTable.Columns("T").Width = 4
        GridDoctos.RootTable.Columns("Folio").Width = 40
        GridDoctos.RootTable.Columns("Fecha").Width = 20
        'GridDoctos.RootTable.Columns("MON").Width = 6
        Me.GridDoctos.HorizontalScroll.Enabled = True

        dtDetalle = ModPOS.CrearTabla("Detalle", _
        "Marca", "System.Boolean", _
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
        "RechazoRF", "System.Int32", _
        "KgLt", "System.Int32", _
        "Recolector", "System.String", _
        "TipoProducto", "System.String")

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.AutoSizeColumns()
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
        GridDetalle.RootTable.Columns("KgLt").Visible = False
        GridDetalle.RootTable.Columns("Marca").Visible = ticketPicking
        btnImprimir.Visible = ticketPicking



        'GridDetalle.RootTable.Columns("T").Width = 6
        GridDetalle.RootTable.Columns("Folio").Width = 40
        'GridDetalle.RootTable.Columns("Clave").Width = 70
        'GridDetalle.RootTable.Columns("Cantidad").Width = 30
        'GridDetalle.RootTable.Columns("Surtido").Width = 30
        'GridDetalle.RootTable.Columns("Ubicación").Width = 60
        GridDetalle.RootTable.Columns("Recolector").Width = 60
        GridDetalle.RootTable.Columns("RF").Visible = False


        If TallaColor = 0 Then
            GridDetalle.RootTable.Columns("TipoProducto").Visible = False
        Else
            GridDetalle.RootTable.Columns("TipoProducto").Width = 80
            btnImprimir.Visible = False
            btnReiniciar.Visible = True
        End If


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

        GridDetalle.CurrentTable.Columns("Recolector").HasValueList = True
        Dim AircraftTypeValueListItemCollectionS As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionS = GridDetalle.Tables(0).Columns("Recolector").ValueList
        With AircraftTypeValueListItemCollectionS

            dtRecolector = ModPOS.Recupera_Tabla("st_filtra_usuario", "@Tipo", 2, "@SUCClave", SUCClave)

            For i = 0 To dtRecolector.Rows.Count - 1
                .Add(dtRecolector.Rows(i)("USRClave"), dtRecolector.Rows(i)("Referencia"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("Recolector").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Surtido"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)
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
        Me.GridDetalle.HorizontalScroll.Enabled = True


        With cmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Surtido"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoRechazo"
            .llenar()
        End With

        With cmbRecolector
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_usuario"
            .NombreParametro1 = "Tipo"
            .Parametro1 = 2
            .NombreParametro2 = "SUCClave"
            .Parametro2 = SUCClave
            .llenar()
        End With

        If Packing = True Then
            Dim dt As DataTable

            'Carga Paquetes
            dt = ModPOS.Recupera_Tabla("st_recupera_paquete", "@PICClave", PICClave)
            For i = 0 To dt.Rows.Count - 1
                AddPaquete(dt.Rows(i)("idPaquete"), dt.Rows(i)("sTipo"), dt.Rows(i)("guia"), dt.Rows(i)("nota"))
            Next

            dt = ModPOS.Recupera_Tabla("sp_filtra_labelsheet", "@Tipo", 3)

            If dt.Rows.Count > 0 Then
                idSheet = dt.Rows(0)("IDSheet")

            End If

            If idSheet <> "" Then

                dt = ModPOS.Recupera_Tabla("sp_recupera_labelsheet", "@IDSheet", idSheet)

                TipoPapel = dt.Rows(0)("Nombre")
                AnchoPapel = dt.Rows(0)("AnchoPapel")
                AltoPapel = dt.Rows(0)("AltoPapel")
                mpSuperior = dt.Rows(0)("mpSuperior")
                mpInferior = dt.Rows(0)("mpInferior")
                mpIzquierdo = dt.Rows(0)("mpIzquierdo")
                mpDerecho = dt.Rows(0)("mpDerecho")
                Horizontal = dt.Rows(0)("Horizontal")
                Columnas = dt.Rows(0)("Columnas")
                Filas = dt.Rows(0)("Filas")
                EspacioColumna = dt.Rows(0)("EspacioColumna")
                EspacioFila = dt.Rows(0)("EspacioFila")
                AnchoEtiqueta = dt.Rows(0)("AnchoEtiqueta")
                AltoEtiqueta = dt.Rows(0)("AltoEtiqueta")
                meSuperior = dt.Rows(0)("meSuperior")
                meInferior = dt.Rows(0)("meInferior")
                meIzquierdo = dt.Rows(0)("meIzquierdo")
                meDerecho = dt.Rows(0)("meDerecho")
                TipoLetra = dt.Rows(0)("TipoLetra")
                SizeLetra = dt.Rows(0)("SizeLetra")
                SizeCodigo = dt.Rows(0)("SizeCodigo")
                dt.Dispose()

            End If

        Else

            btnDelPaq.Visible = False
            btnPrnLabel.Visible = False
            btnEditar.Visible = False
            btnAddPaq.Visible = False
            gridPaquete.Visible = False
            GridDoctos.Height = 287
        End If


        bLoad = True

        If Me.TRAClave <> "" Then
            CargaDatosTransporte(TRAClave)
            If Me.EMPClave <> "" Then
                CargaDatosEmpleado(EMPClave)
            End If
        End If

        If TallaColor = 1 AndAlso TxtProducto.Enabled Then
            ChkTodos.Enabled = GrupoTipo
            GridDetalle.CurrentTable.Columns("Surtido").Selectable = GrupoTipo
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
                Dim msg As String = ""
                msg = ModPOS.Ejecuta("sp_libera_picking", "@PICClave", PICClave)

                If msg <> "OK" Then
                    MessageBox.Show(msg)
                End If

                If Not ModPOS.Surtido Is Nothing Then

                    ModPOS.Surtido.AgregarFolio()

                End If
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
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
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
        Dim msg As String = ""

        If bSurtido = False Then

            If dtDetalle.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron partidas de producto por surtir,falta agregar un documento", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim dt As DataTable

            Dim dSolicitado, dSurtido As Double
            Dim foundRows() As DataRow
            Dim i, j As Integer

            If dtDoctos.Rows.Count > 0 Then
                For i = 0 To dtDoctos.Rows.Count - 1

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("PICClave") <> PICClave OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                            MessageBox.Show("El documento " & dtDoctos.Rows(i)("Folio") & " ya se encuentra abierto o se encuentra surtido por lo que sera removido del proceso actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            remueveDocumento(dtDoctos.Rows(i)("Tipo"), dtDoctos.Rows(i)("DOCClave"))
                        End If
                    End If
                Next
            End If


            If dtDoctos.Rows(0)("Tipo") = 1 Then
                'Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    'Recupera las partidas del pedido que corresponden al producto actual
                    dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", dtDetalle.Rows(i)("Tipo"), "@DOCClave", dtDetalle.Rows(i)("DOCClave"), "@PROClave", dtDetalle.Rows(i)("PROClave"))
                    If dtVentaDetalle.Rows(0)("IdKit").GetType.Name <> "DBNull" Then
                        Dim dtKits As DataTable = ModPOS.Recupera_Tabla("st_recupera_Kit", "@DOCClave", dtDoctos.Rows(0)("DOCClave"), "@IdKit", dtVentaDetalle.Rows(0)("IdKit"))
                        Dim foundRowsKit() As DataRow
                        'Dim j As Integer
                        For j = 0 To dtKits.Rows.Count - 1
                            foundRowsKit = dtDetalle.Select("PROClave = '" & dtKits.Rows(j)("PROClave") & "'")
                            If foundRowsKit.Length > 0 Then
                                foundRowsKit(0)("Surtido") = dtDetalle.Rows(i)("Surtido")
                                foundRowsKit(0)("TipoRechazo") = dtDetalle.Rows(i)("TipoRechazo")
                                foundRowsKit(0)("Recolector") = dtDetalle.Rows(i)("Recolector")
                            End If
                        Next
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
                        a.MontodeAutorizacion = dtDoctos.Compute("SUM(SaldoBase)", "")
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


                                        msg = ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1, "@Motivo", motCancelacion, "@Autoriza", Autoriza, "@AlmacenNegado", ALMClave)
                                        'ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Total"))

                                        If msg <> "OK" Then
                                            MessageBox.Show(msg)
                                        End If

                                        msg = ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)

                                        If msg <> "OK" Then
                                            MessageBox.Show(msg)
                                        End If
                                    ElseIf foundRows(i)("Tipo") = 8 Then
                                        Dim dtCargo As DataTable = ModPOS.SiExisteRecupera("st_verificarCargoProveedor", "@TRSClave", foundRows(i)("DOCClave"))
                                        If Not dtCargo Is Nothing Then
                                            If dtCargo.Rows(0)("Cantidad") > 0 Then
                                                MessageBox.Show("No se puede eliminar el traslado debido a que cuenta con cargos a proveedor asociados", "Información", MessageBoxButtons.OK)
                                                Exit Sub
                                            End If
                                        End If
                                        msg = ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@USRClave", ModPOS.UsuarioActual)
                                    ElseIf foundRows(i)("iTipo") = 6 Then
                                        msg = ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    ElseIf foundRows(i)("iTipo") = 10 Then
                                        msg = ModPOS.Ejecuta("st_cancela_devcompra", "@DEVClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                    End If

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If

                                    msg = ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", foundRows(i)("Tipo"), "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If


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

                    foundRows = dtDoctos.Select("Tipo = 8")
                    If foundRows.Length > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            Dim dtCargo As DataTable = ModPOS.SiExisteRecupera("st_verificarCargoProveedor", "@TRSClave", foundRows(i)("DOCClave"))
                            If Not dtCargo Is Nothing Then
                                If dtCargo.Rows(0)("Cantidad") > 0 Then
                                    MessageBox.Show("No se puede cancelar la mercancia debido a que cuenta con cargos a proveedor asociados", "Información", MessageBoxButtons.OK)
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If


                End If


                foundRows = dtDetalle.Select("RF = 0 and Surtido > 0 and Recolector = ''")
                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("No se ha especificado Recolector", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                'Valida Entrega
                foundRows = dtDoctos.Select("TipoEntrega = 2 and Tipo = 1")
                If foundRows.GetLength(0) > 0 Then
                    If validaForm() = False Then
                        Beep()
                        MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If


                'Valida que haya especificado Und para los KgLt
                foundRows = dtDetalle.Select("Surtido > 0 and KgLt = 1 and Und <= 0")
                If foundRows.GetLength(0) > 0 Then
                    Beep()
                    MessageBox.Show("¡Alguno de los productos requieren que se especifique la cantidad de Und (KgLt)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If


                'Valida si hay existencia disponible en la ubicacion para producto que Surtido es mayor a cantidad

                foundRows = dtDetalle.Select("Surtido > Cantidad and KgLt = 1")
                If foundRows.GetLength(0) > 0 Then
                    Dim dtUbc As DataTable
                    Dim Sobrante, Disponible As Double
                    Dim bError As Boolean = False
                    For i = 0 To foundRows.GetUpperBound(0)
                        dtUbc = ModPOS.Recupera_Tabla("sp_busca_exist_ubc", "@PROClave", foundRows(i)("PROClave"), "@UBCClave", foundRows(i)("UBCClave"))
                        Disponible = (dtUbc.Rows(0)("Existencia") - dtUbc.Rows(0)("Apartado") - dtUbc.Rows(0)("Bloqueado"))
                        dtUbc.Dispose()
                        Sobrante = foundRows(i)("Surtido") - foundRows(i)("Cantidad")

                        If Disponible < Sobrante Then
                            MessageBox.Show("No hay existencia disponible suficiente para surtir el producto " & foundRows(i)("Nombre") & ", en la ubicación " & foundRows(i)("Ubicación"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            bError = True
                            Exit For
                        End If

                    Next

                    If bError = True Then
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



                'Confirmación de recolección
                Beep()
                Select Case MessageBox.Show("¿Desea confirmar el Surtido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        Exit Sub
                End Select

                BtnGuardar.Enabled = False

                'Busca productos con seguimiento

                foundRows = dtDetalle.Select("Tipo=1 and Seguimiento > 1 and Surtido > 0")
                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        registraSeguimiento(foundRows(i)("Tipo"), foundRows(i)("DOCClave"), foundRows(i)("PROClave"), foundRows(i)("Clave"), foundRows(i)("Nombre"), foundRows(i)("Surtido"), foundRows(i)("Seguimiento"), foundRows(i)("DiasGarantia"))
                    Next
                End If

                'Actualiza Detalle y Libera apartados
                Dim Stage As String
                Dim PesoUnd As Double
                Dim Faltante As Double

                For i = 0 To dtDetalle.Rows.Count - 1

                    'Recupera las partidas del pedido que corresponden al producto actual
                    dtVentaDetalle = ModPOS.Recupera_Tabla("sp_recupera_dveclave", "@Tipo", dtDetalle.Rows(i)("Tipo"), "@DOCClave", dtDetalle.Rows(i)("DOCClave"), "@PROClave", dtDetalle.Rows(i)("PROClave"))

                    If dtDetalle.Rows(i)("RF") = 1 Then
                        If dtDetalle.Rows(i)("RechazoRF") = 1 Then
                            Stage = dtDetalle.Rows(i)("UBCClave")
                        Else
                            Stage = foundRows(0)("Stage")
                        End If
                    Else
                        Stage = dtDetalle.Rows(i)("UBCClave")
                    End If

                    'Valida si el producto requiere recalculo de precio por kilo/litro
                    If dtDetalle.Rows(i)("KgLt") = 1 Then


                        'Actualiza Sobrante
                        Dim Sobrante As Double = 0

                        If CDbl(dtDetalle.Rows(i)("Surtido")) > CDbl(dtDetalle.Rows(i)("Cantidad")) Then
                            Sobrante = CDbl(dtDetalle.Rows(i)("Surtido")) - CDbl(dtDetalle.Rows(i)("Cantidad"))
                            'Incremente la cantidad de apartado por sobrante
                            ModPOS.Ejecuta("st_suma_apartado", "@ALMClave", ALMClave, "@UBCClave", dtDetalle.Rows(i)("UBCClave"), "@PROClave", dtDetalle.Rows(i)("PROClave"), "@Cantidad", Sobrante)
                        End If

                        If dtDetalle.Rows(i)("Surtido") > 0 Then
                            PesoUnd = (dtDetalle.Rows(i)("Surtido") / dtDetalle.Rows(i)("Und"))
                        Else
                            PesoUnd = 1
                        End If

                        Dim CantidadSurtida As Double = dtDetalle.Rows(i)("Surtido")

                        For j = 0 To dtVentaDetalle.Rows.Count - 1

                            If dtVentaDetalle.Rows(j)("Cantidad") > CantidadSurtida Then

                                If dtDetalle.Rows(i)("Tipo") = 1 Then
                                    recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), dtVentaDetalle.Rows(j)("Cantidad") - CantidadSurtida, dtDetalle.Rows(i)("KgLt"), PesoUnd)
                                End If

                                'Quita el APartado del almacen y de prd_exist_uba del producto que no fue surtido
                                msg = ModPOS.Ejecuta("st_act_detalle_doctos", _
                                                              "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                              "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                              "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                              "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                              "@Faltante", dtVentaDetalle.Rows(j)("Cantidad") - CantidadSurtida)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                                Exit For

                            ElseIf dtVentaDetalle.Rows(j)("Cantidad") <= CantidadSurtida Then


                                If j = dtVentaDetalle.Rows.Count - 1 Then
                                    Sobrante = dtVentaDetalle.Rows(j)("Cantidad") - CantidadSurtida
                                Else
                                    Sobrante = 0
                                End If

                                If dtDetalle.Rows(i)("Tipo") = 1 Then
                                    recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), Sobrante, dtDetalle.Rows(i)("KgLt"), PesoUnd)
                                End If


                                'Suma el sobrante 
                                msg = ModPOS.Ejecuta("st_act_detalle_doctos", _
                                                             "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                             "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                             "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                             "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                             "@Faltante", Sobrante)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                                If Sobrante = 0 Then
                                    CantidadSurtida -= dtVentaDetalle.Rows(j)("Cantidad")
                                End If

                                If CantidadSurtida = 0 Then
                                    Exit For
                                End If

                            End If



                        Next




                    Else

                        'Obtiene el faltante para la ubicacion y producto actual
                        Faltante = dtDetalle.Rows(i)("Cantidad") - dtDetalle.Rows(i)("Surtido")


                        If Faltante > 0 Then
                            'Si existe faltante, libera el apartado del faltante y actualiza partida del pedido

                            For j = 0 To dtVentaDetalle.Rows.Count - 1
                                If dtVentaDetalle.Rows(j)("Cantidad") >= Faltante Then

                                    If dtDetalle.Rows(i)("Tipo") = 1 Then
                                        recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), Faltante, dtDetalle.Rows(i)("KgLt"), 1)
                                    End If

                                    msg = ModPOS.Ejecuta("st_act_detalle_doctos", _
                                                                  "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                                  "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                                  "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                                  "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                                  "@Faltante", Faltante)

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If
                                    Exit For
                                Else

                                    If dtDetalle.Rows(i)("Tipo") = 1 Then
                                        recalculaPartidaPedido(dtVentaDetalle, dtDetalle.Rows(i)("DOCClave"), dtVentaDetalle.Rows(j)("DETClave"), dtVentaDetalle.Rows(j)("Cantidad"), dtVentaDetalle.Rows(j)("Cantidad"), dtDetalle.Rows(i)("KgLt"), 1)
                                    End If

                                    msg = ModPOS.Ejecuta("st_act_detalle_doctos", _
                                                                              "@Tipo", dtDetalle.Rows(i)("Tipo"), _
                                                                              "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                                                              "@DETClave", dtVentaDetalle.Rows(j)("DETClave"), _
                                                                              "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                                              "@Faltante", dtVentaDetalle.Rows(j)("Cantidad"))


                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If

                                    Faltante -= dtVentaDetalle.Rows(j)("Cantidad")
                                End If
                            Next

                        End If



                    End If


                    foundRows = dtDoctos.Select("DOCClave='" & dtDetalle.Rows(i)("DOCClave") & "' and Tipo = " & CStr(dtDetalle.Rows(i)("Tipo")) & "")

                    'Obtiene el Stage para realizar el ajuste de inventario
                    Stage = foundRows(0)("Stage")

                    ' Actualiza Surtido Detalle y mueve producto de la ubicacion de recoleccion a la de Stage
                    If dtDetalle.Rows(i)("Cantidad") > dtDetalle.Rows(i)("Surtido") Then
                        Faltante = dtDetalle.Rows(i)("Cantidad") - dtDetalle.Rows(i)("Surtido")
                    Else
                        Faltante = 0
                    End If

                    msg = ModPOS.Ejecuta("st_act_surtido_detalle", _
                                   "@TipoDoc", dtDetalle.Rows(i)("Tipo"), _
                                   "@DOCClave", dtDetalle.Rows(i)("DOCClave"), _
                                   "@ALMClave", ALMClave, _
                                   "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                   "@UBCClave", dtDetalle.Rows(i)("UBCClave"), _
                                   "@Surtido", dtDetalle.Rows(i)("Surtido"), _
                                   "@Faltante", Faltante, _
                                   "@TipoRechazo", dtDetalle.Rows(i)("TipoRechazo"), _
                                   "@Stage", Stage, _
                                   "@Usuario", ModPOS.UsuarioActual, _
                                   "@RF", dtDetalle.Rows(i)("RF"), _
                                   "@Und", dtDetalle.Rows(i)("Und"), _
                                   "@Recolector", dtDetalle.Rows(i)("Recolector"))

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If


                Next

                'Elimina partidas con cantidad = cero
                Dim dtVenta, dtEliminados, dtRecalcula As DataTable

                If dtDoctos.Rows.Count > 0 Then

                    'Valida si es una Flertera especial
                    Dim Fletera As String = ""
                    Dim bFletera As Boolean = False

                    If iFormaEnvio > 2 Then
                        dt = ModPOS.Recupera_Tabla("st_valida_fletera", "@formaEnvio", iFormaEnvio, "@COMCLave", ModPOS.CompanyActual)
                        If dt.Rows.Count > 0 Then
                            bFletera = True
                            Do
                                Dim a As New FrmObservaciones
                                a.GrpNota.Text = "Fletera"
                                a.Text = "Captura el nombre de la fletera"
                                a.MaxLineas = 1
                                a.TotalCaracteres = 50
                                If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                    Fletera = a.Nota
                                End If
                                a.Dispose()
                            Loop While Fletera = ""
                        End If
                        dt.Dispose()
                    End If


                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.Show("Procesando información...")

                    For i = 0 To dtDoctos.Rows.Count - 1


                        If bFletera = True AndAlso Fletera <> "" Then
                            ModPOS.Ejecuta("st_actualiza_fletera", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@Fletera", Fletera)
                        End If


                        msg = ModPOS.Ejecuta("st_actualiza_surtido", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual, "@ALMClave", ALMClave)

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If

                        dtEliminados = ModPOS.Recupera_Tabla("st_busca_eliminados_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                        If dtEliminados.Rows.Count > 0 Then
                            msg = ModPOS.Ejecuta("sp_elimina_detalle_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))

                            If msg <> "OK" Then
                                MessageBox.Show(msg)
                            End If

                            dtRecalcula = ModPOS.Recupera_Tabla("st_recupera_doc_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                            If dtRecalcula.Rows.Count > 0 Then
                                Dim z As Integer
                                For z = 0 To dtRecalcula.Rows.Count - 1
                                    'Recalcula numero de partida
                                    msg = ModPOS.Ejecuta("st_ac_partida_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@DETClave", dtRecalcula.Rows(z)("DETClave"), "@Partida", (z + 1) * 10)

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If

                                Next
                            End If
                            dtRecalcula.Dispose()
                        End If
                        dtEliminados.Dispose()


                        Dim iTipoDoc As Integer

                        iTipoDoc = dtDoctos.Rows(i)("Tipo") * -1


                        If dtDoctos.Rows(i)("Tipo") = 1 Then 'Venta

                            'AplicaPromociones
                            msg = ModPOS.Ejecuta("st_aplicar_promociones_cerrada", _
                             "@SUCClave", SUCClave, _
                             "@VENClave", dtDoctos.Rows(i)("DOCClave"), _
                             "@Usuario", ModPOS.UsuarioActual)

                            If msg <> "OK" Then
                                MessageBox.Show(msg)
                            End If

                            msg = ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", dtDoctos.Rows(i)("DOCClave"), "@Estado", 2, "@ActSaldo", 1)

                            If msg <> "OK" Then
                                MessageBox.Show(msg)
                            End If

                            dtVenta = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", dtDoctos.Rows(i)("DOCClave"))
                            If dtVenta.Rows.Count > 0 Then
                                msg = ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", dtVenta.Rows(0)("Cliente"), "@Importe", dtVenta.Rows(0)("Total") * dtVenta.Rows(0)("TipoCambio"))
                            End If
                            dtVenta.Dispose()

                            If msg <> "OK" Then
                                MessageBox.Show(msg)
                            End If

                            ModPOS.GeneraMovInv(2, 1, iTipoDoc, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual, Picking, 1, dtDoctos.Rows(i)("Stage"))

                            If dtDoctos.Rows(i)("TipoAplicacion") > 0 Then
                                Dim detallePago As DataTable
                                Dim z As Integer
                                'Busca Abonos en transitos referenciados al documento

                                detallePago = ModPOS.Recupera_Tabla("sp_aplicar_abn_transito", "@VENClave", dtDoctos.Rows(i)("DOCClave"))
                                If detallePago.Rows.Count > 0 Then

                                    dtVenta = ModPOS.Recupera_Tabla("st_recupera_docto", "@VENClave", dtDoctos.Rows(i)("DOCClave"))

                                    For z = 0 To detallePago.Rows.Count - 1
                                        ModPOS.Aplica_Transito(dtVenta, dtVenta.Rows(0)("CTEClave"), detallePago.Rows(z)("ID"), detallePago.Rows(z)("TipoPago"), detallePago.Rows(z)("SaldoBase"), dtVenta.Rows(0)("CAJClave"), detallePago.Rows(z)("Tipo"))

                                        If InterfazSalida <> "" Then
                                            Dim sFolio, sFecha As String
                                            sFolio = detallePago.Rows(z)("ID")
                                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                            Dim dtInterfaz As DataTable = Nothing

                                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AplicacionNC", "@COMClave", ModPOS.CompanyActual)


                                            If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                                msg = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", detallePago.Rows(z)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", 1)

                                                If msg <> "OK" Then
                                                    MessageBox.Show(msg)
                                                End If
                                            End If
                                        End If


                                    Next


                                End If
                                'Busca abonos refreenciados para pagar el documento

                                detallePago = ModPOS.Recupera_Tabla("st_recupera_referenciadoa", "@VENClave", dtDoctos.Rows(i)("DOCClave"))

                                If detallePago.Rows.Count > 0 Then

                                    Dim idEvento As String = obtenerLlave()

                                    dtVenta = ModPOS.Recupera_Tabla("st_recupera_docto", "@VENClave", dtDoctos.Rows(i)("DOCClave"))

                                    For z = 0 To detallePago.Rows.Count - 1
                                        ModPOS.Aplica_Pagos(dtVenta, dtVenta.Rows(0)("CTEClave"), detallePago.Rows(z)("ID"), detallePago.Rows(z)("TipoPago"), detallePago.Rows(z)("SaldoBase"), dtVenta.Rows(0)("CAJClave"), 1, detallePago.Rows(z)("Fecha"), idEvento)

                                        If InterfazSalida <> "" Then
                                            Dim sFolio, sFecha As String
                                            sFolio = detallePago.Rows(z)("ID")
                                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                            Dim dtInterfaz As DataTable = Nothing

                                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)


                                            If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                                msg = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", detallePago.Rows(z)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", 1)

                                                If msg <> "OK" Then
                                                    MessageBox.Show(msg)
                                                End If
                                            End If
                                        End If
                                    Next

                                End If
                            End If



                        ElseIf dtDoctos.Rows(i)("Tipo") = 8 Then ' Traslado
                            ModPOS.GeneraMovInv(2, 8, iTipoDoc, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual, Picking, 1, dtDoctos.Rows(i)("Stage"))


                            If InterfazSalida <> "" Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "TrasladoOUT", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    msg = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("DOCClave"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If
                                End If
                            End If


                        ElseIf dtDoctos.Rows(i)("Tipo") = 6 Then ' Traspaso
                            ModPOS.GeneraMovInv(2, 8, iTipoDoc, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual, Picking, 1, dtDoctos.Rows(i)("Stage"))



                        ElseIf dtDoctos.Rows(i)("Tipo") = 10 Then 'Devolucion Compra
                            ModPOS.GeneraMovInv(2, 2, iTipoDoc, dtDoctos.Rows(i)("DOCClave"), ALMClave, dtDoctos.Rows(i)("Folio"), ModPOS.UsuarioActual, Picking, 1, dtDoctos.Rows(i)("Stage"))


                            If InterfazSalida <> "" Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "DevCompra", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    msg = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("DOCClave"), "@TipoDocumento", 10, "@Path", InterfazSalida, "@Fecha", sFecha)

                                    If msg <> "OK" Then
                                        MessageBox.Show(msg)
                                    End If
                                End If
                            End If


                        End If

                        msg = ModPOS.Ejecuta("sp_modifica_envio_pic", _
                                                               "@Tipo", dtDoctos.Rows(i)("Tipo"), _
                                                               "@ENVClave", dtDoctos.Rows(i)("ENVClave"), _
                                                               "@Orden", dtDoctos.Rows(i)("Orden"), _
                                                               "@fechaEfectiva", dtDoctos.Rows(i)("fechaEfectiva"), _
                                                               "@TRAClave", TRAClave, _
                                                               "@Observaciones", dtDoctos.Rows(i)("Observaciones"), _
                                                               "@Referencia", dtDoctos.Rows(i)("Referencia"), _
                                                               "@EMPClave", EMPClave)

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If


                        msg = ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@PICClave", Nothing, "@DOCClave", dtDoctos.Rows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If


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
                        'Checar si mejor se obtiene los tamaños de papel de la impresora seleccionada
                        previewPedido(FormatoPedido, dtDoctos.Rows(i)("DOCClave"), dtDoctos.Rows(i)("Total"), SUCClave, sImpresora, True, iCopias, False, True, "", "", True)

                    ElseIf dtDoctos.Rows(i)("Tipo") = 8 Then

                        If TallaColor = 1 Then

                            Dim dtTicket As DataTable
                            dtTicket = ModPOS.SiExisteRecupera("sp_recupera_tikclave", "@SUCClave", SUCClave)

                            Dim sTIKClave As String = ""
                            If Not dtTicket Is Nothing Then
                                sTIKClave = dtTicket.Rows(0)("TIKClave")
                                dtTicket.Dispose()
                            End If

                            ModPOS.imprimirTicketTraslado(sTIKClave, True, dtDoctos.Rows(i)("DOCClave"), TallaColor)

                        Else

                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_traslado", "@TRSClave", dtDoctos.Rows(i)("DOCClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", dtDoctos.Rows(i)("DOCClave")))
                            OpenReport.Print(iCopias, "CRTraslado.rpt", pvtaDataSet, "", sImpresora)

                        End If


                    ElseIf dtDoctos.Rows(i)("Tipo") = 6 Then

                        If TallaColor = 1 Then
                            Dim dtTicket As DataTable
                            dtTicket = ModPOS.SiExisteRecupera("sp_recupera_tikclave", "@SUCClave", SUCClave)

                            Dim sTIKClave As String = ""
                            If Not dtTicket Is Nothing Then
                                sTIKClave = dtTicket.Rows(0)("TIKClave")
                                dtTicket.Dispose()
                            End If

                            ModPOS.imprimirTicketTransferencia(sTIKClave, True, dtDoctos.Rows(i)("DOCClave"))
                        Else
                            Dim OpenReport As New Report
                            Dim pvtaDataSet As New DataSet
                            pvtaDataSet.DataSetName = "pvtaDataSet"
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", dtDoctos.Rows(i)("DOCClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", dtDoctos.Rows(i)("DOCClave")))
                            OpenReport.Print(iCopias, "CRTransferencia.rpt", pvtaDataSet, "", sImpresora)

                        End If



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

                If CDbl(GridDetalle.GetValue("Surtido")) > CDbl(GridDetalle.GetValue("Cantidad")) AndAlso CInt(GridDetalle.GetValue("KgLt")) = 0 Then
                    Beep()
                    MessageBox.Show("¡La cantidad a surtir no de ser mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If CInt(GridDetalle.GetValue("RF")) = 1 Then
                        GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("SurtidoStage")))
                    Else
                        GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("Cantidad")))


                    End If

                ElseIf CDbl(GridDetalle.GetValue("Surtido")) < 0 Then
                    GridDetalle.SetValue("Surtido", 0)
                    GridDetalle.SetValue("Und", 0)
                    GridDetalle.SetValue("Recolector", "")
                ElseIf CInt(GridDetalle.GetValue("RF")) = 1 AndAlso CDbl(GridDetalle.GetValue("Surtido")) > CDbl(GridDetalle.GetValue("SurtidoStage")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad a surtir no de ser mayor a la recolectada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Surtido", CDbl(GridDetalle.GetValue("SurtidoStage")))

                ElseIf GridDetalle.GetValue("RF") = 0 AndAlso CDbl(GridDetalle.GetValue("Surtido")) > 0 AndAlso Not cmbRecolector.SelectedValue Is Nothing AndAlso GridDetalle.GetValue("Recolector") = "" Then
                    GridDetalle.SetValue("Recolector", cmbRecolector.SelectedValue)

                ElseIf CDbl(GridDetalle.GetValue("Surtido")) = 0 Then
                    GridDetalle.SetValue("Recolector", "")
                End If

            Else
                GridDetalle.SetValue("Surtido", 0)
                GridDetalle.SetValue("Und", 0)
                GridDetalle.SetValue("Recolector", "")
            End If
        ElseIf GridDetalle.CurrentColumn.Caption = "Und" Then
            If Not IsNumeric(GridDetalle.GetValue("Und")) Then
                GridDetalle.SetValue("Und", 0)
            ElseIf CInt(GridDetalle.GetValue("KgLt")) = 0 Then
                GridDetalle.SetValue("Und", 0)
            End If
        End If


    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
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
            If CDbl(TxtCantidad.Text) <= 0 Then
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

        Dim foundRows() As System.Data.DataRow

        If Packing = True Then

            foundRows = dtDetalle.Select("Tipo = " & CStr(Tipo) & " and DOCClave = '" & DOCClave & "' and Surtido > 0 ")

            If foundRows.GetLength(0) > 0 AndAlso dtPaquete.Rows.Count > 0 Then
                MessageBox.Show("El documento no puede ser removido debido a que se encuentra asociado a un paquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If


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

        If Packing = True AndAlso dtDoctos.Rows.Count = 0 Then
            If TxtProducto.Enabled = False Then
                If TallaColor = 1 Then
                    ChkTodos.Enabled = False
                    GridDetalle.CurrentTable.Columns("Surtido").Selectable = False

                    BtnBuscaProd.Enabled = True
                    TxtCantidad.Enabled = True
                    TxtProducto.Enabled = True

                Else
                    ChkTodos.Enabled = True
                    GridDetalle.CurrentTable.Columns("Surtido").Selectable = True

                    BtnBuscaProd.Enabled = True
                    TxtCantidad.Enabled = True
                    TxtProducto.Enabled = True

                End If
            End If
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
                        If Not cmbRecolector.SelectedValue Is Nothing AndAlso GridDetalle.GetDataRows(i).DataRow("Recolector") = "" Then
                            GridDetalle.GetDataRows(i).DataRow("Recolector") = cmbRecolector.SelectedValue
                        End If
                    End If
                Next
            Else
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    If CInt(GridDetalle.GetDataRows(i).DataRow("RF")) = 0 Then
                        GridDetalle.GetDataRows(i).DataRow("Surtido") = 0
                        GridDetalle.GetDataRows(i).DataRow("Recolector") = ""
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

                Dim foundRows() As DataRow
                foundRows = dtDetalle.Select("Surtido = 0 and RF = 0")
                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        foundRows(i)("TipoRechazo") = cmbMotivo.SelectedValue
                    Next
                End If


            End If
        End If
    End Sub



    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim foundRows() As DataRow
        Dim i As Integer
        foundRows = dtDetalle.Select("Marca = 1")
        If foundRows.GetLength(0) > 0 Then
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim sImpresora As String = PrintDialog1.PrinterSettings.PrinterName

                Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
                Tickets.Generic = True
                Dim dtTicket As DataTable
                dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", TIKClave)

                Dim lineasImpresas As Integer = 6

                If Not dtTicket Is Nothing Then
                    Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
                    Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
                    Tickets.LetraName = dtTicket.Rows(0)("FontName")
                    If dtTicket.Rows(0)("url_imagen") <> "" Then
                        Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
                    End If
                    dtTicket.Dispose()
                End If

                Tickets.AddHeaderLine("*** PICKING ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

                Dim str As String
                Dim str4 As String = ""
                Dim str7 As String
                Dim str8 As String

                If (Tickets.MaxCharLine < 32) Then
                    str = Tickets.FormateaCadena(1, "CLAVE", 9)
                    str7 = Tickets.FormateaCadena(2, "UBICACION", 9)
                    str8 = Tickets.FormateaCadena(2, "CANTIDAD", 9)
                Else
                    str = Tickets.FormateaCadena(1, "CLAVE", 11)
                    str7 = Tickets.FormateaCadena(2, "UBICACION", 11)
                    str8 = Tickets.FormateaCadena(2, "CANTIDAD", 10)
                End If

                'Si es mayor a 32
                If (Tickets.MaxCharLine > 32) Then
                    str4 = Tickets.Espacio((Tickets.MaxCharLine - 32))
                End If

                Tickets.AddSubHeaderLine(String.Concat(New String() {str, str7, str4, str8}), 0, 1)
                lineasImpresas += 2


                For i = 0 To foundRows.GetUpperBound(0)
                    Tickets.AddItemPicking(foundRows(i)("Ubicación"), foundRows(i)("Clave"), foundRows(i)("Nombre"), foundRows(i)("Cantidad").ToString)
                    lineasImpresas += 2
                Next

                Tickets.PrintTicket(sImpresora, 70, lineasImpresas)

            End If
        End If
    End Sub

    Private Sub GridDetalle_DoubleClick(sender As Object, e As EventArgs) Handles GridDetalle.DoubleClick
        If Not GridDetalle.GetValue(0) Is Nothing AndAlso GridDetalle.CurrentTable.Columns("Surtido").Selectable = False Then
            Dim a As New FrmCantSurtida
            a.Cantidad = GridDetalle.GetValue("Cantidad")
            a.Surtido = GridDetalle.GetValue("Surtido")
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                GridDetalle.SetValue("Surtido", a.Surtido)
            End If
        End If
    End Sub

    Private Sub GridDetalle_FormattingRow(sender As Object, e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridDetalle.FormattingRow
        Dim row As Janus.Windows.GridEX.GridEXRow = e.Row
        row.RowStyle = New Janus.Windows.GridEX.GridEXFormatStyle

        If row.Cells("Cantidad").Value <= row.Cells("Surtido").Value Then
            row.RowStyle.ForeColor = Color.Black
        Else
            row.RowStyle.ForeColor = Color.Red
        End If

    End Sub

    Private Function ObtenerFolio() As String
        Dim Folio As Integer
        Dim Clave, Fecha As String
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 13, "@PDVClave", SUCClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 13, "@PDVClave", SUCClave)
            Folio = 1
            Fecha = String.Format("{0:yyMMdd}", Today.Date)
        Else

            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Fecha = dt.Rows(0)("Fecha")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 13, "@PDVClave", SUCClave, "@Incremento", 1)

            dt.Dispose()
        End If

        Dim sSecuencia As String = "000000" & CStr(Folio)

        Clave = ClaveSucursal & Fecha.Trim & sSecuencia.Substring(sSecuencia.Length - 6, 6).Trim
        Return Clave

    End Function


    Private Sub ImprimirEtiqueta(ByVal numCopias As Integer, ByVal idPaquete As String, ByVal TipoPaq As String, ByVal Fecha As Date, ByVal Usuario As String, ByVal Origen As String, ByVal Cliente As String, ByVal Domicilio As String, ByVal Domicilio1 As String, ByVal Domicilio2 As String, ByVal guia As String, ByVal nota As String)
        ' define el tamaño de la etiqueta
        Dim lsPackingLabels As New PickingPrinting.PackingSet(New System.Drawing.Printing.PaperSize(TipoPapel, ModPOS.Redondear(AnchoPapel * 100 * 0.3937, 0), ModPOS.Redondear(AltoPapel * 100 * 0.3937, 0)), _
                                                                       Horizontal, _
                                                                       ModPOS.Redondear(AnchoEtiqueta * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(AltoEtiqueta * 100 * 0.3937, 0), _
                                                                       Columnas, _
                                                                       ModPOS.Redondear(EspacioColumna * 100 * 0.3937, 0), _
                                                                       Filas, _
                                                                       ModPOS.Redondear(EspacioFila * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpIzquierdo * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpDerecho * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpSuperior * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(mpInferior * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meIzquierdo * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meDerecho * 100 * 0.3937, 0), _
                                                                       ModPOS.Redondear(meSuperior * 100 * 0.3937, 0), _
                                                                      ModPOS.Redondear(meInferior * 100 * 0.3937, 0))
        'define el tamaño y tipo de letras
        lsPackingLabels.PackingFont = New Font(TipoLetra, SizeLetra, FontStyle.Regular)
        lsPackingLabels.PackingFontBold = New Font(TipoLetra, SizeLetra, FontStyle.Bold)
        lsPackingLabels.PackingCodeFont = New Font("Free 3 of 9 Extended", SizeCodigo)

        'Crea la etiqueta

        Dim lblPackingLabel As New PickingPrinting.PackingSheet()

        lblPackingLabel.AddPacking(idPaquete)
        lblPackingLabel.AddTipoPaquete(TipoPaq)
        lblPackingLabel.AddFecha(Fecha)
        lblPackingLabel.AddNombreUsuario(Usuario)
        lblPackingLabel.AddOrigen(Origen)
        lblPackingLabel.AddCliente(Cliente)
        lblPackingLabel.AddCalle(Domicilio)
        lblPackingLabel.AddDomicilio1(Domicilio1)
        lblPackingLabel.addDomicilio2(Domicilio2)
        lblPackingLabel.addGuia(guia)
        lblPackingLabel.addNota(nota)

        Dim i As Integer
        For i = 1 To numCopias
            lsPackingLabels.AddPackingSheet(lblPackingLabel)
        Next


        ' Permite al usuario elegir la impresora:

        PrintDialog1.Document = lsPackingLabels
        PrintDialog1.AllowSomePages = True

        '  If PrintDialog1.ShowDialog() = DialogResult.OK Then
        PrintDialog1.Document.Print()
        '  End If

    End Sub

    Public Sub AddPaquete(ByVal idPaq As String, ByVal sTipo As String, ByVal sGuia As String, ByVal sNota As String)

        Dim row1 As DataRow
        row1 = dtPaquete.NewRow()
        'declara el nombre de la fila
        row1.Item("T") = sTipo
        row1.Item("idPaquete") = idPaq
        row1.Item("guia") = sGuia
        row1.Item("nota") = sNota
        dtPaquete.Rows.Add(row1)
        GridDoctos.AutoSizeColumns()
        GridDoctos.HorizontalScroll.Enabled = True
    End Sub


    Private Sub btnAddPaq_Click(sender As Object, e As EventArgs) Handles btnAddPaq.Click


        'Valida que exista plantilla de etiqueta
        If idSheet = "" Then
            MessageBox.Show("No existe plantilla de etiqueta para paquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Valida que existan documentos asociados
        If dtDoctos.Rows.Count = 0 Then
            MessageBox.Show("No existen documentos por surtir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        'Recupera el tipo de Etiqueta 
        Dim idPaquete, sDestino As String
        Dim sTipo As String

        If CInt(dtDoctos.Rows(0)("TipoEntrega")) = 3 Then
            sDestino = CStr(dtDoctos.Rows(0)("ENVClave"))
        Else
            sDestino = ""
        End If


        idPaquete = ObtenerFolio()

        Dim nota, guia, tipoPaq As String
        Dim numCopias As Integer
        Dim p As New FrmPaquete
        p.Text = "IdPaquete: " & idPaquete
        If p.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            nota = p.Nota
            guia = p.Guia
            tipoPaq = p.TipoPaquete
            numCopias = p.numCopias
            p.Dispose()



            Dim dt As DataTable
            dt = Recupera_Tabla("sp_recupera_valor", "@Tabla", "Paquete", "@Campo", "TipoPaquete", "@Valor", tipoPaq)
            sTipo = CStr(dt.Rows(0)("Clave"))
            dt.Dispose()


            ModPOS.Ejecuta("st_inserta_paquete", "@idPaquete", idPaquete, "@PICClave", PICClave, "@SUCClave", SUCClave, "@TipoDocumento", dtDoctos.Rows(0)("Tipo"), "@SucursalDestino", sDestino, "@TipoPaquete", tipoPaq, "@Domicilio", dtDoctos.Rows(0)("Calle"), "@Domicilio2", dtDoctos.Rows(0)("Domicilio1"), "@Domicilio3", dtDoctos.Rows(0)("Domicilio2"), "@Usuario", Empacador, "@Guia", guia, "@Nota", nota)

            AddPaquete(idPaquete, sTipo, guia, nota)

            ' ImprimirEtiqueta(numCopias, idPaquete, sTipo, Today.Date, NombreUsuario, ClaveSucursal & " " & NombreSucursal, dtDoctos.Rows(0)("Clave") & " - " & dtDoctos.Rows(0)("RazonSocial"), dtDoctos.Rows(0)("Calle"), dtDoctos.Rows(0)("Domicilio1"), dtDoctos.Rows(0)("Domicilio2"), guia, nota)

            ImprimirEtiqueta(numCopias, idPaquete, sTipo, Today.Date, NombreUsuario, NombreSucursal, dtDoctos.Rows(0)("RazonSocial"), dtDoctos.Rows(0)("Calle"), dtDoctos.Rows(0)("Domicilio1"), dtDoctos.Rows(0)("Domicilio2"), guia, nota)

            'Abre ventana para Paquete Detalle

            Dim a As New FrmPacking
            a.TallaColor = TallaColor
            a.SUCClave = SUCClave
            a.Padre = "Nuevo"
            a.ClaveSucursal = ClaveSucursal
            a.idPaquete = idPaquete
            a.PICClave = PICClave
            a.ShowDialog()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim a As New FrmPacking
        a.SUCClave = SUCClave
        a.Padre = "Editar"
        a.ClaveSucursal = ClaveSucursal
        a.idPaquete = ""
        a.PICClave = PICClave
        a.ShowDialog()
    End Sub

    Private Sub btnPrnLabel_Click(sender As Object, e As EventArgs) Handles btnPrnLabel.Click

        If dtPaquete.Rows.Count > 0 Then
            If Not gridPaquete.GetValue(0) Is Nothing Then
                ImprimirEtiqueta(1, gridPaquete.GetValue("idPaquete"), gridPaquete.GetValue("T"), Today.Date, NombreUsuario, ClaveSucursal & " " & NombreSucursal, dtDoctos.Rows(0)("Clave") & " - " & dtDoctos.Rows(0)("RazonSocial"), dtDoctos.Rows(0)("Calle"), dtDoctos.Rows(0)("Domicilio1"), dtDoctos.Rows(0)("Domicilio2"), gridPaquete.GetValue("guia"), gridPaquete.GetValue("nota"))
            Else
                Beep()
                MessageBox.Show("Debe seleccionar un IdPaquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Beep()
            MessageBox.Show("No existen paquetes creados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelPaq_Click(sender As Object, e As EventArgs) Handles btnDelPaq.Click
        If dtPaquete.Rows.Count > 0 Then
            If Not gridPaquete.GetValue(0) Is Nothing Then
                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_paqdet", "@idPaquete", gridPaquete.GetValue("idPaquete"))

                If dt.Rows.Count = 0 Then
                    Select Case MessageBox.Show("Se eliminara el idPaquete :" & gridPaquete.GetValue("idPaquete"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Case DialogResult.Yes
                            ModPOS.Ejecuta("st_elimina_paq", "@idPaquete", gridPaquete.GetValue("idPaquete"), "@Usuario", ModPOS.UsuarioActual)

                            Dim foundRows() As System.Data.DataRow
                            foundRows = dtPaquete.Select("idPaquete ='" & gridPaquete.GetValue("idPaquete") & "'")
                            dtPaquete.Rows.Remove(foundRows(0))

                    End Select

                Else
                    Beep()
                    MessageBox.Show("No es posible eliminar el paquete debido a que tiene producto asignado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                Beep()
                MessageBox.Show("Debe seleccionar un IdPaquete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Beep()
            MessageBox.Show("No existen paquetes disponibles para ser eliminados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnParcial_Click(sender As Object, e As EventArgs) Handles btnParcial.Click
        'Valida si existen productos pendientes de surtir
        If bSurtido = False Then

            If dtDetalle.Rows.Count = 0 Then
                MessageBox.Show("No se encuntraron partidas de producto por surtir,falta agregar un documento", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Packing = True Then
                If dtDoctos.Rows.Count > 1 Then
                    MessageBox.Show("No es posible guardar parcialmente un Packing que contenga más de un documento", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If


            Dim i, j, iTipo As Integer

            If dtDoctos.Rows.Count > 0 Then
                For i = 0 To dtDoctos.Rows.Count - 1
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", dtDoctos.Rows(i)("Tipo"), "@DOCClave", dtDoctos.Rows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then

                        iTipo = CInt(dtDoctos.Rows(i)("Tipo"))

                        If (iTipo = 1 AndAlso dt.Rows(0)("Estado") <> 8) OrElse (iTipo <> 1 AndAlso dt.Rows(0)("Estado") <> 6) Then
                            MessageBox.Show("El docuemnto " & dtDoctos.Rows(i)("Folio") & " ya se encuentra abierto o se encuentra surtido por lo que sera removido del proceso actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            remueveDocumento(dtDoctos.Rows(i)("Tipo"), dtDoctos.Rows(i)("DOCClave"))
                        Else
                            If dt.Rows(0)("PICClave") <> PICClave OrElse dt.Rows(0)("EdoSurtido") = 5 Then
                                MessageBox.Show("El docuemnto " & dtDoctos.Rows(i)("Folio") & " ya se encuentra abierto o se encuentra surtido por lo que sera removido del proceso actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                remueveDocumento(dtDoctos.Rows(i)("Tipo"), dtDoctos.Rows(i)("DOCClave"))
                            Else
                                ModPOS.Ejecuta("st_actualiza_surtido", "@Tipo", CStr(dtDoctos.Rows(i)("Tipo")), "@DOCClave", CStr(dtDoctos.Rows(i)("DOCClave")), "@Usuario", ModPOS.UsuarioActual, "@Estado", 1, "@ALMClave", ALMClave)


                                If iTipo = 1 Then
                                    ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", CStr(dtDoctos.Rows(i)("DOCClave")), "@Estado", 7)
                                ElseIf iTipo = 8 Then
                                    ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", CStr(dtDoctos.Rows(i)("DOCClave")), "@Estado", 5)
                                ElseIf iTipo = 6 Then
                                    ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", CStr(dtDoctos.Rows(i)("DOCClave")), "@Estado", 5)
                                ElseIf iTipo = 10 Then
                                    ModPOS.Ejecuta("sp_actualiza_estado_devcompra", "@DEVClave", CStr(dtDoctos.Rows(i)("DOCClave")), "@Estado", 5)
                                End If

                                Dim foundRows() As DataRow
                                foundRows = dtDetalle.Select("Tipo = " & CStr(iTipo) & " and DOCClave = '" & CStr(dtDoctos.Rows(i)("DOCClave")) & "' and Surtido > 0 or TipoRechazo > 0")
                                If foundRows.GetLength(0) > 0 Then
                                    For j = 0 To foundRows.GetUpperBound(0)
                                        ModPOS.Ejecuta("st_actualiza_surtidodetalle", _
                                                         "@TipoDoc", foundRows(j)("Tipo"), _
                                                         "@DOCClave", foundRows(j)("DOCClave"), _
                                                         "@PROClave", foundRows(j)("PROClave"), _
                                                         "@UBCClave", foundRows(j)("UBCClave"), _
                                                         "@Surtido", foundRows(j)("Surtido"), _
                                                         "@TipoRechazo", foundRows(j)("TipoRechazo"), _
                                                         "@Und", foundRows(j)("Und"), _
                                                         "@Recolector", foundRows(j)("Recolector"))
                                    Next
                                End If
                            End If
                        End If
                    End If
                Next

                ModPOS.Ejecuta("st_libera_ip_picking", "@PICClave", PICClave)

                bSurtido = True

            End If

            Me.Close()

        End If

    End Sub


    Private Sub btnReiniciar_Click(sender As Object, e As EventArgs) Handles btnReiniciar.Click
        If dtDetalle.Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To GridDetalle.GetDataRows.Length - 1
                If CInt(GridDetalle.GetDataRows(i).DataRow("RF")) = 0 Then
                    GridDetalle.GetDataRows(i).DataRow("Surtido") = 0
                    GridDetalle.GetDataRows(i).DataRow("Recolector") = ""
                End If
            Next

            dtDetalle.AcceptChanges()
            GridDetalle.Refresh()

            'quitar el detalle de los paquetes 
            If Packing = True Then
                If dtPaquete.Rows.Count > 0 Then
                    ModPOS.Ejecuta("st_elimina_paquetedet", "@PICClave", PICClave)
                End If
            End If


        End If
    End Sub
End Class
