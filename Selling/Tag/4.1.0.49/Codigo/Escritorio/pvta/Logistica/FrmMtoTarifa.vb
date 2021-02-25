Public Class FrmMtoTarifa
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
    Friend WithEvents GrpTarifas As System.Windows.Forms.GroupBox
    Friend WithEvents GridTarifas As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoTarifa))
        Me.GrpTarifas = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GridTarifas = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpTarifas.SuspendLayout()
        CType(Me.GridTarifas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTarifas
        '
        Me.GrpTarifas.Controls.Add(Me.BtnCancelar)
        Me.GrpTarifas.Controls.Add(Me.GridTarifas)
        Me.GrpTarifas.Controls.Add(Me.BtnEliminar)
        Me.GrpTarifas.Controls.Add(Me.BtnModificar)
        Me.GrpTarifas.Controls.Add(Me.BtnAgregar)
        Me.GrpTarifas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTarifas.Location = New System.Drawing.Point(0, 0)
        Me.GrpTarifas.Name = "GrpTarifas"
        Me.GrpTarifas.Size = New System.Drawing.Size(742, 473)
        Me.GrpTarifas.TabIndex = 11
        Me.GrpTarifas.TabStop = False
        Me.GrpTarifas.Text = "Tarifas de Transporte "
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(357, 428)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridTarifas
        '
        Me.GridTarifas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTarifas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTarifas.ColumnAutoResize = True
        Me.GridTarifas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTarifas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTarifas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridTarifas.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridTarifas.Location = New System.Drawing.Point(7, 15)
        Me.GridTarifas.Name = "GridTarifas"
        Me.GridTarifas.RecordNavigator = True
        Me.GridTarifas.Size = New System.Drawing.Size(729, 407)
        Me.GridTarifas.TabIndex = 1
        Me.GridTarifas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(453, 428)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar tarifa seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(549, 428)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar tarifa seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(645, 428)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar tarifa"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoTarifa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpTarifas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoTarifa"
        Me.Text = "Mantenimiento de Tarifas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTarifas.ResumeLayout(False)
        CType(Me.GridTarifas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sTarifaSelected As String
    Private Clave As String

    Private Sub FrmMtoTarifa_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoTarifa.Dispose()
        ModPOS.MtoTarifa = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoTarifa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridTarifas, "sp_muestra_tarifas", "@COMClave", ModPOS.CompanyActual)
        Me.GridTarifas.RootTable.Columns("TARClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridTarifas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridTarifas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridTarifas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTarifas.SelectionChanged
        If Not GridTarifas.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sTarifaSelected = GridTarifas.GetValue("TARClave")
            Me.Clave = GridTarifas.GetValue("Clave")
        Else
            Me.sTarifaSelected = ""
            Clave = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Tarifa Is Nothing Then
            ModPOS.Tarifa = New FrmTarifa
            With ModPOS.Tarifa
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Tarifa.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Tarifa.Show()
        ModPOS.Tarifa.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaTarifa()
    End Sub

    Public Sub modificaTarifa()
        If sTarifaSelected <> "" Then

            If ModPOS.Tarifa Is Nothing Then

                ModPOS.Tarifa = New FrmTarifa
                With ModPOS.Tarifa
                    .Text = "Modificar Listado de Tarifas"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_tarifa", "@TARClave", Me.sTarifaSelected)
                    .TARClave = dt.Rows(0)("TARClave")
                    .CTEClave = dt.Rows(0)("CTEClave")
                    .Clave = dt.Rows(0)("Clave")
                    .RazonSocial = dt.Rows(0)("RazonSocial")
                    .RFC = dt.Rows(0)("Id_Fiscal")
                    .Estado = dt.Rows(0)("Estado")
                    dt.Dispose()
                End With
            End If

            ModPOS.Tarifa.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Tarifa.Show()
            ModPOS.Tarifa.BringToFront()

        End If
    End Sub

    Private Sub GridListaPrecio_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTarifas.DoubleClick
        modificaTarifa()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sTarifaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la tarifa: " & Clave, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_tarifa", "@TARClave", sTarifaSelected, "@Usuario", ModPOS.UsuarioActual)
                    ModPOS.ActualizaGrid(True, Me.GridTarifas, "sp_muestra_tarifas", "@COMClave", ModPOS.CompanyActual)
                    Me.GridTarifas.RootTable.Columns("TARClave").Visible = False

            End Select

        End If
    End Sub

End Class
