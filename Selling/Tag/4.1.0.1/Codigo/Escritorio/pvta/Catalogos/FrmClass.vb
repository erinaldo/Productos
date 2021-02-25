Public Class FrmClass
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
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpClass As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtClavePadre As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents BtnBusca As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDescripcionPadre As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClass))
        Me.GrpClass = New System.Windows.Forms.GroupBox
        Me.lblDescripcionPadre = New System.Windows.Forms.Label
        Me.BtnBusca = New Janus.Windows.EditControls.UIButton
        Me.TxtClavePadre = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbGrupo = New Selling.StoreCombo
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.GrpClass.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClass
        '
        Me.GrpClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClass.Controls.Add(Me.PictureBox4)
        Me.GrpClass.Controls.Add(Me.lblDescripcionPadre)
        Me.GrpClass.Controls.Add(Me.BtnBusca)
        Me.GrpClass.Controls.Add(Me.TxtClavePadre)
        Me.GrpClass.Controls.Add(Me.Label5)
        Me.GrpClass.Controls.Add(Me.Label3)
        Me.GrpClass.Controls.Add(Me.cmbGrupo)
        Me.GrpClass.Controls.Add(Me.TxtCompany)
        Me.GrpClass.Controls.Add(Me.Label2)
        Me.GrpClass.Controls.Add(Me.PictureBox3)
        Me.GrpClass.Controls.Add(Me.Label1)
        Me.GrpClass.Controls.Add(Me.CmbTipo)
        Me.GrpClass.Controls.Add(Me.PictureBox1)
        Me.GrpClass.Controls.Add(Me.ChkEstado)
        Me.GrpClass.Controls.Add(Me.PictureBox2)
        Me.GrpClass.Controls.Add(Me.TxtNombre)
        Me.GrpClass.Controls.Add(Me.LblNombre)
        Me.GrpClass.Controls.Add(Me.TxtClave)
        Me.GrpClass.Controls.Add(Me.LblClave)
        Me.GrpClass.Controls.Add(Me.Label4)
        Me.GrpClass.Location = New System.Drawing.Point(5, 7)
        Me.GrpClass.Name = "GrpClass"
        Me.GrpClass.Size = New System.Drawing.Size(772, 230)
        Me.GrpClass.TabIndex = 1
        Me.GrpClass.TabStop = False
        Me.GrpClass.Text = "Clasificación"
        '
        'lblDescripcionPadre
        '
        Me.lblDescripcionPadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescripcionPadre.Location = New System.Drawing.Point(324, 198)
        Me.lblDescripcionPadre.Name = "lblDescripcionPadre"
        Me.lblDescripcionPadre.Size = New System.Drawing.Size(418, 15)
        Me.lblDescripcionPadre.TabIndex = 138
        '
        'BtnBusca
        '
        Me.BtnBusca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBusca.Image = CType(resources.GetObject("BtnBusca.Image"), System.Drawing.Image)
        Me.BtnBusca.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBusca.Location = New System.Drawing.Point(277, 189)
        Me.BtnBusca.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBusca.Name = "BtnBusca"
        Me.BtnBusca.Size = New System.Drawing.Size(31, 30)
        Me.BtnBusca.TabIndex = 137
        Me.BtnBusca.ToolTipText = "Busqueda de Clasificación"
        Me.BtnBusca.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClavePadre
        '
        Me.TxtClavePadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtClavePadre.Location = New System.Drawing.Point(98, 195)
        Me.TxtClavePadre.Name = "TxtClavePadre"
        Me.TxtClavePadre.Size = New System.Drawing.Size(165, 20)
        Me.TxtClavePadre.TabIndex = 82
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Padre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Grupo"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(98, 161)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(283, 21)
        Me.cmbGrupo.TabIndex = 80
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(98, 22)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(438, 20)
        Me.TxtCompany.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 15)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Compañia"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(386, 58)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 77
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Tipo"
        '
        'CmbTipo
        '
        Me.CmbTipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(98, 57)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(283, 21)
        Me.CmbTipo.TabIndex = 75
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(386, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(556, 21)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(66, 22)
        Me.ChkEstado.TabIndex = 56
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(556, 126)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNombre.Location = New System.Drawing.Point(98, 126)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(438, 20)
        Me.TxtNombre.TabIndex = 2
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 129)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Nombre"
        '
        'TxtClave
        '
        Me.TxtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtClave.Location = New System.Drawing.Point(98, 91)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(165, 20)
        Me.TxtClave.TabIndex = 1
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 94)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(269, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 10 Caracteres"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(687, 242)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 8
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(591, 242)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 9
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(314, 195)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 139
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'FrmClass
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 286)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpClass)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 325)
        Me.Name = "FrmClass"
        Me.Text = "Clasificación"
        Me.GrpClass.ResumeLayout(False)
        Me.GrpClass.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public CLAClave As Integer
    Public CLAClavePadre As Integer

    Public Referencia As String
    Public Nombre As String
    Public Estado As Integer = 1
    Public Tipo As Integer = 1
    Public Grupo As Integer = 0
    Public Nivel As Integer = 0

    Private sReferencia As String
    Private iBaja As Integer

    Private CLAClavePadreOrigen As Integer

    Private ReferenciaPadre As String
    Private NombrePadre As String
    Private NivelPadre As Integer

    Private alerta(3) As PictureBox
    Private reloj As parpadea
    Private bCargado As Boolean = False

    Private dtSubclas As DataTable


