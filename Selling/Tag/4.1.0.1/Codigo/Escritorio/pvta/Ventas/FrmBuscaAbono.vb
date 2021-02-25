Public Class FrmBuscaAbono
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Dim TotalPago As Object

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
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbFiltro As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAbono As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaAbono))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX()
        Me.CmbFiltro = New Selling.StoreCombo()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnAbono = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.Label2)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.CmbFecha)
        Me.GrpTickets.Controls.Add(Me.TxtBusqueda)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.GridAbonos)
        Me.GrpTickets.Controls.Add(Me.CmbFiltro)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, 7)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(778, 420)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Busqueda"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Filtro"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(598, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Fecha"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(358, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox2.TabIndex = 71
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbFecha
        '
        Me.CmbFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFecha.CustomFormat = "yyyyMMdd"
        Me.CmbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFecha.Location = New System.Drawing.Point(653, 19)
        Me.CmbFecha.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFecha.Name = "CmbFecha"
        Me.CmbFecha.Size = New System.Drawing.Size(119, 22)
        Me.CmbFecha.TabIndex = 70
        Me.CmbFecha.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBusqueda.Location = New System.Drawing.Point(49, 19)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(132, 21)
        Me.TxtBusqueda.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(187, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GridAbonos
        '
        Me.GridAbonos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAbonos.ColumnAutoResize = True
        Me.GridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAbonos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAbonos.GroupByBoxVisible = False
        Me.GridAbonos.Location = New System.Drawing.Point(7, 47)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(765, 367)
        Me.GridAbonos.TabIndex = 2
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbFiltro
        '
        Me.CmbFiltro.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFiltro.Location = New System.Drawing.Point(212, 17)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(140, 24)
        Me.CmbFiltro.TabIndex = 45
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 433)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 44
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(599, 433)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 45
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAbono
        '
        Me.btnAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbono.Icon = CType(resources.GetObject("btnAbono.Icon"), System.Drawing.Icon)
        Me.btnAbono.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnAbono.Location = New System.Drawing.Point(503, 433)
        Me.btnAbono.Name = "btnAbono"
        Me.btnAbono.Size = New System.Drawing.Size(90, 37)
        Me.btnAbono.TabIndex = 46
        Me.btnAbono.Text = "Editar"
        Me.btnAbono.ToolTipText = "Modifica Abono"
        Me.btnAbono.Visible = False
        Me.btnAbono.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(407, 433)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 53
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancelación del Abono seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmBuscaAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.btnAbono)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.GrpTickets)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmBuscaAbono"
        Me.Text = "Busqueda de Abonos"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ABNClave As String
    Public ReciboTicket As Integer = 0
    Public dtDetallePago As DataTable
    ' Private sTicketSelected As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False

    Private Sub FrmBuscaAbono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2


        With Me.CmbFiltro
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        CmbFecha.Value = Today

        bload = True

        TxtBusqueda.Text = "%"
        RefrescaGrid()
    End Sub

    Public Sub RefrescaGrid()
        If validaForm() Then

            ModPOS.ActualizaGrid(False, Me.GridAbonos, "sp_recupera_abonos", "@Campo", CmbFiltro.SelectedValue, "@Busqueda", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@Inicio", CmbFecha.Value, "@Fin", CmbFecha.Value.AddHours(23.9999))
            Me.GridAbonos.RootTable.Columns("ID").Visible = False
            Me.GridAbonos.RootTable.Columns("Metodo").Width = 50
            Me.GridAbonos.RootTable.Columns("Ref").Width = 30
            Me.GridAbonos.RootTable.Columns("Folio").Width = 90
            Me.GridAbonos.RootTable.Columns("Importe").Width = 70
            Me.GridAbonos.RootTable.Columns("Saldo").Width = 50
            Me.GridAbonos.RootTable.Columns("Aplicado").Width = 50
            Me.GridAbonos.RootTable.Columns("Clave").Width = 70
            Me.GridAbonos.RootTable.Columns("Razón Social").Width = 190
            Me.GridAbonos.RootTable.Columns("Nota").Visible = False
            Me.GridAbonos.RootTable.Columns("Banco").Visible = False
            Me.GridAbonos.RootTable.Columns("NumCta").Visible = False
            GridAbonos.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridAbonos.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridAbonos.RootTable.Columns("Aplicado").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbFiltro.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtBusqueda.Text = "" Then
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not GridAbonos.DataSource Is Nothing Then
            If Not GridAbonos.GetValue(0) Is Nothing Then
                ABNClave = GridAbonos.GetValue(0)
                If ReciboTicket = 1 Then
                    dtDetallePago = ModPOS.CrearTabla("DetallePago", _
                    "ABNClave", "System.String", _
                    "Metodo", "System.String", _
                    "Monto", "System.Double", _
                    "Banco", "System.String", _
                    "Ref", "System.String", _
                    "NumCta", "System.String", _
                    "Cliente", "System.String", _
                    "Nombre", "System.String", _
                    "Nota", "System.String")

                    Dim row1 As DataRow
                    row1 = dtDetallePago.NewRow()
                    'declara el nombre de la fila

                 

                    row1.Item("ABNClave") = GridAbonos.GetValue("ID")
                    row1.Item("Metodo") = GridAbonos.GetValue("Metodo")
                    row1.Item("Monto") = GridAbonos.GetValue("Importe")
                    row1.Item("Banco") = GridAbonos.GetValue("Banco")
                    row1.Item("Ref") = GridAbonos.GetValue("Ref")
                    row1.Item("NumCta") = GridAbonos.GetValue("NumCta")
                    row1.Item("Cliente") = GridAbonos.GetValue("Clave")
                    row1.Item("Nombre") = GridAbonos.GetValue("Razón Social")
                    row1.Item("Nota") = GridAbonos.GetValue("Nota")
                    dtDetallePago.Rows.Add(row1)

                End If
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                ABNClave = ""
            End If
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub GridAbonos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAbonos.DoubleClick
        If Not GridAbonos.GetValue(0) Is Nothing Then
            BtnGuardar.PerformClick()
        End If
    End Sub

    Private Sub GridAbonos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridAbonos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnGuardar.PerformClick()
        End If
    End Sub

    Private Sub GridAbonos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAbonos.SelectionChanged
        If Not GridAbonos.GetValue(0) Is Nothing Then
            Me.BtnGuardar.Enabled = True
            If CmbFecha.Value.Date.ToString("MM/dd/yyyy") = Today.Date.ToString("MM/dd/yyyy") AndAlso Not GridAbonos.GetValue("Banco").GetType.ToString = "System.DBNull" Then
                If GridAbonos.GetValue("Banco") <> "" Then
                    btnAbono.Visible = True
                Else
                    btnAbono.Visible = False
                End If
            Else
                btnAbono.Visible = False
            End If
        Else
            Me.BtnGuardar.Enabled = False
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub TxtBusqueda_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusqueda.KeyUp
        If TxtBusqueda.Text <> "" Then
            RefrescaGrid()
        End If
    End Sub

    Private Sub CmbFecha_ValueChanged(sender As Object, e As EventArgs) Handles CmbFecha.ValueChanged
        If bload Then
            RefrescaGrid()
        End If
    End Sub

    Private Sub CmbFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbFiltro.SelectedValueChanged
        If bload AndAlso Not CmbFiltro.SelectedValue Is Nothing Then
            RefrescaGrid()
        End If
    End Sub

    Private Sub btnAbono_Click(sender As Object, e As EventArgs) Handles btnAbono.Click
        If Not GridAbonos.GetValue(0) Is Nothing Then
            Dim a As New FrmEditAbono
            a.ABNClave = GridAbonos.GetValue(0)
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        If Not GridAbonos.GetValue(0) Is Nothing Then
            Dim Tipo, Estado As Integer
            Dim Importe, Saldo As Decimal
            Dim SUCClave, Clave As String

            If CmbFecha.Value <> Today Then
                MessageBox.Show("El Abono seleccionado no se puede cancelar debido a que no corresponde a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", GridAbonos.GetValue(0))
            Tipo = dt.Rows(0)("Tipo")
            Importe = dt.Rows(0)("Importe")
            Saldo = dt.Rows(0)("Saldo")
            SUCClave = dt.Rows(0)("SUCClave")
            Clave = dt.Rows(0)("Clave")
            dt.Dispose()
            If Tipo = 1 Then
                dt = ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", GridAbonos.GetValue(0))
            Else
                dt = ModPOS.Recupera_Tabla("st_sello_anticipo", "@ABNClave", GridAbonos.GetValue(0))
            End If

            If dt.Rows.Count = 0 Then
                Estado = 2
            Else
                Estado = dt.Rows(0)("estado")
            End If
            dt.Dispose()

            If Estado = 1 Then
                MessageBox.Show("El Abono seleccionado no se puede cancelar debido a que se encuentra Certificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Saldo <> Importe Then
                dt = ModPOS.Recupera_Tabla("st_detalle_pago", "@ABNClave", GridAbonos.GetValue(0))

                Dim foundRows() As DataRow = dt.Select("SaldoRemanente <> SaldoActual")

                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("El Abono seleccionado No puede ser cancelado debido a que No es el ultimo numero de pago aplicado a los documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If


            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & Clave & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = Importe
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then

                            ModPOS.Ejecuta("st_cancela_abono", "@ABNClave", GridAbonos.GetValue(0))
                            RefrescaGrid()

                        End If
                    End If

            End Select
        End If
    End Sub
End Class
