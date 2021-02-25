Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRecibo
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
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPorSurtir As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridRecibo As Janus.Windows.GridEX.GridEX
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnRecibir As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnLiberar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibo))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.CmbSucursal = New Selling.StoreCombo
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.btnLiberar = New Janus.Windows.EditControls.UIButton
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnRecibir = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton
        Me.GridRecibo = New Janus.Windows.GridEX.GridEX
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpPorSurtir.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(606, 521)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 18
        Me.BtnReimpresion.Text = "Imprimir"
        Me.BtnReimpresion.ToolTipText = "Reimpresión de documento seleccionado"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
               '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GrpPorSurtir
        '
        Me.GrpPorSurtir.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox2)
        Me.GrpPorSurtir.Controls.Add(Me.CmbSucursal)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
        Me.GrpPorSurtir.Controls.Add(Me.btnLiberar)
        Me.GrpPorSurtir.Controls.Add(Me.ChkTodos)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox1)
        Me.GrpPorSurtir.Controls.Add(Me.BtnRecibir)
        Me.GrpPorSurtir.Controls.Add(Me.Label3)
        Me.GrpPorSurtir.Controls.Add(Me.BtnReimpresion)
        Me.GrpPorSurtir.Controls.Add(Me.CmbAlmacen)
        Me.GrpPorSurtir.Controls.Add(Me.Label1)
        Me.GrpPorSurtir.Controls.Add(Me.dtPicker)
        Me.GrpPorSurtir.Controls.Add(Me.BtnRefresh)
        Me.GrpPorSurtir.Controls.Add(Me.GridRecibo)
        Me.GrpPorSurtir.Controls.Add(Me.Label2)
        Me.GrpPorSurtir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPorSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPorSurtir.ForeColor = System.Drawing.Color.Black
        Me.GrpPorSurtir.Location = New System.Drawing.Point(0, 0)
        Me.GrpPorSurtir.Name = "GrpPorSurtir"
        Me.GrpPorSurtir.Size = New System.Drawing.Size(800, 564)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Productos por recibir"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(493, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 125
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(79, 17)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 123
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(414, 521)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnLiberar
        '
        Me.btnLiberar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLiberar.Icon = CType(resources.GetObject("btnLiberar.Icon"), System.Drawing.Icon)
        Me.btnLiberar.Location = New System.Drawing.Point(510, 521)
        Me.btnLiberar.Name = "btnLiberar"
        Me.btnLiberar.Size = New System.Drawing.Size(90, 37)
        Me.btnLiberar.TabIndex = 87
        Me.btnLiberar.Text = "&Liberar"
        Me.btnLiberar.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recepción"
        Me.btnLiberar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(10, 45)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(129, 19)
        Me.ChkTodos.TabIndex = 122
        Me.ChkTodos.Text = "Todos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(46, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnRecibir
        '
        Me.BtnRecibir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRecibir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecibir.Icon = CType(resources.GetObject("BtnRecibir.Icon"), System.Drawing.Icon)
        Me.BtnRecibir.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnRecibir.Location = New System.Drawing.Point(702, 521)
        Me.BtnRecibir.Name = "BtnRecibir"
        Me.BtnRecibir.Size = New System.Drawing.Size(90, 37)
        Me.BtnRecibir.TabIndex = 25
        Me.BtnRecibir.Text = "Recibir"
        Me.BtnRecibir.ToolTipText = "Recibir documentos seleccionados"
        Me.BtnRecibir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(449, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(526, 12)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(464, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(526, 40)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(211, 22)
        Me.dtPicker.TabIndex = 24
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(755, 38)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridRecibo
        '
        Me.GridRecibo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRecibo.ColumnAutoResize = True
        Me.GridRecibo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRecibo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRecibo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridRecibo.GroupByBoxVisible = False
        Me.GridRecibo.Location = New System.Drawing.Point(7, 66)
        Me.GridRecibo.Name = "GridRecibo"
        Me.GridRecibo.RecordNavigator = True
        Me.GridRecibo.Size = New System.Drawing.Size(786, 449)
        Me.GridRecibo.TabIndex = 4
        Me.GridRecibo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Sucursal"
        '
        'FrmRecibo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 564)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmRecibo"
        Me.Text = "Recibo de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPorSurtir.ResumeLayout(False)
        Me.GrpPorSurtir.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ALMClave As String
    ' Private VENClave As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtRecibo As DataTable
    Private bload As Boolean = False
    Private Periodo, Mes As Integer
    Private SUCClave As String
    Private Movilidad As Boolean

    Private Sub FrmRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        Me.StartPosition = FormStartPosition.CenterScreen

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        CmbSucursal.SelectedValue = SucursalPredeterminada

        If Not CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = CmbSucursal.SelectedValue

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_alm_suc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With

        Else
            SUCClave = ""
        End If

        If Not CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = CmbAlmacen.SelectedValue
        Else
            ALMClave = ""
        End If


        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        bload = True


        Me.AgregarFolio()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If SUCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If ALMClave = "" Then
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

    Public Sub AgregarFolio()
        If validaForm() Then

            If Not dtRecibo Is Nothing Then
                dtRecibo.Dispose()
            End If
            dtRecibo = ModPOS.Recupera_Tabla("sp_obtener_recibo", "@ALMClave", ALMClave, "@Periodo", Periodo, "@Mes", Mes)
            GridRecibo.DataSource = dtRecibo
            GridRecibo.RetrieveStructure()
            GridRecibo.AutoSizeColumns()
            GridRecibo.RootTable.Columns("DOCClave").Visible = False
            GridRecibo.RootTable.Columns("iEstado").Visible = False
            GridRecibo.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            If Me.ChkTodos.Checked = True Then
                ChkTodos.Checked = False
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmRecibo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Recibo.Dispose()
        ModPOS.Recibo = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub



    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtRecibo Is Nothing Then
                dtRecibo.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub GridRecibo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridRecibo.CurrentCellChanged
        If Not GridRecibo.CurrentColumn Is Nothing Then
            If GridRecibo.CurrentColumn.Caption = "Marca" Then
                GridRecibo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridRecibo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    'Private Sub GridPicking_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridPicking.FormattingRow
    '    GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    'End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        AgregarFolio()
    End Sub

    Private Sub GridRecibo_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridRecibo.SelectionChanged
        If Not GridRecibo.GetValue(0) Is Nothing Then
            Me.BtnReimpresion.Enabled = True
            Me.BtnRecibir.Enabled = True

        Else
            Me.BtnReimpresion.Enabled = False
            Me.BtnRecibir.Enabled = False
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow

        foundRows = dtRecibo.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    '     ModPOS.ImprimirSurtido(foundRows(i)("DOCClave"), PrintDialog1.PrinterSettings.PrinterName)
                Next
            End If
        End If
    End Sub

    Private Sub modificaRecibo()

        Dim foundRows() As DataRow
        foundRows = dtRecibo.Select("Marca ='True' and iEstado = 6")

        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que encuentran en proceso de recepción, debe liberarlos previante antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim i As Integer
        Dim dt As DataTable


        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Movilidad = IIf(dt.Rows(0)("Movilidad").GetType.Name = "DBNull", False, dt.Rows(0)("Movilidad"))
        dt.Dispose()

        foundRows = dtRecibo.Select("Marca ='True'")

        If Movilidad = False Then
            Dim sDoctos As String = ""
            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_conf", "@DOCClave", foundRows(i)("DOCClave"), "@Tipo", foundRows(i)("Tipo"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("CNFClave").GetType.Name <> "DBNull" Then
                            MessageBox.Show("El documeto " & foundRows(i)("Folio") & " se encuentra en proceso de recepción será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If sDoctos = "" Then
                                sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("Tipo"))
                            Else
                                sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("Tipo"))
                            End If
                        End If
                    End If
                    dt.Dispose()
                Next
            End If

            If ModPOS.Confirmacion Is Nothing Then
                ModPOS.Confirmacion = New FrmConfirmacion
                With ModPOS.Confirmacion
                    .StartPosition = FormStartPosition.CenterScreen
                    .Documentos = sDoctos
                    .SUCClave = SUCClave
                    .ALMDestino = Me.ALMClave
                End With
            End If

            ModPOS.Confirmacion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Confirmacion.Show()
            ModPOS.Confirmacion.BringToFront()

        Else

            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_recibo", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("CNFClave").GetType.Name <> "DBNull" Then
                            MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra en proceso de recepción será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            ModPOS.Ejecuta("sp_prioridad_picking", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                    dt.Dispose()
                Next

                Me.AgregarFolio()

            Else
                MessageBox.Show("¡Debe Marcar por lo menos un documento para Recibir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub BtnRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecibir.Click
        modificaRecibo()
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtRecibo.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To dtRecibo.Rows.Count - 1
                    dtRecibo.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtRecibo.Rows.Count - 1
                    dtRecibo.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        Dim foundRows() As DataRow

        foundRows = dtRecibo.Select("Marca ='True' and (iEstado = 2 or iEstado=7)")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser liberados debido a que no se encuentran en Proceso")
            Exit Sub
        End If

        foundRows = dtRecibo.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then

            Dim dSaldo As Double = IIf(dtRecibo.Compute("Sum(Total)", "Marca = True") Is System.DBNull.Value, 0, dtRecibo.Compute("Sum(Total)", "Marca = True"))

            Select Case MessageBox.Show("¿Esta seguro de Liberar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim Autoriza As String = a.Autoriza
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_agrega_confirmacion", "@CNFClave", Nothing, "@DOCClave", foundRows(i)("DOCClave"), "@Tipo", foundRows(i)("Tipo"), "@Usuario", ModPOS.UsuarioActual)
                                ModPOS.Ejecuta("sp_actualiza_confirmacion", "@DOCClave", foundRows(i)("DOCClave"), "@Tipo", foundRows(i)("Tipo"), "@Estado", 4)
                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento que desea Liberar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bload = True AndAlso CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = ""
        ElseIf bload = True Then
            ALMClave = CmbAlmacen.SelectedValue
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bload = True AndAlso CmbSucursal.SelectedValue Is Nothing Then
            SUCClave = ""
        ElseIf bload = True Then
            SUCClave = CmbSucursal.SelectedValue

            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_alm_suc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        End If

    End Sub

  
End Class
