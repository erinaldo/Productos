Public Class FrmMtoSucursales
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
    Friend WithEvents GridSucursales As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoSucursales))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpSucursales = New System.Windows.Forms.GroupBox
        Me.GridSucursales = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpSucursales.SuspendLayout()
        CType(Me.GridSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(399, 519)
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
        Me.BtnModificar.Location = New System.Drawing.Point(591, 519)
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
        Me.BtnEliminar.Location = New System.Drawing.Point(495, 519)
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
        Me.GrpSucursales.Controls.Add(Me.GridSucursales)
        Me.GrpSucursales.Controls.Add(Me.BtnEliminar)
        Me.GrpSucursales.Controls.Add(Me.BtnModificar)
        Me.GrpSucursales.Controls.Add(Me.BtnAgregar)
        Me.GrpSucursales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpSucursales.Location = New System.Drawing.Point(0, 0)
        Me.GrpSucursales.Name = "GrpSucursales"
        Me.GrpSucursales.Size = New System.Drawing.Size(784, 562)
        Me.GrpSucursales.TabIndex = 11
        Me.GrpSucursales.TabStop = False
        Me.GrpSucursales.Text = "Sucursales"
        '
        'GridSucursales
        '
        Me.GridSucursales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSucursales.ColumnAutoResize = True
        Me.GridSucursales.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSucursales.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSucursales.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSucursales.Location = New System.Drawing.Point(7, 15)
        Me.GridSucursales.Name = "GridSucursales"
        Me.GridSucursales.RecordNavigator = True
        Me.GridSucursales.Size = New System.Drawing.Size(771, 500)
        Me.GridSucursales.TabIndex = 1
        Me.GridSucursales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(687, 519)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva sucursal"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoSucursales
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.GrpSucursales)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmMtoSucursales"
        Me.Text = "Mantenimiento de Sucursales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpSucursales.ResumeLayout(False)
        CType(Me.GridSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sSucursalSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoSucursales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(False, Me.GridSucursales, "sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)
        Me.GridSucursales.RootTable.Columns("SUCClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridSucursales_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridSucursales.SelectionChanged
        If Not GridSucursales.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sSucursalSelected = GridSucursales.GetValue(0)
            Me.sNombre = GridSucursales.GetValue("Nombre")
        Else
            Me.sSucursalSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Sucursal Is Nothing Then
            ModPOS.Sucursal = New FrmSucursal
            With ModPOS.Sucursal
                .Text = "Agregar Sucursal"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Sucursal.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Sucursal.Show()
        ModPOS.Sucursal.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificaSucursal()
    End Sub

    Public Sub modificaSucursal()
        If sSucursalSelected <> "" Then

            If ModPOS.Sucursal Is Nothing Then

                ModPOS.Sucursal = New FrmSucursal
                With ModPOS.Sucursal
                    .Text = "Modificar Sucursal"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", Me.sSucursalSelected)

                    .SUCClave = dt.Rows(0)("SUCClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Tipo = dt.Rows(0)("Tipo")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Pais = dt.Rows(0)("Pais")
                    .Estado = dt.Rows(0)("Entidad")
                    .Mnpio = dt.Rows(0)("Municipio")
                    .Colonia = dt.Rows(0)("Colonia")
                    .Calle = dt.Rows(0)("Calle")
                    .CodigoPostal = dt.Rows(0)("CodigoPostal")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Localidad = dt.Rows(0)("Localidad")
                    .noExterior = dt.Rows(0)("noExterior")
                    .noInterior = dt.Rows(0)("noInterior")
                    .Tel = dt.Rows(0)("Telefono")
                    .Tel2 = IIf(dt.Rows(0)("Telefono2").GetType.Name = "DBNull", "", dt.Rows(0)("Telefono2"))
                    .CERClave = IIf(dt.Rows(0)("CERClave").GetType.Name = "DBNull", "", dt.Rows(0)("CERClave"))

                    .Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))

                    .Transito = IIf(dt.Rows(0)("Transito").GetType.Name = "DBNull", False, dt.Rows(0)("Transito"))

                    .Movilidad = IIf(dt.Rows(0)("Movilidad").GetType.Name = "DBNull", False, dt.Rows(0)("Movilidad"))

                    .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", "", dt.Rows(0)("Responsable"))

                    .eMail = IIf(dt.Rows(0)("eMail").GetType.Name = "DBNull", "", dt.Rows(0)("eMail"))

                    .Servidor = IIf(dt.Rows(0)("Servidor").GetType.Name = "DBNull", "", dt.Rows(0)("Servidor"))


                    If Not dt.Rows(0)("Publicidad") Is System.DBNull.Value Then
                        .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Publicidad"), Byte()))
                        .Icono = CType(dt.Rows(0)("Publicidad"), Byte())
                    End If

                    dt.Dispose()

                End With
            End If

            ModPOS.Sucursal.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Sucursal.Show()
            ModPOS.Sucursal.BringToFront()

        End If
    End Sub

    Private Sub GridSucursales_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridSucursales.DoubleClick
        modificaSucursal()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sSucursalSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la sucursal  :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_sucursal", "@SUCClave", sSucursalSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(False, Me.GridSucursales, "sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)
                    Me.GridSucursales.RootTable.Columns("SUCClave").Visible = False
            End Select
        End If
    End Sub

    Private Sub FrmMtoSucursales_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoSucursales.Dispose()
        ModPOS.MtoSucursales = Nothing
    End Sub
End Class
