Public Class FrmMtoPromocion
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
    Friend WithEvents GrpPromociones As System.Windows.Forms.GroupBox
    Friend WithEvents GridPromociones As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPromocion))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpPromociones = New System.Windows.Forms.GroupBox
        Me.GridPromociones = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPromociones.SuspendLayout()
        CType(Me.GridPromociones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(357, 429)
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
        Me.BtnModificar.Location = New System.Drawing.Point(549, 429)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar promoción seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(453, 429)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar promoción seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPromociones
        '
        Me.GrpPromociones.Controls.Add(Me.BtnCancelar)
        Me.GrpPromociones.Controls.Add(Me.GridPromociones)
        Me.GrpPromociones.Controls.Add(Me.BtnEliminar)
        Me.GrpPromociones.Controls.Add(Me.BtnModificar)
        Me.GrpPromociones.Controls.Add(Me.BtnAgregar)
        Me.GrpPromociones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPromociones.Location = New System.Drawing.Point(0, 0)
        Me.GrpPromociones.Name = "GrpPromociones"
        Me.GrpPromociones.Size = New System.Drawing.Size(742, 473)
        Me.GrpPromociones.TabIndex = 11
        Me.GrpPromociones.TabStop = False
        Me.GrpPromociones.Text = "Promociones"
        '
        'GridPromociones
        '
        Me.GridPromociones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPromociones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPromociones.ColumnAutoResize = True
        Me.GridPromociones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPromociones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPromociones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPromociones.Location = New System.Drawing.Point(7, 15)
        Me.GridPromociones.Name = "GridPromociones"
        Me.GridPromociones.RecordNavigator = True
        Me.GridPromociones.Size = New System.Drawing.Size(728, 408)
        Me.GridPromociones.TabIndex = 1
        Me.GridPromociones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(645, 429)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva promoción"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPromocion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpPromociones)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoPromocion"
        Me.Text = "Mantenimiento de Promociones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPromociones.ResumeLayout(False)
        CType(Me.GridPromociones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPromocionSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridPromociones, "sp_muestra_promociones", "@COMClave", ModPOS.CompanyActual)
        Me.GridPromociones.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridPromociones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPromociones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPromociones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPromociones.SelectionChanged
        If Not GridPromociones.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPromocionSelected = GridPromociones.GetValue("ID")
            Me.sNombre = GridPromociones.GetValue("Clave")
        Else
            Me.sPromocionSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Promocion Is Nothing Then
            ModPOS.Promocion = New FrmPromocion
            With ModPOS.Promocion
                .Text = "Nueva Promoción"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Nuevo"
            End With
        End If
        ModPOS.Promocion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Promocion.Show()
        ModPOS.Promocion.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaPromocion()
    End Sub

    Public Sub modificaPromocion()
        If sPromocionSelected <> "" Then
            If ModPOS.Promocion Is Nothing Then
                ModPOS.Promocion = New FrmPromocion
                With ModPOS.Promocion
                    .Text = "Modificar Promoción"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_promocion", "@PRMClave", Me.sPromocionSelected)
                    .PRMClave = dt.Rows(0)("PRMClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Tipo = dt.Rows(0)("Tipo")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .FechaInicio = dt.Rows(0)("FechaInicio")
                    .FechaFin = dt.Rows(0)("FechaFin")
                    .Aplicacion = dt.Rows(0)("TipoAplicacion")
                    .CalculoBase = dt.Rows(0)("TipoCalculoBase")
                    .Gerarquia = dt.Rows(0)("Gerarquia")
                    .Cascada = dt.Rows(0)("Cascada")
                    .Estado = dt.Rows(0)("Estado")
                    .Iguales = IIf(dt.Rows(0)("Iguales").GetType.Name = "DBNull", 1, dt.Rows(0)("Iguales"))
                    dt.Dispose()
                End With
            End If
            ModPOS.Promocion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Promocion.Show()
            ModPOS.Promocion.BringToFront()
        End If
    End Sub

    Private Sub GridPromociones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPromociones.DoubleClick
        modificaPromocion()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPromocionSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la promoción: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_promocion", "@PRMClave", sPromocionSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridPromociones, "sp_muestra_promociones", "@COMClave", ModPOS.CompanyActual)
                    Me.GridPromociones.RootTable.Columns("ID").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoPromocion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPromocion.Dispose()
        ModPOS.MtoPromocion = Nothing

    End Sub
End Class
