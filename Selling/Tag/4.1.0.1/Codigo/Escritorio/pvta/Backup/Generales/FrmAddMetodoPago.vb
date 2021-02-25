Public Class FrmAddMetodoPago
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
    Friend WithEvents GrpDenominacion As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents CmbMetodoPago As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents cmbBanco As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkPreferido As Selling.ChkStatus
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddMetodoPago))
        Me.GrpDenominacion = New System.Windows.Forms.GroupBox
        Me.cmbBanco = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkPreferido = New Selling.ChkStatus(Me.components)
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.LblCodigoBarras = New System.Windows.Forms.Label
        Me.CmbMetodoPago = New Selling.StoreCombo
        Me.LblUnidadVenta = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpDenominacion.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDenominacion
        '
        Me.GrpDenominacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDenominacion.Controls.Add(Me.cmbBanco)
        Me.GrpDenominacion.Controls.Add(Me.Label1)
        Me.GrpDenominacion.Controls.Add(Me.ChkPreferido)
        Me.GrpDenominacion.Controls.Add(Me.ChkEstado)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox2)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox1)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox3)
        Me.GrpDenominacion.Controls.Add(Me.TxtReferencia)
        Me.GrpDenominacion.Controls.Add(Me.LblCodigoBarras)
        Me.GrpDenominacion.Controls.Add(Me.CmbMetodoPago)
        Me.GrpDenominacion.Controls.Add(Me.LblUnidadVenta)
        Me.GrpDenominacion.Location = New System.Drawing.Point(7, 7)
        Me.GrpDenominacion.Name = "GrpDenominacion"
        Me.GrpDenominacion.Size = New System.Drawing.Size(354, 154)
        Me.GrpDenominacion.TabIndex = 0
        Me.GrpDenominacion.TabStop = False
        Me.GrpDenominacion.Text = "Metodo de Pago"
        '
        'cmbBanco
        '
        Me.cmbBanco.Location = New System.Drawing.Point(109, 50)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(174, 21)
        Me.cmbBanco.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Banco"
        '
        'ChkPreferido
        '
        Me.ChkPreferido.Location = New System.Drawing.Point(109, 120)
        Me.ChkPreferido.Name = "ChkPreferido"
        Me.ChkPreferido.Size = New System.Drawing.Size(104, 22)
        Me.ChkPreferido.TabIndex = 92
        Me.ChkPreferido.Text = "Preferido"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(222, 120)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(61, 22)
        Me.ChkEstado.TabIndex = 3
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(288, 55)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(287, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(287, 88)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 89
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(109, 84)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(174, 20)
        Me.TxtReferencia.TabIndex = 1
        '
        'LblCodigoBarras
        '
        Me.LblCodigoBarras.Location = New System.Drawing.Point(4, 87)
        Me.LblCodigoBarras.Name = "LblCodigoBarras"
        Me.LblCodigoBarras.Size = New System.Drawing.Size(95, 17)
        Me.LblCodigoBarras.TabIndex = 87
        Me.LblCodigoBarras.Text = "No. Cta o Tarjeta"
        '
        'CmbMetodoPago
        '
        Me.CmbMetodoPago.Location = New System.Drawing.Point(109, 16)
        Me.CmbMetodoPago.Name = "CmbMetodoPago"
        Me.CmbMetodoPago.Size = New System.Drawing.Size(174, 21)
        Me.CmbMetodoPago.TabIndex = 0
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(6, 19)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(45, 14)
        Me.LblUnidadVenta.TabIndex = 86
        Me.LblUnidadVenta.Text = "Tipo"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(175, 170)
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
        Me.BtnAgregar.Location = New System.Drawing.Point(271, 170)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddMetodoPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(367, 213)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpDenominacion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 204)
        Me.Name = "FrmAddMetodoPago"
        Me.Text = "Metodo de Pago"
        Me.GrpDenominacion.ResumeLayout(False)
        Me.GrpDenominacion.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public FormOrigen As String = ""
    Public Clave As String = ""
    Public Padre As String

    Public MTPClave As String
    Public BNKClave As String
    Public MetodoPago As Integer
    Public Preferido As Integer
    Public Referencia As String
    Public Estado As Integer

    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private bload As Boolean = False



    Private Sub FrmAddMetodoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        With Me.CmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        With cmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With

        If CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7 Then
            cmbBanco.Visible = False
            TxtReferencia.Visible = False
            TxtReferencia.Text = ""
        Else
            cmbBanco.Visible = True
            TxtReferencia.Visible = True
        End If

        If Padre = "Agregar" Then
            MTPClave = ModPOS.obtenerLlave
        Else
            CmbMetodoPago.SelectedValue = MetodoPago
            CmbMetodoPago.Enabled = False
            cmbBanco.SelectedValue = BNKClave
            cmbBanco.Enabled = False
            TxtReferencia.Text = Referencia
            ChkEstado.Estado = Estado
            ChkPreferido.Estado = Preferido
        End If

        bload = True
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

      

        If Not CmbMetodoPago.SelectedValue Is Nothing AndAlso Not (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) AndAlso Me.cmbBanco.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Not CmbMetodoPago.SelectedValue Is Nothing AndAlso Not (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) AndAlso TxtReferencia.Text = "" Then
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then

            If Not (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
                If TxtReferencia.Text.Length < 4 Then
                    Beep()
                    MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            Else
                TxtReferencia.Text = ""
            End If


            Dim BancoClave As String 
            Dim Banco As String

            If cmbBanco.SelectedValue Is Nothing OrElse (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
                Banco = ""
                BancoClave = ""
            Else
                BancoClave = cmbBanco.SelectedValue
                Banco = cmbBanco.SelectedItem(1)
            End If

            If Me.FormOrigen = "" Then
                Cliente.AddMetodoPago(MTPClave, CmbMetodoPago.SelectedValue, CmbMetodoPago.SelectedItem(1), BancoClave, Banco, TxtReferencia.Text.Trim.ToUpper, ChkPreferido.GetEstado, ChkEstado.GetEstado)

                If Padre = "Agregar" Then
                    MTPClave = ModPOS.obtenerLlave
                    TxtReferencia.Text = ""
                Else
                    Me.Close()
                End If
            Else
                ModPOS.MetodoPago.AddMetodoPago(CmbMetodoPago.SelectedValue, CmbMetodoPago.SelectedItem(1), BancoClave, Banco, TxtReferencia.Text.Trim.ToUpper)
                Me.Close()
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub TxtDenominacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub CmbMetodoPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMetodoPago.SelectedIndexChanged
        If bload = True AndAlso (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
            cmbBanco.Visible = False
            TxtReferencia.Visible = False
            TxtReferencia.Text = ""
        Else
            cmbBanco.Visible = True
            TxtReferencia.Visible = True
        End If
    End Sub
End Class
