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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecibo))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnRecibir = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.GridRecibo = New Janus.Windows.GridEX.GridEX()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.BtnReimpresion.Location = New System.Drawing.Point(654, 521)
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
        Me.GrpPorSurtir.Controls.Add(Me.Label4)
        Me.GrpPorSurtir.Controls.Add(Me.dtFinal)
        Me.GrpPorSurtir.Controls.Add(Me.BtnEliminar)
        Me.GrpPorSurtir.Controls.Add(Me.BtnModificar)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox2)
        Me.GrpPorSurtir.Controls.Add(Me.CmbSucursal)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
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
        Me.GrpPorSurtir.Size = New System.Drawing.Size(944, 564)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Productos por recibir"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(819, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "al"
        '
        'dtFinal
        '
        Me.dtFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtFinal.CustomFormat = "MMMM yyyy"
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(844, 24)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.ShowUpDown = True
        Me.dtFinal.Size = New System.Drawing.Size(92, 22)
        Me.dtFinal.TabIndex = 128
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(558, 521)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEliminar.TabIndex = 127
        Me.BtnEliminar.Text = "&Cancelar"
        Me.BtnEliminar.ToolTipText = "Cancelar recibo seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(750, 521)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 126
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modificar recibo seleccionado"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(344, 26)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 125
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(79, 23)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 123
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(462, 521)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 24
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(10, 26)
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
        Me.BtnRecibir.Location = New System.Drawing.Point(846, 521)
        Me.BtnRecibir.Name = "BtnRecibir"
        Me.BtnRecibir.Size = New System.Drawing.Size(90, 37)
        Me.BtnRecibir.TabIndex = 25
        Me.BtnRecibir.Text = "Recibir"
        Me.BtnRecibir.ToolTipText = "Recibir documentos seleccionados"
        Me.BtnRecibir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(341, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Location = New System.Drawing.Point(406, 23)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(663, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker.Location = New System.Drawing.Point(725, 24)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(92, 22)
        Me.dtPicker.TabIndex = 24
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(619, 23)
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
        Me.GridRecibo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridRecibo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRecibo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridRecibo.GroupByBoxVisible = False
        Me.GridRecibo.Location = New System.Drawing.Point(7, 56)
        Me.GridRecibo.Name = "GridRecibo"
        Me.GridRecibo.RecordNavigator = True
        Me.GridRecibo.Size = New System.Drawing.Size(930, 459)
        Me.GridRecibo.TabIndex = 4
        Me.GridRecibo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Sucursal"
        '
        'FrmRecibo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(944, 564)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
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
    Private Inicio, Fin As DateTime
    Private SUCClave As String
    Private Movilidad As Boolean

    Private Sub FrmRecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        dtPicker.Value = Today.Date
        dtFinal.Value = dtPicker.Value

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
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
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

        Inicio = dtPicker.Value
        Fin = dtFinal.Value


        GridRecibo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False

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
            dtRecibo = ModPOS.Recupera_Tabla("sp_obtener_recibo", "@ALMClave", ALMClave, "@Inicio", Inicio, "@Fin", Fin.AddHours(23.9999))
            GridRecibo.DataSource = dtRecibo
            GridRecibo.RetrieveStructure()
            GridRecibo.AutoSizeColumns()
            GridRecibo.RootTable.Columns("IdRecibo").Visible = False

            GridRecibo.HorizontalScroll.Enabled = True
            GridRecibo.RootTable.Columns("Recibido").FormatString = "0.00 %"

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
        If bload = True AndAlso (Inicio <> dtPicker.Value) Then
            If dtPicker.Value > Fin Then
                dtPicker.Value = Fin
            End If

            Inicio = dtPicker.Value

            If Not dtRecibo Is Nothing Then
                dtRecibo.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        AgregarFolio()
    End Sub

    Private Sub GridRecibo_DoubleClick(sender As Object, e As EventArgs) Handles GridRecibo.DoubleClick
        If Not GridRecibo.GetValue(0) Is Nothing Then
            modificaRecibo()
        End If
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
        If Not GridRecibo.GetValue(0) Is Nothing Then

            Dim idRecibo As String = GridRecibo.GetValue(0)
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_encabezado_ra", "@IdRecibo", idRecibo))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ra", "@IdRecibo", idRecibo))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_pie_ra", "@IdRecibo", idRecibo))
            OpenReport.PrintPreview("Reporte de Recibos de Almacén", "CRReciboDetalle.rpt", pvtaDataSet, "")

        End If
    End Sub

    Private Sub modificaRecibo()

        If ModPOS.Confirmacion Is Nothing Then
            ModPOS.Confirmacion = New FrmConfirmacion
            With ModPOS.Confirmacion
                .StartPosition = FormStartPosition.CenterScreen
                .SUCClave = SUCClave
                .ALMClave = Me.ALMClave
                .Padre = "Modificar"

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_reciboalmacen", "@IdRecibo", GridRecibo.GetValue(0))

                .IdRecibo = dt.Rows(0)("IdRecibo")
                .ALMClave = dt.Rows(0)("ALMClave")
                .Folio = IIf(dt.Rows(0)("Folio").GetType.Name = "DBNull", "", dt.Rows(0)("Folio"))
                .FechaRecibo = dt.Rows(0)("FechaRecibo")
                .UBCClave = dt.Rows(0)("Anden")
                .Chofer = dt.Rows(0)("Chofer")
                .Transporte = dt.Rows(0)("Transporte")
                .Estado = dt.Rows(0)("Estado")
                .Notas = IIf(dt.Rows(0)("Notas").GetType.Name = "DBNull", "", dt.Rows(0)("Notas"))
                dt.Dispose()
            End With
        End If

        ModPOS.Confirmacion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Confirmacion.Show()
        ModPOS.Confirmacion.BringToFront()

    End Sub

    Private Sub BtnRecibir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecibir.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            If ModPOS.Confirmacion Is Nothing Then
                ModPOS.Confirmacion = New FrmConfirmacion
                With ModPOS.Confirmacion
                    .StartPosition = FormStartPosition.CenterScreen
                    .SUCClave = SUCClave
                    .ALMClave = CmbAlmacen.SelectedValue
                    .Padre = "Agregar"
                End With
            End If
            ModPOS.Confirmacion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Confirmacion.Show()
            ModPOS.Confirmacion.BringToFront()
        Else
            Beep()
            MessageBox.Show("¡El Almacén seleccionado no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        End If

    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If Not GridRecibo.GetValue(0) Is Nothing Then
            modificaRecibo()
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If Not GridRecibo.GetValue(0) Is Nothing Then
            Select Case MessageBox.Show("¿Esta seguro que desea cancelar el recibo " & CStr(GridRecibo.GetValue("Folio")) & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim dt As DataTable
                    Dim dSaldo As Double
                    dt = ModPOS.Recupera_Tabla("sp_recupera_total_recibo", "@IdRecibo", GridRecibo.GetValue(0))

                    dSaldo = CDbl(dt.Rows(0)("Total"))
                    dt.Dispose()

                    Dim dRecibidos As Integer

                    dt = ModPOS.Recupera_Tabla("st_valida_reciboAlmacenD", "@IdRecibo", GridRecibo.GetValue(0), "@DOCClave", "", "@Tipo", 0, "@Modo", 0)
                    dRecibidos = dt.Rows.Count
                    dt.Dispose()

                    If dSaldo > 0 Then
                        Dim a As New MeAutorizacion
                        a.Sucursal = Me.CmbSucursal.SelectedValue
                        a.MontodeAutorizacion = dSaldo
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then
                                dt = ModPOS.Recupera_Tabla("sp_recupera_reciboalmacen", "@IdRecibo", GridRecibo.GetValue(0))

                                If CInt(dt.Rows(0)("Estado")) <= 1 Then
                                    If dRecibidos = 0 Then
                                        ModPOS.Ejecuta("sp_act_edo_recibo", "@IdRecibo", GridRecibo.GetValue(0), "@Estado", 3)
                                        ModPOS.Ejecuta("st_act_reciboalmacent", "@IdRecibo", GridRecibo.GetValue(0), "@Estado", 0)

                                        Me.AgregarFolio()
                                    Else
                                        MessageBox.Show("El recibo no puede ser cancelado debido a que ya se recibio material de algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                                    End If
                                Else
                                    MessageBox.Show("El recibo no puede ser cancelado debido a que se encuentra Finalizado o Cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                                End If
                                    dt.Dispose()
                                End If
                        End If

                    Else
                        dt = ModPOS.Recupera_Tabla("sp_recupera_reciboalmacen", "@IdRecibo", GridRecibo.GetValue(0))

                        If CInt(dt.Rows(0)("Estado")) <= 1 Then
                            If dRecibidos = 0 Then
                                ModPOS.Ejecuta("sp_act_edo_recibo", "@IdRecibo", GridRecibo.GetValue(0), "@Estado", 3)
                                ModPOS.Ejecuta("st_act_reciboalmacent", "@IdRecibo", GridRecibo.GetValue(0), "@Estado", 0)

                                Me.AgregarFolio()
                            Else
                                MessageBox.Show("El recibo no puede ser cancelado debido a que ya se recibio material de algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                            End If
                        Else
                            MessageBox.Show("El recibo no puede ser cancelado debido a que se encuentra Finalizado o Cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                        End If
                            dt.Dispose()
                        End If

            End Select
        Else
            MessageBox.Show("¡No se ha seleccionado un Recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dtFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtFinal.ValueChanged
        If bload = True AndAlso (Fin <> dtFinal.Value) Then
            If dtFinal.Value < Inicio Then
                dtFinal.Value = Inicio
            End If

            Fin = dtFinal.Value

            If Not dtRecibo Is Nothing Then
                dtRecibo.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub


End Class
