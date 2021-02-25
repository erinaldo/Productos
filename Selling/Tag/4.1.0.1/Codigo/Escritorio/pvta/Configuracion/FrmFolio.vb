Public Class FrmFolio
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
    Friend WithEvents GrpFolio As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTPersona As System.Windows.Forms.Label
    Friend WithEvents CmbTipoComprobante As Selling.StoreCombo
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Almacen As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents LblAno As System.Windows.Forms.Label
    Friend WithEvents TxtNoAprobacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpIcono As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaAprobacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtAnoAprobacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFolio))
        Me.GrpFolio = New System.Windows.Forms.GroupBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.CmbFechaAprobacion = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.LblAno = New System.Windows.Forms.Label()
        Me.TxtAnoAprobacion = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtNoAprobacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Almacen = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblTPersona = New System.Windows.Forms.Label()
        Me.CmbTipoComprobante = New Selling.StoreCombo()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.LblSerie = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpIcono = New System.Windows.Forms.GroupBox()
        Me.PictIcono = New System.Windows.Forms.PictureBox()
        Me.GrpFolio.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIcono.SuspendLayout()
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpFolio
        '
        Me.GrpFolio.Controls.Add(Me.PictureBox8)
        Me.GrpFolio.Controls.Add(Me.Label5)
        Me.GrpFolio.Controls.Add(Me.CmbCaja)
        Me.GrpFolio.Controls.Add(Me.CmbFechaAprobacion)
        Me.GrpFolio.Controls.Add(Me.PictureBox6)
        Me.GrpFolio.Controls.Add(Me.PictureBox7)
        Me.GrpFolio.Controls.Add(Me.TxtAnoAprobacion)
        Me.GrpFolio.Controls.Add(Me.TxtNoAprobacion)
        Me.GrpFolio.Controls.Add(Me.Label1)
        Me.GrpFolio.Controls.Add(Me.PictureBox5)
        Me.GrpFolio.Controls.Add(Me.Almacen)
        Me.GrpFolio.Controls.Add(Me.CmbSucursal)
        Me.GrpFolio.Controls.Add(Me.PictureBox4)
        Me.GrpFolio.Controls.Add(Me.PictureBox3)
        Me.GrpFolio.Controls.Add(Me.Label3)
        Me.GrpFolio.Controls.Add(Me.TxtFinal)
        Me.GrpFolio.Controls.Add(Me.Label2)
        Me.GrpFolio.Controls.Add(Me.TxtInicial)
        Me.GrpFolio.Controls.Add(Me.PictureBox2)
        Me.GrpFolio.Controls.Add(Me.LblTPersona)
        Me.GrpFolio.Controls.Add(Me.CmbTipoComprobante)
        Me.GrpFolio.Controls.Add(Me.TxtSerie)
        Me.GrpFolio.Controls.Add(Me.LblSerie)
        Me.GrpFolio.Controls.Add(Me.PictureBox1)
        Me.GrpFolio.Controls.Add(Me.Label4)
        Me.GrpFolio.Controls.Add(Me.LblAno)
        Me.GrpFolio.Location = New System.Drawing.Point(7, 7)
        Me.GrpFolio.Name = "GrpFolio"
        Me.GrpFolio.Size = New System.Drawing.Size(361, 231)
        Me.GrpFolio.TabIndex = 1
        Me.GrpFolio.TabStop = False
        Me.GrpFolio.Text = "Folio"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(112, 201)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox8.TabIndex = 123
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(138, 201)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(212, 21)
        Me.CmbCaja.TabIndex = 121
        '
        'CmbFechaAprobacion
        '
        Me.CmbFechaAprobacion.CustomFormat = "yyyyMMdd"
        Me.CmbFechaAprobacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaAprobacion.Location = New System.Drawing.Point(196, 123)
        Me.CmbFechaAprobacion.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaAprobacion.Name = "CmbFechaAprobacion"
        Me.CmbFechaAprobacion.Size = New System.Drawing.Size(98, 20)
        Me.CmbFechaAprobacion.TabIndex = 120
        Me.CmbFechaAprobacion.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(112, 153)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox6.TabIndex = 98
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(112, 179)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox7.TabIndex = 97
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'LblAno
        '
        Me.LblAno.Location = New System.Drawing.Point(8, 127)
        Me.LblAno.Name = "LblAno"
        Me.LblAno.Size = New System.Drawing.Size(130, 15)
        Me.LblAno.TabIndex = 96
        Me.LblAno.Text = "Año / Fecha Aprobación"
        '
        'TxtAnoAprobacion
        '
        Me.TxtAnoAprobacion.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.TxtAnoAprobacion.Location = New System.Drawing.Point(138, 123)
        Me.TxtAnoAprobacion.Name = "TxtAnoAprobacion"
        Me.TxtAnoAprobacion.ReadOnly = True
        Me.TxtAnoAprobacion.Size = New System.Drawing.Size(53, 20)
        Me.TxtAnoAprobacion.TabIndex = 93
        Me.TxtAnoAprobacion.Text = "0"
        Me.TxtAnoAprobacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAnoAprobacion.Value = 0
        Me.TxtAnoAprobacion.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'TxtNoAprobacion
        '
        Me.TxtNoAprobacion.Location = New System.Drawing.Point(138, 150)
        Me.TxtNoAprobacion.Name = "TxtNoAprobacion"
        Me.TxtNoAprobacion.Size = New System.Drawing.Size(212, 20)
        Me.TxtNoAprobacion.TabIndex = 94
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "No. Aprobación"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(112, 126)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox5.TabIndex = 92
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Almacen
        '
        Me.Almacen.Location = New System.Drawing.Point(8, 180)
        Me.Almacen.Name = "Almacen"
        Me.Almacen.Size = New System.Drawing.Size(80, 15)
        Me.Almacen.TabIndex = 91
        Me.Almacen.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(138, 175)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(212, 21)
        Me.CmbSucursal.TabIndex = 90
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(112, 97)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(21, 17)
        Me.PictureBox4.TabIndex = 72
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(111, 70)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 17)
        Me.PictureBox3.TabIndex = 71
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Folio Final"
        '
        'TxtFinal
        '
        Me.TxtFinal.Location = New System.Drawing.Point(138, 97)
        Me.TxtFinal.Name = "TxtFinal"
        Me.TxtFinal.Size = New System.Drawing.Size(120, 20)
        Me.TxtFinal.TabIndex = 3
        Me.TxtFinal.Text = "0"
        Me.TxtFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtFinal.Value = 0
        Me.TxtFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Folio Inicial"
        '
        'TxtInicial
        '
        Me.TxtInicial.Location = New System.Drawing.Point(138, 70)
        Me.TxtInicial.Name = "TxtInicial"
        Me.TxtInicial.Size = New System.Drawing.Size(120, 20)
        Me.TxtInicial.TabIndex = 2
        Me.TxtInicial.Text = "0"
        Me.TxtInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtInicial.Value = 0
        Me.TxtInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(111, 43)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 16)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'LblTPersona
        '
        Me.LblTPersona.Location = New System.Drawing.Point(8, 18)
        Me.LblTPersona.Name = "LblTPersona"
        Me.LblTPersona.Size = New System.Drawing.Size(130, 14)
        Me.LblTPersona.TabIndex = 33
        Me.LblTPersona.Text = "Tipo de Comprobante"
        '
        'CmbTipoComprobante
        '
        Me.CmbTipoComprobante.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoComprobante.Location = New System.Drawing.Point(138, 13)
        Me.CmbTipoComprobante.Name = "CmbTipoComprobante"
        Me.CmbTipoComprobante.Size = New System.Drawing.Size(175, 21)
        Me.CmbTipoComprobante.TabIndex = 0
        '
        'TxtSerie
        '
        Me.TxtSerie.Location = New System.Drawing.Point(138, 42)
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(120, 20)
        Me.TxtSerie.TabIndex = 1
        '
        'LblSerie
        '
        Me.LblSerie.Location = New System.Drawing.Point(8, 45)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(80, 15)
        Me.LblSerie.TabIndex = 24
        Me.LblSerie.Text = "Serie"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(112, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 17)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(267, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 14)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(422, 245)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(518, 245)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpIcono
        '
        Me.GrpIcono.Controls.Add(Me.PictIcono)
        Me.GrpIcono.Location = New System.Drawing.Point(374, 7)
        Me.GrpIcono.Name = "GrpIcono"
        Me.GrpIcono.Size = New System.Drawing.Size(234, 231)
        Me.GrpIcono.TabIndex = 23
        Me.GrpIcono.TabStop = False
        Me.GrpIcono.Text = "Código de Barras Bidimensional"
        '
        'PictIcono
        '
        Me.PictIcono.BackColor = System.Drawing.Color.White
        Me.PictIcono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono.Location = New System.Drawing.Point(5, 13)
        Me.PictIcono.Name = "PictIcono"
        Me.PictIcono.Size = New System.Drawing.Size(224, 212)
        Me.PictIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictIcono.TabIndex = 0
        Me.PictIcono.TabStop = False
        '
        'FrmFolio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(617, 286)
        Me.Controls.Add(Me.GrpIcono)
        Me.Controls.Add(Me.GrpFolio)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFolio"
        Me.Text = "Folio"
        Me.GrpFolio.ResumeLayout(False)
        Me.GrpFolio.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIcono.ResumeLayout(False)
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public FOLClave As String
    Public Tipo As Integer
    Public Serie As String
    Public Actual As Double
    Public Inicial As Double
    Public Final As Double
    Public SUCClave As String = ""
    Public CAJClave As String = ""
    Public AnoAprobacion As Integer
    Public fechaAprobacion As Date

    Public NoAprobacion As String


    Public Icono As Byte()
    Public NuevoIcono As Boolean = False

    Private alerta(7) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipoComprobante.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbCaja.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        'If Me.TxtSerie.Text = "" Then
        '    i += 1
        '    reloj = New parpadea(Me.alerta(1))
        '    reloj.Enabled = True
        '    reloj.Start()
        'ElseIf Me.TxtSerie.Text.Length > 10 Then
        '    Me.TxtSerie.Text = Me.TxtSerie.Text.Substring(0, 10)
        'End If

        If CInt(TxtInicial.Text) < 1 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtInicial.Text) > CInt(TxtFinal.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Padre = "Modificar" AndAlso Actual > 0 AndAlso Actual <= CInt(TxtFinal.Text) AndAlso Final > CInt(TxtFinal.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(TxtAnoAprobacion.Text) < 2004 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(CmbFechaAprobacion.Value.Year) < 2004 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtNoAprobacion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_folioCFD", "@Serie", Me.TxtSerie.Text.ToUpper.Trim, "@NoAprobacion", TxtNoAprobacion.Text, "AnoAprobacion", TxtAnoAprobacion.Text) > 0 Then
                Beep()
                MessageBox.Show("La Serie que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
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

    Private Sub FrmFolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8

        With Me.CmbTipoComprobante
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Folio"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_all_sucursal"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        TxtSerie.Text = Serie
        TxtInicial.Text = Inicial
        TxtFinal.Text = Final
        TxtAnoAprobacion.Text = AnoAprobacion
        TxtNoAprobacion.Text = NoAprobacion
        CmbSucursal.SelectedValue = SUCClave
        CmbCaja.SelectedValue = CAJClave
        CmbTipoComprobante.SelectedValue = Tipo
        CmbFechaAprobacion.Value = fechaAprobacion

        If Padre = "Modificar" Then
            If Actual > 0 Then
                Me.CmbTipoComprobante.Enabled = False
                TxtSerie.Enabled = False
                TxtInicial.Enabled = False
                TxtFinal.Enabled = False
                TxtAnoAprobacion.Enabled = False
                TxtNoAprobacion.Enabled = False
            End If
        End If

        cargado = True
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    Tipo = CmbTipoComprobante.SelectedValue
                    Serie = TxtSerie.Text
                    Inicial = TxtInicial.Text
                    Final = TxtFinal.Text
                    AnoAprobacion = TxtAnoAprobacion.Text
                    NoAprobacion = TxtNoAprobacion.Text
                    SUCClave = CmbSucursal.SelectedValue
                    CAJClave = CmbCaja.SelectedValue
                    fechaAprobacion = CmbFechaAprobacion.Value.AddHours(23.9999)

                    ModPOS.Ejecuta("sp_inserta_foliocfd", _
                                    "@Tipo", Tipo, _
                                    "@Serie", Serie, _
                                    "@Inicial", Inicial, _
                                    "@Final", Final, _
                                    "@AnoAprobacion", AnoAprobacion, _
                                    "@NoAprobacion", NoAprobacion, _
                                    "@SUCClave", SUCClave, _
                                    "@CAJClave", CAJClave, _
                                    "@fechaAprobacion", fechaAprobacion, _
                                    "@CBB", Icono, _
                                    "@Usuario", ModPOS.UsuarioActual)

                    If Not ModPOS.MtoFolios Is Nothing Then
                        ModPOS.ActualizaGrid(False, ModPOS.MtoFolios.GridFolios, "sp_muestra_folios", "@COMClave", ModPOS.CompanyActual)
                        MtoFolios.GridFolios.RootTable.Columns("FOLClave").Visible = False
                    End If

                    TxtSerie.Text = ""
                    TxtInicial.Text = "1"
                    TxtFinal.Text = "0"
                    TxtAnoAprobacion.Text = Today.Year
                    TxtNoAprobacion.Text = ""
                    CmbSucursal.SelectedValue = ""
                    CmbFechaAprobacion.Value = Today()

                Case "Modificar"
                    If Not (CmbTipoComprobante.SelectedValue = Tipo AndAlso _
                        Serie = TxtSerie.Text AndAlso _
                        Inicial = TxtInicial.Text AndAlso _
                        AnoAprobacion = TxtAnoAprobacion.Text AndAlso _
                        NoAprobacion = TxtNoAprobacion.Text AndAlso _
                        fechaAprobacion = CmbFechaAprobacion.Value.AddHours(23.9999) AndAlso _
                        SUCClave = CmbSucursal.SelectedValue AndAlso _
                        CAJClave = CmbCaja.SelectedValue AndAlso _
                          Not NuevoIcono AndAlso _
                        Final = TxtFinal.Text) Then


                        Tipo = CmbTipoComprobante.SelectedValue
                        Serie = TxtSerie.Text
                        Inicial = TxtInicial.Text
                        Final = TxtFinal.Text
                        AnoAprobacion = TxtAnoAprobacion.Text
                        NoAprobacion = TxtNoAprobacion.Text
                        SUCClave = CmbSucursal.SelectedValue
                        CAJClave = CmbCaja.SelectedValue
                        fechaAprobacion = CmbFechaAprobacion.Value.AddHours(23.9999)

                        ModPOS.Ejecuta("sp_actualiza_foliocfd", _
                                        "@FOLClave", FOLClave, _
                                        "@Tipo", Tipo, _
                                        "@Serie", Serie, _
                                        "@Inicial", Inicial, _
                                        "@Final", Final, _
                                        "@AnoAprobacion", AnoAprobacion, _
                                        "@NoAprobacion", NoAprobacion, _
                                        "@SUCClave", SUCClave, _
                                        "@CAJClave", CAJClave, _
                                        "@fechaAprobacion", fechaAprobacion, _
                                        "@CBB", Icono, _
                                        "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoFolios Is Nothing Then
                            ModPOS.ActualizaGrid(False, ModPOS.MtoFolios.GridFolios, "sp_muestra_folios", "@COMClave", ModPOS.CompanyActual)
                            MtoFolios.GridFolios.RootTable.Columns("FOLClave").Visible = False
                        End If
                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmFolio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Folio.Dispose()
        ModPOS.Folio = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub PictIcono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIcono.DoubleClick
        Dim curFileName As String = ""

        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de JPG|*.JPG"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo JPG"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName



                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim Icono(lung)
                fsIcono.Read(Icono, 0, lung)
                fsIcono.Close()

                Me.PictIcono.Image = Image.FromFile(curFileName)

                NuevoIcono = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub CmbFechaAprobacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbFechaAprobacion.ValueChanged
        If cargado = True Then
            TxtAnoAprobacion.Text = CmbFechaAprobacion.Value.Year
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso cargado Then
            With CmbCaja
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub
End Class
