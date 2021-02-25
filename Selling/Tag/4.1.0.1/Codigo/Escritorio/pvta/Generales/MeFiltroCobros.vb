Public Class MeFiltroCobros
    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private Sucursal As String
    Private Caja As String
    Private Todos As Integer
    Private Metodo As Integer

    Private bError As Boolean = False

    Public Titulo As String
    Private bLoad As Boolean = False
    ' Public Reporte As String

    Private alerta(4) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox

    Private reloj As parpadea

    Public ReadOnly Property SucursalOrigen() As String
        Get
            SucursalOrigen = Sucursal
        End Get
    End Property

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

    Public ReadOnly Property CajaOrigen() As String
        Get
            CajaOrigen = Caja
        End Get
    End Property

    Public ReadOnly Property TodosMetodos() As Integer
        Get
            TodosMetodos = Todos
        End Get
    End Property

    Public ReadOnly Property MetodoPago() As Integer
        Get
            MetodoPago = Metodo
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
    Friend WithEvents GrpRango As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroCobros))
        Me.GrpRango = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.cmbMetodoPago = New Selling.StoreCombo()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GrpRango.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpRango
        '
        Me.GrpRango.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRango.Controls.Add(Me.Label2)
        Me.GrpRango.Controls.Add(Me.Label1)
        Me.GrpRango.Controls.Add(Me.PictureBox4)
        Me.GrpRango.Controls.Add(Me.PictureBox3)
        Me.GrpRango.Controls.Add(Me.CmbFechaFin)
        Me.GrpRango.Controls.Add(Me.cmbFechaInicio)
        Me.GrpRango.Location = New System.Drawing.Point(4, 125)
        Me.GrpRango.Name = "GrpRango"
        Me.GrpRango.Size = New System.Drawing.Size(433, 45)
        Me.GrpRango.TabIndex = 2
        Me.GrpRango.TabStop = False
        Me.GrpRango.Text = "Rango"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(215, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "AL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "DEL"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(388, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(177, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 16)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(273, 15)
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
        Me.cmbFechaInicio.Location = New System.Drawing.Point(46, 15)
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
        Me.BtnOK.Location = New System.Drawing.Point(347, 177)
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
        Me.BtnCancel.Location = New System.Drawing.Point(251, 177)
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
        Me.Label3.Location = New System.Drawing.Point(7, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Sucursal"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(38, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 17)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(38, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox2.TabIndex = 96
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(7, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Caja"
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(67, 49)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(348, 21)
        Me.CmbCaja.TabIndex = 95
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(67, 11)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(349, 21)
        Me.CmbSucursal.TabIndex = 38
        '
        'ChkTodos
        '
        Me.ChkTodos.Checked = True
        Me.ChkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodos.Location = New System.Drawing.Point(4, 88)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(140, 23)
        Me.ChkTodos.TabIndex = 99
        Me.ChkTodos.Text = "Todos los Metodos"
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPago.Location = New System.Drawing.Point(125, 87)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(291, 21)
        Me.cmbMetodoPago.TabIndex = 100
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(96, 88)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox5.TabIndex = 101
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'MeFiltroCobros
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(446, 224)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.cmbMetodoPago)
        Me.Controls.Add(Me.ChkTodos)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CmbCaja)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GrpRango)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 157)
        Me.Name = "MeFiltroCobros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpRango.ResumeLayout(False)
        Me.GrpRango.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

        If Me.CmbCaja.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkTodos.Checked = False Then
            If Me.cmbMetodoPago.SelectedValue Is Nothing Then
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

            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            Sucursal = CmbSucursal.SelectedValue
            Caja = CmbCaja.SelectedValue

            If ChkTodos.Checked = False Then
                Todos = 0
                Metodo = cmbMetodoPago.SelectedValue
            Else
                Todos = 1
                Metodo = -1
            End If
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

        bLoad = True


        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = IIf(CmbSucursal.SelectedValue Is Nothing, "", CmbSucursal.SelectedValue)
            .llenar()
        End With


        With cmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_metodopago"
            .llenar()
        End With

        cmbMetodoPago.Enabled = False

        Me.Text = Titulo

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
    End Sub


    Private Sub CmbAlmacen_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedValueChanged
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

   
    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.Checked = True Then
            cmbMetodoPago.Enabled = False
        Else
            cmbMetodoPago.Enabled = True
        End If
    End Sub
End Class
