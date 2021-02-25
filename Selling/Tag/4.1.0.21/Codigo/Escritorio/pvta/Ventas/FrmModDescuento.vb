Public Class FrmModDescuento
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
    Friend WithEvents grpMaterial As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtClaveMaterial As System.Windows.Forms.TextBox
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaMaterial As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents dtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtClaveCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInicio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFin As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbDirecto As Selling.StoreCombo
    Friend WithEvents lblDirecto As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSector As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents cmbGpoMaterial As Selling.StoreCombo
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents dtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents txtNombreMaterial As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModDescuento))
        Me.grpMaterial = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnBuscaMaterial = New Janus.Windows.EditControls.UIButton()
        Me.txtClaveMaterial = New System.Windows.Forms.TextBox()
        Me.txtNombreMaterial = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.dtInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnBuscaCliente = New Janus.Windows.EditControls.UIButton()
        Me.txtClaveCliente = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInicio = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFin = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblDirecto = New System.Windows.Forms.Label()
        Me.LblUnidadVenta = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.dtFin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.cmbGpoMaterial = New Selling.StoreCombo()
        Me.cmbTipoSector = New Selling.StoreCombo()
        Me.cmbDirecto = New Selling.StoreCombo()
        Me.grpMaterial.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCliente.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMaterial
        '
        Me.grpMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMaterial.Controls.Add(Me.PictureBox2)
        Me.grpMaterial.Controls.Add(Me.btnBuscaMaterial)
        Me.grpMaterial.Controls.Add(Me.txtClaveMaterial)
        Me.grpMaterial.Controls.Add(Me.txtNombreMaterial)
        Me.grpMaterial.Controls.Add(Me.Label7)
        Me.grpMaterial.Location = New System.Drawing.Point(3, 61)
        Me.grpMaterial.Name = "grpMaterial"
        Me.grpMaterial.Size = New System.Drawing.Size(702, 49)
        Me.grpMaterial.TabIndex = 0
        Me.grpMaterial.TabStop = False
        Me.grpMaterial.Text = "Material"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(33, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox2.TabIndex = 153
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnBuscaMaterial
        '
        Me.btnBuscaMaterial.Image = CType(resources.GetObject("btnBuscaMaterial.Image"), System.Drawing.Image)
        Me.btnBuscaMaterial.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscaMaterial.Location = New System.Drawing.Point(191, 16)
        Me.btnBuscaMaterial.Name = "btnBuscaMaterial"
        Me.btnBuscaMaterial.Size = New System.Drawing.Size(48, 24)
        Me.btnBuscaMaterial.TabIndex = 2
        Me.btnBuscaMaterial.ToolTipText = "Busqueda de Producto"
        Me.btnBuscaMaterial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtClaveMaterial
        '
        Me.txtClaveMaterial.Location = New System.Drawing.Point(60, 19)
        Me.txtClaveMaterial.Name = "txtClaveMaterial"
        Me.txtClaveMaterial.Size = New System.Drawing.Size(127, 20)
        Me.txtClaveMaterial.TabIndex = 1
        '
        'txtNombreMaterial
        '
        Me.txtNombreMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreMaterial.Location = New System.Drawing.Point(245, 19)
        Me.txtNombreMaterial.Name = "txtNombreMaterial"
        Me.txtNombreMaterial.ReadOnly = True
        Me.txtNombreMaterial.Size = New System.Drawing.Size(450, 20)
        Me.txtNombreMaterial.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Clave"
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(371, 208)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(136, 16)
        Me.lblInicio.TabIndex = 136
        Me.lblInicio.Text = "Inicio de Vigencia"
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(374, 225)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(118, 20)
        Me.dtInicio.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(252, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "% Dscto."
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(252, 225)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(96, 20)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0.0R
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(602, 267)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(506, 267)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpCliente
        '
        Me.grpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCliente.Controls.Add(Me.PictureBox1)
        Me.grpCliente.Controls.Add(Me.btnBuscaCliente)
        Me.grpCliente.Controls.Add(Me.txtClaveCliente)
        Me.grpCliente.Controls.Add(Me.txtNombreCliente)
        Me.grpCliente.Controls.Add(Me.Label2)
        Me.grpCliente.Controls.Add(Me.Label3)
        Me.grpCliente.Location = New System.Drawing.Point(3, 4)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(702, 49)
        Me.grpCliente.TabIndex = 137
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = "Cliente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(33, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox1.TabIndex = 152
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'btnBuscaCliente
        '
        Me.btnBuscaCliente.Image = CType(resources.GetObject("btnBuscaCliente.Image"), System.Drawing.Image)
        Me.btnBuscaCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnBuscaCliente.Location = New System.Drawing.Point(191, 16)
        Me.btnBuscaCliente.Name = "btnBuscaCliente"
        Me.btnBuscaCliente.Size = New System.Drawing.Size(48, 24)
        Me.btnBuscaCliente.TabIndex = 2
        Me.btnBuscaCliente.ToolTipText = "Busqueda de Producto"
        Me.btnBuscaCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtClaveCliente
        '
        Me.txtClaveCliente.Location = New System.Drawing.Point(60, 19)
        Me.txtClaveCliente.Name = "txtClaveCliente"
        Me.txtClaveCliente.Size = New System.Drawing.Size(127, 20)
        Me.txtClaveCliente.TabIndex = 1
        '
        'txtNombreCliente
        '
        Me.txtNombreCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreCliente.Location = New System.Drawing.Point(245, 18)
        Me.txtNombreCliente.Name = "txtNombreCliente"
        Me.txtNombreCliente.ReadOnly = True
        Me.txtNombreCliente.Size = New System.Drawing.Size(451, 20)
        Me.txtNombreCliente.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Inicio"
        '
        'txtInicio
        '
        Me.txtInicio.Location = New System.Drawing.Point(14, 225)
        Me.txtInicio.Name = "txtInicio"
        Me.txtInicio.Size = New System.Drawing.Size(96, 20)
        Me.txtInicio.TabIndex = 138
        Me.txtInicio.Text = "0.00"
        Me.txtInicio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtInicio.Value = 0.0R
        Me.txtInicio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(131, 206)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 16)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Fin"
        '
        'txtFin
        '
        Me.txtFin.Location = New System.Drawing.Point(134, 225)
        Me.txtFin.Name = "txtFin"
        Me.txtFin.Size = New System.Drawing.Size(96, 20)
        Me.txtFin.TabIndex = 140
        Me.txtFin.Text = "0.00"
        Me.txtFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFin.Value = 0.0R
        Me.txtFin.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblDirecto
        '
        Me.lblDirecto.Location = New System.Drawing.Point(10, 178)
        Me.lblDirecto.Name = "lblDirecto"
        Me.lblDirecto.Size = New System.Drawing.Size(100, 14)
        Me.lblDirecto.TabIndex = 144
        Me.lblDirecto.Text = "Descuento Directo"
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(10, 151)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(76, 15)
        Me.LblUnidadVenta.TabIndex = 147
        Me.LblUnidadVenta.Text = "Tipo Sector"
        '
        'lblGrupo
        '
        Me.lblGrupo.Location = New System.Drawing.Point(10, 123)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(108, 15)
        Me.lblGrupo.TabIndex = 149
        Me.lblGrupo.Text = "Grupo de Material"
        '
        'dtFin
        '
        Me.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFin.Location = New System.Drawing.Point(506, 225)
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(118, 20)
        Me.dtFin.TabIndex = 150
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(503, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Fin de Vigencia"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(112, 123)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox3.TabIndex = 154
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(112, 151)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox4.TabIndex = 155
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(112, 178)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox5.TabIndex = 156
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(45, 205)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox6.TabIndex = 157
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(155, 205)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox7.TabIndex = 158
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(298, 205)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox8.TabIndex = 159
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(463, 202)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox9.TabIndex = 160
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(602, 202)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox10.TabIndex = 161
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(387, 175)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(252, 21)
        Me.ChkTodos.TabIndex = 180
        Me.ChkTodos.Text = "Aplicar a Todos los Productos"
        Me.ChkTodos.Visible = False
        '
        'cmbGpoMaterial
        '
        Me.cmbGpoMaterial.Location = New System.Drawing.Point(138, 120)
        Me.cmbGpoMaterial.Name = "cmbGpoMaterial"
        Me.cmbGpoMaterial.Size = New System.Drawing.Size(241, 21)
        Me.cmbGpoMaterial.TabIndex = 148
        '
        'cmbTipoSector
        '
        Me.cmbTipoSector.Location = New System.Drawing.Point(138, 148)
        Me.cmbTipoSector.Name = "cmbTipoSector"
        Me.cmbTipoSector.Size = New System.Drawing.Size(241, 21)
        Me.cmbTipoSector.TabIndex = 146
        '
        'cmbDirecto
        '
        Me.cmbDirecto.Location = New System.Drawing.Point(138, 175)
        Me.cmbDirecto.Name = "cmbDirecto"
        Me.cmbDirecto.Size = New System.Drawing.Size(241, 21)
        Me.cmbDirecto.TabIndex = 145
        '
        'FrmModDescuento
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(710, 316)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtFin)
        Me.Controls.Add(Me.cmbGpoMaterial)
        Me.Controls.Add(Me.lblGrupo)
        Me.Controls.Add(Me.cmbTipoSector)
        Me.Controls.Add(Me.LblUnidadVenta)
        Me.Controls.Add(Me.cmbDirecto)
        Me.Controls.Add(Me.lblDirecto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInicio)
        Me.Controls.Add(Me.grpCliente)
        Me.Controls.Add(Me.lblInicio)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.dtInicio)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpMaterial)
        Me.Controls.Add(Me.TxtImporte)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmModDescuento"
        Me.Text = "Modificar vigencia"
        Me.grpMaterial.ResumeLayout(False)
        Me.grpMaterial.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCliente.ResumeLayout(False)
        Me.grpCliente.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Id As String
    Public Tipo As Integer
    Public Nivel As Integer
    Public DESClave As String

    Public Cliente As String
    Public Producto As String
    
    Public GrupoMaterial As Integer
    Public TipoSector As Integer
    Public DescuentoDirecto As Double
    'Public DescuentoPostVenta As Decimal

    Public Inicio As Date
    Public Fin As Date
    Public RangoInicial As Double
    Public RangoFinal As Double
    Public Importe As Double
    Public Padre As String

    Private PROClave As String = ""
    Private CTEClave As String = ""
    Private alerta(9) As PictureBox
    Private reloj As parpadea
    Private dt As DataTable
    Private bcargado As Boolean = False

    Private Sub recuperaCliente(ByVal sClave As String)
        Dim dtCliente As DataTable = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", sClave, "@COMClave", ModPOS.CompanyActual)
        If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
            CTEClave = dtCliente.Rows(0)("CTEClave")
            Cliente = dtCliente.Rows(0)("Clave")
            txtNombreCliente.Text = dtCliente.Rows(0)("RazonSocial")
            dtCliente.Dispose()
        Else
            CTEClave = ""
            Cliente = ""
            txtNombreCliente.Text = ""
            MessageBox.Show("¡La Clave de cliente no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        txtClaveCliente.Text = Cliente

    End Sub

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_busca_producto", "@Clave", sClave.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@Char", cReplace)
        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
            PROClave = dtProducto.Rows(0)("PROClave")
            Producto = dtProducto.Rows(0)("Clave")
            txtNombreMaterial.Text = dtProducto.Rows(0)("Nombre")
            dtProducto.Dispose()
        Else
            PROClave = ""
            Producto = ""
            txtNombreMaterial.Text = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        txtClaveMaterial.Text = Producto

    End Sub

    Private Sub FrmModDescuento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10

        Select Case Nivel
            Case 1, 9 ' Cliente\Material
                cmbDirecto.Enabled = False
                cmbGpoMaterial.Enabled = False
                cmbTipoSector.Enabled = False
                ChkTodos.Visible = True

            Case 2, 5 'Cliente\Grupo
                With Me.cmbGpoMaterial
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_gpo_material"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .llenar()
                End With

                grpMaterial.Enabled = False
                cmbDirecto.Enabled = False
                cmbTipoSector.Enabled = False
                cmbGpoMaterial.SelectedValue = GrupoMaterial

            Case 3, 10 'Material
                grpCliente.Enabled = False
                cmbDirecto.Enabled = False
                cmbGpoMaterial.Enabled = False
                cmbTipoSector.Enabled = False
              
            Case Is = 4 ' Descuento\Material
                With cmbDirecto
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_valorref"
                    .NombreParametro1 = "tabla"
                    .Parametro1 = "Cliente"
                    .NombreParametro2 = "campo"
                    .Parametro2 = "DescuentoDirecto"
                    .llenar()
                End With
                lblDirecto.Text = "Descuento Directo"
                ChkTodos.Visible = True
                TxtImporte.Enabled = False
                cmbDirecto.SelectedValue = DescuentoDirecto
                grpCliente.Enabled = False
                cmbGpoMaterial.Enabled = False
                cmbTipoSector.Enabled = False

            Case 6, 11 ' Sector\Descuento
                With cmbDirecto
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_valorref"
                    .NombreParametro1 = "tabla"
                    .Parametro1 = "Cliente"
                    .NombreParametro2 = "campo"
                    .Parametro2 = "DescuentoDirecto"
                    .llenar()
                End With
                cmbDirecto.SelectedValue = DescuentoDirecto
                lblDirecto.Text = "Descuento Directo"
                With Me.cmbTipoSector
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_sector"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .llenar()
                End With
                cmbTipoSector.SelectedValue = TipoSector
                grpMaterial.Enabled = False
                grpCliente.Enabled = False
                cmbGpoMaterial.Enabled = False
                TxtImporte.Enabled = False

            Case 7, 12 'Grupo\Descuento

                With Me.cmbGpoMaterial
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_gpo_material"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .llenar()
                End With
                cmbGpoMaterial.SelectedValue = GrupoMaterial

                With cmbDirecto
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_valorref"
                    .NombreParametro1 = "tabla"
                    .Parametro1 = "Cliente"
                    .NombreParametro2 = "campo"
                    .Parametro2 = "DescuentoDirecto"
                    .llenar()
                End With

                cmbDirecto.SelectedValue = DescuentoDirecto
                lblDirecto.Text = "Descuento Directo"
               
                grpMaterial.Enabled = False
                grpCliente.Enabled = False
                cmbTipoSector.Enabled = False
                TxtImporte.Enabled = False

            Case Is = 8 ' Grupo
                With Me.cmbGpoMaterial
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_gpo_material"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .llenar()
                End With

                cmbGpoMaterial.SelectedValue = GrupoMaterial
                grpMaterial.Enabled = False
                grpCliente.Enabled = False
                cmbDirecto.Enabled = False
                cmbTipoSector.Enabled = False
            Case Is = 13 ' Sector / Post. Venta
               
                With Me.cmbTipoSector
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_sector"
                    .NombreParametro1 = "COMClave"
                    .Parametro1 = ModPOS.CompanyActual
                    .llenar()
                End With
                cmbTipoSector.SelectedValue = TipoSector


                With cmbDirecto
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_valorref"
                    .NombreParametro1 = "tabla"
                    .Parametro1 = "Cliente"
                    .NombreParametro2 = "campo"
                    .Parametro2 = "DescuentoPostVenta"
                    .llenar()
                End With
                cmbDirecto.SelectedValue = DescuentoDirecto
                lblDirecto.Text = "Desc.PostVenta"


                grpMaterial.Enabled = False
                grpCliente.Enabled = False
                cmbGpoMaterial.Enabled = False
                TxtImporte.Enabled = False


            Case Is = 14 ' Post. Venta

                With cmbDirecto
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_filtra_valorref"
                    .NombreParametro1 = "tabla"
                    .Parametro1 = "Cliente"
                    .NombreParametro2 = "campo"
                    .Parametro2 = "DescuentoPostVenta"
                    .llenar()
                End With
                cmbDirecto.SelectedValue = DescuentoDirecto
                lblDirecto.Text = "Desc.PostVenta"
                grpMaterial.Enabled = False
                grpCliente.Enabled = False
                cmbDirecto.Enabled = True
                cmbGpoMaterial.Enabled = False
                cmbTipoSector.Enabled = False
        End Select

        bcargado = True

        If Tipo <> 2 Then
        
            txtInicio.Enabled = False
            txtFin.Enabled = False
        End If


        If Padre = "Nuevo" Then
        
            dtInicio.Value = Today.Date
            dtFin.Value = "#31/12/9998#"
        Else
            ChkTodos.Enabled = False

            Select Case Nivel
                Case 1, 9 'Cliente /Material
                    recuperaProducto(Me.Producto)
                    recuperaCliente(Me.Cliente)
                Case 2, 5 'Cliente
                    recuperaCliente(Me.Cliente)
                Case 3, 4, 10 'Material
                    recuperaProducto(Me.Producto)
            End Select

            If Tipo = 2 Then
                txtInicio.Text = RangoInicial
                txtFin.Text = RangoFinal
            End If

            TxtImporte.Text = Importe

            dtInicio.Value = Inicio

            dtFin.Value = IIf(Fin > "#31/12/9998#", "#31/12/9998#", Fin)

            grpMaterial.Enabled = False
            grpCliente.Enabled = False
            cmbDirecto.Enabled = False
            cmbGpoMaterial.Enabled = False
            cmbTipoSector.Enabled = False

        End If


    End Sub

    Private Sub FrmModDescuento_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ModDescuento.Dispose()
        ModPOS.ModDescuento = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim result As Boolean

            If Padre = "Nuevo" Then

            
                Select Case Nivel
                    Case 1, 9 ' Cliente\Material
                        If ChkTodos.Checked Then
                            Dim frmStatusMessage As New frmStatus
                            frmStatusMessage.BringToFront()
                            Dim i As Integer
                            Dim dt As DataTable = Recupera_Tabla("st_todos_productos", "@COMClave", ModPOS.CompanyActual, "@DESClave", DESClave)
                            For i = 0 To dt.Rows.Count - 1
                                frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dt.Rows.Count) & " registros")
                                result = ModPOS.DesCte.addVigencia(Tipo, Nivel, txtClaveMaterial.Text, PROClave, txtClaveCliente.Text, CTEClave, "", 0, "", 0, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                            Next
                            dt.Dispose()
                            frmStatusMessage.Close()

                        Else
                            result = ModPOS.DesCte.addVigencia(Tipo, Nivel, txtClaveMaterial.Text, PROClave, txtClaveCliente.Text, CTEClave, "", 0, "", 0, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                        End If
                    Case 2, 5 'Cliente\Grupo
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", txtClaveCliente.Text, CTEClave, cmbGpoMaterial.SelectedItem(1), cmbGpoMaterial.SelectedValue, "", 0, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                    Case 3, 10 'Material
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, txtClaveMaterial.Text, PROClave, "", "", "", 0, "", 0, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                    Case Is = 4 ' Descuento\Material
                        If ChkTodos.Checked Then
                            Dim frmStatusMessage As New frmStatus
                            frmStatusMessage.BringToFront()
                            Dim i As Integer
                            Dim dt As DataTable = Recupera_Tabla("st_todos_productos", "@COMClave", ModPOS.CompanyActual, "@DESClave", DESClave)
                            For i = 0 To dt.Rows.Count - 1
                                frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dt.Rows.Count) & " registros")

                                ModPOS.DesCte.addVigencia(Tipo, Nivel, dt.Rows(i)("Clave"), dt.Rows(i)("PROClave"), "", "", "", 0, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                            Next
                            dt.Dispose()
                            frmStatusMessage.Close()

                        Else
                            result = ModPOS.DesCte.addVigencia(Tipo, Nivel, txtClaveMaterial.Text, PROClave, "", "", "", 0, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                        End If
                    Case 6, 11 ' Sector\Descuento
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", "", "", "", 0, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, cmbTipoSector.SelectedItem(1), cmbTipoSector.SelectedValue, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                    Case 7, 12 'Grupo\Descuento
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", "", "", cmbGpoMaterial.SelectedItem(1), cmbGpoMaterial.SelectedValue, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                    Case Is = 8 ' Grupo
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", "", "", cmbGpoMaterial.SelectedItem(1), cmbGpoMaterial.SelectedValue, "", 0, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)
                    Case Is = 13 'Sector\PostVenta
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", "", "", "", 0, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, cmbTipoSector.SelectedItem(1), cmbTipoSector.SelectedValue, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)

                    Case Is = 14 ' Postventa
                        result = ModPOS.DesCte.addVigencia(Tipo, Nivel, "", "", "", "", "", 0, cmbDirecto.SelectedItem(1), cmbDirecto.SelectedValue, "", 0, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)

                End Select

                If result = True Then
                    CTEClave = ""
                    txtClaveCliente.Text = ""
                    txtNombreCliente.Text = ""

                    PROClave = ""
                    txtClaveMaterial.Text = ""
                    txtNombreMaterial.Text = ""

                    txtInicio.Text = 0
                    txtFin.Text = 0

                    TxtImporte.Text = 0
                    dtInicio.Value = Today.Date
                    dtFin.Value = Today.Date.AddDays(1)
                End If

            Else

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_desdet", _
                                               "@Id", Id,
                                               "@DESClave", DESClave, _
                                               "@Nivel", Nivel, _
                                               "@Tipo", Tipo, _
                                               "@CTEClave", CTEClave, _
                                               "@PROClave", PROClave, _
                                               "@TipoSector", IIf(cmbTipoSector.SelectedValue Is Nothing, 0, cmbTipoSector.SelectedValue), _
                                               "@DescuentoDirecto", IIf(cmbDirecto.SelectedValue Is Nothing, 0, cmbDirecto.SelectedValue), _
                                               "@GrupoMaterial", IIf(cmbGpoMaterial.SelectedValue Is Nothing, 0, cmbGpoMaterial.SelectedValue), _
                                               "@Inicio", dtInicio.Value, _
                                               "@Fin", dtFin.Value.AddHours(23.9999), _
                                               "@COMClave", ModPOS.CompanyActual) > 0 Then


                    Beep()
                    MessageBox.Show("La política de descuento que intenta agregar tiene conflicto de vigencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else
                    ModPOS.DesCte.updVigencia(Id, Tipo, CDbl(txtInicio.Text), CDbl(txtFin.Text), CDbl(TxtImporte.Text), dtInicio.Value, dtFin.Value)

                    Me.Close()
                End If
            End If
        Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        Select Case Nivel
            Case 1, 9 ' Cliente\Material

                If Me.Cliente = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(0))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If ChkTodos.Checked = False AndAlso Me.Producto = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case 2, 5 'Cliente\Grupo

                If Me.Cliente = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(0))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If Me.cmbGpoMaterial.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case 3, 10 'Material
                If Me.Producto = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case Is = 4 ' Descuento\Material
                If cmbDirecto.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(4))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If ChkTodos.Checked = False AndAlso Me.Producto = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case 6, 11 ' Sector\Descuento
                If cmbDirecto.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(4))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If cmbTipoSector.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(3))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case Is = 7 'Grupo\Descuento
                If cmbDirecto.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(4))
                    reloj.Enabled = True
                    reloj.Start()
                End If

                If cmbGpoMaterial.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                End If

            Case Is = 8 ' Grupo
                If Me.cmbGpoMaterial.SelectedValue Is Nothing Then
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                End If
        End Select

        If Tipo = 2 Then
            If CDbl(txtInicio.Text) <= 0 Then
                i += 1
                reloj = New parpadea(Me.alerta(5))
                reloj.Enabled = True
                reloj.Start()

            ElseIf CDbl(txtInicio.Text) > CDbl(txtFin.Text) Then
                i += 1
                reloj = New parpadea(Me.alerta(6))
                reloj.Enabled = True
                reloj.Start()
            End If

        End If



        If CDbl(TxtImporte.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If


        If dtInicio.Value > dtFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Padre = "Nuevo" Then
            If dtInicio.Value < Today Then
                i += 1
                reloj = New parpadea(Me.alerta(8))
                reloj.Enabled = True
                reloj.Start()
            End If

        Else
            If dtFin.Value < Today Then
                i += 1
                reloj = New parpadea(Me.alerta(9))
                reloj.Enabled = True
                reloj.Start()
            End If
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

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaMaterial.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.BusquedaInicial = False
        a.Busqueda = txtClaveMaterial.Text.Trim.ToUpper
        a.AlmRequerido = False
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
           
            recuperaProducto(a.valor)
        End If
        a.Dispose()

    End Sub

    Private Sub TxtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClaveMaterial.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(txtClaveMaterial.Text) Then
                recuperaProducto(txtClaveMaterial.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de producto es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = txtClaveMaterial.Text.Trim.ToUpper
            a.AlmRequerido = False
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()

        End If

    End Sub

    Private Sub txtClaveCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClaveCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(txtClaveCliente.Text) Then
                recuperaCliente(txtClaveCliente.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de cliente es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_cliente"
            a.TablaCmb = "Cliente"
            a.CampoCmb = "Filtro"
            a.OcultaID = True
            a.BusquedaInicial = True
            a.Busqueda = txtClaveCliente.Text
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If Not a.valor Is Nothing Then
                    recuperaCliente(a.Descripcion)
                End If
            End If
            a.Dispose()
        End If

    End Sub

    Private Sub btnBuscaCliente_Click(sender As Object, e As EventArgs) Handles btnBuscaCliente.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                recuperaCliente(a.Descripcion)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub cmbDirecto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDirecto.SelectedValueChanged
        If bcargado = True AndAlso Not cmbDirecto.SelectedValue Is Nothing Then
            TxtImporte.Text = cmbDirecto.SelectedValue
        End If
    End Sub
End Class
