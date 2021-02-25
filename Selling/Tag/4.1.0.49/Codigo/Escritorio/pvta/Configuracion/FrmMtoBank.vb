Public Class FrmMtoBank
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
    Friend WithEvents GrpBank As System.Windows.Forms.GroupBox
    Friend WithEvents GridBancos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoBank))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpBank = New System.Windows.Forms.GroupBox()
        Me.GridBancos = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpBank.SuspendLayout()
        CType(Me.GridBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 337)
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
        Me.BtnModificar.Location = New System.Drawing.Point(463, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica Banco seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina Banco seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpBank
        '
        Me.GrpBank.Controls.Add(Me.BtnCancelar)
        Me.GrpBank.Controls.Add(Me.GridBancos)
        Me.GrpBank.Controls.Add(Me.BtnEliminar)
        Me.GrpBank.Controls.Add(Me.BtnModificar)
        Me.GrpBank.Controls.Add(Me.BtnAgregar)
        Me.GrpBank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBank.Location = New System.Drawing.Point(0, 0)
        Me.GrpBank.Name = "GrpBank"
        Me.GrpBank.Size = New System.Drawing.Size(656, 380)
        Me.GrpBank.TabIndex = 11
        Me.GrpBank.TabStop = False
        Me.GrpBank.Text = "Bancos"
        '
        'GridBancos
        '
        Me.GridBancos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridBancos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridBancos.ColumnAutoResize = True
        Me.GridBancos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridBancos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridBancos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridBancos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridBancos.Location = New System.Drawing.Point(7, 15)
        Me.GridBancos.Name = "GridBancos"
        Me.GridBancos.RecordNavigator = True
        Me.GridBancos.Size = New System.Drawing.Size(642, 316)
        Me.GridBancos.TabIndex = 1
        Me.GridBancos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Banco"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoBank
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpBank)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoBank"
        Me.Text = "Mantenimiento de Bancos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpBank.ResumeLayout(False)
        CType(Me.GridBancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sBankSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridBancos, "sp_recupera_bancos", Nothing)
        Me.GridBancos.RootTable.Columns("BNKClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridBancos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridBancos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBancos.SelectionChanged
        If Not GridBancos.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sBankSelected = GridBancos.GetValue(0)
            Me.sNombre = GridBancos.GetValue(1)
        Else
            Me.sBankSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Bancos Is Nothing Then
            ModPOS.Bancos = New FrmBank
            With ModPOS.Bancos
                .Text = "Agregar Banco"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Bancos.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Bancos.Show()
        ModPOS.Bancos.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarBank()
    End Sub

    Public Sub modificarBank()
        If sBankSelected <> "" Then

            If ModPOS.Bancos Is Nothing Then

                ModPOS.Bancos = New FrmBank

                With ModPOS.Bancos
                    .Text = "Modificar Banco"
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_banco", "@Banco", sBankSelected)

                    .BNKClave = dt.Rows(0)("BNKClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .RFC = IIf(dt.Rows(0)("RfcEmisor").GetType.Name = "DBNull", "", dt.Rows(0)("RfcEmisor"))
                    .Nombre = dt.Rows(0)("Nombre")
                    .Estado = dt.Rows(0)("Estado")
                    dt.Dispose()
                End With
            End If
            ModPOS.Bancos.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Bancos.Show()
            ModPOS.Bancos.BringToFront()
        End If
    End Sub

    Private Sub GridBancos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridBancos.DoubleClick
        modificarBank()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sBankSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Banco  :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_bank", "@Banco", sBankSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridBancos, "sp_recupera_bancos", Nothing)
                    Me.GridBancos.RootTable.Columns("BNKClave").Visible = False

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoBank_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoBancos.Dispose()
        ModPOS.MtoBancos = Nothing
    End Sub

End Class
