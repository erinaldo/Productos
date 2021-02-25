Public Class FrmAlmacenes
    Inherits System.Windows.Forms.Form
    Private sSUCClave As String
    Private sAlmacenSelected As String
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private sReferencia As String
    Private bload As Boolean = False

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
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents GridAlmacen As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAlmacenes))
        Me.GrpAlmacen = New System.Windows.Forms.GroupBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GridAlmacen = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton()
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.GrpAlmacen.SuspendLayout()
        CType(Me.GridAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpAlmacen
        '
        Me.GrpAlmacen.Controls.Add(Me.CmbSucursal)
        Me.GrpAlmacen.Controls.Add(Me.Label1)
        Me.GrpAlmacen.Controls.Add(Me.BtnCancelar)
        Me.GrpAlmacen.Controls.Add(Me.GridAlmacen)
        Me.GrpAlmacen.Controls.Add(Me.BtnEliminar)
        Me.GrpAlmacen.Controls.Add(Me.BtnAbrir)
        Me.GrpAlmacen.Controls.Add(Me.BtnNuevo)
        Me.GrpAlmacen.Controls.Add(Me.BtnModificar)
        Me.GrpAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.GrpAlmacen.Name = "GrpAlmacen"
        Me.GrpAlmacen.Size = New System.Drawing.Size(784, 561)
        Me.GrpAlmacen.TabIndex = 0
        Me.GrpAlmacen.TabStop = False
        Me.GrpAlmacen.Text = "Almacenes"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(59, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(507, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Sucursal"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(304, 525)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridAlmacen
        '
        Me.GridAlmacen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAlmacen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAlmacen.ColumnAutoResize = True
        Me.GridAlmacen.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAlmacen.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAlmacen.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAlmacen.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridAlmacen.Location = New System.Drawing.Point(7, 42)
        Me.GridAlmacen.Name = "GridAlmacen"
        Me.GridAlmacen.RecordNavigator = True
        Me.GridAlmacen.Size = New System.Drawing.Size(771, 477)
        Me.GridAlmacen.TabIndex = 0
        Me.GridAlmacen.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(400, 525)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminar.TabIndex = 3
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Borrar Almacén"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(496, 525)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(90, 30)
        Me.BtnAbrir.TabIndex = 4
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Abrir Almacén"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Icon = CType(resources.GetObject("BtnNuevo.Icon"), System.Drawing.Icon)
        Me.BtnNuevo.Location = New System.Drawing.Point(688, 525)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 30)
        Me.BtnNuevo.TabIndex = 1
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.ToolTipText = "Crear Nuevo Almacén"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(592, 525)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 30)
        Me.BtnModificar.TabIndex = 2
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar Almacén"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAlmacenes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GrpAlmacen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(500, 305)
        Me.Name = "FrmAlmacenes"
        Me.Text = "Almacenes"
        Me.GrpAlmacen.ResumeLayout(False)
        CType(Me.GridAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmAlmacenes_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.Almacenes.Dispose()
        ModPOS.Almacenes = Nothing
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If ModPOS.CrearAlm Is Nothing Then
            ModPOS.CrearAlm = New FrmCrearAlm
            ModPOS.CrearAlm.MdiParent = ModPOS.Principal
            ModPOS.CrearAlm.Text = "Crear Nuevo Almacén"
            ModPOS.CrearAlm.Padre = "Nuevo"
            ModPOS.CrearAlm.SUCClave = sSUCClave

        End If
        ModPOS.CrearAlm.StartPosition = FormStartPosition.CenterScreen
        ModPOS.CrearAlm.Show()
        ModPOS.CrearAlm.BringToFront()

        Me.Close()
    End Sub

    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, GridAlmacen, "sp_muestra_almacenes", "@SUCClave", sSUCClave)
        Me.GridAlmacen.RootTable.Columns("ALMClave").Visible = False
        GridAlmacen.RootTable.Columns("Alto").FormatString = "0.00"
        GridAlmacen.RootTable.Columns("Largo").FormatString = "0.00"
        GridAlmacen.RootTable.Columns("Ancho").FormatString = "0.00"
    End Sub


    Private Sub FrmAlmacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

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

        bload = True
        refrescaGrid()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Modificar()
    End Sub

    Private Sub GridAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridAlmacen_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAlmacen.SelectionChanged
        If Not Me.GridAlmacen.GetValue(0) Is Nothing Then
            sAlmacenSelected = Me.GridAlmacen.GetValue(0)
            sReferencia = Me.GridAlmacen.GetValue(1)
            ModPOS.Almacenes.BtnAbrir.Enabled = True
            ModPOS.Almacenes.BtnModificar.Enabled = True
            ModPOS.Almacenes.BtnEliminar.Enabled = True
        Else
            sAlmacenSelected = ""
            sReferencia = ""
            ModPOS.Almacenes.BtnAbrir.Enabled = False
            ModPOS.Almacenes.BtnModificar.Enabled = False
            ModPOS.Almacenes.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click

        If Not ModPOS.Superficie Is Nothing Then
            ModPOS.Graba_Layout_Activo()
            ModPOS.Superficie.Close()
        End If

        If Me.sAlmacenSelected <> "" Then

            ModPOS.Almacen_Activo = sAlmacenSelected

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacenSelected)

            ModPOS.EscalaActual = dt.Rows(0)("Escala")

            ModPOS.Superficie = New FrmCanvas

            With ModPOS.Superficie
                .StartPosition = FormStartPosition.CenterScreen
                .MdiParent = ModPOS.Principal
                .Show()

                'Modificar valores del almacen
                .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                .ALMClave = dt.Rows(0)("ALMClave")
                .Referencia = dt.Rows(0)("Clave")
                .Nombre = dt.Rows(0)("Nombre")
                .Escala = dt.Rows(0)("Escala")
                .Alto = dt.Rows(0)("Alto")
                .Largo = dt.Rows(0)("Largo")
                .Ancho = dt.Rows(0)("Ancho")
                .Width = CInt(dt.Rows(0)("Width"))
                .Height = CInt(dt.Rows(0)("Height"))
                .Estado = dt.Rows(0)("Estado")
                .BloqueoVta = IIf(dt.Rows(0)("BloqueoVta").GetType.Name = "DBNull", False, dt.Rows(0)("BloqueoVta"))
                .Predeterminado = IIf(dt.Rows(0)("Predeterminado").GetType.Name = "DBNull", False, dt.Rows(0)("Predeterminado"))
                .TipoSurtido = IIf(dt.Rows(0)("TipoSurtido").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoSurtido"))
                .Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
                .Refresh()
            End With

            dt.Dispose()

            Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

            Cnx = New System.Data.SqlClient.SqlConnection

            Try
                Cnx.ConnectionString = ModPOS.BDConexion
                Cnx.Open()
            Catch ex As Exception
                Beep()
                MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim dr As System.Data.SqlClient.SqlDataReader
            Dim myCommand As System.Data.SqlClient.SqlCommand

            myCommand = New System.Data.SqlClient.SqlCommand("sp_load_almacen", Cnx)
            myCommand.CommandTimeout = ModPOS.myTimeOut
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.Parameters.Add("@ALMClave", SqlDbType.VarChar).Value = ModPOS.Superficie.ALMClave

            dr = myCommand.ExecuteReader()
            Dim rotada As Boolean

            While dr.Read()
                If dr("Rotada") = 1 Then
                    rotada = True
                Else
                    rotada = False
                End If
                ModPOS.Superficie.NuevaEstructura(dr("ESTClave"), dr("Color"), dr("OrigenX"), dr("OrigenY"), dr("Width"), dr("Height"), rotada)


                With ModPOS.vector(ModPOS.numEst_Vector - 1)
                    .TSTClave = dr("TESTClave")
                    .AREClave = dr("AREClave").ToString
                    .Clave = dr("Clave")
                    .PasilloColoca = dr("PasilloColoca")
                    .PasilloRecoge = dr("PasilloRecoge").ToString
                    .TipoRotacion = dr("TipoRotacion")
                    .Alto = dr("Alto")
                    .Largo = dr("Largo")
                    .Ancho = dr("Ancho")
                    .Columnas = dr("Columnas")
                    .Niveles = dr("Niveles")
                    '  .CapacidadCarga = dr("CapacidadCarga")
                    .Estado = dr("Estado")
                    .formaEnvioInicial = IIf(dr("formaEnvioInicial").GetType.Name <> "DBNull", dr("formaEnvioInicial"), 0)
                    .formaEnvioFinal = IIf(dr("formaEnvioFinal").GetType.Name <> "DBNull", dr("formaEnvioFinal"), 99)
                    .SecuenciaRecoleccion = IIf(dr("SecuenciaRecoleccion").GetType.Name <> "DBNull", dr("SecuenciaRecoleccion"), 0)
                    .TipoAplicacion = IIf(dr("TipoAplicacion").GetType.Name <> "DBNull", dr("TipoAplicacion"), 1)
                End With

                ModPOS.vector(ModPOS.numEst_Vector - 1).Image = ModPOS.ImageAddText(ModPOS.vector(ModPOS.numEst_Vector - 1), ModPOS.vector(ModPOS.numEst_Vector - 1).Clave)
                ' ModPOS.redrawClave(ModPOS.vector(ModPOS.numEst_Vector - 1), ModPOS.vector(ModPOS.numEst_Vector - 1).Clave)

            End While
            myCommand.Dispose()
            dr.Close()
            Cnx.Close()

        End If
        ModPOS.Principal.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.True
        ModPOS.Principal.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.True
        ModPOS.Principal.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.True
        ModPOS.Principal.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.True
        ModPOS.Principal.Volumen.Enabled = Janus.Windows.UI.InheritableBoolean.True

        If ModPOS.Est_Selected = -1 Then
            With ModPOS.Principal
                .Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .Fila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .Columna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                .Largo.Enabled = Janus.Windows.UI.InheritableBoolean.False
            End With
        End If

        If ModPOS.numEst_CpyVector = -1 And ModPOS.Superficie Is Nothing Then
            ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False
        End If


        Me.Close()

    End Sub

    Private Sub GridAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAlmacen.DoubleClick
        Modificar()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Beep()
        Select Case MessageBox.Show("Se eliminara el Almacén :" & sReferencia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes

                If ModPOS.SiExite(ModPOS.BDConexion, "sp_almacen_vacio", "@ALMClave", sAlmacenSelected) <> 0 Then
                    MessageBox.Show("El Almacen seleccionado no puede ser eliminado ya que existen estructuras asignadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    If ModPOS.Almacen_Activo = sAlmacenSelected Then
                        ModPOS.Graba_Layout_Activo()
                        ModPOS.Almacen_Activo = ""
                        ModPOS.Superficie.Close()
                        ModPOS.Principal.Cerrar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                        ModPOS.Principal.Zoom.Enabled = Janus.Windows.UI.InheritableBoolean.False
                        ModPOS.Principal.Nuevo.Enabled = Janus.Windows.UI.InheritableBoolean.False
                        ModPOS.Principal.Buscar.Enabled = Janus.Windows.UI.InheritableBoolean.False

                        If ModPOS.Est_Selected = -1 Then
                            ModPOS.Principal.Copiar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.CopiarN.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.Rotar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.Eliminar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.Fila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.Columna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.EliminarColumna.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.EliminarFila.Enabled = Janus.Windows.UI.InheritableBoolean.False
                            ModPOS.Principal.Largo.Enabled = Janus.Windows.UI.InheritableBoolean.False
                        End If
                        If ModPOS.numEst_CpyVector = -1 And ModPOS.Superficie Is Nothing Then
                            ModPOS.Principal.Pegar.Enabled = Janus.Windows.UI.InheritableBoolean.False
                        End If
                    End If

                    ModPOS.Ejecuta("sp_elimina_almacen", "@ALMClave", sAlmacenSelected, "@Usuario", ModPOS.UsuarioActual)

                    refrescaGrid()

                End If

            Case DialogResult.No

        End Select

    End Sub
    Private Sub Modificar()
        If Me.sAlmacenSelected <> "" Then
            If ModPOS.CrearAlm Is Nothing Then

                Dim dt As DataTable
             
                dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacenSelected)

                ModPOS.CrearAlm = New FrmCrearAlm
                ModPOS.CrearAlm.MdiParent = ModPOS.Principal
                ModPOS.CrearAlm.Text = "Modificar Almacén"
                ModPOS.CrearAlm.Padre = "Modificar"

                With ModPOS.CrearAlm
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                    .Estado = dt.Rows(0)("Estado")
                    .Alto = dt.Rows(0)("Alto")
                    .Largo = dt.Rows(0)("Largo")
                    .Ancho = dt.Rows(0)("Ancho")
                    .Escala = dt.Rows(0)("Escala")
                    .BloqueoVta = IIf(dt.Rows(0)("BloqueoVta").GetType.Name = "DBNull", False, dt.Rows(0)("BloqueoVta"))
                    .Predeterminado = IIf(dt.Rows(0)("Predeterminado").GetType.Name = "DBNull", False, dt.Rows(0)("Predeterminado"))
                    .TipoSurtido = IIf(dt.Rows(0)("TipoSurtido").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoSurtido"))
                    .Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))

                End With
                dt.Dispose()
            End If
            ModPOS.CrearAlm.StartPosition = FormStartPosition.CenterScreen
            ModPOS.CrearAlm.Show()
            ModPOS.CrearAlm.BringToFront()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad Then
                refrescaGrid()
        End If
    End Sub
End Class
