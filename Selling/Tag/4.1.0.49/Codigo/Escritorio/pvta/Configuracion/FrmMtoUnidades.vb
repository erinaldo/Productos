Public Class FrmMtoUnidades
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
    Friend WithEvents GridUnidades As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoUnidades))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades = New System.Windows.Forms.GroupBox()
        Me.GridUnidades = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpUnidades.SuspendLayout()
        CType(Me.GridUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnModificar.ToolTipText = "Modificar unidad seleccionada"
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
        Me.BtnEliminar.ToolTipText = "Eliminar unidad seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Controls.Add(Me.BtnCancelar)
        Me.GrpUnidades.Controls.Add(Me.GridUnidades)
        Me.GrpUnidades.Controls.Add(Me.BtnEliminar)
        Me.GrpUnidades.Controls.Add(Me.BtnModificar)
        Me.GrpUnidades.Controls.Add(Me.BtnAgregar)
        Me.GrpUnidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpUnidades.Location = New System.Drawing.Point(0, 0)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(656, 380)
        Me.GrpUnidades.TabIndex = 11
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Unidades"
        '
        'GridUnidades
        '
        Me.GridUnidades.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridUnidades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUnidades.ColumnAutoResize = True
        Me.GridUnidades.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridUnidades.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUnidades.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridUnidades.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridUnidades.Location = New System.Drawing.Point(7, 15)
        Me.GridUnidades.Name = "GridUnidades"
        Me.GridUnidades.RecordNavigator = True
        Me.GridUnidades.Size = New System.Drawing.Size(643, 315)
        Me.GridUnidades.TabIndex = 1
        Me.GridUnidades.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.BtnAgregar.ToolTipText = "Agregar nueva unidad"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoUnidades
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoUnidades"
        Me.Text = "Mantenimiento de Unidades"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.GridUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sUnidadSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoUnidades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(True, Me.GridUnidades, "sp_muestra_unidades", Nothing)
        Me.GridUnidades.RootTable.Columns("ID").Visible = False
        Me.GridUnidades.RootTable.Columns("ID_Estado").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridUnidades_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridUnidades.SelectionChanged
        If Not GridUnidades.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sUnidadSelected = GridUnidades.GetValue(0)
            Me.sNombre = GridUnidades.GetValue("Abreviatura")
        Else
            Me.sUnidadSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Unidad Is Nothing Then
            ModPOS.Unidad = New FrmUnidad
            With ModPOS.Unidad
                .Text = "Agregar Unidad"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Unidad.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Unidad.Show()
        ModPOS.Unidad.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaUnidad()
    End Sub

    Public Sub modificaUnidad()
        If sUnidadSelected <> "" Then

            If ModPOS.Unidad Is Nothing Then

                ModPOS.Unidad = New FrmUnidad
                With ModPOS.Unidad
                    .Text = "Modificar Unidad"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtAbreviatura.ReadOnly = True


                    .UNDClave = GridUnidades.GetValue("ID")
                    .Abreviatura = GridUnidades.GetValue("Abreviatura")
                    .Nombre = GridUnidades.GetValue("Nombre")
                    .Estado = GridUnidades.GetValue("ID_Estado")
                    .Orden = IIf(GridUnidades.GetValue("Orden").GetType.Name = "DBNull", 0, GridUnidades.GetValue("Orden"))
                    .ClaveSAT = IIf(GridUnidades.GetValue("ClaveSAT").GetType.Name = "DBNull", "", GridUnidades.GetValue("ClaveSAT"))
                End With
            End If

            ModPOS.Unidad.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Unidad.Show()
            ModPOS.Unidad.BringToFront()

        End If
    End Sub

    Private Sub GridImpuestos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridUnidades.DoubleClick
        modificaUnidad()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sUnidadSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Unidad  :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_unidad_vacia", "@Unidad", CStr(sUnidadSelected)) <> 0 Then
                        MessageBox.Show("La unidad seleccionada no puede ser eliminada ya que existen productos con dicha unidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        ModPOS.Ejecuta("sp_elimina_unidad", "@Unidad", sUnidadSelected, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridUnidades, "sp_muestra_unidades", Nothing)
                        Me.GridUnidades.RootTable.Columns("ID").Visible = False
                        Me.GridUnidades.RootTable.Columns("ID_Estado").Visible = False

                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoUnidades_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoUnidades.Dispose()
        ModPOS.MtoUnidades = Nothing

    End Sub
End Class
