Public Class FrmMtoMon
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
    Friend WithEvents GrpMonedas As System.Windows.Forms.GroupBox
    Friend WithEvents GridMonedas As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoMon))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpMonedas = New System.Windows.Forms.GroupBox()
        Me.GridMonedas = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpMonedas.SuspendLayout()
        CType(Me.GridMonedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 336)
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
        Me.BtnModificar.Location = New System.Drawing.Point(463, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar moneda seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar moneda seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpMonedas
        '
        Me.GrpMonedas.Controls.Add(Me.BtnCancelar)
        Me.GrpMonedas.Controls.Add(Me.GridMonedas)
        Me.GrpMonedas.Controls.Add(Me.BtnEliminar)
        Me.GrpMonedas.Controls.Add(Me.BtnModificar)
        Me.GrpMonedas.Controls.Add(Me.BtnAgregar)
        Me.GrpMonedas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpMonedas.Location = New System.Drawing.Point(0, 0)
        Me.GrpMonedas.Name = "GrpMonedas"
        Me.GrpMonedas.Size = New System.Drawing.Size(656, 380)
        Me.GrpMonedas.TabIndex = 11
        Me.GrpMonedas.TabStop = False
        Me.GrpMonedas.Text = "Monedas"
        '
        'GridMonedas
        '
        Me.GridMonedas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMonedas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMonedas.ColumnAutoResize = True
        Me.GridMonedas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMonedas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMonedas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMonedas.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridMonedas.Location = New System.Drawing.Point(7, 15)
        Me.GridMonedas.Name = "GridMonedas"
        Me.GridMonedas.RecordNavigator = True
        Me.GridMonedas.Size = New System.Drawing.Size(642, 316)
        Me.GridMonedas.TabIndex = 1
        Me.GridMonedas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva moneda"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoMon
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpMonedas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoMon"
        Me.Text = "Mantenimiento de Monedas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpMonedas.ResumeLayout(False)
        CType(Me.GridMonedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sMonSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoMon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridMonedas, "sp_muestra_monedas", Nothing)
        Me.GridMonedas.RootTable.Columns("MONClave").Visible = False


        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridMonedas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridMonedas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridMonedas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMonedas.SelectionChanged
        If Not GridMonedas.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sMonSelected = GridMonedas.GetValue("MONClave")
            Me.sNombre = GridMonedas.GetValue("Descripción")
        Else
            Me.sMonSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Moneda Is Nothing Then
            ModPOS.Moneda = New FrmMoneda
            With ModPOS.Moneda
                .Text = "Agregar Moneda"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Moneda.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Moneda.Show()
        ModPOS.Moneda.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarMon()
    End Sub

    Public Sub modificarMon()
        If sMonSelected <> "" Then

            If ModPOS.Moneda Is Nothing Then

                ModPOS.Moneda = New FrmMoneda
                With ModPOS.Moneda
                    .Text = "Modificar Moneda"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Me.sMonSelected)

                    .MONClave = dt.Rows(0)("MONClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .TipoCambio = dt.Rows(0)("TipoCambio")
                    .TipoCambioVenta = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))

                    .Estado = dt.Rows(0)("Estado")

                    dt.Dispose()

                End With
            End If
            ModPOS.Moneda.TxtNombre.ReadOnly = True
            ModPOS.Moneda.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Moneda.Show()
            ModPOS.Moneda.BringToFront()

        End If
    End Sub

    Private Sub GridMonedas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridMonedas.DoubleClick
        modificarMon()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sMonSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Moneda  :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                        ModPOS.Ejecuta("sp_elimina_moneda", "@Moneda", sMonSelected, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridMonedas, "sp_muestra_monedas", Nothing)
            End Select
        End If
    End Sub

    Private Sub FrmMtoMon_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoMon.Dispose()
        ModPOS.MtoMon = Nothing

    End Sub
End Class
