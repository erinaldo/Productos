Public Class MeFiltroPrice
    Inherits System.Windows.Forms.Form

    Private Lista As String
    Private Linea As String
    Private Sublinea As String
    Public Titulo As String
    Private bError As Boolean = False
    Private Tipo As Integer

    Private LineaCargada As Boolean
    ' Public Reporte As String

    Private alerta(3) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbListaPrecio As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSubLinea As Selling.StoreCombo
    Friend WithEvents CmbLinea As Selling.StoreCombo
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkSublinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkToda As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Private reloj As parpadea


    Public ReadOnly Property TipoImpuesto() As String
        Get
            TipoImpuesto = Tipo
        End Get
    End Property

    Public ReadOnly Property ListaPrecio() As String
        Get
            ListaPrecio = Lista
        End Get
    End Property

    Public ReadOnly Property LineaCVE() As String
        Get
            LineaCVE = Linea
        End Get
    End Property

    Public ReadOnly Property SublineaCVE() As String
        Get
            SublineaCVE = Sublinea
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
    Friend WithEvents GrpLinea As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroPrice))
        Me.GrpLinea = New System.Windows.Forms.GroupBox
        Me.ChkSublinea = New System.Windows.Forms.CheckBox
        Me.ChkLinea = New System.Windows.Forms.CheckBox
        Me.CmbSubLinea = New Selling.StoreCombo
        Me.CmbLinea = New Selling.StoreCombo
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.CmbListaPrecio = New Selling.StoreCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkToda = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GrpLinea.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpLinea
        '
        Me.GrpLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLinea.Controls.Add(Me.ChkSublinea)
        Me.GrpLinea.Controls.Add(Me.ChkLinea)
        Me.GrpLinea.Controls.Add(Me.CmbSubLinea)
        Me.GrpLinea.Controls.Add(Me.CmbLinea)
        Me.GrpLinea.Controls.Add(Me.PictureBox4)
        Me.GrpLinea.Controls.Add(Me.PictureBox3)
        Me.GrpLinea.Enabled = False
        Me.GrpLinea.Location = New System.Drawing.Point(2, 59)
        Me.GrpLinea.Name = "GrpLinea"
        Me.GrpLinea.Size = New System.Drawing.Size(366, 74)
        Me.GrpLinea.TabIndex = 2
        Me.GrpLinea.TabStop = False
        '
        'ChkSublinea
        '
        Me.ChkSublinea.Location = New System.Drawing.Point(10, 48)
        Me.ChkSublinea.Name = "ChkSublinea"
        Me.ChkSublinea.Size = New System.Drawing.Size(69, 23)
        Me.ChkSublinea.TabIndex = 74
        Me.ChkSublinea.Text = "Sublinea"
        '
        'ChkLinea
        '
        Me.ChkLinea.Location = New System.Drawing.Point(10, 20)
        Me.ChkLinea.Name = "ChkLinea"
        Me.ChkLinea.Size = New System.Drawing.Size(57, 23)
        Me.ChkLinea.TabIndex = 73
        Me.ChkLinea.Text = "Linea"
        '
        'CmbSubLinea
        '
        Me.CmbSubLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSubLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSubLinea.Location = New System.Drawing.Point(84, 48)
        Me.CmbSubLinea.Name = "CmbSubLinea"
        Me.CmbSubLinea.Size = New System.Drawing.Size(259, 21)
        Me.CmbSubLinea.TabIndex = 72
        '
        'CmbLinea
        '
        Me.CmbLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLinea.Location = New System.Drawing.Point(84, 19)
        Me.CmbLinea.Name = "CmbLinea"
        Me.CmbLinea.Size = New System.Drawing.Size(259, 21)
        Me.CmbLinea.TabIndex = 71
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(347, 53)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(347, 23)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 16)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(278, 139)
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
        Me.BtnCancel.Location = New System.Drawing.Point(182, 139)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbListaPrecio
        '
        Me.CmbListaPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbListaPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.CmbListaPrecio.Location = New System.Drawing.Point(74, 7)
        Me.CmbListaPrecio.Name = "CmbListaPrecio"
        Me.CmbListaPrecio.Size = New System.Drawing.Size(276, 21)
        Me.CmbListaPrecio.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(10, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Lista"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(354, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkToda
        '
        Me.ChkToda.Checked = True
        Me.ChkToda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkToda.Location = New System.Drawing.Point(12, 35)
        Me.ChkToda.Name = "ChkToda"
        Me.ChkToda.Size = New System.Drawing.Size(87, 22)
        Me.ChkToda.TabIndex = 74
        Me.ChkToda.Text = "Toda"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(72, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 12)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "Tipo Impuesto"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(158, 35)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipo.TabIndex = 75
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(312, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 77
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'MeFiltroPrice
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(369, 180)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.ChkToda)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbListaPrecio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GrpLinea)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 213)
        Me.Name = "MeFiltroPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpLinea.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroPrice_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbListaPrecio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkLinea.Checked AndAlso Me.CmbLinea.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkSublinea.Checked AndAlso Me.CmbSubLinea.SelectedValue Is Nothing Then
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then

            Lista = CmbListaPrecio.SelectedValue
            Tipo = CmbTipo.SelectedValue

            If ChkToda.Checked Then
                Linea = ""
                Sublinea = ""
            Else
                If ChkLinea.Checked Then
                    Linea = CStr(CmbLinea.SelectedValue)
                Else
                    Linea = ""
                End If

                If ChkSublinea.Checked Then
                    Sublinea = CStr(CmbSubLinea.SelectedValue)
                Else
                    Sublinea = ""
                End If
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

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox1
        alerta(3) = Me.PictureBox2

        With Me.cmbListaPrecio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_lista"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With

        With Me.CmbLinea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_linea"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
            lineaCargada = True
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        Me.Text = Titulo

    End Sub


    Private Sub CmbLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLinea.SelectedIndexChanged
        If Not CmbLinea.SelectedValue Is Nothing AndAlso lineaCargada Then
            With Me.CmbSubLinea
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_sublinea"
                .NombreParametro1 = "CLAClavePadre"
                .Parametro1 = CmbLinea.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub ChkToda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkToda.CheckedChanged
        If ChkToda.Checked Then
            GrpLinea.Enabled = False
            ChkLinea.Checked = False
            ChkSublinea.Checked = False
        Else
            GrpLinea.Enabled = True
            ChkLinea.Checked = True
            ChkSublinea.Checked = True
        End If
    End Sub
End Class
