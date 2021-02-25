Public Class FrmAperturaLiquid
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
    Friend WithEvents dtpDiaTrabajo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BtnUser As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUsuarioNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClavePdV As System.Windows.Forms.TextBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombrePdV As System.Windows.Forms.TextBox
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnPdV As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaLiquid))
        Me.dtpDiaTrabajo = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BtnUser = New Janus.Windows.EditControls.UIButton()
        Me.TxtUsuarioNombre = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClavePdV = New System.Windows.Forms.TextBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.TxtNombrePdV = New System.Windows.Forms.TextBox()
        Me.BtnPdV = New Janus.Windows.EditControls.UIButton()
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpDiaTrabajo
        '
        Me.dtpDiaTrabajo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDiaTrabajo.Location = New System.Drawing.Point(85, 15)
        Me.dtpDiaTrabajo.Name = "dtpDiaTrabajo"
        Me.dtpDiaTrabajo.Size = New System.Drawing.Size(88, 20)
        Me.dtpDiaTrabajo.TabIndex = 1
        Me.dtpDiaTrabajo.Value = New Date(2012, 4, 13, 12, 36, 31, 0)
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(4, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 14)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "Punto de Venta"
        '
        'BtnUser
        '
        Me.BtnUser.Icon = CType(resources.GetObject("BtnUser.Icon"), System.Drawing.Icon)
        Me.BtnUser.Location = New System.Drawing.Point(481, 76)
        Me.BtnUser.Name = "BtnUser"
        Me.BtnUser.Size = New System.Drawing.Size(26, 24)
        Me.BtnUser.TabIndex = 7
        Me.BtnUser.ToolTipText = "Generar clave automatica"
        Me.BtnUser.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUsuarioNombre
        '
        Me.TxtUsuarioNombre.Location = New System.Drawing.Point(154, 79)
        Me.TxtUsuarioNombre.Name = "TxtUsuarioNombre"
        Me.TxtUsuarioNombre.ReadOnly = True
        Me.TxtUsuarioNombre.Size = New System.Drawing.Size(322, 20)
        Me.TxtUsuarioNombre.TabIndex = 5
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 82)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(76, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Vendedor"
        '
        'TxtClavePdV
        '
        Me.TxtClavePdV.Location = New System.Drawing.Point(92, 47)
        Me.TxtClavePdV.Name = "TxtClavePdV"
        Me.TxtClavePdV.Size = New System.Drawing.Size(57, 20)
        Me.TxtClavePdV.TabIndex = 2
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(4, 18)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(83, 15)
        Me.LblTipo.TabIndex = 61
        Me.LblTipo.Text = "Día de Trabajo"
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(92, 79)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(57, 20)
        Me.TxtUsuario.TabIndex = 3
        '
        'TxtNombrePdV
        '
        Me.TxtNombrePdV.Location = New System.Drawing.Point(153, 47)
        Me.TxtNombrePdV.Name = "TxtNombrePdV"
        Me.TxtNombrePdV.ReadOnly = True
        Me.TxtNombrePdV.Size = New System.Drawing.Size(323, 20)
        Me.TxtNombrePdV.TabIndex = 81
        '
        'BtnPdV
        '
        Me.BtnPdV.Icon = CType(resources.GetObject("BtnPdV.Icon"), System.Drawing.Icon)
        Me.BtnPdV.Location = New System.Drawing.Point(481, 45)
        Me.BtnPdV.Name = "BtnPdV"
        Me.BtnPdV.Size = New System.Drawing.Size(26, 24)
        Me.BtnPdV.TabIndex = 6
        Me.BtnPdV.ToolTipText = "Generar clave automatica"
        Me.BtnPdV.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(416, 109)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 4
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(320, 109)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblFolio
        '
        Me.LblFolio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblFolio.Location = New System.Drawing.Point(5, 11)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(300, 25)
        Me.LblFolio.TabIndex = 78
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblFolio)
        Me.GroupBox1.Location = New System.Drawing.Point(193, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 36)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Folio"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(67, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 18)
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(67, 83)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 17)
        Me.PictureBox2.TabIndex = 87
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmAperturaLiquid
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(511, 153)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnPdV)
        Me.Controls.Add(Me.TxtNombrePdV)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dtpDiaTrabajo)
        Me.Controls.Add(Me.TxtClavePdV)
        Me.Controls.Add(Me.LblTipo)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.TxtUsuarioNombre)
        Me.Controls.Add(Me.BtnUser)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(527, 180)
        Me.Name = "FrmAperturaLiquid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apertura de Liquidación"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private VendedorClave As String
    Private VendedorNombre As String

    Private SUCClave As String
    Private ALMClave As String
    'Private ALMClaveSUC As String

    Private PDVClave As String = ""
    Private LIQClave As String = ""
    Private CAJClave As String = ""

    Private alerta(1) As PictureBox
    Private reloj As parpadea


    Private Sub recuperaPDV(ByVal PDVClave As String, ByVal Dia As DateTime)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_ruta", "@PDVClave", PDVClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            Me.PDVClave = dt.Rows(0)("PDVClave")
            Me.CAJClave = dt.Rows(0)("CAJClave")
            Me.ALMClave = dt.Rows(0)("ALMClave")

            Me.SUCClave = dt.Rows(0)("SUCClave")

            'Genera folio liquidación.
            Dim Clave, Year, DiaYear As String

            Clave = dt.Rows(0)("Referencia").ToString
            Year = Me.dtpDiaTrabajo.Value.Year.ToString
            DiaYear = Me.dtpDiaTrabajo.Value.DayOfYear.ToString

            LblFolio.Text = Clave & "-" & Year & DiaYear


            Me.TxtUsuario.Focus()

        Else
            PDVClave = ""
            LblFolio.Text = ""
            TxtNombrePdV.Text = ""
            TxtClavePdV.Text = ""
            MessageBox.Show("El punto de venta seleccionado no es de tipo Ruta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FrmAperturaLiq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        dtpDiaTrabajo.Value = Today.Date
    End Sub

    Private Sub TxtUsuario_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUsuario.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtUsuario.Text <> "" Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", TxtUsuario.Text.Trim.ToUpper.Replace("'", "''"))
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        VendedorClave = dt.Rows(0)("USRClave")
                        VendedorNombre = dt.Rows(0)("Nombre")
                        TxtUsuarioNombre.Text = VendedorNombre
                        dt.Dispose()
                        BtnAceptar.Focus()
                    Else
                        VendedorClave = ""
                        TxtUsuarioNombre.Text = "¡Clave de Usuario No Existe!"
                        TxtUsuario.Text = ""
                        VendedorClave = ""
                        VendedorNombre = ""
                    End If
                Else
                    TxtUsuarioNombre.Text = "¡Clave de Usuario No Valida!"
                    TxtUsuario.Text = ""
                    VendedorClave = ""
                    VendedorNombre = ""
                End If
            Case Is = Keys.Right
                BtnUser.PerformClick()
        End Select

    End Sub

    Private Sub BtnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUser.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.BusquedaInicial = True
        a.Busqueda = TxtUsuario.Text
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                TxtUsuario.Text = a.Descripcion2
                VendedorClave = a.valor
                VendedorNombre = a.Descripcion
                TxtUsuarioNombre.Text = VendedorNombre
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnPdV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPdV.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_pdv"
        a.TablaCmb = "PuntodeVenta"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.BusquedaInicial = True
        a.Busqueda = TxtClavePdV.Text
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                TxtClavePdV.Text = a.Descripcion
                TxtNombrePdV.Text = a.Descripcion2
                recuperaPDV(a.valor, dtpDiaTrabajo.Value)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtClavePdV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClavePdV.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtClavePdV.Text <> "" Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_search_pdv", "@Campo", 1, "@Busqueda", TxtClavePdV.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        TxtNombrePdV.Text = dt.Rows(0)("Descripción")
                        recuperaPDV(dt.Rows(0)("ID"), dtpDiaTrabajo.Value)
                        dt.Dispose()
                    Else
                        TxtNombrePdV.Text = "¡Clave de Ruta No Existe!"
                    End If
                Else
                    TxtNombrePdV.Text = "¡Clave de Ruta No Valida!"
                End If
            Case Is = Keys.Right
                BtnPdV.PerformClick()
        End Select

    End Sub

    Private Sub dtpDiaTrabajo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDiaTrabajo.ValueChanged
        'Verifica si hay ruta seleccionada, de ser así recalcular folio y validar que no haya liquidacion para el dia seleccionado.
        If Me.PDVClave <> "" Then
            recuperaPDV(PDVClave, dtpDiaTrabajo.Value)
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If PDVClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If VendedorClave = "" Then
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

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then

            'Verifica si ya existe liquidación para el punto de venta y dia de trabajo seleccionado

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_liquidacion", "@Folio", LblFolio.Text, "@Tipo", 1)
            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                Beep()
                MessageBox.Show("¡El Folio de Liquidación que intenta crear ya existe para el punto de venta y dia de trabajo seleccionados!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            dt.Dispose()

            'Verifica que la fecha del dia de trabajo seleccionado no se encuentre entre alguno de los rangos seleccionados, para el punto de venta.
            dt = ModPOS.Recupera_Tabla("sp_liquidacion_abierta", "@PDVClave", PDVClave)
            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                Beep()
                MessageBox.Show("¡No es posible crear una liquidación ya que se encuentra una liquidación Abierta para el Punto de Venta seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            dt.Dispose()

            'crear registro de liquidación

            LIQClave = ModPOS.obtenerLlave

            ModPOS.Ejecuta("sp_crear_liquidacion", _
                           "@LIQClave", LIQClave, _
                           "@PDVClave", PDVClave, _
                           "@CAJClave", CAJClave, _
                           "@SUCClave", SUCClave, _
                           "@ALMClave", ALMClave, _
                           "@USRClave", VendedorClave, _
                           "@Folio", LblFolio.Text, _
                           "@DiaTrabajo", dtpDiaTrabajo.Value, _
                           "@Usuario", ModPOS.UsuarioActual)

            'crear historico de inventario actual del dia de trabajo seleccionado.

            ModPOS.Ejecuta("sp_crear_liqHist", _
                           "@LIQClave", LIQClave, _
                           "@ALMClave", ALMClave)


            'Actualiza MtoLiquidaciones

            If Not ModPOS.MtoLiquid Is Nothing Then

                If Not ModPOS.MtoLiquid.CmbSucursal.SelectedValue Is Nothing Then
                    Cursor.Current = Cursors.WaitCursor
                    ModPOS.ActualizaGrid(False, ModPOS.MtoLiquid.GridLiquidaciones, "sp_muestra_liquidaciones", "@Sucursal", ModPOS.MtoLiquid.CmbSucursal.SelectedValue, "@DiaTrabajo", ModPOS.MtoLiquid.dtpDiaTrabajo.Value)
                    ModPOS.MtoLiquid.GridLiquidaciones.RootTable.Columns("LIQClave").Visible = False
                    Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                    fc = New Janus.Windows.GridEX.GridEXFormatCondition(ModPOS.MtoLiquid.GridLiquidaciones.RootTable.Columns("Fase"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cerrada")
                    fc.FormatStyle.ForeColor = System.Drawing.Color.Gray
                    ModPOS.MtoLiquid.GridLiquidaciones.RootTable.FormatConditions.Add(fc)
                    Cursor.Current = Cursors.Default
                End If
            End If

            If ModPOS.Liquid Is Nothing Then

                ModPOS.Liquid = New FrmLiquid
                With ModPOS.Liquid
                    .LIQClave = LIQClave
                    .DiaTrabajo = dtpDiaTrabajo.Value
                    .PDVClave = PDVClave
                    .CAJClave = CAJClave
                    .ALMClave = ALMClave
                    .SUCClave = SUCClave
                    .Folio = LblFolio.Text
                    .ClavePDV = Me.TxtClavePdV.Text
                    .NombrePDV = Me.TxtNombrePdV.Text
                    .ClaveVEN = Me.TxtUsuario.Text
                    .NombreVEN = Me.TxtUsuarioNombre.Text
                    .VendedorClave = Me.VendedorClave
                    .LblFase.Text = "Abierta"
                    .Fase = 1
                End With
            End If

            ModPOS.Liquid.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Liquid.Show()
            ModPOS.Liquid.BringToFront()


            TxtUsuarioNombre.Text = ""
            TxtUsuario.Text = ""
            VendedorClave = ""
            VendedorNombre = ""
            PDVClave = ""
            LblFolio.Text = ""
            TxtNombrePdV.Text = ""
            TxtClavePdV.Text = ""
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
