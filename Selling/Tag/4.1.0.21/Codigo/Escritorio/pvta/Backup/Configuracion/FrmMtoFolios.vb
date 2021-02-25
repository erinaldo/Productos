Public Class FrmMtoFolios
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
    Friend WithEvents GridFolios As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoFolios))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpUnidades = New System.Windows.Forms.GroupBox
        Me.GridFolios = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpUnidades.SuspendLayout()
        CType(Me.GridFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(404, 517)
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
        Me.BtnModificar.Location = New System.Drawing.Point(594, 517)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar folio seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(499, 517)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar folio seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Controls.Add(Me.BtnCancelar)
        Me.GrpUnidades.Controls.Add(Me.GridFolios)
        Me.GrpUnidades.Controls.Add(Me.BtnEliminar)
        Me.GrpUnidades.Controls.Add(Me.BtnModificar)
        Me.GrpUnidades.Controls.Add(Me.BtnAgregar)
        Me.GrpUnidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUnidades.Location = New System.Drawing.Point(0, 0)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(784, 562)
        Me.GrpUnidades.TabIndex = 11
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Folios"
        '
        'GridFolios
        '
        Me.GridFolios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridFolios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridFolios.ColumnAutoResize = True
        Me.GridFolios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridFolios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridFolios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridFolios.Location = New System.Drawing.Point(7, 15)
        Me.GridFolios.Name = "GridFolios"
        Me.GridFolios.RecordNavigator = True
        Me.GridFolios.Size = New System.Drawing.Size(771, 496)
        Me.GridFolios.TabIndex = 1
        Me.GridFolios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(687, 517)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo folio"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoFolios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.GrpUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmMtoFolios"
        Me.Text = "Mantenimiento de Folios Fiscales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.GridFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sFolioSelected As String
    Private sSerie As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoFolios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(False, Me.GridFolios, "sp_muestra_folios", "@COMClave", ModPOS.CompanyActual)
        Me.GridFolios.RootTable.Columns("FOLClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridFolios_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridFolios.SelectionChanged
        If Not GridFolios.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sFolioSelected = GridFolios.GetValue(0)
            Me.sSerie = GridFolios.GetValue("Serie")
        Else
            Me.sFolioSelected = ""
            Me.sSerie = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Folio Is Nothing Then
            ModPOS.Folio = New FrmFolio
            With ModPOS.Folio
                .Text = "Agregar Folio"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .AnoAprobacion = Today.Year
                .fechaAprobacion = Today()
            End With
        End If
        ModPOS.Folio.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Folio.Show()
        ModPOS.Folio.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificafolio()
    End Sub

    Public Sub modificaFolio()
        If sFolioSelected <> "" Then

            If ModPOS.Folio Is Nothing Then

                ModPOS.Folio = New FrmFolio
                With ModPOS.Folio
                    .Text = "Modificar Folio"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_foliocfd", "@FOLClave", Me.sFolioSelected)

                    .FOLClave = dt.Rows(0)("FOLClave")
                    .Serie = dt.Rows(0)("Serie")
                    .Inicial = dt.Rows(0)("FolioInicial")
                    .Final = dt.Rows(0)("FolioFinal")
                    .Actual = dt.Rows(0)("FolioActual")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                    .CAJClave = IIf(dt.Rows(0)("CAJClave").GetType.Name = "DBNull", "", dt.Rows(0)("CAJClave"))
                    .Tipo = dt.Rows(0)("TipoComprobante")
                    .AnoAprobacion = IIf(dt.Rows(0)("AnoAprobacion").GetType.Name = "DBNull", 2004, dt.Rows(0)("AnoAprobacion"))
                    .NoAprobacion = IIf(dt.Rows(0)("NoAprobacion").GetType.Name = "DBNull", "", dt.Rows(0)("NoAprobacion"))
                    .fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                    If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                        .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("CBB"), Byte()))
                        .Icono = CType(dt.Rows(0)("CBB"), Byte())
                    End If

                    dt.Dispose()
                End With
            End If

            ModPOS.Folio.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Folio.Show()
            ModPOS.Folio.BringToFront()

        End If
    End Sub

    Private Sub GridFolios_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridFolios.DoubleClick
        modificaFolio()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sFolioSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el folio  :" & sSerie, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_folio", "@FOLClave", sFolioSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(False, Me.GridFolios, "sp_muestra_folios", "@COMClave", ModPOS.CompanyActual)
                    Me.GridFolios.RootTable.Columns("FOLClave").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoFolios_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoFolios.Dispose()
        ModPOS.MtoFolios = Nothing
    End Sub
End Class
