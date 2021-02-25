Public Class FrmMtoPisos
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
    Friend WithEvents GrpPisos As System.Windows.Forms.GroupBox
    Friend WithEvents GridPisos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPisos))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpPisos = New System.Windows.Forms.GroupBox
        Me.GridPisos = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPisos.SuspendLayout()
        CType(Me.GridPisos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnModificar.ToolTipText = "Modifica Piso seleccionado"
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
        Me.BtnEliminar.ToolTipText = "Elimina Piso seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPisos
        '
        Me.GrpPisos.Controls.Add(Me.BtnCancelar)
        Me.GrpPisos.Controls.Add(Me.GridPisos)
        Me.GrpPisos.Controls.Add(Me.BtnEliminar)
        Me.GrpPisos.Controls.Add(Me.BtnModificar)
        Me.GrpPisos.Controls.Add(Me.BtnAgregar)
        Me.GrpPisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPisos.Location = New System.Drawing.Point(0, 0)
        Me.GrpPisos.Name = "GrpPisos"
        Me.GrpPisos.Size = New System.Drawing.Size(656, 380)
        Me.GrpPisos.TabIndex = 11
        Me.GrpPisos.TabStop = False
        Me.GrpPisos.Text = "Pisos"
        '
        'GridPisos
        '
        Me.GridPisos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPisos.ColumnAutoResize = True
        Me.GridPisos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPisos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPisos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPisos.Location = New System.Drawing.Point(7, 15)
        Me.GridPisos.Name = "GridPisos"
        Me.GridPisos.RecordNavigator = True
        Me.GridPisos.Size = New System.Drawing.Size(642, 317)
        Me.GridPisos.TabIndex = 1
        Me.GridPisos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.BtnAgregar.ToolTipText = "Agregar nuevo Piso"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPisos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpPisos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPisos"
        Me.Text = "Mantenimiento de Pisos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPisos.ResumeLayout(False)
        CType(Me.GridPisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPisoSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridPisos, "sp_recupera_pisos", "@COMClave", ModPOS.CompanyActual)
        Me.GridPisos.RootTable.Columns("PISClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridBancos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPisos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPisos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPisos.SelectionChanged
        If Not GridPisos.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPisoSelected = GridPisos.GetValue(0)
            Me.sNombre = GridPisos.GetValue(1)
        Else
            Me.sPisoSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Pisos Is Nothing Then
            ModPOS.Pisos = New FrmPisos
            With ModPOS.Pisos
                .Text = "Agregar Piso"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Pisos.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Pisos.Show()
        ModPOS.Pisos.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarPiso()
    End Sub

    Public Sub modificarPiso()
        If sPisoSelected <> "" Then

            If ModPOS.Pisos Is Nothing Then

                ModPOS.Pisos = New FrmPisos

                With ModPOS.Pisos
                    .Text = "Modificar Piso"
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_piso", "@Piso", sPisoSelected)

                    .PISClave = dt.Rows(0)("PISClave")
                    .SUCClave = dt.Rows(0)("SUCClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .ColorPiso = dt.Rows(0)("ColorPiso")
                    .cMesaOcupada = dt.Rows(0)("cMesaOcupada")
                    .cMesaDisponible = dt.Rows(0)("cMesaDisponible")
                    .cMesaSucia = dt.Rows(0)("cMesaSucia")
                    .Estado = dt.Rows(0)("Estado")

                    If Not dt.Rows(0)("ImagenDisponible") Is System.DBNull.Value Then
                        .PictDisponible.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("ImagenDisponible"), Byte()))
                        .IconoDisp = CType(dt.Rows(0)("ImagenDisponible"), Byte())
                        .IconoDispActual = .IconoDisp
                    End If

                    If Not dt.Rows(0)("ImagenOcupada") Is System.DBNull.Value Then
                        .PictOcupada.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("ImagenOcupada"), Byte()))
                        .IconoOcup = CType(dt.Rows(0)("ImagenOcupada"), Byte())
                        .IconoOcupActual = .IconoOcup
                    End If

                    
                    dt.Dispose()
                End With
            End If
            ModPOS.Pisos.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Pisos.Show()
            ModPOS.Pisos.BringToFront()
        End If
    End Sub

    Private Sub GridPisos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPisos.DoubleClick
        modificarPiso()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPisoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Piso: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_piso", "@Piso", sPisoSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridPisos, "sp_recupera_pisos", "@COMClave", ModPOS.CompanyActual)
                    Me.GridPisos.RootTable.Columns("PISClave").Visible = False

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoPisos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Mtopisos.Dispose()
        ModPOS.Mtopisos = Nothing
    End Sub

End Class
