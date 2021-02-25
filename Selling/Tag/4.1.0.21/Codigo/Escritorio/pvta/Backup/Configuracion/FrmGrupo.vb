Public Class FrmGrupo
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpModulo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpIcono As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numOrden As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkEstado As Selling.ChkStatus
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGrupo))
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpModulo = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.numOrden = New System.Windows.Forms.NumericUpDown
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GrpIcono = New System.Windows.Forms.GroupBox
        Me.PictIcono = New System.Windows.Forms.PictureBox
        Me.GrpModulo.SuspendLayout()
        CType(Me.numOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIcono.SuspendLayout()
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(310, 111)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 3
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(214, 111)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpModulo
        '
        Me.GrpModulo.Controls.Add(Me.Label2)
        Me.GrpModulo.Controls.Add(Me.numOrden)
        Me.GrpModulo.Controls.Add(Me.ChkEstado)
        Me.GrpModulo.Controls.Add(Me.TxtNombre)
        Me.GrpModulo.Controls.Add(Me.LblNombre)
        Me.GrpModulo.Controls.Add(Me.LblClave)
        Me.GrpModulo.Controls.Add(Me.TxtClave)
        Me.GrpModulo.Controls.Add(Me.PictureBox1)
        Me.GrpModulo.Location = New System.Drawing.Point(6, 4)
        Me.GrpModulo.Name = "GrpModulo"
        Me.GrpModulo.Size = New System.Drawing.Size(293, 102)
        Me.GrpModulo.TabIndex = 6
        Me.GrpModulo.TabStop = False
        Me.GrpModulo.Text = "Modulo"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Orden"
        '
        'numOrden
        '
        Me.numOrden.Location = New System.Drawing.Point(73, 74)
        Me.numOrden.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numOrden.Name = "numOrden"
        Me.numOrden.Size = New System.Drawing.Size(87, 20)
        Me.numOrden.TabIndex = 55
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(218, 11)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(69, 22)
        Me.ChkEstado.TabIndex = 54
        Me.ChkEstado.Text = "Activo"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(73, 49)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(194, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 49)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(60, 22)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 19)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 22)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(73, 19)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GrpIcono
        '
        Me.GrpIcono.Controls.Add(Me.PictIcono)
        Me.GrpIcono.Location = New System.Drawing.Point(307, 4)
        Me.GrpIcono.Name = "GrpIcono"
        Me.GrpIcono.Size = New System.Drawing.Size(93, 102)
        Me.GrpIcono.TabIndex = 9
        Me.GrpIcono.TabStop = False
        Me.GrpIcono.Text = "Icono"
        '
        'PictIcono
        '
        Me.PictIcono.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictIcono.Location = New System.Drawing.Point(6, 19)
        Me.PictIcono.Name = "PictIcono"
        Me.PictIcono.Size = New System.Drawing.Size(81, 75)
        Me.PictIcono.TabIndex = 0
        Me.PictIcono.TabStop = False
        '
        'FrmGrupo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(407, 154)
        Me.Controls.Add(Me.GrpIcono)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpModulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(420, 185)
        Me.Name = "FrmGrupo"
        Me.Text = "FrmGrupo"
        Me.GrpModulo.ResumeLayout(False)
        Me.GrpModulo.PerformLayout()
        CType(Me.numOrden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIcono.ResumeLayout(False)
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public sGRPKey As String
    Public sNombre As String
    Public iEstado As Integer
    Public iOrden As Integer

    Public Icono As Byte()
    Public IconoActual As Byte()
    Public NuevoIcono As Boolean = False

    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 40 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 40)
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

    Private Sub FrmGrupo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
       
       
        alerta(0) = Me.PictureBox1
        TxtClave.Text = sGRPKey
        TxtNombre.Text = sNombre
        ChkEstado.Estado = iEstado
        numOrden.Value = iOrden

    End Sub

    Private Sub PictIcono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIcono.DoubleClick
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de Icono|*.ICO|Todos los archivos PNG|*.PNG"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de Imágen"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName



                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim Icono(lung)
                fsIcono.Read(Icono, 0, lung)
                fsIcono.Close()

                Me.PictIcono.Image = Image.FromFile(curFileName)

                NuevoIcono = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm() Then
            If Not (numOrden.Value = iOrden AndAlso _
                    sNombre = Me.TxtNombre.Text.Trim AndAlso _
                    Icono Is IconoActual AndAlso _
                    iEstado = ChkEstado.GetEstado) Then

                sNombre = Me.TxtNombre.Text.Trim
                IconoActual = Icono
                iEstado = ChkEstado.GetEstado
                iOrden = numOrden.Value

                ModPOS.Ejecuta("sp_actualiza_modulo", "@Clave", sGRPKey, "@Nombre", sNombre, "@Estado", iEstado, "@Imagen", IconoActual, "@Orden", iOrden)
                ModPOS.ActualizaGrid(True, ModPOS.MtoModulos.GridModulos, "sp_muestra_modulos", Nothing)

                Me.Close()
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmGrupo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.Modulo.Dispose()
        ModPOS.Modulo = Nothing
    End Sub


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub
End Class
