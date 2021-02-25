Public Class FrmMtoEmpleados
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
    Friend WithEvents GrpPDV As System.Windows.Forms.GroupBox
    Friend WithEvents GridEmpleados As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoEmpleados))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV = New System.Windows.Forms.GroupBox()
        Me.GridEmpleados = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV.SuspendLayout()
        CType(Me.GridEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(295, 337)
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
        Me.BtnModificar.Location = New System.Drawing.Point(487, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar empleado seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(391, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar empleado seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPDV
        '
        Me.GrpPDV.Controls.Add(Me.BtnCancelar)
        Me.GrpPDV.Controls.Add(Me.GridEmpleados)
        Me.GrpPDV.Controls.Add(Me.BtnEliminar)
        Me.GrpPDV.Controls.Add(Me.BtnModificar)
        Me.GrpPDV.Controls.Add(Me.BtnAgregar)
        Me.GrpPDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPDV.Location = New System.Drawing.Point(0, 0)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(680, 380)
        Me.GrpPDV.TabIndex = 11
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Empleados"
        '
        'GridEmpleados
        '
        Me.GridEmpleados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEmpleados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEmpleados.ColumnAutoResize = True
        Me.GridEmpleados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEmpleados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEmpleados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEmpleados.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridEmpleados.Location = New System.Drawing.Point(7, 15)
        Me.GridEmpleados.Name = "GridEmpleados"
        Me.GridEmpleados.RecordNavigator = True
        Me.GridEmpleados.Size = New System.Drawing.Size(666, 316)
        Me.GridEmpleados.TabIndex = 1
        Me.GridEmpleados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(583, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo empleado"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoEmpleados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(680, 380)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoEmpleados"
        Me.Text = "Mantenimiento de Empleados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPDV.ResumeLayout(False)
        CType(Me.GridEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sEmpleadoSelected As String
    Private sNombre As String
    Private cargado As Boolean
  
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Public Sub actualizaGrid()
        Cursor.Current = Cursors.WaitCursor
        cargado = False
        ModPOS.ActualizaGrid(True, Me.GridEmpleados, "sp_muestra_empleados", "@COMClave", ModPOS.CompanyActual)
        Me.GridEmpleados.RootTable.Columns("EMPClave").Visible = False

        If Not GridEmpleados.GetValue("EMPClave") Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sEmpleadoSelected = GridEmpleados.GetValue("EMPClave")
            Me.sNombre = GridEmpleados.GetValue("NombreCompleto")
        Else
            Me.sEmpleadoSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If


        cargado = True
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FrmMtoEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        actualizaGrid()
    End Sub

    Private Sub GridEmpleados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEmpleados.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridEmpleados_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridEmpleados.SelectionChanged
        If cargado = True Then
            If Not GridEmpleados.GetValue("EMPClave") Is Nothing Then
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.sEmpleadoSelected = GridEmpleados.GetValue("EMPClave")
                Me.sNombre = GridEmpleados.GetValue("NombreCompleto")
            Else
                Me.sEmpleadoSelected = ""
                Me.sNombre = ""
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Empleado Is Nothing Then
            ModPOS.Empleado = New FrmEmpleado
            With ModPOS.Empleado
                .Text = "Agregar Empleado"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Empleado.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Empleado.Show()
        ModPOS.Empleado.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarEmpleado()
    End Sub

    Public Sub modificarEmpleado()
        If sEmpleadoSelected <> "" Then

            If ModPOS.Empleado Is Nothing Then

                ModPOS.Empleado = New FrmEmpleado
                With ModPOS.Empleado
                    .Text = "Modificar Empleado"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtNumEmpleado.ReadOnly = True
                    .ChkEstado.Enabled = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_empleado", "@EMPClave", Me.sEmpleadoSelected)

                    .EMPClave = dt.Rows(0)("EMPClave")
                    .NumEmpleado = dt.Rows(0)("NumEmpleado")
                    .NombreCompleto = dt.Rows(0)("NombreCompleto")
                    .RFC = dt.Rows(0)("id_Fiscal")
                    .NSS = dt.Rows(0)("NumSeguridadSocial")
                    .CURP = dt.Rows(0)("CURP")
                    .TipoRegimen = dt.Rows(0)("TipoRegimen")
                    .Departamento = dt.Rows(0)("Departamento")
                    .Puesto = dt.Rows(0)("Puesto")
                    .TipoContrato = dt.Rows(0)("TipoContrato")
                    .TipoJornada = dt.Rows(0)("TipoJornada")
                    .CLABE = dt.Rows(0)("CLABE")
                    .TipoBanco = dt.Rows(0)("TipoBanco")
                    .FechaReg = dt.Rows(0)("FechaInicioRelLaboral")
                    .PeriodicidadPago = dt.Rows(0)("PeriodicidadPago")
                    .SalarioBase = dt.Rows(0)("SalarioBaseCotAport")

                    .SalarioDiario = dt.Rows(0)("SalarioDiarioIntegrado")
                    .PaisLabora = IIf(dt.Rows(0)("PaisLabora").GetType.Name = "DBNull", 1, dt.Rows(0)("PaisLabora"))
                    .EdoLabora = IIf(dt.Rows(0)("EdoLabora").GetType.Name = "DBNull", "", dt.Rows(0)("EdoLabora"))


                    .Sindicalizado = IIf(dt.Rows(0)("Sindicalizado").GetType.Name = "DBNull", 0, dt.Rows(0)("Sindicalizado"))
                    .PaisF = dt.Rows(0)("Pais")
                    .EntidadF = dt.Rows(0)("Entidad")
                    .MnpioF = dt.Rows(0)("Municipio")
                    .ColoniaF = dt.Rows(0)("Colonia")
                    .CalleF = dt.Rows(0)("Calle")
                    .noExteriorF = dt.Rows(0)("noExterior")
                    .noInteriorF = dt.Rows(0)("noInterior")
                    .codigoPostalF = dt.Rows(0)("codigoPostal")

                    .Contacto = dt.Rows(0)("Contacto")
                    .Tel1 = dt.Rows(0)("Tel1")
                    .Tel2 = dt.Rows(0)("Tel2")
                    .email = dt.Rows(0)("Email")

                    .TipoEstado = dt.Rows(0)("Estado")

                    .TipoLicencia = IIf(dt.Rows(0)("TipoLicencia").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoLicencia"))
                    .Licencia = IIf(dt.Rows(0)("Licencia").GetType.Name = "DBNull", "", dt.Rows(0)("Licencia"))
                    .Vencimiento = IIf(dt.Rows(0)("Vencimiento").GetType.Name = "DBNull", DateTime.Today, dt.Rows(0)("Vencimiento"))

                    .TipoEmpleado = IIf(dt.Rows(0)("TipoEmpleado").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoEmpleado"))
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))


                    dt.Dispose()

                End With
            End If

                    ModPOS.Empleado.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Empleado.Show()
                    ModPOS.Empleado.BringToFront()

        End If
    End Sub

    Private Sub GridEmpleados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridEmpleados.DoubleClick
        modificarEmpleado()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sEmpleadoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Empleado :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_empleado", "@EMPClave", sEmpleadoSelected, "@Usuario", ModPOS.UsuarioActual)

                    actualizaGrid()

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoEmpleados_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoEmpleados.Dispose()
        ModPOS.MtoEmpleados = Nothing
    End Sub
End Class
