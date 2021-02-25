Public Class FrmUnidad
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
    Friend WithEvents GrpUnidad As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtAbreviatura As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnidad))
        Me.GrpUnidad = New System.Windows.Forms.GroupBox
        Me.TxtOrden = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtAbreviatura = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpUnidad.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpUnidad
        '
        Me.GrpUnidad.Controls.Add(Me.TxtOrden)
        Me.GrpUnidad.Controls.Add(Me.Label1)
        Me.GrpUnidad.Controls.Add(Me.ChkEstado)
        Me.GrpUnidad.Controls.Add(Me.TxtNombre)
        Me.GrpUnidad.Controls.Add(Me.LblNombre)
        Me.GrpUnidad.Controls.Add(Me.TxtAbreviatura)
        Me.GrpUnidad.Controls.Add(Me.LblClave)
        Me.GrpUnidad.Controls.Add(Me.PictureBox1)
        Me.GrpUnidad.Controls.Add(Me.Label4)
        Me.GrpUnidad.Location = New System.Drawing.Point(7, 7)
        Me.GrpUnidad.Name = "GrpUnidad"
        Me.GrpUnidad.Size = New System.Drawing.Size(360, 116)
        Me.GrpUnidad.TabIndex = 1
        Me.GrpUnidad.TabStop = False
        Me.GrpUnidad.Text = "Unidad"
        '
        'TxtOrden
        '
        Me.TxtOrden.Location = New System.Drawing.Point(107, 85)
        Me.TxtOrden.Name = "TxtOrden"
        Me.TxtOrden.Size = New System.Drawing.Size(65, 20)
        Me.TxtOrden.TabIndex = 94
        Me.TxtOrden.Text = "0"
        Me.TxtOrden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtOrden.Value = 0
        Me.TxtOrden.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Orden"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(287, 13)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(66, 22)
        Me.ChkEstado.TabIndex = 0
        Me.ChkEstado.Text = "Activo"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(107, 58)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(226, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 58)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtAbreviatura
        '
        Me.TxtAbreviatura.Location = New System.Drawing.Point(107, 29)
        Me.TxtAbreviatura.Name = "TxtAbreviatura"
        Me.TxtAbreviatura.Size = New System.Drawing.Size(120, 20)
        Me.TxtAbreviatura.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 29)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Abreviatura"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(233, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(233, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 14)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(347, 66)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(181, 129)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(277, 129)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmUnidad
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(377, 175)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GrpUnidad)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUnidad"
        Me.Text = "Unidad"
        Me.GrpUnidad.ResumeLayout(False)
        Me.GrpUnidad.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public UNDClave As String
    Public Nombre As String
    Public Abreviatura As String
    Public Estado As Integer
    Public Orden As Integer
 
    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)

        End If

        If Me.TxtAbreviatura.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtAbreviatura.Text.Length > 10 Then
            Me.TxtAbreviatura.Text = Me.TxtAbreviatura.Text.Substring(0, 10)

        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Unidad", "@clave", UCase(Trim(Me.TxtAbreviatura.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmImpuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        TxtNombre.Text = Nombre
        TxtAbreviatura.Text = Abreviatura
        ChkEstado.Estado = Estado
        TxtOrden.Text = Orden
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    UNDClave = ModPOS.obtenerLlave
                    Nombre = UCase(Trim(Me.TxtNombre.Text))
                    Abreviatura = UCase(Trim(Me.TxtAbreviatura.Text))
                    Orden = TxtOrden.Text

                    ModPOS.Ejecuta("sp_inserta_unidad", "@UNDClave", UNDClave, "@Nombre", Nombre, "@Orden", Orden, "@Abreviatura", Abreviatura, "@Usuario", ModPOS.UsuarioActual)

                    If Not ModPOS.MtoUnidades Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoUnidades.GridUnidades, "sp_muestra_unidades", Nothing)
                        MtoUnidades.GridUnidades.RootTable.Columns("ID").Visible = False
                        MtoUnidades.GridUnidades.RootTable.Columns("ID_Estado").Visible = False

                    End If


                    TxtNombre.Text = ""
                    TxtAbreviatura.Text = ""

                Case "Modificar"
                    If Not (Estado = ChkEstado.GetEstado AndAlso Nombre = TxtNombre.Text AndAlso Orden = TxtOrden.Text) Then

                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text))
                        Me.Estado = ChkEstado.GetEstado
                        Orden = TxtOrden.Text

                        ModPOS.Ejecuta("sp_actualiza_unidad", "@UNDClave", UNDClave, "@Estado", Estado, "@Nombre", Nombre, "@Orden", Orden, "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoUnidades Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoUnidades.GridUnidades, "sp_muestra_unidades", Nothing)
                            MtoUnidades.GridUnidades.RootTable.Columns("ID").Visible = False
                            MtoUnidades.GridUnidades.RootTable.Columns("ID_Estado").Visible = False

                        End If
                    End If
                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmImpuesto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Unidad.Dispose()
        ModPOS.Unidad = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class
