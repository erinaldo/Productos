Public Class FrmMtoModificadores
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpModificadores As System.Windows.Forms.GroupBox
    Friend WithEvents BtnProductos As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridModificadores As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoModificadores))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpModificadores = New System.Windows.Forms.GroupBox
        Me.GridModificadores = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnProductos = New Janus.Windows.EditControls.UIButton
        Me.GrpModificadores.SuspendLayout()
        CType(Me.GridModificadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(174, 337)
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
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(462, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Editar modificador seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(270, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina modificador seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpModificadores
        '
        Me.GrpModificadores.Controls.Add(Me.BtnCancelar)
        Me.GrpModificadores.Controls.Add(Me.BtnProductos)
        Me.GrpModificadores.Controls.Add(Me.BtnEliminar)
        Me.GrpModificadores.Controls.Add(Me.GridModificadores)
        Me.GrpModificadores.Controls.Add(Me.BtnAgregar)
        Me.GrpModificadores.Controls.Add(Me.BtnModificar)
        Me.GrpModificadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpModificadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpModificadores.Location = New System.Drawing.Point(0, 0)
        Me.GrpModificadores.Name = "GrpModificadores"
        Me.GrpModificadores.Size = New System.Drawing.Size(656, 380)
        Me.GrpModificadores.TabIndex = 11
        Me.GrpModificadores.TabStop = False
        Me.GrpModificadores.Text = "Modificadores de Producto"
        '
        'GridModificadores
        '
        Me.GridModificadores.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridModificadores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridModificadores.ColumnAutoResize = True
        Me.GridModificadores.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridModificadores.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridModificadores.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridModificadores.Location = New System.Drawing.Point(6, 15)
        Me.GridModificadores.Name = "GridModificadores"
        Me.GridModificadores.RecordNavigator = True
        Me.GridModificadores.Size = New System.Drawing.Size(642, 313)
        Me.GridModificadores.TabIndex = 1
        Me.GridModificadores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(558, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Modificador"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnProductos
        '
        Me.BtnProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnProductos.Image = CType(resources.GetObject("BtnProductos.Image"), System.Drawing.Image)
        Me.BtnProductos.Location = New System.Drawing.Point(366, 337)
        Me.BtnProductos.Name = "BtnProductos"
        Me.BtnProductos.Size = New System.Drawing.Size(90, 37)
        Me.BtnProductos.TabIndex = 60
        Me.BtnProductos.Text = "&Productos"
        Me.BtnProductos.ToolTipText = "Agregar productos al modificador seleccionado"
        Me.BtnProductos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoModificadores
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpModificadores)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoModificadores"
        Me.Text = "Mantenimiento de Modificadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpModificadores.ResumeLayout(False)
        CType(Me.GridModificadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sModificador As String
    Private sNombre As String
    Private iTipo As Integer

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoModificador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridModificadores, "sp_muestra_modificadores", "@COMClave", ModPOS.CompanyActual)
        Me.GridModificadores.RootTable.Columns("MODClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridModificadores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridModificadores.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridModificadores_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridModificadores.SelectionChanged
        If Not GridModificadores.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sModificador = GridModificadores.GetValue("MODClave")
            Me.sNombre = GridModificadores.GetValue("Clave")
            BtnProductos.Enabled = True
        Else
            Me.sModificador = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            BtnProductos.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Modificador Is Nothing Then
            ModPOS.Modificador = New FrmModificador
            With ModPOS.Modificador
                .Text = "Agregar Modificador"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Modificador.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Modificador.Show()
        ModPOS.Modificador.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        editarModificador()
    End Sub

    Public Sub editarModificador()
        If sModificador <> "" Then

            If ModPOS.Modificador Is Nothing Then

                ModPOS.Modificador = New FrmModificador

                With ModPOS.Modificador
                    .Text = "Editar Modificador"
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_modificador", "@MODClave", Me.sModificador)
                    .MODClave = dt.Rows(0)("MODClave")
                    .Clave = dt.Rows(0)("CLAVE")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Estado = dt.Rows(0)("Estado")

                    dt.Dispose()

                End With
            End If
            ModPOS.Modificador.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Modificador.Show()
            ModPOS.Modificador.BringToFront()
        End If
    End Sub

    Private Sub GridModificadores_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridModificadores.DoubleClick
        editarModificador()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sModificador <> "" Then
            Beep()

            Select Case MessageBox.Show("Se eliminara el Modificador: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_modificador_vacio", "@MODClave", sModificador) <> 0 Then
                        MessageBox.Show("El modificador seleccionado no puede ser eliminado ya que existen productos asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ModPOS.Ejecuta("sp_elimina_modificador", "@MODClave", sModificador, "@Usuario", ModPOS.UsuarioActual)
                        ModPOS.ActualizaGrid(True, Me.GridModificadores, "sp_muestra_modificadores", "@COMClave", ModPOS.CompanyActual)
                        Me.GridModificadores.RootTable.Columns("MODClave").Visible = False
                    End If

                Case DialogResult.No
            End Select
        End If
    End Sub

    Private Sub FrmMtoModificadores_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoModificadores.Dispose()
        ModPOS.MtoModificadores = Nothing
    End Sub

    Private Sub BtnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProductos.Click
        If Not sModificador Is Nothing Then
            If ModPOS.ProdMod Is Nothing Then
                ModPOS.ProdMod = New FrmProdMod
                With ModPOS.ProdMod
                    .StartPosition = FormStartPosition.CenterScreen
                    .Text = "Modificador: " & GridModificadores.GetValue("Nombre")
                    .MODClave = sModificador
                End With
            End If
            ModPOS.ProdMod.StartPosition = FormStartPosition.CenterScreen
            ModPOS.ProdMod.Show()
            ModPOS.ProdMod.BringToFront()
        End If
    End Sub
End Class