#Region "Metodos Internos"

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 10 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 10)

        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 60 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 60)

        End If

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Padre = "Modificar" AndAlso CLAClave = CLAClavePadre Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_clasificacion", "@Tipo", CmbTipo.SelectedValue, "@Referencia", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Clave que intenta agregar ya existe en el sistema para el tipo seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


    Private Sub Reinicializa()
        CLAClave = -1
        Referencia = ""
        Nombre = ""
        Estado = 1

        CmbTipo.Enabled = True
        TxtClave.Text = ""
        TxtNombre.Text = ""


    End Sub

   


#End Region

    Private Sub recuperaPadre(ByVal Padre As Integer)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_clase", "@Clase", Padre)

        Me.CLAClavePadre = Padre
        ReferenciaPadre = dt.Rows(0)("Referencia")
        NombrePadre = dt.Rows(0)("Nombre")
        NivelPadre = IIf(dt.Rows(0)("Nivel").GetType.Name = "DBNull", 0, dt.Rows(0)("Nivel"))

        dt.Dispose()


        lblDescripcionPadre.Text = NombrePadre
        TxtClavePadre.Text = ReferenciaPadre


    End Sub


    Private Sub FrmClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor


        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Clasificacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        CmbTipo.SelectedValue = Tipo

        With Me.cmbGrupo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = IIf(CmbTipo.SelectedValue Is Nothing, 0, CmbTipo.SelectedValue)

            .llenar()
        End With

        Me.bCargado = True

        Me.TxtClave.Text = Referencia
        TxtNombre.Text = Nombre
        ChkEstado.Estado = Estado
        cmbGrupo.SelectedValue = Grupo

        CLAClavePadreOrigen = CLAClavePadre

        If Padre <> "Agregar" Then

            If CLAClavePadre <> 0 Then
                Me.recuperaPadre(CLAClavePadre)
            Else

                TxtClavePadre.Text = ""
                lblDescripcionPadre.Text = ""
            End If

        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub FrmClass_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not ModPOS.MtoClass Is Nothing Then
            ModPOS.ActualizaGrid(True, ModPOS.MtoClass.GridClasificaciones, "sp_muestra_clases", "@COMClave", ModPOS.CompanyActual)
            ModPOS.MtoClass.GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
            ModPOS.MtoClass.GridClasificaciones.RootTable.Columns("TClasificacion").Visible = False
        End If

        ModPOS.Clase.Dispose()
        ModPOS.Clase = Nothing

    End Sub


   

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            
            Select Case Me.Padre
                Case "Agregar"

                    Referencia = UCase(Trim(Me.TxtClave.Text))
                    Nombre = Trim(Me.TxtNombre.Text)
                    Tipo = CmbTipo.SelectedValue
                    Estado = ChkEstado.GetEstado

                    Grupo = IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue)

                    If CLAClavePadre = 0 Then
                        Nivel = 0
                    Else
                        Nivel = NivelPadre + 1
                    End If

                    ModPOS.Ejecuta("sp_inserta_clase", _
                    "@CLAClavePadre", CLAClavePadre, _
                    "@Referencia", Referencia, _
                    "@Nombre", Nombre, _
                    "@Tipo", Tipo, _
                    "@Estado", Estado, _
                    "@Grupo", Grupo, _
                    "@Nivel", Nivel, _
                    "@Usuario", ModPOS.UsuarioActual, _
                    "@COMClave", ModPOS.CompanyActual)


                    Reinicializa()


                Case "Modificar"
                    If Not (Nombre = UCase(Trim(Me.TxtNombre.Text)) AndAlso Estado = ChkEstado.GetEstado _
                            AndAlso Grupo = cmbGrupo.SelectedValue AndAlso CLAClavePadre = CLAClavePadreOrigen) Then


                        Me.Nombre = UCase(Trim(Me.TxtNombre.Text))

                        Me.Estado = Me.ChkEstado.GetEstado

                        Grupo = IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue)

                        If CLAClavePadre = 0 Then
                            Nivel = 0
                        Else
                            Nivel = NivelPadre + 1
                        End If


                        ModPOS.Ejecuta("sp_actualiza_clase", _
                        "@CLAClave", CLAClave, _
                        "@CLAClavePadre", CLAClavePadre, _
                        "@Estado", Estado, _
                        "@Nombre", Nombre, _
                        "@Tipo", Tipo, _
                        "@Grupo", Grupo, _
                        "@Nivel", Nivel, _
                        "@Usuario", ModPOS.UsuarioActual, _
                        "@COMClave", ModPOS.CompanyActual)

                    End If

                   
                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub CmbTipo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedValueChanged
        If Not CmbTipo.SelectedValue Is Nothing AndAlso bCargado = True Then
            With Me.cmbGrupo
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_grupo"
                .NombreParametro1 = "Tipo"
                .Parametro1 = CmbTipo.SelectedValue
                .llenar()
            End With

        End If
    End Sub

    Private Sub BtnBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusca.Click
        Dim a As New MeSearchSimple
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_filtra_clasificacion", "@TClasificacion", CmbTipo.SelectedValue, "@TGrupo", IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue), "@COMClave", ModPOS.CompanyActual)
        a.GridSearch.RootTable.Columns("CLAClave").Visible = False
        a.numColValor = 0
        a.numColDescripcion = 1
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.recuperaPadre(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If bCargado = True AndAlso Not cmbGrupo.SelectedValue Is Nothing Then
            If cmbGrupo.SelectedValue <> Me.Grupo Then
                CLAClavePadre = 0
                TxtClavePadre.Text = ""
                lblDescripcionPadre.Text = ""
            End If
        End If
    End Sub

    Private Sub TxtClavePadre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClavePadre.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TxtClavePadre.Text <> "" AndAlso Not CmbTipo.SelectedValue Is Nothing Then



                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_busca_clasificacion", "@Tipo", CmbTipo.SelectedValue, "@Grupo", IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue), "@Referencia", TxtClavePadre.Text, "@COMClave", ModPOS.CompanyActual)

                If dt.Rows.Count > 0 Then

                    Me.CLAClavePadre = dt.Rows(0)("CLAClave")
                    ReferenciaPadre = dt.Rows(0)("Referencia")
                    NombrePadre = dt.Rows(0)("Nombre")
                    NivelPadre = IIf(dt.Rows(0)("Nivel").GetType.Name = "DBNull", 0, dt.Rows(0)("Nivel"))

                    lblDescripcionPadre.Text = NombrePadre
                    TxtClavePadre.Text = ReferenciaPadre

                Else
                    MessageBox.Show("No se encontro referencia que coincida para el Tipo y Grupo seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                dt.Dispose()

            End If
        End If
    End Sub
End Class
