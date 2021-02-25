Public Class FrmMtoTransporte
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
    Friend WithEvents GrpTransporte As System.Windows.Forms.GroupBox
    Friend WithEvents GridTransporte As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoTransporte))
        Me.GrpTransporte = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GridTransporte = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpTransporte.SuspendLayout()
        CType(Me.GridTransporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTransporte
        '
        Me.GrpTransporte.Controls.Add(Me.BtnCancelar)
        Me.GrpTransporte.Controls.Add(Me.GridTransporte)
        Me.GrpTransporte.Controls.Add(Me.BtnEliminar)
        Me.GrpTransporte.Controls.Add(Me.BtnModificar)
        Me.GrpTransporte.Controls.Add(Me.BtnAgregar)
        Me.GrpTransporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTransporte.Location = New System.Drawing.Point(0, 0)
        Me.GrpTransporte.Name = "GrpTransporte"
        Me.GrpTransporte.Size = New System.Drawing.Size(680, 380)
        Me.GrpTransporte.TabIndex = 11
        Me.GrpTransporte.TabStop = False
        Me.GrpTransporte.Text = "Transporte"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(295, 335)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 15
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridTransporte
        '
        Me.GridTransporte.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTransporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTransporte.ColumnAutoResize = True
        Me.GridTransporte.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTransporte.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTransporte.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridTransporte.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridTransporte.Location = New System.Drawing.Point(7, 15)
        Me.GridTransporte.Name = "GridTransporte"
        Me.GridTransporte.RecordNavigator = True
        Me.GridTransporte.Size = New System.Drawing.Size(666, 312)
        Me.GridTransporte.TabIndex = 1
        Me.GridTransporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(391, 335)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar transporte seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(487, 335)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transporte seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(583, 335)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo transporte"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoTransporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(680, 380)
        Me.Controls.Add(Me.GrpTransporte)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoTransporte"
        Me.Text = "Mantenimiento de Transporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTransporte.ResumeLayout(False)
        CType(Me.GridTransporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sTransporteSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub FrmMtoTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridTransporte, "sp_muestra_transportes", "@COMClave", ModPOS.CompanyActual)
        Me.GridTransporte.RootTable.Columns("TRAClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridTransporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridTransporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridTransporte_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTransporte.SelectionChanged
        If Not GridTransporte.GetValue("TRAClave") Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sTransporteSelected = GridTransporte.GetValue("TRAClave")
            Me.sNombre = GridTransporte.GetValue(1)
        Else
            Me.sTransporteSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Transporte Is Nothing Then
            ModPOS.Transporte = New FrmTransporte
            With ModPOS.Transporte
                .Text = "Agregar Transporte"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .cmbEstado.Enabled = False
            End With
        End If
        ModPOS.Transporte.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Transporte.Show()
        ModPOS.Transporte.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarTrans()
    End Sub

    Public Sub modificarTrans()
        If sTransporteSelected <> "" Then

            If ModPOS.Transporte Is Nothing Then

                ModPOS.Transporte = New FrmTransporte
                With ModPOS.Transporte
                    .Text = "Modificar Transporte"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .txtEconomico.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transporte", "@TRAClave", Me.sTransporteSelected)

                    .TRAClave = dt.Rows(0)("TRAClave")
                    .noEconomico = dt.Rows(0)("noEconomico")
                    .Marca = dt.Rows(0)("Marca")
                    .Modelo = dt.Rows(0)("Modelo")
                    .serieChasis = dt.Rows(0)("serieChasis")
                    .serieMotor = dt.Rows(0)("serieMotor")
                    .Placa = dt.Rows(0)("Placa")
                    .noPoliza = dt.Rows(0)("noPoliza")
                    .Vencimiento = dt.Rows(0)("Vencimiento")
                    .Propietario = dt.Rows(0)("Propietario")
                    .Estado = dt.Rows(0)("Estado")
                    dt.Dispose()

                End With
            End If

            ModPOS.Transporte.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Transporte.Show()
            ModPOS.Transporte.BringToFront()

        End If
    End Sub

    Private Sub GridCaja_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTransporte.DoubleClick
        modificarTrans()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sTransporteSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Transporte: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_transporte", "@TRAClave", sTransporteSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridTransporte, "sp_muestra_transportes", "@COMClave", ModPOS.CompanyActual)
                    Me.GridTransporte.RootTable.Columns("TRAClave").Visible = False

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoTransporte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoTransporte.Dispose()
        ModPOS.MtoTransporte = Nothing
    End Sub
End Class
