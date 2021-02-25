Public Class MeFiltroCteTodos
    Inherits System.Windows.Forms.Form

    Private CAJClave As String = ""
    Private CTEClave As String = ""
    Private Todos As Integer
    Private FechaIni As String
    Private FechaFin As String
    Private bError As Boolean = False
    Private SUCClave As String
    Private bLoad As Boolean = False
    Private alerta(4) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents lblCombo As System.Windows.Forms.Label
    Friend WithEvents ChkCaja As Selling.ChkStatus
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox

    Private reloj As parpadea

    Public ReadOnly Property FechaInicio() As String
        Get
            FechaInicio = FechaIni
        End Get
    End Property

    Public ReadOnly Property FechaFinal() As String
        Get
            FechaFinal = FechaFin
        End Get
    End Property


    Public ReadOnly Property Cliente() As String
        Get
            Cliente = CTEClave
        End Get
    End Property


    Public ReadOnly Property Caja() As String
        Get
            Caja = CAJClave
        End Get
    End Property

    Public ReadOnly Property TodosClientes() As Integer
        Get
            TodosClientes = Todos
        End Get
    End Property

    Public ReadOnly Property Sucursal() As String
        Get
            Sucursal = SUCClave
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroCteTodos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.lblCombo = New System.Windows.Forms.Label()
        Me.ChkCaja = New Selling.ChkStatus(Me.components)
        Me.CmbCaja = New Selling.StoreCombo()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.CmbFechaFin)
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(513, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(238, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(18, 20)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(278, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "AL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(69, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "DEL"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(454, 16)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(330, 15)
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Size = New System.Drawing.Size(119, 20)
        Me.CmbFechaFin.TabIndex = 69
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(107, 15)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 20)
        Me.cmbFechaInicio.TabIndex = 68
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(425, 164)
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
        Me.BtnCancel.Location = New System.Drawing.Point(329, 164)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(163, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox1.TabIndex = 175
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(116, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 15)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "Cliente"
        '
        'lblCliente
        '
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(2, 34)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(513, 15)
        Me.lblCliente.TabIndex = 178
        '
        'TxtCliente
        '
        Me.TxtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtCliente.Location = New System.Drawing.Point(191, 7)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(140, 21)
        Me.TxtCliente.TabIndex = 176
        '
        'BtnCliente
        '
        Me.BtnCliente.Enabled = False
        Me.BtnCliente.Image = CType(resources.GetObject("BtnCliente.Image"), System.Drawing.Image)
        Me.BtnCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnCliente.Location = New System.Drawing.Point(337, 6)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(35, 22)
        Me.BtnCliente.TabIndex = 177
        Me.BtnCliente.ToolTipText = "Busqueda de Operador o Chofer"
        Me.BtnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(5, 7)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(96, 21)
        Me.ChkTodos.TabIndex = 179
        Me.ChkTodos.Text = "Todos"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(368, 55)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox2.TabIndex = 184
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(79, 55)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(283, 21)
        Me.CmbSucursal.TabIndex = 183
        '
        'lblCombo
        '
        Me.lblCombo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCombo.Location = New System.Drawing.Point(4, 59)
        Me.lblCombo.Name = "lblCombo"
        Me.lblCombo.Size = New System.Drawing.Size(54, 15)
        Me.lblCombo.TabIndex = 182
        Me.lblCombo.Text = "Sucursal"
        '
        'ChkCaja
        '
        Me.ChkCaja.Location = New System.Drawing.Point(5, 86)
        Me.ChkCaja.Name = "ChkCaja"
        Me.ChkCaja.Size = New System.Drawing.Size(96, 21)
        Me.ChkCaja.TabIndex = 185
        Me.ChkCaja.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(79, 86)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(283, 21)
        Me.CmbCaja.TabIndex = 186
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(368, 86)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox5.TabIndex = 187
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'MeFiltroCteTodos
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(520, 206)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.CmbCaja)
        Me.Controls.Add(Me.ChkCaja)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.lblCombo)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MeFiltroCteTodos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub MeFiltro_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkTodos.Checked = False Then
            If CTEClave = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(2))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If ChkCaja.Checked = True Then
            If CmbCaja.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(4))
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
            If ChkTodos.Checked Then
                Todos = 1
            Else
                Todos = 0

            End If

            If ChkCaja.Checked Then
                CAJClave = CmbCaja.SelectedValue
            Else
                CAJClave = ""
            End If

            SUCClave = CmbSucursal.SelectedValue

            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("�Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
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

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        bLoad = True


        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With

        CmbCaja.Enabled = False

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox1
        alerta(3) = Me.PictureBox1
        alerta(4) = Me.PictureBox5

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
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
            MessageBox.Show("La informaci�n del empleado no exite o se encuentra incompleta", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
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

    Private Sub TxtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCliente.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtCliente.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        CargaDatosCliente(dtCliente.Rows(0)("CTEClave"))
                        dtCliente.Dispose()
                    End If
                Else
                    CTEClave = ""
                    TxtCliente.Text = ""
                    lblCliente.Text = ""

                    MessageBox.Show("No se encontraron coincidencias para el N�mero de Empleado", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Case Is = Keys.Right
                BtnCliente.PerformClick()
        End Select
    End Sub



    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.Checked Then
            BtnCliente.Enabled = False
            CTEClave = ""
            TxtCliente.Text = ""
            lblCliente.Text = ""
        Else
            Me.BtnCliente.Enabled = True
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then
            With CmbCaja
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub ChkCaja_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCaja.CheckedChanged
        If ChkCaja.Checked Then
            CmbCaja.Enabled = True
        Else
            CmbCaja.Enabled = False
        End If
    End Sub
End Class
