Imports System.Data.SqlClient

Public Class FrmMtoArea
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
    Friend WithEvents GrpAreas As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAsignar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAreas As Janus.Windows.GridEX.GridEX
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents LblAlmacen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoArea))
        Me.GrpAreas = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.LblAlmacen = New System.Windows.Forms.Label()
        Me.GridAreas = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAsignar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpAreas.SuspendLayout()
        CType(Me.GridAreas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpAreas
        '
        Me.GrpAreas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAreas.Controls.Add(Me.CmbSucursal)
        Me.GrpAreas.Controls.Add(Me.Label1)
        Me.GrpAreas.Controls.Add(Me.CmbAlmacen)
        Me.GrpAreas.Controls.Add(Me.LblAlmacen)
        Me.GrpAreas.Controls.Add(Me.GridAreas)
        Me.GrpAreas.Location = New System.Drawing.Point(8, 8)
        Me.GrpAreas.Name = "GrpAreas"
        Me.GrpAreas.Size = New System.Drawing.Size(740, 347)
        Me.GrpAreas.TabIndex = 0
        Me.GrpAreas.TabStop = False
        Me.GrpAreas.Text = "Areas"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(74, 16)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(262, 21)
        Me.CmbSucursal.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Sucursal"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(466, 16)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(266, 21)
        Me.CmbAlmacen.TabIndex = 42
        '
        'LblAlmacen
        '
        Me.LblAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblAlmacen.Location = New System.Drawing.Point(413, 19)
        Me.LblAlmacen.Name = "LblAlmacen"
        Me.LblAlmacen.Size = New System.Drawing.Size(84, 22)
        Me.LblAlmacen.TabIndex = 41
        Me.LblAlmacen.Text = "Almacén"
        '
        'GridAreas
        '
        Me.GridAreas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAreas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAreas.ColumnAutoResize = True
        Me.GridAreas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAreas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAreas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAreas.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridAreas.Location = New System.Drawing.Point(8, 46)
        Me.GridAreas.Name = "GridAreas"
        Me.GridAreas.RecordNavigator = True
        Me.GridAreas.Size = New System.Drawing.Size(724, 295)
        Me.GridAreas.TabIndex = 1
        Me.GridAreas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(658, 361)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 0
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nueva area"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(370, 361)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar area seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(562, 361)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 3
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar area seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAsignar
        '
        Me.BtnAsignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAsignar.Icon = CType(resources.GetObject("BtnAsignar.Icon"), System.Drawing.Icon)
        Me.BtnAsignar.Location = New System.Drawing.Point(466, 361)
        Me.BtnAsignar.Name = "BtnAsignar"
        Me.BtnAsignar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAsignar.TabIndex = 4
        Me.BtnAsignar.Text = "A&signar"
        Me.BtnAsignar.ToolTipText = "Asignar estructura al area seleccionada"
        Me.BtnAsignar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(274, 361)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoArea
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(752, 406)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAsignar)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GrpAreas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(664, 407)
        Me.Name = "FrmMtoArea"
        Me.Text = "Mantenimiento de Areas"
        Me.GrpAreas.ResumeLayout(False)
        CType(Me.GridAreas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sAreaSelected As String
    Private sReferencia As String
    Private sNombreArea As String
    Private iColor As Integer
    Private bload As Boolean = False

    Public Sub refrescaGrid()

        Dim sALMClave As String

        If CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        Else
            sALMClave = CmbAlmacen.SelectedValue
        End If

        ModPOS.ActualizaGrid(True, GridAreas, "sp_muestra_areas", "@ALMClave", sALMClave)
        Me.GridAreas.RootTable.Columns("Color").Visible = False
        Me.GridAreas.RootTable.Columns("ID").Visible = False

    End Sub

    Private Sub FrmMtoArea_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPos.MtoArea.Dispose()
        ModPos.MtoArea = Nothing
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            If ModPOS.Areas Is Nothing Then
                ModPOS.Areas = New FrmArea
                ModPOS.Areas.Text = "Agregar Area"
                ModPOS.Areas.MdiParent = ModPOS.Principal
                ModPOS.Areas.Padre = "Agregar"
                ModPOS.Areas.cmbTipoEstado.Enabled = False
                ModPOS.Areas.cmbTipoEstado.Visible = False
                ModPOS.Areas.LblEstado.Visible = False
                ModPOS.Areas.SUCClave = CmbSucursal.SelectedValue
                ModPOS.Areas.ALMClave = CmbAlmacen.SelectedValue
            End If
            ModPOS.Areas.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Areas.Show()
            ModPOS.Areas.BringToFront()
        End If
    End Sub

    Private Sub BtnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsignar.Click
        If Me.sAreaSelected <> "" Then
            If ModPOS.AsignarEstructura Is Nothing Then
                ModPOS.AsignarEstructura = New FrmAsignarEstructura
                ModPOS.AsignarEstructura.StartPosition = FormStartPosition.CenterScreen
                ModPOS.AsignarEstructura.AREClave = Me.sAreaSelected
                ModPOS.AsignarEstructura.TxtClave.Text = Me.sReferencia
                ModPOS.AsignarEstructura.TxtNombre.Text = Me.sNombreArea
                ModPOS.AsignarEstructura.Color = Me.iColor


            End If
            ModPOS.AsignarEstructura.StartPosition = FormStartPosition.CenterScreen
            ModPOS.AsignarEstructura.Show()
            ModPOS.AsignarEstructura.BringToFront()
        End If
    End Sub

    Private Sub FrmMtoArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub GridAreas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridAreas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridAreas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAreas.SelectionChanged
        If Not Me.GridAreas.GetValue(0) Is Nothing Then
          
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.BtnAsignar.Enabled = True
            Me.sAreaSelected = GridAreas.GetValue("ID")
            Me.sReferencia = GridAreas.GetValue("Clave")
            Me.sNombreArea = GridAreas.GetValue("Nombre")
            Me.iColor = GridAreas.GetValue("Color")
        Else
            Me.sAreaSelected = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.BtnAsignar.Enabled = False
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GridAreas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAreas.DoubleClick
        Modificar()
    End Sub


    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara el Area :" & sReferencia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Dim Con As String = ModPos.BDConexion
                If ModPOS.SiExite(Con, "sp_area_vacia", "@Area", sAreaSelected) <> 0 Then
                    MessageBox.Show("El Area seleccionada no puede ser eliminada ya que existen estructuras asignadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    ModPOS.Elimina_Area(sAreaSelected)

                    refrescaGrid()

                End If

            Case DialogResult.No

        End Select


    End Sub

    Private Sub Modificar()
        If Me.sAreaSelected <> "" AndAlso Not CmbSucursal.SelectedValue Is Nothing Then
            If ModPOS.Areas Is Nothing Then

                ModPOS.Areas = New FrmArea
                ModPOS.Areas.Text = "Modificar Area"
                ModPOS.Areas.MdiParent = ModPOS.Principal
                ModPOS.Areas.Padre = "Modificar"

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_area", "@Area", sAreaSelected)

                With ModPOS.Areas
                    .SUCClave = CmbSucursal.SelectedValue
                    .AREClave = dt.Rows(0)("AREClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .ALMClave = IIf(dt.Rows(0)("ALMClave").GetType.Name = "DBNull", "", dt.Rows(0)("ALMClave"))
                    .Tipo = dt.Rows(0)("Tipo")
                    .Color = dt.Rows(0)("Color")
                    .Estado = dt.Rows(0)("Estado")
                    .Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
                End With
                dt.Dispose()

            End If
            ModPOS.Areas.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Areas.Show()
            ModPOS.Areas.BringToFront()

        End If
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
