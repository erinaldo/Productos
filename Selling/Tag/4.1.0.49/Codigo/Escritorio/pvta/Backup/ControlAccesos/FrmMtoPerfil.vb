Public Class FrmMtoPerfil
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
    Friend WithEvents GrpPerfiles As System.Windows.Forms.GroupBox
    Friend WithEvents GridPerfiles As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPerfil))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpPerfiles = New System.Windows.Forms.GroupBox
        Me.GridPerfiles = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPerfiles.SuspendLayout()
        CType(Me.GridPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(272, 336)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(464, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar perfil seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(368, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar perfil seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPerfiles
        '
        Me.GrpPerfiles.Controls.Add(Me.BtnCancelar)
        Me.GrpPerfiles.Controls.Add(Me.GridPerfiles)
        Me.GrpPerfiles.Controls.Add(Me.BtnEliminar)
        Me.GrpPerfiles.Controls.Add(Me.BtnModificar)
        Me.GrpPerfiles.Controls.Add(Me.BtnAgregar)
        Me.GrpPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPerfiles.Location = New System.Drawing.Point(0, 0)
        Me.GrpPerfiles.Name = "GrpPerfiles"
        Me.GrpPerfiles.Size = New System.Drawing.Size(656, 380)
        Me.GrpPerfiles.TabIndex = 11
        Me.GrpPerfiles.TabStop = False
        Me.GrpPerfiles.Text = "Perfiles"
        '
        'GridPerfiles
        '
        Me.GridPerfiles.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPerfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPerfiles.ColumnAutoResize = True
        Me.GridPerfiles.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPerfiles.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPerfiles.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPerfiles.Location = New System.Drawing.Point(7, 15)
        Me.GridPerfiles.Name = "GridPerfiles"
        Me.GridPerfiles.RecordNavigator = True
        Me.GridPerfiles.Size = New System.Drawing.Size(643, 315)
        Me.GridPerfiles.TabIndex = 1
        Me.GridPerfiles.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(560, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo perfil"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPerfil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpPerfiles)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPerfil"
        Me.Text = "Mantenimiento de Perfiles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPerfiles.ResumeLayout(False)
        CType(Me.GridPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPerfilSelected As String
  

    Private Sub FrmMtoPerfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridPerfiles, "sp_muestra_perfiles", Nothing)
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Perfil Is Nothing Then
            ModPOS.Perfil = New FrmPerfil
            ModPOS.Perfil.Text = "Nuevo Perfil"
            ModPOS.Perfil.Padre = "Nuevo"
            ModPOS.Perfil.ChkEstado.Enabled = False
            ModPOS.Perfil.TxtClave.ReadOnly = True
        End If
        ModPOS.Perfil.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Perfil.Show()
        ModPOS.Perfil.BringToFront()

    End Sub

    Private Sub GridPerfiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPerfiles.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub


    Private Sub GridPerfiles_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPerfiles.SelectionChanged

        If Not (Me.GridPerfiles.GetValue(0) Is Nothing OrElse (Me.GridPerfiles.GetValue(0) = "SUPER" And ModPOS.UsuarioActual <> "SU")) Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPerfilSelected = GridPerfiles.GetValue(0)
        Else
            Me.sPerfilSelected = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If

    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub GridPerfiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPerfiles.DoubleClick
        Modificar()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara el Perfil :" & sPerfilSelected, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Dim Con As String = ModPOS.BDConexion
                If ModPOS.SiExite(Con, "sp_perfil_vacio", "@Perfil", sPerfilSelected) <> 0 Then
                    MessageBox.Show("El Perfil seleccionado no puede ser eliminado ya que existen usuarios asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    ModPOS.Ejecuta("sp_elimina_perfil", "@Perfil", sPerfilSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, ModPOS.MtoPerfil.GridPerfiles, "sp_muestra_perfiles", Nothing)

                End If

            Case DialogResult.No

        End Select

    End Sub
    Private Sub Modificar()
        If Not (Me.GridPerfiles.GetValue(0) Is Nothing OrElse Me.sPerfilSelected = "" OrElse (Me.GridPerfiles.GetValue(0) = "SUPER" And ModPOS.UsuarioActual <> "SU")) Then
            If ModPOS.Perfil Is Nothing Then
                ModPOS.Perfil = New FrmPerfil
                ModPOS.Perfil.Text = "Editar Perfil"
                ModPOS.Perfil.Padre = "Modificar"
                ModPOS.Perfil.ChkEstado.Enabled = True
                ModPOS.Perfil.TxtClave.ReadOnly = True
                ModPOS.Perfil.sITMKey = sPerfilSelected
                ModPOS.Perfil.sNombre = GridPerfiles.GetValue(1)
                If GridPerfiles.GetValue(2) = "Activo" Then
                    ModPOS.Perfil.iEstado = 1
                Else
                    ModPOS.Perfil.iEstado = 0
                End If
            End If
            ModPOS.Perfil.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Perfil.Show()
            ModPOS.Perfil.BringToFront()
        End If

    End Sub


    Private Sub FrmMtoPerfil_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPerfil.Dispose()
        ModPOS.MtoPerfil = Nothing
    End Sub
End Class
