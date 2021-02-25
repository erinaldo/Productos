Public Class FrmMtoViaje
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
    Friend WithEvents GrpViaje As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents GridViaje As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoViaje))
        Me.GrpViaje = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.GridViaje = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpViaje.SuspendLayout()
        CType(Me.GridViaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpViaje
        '
        Me.GrpViaje.Controls.Add(Me.BtnCancelar)
        Me.GrpViaje.Controls.Add(Me.Label3)
        Me.GrpViaje.Controls.Add(Me.BtnEliminar)
        Me.GrpViaje.Controls.Add(Me.BtnModificar)
        Me.GrpViaje.Controls.Add(Me.dtPicker)
        Me.GrpViaje.Controls.Add(Me.GridViaje)
        Me.GrpViaje.Controls.Add(Me.BtnAgregar)
        Me.GrpViaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpViaje.Location = New System.Drawing.Point(0, 0)
        Me.GrpViaje.Name = "GrpViaje"
        Me.GrpViaje.Size = New System.Drawing.Size(680, 380)
        Me.GrpViaje.TabIndex = 11
        Me.GrpViaje.TabStop = False
        Me.GrpViaje.Text = "Viajes"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(436, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(487, 15)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 20)
        Me.dtPicker.TabIndex = 57
        '
        'GridViaje
        '
        Me.GridViaje.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridViaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridViaje.ColumnAutoResize = True
        Me.GridViaje.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridViaje.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridViaje.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridViaje.Location = New System.Drawing.Point(7, 40)
        Me.GridViaje.Name = "GridViaje"
        Me.GridViaje.RecordNavigator = True
        Me.GridViaje.Size = New System.Drawing.Size(666, 288)
        Me.GridViaje.TabIndex = 1
        Me.GridViaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        Me.BtnModificar.ToolTipText = "Modificar viaje seleccionado"
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
        Me.BtnEliminar.ToolTipText = "Eliminar viaje seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.BtnAgregar.ToolTipText = "Agregar nuevo viaje"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoViaje
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(680, 380)
        Me.Controls.Add(Me.GrpViaje)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoViaje"
        Me.Text = "Mantenimiento de Viajes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpViaje.ResumeLayout(False)
        Me.GrpViaje.PerformLayout()
        CType(Me.GridViaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sViajeSelected As String
    Private sNombre As String
    Private bLoad As Boolean = False
    Private Periodo As Integer
    Private Mes As Integer

    Public Sub refrescaGrid()
        Cursor.Current = Cursors.WaitCursor
        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month
        ModPOS.ActualizaGrid(False, Me.GridViaje, "sp_muestra_viajes", "@COMClave", ModPOS.CompanyActual, "@Periodo", Periodo, "@Mes", Mes)
        Me.GridViaje.RootTable.Columns("VIAClave").Visible = False
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoViaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        refrescaGrid()
        bLoad = True
    End Sub

    Private Sub GridViaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridViaje.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridViaje_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViaje.SelectionChanged
        If Not GridViaje.GetValue("VIAClave") Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sViajeSelected = GridViaje.GetValue("VIAClave")
            Me.sNombre = GridViaje.GetValue(1)
        Else
            Me.sViajeSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Viaje Is Nothing Then
            ModPOS.Viaje = New FrmViaje
            With ModPOS.Viaje
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Viaje.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Viaje.Show()
        ModPOS.Viaje.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarViaje()
    End Sub

    Public Sub modificarViaje()
        If sViajeSelected <> "" Then

            If ModPOS.Viaje Is Nothing Then

                ModPOS.Viaje = New FrmViaje
                With ModPOS.Viaje
                    .Text = "Modificar Viaje"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_viaje", "@VIAClave", Me.sViajeSelected)
                    .VIAClave = dt.Rows(0)("VIAClave")
                    .fechaViaje = dt.Rows(0)("fechaViaje")
                    .TRAClave = dt.Rows(0)("TRAClave")
                    .EMPClave = dt.Rows(0)("EMPClave")
                    .CTEClave = dt.Rows(0)("CTEClave")
                    .Factura = dt.Rows(0)("Factura")
                    .noViaje = dt.Rows(0)("noViaje")
                    .fechaFactura = IIf(dt.Rows(0)("fechaFactura").GetType.Name = "DBNull", #1/1/2000#, dt.Rows(0)("fechaFactura"))
                    .fechaVencimiento = IIf(dt.Rows(0)("fechaVencimiento").GetType.Name = "DBNull", #1/1/2000#, dt.Rows(0)("fechaVencimiento"))
                    .fechaCobranza = IIf(dt.Rows(0)("fechaCobranza").GetType.Name = "DBNull", #1/1/2000#, dt.Rows(0)("fechaCobranza"))
                    .Pagado = IIf(dt.Rows(0)("Pagado").GetType.Name = "DBNull", 0, dt.Rows(0)("Pagado"))
                    .fechaPago = IIf(dt.Rows(0)("fechaPago").GetType.Name = "DBNull", #1/1/2000#, dt.Rows(0)("fechaPago"))

                    dt.Dispose()
                End With
            End If

            ModPOS.Viaje.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Viaje.Show()
            ModPOS.Viaje.BringToFront()

        End If
    End Sub

    Private Sub GridViaje_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViaje.DoubleClick
        modificarViaje()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sViajeSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Viaje: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_viaje", "@VIAClave", sViajeSelected, "@Usuario", ModPOS.UsuarioActual)
                    refrescaGrid()
                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoViaje_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoViaje.Dispose()
        ModPOS.MtoViaje = Nothing
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Me.refrescaGrid()
        End If
    End Sub
End Class
