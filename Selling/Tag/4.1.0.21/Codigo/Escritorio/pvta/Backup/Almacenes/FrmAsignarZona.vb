Public Class FrmAsginarZona
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
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents LstSinAsignar As System.Windows.Forms.ListBox
    Friend WithEvents GrpAsignados As System.Windows.Forms.GroupBox
    Friend WithEvents LstAsignados As System.Windows.Forms.ListBox
    Friend WithEvents cmdTodosIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdTodosDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblZona As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkNivel As System.Windows.Forms.CheckBox
    Friend WithEvents cmbNiveles As Selling.StoreCombo
    Friend WithEvents cmbZonas As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsginarZona))
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox
        Me.ChkNivel = New System.Windows.Forms.CheckBox
        Me.LstSinAsignar = New System.Windows.Forms.ListBox
        Me.cmbNiveles = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpAsignados = New System.Windows.Forms.GroupBox
        Me.LblZona = New System.Windows.Forms.Label
        Me.LstAsignados = New System.Windows.Forms.ListBox
        Me.cmbZonas = New Selling.StoreCombo
        Me.cmdTodosIzq = New Janus.Windows.EditControls.UIButton
        Me.cmdUnoIzq = New Janus.Windows.EditControls.UIButton
        Me.cmdTodosDer = New Janus.Windows.EditControls.UIButton
        Me.cmdUnoDer = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.GrpSinAsignar.SuspendLayout()
        Me.GrpAsignados.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Controls.Add(Me.ChkNivel)
        Me.GrpSinAsignar.Controls.Add(Me.LstSinAsignar)
        Me.GrpSinAsignar.Controls.Add(Me.cmbNiveles)
        Me.GrpSinAsignar.Controls.Add(Me.Label1)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(7, 15)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(220, 342)
        Me.GrpSinAsignar.TabIndex = 12
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Huecos Disponibles"
        '
        'ChkNivel
        '
        Me.ChkNivel.Location = New System.Drawing.Point(12, 22)
        Me.ChkNivel.Name = "ChkNivel"
        Me.ChkNivel.Size = New System.Drawing.Size(26, 23)
        Me.ChkNivel.TabIndex = 38
        '
        'LstSinAsignar
        '
        Me.LstSinAsignar.Location = New System.Drawing.Point(7, 52)
        Me.LstSinAsignar.Name = "LstSinAsignar"
        Me.LstSinAsignar.ScrollAlwaysVisible = True
        Me.LstSinAsignar.Size = New System.Drawing.Size(200, 264)
        Me.LstSinAsignar.TabIndex = 10
        '
        'cmbNiveles
        '
        Me.cmbNiveles.Location = New System.Drawing.Point(86, 22)
        Me.cmbNiveles.Name = "cmbNiveles"
        Me.cmbNiveles.Size = New System.Drawing.Size(120, 21)
        Me.cmbNiveles.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(42, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Nivel"
        '
        'GrpAsignados
        '
        Me.GrpAsignados.Controls.Add(Me.LblZona)
        Me.GrpAsignados.Controls.Add(Me.LstAsignados)
        Me.GrpAsignados.Controls.Add(Me.cmbZonas)
        Me.GrpAsignados.Location = New System.Drawing.Point(273, 15)
        Me.GrpAsignados.Name = "GrpAsignados"
        Me.GrpAsignados.Size = New System.Drawing.Size(214, 342)
        Me.GrpAsignados.TabIndex = 17
        Me.GrpAsignados.TabStop = False
        Me.GrpAsignados.Text = "Huecos Asignados"
        '
        'LblZona
        '
        Me.LblZona.Location = New System.Drawing.Point(10, 28)
        Me.LblZona.Name = "LblZona"
        Me.LblZona.Size = New System.Drawing.Size(35, 15)
        Me.LblZona.TabIndex = 36
        Me.LblZona.Text = "Zona"
        '
        'LstAsignados
        '
        Me.LstAsignados.Location = New System.Drawing.Point(7, 52)
        Me.LstAsignados.Name = "LstAsignados"
        Me.LstAsignados.ScrollAlwaysVisible = True
        Me.LstAsignados.Size = New System.Drawing.Size(200, 264)
        Me.LstAsignados.TabIndex = 11
        '
        'cmbZonas
        '
        Me.cmbZonas.Location = New System.Drawing.Point(65, 22)
        Me.cmbZonas.Name = "cmbZonas"
        Me.cmbZonas.Size = New System.Drawing.Size(140, 21)
        Me.cmbZonas.TabIndex = 21
        '
        'cmdTodosIzq
        '
        Me.cmdTodosIzq.Location = New System.Drawing.Point(235, 157)
        Me.cmdTodosIzq.Name = "cmdTodosIzq"
        Me.cmdTodosIzq.Size = New System.Drawing.Size(28, 28)
        Me.cmdTodosIzq.TabIndex = 16
        Me.cmdTodosIzq.Text = "<<"
        Me.cmdTodosIzq.ToolTipText = "Remover todos los huecos asignados"
        Me.cmdTodosIzq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdUnoIzq
        '
        Me.cmdUnoIzq.Location = New System.Drawing.Point(235, 127)
        Me.cmdUnoIzq.Name = "cmdUnoIzq"
        Me.cmdUnoIzq.Size = New System.Drawing.Size(28, 28)
        Me.cmdUnoIzq.TabIndex = 15
        Me.cmdUnoIzq.Text = "<"
        Me.cmdUnoIzq.ToolTipText = "Remover el hueco seleccionado de la asignación"
        Me.cmdUnoIzq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdTodosDer
        '
        Me.cmdTodosDer.Location = New System.Drawing.Point(235, 98)
        Me.cmdTodosDer.Name = "cmdTodosDer"
        Me.cmdTodosDer.Size = New System.Drawing.Size(28, 28)
        Me.cmdTodosDer.TabIndex = 14
        Me.cmdTodosDer.Text = ">>"
        Me.cmdTodosDer.ToolTipText = "Asignar todos los huecos"
        Me.cmdTodosDer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdUnoDer
        '
        Me.cmdUnoDer.Location = New System.Drawing.Point(235, 68)
        Me.cmdUnoDer.Name = "cmdUnoDer"
        Me.cmdUnoDer.Size = New System.Drawing.Size(28, 28)
        Me.cmdUnoDer.TabIndex = 13
        Me.cmdUnoDer.Text = ">"
        Me.cmdUnoDer.ToolTipText = "Asignar el hueco seleccionado"
        Me.cmdUnoDer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(291, 365)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 19
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(396, 364)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 18
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAsginarZona
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(494, 407)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.GrpAsignados)
        Me.Controls.Add(Me.cmdTodosIzq)
        Me.Controls.Add(Me.cmdUnoIzq)
        Me.Controls.Add(Me.cmdTodosDer)
        Me.Controls.Add(Me.cmdUnoDer)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsginarZona"
        Me.Text = "Asignación de Zonas"
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpAsignados.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Estructura As String = ""
    Private Inicializado As Boolean = False

    Private dtSinAsignar As DataTable
    Private dtAsignados As DataTable

    Private Sub Selecciones(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdUnoDer.Click, _
        cmdTodosDer.Click, cmdUnoIzq.Click, cmdTodosIzq.Click, _
        LstSinAsignar.DoubleClick, LstAsignados.DoubleClick
        Dim i As Integer
        Dim fila As DataRowView

        If sender Is LstSinAsignar Or sender Is cmdUnoDer Then
            If LstSinAsignar.SelectedIndex <> -1 Then
                fila = LstSinAsignar.SelectedItem
                Me.dtAsignados.ImportRow(fila.Row)
                Me.dtSinAsignar.Rows.Remove(fila.Row)
            End If
            LstSinAsignar.ClearSelected()

        ElseIf sender Is cmdTodosDer Then
            For i = 0 To LstSinAsignar.Items.Count - 1
                fila = LstSinAsignar.Items.Item(i)
                Me.dtAsignados.ImportRow(fila.Row)
            Next
            Me.dtSinAsignar.Rows.Clear()
            LstAsignados.ClearSelected()

        ElseIf sender Is LstAsignados Or sender Is cmdUnoIzq Then
            If LstAsignados.SelectedIndex <> -1 Then
                fila = LstAsignados.SelectedItem
                Me.dtSinAsignar.ImportRow(fila.Row)
                Me.dtAsignados.Rows.Remove(fila.Row)
            End If

            LstSinAsignar.ClearSelected()

        ElseIf sender Is cmdTodosIzq Then
            For i = 0 To LstAsignados.Items.Count - 1
                fila = LstAsignados.Items.Item(i)
                Me.dtSinAsignar.ImportRow(fila.Row)
            Next
            dtAsignados.Rows.Clear()
            LstSinAsignar.ClearSelected()

        End If
    End Sub

    Private Sub FrmAsginarUbicacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPos.AsignarZona.Dispose()
        ModPos.AsignarZona = Nothing
    End Sub

    Private Sub FrmAsginarUbicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim Cnx As String

        Cnx = ModPos.BDConexion


        With Me.cmbZonas
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Hueco"
            .NombreParametro2 = "campo"
            .Parametro2 = "Zona"
            .llenar()
        End With

        With Me.cmbNiveles
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_Nivel"
            .NombreParametro1 = "Estructura"
            .Parametro1 = Me.Estructura
            .llenar()
        End With

        Me.cmbNiveles.Enabled = False


        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_HuecosAsignados", "@Estructura", Me.Estructura, "@Zona", Me.cmbZonas.SelectedValue)

        Me.LstAsignados.DataSource = dtAsignados
        Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()

        dtSinAsignar = ModPOS.Recupera_Tabla("sp_filtra_HuecosSinAsignar", "@Estructura", Me.Estructura, "@Nivel", "0")

        Me.LstSinAsignar.DataSource = dtSinAsignar
        Me.LstSinAsignar.DisplayMember = dtSinAsignar.Columns(1).ColumnName
        Me.LstSinAsignar.ValueMember = dtSinAsignar.Columns(0).ColumnName
        Me.LstSinAsignar.ClearSelected()

        Me.Inicializado = True
    End Sub

    Private Sub ChkNivel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkNivel.CheckedChanged
        If Me.ChkNivel.Checked = False Then
            Me.cmbNiveles.Enabled = False
            dtSinAsignar = ModPOS.Recupera_Tabla("sp_filtra_HuecosSinAsignar", "@Estructura", Me.Estructura, "@Nivel", "0")
            Me.LstSinAsignar.DataSource = dtSinAsignar
            Me.LstSinAsignar.DisplayMember = dtSinAsignar.Columns(1).ColumnName
            Me.LstSinAsignar.ValueMember = dtSinAsignar.Columns(0).ColumnName
            Me.LstSinAsignar.ClearSelected()


        Else
            Me.cmbNiveles.Enabled = True

            dtSinAsignar = ModPOS.Recupera_Tabla("sp_filtra_HuecosSinAsignar", "@Estructura", Me.Estructura, "@Nivel", CStr(Me.cmbNiveles.SelectedValue))
            Me.LstSinAsignar.DataSource = dtSinAsignar
            Me.LstSinAsignar.DisplayMember = dtSinAsignar.Columns(1).ColumnName
            Me.LstSinAsignar.ValueMember = dtSinAsignar.Columns(0).ColumnName
            Me.LstSinAsignar.ClearSelected()

        End If
    End Sub

    Private Sub cmbNiveles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNiveles.SelectedIndexChanged
        If Inicializado Then
            dtSinAsignar = ModPOS.Recupera_Tabla("sp_filtra_HuecosSinAsignar", "@Estructura", Me.Estructura, "@Nivel", CStr(Me.cmbNiveles.SelectedValue))
            Me.LstSinAsignar.DataSource = dtSinAsignar
            Me.LstSinAsignar.DisplayMember = dtSinAsignar.Columns(1).ColumnName
            Me.LstSinAsignar.ValueMember = dtSinAsignar.Columns(0).ColumnName
            Me.LstSinAsignar.ClearSelected()
        End If
    End Sub

    Private Sub cmbZonas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbZonas.SelectedIndexChanged
        If Inicializado Then
            dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_HuecosAsignados", "@Estructura", Me.Estructura, "@Zona", Me.cmbZonas.SelectedValue)

            Me.LstAsignados.DataSource = dtAsignados
            Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
            Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim i As Integer

        If Me.dtAsignados.Rows.Count > 0 Then
            For i = 0 To Me.dtAsignados.Rows.Count - 1

                ModPos.Update_Zona(Me.Estructura, dtAsignados.Rows(i).ItemArray(0), CStr(cmbZonas.SelectedValue))
            Next
        End If

        If Me.dtSinAsignar.Rows.Count > 0 Then
            For i = 0 To Me.dtAsignados.Rows.Count - 1

                ModPOS.Update_Zona(Me.Estructura, dtSinAsignar.Rows(i).ItemArray(0), 0)
            Next
        End If


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class
