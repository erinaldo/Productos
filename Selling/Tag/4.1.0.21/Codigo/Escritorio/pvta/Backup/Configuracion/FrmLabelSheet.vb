Public Class FrmLabelSheet
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPrinter As System.Windows.Forms.GroupBox
    Friend WithEvents ChkHorizontal As Selling.ChkStatus
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtEspFilas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtFilas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtEspColumnas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtColumnas As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMpInferior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMpSuperior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMpDerecho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMpIzquierdo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMeInferior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMeSuperior As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMeDerecho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtMeIzquierdo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtFontSize As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtCodeSize As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtFontName As System.Windows.Forms.TextBox
    Friend WithEvents BtnFuente As Janus.Windows.EditControls.UIButton
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPreview As Janus.Windows.EditControls.UIButton
    Friend WithEvents dlgPrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtAltoPapel As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtAnchoPapel As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLabelSheet))
        Me.GrpPrinter = New System.Windows.Forms.GroupBox
        Me.PictureBox21 = New System.Windows.Forms.PictureBox
        Me.TxtAltoPapel = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtAnchoPapel = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.PictureBox20 = New System.Windows.Forms.PictureBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmbTipo = New Selling.StoreCombo
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtFontName = New System.Windows.Forms.TextBox
        Me.BtnFuente = New Janus.Windows.EditControls.UIButton
        Me.TxtFontSize = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtCodeSize = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtEspFilas = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtFilas = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtEspColumnas = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtColumnas = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox19 = New System.Windows.Forms.PictureBox
        Me.PictureBox18 = New System.Windows.Forms.PictureBox
        Me.PictureBox17 = New System.Windows.Forms.PictureBox
        Me.PictureBox16 = New System.Windows.Forms.PictureBox
        Me.TxtMeInferior = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMeSuperior = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMeDerecho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMeIzquierdo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox15 = New System.Windows.Forms.PictureBox
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.TxtMpInferior = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMpSuperior = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMpDerecho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtMpIzquierdo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ChkHorizontal = New Selling.ChkStatus(Me.components)
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.BtnPreview = New Janus.Windows.EditControls.UIButton
        Me.dlgPrintDialog = New System.Windows.Forms.PrintDialog
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpPrinter.SuspendLayout()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPrinter
        '
        Me.GrpPrinter.Controls.Add(Me.PictureBox21)
        Me.GrpPrinter.Controls.Add(Me.TxtAltoPapel)
        Me.GrpPrinter.Controls.Add(Me.TxtAnchoPapel)
        Me.GrpPrinter.Controls.Add(Me.Label1)
        Me.GrpPrinter.Controls.Add(Me.Label20)
        Me.GrpPrinter.Controls.Add(Me.PictureBox20)
        Me.GrpPrinter.Controls.Add(Me.Label19)
        Me.GrpPrinter.Controls.Add(Me.cmbTipo)
        Me.GrpPrinter.Controls.Add(Me.PictureBox11)
        Me.GrpPrinter.Controls.Add(Me.PictureBox10)
        Me.GrpPrinter.Controls.Add(Me.PictureBox9)
        Me.GrpPrinter.Controls.Add(Me.PictureBox8)
        Me.GrpPrinter.Controls.Add(Me.PictureBox7)
        Me.GrpPrinter.Controls.Add(Me.PictureBox6)
        Me.GrpPrinter.Controls.Add(Me.PictureBox5)
        Me.GrpPrinter.Controls.Add(Me.PictureBox4)
        Me.GrpPrinter.Controls.Add(Me.PictureBox3)
        Me.GrpPrinter.Controls.Add(Me.PictureBox2)
        Me.GrpPrinter.Controls.Add(Me.Label18)
        Me.GrpPrinter.Controls.Add(Me.TxtFontName)
        Me.GrpPrinter.Controls.Add(Me.BtnFuente)
        Me.GrpPrinter.Controls.Add(Me.TxtFontSize)
        Me.GrpPrinter.Controls.Add(Me.Label17)
        Me.GrpPrinter.Controls.Add(Me.TxtCodeSize)
        Me.GrpPrinter.Controls.Add(Me.Label14)
        Me.GrpPrinter.Controls.Add(Me.TxtNombre)
        Me.GrpPrinter.Controls.Add(Me.LblNombre)
        Me.GrpPrinter.Controls.Add(Me.TxtAlto)
        Me.GrpPrinter.Controls.Add(Me.TxtAncho)
        Me.GrpPrinter.Controls.Add(Me.TxtEspFilas)
        Me.GrpPrinter.Controls.Add(Me.TxtFilas)
        Me.GrpPrinter.Controls.Add(Me.TxtEspColumnas)
        Me.GrpPrinter.Controls.Add(Me.TxtColumnas)
        Me.GrpPrinter.Controls.Add(Me.GroupBox2)
        Me.GrpPrinter.Controls.Add(Me.GroupBox1)
        Me.GrpPrinter.Controls.Add(Me.Label11)
        Me.GrpPrinter.Controls.Add(Me.Label12)
        Me.GrpPrinter.Controls.Add(Me.Label8)
        Me.GrpPrinter.Controls.Add(Me.Label7)
        Me.GrpPrinter.Controls.Add(Me.Label6)
        Me.GrpPrinter.Controls.Add(Me.Label5)
        Me.GrpPrinter.Controls.Add(Me.ChkHorizontal)
        Me.GrpPrinter.Controls.Add(Me.ChkEstado)
        Me.GrpPrinter.Controls.Add(Me.PictureBox1)
        Me.GrpPrinter.Location = New System.Drawing.Point(7, 7)
        Me.GrpPrinter.Name = "GrpPrinter"
        Me.GrpPrinter.Size = New System.Drawing.Size(453, 376)
        Me.GrpPrinter.TabIndex = 1
        Me.GrpPrinter.TabStop = False
        Me.GrpPrinter.Text = "Plantilla"
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
        Me.PictureBox21.Location = New System.Drawing.Point(83, 110)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox21.TabIndex = 112
        Me.PictureBox21.TabStop = False
        Me.PictureBox21.Visible = False
        '
        'TxtAltoPapel
        '
        Me.TxtAltoPapel.DecimalDigits = 2
        Me.TxtAltoPapel.Location = New System.Drawing.Point(132, 108)
        Me.TxtAltoPapel.Name = "TxtAltoPapel"
        Me.TxtAltoPapel.Size = New System.Drawing.Size(79, 20)
        Me.TxtAltoPapel.TabIndex = 3
        Me.TxtAltoPapel.Text = "0.00"
        Me.TxtAltoPapel.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAltoPapel.Value = 0
        Me.TxtAltoPapel.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtAnchoPapel
        '
        Me.TxtAnchoPapel.DecimalDigits = 2
        Me.TxtAnchoPapel.Location = New System.Drawing.Point(132, 82)
        Me.TxtAnchoPapel.Name = "TxtAnchoPapel"
        Me.TxtAnchoPapel.Size = New System.Drawing.Size(79, 20)
        Me.TxtAnchoPapel.TabIndex = 2
        Me.TxtAnchoPapel.Text = "0.00"
        Me.TxtAnchoPapel.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAnchoPapel.Value = 0
        Me.TxtAnchoPapel.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Alto Papel (cm)"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(5, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 13)
        Me.Label20.TabIndex = 110
        Me.Label20.Text = "Ancho Papel (cm)"
        '
        'PictureBox20
        '
        Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
        Me.PictureBox20.Location = New System.Drawing.Point(74, 18)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox20.TabIndex = 107
        Me.PictureBox20.TabStop = False
        Me.PictureBox20.Visible = False
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(6, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 15)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Tipo de Plantilla"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(100, 18)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(194, 21)
        Me.cmbTipo.TabIndex = 105
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(81, 223)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox11.TabIndex = 104
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(82, 163)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox10.TabIndex = 103
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(301, 204)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox9.TabIndex = 102
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(301, 177)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox8.TabIndex = 101
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(301, 142)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox7.TabIndex = 100
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(82, 192)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox6.TabIndex = 99
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(301, 116)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 98
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(82, 137)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox4.TabIndex = 97
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(259, 88)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 96
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(83, 84)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 95
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(224, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 15)
        Me.Label18.TabIndex = 94
        Me.Label18.Text = "Fuente"
        '
        'TxtFontName
        '
        Me.TxtFontName.Location = New System.Drawing.Point(277, 86)
        Me.TxtFontName.Name = "TxtFontName"
        Me.TxtFontName.ReadOnly = True
        Me.TxtFontName.Size = New System.Drawing.Size(127, 20)
        Me.TxtFontName.TabIndex = 93
        '
        'BtnFuente
        '
        Me.BtnFuente.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFuente.Location = New System.Drawing.Point(407, 83)
        Me.BtnFuente.Name = "BtnFuente"
        Me.BtnFuente.Size = New System.Drawing.Size(27, 27)
        Me.BtnFuente.TabIndex = 8
        Me.BtnFuente.Text = "A"
        '
        'TxtFontSize
        '
        Me.TxtFontSize.Location = New System.Drawing.Point(354, 116)
        Me.TxtFontSize.Name = "TxtFontSize"
        Me.TxtFontSize.Size = New System.Drawing.Size(79, 20)
        Me.TxtFontSize.TabIndex = 9
        Me.TxtFontSize.Text = "0"
        Me.TxtFontSize.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtFontSize.Value = 0
        Me.TxtFontSize.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(224, 119)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "Tamaño Letra"
        '
        'TxtCodeSize
        '
        Me.TxtCodeSize.Location = New System.Drawing.Point(354, 142)
        Me.TxtCodeSize.Name = "TxtCodeSize"
        Me.TxtCodeSize.Size = New System.Drawing.Size(79, 20)
        Me.TxtCodeSize.TabIndex = 10
        Me.TxtCodeSize.Text = "0"
        Me.TxtCodeSize.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtCodeSize.Value = 0
        Me.TxtCodeSize.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(224, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Tamaño Código"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(101, 45)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(193, 20)
        Me.TxtNombre.TabIndex = 0
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 48)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(67, 15)
        Me.LblNombre.TabIndex = 86
        Me.LblNombre.Text = "Nombre "
        '
        'TxtAlto
        '
        Me.TxtAlto.DecimalDigits = 2
        Me.TxtAlto.Location = New System.Drawing.Point(354, 201)
        Me.TxtAlto.Name = "TxtAlto"
        Me.TxtAlto.Size = New System.Drawing.Size(79, 20)
        Me.TxtAlto.TabIndex = 12
        Me.TxtAlto.Text = "0.00"
        Me.TxtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAlto.Value = 0
        Me.TxtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtAncho
        '
        Me.TxtAncho.DecimalDigits = 2
        Me.TxtAncho.Location = New System.Drawing.Point(354, 174)
        Me.TxtAncho.Name = "TxtAncho"
        Me.TxtAncho.Size = New System.Drawing.Size(79, 20)
        Me.TxtAncho.TabIndex = 11
        Me.TxtAncho.Text = "0.00"
        Me.TxtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAncho.Value = 0
        Me.TxtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtEspFilas
        '
        Me.TxtEspFilas.DecimalDigits = 2
        Me.TxtEspFilas.Location = New System.Drawing.Point(132, 219)
        Me.TxtEspFilas.Name = "TxtEspFilas"
        Me.TxtEspFilas.Size = New System.Drawing.Size(79, 20)
        Me.TxtEspFilas.TabIndex = 7
        Me.TxtEspFilas.Text = "0.00"
        Me.TxtEspFilas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtEspFilas.Value = 0
        Me.TxtEspFilas.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtFilas
        '
        Me.TxtFilas.Location = New System.Drawing.Point(132, 189)
        Me.TxtFilas.Name = "TxtFilas"
        Me.TxtFilas.Size = New System.Drawing.Size(79, 20)
        Me.TxtFilas.TabIndex = 6
        Me.TxtFilas.Text = "1"
        Me.TxtFilas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtFilas.Value = 1
        Me.TxtFilas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'TxtEspColumnas
        '
        Me.TxtEspColumnas.DecimalDigits = 2
        Me.TxtEspColumnas.Location = New System.Drawing.Point(132, 161)
        Me.TxtEspColumnas.Name = "TxtEspColumnas"
        Me.TxtEspColumnas.Size = New System.Drawing.Size(79, 20)
        Me.TxtEspColumnas.TabIndex = 5
        Me.TxtEspColumnas.Text = "0.00"
        Me.TxtEspColumnas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtEspColumnas.Value = 0
        Me.TxtEspColumnas.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtColumnas
        '
        Me.TxtColumnas.Location = New System.Drawing.Point(132, 135)
        Me.TxtColumnas.Name = "TxtColumnas"
        Me.TxtColumnas.Size = New System.Drawing.Size(79, 20)
        Me.TxtColumnas.TabIndex = 4
        Me.TxtColumnas.Text = "1"
        Me.TxtColumnas.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtColumnas.Value = 1
        Me.TxtColumnas.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox19)
        Me.GroupBox2.Controls.Add(Me.PictureBox18)
        Me.GroupBox2.Controls.Add(Me.PictureBox17)
        Me.GroupBox2.Controls.Add(Me.PictureBox16)
        Me.GroupBox2.Controls.Add(Me.TxtMeInferior)
        Me.GroupBox2.Controls.Add(Me.TxtMeSuperior)
        Me.GroupBox2.Controls.Add(Me.TxtMeDerecho)
        Me.GroupBox2.Controls.Add(Me.TxtMeIzquierdo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(263, 243)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 120)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Margen de la Etiqueta"
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(51, 94)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox19.TabIndex = 108
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(51, 69)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox18.TabIndex = 107
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(52, 44)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox17.TabIndex = 106
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(52, 18)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox16.TabIndex = 105
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'TxtMeInferior
        '
        Me.TxtMeInferior.DecimalDigits = 2
        Me.TxtMeInferior.Location = New System.Drawing.Point(87, 90)
        Me.TxtMeInferior.Name = "TxtMeInferior"
        Me.TxtMeInferior.Size = New System.Drawing.Size(83, 20)
        Me.TxtMeInferior.TabIndex = 4
        Me.TxtMeInferior.Text = "0.00"
        Me.TxtMeInferior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMeInferior.Value = 0
        Me.TxtMeInferior.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMeSuperior
        '
        Me.TxtMeSuperior.DecimalDigits = 2
        Me.TxtMeSuperior.Location = New System.Drawing.Point(87, 65)
        Me.TxtMeSuperior.Name = "TxtMeSuperior"
        Me.TxtMeSuperior.Size = New System.Drawing.Size(83, 20)
        Me.TxtMeSuperior.TabIndex = 3
        Me.TxtMeSuperior.Text = "0.00"
        Me.TxtMeSuperior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMeSuperior.Value = 0
        Me.TxtMeSuperior.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMeDerecho
        '
        Me.TxtMeDerecho.DecimalDigits = 2
        Me.TxtMeDerecho.Location = New System.Drawing.Point(87, 41)
        Me.TxtMeDerecho.Name = "TxtMeDerecho"
        Me.TxtMeDerecho.Size = New System.Drawing.Size(83, 20)
        Me.TxtMeDerecho.TabIndex = 2
        Me.TxtMeDerecho.Text = "0.00"
        Me.TxtMeDerecho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMeDerecho.Value = 0
        Me.TxtMeDerecho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMeIzquierdo
        '
        Me.TxtMeIzquierdo.DecimalDigits = 2
        Me.TxtMeIzquierdo.Location = New System.Drawing.Point(87, 15)
        Me.TxtMeIzquierdo.Name = "TxtMeIzquierdo"
        Me.TxtMeIzquierdo.Size = New System.Drawing.Size(83, 20)
        Me.TxtMeIzquierdo.TabIndex = 1
        Me.TxtMeIzquierdo.Text = "0.00"
        Me.TxtMeIzquierdo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMeIzquierdo.Value = 0
        Me.TxtMeIzquierdo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Izq. (cm)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Der. (cm)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Superior (cm)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Inferior (cm)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox15)
        Me.GroupBox1.Controls.Add(Me.PictureBox14)
        Me.GroupBox1.Controls.Add(Me.PictureBox13)
        Me.GroupBox1.Controls.Add(Me.PictureBox12)
        Me.GroupBox1.Controls.Add(Me.TxtMpInferior)
        Me.GroupBox1.Controls.Add(Me.TxtMpSuperior)
        Me.GroupBox1.Controls.Add(Me.TxtMpDerecho)
        Me.GroupBox1.Controls.Add(Me.TxtMpIzquierdo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 244)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 120)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Margen de la Hoja"
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(55, 94)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox15.TabIndex = 108
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(55, 71)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox14.TabIndex = 107
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(55, 47)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox13.TabIndex = 106
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(57, 19)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox12.TabIndex = 105
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'TxtMpInferior
        '
        Me.TxtMpInferior.DecimalDigits = 2
        Me.TxtMpInferior.Location = New System.Drawing.Point(97, 93)
        Me.TxtMpInferior.Name = "TxtMpInferior"
        Me.TxtMpInferior.Size = New System.Drawing.Size(79, 20)
        Me.TxtMpInferior.TabIndex = 4
        Me.TxtMpInferior.Text = "0.00"
        Me.TxtMpInferior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMpInferior.Value = 0
        Me.TxtMpInferior.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMpSuperior
        '
        Me.TxtMpSuperior.DecimalDigits = 2
        Me.TxtMpSuperior.Location = New System.Drawing.Point(96, 68)
        Me.TxtMpSuperior.Name = "TxtMpSuperior"
        Me.TxtMpSuperior.Size = New System.Drawing.Size(79, 20)
        Me.TxtMpSuperior.TabIndex = 3
        Me.TxtMpSuperior.Text = "0.00"
        Me.TxtMpSuperior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMpSuperior.Value = 0
        Me.TxtMpSuperior.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMpDerecho
        '
        Me.TxtMpDerecho.DecimalDigits = 2
        Me.TxtMpDerecho.Location = New System.Drawing.Point(96, 44)
        Me.TxtMpDerecho.Name = "TxtMpDerecho"
        Me.TxtMpDerecho.Size = New System.Drawing.Size(79, 20)
        Me.TxtMpDerecho.TabIndex = 2
        Me.TxtMpDerecho.Text = "0.00"
        Me.TxtMpDerecho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMpDerecho.Value = 0
        Me.TxtMpDerecho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtMpIzquierdo
        '
        Me.TxtMpIzquierdo.DecimalDigits = 2
        Me.TxtMpIzquierdo.Location = New System.Drawing.Point(96, 18)
        Me.TxtMpIzquierdo.Name = "TxtMpIzquierdo"
        Me.TxtMpIzquierdo.Size = New System.Drawing.Size(79, 20)
        Me.TxtMpIzquierdo.TabIndex = 1
        Me.TxtMpIzquierdo.Text = "0.00"
        Me.TxtMpIzquierdo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtMpIzquierdo.Value = 0
        Me.TxtMpIzquierdo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Izq. (cm)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Der. (cm)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Superior (cm)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Inferior (cm)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Espacio/Filas (cm)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 163)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Espacio/Columnas (cm)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "No. Filas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "No. Columnas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(224, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Alto Etiqueta (cm)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(224, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Ancho Etiqueta (cm)"
        '
        'ChkHorizontal
        '
        Me.ChkHorizontal.Location = New System.Drawing.Point(307, 18)
        Me.ChkHorizontal.Name = "ChkHorizontal"
        Me.ChkHorizontal.Size = New System.Drawing.Size(97, 22)
        Me.ChkHorizontal.TabIndex = 14
        Me.ChkHorizontal.Text = "Horizontal"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(307, 45)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(68, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(74, 47)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnPreview
        '
        Me.BtnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPreview.Icon = CType(resources.GetObject("BtnPreview.Icon"), System.Drawing.Icon)
        Me.BtnPreview.Location = New System.Drawing.Point(274, 389)
        Me.BtnPreview.Name = "BtnPreview"
        Me.BtnPreview.Size = New System.Drawing.Size(90, 37)
        Me.BtnPreview.TabIndex = 4
        Me.BtnPreview.Text = "&Vista Previa"
        Me.BtnPreview.ToolTipText = "Generar Vista Previa de Impresión"
        Me.BtnPreview.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dlgPrintDialog
        '
        Me.dlgPrintDialog.UseEXDialog = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(178, 389)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(370, 389)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmLabelSheet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(465, 432)
        Me.Controls.Add(Me.BtnPreview)
        Me.Controls.Add(Me.GrpPrinter)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLabelSheet"
        Me.Text = "Plantilla"
        Me.GrpPrinter.ResumeLayout(False)
        Me.GrpPrinter.PerformLayout()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public Tipo As Integer = 0
    Public IDSheet As String = ""
    Public Nombre As String = ""

    Public AnchoPapel As Double
    Public AltoPapel As Double
    Public mpSuperior As Double
    Public mpInferior As Double
    Public mpIzquierdo As Double
    Public mpDerecho As Double
    Public Horizontal As Boolean = False
    Public Columnas As Integer
    Public Filas As Integer
    Public EspacioColumna As Double
    Public EspacioFila As Double
    Public AnchoEtiqueta As Double
    Public AltoEtiqueta As Double
    Public meSuperior As Double
    Public meInferior As Double
    Public meIzquierdo As Double
    Public meDerecho As Double
    Public TipoLetra As String = ""
    Public SizeLetra As Double
    Public SizeCodigo As Double
    Public Estado As Integer


    Private alerta(20) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False

    Private Sub reinicializa()
        Tipo = 0
        Nombre = ""
        mpSuperior = 0
        mpInferior = 0
        mpIzquierdo = 0
        mpDerecho = 0
        Horizontal = False
        Columnas = 0
        Filas = 0
        EspacioColumna = 0
        EspacioFila = 0
        AnchoEtiqueta = 0
        AltoEtiqueta = 0
        AnchoPapel = 0
        AltoPapel = 0
        meSuperior = 0
        meInferior = 0
        meIzquierdo = 0
        meDerecho = 0
        TipoLetra = ""
        SizeLetra = 0
        SizeCodigo = 0
        Estado = 0
        cmbTipo.SelectedValue = Tipo
        TxtNombre.Text = Nombre
        TxtAnchoPapel.Text = AnchoPapel
        TxtAltoPapel.Text = AltoPapel
        TxtMpSuperior.Text = mpSuperior
        TxtMpInferior.Text = mpInferior
        TxtMpIzquierdo.Text = mpIzquierdo
        TxtMpDerecho.Text = mpDerecho
        ChkHorizontal.Checked = Horizontal
        TxtColumnas.Text = Columnas
        TxtFilas.Text = Filas
        TxtEspColumnas.Text = EspacioColumna
        TxtEspFilas.Text = EspacioFila
        TxtAncho.Text = AnchoEtiqueta
        TxtAlto.Text = AltoEtiqueta
        TxtMeSuperior.Text = meSuperior
        TxtMeInferior.Text = meInferior
        TxtMeIzquierdo.Text = meIzquierdo
        TxtMeDerecho.Text = meDerecho
        TxtFontName.Text = TipoLetra
        TxtFontSize.Text = SizeLetra
        TxtCodeSize.Text = SizeCodigo
        ChkEstado.Estado = Estado
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtAnchoPapel.Text <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtAltoPapel.Text <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(20))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtFontName.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtColumnas.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtFontSize.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CInt(TxtFilas.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CInt(TxtCodeSize.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtAncho.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CInt(TxtAlto.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtEspColumnas.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtEspFilas.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMpIzquierdo.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMpDerecho.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMpSuperior.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMpInferior.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMeIzquierdo.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMeDerecho.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMeSuperior.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(17))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtMeInferior.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(18))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(19))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length - 1
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmImpuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        alerta(9) = Me.PictureBox10
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox14
        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox16
        alerta(16) = Me.PictureBox17
        alerta(17) = Me.PictureBox18
        alerta(18) = Me.PictureBox19

        alerta(19) = Me.PictureBox20

        alerta(19) = Me.PictureBox21



        With Me.cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "LabelSheet"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        '        Dim printDoc As New System.Drawing.Printing.PrintDocument()


      
        cmbTipo.SelectedValue = Tipo
        TxtNombre.Text = Nombre
        TxtAnchoPapel.Text = AnchoPapel
        TxtAltoPapel.Text = AltoPapel
        TxtMpSuperior.Text = mpSuperior
        TxtMpInferior.Text = mpInferior
        TxtMpIzquierdo.Text = mpIzquierdo
        TxtMpDerecho.Text = mpDerecho
        ChkHorizontal.Checked = Horizontal
        TxtColumnas.Text = Columnas
        TxtFilas.Text = Filas
        TxtEspColumnas.Text = EspacioColumna
        TxtEspFilas.Text = EspacioFila
        TxtAncho.Text = AnchoEtiqueta
        TxtAlto.Text = AltoEtiqueta
        TxtMeSuperior.Text = meSuperior
        TxtMeInferior.Text = meInferior
        TxtMeIzquierdo.Text = meIzquierdo
        TxtMeDerecho.Text = meDerecho
        TxtFontName.Text = TipoLetra
        TxtFontSize.Text = SizeLetra
        TxtCodeSize.Text = SizeCodigo
        ChkEstado.Estado = Estado


        bload = True
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"
                    Tipo = cmbTipo.SelectedValue
                    IDSheet = ModPOS.obtenerLlave
                    Nombre = TxtNombre.Text

                    AnchoPapel = TxtAnchoPapel.Text
                    AltoPapel = TxtAltoPapel.Text

                    mpSuperior = TxtMpSuperior.Text
                    mpInferior = TxtMpInferior.Text
                    mpIzquierdo = TxtMpIzquierdo.Text
                    mpDerecho = TxtMpDerecho.Text
                    Horizontal = ChkHorizontal.Checked
                    Columnas = TxtColumnas.Text
                    Filas = TxtFilas.Text
                    EspacioColumna = TxtEspColumnas.Text
                    EspacioFila = TxtEspFilas.Text
                    AnchoEtiqueta = TxtAncho.Text
                    AltoEtiqueta = TxtAlto.Text
                    meSuperior = TxtMeSuperior.Text
                    meInferior = TxtMeInferior.Text
                    meIzquierdo = TxtMeIzquierdo.Text
                    meDerecho = TxtMeDerecho.Text
                    TipoLetra = TxtFontName.Text
                    SizeLetra = TxtFontSize.Text
                    SizeCodigo = TxtCodeSize.Text
                    Estado = ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_inserta_labelsheet", _
                                    "@IDSheet", IDSheet, _
                                    "@Tipo", Tipo, _
                                    "@Nombre", Nombre, _
                                    "@AnchoPapel", AnchoPapel, _
                                    "@AltoPapel", AltoPapel, _
                                    "@mpSuperior", mpSuperior, _
                                    "@mpInferior", mpInferior, _
                                    "@mpIzquierdo", mpIzquierdo, _
                                    "@mpDerecho", mpDerecho, _
                                    "@Horizontal", Horizontal, _
                                    "@Columnas", Columnas, _
                                    "@Filas", Filas, _
                                    "@EspacioColumna", EspacioColumna, _
                                    "@EspacioFila", EspacioFila, _
                                    "@AnchoEtiqueta", AnchoEtiqueta, _
                                    "@AltoEtiqueta", AltoEtiqueta, _
                                    "@meSuperior", meSuperior, _
                                    "@meInferior", meInferior, _
                                    "@meIzquierdo", meIzquierdo, _
                                    "@meDerecho", meDerecho, _
                                    "@TipoLetra", TipoLetra, _
                                    "@SizeLetra", SizeLetra, _
                                    "@SizeCodigo", SizeCodigo, _
                                    "@Usuario", ModPOS.UsuarioActual)

                    reinicializa()

                    If Not ModPOS.MtoLabelSheet Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoLabelSheet.GridLabelSheets, "sp_consulta_labelsheet", Nothing)
                        ModPOS.MtoLabelSheet.GridLabelSheets.RootTable.Columns("ID").Visible = False

                    End If

                Case "Modificar"
                    If Not (Tipo = cmbTipo.SelectedValue AndAlso _
                        Nombre = TxtNombre.Text AndAlso _
                        AnchoPapel = TxtAnchoPapel.Text AndAlso _
                        AltoPapel = TxtAltoPapel.Text AndAlso _
                        mpSuperior = TxtMpSuperior.Text AndAlso _
                        mpInferior = TxtMpInferior.Text AndAlso _
                        mpIzquierdo = TxtMpIzquierdo.Text AndAlso _
                        mpDerecho = TxtMpDerecho.Text AndAlso _
                        Horizontal = ChkHorizontal.Checked AndAlso _
                        Columnas = TxtColumnas.Text AndAlso _
                        Filas = TxtFilas.Text AndAlso _
                        EspacioColumna = TxtEspColumnas.Text AndAlso _
                        EspacioFila = TxtEspFilas.Text AndAlso _
                        AnchoEtiqueta = TxtAncho.Text AndAlso _
                        AltoEtiqueta = TxtAlto.Text AndAlso _
                        meSuperior = TxtMeSuperior.Text AndAlso _
                        meInferior = TxtMeInferior.Text AndAlso _
                        meIzquierdo = TxtMeIzquierdo.Text AndAlso _
                        meDerecho = TxtMeDerecho.Text AndAlso _
                        TipoLetra = TxtFontName.Text AndAlso _
                        SizeLetra = TxtFontSize.Text AndAlso _
                        SizeCodigo = TxtCodeSize.Text AndAlso _
                        Estado = ChkEstado.GetEstado) Then

                        Tipo = cmbTipo.SelectedValue
                        Nombre = TxtNombre.Text
                        AnchoPapel = TxtAnchoPapel.Text
                        AltoPapel = TxtAltoPapel.Text
                        mpSuperior = TxtMpSuperior.Text
                        mpInferior = TxtMpInferior.Text
                        mpIzquierdo = TxtMpIzquierdo.Text
                        mpDerecho = TxtMpDerecho.Text
                        Horizontal = ChkHorizontal.Checked
                        Columnas = TxtColumnas.Text
                        Filas = TxtFilas.Text
                        EspacioColumna = TxtEspColumnas.Text
                        EspacioFila = TxtEspFilas.Text
                        AnchoEtiqueta = TxtAncho.Text
                        AltoEtiqueta = TxtAlto.Text
                        meSuperior = TxtMeSuperior.Text
                        meInferior = TxtMeInferior.Text
                        meIzquierdo = TxtMeIzquierdo.Text
                        meDerecho = TxtMeDerecho.Text
                        TipoLetra = TxtFontName.Text
                        SizeLetra = TxtFontSize.Text
                        SizeCodigo = TxtCodeSize.Text
                        Estado = ChkEstado.GetEstado

                        ModPOS.Ejecuta("sp_actualiza_labelsheet", _
                                        "@IDSheet", IDSheet, _
                                        "@Tipo", Tipo, _
                                        "@Nombre", Nombre, _
                                        "@AnchoPapel", AnchoPapel, _
                                        "@AltoPapel", AltoPapel, _
                                        "@mpSuperior", mpSuperior, _
                                        "@mpInferior", mpInferior, _
                                        "@mpIzquierdo", mpIzquierdo, _
                                        "@mpDerecho", mpDerecho, _
                                        "@Horizontal", Horizontal, _
                                        "@Columnas", Columnas, _
                                        "@Filas", Filas, _
                                        "@EspacioColumna", EspacioColumna, _
                                        "@EspacioFila", EspacioFila, _
                                        "@AnchoEtiqueta", AnchoEtiqueta, _
                                        "@AltoEtiqueta", AltoEtiqueta, _
                                        "@meSuperior", meSuperior, _
                                        "@meInferior", meInferior, _
                                        "@meIzquierdo", meIzquierdo, _
                                        "@meDerecho", meDerecho, _
                                        "@TipoLetra", TipoLetra, _
                                        "@SizeLetra", SizeLetra, _
                                        "@SizeCodigo", SizeCodigo, _
                                        "@Estado", Estado, _
                                        "@Usuario", ModPOS.UsuarioActual)


                        If Not ModPOS.MtoLabelSheet Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoLabelSheet.GridLabelSheets, "sp_consulta_labelsheet", Nothing)
                            ModPOS.MtoLabelSheet.GridLabelSheets.RootTable.Columns("ID").Visible = False

                        End If

                    End If
                    Me.Close()
            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmLabelSheet_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.LabelSheet.Dispose()
        ModPOS.LabelSheet = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnFuente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFuente.Click
        FontDialog1.ShowColor = False
        FontDialog1.ShowEffects = False

        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            TxtFontName.Text = FontDialog1.Font.Name
            TxtFontSize.Text = CStr(ModPOS.Redondear(FontDialog1.Font.Size, 0))
        End If
    End Sub

   


    Private Sub BtnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPreview.Click
        If validaForm() Then
            'New PaperSize("A4", 830, 1170)

            Dim lsAddressLabels As New LabelPrinting.LabelSet(New System.Drawing.Printing.PaperSize(Nombre, ModPOS.Redondear(Me.TxtAnchoPapel.Text * 100 * 0.3937, 0), ModPOS.Redondear(Me.TxtAltoPapel.Text * 100 * 0.3937, 0)), _
                                                             Me.ChkHorizontal.Checked, _
                                                             ModPOS.Redondear(Me.TxtAncho.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtAlto.Text * 100 * 0.3937, 0), _
                                                             CInt(Me.TxtColumnas.Text), _
                                                             ModPOS.Redondear(Me.TxtEspColumnas.Text * 100 * 0.3937, 0), _
                                                             CInt(Me.TxtFilas.Text), _
                                                             ModPOS.Redondear(Me.TxtEspFilas.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMpIzquierdo.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMpDerecho.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMpSuperior.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMpInferior.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMeIzquierdo.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMeDerecho.Text * 100 * 0.3937, 0), _
                                                             ModPOS.Redondear(Me.TxtMeSuperior.Text * 100 * 0.3937, 0), _
                                                            ModPOS.Redondear(Me.TxtMeInferior.Text * 100 * 0.3937, 0))

            lsAddressLabels.LabelFont = New Font(TxtFontName.Text, TxtFontSize.Text)
            lsAddressLabels.LabelCodeFont = New Font("Free 3 of 9 Extended", TxtCodeSize.Text)

            ' Create label objects... 

            Dim lblAddressLabel As New LabelPrinting.LabelCode()

            If cmbTipo.SelectedValue = 1 Then
                lblAddressLabel.AddClave("Clave")
                lblAddressLabel.AddTexto("Nombre Corto")
                lblAddressLabel.AddCodigo("*" & "CODIGO" & "*")
            Else
                lblAddressLabel.AddClave("Ubicación")
                lblAddressLabel.AddTexto("COL.  FIL.")
                lblAddressLabel.AddCodigo("*" & "CODIGO" & "*")
            End If

            Dim numCopias As Integer

            numCopias = (CInt(Me.TxtColumnas.Text) * CInt(Me.TxtFilas.Text))

            ' And add the labels to your label set:
            Dim i As Integer
            For i = 1 To numCopias
                lsAddressLabels.AddLabelCode(lblAddressLabel)
            Next

            ' Create a PrintDialog to allow the user to choose a printer:

            dlgPrintDialog.Document = lsAddressLabels
            dlgPrintDialog.AllowSomePages = True

            ' Offer the user a preview, or print directly to paper:

            If dlgPrintDialog.ShowDialog() = DialogResult.OK Then
                ' Show a print preview... 
                Dim dlgPrintPreview As New PrintPreviewDialog()
                dlgPrintPreview.Document = lsAddressLabels
                ' show the dialog... 
                dlgPrintPreview.ShowDialog()
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
