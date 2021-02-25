Public Class FrmMtoUsuario
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents GridUsuarios As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoUsuario))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpUsuarios = New System.Windows.Forms.GroupBox
        Me.GridUsuarios = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpUsuarios.SuspendLayout()
        CType(Me.GridUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(358, 427)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(550, 427)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 9
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar usuario seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(454, 427)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 8
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar usuario seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUsuarios
        '
        Me.GrpUsuarios.Controls.Add(Me.BtnCancelar)
        Me.GrpUsuarios.Controls.Add(Me.GridUsuarios)
        Me.GrpUsuarios.Controls.Add(Me.BtnEliminar)
        Me.GrpUsuarios.Controls.Add(Me.BtnModificar)
        Me.GrpUsuarios.Controls.Add(Me.BtnAgregar)
        Me.GrpUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.GrpUsuarios.Name = "GrpUsuarios"
        Me.GrpUsuarios.Size = New System.Drawing.Size(742, 473)
        Me.GrpUsuarios.TabIndex = 5
        Me.GrpUsuarios.TabStop = False
        Me.GrpUsuarios.Text = "Usuarios"
        '
        'GridUsuarios
        '
        Me.GridUsuarios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUsuarios.ColumnAutoResize = True
        Me.GridUsuarios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridUsuarios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUsuarios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridUsuarios.Location = New System.Drawing.Point(7, 15)
        Me.GridUsuarios.Name = "GridUsuarios"
        Me.GridUsuarios.RecordNavigator = True
        Me.GridUsuarios.Size = New System.Drawing.Size(729, 406)
        Me.GridUsuarios.TabIndex = 1
        Me.GridUsuarios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(646, 427)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo usuario"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoUsuario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpUsuarios)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoUsuario"
        Me.Text = "Mantenimiento de Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUsuarios.ResumeLayout(False)
        CType(Me.GridUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sUsuarioSelected As String

    Private Sub FrmMtoUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridUsuarios, "sp_muestra_usuarios", Nothing)
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Usuarios Is Nothing Then
            ModPOS.Usuarios = New FrmUsuarios
            With ModPOS.Usuarios
                .Text = "Agregar Usuario"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False

            End With
        End If
        ModPOS.Usuarios.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Usuarios.Show()
        ModPOS.Usuarios.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub GridUsuarios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridUsuarios.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridUsuarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUsuarios.SelectionChanged
        If Not (Me.GridUsuarios.GetValue(0) Is Nothing OrElse (Me.GridUsuarios.GetValue(0) = "SU" And ModPOS.UsuarioActual <> "SU")) Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sUsuarioSelected = GridUsuarios.GetValue(0)
        Else
            Me.sUsuarioSelected = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub GridUsuarios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUsuarios.DoubleClick
        Modificar()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara el Usuario :" & sUsuarioSelected, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes

                'Dim Con As String = ModPOS.BDConexion
                'If ModPOS.SiExite(Con,"sp_documento_activo", "@Producto", sPerfilSelected) <> 0 Then
                '    MessageBox.Show("El Perfil seleccionado no puede ser eliminado ya que existen usuarios asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                ModPOS.Ejecuta("sp_elimina_usuario", "@Usuario", sUsuarioSelected, "@MUsuario", ModPOS.UsuarioActual)

                ModPOS.ActualizaGrid(True, ModPOS.MtoUsuario.GridUsuarios, "sp_muestra_usuarios", Nothing)

                'End If

            Case DialogResult.No

        End Select

    End Sub

    Private Sub Modificar()
        If Me.sUsuarioSelected <> "" Then
            If ModPOS.Usuarios Is Nothing Then
                ModPOS.Usuarios = New FrmUsuarios
                With ModPOS.Usuarios
                    .Text = "Modificar Usuario"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .ChkEstado.Enabled = True
                End With

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", Me.sUsuarioSelected)
                With ModPOS.Usuarios
                    .USRClave = dt.Rows(0)("USRClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Nombre = dt.Rows(0)("Nombre")
                    .CMIClave = IIf(dt.Rows(0)("CMIClave").GetType.FullName = "System.DBNull", "", dt.Rows(0)("CMIClave"))
                    .PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")
                    .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
                    .PERClave = dt.Rows(0)("PERClave")
                    .Login = dt.Rows(0)("Login")
                    .Password = dt.Rows(0)("Password")
                    .Estado = dt.Rows(0)("Estado")
                    .SUCClave = dt.Rows(0)("SUCClave")
                    .ModCosto = IIf(dt.Rows(0)("ModCosto").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("ModCosto"))
                    .MaxCredito = IIf(dt.Rows(0)("MaxCredito").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("MaxCredito"))
                    .CambiaLista = IIf(dt.Rows(0)("CambiaLista").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("CambiaLista"))

                End With
                dt.Dispose()
            End If
            ModPOS.Usuarios.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Usuarios.Show()
            ModPOS.Usuarios.BringToFront()
        End If
    End Sub

    Private Sub FrmMtoUsuario_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoUsuario.Dispose()
        ModPOS.MtoUsuario = Nothing
    End Sub
End Class
