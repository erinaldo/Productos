Public Class FrmMtoTraslados
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
    Friend WithEvents GrpTransferencia As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTraslado As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridTraslados As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbFormato As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoTraslados))
        Me.GrpTransferencia = New System.Windows.Forms.GroupBox
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbFormato = New Selling.StoreCombo
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnTraslado = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridTraslados = New Janus.Windows.GridEX.GridEX
        Me.GrpTransferencia.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTraslados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTransferencia
        '
        Me.GrpTransferencia.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTransferencia.Controls.Add(Me.BtnEliminar)
        Me.GrpTransferencia.Controls.Add(Me.BtnSalir)
        Me.GrpTransferencia.Controls.Add(Me.PictureBox2)
        Me.GrpTransferencia.Controls.Add(Me.cmbFormato)
        Me.GrpTransferencia.Controls.Add(Me.BtnModificar)
        Me.GrpTransferencia.Controls.Add(Me.BtnReimpresion)
        Me.GrpTransferencia.Controls.Add(Me.Label2)
        Me.GrpTransferencia.Controls.Add(Me.ChkTodos)
        Me.GrpTransferencia.Controls.Add(Me.Label3)
        Me.GrpTransferencia.Controls.Add(Me.dtPicker)
        Me.GrpTransferencia.Controls.Add(Me.BtnTraslado)
        Me.GrpTransferencia.Controls.Add(Me.PictureBox1)
        Me.GrpTransferencia.Controls.Add(Me.CmbSucursal)
        Me.GrpTransferencia.Controls.Add(Me.Label1)
        Me.GrpTransferencia.Controls.Add(Me.GridTraslados)
        Me.GrpTransferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTransferencia.ForeColor = System.Drawing.Color.Black
        Me.GrpTransferencia.Location = New System.Drawing.Point(0, 0)
        Me.GrpTransferencia.Name = "GrpTransferencia"
        Me.GrpTransferencia.Size = New System.Drawing.Size(789, 473)
        Me.GrpTransferencia.TabIndex = 1
        Me.GrpTransferencia.TabStop = False
        Me.GrpTransferencia.Text = "Traslados"
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
        Me.BtnEliminar.Text = "&Salir"
        Me.BtnEliminar.ToolTipText = "Cancelar traslado seleccionado"
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
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(581, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 126
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbFormato
        '
        Me.cmbFormato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFormato.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFormato.Location = New System.Drawing.Point(597, 41)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(184, 24)
        Me.cmbFormato.TabIndex = 125
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
        Me.BtnModificar.ToolTipText = "Modificar traslado seleccionado"
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
        Me.BtnReimpresion.ToolTipText = "Reimpresi�n de traslado seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(539, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Formato "
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(7, 46)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(69, 20)
        Me.ChkTodos.TabIndex = 123
        Me.ChkTodos.Text = "Todos"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(539, 21)
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
        Me.dtPicker.Location = New System.Drawing.Point(597, 16)
        Me.dtPicker.MaxDate = New Date(9998, 12, 28, 0, 0, 0, 0)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 22)
        Me.dtPicker.TabIndex = 54
        '
        'BtnTraslado
        '
        Me.BtnTraslado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTraslado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTraslado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTraslado.Icon = CType(resources.GetObject("BtnTraslado.Icon"), System.Drawing.Icon)
        Me.BtnTraslado.Location = New System.Drawing.Point(693, 430)
        Me.BtnTraslado.Name = "BtnTraslado"
        Me.BtnTraslado.Size = New System.Drawing.Size(90, 37)
        Me.BtnTraslado.TabIndex = 6
        Me.BtnTraslado.Text = "&Traslado"
        Me.BtnTraslado.ToolTipText = "Nuevo Traslado"
        Me.BtnTraslado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(98, 22)
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
        Me.CmbSucursal.Location = New System.Drawing.Point(118, 16)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(362, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal Destino"
        '
        'GridTraslados
        '
        Me.GridTraslados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridTraslados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTraslados.ColumnAutoResize = True
        Me.GridTraslados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTraslados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTraslados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridTraslados.GroupByBoxVisible = False
        Me.GridTraslados.Location = New System.Drawing.Point(7, 70)
        Me.GridTraslados.Name = "GridTraslados"
        Me.GridTraslados.RecordNavigator = True
        Me.GridTraslados.Size = New System.Drawing.Size(776, 354)
        Me.GridTraslados.TabIndex = 2
        Me.GridTraslados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoTraslados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(789, 473)
        Me.Controls.Add(Me.GrpTransferencia)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoTraslados"
        Me.Text = " Traslados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTransferencia.ResumeLayout(False)
        Me.GrpTransferencia.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTraslados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private sSUCClave As String

    Private sTrasladoSelected As String
    Private sNombre As String

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private dtTraslado As DataTable

    Private bLoad As Boolean = False

    Public Sub refrescaGrid()
        bLoad = False
        Cursor.Current = Cursors.WaitCursor

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtTraslado Is Nothing Then
            dtTraslado.Dispose()
        End If

        dtTraslado = ModPOS.Recupera_Tabla("sp_muestra_traslados", "@SUCClave", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridTraslados.DataSource = dtTraslado
        GridTraslados.RetrieveStructure()

        Me.GridTraslados.RootTable.Columns("TRSClave").Visible = False
        Me.GridTraslados.RootTable.Columns("iEstado").Visible = False
        Me.GridTraslados.RootTable.Columns("Total").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridTraslados.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridTraslados.RootTable.FormatConditions.Add(fc)
        Cursor.Current = Cursors.Default
        bLoad = True
    End Sub

    Public Sub modificarTraslado()


        If sTrasladoSelected <> "" Then
            If ModPOS.Traslado Is Nothing Then
                ModPOS.Traslado = New FrmTraslado
                With ModPOS.Traslado
                    .Text = "Modificar Traslado"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Modificar"
                    .Formato = IIf(cmbFormato.SelectedValue Is Nothing, 2, cmbFormato.SelectedValue)

                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_traslado", "@TRSClave", Me.sTrasladoSelected)
                    .TRSClave = dt.Rows(0)("TRSClave")
                    .Folio = dt.Rows(0)("Folio")
                    .FecRegistro = dt.Rows(0)("FechaRegistro")
                    .Motivo = IIf(dt.Rows(0)("Motivo").GetType.Name = "DBNull", "", dt.Rows(0)("Motivo"))
                    .Solicita = IIf(dt.Rows(0)("Solicita").GetType.Name = "DBNull", "", dt.Rows(0)("Solicita"))

                    .SUCClave = dt.Rows(0)("SUCClave")
                    .ALMClave = dt.Rows(0)("ALMClave")
                    .SUCDestino = dt.Rows(0)("SUCDestino")
                    .ALMDestino = dt.Rows(0)("ALMDestino")
                    .Notas = dt.Rows(0)("Notas")
                    .Estado = dt.Rows(0)("Estado")
                    .tipoEntrega = IIf(dt.Rows(0)("tipoEntrega").GetType.Name = "DBNull", 0, dt.Rows(0)("tipoEntrega"))
                    .formaEnvio = IIf(dt.Rows(0)("formaEnvio").GetType.Name = "DBNull", 0, dt.Rows(0)("formaEnvio"))

                    dt.Dispose()

                End With
            End If

            ModPOS.Traslado.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Traslado.Show()
            ModPOS.Traslado.BringToFront()

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

        If Me.cmbFormato.SelectedValue Is Nothing Then
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

    Private Sub FrmMtoTraslados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        With Me.cmbFormato
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "MOVALM"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Imprimir"
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

    Private Sub GridTransferencia_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridTraslados.CurrentCellChanged
        If Not GridTraslados.CurrentColumn Is Nothing Then
            If GridTraslados.CurrentColumn.Caption = "Marca" Then
                GridTraslados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridTraslados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridTransferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridTraslados.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnModificar.PerformClick()
        End If
    End Sub

    Private Sub GridTraslados_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTraslados.SelectionChanged
        If Not GridTraslados.GetValue(0) Is Nothing Then
            sTrasladoSelected = GridTraslados.GetValue("TRSClave")
            sNombre = GridTraslados.GetValue("Folio")
            BtnModificar.Enabled = True
            BtnEliminar.Enabled = True
            BtnReimpresion.Enabled = True

        Else
            sTrasladoSelected = ""
            sNombre = ""
            BtnModificar.Enabled = False
            BtnEliminar.Enabled = False
            BtnReimpresion.Enabled = False
        End If
    End Sub

    Private Sub GridTraslados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridTraslados.DoubleClick
        If Not GridTraslados.GetValue(0) Is Nothing Then
            modificarTraslado()
        End If
    End Sub

    Private Sub FrmMtoTraslados_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoTraslados.Dispose()
        ModPOS.MtoTraslados = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
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
        If dtTraslado.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To dtTraslado.Rows.Count - 1
                    dtTraslado.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtTraslado.Rows.Count - 1
                    dtTraslado.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Me.modificarTraslado()
    End Sub

    Private Sub BtnTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTraslado.Click
        If validaForm() Then
            If ModPOS.Traslado Is Nothing Then
                ModPOS.Traslado = New FrmTraslado
                ModPOS.Traslado.Padre = "Nuevo"
                ModPOS.Traslado.Formato = cmbFormato.SelectedValue
                ModPOS.Traslado.SUCDestino = Me.CmbSucursal.SelectedValue
            End If
            ModPOS.Traslado.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Traslado.Show()
            ModPOS.Traslado.BringToFront()
        Else
            Beep()
            MessageBox.Show("�Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click

        Dim foundRows() As DataRow
        foundRows = dtTraslado.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Select Case MessageBox.Show("�Esta seguro que desea cancelar los traslados seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim dSaldo As Double = IIf(dtTraslado.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtTraslado.Compute("Sum(Total)", "Marca = True"))

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
                                dt = ModPOS.Recupera_Tabla("sp_recupera_traslado", "@TRSClave", foundRows(i)("TRSClave"))
                                iEstado = dt.Rows(0)("Estado")
                                dt.Dispose()
                                If iEstado = 1 Then
                                    ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("TRSClave"), "@USRClave", ModPOS.UsuarioActual)
                                    refrescaGrid()
                                Else
                                    MessageBox.Show("No es posible cancelar el Traslado: " & CStr(foundRows(i)("Folio")), "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Next
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("�No se ha seleccionado un Traslado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click

        If cmbFormato.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un formato de impresi�n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim foundRows() As DataRow
        foundRows = dtTraslado.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            If cmbFormato.SelectedValue = 1 Then

                Dim dtTicket As DataTable
                dtTicket = ModPOS.SiExisteRecupera("sp_recupera_tikclave", "@SUCClave", CmbSucursal.SelectedValue)

                Dim sTIKClave As String = ""
                If Not dtTicket Is Nothing Then
                    sTIKClave = dtTicket.Rows(0)("TIKClave")
                    dtTicket.Dispose()
                End If

                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.imprimirTicketTraslado(sTIKClave, True, foundRows(i)("TRSClave"))
                Next
            Else
                For i = 0 To foundRows.GetUpperBound(0)
                    imprimirReporteTraslado(foundRows(i)("TRSClave"))
                Next
            End If
        Else
            MessageBox.Show("�No se ha seleccionado un Traslado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

End Class
