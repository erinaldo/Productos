Public Class FrmMtoLiquid
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpLiquidaciones As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridLiquidaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDiaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoLiquid))
        Me.GrpLiquidaciones = New System.Windows.Forms.GroupBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDiaTrabajo = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridLiquidaciones = New Janus.Windows.GridEX.GridEX()
        Me.GrpLiquidaciones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpLiquidaciones
        '
        Me.GrpLiquidaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpLiquidaciones.Controls.Add(Me.BtnSalir)
        Me.GrpLiquidaciones.Controls.Add(Me.BtnEliminar)
        Me.GrpLiquidaciones.Controls.Add(Me.BtnModificar)
        Me.GrpLiquidaciones.Controls.Add(Me.BtnReimpresion)
        Me.GrpLiquidaciones.Controls.Add(Me.BtnAgregar)
        Me.GrpLiquidaciones.Controls.Add(Me.Label3)
        Me.GrpLiquidaciones.Controls.Add(Me.dtpDiaTrabajo)
        Me.GrpLiquidaciones.Controls.Add(Me.PictureBox1)
        Me.GrpLiquidaciones.Controls.Add(Me.CmbSucursal)
        Me.GrpLiquidaciones.Controls.Add(Me.Label1)
        Me.GrpLiquidaciones.Controls.Add(Me.GridLiquidaciones)
        Me.GrpLiquidaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpLiquidaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpLiquidaciones.ForeColor = System.Drawing.Color.Black
        Me.GrpLiquidaciones.Location = New System.Drawing.Point(0, 0)
        Me.GrpLiquidaciones.Name = "GrpLiquidaciones"
        Me.GrpLiquidaciones.Size = New System.Drawing.Size(789, 473)
        Me.GrpLiquidaciones.TabIndex = 1
        Me.GrpLiquidaciones.TabStop = False
        Me.GrpLiquidaciones.Text = "Liquidaciones"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(309, 427)
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
        Me.BtnEliminar.Location = New System.Drawing.Point(405, 427)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar transferencia seleccionada"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(597, 427)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar transferencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Image = CType(resources.GetObject("BtnReimpresion.Image"), System.Drawing.Image)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(501, 427)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near
        Me.BtnReimpresion.ToolTipText = "Reimpresión de transferencia seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(693, 427)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 12
        Me.BtnAgregar.Text = "&Agregar "
        Me.BtnAgregar.ToolTipText = "Crear nuevo cliente"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(569, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 18)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Día de Trabajo"
        '
        'dtpDiaTrabajo
        '
        Me.dtpDiaTrabajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDiaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiaTrabajo.Location = New System.Drawing.Point(692, 17)
        Me.dtpDiaTrabajo.Name = "dtpDiaTrabajo"
        Me.dtpDiaTrabajo.Size = New System.Drawing.Size(88, 22)
        Me.dtpDiaTrabajo.TabIndex = 42
        Me.dtpDiaTrabajo.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(451, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(81, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(363, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridLiquidaciones
        '
        Me.GridLiquidaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridLiquidaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLiquidaciones.ColumnAutoResize = True
        Me.GridLiquidaciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLiquidaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLiquidaciones.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridLiquidaciones.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridLiquidaciones.Location = New System.Drawing.Point(7, 45)
        Me.GridLiquidaciones.Name = "GridLiquidaciones"
        Me.GridLiquidaciones.RecordNavigator = True
        Me.GridLiquidaciones.Size = New System.Drawing.Size(776, 376)
        Me.GridLiquidaciones.TabIndex = 2
        Me.GridLiquidaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoLiquid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpLiquidaciones)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoLiquid"
        Me.Text = "Mto Liquidaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpLiquidaciones.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sLiquidacionSelected As String
    Private sFolio, sFase As String

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String

    Private bLoad As Boolean = False

    Private Sub FrmMtoLiquid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbSucursal.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        dtpDiaTrabajo.Value = Today.Date

        Dim sSUCClave As String

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If


        ModPOS.ActualizaGrid(False, GridLiquidaciones, "sp_muestra_liquidaciones", "@Sucursal", sSUCClave, "@DiaTrabajo", dtpDiaTrabajo.Value)
        GridLiquidaciones.RootTable.Columns("LIQClave").Visible = False
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridLiquidaciones.RootTable.Columns("Fase"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cerrada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
        GridLiquidaciones.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default

        bLoad = True
    End Sub

    Private Sub GridTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridLiquidaciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridLiquidaciones_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridLiquidaciones.SelectionChanged
        If Not GridLiquidaciones.GetValue(0) Is Nothing Then
            sLiquidacionSelected = GridLiquidaciones.GetValue("LIQClave")
            sFolio = GridLiquidaciones.GetValue("Folio")
            sFase = GridLiquidaciones.GetValue("Fase")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True
        Else
            sLiquidacionSelected = ""
            sFolio = ""
            sFase = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridLiquidaciones_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridLiquidaciones.DoubleClick
        If Not GridLiquidaciones.GetValue(0) Is Nothing Then
            modificarLiquidacion()
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

    Private Sub FrmMtoLiquid_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoLiquid.Dispose()
        ModPOS.MtoLiquid = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub imprimirLiquidacion(ByVal LIQClave As String)

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_movimientos_liq", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_general", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_corte", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_pagos", "@LIQClave", LIQClave))

        OpenReport.PrintPreview("Liquidación", "CRLiquidacion.rpt", pvtaDataSet, "")

        'OpenReport.Print("CRLiquidacion.rpt", pvtaDataSet, "", sImpresora)

    End Sub

    Private Sub imprimirComision(ByVal LIQClave As String)


        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_general", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_comision_prod", "@LIQClave", LIQClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_liq_comision_vta", "@LIQClave", LIQClave))

        OpenReport.PrintPreview("Comisiones", "CRComision.rpt", pvtaDataSet, "")

        'OpenReport.Print("CRComision.rpt", pvtaDataSet, "", sImpresora)

    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sLiquidacionSelected <> "" Then
            imprimirLiquidacion(sLiquidacionSelected)
            imprimirComision(sLiquidacionSelected)
        Else
            MessageBox.Show("¡No se ha seleccionado una Liquidación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarLiquidacion()
        If sLiquidacionSelected <> "" Then
            If ModPOS.Liquid Is Nothing Then
                ModPOS.Liquid = New FrmLiquid
                With ModPOS.Liquid
                    .Text = "Modificar Liquidación"
                    .StartPosition = FormStartPosition.CenterScreen

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_liquidacion", "@Folio", Me.sLiquidacionSelected, "@Tipo", 2)

                    .LIQClave = dt.Rows(0)("LIQClave")
                    .DiaTrabajo = dt.Rows(0)("DiaTrabajo")
                    .PDVClave = dt.Rows(0)("PDVClave")
                    .CAJClave = dt.Rows(0)("CAJClave")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .SUCClave = dt.Rows(0)("SUCClave")
                    .Folio = dt.Rows(0)("Folio")
                    .ClavePDV = dt.Rows(0)("ClavePDV")
                    .NombrePDV = dt.Rows(0)("NombrePDV")
                    .ClaveVEN = dt.Rows(0)("ClaveVEN")
                    .NombreVEN = dt.Rows(0)("NombreVEN")
                    .VendedorClave = dt.Rows(0)("USRClave")
                    .Fase = dt.Rows(0)("Fase")
                    .LblFase.Text = dt.Rows(0)("Descripcion")
                    dt.Dispose()
                End With
            End If

            ModPOS.Liquid.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Liquid.Show()
            ModPOS.Liquid.BringToFront()
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarLiquidacion()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sLiquidacionSelected <> "" Then

            If sFase <> "Cerrada" Then
                MessageBox.Show("No es posible cancelar la liquidacion debido a que ya ha sido cerrada")
                Exit Sub
            End If

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & sFolio & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_cancela_liquidacion", "@LIQClave", sLiquidacionSelected, "@Usuario", ModPOS.UsuarioActual)
            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado una Liquidación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub Combos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                Cursor.Current = Cursors.WaitCursor
                ModPOS.ActualizaGrid(False, GridLiquidaciones, "sp_muestra_liquidaciones", "@Sucursal", CmbSucursal.SelectedValue, "@DiaTrabajo", dtpDiaTrabajo.Value)
                GridLiquidaciones.RootTable.Columns("LIQClave").Visible = False
                Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridLiquidaciones.RootTable.Columns("Fase"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cerrada")
                fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
                GridLiquidaciones.RootTable.FormatConditions.Add(fc)
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

 
    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim a As New FrmAperturaLiquid
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub dtpDiaTrabajo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDiaTrabajo.ValueChanged
        If bLoad Then
            If validaForm() Then
                Cursor.Current = Cursors.WaitCursor
                ModPOS.ActualizaGrid(False, GridLiquidaciones, "sp_muestra_liquidaciones", "@Sucursal", CmbSucursal.SelectedValue, "@DiaTrabajo", dtpDiaTrabajo.Value)
                GridLiquidaciones.RootTable.Columns("LIQClave").Visible = False
                Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridLiquidaciones.RootTable.Columns("Fase"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cerrada")
                fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
                GridLiquidaciones.RootTable.FormatConditions.Add(fc)
                Cursor.Current = Cursors.Default
            End If
        End If
    End Sub

End Class
