Public Class FrmMtoCompras
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCompra As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCompras As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEtiquetas As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoCompras))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnEtiquetas = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbSucursal = New Selling.StoreCombo
        Me.BtnCompra = New Janus.Windows.EditControls.UIButton
        Me.GridCompras = New Janus.Windows.GridEX.GridEX
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnEliminar)
        Me.GrpTickets.Controls.Add(Me.BtnEtiquetas)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.BtnModificar)
        Me.GrpTickets.Controls.Add(Me.BtnReimpresion)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox4)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.CmbSucursal)
        Me.GrpTickets.Controls.Add(Me.BtnCompra)
        Me.GrpTickets.Controls.Add(Me.GridCompras)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(784, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Compras"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(208, 429)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir "
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(304, 429)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 11
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar compra seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEtiquetas
        '
        Me.BtnEtiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEtiquetas.Icon = CType(resources.GetObject("BtnEtiquetas.Icon"), System.Drawing.Icon)
        Me.BtnEtiquetas.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnEtiquetas.Location = New System.Drawing.Point(400, 429)
        Me.BtnEtiquetas.Name = "BtnEtiquetas"
        Me.BtnEtiquetas.Size = New System.Drawing.Size(90, 37)
        Me.BtnEtiquetas.TabIndex = 13
        Me.BtnEtiquetas.Text = "&Etiquetas"
        Me.BtnEtiquetas.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnEtiquetas.ToolTipText = "Imprime etiquetas de código de barras de los productos de la compra"
        Me.BtnEtiquetas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(517, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Periodo"
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(592, 429)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 12
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar proveedor seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(496, 429)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de Compra seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(592, 16)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 130
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(36, 21)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(25, 17)
        Me.PictureBox4.TabIndex = 129
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.Location = New System.Drawing.Point(88, 14)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(292, 24)
        Me.CmbSucursal.TabIndex = 127
        '
        'BtnCompra
        '
        Me.BtnCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCompra.Image = CType(resources.GetObject("BtnCompra.Image"), System.Drawing.Image)
        Me.BtnCompra.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnCompra.Location = New System.Drawing.Point(688, 429)
        Me.BtnCompra.Name = "BtnCompra"
        Me.BtnCompra.Size = New System.Drawing.Size(90, 37)
        Me.BtnCompra.TabIndex = 6
        Me.BtnCompra.Text = "&Compra"
        Me.BtnCompra.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnCompra.ToolTipText = "Registro de Compra"
        Me.BtnCompra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridCompras
        '
        Me.GridCompras.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCompras.ColumnAutoResize = True
        Me.GridCompras.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCompras.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCompras.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCompras.Location = New System.Drawing.Point(7, 44)
        Me.GridCompras.Name = "GridCompras"
        Me.GridCompras.RecordNavigator = True
        Me.GridCompras.Size = New System.Drawing.Size(770, 379)
        Me.GridCompras.TabIndex = 2
        Me.GridCompras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoCompras
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoCompras"
        Me.Text = "Compras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Mes As Integer
    Public Periodo As Integer
    Private sSUCClave As String

    Private sCompraSelected As String

    Private dTotal As Double
    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False


    Public Sub refrescaGrid()
        Cursor.Current = Cursors.WaitCursor

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, Me.GridCompras, "sp_muestra_compras", "@SUCClave", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridCompras.RootTable.Columns("COMClave").Visible = False
        GridCompras.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridCompras.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCompras.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridCompras.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default

    End Sub


    Public Sub AbrirCompra(ByVal Cancelar As Boolean)
        If sCompraSelected <> "" Then
            If validaForm() Then
                If ModPOS.Compras Is Nothing Then
                    ModPOS.Compras = New FrmCompra
                    With ModPOS.Compras


                        Dim Orden As String
                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_compra", "@COMClave", Me.sCompraSelected)
                        Orden = IIf(dt.Rows(0)("ORDClave").GetType.Name = "DBNull", "", dt.Rows(0)("ORDClave"))
                        .COMClave = dt.Rows(0)("COMClave")
                        .ALMClave = dt.Rows(0)("ALMClave")
                        .SUCClave = dt.Rows(0)("SUCClave")
                        .Folio = dt.Rows(0)("Factura")
                        .ORDClave = Orden
                        .PRVClave = dt.Rows(0)("PRVClave")
                        .CargaDatosProveedor(dt.Rows(0)("CProveedor"))
                        .FechaCompra = dt.Rows(0)("FechaFactura")
                        .FechaVencimiento = dt.Rows(0)("FechaVencimiento")
                        .SubTotal = dt.Rows(0)("Subtotal")
                        .Descuento = dt.Rows(0)("Descuentotot")
                        .Impuesto = dt.Rows(0)("Impuestotot")
                        .Total = dt.Rows(0)("Total")
                        .Saldo = dt.Rows(0)("Saldo")
                        .Fase = IIf(dt.Rows(0)("Fase").GetType.Name = "DBNull", True, dt.Rows(0)("Fase"))
                        .TxtClaveProv.Text = dt.Rows(0)("CProveedor")
                        .Motivo = IIf(dt.Rows(0)("Motivo").GetType.Name = "DBNull", "", dt.Rows(0)("Motivo"))
                        .Solicita = IIf(dt.Rows(0)("Solicita").GetType.Name = "DBNull", "", dt.Rows(0)("Solicita"))
                        .Nota = IIf(dt.Rows(0)("Nota").GetType.Name = "DBNull", "", dt.Rows(0)("Nota"))
                        .Estado = dt.Rows(0)("Estado")
                        dt.Dispose()
                       
                       
                        If Cancelar Then
                            .Padre = "Eliminar"
                            .Text = "Cancelación de Compra"
                        Else
                            .Padre = "Modificar"
                            .Text = "Modificar Compra"
                        End If

                        If Cancelar OrElse .Fase = True Then
                            .GrpGeneral.Enabled = False
                            .GrpDetalle.Enabled = False
                        End If

                    End With
                End If
                ModPOS.Compras.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Compras.Show()
                ModPOS.Compras.BringToFront()
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub FrmBuscaTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox4
       
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


        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        refrescaGrid()

        bLoad = True
    End Sub


    Private Sub GridCompras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCompras.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnReimpresion.PerformClick()
        End If
    End Sub

    Private Sub GridCompras_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCompras.SelectionChanged
        If Not GridCompras.GetValue(0) Is Nothing Then
            sCompraSelected = GridCompras.GetValue("COMClave")
            dTotal = GridCompras.GetValue("Total")
        Else
            sCompraSelected = ""
            dTotal = 0
        End If
    End Sub

    Private Sub GridCompras_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCompras.DoubleClick
        If Not GridCompras.GetValue(0) Is Nothing Then
            Me.AbrirCompra(False)
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

      

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmMtoCompras_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoCompras.Dispose()
        ModPOS.MtoCompras = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCompra.Click
        If validaForm() Then
            If ModPOS.Compras Is Nothing Then
                ModPOS.Compras = New FrmCompra
                ModPOS.Compras.Padre = "Nuevo"
                ModPOS.Compras.SUCClave = CmbSucursal.SelectedValue
            End If
            ModPOS.Compras.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Compras.Show()
            ModPOS.Compras.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sCompraSelected <> "" Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_compra", "@COMClave", sCompraSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_compra", "@COMClave", sCompraSelected))
            OpenReport.PrintPreview("Compra", "CRCompra.rpt", pvtaDataSet, "")
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Me.AbrirCompra(True)
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub



    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.AbrirCompra(False)
    End Sub

    Private Sub BtnEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEtiquetas.Click
        If sCompraSelected <> "" Then
            Dim a As New FrmPrintLabelCode
            a.COMClave = sCompraSelected
            a.iTipoDOc = 1
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("¡No se ha seleccionado una Compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub
End Class
