Public Class FrmMtoAcondicionado
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
    Friend WithEvents GrpTransferencia As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAcondicionado As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAcondicionado As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConfirmación As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoAcondicionado))
        Me.GrpTransferencia = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.btnConfirmación = New Janus.Windows.EditControls.UIButton
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnAcondicionado = New Janus.Windows.EditControls.UIButton
        Me.GridAcondicionado = New Janus.Windows.GridEX.GridEX
        Me.GrpTransferencia.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAcondicionado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTransferencia
        '
        Me.GrpTransferencia.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTransferencia.Controls.Add(Me.PictureBox2)
        Me.GrpTransferencia.Controls.Add(Me.CmbSucursal)
        Me.GrpTransferencia.Controls.Add(Me.PictureBox1)
        Me.GrpTransferencia.Controls.Add(Me.Label1)
        Me.GrpTransferencia.Controls.Add(Me.CmbAlmacen)
        Me.GrpTransferencia.Controls.Add(Me.Label2)
        Me.GrpTransferencia.Controls.Add(Me.BtnEliminar)
        Me.GrpTransferencia.Controls.Add(Me.BtnSalir)
        Me.GrpTransferencia.Controls.Add(Me.btnConfirmación)
        Me.GrpTransferencia.Controls.Add(Me.BtnModificar)
        Me.GrpTransferencia.Controls.Add(Me.BtnReimpresion)
        Me.GrpTransferencia.Controls.Add(Me.Label3)
        Me.GrpTransferencia.Controls.Add(Me.dtPicker)
        Me.GrpTransferencia.Controls.Add(Me.BtnAcondicionado)
        Me.GrpTransferencia.Controls.Add(Me.GridAcondicionado)
        Me.GrpTransferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTransferencia.ForeColor = System.Drawing.Color.Black
        Me.GrpTransferencia.Location = New System.Drawing.Point(0, 0)
        Me.GrpTransferencia.Name = "GrpTransferencia"
        Me.GrpTransferencia.Size = New System.Drawing.Size(789, 473)
        Me.GrpTransferencia.TabIndex = 1
        Me.GrpTransferencia.TabStop = False
        Me.GrpTransferencia.Text = "Acondicionado"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(539, 13)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 131
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(85, 18)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 129
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(52, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox1.TabIndex = 128
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(495, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(572, 10)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 126
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Sucursal"
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(298, 430)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar acondicionado seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(202, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnConfirmación
        '
        Me.btnConfirmación.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmación.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirmación.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmación.Icon = CType(resources.GetObject("btnConfirmación.Icon"), System.Drawing.Icon)
        Me.btnConfirmación.Location = New System.Drawing.Point(394, 430)
        Me.btnConfirmación.Name = "btnConfirmación"
        Me.btnConfirmación.Size = New System.Drawing.Size(102, 37)
        Me.btnConfirmación.TabIndex = 13
        Me.btnConfirmación.Text = "&Confirmación"
        Me.btnConfirmación.ToolTipText = "Confirmación de acondicionado"
        Me.btnConfirmación.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(597, 430)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 11
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar acondicionado seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(501, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Imprimir"
        Me.BtnReimpresion.ToolTipText = "Reimpresión de acondicionado seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(495, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CausesValidation = False
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(572, 36)
        Me.dtPicker.MaxDate = New Date(9998, 12, 28, 0, 0, 0, 0)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(211, 22)
        Me.dtPicker.TabIndex = 54
        '
        'BtnAcondicionado
        '
        Me.BtnAcondicionado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAcondicionado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAcondicionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcondicionado.Icon = CType(resources.GetObject("BtnAcondicionado.Icon"), System.Drawing.Icon)
        Me.BtnAcondicionado.Location = New System.Drawing.Point(693, 430)
        Me.BtnAcondicionado.Name = "BtnAcondicionado"
        Me.BtnAcondicionado.Size = New System.Drawing.Size(90, 37)
        Me.BtnAcondicionado.TabIndex = 6
        Me.BtnAcondicionado.Text = "&Acond."
        Me.BtnAcondicionado.ToolTipText = "Nuevo Acondicionado"
        Me.BtnAcondicionado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridAcondicionado
        '
        Me.GridAcondicionado.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAcondicionado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAcondicionado.ColumnAutoResize = True
        Me.GridAcondicionado.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAcondicionado.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAcondicionado.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAcondicionado.Location = New System.Drawing.Point(7, 62)
        Me.GridAcondicionado.Name = "GridAcondicionado"
        Me.GridAcondicionado.RecordNavigator = True
        Me.GridAcondicionado.Size = New System.Drawing.Size(776, 362)
        Me.GridAcondicionado.TabIndex = 2
        Me.GridAcondicionado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoAcondicionado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpTransferencia)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoAcondicionado"
        Me.Text = "Acondicionado de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTransferencia.ResumeLayout(False)
        Me.GrpTransferencia.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAcondicionado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private SUCClave As String
    Private sALMClave As String

    Private sAcondicionadoSelected As String
    Private sNombre As String

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private dtAcondicionado As DataTable

    Private bLoad As Boolean = False

    Private Sub FrmMtoAcondicionado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

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


        If Not CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = CmbSucursal.SelectedValue

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With

        Else
            SUCClave = ""
        End If

        If Not CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = CmbAlmacen.SelectedValue
        Else
            sALMClave = ""
        End If

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month




        refrescaGrid()


    End Sub

    Public Sub refrescaGrid()
        bLoad = False
        Cursor.Current = Cursors.WaitCursor

        If CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        Else
            sALMClave = CmbAlmacen.SelectedValue
        End If

        If Not dtAcondicionado Is Nothing Then
            dtAcondicionado.Dispose()
        End If

        dtAcondicionado = ModPOS.Recupera_Tabla("sp_muestra_acondicionado", "@Almacen", sALMClave, "@Periodo", Periodo, "@Mes", Mes)
        GridAcondicionado.DataSource = dtAcondicionado
        GridAcondicionado.RetrieveStructure()

        Me.GridAcondicionado.RootTable.Columns("ACOClave").Visible = False
        Me.GridAcondicionado.RootTable.Columns("iEstado").Visible = False
        Me.GridAcondicionado.RootTable.Columns("Total").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridAcondicionado.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridAcondicionado.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub

    Private Sub GridTransferencia_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAcondicionado.CurrentCellChanged
        If Not GridAcondicionado.CurrentColumn Is Nothing Then
            If GridAcondicionado.CurrentColumn.Caption = "Marca" Then
                GridAcondicionado.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridAcondicionado.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridAcondicionado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridTransferencia_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridAcondicionado.SelectionChanged
        If Not GridAcondicionado.GetValue(0) Is Nothing Then
            sAcondicionadoSelected = GridAcondicionado.GetValue("ACOClave")
            sNombre = GridAcondicionado.GetValue("Folio")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True

        Else
            sAcondicionadoSelected = ""
            sNombre = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridTransferencia_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridAcondicionado.DoubleClick
        If Not GridAcondicionado.GetValue(0) Is Nothing Then
            modificarTransferencia()
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If SUCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If sALMClave = "" Then
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

    Private Sub FrmMtoAcondicionado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoAcondicionado.Dispose()
        ModPOS.MtoAcondicionado = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAcondicionado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcondicionado.Click
        If validaForm() Then
            If ModPOS.Acondicionado Is Nothing Then
                ModPOS.Acondicionado = New FrmAcondicionado
                ModPOS.Acondicionado.Padre = "Nuevo"

                ' ModPOS.Transferencia.TxtSucursal.Text = CmbAlmacen.SelectedItem.row.itemarray(1)
                ModPOS.Acondicionado.ALMClave = Me.CmbAlmacen.SelectedValue

            End If
            ModPOS.Acondicionado.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Acondicionado.Show()
            ModPOS.Acondicionado.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click

        If sAcondicionadoSelected <> "" Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_acondicioando", "@ACOClave", sAcondicionadoSelected))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_acondicionado", "@ACOClave", sAcondicionadoSelected))
            OpenReport.PrintPreview("Acondicioando", "CRTAcondicionado.rpt", pvtaDataSet, "")
        End If

    End Sub

    Public Sub modificarTransferencia()


        If sAcondicionadoSelected <> "" Then
            If ModPOS.Transferencia Is Nothing Then
                ModPOS.Transferencia = New FrmMOVALM
                With ModPOS.Transferencia
                    .Text = "Modificar Traspaso"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", Me.sAcondicionadoSelected)
                    .MVAClave = dt.Rows(0)("MVAClave")
                    .Motivo = dt.Rows(0)("Motivo")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .ALMDestino = dt.Rows(0)("ALMDestino")
                    .Folio = dt.Rows(0)("Folio")
                    .FecRegistro = dt.Rows(0)("FechaRegistro")
                    .Notas = dt.Rows(0)("Notas")
                    .Estado = dt.Rows(0)("Estado")
                    '.TxtSucursal.Text = dt.Rows(0)("NAlmacen")
                    .DescripcionEstado = dt.Rows(0)("NEstado")
                    dt.Dispose()

                End With
            End If

            ModPOS.Transferencia.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Transferencia.Show()
            ModPOS.Transferencia.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarTransferencia()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click

        If sAcondicionadoSelected <> "" Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar los traspasos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    '   Dim dSaldo As Double = IIf(dtTraspaso.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtTraspaso.Compute("Sum(Total)", "Marca = True"))

                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    ' a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then


                            Dim dt As DataTable
                            Dim iEstado As Integer
                            dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", sAcondicionadoSelected)
                            iEstado = dt.Rows(0)("Estado")
                            dt.Dispose()
                            If iEstado = 1 Then
                                ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", sAcondicionadoSelected, "@Usuario", ModPOS.UsuarioActual)
                                refrescaGrid()
                            Else
                                '   MessageBox.Show("No es posible cancelar el Traspaso: " & CStr(foundRows(i)("Folio")), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado un Traspaso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

   





    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

    Private Sub btnConfirmación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmación.Click

        Dim foundRows() As DataRow
        foundRows = dtAcondicionado.Select("Marca ='True' and iEstado = 5")

        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que encuentran en proceso de confirmación, debe liberarlos previante antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        foundRows = dtAcondicionado.Select("Marca ='True' and iEstado = 4")

        If foundRows.GetLength(0) > 0 Then

            Dim TRAClave As String = ModPOS.obtenerLlave
            Dim i As Integer
            Dim dt As DataTable

            For i = 0 To foundRows.GetUpperBound(0)
                dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", foundRows(i)("MVAClave"))


                dt.Dispose()
            Next


        Else
            MessageBox.Show("¡Debe Marcar por lo menos un documento en Transito para Confirmar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged, CmbAlmacen.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad = True AndAlso CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = ""
        ElseIf bLoad = True Then
            SUCClave = CmbSucursal.SelectedValue

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        End If
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bLoad = True AndAlso CmbAlmacen.SelectedValue Is Nothing Then
            sALMClave = ""
        ElseIf bLoad = True Then
            sALMClave = CmbAlmacen.SelectedValue
        End If
    End Sub
End Class
