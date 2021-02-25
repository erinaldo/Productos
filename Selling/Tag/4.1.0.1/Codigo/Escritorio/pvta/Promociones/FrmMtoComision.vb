Public Class FrmMtoComision
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
    Friend WithEvents GrpComisiones As System.Windows.Forms.GroupBox
    Friend WithEvents GridComisiones As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoComision))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpComisiones = New System.Windows.Forms.GroupBox
        Me.GridComisiones = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpComisiones.SuspendLayout()
        CType(Me.GridComisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(358, 429)
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
        Me.BtnModificar.Location = New System.Drawing.Point(550, 429)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar comisión seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(454, 429)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar comición seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpComisiones
        '
        Me.GrpComisiones.Controls.Add(Me.BtnCancelar)
        Me.GrpComisiones.Controls.Add(Me.GridComisiones)
        Me.GrpComisiones.Controls.Add(Me.BtnEliminar)
        Me.GrpComisiones.Controls.Add(Me.BtnModificar)
        Me.GrpComisiones.Controls.Add(Me.BtnAgregar)
        Me.GrpComisiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpComisiones.Location = New System.Drawing.Point(0, 0)
        Me.GrpComisiones.Name = "GrpComisiones"
        Me.GrpComisiones.Size = New System.Drawing.Size(742, 473)
        Me.GrpComisiones.TabIndex = 11
        Me.GrpComisiones.TabStop = False
        Me.GrpComisiones.Text = "Comisiones"
        '
        'GridComisiones
        '
        Me.GridComisiones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridComisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComisiones.ColumnAutoResize = True
        Me.GridComisiones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComisiones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComisiones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridComisiones.Location = New System.Drawing.Point(7, 15)
        Me.GridComisiones.Name = "GridComisiones"
        Me.GridComisiones.RecordNavigator = True
        Me.GridComisiones.Size = New System.Drawing.Size(729, 408)
        Me.GridComisiones.TabIndex = 1
        Me.GridComisiones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(646, 429)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva Comisión"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoComision
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpComisiones)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoComision"
        Me.Text = "Mantenimiento de Comisiones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpComisiones.ResumeLayout(False)
        CType(Me.GridComisiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sComisionSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoComision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridComisiones, "sp_muestra_comisiones", "@COMClave", ModPOS.CompanyActual)
        Me.GridComisiones.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridComisiones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridComisiones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPromociones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridComisiones.SelectionChanged
        If Not GridComisiones.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sComisionSelected = GridComisiones.GetValue("ID")
            Me.sNombre = GridComisiones.GetValue("Clave")
        Else
            Me.sComisionSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Comision Is Nothing Then
            ModPOS.Comision = New FrmComision
            With ModPOS.Comision
                .Text = "Nueva Comisión"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Nuevo"
            End With
        End If
        ModPOS.Comision.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Comision.Show()
        ModPOS.Comision.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaComision()
    End Sub

    Public Sub modificaComision()
        If sComisionSelected <> "" Then
            If ModPOS.Comision Is Nothing Then
                ModPOS.Comision = New FrmComision
                With ModPOS.Comision
                    .Text = "Modificar Comisión"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_comision", "@CMIClave", Me.sComisionSelected)
                    .CMIClave = dt.Rows(0)("CMIClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Tipo = dt.Rows(0)("Tipo")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Aplicacion = dt.Rows(0)("TipoAplicacion")
                    .Estado = dt.Rows(0)("Estado")
                    dt.Dispose()
                End With
            End If
            ModPOS.Comision.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Comision.Show()
            ModPOS.Comision.BringToFront()
        End If
    End Sub

    Private Sub GridPromociones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridComisiones.DoubleClick
        modificaComision()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sComisionSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la comisión: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_comision", "@CMIClave", sComisionSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridComisiones, "sp_muestra_comisiones", "@COMClave", ModPOS.CompanyActual)
                    Me.GridComisiones.RootTable.Columns("ID").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoComision_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoComision.Dispose()
        ModPOS.MtoComision = Nothing
    End Sub

End Class
