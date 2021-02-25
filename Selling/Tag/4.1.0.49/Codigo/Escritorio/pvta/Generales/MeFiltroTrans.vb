Public Class MeFiltroTrans
    Inherits System.Windows.Forms.Form

    Private TRAClave As String
    Private FechaIni As String
    Private FechaFin As String
    Private bError As Boolean = False

    Private alerta(2) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents BtnBusquedaTransporte As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEconomico As System.Windows.Forms.TextBox

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


    Public ReadOnly Property Transporte() As String
        Get
            Transporte = TRAClave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroTrans))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblPlacas = New System.Windows.Forms.Label
        Me.BtnBusquedaTransporte = New Janus.Windows.EditControls.UIButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEconomico = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 31)
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
        Me.BtnOK.Location = New System.Drawing.Point(425, 81)
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
        Me.BtnCancel.Location = New System.Drawing.Point(329, 81)
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
        Me.PictureBox1.Location = New System.Drawing.Point(85, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox1.TabIndex = 175
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblPlacas
        '
        Me.lblPlacas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.Location = New System.Drawing.Point(235, 12)
        Me.lblPlacas.MaximumSize = New System.Drawing.Size(240, 15)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(240, 15)
        Me.lblPlacas.TabIndex = 173
        Me.lblPlacas.Text = "Placas:"
        '
        'BtnBusquedaTransporte
        '
        Me.BtnBusquedaTransporte.Image = CType(resources.GetObject("BtnBusquedaTransporte.Image"), System.Drawing.Image)
        Me.BtnBusquedaTransporte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusquedaTransporte.Location = New System.Drawing.Point(194, 7)
        Me.BtnBusquedaTransporte.Name = "BtnBusquedaTransporte"
        Me.BtnBusquedaTransporte.Size = New System.Drawing.Size(35, 22)
        Me.BtnBusquedaTransporte.TabIndex = 172
        Me.BtnBusquedaTransporte.ToolTipText = "Busqueda de Transporte o Vehiculo"
        Me.BtnBusquedaTransporte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 15)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "No. Economico"
        '
        'txtEconomico
        '
        Me.txtEconomico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEconomico.Location = New System.Drawing.Point(109, 7)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(79, 21)
        Me.txtEconomico.TabIndex = 171
        '
        'MeFiltroTrans
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(520, 123)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblPlacas)
        Me.Controls.Add(Me.BtnBusquedaTransporte)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEconomico)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MeFiltroTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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

        If TRAClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("ˇAlguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox1

        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
    End Sub

    Private Sub CargaDatosTransporte(ByVal sTRAClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_transporte", "@TRAClave", sTRAClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TRAClave = dt.Rows(0)("TRAClave")
            txtEconomico.Text = dt.Rows(0)("noEconomico")
            lblPlacas.Text = dt.Rows(0)("Placa")
            dt.Dispose()
        Else
            TRAClave = ""
            txtEconomico.Text = ""
            lblPlacas.Text = ""

            MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub BtnBusquedaTransporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaTransporte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_transporte"
        a.TablaCmb = "Transporte"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.BusquedaInicial = True
        a.Busqueda = "%"
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CargaDatosTransporte(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub txtEconomico_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEconomico.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtEconomico.Text <> "" Then
                    Dim dtTransporte As DataTable
                    dtTransporte = ModPOS.SiExisteRecupera("sp_consulta_transporte", "@Economico", txtEconomico.Text.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtTransporte Is Nothing AndAlso dtTransporte.Rows.Count > 0 Then
                        Dim sTRAClave As String = dtTransporte.Rows(0)("TRAClave")
                        dtTransporte.Dispose()
                        CargaDatosTransporte(sTRAClave)
                    Else
                        TRAClave = ""
                        txtEconomico.Text = ""
                        lblPlacas.Text = ""
                      
                        MessageBox.Show("La información del Transporte no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_transporte"
                a.TablaCmb = "Transporte"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = txtEconomico.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CargaDatosTransporte(a.valor)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub
End Class
