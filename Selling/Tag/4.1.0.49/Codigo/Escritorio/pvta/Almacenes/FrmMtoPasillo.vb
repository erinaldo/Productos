Public Class FrmMtoPasillo
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
    Friend WithEvents GrpPasillos As System.Windows.Forms.GroupBox
    Friend WithEvents GridPasillos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPasillo))
        Me.GrpPasillos = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GridPasillos = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPasillos.SuspendLayout()
        CType(Me.GridPasillos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillos
        '
        Me.GrpPasillos.Controls.Add(Me.CmbSucursal)
        Me.GrpPasillos.Controls.Add(Me.Label1)
        Me.GrpPasillos.Controls.Add(Me.CmbAlmacen)
        Me.GrpPasillos.Controls.Add(Me.LblAlmacen)
        Me.GrpPasillos.Controls.Add(Me.BtnCancelar)
        Me.GrpPasillos.Controls.Add(Me.BtnEliminar)
        Me.GrpPasillos.Controls.Add(Me.BtnModificar)
        Me.GrpPasillos.Controls.Add(Me.GridPasillos)
        Me.GrpPasillos.Controls.Add(Me.BtnAgregar)
        Me.GrpPasillos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPasillos.Location = New System.Drawing.Point(0, 0)
        Me.GrpPasillos.Name = "GrpPasillos"
        Me.GrpPasillos.Size = New System.Drawing.Size(752, 406)
        Me.GrpPasillos.TabIndex = 4
        Me.GrpPasillos.TabStop = False
        Me.GrpPasillos.Text = "Pasillos"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(75, 17)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(262, 21)
        Me.CmbSucursal.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Sucursal"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(479, 17)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(266, 21)
        Me.CmbAlmacen.TabIndex = 46
        '
        'LblAlmacen
        '
        Me.LblAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAlmacen.Location = New System.Drawing.Point(426, 20)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(84, 22)
        Me.LblAlmacen.TabIndex = 45
        Me.LblAlmacen.Text = "Almacén"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(368, 364)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 8
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(464, 364)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina pasillo seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(560, 364)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica pasillo seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPasillos
        '
        Me.GridPasillos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPasillos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPasillos.ColumnAutoResize = True
        Me.GridPasillos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPasillos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPasillos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPasillos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPasillos.Location = New System.Drawing.Point(7, 46)
        Me.GridPasillos.Name = "GridPasillos"
        Me.GridPasillos.RecordNavigator = True
        Me.GridPasillos.Size = New System.Drawing.Size(739, 312)
        Me.GridPasillos.TabIndex = 2
        Me.GridPasillos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(656, 364)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 9
        Me.BtnAgregar.Text = "&Nuevo"
        Me.BtnAgregar.ToolTipText = "Crear nuevo pasillo"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPasillo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(752, 406)
        Me.Controls.Add(Me.GrpPasillos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPasillo"
        Me.Text = "Mantenimiento de Pasillos"
        Me.GrpPasillos.ResumeLayout(False)
        CType(Me.GridPasillos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPasilloSelected As String
    Private sReferencia As String
    Private bload As Boolean = False


    Public Sub refrescaGrid()

        Dim sALMClave As String

        If CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        Else
            sALMClave = CmbAlmacen.SelectedValue
        End If

        ModPOS.ActualizaGrid(True, GridPasillos, "sp_muestra_pasillos", "@ALMClave", sALMClave)
        Me.GridPasillos.RootTable.Columns("ID").Visible = False


    End Sub

    Private Sub FrmMtoPasillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almsuc"
            .NombreParametro1 = "SUCClave"
            .Parametro1 = CmbSucursal.SelectedValue
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If



        bLoad = True

        refrescaGrid()



        
    End Sub

    Private Sub FrmMtoPasillo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPasillo.Dispose()
        ModPOS.MtoPasillo = Nothing
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not CmbAlmacen.SelectedValue Is Nothing AndAlso Not CmbSucursal.SelectedValue Is Nothing Then
            If ModPOS.Pasillo Is Nothing Then
                ModPOS.Pasillo = New FrmPasillo
                With ModPOS.Pasillo
                    .Text = "Agregar Pasillo"
                    .cmbTipoEstado.Enabled = False
                    .Padre = "Agregar"
                    .ALMClave = CmbAlmacen.SelectedValue
                    .SUCClave = CmbSucursal.SelectedValue
                End With
            End If
            With ModPOS.Pasillo
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With
        Else
            MessageBox.Show("Debe seleccionar una Sucursal y Almacén validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub GridPasillos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPasillos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub


    Private Sub GridPasillos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPasillos.SelectionChanged
        If Not Me.GridPasillos.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPasilloSelected = GridPasillos.GetValue("ID")
            Me.sReferencia = GridPasillos.GetValue("Clave")
        Else
            Me.sPasilloSelected = ""
            Me.sReferencia = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub GridPasillos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPasillos.DoubleClick
        Modificar()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara el Pasillo :" & sReferencia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Dim Con As String = ModPOS.BDConexion
                If ModPOS.SiExite(Con, "sp_pasillo_vacio", "@Pasillo", sPasilloSelected) <> 0 Then
                    MessageBox.Show("El Pasillo seleccionado no puede ser eliminado ya que existen estructuras asignadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    ModPOS.Elimina_Pasillo(sPasilloSelected)

                    refrescaGrid()


                End If

            Case DialogResult.No

        End Select

    End Sub

    Private Sub Modificar()
        If Me.sPasilloSelected <> "" AndAlso Not CmbSucursal.SelectedValue Is Nothing Then
            If ModPOS.Pasillo Is Nothing Then

                ModPOS.Pasillo = New FrmPasillo
                With ModPOS.Pasillo
                    .Text = "Modificar Pasillo"
                    .MdiParent = ModPOS.Principal
                    .StartPosition = FormStartPosition.CenterScreen
                    .cmbTipoEstado.Enabled = False
                    .Padre = "Modificar"
                    .SUCClave = CmbSucursal.SelectedValue
                End With



                Dim dt As DataTable

                dt = ModPOS.Recupera_Tabla("sp_recupera_pasillo", "@Pasillo", Me.sPasilloSelected)

                With ModPOS.Pasillo
                    .PASClave = dt.Rows(0)("PASClave")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .Referencia = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Estado = dt.Rows(0)("Estado")
                End With
                dt.Dispose()

            End If
            With ModPOS.Pasillo
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
                .BringToFront()
            End With

        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bload Then


            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With

        End If
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bload AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            refrescaGrid()
        End If
    End Sub
End Class
