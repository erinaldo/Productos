Public Class MeFiltroCobra
    Inherits System.Windows.Forms.Form

    Private Dias As Integer
    Private USRClave As String = ""
    Private CTEClave As String = ""
    Private ZonaReparto As Integer = -1
    Private Sucursal As String
    Public Titulo As String
    Private bError As Boolean = False
    ' Public Reporte As String

    Private alerta(4) As PictureBox

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnUsuario As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents chkUsuario As Selling.ChkStatus
    Friend WithEvents ChkZona As Selling.ChkStatus
    Friend WithEvents lblZona As System.Windows.Forms.Label
    Friend WithEvents btnZona As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtZona As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents chkCliente As Selling.ChkStatus

    Private reloj As parpadea

    Public ReadOnly Property SucursalOrigen() As String
        Get
            SucursalOrigen = Sucursal
        End Get
    End Property

    Public ReadOnly Property VencimientoDias() As Integer
        Get
            VencimientoDias = Dias
        End Get
    End Property

    Public ReadOnly Property Usuario() As String
        Get
            Usuario = USRClave
        End Get
    End Property


    Public ReadOnly Property Cliente() As String
        Get
            Cliente = CTEClave
        End Get
    End Property


    Public ReadOnly Property Zona() As Integer
        Get
            Zona = ZonaReparto
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents GrpVencimiento As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroCobra))
        Me.GrpVencimiento = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.btnUsuario = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblZona = New System.Windows.Forms.Label()
        Me.btnZona = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtZona = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.chkCliente = New Selling.ChkStatus(Me.components)
        Me.ChkZona = New Selling.ChkStatus(Me.components)
        Me.chkUsuario = New Selling.ChkStatus(Me.components)
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.GrpVencimiento.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpVencimiento
        '
        Me.GrpVencimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpVencimiento.Controls.Add(Me.PictureBox2)
        Me.GrpVencimiento.Controls.Add(Me.TxtDias)
        Me.GrpVencimiento.Controls.Add(Me.Label1)
        Me.GrpVencimiento.Location = New System.Drawing.Point(25, 205)
        Me.GrpVencimiento.Name = "GrpVencimiento"
        Me.GrpVencimiento.Size = New System.Drawing.Size(496, 44)
        Me.GrpVencimiento.TabIndex = 2
        Me.GrpVencimiento.TabStop = False
        Me.GrpVencimiento.Text = "Vencimiento a:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(353, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 19)
        Me.PictureBox2.TabIndex = 74
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtDias
        '
        Me.TxtDias.DecimalDigits = 0
        Me.TxtDias.Location = New System.Drawing.Point(170, 16)
        Me.TxtDias.Name = "TxtDias"
        Me.TxtDias.Size = New System.Drawing.Size(102, 20)
        Me.TxtDias.TabIndex = 72
        Me.TxtDias.Text = "0"
        Me.TxtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtDias.Value = 0
        Me.TxtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(142, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Dias"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(431, 255)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(335, 255)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(7, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Sucursal"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(499, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 17)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(10, 130)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(503, 15)
        Me.lblUsuario.TabIndex = 194
        Me.lblUsuario.Visible = False
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(128, 104)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(140, 21)
        Me.txtUsuario.TabIndex = 192
        Me.txtUsuario.Visible = False
        '
        'btnUsuario
        '
        Me.btnUsuario.Enabled = False
        Me.btnUsuario.Image = CType(resources.GetObject("btnUsuario.Image"), System.Drawing.Image)
        Me.btnUsuario.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnUsuario.Location = New System.Drawing.Point(274, 103)
        Me.btnUsuario.Name = "btnUsuario"
        Me.btnUsuario.Size = New System.Drawing.Size(35, 22)
        Me.btnUsuario.TabIndex = 193
        Me.btnUsuario.ToolTipText = "Busqueda de Operador o Chofer"
        Me.btnUsuario.Visible = False
        Me.btnUsuario.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(315, 103)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox3.TabIndex = 191
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'lblZona
        '
        Me.lblZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZona.Location = New System.Drawing.Point(10, 186)
        Me.lblZona.Name = "lblZona"
        Me.lblZona.Size = New System.Drawing.Size(503, 15)
        Me.lblZona.TabIndex = 197
        Me.lblZona.Visible = False
        '
        'btnZona
        '
        Me.btnZona.Enabled = False
        Me.btnZona.Image = CType(resources.GetObject("btnZona.Image"), System.Drawing.Image)
        Me.btnZona.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnZona.Location = New System.Drawing.Point(274, 159)
        Me.btnZona.Name = "btnZona"
        Me.btnZona.Size = New System.Drawing.Size(35, 22)
        Me.btnZona.TabIndex = 200
        Me.btnZona.ToolTipText = "Busqueda de Operador o Chofer"
        Me.btnZona.Visible = False
        Me.btnZona.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(315, 159)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox4.TabIndex = 198
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'txtZona
        '
        Me.txtZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtZona.Location = New System.Drawing.Point(128, 160)
        Me.txtZona.Name = "txtZona"
        Me.txtZona.ReadOnly = True
        Me.txtZona.Size = New System.Drawing.Size(140, 21)
        Me.txtZona.TabIndex = 199
        Me.txtZona.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(10, 75)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(503, 15)
        Me.lblCliente.TabIndex = 204
        Me.lblCliente.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtCliente.Location = New System.Drawing.Point(128, 49)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(140, 21)
        Me.txtCliente.TabIndex = 202
        Me.txtCliente.Visible = False
        '
        'btnCliente
        '
        Me.btnCliente.Enabled = False
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCliente.Location = New System.Drawing.Point(274, 48)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(35, 22)
        Me.btnCliente.TabIndex = 203
        Me.btnCliente.ToolTipText = "Busqueda de Operador o Chofer"
        Me.btnCliente.Visible = False
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(315, 48)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox5.TabIndex = 201
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'chkCliente
        '
        Me.chkCliente.Location = New System.Drawing.Point(10, 49)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(73, 21)
        Me.chkCliente.TabIndex = 205
        Me.chkCliente.Text = "Cliente"
        Me.chkCliente.Visible = False
        '
        'ChkZona
        '
        Me.ChkZona.Location = New System.Drawing.Point(10, 162)
        Me.ChkZona.Name = "ChkZona"
        Me.ChkZona.Size = New System.Drawing.Size(115, 21)
        Me.ChkZona.TabIndex = 196
        Me.ChkZona.Text = "Zona de Reparto"
        Me.ChkZona.Visible = False
        '
        'chkUsuario
        '
        Me.chkUsuario.Location = New System.Drawing.Point(10, 104)
        Me.chkUsuario.Name = "chkUsuario"
        Me.chkUsuario.Size = New System.Drawing.Size(73, 21)
        Me.chkUsuario.TabIndex = 195
        Me.chkUsuario.Text = "Vendedor"
        Me.chkUsuario.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(84, 13)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(409, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'MeFiltroCobra
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(525, 296)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btnCliente)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.chkCliente)
        Me.Controls.Add(Me.txtZona)
        Me.Controls.Add(Me.btnZona)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.lblZona)
        Me.Controls.Add(Me.ChkZona)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btnUsuario)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.chkUsuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GrpVencimiento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 157)
        Me.Name = "MeFiltroCobra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpVencimiento.ResumeLayout(False)
        Me.GrpVencimiento.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub MeFiltroCobra_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtDias.Text = "" OrElse CInt(TxtDias.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If chkCliente.Checked = True Then
            If CTEClave = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(4))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If chkUsuario.Checked = True Then
            If USRClave = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If


        If ChkZona.Checked = True Then
            If ZonaReparto = -1 Then
                i += 1
                reloj = New parpadea(Me.alerta(3))
                reloj.Enabled = True
                reloj.Start()
            End If
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then

            If chkUsuario.Checked = False Then
                USRClave = ""
            End If

            If ChkZona.Checked = False Then
                ZonaReparto = -1
            End If

            If chkCliente.Checked = False Then
                CTEClave = ""
            End If

            Sucursal = CmbSucursal.SelectedValue

            Dias = CInt(TxtDias.Text)
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        Me.Text = Titulo


    End Sub


    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsuario.CheckedChanged
        If chkUsuario.Checked Then
            btnUsuario.Enabled = True
        Else
            btnUsuario.Enabled = False
        End If
    End Sub

    Private Sub btnUsuario_Click(sender As Object, e As EventArgs) Handles btnUsuario.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.BusquedaInicial = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                txtUsuario.Text = a.Descripcion2
                lblUsuario.Text = a.Descripcion
                USRClave = a.valor
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub btnZona_Click(sender As Object, e As EventArgs) Handles btnZona.Click
        Dim a As New FrmConsulta
        a.Intro = False
        a.Campo = "Valor"
        a.Campo2 = "Descripcion"
        a.AutoSizeForm = False
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_filtra_ValorRef", "@Tabla", "Cliente", "@Campo", "ZonaReparto")
        a.GridConsultaGen.RootTable.Columns("Valor").Visible = False
        a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ID <> "" Then
                ZonaReparto = a.ID
                txtZona.Text = ZonaReparto
                lblZona.Text = a.ID2
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub ChkZona_CheckedChanged(sender As Object, e As EventArgs) Handles ChkZona.CheckedChanged
        If ChkZona.Checked Then
            btnZona.Enabled = True

        Else
            btnZona.Enabled = False
        End If
    End Sub


    Private Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            TxtCliente.Text = dt.Rows(0)("Clave")
            lblCliente.Text = dt.Rows(0)("RazonSocial")
            dt.Dispose()
        Else
            CTEClave = ""
            TxtCliente.Text = ""
            lblCliente.Text = ""
            MessageBox.Show("La información del empleado no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then

                CargaDatosCliente(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub chkCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkCliente.CheckedChanged
        If chkCliente.Checked Then
            btnCliente.Enabled = True
            txtCliente.Enabled = True
        Else
            btnCliente.Enabled = False
            txtCliente.Enabled = True
        End If
    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtCliente.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", txtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        CargaDatosCliente(dtCliente.Rows(0)("CTEClave"))
                        dtCliente.Dispose()
                    End If
                Else
                    CTEClave = ""
                    txtCliente.Text = ""
                    lblCliente.Text = ""

                    MessageBox.Show("No se encontraron coincidencias para el Número de Empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Case Is = Keys.Right
                btnCliente.PerformClick()
        End Select
    End Sub

    
End Class
