Public Class FrmAddModificador
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
    Friend WithEvents GrpPasillo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtOrden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblFactor As System.Windows.Forms.Label
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LblCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtAbreviatura As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddModificador))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.txtAbreviatura = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtOrden = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblFactor = New System.Windows.Forms.Label
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.LblCodigoBarras = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpPasillo.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.Label4)
        Me.GrpPasillo.Controls.Add(Me.PictureBox3)
        Me.GrpPasillo.Controls.Add(Me.txtAbreviatura)
        Me.GrpPasillo.Controls.Add(Me.Label1)
        Me.GrpPasillo.Controls.Add(Me.ChkEstado)
        Me.GrpPasillo.Controls.Add(Me.PictureBox2)
        Me.GrpPasillo.Controls.Add(Me.PictureBox1)
        Me.GrpPasillo.Controls.Add(Me.TxtOrden)
        Me.GrpPasillo.Controls.Add(Me.LblFactor)
        Me.GrpPasillo.Controls.Add(Me.TxtDescripcion)
        Me.GrpPasillo.Controls.Add(Me.LblCodigoBarras)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 7)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(348, 112)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Detalle"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(254, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(187, 50)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 95
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'txtAbreviatura
        '
        Me.txtAbreviatura.Location = New System.Drawing.Point(85, 48)
        Me.txtAbreviatura.Name = "txtAbreviatura"
        Me.txtAbreviatura.Size = New System.Drawing.Size(98, 20)
        Me.txtAbreviatura.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Abreviatura"
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(277, 19)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(58, 23)
        Me.ChkEstado.TabIndex = 4
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(251, 79)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(155, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 89
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtOrden
        '
        Me.TxtOrden.Location = New System.Drawing.Point(85, 19)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(65, 20)
        Me.TxtOrden.TabIndex = 3
        Me.TxtOrden.Text = "1"
        Me.TxtOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtOrden.Value = 1
        Me.TxtOrden.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'LblFactor
        '
        Me.LblFactor.Location = New System.Drawing.Point(13, 21)
        Me.LblFactor.Name = "LblFactor"
        Me.LblFactor.Size = New System.Drawing.Size(66, 15)
        Me.LblFactor.TabIndex = 88
        Me.LblFactor.Text = "Orden"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(85, 76)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(161, 20)
        Me.TxtDescripcion.TabIndex = 2
        '
        'LblCodigoBarras
        '
        Me.LblCodigoBarras.Location = New System.Drawing.Point(13, 79)
        Me.LblCodigoBarras.Name = "LblCodigoBarras"
        Me.LblCodigoBarras.Size = New System.Drawing.Size(80, 17)
        Me.LblCodigoBarras.TabIndex = 87
        Me.LblCodigoBarras.Text = "Descripción"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(169, 125)
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
        Me.BtnAgregar.Location = New System.Drawing.Point(265, 125)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAddModificador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(367, 167)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddModificador"
        Me.Text = "Modificador Detalle"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public DMDClave As String = ""
    Public Orden As Integer = 1
    Public Abreviatura As String
    Public Descripcion As String
    Public Estado As Integer = 1

    Public Padre As String


    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Sub FrmAddModificador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        If Padre = "Agregar" Then
            DMDClave = ModPOS.obtenerLlave
        End If
        txtAbreviatura.Text = Abreviatura
        TxtOrden.Text = Orden
        TxtDescripcion.Text = Descripcion
        ChkEstado.Estado = Estado
    End Sub

    Private Sub FrmAddModificador_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddModificador.Dispose()
        ModPOS.AddModificador = Nothing
    End Sub

    Private Sub Reinicializa()
        DMDClave = ModPOS.obtenerLlave
        Orden = CInt(TxtOrden.Text) + 1
        Abreviatura = ""
        Descripcion = ""
        Estado = 1
        DMDClave = ModPOS.obtenerLlave
        TxtOrden.Text = Orden
        txtAbreviatura.Text = Abreviatura
        TxtDescripcion.Text = Descripcion
        ChkEstado.Estado = Estado
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If CInt(TxtOrden.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtAbreviatura.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDescripcion.Text = "" Then
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
            If Not ModPOS.Modificador Is Nothing Then
                ModPOS.Modificador.AddNuevoModificador(DMDClave, TxtOrden.Text, txtAbreviatura.Text, TxtDescripcion.Text, ChkEstado.GetEstado)
            Else
                Me.Close()
            End If

            If Padre = "Agregar" Then
                Reinicializa()
            Else
                Me.Close()
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCodigoBarras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

End Class
