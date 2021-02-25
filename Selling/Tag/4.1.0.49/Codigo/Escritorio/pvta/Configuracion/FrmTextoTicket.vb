Public Class FrmTextoTicket
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
    Friend WithEvents GrpAlmacen As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbAlineacion As Selling.StoreCombo
    Friend WithEvents ChkNegrita As Selling.ChkStatus
    Friend WithEvents TxtLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtRow As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTextoTicket))
        Me.GrpAlmacen = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbAlineacion = New Selling.StoreCombo
        Me.ChkNegrita = New Selling.ChkStatus(Me.components)
        Me.TxtLinea = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.TxtRow = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GrpAlmacen.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpAlmacen
        '
        Me.GrpAlmacen.Controls.Add(Me.PictureBox3)
        Me.GrpAlmacen.Controls.Add(Me.Label1)
        Me.GrpAlmacen.Controls.Add(Me.CmbAlineacion)
        Me.GrpAlmacen.Controls.Add(Me.ChkNegrita)
        Me.GrpAlmacen.Controls.Add(Me.TxtLinea)
        Me.GrpAlmacen.Controls.Add(Me.LblNombre)
        Me.GrpAlmacen.Controls.Add(Me.LblClave)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox1)
        Me.GrpAlmacen.Controls.Add(Me.PictureBox2)
        Me.GrpAlmacen.Location = New System.Drawing.Point(7, 3)
        Me.GrpAlmacen.Name = "GrpAlmacen"
        Me.GrpAlmacen.Size = New System.Drawing.Size(340, 111)
        Me.GrpAlmacen.TabIndex = 1
        Me.GrpAlmacen.TabStop = False
        Me.GrpAlmacen.Text = "Texto"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(224, 82)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 32
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Linea"
        '
        'CmbAlineacion
        '
        Me.CmbAlineacion.Location = New System.Drawing.Point(64, 52)
        Me.CmbAlineacion.Name = "CmbAlineacion"
        Me.CmbAlineacion.Size = New System.Drawing.Size(153, 21)
        Me.CmbAlineacion.TabIndex = 30
        '
        'ChkNegrita
        '
        Me.ChkNegrita.Checked = True
        Me.ChkNegrita.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkNegrita.Location = New System.Drawing.Point(266, 52)
        Me.ChkNegrita.Name = "ChkNegrita"
        Me.ChkNegrita.Size = New System.Drawing.Size(62, 22)
        Me.ChkNegrita.TabIndex = 0
        Me.ChkNegrita.Text = "Negrita"
        '
        'TxtLinea
        '
        Me.TxtLinea.Location = New System.Drawing.Point(64, 22)
        Me.TxtLinea.Name = "TxtLinea"
        Me.TxtLinea.Size = New System.Drawing.Size(253, 20)
        Me.TxtLinea.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 26)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(46, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Texto"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 57)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(61, 14)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Alineación"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(320, 22)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(217, 52)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(161, 120)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(257, 120)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRow
        '
        Me.TxtRow.Enabled = False
        Me.TxtRow.Location = New System.Drawing.Point(71, 86)
        Me.TxtRow.Name = "TxtRow"
        Me.TxtRow.Size = New System.Drawing.Size(153, 20)
        Me.TxtRow.TabIndex = 4
        Me.TxtRow.Text = "0"
        Me.TxtRow.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtRow.Value = 0
        Me.TxtRow.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'FrmTextoTicket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(356, 166)
        Me.Controls.Add(Me.TxtRow)
        Me.Controls.Add(Me.GrpAlmacen)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTextoTicket"
        Me.Text = "Texto"
        Me.GrpAlmacen.ResumeLayout(False)
        Me.GrpAlmacen.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String

    Public TIKClave As String
    Public MaxChar As Integer
    Public ID As String = ""
    Public Texto As String
    Public Negrita As Integer
    Public Alinear As Integer
    Public Tipo As String
    Public Linea As Integer = 0

    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtLinea.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtLinea.Text.Length > MaxChar Then
            Me.TxtLinea.Text = Me.TxtLinea.Text.Substring(0, MaxChar)

        End If

        If CmbAlineacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Padre = "Modificar" AndAlso (TxtRow.Text = "" OrElse CInt(TxtRow.Text) <= 0) Then
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

    Private Sub FrmTextoTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        With Me.CmbAlineacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Ticket"
            .NombreParametro2 = "campo"
            .Parametro2 = "Alinear"
            .llenar()
        End With



        TxtLinea.Text = Texto
        CmbAlineacion.SelectedValue = Alinear
        ChkNegrita.Estado = Math.Abs(Negrita)
        TxtRow.Text = CStr(Linea)

        If Padre = "Modificar" Then
            TxtRow.Enabled = True
        End If

    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Select Case Me.Padre
                Case "Agregar"

                    Texto = TxtLinea.Text.Trim.ToUpper
                    Alinear = CmbAlineacion.SelectedValue
                    Negrita = ChkNegrita.GetEstado

                    If Not ModPOS.Ticket Is Nothing Then
                        ModPOS.Ticket.addTexto(Tipo, Texto, Negrita, Alinear)
                    End If

                    TxtLinea.Text = ""

                Case "Modificar"
                    If Not (Texto = TxtLinea.Text.Trim.ToUpper AndAlso _
                        Alinear = CmbAlineacion.SelectedValue AndAlso _
                        Linea = CInt(TxtRow.Text) AndAlso _
                        Negrita = ChkNegrita.GetEstado) Then

                        Texto = TxtLinea.Text.Trim.ToUpper
                        Alinear = CmbAlineacion.SelectedValue
                        Negrita = ChkNegrita.GetEstado
                        Linea = CInt(TxtRow.Text)


                        If Not ModPOS.Ticket Is Nothing Then

                            ModPOS.Ticket.updateTexto(Tipo, ID, Linea, Texto, Negrita, Alinear)

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
        ModPOS.Texto.Dispose()
        ModPOS.Texto = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

End Class
