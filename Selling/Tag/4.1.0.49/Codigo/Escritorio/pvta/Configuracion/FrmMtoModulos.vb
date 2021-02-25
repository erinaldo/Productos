Public Class FrmMtoModulos
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
    Friend WithEvents BtnModificarItem As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpEstructuras As System.Windows.Forms.GroupBox
    Friend WithEvents GridActividades As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpModulos As System.Windows.Forms.GroupBox
    Friend WithEvents GridModulos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoModulos))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificarItem = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GrpEstructuras = New System.Windows.Forms.GroupBox()
        Me.GridActividades = New Janus.Windows.GridEX.GridEX()
        Me.GrpModulos = New System.Windows.Forms.GroupBox()
        Me.GridModulos = New Janus.Windows.GridEX.GridEX()
        Me.GrpEstructuras.SuspendLayout()
        CType(Me.GridActividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpModulos.SuspendLayout()
        CType(Me.GridModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(370, 364)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 14
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificarItem
        '
        Me.BtnModificarItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificarItem.Image = CType(resources.GetObject("BtnModificarItem.Image"), System.Drawing.Image)
        Me.BtnModificarItem.Location = New System.Drawing.Point(561, 364)
        Me.BtnModificarItem.Name = "BtnModificarItem"
        Me.BtnModificarItem.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificarItem.TabIndex = 13
        Me.BtnModificarItem.Text = "&Actividad"
        Me.BtnModificarItem.ToolTipText = "Modifica actividad seleccionada"
        Me.BtnModificarItem.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(466, 364)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 12
        Me.BtnModificar.Text = "&Modulo"
        Me.BtnModificar.ToolTipText = "Modifica modulo seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpEstructuras
        '
        Me.GrpEstructuras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstructuras.Controls.Add(Me.GridActividades)
        Me.GrpEstructuras.Location = New System.Drawing.Point(7, 183)
        Me.GrpEstructuras.Name = "GrpEstructuras"
        Me.GrpEstructuras.Size = New System.Drawing.Size(644, 175)
        Me.GrpEstructuras.TabIndex = 10
        Me.GrpEstructuras.TabStop = False
        Me.GrpEstructuras.Text = "Actividades "
        '
        'GridActividades
        '
        Me.GridActividades.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridActividades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridActividades.ColumnAutoResize = True
        Me.GridActividades.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridActividades.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridActividades.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridActividades.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridActividades.Location = New System.Drawing.Point(7, 15)
        Me.GridActividades.Name = "GridActividades"
        Me.GridActividades.RecordNavigator = True
        Me.GridActividades.Size = New System.Drawing.Size(630, 153)
        Me.GridActividades.TabIndex = 2
        Me.GridActividades.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpModulos
        '
        Me.GrpModulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpModulos.Controls.Add(Me.GridModulos)
        Me.GrpModulos.Location = New System.Drawing.Point(7, 7)
        Me.GrpModulos.Name = "GrpModulos"
        Me.GrpModulos.Size = New System.Drawing.Size(644, 170)
        Me.GrpModulos.TabIndex = 8
        Me.GrpModulos.TabStop = False
        Me.GrpModulos.Text = "Modulos"
        '
        'GridModulos
        '
        Me.GridModulos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridModulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridModulos.ColumnAutoResize = True
        Me.GridModulos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridModulos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridModulos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridModulos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridModulos.Location = New System.Drawing.Point(7, 15)
        Me.GridModulos.Name = "GridModulos"
        Me.GridModulos.RecordNavigator = True
        Me.GridModulos.Size = New System.Drawing.Size(630, 149)
        Me.GridModulos.TabIndex = 1
        Me.GridModulos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoModulos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 406)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnModificarItem)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.GrpEstructuras)
        Me.Controls.Add(Me.GrpModulos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoModulos"
        Me.Text = "Mantenimiento de Modulos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpEstructuras.ResumeLayout(False)
        CType(Me.GridActividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpModulos.ResumeLayout(False)
        CType(Me.GridModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public sModuloSelected As String
    Private sActividadSelected As String

    Private Sub FrmMtoModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridModulos, "sp_muestra_modulos", Nothing)
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridActividades_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridActividades.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificarItem.PerformClick()
        End If
    End Sub

    Private Sub GridActividades_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridActividades.SelectionChanged
        If Not Me.GridActividades.GetValue(0) Is Nothing Then
            Me.BtnModificarItem.Enabled = True
            Me.sActividadSelected = GridActividades.GetValue(0)
        Else
            Me.sActividadSelected = ""
            Me.BtnModificarItem.Enabled = False
        End If

    End Sub

    Private Sub GridModulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridModulos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub


    Private Sub GridModulos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridModulos.SelectionChanged
        If Not Me.GridModulos.GetValue(0) Is Nothing Then
            ModPOS.ActualizaGrid(True, Me.GridActividades, "sp_muestra_actividades", "@Modulo", Me.GridModulos.GetValue(0))
            Me.BtnModificar.Enabled = True
            Me.sModuloSelected = GridModulos.GetValue(0)
        Else
            Me.sModuloSelected = ""
            Me.BtnModificar.Enabled = False
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        ModificaGroup()
        
        End Sub

    Private Sub BtnModificarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificarItem.Click
        ModificaItem()
    End Sub

    Private Sub GridActividades_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridActividades.DoubleClick
        ModificaItem()
    End Sub

    Private Sub GridModulos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridModulos.DoubleClick
        ModificaGroup()
    End Sub

    Private Sub ModificaItem()
        If Me.sActividadSelected <> "" Then
            If ModPOS.Actividad Is Nothing Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_act", "@Modulo", sModuloSelected, "@Actividad", sActividadSelected)

                ModPOS.Actividad = New FrmActividad

                With ModPOS.Actividad
                    .Text = "Editar Actividad"
                    .sITMKey = dt.Rows(0)("ITMKey")
                    .sGRPKey = dt.Rows(0)("GRPKey")
                    .sNombre = dt.Rows(0)("Nombre")
                    .iEstado = dt.Rows(0)("Estado")
                    .iOrden = IIf(dt.Rows(0)("Orden").GetType.Name = "DBNull", 0, dt.Rows(0)("Orden"))

                    .ChkEstado.Enabled = False
                    
                    If Not dt.Rows(0)("Imagen") Is System.DBNull.Value Then
                        .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Imagen"), Byte()))
                        .Icono = CType(dt.Rows(0)("Imagen"), Byte())
                        .IconoActual = .Icono
                    End If
                End With
                dt.Dispose()
            End If
            With ModPOS.Actividad
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If

    End Sub

    Private Sub ModificaGroup()
        If Me.sModuloSelected <> "" Then
            If ModPOS.Modulo Is Nothing Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_mod", "@Modulo", sModuloSelected)

                ModPOS.Modulo = New FrmGrupo

                With ModPOS.Modulo
                    .Text = "Editar Modulo"
                    .sGRPKey = dt.Rows(0)("GRPKey")
                    .iEstado = dt.Rows(0)("Estado")
                    .sNombre = dt.Rows(0)("Nombre")
                    .iOrden = dt.Rows(0)("Orden")

                    .ChkEstado.Enabled = False
                    If Not dt.Rows(0)("Imagen") Is System.DBNull.Value Then
                        .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Imagen"), Byte()))
                        .Icono = CType(dt.Rows(0)("Imagen"), Byte())
                        .IconoActual = .Icono
                    End If
                End With
                dt.Dispose()
            End If
            With ModPOS.Modulo
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If
    End Sub


    Private Sub FrmMtoModulos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoModulos.Dispose()
        ModPOS.MtoModulos = Nothing

    End Sub
End Class
