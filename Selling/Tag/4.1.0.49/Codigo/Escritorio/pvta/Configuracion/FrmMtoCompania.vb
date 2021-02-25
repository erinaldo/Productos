Public Class FrmMtoCompania
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
    Friend WithEvents GrpCompania As System.Windows.Forms.GroupBox
    Friend WithEvents GridCompania As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoCompania))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCompania = New System.Windows.Forms.GroupBox()
        Me.GridCompania = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCompania.SuspendLayout()
        CType(Me.GridCompania, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(453, 470)
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
        Me.BtnModificar.Location = New System.Drawing.Point(645, 470)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar compañia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(549, 470)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina compañia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCompania
        '
        Me.GrpCompania.Controls.Add(Me.BtnCancelar)
        Me.GrpCompania.Controls.Add(Me.GridCompania)
        Me.GrpCompania.Controls.Add(Me.BtnModificar)
        Me.GrpCompania.Controls.Add(Me.BtnEliminar)
        Me.GrpCompania.Controls.Add(Me.BtnAgregar)
        Me.GrpCompania.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCompania.Location = New System.Drawing.Point(0, 0)
        Me.GrpCompania.Name = "GrpCompania"
        Me.GrpCompania.Size = New System.Drawing.Size(839, 513)
        Me.GrpCompania.TabIndex = 11
        Me.GrpCompania.TabStop = False
        Me.GrpCompania.Text = "Compañias"
        '
        'GridCompania
        '
        Me.GridCompania.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCompania.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCompania.ColumnAutoResize = True
        Me.GridCompania.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCompania.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCompania.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCompania.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCompania.Location = New System.Drawing.Point(6, 15)
        Me.GridCompania.Name = "GridCompania"
        Me.GridCompania.RecordNavigator = True
        Me.GridCompania.Size = New System.Drawing.Size(825, 449)
        Me.GridCompania.TabIndex = 1
        Me.GridCompania.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(741, 470)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva compañia"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoCompania
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(839, 513)
        Me.Controls.Add(Me.GrpCompania)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoCompania"
        Me.Text = "Mantenimiento de Compañias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpCompania.ResumeLayout(False)
        CType(Me.GridCompania, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private CompaniaSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoCompania_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridCompania, "sp_muestra_companias", Nothing)
        Me.GridCompania.RootTable.Columns("COMClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridClasificaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCompania.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridClasificaciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCompania.SelectionChanged
        If Not GridCompania.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            CompaniaSelected = GridCompania.GetValue("COMClave")
            Me.sNombre = GridCompania.GetValue("Nombre")
          Else
            Me.CompaniaSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False

        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Compania Is Nothing Then
            ModPOS.Compania = New FrmCompania
            With ModPOS.Compania
                .Text = "Agregar Compañia"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Compania.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Compania.Show()
        ModPOS.Compania.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarCompania()
    End Sub

    Public Sub modificarCompania()
        If CompaniaSelected <> "" Then

            If ModPOS.Compania Is Nothing Then

                ModPOS.Compania = New FrmCompania

                With ModPOS.Compania
                    .Text = "Modificar Compañia"
                    .Padre = "Modificar"
                    .COMClave = CompaniaSelected
                End With
            End If
            ModPOS.Compania.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Compania.Show()
            ModPOS.Compania.BringToFront()
        End If
    End Sub

    Private Sub GridCompania_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCompania.DoubleClick
        modificarCompania()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If CompaniaSelected <> "" Then
            Beep()

            Select Case MessageBox.Show("Se eliminara la Compañia: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion

                    ModPOS.Ejecuta("sp_elimina_compania", "@COMClave", CompaniaSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(False, Me.GridCompania, "sp_muestra_companias", Nothing)
                    Me.GridCompania.RootTable.Columns("COMClave").Visible = False
                Case DialogResult.No
            End Select

        End If
    End Sub

    Private Sub FrmMtoCompania_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCompania.Dispose()
        ModPOS.MtoCompania = Nothing
    End Sub

    
End Class
