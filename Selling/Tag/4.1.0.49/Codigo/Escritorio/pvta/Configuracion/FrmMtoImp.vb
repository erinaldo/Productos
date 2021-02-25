Public Class FrmMtoImp
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
    Friend WithEvents GrpClass As System.Windows.Forms.GroupBox
    Friend WithEvents GridImpuestos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoImp))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpClass = New System.Windows.Forms.GroupBox()
        Me.GridImpuestos = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpClass.SuspendLayout()
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 337)
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
        Me.BtnModificar.Location = New System.Drawing.Point(463, 337)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica impuesto seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(367, 337)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Elimina impuesto seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClass
        '
        Me.GrpClass.Controls.Add(Me.BtnCancelar)
        Me.GrpClass.Controls.Add(Me.GridImpuestos)
        Me.GrpClass.Controls.Add(Me.BtnEliminar)
        Me.GrpClass.Controls.Add(Me.BtnModificar)
        Me.GrpClass.Controls.Add(Me.BtnAgregar)
        Me.GrpClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClass.Location = New System.Drawing.Point(0, 0)
        Me.GrpClass.Name = "GrpClass"
        Me.GrpClass.Size = New System.Drawing.Size(656, 380)
        Me.GrpClass.TabIndex = 11
        Me.GrpClass.TabStop = False
        Me.GrpClass.Text = "Impuestos"
        '
        'GridImpuestos
        '
        Me.GridImpuestos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridImpuestos.ColumnAutoResize = True
        Me.GridImpuestos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridImpuestos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridImpuestos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridImpuestos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridImpuestos.Location = New System.Drawing.Point(7, 15)
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.RecordNavigator = True
        Me.GridImpuestos.Size = New System.Drawing.Size(642, 315)
        Me.GridImpuestos.TabIndex = 1
        Me.GridImpuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(559, 337)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo impuesto"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoImp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(656, 380)
        Me.Controls.Add(Me.GrpClass)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoImp"
        Me.Text = "Mantenimiento de Impuestos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClass.ResumeLayout(False)
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sImpSelected As String
    Private sNombre As String
    
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoImp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(True, Me.GridImpuestos, "sp_muestra_impuestos", "@COMClave", ModPOS.CompanyActual)
        GridImpuestos.RootTable.Columns("IMPClave").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridImpuestos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridImpuestos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridImpuestos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridImpuestos.SelectionChanged
        If Not GridImpuestos.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sImpSelected = GridImpuestos.GetValue("IMPClave")
            Me.sNombre = GridImpuestos.GetValue(1)
            Else
            Me.sImpSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Impuesto Is Nothing Then
            ModPOS.Impuesto = New FrmImpuesto
            With ModPOS.Impuesto
                .Text = "Agregar Impuesto"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Impuesto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Impuesto.Show()
        ModPOS.Impuesto.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarImp()
    End Sub

    Public Sub modificarImp()
        If sImpSelected <> "" Then

            If ModPOS.Impuesto Is Nothing Then

                ModPOS.Impuesto = New FrmImpuesto
                With ModPOS.Impuesto
                    .Text = "Modificar Impuesto"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtNombre.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_impuesto", "@Impuesto", Me.sImpSelected)

                    .IMPClave = dt.Rows(0)("IMPClave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .Jerarquia = dt.Rows(0)("Jerarquia")
                    .TAplicacion = dt.Rows(0)("TipoAplicacion")
                    .SobreImpuesto = dt.Rows(0)("SobreImp")
                    .Estado = dt.Rows(0)("Estado")
                    .CtaContableCompra = IIf(dt.Rows(0)("CtaContableCompra").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContableCompra"))
                    .CtaContableVenta = IIf(dt.Rows(0)("CtaContableVenta").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContableVenta"))
                    .ClaveSAT = IIf(dt.Rows(0)("ClaveSAT").GetType.Name = "DBNull", "", dt.Rows(0)("ClaveSAT"))
                    .noTrasladar = IIf(dt.Rows(0)("noTrasladar").GetType.Name = "DBNull", False, dt.Rows(0)("noTrasladar"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Impuesto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Impuesto.Show()
            ModPOS.Impuesto.BringToFront()

        End If
    End Sub

    Private Sub GridImpuestos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridImpuestos.DoubleClick
        modificarImp()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sImpSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Impuesto  :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim Con As String = ModPOS.BDConexion
                    If ModPOS.SiExite(Con, "sp_impuesto_vacio", "@Impuesto", sImpSelected) <> 0 Then
                        MessageBox.Show("El Impuesto seleccionado no puede ser eliminado ya que existen productos con dicho impuesto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        ModPOS.Ejecuta("sp_elimina_impuesto", "@Impuesto", sImpSelected, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.ActualizaGrid(True, Me.GridImpuestos, "sp_muestra_impuestos", "@COMClave", ModPOS.CompanyActual)
                        GridImpuestos.RootTable.Columns("IMPClave").Visible = False

                        
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoImp_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoImp.Dispose()
        ModPOS.MtoImp = Nothing

    End Sub
End Class
