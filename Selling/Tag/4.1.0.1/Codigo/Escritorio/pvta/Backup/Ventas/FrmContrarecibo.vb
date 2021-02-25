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
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents GrpModificador As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaFactura As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuario As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContrarecibo))
        Me.GrpModificador = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbUsuario = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnBuscaFactura = New Janus.Windows.EditControls.UIButton
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtFactura = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpModificador.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpModificador
        '
        Me.GrpModificador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpModificador.Controls.Add(Me.PictureBox2)
        Me.GrpModificador.Controls.Add(Me.PictureBox1)
        Me.GrpModificador.Controls.Add(Me.cmbUsuario)
        Me.GrpModificador.Controls.Add(Me.Label1)
        Me.GrpModificador.Controls.Add(Me.BtnBuscaFactura)
        Me.GrpModificador.Controls.Add(Me.TxtCompany)
        Me.GrpModificador.Controls.Add(Me.Label16)
        Me.GrpModificador.Controls.Add(Me.ChkEstado)
        Me.GrpModificador.Controls.Add(Me.TxtFactura)
        Me.GrpModificador.Controls.Add(Me.LblNombre)
        Me.GrpModificador.Controls.Add(Me.TxtReferencia)
        Me.GrpModificador.Controls.Add(Me.LblClave)
        Me.GrpModificador.Location = New System.Drawing.Point(5, 7)
        Me.GrpModificador.Name = "GrpModificador"
        Me.GrpModificador.Size = New System.Drawing.Size(427, 163)
        Me.GrpModificador.TabIndex = 1
        Me.GrpModificador.TabStop = False
        Me.GrpModificador.Text = "Gestión de Contrarecibo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(80, 87)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 141
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(80, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 140
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbUsuario
        '
        Me.cmbUsuario.Location = New System.Drawing.Point(98, 45)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(227, 21)
        Me.cmbUsuario.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(13, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Referencia"
        '
        'BtnBuscaFactura
        '
        Me.BtnBuscaFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaFactura.Image = CType(resources.GetObject("BtnBuscaFactura.Image"), System.Drawing.Image)
        Me.BtnBuscaFactura.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaFactura.Location = New System.Drawing.Point(291, 75)
        Me.BtnBuscaFactura.Name = "BtnBuscaFactura"
        Me.BtnBuscaFactura.Size = New System.Drawing.Size(36, 22)
        Me.BtnBuscaFactura.TabIndex = 5
        Me.BtnBuscaFactura.ToolTipText = "Busqueda de Factura"
        Me.BtnBuscaFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(98, 14)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(316, 20)
        Me.TxtCompany.TabIndex = 137
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(13, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 15)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Compañia"
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Location = New System.Drawing.Point(98, 106)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(92, 23)
        Me.ChkEstado.TabIndex = 2
        Me.ChkEstado.Text = "Entregado"
        '
        'TxtFactura
        '
        Me.TxtFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFactura.Location = New System.Drawing.Point(98, 76)
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(188, 20)
        Me.TxtFactura.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblNombre.Location = New System.Drawing.Point(13, 79)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Folio Factura"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtReferencia.Location = New System.Drawing.Point(98, 130)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(188, 20)
        Me.TxtReferencia.TabIndex = 3
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblClave.Location = New System.Drawing.Point(13, 43)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Responsable"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(342, 176)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(246, 176)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmContrarecibo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(439, 214)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpModificador)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(455, 253)
        Me.MinimumSize = New System.Drawing.Size(455, 253)
        Me.Name = "FrmContrarecibo"
        Me.Text = "Contrarecibo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpModificador.ResumeLayout(False)
        Me.GrpModificador.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public FACClave As String

    Private Estado As Integer = 1
    Private Responsable As String
    Private Referencia As String
    Private Folio As String

    Private sClave As String = ""
    Private iBaja As Integer


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

        If Me.TxtFactura.Text = "" Then
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
 
 
    Private Sub Reinicializa()

        Referencia = ""
        Folio = ""
        Estado = 1

        TxtReferencia.Text = ""
        TxtFactura.Text = ""
        ChkEstado.Estado = Estado



    End Sub

   


#End Region


    Private Sub FrmContrarecibo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2


        Cursor.Current = Cursors.WaitCursor

        Me.TxtCompany.Text = ModPOS.CompanyName


        With Me.cmbUsuario
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_usuario"
            .llenar()
        End With


        If Padre = "Agregar" Then
            Me.ChkEstado.Enabled = False
            Me.TxtReferencia.Enabled = False
        Else
            CargaDatosFactura(FACClave, 1)
            TxtFactura.Enabled = False
            BtnBuscaFactura.Enabled = False

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_contrarecibo", "@FACClave", FACClave)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Referencia = IIf(dt.Rows(0)("Referencia").GetType.Name = "DBNull", "", dt.Rows(0)("Referencia"))
                Responsable = dt.Rows(0)("USRClave")
                Estado = dt.Rows(0)("TipoEstado")
                Me.TxtReferencia.Text = Referencia
                ChkEstado.Estado = Estado
                cmbUsuario.SelectedValue = Responsable
            End If
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscaFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaFactura.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_factura"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.CargaDatosFactura(a.valor, 1)
            TxtFactura.Text = a.Descripcion
        End If
        a.Dispose()
    End Sub

    Private Sub TxtFactura_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFactura.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtFactura.Text = vbNullString Then
                CargaDatosFactura(TxtFactura.Text.ToUpper.Trim.Replace("'", "''"), 0)
            End If
        End If
    End Sub

    Private Sub CargaDatosFactura(ByVal Folio As String, ByVal esClave As Integer)
        'Valida que el campo Ticket no se encuentre vacio
        Dim dtFactura As DataTable = ModPOS.SiExisteRecupera("sp_busca_factura", "@Folio", Folio, "@Clave", esClave, "@COMClave", ModPOS.CompanyActual)
        If Not dtFactura Is Nothing AndAlso dtFactura.Rows.Count > 0 Then
            Folio = CStr(dtFactura.Rows(0)("Serie")) & CStr(dtFactura.Rows(0)("Folio"))
            FACClave = dtFactura.Rows(0)("FACClave")
            TxtFactura.Text = Folio
            dtFactura.Dispose()

            If Padre = "Agregar" Then
                Me.BtnGuardar.Focus()
            End If
        Else
            MessageBox.Show("No se encontro documento o se encuentra cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FrmContrarecibo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCXC Is Nothing Then
            If Not ModPOS.MtoCXC Is Nothing AndAlso Padre = "Agregar" Then
                ModPOS.MtoCXC.actualizaContrarecibos()
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    If FACClave = "" Then
                        MessageBox.Show("Debe especificar una factura, escibiendo el folio y presionando la tecla ENT o usando la opción de busqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    'Valida si ya existe la factura en el control de contrarecibos
                    Dim dt As DataTable

                    dt = ModPOS.Recupera_Tabla("sp_recupera_contrarecibo", "@FACClave", FACClave)
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        MessageBox.Show("La factura " & TxtFactura.Text & ", ya fue asignada para contrarecibo el día " & CStr(dt.Rows(0)("Asignacion")), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    Responsable = cmbUsuario.SelectedValue

                    ModPOS.Ejecuta("sp_agrega_contrarecibo", "@FACClave", FACClave, "@Responsable", Responsable, "@COMClave", ModPOS.CompanyActual, "@Usuario", ModPOS.UsuarioActual)

                    TxtFactura.Text = ""
                    FACClave = ""
                    TxtFactura.Focus()

                Case "Modificar"
                    If Not (Responsable = cmbUsuario.SelectedValue AndAlso _
                        Estado = Me.ChkEstado.GetEstado AndAlso _
                        Referencia = Me.TxtReferencia.Text) Then

                        Responsable = cmbUsuario.SelectedValue
                        Me.Estado = ChkEstado.GetEstado
                        Referencia = TxtReferencia.Text

                        ModPOS.Ejecuta("sp_actualiza_contrarecibo", "@FACClave", FACClave, "@Responsable", Responsable, "@Estado", Estado, "@Referencia", Referencia, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.MtoCXC.actualizaContrarecibos()

                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub
End Class
