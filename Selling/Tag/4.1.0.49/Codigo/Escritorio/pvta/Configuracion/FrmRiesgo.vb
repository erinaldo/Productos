Public Class FrmRiesgo
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
    Friend WithEvents GrpRiesgo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtValorPedido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPorcPedido As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ChkVerificacion As Selling.ChkStatus
    Friend WithEvents ChkLimite As Selling.ChkStatus
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCreditoPreventa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents txtDiasPreventa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRiesgo))
        Me.GrpRiesgo = New System.Windows.Forms.GroupBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.txtCreditoPreventa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.txtDiasPreventa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPorcPedido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ChkVerificacion = New Selling.ChkStatus(Me.components)
        Me.ChkLimite = New Selling.ChkStatus(Me.components)
        Me.TxtValorPedido = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpRiesgo.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpRiesgo
        '
        Me.GrpRiesgo.Controls.Add(Me.PictureBox7)
        Me.GrpRiesgo.Controls.Add(Me.txtCreditoPreventa)
        Me.GrpRiesgo.Controls.Add(Me.Label4)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox6)
        Me.GrpRiesgo.Controls.Add(Me.txtDiasPreventa)
        Me.GrpRiesgo.Controls.Add(Me.Label3)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox5)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox4)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox3)
        Me.GrpRiesgo.Controls.Add(Me.txtDias)
        Me.GrpRiesgo.Controls.Add(Me.Label2)
        Me.GrpRiesgo.Controls.Add(Me.txtPorcPedido)
        Me.GrpRiesgo.Controls.Add(Me.ChkVerificacion)
        Me.GrpRiesgo.Controls.Add(Me.ChkLimite)
        Me.GrpRiesgo.Controls.Add(Me.TxtValorPedido)
        Me.GrpRiesgo.Controls.Add(Me.Label9)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox2)
        Me.GrpRiesgo.Controls.Add(Me.TxtClave)
        Me.GrpRiesgo.Controls.Add(Me.Label1)
        Me.GrpRiesgo.Controls.Add(Me.PictureBox1)
        Me.GrpRiesgo.Controls.Add(Me.TxtDescripcion)
        Me.GrpRiesgo.Controls.Add(Me.Label34)
        Me.GrpRiesgo.Controls.Add(Me.Label37)
        Me.GrpRiesgo.Location = New System.Drawing.Point(7, 7)
        Me.GrpRiesgo.Name = "GrpRiesgo"
        Me.GrpRiesgo.Size = New System.Drawing.Size(514, 269)
        Me.GrpRiesgo.TabIndex = 0
        Me.GrpRiesgo.TabStop = False
        Me.GrpRiesgo.Text = "Clase"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(112, 237)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox7.TabIndex = 154
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'txtCreditoPreventa
        '
        Me.txtCreditoPreventa.Location = New System.Drawing.Point(138, 234)
        Me.txtCreditoPreventa.Name = "txtCreditoPreventa"
        Me.txtCreditoPreventa.Size = New System.Drawing.Size(93, 20)
        Me.txtCreditoPreventa.TabIndex = 152
        Me.txtCreditoPreventa.Text = "-1.00"
        Me.txtCreditoPreventa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtCreditoPreventa.Value = -1.0R
        Me.txtCreditoPreventa.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 237)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 15)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Limite Crédito Preventa"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(110, 209)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox6.TabIndex = 151
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'txtDiasPreventa
        '
        Me.txtDiasPreventa.Location = New System.Drawing.Point(137, 207)
        Me.txtDiasPreventa.Name = "txtDiasPreventa"
        Me.txtDiasPreventa.Size = New System.Drawing.Size(93, 20)
        Me.txtDiasPreventa.TabIndex = 149
        Me.txtDiasPreventa.Text = "-1"
        Me.txtDiasPreventa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtDiasPreventa.Value = -1
        Me.txtDiasPreventa.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 15)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Dias de Crédito Preventa"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(111, 134)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox5.TabIndex = 148
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(111, 108)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox4.TabIndex = 147
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(111, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox3.TabIndex = 146
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(138, 132)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(93, 20)
        Me.txtDias.TabIndex = 5
        Me.txtDias.Text = "-1"
        Me.txtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtDias.Value = -1
        Me.txtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 15)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "Dias de Antiguedad Max."
        '
        'txtPorcPedido
        '
        Me.txtPorcPedido.Location = New System.Drawing.Point(137, 105)
        Me.txtPorcPedido.Name = "txtPorcPedido"
        Me.txtPorcPedido.Size = New System.Drawing.Size(93, 20)
        Me.txtPorcPedido.TabIndex = 4
        Me.txtPorcPedido.Text = "-1.00"
        Me.txtPorcPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtPorcPedido.Value = -1.0R
        Me.txtPorcPedido.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'ChkVerificacion
        '
        Me.ChkVerificacion.BackColor = System.Drawing.Color.Transparent
        Me.ChkVerificacion.Location = New System.Drawing.Point(138, 181)
        Me.ChkVerificacion.Name = "ChkVerificacion"
        Me.ChkVerificacion.Size = New System.Drawing.Size(217, 22)
        Me.ChkVerificacion.TabIndex = 7
        Me.ChkVerificacion.Text = "Valida Fecha de Verificación"
        Me.ChkVerificacion.UseVisualStyleBackColor = False
        '
        'ChkLimite
        '
        Me.ChkLimite.BackColor = System.Drawing.Color.Transparent
        Me.ChkLimite.Checked = True
        Me.ChkLimite.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkLimite.Location = New System.Drawing.Point(138, 158)
        Me.ChkLimite.Name = "ChkLimite"
        Me.ChkLimite.Size = New System.Drawing.Size(166, 22)
        Me.ChkLimite.TabIndex = 6
        Me.ChkLimite.Text = "Valida Limite Crédito"
        Me.ChkLimite.UseVisualStyleBackColor = False
        '
        'TxtValorPedido
        '
        Me.TxtValorPedido.Location = New System.Drawing.Point(137, 74)
        Me.TxtValorPedido.Name = "TxtValorPedido"
        Me.TxtValorPedido.Size = New System.Drawing.Size(93, 20)
        Me.TxtValorPedido.TabIndex = 3
        Me.TxtValorPedido.Text = "-1.00"
        Me.TxtValorPedido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtValorPedido.Value = -1.0R
        Me.TxtValorPedido.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(9, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 15)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "Valor Max. Pedido"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(111, 51)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox2.TabIndex = 136
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(137, 19)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(94, 20)
        Me.TxtClave.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Descripción"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(111, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(137, 48)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(341, 20)
        Me.TxtDescripcion.TabIndex = 2
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(9, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 15)
        Me.Label34.TabIndex = 125
        Me.Label34.Text = "Clave"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(9, 108)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(112, 15)
        Me.Label37.TabIndex = 124
        Me.Label37.Text = "Porc.  Max. Pedidos Vencidos"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(335, 282)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(431, 282)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmRiesgo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(529, 327)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpRiesgo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 204)
        Me.Name = "FrmRiesgo"
        Me.Text = "Clase de Riesgo"
        Me.GrpRiesgo.ResumeLayout(False)
        Me.GrpRiesgo.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public COMClave As String
    Public Padre As String

    Private alerta(6) As PictureBox
    Private reloj As parpadea
    Private dtImpuesto, dtImpuestoProd As DataTable
    Private bLoad As Boolean = False

    Private Sub FrmPAC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
       
       
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(TxtValorPedido.Text) < -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(txtPorcPedido.Text) < -1 OrElse CDbl(txtPorcPedido.Text) > 100 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(txtDias.Text) < -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(txtDiasPreventa.Text) < -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CDbl(txtCreditoPreventa.Text) < -1 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then
            ModPOS.Compania.AddRiesgo(TxtClave.Text.Trim, TxtDescripcion.Text.Trim, ChkLimite.Checked, CDbl(TxtValorPedido.Text), ChkVerificacion.Checked, CDbl(txtPorcPedido.Text), CInt(txtDias.Text), CInt(txtDiasPreventa.Text), CDec(txtCreditoPreventa.Text))
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

End Class
