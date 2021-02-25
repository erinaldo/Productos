Public Class FrmMtoOrdenes
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
    Friend WithEvents BtnOrdenCompra As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridOrdenes As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoOrdenes))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnOrdenCompra = New Janus.Windows.EditControls.UIButton()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.GridOrdenes = New Janus.Windows.GridEX.GridEX()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnEliminar)
        Me.GrpTickets.Controls.Add(Me.BtnModificar)
        Me.GrpTickets.Controls.Add(Me.BtnReimpresion)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.BtnOrdenCompra)
        Me.GrpTickets.Controls.Add(Me.CmbSucursal)
        Me.GrpTickets.Controls.Add(Me.GridOrdenes)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(784, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Orden de Compra"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(463, 16)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 120
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(304, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.Location = New System.Drawing.Point(400, 430)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar orden seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(592, 430)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar orden seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(496, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de Orden de Compra Seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(593, 18)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 118
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox1.TabIndex = 117
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Sucursal"
        '
        'BtnOrdenCompra
        '
        Me.BtnOrdenCompra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOrdenCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOrdenCompra.Image = CType(resources.GetObject("BtnOrdenCompra.Image"), System.Drawing.Image)
        Me.BtnOrdenCompra.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnOrdenCompra.Location = New System.Drawing.Point(688, 430)
        Me.BtnOrdenCompra.Name = "BtnOrdenCompra"
        Me.BtnOrdenCompra.Size = New System.Drawing.Size(90, 37)
        Me.BtnOrdenCompra.TabIndex = 6
        Me.BtnOrdenCompra.Text = "&Orden"
        Me.BtnOrdenCompra.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnOrdenCompra.ToolTipText = "Registro de Orden de Compra"
        Me.BtnOrdenCompra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(72, 16)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(385, 24)
        Me.CmbSucursal.TabIndex = 115
        '
        'GridOrdenes
        '
        Me.GridOrdenes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridOrdenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridOrdenes.ColumnAutoResize = True
        Me.GridOrdenes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridOrdenes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridOrdenes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridOrdenes.Location = New System.Drawing.Point(7, 46)
        Me.GridOrdenes.Name = "GridOrdenes"
        Me.GridOrdenes.RecordNavigator = True
        Me.GridOrdenes.Size = New System.Drawing.Size(771, 380)
        Me.GridOrdenes.TabIndex = 2
        Me.GridOrdenes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoOrdenes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoOrdenes"
        Me.Text = "Orden de Compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private sOrdenSelected As String
    Private sNombre As String
    Private sSUCClave As String

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False

    Private Sub FrmMtoOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

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

        refreshGrid()
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub

    Public Sub refreshGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, Me.GridOrdenes, "sp_muestra_ordenes", "@SUCClave", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridOrdenes.RootTable.Columns("ORDClave").Visible = False
        GridOrdenes.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridOrdenes.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridOrdenes.RootTable.FormatConditions.Add(fc)
    End Sub


    Private Sub GridOrdenes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridOrdenes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridOrdenes_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridOrdenes.SelectionChanged
        If Not GridOrdenes.GetValue(0) Is Nothing Then
            sOrdenSelected = GridOrdenes.GetValue("ORDClave")
            sNombre = GridOrdenes.GetValue("Folio")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True

        Else
            sOrdenSelected = ""
            sNombre = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridOrdenes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridOrdenes.DoubleClick
        If Not GridOrdenes.GetValue(0) Is Nothing Then
            modificarOrden()
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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
        ModPOS.MtoOrdenes.Dispose()
        ModPOS.MtoOrdenes = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOrdenCompra.Click
        If validaForm() Then
            If ModPOS.Orden Is Nothing Then
                ModPOS.Orden = New FrmOrden
                ModPOS.Orden.Padre = "Nuevo"
            End If
            ModPOS.Orden.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Orden.Show()
            ModPOS.Orden.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sOrdenSelected <> "" Then

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "RepOrden", "@COMClave", ModPOS.CompanyActual)
            Dim Reporte As String = CStr(dt.Rows(0)("Valor"))
            dt.Dispose()

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet

            If Reporte = "Clasico" Then
                pvtaDataSet.DataSetName = "pvtaDataSet"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_orden", "@ORDClave", sOrdenSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_orden", "@ORDClave", sOrdenSelected))
                OpenReport.PrintPreview("Orden de Compra", "CROrden.rpt", pvtaDataSet, "")
            Else
                pvtaDataSet.DataSetName = "pvtaDataSet"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_orden", "@ORDClave", sOrdenSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_orden", "@ORDClave", sOrdenSelected))
                OpenReport.PrintPreview("Orden de Compra", "CROrdenC.rpt", pvtaDataSet, "")
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado una Orden de Compra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarOrden()
        If sOrdenSelected <> "" Then
            If ModPOS.Orden Is Nothing Then
                ModPOS.Orden = New FrmOrden
                With ModPOS.Orden
                    .Text = "Modificar Orden de Compra"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_orden", "@ORDClave", Me.sOrdenSelected)

                    .ORDClave = dt.Rows(0)("ORDClave")
                    .PRVClave = dt.Rows(0)("PRVClave")
                    .Folio = dt.Rows(0)("Folio")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .SUCClave = dt.Rows(0)("SUCClave")
                    .Estado = dt.Rows(0)("Estado")
                    .Subtotal = dt.Rows(0)("Subtotal")
                    .Impuesto = dt.Rows(0)("ImpuestoTot")
                    .Total = dt.Rows(0)("Total")
                    .Solicita = dt.Rows(0)("Solicita")
                    .Motivo = dt.Rows(0)("Motivo")
                    .Nota = dt.Rows(0)("Nota")
                    .TxtRazonSocial.Text = dt.Rows(0)("NProveedor")
                    .TxtEstado.Text = dt.Rows(0)("NEstado")
                    .TxtClaveProv.Text = dt.Rows(0)("CProveedor")
                    dt.Dispose()

                End With
            End If

            ModPOS.Orden.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Orden.Show()
            ModPOS.Orden.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarOrden()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sOrdenSelected <> "" Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar la Orden de Compra: " & sNombre & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim dt As DataTable
                    Dim iEstado, iSurtido As Integer
                    dt = ModPOS.Recupera_Tabla("sp_recupera_orden", "@ORDClave", Me.sOrdenSelected)
                    iEstado = dt.Rows(0)("Estado")
                    dt.Dispose()

                    If iEstado <> 4 Then

                        dt = ModPOS.Recupera_Tabla("st_recupera_surtido_ord", "@ORDClave", Me.sOrdenSelected)
                        iSurtido = dt.Rows(0)("Surtido")
                        dt.Dispose()

                        If iSurtido = 0 Then
                            ModPOS.Ejecuta("sp_cancela_orden", "@ORDClave", sOrdenSelected, "@Usuario", ModPOS.UsuarioActual)
                            Cursor.Current = Cursors.WaitCursor
                            refreshGrid()
                            Cursor.Current = Cursors.Default
                        Else
                            MessageBox.Show("No es posible cancelar la Orden de Compra debido a que contiene partidas surtidas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Else
                        MessageBox.Show("No es posible cancelar la Orden de Compra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

            End Select
        End If

    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Cursor.Current = Cursors.WaitCursor
            refreshGrid()
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad = True Then
            If Not CmbSucursal.SelectedValue Is Nothing Then
                Periodo = dtPicker.Value.Year
                Mes = dtPicker.Value.Month
                Cursor.Current = Cursors.WaitCursor
                refreshGrid()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If bLoad = True Then
            If Not CmbSucursal.SelectedValue Is Nothing Then
                Periodo = dtPicker.Value.Year
                Mes = dtPicker.Value.Month
                Cursor.Current = Cursors.WaitCursor
                refreshGrid()
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub
End Class
