Public Class FrmMtoExcepcion
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
    Friend WithEvents GridExcepcion As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents cmbGrupoPrecio As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents LblDestino As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoExcepcion))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.cmbGrupoPrecio = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.LblDestino = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridExcepcion = New Janus.Windows.GridEX.GridEX()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridExcepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnModificar)
        Me.GrpTickets.Controls.Add(Me.cmbGrupoPrecio)
        Me.GrpTickets.Controls.Add(Me.Label2)
        Me.GrpTickets.Controls.Add(Me.cmbTipoCanal)
        Me.GrpTickets.Controls.Add(Me.LblDestino)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.TxtMaxHits)
        Me.GrpTickets.Controls.Add(Me.CmbCampo)
        Me.GrpTickets.Controls.Add(Me.TxtBuscar)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.BtnAgregar)
        Me.GrpTickets.Controls.Add(Me.GridExcepcion)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(784, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Excepciones"
        '
        'BtnModificar
        '
        Me.BtnModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificar.Image = CType(resources.GetObject("BtnModificar.Image"), System.Drawing.Image)
        Me.BtnModificar.Location = New System.Drawing.Point(594, 430)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(90, 37)
        Me.BtnModificar.TabIndex = 161
        Me.BtnModificar.Text = "&Modificar"
        Me.BtnModificar.ToolTipText = "Modifica el precio de la vigencia seleccionada"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbGrupoPrecio
        '
        Me.cmbGrupoPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGrupoPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupoPrecio.Location = New System.Drawing.Point(119, 49)
        Me.cmbGrupoPrecio.Name = "cmbGrupoPrecio"
        Me.cmbGrupoPrecio.Size = New System.Drawing.Size(211, 24)
        Me.cmbGrupoPrecio.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Gpo. Precios"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.Location = New System.Drawing.Point(119, 21)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(211, 24)
        Me.cmbTipoCanal.TabIndex = 158
        '
        'LblDestino
        '
        Me.LblDestino.Location = New System.Drawing.Point(9, 24)
        Me.LblDestino.Name = "LblDestino"
        Me.LblDestino.Size = New System.Drawing.Size(103, 16)
        Me.LblDestino.TabIndex = 157
        Me.LblDestino.Text = "Canal de Venta"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(336, 52)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox2.TabIndex = 156
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(336, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 19)
        Me.PictureBox1.TabIndex = 155
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(589, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 16)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(722, 81)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 22)
        Me.TxtMaxHits.TabIndex = 153
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 82)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 24)
        Me.CmbCampo.TabIndex = 152
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(178, 82)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(259, 22)
        Me.TxtBuscar.TabIndex = 151
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(404, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(500, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Text = "&Eliminar"
        Me.BtnCancelar.ToolTipText = "Cancela la excepción seleccionada"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(688, 430)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 21
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Crea una nueva Excepción de Precio"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridExcepcion
        '
        Me.GridExcepcion.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridExcepcion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridExcepcion.ColumnAutoResize = True
        Me.GridExcepcion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridExcepcion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridExcepcion.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridExcepcion.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridExcepcion.Location = New System.Drawing.Point(7, 112)
        Me.GridExcepcion.Name = "GridExcepcion"
        Me.GridExcepcion.RecordNavigator = True
        Me.GridExcepcion.Size = New System.Drawing.Size(770, 312)
        Me.GridExcepcion.TabIndex = 2
        Me.GridExcepcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmMtoExcepcion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoExcepcion"
        Me.Text = "Excepción de Precio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridExcepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Mes As Integer
    Public Periodo As Integer

    Private TallaColor As Integer = 0
    Private sExcepcionSelected, sTipoCliente As String
    Private bCargado As Boolean = False
    Private dt As DataTable


    Private Sub Modifica_Excepcion()
        If ModPOS.Excepcion Is Nothing Then
            ModPOS.Excepcion = New FrmExcepcion
            With ModPOS.Excepcion
                .TallaColor = TallaColor
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .EXPClave = sExcepcionSelected
                .Cliente = GridExcepcion.GetValue("Cliente")
                .Producto = GridExcepcion.GetValue("Clave")
                .dtInicio.Visible = False
                .lblInicio.Visible = False
                .cmbTipo.Enabled = False
                .btnCte.Enabled = False
                .BtnProd.Enabled = False
                .TxtCliente.ReadOnly = True
                .TxtClave.ReadOnly = True
                .Precio = GridExcepcion.GetValue("Precio")
                .Minimo = GridExcepcion.GetValue("Minimo")
            End With
        End If
        ModPOS.Excepcion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Excepcion.Show()
        ModPOS.Excepcion.BringToFront()

    End Sub


    Private Sub actGrid(ByVal MaxHits As Integer, ByVal iCampo As Integer, ByVal sBusqueda As String, ByVal iCanal As Integer, ByVal iGrupo As Integer)
        Clock.Stop()

        If bCargado Then
            If Not dt Is Nothing Then
                dt.Dispose()
            End If



            dt = ModPOS.Recupera_Tabla("sp_muestra_excepciones", "@Max", MaxHits, "@Campo", iCampo, "@Busqueda", sBusqueda, "@Canal", iCanal, "@Grupo", iGrupo, "@Char", cReplace)

            GridExcepcion.DataSource = dt
            GridExcepcion.RetrieveStructure(True)
            GridExcepcion.GroupByBoxVisible = False
            GridExcepcion.RootTable.Columns("EXPClave").Visible = False
            GridExcepcion.RootTable.Columns("Cliente").Width = 40
            GridExcepcion.RootTable.Columns("Clave").Width = 60
            GridExcepcion.RootTable.Columns("Nombre").Width = 190
            GridExcepcion.RootTable.Columns("Precio").Width = 40
            GridExcepcion.RootTable.Columns("Minimo").Width = 40
            GridExcepcion.RootTable.Columns("Inicio").Width = 40
            GridExcepcion.RootTable.Columns("Fin").Width = 40



        End If

    End Sub

    Public Sub addExcepcion(ByVal sEXPClave As String,ByVal sCliente As String, ByVal sClave As String, ByVal sNombre As String,byval Precio as double, byval Minimo as double, byval dInicio as date, byval dFin as date)
        Dim row1 As DataRow
        row1 = dt.NewRow()
        row1.Item("EXPClave") = sEXPClave
        row1.Item("Cliente") = sCliente
        row1.Item("Clave") = sClave
        row1.Item("Nombre") = sNombre
        row1.Item("Precio") = Precio
        row1.Item("Minimo") = Minimo
        row1.Item("Inicio") = dInicio
        row1.Item("Fin") = dFin
        dt.Rows.Add(row1)
    End Sub


    Public Sub updExcepcion(ByVal sEXPClave As String, ByVal fPrecio As Double, ByVal fMinimo As Double)
        Dim foundRows() As System.Data.DataRow

        foundRows = dt.Select("EXPClave = '" & sEXPClave & "'")

        If foundRows.GetLength(0) > 0 Then

            foundRows(0)("Precio") = fPrecio
            foundRows(0)("Minimo") = fMinimo


        End If
    End Sub

    Private Sub FrmMtoExcepcion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoExcepcion.Dispose()
        ModPOS.MtoExcepcion = Nothing
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not CmbCampo.SelectedValue Is Nothing AndAlso Not cmbTipoCanal.SelectedValue Is Nothing AndAlso Not cmbGrupoPrecio.SelectedValue Is Nothing Then
            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, cmbTipoCanal.SelectedValue, cmbGrupoPrecio.SelectedValue)
        End If
    End Sub

    Private Sub FrmMtoExcepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With

        With cmbGrupoPrecio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Precio"
            .NombreParametro2 = "campo"
            .Parametro2 = "Grupo"
            .llenar()
        End With

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With


        bCargado = True

        Me.actGrid(0, 1, "", cmbTipoCanal.SelectedValue, cmbGrupoPrecio.SelectedValue)



    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If sExcepcionSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la excepción de precio seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    ModPOS.Ejecuta("sp_elimina_excepcion", "@EXPClave", sExcepcionSelected, "@Cliente", sTipoCliente)
                    Dim foundRows() As System.Data.DataRow

                    foundRows = dt.Select("EXPClave = '" & sExcepcionSelected & "' and Cliente ='" & sTipoCliente & "'")

                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            dt.Rows.Remove(foundRows(i))
                        Next

                    End If
            End Select
        End If

    End Sub

    Private Sub GridExcepcion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridExcepcion.DoubleClick
        If sExcepcionSelected <> "" Then
            Modifica_Excepcion()
        End If
    End Sub

    Private Sub GridExcepcion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridExcepcion.SelectionChanged
        If Not GridExcepcion.GetValue(0) Is Nothing Then
            Me.BtnCancelar.Enabled = True
            Me.sExcepcionSelected = GridExcepcion.GetValue("EXPClave")
            sTipoCliente = GridExcepcion.GetValue("Cliente")
           
        Else
            BtnCancelar.Enabled = False
            Me.sExcepcionSelected = ""
            sTipoCliente = ""

        End If
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Excepcion Is Nothing Then
            ModPOS.Excepcion = New FrmExcepcion
            With ModPOS.Excepcion
                .TallaColor = TallaColor
                .StartPosition = FormStartPosition.CenterScreen
                .Canal = cmbTipoCanal.SelectedValue
                .Grupo = cmbGrupoPrecio.SelectedValue

            End With
        End If
        ModPOS.Excepcion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Excepcion.Show()
        ModPOS.Excepcion.BringToFront()

    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        If sExcepcionSelected <> "" Then
            Modifica_Excepcion()
        End If
    End Sub
End Class
