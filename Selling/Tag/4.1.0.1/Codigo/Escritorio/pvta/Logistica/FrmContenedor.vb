Public Class FrmContenedor
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
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpPDV As System.Windows.Forms.GroupBox
    Friend WithEvents txtEconomico As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPropietario As Selling.StoreCombo
    Friend WithEvents cmbModelo As Selling.StoreCombo
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContenedor))
        Me.GrpPDV = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.txtPlaca = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.cmbMarca = New Selling.StoreCombo()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmbPropietario = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbTipo = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.txtEconomico = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.cmbModelo = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblSerie = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpPDV.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPDV
        '
        Me.GrpPDV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPDV.Controls.Add(Me.PictureBox6)
        Me.GrpPDV.Controls.Add(Me.txtPlaca)
        Me.GrpPDV.Controls.Add(Me.PictureBox7)
        Me.GrpPDV.Controls.Add(Me.cmbMarca)
        Me.GrpPDV.Controls.Add(Me.PictureBox8)
        Me.GrpPDV.Controls.Add(Me.PictureBox5)
        Me.GrpPDV.Controls.Add(Me.PictureBox4)
        Me.GrpPDV.Controls.Add(Me.PictureBox3)
        Me.GrpPDV.Controls.Add(Me.cmbPropietario)
        Me.GrpPDV.Controls.Add(Me.Label1)
        Me.GrpPDV.Controls.Add(Me.lblTipo)
        Me.GrpPDV.Controls.Add(Me.cmbTipo)
        Me.GrpPDV.Controls.Add(Me.PictureBox1)
        Me.GrpPDV.Controls.Add(Me.Label5)
        Me.GrpPDV.Controls.Add(Me.cmbEstado)
        Me.GrpPDV.Controls.Add(Me.txtEconomico)
        Me.GrpPDV.Controls.Add(Me.cmbModelo)
        Me.GrpPDV.Controls.Add(Me.Label2)
        Me.GrpPDV.Controls.Add(Me.txtSerie)
        Me.GrpPDV.Controls.Add(Me.LblClave)
        Me.GrpPDV.Controls.Add(Me.PictureBox2)
        Me.GrpPDV.Controls.Add(Me.LblSerie)
        Me.GrpPDV.Controls.Add(Me.Label4)
        Me.GrpPDV.Controls.Add(Me.Label3)
        Me.GrpPDV.Location = New System.Drawing.Point(7, -1)
        Me.GrpPDV.Name = "GrpPDV"
        Me.GrpPDV.Size = New System.Drawing.Size(689, 261)
        Me.GrpPDV.TabIndex = 1
        Me.GrpPDV.TabStop = False
        Me.GrpPDV.Text = "Datos Generales"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(75, 199)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox6.TabIndex = 121
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(100, 90)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(120, 20)
        Me.txtPlaca.TabIndex = 3
        Me.txtPlaca.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(75, 227)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox7.TabIndex = 118
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.Location = New System.Drawing.Point(100, 158)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(212, 21)
        Me.cmbMarca.TabIndex = 5
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(396, 33)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox8.TabIndex = 108
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(75, 162)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox5.TabIndex = 106
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(75, 123)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox4.TabIndex = 105
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(75, 95)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox3.TabIndex = 104
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'cmbPropietario
        '
        Me.cmbPropietario.Location = New System.Drawing.Point(100, 224)
        Me.cmbPropietario.Name = "cmbPropietario"
        Me.cmbPropietario.Size = New System.Drawing.Size(212, 21)
        Me.cmbPropietario.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 227)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Propietario"
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(4, 123)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(47, 14)
        Me.lblTipo.TabIndex = 89
        Me.lblTipo.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.Location = New System.Drawing.Point(100, 120)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(212, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(75, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(372, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Location = New System.Drawing.Point(419, 30)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(133, 21)
        Me.cmbEstado.TabIndex = 8
        '
        'txtEconomico
        '
        Me.txtEconomico.Location = New System.Drawing.Point(100, 30)
        Me.txtEconomico.Name = "txtEconomico"
        Me.txtEconomico.Size = New System.Drawing.Size(120, 20)
        Me.txtEconomico.TabIndex = 1
        Me.txtEconomico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'cmbModelo
        '
        Me.cmbModelo.Location = New System.Drawing.Point(100, 191)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.Size = New System.Drawing.Size(212, 21)
        Me.cmbModelo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 15)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Modelo"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(100, 59)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(256, 20)
        Me.txtSerie.TabIndex = 2
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(4, 32)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(94, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "No. Económico"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(75, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 18)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'LblSerie
        '
        Me.LblSerie.Location = New System.Drawing.Point(4, 62)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(72, 15)
        Me.LblSerie.TabIndex = 26
        Me.LblSerie.Text = "Serie"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Placa"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 14)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Marca"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(510, 281)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(606, 281)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmContenedor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(706, 326)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GrpPDV)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(602, 338)
        Me.Name = "FrmContenedor"
        Me.Text = "Caja"
        Me.GrpPDV.ResumeLayout(False)
        Me.GrpPDV.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public CONClave As String
    Public noEconomico As String
    Public Tipo As Integer
    Public Marca As Integer
    Public Modelo As Integer
    Public Placa As String
    Public Serie As String
    Public Propietario As Integer
    Public Estado As Integer = 1

    Private alerta(7) As PictureBox
    Private reloj As parpadea

    Private bLoad As Boolean = False


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.txtEconomico.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtSerie.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.txtPlaca.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbMarca.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbModelo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbPropietario.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbEstado.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Contenedor", "@clave", UCase(Trim(Me.txtEconomico.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmContenedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8

        With cmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contenedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With cmbMarca
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contenedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Marca"
            .llenar()
        End With

        With Me.cmbEstado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contenedor"
            .NombreParametro2 = "campo"
            .Parametro2 = "Estado"
            .llenar()
        End With


        With Me.cmbModelo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Activo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Modelo"
            .llenar()
        End With

        With Me.cmbPropietario
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Activo"
            .NombreParametro2 = "campo"
            .Parametro2 = "Propietario"
            .llenar()
        End With



        bLoad = True


        txtEconomico.Text = noEconomico
        txtSerie.Text = Serie
        txtPlaca.Text = Placa
        cmbTipo.SelectedValue = Tipo
        cmbMarca.SelectedValue = Marca
        cmbModelo.SelectedValue = Modelo
        cmbEstado.SelectedValue = Estado
        cmbPropietario.SelectedValue = Propietario


    End Sub

    Public Sub reinicializar()
        noEconomico = ""
        Serie = ""
        Placa = ""
        Tipo = 0
        Estado = 1
        Marca = 0
        Modelo = 0
        Propietario = 0

        txtEconomico.Text = noEconomico
        txtSerie.Text = Serie
        txtPlaca.Text = Placa
        cmbTipo.SelectedValue = Tipo
        cmbMarca.SelectedValue = Marca
        cmbModelo.SelectedValue = Modelo
        cmbEstado.SelectedValue = Estado
        cmbPropietario.SelectedValue = Propietario
    End Sub

    Private Sub FrmContenedor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Contenedor.Dispose()
        ModPOS.Contenedor = Nothing
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Select Case Me.Padre
                Case "Agregar"
                    CONClave = ModPOS.obtenerLlave
                    noEconomico = txtEconomico.Text
                    Serie = txtSerie.Text
                    Placa = txtPlaca.Text
                    Tipo = cmbTipo.SelectedValue
                    Marca = cmbMarca.SelectedValue
                    Modelo = cmbModelo.SelectedValue
                    Estado = cmbEstado.SelectedValue
                    Propietario = cmbPropietario.SelectedValue


                    ModPOS.Ejecuta("sp_inserta_contenedor", _
                     "@CONClave", CONClave, _
                        "@Economico", noEconomico, _
                        "@Serie", Serie, _
                        "@Placa", Placa, _
                        "@Tipo", Tipo, _
                        "@Marca", Marca, _
                        "@Modelo", Modelo, _
                        "@Propietario", Propietario, _
                        "@Estado", Estado, _
                        "@COMClave", ModPOS.CompanyActual, _
                        "@Usuario", ModPOS.UsuarioActual)

                    reinicializar()

                    If Not ModPOS.MtoContenedor Is Nothing Then
                        ModPOS.ActualizaGrid(True, ModPOS.MtoContenedor.GridCaja, "sp_muestra_contenedores", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoContenedor.GridCaja.RootTable.Columns("CONClave").Visible = False
                    End If


                Case "Modificar"


                    If Not (txtEconomico.Text = noEconomico AndAlso _
                        txtSerie.Text = Serie AndAlso _
                        txtPlaca.Text = Placa AndAlso _
                        cmbTipo.SelectedValue = Tipo AndAlso _
                        cmbMarca.SelectedValue = Marca AndAlso _
                        cmbModelo.SelectedValue = Modelo AndAlso _
                        cmbEstado.SelectedValue = Estado AndAlso _
                        cmbPropietario.SelectedValue = Propietario) Then


                        noEconomico = txtEconomico.Text
                        Serie = txtSerie.Text
                        Placa = txtPlaca.Text
                        Tipo = cmbTipo.SelectedValue
                        Marca = cmbMarca.SelectedValue
                        Modelo = cmbModelo.SelectedValue
                        Estado = cmbEstado.SelectedValue
                        Propietario = cmbPropietario.SelectedValue




                        ModPOS.Ejecuta("sp_modificar_contenedor", _
                        "@CONClave", CONClave, _
                        "@Serie", Serie, _
                        "@Placa", Placa, _
                        "@Tipo", Tipo, _
                        "@Marca", Marca, _
                        "@Modelo", Modelo, _
                        "@Propietario", Propietario, _
                        "@Estado", Estado, _
                        "@Usuario", ModPOS.UsuarioActual)

                        If Not ModPOS.MtoContenedor Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoContenedor.GridCaja, "sp_muestra_contenedores", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoContenedor.GridCaja.RootTable.Columns("CONClave").Visible = False
                        End If

                    End If
                    Me.Close()
            End Select



        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub



    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class
