Public Class MeFiltroValor
    Inherits System.Windows.Forms.Form

    Private Almacen As String

    Private Linea As String
    Private Sublinea As String
    Public Titulo As String
    Private bError As Boolean = False

    Private LineaCargada As Boolean
    ' Public Reporte As String

    Private alerta(2) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSubLinea As Selling.StoreCombo
    Friend WithEvents CmbLinea As Selling.StoreCombo
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkSublinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLinea As System.Windows.Forms.CheckBox
    Friend WithEvents ChkToda As System.Windows.Forms.CheckBox
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label

    Private reloj As parpadea

    Public ReadOnly Property AlmacenOrigen() As String
        Get
            AlmacenOrigen = Almacen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroValor))
        Me.GrpLinea = New System.Windows.Forms.GroupBox
        Me.ChkSublinea = New System.Windows.Forms.CheckBox
        Me.ChkLinea = New System.Windows.Forms.CheckBox
        Me.CmbSubLinea = New Selling.StoreCombo
        Me.CmbLinea = New Selling.StoreCombo
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkToda = New System.Windows.Forms.CheckBox
        Me.CmbAlmacen = New Selling.StoreCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpLinea.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpLinea.Location = New System.Drawing.Point(2, 63)
        Me.GrpLinea.Name = "GrpLinea"
        Me.GrpLinea.Size = New System.Drawing.Size(529, 74)
        Me.GrpLinea.TabIndex = 2
        Me.GrpLinea.TabStop = False
        '
        'ChkSublinea
        '
        Me.ChkSublinea.Location = New System.Drawing.Point(10, 48)
        Me.ChkSublinea.Name = "ChkSublinea"
        Me.ChkSublinea.Size = New System.Drawing.Size(72, 23)
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
        Me.CmbSubLinea.Location = New System.Drawing.Point(88, 48)
        Me.CmbSubLinea.Name = "CmbSubLinea"
        Me.CmbSubLinea.Size = New System.Drawing.Size(418, 21)
        Me.CmbSubLinea.TabIndex = 72
        '
        'CmbLinea
        '
        Me.CmbLinea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbLinea.BackColor = System.Drawing.SystemColors.Window
        Me.CmbLinea.Location = New System.Drawing.Point(88, 19)
        Me.CmbLinea.Name = "CmbLinea"
        Me.CmbLinea.Size = New System.Drawing.Size(418, 21)
        Me.CmbLinea.TabIndex = 71
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(510, 53)
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
        Me.PictureBox3.Location = New System.Drawing.Point(510, 23)
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
        Me.BtnOK.Location = New System.Drawing.Point(436, 150)
        Me.BtnOK.MaximumSize = New System.Drawing.Size(547, 229)
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
        Me.BtnCancel.Location = New System.Drawing.Point(340, 150)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(517, 13)
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
        Me.ChkToda.Location = New System.Drawing.Point(12, 40)
        Me.ChkToda.Name = "ChkToda"
        Me.ChkToda.Size = New System.Drawing.Size(143, 22)
        Me.ChkToda.TabIndex = 74
        Me.ChkToda.Text = "Todas las lineas"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(53, 13)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(459, 21)
        Me.CmbAlmacen.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(4, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Almacén"
        '
        'MeFiltroValor
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(531, 195)
        Me.Controls.Add(Me.CmbAlmacen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ChkToda)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GrpLinea)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(385, 213)
        Me.Name = "MeFiltroValor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GrpLinea.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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


        If Me.CmbAlmacen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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
            Almacen = CmbAlmacen.SelectedValue

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

        With CmbAlmacen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        With Me.CmbLinea
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_linea"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
            LineaCargada = True
        End With


        Me.Text = Titulo

    End Sub


    Private Sub CmbLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLinea.SelectedIndexChanged
        If Not CmbLinea.SelectedValue Is Nothing AndAlso LineaCargada Then
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
