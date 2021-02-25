Public Class FrmBank
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
    Friend WithEvents BtnEliminaSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregarSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpBanco As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCuentas As System.Windows.Forms.GroupBox
    Friend WithEvents GridCuentas As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBank))
        Me.GrpBanco = New System.Windows.Forms.GroupBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCuentas = New System.Windows.Forms.GroupBox()
        Me.BtnAgregarSub = New Janus.Windows.EditControls.UIButton()
        Me.GridCuentas = New Janus.Windows.GridEX.GridEX()
        Me.BtnEliminaSub = New Janus.Windows.EditControls.UIButton()
        Me.GrpBanco.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCuentas.SuspendLayout()
        CType(Me.GridCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBanco
        '
        Me.GrpBanco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBanco.Controls.Add(Me.txtRFC)
        Me.GrpBanco.Controls.Add(Me.Label1)
        Me.GrpBanco.Controls.Add(Me.PictureBox1)
        Me.GrpBanco.Controls.Add(Me.ChkEstado)
        Me.GrpBanco.Controls.Add(Me.PictureBox2)
        Me.GrpBanco.Controls.Add(Me.TxtNombre)
        Me.GrpBanco.Controls.Add(Me.LblNombre)
        Me.GrpBanco.Controls.Add(Me.TxtClave)
        Me.GrpBanco.Controls.Add(Me.LblClave)
        Me.GrpBanco.Controls.Add(Me.Label4)
        Me.GrpBanco.Location = New System.Drawing.Point(10, 7)
        Me.GrpBanco.Name = "GrpBanco"
        Me.GrpBanco.Size = New System.Drawing.Size(775, 134)
        Me.GrpBanco.TabIndex = 1
        Me.GrpBanco.TabStop = False
        Me.GrpBanco.Text = "Banco"
        '
        'txtRFC
        '
        Me.txtRFC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRFC.Location = New System.Drawing.Point(87, 99)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(177, 20)
        Me.txtRFC.TabIndex = 57
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 14)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "RFC"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(283, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 17)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(635, 15)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(76, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(482, 67)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(87, 64)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(389, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 67)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(87, 31)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(177, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 34)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 14)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Referencia"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(270, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 432)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 432)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 7
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCuentas
        '
        Me.GrpCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCuentas.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCuentas.Controls.Add(Me.BtnAgregarSub)
        Me.GrpCuentas.Controls.Add(Me.GridCuentas)
        Me.GrpCuentas.Controls.Add(Me.BtnEliminaSub)
        Me.GrpCuentas.Location = New System.Drawing.Point(10, 149)
        Me.GrpCuentas.Name = "GrpCuentas"
        Me.GrpCuentas.Size = New System.Drawing.Size(775, 279)
        Me.GrpCuentas.TabIndex = 2
        Me.GrpCuentas.TabStop = False
        Me.GrpCuentas.Text = "Cuentas"
        '
        'BtnAgregarSub
        '
        Me.BtnAgregarSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregarSub.Image = CType(resources.GetObject("BtnAgregarSub.Image"), System.Drawing.Image)
        Me.BtnAgregarSub.Location = New System.Drawing.Point(679, 19)
        Me.BtnAgregarSub.Name = "BtnAgregarSub"
        Me.BtnAgregarSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregarSub.TabIndex = 2
        Me.BtnAgregarSub.Text = "&Agregar"
        Me.BtnAgregarSub.ToolTipText = "Agrega nueva cuenta de banco"
        Me.BtnAgregarSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridCuentas
        '
        Me.GridCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCuentas.ColumnAutoResize = True
        Me.GridCuentas.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCuentas.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCuentas.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCuentas.Location = New System.Drawing.Point(7, 19)
        Me.GridCuentas.Name = "GridCuentas"
        Me.GridCuentas.RecordNavigator = True
        Me.GridCuentas.Size = New System.Drawing.Size(667, 253)
        Me.GridCuentas.TabIndex = 1
        Me.GridCuentas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnEliminaSub
        '
        Me.BtnEliminaSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaSub.Image = CType(resources.GetObject("BtnEliminaSub.Image"), System.Drawing.Image)
        Me.BtnEliminaSub.Location = New System.Drawing.Point(679, 52)
        Me.BtnEliminaSub.Name = "BtnEliminaSub"
        Me.BtnEliminaSub.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaSub.TabIndex = 4
        Me.BtnEliminaSub.Text = "&Eliminar "
        Me.BtnEliminaSub.ToolTipText = "Elimina la cuenta seleccionada"
        Me.BtnEliminaSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmBank
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpBanco)
        Me.Controls.Add(Me.GrpCuentas)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmBank"
        Me.Text = "FrmBank"
        Me.GrpBanco.ResumeLayout(False)
        Me.GrpBanco.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCuentas.ResumeLayout(False)
        CType(Me.GridCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public BNKClave As String
    Public Referencia As String
    Public Nombre As String
    Public Estado As Integer = 1
    Public RFC As String

    Private sCountSelected As String
    Private sCountRef As String

    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private dtCuentas As DataTable

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Bank", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        TxtClave.Text = Referencia
        TxtNombre.Text = Nombre
        txtRFC.Text = RFC
        ChkEstado.Estado = Estado
        ChkEstado.Enabled = True


        If Padre = "Agregar" Then

            BNKClave = ModPOS.obtenerLlave

            dtCuentas = ModPOS.CrearTabla("Count", _
            "CNTAClave", "System.String", _
            "Cuenta", "System.String", _
            "Referencia", "System.String", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")
        Else
            dtCuentas = ModPOS.Recupera_Tabla("sp_muestra_cuentas", "@BNKClave", BNKClave)
        End If

        GridCuentas.DataSource = dtCuentas
        GridCuentas.RetrieveStructure(True)
        GridCuentas.GroupByBoxVisible = False
        GridCuentas.RootTable.Columns("CNTAClave").Visible = False
        GridCuentas.RootTable.Columns("Update").Visible = False
        GridCuentas.RootTable.Columns("Baja").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCuentas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridCuentas.RootTable.FormatConditions.Add(fc)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub Reinicializa()

        BNKClave = ModPOS.obtenerLlave
        Referencia = ""
        Nombre = ""
        Estado = 1
        RFC = ""
        TxtClave.Text = Referencia
        TxtNombre.Text = Nombre
        ChkEstado.Estado = Estado
        txtRFC.Text = ""

        dtCuentas = ModPOS.CrearTabla("Count", _
        "CNTAClave", "System.String", _
        "Cuenta", "System.String", _
        "Referencia", "System.String", _
        "Estado", "System.String", _
        "Update", "System.Int32", _
        "Baja", "System.Int32")

        GridCuentas.DataSource = dtCuentas
        GridCuentas.RetrieveStructure(True)
        GridCuentas.GroupByBoxVisible = False
        GridCuentas.RootTable.Columns("CNTAClave").Visible = False
        GridCuentas.RootTable.Columns("Update").Visible = False
        GridCuentas.RootTable.Columns("Baja").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCuentas.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridCuentas.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim foundRows() As System.Data.DataRow

            Select Case Me.Padre
                Case "Agregar"

                    Referencia = UCase(Trim(Me.TxtClave.Text))
                    Nombre = UCase(Trim(Me.TxtNombre.Text))
                    RFC = txtRFC.Text.ToUpper.Trim

                    Me.Estado = ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_inserta_bank", "@BNKClave", BNKClave, "@Referencia", Referencia, "@Nombre", Nombre, "@RFC", RFC, "@Estado", Estado, "@Usuario", ModPOS.UsuarioActual)


                    foundRows = dtCuentas.Select(" Update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_count", _
                            "@BNKClave", BNKClave, _
                            "@CNTAClave", foundRows(z)("CNTAClave"), _
                            "@Cuenta", foundRows(z)("Cuenta"), _
                            "@Referencia", foundRows(z)("Referencia"), _
                            "@Baja", foundRows(z)("Baja"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Reinicializa()

                Case "Modificar"
                    If Not (Nombre = UCase(Trim(Me.TxtNombre.Text)) AndAlso RFC = txtRFC.Text.ToUpper.Trim AndAlso Estado = ChkEstado.GetEstado) Then
                        RFC = txtRFC.Text.ToUpper.Trim
                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                        Me.Estado = ChkEstado.GetEstado

                        ModPOS.Ejecuta("sp_actualiza_bank", "@BNKClave", BNKClave, "@Nombre", Nombre, "@RFC", RFC, "@Estado", Estado, "@Usuario", ModPOS.UsuarioActual)

                    End If

                    foundRows = dtCuentas.Select(" Update = 1 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_count", _
                            "@BNKClave", BNKClave, _
                            "@CNTAClave", foundRows(z)("CNTAClave"), _
                            "@Cuenta", foundRows(z)("Cuenta"), _
                            "@Referencia", foundRows(z)("Referencia"), _
                            "@Baja", foundRows(z)("Baja"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Me.Close()

            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmBank_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoBancos Is Nothing Then
            ModPOS.ActualizaGrid(True, ModPOS.MtoBancos.GridBancos, "sp_recupera_bancos", Nothing)
            ModPOS.MtoBancos.GridBancos.RootTable.Columns("BNKClave").Visible = False
        End If
        ModPOS.Bancos.Dispose()
        ModPOS.Bancos = Nothing
    End Sub

    Private Sub BtnAgregarSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarSub.Click
        Dim row1 As DataRow
        row1 = dtCuentas.NewRow()
        'declara el nombre de la fila

        row1.Item("CNTAClave") = ModPOS.obtenerLlave
        row1.Item("Cuenta") = ""
        row1.Item("Referencia") = ""
        row1.Item("Update") = 0
        row1.Item("Baja") = 0

        dtCuentas.Rows.Add(row1)

    End Sub

    Private Sub BtnEliminaSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaSub.Click
        If Me.sCountSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el No. Cuenta :" & sCountRef, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCuentas.Select("CNTAClave Like '" & sCountSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridCuentas_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCuentas.CellEdited

        Select Case GridCuentas.CurrentColumn.Caption
            Case "Cuenta"

                If GridCuentas.GetValue("Cuenta").GetType.Name = "DBNull" OrElse CStr(GridCuentas.GetValue("Cuenta")).Length = 0 Then
                    GridCuentas.SetValue("Cuenta", "ERROR")
                    GridCuentas.SetValue("Update", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCuentas.Select(" CNTAClave <> '" & GridCuentas.GetValue("CNTAClave") & "' and Baja = 0 and Cuenta = '" & CStr(GridCuentas.GetValue("Cuenta")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Cuenta que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridCuentas.SetValue("Cuenta", "ERROR")
                        GridCuentas.SetValue("Update", 0)
                    Else
                        GridCuentas.SetValue("Cuenta", CStr(GridCuentas.GetValue("Cuenta")).Trim)
                        GridCuentas.SetValue("Update", 1)
                    End If
                End If


            Case "Referencia"
                If GridCuentas.GetValue("Referencia").GetType.Name = "DBNull" OrElse CStr(GridCuentas.GetValue("Referencia")).Length = 0 Then
                    GridCuentas.SetValue("Referencia", "ERROR")
                    GridCuentas.SetValue("Update", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCuentas.Select(" CNTAClave <> '" & GridCuentas.GetValue("CNTAClave") & "' and Baja = 0 and Referencia = '" & CStr(GridCuentas.GetValue("Referencia")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Referencia que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridCuentas.SetValue("Referencia", "ERROR")
                        GridCuentas.SetValue("Update", 0)
                    Else
                        GridCuentas.SetValue("Referencia", CStr(GridCuentas.GetValue("Referencia")).Trim)
                        GridCuentas.SetValue("Update", 1)
                    End If
                End If

        

        End Select

    End Sub

    Private Sub GridCuentas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridCuentas.SelectionChanged
        If Not Me.GridCuentas.GetValue(0) Is Nothing Then
            Me.BtnEliminaSub.Enabled = True
            Me.sCountSelected = GridCuentas.GetValue(0)
            sCountRef = GridCuentas.GetValue("Referencia")
        Else
            Me.sCountSelected = ""
            sCountRef = ""
            Me.BtnEliminaSub.Enabled = False
        End If
    End Sub

    
End Class
