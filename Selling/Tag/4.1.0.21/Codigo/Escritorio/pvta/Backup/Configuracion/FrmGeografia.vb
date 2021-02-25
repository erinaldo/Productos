Public Class FrmGeografia
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpActividad As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents LblPostal As System.Windows.Forms.Label
    Friend WithEvents cmbTipoAsentamiento As Selling.StoreCombo
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPostal As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGeografia))
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpActividad = New System.Windows.Forms.GroupBox
        Me.TxtCodigoPostal = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.LblTipo = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.cmbTipoAsentamiento = New Selling.StoreCombo
        Me.LblPostal = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GrpActividad.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(312, 117)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(216, 117)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpActividad
        '
        Me.GrpActividad.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpActividad.Controls.Add(Me.LblTipo)
        Me.GrpActividad.Controls.Add(Me.PictureBox3)
        Me.GrpActividad.Controls.Add(Me.cmbTipoAsentamiento)
        Me.GrpActividad.Controls.Add(Me.LblPostal)
        Me.GrpActividad.Controls.Add(Me.PictureBox2)
        Me.GrpActividad.Controls.Add(Me.ChkEstado)
        Me.GrpActividad.Controls.Add(Me.TxtNombre)
        Me.GrpActividad.Controls.Add(Me.LblNombre)
        Me.GrpActividad.Controls.Add(Me.PictureBox1)
        Me.GrpActividad.Location = New System.Drawing.Point(6, 5)
        Me.GrpActividad.Name = "GrpActividad"
        Me.GrpActividad.Size = New System.Drawing.Size(396, 107)
        Me.GrpActividad.TabIndex = 1
        Me.GrpActividad.TabStop = False
        Me.GrpActividad.Text = "Localidad"
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(73, 74)
        Me.TxtCodigoPostal.Mask = "00000####"
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodigoPostal.TabIndex = 2
        Me.TxtCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtCodigoPostal.Visible = False
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(208, 59)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(159, 15)
        Me.LblTipo.TabIndex = 59
        Me.LblTipo.Text = "Tipo de Asentamiento"
        Me.LblTipo.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(373, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 58
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbTipoAsentamiento
        '
        Me.cmbTipoAsentamiento.Location = New System.Drawing.Point(208, 74)
        Me.cmbTipoAsentamiento.Name = "cmbTipoAsentamiento"
        Me.cmbTipoAsentamiento.Size = New System.Drawing.Size(159, 21)
        Me.cmbTipoAsentamiento.TabIndex = 3
        Me.cmbTipoAsentamiento.Visible = False
        '
        'LblPostal
        '
        Me.LblPostal.Location = New System.Drawing.Point(73, 59)
        Me.LblPostal.Name = "LblPostal"
        Me.LblPostal.Size = New System.Drawing.Size(101, 15)
        Me.LblPostal.TabIndex = 55
        Me.LblPostal.Text = "Código Postal"
        Me.LblPostal.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(180, 74)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 56
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(320, 10)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(67, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(73, 34)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(294, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 34)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(60, 23)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(367, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'FrmGeografia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(408, 159)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpActividad)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGeografia"
        Me.Text = "Geografía"
        Me.GrpActividad.ResumeLayout(False)
        Me.GrpActividad.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public sTipo As String
    Public sClave As String
    Public sNombre As String
    Public iEstado As Integer

    Public c_estado As String
    Public c_mnpio As String
    Public c_asentamiento As Integer
    Public sCodigoPostal As String

    Public iPais As Integer

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)
        End If

        If sTipo = "Colonia" Then


            If Me.TxtCodigoPostal.Text = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(1))
                reloj.Enabled = True
                reloj.Start()
            ElseIf Me.TxtCodigoPostal.Text.Length > 10 Then
                Me.TxtCodigoPostal.Text = Me.TxtCodigoPostal.Text.Substring(0, 10)
            End If

            If Me.cmbTipoAsentamiento.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
            End If

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

    Private Sub reinicializa()

        sNombre = ""
        sCodigoPostal = ""
        iEstado = 1
        TxtNombre.Text = sNombre
        TxtCodigoPostal.Text = sCodigoPostal
        ChkEstado.Estado = iEstado

    End Sub

    Private Sub FrmActividad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        TxtNombre.Text = sNombre
        ChkEstado.Estado = iEstado

        If sTipo = "Colonia" Then
            With Me.cmbTipoAsentamiento
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Geografia"
                .NombreParametro2 = "campo"
                .Parametro2 = "tipo_asentamiento"
                .llenar()
            End With


            cmbTipoAsentamiento.SelectedValue = Me.c_asentamiento
            TxtCodigoPostal.Text = sCodigoPostal

            LblPostal.Visible = True
            LblTipo.Visible = True
            cmbTipoAsentamiento.Visible = True
            TxtCodigoPostal.Visible = True
        End If

    End Sub

    Private Sub FrmActividad_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Geografia.Dispose()
        ModPOS.Geografia = Nothing

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm() Then

            Select Case Me.Padre
                Case "Agregar"
                    sClave = ModPOS.obtenerLlave
                    sNombre = Me.TxtNombre.Text.Trim
                  
                    Select Case sTipo
                        Case "Estado"

                            ModPOS.Ejecuta("sp_inserta_geografia", _
                                "@Tipo", 1, _
                                "@Clave", sClave, _
                                "@Pais", iPais, _
                                "@Estado", sNombre, _
                                "@Mnpio", "", _
                                "@Colonia", "", _
                                "@CP", "", _
                                "@Asentamiento", 0, _
                                "@Usuario", ModPOS.UsuarioActual)

                            If Not ModPOS.Geografia Is Nothing Then
                                ModPOS.ActualizaGrid(True, MtoGeografia.GridEstados, "sp_muestra_estados", "@Pais", iPais)
                                MtoGeografia.GridEstados.RootTable.Columns("ID").Visible = False
                                MtoGeografia.GridEstados.RootTable.Columns("ID_Estado").Visible = False

                                ModPOS.ActualizaGrid(True, MtoGeografia.GridMnpios, "sp_muestra_mnpios", "@Estado", sClave)
                                MtoGeografia.GridMnpios.RootTable.Columns("ID").Visible = False
                                MtoGeografia.GridMnpios.RootTable.Columns("ID_Estado").Visible = False

                            End If

                        Case "Mnpio"

                            ModPOS.Ejecuta("sp_inserta_geografia", _
                                                        "@Tipo", 2, _
                                                        "@Clave", sClave, _
                                                        "@Pais", 0, _
                                                        "@Estado", c_estado, _
                                                        "@Mnpio", sNombre, _
                                                        "@Colonia", "", _
                                                        "@CP", "", _
                                                        "@Asentamiento", 0, _
                                                        "@Usuario", ModPOS.UsuarioActual)

                            If Not ModPOS.Geografia Is Nothing Then
                                ModPOS.ActualizaGrid(True, MtoGeografia.GridMnpios, "sp_muestra_mnpios", "@Estado", c_estado)
                                MtoGeografia.GridMnpios.RootTable.Columns("ID").Visible = False
                                MtoGeografia.GridMnpios.RootTable.Columns("ID_Estado").Visible = False
                            End If

                        Case "Colonia"

                            c_asentamiento = cmbTipoAsentamiento.SelectedValue
                            sCodigoPostal = TxtCodigoPostal.Text.Trim

                            ModPOS.Ejecuta("sp_inserta_geografia", _
                                "@Tipo", 3, _
                                "@Clave", sClave, _
                                "@Pais", 0, _
                                "@Estado", c_estado, _
                                "@Mnpio", c_mnpio, _
                                "@Colonia", sNombre, _
                                "@CP", sCodigoPostal, _
                                "@Asentamiento", c_asentamiento, _
                                "@Usuario", ModPOS.UsuarioActual)

                            If Not ModPOS.Geografia Is Nothing Then
                                ModPOS.ActualizaGrid(True, MtoGeografia.GridColonias, "sp_muestra_colonias", "@Estado", c_estado, "@Mnpio", c_mnpio)
                                MtoGeografia.GridColonias.RootTable.Columns("ID").Visible = False
                                MtoGeografia.GridColonias.RootTable.Columns("ID_Estado").Visible = False
                                MtoGeografia.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False
                            End If

                    End Select

                    reinicializa()

                Case "Modificar"
                    Select Case sTipo
                        Case "Estado"
                            If Not ( _
                                    sNombre = Me.TxtNombre.Text.Trim AndAlso _
                                   iEstado = ChkEstado.GetEstado) Then
                                If iEstado = 1 AndAlso ChkEstado.GetEstado = 0 Then
                                    If SiExite(ModPOS.BDConexion, "sp_existe_geografia", "@Tipo", 1, "@Estado", sClave, "@Mnpio", "", "@CP", "") = 0 Then
                                        actualiza_geografia(1)
                                    Else
                                        MessageBox.Show("No es posible cambiar su estado a inactivo ya que existe un domicilio de cliente o de proveedor relacionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    actualiza_geografia(1)
                                End If
                            End If

                        Case "Mnpio"
                            If Not ( _
                                        sNombre = Me.TxtNombre.Text.Trim AndAlso _
                                        iEstado = ChkEstado.GetEstado) Then

                                If iEstado = 1 AndAlso ChkEstado.GetEstado = 0 Then
                                    If SiExite(ModPOS.BDConexion, "sp_existe_geografia", "@Tipo", 2, "@Estado", c_estado, "@Mnpio", sClave, "@CP", "") = 0 Then
                                        actualiza_geografia(2)
                                    Else
                                        MessageBox.Show("No es posible cambiar su estado a inactivo ya que existe un domicilio de cliente o de proveedor relacionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    actualiza_geografia(2)
                                End If
                            End If

                        Case "Colonia"
                            If Not ( _
                                        sNombre = Me.TxtNombre.Text.Trim AndAlso _
                                        c_asentamiento = cmbTipoAsentamiento.SelectedValue AndAlso _
                                        sCodigoPostal = TxtCodigoPostal.Text.Trim AndAlso _
                                        iEstado = ChkEstado.GetEstado) Then

                                If iEstado = 1 AndAlso ChkEstado.GetEstado = 0 Then
                                    If SiExite(ModPOS.BDConexion, "sp_existe_geografia", "@Tipo", 3, "@Estado", "", "@Mnpio", "", "@CP", sClave) = 0 Then
                                        actualiza_geografia(3)
                                    Else
                                        MessageBox.Show("No es posible cambiar su estado a inactivo ya que existe un domicilio de cliente o de proveedor relacionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                Else
                                    actualiza_geografia(3)
                                End If
                            End If
                    End Select
                    Me.Close()
            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub actualiza_geografia(ByVal tipo As Integer)
        Select Case tipo
            Case 1
                sNombre = Me.TxtNombre.Text.Trim
                iEstado = ChkEstado.GetEstado

                ModPOS.Ejecuta("sp_actualiza_geografia", _
                "@Tipo", 1, _
                "@Clave", sClave, _
                "@Estado", sNombre, _
                "@Mnpio", "", _
                "@Colonia", "", _
                "@CP", "", _
                "@Asentamiento", 0, _
                "@Status", iEstado, _
                "@Usuario", ModPOS.UsuarioActual)

                If Not ModPOS.Geografia Is Nothing Then
                    ModPOS.ActualizaGrid(True, MtoGeografia.GridEstados, "sp_muestra_estados", "@Pais", iPais)
                    MtoGeografia.GridEstados.RootTable.Columns("ID").Visible = False
                    MtoGeografia.GridEstados.RootTable.Columns("ID_Estado").Visible = False
                End If
            Case 2
                sNombre = Me.TxtNombre.Text.Trim
                iEstado = ChkEstado.GetEstado

                ModPOS.Ejecuta("sp_actualiza_geografia", _
                "@Tipo", 2, _
                "@Clave", sClave, _
                "@Estado", c_estado, _
                "@Mnpio", sNombre, _
                "@Colonia", "", _
                "@CP", "", _
                "@Asentamiento", 0, _
                "@Status", iEstado, _
                "@Usuario", ModPOS.UsuarioActual)

                If Not ModPOS.Geografia Is Nothing Then
                    ModPOS.ActualizaGrid(True, MtoGeografia.GridMnpios, "sp_muestra_mnpios", "@Estado", c_estado)
                    MtoGeografia.GridMnpios.RootTable.Columns("ID").Visible = False
                    MtoGeografia.GridMnpios.RootTable.Columns("ID_Estado").Visible = False
                End If

            Case 3
                sNombre = Me.TxtNombre.Text.Trim
                iEstado = ChkEstado.GetEstado
                c_asentamiento = cmbTipoAsentamiento.SelectedValue
                sCodigoPostal = TxtCodigoPostal.Text.Trim

                ModPOS.Ejecuta("sp_actualiza_geografia", _
                "@Tipo", 3, _
                "@Clave", sClave, _
                "@Estado", "", _
                "@Mnpio", "", _
                "@Colonia", sNombre, _
                "@CP", sCodigoPostal, _
                "@Asentamiento", c_asentamiento, _
                "@Status", iEstado, _
                "@Usuario", ModPOS.UsuarioActual)

                If Not ModPOS.Geografia Is Nothing Then
                    ModPOS.ActualizaGrid(True, MtoGeografia.GridColonias, "sp_muestra_colonias", "@Estado", c_estado, "@Mnpio", c_mnpio)
                    MtoGeografia.GridColonias.RootTable.Columns("ID").Visible = False
                    MtoGeografia.GridColonias.RootTable.Columns("ID_Estado").Visible = False
                    MtoGeografia.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False
                End If
        End Select
    End Sub

End Class
