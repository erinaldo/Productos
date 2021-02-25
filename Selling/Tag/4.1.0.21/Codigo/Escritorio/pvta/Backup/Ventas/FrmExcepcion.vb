Public Class FrmExcepcion
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
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrecio As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMinimo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblInicio As System.Windows.Forms.Label
    Friend WithEvents dtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents btnCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExcepcion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblProducto = New System.Windows.Forms.Label
        Me.btnCte = New Janus.Windows.EditControls.UIButton
        Me.LblCliente = New System.Windows.Forms.Label
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbTipo = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.lblInicio = New System.Windows.Forms.Label
        Me.dtInicio = New System.Windows.Forms.DateTimePicker
        Me.BtnProd = New Janus.Windows.EditControls.UIButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMinimo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPrecio = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblProducto)
        Me.GroupBox1.Controls.Add(Me.btnCte)
        Me.GroupBox1.Controls.Add(Me.LblCliente)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbTipo)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.lblInicio)
        Me.GroupBox1.Controls.Add(Me.dtInicio)
        Me.GroupBox1.Controls.Add(Me.BtnProd)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtMinimo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPrecio)
        Me.GroupBox1.Controls.Add(Me.TxtClave)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.MaximumSize = New System.Drawing.Size(800, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "Desc. Corta"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 145
        Me.Label3.Text = "Razon Social"
        '
        'lblProducto
        '
        Me.lblProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProducto.Location = New System.Drawing.Point(116, 126)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(400, 19)
        Me.lblProducto.TabIndex = 144
        '
        'btnCte
        '
        Me.btnCte.Image = CType(resources.GetObject("btnCte.Image"), System.Drawing.Image)
        Me.btnCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCte.Location = New System.Drawing.Point(241, 45)
        Me.btnCte.Name = "btnCte"
        Me.btnCte.Size = New System.Drawing.Size(48, 24)
        Me.btnCte.TabIndex = 3
        Me.btnCte.ToolTipText = "Busqueda de Producto"
        Me.btnCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.Location = New System.Drawing.Point(116, 72)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(403, 19)
        Me.LblCliente.TabIndex = 142
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(115, 47)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(120, 20)
        Me.TxtCliente.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Cliente"
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Cliente", "Producto"})
        Me.cmbTipo.Location = New System.Drawing.Point(116, 19)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(119, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(9, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(129, 21)
        Me.Label32.TabIndex = 138
        Me.Label32.Text = "Tipo Excepción"
        '
        'lblInicio
        '
        Me.lblInicio.Location = New System.Drawing.Point(218, 165)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(136, 16)
        Me.lblInicio.TabIndex = 136
        Me.lblInicio.Text = "Inicio de Vigencia"
        '
        'dtInicio
        '
        Me.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInicio.Location = New System.Drawing.Point(221, 182)
        Me.dtInicio.Name = "dtInicio"
        Me.dtInicio.Size = New System.Drawing.Size(118, 20)
        Me.dtInicio.TabIndex = 8
        '
        'BtnProd
        '
        Me.BtnProd.Image = CType(resources.GetObject("BtnProd.Image"), System.Drawing.Image)
        Me.BtnProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnProd.Location = New System.Drawing.Point(241, 93)
        Me.BtnProd.Name = "BtnProd"
        Me.BtnProd.Size = New System.Drawing.Size(48, 24)
        Me.BtnProd.TabIndex = 5
        Me.BtnProd.ToolTipText = "Busqueda de Producto"
        Me.BtnProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(116, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Minimo"
        '
        'txtMinimo
        '
        Me.txtMinimo.Location = New System.Drawing.Point(116, 182)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Size = New System.Drawing.Size(96, 20)
        Me.txtMinimo.TabIndex = 7
        Me.txtMinimo.Text = "0.00"
        Me.txtMinimo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMinimo.Value = 0
        Me.txtMinimo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Precio"
        '
        'TxtPrecio
        '
        Me.TxtPrecio.Location = New System.Drawing.Point(9, 182)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(96, 20)
        Me.TxtPrecio.TabIndex = 6
        Me.TxtPrecio.Text = "0.00"
        Me.TxtPrecio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPrecio.Value = 0
        Me.TxtPrecio.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(116, 96)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(119, 20)
        Me.TxtClave.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Producto"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(346, 228)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(442, 228)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmExcepcion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(535, 271)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(488, 209)
        Me.Name = "FrmExcepcion"
        Me.Text = "Excepción de precio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Canal As Integer
    Public Grupo As Integer
    Public PROClave As String
    Public Inicio As Date
    Public Precio As Double
    Public Minimo As Double
    Public Padre As String
    Public EXPClave As String
    Public Cliente As String
    Public Producto As String

    Private Clave As String
    Private Nombre As String

    Private dt As DataTable
    Private CTEClave As String

    Private Sub recuperaCliente(ByVal sClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", sClave)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            Clave = dt.Rows(0)("Clave")
            Nombre = dt.Rows(0)("RazonSocial")
            dt.Dispose()
        Else
            CTEClave = ""
            Clave = ""
            Nombre = ""
            MessageBox.Show("¡La Clave de cliente no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        TxtCliente.Text = Clave
        LblCliente.Text = Nombre
    End Sub

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_busca_producto", "@Clave", sClave.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
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
        lblProducto.Text = Nombre
    End Sub

    Private Sub FrmExcepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        cmbTipo.SelectedItem = "Cliente"
        dtInicio.Value = Today.Date
        CTEClave = ""
        TxtCliente.Text = ""
        LblCliente.Text = ""
        PROClave = ""
        TxtClave.Text = ""
        lblProducto.Text = ""
        TxtPrecio.Text = 0
        txtMinimo.Text = 0
        If Padre = "Modificar" Then
            If Cliente <> "" Then
                cmbTipo.SelectedItem = "Cliente"
                recuperaCliente(Cliente)
            Else
                cmbTipo.SelectedItem = "Producto"
            End If
            recuperaProducto(Producto)
            TxtPrecio.Text = Precio
            txtMinimo.Text = Minimo
        End If



    End Sub

    Private Sub FrmExcepcion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Excepcion.Dispose()
        ModPOS.Excepcion = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Precio = TxtPrecio.Text
            Minimo = txtMinimo.Text
            If Padre <> "Modificar" Then

                Dim EXPClave As String = ModPOS.obtenerLlave

                ModPOS.Ejecuta("sp_agrega_vigencia_excepcion", _
                   "@EXPClave", EXPClave, _
                   "@COMClave", ModPOS.CompanyActual, _
                   "@Canal", Canal, _
                   "@Grupo", Grupo, _
                   "@CTEClave", CTEClave, _
                   "@PROClave", PROClave, _
                   "@Inicio", dtInicio.Value, _
                   "@Precio", Precio, _
                   "@Minimo", Minimo, _
                   "@Usuario", ModPOS.UsuarioActual)

                ModPOS.MtoExcepcion.addExcepcion(EXPClave, TxtCliente.Text, TxtClave.Text, lblProducto.Text, Precio, Minimo, dtInicio.Value, #12/31/9999#)

                cmbTipo.SelectedItem = "Cliente"
                dtInicio.Value = Today.Date
                CTEClave = ""
                TxtCliente.Text = ""
                LblCliente.Text = ""
                PROClave = ""
                TxtClave.Text = ""
                lblProducto.Text = ""
                TxtPrecio.Text = 0
                txtMinimo.Text = 0
            Else


                ModPOS.Ejecuta("sp_modifica_vigencia_excepcion", _
                   "@EXPClave", EXPClave, _
                   "@CTEClave", CTEClave, _
                   "@Precio", Precio, _
                   "@Minimo", Minimo, _
                   "@Usuario", ModPOS.UsuarioActual)

                ModPOS.MtoExcepcion.updExcepcion(EXPClave, Precio, Minimo)

                Me.Close()

            End If


        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If CDbl(TxtPrecio.Text) <= 0 Then
            MessageBox.Show("El precio  debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        ElseIf CDbl(txtMinimo.Text) > CDbl(TxtPrecio.Text) Then
            MessageBox.Show("El precio minimo debe ser menor o igual al precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        ElseIf CDbl(txtMinimo.Text) < 0 Then
            MessageBox.Show("El precio minimo debe ser mayor o igual a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            i += 1
        End If

        If Padre <> "Modificar" Then
            If Me.cmbTipo.SelectedItem Is Nothing Then
                i += 1
                MessageBox.Show("El Tipo de Excepción de precio es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf cmbTipo.SelectedItem = "Cliente" AndAlso CTEClave = "" Then
                i += 1
                MessageBox.Show("El Cliente es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If


            If PROClave = "" Then
                MessageBox.Show("No se encontro un producto seleccionado. escriba la clave de producto y presione la tecla Enter o presione el botón de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                i += 1
            End If

            If dtInicio.Value < Today Then
                MessageBox.Show("El inicio de vigencia del precio actual no puede ser menor al día actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                i += 1

            ElseIf PROClave <> "" Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_vigencia_excepcion", "@COMClave", ModPOS.CompanyActual, "@Canal", Canal, "@Grupo", Grupo, "@CTEClave", CTEClave, "@PROClave", PROClave, "@Inicio", dtInicio.Value)

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

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
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
            lblProducto.Text = a.Descripcion
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

    Private Sub btnCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                TxtCliente.Text = a.Descripcion
                LblCliente.Text = a.Descripcion2
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If Padre <> "Modificar" Then
            If cmbTipo.SelectedItem <> "Cliente" Then
                btnCte.Enabled = False
                TxtCliente.Enabled = False
            Else
                btnCte.Enabled = True
                TxtCliente.Enabled = True
            End If
        End If
    End Sub

    Private Sub TxtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtCliente.Text) Then
                recuperaCliente(TxtCliente.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de cliente es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_cliente"
            a.TablaCmb = "Cliente"
            a.CampoCmb = "Filtro"
            a.OcultaID = True
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If Not a.valor Is Nothing Then
                    CTEClave = a.valor
                    TxtCliente.Text = a.Descripcion
                    LblCliente.Text = a.Descripcion2
                End If
            End If
            a.Dispose()

        End If

    End Sub
End Class
