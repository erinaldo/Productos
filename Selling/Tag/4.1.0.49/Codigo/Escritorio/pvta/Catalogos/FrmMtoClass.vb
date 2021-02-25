Public Class FrmMtoClass
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
    Friend WithEvents GridClasificaciones As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoClass))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpBank = New System.Windows.Forms.GroupBox()
        Me.GridClasificaciones = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpBank.SuspendLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(270, 336)
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
        Me.BtnModificar.Location = New System.Drawing.Point(462, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar Clasificación seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(366, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina Clasificación seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpBank
        '
        Me.GrpBank.Controls.Add(Me.GridClasificaciones)
        Me.GrpBank.Controls.Add(Me.BtnAgregar)
        Me.GrpBank.Controls.Add(Me.BtnModificar)
        Me.GrpBank.Controls.Add(Me.BtnCancelar)
        Me.GrpBank.Controls.Add(Me.BtnEliminar)
        Me.GrpBank.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBank.Location = New System.Drawing.Point(0, 0)
        Me.GrpBank.Name = "GrpBank"
        Me.GrpBank.Size = New System.Drawing.Size(656, 380)
        Me.GrpBank.TabIndex = 11
        Me.GrpBank.TabStop = False
        Me.GrpBank.Text = "Clasificaciones"
        '
        'GridClasificaciones
        '
        Me.GridClasificaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClasificaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClasificaciones.ColumnAutoResize = True
        Me.GridClasificaciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClasificaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClasificaciones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClasificaciones.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridClasificaciones.Location = New System.Drawing.Point(6, 15)
        Me.GridClasificaciones.Name = "GridClasificaciones"
        Me.GridClasificaciones.RecordNavigator = True
        Me.GridClasificaciones.Size = New System.Drawing.Size(642, 315)
        Me.GridClasificaciones.TabIndex = 1
        Me.GridClasificaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(558, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva Clasificación"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoClass
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpBank)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoClass"
        Me.Text = "Mantenimiento de Clasificaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpBank.ResumeLayout(False)
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private iClassSelected As Integer
    Private sNombre As String
    Private iTipo As Integer

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridClasificaciones, "sp_muestra_clases", "@COMClave", ModPOS.CompanyActual)
        Me.GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
        Me.GridClasificaciones.RootTable.Columns("TClasificacion").Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GridClasificaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridClasificaciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub


    Private Sub GridClasificaciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClasificaciones.SelectionChanged
        If Not GridClasificaciones.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.iClassSelected = GridClasificaciones.GetValue("CLAClave")
            Me.sNombre = GridClasificaciones.GetValue("Clave")
            Me.iTipo = GridClasificaciones.GetValue("TClasificacion")
        Else
            Me.iClassSelected = -1
            Me.sNombre = ""
            iTipo = -1
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False


        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Clase Is Nothing Then
            ModPOS.Clase = New FrmClass
            With ModPOS.Clase
                .Text = "Agregar Clasificación"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Clase.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Clase.Show()
        ModPOS.Clase.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarClass()
    End Sub

    Public Sub modificarClass()
        If iClassSelected <> -1 Then

            If ModPOS.Clase Is Nothing Then

                ModPOS.Clase = New FrmClass

                With ModPOS.Clase
                    .Text = "Modificar Clasificación"
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .CmbTipo.Enabled = False


                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_clase", "@Clase", Me.iClassSelected)

                    .CLAClavePadre = dt.Rows(0)("CLAClavePadre")
                    .CLAClave = dt.Rows(0)("CLAClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Estado = dt.Rows(0)("Estado")
                    .Tipo = dt.Rows(0)("TClasificacion")
                    .Grupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))
                    .Nivel = IIf(dt.Rows(0)("Nivel").GetType.Name = "DBNull", 0, dt.Rows(0)("Nivel"))

                    dt.Dispose()

                End With
            End If
            ModPOS.Clase.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Clase.Show()
            ModPOS.Clase.BringToFront()
        End If
    End Sub

    Private Sub GridClasificaciones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridClasificaciones.DoubleClick
        modificarClass()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If iClassSelected <> -1 Then
            Beep()

            Select Case MessageBox.Show("Se eliminara la Clasificación Tipo: " & GridClasificaciones.GetValue("Tipo") & ", Clave: " & sNombre & " Con todo sus sub clases contenidas", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_clase_vacia", "@CLAClave", iClassSelected, "@Tipo", iTipo) <> 0 Then
                        MessageBox.Show("La clasificación seleccionada no puede ser eliminada ya que existen miembros asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        ModPOS.Ejecuta("sp_elimina_clase", "@CLAClave", iClassSelected, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridClasificaciones, "sp_muestra_clases", "@COMClave", ModPOS.CompanyActual)

                        Me.GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
                        Me.GridClasificaciones.RootTable.Columns("TClasificacion").Visible = False

                    End If

                Case DialogResult.No

            End Select

        End If
    End Sub

    Private Sub FrmMtoClass_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoClass.Dispose()
        ModPOS.MtoClass = Nothing
    End Sub

   

End Class
