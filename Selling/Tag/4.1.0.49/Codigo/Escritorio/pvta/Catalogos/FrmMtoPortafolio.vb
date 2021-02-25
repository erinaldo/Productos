Public Class FrmMtoPortafolio
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
    Friend WithEvents GridPortafolios As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPortafolio))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpModificadores = New System.Windows.Forms.GroupBox()
        Me.GridPortafolios = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpModificadores.SuspendLayout()
        CType(Me.GridPortafolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(270, 337)
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
        Me.BtnModificar.ToolTipText = "Editar portafolio seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(366, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina portafolio seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpModificadores
        '
        Me.GrpModificadores.Controls.Add(Me.BtnCancelar)
        Me.GrpModificadores.Controls.Add(Me.GridPortafolios)
        Me.GrpModificadores.Controls.Add(Me.BtnModificar)
        Me.GrpModificadores.Controls.Add(Me.BtnAgregar)
        Me.GrpModificadores.Controls.Add(Me.BtnEliminar)
        Me.GrpModificadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpModificadores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpModificadores.Location = New System.Drawing.Point(0, 0)
        Me.GrpModificadores.Name = "GrpModificadores"
        Me.GrpModificadores.Size = New System.Drawing.Size(656, 380)
        Me.GrpModificadores.TabIndex = 11
        Me.GrpModificadores.TabStop = False
        Me.GrpModificadores.Text = "Portafolio de Productos"
        '
        'GridPortafolios
        '
        Me.GridPortafolios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPortafolios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPortafolios.ColumnAutoResize = True
        Me.GridPortafolios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPortafolios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPortafolios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPortafolios.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPortafolios.Location = New System.Drawing.Point(6, 15)
        Me.GridPortafolios.Name = "GridPortafolios"
        Me.GridPortafolios.RecordNavigator = True
        Me.GridPortafolios.Size = New System.Drawing.Size(642, 316)
        Me.GridPortafolios.TabIndex = 1
        Me.GridPortafolios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.BtnAgregar.ToolTipText = "Agregar nuevo portafolio"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPortafolio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpModificadores)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPortafolio"
        Me.Text = "Mantenimiento de Portafolios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpModificadores.ResumeLayout(False)
        CType(Me.GridPortafolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private TallaColor As Integer = 0
    Private sPortafolio As String
    Private sNombre As String
    Private iTipo As Integer

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPortafolio_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPortafolio.Dispose()
        ModPOS.MtoPortafolio = Nothing
    End Sub

    Private Sub FrmMtoPortafolio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        ActGrid()
    End Sub


    Public Sub ActGrid()
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridPortafolios, "sp_muestra_portafolios", "@COMClave", ModPOS.CompanyActual)
        Me.GridPortafolios.RootTable.Columns("PORClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub GridPortafolios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPortafolios.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPortafolios_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPortafolios.SelectionChanged
        If Not GridPortafolios.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPortafolio = GridPortafolios.GetValue("PORClave")
            Me.sNombre = GridPortafolios.GetValue("Clave")
        Else
            Me.sPortafolio = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Portafolio Is Nothing Then
            ModPOS.Portafolio = New FrmPortafolio
            With ModPOS.Portafolio
                .TallaColor = TallaColor
                .Text = "Agregar Portafolio"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Portafolio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Portafolio.Show()
        ModPOS.Portafolio.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        editarPortafolio()
    End Sub

    Public Sub editarPortafolio()
        If sPortafolio <> "" Then

            If ModPOS.Portafolio Is Nothing Then

                ModPOS.Portafolio = New FrmPortafolio

                With ModPOS.Portafolio
                    .TallaColor = TallaColor
                    .Text = "Editar Portafolio"
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_portafolio", "@PORClave", Me.sPortafolio)
                    .PORClave = dt.Rows(0)("PORClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Estado = dt.Rows(0)("Estado")

                    dt.Dispose()

                End With
            End If
            ModPOS.Portafolio.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Portafolio.Show()
            ModPOS.Portafolio.BringToFront()
        End If
    End Sub

    Private Sub GridPortafolios_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPortafolios.DoubleClick
        editarPortafolio()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPortafolio <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Portafolio: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_portafolio", "@MODClave", sPortafolio, "@Usuario", ModPOS.UsuarioActual)
                    ActGrid()
                Case DialogResult.No
            End Select
        End If
    End Sub


End Class
