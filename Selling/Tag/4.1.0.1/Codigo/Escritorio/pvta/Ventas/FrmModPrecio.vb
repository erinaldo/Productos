Public Class FrmModPrecio
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMinimo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents dtVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModPrecio))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblInicio = New System.Windows.Forms.Label
        Me.dtVigencia = New System.Windows.Forms.DateTimePicker
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMinimo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblInicio)
        Me.GroupBox1.Controls.Add(Me.dtVigencia)
        Me.GroupBox1.Controls.Add(Me.BtnBuscaProd)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtMinimo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio)
        Me.GroupBox1.Controls.Add(Me.TxtClave)
        Me.GroupBox1.Controls.Add(Me.TxtNombre)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 138)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(218, 88)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(136, 16)
        Me.lblInicio.TabIndex = 136
        Me.lblInicio.Text = "Inicio de Vigencia"
        Me.lblInicio.Visible = False
        '
        'dtVigencia
        '
        Me.dtVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVigencia.Location = New System.Drawing.Point(221, 105)
        Me.dtVigencia.Name = "dtVigencia"
        Me.dtVigencia.Size = New System.Drawing.Size(118, 20)
        Me.dtVigencia.TabIndex = 5
        Me.dtVigencia.Visible = False
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(191, 16)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(48, 24)
        Me.BtnBuscaProd.TabIndex = 2
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.Visible = False
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(116, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Minimo"
        '
        'txtMinimo
        '
        Me.txtMinimo.Location = New System.Drawing.Point(116, 105)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Size = New System.Drawing.Size(96, 20)
        Me.txtMinimo.TabIndex = 4
        Me.txtMinimo.Text = "0.00"
        Me.txtMinimo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMinimo.Value = 0
        Me.txtMinimo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Precio"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(9, 105)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(96, 20)
        Me.TxtPrecio.TabIndex = 3
        Me.TxtPrecio.Text = "0.00"
        Me.TxtPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPrecio.Value = 0
        Me.TxtPrecio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(60, 19)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(127, 20)
        Me.TxtClave.TabIndex = 1
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(60, 48)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(367, 20)
        Me.TxtNombre.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Nombre"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(7, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Clave"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(412, 150)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(316, 150)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmModPrecio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(507, 193)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(800, 232)
        Me.Name = "FrmModPrecio"
        Me.Text = "Modificar Producto de la Lista de Precios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public PREClave As String
    Public PROClave As String
    Public Inicio As Date
    Public Precio As Double
    Public Minimo As Double
    Public Clave As String
    Public Nombre As String
    Public Padre As String

    Private dt As DataTable
    
    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_busca_producto", "@Clave", sClave.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@Char", cReplace)
        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            dtProducto.Dispose()
        Else
            PROClave = ""
            Clave = ""
            Nombre = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
    End Sub

    Private Sub FrmModPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        If Padre = "Nuevo" Then
            TxtClave.Enabled = True
            TxtClave.ReadOnly = False
            BtnBuscaProd.Visible = True
            lblInicio.Visible = True
            dtVigencia.Visible = True
            dtVigencia.Value = Today.Date
        Else
            TxtClave.Text = Clave
            TxtNombre.Text = Nombre
            TxtPrecio.Text = Precio.ToString
            txtMinimo.Text = Minimo.ToString
        End If


    End Sub

    Private Sub FrmModPrecio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ModPrecio.Dispose()
        ModPOS.ModPrecio = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Precio = TxtPrecio.Text
            Minimo = txtMinimo.Text

            If Padre = "Nuevo" Then

                ModPOS.Ejecuta("sp_agrega_vigencia", _
                   "@PREClave", PREClave, _
                   "@PROClave", PROClave, _
                   "@Inicio", dtVigencia.Value, _
                   "@Precio", Precio, _
                   "@Minimo", Minimo, _
                   "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Precio.addPrecio(PROClave, TxtClave.Text, TxtNombre.Text, Precio, Minimo, dtVigencia.Value, #12/31/9999#)

                PROClave = ""
                TxtClave.Text = ""
                TxtNombre.Text = ""
                TxtPrecio.Text = 0
                txtMinimo.Text = 0
                dtVigencia.Value = Today.Date

            Else
                ModPOS.Ejecuta("sp_modifica_precio", _
                    "@PREClave", PREClave, _
                    "@PROClave", PROClave, _
                    "@Inicio", Inicio, _
                    "@Precio", Precio, _
                    "@Minimo", Minimo, _
                    "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Precio.updPrecio(PROClave, Inicio, Precio, Minimo)

                Me.Close()

            End If
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If CDbl(TxtPrecio.Text) <= 0 Then
            MessageBox.Show("El precio  debe ser menor o igual cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        ElseIf CDbl(txtMinimo.Text) > CDbl(TxtPrecio.Text) Then
            MessageBox.Show("El precio minimo debe ser menor o igual al precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        ElseIf CDbl(txtMinimo.Text) <= 0 Then
            MessageBox.Show("El precio minimo debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        End If


        If Padre = "Nuevo" Then

            If PROClave = "" Then
                MessageBox.Show("No se encontro un producto seleccionado. escriba la clave de producto y presione la tecla Enter o presione el botón de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                i += 1
            End If

            If dtVigencia.Value < Today Then
                MessageBox.Show("El inicio de vigencia del precio actual no puede ser menor al día actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                i += 1
            ElseIf PROClave <> "" Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_vigencia", "@PROClave", PROClave, "@PREClave", PREClave, "@Inicio", dtVigencia.Value)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("La vigencia que intenta agregar ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    i += 1
                Else
                    dt.Dispose()
                End If
            End If



        End If

        If i > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.BusquedaInicial = False
        a.Busqueda = TxtClave.Text.Trim.ToUpper
        a.AlmRequerido = False
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClave.Text = a.valor
            TxtNombre.Text = a.Descripcion
            recuperaProducto(a.valor)
        End If
        a.Dispose()

    End Sub

    Private Sub TxtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtClave.Text) Then
                recuperaProducto(TxtClave.Text.Trim.ToUpper)
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
            a.BusquedaInicial = False
            a.Busqueda = TxtClave.Text.Trim.ToUpper
            a.AlmRequerido = False
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()

        End If

    End Sub

End Class
