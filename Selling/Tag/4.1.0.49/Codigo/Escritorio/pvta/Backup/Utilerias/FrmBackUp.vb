Public Class FrmBackUp
    Inherits System.Windows.Forms.Form

    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Public sNombreBackup As String = "\Selling.bak"
    Public sRuta As String = "C:\Backup"

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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Button2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpProceso As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCategoriaJob As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreJob As System.Windows.Forms.TextBox
    Friend WithEvents GrpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents GrpDias As System.Windows.Forms.GroupBox
    Friend WithEvents ChkListDias As System.Windows.Forms.CheckedListBox
    Friend WithEvents TxtNombreStep As System.Windows.Forms.TextBox
    Friend WithEvents LblFactura As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFrecuencia As StoreCombo
    Friend WithEvents TxtHoraFin As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtHoraInicio As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents NumIntervalo As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBackUp))
        Me.GrpProceso = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCategoriaJob = New System.Windows.Forms.TextBox
        Me.TxtNombreJob = New System.Windows.Forms.TextBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtHoraFin = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtHoraInicio = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.NumIntervalo = New System.Windows.Forms.NumericUpDown
        Me.cmbFrecuencia = New Selling.StoreCombo
        Me.LblFactura = New System.Windows.Forms.Label
        Me.Button2 = New Janus.Windows.EditControls.UIButton
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.GrpDias = New System.Windows.Forms.GroupBox
        Me.ChkListDias = New System.Windows.Forms.CheckedListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNombreStep = New System.Windows.Forms.TextBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton
        Me.GrpProceso.SuspendLayout()
        Me.GrpConfiguracion.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumIntervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDias.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpProceso
        '
        Me.GrpProceso.Controls.Add(Me.Label2)
        Me.GrpProceso.Controls.Add(Me.Label1)
        Me.GrpProceso.Controls.Add(Me.TxtCategoriaJob)
        Me.GrpProceso.Controls.Add(Me.TxtNombreJob)
        Me.GrpProceso.Location = New System.Drawing.Point(13, 15)
        Me.GrpProceso.Name = "GrpProceso"
        Me.GrpProceso.Size = New System.Drawing.Size(420, 96)
        Me.GrpProceso.TabIndex = 7
        Me.GrpProceso.TabStop = False
        Me.GrpProceso.Text = "Proceso de Respaldo Actual"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre"
        '
        'TxtCategoriaJob
        '
        Me.TxtCategoriaJob.Location = New System.Drawing.Point(87, 52)
        Me.TxtCategoriaJob.Name = "TxtCategoriaJob"
        Me.TxtCategoriaJob.ReadOnly = True
        Me.TxtCategoriaJob.Size = New System.Drawing.Size(206, 20)
        Me.TxtCategoriaJob.TabIndex = 1
        Me.TxtCategoriaJob.TabStop = False
        '
        'TxtNombreJob
        '
        Me.TxtNombreJob.Location = New System.Drawing.Point(87, 22)
        Me.TxtNombreJob.Name = "TxtNombreJob"
        Me.TxtNombreJob.ReadOnly = True
        Me.TxtNombreJob.Size = New System.Drawing.Size(206, 20)
        Me.TxtNombreJob.TabIndex = 0
        Me.TxtNombreJob.TabStop = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(150, 415)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnOk.Location = New System.Drawing.Point(248, 415)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 2
        Me.BtnOk.Text = "Iniciar Servicio"
        Me.BtnOk.ToolTipText = "Iniciar Servicio"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConfiguracion
        '
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox4)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox3)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox2)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox1)
        Me.GrpConfiguracion.Controls.Add(Me.Label11)
        Me.GrpConfiguracion.Controls.Add(Me.Label10)
        Me.GrpConfiguracion.Controls.Add(Me.GroupBox1)
        Me.GrpConfiguracion.Controls.Add(Me.Label7)
        Me.GrpConfiguracion.Controls.Add(Me.TxtHoraFin)
        Me.GrpConfiguracion.Controls.Add(Me.Label6)
        Me.GrpConfiguracion.Controls.Add(Me.TxtHoraInicio)
        Me.GrpConfiguracion.Controls.Add(Me.Label5)
        Me.GrpConfiguracion.Controls.Add(Me.Label4)
        Me.GrpConfiguracion.Controls.Add(Me.NumIntervalo)
        Me.GrpConfiguracion.Controls.Add(Me.cmbFrecuencia)
        Me.GrpConfiguracion.Controls.Add(Me.LblFactura)
        Me.GrpConfiguracion.Controls.Add(Me.Button2)
        Me.GrpConfiguracion.Controls.Add(Me.TxtDireccion)
        Me.GrpConfiguracion.Controls.Add(Me.LblClave)
        Me.GrpConfiguracion.Controls.Add(Me.GrpDias)
        Me.GrpConfiguracion.Controls.Add(Me.Label3)
        Me.GrpConfiguracion.Controls.Add(Me.TxtNombreStep)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox5)
        Me.GrpConfiguracion.Location = New System.Drawing.Point(13, 119)
        Me.GrpConfiguracion.Name = "GrpConfiguracion"
        Me.GrpConfiguracion.Size = New System.Drawing.Size(420, 290)
        Me.GrpConfiguracion.TabIndex = 0
        Me.GrpConfiguracion.TabStop = False
        Me.GrpConfiguracion.Text = "Configuración"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(367, 193)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 61
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(367, 163)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 60
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(400, 89)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 59
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(80, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(313, 193)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 15)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "HH:MM:SS"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(313, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 15)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "HH:MM:SS"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 223)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 59)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Duración"
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(71, 28)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(166, 20)
        Me.cmbFechaInicio.TabIndex = 5
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 15)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Fecha Inicio "
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(153, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Hora Fin"
        '
        'TxtHoraFin
        '
        Me.TxtHoraFin.Location = New System.Drawing.Point(240, 193)
        Me.TxtHoraFin.Mask = "00:00:00"
        Me.TxtHoraFin.MaxLength = 240000
        Me.TxtHoraFin.Name = "TxtHoraFin"
        Me.TxtHoraFin.Size = New System.Drawing.Size(62, 20)
        Me.TxtHoraFin.TabIndex = 4
        Me.TxtHoraFin.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(153, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Hora Inicio"
        '
        'TxtHoraInicio
        '
        Me.TxtHoraInicio.Location = New System.Drawing.Point(240, 163)
        Me.TxtHoraInicio.Mask = "00:00:00"
        Me.TxtHoraInicio.MaxLength = 240000
        Me.TxtHoraInicio.Name = "TxtHoraInicio"
        Me.TxtHoraInicio.Size = New System.Drawing.Size(62, 20)
        Me.TxtHoraInicio.TabIndex = 3
        Me.TxtHoraInicio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(280, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Horas"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(153, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Intervalo cada"
        '
        'NumIntervalo
        '
        Me.NumIntervalo.Location = New System.Drawing.Point(240, 134)
        Me.NumIntervalo.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.NumIntervalo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumIntervalo.Name = "NumIntervalo"
        Me.NumIntervalo.Size = New System.Drawing.Size(40, 20)
        Me.NumIntervalo.TabIndex = 2
        Me.NumIntervalo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.Location = New System.Drawing.Point(240, 89)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Size = New System.Drawing.Size(160, 21)
        Me.cmbFrecuencia.TabIndex = 1
        '
        'LblFactura
        '
        Me.LblFactura.Location = New System.Drawing.Point(153, 97)
        Me.LblFactura.Name = "LblFactura"
        Me.LblFactura.Size = New System.Drawing.Size(87, 14)
        Me.LblFactura.TabIndex = 47
        Me.LblFactura.Text = "Frecuencia por día"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageSize = New System.Drawing.Size(20, 20)
        Me.Button2.Location = New System.Drawing.Point(380, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 30)
        Me.Button2.TabIndex = 27
        Me.Button2.Visible = False
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(66, 45)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(307, 20)
        Me.TxtDireccion.TabIndex = 25
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 45)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 14)
        Me.LblClave.TabIndex = 26
        Me.LblClave.Text = "Guardar en "
        '
        'GrpDias
        '
        Me.GrpDias.Controls.Add(Me.ChkListDias)
        Me.GrpDias.Location = New System.Drawing.Point(13, 102)
        Me.GrpDias.Name = "GrpDias"
        Me.GrpDias.Size = New System.Drawing.Size(114, 115)
        Me.GrpDias.TabIndex = 6
        Me.GrpDias.TabStop = False
        Me.GrpDias.Text = "Realizar cada"
        '
        'ChkListDias
        '
        Me.ChkListDias.Items.AddRange(New Object() {"Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"})
        Me.ChkListDias.Location = New System.Drawing.Point(7, 15)
        Me.ChkListDias.Name = "ChkListDias"
        Me.ChkListDias.Size = New System.Drawing.Size(100, 94)
        Me.ChkListDias.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre"
        '
        'TxtNombreStep
        '
        Me.TxtNombreStep.Location = New System.Drawing.Point(67, 22)
        Me.TxtNombreStep.Name = "TxtNombreStep"
        Me.TxtNombreStep.ReadOnly = True
        Me.TxtNombreStep.Size = New System.Drawing.Size(200, 20)
        Me.TxtNombreStep.TabIndex = 3
        Me.TxtNombreStep.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(367, 30)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 62
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(343, 415)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Actualizar"
        Me.BtnActualizar.ToolTipText = "Actualizar"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmBackUp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(442, 460)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpConfiguracion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GrpProceso)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBackUp"
        Me.Text = "Programación de Respaldos del Sistema"
        Me.GrpProceso.ResumeLayout(False)
        Me.GrpProceso.PerformLayout()
        Me.GrpConfiguracion.ResumeLayout(False)
        Me.GrpConfiguracion.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.NumIntervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDias.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos"
    Private Sub habilitaServicio()
        Dim dt As DataTable
        Dim status As String
        dt = ModPOS.Recupera_Consulta("EXEC master.dbo.xp_ServiceControl 'QUERYSTATE','SQLServerAgent'")
        status = dt.Rows(0)("Current Service State")
        dt.Dispose()
        If status = "Stopped." Then

            BtnActualizar.Enabled = False
            BtnOk.Enabled = True
        Else
            BtnActualizar.Enabled = True
            BtnOk.Enabled = False
        End If
    End Sub

    Private Function validaHora(ByVal hora As String) As Boolean
        If hora.Length < 8 Then
            Return False
        ElseIf CInt(hora.Substring(0, 2)) = 24 AndAlso CInt(hora.Substring(3, 2)) > 0 AndAlso CInt(hora.Substring(6, 2)) > 0 Then
            Return True

        ElseIf CInt(hora.Substring(0, 2)) > 23 Then
            Return False

        ElseIf CInt(hora.Substring(3, 2)) > 59 Then
            Return False
        ElseIf CInt(hora.Substring(6, 2)) > 59 Then
            Return False
        Else
            Return True
        End If



    End Function

    Private Function calculaHora(ByVal hora As String) As String
        Dim hr As String
        If hora <> "" AndAlso hora.Length = 8 Then
            hr = hora.Substring(0, 2) & hora.Substring(3, 2) & hora.Substring(6, 2)
        Else
            hr = "000000"
        End If
        Return hr
    End Function

    Private Function recuperaFecha(ByVal Fec As String) As Date
        Dim Fecha As Date
        Fecha = CDate(Fec.Substring(0, 4) & "/" & Fec.Substring(4, 2) & "/" & Fec.Substring(6, 2))

        Return Fecha

    End Function

    Private Function calcularFecha(ByVal dat As Date) As String
        Dim fecha, mes, dia As String

        If CStr(dat.Month).Length < 2 Then
            mes = "0" & CStr(dat.Month)
        Else
            mes = CStr(dat.Month)
        End If

        If CStr(dat.Day).Length < 2 Then
            dia = "0" & CStr(dat.Day)
        Else
            dia = CStr(dat.Day)
        End If

        fecha = CStr(dat.Year) & mes & dia
        Return fecha
    End Function

    Private Sub recuperaDias(ByVal Dias As Int16)
        If Dias > 0 Then
            If Dias >= 64 Then
                ChkListDias.SetItemCheckState(6, CheckState.Checked)
                recuperaDias(Dias - 64)

            ElseIf Dias < 64 AndAlso Dias >= 32 Then
                ChkListDias.SetItemCheckState(5, CheckState.Checked)
                recuperaDias(Dias - 32)

            ElseIf Dias < 32 AndAlso Dias >= 16 Then
                ChkListDias.SetItemCheckState(4, CheckState.Checked)
                recuperaDias(Dias - 16)

            ElseIf Dias < 16 AndAlso Dias >= 8 Then
                ChkListDias.SetItemCheckState(3, CheckState.Checked)
                recuperaDias(Dias - 8)

            ElseIf Dias < 8 AndAlso Dias >= 4 Then
                ChkListDias.SetItemCheckState(2, CheckState.Checked)
                recuperaDias(Dias - 4)

            ElseIf Dias = 3 Then
                ChkListDias.SetItemCheckState(1, CheckState.Checked)
                recuperaDias(Dias - 2)

            ElseIf Dias = 2 Then
                ChkListDias.SetItemCheckState(1, CheckState.Checked)
                recuperaDias(Dias - 2)

            ElseIf Dias = 1 Then
                ChkListDias.SetItemCheckState(0, CheckState.Checked)
            End If

        End If
    End Sub

    Private Function calcularDias() As String
        Dim i As Integer
        Dim Valor As Int16
        For i = 0 To Me.ChkListDias.CheckedItems.Count - 1
            Select Case CStr(ChkListDias.CheckedItems(i))
                Case "Sábado"
                    Valor += 64
                Case "Viernes"
                    Valor += 32
                Case "Jueves"
                    Valor += 16
                Case "Miércoles"
                    Valor += 8
                Case "Martes"
                    Valor += 4
                Case "Lunes"
                    Valor += 2
                Case "Domingo"
                    Valor += 1
            End Select
        Next
        Return CStr(Valor)
    End Function

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If ChkListDias.CheckedItems.Count = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFrecuencia.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtHoraInicio.Text = "" OrElse Not validaHora(TxtHoraInicio.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtHoraFin.Text = "" OrElse Not validaHora(TxtHoraFin.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CInt(calculaHora(TxtHoraInicio.Text)) >= CInt(calculaHora(TxtHoraFin.Text)) Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDireccion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
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
#End Region

    Private Sub FrmBackUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        habilitaServicio()


        TxtDireccion.Text = sRuta & sNombreBackup

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        Me.cmbFechaInicio.Value = Today

        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With Me.cmbFrecuencia
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Backup"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Frecuencia"
            .llenar()
        End With


        Dim dt As DataTable

        Try
            dt = ModPOS.Recupera_Tabla_No_Msg("msdb.dbo.sp_help_job", "@job_name", "pvta_backup", "@job_aspect", "JOB")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    TxtNombreJob.Text = dt.Rows(0)("name")
                    TxtCategoriaJob.Text = dt.Rows(0)("description")
                End If
                dt.Dispose()
            End If
        Catch ex As System.Data.SqlClient.SqlException
        End Try


        If TxtNombreJob.Text <> "" Then


            dt = ModPOS.Recupera_Tabla("msdb.dbo.sp_help_jobstep", "@job_name", TxtNombreJob.Text)
            TxtNombreStep.Text = dt.Rows(0)("step_name")
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("msdb.dbo.sp_help_jobschedule", "@job_name", TxtNombreJob.Text)
            recuperaDias(CInt(dt.Rows(0)("freq_interval")))
            cmbFrecuencia.SelectedValue = dt.Rows(0)("freq_subday_type")
            NumIntervalo.Text = dt.Rows(0)("freq_subday_interval")
            Dim s As String
            s = dt.Rows(0)("active_start_time")
            If s.Length < 6 Then
                TxtHoraInicio.Text = "0" & s
            Else
                TxtHoraInicio.Text = dt.Rows(0)("active_start_time")
            End If
            s = dt.Rows(0)("active_end_time")
            If s.Length < 6 Then
                TxtHoraFin.Text = "0" & s
            Else
                TxtHoraFin.Text = dt.Rows(0)("active_end_time")
            End If
            cmbFechaInicio.Value = recuperaFecha(dt.Rows(0)("active_start_date"))

            'dt.Dispose()

            'dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@Nombre", "Backup de Sistema")
            'TxtDireccion.Text = dt.Rows(0)("Valor")
            'dt.Dispose()

        End If


    End Sub

    Private Sub FrmBackUp_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Backup.Dispose()
        ModPOS.Backup = Nothing

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Dim dt As DataTable
        Dim status As String
        dt = ModPOS.Recupera_Consulta("EXEC master.dbo.xp_ServiceControl 'QUERYSTATE','SQLServerAgent'")
        status = dt.Rows(0)("Current Service State")
        dt.Dispose()
        If status = "Stopped." Then
            ModPOS.Ejecuta_Consulta("EXEC master.dbo.xp_ServiceControl 'START','SQLServerAgent'")
            MsgBox("El Servicio ya ha Inicializado exitosamente", MsgBoxStyle.Information, "Información")
            BtnActualizar.Enabled = True
            BtnOk.Enabled = False
        Else
            MsgBox("El Servicio ya se encuentra Inicializado", MsgBoxStyle.Information, "Información")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ''Dim a As New System.Windows.Forms.FolderBrowserDialog

        ''If (a.ShowDialog() = DialogResult.OK) Then

        ''    If a.SelectedPath.Length <= 3 Then
        ''        TxtDireccion.Text = a.SelectedPath & "pvta.bak"
        ''    Else
        ''        TxtDireccion.Text = a.SelectedPath & "\pvta.bak"
        ''    End If
        ''End If
    End Sub

    Private Sub cmbFrecuencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrecuencia.SelectedIndexChanged
        If cmbFrecuencia.SelectedIndex = 0 Then
            Me.NumIntervalo.Enabled = False
            Me.TxtHoraFin.ReadOnly = True
            NumIntervalo.Text = "1"
            TxtHoraFin.Text = "23:59:59"
        Else
            Me.NumIntervalo.Enabled = True
            Me.TxtHoraFin.ReadOnly = False

        End If

    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click

        If validaForm() Then

            Try
                If Not System.IO.Directory.Exists(sRuta) Then
                    System.IO.Directory.CreateDirectory(sRuta)
                End If
            Catch ex As Exception
            End Try

            Select Case Me.TxtNombreJob.Text
                Case ""
                    Try

                        'En caso de que no exista el Job lo crea
                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_add_job @job_name='pvta_backup',@enabled=1,@description='Respaldo automatico'")

                        TxtNombreJob.Text = "pvta_backup"
                        TxtCategoriaJob.Text = "Respaldo automatico"

                        'Crea el Step del Job
                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_add_jobstep @job_name='pvta_backup',@step_name='pvta_bak',@command= 'BACKUP DATABASE Selling  TO DISK = ''" & Me.TxtDireccion.Text & "''   WITH INIT, NOSKIP, STATS = 10',@database_name='Selling'")

                        TxtNombreStep.Text = "pvta_backup"

                        'Actualiza el parametro de compañia de respaldo
                        'ModPOS.Ejecuta("sp_actualiza_comparam", "@Nombre", "Backup de Sistema", "@Valor", TxtDireccion.Text)
                        'Crea el Schedule del job

                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_add_jobschedule @job_name='pvta_backup',@name='ScheduleBackup',@freq_type=8,@freq_recurrence_factor=1,@freq_interval=" & calcularDias() & _
                        ",@freq_subday_type=" & CStr(cmbFrecuencia.SelectedValue) & _
                        ",@freq_subday_interval=" & NumIntervalo.Text & _
                        ",@active_start_time=" & calculaHora(TxtHoraInicio.Text) & _
                        ",@active_end_time=" & calculaHora(TxtHoraFin.Text) & _
                        ",@active_start_date=" & calcularFecha(cmbFechaInicio.Value))


                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_add_jobserver @job_name = 'pvta_backup', @server_name = N'(local)'")

                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_start_job @job_name = 'pvta_backup'")


                        MsgBox("El respaldo ha sido programado exitosamente", MsgBoxStyle.Information, "Información")
                    Catch ex As Exception
                        MsgBox("Error al programar el respaldo, comunicarse a soporte tecnico", MsgBoxStyle.Critical, "Error")
                    End Try

                Case "pvta_backup"
                    Try

                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_update_jobstep @job_name='pvta_backup',@step_id=1,@command= 'BACKUP DATABASE pvta  TO DISK = ''" & Me.TxtDireccion.Text & "''   WITH INIT, NOSKIP, STATS = 10',@database_name='pvta'")
                        'Actualiza el parametro de compañia de respaldo
                        '  ModPOS.Ejecuta("sp_actualiza_comparam", "@Nombre", "Backup de Sistema", "@Valor", TxtDireccion.Text)
                        'Crea el Schedule del job

                        ModPOS.Ejecuta_Consulta("EXEC msdb.dbo.sp_update_jobschedule @job_name='pvta_backup',@name='ScheduleBackup',@freq_interval=" & calcularDias() & _
                        ",@freq_subday_type=" & CStr(cmbFrecuencia.SelectedValue) & _
                        ",@freq_subday_interval=" & NumIntervalo.Text & _
                        ",@active_start_time=" & calculaHora(TxtHoraInicio.Text) & _
                        ",@active_end_time=" & calculaHora(TxtHoraFin.Text) & _
                        ",@active_start_date=" & calcularFecha(cmbFechaInicio.Value))



                        MsgBox("El respaldo ha sido actualizado exitosamente", MsgBoxStyle.Information, "Información")

                    Catch ex As Exception
                        MsgBox("Error al actualizar el respaldo, comunicarse a soporte tecnico", MsgBoxStyle.Critical, "Error")
                    End Try
            End Select


        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

End Class
