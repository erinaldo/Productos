Public Class FrmAddEstrategia
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
    Friend WithEvents GrpEstrategia As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbArea As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtCapacidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents BtnUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents BtnProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents chkAplicarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddEstrategia))
        Me.GrpEstrategia = New System.Windows.Forms.GroupBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnProducto = New Janus.Windows.EditControls.UIButton()
        Me.TxtCapacidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.BtnUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtClaveProd = New System.Windows.Forms.TextBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.cmbArea = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.chkAplicarTodos = New System.Windows.Forms.CheckBox()
        Me.GrpEstrategia.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpEstrategia
        '
        Me.GrpEstrategia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstrategia.Controls.Add(Me.chkAplicarTodos)
        Me.GrpEstrategia.Controls.Add(Me.lblUbicacion)
        Me.GrpEstrategia.Controls.Add(Me.PictureBox4)
        Me.GrpEstrategia.Controls.Add(Me.PictureBox3)
        Me.GrpEstrategia.Controls.Add(Me.PictureBox2)
        Me.GrpEstrategia.Controls.Add(Me.BtnProducto)
        Me.GrpEstrategia.Controls.Add(Me.TxtCapacidad)
        Me.GrpEstrategia.Controls.Add(Me.TxtUbicacion)
        Me.GrpEstrategia.Controls.Add(Me.BtnUbicacion)
        Me.GrpEstrategia.Controls.Add(Me.Label28)
        Me.GrpEstrategia.Controls.Add(Me.Label29)
        Me.GrpEstrategia.Controls.Add(Me.Label25)
        Me.GrpEstrategia.Controls.Add(Me.TxtClaveProd)
        Me.GrpEstrategia.Controls.Add(Me.TxtDescripcion)
        Me.GrpEstrategia.Controls.Add(Me.cmbArea)
        Me.GrpEstrategia.Controls.Add(Me.PictureBox1)
        Me.GrpEstrategia.Controls.Add(Me.Label26)
        Me.GrpEstrategia.Location = New System.Drawing.Point(5, 4)
        Me.GrpEstrategia.Name = "GrpEstrategia"
        Me.GrpEstrategia.Size = New System.Drawing.Size(618, 187)
        Me.GrpEstrategia.TabIndex = 0
        Me.GrpEstrategia.TabStop = False
        Me.GrpEstrategia.Text = "Estrategia"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.AutoSize = True
        Me.lblUbicacion.Location = New System.Drawing.Point(330, 124)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(0, 13)
        Me.lblUbicacion.TabIndex = 169
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(92, 155)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 168
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(92, 124)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 167
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(92, 60)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 166
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnProducto
        '
        Me.BtnProducto.Image = CType(resources.GetObject("BtnProducto.Image"), System.Drawing.Image)
        Me.BtnProducto.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnProducto.Location = New System.Drawing.Point(293, 53)
        Me.BtnProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnProducto.Name = "BtnProducto"
        Me.BtnProducto.Size = New System.Drawing.Size(31, 25)
        Me.BtnProducto.TabIndex = 165
        Me.BtnProducto.ToolTipText = "Busqueda de Ubicación"
        Me.BtnProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCapacidad
        '
        Me.TxtCapacidad.Location = New System.Drawing.Point(114, 151)
        Me.TxtCapacidad.Name = "TxtCapacidad"
        Me.TxtCapacidad.Size = New System.Drawing.Size(103, 20)
        Me.TxtCapacidad.TabIndex = 163
        Me.TxtCapacidad.Text = "0.00"
        Me.TxtCapacidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCapacidad.Value = 0.0R
        Me.TxtCapacidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(114, 119)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(173, 21)
        Me.TxtUbicacion.TabIndex = 159
        '
        'BtnUbicacion
        '
        Me.BtnUbicacion.Image = CType(resources.GetObject("BtnUbicacion.Image"), System.Drawing.Image)
        Me.BtnUbicacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnUbicacion.Location = New System.Drawing.Point(293, 117)
        Me.BtnUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnUbicacion.Name = "BtnUbicacion"
        Me.BtnUbicacion.Size = New System.Drawing.Size(31, 25)
        Me.BtnUbicacion.TabIndex = 160
        Me.BtnUbicacion.ToolTipText = "Busqueda de Ubicación"
        Me.BtnUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Location = New System.Drawing.Point(7, 124)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(82, 16)
        Me.Label28.TabIndex = 161
        Me.Label28.Text = "Ubicación"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Location = New System.Drawing.Point(6, 154)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 16)
        Me.Label29.TabIndex = 164
        Me.Label29.Text = "Capacidad (Und)"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(5, 60)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 16)
        Me.Label25.TabIndex = 158
        Me.Label25.Text = "Producto"
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(114, 55)
        Me.TxtClaveProd.Multiline = True
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(173, 21)
        Me.TxtClaveProd.TabIndex = 157
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(114, 87)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(498, 21)
        Me.TxtDescripcion.TabIndex = 156
        '
        'cmbArea
        '
        Me.cmbArea.Location = New System.Drawing.Point(114, 23)
        Me.cmbArea.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(146, 21)
        Me.cmbArea.TabIndex = 150
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(92, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 149
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Location = New System.Drawing.Point(5, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(60, 16)
        Me.Label26.TabIndex = 151
        Me.Label26.Text = "Area"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(439, 200)
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
        Me.BtnAgregar.Location = New System.Drawing.Point(535, 200)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chkAplicarTodos
        '
        Me.chkAplicarTodos.Location = New System.Drawing.Point(414, 151)
        Me.chkAplicarTodos.Name = "chkAplicarTodos"
        Me.chkAplicarTodos.Size = New System.Drawing.Size(182, 19)
        Me.chkAplicarTodos.TabIndex = 170
        Me.chkAplicarTodos.Text = "Aplicar a Todos los Productos"
        '
        'FrmAddEstrategia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(629, 241)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpEstrategia)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddEstrategia"
        Me.Text = "Estrategia de Almacenaje"
        Me.GrpEstrategia.ResumeLayout(False)
        Me.GrpEstrategia.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public TallaColor As Integer = 0
    Public ALMClave As String
    Public Form As String = "Almacen"

    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private sUBCClave As String
    Private sPROClave As String
    Private sClave As String
    Private sNombre As String
    Private NumDecimales As Integer

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbArea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If sPROClave = "" OrElse TxtClaveProd.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If sUBCClave = "" OrElse TxtUbicacion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(TxtCapacidad.Text) = 0 Then
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

    Public Sub recuperaProducto(ByVal ClaveProducto As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", ClaveProducto.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
            sPROClave = dtProducto.Rows(0)("PROClave")
            sClave = dtProducto.Rows(0)("Clave")
            sNombre = dtProducto.Rows(0)("Nombre")
            NumDecimales = dtProducto.Rows(0)("Num_Decimales")
            dtProducto.Dispose()
            TxtUbicacion.Focus()
        Else
            sPROClave = ""
            sClave = ""
            sNombre = ""
            NumDecimales = 0
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        TxtClaveProd.Text = sClave
        Me.TxtDescripcion.Text = sNombre
        TxtCapacidad.DecimalDigits = NumDecimales
    End Sub

    Private Sub leeUbicacion(ByVal Codigo As String, ByVal UBC As String)

        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            If UBC = "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion_are", "@AREClave", cmbArea.SelectedValue, "@Ubicacion", Codigo)

                If dt.Rows.Count > 0 Then
                    sUBCClave = dt.Rows(0)("UBCClave")
                    TxtUbicacion.Text = Codigo
                Else
                    sUBCClave = ""
                    TxtUbicacion.Text = ""
                    Beep()
                    MessageBox.Show("La ubicación no se encuentra en el area seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                sUBCClave = UBC
                TxtUbicacion.Text = Codigo
                lblUbicacion.Text = Codigo
            End If

        Else
            sUBCClave = ""
            TxtUbicacion.Text = ""
            lblUbicacion.Text = ""

            Beep()
            MessageBox.Show("La ubicación no se encuentra en el area seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub reinicializa()
        sUBCClave = ""
        sPROClave = ""
        sClave = ""
        sNombre = ""
        NumDecimales = 0
        TxtClaveProd.Text = ""
        TxtDescripcion.Text = ""
        TxtCapacidad.DecimalDigits = NumDecimales
        lblUbicacion.Text = ""
        TxtUbicacion.Text = ""
    End Sub

    Private Sub FrmAddEstrategia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        With Me.cmbArea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_areas"
            .NombreParametro1 = "ALMClave"
            .Parametro1 = ALMClave
            .llenar()
        End With


    End Sub

    Private Sub FrmAddEstrategia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddEstrategia.Dispose()
        ModPOS.AddEstrategia = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then
            If Form = "Almacen" Then
                If Not ModPOS.CrearAlm Is Nothing Then
                    ModPOS.CrearAlm.setEstrategia(sPROClave, CStr(cmbArea.SelectedValue), sUBCClave, cmbArea.SelectedItem(1), TxtUbicacion.Text, sClave, CDbl(TxtCapacidad.Text))

                    If chkAplicarTodos.Checked = True Then
                        ModPOS.Ejecuta("st_agrega_estrategia_faltantes", "@PROClave", sPROClave, "@ALMClave", ALMClave, "@AREClave", CStr(cmbArea.SelectedValue), "@UBCClave", sUBCClave, "@Capacidad", CDbl(TxtCapacidad.Text), "@Usuario", ModPOS.UsuarioActual)
                        Me.Close()
                    End If
                    reinicializa()


                End If
            Else
                If Not ModPOS.Confirmacion Is Nothing Then

                    ModPOS.Confirmacion.actEstrategia(sPROClave, sUBCClave, TxtUbicacion.Text, cmbArea.SelectedItem(1))
                    ModPOS.Ejecuta("sp_modifica_estrategia", "@Id", ModPOS.obtenerLlave(), "@PROClave", sPROClave, "@ALMClave", ALMClave, "@AREClave", CStr(cmbArea.SelectedValue), "@UBCClave", sUBCClave, "@Capacidad", CDbl(TxtCapacidad.Text), "@Usuario", ModPOS.UsuarioActual)
                    If chkAplicarTodos.Checked = True Then
                        ModPOS.Ejecuta("st_agrega_estrategia_faltantes", "@PROClave", sPROClave, "@ALMClave", ALMClave, "@AREClave", CStr(cmbArea.SelectedValue), "@UBCClave", sUBCClave, "@Capacidad", CDbl(TxtCapacidad.Text), "@Usuario", ModPOS.UsuarioActual)
                    End If
                    Me.Close()
                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_producto_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_producto"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.BusquedaInicial = True
        a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
        a.AlmRequerido = True
        a.ALMClave = ALMClave
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClaveProd.Text = a.valor
            TxtDescripcion.Text = a.Descripcion
            recuperaProducto(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClaveProd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtClaveProd.Text) Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            Else
                MessageBox.Show("La clave de producto y Tipo de documento son Requeridos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            If TallaColor = 1 Then
                a.ProcedimientoAlmacenado = "st_search_producto_tc"
                a.CampoCmb = "FiltroTC"
            Else
                a.ProcedimientoAlmacenado = "sp_search_producto"
                a.CampoCmb = "Filtro"
            End If
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.NumColDes = 2
            a.BusquedaInicial = True
            a.Busqueda = TxtClaveProd.Text.Trim.ToUpper
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.CompaniaRequerido = True
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()

        End If
    End Sub

    Private Sub BtnUbicacion_Click(sender As Object, e As EventArgs) Handles BtnUbicacion.Click
        If Not cmbArea.SelectedValue Is Nothing Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_ubicacion_are"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = ALMClave
            a.OcultaCol = True
            a.OcultaColNum = 0
            a.AREClave = cmbArea.SelectedValue
            a.NumColDes = 1
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                leeUbicacion(a.Descripcion, a.valor)
                TxtCapacidad.Focus()
            End If
            a.Dispose()
        Else
            MessageBox.Show("El Area es Requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TxtUbicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not System.String.IsNullOrEmpty(TxtUbicacion.Text) AndAlso Not cmbArea.SelectedValue Is Nothing Then
                leeUbicacion(TxtUbicacion.Text.Trim.ToUpper, "")
                TxtCapacidad.Focus()
            Else
                MessageBox.Show("La clave de ubicación y area son Requeridos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If Not cmbArea.SelectedValue Is Nothing Then
                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_ubicacion_are"
                a.TablaCmb = "Reubicacion"
                a.CampoCmb = "Filtro"
                a.AlmRequerido = True
                a.ALMClave = ALMClave
                a.OcultaCol = True
                a.OcultaColNum = 0
                a.AREClave = cmbArea.SelectedValue
                a.NumColDes = 1
                a.BusquedaInicial = True
                a.Busqueda = TxtUbicacion.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    leeUbicacion(a.Descripcion, a.valor)
                    TxtCapacidad.Focus()
                End If
                a.Dispose()
            Else
                MessageBox.Show("El Area es Requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub TxtCapacidad_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCapacidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAgregar.PerformClick()
        End If
    End Sub
End Class
