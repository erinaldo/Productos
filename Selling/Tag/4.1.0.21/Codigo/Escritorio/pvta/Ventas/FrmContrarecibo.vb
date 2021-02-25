Public Class FrmContrarecibo
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
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents GrpModificador As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbUsuario As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbZonaReparto As Selling.StoreCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContrarecibo))
        Me.GrpModificador = New System.Windows.Forms.GroupBox()
        Me.txtFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbZonaReparto = New Selling.StoreCombo()
        Me.cmbUsuario = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.GrpModificador.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpModificador
        '
        Me.GrpModificador.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpModificador.Controls.Add(Me.TxtReferencia)
        Me.GrpModificador.Controls.Add(Me.Label2)
        Me.GrpModificador.Controls.Add(Me.PictureBox2)
        Me.GrpModificador.Controls.Add(Me.cmbZonaReparto)
        Me.GrpModificador.Controls.Add(Me.Label28)
        Me.GrpModificador.Controls.Add(Me.txtFinal)
        Me.GrpModificador.Controls.Add(Me.Label6)
        Me.GrpModificador.Controls.Add(Me.Label5)
        Me.GrpModificador.Controls.Add(Me.TxtInicial)
        Me.GrpModificador.Controls.Add(Me.Label4)
        Me.GrpModificador.Controls.Add(Me.dtFinal)
        Me.GrpModificador.Controls.Add(Me.Label1)
        Me.GrpModificador.Controls.Add(Me.dtPicker)
        Me.GrpModificador.Controls.Add(Me.GridDetalle)
        Me.GrpModificador.Controls.Add(Me.PictureBox1)
        Me.GrpModificador.Controls.Add(Me.cmbUsuario)
        Me.GrpModificador.Controls.Add(Me.LblClave)
        Me.GrpModificador.Controls.Add(Me.ChkTodos)
        Me.GrpModificador.Location = New System.Drawing.Point(5, 7)
        Me.GrpModificador.Name = "GrpModificador"
        Me.GrpModificador.Size = New System.Drawing.Size(772, 510)
        Me.GrpModificador.TabIndex = 1
        Me.GrpModificador.TabStop = False
        Me.GrpModificador.Text = "Gestión de Contrarecibo"
        '
        'txtFinal
        '
        Me.txtFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFinal.Location = New System.Drawing.Point(675, 47)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.Size = New System.Drawing.Size(92, 20)
        Me.txtFinal.TabIndex = 151
        Me.txtFinal.Text = "99"
        Me.txtFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtFinal.Value = 99
        Me.txtFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(650, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "al"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(483, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Prioridad"
        '
        'TxtInicial
        '
        Me.TxtInicial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtInicial.Location = New System.Drawing.Point(552, 47)
        Me.TxtInicial.Name = "TxtInicial"
        Me.TxtInicial.Size = New System.Drawing.Size(92, 20)
        Me.TxtInicial.TabIndex = 148
        Me.TxtInicial.Text = "0"
        Me.TxtInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtInicial.Value = 0
        Me.TxtInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(650, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "al"
        '
        'dtFinal
        '
        Me.dtFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtFinal.CustomFormat = "MMMM yyyy"
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(675, 18)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.ShowUpDown = True
        Me.dtFinal.Size = New System.Drawing.Size(92, 20)
        Me.dtFinal.TabIndex = 146
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(483, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPicker.Location = New System.Drawing.Point(552, 18)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(92, 20)
        Me.dtPicker.TabIndex = 144
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(6, 121)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(761, 383)
        Me.GridDetalle.TabIndex = 143
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(64, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox1.TabIndex = 140
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(3, 24)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Responsable"
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(6, 96)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkTodos.TabIndex = 142
        Me.ChkTodos.Text = "Todos"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(687, 523)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(591, 523)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(3, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(115, 15)
        Me.Label28.TabIndex = 153
        Me.Label28.Text = "Zona de Reparto"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(64, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox2.TabIndex = 154
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 13
        Me.cmbZonaReparto.Location = New System.Drawing.Point(119, 46)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(261, 21)
        Me.cmbZonaReparto.TabIndex = 152
        '
        'cmbUsuario
        '
        Me.cmbUsuario.Location = New System.Drawing.Point(119, 21)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(261, 21)
        Me.cmbUsuario.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 155
        Me.Label2.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtReferencia.Location = New System.Drawing.Point(119, 72)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(261, 21)
        Me.TxtReferencia.TabIndex = 156
        '
        'FrmContrarecibo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpModificador)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(455, 253)
        Me.Name = "FrmContrarecibo"
        Me.Text = "Contrarecibo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpModificador.ResumeLayout(False)
        Me.GrpModificador.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public CAJClave As String
    Private Responsable, Referencia As String
    Private ZonaReparto, PIN, PFN As Integer
    Private Inicio, Fin As Date
    Private dtFactura As DataTable
    Private bload As Boolean = False
    Private alerta(1) As PictureBox
    Private reloj As parpadea


#Region "Metodos Internos"

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If cmbUsuario.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbZonaReparto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If



        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length - 1
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

#End Region

    Public Sub AgregarFolio()
        If validaForm() Then


            Cursor.Current = Cursors.WaitCursor

            If Not dtFactura Is Nothing Then
                dtFactura.Dispose()
            End If
            dtFactura = ModPOS.Recupera_Tabla("sp_recupera_contrarecibo", "@CAJClave", CAJClave, "@Inicio", Inicio.Date, "@Fin", Fin.Date.AddHours(23.9999), "@PIN", PIN, "@PFN", PFN)
            GridDetalle.DataSource = dtFactura
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("FACClave").Visible = False
            GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            If Me.ChkTodos.Checked = True Then
                ChkTodos.Checked = False
            End If

            Cursor.Current = Cursors.Default
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmContrarecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        With Me.cmbUsuario
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_empleado"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With


        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With

        Inicio = dtPicker.Value
        Fin = dtFinal.Value
        PIN = CInt(TxtInicial.Text)
        PFN = CInt(txtFinal.Text)

        bload = True

        AgregarFolio()

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Inicio <> dtPicker.Value) Then
            If dtPicker.Value > Fin Then
                dtPicker.Value = Fin
            End If

            Inicio = dtPicker.Value

            If Not dtFactura Is Nothing Then
                dtFactura.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub TxtInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtInicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFinal.Focus()
        End If
    End Sub

    Private Sub TxtInicial_Leave(sender As Object, e As EventArgs) Handles TxtInicial.Leave
        If bload = True AndAlso (PIN <> Math.Abs(CInt(TxtInicial.Text))) Then
            If Math.Abs(CInt(TxtInicial.Text)) > PFN Then
                TxtInicial.Text = PFN
            End If

            PIN = Math.Abs(CInt(TxtInicial.Text))

            If Not dtFactura Is Nothing Then
                dtFactura.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub txtFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridDetalle.Focus()
        End If

    End Sub

    Private Sub txtFinal_Leave(sender As Object, e As EventArgs) Handles txtFinal.Leave
        If bload = True AndAlso (PIN <> Math.Abs(CInt(txtFinal.Text))) Then
            If Math.Abs(CInt(txtFinal.Text)) < PIN Then
                txtFinal.Text = PIN
            End If

            PFN = Math.Abs(CInt(txtFinal.Text))

            If Not dtFactura Is Nothing Then
                dtFactura.Dispose()
            End If
            AgregarFolio()

        End If
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtFactura.Rows.Count > 0 Then
            Dim i As Integer

            If ChkTodos.Checked Then
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridDetalle.GetDataRows.Length - 1
                    GridDetalle.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
        End If

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim foundRows() As DataRow

            foundRows = dtFactura.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                Responsable = cmbUsuario.SelectedValue
                ZonaReparto = cmbZonaReparto.SelectedValue
                Referencia = TxtReferencia.Text

                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_agrega_contrarecibo", "@FACClave", foundRows(i)("FACClave"), "@Responsable", Responsable, "@ZonaReparto", ZonaReparto, "@Referencia", Referencia, "@COMClave", ModPOS.CompanyActual, "@Usuario", ModPOS.UsuarioActual)
                Next

                If Not ModPOS.MtoCXC Is Nothing Then
                    If Not ModPOS.MtoCXC Is Nothing Then
                        ModPOS.MtoCXC.actualizaContrarecibos()
                    End If
                End If

                Me.Close()
            Else
                Beep()
                MessageBox.Show("Debe marcar las facturas que desea registrar en control de contrarecibos al responsable seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub GridDetalle_CurrentCellChanging(sender As Object, e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridDetalle.CurrentCellChanging
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Marca" Then
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub
End Class
