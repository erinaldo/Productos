Public Class FrmMesa
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
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFase As Selling.StoreCombo
    Friend WithEvents txtNombre As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMesa))
        Me.GrpCuenta = New System.Windows.Forms.GroupBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtNombre = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.cmbFase = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpCuenta.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCuenta
        '
        Me.GrpCuenta.Controls.Add(Me.PictureBox7)
        Me.GrpCuenta.Controls.Add(Me.Label5)
        Me.GrpCuenta.Controls.Add(Me.txtNombre)
        Me.GrpCuenta.Controls.Add(Me.cmbFase)
        Me.GrpCuenta.Controls.Add(Me.PictureBox1)
        Me.GrpCuenta.Controls.Add(Me.LblNombre)
        Me.GrpCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GrpCuenta.Location = New System.Drawing.Point(7, 7)
        Me.GrpCuenta.Name = "GrpCuenta"
        Me.GrpCuenta.Size = New System.Drawing.Size(346, 104)
        Me.GrpCuenta.TabIndex = 7
        Me.GrpCuenta.TabStop = False
        Me.GrpCuenta.Text = "Mesa"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(257, 70)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox7.TabIndex = 102
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 12)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Estado"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(91, 29)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(161, 20)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'cmbFase
        '
        Me.cmbFase.Location = New System.Drawing.Point(91, 65)
        Me.cmbFase.Name = "cmbFase"
        Me.cmbFase.Size = New System.Drawing.Size(161, 21)
        Me.cmbFase.TabIndex = 100
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(257, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 32)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(87, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Clave"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(168, 117)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(264, 117)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMesa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(360, 164)
        Me.Controls.Add(Me.GrpCuenta)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMesa"
        Me.Text = "Mesa"
        Me.GrpCuenta.ResumeLayout(False)
        Me.GrpCuenta.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public MESClave As String
    Public Clave As String
    Public Estado As Integer = 1

    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.txtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.txtNombre.Text.Length > 20 Then
            Me.txtNombre.Text = Me.txtNombre.Text.Substring(0, 20)

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

    Private Sub FrmCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        txtNombre.Text = Clave

        With Me.cmbFase
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Mesa"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With


        cmbFase.SelectedValue = Estado
        txtNombre.Focus()

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    MESClave = ModPOS.obtenerLlave

                    Clave = UCase(Trim(Me.txtNombre.Text))
                    Estado = cmbFase.SelectedValue

                    ModPOS.Pisos.AddMesa(MESClave, Clave, Estado, cmbFase.SelectedItem(1).ToString)


                    Clave = ""
                    Estado = 1
                    txtNombre.Text = Clave
                    cmbFase.SelectedValue = Estado

                    txtNombre.Focus()

                Case "Modificar"
                    If Not (Clave = UCase(Trim(Me.txtNombre.Text)) AndAlso Estado = cmbFase.SelectedValue) Then
                        Me.Clave = UCase(Trim(Me.txtNombre.Text))
                        Me.Estado = cmbFase.SelectedValue
                        ModPOS.Pisos.AddMesa(MESClave, Clave, Estado, cmbFase.SelectedItem(1).ToString)
                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

End Class
