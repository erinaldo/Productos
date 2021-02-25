Public Class FrmMtoCertificado
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
    Friend WithEvents GrpSucursales As System.Windows.Forms.GroupBox
    Friend WithEvents GridCertificados As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoCertificado))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpSucursales = New System.Windows.Forms.GroupBox()
        Me.GridCertificados = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpSucursales.SuspendLayout()
        CType(Me.GridCertificados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(401, 518)
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
        Me.BtnModificar.Location = New System.Drawing.Point(592, 518)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar sucursal seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(497, 518)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar sucursal seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpSucursales
        '
        Me.GrpSucursales.Controls.Add(Me.BtnCancelar)
        Me.GrpSucursales.Controls.Add(Me.GridCertificados)
        Me.GrpSucursales.Controls.Add(Me.BtnEliminar)
        Me.GrpSucursales.Controls.Add(Me.BtnModificar)
        Me.GrpSucursales.Controls.Add(Me.BtnAgregar)
        Me.GrpSucursales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpSucursales.Location = New System.Drawing.Point(0, 0)
        Me.GrpSucursales.Name = "GrpSucursales"
        Me.GrpSucursales.Size = New System.Drawing.Size(784, 562)
        Me.GrpSucursales.TabIndex = 11
        Me.GrpSucursales.TabStop = False
        Me.GrpSucursales.Text = "Certificados"
        '
        'GridCertificados
        '
        Me.GridCertificados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCertificados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCertificados.ColumnAutoResize = True
        Me.GridCertificados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCertificados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCertificados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCertificados.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCertificados.Location = New System.Drawing.Point(7, 15)
        Me.GridCertificados.Name = "GridCertificados"
        Me.GridCertificados.RecordNavigator = True
        Me.GridCertificados.Size = New System.Drawing.Size(771, 496)
        Me.GridCertificados.TabIndex = 1
        Me.GridCertificados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(686, 518)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva sucursal"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoCertificado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.GrpSucursales)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmMtoCertificado"
        Me.Text = "Mantenimiento de Certificados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpSucursales.ResumeLayout(False)
        CType(Me.GridCertificados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sCertificadoSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoCertificado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(False, Me.GridCertificados, "sp_muestra_certificados", "@COMClave", ModPOS.CompanyActual)
        Me.GridCertificados.RootTable.Columns("CERClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridCertificados_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCertificados.SelectionChanged
        If Not GridCertificados.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sCertificadoSelected = GridCertificados.GetValue("CERClave")
            Me.sNombre = GridCertificados.GetValue("Serie")
        Else
            Me.sCertificadoSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Certificado Is Nothing Then
            ModPOS.Certificado = New FrmCertificado
            With ModPOS.Certificado
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Certificado.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Certificado.Show()
        ModPOS.Certificado.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaCertificado()
    End Sub

    Public Sub modificaCertificado()
        If sCertificadoSelected <> "" Then

            If ModPOS.Certificado Is Nothing Then

                ModPOS.Certificado = New FrmCertificado
                With ModPOS.Certificado
                    .Text = "Modificar Certificado"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_certificado", "@CERClave", Me.sCertificadoSelected)

                    .CERClave = dt.Rows(0)("CERClave")
                    .Serie = dt.Rows(0)("Serie")
                    .Certificado64 = IIf(dt.Rows(0)("Certificado").GetType.Name = "DBNull", "", dt.Rows(0)("Certificado"))
                    .Inicial = dt.Rows(0)("VigenciaInicial")
                    .Final = dt.Rows(0)("VigenciaFinal")
                    .LLave = dt.Rows(0)("Llave")
                    .urlCertificado = IIf(dt.Rows(0)("urlCertificado").GetType.Name = "DBNull", "", dt.Rows(0)("urlCertificado"))
                    .Password = dt.Rows(0)("Password")
                    dt.Dispose()

                End With
            End If

            ModPOS.Certificado.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Certificado.Show()
            ModPOS.Certificado.BringToFront()

        End If
    End Sub

    Private Sub GridSucursales_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCertificados.DoubleClick
        modificaCertificado()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sCertificadoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el certificado No. Serie: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_certificado", "@CERClave", sCertificadoSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(False, Me.GridCertificados, "sp_muestra_certificados", "@COMClave", ModPOS.CompanyActual)
                    Me.GridCertificados.RootTable.Columns("CERClave").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoCertificado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCertificado.Dispose()
        ModPOS.MtoCertificado = Nothing
    End Sub
End Class
