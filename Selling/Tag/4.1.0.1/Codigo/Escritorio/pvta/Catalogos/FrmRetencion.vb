Public Class FrmRetencion
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
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpMultiproducto As System.Windows.Forms.GroupBox
    Friend WithEvents txtTasa As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cmbImpuesto As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRetencion))
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.txtTasa = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.cmbImpuesto = New Selling.StoreCombo()
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Controls.Add(Me.cmbImpuesto)
        Me.GrpMultiproducto.Controls.Add(Me.txtTasa)
        Me.GrpMultiproducto.Controls.Add(Me.LblNombre)
        Me.GrpMultiproducto.Controls.Add(Me.LblClave)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox1)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox2)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(7, 4)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(270, 83)
        Me.GrpMultiproducto.TabIndex = 1
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Retención"
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(6, 51)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Tasa"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 21)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Impuesto"
        '
        'txtTasa
        '
        Me.txtTasa.DecimalDigits = 6
        Me.txtTasa.Location = New System.Drawing.Point(69, 48)
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(172, 20)
        Me.txtTasa.TabIndex = 95
        Me.txtTasa.Text = "0.000000"
        Me.txtTasa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtTasa.Value = 0.0R
        Me.txtTasa.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(247, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(248, 51)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(91, 95)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(187, 95)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbImpuesto
        '
        Me.cmbImpuesto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbImpuesto.Location = New System.Drawing.Point(68, 18)
        Me.cmbImpuesto.Name = "cmbImpuesto"
        Me.cmbImpuesto.Size = New System.Drawing.Size(173, 21)
        Me.cmbImpuesto.TabIndex = 96
        '
        'FrmRetencion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(287, 141)
        Me.Controls.Add(Me.GrpMultiproducto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRetencion"
        Me.Text = "Detalle Retención"
        Me.GrpMultiproducto.ResumeLayout(False)
        Me.GrpMultiproducto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public Impuesto As String
    Public Tasa As Decimal
  

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private aMarca() As String
    Private aModelo() As String

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If cmbImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()

        End If

        If CDec(txtTasa.Text) <= 0 Then
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

    Private Sub FrmRetencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        With Me.cmbImpuesto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impuesto"
            .llenar()
        End With
      

    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    Impuesto = cmbImpuesto.SelectedValue
                    Tasa = txtTasa.Text




                    ModPOS.Producto.AddRetencion(Impuesto, cmbImpuesto.SelectedItem(1), Tasa)

                    cmbImpuesto.SelectedValue = 0
                    txtTasa.Text = 0
            End Select


        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmRetencion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Retencion.Dispose()
        ModPOS.Retencion = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



End Class
