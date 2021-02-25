Public Class FrmMtoPDV
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
    Friend WithEvents GridPDV As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoPDV))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV = New System.Windows.Forms.GroupBox()
        Me.GridPDV = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV.SuspendLayout()
        CType(Me.GridPDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(399, 517)
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
        Me.BtnModificar.Location = New System.Drawing.Point(591, 517)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar punto de venta seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(495, 517)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 13
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar punto de venta seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpPDV
        '
        Me.GrpPDV.Controls.Add(Me.BtnCancelar)
        Me.GrpPDV.Controls.Add(Me.GridPDV)
        Me.GrpPDV.Controls.Add(Me.BtnEliminar)
        Me.GrpPDV.Controls.Add(Me.BtnModificar)
        Me.GrpPDV.Controls.Add(Me.BtnAgregar)
        Me.GrpPDV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPDV.Location = New System.Drawing.Point(0, 0)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(784, 561)
        Me.GrpPDV.TabIndex = 11
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Puntos de Venta"
        '
        'GridPDV
        '
        Me.GridPDV.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPDV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPDV.ColumnAutoResize = True
        Me.GridPDV.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPDV.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPDV.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPDV.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPDV.Location = New System.Drawing.Point(7, 15)
        Me.GridPDV.Name = "GridPDV"
        Me.GridPDV.RecordNavigator = True
        Me.GridPDV.Size = New System.Drawing.Size(770, 495)
        Me.GridPDV.TabIndex = 1
        Me.GridPDV.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(687, 517)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Agregar nuevo punto de venta"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMtoPDV
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(553, 378)
        Me.Name = "FrmMtoPDV"
        Me.Text = "Mantenimiento de Puntos de Venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPDV.ResumeLayout(False)
        CType(Me.GridPDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sPDVSelected As String
    Private sNombre As String

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor
        Try
            ModPOS.ActualizaGrid(True, Me.GridPDV, "sp_muestra_pdv", "@COMClave", ModPOS.CompanyActual)
            Me.GridPDV.RootTable.Columns("PDVClave").Visible = False
        Catch ex As Exception
        End Try
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub GridPDV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridPDV.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridPDV_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPDV.SelectionChanged
        If Not GridPDV.GetValue(0) Is Nothing Then
            Me.BtnModificar.Enabled = True
            Me.BtnEliminar.Enabled = True
            Me.sPDVSelected = GridPDV.GetValue("PDVClave")
            Me.sNombre = GridPDV.GetValue("Referencia") & " " & GridPDV.GetValue("Descripción")
        Else
            Me.sPDVSelected = ""
            Me.sNombre = ""
            Me.BtnModificar.Enabled = False
            Me.BtnEliminar.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.PDV Is Nothing Then
            ModPOS.PDV = New FrmPDV
            With ModPOS.PDV
                .Text = "Agregar Punto de Venta"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
                .PRNClave = ""
            End With
        End If
        ModPOS.PDV.StartPosition = FormStartPosition.CenterScreen
        ModPOS.PDV.Show()
        ModPOS.PDV.BringToFront()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        modificarPDV()
    End Sub

    Public Sub modificarPDV()
        If sPDVSelected <> "" Then

            If ModPOS.PDV Is Nothing Then

                ModPOS.PDV = New FrmPDV
                With ModPOS.PDV
                    .Text = "Modificar Punto de Venta"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .TxtNombre.ReadOnly = True

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_pdv", "@PDV", Me.sPDVSelected)

                    .PDVClave = dt.Rows(0)("PDVClave")
                    .Descripcion = dt.Rows(0)("Descripcion")
                    .PRNClave = dt.Rows(0)("PRNClave")
                    .Referencia = dt.Rows(0)("Referencia")
                    .Estado = dt.Rows(0)("Estado")
                    .Mostrador = dt.Rows(0)("Mostrador")
                    .Fase = dt.Rows(0)("Fase")
                    .CAJClave = dt.Rows(0)("CAJClave")
                    .Supervisor = dt.Rows(0)("Supervisor")
                    .Caja = Math.Abs(CInt(dt.Rows(0)("Caja")))
                    .Redondeo = Math.Abs(CInt(dt.Rows(0)("Redondeo")))
                    .ModPrecio = Math.Abs(CInt(dt.Rows(0)("CambiaPrecio")))
                    .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
                    .Frase = dt.Rows(0)("Frase")
                    .TIKClave = dt.Rows(0)("TIKClave")
                    .ALMClave = IIf(dt.Rows(0)("ALMClave").GetType.Name = "DBNull", "", dt.Rows(0)("ALMClave"))
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
                    .Agotamiento = Math.Abs(CInt(dt.Rows(0)("Agotamiento")))
                    .ModPrecioServicio = Math.Abs(CInt(dt.Rows(0)("ModPrecioServicio")))
                    .Procesador = dt.Rows(0)("Procesador")
                    .Tipo = dt.Rows(0)("Tipo")
                    .NumTickets = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))
                    .SolicitaVendedor = Math.Abs(CInt(dt.Rows(0)("SolicitaVendedor")))
                    .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))

                    If dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull" Then
                        .Display = 0
                    Else
                        .Display = Math.Abs(CInt(dt.Rows(0)("PoleDisplay")))
                    End If

                    .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
                    .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
                    .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
                    .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))

             
                    If dt.Rows(0)("Devolucion").GetType.Name = "DBNull" Then
                        .Devolucion = 0
                    Else
                        .Devolucion = Math.Abs(CInt(dt.Rows(0)("Devolucion")))
                    End If


                    If dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull" Then
                        .ValidaInventario = 0
                    Else
                        .ValidaInventario = Math.Abs(CInt(dt.Rows(0)("ValidaInventario")))
                    End If

                    If dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull" Then
                        .ActivarCotizacion = 0
                    Else
                        .ActivarCotizacion = Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion")))
                    End If

                    .TipoVenta = IIf(dt.Rows(0)("TipoVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoVenta"))



                    If dt.Rows(0)("Remoto").GetType.Name = "DBNull" Then
                        .Remoto = 0
                    Else
                        .Remoto = Math.Abs(CInt(dt.Rows(0)("Remoto")))
                    End If

                    If dt.Rows(0)("BloquearPrecio").GetType.Name = "DBNull" Then
                        .BloquearPrecio = 0
                    Else
                        .BloquearPrecio = Math.Abs(CInt(dt.Rows(0)("BloquearPrecio")))
                    End If

                    If dt.Rows(0)("Liberar").GetType.Name = "DBNull" Then
                        .Liberar = 0
                    Else
                        .Liberar = Math.Abs(CInt(dt.Rows(0)("Liberar")))
                    End If

                    If dt.Rows(0)("ImprimirRemoto").GetType.Name = "DBNull" Then
                        .ImprimirRemoto = 0
                    Else
                        .ImprimirRemoto = Math.Abs(CInt(dt.Rows(0)("ImprimirRemoto")))
                    End If

                    If dt.Rows(0)("IdClase").GetType.Name = "DBNull" Then
                        .IdClase = ""
                    Else
                        .IdClase = dt.Rows(0)("IdClase")
                    End If


                    If dt.Rows(0)("FormatoLogo").GetType.Name = "DBNull" Then
                        .FormatoLogo = ""
                    Else
                        .FormatoLogo = dt.Rows(0)("FormatoLogo")
                    End If

                    .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                    .StageSurtido = IIf(dt.Rows(0)("StageSurtido").GetType.Name = "DBNull", "", dt.Rows(0)("StageSurtido"))

                    dt.Dispose()

                End With
            End If

            ModPOS.PDV.StartPosition = FormStartPosition.CenterScreen
            ModPOS.PDV.Show()
            ModPOS.PDV.BringToFront()

        End If
    End Sub

    Private Sub GridPDV_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridPDV.DoubleClick
        modificarPDV()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sPDVSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Punto de Venta :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_pdv", "@PDV", sPDVSelected, "@Usuario", ModPOS.UsuarioActual)

                    ModPOS.ActualizaGrid(True, Me.GridPDV, "sp_muestra_pdv", "@COMClave", ModPOS.CompanyActual)
                    Me.GridPDV.RootTable.Columns("PDVClave").Visible = False
                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub FrmMtoPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoPDV.Dispose()
        ModPOS.MtoPDV = Nothing

    End Sub
End Class
