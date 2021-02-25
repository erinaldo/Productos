Public Class FrmMtoCaja
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
    Friend WithEvents GridCaja As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoCaja))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV = New System.Windows.Forms.GroupBox()
        Me.GridCaja = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV.SuspendLayout()
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(399, 518)
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
        Me.BtnModificar.Location = New System.Drawing.Point(591, 518)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar caja seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(495, 518)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar caja seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPDV
        '
        Me.GrpPDV.Controls.Add(Me.BtnCancelar)
        Me.GrpPDV.Controls.Add(Me.GridCaja)
        Me.GrpPDV.Controls.Add(Me.BtnEliminar)
        Me.GrpPDV.Controls.Add(Me.BtnModificar)
        Me.GrpPDV.Controls.Add(Me.BtnAgregar)
        Me.GrpPDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPDV.Location = New System.Drawing.Point(0, 0)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(784, 561)
        Me.GrpPDV.TabIndex = 11
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Cajas"
        '
        'GridCaja
        '
        Me.GridCaja.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCaja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCaja.ColumnAutoResize = True
        Me.GridCaja.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCaja.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCaja.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCaja.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCaja.Location = New System.Drawing.Point(7, 15)
        Me.GridCaja.Name = "GridCaja"
        Me.GridCaja.RecordNavigator = True
        Me.GridCaja.Size = New System.Drawing.Size(770, 498)
        Me.GridCaja.TabIndex = 1
        Me.GridCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(687, 518)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nueva caja"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoCaja"
        Me.Text = "Mantenimiento de Cajas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPDV.ResumeLayout(False)
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sCAJASelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        ModPOS.ActualizaGrid(True, Me.GridCaja, "sp_muestra_caja", "@COMClave", ModPOS.CompanyActual)
        Me.GridCaja.RootTable.Columns("ID").Visible = False
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridCaja_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCaja.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridCaja_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCaja.SelectionChanged
        If Not GridCaja.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sCAJASelected = GridCaja.GetValue(0)
            Me.sNombre = GridCaja.GetValue(1)
        Else
            Me.sCAJASelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Caja Is Nothing Then
            ModPOS.Caja = New FrmCaja
            With ModPOS.Caja
                .Text = "Agregar Caja"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Caja.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Caja.Show()
        ModPOS.Caja.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarCaja()
    End Sub

    Public Sub modificarCaja()
        If sCAJASelected <> "" Then

            If ModPOS.Caja Is Nothing Then

                ModPOS.Caja = New FrmCaja
                With ModPOS.Caja
                    .Text = "Modificar Caja"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtNombre.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", Me.sCAJASelected)

                    .CAJClave = dt.Rows(0)("CAJClave")
                    .Clave = dt.Rows(0)("Clave")
                    .Nombre = dt.Rows(0)("Nombre")
                    .Estado = dt.Rows(0)("Estado")
                    .Fase = dt.Rows(0)("Fase")
                    .TIKClave = dt.Rows(0)("TIKClave")
                    .TICDevolucion = dt.Rows(0)("TICDevolucion")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name <> "DBNull", dt.Rows(0)("SUCClave"), "")
                    .LimiteEfectivo = dt.Rows(0)("LimiteEfectivo")
                    .LimiteCheque = dt.Rows(0)("LimiteCheque")
                    .LimiteVales = dt.Rows(0)("LimiteVale")
                    .ImpFac = dt.Rows(0)("ImpresoraFac")
                    .ImpRec = dt.Rows(0)("ImpresoraRec")
                    .Procesador = dt.Rows(0)("Procesador")
                    .Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name <> "DBNull", dt.Rows(0)("Cajon"), False)
                    .ALMClave = IIf(dt.Rows(0)("ALMClave").GetType.Name <> "DBNull", dt.Rows(0)("ALMClave"), "")
                    .Manual = IIf(dt.Rows(0)("Manual").GetType.Name <> "DBNull", dt.Rows(0)("Manual"), 0)
                    .Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name <> "DBNull", dt.Rows(0)("url_aplicacion"), "")
                    .PRNClavePic = IIf(dt.Rows(0)("PRNClavePic").GetType.Name <> "DBNull", dt.Rows(0)("PRNClavePic"), "")
                    .copiaCredito = IIf(dt.Rows(0)("copiaCredito").GetType.Name <> "DBNull", dt.Rows(0)("copiaCredito"), 0)
                    .CorteDetallado = IIf(dt.Rows(0)("CorteDetallado").GetType.Name <> "DBNull", dt.Rows(0)("CorteDetallado"), 0)
                    .Transferencia = IIf(dt.Rows(0)("Transferencia").GetType.Name <> "DBNull", dt.Rows(0)("Transferencia"), 0)
                    .FormatoCorte = IIf(dt.Rows(0)("FormatoCorte").GetType.Name <> "DBNull", dt.Rows(0)("FormatoCorte"), "")
                    .Stage = IIf(dt.Rows(0)("Stage").GetType.Name <> "DBNull", dt.Rows(0)("Stage"), "")
                    .StageCancelacion = IIf(dt.Rows(0)("StageCancelacion").GetType.Name <> "DBNull", dt.Rows(0)("StageCancelacion"), "")
                    .Bloqueo = IIf(dt.Rows(0)("Bloqueo").GetType.Name <> "DBNull", dt.Rows(0)("Bloqueo"), "0|0|0|0|0|0|0|0|0|0|0")
                    .ConfirmarAbono = IIf(dt.Rows(0)("ConfirmaAbono").GetType.Name <> "DBNull", dt.Rows(0)("ConfirmaAbono"), 0)
                    .reciboTicket = IIf(dt.Rows(0)("reciboTicket").GetType.Name <> "DBNull", dt.Rows(0)("reciboTicket"), 0)
                    .mostrarNotas = IIf(dt.Rows(0)("muestraNotas").GetType.Name <> "DBNull", dt.Rows(0)("muestraNotas"), 0)
                    .incluirCierre = IIf(dt.Rows(0)("incluirCierre").GetType.Name <> "DBNull", dt.Rows(0)("incluirCierre"), False)
                    .Mostrador = IIf(dt.Rows(0)("Mostrador").GetType.Name <> "DBNull", dt.Rows(0)("Mostrador"), "")
                    .Anticipos = IIf(dt.Rows(0)("Anticipos").GetType.Name <> "DBNull", dt.Rows(0)("Anticipos"), 0)
                    .StageLU = IIf(dt.Rows(0)("StageLU").GetType.Name <> "DBNull", dt.Rows(0)("StageLU"), "")
                    .FormatoRecibo = IIf(dt.Rows(0)("FormatoRecibo").GetType.Name <> "DBNull", dt.Rows(0)("FormatoRecibo"), "Carta")
                    .ALMClaveDev = IIf(dt.Rows(0)("ALMClaveDev").GetType.Name <> "DBNull", dt.Rows(0)("ALMClaveDev"), "")
                    .PDVClave = IIf(dt.Rows(0)("PDVClave").GetType.Name <> "DBNull", dt.Rows(0)("PDVClave"), "")
                    .idCajero = IIf(dt.Rows(0)("idCajero").GetType.Name <> "DBNull", dt.Rows(0)("idCajero"), 0)
                    .idPOS = IIf(dt.Rows(0)("idPOS").GetType.Name <> "DBNull", dt.Rows(0)("idPOS"), "")
                    .passCajero = IIf(dt.Rows(0)("passCajero").GetType.Name <> "DBNull", dt.Rows(0)("passCajero"), "")

                    If dt.Rows(0)("IdClase").GetType.Name = "DBNull" Then
                        .IdClase = ""
                    Else
                        .IdClase = dt.Rows(0)("IdClase")
                    End If


                    If dt.Rows(0)("IdClaseCancelacion").GetType.Name = "DBNull" Then
                        .idClaseCancel = ""
                    Else
                        .idClaseCancel = dt.Rows(0)("IdClaseCancelacion")
                    End If
                    dt.Dispose()

                End With
            End If

            ModPOS.Caja.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Caja.Show()
            ModPOS.Caja.BringToFront()

        End If
    End Sub

    Private Sub GridPDV_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCaja.DoubleClick
        modificarCaja()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sCAJASelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Caja :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_caja", "@Caja", sCAJASelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridCaja, "sp_muestra_caja", "@COMClave", ModPOS.CompanyActual)
                    Me.GridCaja.RootTable.Columns("ID").Visible = False

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCajas.Dispose()
        ModPOS.MtoCajas = Nothing
    End Sub
End Class
