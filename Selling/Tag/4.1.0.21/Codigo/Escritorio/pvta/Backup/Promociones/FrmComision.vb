Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmComision
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpReglaPromocion As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbTipoComision As Selling.StoreCombo
    Friend WithEvents LblClavePromocion As System.Windows.Forms.Label
    Friend WithEvents LblTipoAplicacion As System.Windows.Forms.Label
    Friend WithEvents TxtComisionDesc As System.Windows.Forms.TextBox
    Friend WithEvents LblPromocionDesc As System.Windows.Forms.Label
    Friend WithEvents TxtComisionClave As System.Windows.Forms.TextBox
    Friend WithEvents LblTipoPromocion As System.Windows.Forms.Label
    Friend WithEvents CmbTipoAplicacion As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComision))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpReglaPromocion = New System.Windows.Forms.GroupBox
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbTipoAplicacion = New Selling.StoreCombo
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.CmbTipoComision = New Selling.StoreCombo
        Me.LblClavePromocion = New System.Windows.Forms.Label
        Me.LblTipoAplicacion = New System.Windows.Forms.Label
        Me.TxtComisionDesc = New System.Windows.Forms.TextBox
        Me.LblPromocionDesc = New System.Windows.Forms.Label
        Me.TxtComisionClave = New System.Windows.Forms.TextBox
        Me.LblTipoPromocion = New System.Windows.Forms.Label
        Me.GrpReglaPromocion.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(595, 530)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(691, 530)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpReglaPromocion
        '
        Me.GrpReglaPromocion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpReglaPromocion.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpReglaPromocion.Controls.Add(Me.BtnDel)
        Me.GrpReglaPromocion.Controls.Add(Me.PictureBox5)
        Me.GrpReglaPromocion.Controls.Add(Me.BtnAdd)
        Me.GrpReglaPromocion.Controls.Add(Me.GridDetalle)
        Me.GrpReglaPromocion.Location = New System.Drawing.Point(7, 153)
        Me.GrpReglaPromocion.Name = "GrpReglaPromocion"
        Me.GrpReglaPromocion.Size = New System.Drawing.Size(774, 371)
        Me.GrpReglaPromocion.TabIndex = 4
        Me.GrpReglaPromocion.TabStop = False
        Me.GrpReglaPromocion.Text = "Rangos de Comisión"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Icon = CType(resources.GetObject("BtnDel.Icon"), System.Drawing.Icon)
        Me.BtnDel.Location = New System.Drawing.Point(677, 11)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(90, 30)
        Me.BtnDel.TabIndex = 7
        Me.BtnDel.Text = "&Eliminar"
        Me.BtnDel.ToolTipText = "Elimina Fila"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(7, 21)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 127
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Icon = CType(resources.GetObject("BtnAdd.Icon"), System.Drawing.Icon)
        Me.BtnAdd.Location = New System.Drawing.Point(581, 11)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(90, 30)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.Text = "Agrega&r"
        Me.BtnAdd.ToolTipText = "Agrega Fila"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 47)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(760, 317)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpGeneral.Controls.Add(Me.TxtCompany)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.ChkEstado)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoAplicacion)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoComision)
        Me.GrpGeneral.Controls.Add(Me.LblClavePromocion)
        Me.GrpGeneral.Controls.Add(Me.LblTipoAplicacion)
        Me.GrpGeneral.Controls.Add(Me.TxtComisionDesc)
        Me.GrpGeneral.Controls.Add(Me.LblPromocionDesc)
        Me.GrpGeneral.Controls.Add(Me.TxtComisionClave)
        Me.GrpGeneral.Controls.Add(Me.LblTipoPromocion)
        Me.GrpGeneral.Location = New System.Drawing.Point(6, 11)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(773, 137)
        Me.GrpGeneral.TabIndex = 119
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(91, 18)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(510, 20)
        Me.TxtCompany.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Compañia"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(559, 97)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(59, 27)
        Me.ChkEstado.TabIndex = 5
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(310, 104)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 126
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(596, 77)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 117
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbTipoAplicacion
        '
        Me.CmbTipoAplicacion.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoAplicacion.Location = New System.Drawing.Point(90, 101)
        Me.CmbTipoAplicacion.Name = "CmbTipoAplicacion"
        Me.CmbTipoAplicacion.Size = New System.Drawing.Size(212, 21)
        Me.CmbTipoAplicacion.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(596, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 115
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(306, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbTipoComision
        '
        Me.CmbTipoComision.Location = New System.Drawing.Point(91, 47)
        Me.CmbTipoComision.Name = "CmbTipoComision"
        Me.CmbTipoComision.Size = New System.Drawing.Size(211, 21)
        Me.CmbTipoComision.TabIndex = 0
        '
        'LblClavePromocion
        '
        Me.LblClavePromocion.Location = New System.Drawing.Point(411, 50)
        Me.LblClavePromocion.Name = "LblClavePromocion"
        Me.LblClavePromocion.Size = New System.Drawing.Size(38, 17)
        Me.LblClavePromocion.TabIndex = 100
        Me.LblClavePromocion.Text = "Clave"
        '
        'LblTipoAplicacion
        '
        Me.LblTipoAplicacion.Location = New System.Drawing.Point(8, 106)
        Me.LblTipoAplicacion.Name = "LblTipoAplicacion"
        Me.LblTipoAplicacion.Size = New System.Drawing.Size(90, 17)
        Me.LblTipoAplicacion.TabIndex = 95
        Me.LblTipoAplicacion.Text = "Tipo Aplicación"
        '
        'TxtComisionDesc
        '
        Me.TxtComisionDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComisionDesc.Location = New System.Drawing.Point(91, 72)
        Me.TxtComisionDesc.Name = "TxtComisionDesc"
        Me.TxtComisionDesc.Size = New System.Drawing.Size(511, 21)
        Me.TxtComisionDesc.TabIndex = 2
        '
        'LblPromocionDesc
        '
        Me.LblPromocionDesc.Location = New System.Drawing.Point(8, 77)
        Me.LblPromocionDesc.Name = "LblPromocionDesc"
        Me.LblPromocionDesc.Size = New System.Drawing.Size(68, 15)
        Me.LblPromocionDesc.TabIndex = 26
        Me.LblPromocionDesc.Text = "Descripción"
        '
        'TxtComisionClave
        '
        Me.TxtComisionClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComisionClave.Location = New System.Drawing.Point(456, 45)
        Me.TxtComisionClave.Name = "TxtComisionClave"
        Me.TxtComisionClave.Size = New System.Drawing.Size(145, 21)
        Me.TxtComisionClave.TabIndex = 1
        '
        'LblTipoPromocion
        '
        Me.LblTipoPromocion.Location = New System.Drawing.Point(7, 51)
        Me.LblTipoPromocion.Name = "LblTipoPromocion"
        Me.LblTipoPromocion.Size = New System.Drawing.Size(100, 15)
        Me.LblTipoPromocion.TabIndex = 108
        Me.LblTipoPromocion.Text = "Tipo Comisión"
        '
        'FrmComision
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.GrpReglaPromocion)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmComision"
        Me.Text = "Comisión"
        Me.GrpReglaPromocion.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public CMIClave As String
    Public Clave As String
    Public Descripcion As String
    Public Tipo As Integer
    Public Aplicacion As Integer
    Public Estado As Integer

    Private alerta(4) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False
    Private DetalleEdited As Boolean = False

    Private dtDetalle, dtRegalo As DataTable


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipoComision.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtComisionClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtComisionDesc.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Comision", "@clave", UCase(Trim(Me.TxtComisionClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmComision_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoComision Is Nothing Then
            ModPOS.ActualizaGrid(True, ModPOS.MtoComision.GridComisiones, "sp_muestra_comisiones", "@COMClave", ModPOS.CompanyActual)
            ModPOS.MtoComision.GridComisiones.RootTable.Columns("ID").Visible = False
        End If
        ModPOS.Comision.Dispose()
        ModPOS.Comision = Nothing
    End Sub

    Private Sub FrmComision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5

        With Me.CmbTipoComision
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Comision"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbTipoAplicacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Comision"
            .NombreParametro2 = "campo"
            .Parametro2 = "Aplicacion"
            .llenar()
        End With

        cargado = True

        If Padre = "Nuevo" Then
            CMIClave = ModPOS.obtenerLlave

            dtDetalle = ModPOS.CrearTabla("ComisionDetalle", "ID", "System.String", _
                                        "CMDClave", "System.String", _
                                        "Importe Inicial", "System.Double", _
                                        "Importe Final", "System.Double", _
                                        "Comisión(%)", "System.Double")

            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("CMDClave").Visible = False

        Else
            Me.TxtComisionDesc.Text = Descripcion
            Me.TxtComisionClave.Text = Clave
            TxtComisionClave.Enabled = False
            Me.CmbTipoAplicacion.SelectedValue = Aplicacion
            ChkEstado.Estado = Math.Abs(Estado)

            CmbTipoComision.Enabled = False
            TxtComisionClave.ReadOnly = True
            CmbTipoAplicacion.Enabled = False

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_comision", "@CMIClave", CMIClave)
            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure(True)
            GridDetalle.GroupByBoxVisible = False
            GridDetalle.RootTable.Columns("ID").Visible = False
            GridDetalle.RootTable.Columns("CMDClave").Visible = False

            Me.CmbTipoComision.SelectedValue = Tipo

        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            If GridDetalle.RowCount > 0 Then
                If Padre = "Nuevo" Then

                    Clave = TxtComisionClave.Text.Trim.ToUpper
                    Descripcion = TxtComisionDesc.Text.Trim.ToUpper
                    Tipo = CmbTipoComision.SelectedValue
                    Aplicacion = CmbTipoAplicacion.SelectedValue
                    Estado = ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_crea_comision", _
                                  "@CMIClave", CMIClave, _
                                  "@Clave", Clave, _
                                  "@Descripcion", Descripcion, _
                                  "@Tipo", Tipo, _
                                  "@Aplicacion", Aplicacion, _
                                  "@Estado", Estado, _
                                  "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_comisiondetalle", _
                                    "@CMIClave", dtDetalle.Rows(fila)("ID"), _
                                    "@CMDClave", dtDetalle.Rows(fila)("CMDClave"), _
                                    "@Inicial", dtDetalle.Rows(fila)("Importe Inicial"), _
                                    "@Final", dtDetalle.Rows(fila)("Importe Final"), _
                                    "@Comision", dtDetalle.Rows(fila)("Comisión(%)"), _
                                    "@Usuario", ModPOS.UsuarioActual)
                    Next


                    Padre = "Modificar"

                    DetalleEdited = False
                Else
                    If Not (Descripcion = TxtComisionDesc.Text.Trim.ToUpper AndAlso _
                             Aplicacion = CmbTipoAplicacion.SelectedValue AndAlso _
                            Estado = ChkEstado.GetEstado) Then

                        Descripcion = TxtComisionDesc.Text.Trim.ToUpper
                        Estado = ChkEstado.GetEstado
                        Aplicacion = CmbTipoAplicacion.SelectedValue

                        ModPOS.Ejecuta("sp_actualiza_comision", _
                               "@CMIClave", CMIClave, _
                               "@Descripcion", Descripcion, _
                               "@Aplicacion", Aplicacion, _
                               "@Estado", Estado, _
                               "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)

                    End If

                    If DetalleEdited Then
                        ModPOS.Ejecuta("sp_elimina_comisiondet", _
                                                 "@CMIClave", CMIClave)
                        Dim fila As Integer

                        For fila = 0 To dtDetalle.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_comisiondetalle", _
                                "@CMIClave", dtDetalle.Rows(fila)("ID"), _
                                "@CMDClave", dtDetalle.Rows(fila)("CMDClave"), _
                                "@Inicial", dtDetalle.Rows(fila)("Importe Inicial"), _
                                "@Final", dtDetalle.Rows(fila)("Importe Final"), _
                                "@Comision", dtDetalle.Rows(fila)("Comisión(%)"), _
                                "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                End If
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        DetalleEdited = True
        Select Case GridDetalle.CurrentColumn.DataMember
            Case Is = "Importe Inicial"
                If Not (IsNumeric(GridDetalle.GetValue("Importe Inicial")) AndAlso GridDetalle.GetValue("Importe Inicial") >= 0) Then
                    Beep()
                    MessageBox.Show("¡La cantidad debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Importe Inicial", 0)
                End If
            Case Is = "Importe Final"
                If Not (IsNumeric(GridDetalle.GetValue("Importe Final")) AndAlso GridDetalle.GetValue("Importe Final") >= GridDetalle.GetValue("Importe Inicial")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad final debe ser mayor o igual a la cantidad inicial!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Importe Final", GridDetalle.GetValue("Importe Inicial"))
                End If
            Case Is = "Comisión(%)"
                If Not (IsNumeric(GridDetalle.GetValue("Comisión(%)")) AndAlso GridDetalle.GetValue("Comisión(%)") >= 0) Then
                    Beep()
                    MessageBox.Show("¡La cantidad debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Comisión(%)", 0)
                End If
        End Select
    End Sub

    Private Sub GridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridDetalle.KeyDown
        If e.KeyCode = Keys.Delete AndAlso GridDetalle.RowCount > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("CMDClave Like '" & GridDetalle.GetValue("CMDClave") & "'")
            dtDetalle.Rows.Remove(foundRows(0))
            DetalleEdited = True
        ElseIf e.KeyCode = Keys.Insert Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = CMIClave
            row1.Item("CMDClave") = ModPOS.obtenerLlave
            row1.Item("Importe Inicial") = 0
            row1.Item("Importe Final") = 0
            row1.Item("Comisión(%)") = 0.0
            'agrega la fila completo a la tabla
            dtDetalle.Rows.Add(row1)
        End If
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim row1 As DataRow
        row1 = dtDetalle.NewRow()
        'declara el nombre de la fila
        row1.Item("ID") = CMIClave
        row1.Item("CMDClave") = ModPOS.obtenerLlave
        row1.Item("Importe Inicial") = 0
        row1.Item("Importe Final") = 0
        row1.Item("Comisión(%)") = 0.0
        'agrega la fila completo a la tabla
        dtDetalle.Rows.Add(row1)
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If GridDetalle.RowCount > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("CMDClave Like '" & GridDetalle.GetValue("CMDClave") & "'")
            dtDetalle.Rows.Remove(foundRows(0))
            DetalleEdited = True
        End If
    End Sub
End Class
