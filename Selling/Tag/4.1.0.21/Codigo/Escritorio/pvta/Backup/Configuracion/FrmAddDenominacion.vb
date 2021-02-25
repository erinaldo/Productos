Public Class FrmAddDenominacion
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
    Friend WithEvents TxtDenominacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblFactor As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents CmbTipoDenominacion As Selling.StoreCombo
    Friend WithEvents LblUnidadVenta As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddDenominacion))
        Me.GrpDenominacion = New System.Windows.Forms.GroupBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtDenominacion = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblFactor = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblCodigoBarras = New System.Windows.Forms.Label
        Me.CmbTipoDenominacion = New Selling.StoreCombo
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
        Me.GrpDenominacion.Controls.Add(Me.ChkEstado)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox2)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox1)
        Me.GrpDenominacion.Controls.Add(Me.PictureBox3)
        Me.GrpDenominacion.Controls.Add(Me.TxtDenominacion)
        Me.GrpDenominacion.Controls.Add(Me.LblFactor)
        Me.GrpDenominacion.Controls.Add(Me.TxtClave)
        Me.GrpDenominacion.Controls.Add(Me.LblCodigoBarras)
        Me.GrpDenominacion.Controls.Add(Me.CmbTipoDenominacion)
        Me.GrpDenominacion.Controls.Add(Me.LblUnidadVenta)
        Me.GrpDenominacion.Location = New System.Drawing.Point(7, 7)
        Me.GrpDenominacion.Name = "GrpDenominacion"
        Me.GrpDenominacion.Size = New System.Drawing.Size(293, 120)
        Me.GrpDenominacion.TabIndex = 0
        Me.GrpDenominacion.TabStop = False
        Me.GrpDenominacion.Text = "Denominación"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(79, 92)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(68, 22)
        Me.ChkEstado.TabIndex = 3
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(152, 68)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(203, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(203, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 89
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtDenominacion
        '
        Me.TxtDenominacion.Location = New System.Drawing.Point(79, 68)
        Me.TxtDenominacion.Name = "TxtDenominacion"
        Me.TxtDenominacion.Size = New System.Drawing.Size(68, 20)
        Me.TxtDenominacion.TabIndex = 2
        Me.TxtDenominacion.Text = "0.00"
        Me.TxtDenominacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtDenominacion.Value = 0
        Me.TxtDenominacion.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblFactor
        '
        Me.LblFactor.Location = New System.Drawing.Point(8, 71)
        Me.LblFactor.Name = "LblFactor"
        Me.LblFactor.Size = New System.Drawing.Size(69, 14)
        Me.LblFactor.TabIndex = 88
        Me.LblFactor.Text = "Importe"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(79, 44)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(119, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblCodigoBarras
        '
        Me.LblCodigoBarras.Location = New System.Drawing.Point(8, 46)
        Me.LblCodigoBarras.Name = "LblCodigoBarras"
        Me.LblCodigoBarras.Size = New System.Drawing.Size(80, 17)
        Me.LblCodigoBarras.TabIndex = 87
        Me.LblCodigoBarras.Text = "Referencia"
        '
        'CmbTipoDenominacion
        '
        Me.CmbTipoDenominacion.Location = New System.Drawing.Point(79, 16)
        Me.CmbTipoDenominacion.Name = "CmbTipoDenominacion"
        Me.CmbTipoDenominacion.Size = New System.Drawing.Size(120, 21)
        Me.CmbTipoDenominacion.TabIndex = 0
        '
        'LblUnidadVenta
        '
        Me.LblUnidadVenta.Location = New System.Drawing.Point(8, 19)
        Me.LblUnidadVenta.Name = "LblUnidadVenta"
        Me.LblUnidadVenta.Size = New System.Drawing.Size(45, 14)
        Me.LblUnidadVenta.TabIndex = 86
        Me.LblUnidadVenta.Text = "Tipo"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(114, 133)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(210, 133)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddDenominacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(303, 172)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpDenominacion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 204)
        Me.Name = "FrmAddDenominacion"
        Me.Text = "Denominación de Moneda"
        Me.GrpDenominacion.ResumeLayout(False)
        Me.GrpDenominacion.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Clave As String = ""
    Public Padre As String
    Public MNDClave As String

    Public Denominacion As Integer
    Public Referencia As String
    Public Importe As Double
    Public Estado As Integer

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Sub FrmAddDenominacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        With Me.CmbTipoDenominacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoDenominacion"
            .llenar()
        End With

        If Padre = "Agregar" Then
            MNDClave = ModPOS.obtenerLlave
        Else
            CmbTipoDenominacion.Enabled = False
            CmbTipoDenominacion.SelectedValue = Denominacion
            TxtClave.Text = Referencia
            TxtDenominacion.Text = Importe
            ChkEstado.Estado = Estado
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipoDenominacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" AndAlso Clave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text = "" AndAlso Clave <> "" Then
            TxtClave.Text = Clave
        End If

        If CDbl(TxtDenominacion.Text) <= 0 Then
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then


            Moneda.AddDenominacion(MNDClave, CmbTipoDenominacion.SelectedValue, CmbTipoDenominacion.SelectedItem(1), TxtClave.Text, TxtDenominacion.Text, ChkEstado.GetEstado)

            If Padre = "Agregar" Then
                MNDClave = ModPOS.obtenerLlave
                TxtClave.Text = ""
                TxtDenominacion.Text = ""
            Else
                Me.Close()
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

  
    Private Sub TxtDenominacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDenominacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub
End Class
