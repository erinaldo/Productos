Public Class FrmPrecio
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
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtLista As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpListaPrecios As System.Windows.Forms.GroupBox
    Friend WithEvents GridPrecios As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTodos As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnVarios As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupoPrecio As Selling.StoreCombo
    Friend WithEvents TxtFactor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents cmbTipoDocumento As Selling.StoreCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents btnUtilidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrecio))
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.GrpListaPrecios = New System.Windows.Forms.GroupBox()
        Me.cmbTipoDocumento = New Selling.StoreCombo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.GridPrecios = New Janus.Windows.GridEX.GridEX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtFactor = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbGrupoPrecio = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.TxtCompany = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtLista = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.btnUtilidad = New Janus.Windows.EditControls.UIButton()
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnTodos = New Janus.Windows.EditControls.UIButton()
        Me.BtnVarios = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpListaPrecios.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Location = New System.Drawing.Point(94, 160)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(211, 20)
        Me.TxtDescripcion.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(5, 135)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(82, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Lista"
        '
        'GrpListaPrecios
        '
        Me.GrpListaPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpListaPrecios.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpListaPrecios.Controls.Add(Me.cmbTipoDocumento)
        Me.GrpListaPrecios.Controls.Add(Me.Label6)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox6)
        Me.GrpListaPrecios.Controls.Add(Me.GroupBox1)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox5)
        Me.GrpListaPrecios.Controls.Add(Me.Label10)
        Me.GrpListaPrecios.Controls.Add(Me.TxtFactor)
        Me.GrpListaPrecios.Controls.Add(Me.Label5)
        Me.GrpListaPrecios.Controls.Add(Me.cmbGrupoPrecio)
        Me.GrpListaPrecios.Controls.Add(Me.Label2)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox4)
        Me.GrpListaPrecios.Controls.Add(Me.cmbTipoCanal)
        Me.GrpListaPrecios.Controls.Add(Me.LblDestino)
        Me.GrpListaPrecios.Controls.Add(Me.TxtCompany)
        Me.GrpListaPrecios.Controls.Add(Me.Label4)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox3)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox2)
        Me.GrpListaPrecios.Controls.Add(Me.TxtLista)
        Me.GrpListaPrecios.Controls.Add(Me.Label1)
        Me.GrpListaPrecios.Controls.Add(Me.LblClave)
        Me.GrpListaPrecios.Controls.Add(Me.TxtDescripcion)
        Me.GrpListaPrecios.Controls.Add(Me.PictureBox1)
        Me.GrpListaPrecios.Controls.Add(Me.ChkEstado)
        Me.GrpListaPrecios.Controls.Add(Me.BtnCancelar)
        Me.GrpListaPrecios.Controls.Add(Me.BtnGuardar)
        Me.GrpListaPrecios.Location = New System.Drawing.Point(4, 5)
        Me.GrpListaPrecios.Name = "GrpListaPrecios"
        Me.GrpListaPrecios.Size = New System.Drawing.Size(781, 514)
        Me.GrpListaPrecios.TabIndex = 2
        Me.GrpListaPrecios.TabStop = False
        Me.GrpListaPrecios.Text = "Lista de Precios (sin impuestos)        "
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoDocumento.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(94, 103)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipoDocumento.TabIndex = 150
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 15)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Documento"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnUtilidad)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtMaxHits)
        Me.GroupBox1.Controls.Add(Me.CmbCampo)
        Me.GroupBox1.Controls.Add(Me.TxtBuscar)
        Me.GroupBox1.Controls.Add(Me.BtnModificar)
        Me.GroupBox1.Controls.Add(Me.BtnEliminar)
        Me.GroupBox1.Controls.Add(Me.BtnTodos)
        Me.GroupBox1.Controls.Add(Me.BtnVarios)
        Me.GroupBox1.Controls.Add(Me.GridPrecios)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(769, 258)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(574, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(706, 16)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 20)
        Me.TxtMaxHits.TabIndex = 149
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(8, 16)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 148
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(179, 16)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(335, 20)
        Me.TxtBuscar.TabIndex = 147
        '
        'GridPrecios
        '
        Me.GridPrecios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrecios.ColumnAutoResize = True
        Me.GridPrecios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPrecios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrecios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPrecios.Location = New System.Drawing.Point(8, 43)
        Me.GridPrecios.Name = "GridPrecios"
        Me.GridPrecios.RecordNavigator = True
        Me.GridPrecios.Size = New System.Drawing.Size(674, 209)
        Me.GridPrecios.TabIndex = 1
        Me.GridPrecios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(174, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(456, 19)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "(Porc. utilidad sugerido para Productos que se agreguen a esta lista por primera " & _
    "vez)"
        '
        'TxtFactor
        '
        Me.TxtFactor.Location = New System.Drawing.Point(94, 187)
        Me.TxtFactor.Name = "TxtFactor"
        Me.TxtFactor.Size = New System.Drawing.Size(73, 20)
        Me.TxtFactor.TabIndex = 139
        Me.TxtFactor.Text = "0.00"
        Me.TxtFactor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtFactor.Value = 0.0R
        Me.TxtFactor.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "Factor"
        '
        'cmbGrupoPrecio
        '
        Me.cmbGrupoPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGrupoPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupoPrecio.Location = New System.Drawing.Point(94, 74)
        Me.cmbGrupoPrecio.Name = "cmbGrupoPrecio"
        Me.cmbGrupoPrecio.Size = New System.Drawing.Size(211, 21)
        Me.cmbGrupoPrecio.TabIndex = 138
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Gpo. Precios"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.Location = New System.Drawing.Point(94, 46)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(211, 21)
        Me.cmbTipoCanal.TabIndex = 134
        '
        'LblDestino
        '
        Me.LblDestino.Location = New System.Drawing.Point(5, 49)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(82, 16)
        Me.LblDestino.TabIndex = 133
        Me.LblDestino.Text = "Canal de Venta"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(94, 19)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(575, 20)
        Me.TxtCompany.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Compañia"
        '
        'TxtLista
        '
        Me.TxtLista.Location = New System.Drawing.Point(94, 133)
        Me.TxtLista.Name = "TxtLista"
        Me.TxtLista.Size = New System.Drawing.Size(86, 20)
        Me.TxtLista.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Descripción"
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(602, 45)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(67, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(311, 106)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox6.TabIndex = 148
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'btnUtilidad
        '
        Me.btnUtilidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUtilidad.Image = CType(resources.GetObject("btnUtilidad.Image"), System.Drawing.Image)
        Me.btnUtilidad.Location = New System.Drawing.Point(688, 223)
        Me.btnUtilidad.Name = "btnUtilidad"
        Me.btnUtilidad.Size = New System.Drawing.Size(73, 30)
        Me.btnUtilidad.TabIndex = 152
        Me.btnUtilidad.Text = "&Utilidad"
        Me.btnUtilidad.ToolTipText = " "
        Me.btnUtilidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(690, 44)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(73, 30)
        Me.btnAgregar.TabIndex = 151
        Me.btnAgregar.Text = "&Vigencia"
        Me.btnAgregar.ToolTipText = "Agrega  nuevo precio"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(689, 116)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(73, 29)
        Me.BtnModificar.TabIndex = 5
        Me.BtnModificar.Text = "&Precio"
        Me.BtnModificar.ToolTipText = "Modifica los datos de la vigencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(688, 187)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(73, 30)
        Me.BtnEliminar.TabIndex = 9
        Me.BtnEliminar.Text = "&Eliminar "
        Me.BtnEliminar.ToolTipText = "Elimina el producto seleccionado de la lista de precios"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnTodos
        '
        Me.BtnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTodos.Image = CType(resources.GetObject("BtnTodos.Image"), System.Drawing.Image)
        Me.BtnTodos.Location = New System.Drawing.Point(690, 80)
        Me.BtnTodos.Name = "BtnTodos"
        Me.BtnTodos.Size = New System.Drawing.Size(73, 30)
        Me.BtnTodos.TabIndex = 4
        Me.BtnTodos.Text = "&Todos"
        Me.BtnTodos.ToolTipText = "Agrega todos los productos existentes que no estan en la lista de precios"
        Me.BtnTodos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnVarios
        '
        Me.BtnVarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVarios.Image = CType(resources.GetObject("BtnVarios.Image"), System.Drawing.Image)
        Me.BtnVarios.Location = New System.Drawing.Point(689, 151)
        Me.BtnVarios.Name = "BtnVarios"
        Me.BtnVarios.Size = New System.Drawing.Size(73, 30)
        Me.BtnVarios.TabIndex = 70
        Me.BtnVarios.Text = "&Varios"
        Me.BtnVarios.ToolTipText = " "
        Me.BtnVarios.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(172, 188)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox5.TabIndex = 142
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(311, 154)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox4.TabIndex = 135
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(186, 135)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(311, 77)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox2.TabIndex = 61
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(311, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(589, 472)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(685, 472)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPrecio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.GrpListaPrecios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPrecio"
        Me.Text = "FrmPrecio"
        Me.GrpListaPrecios.ResumeLayout(False)
        Me.GrpListaPrecios.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public PREClave As String = ""
    Public ListaPrecio As String
    Public Descripcion As String
    Public Grupo As Integer
    Public Estado As Integer
    Public TipoCanal As Integer
    Public Factor As Double
    Public TipoDocumento As Integer

    Private dt As DataTable

    Private sProductoSelected As String
    Private fPrecio As Double
    Private fMinimo As Double
    Private sClave As String
    Private sNombre As String
    Private dInicio As Date

    Private alerta(5) As PictureBox
    Private reloj As parpadea

    Private bCargado As Boolean = False


#Region "Metodos Internos"

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.cmbTipoCanal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbGrupoPrecio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipoDocumento.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLista.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtLista.Text.Length > 20 Then
            Me.TxtLista.Text = Me.TxtLista.Text.Substring(0, 20)
        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 50 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 50)

        End If


        If Me.TxtFactor.Text <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Precio", "@clave", UCase(Trim(Me.TxtLista.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Lista de Precio que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub valorDefault()
        With Me
            .Text = "Nueva Lista de Precio"
            .Padre = "Agregar"
            .TxtLista.Text = ""
            .ChkEstado.Enabled = False
            .btnAgregar.Enabled = False
            .BtnTodos.Enabled = False
            .BtnModificar.Enabled = False
            .BtnEliminar.Enabled = False
            .BtnVarios.Enabled = False

        End With
        'ModPOS.ActualizaGrid(True, GridSubClass, "sp_muestra_subclases", "@Padre", "-1")

    End Sub

    Private Sub actGrid(ByVal MaxHits As Integer, ByVal iCampo As Integer, ByVal sBusqueda As String, ByVal sPrecio As String)
        Clock.Stop()

        If bCargado Then
            If Not dt Is Nothing Then
                dt.Dispose()
            End If



            dt = ModPOS.Recupera_Tabla("sp_muestra_precios", "@Max", MaxHits, "@Campo", iCampo, "@Busqueda", sBusqueda, "@Precio", sPrecio, "@Char", cReplace)

            GridPrecios.DataSource = dt
            GridPrecios.RetrieveStructure(True)
            GridPrecios.GroupByBoxVisible = False
            GridPrecios.RootTable.Columns("PROClave").Visible = False

            GridPrecios.RootTable.Columns("Clave").Width = 60
            GridPrecios.RootTable.Columns("Nombre").Width = 190
            GridPrecios.RootTable.Columns("Precio").Width = 40
            GridPrecios.RootTable.Columns("Minimo").Width = 40
            GridPrecios.RootTable.Columns("Inicio").Width = 40
            GridPrecios.RootTable.Columns("Fin").Width = 40



        End If

    End Sub

#End Region

    Private Sub FrmPrecio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoPrecio Is Nothing Then
            ModPOS.ActualizaGrid(True, ModPOS.MtoPrecio.GridListaPrecio, "sp_muestra_listaprecio", "@COMClave", ModPOS.CompanyActual)
            ModPOS.MtoPrecio.GridListaPrecio.RootTable.Columns("ID").Visible = False
        End If
        ModPOS.Precio.Dispose()
        ModPOS.Precio = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With

        With cmbGrupoPrecio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Precio"
            .NombreParametro2 = "campo"
            .Parametro2 = "Grupo"
            .llenar()
        End With


        With cmbTipoDocumento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Precio"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoDocumento"
            .llenar()
        End With

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With



        bCargado = True

        Me.actGrid(0, 1, "", PREClave)


        If Padre = "Agregar" Then
            valorDefault()
        Else
            cmbTipoCanal.SelectedValue = TipoCanal
            cmbGrupoPrecio.SelectedValue = Grupo
            cmbTipoDocumento.SelectedValue = TipoDocumento

            TxtLista.Text = ListaPrecio
            TxtDescripcion.Text = Descripcion
            ChkEstado.Estado = Estado
            TxtFactor.Text = Factor

            If TxtLista.Text.Length >= 5 AndAlso TxtDescripcion.Text.Substring(0, 5).ToUpper = "Copia" Then
                TxtLista.Enabled = True
            Else
                TxtLista.Enabled = False
                TxtLista.ReadOnly = True
            End If

        End If




    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Select Case Me.Padre

                Case "Agregar"

                    TipoCanal = cmbTipoCanal.SelectedValue
                    PREClave = ModPOS.obtenerLlave
                    Grupo = cmbGrupoPrecio.SelectedValue
                    ListaPrecio = UCase(Trim(Me.TxtLista.Text))
                    Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                    Factor = CDbl(TxtFactor.Text)
                    TipoDocumento = cmbTipoDocumento.SelectedValue


                    ModPOS.Ejecuta("sp_inserta_listaprecio", _
                    "@COMClave", ModPOS.CompanyActual, _
                    "@TipoCanal", TipoCanal, _
                    "@Grupo", Grupo, _
                    "@TipoDocumento", TipoDocumento, _
                    "@PREClave", PREClave, _
                    "@ListaPrecio", ListaPrecio, _
                    "@Descripcion", Descripcion, _
                    "@Factor", Factor, _
                    "@Usuario", ModPOS.UsuarioActual)

                    Padre = "Modificar"

                    Me.TxtLista.Enabled = False
                    Me.ChkEstado.Estado = Estado
                    Me.BtnTodos.Enabled = True
                    Me.btnAgregar.Enabled = True

                Case "Modificar"
                    Dim bModPrecio As Boolean = False
                    If Not ( _
                            TipoCanal = cmbTipoCanal.SelectedValue AndAlso _
                            Grupo = cmbGrupoPrecio.SelectedValue AndAlso _
                            ListaPrecio = UCase(Trim(Me.TxtLista.Text)) AndAlso _
                            TipoDocumento = cmbTipoDocumento.SelectedValue AndAlso _
                            Descripcion = UCase(Trim(Me.TxtDescripcion.Text)) AndAlso _
                            Factor = CDbl(TxtFactor.Text) AndAlso _
                            Estado = Me.ChkEstado.GetEstado) Then


                        TipoCanal = cmbTipoCanal.SelectedValue
                        Grupo = cmbGrupoPrecio.SelectedValue
                        ListaPrecio = UCase(Trim(Me.TxtLista.Text))
                        Descripcion = UCase(Trim(Me.TxtDescripcion.Text))
                        Estado = Me.ChkEstado.GetEstado
                        Factor = CDbl(TxtFactor.Text)
                        TipoDocumento = cmbTipoDocumento.SelectedValue




                        ModPOS.Ejecuta("sp_modifica_listaprecio", _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@TipoCanal", TipoCanal, _
                                        "@Grupo", Grupo, _
                                        "@TipoDocumento", TipoDocumento, _
                                        "@PREClave", PREClave, _
                                        "@ListaPrecio", ListaPrecio, _
                                        "@Descripcion", Descripcion, _
                                        "@Factor", Factor, _
                                        "@Estado", Estado, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    End If

                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub GridPrecios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPrecios.DoubleClick
        If sProductoSelected <> "" Then
            Modifica_Precios()
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        If sProductoSelected <> "" Then
            Modifica_Precios()
        End If
    End Sub

    Private Sub Modifica_Precios()
        If ModPOS.ModPrecio Is Nothing Then
            ModPOS.ModPrecio = New FrmModPrecio
            With ModPOS.ModPrecio
                .StartPosition = FormStartPosition.CenterScreen
                .PREClave = Me.PREClave
                .PROClave = sProductoSelected
                .Inicio = dInicio
                .Clave = sClave
                .Nombre = sNombre
                .Precio = fPrecio
                .Minimo = fMinimo
            End With
        End If
        ModPOS.ModPrecio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ModPrecio.Show()
        ModPOS.ModPrecio.BringToFront()
        
    End Sub

    Private Sub GridPrecios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPrecios.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPrecios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPrecios.SelectionChanged
        If Not GridPrecios.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sProductoSelected = GridPrecios.GetValue("PROClave")
            sClave = GridPrecios.GetValue("Clave")
            sNombre = GridPrecios.GetValue("Nombre")
            fPrecio = GridPrecios.GetValue("Precio")
            fMinimo = GridPrecios.GetValue("Minimo")
            dInicio = GridPrecios.GetValue("Inicio")

        Else
            BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.sProductoSelected = ""
            sClave = ""
            sNombre = ""
          
            fPrecio = 0
            fMinimo = 0

            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If

    End Sub


    Public Sub addPrecio(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal Precio As Double, ByVal Minimo As Double, ByVal dInicio As Date, ByVal dFin As Date)
        Dim row1 As DataRow
        row1 = dt.NewRow()
        row1.Item("PROClave") = sPROClave
        row1.Item("Clave") = sClave
        row1.Item("Nombre") = sNombre
        row1.Item("Precio") = Precio
        row1.Item("Minimo") = Minimo
        row1.Item("Inicio") = dInicio
        row1.Item("Fin") = dFin
        dt.Rows.Add(row1)
    End Sub

    Public Sub updPrecio(ByVal sPROClave As String, ByVal dInicio As Date, ByVal fPrecio As Double, ByVal fMinimo As Double)
        Dim foundRows() As System.Data.DataRow

        foundRows = dt.Select("PROClave = '" & sPROClave & "' and Inicio =#" & dInicio.Date.ToString("MM/dd/yyyy") & "#")

        If foundRows.GetLength(0) > 0 Then
           
            foundRows(0)("Precio") = fPrecio
            foundRows(0)("Minimo") = fMinimo


        End If
    End Sub



    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el producto:" & sNombre & "de la lista de precio actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_precio", "@PREClave", PREClave, "@PROClave", sProductoSelected, "@Inicio", dInicio)
                    Dim foundRows() As System.Data.DataRow

                    foundRows = dt.Select("PROClave = '" & sProductoSelected & "' and Inicio =#" & dInicio.Date.ToString("MM/dd/yyyy") & "#")

                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            dt.Rows.Remove(foundRows(i))
                        Next

                    End If
            End Select
        End If

    End Sub

    Private Sub BtnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTodos.Click
        If CDbl(TxtFactor.Text) > 0 Then
            Cursor.Current = Cursors.WaitCursor

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_todos_precio", _
                                   "@COMClave", ModPOS.CompanyActual, _
                                   "@PREClave", PREClave, _
                                   "@Factor", TxtFactor.Text)


            If dt.Rows.Count > 0 Then
                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.BringToFront()

                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dt.Rows.Count) & " registros")

                    ModPOS.Ejecuta("sp_agrega_vigencia", _
                 "@PREClave", PREClave, _
                 "@PROClave", dt.Rows(i)("PROClave"), _
                 "@Inicio", dt.Rows(i)("Inicio"), _
                 "@Precio", dt.Rows(i)("Precio"), _
                 "@Minimo", dt.Rows(i)("Minimo"), _
                 "@Usuario", ModPOS.UsuarioActual)

                    addPrecio(dt.Rows(i)("PROClave"), dt.Rows(i)("Clave"), dt.Rows(i)("Nombre"), dt.Rows(i)("Precio"), dt.Rows(i)("Minimo"), dt.Rows(i)("Inicio"), #12/31/9999#)

                Next
                frmStatusMessage.Close()
                MessageBox.Show("¡Se agregaron " & CStr(dt.Rows.Count) & " productos a la lista de precios actual!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("¡No se encontraron productos pendientes de agregar a la lista de precios actual!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Cursor.Current = Cursors.Default
        Else
            Beep()
            MessageBox.Show("El factor de utilidad es requerido para determinar el precio inicial de los nuevos productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnVarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVarios.Click
            If ModPOS.AddPrecio Is Nothing Then
            ModPOS.AddPrecio = New FrmAddPrecio
            With ModPOS.AddPrecio
                .Text = "Modificar vigencias de precio"
                .StartPosition = FormStartPosition.CenterScreen
                .PREClave = Me.PREClave
            End With
        End If
        ModPOS.AddPrecio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddPrecio.Show()
        ModPOS.AddPrecio.BringToFront()
      
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

  
    Private Sub CmbCampo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCampo.SelectedValueChanged
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, PREClave)
            End If
        End If
    End Sub

    Private Sub TxtBuscar_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.Leave
        Clock.Stop()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not CmbCampo.SelectedValue Is Nothing Then

            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, PREClave)
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ModPOS.ModPrecio Is Nothing Then
            ModPOS.ModPrecio = New FrmModPrecio
            With ModPOS.ModPrecio
                .Text = "Agregar Nueva Vigencia de Precio"
                .Padre = "Nuevo"
                .StartPosition = FormStartPosition.CenterScreen
                .PREClave = Me.PREClave
                .PROClave = sProductoSelected
                .Inicio = dInicio
                .Clave = sClave
                .Nombre = sNombre
                .Precio = fPrecio
                .Minimo = fMinimo
            End With
        End If
        ModPOS.ModPrecio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ModPrecio.Show()
        ModPOS.ModPrecio.BringToFront()

    End Sub

   
    Private Sub btnUtilidad_Click(sender As Object, e As EventArgs) Handles btnUtilidad.Click
        If ModPOS.ActUtilidad Is Nothing Then
            ModPOS.ActUtilidad = New FrmActUtilidad
            With ModPOS.ActUtilidad
                .Text = "Modificar Utilidad"
                .PREClave = Me.PREClave
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.ActUtilidad.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ActUtilidad.Show()
        ModPOS.ActUtilidad.BringToFront()

    End Sub
End Class
