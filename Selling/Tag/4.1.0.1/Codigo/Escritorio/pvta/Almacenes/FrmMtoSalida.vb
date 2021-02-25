Public Class FrmMtoSalida
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
    Friend WithEvents GrpCargo As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCargo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCargo As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoSalida))
        Me.GrpCargo = New System.Windows.Forms.GroupBox()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnCargo = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCargo = New Janus.Windows.GridEX.GridEX()
        Me.GrpCargo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCargo
        '
        Me.GrpCargo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCargo.Controls.Add(Me.BtnRefresh)
        Me.GrpCargo.Controls.Add(Me.BtnEliminar)
        Me.GrpCargo.Controls.Add(Me.BtnSalir)
        Me.GrpCargo.Controls.Add(Me.BtnModificar)
        Me.GrpCargo.Controls.Add(Me.BtnReimpresion)
        Me.GrpCargo.Controls.Add(Me.ChkTodos)
        Me.GrpCargo.Controls.Add(Me.Label3)
        Me.GrpCargo.Controls.Add(Me.dtPicker)
        Me.GrpCargo.Controls.Add(Me.BtnCargo)
        Me.GrpCargo.Controls.Add(Me.PictureBox1)
        Me.GrpCargo.Controls.Add(Me.CmbSucursal)
        Me.GrpCargo.Controls.Add(Me.Label1)
        Me.GrpCargo.Controls.Add(Me.GridCargo)
        Me.GrpCargo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCargo.ForeColor = System.Drawing.Color.Black
        Me.GrpCargo.Location = New System.Drawing.Point(0, 0)
        Me.GrpCargo.Name = "GrpCargo"
        Me.GrpCargo.Size = New System.Drawing.Size(789, 473)
        Me.GrpCargo.TabIndex = 1
        Me.GrpCargo.TabStop = False
        Me.GrpCargo.Text = "Salida por Cargo a Centro "
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(450, 17)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 125
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(405, 430)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 10
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar documento seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(309, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.BtnModificar.ToolTipText = "Modificar documento seleccionado"
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
        Me.BtnReimpresion.ToolTipText = "Reimpresión de documento seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(7, 46)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(122, 20)
        Me.ChkTodos.TabIndex = 123
        Me.ChkTodos.Text = "Todos"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(535, 25)
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
        Me.dtPicker.Location = New System.Drawing.Point(597, 20)
        Me.dtPicker.MaxDate = New Date(9998, 12, 28, 0, 0, 0, 0)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 54
        '
        'BtnCargo
        '
        Me.BtnCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCargo.Icon = CType(resources.GetObject("BtnCargo.Icon"), System.Drawing.Icon)
        Me.BtnCargo.Location = New System.Drawing.Point(693, 430)
        Me.BtnCargo.Name = "BtnCargo"
        Me.BtnCargo.Size = New System.Drawing.Size(90, 37)
        Me.BtnCargo.TabIndex = 6
        Me.BtnCargo.Text = "&Cargo"
        Me.BtnCargo.ToolTipText = "Nuevo Cargo a Centro de Costo"
        Me.BtnCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(82, 18)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(362, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridCargo
        '
        Me.GridCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridCargo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCargo.ColumnAutoResize = True
        Me.GridCargo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCargo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCargo.GroupByBoxVisible = False
        Me.GridCargo.Location = New System.Drawing.Point(7, 70)
        Me.GridCargo.Name = "GridCargo"
        Me.GridCargo.RecordNavigator = True
        Me.GridCargo.Size = New System.Drawing.Size(776, 354)
        Me.GridCargo.TabIndex = 2
        Me.GridCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoSalida
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpCargo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoSalida"
        Me.Text = "Cargos a Centro de Costo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpCargo.ResumeLayout(False)
        Me.GrpCargo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private sSUCClave As String

    Private sCargoSelected As String
    Private sNombre As String

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private dtCargo As DataTable

    Private bLoad As Boolean = False

    Private Sub FrmMtoSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month

        refrescaGrid()
    End Sub

    Public Sub refrescaGrid()
        bLoad = False
        Cursor.Current = Cursors.WaitCursor

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtCargo Is Nothing Then
            dtCargo.Dispose()
        End If

        dtCargo = ModPOS.Recupera_Tabla("sp_muestra_salida", "@SUCClave", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridCargo.DataSource = dtCargo
        GridCargo.RetrieveStructure()

        Me.GridCargo.RootTable.Columns("MVAClave").Visible = False
        Me.GridCargo.RootTable.Columns("iEstado").Visible = False
        Me.GridCargo.RootTable.Columns("Total").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCargo.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridCargo.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub

    Private Sub GridCargo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCargo.CurrentCellChanged
        If Not GridCargo.CurrentColumn Is Nothing Then
            If GridCargo.CurrentColumn.Caption = "Marca" Then
                GridCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridCargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCargo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridCargo_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCargo.SelectionChanged
        If Not GridCargo.GetValue(0) Is Nothing Then
            sCargoSelected = GridCargo.GetValue("MVAClave")
            sNombre = GridCargo.GetValue("Folio")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True

        Else
            sCargoSelected = ""
            sNombre = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridCargo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCargo.DoubleClick
        If Not GridCargo.GetValue(0) Is Nothing Then
            modificarCargo()
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

    Private Sub FrmMtoSalida_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoSalida.Dispose()
        ModPOS.MtoSalida = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCargo.Click
        If validaForm() Then
            If ModPOS.Salida Is Nothing Then
                ModPOS.Salida = New FrmSalida
                ModPOS.Salida.Padre = "Nuevo"
                ModPOS.Salida.SUCClave = Me.CmbSucursal.SelectedValue

            End If
            ModPOS.Salida.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Salida.Show()
            ModPOS.Salida.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow
        foundRows = dtCargo.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                imprimirReporteTransferencia(foundRows(i)("MVAClave"))
            Next
        Else
            MessageBox.Show("¡No se ha seleccionado un documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub modificarCargo()
        If sCargoSelected <> "" Then
            If ModPOS.Salida Is Nothing Then
                ModPOS.Salida = New FrmSalida
                With ModPOS.Salida
                    .Text = "Modificar Cargo a Centro de Costo"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", Me.sCargoSelected)
                    .MVAClave = dt.Rows(0)("MVAClave")
                    .Motivo = IIf(dt.Rows(0)("Motivo").GetType.Name = "DBNull", "", dt.Rows(0)("Motivo"))
                    .Solicita = IIf(dt.Rows(0)("Solicita").GetType.Name = "DBNull", "", dt.Rows(0)("Solicita"))
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .ALMDestino = dt.Rows(0)("ALMDestino")
                    .Folio = dt.Rows(0)("Folio")
                    .FecRegistro = dt.Rows(0)("FechaRegistro")
                    .Notas = dt.Rows(0)("Notas")
                    .Estado = dt.Rows(0)("Estado")
                    .Total = dt.Rows(0)("Total")
                    .UBCClave = IIf(dt.Rows(0)("UBCClave").GetType.Name <> "DBNull", dt.Rows(0)("UBCClave"), "")
                    .SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name <> "DBNull", dt.Rows(0)("SUCClave"), "")
                    .Stage = IIf(dt.Rows(0)("Stage").GetType.Name <> "DBNull", dt.Rows(0)("Stage"), "")
                    .DescripcionEstado = dt.Rows(0)("NEstado")
                    dt.Dispose()

                End With
            End If

            ModPOS.Salida.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Salida.Show()
            ModPOS.Salida.BringToFront()

        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarCargo()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click

        Dim foundRows() As DataRow
        foundRows = dtCargo.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim dSaldo As Double = IIf(dtCargo.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtCargo.Compute("Sum(Total)", "Marca = True"))

                    Dim a As New MeAutorizacion
                    a.Sucursal = Me.CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)
                                Dim dt As DataTable
                                Dim iEstado As Integer
                                dt = ModPOS.Recupera_Tabla("sp_recupera_transferencia", "@MVAClave", foundRows(i)("MVAClave"))
                                iEstado = dt.Rows(0)("Estado")
                                dt.Dispose()
                                If iEstado = 1 Then
                                    ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("MVAClave"), "@Usuario", ModPOS.UsuarioActual)
                                    refrescaGrid()
                                Else
                                    MessageBox.Show("No es posible cancelar el documento: " & CStr(foundRows(i)("Folio")), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Next
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado algun Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub Combos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtCargo.Rows.Count > 0 Then
            Dim i As Integer

            If ChkTodos.Checked Then
                For i = 0 To GridCargo.GetDataRows.Length - 1
                    GridCargo.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCargo.GetDataRows.Length - 1
                    GridCargo.GetDataRows(i).DataRow("Marca") = False
                Next
            End If


        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub
End Class
