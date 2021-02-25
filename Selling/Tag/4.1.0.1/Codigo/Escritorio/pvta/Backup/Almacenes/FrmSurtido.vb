Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSurtido
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPorSurtir As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridPicking As Janus.Windows.GridEX.GridEX
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSurtir As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnLiberar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSurtido))
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.GrpPorSurtir = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.btnLiberar = New Janus.Windows.EditControls.UIButton
        Me.ChkTodos = New System.Windows.Forms.CheckBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnSurtir = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton
        Me.GridPicking = New Janus.Windows.GridEX.GridEX
        Me.GrpPorSurtir.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnReimpresion.Location = New System.Drawing.Point(608, 521)
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
        Me.GrpPorSurtir.Controls.Add(Me.Label2)
        Me.GrpPorSurtir.Controls.Add(Me.CmbAlmacen)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSalir)
        Me.GrpPorSurtir.Controls.Add(Me.btnLiberar)
        Me.GrpPorSurtir.Controls.Add(Me.ChkTodos)
        Me.GrpPorSurtir.Controls.Add(Me.BtnCancelar)
        Me.GrpPorSurtir.Controls.Add(Me.PictureBox1)
        Me.GrpPorSurtir.Controls.Add(Me.BtnSurtir)
        Me.GrpPorSurtir.Controls.Add(Me.Label3)
        Me.GrpPorSurtir.Controls.Add(Me.BtnReimpresion)
        Me.GrpPorSurtir.Controls.Add(Me.CmbSucursal)
        Me.GrpPorSurtir.Controls.Add(Me.Label1)
        Me.GrpPorSurtir.Controls.Add(Me.dtPicker)
        Me.GrpPorSurtir.Controls.Add(Me.BtnRefresh)
        Me.GrpPorSurtir.Controls.Add(Me.GridPicking)
        Me.GrpPorSurtir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpPorSurtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPorSurtir.ForeColor = System.Drawing.Color.Black
        Me.GrpPorSurtir.Location = New System.Drawing.Point(0, 0)
        Me.GrpPorSurtir.Name = "GrpPorSurtir"
        Me.GrpPorSurtir.Size = New System.Drawing.Size(800, 564)
        Me.GrpPorSurtir.TabIndex = 23
        Me.GrpPorSurtir.TabStop = False
        Me.GrpPorSurtir.Text = "Pedidos por Surtir"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(507, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox2.TabIndex = 125
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(463, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Almacén"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.Location = New System.Drawing.Point(540, 14)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(211, 24)
        Me.CmbAlmacen.TabIndex = 123
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(320, 521)
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
        Me.btnLiberar.Location = New System.Drawing.Point(512, 521)
        Me.btnLiberar.Name = "btnLiberar"
        Me.btnLiberar.Size = New System.Drawing.Size(90, 37)
        Me.btnLiberar.TabIndex = 87
        Me.btnLiberar.Text = "&Liberar"
        Me.btnLiberar.ToolTipText = "Desbloquea el pedido que se encuentra en proceso de recolección"
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
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(416, 521)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 86
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(53, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 19)
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnSurtir
        '
        Me.BtnSurtir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSurtir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSurtir.Icon = CType(resources.GetObject("BtnSurtir.Icon"), System.Drawing.Icon)
        Me.BtnSurtir.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnSurtir.Location = New System.Drawing.Point(704, 521)
        Me.BtnSurtir.Name = "BtnSurtir"
        Me.BtnSurtir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSurtir.TabIndex = 25
        Me.BtnSurtir.Text = "Surtir"
        Me.BtnSurtir.ToolTipText = "Surtir pedido seleccionado"
        Me.BtnSurtir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 16)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Sucursal"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Location = New System.Drawing.Point(84, 16)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(252, 24)
        Me.CmbSucursal.TabIndex = 119
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(463, 47)
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
        Me.dtPicker.Location = New System.Drawing.Point(540, 42)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(211, 22)
        Me.dtPicker.TabIndex = 24
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(757, 41)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(37, 24)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPicking
        '
        Me.GridPicking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPicking.ColumnAutoResize = True
        Me.GridPicking.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPicking.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPicking.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPicking.GroupByBoxVisible = False
        Me.GridPicking.Location = New System.Drawing.Point(10, 70)
        Me.GridPicking.Name = "GridPicking"
        Me.GridPicking.RecordNavigator = True
        Me.GridPicking.Size = New System.Drawing.Size(784, 445)
        Me.GridPicking.TabIndex = 4
        Me.GridPicking.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmSurtido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 564)
        Me.Controls.Add(Me.GrpPorSurtir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmSurtido"
        Me.Text = "Surtido de Pedidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpPorSurtir.ResumeLayout(False)
        Me.GrpPorSurtir.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPicking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Private VENClave As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtPicking As DataTable
    Private bload As Boolean = False
    Private Periodo, Mes As Integer
    Private SUCClave As String
    Private ALMClave As String
    Private Movilidad As Boolean

    Public Sub AgregarFolio()
        If validaForm() Then

            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            dtPicking = ModPOS.Recupera_Tabla("sp_obtener_picking", "@ALMClave", ALMClave, "@Periodo", Periodo, "@Mes", Mes)
            GridPicking.DataSource = dtPicking
            GridPicking.RetrieveStructure()
            GridPicking.AutoSizeColumns()
            GridPicking.RootTable.Columns("iTipo").Visible = False
            GridPicking.RootTable.Columns("DOCClave").Visible = False
            GridPicking.RootTable.Columns("CTEClave").Visible = False
            GridPicking.RootTable.Columns("iEstado").Visible = False
            GridPicking.RootTable.Columns("PICClave").Visible = False
            GridPicking.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridPicking.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            If Me.ChkTodos.Checked = True Then
                ChkTodos.Checked = False
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmSurtido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub FrmSurtido_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Surtido.Dispose()
        ModPOS.Surtido = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtPicking Is Nothing Then
                dtPicking.Dispose()
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub GridPicking_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.CurrentCellChanged
        If Not GridPicking.CurrentColumn Is Nothing Then
            If GridPicking.CurrentColumn.Caption = "Marca" Then
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridPicking.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        AgregarFolio()
    End Sub

    Private Sub GridPicking_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPicking.SelectionChanged
        If Not GridPicking.GetValue(0) Is Nothing Then
            Me.BtnReimpresion.Enabled = True
            Me.BtnSurtir.Enabled = True

        Else
            Me.BtnReimpresion.Enabled = False
            Me.BtnSurtir.Enabled = False
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then
            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.ImprimirSurtido(foundRows(i)("iTipo"), foundRows(i)("DOCClave"), PrintDialog1.PrinterSettings.PrinterName)
                Next
            End If
        End If
    End Sub

    Private Sub modificaSurtido()

        Dim foundRows() As DataRow
        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado= 6)")

        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que encuentran en proceso de recolección, debe liberarlos previante antes de continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim i As Integer
        Dim dt As DataTable


        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Movilidad = IIf(dt.Rows(0)("Movilidad").GetType.Name = "DBNull", False, dt.Rows(0)("Movilidad"))
        dt.Dispose()

        foundRows = dtPicking.Select("Marca ='True'")

        If Movilidad = False Then
            Dim sDoctos As String = ""
            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("PICClave").GetType.Name <> "DBNull" Then
                            MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra en proceso de recolección será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            If sDoctos = "" Then
                                sDoctos = foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                            Else
                                sDoctos &= "|" & foundRows(i)("DOCClave") & "," & CStr(foundRows(i)("iTipo"))
                            End If

                        End If
                    End If
                    dt.Dispose()
                Next
            End If

            If ModPOS.Picking Is Nothing Then
                ModPOS.Picking = New FrmPicking
                With ModPOS.Picking
                    .StartPosition = FormStartPosition.CenterScreen
                    .Documentos = sDoctos
                    .ALMClave = Me.ALMClave
                End With
            End If

            ModPOS.Picking.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Picking.Show()
            ModPOS.Picking.BringToFront()

        Else

            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    dt = ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"))
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("PICClave").GetType.Name <> "DBNull" Then
                            MessageBox.Show("El documento " & foundRows(i)("Folio") & " se encuentra en proceso de recolección será excluido de esta lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            ModPOS.Ejecuta("sp_prioridad_picking", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                    dt.Dispose()
                Next

                Me.AgregarFolio()

            Else
                MessageBox.Show("¡Debe Marcar por lo menos un documento para Surtir!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub BtnSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSurtir.Click
        modificaSurtido()
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If dtPicking.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To dtPicking.Rows.Count - 1
                    dtPicking.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtPicking.Rows.Count - 1
                    dtPicking.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and Total <> Saldo")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser Cancelados debido a que tienen un abono asociado")
            Exit Sub
        End If


        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 8 or iEstado=6)")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser Cancelados debido a que se encuentran en Proceso de Recolección o Picking")
            Exit Sub
        End If

        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Ha seleccionado una sucursal invalida o es requerida")
            Exit Sub
        End If

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then

            Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(Saldo)", "Marca = True"))

            Select Case MessageBox.Show("¿Esta seguro de Cancelar los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion
                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dSaldo
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Dim Autoriza As String = a.Autoriza
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)
                                If foundRows(i)("iTipo") = 1 Then
                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(i)("DOCClave"), "@TipoDoc", 1)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(i)("CTEClave"), "@Importe", foundRows(i)("Total"))
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(i)("DOCClave"), "@Tipo", 1)
                                ElseIf foundRows(i)("iTipo") = 8 Then
                                    ModPOS.Ejecuta("sp_cancela_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@USRClave", ModPOS.UsuarioActual)
                                ElseIf foundRows(i)("iTipo") = 6 Then
                                    ModPOS.Ejecuta("sp_cancela_transferencia", "@MVAClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)
                                End If
                                ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", foundRows(i)("iTipo"), "@DOCClave", foundRows(i)("DOCClave"), "@ALMClave", ALMClave)
                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento(s) que desea Cancelar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnLiberar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberar.Click
        Dim foundRows() As DataRow

        foundRows = dtPicking.Select("Marca ='True' and (iEstado = 7 or iEstado=5)")
        If foundRows.GetLength(0) > 0 Then
            MessageBox.Show("Ha seleccionado documentos que no pueden ser liberados debido a que no se encuentran en Proceso")
            Exit Sub
        End If

        foundRows = dtPicking.Select("Marca ='True'")

        If foundRows.GetLength(0) > 0 Then

            Dim dSaldo As Double = IIf(dtPicking.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtPicking.Compute("Sum(Saldo)", "Marca = True"))

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
                                'Liberar Pedido
                                ModPOS.Ejecuta("sp_agrega_picking", "@Tipo", foundRows(i)("iTipo"), "@PICClave", Nothing, "@DOCClave", foundRows(i)("DOCClave"), "@Usuario", ModPOS.UsuarioActual)

                                If foundRows(i)("iTipo") = 1 Then
                                    ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", foundRows(i)("DOCClave"), "@Estado", 7)
                                ElseIf foundRows(i)("iTipo") = 8 Then
                                    ModPOS.Ejecuta("sp_actualiza_estado_traslado", "@TRSClave", foundRows(i)("DOCClave"), "@Estado", 5)
                                ElseIf foundRows(i)("iTipo") = 6 Then
                                    ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", foundRows(i)("DOCClave"), "@Estado", 5)

                                End If
                            Next
                            AgregarFolio()
                        End If
                    End If
            End Select
        Else
            MessageBox.Show("¡Debe Marcar el documento que desea Liberar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub CmbAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bload = True AndAlso CmbAlmacen.SelectedValue Is Nothing Then
            ALMClave = ""
        ElseIf bload = True Then
            ALMClave = CmbAlmacen.SelectedValue
        End If
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbAlmacen.SelectedValueChanged
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
