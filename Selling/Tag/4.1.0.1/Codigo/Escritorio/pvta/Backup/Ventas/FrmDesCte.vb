Public Class FrmDesCte
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
    Friend WithEvents BtnEliminaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClass As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSubClass As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnAddSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents LblPorc As System.Windows.Forms.Label
    Friend WithEvents TxtDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblDescuento As System.Windows.Forms.Label
    Friend WithEvents ChkCascada As Selling.ChkStatus
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents cmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbAplicacion As Selling.StoreCombo
    Friend WithEvents TxtImporteIni As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtImporteFin As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NumUPDGerarquia As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDesCte))
        Me.GrpClass = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.NumUPDGerarquia = New System.Windows.Forms.NumericUpDown
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.Lbl1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtImporteFin = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtImporteIni = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblTipo = New System.Windows.Forms.Label
        Me.cmbAplicacion = New Selling.StoreCombo
        Me.LblPorc = New System.Windows.Forms.Label
        Me.TxtDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblDescuento = New System.Windows.Forms.Label
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ChkCascada = New Selling.ChkStatus(Me.components)
        Me.cmbTipo = New Selling.StoreCombo
        Me.LblFactura = New System.Windows.Forms.Label
        Me.cmbFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrpSubClass = New System.Windows.Forms.GroupBox
        Me.BtnAddSub = New Janus.Windows.EditControls.UIButton
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
        Me.BtnEliminaCte = New Janus.Windows.EditControls.UIButton
        Me.GrpClass.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUPDGerarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSubClass.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClass
        '
        Me.GrpClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClass.Controls.Add(Me.PictureBox4)
        Me.GrpClass.Controls.Add(Me.NumUPDGerarquia)
        Me.GrpClass.Controls.Add(Me.PictureBox9)
        Me.GrpClass.Controls.Add(Me.PictureBox8)
        Me.GrpClass.Controls.Add(Me.PictureBox7)
        Me.GrpClass.Controls.Add(Me.Lbl1)
        Me.GrpClass.Controls.Add(Me.Label3)
        Me.GrpClass.Controls.Add(Me.TxtImporteFin)
        Me.GrpClass.Controls.Add(Me.TxtImporteIni)
        Me.GrpClass.Controls.Add(Me.Label2)
        Me.GrpClass.Controls.Add(Me.LblTipo)
        Me.GrpClass.Controls.Add(Me.cmbAplicacion)
        Me.GrpClass.Controls.Add(Me.LblPorc)
        Me.GrpClass.Controls.Add(Me.TxtDescuento)
        Me.GrpClass.Controls.Add(Me.LblDescuento)
        Me.GrpClass.Controls.Add(Me.PictureBox6)
        Me.GrpClass.Controls.Add(Me.PictureBox5)
        Me.GrpClass.Controls.Add(Me.PictureBox3)
        Me.GrpClass.Controls.Add(Me.ChkCascada)
        Me.GrpClass.Controls.Add(Me.cmbTipo)
        Me.GrpClass.Controls.Add(Me.LblFactura)
        Me.GrpClass.Controls.Add(Me.cmbFechaFin)
        Me.GrpClass.Controls.Add(Me.Label1)
        Me.GrpClass.Controls.Add(Me.cmbFechaInicio)
        Me.GrpClass.Controls.Add(Me.Label8)
        Me.GrpClass.Controls.Add(Me.PictureBox1)
        Me.GrpClass.Controls.Add(Me.ChkEstado)
        Me.GrpClass.Controls.Add(Me.PictureBox2)
        Me.GrpClass.Controls.Add(Me.TxtNombre)
        Me.GrpClass.Controls.Add(Me.LblNombre)
        Me.GrpClass.Controls.Add(Me.TxtClave)
        Me.GrpClass.Controls.Add(Me.LblClave)
        Me.GrpClass.Controls.Add(Me.Label4)
        Me.GrpClass.Controls.Add(Me.BtnGuardar)
        Me.GrpClass.Controls.Add(Me.BtnCancelar)
        Me.GrpClass.Controls.Add(Me.Label7)
        Me.GrpClass.Location = New System.Drawing.Point(7, 7)
        Me.GrpClass.Name = "GrpClass"
        Me.GrpClass.Size = New System.Drawing.Size(778, 231)
        Me.GrpClass.TabIndex = 1
        Me.GrpClass.TabStop = False
        Me.GrpClass.Text = "Configuración del Descuento o Bonificación"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(220, 135)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox4.TabIndex = 82
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'NumUPDGerarquia
        '
        Me.NumUPDGerarquia.Location = New System.Drawing.Point(399, 19)
        Me.NumUPDGerarquia.Name = "NumUPDGerarquia"
        Me.NumUPDGerarquia.Size = New System.Drawing.Size(80, 20)
        Me.NumUPDGerarquia.TabIndex = 3
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(466, 203)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox9.TabIndex = 80
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(341, 203)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox8.TabIndex = 79
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(380, 19)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox7.TabIndex = 78
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Lbl1
        '
        Me.Lbl1.Location = New System.Drawing.Point(344, 203)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(116, 17)
        Me.Lbl1.TabIndex = 77
        Me.Lbl1.Text = " antes de impuestos"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(217, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 17)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "a"
        '
        'TxtImporteFin
        '
        Me.TxtImporteFin.Location = New System.Drawing.Point(238, 201)
        Me.TxtImporteFin.Name = "TxtImporteFin"
        Me.TxtImporteFin.Size = New System.Drawing.Size(96, 20)
        Me.TxtImporteFin.TabIndex = 75
        Me.TxtImporteFin.Text = "0.00"
        Me.TxtImporteFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporteFin.Value = 0
        Me.TxtImporteFin.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtImporteIni
        '
        Me.TxtImporteIni.Location = New System.Drawing.Point(109, 201)
        Me.TxtImporteIni.Name = "TxtImporteIni"
        Me.TxtImporteIni.Size = New System.Drawing.Size(96, 20)
        Me.TxtImporteIni.TabIndex = 73
        Me.TxtImporteIni.Text = "0.00"
        Me.TxtImporteIni.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporteIni.Value = 0
        Me.TxtImporteIni.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 17)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Aplica a Ventas de"
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(12, 21)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(80, 15)
        Me.LblTipo.TabIndex = 72
        Me.LblTipo.Text = "Tipo"
        '
        'cmbAplicacion
        '
        Me.cmbAplicacion.Location = New System.Drawing.Point(111, 18)
        Me.cmbAplicacion.Name = "cmbAplicacion"
        Me.cmbAplicacion.Size = New System.Drawing.Size(160, 21)
        Me.cmbAplicacion.TabIndex = 71
        '
        'LblPorc
        '
        Me.LblPorc.Location = New System.Drawing.Point(189, 136)
        Me.LblPorc.Name = "LblPorc"
        Me.LblPorc.Size = New System.Drawing.Size(73, 25)
        Me.LblPorc.TabIndex = 70
        Me.LblPorc.Text = "%"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.Location = New System.Drawing.Point(111, 133)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(73, 20)
        Me.TxtDescuento.TabIndex = 5
        Me.TxtDescuento.Text = "0.00"
        Me.TxtDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescuento.Value = 0
        Me.TxtDescuento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblDescuento
        '
        Me.LblDescuento.Location = New System.Drawing.Point(13, 135)
        Me.LblDescuento.Name = "LblDescuento"
        Me.LblDescuento.Size = New System.Drawing.Size(86, 16)
        Me.LblDescuento.TabIndex = 68
        Me.LblDescuento.Text = "Descuento"
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(520, 169)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 67
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(284, 169)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 66
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(277, 105)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 64
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'ChkCascada
        '
        Me.ChkCascada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCascada.Checked = True
        Me.ChkCascada.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCascada.Location = New System.Drawing.Point(347, 133)
        Me.ChkCascada.Name = "ChkCascada"
        Me.ChkCascada.Size = New System.Drawing.Size(153, 22)
        Me.ChkCascada.TabIndex = 6
        Me.ChkCascada.Text = "Aplica Cascada"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(111, 99)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'LblFactura
        '
        Me.LblFactura.Location = New System.Drawing.Point(13, 107)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(87, 15)
        Me.LblFactura.TabIndex = 62
        Me.LblFactura.Text = "Tipo Aplicación"
        '
        'cmbFechaFin
        '
        Me.cmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.cmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaFin.Location = New System.Drawing.Point(348, 165)
        Me.cmbFechaFin.MinDate = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaFin.Name = "cmbFechaFin"
        Me.cmbFechaFin.Size = New System.Drawing.Size(166, 20)
        Me.cmbFechaFin.TabIndex = 8
        Me.cmbFechaFin.Value = New Date(2007, 1, 1, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(285, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Fecha Fin"
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(111, 166)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(167, 20)
        Me.cmbFechaInicio.TabIndex = 7
        Me.cmbFechaInicio.Value = New Date(2007, 1, 1, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Fecha Inicio "
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(371, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(566, 40)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(57, 22)
        Me.ChkEstado.TabIndex = 2
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(623, 71)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(111, 70)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(512, 20)
        Me.TxtNombre.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 77)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(111, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(259, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 53)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(378, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(681, 15)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 30)
        Me.BtnGuardar.TabIndex = 9
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(681, 51)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(341, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 16)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Jerarquía"
        '
        'GrpSubClass
        '
        Me.GrpSubClass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSubClass.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSubClass.Controls.Add(Me.BtnAddSub)
        Me.GrpSubClass.Controls.Add(Me.GridClientes)
        Me.GrpSubClass.Controls.Add(Me.BtnEliminaCte)
        Me.GrpSubClass.Location = New System.Drawing.Point(7, 243)
        Me.GrpSubClass.Name = "GrpSubClass"
        Me.GrpSubClass.Size = New System.Drawing.Size(778, 278)
        Me.GrpSubClass.TabIndex = 2
        Me.GrpSubClass.TabStop = False
        Me.GrpSubClass.Text = "Clientes con Descuento"
        '
        'BtnAddSub
        '
        Me.BtnAddSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddSub.Image = CType(resources.GetObject("BtnAddSub.Image"), System.Drawing.Image)
        Me.BtnAddSub.Location = New System.Drawing.Point(681, 15)
        Me.BtnAddSub.Name = "BtnAddSub"
        Me.BtnAddSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddSub.TabIndex = 2
        Me.BtnAddSub.Text = "&Agregar"
        Me.BtnAddSub.ToolTipText = "Agregar nuevo cliente al descuento actual"
        Me.BtnAddSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClientes
        '
        Me.GridClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.GroupByBoxVisible = False
        Me.GridClientes.Location = New System.Drawing.Point(7, 15)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(668, 255)
        Me.GridClientes.TabIndex = 1
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaCte
        '
        Me.BtnEliminaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaCte.Image = CType(resources.GetObject("BtnEliminaCte.Image"), System.Drawing.Image)
        Me.BtnEliminaCte.Location = New System.Drawing.Point(681, 52)
        Me.BtnEliminaCte.Name = "BtnEliminaCte"
        Me.BtnEliminaCte.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaCte.TabIndex = 3
        Me.BtnEliminaCte.Text = "&Eliminar "
        Me.BtnEliminaCte.ToolTipText = "Eliminar cliente seleccionado del descuento"
        Me.BtnEliminaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmDesCte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 526)
        Me.Controls.Add(Me.GrpClass)
        Me.Controls.Add(Me.GrpSubClass)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmDesCte"
        Me.Text = "Descuento o Bonificación"
        Me.GrpClass.ResumeLayout(False)
        Me.GrpClass.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUPDGerarquia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSubClass.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String



    Public DESClave As String = ""
    Public Clave As String
    Public Nombre As String
    Public Tipo As Integer = 1
    Public Descuento As Double
    Public Cascada As Integer
    Public FechaInicio As Date = Today
    Public FechaFin As Date = Today
    Public Estado As Integer = 1
    Public Aplicacion As Integer = 1
    Public ImporteIni As Double
    Public ImporteFin As Double
    Public Gerarquia As Integer
    Private sClienteSelected As String
    Private sNombre As String
    Private ClienteEdited As Boolean = False

    Private alerta(8) As PictureBox
    Private reloj As parpadea
    Private bCargado As Boolean = False
    Private dtCliente As DataTable

#Region "Metodos Internos"


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If

        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtDescuento.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()

        ElseIf CDbl(TxtDescuento.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtImporteIni.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()

        ElseIf CDbl(TxtImporteIni.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtImporteFin.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()

        ElseIf CDbl(TxtImporteFin.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtImporteIni.Text <> "" AndAlso TxtImporteFin.Text <> "" Then
            If CDbl(TxtImporteFin.Text) < CDbl(TxtImporteIni.Text) Then
                i += 1
                reloj = New parpadea(Me.alerta(7))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Padre <> "Modificar" AndAlso DateDiff(DateInterval.Day, Today, cmbFechaInicio.Value) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If DateDiff(DateInterval.Day, cmbFechaInicio.Value, cmbFechaFin.Value) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Descuento", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
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

#End Region


    Private Sub FrmClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9

        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With cmbAplicacion
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Descuento"
            .NombreParametro2 = "campo"
            .Parametro2 = "Aplicacion"
            .llenar()
        End With

        With cmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Descuento"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        TxtDescuento.Text = Descuento * 100
        TxtImporteFin.Text = ImporteFin
        TxtImporteIni.Text = ImporteIni
        cmbAplicacion.SelectedValue = Aplicacion
        cmbTipo.SelectedValue = Tipo
        ChkEstado.Estado = Estado
        ChkCascada.Estado = Math.Abs(Cascada)
        cmbFechaInicio.Value = FechaInicio
        cmbFechaFin.Value = FechaFin
        NumUPDGerarquia.Value = Gerarquia

        If Padre = "Modificar" Then

            dtCliente = ModPOS.Recupera_Tabla("sp_muestra_descte", "@Descuento", DESClave)


            cmbFechaInicio.Enabled = False

        Else
            dtCliente = ModPOS.CrearTabla("DescuentoCliente", _
                                           "ID", "System.String", _
                                           "Clave", "System.String", _
                                           "Razon Social", "System.String", _
                                           "RFC", "System.String", _
                                           "Status", "System.Int32")
        End If

        GridClientes.DataSource = dtCliente
        GridClientes.RetrieveStructure(True)
        GridClientes.RootTable.Columns("ID").Visible = False
        GridClientes.RootTable.Columns("Status").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClientes.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClientes.RootTable.FormatConditions.Add(fc)

        bCargado = True

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GridClientes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClientes.SelectionChanged
        If Not Me.GridClientes.GetValue(0) Is Nothing Then
            Me.BtnEliminaCte.Enabled = True
            Me.sClienteSelected = GridClientes.GetValue("ID")
            Me.sNombre = GridClientes.GetValue(1)
        Else
            Me.sClienteSelected = ""
            Me.sNombre = ""
            Me.BtnEliminaCte.Enabled = False
        End If
    End Sub

    Private Sub FrmDesCte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.DesCte.Dispose()
        ModPOS.DesCte = Nothing
    End Sub

    Public Sub addClienteDetalle(ByVal ID As String, ByVal Clave As String, ByVal RazonSocial As String, ByVal RFC As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtCliente.Select("ID Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtCliente.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ID
            row1.Item("Clave") = Clave
            row1.Item("Razon Social") = RazonSocial
            row1.Item("RFC") = RFC
            row1.Item("Status") = 0


            dtCliente.Rows.Add(row1)

            ClienteEdited = True
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If dtCliente.Rows.Count = 0 Then
                MessageBox.Show("¡Debe agregar por lo menos un cliente a la politica de descuento!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"

                    DESClave = ModPOS.obtenerLlave

                    Clave = TxtClave.Text.Trim.ToUpper
                    Nombre = TxtNombre.Text.Trim.ToUpper
                    Tipo = cmbTipo.SelectedValue
                    Descuento = CDbl(TxtDescuento.Text) / 100
                    Cascada = ChkCascada.GetEstado
                    FechaInicio = cmbFechaInicio.Value
                    FechaFin = cmbFechaFin.Value.AddHours(23.9999)
                    Aplicacion = cmbAplicacion.SelectedValue
                    ImporteIni = CDbl(TxtImporteIni.Text)
                    ImporteFin = CDbl(TxtImporteFin.Text)
                    Gerarquia = NumUPDGerarquia.Value

                    ModPOS.Ejecuta("sp_inserta_descuento", _
                    "@DESClave", DESClave, _
                    "@Aplicacion", Aplicacion, _
                    "@Clave", Clave, _
                    "@Nombre", Nombre, _
                    "@Tipo", Tipo, _
                    "@Descuento", Descuento, _
                    "@Cascada", Cascada, _
                    "@FechaInicio", FechaInicio, _
                    "@FechaFin", FechaFin, _
                    "@ImporteInicial", ImporteIni, _
                    "@ImporteFinal", ImporteFin, _
                    "@Gerarquia", Gerarquia, _
                    "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)

                    'Dim dt As DataTable
                    'dt = ModPOS.Recupera_Tabla("sp_recupera_clavedesc", "@Clave", Clave)
                    'DESClave = dt.Rows(0)("DESClave")
                    'dt.Dispose()

                 
                    Dim fila As Integer

                    Dim foundRows() As DataRow
                    foundRows = dtCliente.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        Cursor.Current = Cursors.WaitCursor
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_descte", _
                            "@DESClave", DESClave, _
                            "@CTEClave", foundRows(fila)("ID"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                        Cursor.Current = Cursors.Default
                    End If

                    If Not ModPOS.MtoDesCte Is Nothing Then
                        ModPOS.ActualizaGrid(True, MtoDesCte.GridDescuentos, "sp_muestra_descuentos", "@COMClave", ModPOS.CompanyActual)
                        MtoDesCte.GridDescuentos.RootTable.Columns("ID").Visible = False
                    End If


                Case "Modificar"
                    If Not (Nombre = TxtNombre.Text.Trim.ToUpper AndAlso _
                        Tipo = cmbTipo.SelectedValue AndAlso _
                        Descuento = CDbl(TxtDescuento.Text) / 100 AndAlso _
                        Cascada = ChkCascada.GetEstado AndAlso _
                        FechaFin.Date = cmbFechaFin.Value.Date AndAlso _
                        Aplicacion = cmbAplicacion.SelectedValue AndAlso _
                        ImporteIni = CDbl(TxtImporteIni.Text) AndAlso _
                        ImporteFin = CDbl(TxtImporteFin.Text) AndAlso _
                        Gerarquia = NumUPDGerarquia.Value AndAlso _
                        Estado = ChkEstado.GetEstado) Then


                        Nombre = TxtNombre.Text.Trim.ToUpper
                        Tipo = cmbTipo.SelectedValue
                        Descuento = CDbl(TxtDescuento.Text) / 100
                        Cascada = ChkCascada.GetEstado
                        FechaFin = cmbFechaFin.Value.Date.AddHours(23.9999)
                        Estado = ChkEstado.GetEstado
                        Aplicacion = cmbAplicacion.SelectedValue
                        ImporteIni = CDbl(TxtImporteIni.Text)
                        ImporteFin = CDbl(TxtImporteFin.Text)
                        Gerarquia = NumUPDGerarquia.Value


                        ModPOS.Ejecuta("sp_actualiza_descuento", _
                    "@DESClave", DESClave, _
                     "@Aplicacion", Aplicacion, _
                     "@Nombre", Nombre, _
                    "@Tipo", Tipo, _
                    "@Descuento", Descuento, _
                    "@Cascada", Cascada, _
                    "@FechaInicio", FechaInicio, _
                    "@FechaFin", FechaFin, _
                    "@Estado", Estado, _
                    "@ImporteInicial", ImporteIni, _
                    "@ImporteFinal", ImporteFin, _
                    "@Gerarquia", Gerarquia, _
                    "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)


                        If Not ModPOS.MtoDesCte Is Nothing Then
                            ModPOS.ActualizaGrid(True, MtoDesCte.GridDescuentos, "sp_muestra_descuentos", "@COMClave", ModPOS.CompanyActual)
                            MtoDesCte.GridDescuentos.RootTable.Columns("ID").Visible = False
                        End If

                    End If

                    Dim fila As Integer

                    If ClienteEdited = True Then
                        Dim foundRows() As DataRow

                        Cursor.Current = Cursors.WaitCursor
                        foundRows = dtCliente.Select("Status=0")

                        If foundRows.GetLength(0) > 0 Then
                            For fila = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_descte", _
                                "@DESClave", DESClave, _
                                "@CTEClave", foundRows(fila)("ID"), _
                                "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        foundRows = dtCliente.Select("Status=-1")
                        If foundRows.GetLength(0) > 0 Then
                            Cursor.Current = Cursors.WaitCursor
                            For fila = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_elimina_descte", "@CTEClave", foundRows(fila)("ID"), "@DESCLAVE", DESClave)
                            Next
                        End If
                        Cursor.Current = Cursors.Default

                    End If

                    
            End Select

            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnAddSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddSub.Click
        If ModPOS.AddCtes Is Nothing Then
            ModPOS.AddCtes = New FrmAddCtes
            With ModPOS.AddCtes
                .Text = "Agregar Cliente a la Lista de Descuento"
                .StartPosition = FormStartPosition.CenterScreen
                .Clave = Me.DESClave
            End With
        End If
        ModPOS.AddCtes.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddCtes.Show()
        ModPOS.AddCtes.BringToFront()
    End Sub

    Private Sub BtnEliminaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaCte.Click
        If sClienteSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Cliente :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCliente.Select("ID Like '" & sClienteSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1
                        ClienteEdited = True
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub




    Private Sub cmbAplicacion_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAplicacion.SelectedValueChanged
        If bCargado Then
            If Not cmbAplicacion.SelectedValue Is Nothing Then
                Select Case CInt(cmbAplicacion.SelectedValue)
                    Case Is = 1
                        LblDescuento.Text = "Descuento"
                        LblPorc.Text = "%"
                    Case Is = 2
                        LblDescuento.Text = "Bonificación"
                        LblPorc.Text = "Importe"
                    Case Is = 3
                        LblDescuento.Text = "Puntos"
                        LblPorc.Text = "%"
                End Select

            Else

            End If
        End If

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblPorc.Click

    End Sub
End Class
