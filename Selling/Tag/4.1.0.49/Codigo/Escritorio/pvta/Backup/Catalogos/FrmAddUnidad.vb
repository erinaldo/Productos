Public Class FrmAddUnidad
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
    Friend WithEvents GrpPasillo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumFactor As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblFactor As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents CmbUnidadVenta As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtVolumen As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAncho As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbUso As Selling.StoreCombo
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPeso As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddUnidad))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.cmbUso = New Selling.StoreCombo
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAncho = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVolumen = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.NumFactor = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblFactor = New System.Windows.Forms.Label
        Me.TxtCodigoBarras = New System.Windows.Forms.TextBox
        Me.LblCodigoBarras = New System.Windows.Forms.Label
        Me.CmbUnidadVenta = New Selling.StoreCombo
        Me.LblUnidadVenta = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.txtPeso = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GrpPasillo.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.txtPeso)
        Me.GrpPasillo.Controls.Add(Me.Label6)
        Me.GrpPasillo.Controls.Add(Me.PictureBox4)
        Me.GrpPasillo.Controls.Add(Me.cmbUso)
        Me.GrpPasillo.Controls.Add(Me.Label5)
        Me.GrpPasillo.Controls.Add(Me.txtAncho)
        Me.GrpPasillo.Controls.Add(Me.Label4)
        Me.GrpPasillo.Controls.Add(Me.txtLargo)
        Me.GrpPasillo.Controls.Add(Me.Label3)
        Me.GrpPasillo.Controls.Add(Me.txtAlto)
        Me.GrpPasillo.Controls.Add(Me.Label2)
        Me.GrpPasillo.Controls.Add(Me.txtVolumen)
        Me.GrpPasillo.Controls.Add(Me.Label1)
        Me.GrpPasillo.Controls.Add(Me.PictureBox2)
        Me.GrpPasillo.Controls.Add(Me.PictureBox1)
        Me.GrpPasillo.Controls.Add(Me.PictureBox3)
        Me.GrpPasillo.Controls.Add(Me.NumFactor)
        Me.GrpPasillo.Controls.Add(Me.LblFactor)
        Me.GrpPasillo.Controls.Add(Me.TxtCodigoBarras)
        Me.GrpPasillo.Controls.Add(Me.LblCodigoBarras)
        Me.GrpPasillo.Controls.Add(Me.CmbUnidadVenta)
        Me.GrpPasillo.Controls.Add(Me.LblUnidadVenta)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 7)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(293, 255)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Unidad "
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(249, 228)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 102
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'cmbUso
        '
        Me.cmbUso.Location = New System.Drawing.Point(124, 223)
        Me.cmbUso.Name = "cmbUso"
        Me.cmbUso.Size = New System.Drawing.Size(120, 21)
        Me.cmbUso.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(4, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "T. Uso"
        '
        'txtAncho
        '
        Me.txtAncho.DecimalDigits = 3
        Me.txtAncho.Location = New System.Drawing.Point(124, 198)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Size = New System.Drawing.Size(65, 20)
        Me.txtAncho.TabIndex = 98
        Me.txtAncho.Text = "1.000"
        Me.txtAncho.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtAncho.Value = 1
        Me.txtAncho.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Ancho (cm)"
        '
        'txtLargo
        '
        Me.txtLargo.DecimalDigits = 3
        Me.txtLargo.Location = New System.Drawing.Point(124, 172)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.Size = New System.Drawing.Size(65, 20)
        Me.txtLargo.TabIndex = 96
        Me.txtLargo.Text = "1.000"
        Me.txtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtLargo.Value = 1
        Me.txtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Largo (cm)"
        '
        'txtAlto
        '
        Me.txtAlto.DecimalDigits = 3
        Me.txtAlto.Location = New System.Drawing.Point(124, 146)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(65, 20)
        Me.txtAlto.TabIndex = 94
        Me.txtAlto.Text = "1.000"
        Me.txtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtAlto.Value = 1
        Me.txtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Alto (cm)"
        '
        'txtVolumen
        '
        Me.txtVolumen.DecimalDigits = 3
        Me.txtVolumen.Location = New System.Drawing.Point(124, 120)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(65, 20)
        Me.txtVolumen.TabIndex = 92
        Me.txtVolumen.Text = "1.000"
        Me.txtVolumen.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtVolumen.Value = 1
        Me.txtVolumen.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Volumen (dm3)"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(194, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(250, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(249, 71)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 89
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'NumFactor
        '
        Me.NumFactor.Location = New System.Drawing.Point(124, 42)
        Me.NumFactor.Name = "NumFactor"
        Me.NumFactor.Size = New System.Drawing.Size(65, 20)
        Me.NumFactor.TabIndex = 85
        Me.NumFactor.Text = "1"
        Me.NumFactor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumFactor.Value = 1
        Me.NumFactor.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'LblFactor
        '
        Me.LblFactor.Location = New System.Drawing.Point(6, 44)
        Me.LblFactor.Name = "LblFactor"
        Me.LblFactor.Size = New System.Drawing.Size(39, 14)
        Me.LblFactor.TabIndex = 88
        Me.LblFactor.Text = "Factor"
        '
        'TxtCodigoBarras
        '
        Me.TxtCodigoBarras.Location = New System.Drawing.Point(124, 67)
        Me.TxtCodigoBarras.Name = "TxtCodigoBarras"
        Me.TxtCodigoBarras.Size = New System.Drawing.Size(119, 20)
        Me.TxtCodigoBarras.TabIndex = 83
        '
        'LblCodigoBarras
        '
        Me.LblCodigoBarras.Location = New System.Drawing.Point(6, 70)
        Me.LblCodigoBarras.Name = "LblCodigoBarras"
        Me.LblCodigoBarras.Size = New System.Drawing.Size(80, 16)
        Me.LblCodigoBarras.TabIndex = 87
        Me.LblCodigoBarras.Text = "C. de Barras"
        '
        'CmbUnidadVenta
        '
        Me.CmbUnidadVenta.Location = New System.Drawing.Point(124, 16)
        Me.CmbUnidadVenta.Name = "CmbUnidadVenta"
        Me.CmbUnidadVenta.Size = New System.Drawing.Size(120, 21)
        Me.CmbUnidadVenta.TabIndex = 84
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(6, 22)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(61, 15)
        Me.LblUnidadVenta.TabIndex = 86
        Me.LblUnidadVenta.Text = "T. Unidad"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(113, 268)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(209, 268)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtPeso
        '
        Me.txtPeso.DecimalDigits = 3
        Me.txtPeso.Location = New System.Drawing.Point(124, 93)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(65, 20)
        Me.txtPeso.TabIndex = 103
        Me.txtPeso.Text = "1.000"
        Me.txtPeso.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPeso.Value = 1
        Me.txtPeso.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 14)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Peso (kg/lts)"
        '
        'FrmAddUnidad
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(303, 309)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 325)
        Me.Name = "FrmAddUnidad"
        Me.Text = "Unidad de Productos"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Clave As String = ""
    Public Padre As String


    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private Sub FrmAddUnidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        With Me.CmbUnidadVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_unidad"
            .llenar()
        End With

        With Me.cmbUso
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Uso"
            .llenar()
        End With

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbUnidadVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoBarras.Text = "" AndAlso Clave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtCodigoBarras.Text = "" AndAlso Clave <> "" Then
            TxtCodigoBarras.Text = Clave
        End If

        If CInt(NumFactor.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbUso.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then
            Producto.AddUnidad(Me.TxtCodigoBarras.Text, CInt(NumFactor.Text), Me.CmbUnidadVenta.SelectedValue, Me.CmbUnidadVenta.Text, txtVolumen.Text, txtAlto.Text, txtLargo.Text, txtAncho.Text, cmbUso.SelectedValue, cmbUso.Text, txtPeso.Text)
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCodigoBarras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoBarras.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

End Class
