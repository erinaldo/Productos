Public Class FrmMtoNomina
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
    Friend WithEvents GrpNomina As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCopiar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents GridNominas As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoNomina))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpNomina = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnCopiar = New Janus.Windows.EditControls.UIButton()
        Me.GridNominas = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpNomina.SuspendLayout()
        CType(Me.GridNominas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(433, 542)
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
        Me.BtnModificar.Location = New System.Drawing.Point(721, 542)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar nómina seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(529, 542)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar nómina seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpNomina
        '
        Me.GrpNomina.Controls.Add(Me.Label3)
        Me.GrpNomina.Controls.Add(Me.dtPicker)
        Me.GrpNomina.Controls.Add(Me.BtnCancelar)
        Me.GrpNomina.Controls.Add(Me.BtnCopiar)
        Me.GrpNomina.Controls.Add(Me.GridNominas)
        Me.GrpNomina.Controls.Add(Me.BtnAgregar)
        Me.GrpNomina.Controls.Add(Me.BtnEliminar)
        Me.GrpNomina.Controls.Add(Me.BtnModificar)
        Me.GrpNomina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpNomina.Location = New System.Drawing.Point(0, 0)
        Me.GrpNomina.Name = "GrpNomina"
        Me.GrpNomina.Size = New System.Drawing.Size(914, 586)
        Me.GrpNomina.TabIndex = 11
        Me.GrpNomina.TabStop = False
        Me.GrpNomina.Text = "Nóminas"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(804, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(853, 12)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(54, 20)
        Me.dtPicker.TabIndex = 54
        '
        'BtnCopiar
        '
        Me.BtnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopiar.Icon = CType(resources.GetObject("BtnCopiar.Icon"), System.Drawing.Icon)
        Me.BtnCopiar.Location = New System.Drawing.Point(625, 542)
        Me.BtnCopiar.Name = "BtnCopiar"
        Me.BtnCopiar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCopiar.TabIndex = 18
        Me.BtnCopiar.Text = "&Copiar"
        Me.BtnCopiar.ToolTipText = "Copiar la nómina seleccionada"
        Me.BtnCopiar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridNominas
        '
        Me.GridNominas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridNominas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNominas.ColumnAutoResize = True
        Me.GridNominas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNominas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNominas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNominas.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridNominas.Location = New System.Drawing.Point(7, 38)
        Me.GridNominas.Name = "GridNominas"
        Me.GridNominas.RecordNavigator = True
        Me.GridNominas.Size = New System.Drawing.Size(900, 498)
        Me.GridNominas.TabIndex = 1
        Me.GridNominas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(817, 542)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva nómina"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoNomina
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(914, 586)
        Me.Controls.Add(Me.GrpNomina)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoNomina"
        Me.Text = "Mantenimiento de Nómina"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpNomina.ResumeLayout(False)
        Me.GrpNomina.PerformLayout()
        CType(Me.GridNominas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Periodo As Integer

    Private sNominaSelected As String
    Private sNumNomina As String
    Private iTipoEstado As Integer
    Private cargado As Boolean
    Private dtNomina As DataTable
    Private VersionNomina As Integer
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Public Sub actualizaGrid()
        Cursor.Current = Cursors.WaitCursor
      
        cargado = False
        ModPOS.ActualizaGrid(True, Me.GridNominas, "sp_muestra_nominas", "@Periodo", Periodo, "@COMClave", ModPOS.CompanyActual)
        ' ModPOS.ActualizaGrid(True, Me.GridNominas, "sp_muestra_nominas", "@COMClave", ModPOS.CompanyActual)

        Me.GridNominas.RootTable.Columns("NOMClave").Visible = False
        Me.GridNominas.RootTable.Columns("TipoEstado").Visible = False
        Me.GridNominas.RootTable.Columns("VersionNomina").Visible = False
        If Not GridNominas.GetValue("NOMClave") Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.BtnCopiar.Enabled = True
            Me.sNominaSelected = GridNominas.GetValue("NOMClave")
            Me.sNumNomina = GridNominas.GetValue("NumNomina")
            iTipoEstado = GridNominas.GetValue("TipoEstado")
        Else
            Me.sNominaSelected = ""
            Me.sNumNomina = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
            Me.BtnCopiar.Enabled = False

            iTipoEstado = 0
        End If


        cargado = True
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FrmMtoNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Periodo = dtPicker.Value.Year()


        Dim i As Integer
        Dim dtParam As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)

        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "VersionNomina"
                        VersionNomina = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 1, dtParam.Rows(i)("Valor"))
                End Select
            Next
        End With
        dtParam.Dispose()

        actualizaGrid()
    End Sub

    Private Sub GridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridNominas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridConceptos_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNominas.SelectionChanged
        If cargado = True Then
            If Not GridNominas.GetValue("NOMClave") Is Nothing Then
                Me.BtnModificar.Enabled = True
                Me.BtnEliminar.Enabled = True
                Me.BtnCopiar.Enabled = True
                Me.sNominaSelected = GridNominas.GetValue("NOMClave")
                Me.sNumNomina = GridNominas.GetValue("NumNomina")
                iTipoEstado = GridNominas.GetValue("TipoEstado")
            Else
                Me.sNominaSelected = ""
                Me.sNumNomina = ""
                Me.BtnModificar.Enabled = False
                Me.BtnEliminar.Enabled = False
                Me.BtnCopiar.Enabled = False
                iTipoEstado = 0
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Nomina Is Nothing Then
            ModPOS.Nomina = New FrmNomina
            With ModPOS.Nomina
                .Text = "Agregar Nómina"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .versionnomina = VersionNomina
            End With
        End If
        ModPOS.Nomina.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Nomina.Show()
        ModPOS.Nomina.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarNomina()
    End Sub

    Public Sub modificarNomina()
        If sNominaSelected <> "" Then

            If ModPOS.Nomina Is Nothing Then

                ModPOS.Nomina = New FrmNomina
                With ModPOS.Nomina
                    .Text = "Modificar Nómina"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtNumNomina.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_nomina", "@NOMClave", Me.sNominaSelected)

                    .NOMClave = dt.Rows(0)("NOMClave")
                    .NumNomina = dt.Rows(0)("NumNomina")
                    .fechaInicial = dt.Rows(0)("FechaInicialPago")
                    .fechaFinal = dt.Rows(0)("FechaFinalPago")
                    .numDias = dt.Rows(0)("NumDiasPagados")
                    .tipoEstado = dt.Rows(0)("TipoEstado")
                    .SUCClave = dt.Rows(0)("SUCClave")
                    .eRFC = dt.Rows(0)("Id_Fiscal")
                    .TipoNomina = IIf(dt.Rows(0)("TipoNomina").GetType.Name = "DBNull", "O", dt.Rows(0)("TipoNomina"))
                    .versionnomina = IIf(dt.Rows(0)("VersionNomina").GetType.Name = "DBNull", 1, dt.Rows(0)("VersionNomina"))
                    dt.Dispose()

                End With
            End If

            ModPOS.Nomina.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Nomina.Show()
            ModPOS.Nomina.BringToFront()

        End If
    End Sub

    Private Sub GridNominas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNominas.DoubleClick
        modificarNomina()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sNominaSelected <> "" Then

            If iTipoEstado = 1 Then
                Beep()
                Select Case MessageBox.Show("Se eliminara la Nomina :" & sNumNomina, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        ModPOS.Ejecuta("sp_elimina_Nomina", "@NOMClave", sNominaSelected, "@Usuario", ModPOS.UsuarioActual)

                        actualizaGrid()

                    Case DialogResult.No

                End Select
            Else
                MessageBox.Show("La nómina seleccionada se encuentra Cerrada por lo que no es posible eliminarla", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub FrmMtoNomina_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoNomina.Dispose()
        ModPOS.MtoNomina = Nothing
    End Sub


    Private Sub BtnCopiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopiar.Click
        If sNominaSelected <> "" Then

            If VersionNomina <> GridNominas.GetValue("VersionNomina") Then
                Beep()
                MessageBox.Show("No es posible realizar la copia debido a que la versión de Nomina seleccionada es diferente a la versión de Nomina Actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else

                Select Case MessageBox.Show("Se realizara copia de la Nómina: " & sNumNomina, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.Yes

                        Dim dtNomina, dtRecibos, dt As DataTable

                        dtNomina = ModPOS.Recupera_Tabla("sp_recupera_nomina", "@NOMClave", Me.sNominaSelected)

                        dtRecibos = ModPOS.Recupera_Tabla("sp_muestra_recibonomina", "@NOMClave", sNominaSelected)

                        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 9, "@SUCClave", dtNomina.Rows(0)("SUCClave"), "@CAJClave", "")

                        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") < dtRecibos.Rows.Count Then
                                MessageBox.Show("No hay folios disponibles suficientes para realizar la copia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                dtNomina.Dispose()
                                dtRecibos.Dispose()
                                dt.Dispose()
                                Exit Sub
                            End If
                        End If

                        dt.Dispose()


                        Dim sNOMClave As String = ModPOS.obtenerLlave


                        ModPOS.Ejecuta("sp_inserta_nomina", _
                       "@NOMClave", sNOMClave, _
                       "@COMClave", ModPOS.CompanyActual, _
                       "@NumNomina", "", _
                       "@FechaInicial", dtNomina.Rows(0)("FechaInicialPago"), _
                       "@FechaFinal", dtNomina.Rows(0)("FechaFinalPago"), _
                       "@NumDias", dtNomina.Rows(0)("NumDiasPagados"), _
                       "@TipoEstado", 1, _
                       "@SUCClave", dtNomina.Rows(0)("SUCClave"), _
                       "@TipoNomina", IIf(dtNomina.Rows(0)("TipoNomina").GetType.Name = "DBNull", 1, dtNomina.Rows(0)("TipoNomina")), _
                       "@VersionNomina", IIf(dtNomina.Rows(0)("VersionNomina").GetType.Name = "DBNull", 1, dtNomina.Rows(0)("VersionNomina")), _
                       "@Usuario", ModPOS.UsuarioActual)




                        Dim i As Integer
                        Dim sRENClave As String = ""
                        Dim FOLClave As String = ""
                        Dim Serie As String = ""
                        Dim Folio As Double

                        For i = 0 To dtRecibos.Rows.Count - 1

                            If dtRecibos.Rows(i)("Estado") <> "Cancelado" Then

                                dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 9, "@SUCClave", dtNomina.Rows(0)("SUCClave"), "@CAJClave", "")

                                If Not dt Is Nothing Then
                                    If dt.Rows.Count > 0 Then
                                        If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= 1 Then
                                            FOLClave = dt.Rows(0)("FOLClave")
                                            Serie = dt.Rows(0)("Serie")
                                            Folio = dt.Rows(0)("FolioActual") + 1
                                            dt.Dispose()
                                            ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", FOLClave)
                                        End If
                                    Else
                                        MessageBox.Show("No se encuentran folios para el tipo de comprobante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                End If


                                    sRENClave = ModPOS.obtenerLlave

                                    ModPOS.Ejecuta("sp_copia_recibonomina", _
                                                      "@RENClave", dtRecibos.Rows(i)("RENClave"), _
                                                      "@NOMClave", sNOMClave, _
                                                      "@Copia", sRENClave, _
                                                      "@Serie", Serie, _
                                                      "@Folio", Folio, _
                                                      "@VersionNomina", IIf(dtNomina.Rows(0)("VersionNomina").GetType.Name = "DBNull", 1, dtNomina.Rows(0)("VersionNomina")), _
                                                      "@Usuario", ModPOS.UsuarioActual)
                                End If
                        Next

                        dtRecibos.Dispose()
                        dtNomina.Dispose()



                        actualizaGrid()

                    Case DialogResult.No

                End Select
            End If
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPicker.ValueChanged
        If cargado = True AndAlso (Periodo <> dtPicker.Value.Year) Then
            Periodo = dtPicker.Value.Year
            Me.actualizaGrid()
        End If
    End Sub
End Class
