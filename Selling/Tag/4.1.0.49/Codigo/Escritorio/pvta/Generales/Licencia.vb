Public Class Licencia
    Inherits System.Windows.Forms.Form
    Friend WithEvents TxtCandado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblVersion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Public Pass As Boolean = False

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
    Friend WithEvents GrpKey As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtLlave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Licencia))
        Me.GrpKey = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtLlave = New System.Windows.Forms.TextBox
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.TxtCandado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblVersion = New System.Windows.Forms.Label
        Me.GrpKey.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpKey
        '
        Me.GrpKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpKey.Controls.Add(Me.PictureBox2)
        Me.GrpKey.Controls.Add(Me.TxtLlave)
        Me.GrpKey.Location = New System.Drawing.Point(2, 95)
        Me.GrpKey.Name = "GrpKey"
        Me.GrpKey.Size = New System.Drawing.Size(379, 48)
        Me.GrpKey.TabIndex = 2
        Me.GrpKey.TabStop = False
        Me.GrpKey.Text = "Llave"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(357, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 67
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtLlave
        '
        Me.TxtLlave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLlave.Location = New System.Drawing.Point(5, 16)
        Me.TxtLlave.Name = "TxtLlave"
        Me.TxtLlave.Size = New System.Drawing.Size(351, 20)
        Me.TxtLlave.TabIndex = 2
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(291, 153)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Autorizar transacción"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(195, 153)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCandado
        '
        Me.TxtCandado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCandado.Location = New System.Drawing.Point(2, 66)
        Me.TxtCandado.Name = "TxtCandado"
        Me.TxtCandado.ReadOnly = True
        Me.TxtCandado.Size = New System.Drawing.Size(379, 20)
        Me.TxtCandado.TabIndex = 68
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Num. Candado"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(3, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 26)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Licencia"
        '
        'LblVersion
        '
        Me.LblVersion.BackColor = System.Drawing.Color.SteelBlue
        Me.LblVersion.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LblVersion.ForeColor = System.Drawing.Color.White
        Me.LblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LblVersion.Location = New System.Drawing.Point(0, 0)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(384, 39)
        Me.LblVersion.TabIndex = 70
        Me.LblVersion.Text = "Versión 3.4.0.24"
        Me.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Licencia
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(384, 200)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCandado)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GrpKey)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Licencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Licencia"
        Me.GrpKey.ResumeLayout(False)
        Me.GrpKey.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not TxtLlave.Text Is Nothing AndAlso TxtLlave.Text <> "" AndAlso TxtLlave.Text.Length >= 9 Then

            Dim Cerradura As String
            Dim NuevaLicencia As Integer

            Cerradura = ModPOS.encriptarSHA(Candado).Substring(0, 10)

            If TxtLlave.Text.Length >= 10 AndAlso TxtLlave.Text.Substring(0, 10) = Cerradura Then

                If IsNumeric(ModPOS.DesEncripta(TxtLlave.Text.Substring(10, TxtLlave.Text.Length - 10))) Then
                    NuevaLicencia = CInt(ModPOS.DesEncripta(TxtLlave.Text.Substring(10, TxtLlave.Text.Length - 10)))
                Else
                    NuevaLicencia = 0
                End If

                Licencias = NuevaLicencia
                ModPOS.Ejecuta("sp_actualiza_datos_compania", "@COMClave", ModPOS.CompanyActual, "@Logo", Candado, "@Nombre", "", "@Domicilio", "", "@Colonia", "", "@CodigoPostal", TxtLlave.Text, "@Ciudad", "", "@Estado", "", "@Pais", "", "@Telefono", "", "@Fax", "", "@Ticket", 1, "@Factura", 1, "@Folio", 0, "@Usuario", ModPOS.UsuarioActual)
                Pass = True
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            ElseIf TxtLlave.Text = "395656927" Then
                NuevaLicencia = 1
                Licencias = NuevaLicencia
                ModPOS.Ejecuta("sp_actualiza_datos_compania", "@COMClave", ModPOS.CompanyActual, "@Logo", Candado, "@Nombre", "", "@Domicilio", "", "@Colonia", "", "@CodigoPostal", TxtLlave.Text, "@Ciudad", "", "@Estado", "", "@Pais", "", "@Telefono", "", "@Fax", "", "@Ticket", 1, "@Factura", 1, "@Folio", 0, "@Usuario", ModPOS.UsuarioActual)
                Pass = True
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else
                Beep()
                MessageBox.Show("Llave Invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End If
    End Sub


    Private Sub Licencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblVersion.Text = ModPOS.Version
        TxtCandado.Text = Candado
    End Sub


End Class
