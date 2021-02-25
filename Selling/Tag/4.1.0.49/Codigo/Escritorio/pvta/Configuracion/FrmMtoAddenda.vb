Public Class FrmMtoAddenda
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
    Friend WithEvents GrpUnidades As System.Windows.Forms.GroupBox
    Friend WithEvents GridAddendas As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoAddenda))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades = New System.Windows.Forms.GroupBox()
        Me.GridAddendas = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades.SuspendLayout()
        CType(Me.GridAddendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(453, 474)
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
        Me.BtnModificar.Location = New System.Drawing.Point(645, 474)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar addenda seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(549, 474)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar addenda seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Controls.Add(Me.BtnCancelar)
        Me.GrpUnidades.Controls.Add(Me.GridAddendas)
        Me.GrpUnidades.Controls.Add(Me.BtnEliminar)
        Me.GrpUnidades.Controls.Add(Me.BtnModificar)
        Me.GrpUnidades.Controls.Add(Me.BtnAgregar)
        Me.GrpUnidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUnidades.Location = New System.Drawing.Point(0, 0)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(838, 518)
        Me.GrpUnidades.TabIndex = 11
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Addendas"
        '
        'GridAddendas
        '
        Me.GridAddendas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAddendas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAddendas.ColumnAutoResize = True
        Me.GridAddendas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAddendas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAddendas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAddendas.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridAddendas.Location = New System.Drawing.Point(7, 15)
        Me.GridAddendas.Name = "GridAddendas"
        Me.GridAddendas.RecordNavigator = True
        Me.GridAddendas.Size = New System.Drawing.Size(825, 453)
        Me.GridAddendas.TabIndex = 1
        Me.GridAddendas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(741, 474)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Addenda"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoAddenda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(838, 518)
        Me.Controls.Add(Me.GrpUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmMtoAddenda"
        Me.Text = "Mantenimiento de Complementos Fiscales (Addenda)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.GridAddendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sAddendaSelected As String
    Private sAddenda As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoAddenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(True, Me.GridAddendas, "sp_muestra_addendas", "@COMClave", ModPOS.CompanyActual)
        Me.GridAddendas.RootTable.Columns("ADDClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridAddendas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridAddendas.SelectionChanged
        If Not GridAddendas.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sAddendaSelected = GridAddendas.GetValue(0)
            Me.sAddenda = GridAddendas.GetValue("Clave")
        Else
            Me.sAddendaSelected = ""
            Me.sAddenda = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Addenda Is Nothing Then
            ModPOS.Addenda = New FrmAddenda
            With ModPOS.Addenda
                .Text = "Agregar Addenda"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Addenda.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Addenda.Show()
        ModPOS.Addenda.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaAddenda()
    End Sub

    Public Sub modificaAddenda()
        If sAddendaSelected <> "" Then

            If ModPOS.Addenda Is Nothing Then

                ModPOS.Addenda = New FrmAddenda
                With ModPOS.Addenda
                    .Text = "Modificar Addenda"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_addenda", "@ADDClave", Me.sAddendaSelected)

                    .ADDClave = dt.Rows(0)("ADDClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Tipo = dt.Rows(0)("Tipo")
                    .TipoConexion = dt.Rows(0)("TipoConexion")
                    .Estado = dt.Rows(0)("Estado")
                    .UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                    .PwdFTP = dt.Rows(0)("PwdFTP")
                    .FTP = dt.Rows(0)("FTP")
                    .Firma = dt.Rows(0)("FirmaWeb")
                    .email = dt.Rows(0)("email")
                    .NoProveedor = dt.Rows(0)("NoProveedor")
                    .FormatoFactura = dt.Rows(0)("FormatoFactura")
                    dt.Dispose()
                End With
            End If

            ModPOS.Addenda.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Addenda.Show()
            ModPOS.Addenda.BringToFront()

        End If
    End Sub

    Private Sub GridAddendas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridAddendas.DoubleClick
        modificaAddenda()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sAddendaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Addenda  :" & sAddenda, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_addenda", "@ADDClave", sAddendaSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridAddendas, "sp_muestra_addendas", "@COMClave", ModPOS.CompanyActual)
                    Me.GridAddendas.RootTable.Columns("ADDClave").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoAddenda_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoAddenda.Dispose()
        ModPOS.MtoAddenda = Nothing
    End Sub
End Class
