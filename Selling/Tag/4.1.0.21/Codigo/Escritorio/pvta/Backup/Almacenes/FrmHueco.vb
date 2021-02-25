Public Class FrmHueco
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
    Friend WithEvents LblAlto As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoEstado As Selling.StoreCombo
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents TxtAlto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHueco))
        Me.LblAlto = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtAlto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cmbTipoEstado = New Selling.StoreCombo
        Me.LblEstado = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblAlto
        '
        Me.LblAlto.Location = New System.Drawing.Point(0, 18)
        Me.LblAlto.Name = "LblAlto"
        Me.LblAlto.Size = New System.Drawing.Size(120, 23)
        Me.LblAlto.TabIndex = 50
        Me.LblAlto.Text = "Alto del Hueco"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(94, 132)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancela y cierra ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Icon = CType(resources.GetObject("BtnAceptar.Icon"), System.Drawing.Icon)
        Me.BtnAceptar.Location = New System.Drawing.Point(190, 132)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 5
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guarda cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(224, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(224, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Metros"
        '
        'TxtAlto
        '
        Me.TxtAlto.DecimalDigits = 2
        Me.TxtAlto.Location = New System.Drawing.Point(112, 16)
        Me.TxtAlto.Name = "TxtAlto"
        Me.TxtAlto.Size = New System.Drawing.Size(96, 20)
        Me.TxtAlto.TabIndex = 1
        Me.TxtAlto.Text = "0.00"
        Me.TxtAlto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtAlto.Value = 0
        Me.TxtAlto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'cmbTipoEstado
        '
        Me.cmbTipoEstado.Location = New System.Drawing.Point(112, 89)
        Me.cmbTipoEstado.Name = "cmbTipoEstado"
        Me.cmbTipoEstado.Size = New System.Drawing.Size(168, 21)
        Me.cmbTipoEstado.TabIndex = 4
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(0, 94)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(96, 16)
        Me.LblEstado.TabIndex = 54
        Me.LblEstado.Text = "Estado"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(112, 51)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(96, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 23)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Aprovechamiento"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(216, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 23)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "%"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(224, 53)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 59
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(224, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 52
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'FrmHueco
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(284, 177)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.cmbTipoEstado)
        Me.Controls.Add(Me.LblEstado)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TxtAlto)
        Me.Controls.Add(Me.LblAlto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmHueco"
        Me.Text = "Modificar Hueco"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public iEstado As Integer
    Public dAlto As Double
    Public dCarga As Double
    Public iPorc As Integer
    Public sEstructura As String
    Public sHueco As String
    Public iColumna As Integer
    Public sNivel As String

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If CDbl(Me.TxtAlto.Text) <> dAlto OrElse Me.cmbTipoEstado.SelectedValue <> iEstado Then
            If validaForm() Then
                Dim Con As String = ModPOS.BDConexion


                If ModPOS.SiExite(Con, "sp_hueco_vacio", "@Estructura", sEstructura, "@Columna", iColumna, "@cNivel", sNivel) = 0 Then

                    'dCarga = CDbl(TxtCarga.Text)
                    dAlto = CDbl(TxtAlto.Text)
                    iEstado = cmbTipoEstado.SelectedValue
                    iPorc = CInt(NumericUpDown1.Value)

                    ModPOS.Update_Hueco(Me)

                    Me.Close()

                Else
                    MessageBox.Show("No es posible modificar el hueco debido a que existen ubicaciones ocupadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub FrmHueco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
    End Sub

    Private Sub FrmHueco_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Hueco.Dispose()
        ModPOS.Hueco = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtAlto.Text = "" OrElse CDbl(Me.TxtAlto.Text) = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        'If Me.TxtCarga.Text = "" OrElse CDbl(Me.TxtCarga.Text) = 0 Then
        '    i += 1
        '    reloj = New parpadea(Me.alerta(1))
        '    reloj.Enabled = True
        '    reloj.Start()
        'End If

        If CInt(Me.NumericUpDown1.Value) <= 0 OrElse CInt(Me.NumericUpDown1.Value) > 100 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False

        Else
            Me.alerta(0).Visible = False
            Return True
        End If
    End Function


  
End Class
