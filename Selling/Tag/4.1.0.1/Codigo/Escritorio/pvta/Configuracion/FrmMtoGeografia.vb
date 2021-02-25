Public Class FrmMtoGeografia
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
    Friend WithEvents GrpColonias As System.Windows.Forms.GroupBox
    Friend WithEvents GridColonias As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpEstado As System.Windows.Forms.GroupBox
    Friend WithEvents GridEstados As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpMnpios As System.Windows.Forms.GroupBox
    Friend WithEvents GridMnpios As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbPais As Selling.StoreCombo
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents BtnAddColonia As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModColonia As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddEstado As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModEstado As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddMnpio As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModMnpio As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelEstado As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelMnpio As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelColonia As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoGeografia))
        Me.GrpColonias = New System.Windows.Forms.GroupBox()
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.BtnDelColonia = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddColonia = New Janus.Windows.EditControls.UIButton()
        Me.BtnModColonia = New Janus.Windows.EditControls.UIButton()
        Me.GridColonias = New Janus.Windows.GridEX.GridEX()
        Me.GrpEstado = New System.Windows.Forms.GroupBox()
        Me.BtnDelEstado = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddEstado = New Janus.Windows.EditControls.UIButton()
        Me.BtnModEstado = New Janus.Windows.EditControls.UIButton()
        Me.GridEstados = New Janus.Windows.GridEX.GridEX()
        Me.GrpMnpios = New System.Windows.Forms.GroupBox()
        Me.BtnDelMnpio = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddMnpio = New Janus.Windows.EditControls.UIButton()
        Me.BtnModMnpio = New Janus.Windows.EditControls.UIButton()
        Me.GridMnpios = New Janus.Windows.GridEX.GridEX()
        Me.cmbPais = New Selling.StoreCombo()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.GrpColonias.SuspendLayout()
        CType(Me.GridColonias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpEstado.SuspendLayout()
        CType(Me.GridEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMnpios.SuspendLayout()
        CType(Me.GridMnpios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpColonias
        '
        Me.GrpColonias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpColonias.Controls.Add(Me.btnImportar)
        Me.GrpColonias.Controls.Add(Me.BtnDelColonia)
        Me.GrpColonias.Controls.Add(Me.BtnAddColonia)
        Me.GrpColonias.Controls.Add(Me.BtnModColonia)
        Me.GrpColonias.Controls.Add(Me.GridColonias)
        Me.GrpColonias.Location = New System.Drawing.Point(7, 312)
        Me.GrpColonias.Name = "GrpColonias"
        Me.GrpColonias.Size = New System.Drawing.Size(649, 169)
        Me.GrpColonias.TabIndex = 10
        Me.GrpColonias.TabStop = False
        Me.GrpColonias.Text = "Asentamiento"
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportar.Location = New System.Drawing.Point(553, 122)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(90, 37)
        Me.btnImportar.TabIndex = 159
        Me.btnImportar.Text = "Existencia"
        Me.btnImportar.ToolTipText = "Importar existencia"
        Me.btnImportar.Visible = False
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDelColonia
        '
        Me.BtnDelColonia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelColonia.Image = CType(resources.GetObject("BtnDelColonia.Image"), System.Drawing.Image)
        Me.BtnDelColonia.Location = New System.Drawing.Point(553, 86)
        Me.BtnDelColonia.Name = "BtnDelColonia"
        Me.BtnDelColonia.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelColonia.TabIndex = 17
        Me.BtnDelColonia.Text = "&Eliminar"
        Me.BtnDelColonia.ToolTipText = "Elimina asentamiento o colonia seleccionada"
        Me.BtnDelColonia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddColonia
        '
        Me.BtnAddColonia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddColonia.Image = CType(resources.GetObject("BtnAddColonia.Image"), System.Drawing.Image)
        Me.BtnAddColonia.Location = New System.Drawing.Point(553, 15)
        Me.BtnAddColonia.Name = "BtnAddColonia"
        Me.BtnAddColonia.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddColonia.TabIndex = 16
        Me.BtnAddColonia.Text = "&Agregar "
        Me.BtnAddColonia.ToolTipText = "Agrega nuevo asentamiento o colonia"
        Me.BtnAddColonia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModColonia
        '
        Me.BtnModColonia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModColonia.Image = CType(resources.GetObject("BtnModColonia.Image"), System.Drawing.Image)
        Me.BtnModColonia.Location = New System.Drawing.Point(553, 50)
        Me.BtnModColonia.Name = "BtnModColonia"
        Me.BtnModColonia.Size = New System.Drawing.Size(90, 30)
        Me.BtnModColonia.TabIndex = 14
        Me.BtnModColonia.Text = "&Modifica"
        Me.BtnModColonia.ToolTipText = "Modifica asentamiento o colonia seleccionada"
        Me.BtnModColonia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridColonias
        '
        Me.GridColonias.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridColonias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridColonias.ColumnAutoResize = True
        Me.GridColonias.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridColonias.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridColonias.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridColonias.Location = New System.Drawing.Point(7, 15)
        Me.GridColonias.Name = "GridColonias"
        Me.GridColonias.RecordNavigator = True
        Me.GridColonias.Size = New System.Drawing.Size(540, 146)
        Me.GridColonias.TabIndex = 2
        Me.GridColonias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpEstado
        '
        Me.GrpEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEstado.Controls.Add(Me.BtnDelEstado)
        Me.GrpEstado.Controls.Add(Me.BtnAddEstado)
        Me.GrpEstado.Controls.Add(Me.BtnModEstado)
        Me.GrpEstado.Controls.Add(Me.GridEstados)
        Me.GrpEstado.Location = New System.Drawing.Point(7, 30)
        Me.GrpEstado.Name = "GrpEstado"
        Me.GrpEstado.Size = New System.Drawing.Size(649, 141)
        Me.GrpEstado.TabIndex = 8
        Me.GrpEstado.TabStop = False
        Me.GrpEstado.Text = "Entidades"
        '
        'BtnDelEstado
        '
        Me.BtnDelEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelEstado.Image = CType(resources.GetObject("BtnDelEstado.Image"), System.Drawing.Image)
        Me.BtnDelEstado.Location = New System.Drawing.Point(553, 87)
        Me.BtnDelEstado.Name = "BtnDelEstado"
        Me.BtnDelEstado.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelEstado.TabIndex = 15
        Me.BtnDelEstado.Text = "&Eliminar"
        Me.BtnDelEstado.ToolTipText = "Elimina entidad o estado seleccionado"
        Me.BtnDelEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddEstado
        '
        Me.BtnAddEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddEstado.Image = CType(resources.GetObject("BtnAddEstado.Image"), System.Drawing.Image)
        Me.BtnAddEstado.Location = New System.Drawing.Point(553, 15)
        Me.BtnAddEstado.Name = "BtnAddEstado"
        Me.BtnAddEstado.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddEstado.TabIndex = 14
        Me.BtnAddEstado.Text = "&Agregar "
        Me.BtnAddEstado.ToolTipText = "Agrega nueva entidad o estado"
        Me.BtnAddEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModEstado
        '
        Me.BtnModEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModEstado.Image = CType(resources.GetObject("BtnModEstado.Image"), System.Drawing.Image)
        Me.BtnModEstado.Location = New System.Drawing.Point(553, 51)
        Me.BtnModEstado.Name = "BtnModEstado"
        Me.BtnModEstado.Size = New System.Drawing.Size(90, 30)
        Me.BtnModEstado.TabIndex = 13
        Me.BtnModEstado.Text = "&Modifica"
        Me.BtnModEstado.ToolTipText = "Modifica entidad o estado seleccionado"
        Me.BtnModEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEstados
        '
        Me.GridEstados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEstados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEstados.ColumnAutoResize = True
        Me.GridEstados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEstados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEstados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEstados.Location = New System.Drawing.Point(7, 15)
        Me.GridEstados.Name = "GridEstados"
        Me.GridEstados.RecordNavigator = True
        Me.GridEstados.Size = New System.Drawing.Size(540, 119)
        Me.GridEstados.TabIndex = 1
        Me.GridEstados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpMnpios
        '
        Me.GrpMnpios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMnpios.Controls.Add(Me.BtnDelMnpio)
        Me.GrpMnpios.Controls.Add(Me.BtnAddMnpio)
        Me.GrpMnpios.Controls.Add(Me.BtnModMnpio)
        Me.GrpMnpios.Controls.Add(Me.GridMnpios)
        Me.GrpMnpios.Location = New System.Drawing.Point(7, 171)
        Me.GrpMnpios.Name = "GrpMnpios"
        Me.GrpMnpios.Size = New System.Drawing.Size(649, 141)
        Me.GrpMnpios.TabIndex = 15
        Me.GrpMnpios.TabStop = False
        Me.GrpMnpios.Text = "Municipios"
        '
        'BtnDelMnpio
        '
        Me.BtnDelMnpio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelMnpio.Image = CType(resources.GetObject("BtnDelMnpio.Image"), System.Drawing.Image)
        Me.BtnDelMnpio.Location = New System.Drawing.Point(553, 87)
        Me.BtnDelMnpio.Name = "BtnDelMnpio"
        Me.BtnDelMnpio.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelMnpio.TabIndex = 17
        Me.BtnDelMnpio.Text = "&Eliminar"
        Me.BtnDelMnpio.ToolTipText = "Elimina municipio seleccionado"
        Me.BtnDelMnpio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddMnpio
        '
        Me.BtnAddMnpio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddMnpio.Image = CType(resources.GetObject("BtnAddMnpio.Image"), System.Drawing.Image)
        Me.BtnAddMnpio.Location = New System.Drawing.Point(553, 15)
        Me.BtnAddMnpio.Name = "BtnAddMnpio"
        Me.BtnAddMnpio.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddMnpio.TabIndex = 16
        Me.BtnAddMnpio.Text = "&Agregar "
        Me.BtnAddMnpio.ToolTipText = "Agrega nuevo municipio"
        Me.BtnAddMnpio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModMnpio
        '
        Me.BtnModMnpio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModMnpio.Image = CType(resources.GetObject("BtnModMnpio.Image"), System.Drawing.Image)
        Me.BtnModMnpio.Location = New System.Drawing.Point(553, 51)
        Me.BtnModMnpio.Name = "BtnModMnpio"
        Me.BtnModMnpio.Size = New System.Drawing.Size(90, 30)
        Me.BtnModMnpio.TabIndex = 14
        Me.BtnModMnpio.Text = "&Modifica"
        Me.BtnModMnpio.ToolTipText = "Modifica municipio seleccionado"
        Me.BtnModMnpio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMnpios
        '
        Me.GridMnpios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMnpios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMnpios.ColumnAutoResize = True
        Me.GridMnpios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMnpios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMnpios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMnpios.Location = New System.Drawing.Point(7, 15)
        Me.GridMnpios.Name = "GridMnpios"
        Me.GridMnpios.RecordNavigator = True
        Me.GridMnpios.Size = New System.Drawing.Size(540, 119)
        Me.GridMnpios.TabIndex = 1
        Me.GridMnpios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbPais
        '
        Me.cmbPais.Location = New System.Drawing.Point(53, 4)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(220, 21)
        Me.cmbPais.TabIndex = 52
        '
        'LblPais
        '
        Me.LblPais.Location = New System.Drawing.Point(11, 7)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(36, 15)
        Me.LblPais.TabIndex = 54
        Me.LblPais.Text = "País"
        '
        'FrmMtoGeografia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 493)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.LblPais)
        Me.Controls.Add(Me.GrpMnpios)
        Me.Controls.Add(Me.GrpColonias)
        Me.Controls.Add(Me.GrpEstado)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 483)
        Me.Name = "FrmMtoGeografia"
        Me.Text = "Geografía"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpColonias.ResumeLayout(False)
        CType(Me.GridColonias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpEstado.ResumeLayout(False)
        CType(Me.GridEstados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMnpios.ResumeLayout(False)
        CType(Me.GridMnpios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sEstadoSelected, sNombreEstado As String
    Private sMnpioSelected, sNombreMnpio As String
    Private sColoniaSelected, sNombreColonia, CodigoPostal As String
    Private iStateEstado, iStateMnpio, iStateColonia, iAsentamiento As Integer

    Private Cargado As Boolean = False


    Private Sub FrmMtoModulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        With Me.cmbPais
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        Cargado = True

        ModPOS.ActualizaGrid(True, Me.GridEstados, "sp_muestra_estados", "@Pais", cmbPais.SelectedValue)
        Me.GridEstados.RootTable.Columns("ID").Visible = False
        Me.GridEstados.RootTable.Columns("ID_Estado").Visible = False

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ModificaEstado()
        If Me.sEstadoSelected <> "" Then
            If ModPOS.Geografia Is Nothing Then


                ModPOS.Geografia = New FrmGeografia

                With ModPOS.Geografia
                    .Padre = "Modificar"
                    .sTipo = "Estado"
                    .GrpActividad.Text = "Editar Estado"
                    .sClave = sEstadoSelected
                    .sNombre = sNombreEstado
                    .iEstado = iStateEstado
                    .iPais = cmbPais.SelectedValue
                End With

            End If
            With ModPOS.Geografia
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If

    End Sub

    Private Sub ModificaMnpio()
        If Me.sMnpioSelected <> "" Then
            If ModPOS.Geografia Is Nothing Then


                ModPOS.Geografia = New FrmGeografia

                With ModPOS.Geografia
                    .Padre = "Modificar"
                    .sTipo = "Mnpio"
                    .GrpActividad.Text = "Editar Municipio"
                    .sClave = sMnpioSelected
                    .sNombre = sNombreMnpio
                    .iEstado = iStateMnpio
                    .c_estado = sEstadoSelected
                End With

            End If
            With ModPOS.Geografia
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If

    End Sub

    Private Sub ModificaColonia()
        If Me.sColoniaSelected <> "" Then
            If ModPOS.Geografia Is Nothing Then


                ModPOS.Geografia = New FrmGeografia

                With ModPOS.Geografia
                    .Padre = "Modificar"
                    .sTipo = "Colonia"
                    .GrpActividad.Text = "Editar Asentamiento"
                    .sClave = sColoniaSelected
                    .sNombre = sNombreColonia
                    .iEstado = iStateColonia

                    .c_estado = sEstadoSelected
                    .c_mnpio = sMnpioSelected
                    .sCodigoPostal = CodigoPostal
                    .c_asentamiento = iAsentamiento
                End With

            End If
            With ModPOS.Geografia
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        End If

    End Sub

    Private Sub FrmMtoModulos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoGeografia.Dispose()
        ModPOS.MtoGeografia = Nothing

    End Sub

    Private Sub GridEstados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEstados.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModEstado.PerformClick()
        End If
    End Sub

    Private Sub GridEstados_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstados.SelectionChanged
        If Not Me.GridEstados.GetValue(0) Is Nothing Then

            BtnModEstado.Enabled = True
            BtnDelEstado.Enabled = True
            BtnModMnpio.Enabled = True
            BtnDelMnpio.Enabled = True
            BtnModColonia.Enabled = True
            BtnDelColonia.Enabled = True

            sEstadoSelected = GridEstados.GetValue("ID")
            sNombreEstado = GridEstados.GetValue("Nombre")
            iStateEstado = CInt(GridEstados.GetValue("ID_Estado"))
            ModPOS.ActualizaGrid(True, Me.GridMnpios, "sp_muestra_mnpios", "@Estado", sEstadoSelected)
            Me.GridMnpios.RootTable.Columns("ID").Visible = False
            Me.GridMnpios.RootTable.Columns("ID_Estado").Visible = False

        Else
            sEstadoSelected = ""
            BtnModEstado.Enabled = False
            BtnDelEstado.Enabled = False
            BtnModMnpio.Enabled = False
            BtnDelMnpio.Enabled = False
            BtnModColonia.Enabled = False
            BtnDelColonia.Enabled = False
            ModPOS.ActualizaGrid(True, Me.GridMnpios, "sp_muestra_mnpios", "@Estado", sEstadoSelected)
            Me.GridMnpios.RootTable.Columns("ID").Visible = False
            Me.GridMnpios.RootTable.Columns("ID_Estado").Visible = False

        End If

        If GridMnpios.RowCount < 1 Then
            sMnpioSelected = ""
            BtnModColonia.Enabled = False
            BtnDelColonia.Enabled = False
            ModPOS.ActualizaGrid(True, Me.GridColonias, "sp_muestra_colonias", "@Estado", sEstadoSelected, "@Mnpio", sMnpioSelected)
            Me.GridColonias.RootTable.Columns("ID").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Estado").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False
        End If
    End Sub

    Private Sub GridMnpios_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridMnpios.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModMnpio.PerformClick()
        End If
    End Sub

    Private Sub GridMnpios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMnpios.SelectionChanged
        If Not Me.GridMnpios.GetValue(0) Is Nothing Then
            BtnModMnpio.Enabled = True
            BtnDelMnpio.Enabled = True
            BtnModColonia.Enabled = True
            BtnDelColonia.Enabled = True

            sMnpioSelected = GridMnpios.GetValue("ID")
            sNombreMnpio = GridMnpios.GetValue("Nombre")
            iStateMnpio = GridMnpios.GetValue("ID_Estado")
            ModPOS.ActualizaGrid(True, Me.GridColonias, "sp_muestra_colonias", "@Estado", sEstadoSelected, "@Mnpio", sMnpioSelected)
            Me.GridColonias.RootTable.Columns("ID").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Estado").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False

        Else
            sMnpioSelected = ""
            BtnModMnpio.Enabled = False
            BtnDelMnpio.Enabled = False
            BtnModColonia.Enabled = False
            BtnDelColonia.Enabled = False
            ModPOS.ActualizaGrid(True, Me.GridColonias, "sp_muestra_colonias", "@Estado", sEstadoSelected, "@Mnpio", sMnpioSelected)
            Me.GridColonias.RootTable.Columns("ID").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Estado").Visible = False
            Me.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False

        End If
    End Sub

    Private Sub GridColonias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridColonias.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModColonia.PerformClick()
        End If
    End Sub

    Private Sub GridColonias_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridColonias.SelectionChanged
        If Not Me.GridColonias.GetValue(0) Is Nothing Then
            BtnModColonia.Enabled = True
            BtnDelColonia.Enabled = True
            sColoniaSelected = GridColonias.GetValue("ID")
            sNombreColonia = GridColonias.GetValue("Nombre")
            iStateColonia = GridColonias.GetValue("ID_Estado")
            CodigoPostal = GridColonias.GetValue("C.P.")
            iAsentamiento = GridColonias.GetValue("ID_Asentamiento")
        Else
            sColoniaSelected = ""
            BtnModColonia.Enabled = False
            BtnDelColonia.Enabled = False
        End If

    End Sub

    Private Sub BtnModEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModEstado.Click
        ModificaEstado()
    End Sub

    Private Sub BtnModMnpio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModMnpio.Click
        ModificaMnpio()
    End Sub

    Private Sub BtnModColonia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModColonia.Click
        ModificaColonia()
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged
        If Cargado = True AndAlso Not cmbPais.SelectedValue Is Nothing Then
            ModPOS.ActualizaGrid(True, Me.GridEstados, "sp_muestra_estados", "@Pais", cmbPais.SelectedValue)
            Me.GridEstados.RootTable.Columns("ID").Visible = False
            Me.GridEstados.RootTable.Columns("ID_Estado").Visible = False

        End If

    End Sub

    Private Sub GridEstados_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEstados.DoubleClick
        ModificaEstado()
    End Sub

    Private Sub GridMnpios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMnpios.DoubleClick
        ModificaMnpio()
    End Sub

    Private Sub GridColonias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridColonias.DoubleClick
        ModificaColonia()
    End Sub

    Private Sub BtnDelEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelEstado.Click
        If sEstadoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Entidad :" & sNombreEstado, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_geografia", "@Tipo", 1, "@Clave", sEstadoSelected, "@Clave2", "", "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridEstados, "sp_muestra_estados", "@Pais", cmbPais.SelectedValue)
                    Me.GridEstados.RootTable.Columns("ID").Visible = False
                    Me.GridEstados.RootTable.Columns("ID_Estado").Visible = False
            End Select
        End If

    End Sub

    Private Sub BtnDelMnpio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelMnpio.Click
        If sMnpioSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Municipio :" & sNombreMnpio, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_geografia", "@Tipo", 2, "@Clave", sEstadoSelected, "@Clave2", sMnpioSelected, "@Usuario", ModPOS.UsuarioActual)
                    ModPOS.ActualizaGrid(True, Me.GridMnpios, "sp_muestra_mnpios", "@Estado", sEstadoSelected)
                    Me.GridMnpios.RootTable.Columns("ID").Visible = False
                    Me.GridMnpios.RootTable.Columns("ID_Estado").Visible = False
            End Select
        End If

    End Sub

    Private Sub BtnDelColonia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelColonia.Click
        If sColoniaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Colonia :" & sNombreColonia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_elimina_geografia", "@Tipo", 3, "@Clave", sColoniaSelected, "@Clave2", "", "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridColonias, "sp_muestra_colonias", "@Estado", sEstadoSelected, "@Mnpio", sMnpioSelected)
                    Me.GridColonias.RootTable.Columns("ID").Visible = False
                    Me.GridColonias.RootTable.Columns("ID_Estado").Visible = False
                    Me.GridColonias.RootTable.Columns("ID_Asentamiento").Visible = False
            End Select
        End If

    End Sub

    Private Sub BtnAddEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddEstado.Click
        If ModPOS.Geografia Is Nothing Then


            ModPOS.Geografia = New FrmGeografia

            With ModPOS.Geografia
                .Padre = "Agregar"
                .sTipo = "Estado"
                .GrpActividad.Text = "Agregar Estado"
                .sClave = ""
                .sNombre = ""
                .iEstado = 1
                .ChkEstado.Enabled = False
                .iPais = cmbPais.SelectedValue
            End With

        End If
        With ModPOS.Geografia
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub BtnAddMnpio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddMnpio.Click
        If sEstadoSelected <> "" Then
            If ModPOS.Geografia Is Nothing Then


                ModPOS.Geografia = New FrmGeografia

                With ModPOS.Geografia
                    .Padre = "Agregar"
                    .sTipo = "Mnpio"
                    .GrpActividad.Text = "Agregar Municipio"
                    .sClave = ""
                    .sNombre = ""
                    .iEstado = 1
                    .ChkEstado.Enabled = False
                    .c_estado = sEstadoSelected
                End With

            End If
            With ModPOS.Geografia
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        Else
            MessageBox.Show("No es posible agregar un registro ya que deben estar seleccionado un Estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnAddColonia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddColonia.Click

        If sEstadoSelected <> "" And sMnpioSelected <> "" Then
            If ModPOS.Geografia Is Nothing Then


                ModPOS.Geografia = New FrmGeografia

                With ModPOS.Geografia
                    .Padre = "Agregar"
                    .sTipo = "Colonia"
                    .GrpActividad.Text = "Agegar Asentamiento"
                    .sClave = ""
                    .sNombre = ""
                    .iEstado = 1
                    .ChkEstado.Enabled = False

                    .c_estado = sEstadoSelected
                    .c_mnpio = sMnpioSelected
                    .sCodigoPostal = ""
                    .c_asentamiento = 0
                End With

            End If
            With ModPOS.Geografia
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With

        Else
            MessageBox.Show("No es posible agregar un registro ya que deben estar seleccionado un Municipio y Estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de XML|*.XML"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo XML"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                Dim oXml As New Xml.XmlDocument()
                oXml.Load(openDlg.FileName)


            End If
        Catch ex As Exception

        End Try
     
    End Sub
End Class
