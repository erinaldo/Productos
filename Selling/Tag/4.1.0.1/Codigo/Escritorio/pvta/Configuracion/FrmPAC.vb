Public Class FrmPAC
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
    Friend WithEvents GrpCosto As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbTipoPAC As Selling.StoreCombo
    Friend WithEvents TxtCustomerKey As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtServidorTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtServidorCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtTimbres As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPAC))
        Me.GrpCosto = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TxtTimbres = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TxtUserId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoPAC = New Selling.StoreCombo()
        Me.TxtCustomerKey = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtServidorTimbrado = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtServidorCancelacion = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.GrpCosto.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCosto
        '
        Me.GrpCosto.Controls.Add(Me.PictureBox7)
        Me.GrpCosto.Controls.Add(Me.Label2)
        Me.GrpCosto.Controls.Add(Me.TxtRFC)
        Me.GrpCosto.Controls.Add(Me.PictureBox6)
        Me.GrpCosto.Controls.Add(Me.TxtTimbres)
        Me.GrpCosto.Controls.Add(Me.Label9)
        Me.GrpCosto.Controls.Add(Me.PictureBox5)
        Me.GrpCosto.Controls.Add(Me.TxtUserId)
        Me.GrpCosto.Controls.Add(Me.Label1)
        Me.GrpCosto.Controls.Add(Me.PictureBox3)
        Me.GrpCosto.Controls.Add(Me.PictureBox2)
        Me.GrpCosto.Controls.Add(Me.PictureBox1)
        Me.GrpCosto.Controls.Add(Me.PictureBox4)
        Me.GrpCosto.Controls.Add(Me.cmbTipoPAC)
        Me.GrpCosto.Controls.Add(Me.TxtCustomerKey)
        Me.GrpCosto.Controls.Add(Me.Label32)
        Me.GrpCosto.Controls.Add(Me.TxtServidorTimbrado)
        Me.GrpCosto.Controls.Add(Me.Label33)
        Me.GrpCosto.Controls.Add(Me.TxtServidorCancelacion)
        Me.GrpCosto.Controls.Add(Me.Label34)
        Me.GrpCosto.Controls.Add(Me.Label37)
        Me.GrpCosto.Location = New System.Drawing.Point(7, 7)
        Me.GrpCosto.Name = "GrpCosto"
        Me.GrpCosto.Size = New System.Drawing.Size(514, 208)
        Me.GrpCosto.TabIndex = 0
        Me.GrpCosto.TabStop = False
        Me.GrpCosto.Text = "PAC"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(102, 155)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox6.TabIndex = 139
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtTimbres
        '
        Me.TxtTimbres.Location = New System.Drawing.Point(120, 152)
        Me.TxtTimbres.Name = "TxtTimbres"
        Me.TxtTimbres.Size = New System.Drawing.Size(93, 20)
        Me.TxtTimbres.TabIndex = 137
        Me.TxtTimbres.Text = "0"
        Me.TxtTimbres.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtTimbres.Value = 0
        Me.TxtTimbres.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 15)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "No. Timbres"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(102, 48)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 136
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'TxtUserId
        '
        Me.TxtUserId.Location = New System.Drawing.Point(120, 48)
        Me.TxtUserId.Name = "TxtUserId"
        Me.TxtUserId.Size = New System.Drawing.Size(383, 20)
        Me.TxtUserId.TabIndex = 134
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "UserId"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(102, 105)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 133
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(103, 72)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 132
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(102, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(102, 132)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 130
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'cmbTipoPAC
        '
        Me.cmbTipoPAC.Location = New System.Drawing.Point(120, 21)
        Me.cmbTipoPAC.Name = "cmbTipoPAC"
        Me.cmbTipoPAC.Size = New System.Drawing.Size(161, 21)
        Me.cmbTipoPAC.TabIndex = 128
        '
        'TxtCustomerKey
        '
        Me.TxtCustomerKey.Location = New System.Drawing.Point(120, 72)
        Me.TxtCustomerKey.Name = "TxtCustomerKey"
        Me.TxtCustomerKey.Size = New System.Drawing.Size(383, 20)
        Me.TxtCustomerKey.TabIndex = 121
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(4, 105)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(112, 15)
        Me.Label32.TabIndex = 127
        Me.Label32.Text = "Servidor Timbrado"
        '
        'TxtServidorTimbrado
        '
        Me.TxtServidorTimbrado.Location = New System.Drawing.Point(120, 100)
        Me.TxtServidorTimbrado.Name = "TxtServidorTimbrado"
        Me.TxtServidorTimbrado.Size = New System.Drawing.Size(383, 20)
        Me.TxtServidorTimbrado.TabIndex = 122
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(4, 75)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(77, 15)
        Me.Label33.TabIndex = 126
        Me.Label33.Text = "CustomerKey"
        '
        'TxtServidorCancelacion
        '
        Me.TxtServidorCancelacion.Location = New System.Drawing.Point(120, 128)
        Me.TxtServidorCancelacion.Name = "TxtServidorCancelacion"
        Me.TxtServidorCancelacion.Size = New System.Drawing.Size(384, 20)
        Me.TxtServidorCancelacion.TabIndex = 123
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(4, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 15)
        Me.Label34.TabIndex = 125
        Me.Label34.Text = "Tipo PAC"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(4, 131)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(112, 15)
        Me.Label37.TabIndex = 124
        Me.Label37.Text = "Servidor Cancelación"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(335, 221)
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
        Me.BtnAgregar.Location = New System.Drawing.Point(431, 221)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(119, 178)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(384, 20)
        Me.TxtRFC.TabIndex = 140
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "RFC PAC"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(102, 181)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox7.TabIndex = 142
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'FrmPAC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(529, 266)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpCosto)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 204)
        Me.Name = "FrmPAC"
        Me.Text = "Proveedor Autorizado de Certificación"
        Me.GrpCosto.ResumeLayout(False)
        Me.GrpCosto.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
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

        With Me.cmbTipoPAC
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "PAC"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        bLoad = True

        If cmbTipoPAC.SelectedValue = 2 OrElse cmbTipoPAC.SelectedValue = 3 OrElse cmbTipoPAC.SelectedValue = 4 Then
            TxtUserId.Enabled = True
        Else
            TxtUserId.Enabled = False
            TxtUserId.Text = ""
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If cmbTipoPAC.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCustomerKey.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtUserId.Text = "" AndAlso (cmbTipoPAC.SelectedValue = 2 OrElse cmbTipoPAC.SelectedValue = 3 OrElse cmbTipoPAC.SelectedValue = 4) Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtServidorTimbrado.Text = "" AndAlso cmbTipoPAC.SelectedValue <> 4 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtServidorCancelacion.Text = "" AndAlso cmbTipoPAC.SelectedValue <> 4 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtTimbres.Text <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtRFC.Text = "" Then
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
            ModPOS.Compania.AddPAC(Me.cmbTipoPAC.SelectedValue, cmbTipoPAC.SelectedItem(1), Me.TxtCustomerKey.Text, Me.TxtServidorTimbrado.Text, Me.TxtServidorCancelacion.Text, TxtUserId.Text, TxtTimbres.Text, TxtRFC.Text)
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

  
  

    Private Sub cmbTipoPAC_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoPAC.SelectedValueChanged
        If Not cmbTipoPAC.SelectedValue Is Nothing AndAlso bLoad = True Then
            If cmbTipoPAC.SelectedValue = 2 OrElse cmbTipoPAC.SelectedValue = 3 OrElse cmbTipoPAC.SelectedValue = 4 Then
                TxtUserId.Enabled = True
            Else
                TxtUserId.Enabled = False
                TxtUserId.Text = ""
            End If
        End If
    End Sub
End Class
