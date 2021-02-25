Public Class FrmAplicacion
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
    Friend WithEvents TxtModelo As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtMarca As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpMultiproducto As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtPickerAño As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPickerHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAplicacion))
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox
        Me.dtPickerAño = New System.Windows.Forms.DateTimePicker
        Me.dtPickerHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtModelo = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtMarca = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox3)
        Me.GrpMultiproducto.Controls.Add(Me.dtPickerAño)
        Me.GrpMultiproducto.Controls.Add(Me.dtPickerHasta)
        Me.GrpMultiproducto.Controls.Add(Me.Label1)
        Me.GrpMultiproducto.Controls.Add(Me.Label2)
        Me.GrpMultiproducto.Controls.Add(Me.TxtModelo)
        Me.GrpMultiproducto.Controls.Add(Me.LblNombre)
        Me.GrpMultiproducto.Controls.Add(Me.TxtMarca)
        Me.GrpMultiproducto.Controls.Add(Me.LblClave)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox1)
        Me.GrpMultiproducto.Controls.Add(Me.PictureBox2)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(7, 4)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(270, 111)
        Me.GrpMultiproducto.TabIndex = 1
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Aplicación"
        '
        'dtPickerAño
        '
        Me.dtPickerAño.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickerAño.CustomFormat = "yyyy"
        Me.dtPickerAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerAño.Location = New System.Drawing.Point(79, 77)
        Me.dtPickerAño.MinDate = New Date(1920, 1, 1, 0, 0, 0, 0)
        Me.dtPickerAño.Name = "dtPickerAño"
        Me.dtPickerAño.ShowUpDown = True
        Me.dtPickerAño.Size = New System.Drawing.Size(55, 20)
        Me.dtPickerAño.TabIndex = 54
        '
        'dtPickerHasta
        '
        Me.dtPickerHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickerHasta.CustomFormat = "yyyy"
        Me.dtPickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerHasta.Location = New System.Drawing.Point(189, 77)
        Me.dtPickerHasta.MinDate = New Date(1920, 1, 1, 0, 0, 0, 0)
        Me.dtPickerHasta.Name = "dtPickerHasta"
        Me.dtPickerHasta.ShowUpDown = True
        Me.dtPickerHasta.Size = New System.Drawing.Size(55, 20)
        Me.dtPickerHasta.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(140, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Hasta"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Año"
        '
        'TxtModelo
        '
        Me.TxtModelo.Location = New System.Drawing.Point(79, 48)
        Me.TxtModelo.Name = "TxtModelo"
        Me.TxtModelo.Size = New System.Drawing.Size(165, 20)
        Me.TxtModelo.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 51)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Modelo"
        '
        'TxtMarca
        '
        Me.TxtMarca.Location = New System.Drawing.Point(79, 19)
        Me.TxtMarca.Name = "TxtMarca"
        Me.TxtMarca.Size = New System.Drawing.Size(165, 20)
        Me.TxtMarca.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 21)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Marca"
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
        Me.BtnCancelar.Location = New System.Drawing.Point(91, 121)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(187, 121)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(247, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 55
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'FrmAplicacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(287, 169)
        Me.Controls.Add(Me.GrpMultiproducto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAplicacion"
        Me.Text = "Detalle Aplicación "
        Me.GrpMultiproducto.ResumeLayout(False)
        Me.GrpMultiproducto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public Modelo As String
    Public Marca As String
    Public Año As Integer
    Public Hasta As Integer


    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private aMarca() As String
    Private aModelo() As String

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtMarca.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()

        End If

        If Me.TxtModelo.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()

        End If

        If Me.dtPickerHasta.Value.Year < dtPickerAño.Value.Year Then
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

    Private Sub FrmAplicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3


        Dim dtMarca As DataTable

        dtMarca = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Producto", "@Campo", "Marca")
        If dtMarca.Rows.Count > 0 Then
            ReDim aMarca(dtMarca.Rows.Count - 1)

            For i As Integer = 0 To dtMarca.Rows.Count - 1
                aMarca(i) = dtMarca.Rows(i)("Descripcion")
            Next

            Me.TxtMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtMarca.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtMarca.AutoCompleteCustomSource.AddRange(amarca)
            dtMarca.Dispose()
        End If


        Dim dtModelo As DataTable

        dtModelo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Producto", "@Campo", "Modelo")
        If dtModelo.Rows.Count > 0 Then
            ReDim aModelo(dtModelo.Rows.Count - 1)

            For i As Integer = 0 To dtModelo.Rows.Count - 1
                aModelo(i) = dtModelo.Rows(i)("Descripcion")
            Next

            Me.TxtModelo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtModelo.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtModelo.AutoCompleteCustomSource.AddRange(aModelo)
            dtModelo.Dispose()
        End If



    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    Marca = TxtMarca.Text.Trim.ToUpper
                    Modelo = TxtModelo.Text.Trim.ToUpper
                    Año = dtPickerAño.Value.Year
                    Hasta = dtPickerHasta.Value.Year





                    ModPOS.Producto.AddAplicacion(Marca, Modelo, Año, Hasta)

                    TxtMarca.Text = ""
                    TxtModelo.Text = ""

            End Select


        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmAplicacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Aplicacion.Dispose()
        ModPOS.Aplicacion = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

 
  
End Class
