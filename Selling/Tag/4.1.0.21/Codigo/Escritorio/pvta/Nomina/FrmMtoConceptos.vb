Public Class FrmMtoConceptos
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
    Friend WithEvents GridConceptos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoConceptos))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.GrpPDV = New System.Windows.Forms.GroupBox
        Me.GridConceptos = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPDV.SuspendLayout()
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(295, 336)
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
        Me.BtnModificar.Location = New System.Drawing.Point(487, 336)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar concepto seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(391, 336)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar concepto seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPDV
        '
        Me.GrpPDV.Controls.Add(Me.BtnCancelar)
        Me.GrpPDV.Controls.Add(Me.GridConceptos)
        Me.GrpPDV.Controls.Add(Me.BtnEliminar)
        Me.GrpPDV.Controls.Add(Me.BtnModificar)
        Me.GrpPDV.Controls.Add(Me.BtnAgregar)
        Me.GrpPDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPDV.Location = New System.Drawing.Point(0, 0)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(680, 380)
        Me.GrpPDV.TabIndex = 11
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Conceptos"
        '
        'GridConceptos
        '
        Me.GridConceptos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridConceptos.ColumnAutoResize = True
        Me.GridConceptos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridConceptos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridConceptos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridConceptos.Location = New System.Drawing.Point(7, 15)
        Me.GridConceptos.Name = "GridConceptos"
        Me.GridConceptos.RecordNavigator = True
        Me.GridConceptos.Size = New System.Drawing.Size(666, 316)
        Me.GridConceptos.TabIndex = 1
        Me.GridConceptos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(583, 336)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo concepto"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoConceptos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(680, 380)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoConceptos"
        Me.Text = "Mantenimiento de Conceptos de Nómina"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPDV.ResumeLayout(False)
        CType(Me.GridConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sConceptoSelected As String
    Private sNombre As String
    Private cargado As Boolean

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Public Sub actualizaGrid()
        Cursor.Current = Cursors.WaitCursor
        cargado = False
        ModPOS.ActualizaGrid(True, Me.GridConceptos, "sp_muestra_conceptos", "@COMClave", ModPOS.CompanyActual)
        Me.GridConceptos.RootTable.Columns("CONClave").Visible = False

        If Not GridConceptos.GetValue("CONClave") Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sConceptoSelected = GridConceptos.GetValue("CONClave")
            Me.sNombre = GridConceptos.GetValue("Descripción")
        Else
            Me.sConceptoSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If


        cargado = True
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FrmMtoConceptos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        actualizaGrid()
    End Sub

    Private Sub GridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridConceptos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridConceptos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridConceptos.SelectionChanged
        If cargado = True Then
            If Not GridConceptos.GetValue("CONClave") Is Nothing Then
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.sConceptoSelected = GridConceptos.GetValue("CONClave")
                Me.sNombre = GridConceptos.GetValue("Descripción")
            Else
                Me.sConceptoSelected = ""
                Me.sNombre = ""
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Concepto Is Nothing Then
            ModPOS.Concepto = New FrmConcepto
            With ModPOS.Concepto
                .Text = "Agregar Concepto de Nómina"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Concepto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Concepto.Show()
        ModPOS.Concepto.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarConcepto()
    End Sub

    Public Sub modificarConcepto()
        If sConceptoSelected <> "" Then

            If ModPOS.Concepto Is Nothing Then

                ModPOS.Concepto = New FrmConcepto
                With ModPOS.Concepto
                    .Text = "Modificar Concepto de Nómina"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtClave.ReadOnly = True
                    .ChkEstado.Enabled = True
                    .CmbTipo.Enabled = False

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_conceptoNomina", "@CONClave", Me.sConceptoSelected)

                    .CONClave = dt.Rows(0)("CONClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Concepto = dt.Rows(0)("Concepto")
                    .Tipo = dt.Rows(0)("Tipo")
                    .TipoConcepto = dt.Rows(0)("TipoConcepto")
                    .TipoEstado = dt.Rows(0)("Estado")

                    dt.Dispose()

                End With
            End If

            ModPOS.Concepto.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Concepto.Show()
            ModPOS.Concepto.BringToFront()

        End If
    End Sub

    Private Sub GridConceptos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridConceptos.DoubleClick
        modificarConcepto()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sConceptoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Concepto :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_conceptoNomina", "@CONClave", sConceptoSelected, "@Usuario", ModPOS.UsuarioActual)

                    actualizaGrid()

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoConceptos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoConceptos.Dispose()
        ModPOS.MtoConceptos = Nothing
    End Sub
End Class
