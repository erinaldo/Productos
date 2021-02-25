Public Class FrmGasto
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpRendimiento As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtFechaEvento As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnDelGasto As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbMotivo As Selling.StoreCombo
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents TxtViaje As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAddGasto As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents BtnOperador As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents lblNomOperador As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGasto))
        Me.GrpRendimiento = New System.Windows.Forms.GroupBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.BtnAddGasto = New Janus.Windows.EditControls.UIButton
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnDelGasto = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtFechaEvento = New System.Windows.Forms.DateTimePicker
        Me.LblNombre = New System.Windows.Forms.Label
        Me.lblNomOperador = New System.Windows.Forms.Label
        Me.TxtEmpleado = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtViaje = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtFecha = New System.Windows.Forms.DateTimePicker
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnOperador = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.CmbMotivo = New Selling.StoreCombo
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.LblTotal = New System.Windows.Forms.Label
        Me.GrpRendimiento.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpRendimiento
        '
        Me.GrpRendimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpRendimiento.BackColor = System.Drawing.Color.Transparent
        Me.GrpRendimiento.Controls.Add(Me.TxtTotal)
        Me.GrpRendimiento.Controls.Add(Me.LblTotal)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox7)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox6)
        Me.GrpRendimiento.Controls.Add(Me.TxtReferencia)
        Me.GrpRendimiento.Controls.Add(Me.BtnAddGasto)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox5)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox4)
        Me.GrpRendimiento.Controls.Add(Me.PictureBox3)
        Me.GrpRendimiento.Controls.Add(Me.TxtImporte)
        Me.GrpRendimiento.Controls.Add(Me.Label13)
        Me.GrpRendimiento.Controls.Add(Me.Label12)
        Me.GrpRendimiento.Controls.Add(Me.btnDelGasto)
        Me.GrpRendimiento.Controls.Add(Me.GridDetalle)
        Me.GrpRendimiento.Controls.Add(Me.Label9)
        Me.GrpRendimiento.Controls.Add(Me.dtFechaEvento)
        Me.GrpRendimiento.Controls.Add(Me.CmbMotivo)
        Me.GrpRendimiento.Controls.Add(Me.LblNombre)
        Me.GrpRendimiento.Location = New System.Drawing.Point(6, 66)
        Me.GrpRendimiento.Name = "GrpRendimiento"
        Me.GrpRendimiento.Size = New System.Drawing.Size(688, 317)
        Me.GrpRendimiento.TabIndex = 4
        Me.GrpRendimiento.TabStop = False
        Me.GrpRendimiento.Text = "Detalle"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(10, 67)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox7.TabIndex = 142
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(537, 27)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox6.TabIndex = 141
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(403, 26)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(93, 20)
        Me.TxtReferencia.TabIndex = 5
        '
        'BtnAddGasto
        '
        Me.BtnAddGasto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddGasto.Icon = CType(resources.GetObject("BtnAddGasto.Icon"), System.Drawing.Icon)
        Me.BtnAddGasto.Location = New System.Drawing.Point(651, 55)
        Me.BtnAddGasto.Name = "BtnAddGasto"
        Me.BtnAddGasto.Size = New System.Drawing.Size(31, 30)
        Me.BtnAddGasto.TabIndex = 9
        Me.BtnAddGasto.ToolTipText = "Agregar registro actual"
        Me.BtnAddGasto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(369, 29)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox5.TabIndex = 139
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(208, 26)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox4.TabIndex = 138
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(44, 23)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox3.TabIndex = 125
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'TxtImporte
        '
        Me.TxtImporte.Location = New System.Drawing.Point(562, 27)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(120, 20)
        Me.TxtImporte.TabIndex = 3
        Me.TxtImporte.Text = "0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtImporte.Value = 0
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(502, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "Importe"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(6, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 12)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Motivo"
        '
        'btnDelGasto
        '
        Me.btnDelGasto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelGasto.Icon = CType(resources.GetObject("btnDelGasto.Icon"), System.Drawing.Icon)
        Me.btnDelGasto.Location = New System.Drawing.Point(612, 55)
        Me.btnDelGasto.Name = "btnDelGasto"
        Me.btnDelGasto.Size = New System.Drawing.Size(31, 30)
        Me.btnDelGasto.TabIndex = 10
        Me.btnDelGasto.ToolTipText = "Elimina el ultimo registro"
        Me.btnDelGasto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.Location = New System.Drawing.Point(6, 91)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(676, 188)
        Me.GridDetalle.TabIndex = 129
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(195, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "Fecha"
        '
        'dtFechaEvento
        '
        Me.dtFechaEvento.CustomFormat = "yyyyMMdd"
        Me.dtFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaEvento.Location = New System.Drawing.Point(241, 27)
        Me.dtFechaEvento.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtFechaEvento.Name = "dtFechaEvento"
        Me.dtFechaEvento.Size = New System.Drawing.Size(95, 20)
        Me.dtFechaEvento.TabIndex = 7
        Me.dtFechaEvento.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(343, 29)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(71, 15)
        Me.LblNombre.TabIndex = 140
        Me.LblNombre.Text = "Referencia"
        '
        'lblNomOperador
        '
        Me.lblNomOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomOperador.Location = New System.Drawing.Point(239, 42)
        Me.lblNomOperador.Name = "lblNomOperador"
        Me.lblNomOperador.Size = New System.Drawing.Size(457, 15)
        Me.lblNomOperador.TabIndex = 171
        '
        'TxtEmpleado
        '
        Me.TxtEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtEmpleado.Location = New System.Drawing.Point(103, 39)
        Me.TxtEmpleado.Name = "TxtEmpleado"
        Me.TxtEmpleado.Size = New System.Drawing.Size(73, 21)
        Me.TxtEmpleado.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 15)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "Operador"
        '
        'TxtViaje
        '
        Me.TxtViaje.Location = New System.Drawing.Point(345, 10)
        Me.TxtViaje.Name = "TxtViaje"
        Me.TxtViaje.Size = New System.Drawing.Size(349, 20)
        Me.TxtViaje.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(239, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 15)
        Me.Label14.TabIndex = 142
        Me.Label14.Text = "Trayecto o Viaje"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 15)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Fecha de evento"
        '
        'dtFecha
        '
        Me.dtFecha.CustomFormat = "yyyyMMdd"
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(101, 10)
        Me.dtFecha.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(120, 20)
        Me.dtFecha.TabIndex = 129
        Me.dtFecha.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(320, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox1.TabIndex = 145
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(78, 39)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 21)
        Me.PictureBox2.TabIndex = 170
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnOperador
        '
        Me.BtnOperador.Image = CType(resources.GetObject("BtnOperador.Image"), System.Drawing.Image)
        Me.BtnOperador.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnOperador.Location = New System.Drawing.Point(182, 38)
        Me.BtnOperador.Name = "BtnOperador"
        Me.BtnOperador.Size = New System.Drawing.Size(35, 22)
        Me.BtnOperador.TabIndex = 168
        Me.BtnOperador.ToolTipText = "Busqueda de Operador o Chofer"
        Me.BtnOperador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(510, 389)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(606, 389)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbMotivo
        '
        Me.CmbMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbMotivo.Location = New System.Drawing.Point(69, 26)
        Me.CmbMotivo.Name = "CmbMotivo"
        Me.CmbMotivo.Size = New System.Drawing.Size(120, 21)
        Me.CmbMotivo.TabIndex = 8
        '
        'TxtTotal
        '
        Me.TxtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(557, 285)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(125, 26)
        Me.TxtTotal.TabIndex = 143
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(516, 294)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(39, 15)
        Me.LblTotal.TabIndex = 144
        Me.LblTotal.Text = "Total"
        '
        'FrmGasto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(706, 429)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblNomOperador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtViaje)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.dtFecha)
        Me.Controls.Add(Me.TxtEmpleado)
        Me.Controls.Add(Me.BtnOperador)
        Me.Controls.Add(Me.GrpRendimiento)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(602, 338)
        Me.Name = "FrmGasto"
        Me.Text = "Control de Gastos"
        Me.GrpRendimiento.ResumeLayout(False)
        Me.GrpRendimiento.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Padre As String

    Public GASClave As String = ""
    Public Fecha As DateTime = Today
    Public Viaje As String = ""
    Public EMPClave As String = ""
    Public Total As Double = 0.0

    Private alerta(6) As PictureBox
    Private reloj As parpadea
    Private bMotivo As Boolean = False
    Private bLoad As Boolean = False
    Private bError As Boolean = False


    Private dtDetalle, dtTipoMotivo As DataTable


    Private Sub cargaDetalle()
        dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_gastodetalle", "@GASClave", GASClave)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("nvo").Visible = False


        GridDetalle.CurrentTable.Columns("Motivo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("Motivo").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoMotivo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Gasto", "@Campo", "Motivo")

            Dim i As Integer

            For i = 0 To dtTipoMotivo.Rows.Count - 1
                .Add(dtTipoMotivo.Rows(i)("valor"), dtTipoMotivo.Rows(i)("descripcion"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("Motivo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("nvo"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

        bMotivo = True

    End Sub

    Private Function validaGasto() As Boolean
        Dim i As Integer = 0

        If Me.CmbMotivo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtReferencia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(Me.TxtImporte.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
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

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtViaje.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If EMPClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
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

    Private Sub FrmGasto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7

        dtFechaEvento.Value = DateTime.Today

        With CmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Gasto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With


        bLoad = True


        dtFecha.Value = Fecha
        TxtViaje.Text = Viaje



        If Padre = "Agregar" Then

        Else
            CargaDatosEmpleado(EMPClave)
        End If


        cargaDetalle()

        TxtTotal.Text = Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

    End Sub

    Public Sub reinicializar()
        EMPClave = ""
        Viaje = ""
        Fecha = Today

    End Sub

    Private Sub FrmGasto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bError Then
            MessageBox.Show("Se ha eliminado uno o más registros, por lo que debe guardar cambios para salir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            e.Cancel = True
        Else
            ModPOS.Gasto.Dispose()
            ModPOS.Gasto = Nothing

        End If
    End Sub

    Private Sub BtnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            bError = False
            Select Case Me.Padre
                Case "Agregar"
                    GASClave = ModPOS.obtenerLlave
                    Viaje = TxtViaje.Text.ToUpper
                    Fecha = dtFecha.Value
                    Total = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)


                    ModPOS.Ejecuta("sp_inserta_gasto", _
                        "@GASClave", GASClave, _
                        "@Fecha", Fecha, _
                        "@Viaje", Viaje, _
                        "@EMPClave", EMPClave, _
                        "@Total", Total, _
                        "@COMClave", ModPOS.CompanyActual, _
                        "@Usuario", ModPOS.UsuarioActual)

                    Dim foundRows() As DataRow
                    foundRows = dtDetalle.Select("nvo = 1 ")
                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        For i = 0 To foundRows.GetUpperBound(0)
                            ' Agrega
                            ModPOS.Ejecuta("sp_inserta_gastodetalle", _
                         "@GASClave", GASClave, _
                         "@GADClave", foundRows(i)("id"), _
                         "@Motivo", foundRows(i)("Motivo"), _
                         "@Fecha", foundRows(i)("Fecha"), _
                         "@Referencia", foundRows(i)("Referencia"), _
                         "@Importe", foundRows(i)("Importe"))

                        Next
                    End If

                    reinicializar()

                    If Not ModPOS.MtoGasto Is Nothing Then
                        ModPOS.MtoGasto.refrescaGrid()
                    End If


                Case "Modificar"

                    Dim dTotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)


                    If Not (TxtViaje.Text = Viaje AndAlso _
                        dtFecha.Value = Fecha AndAlso dTotal = Total) Then


                        Viaje = TxtViaje.Text.ToUpper
                        Fecha = dtFecha.Value
                        Total = dTotal


                        ModPOS.Ejecuta("sp_modificar_gasto", _
                        "@GASClave", GASClave, _
                        "@Fecha", Fecha, _
                        "@Viaje", Viaje, _
                        "@Total", Total, _
                        "@Usuario", ModPOS.UsuarioActual)



                        If Not ModPOS.MtoGasto Is Nothing Then
                            ModPOS.MtoGasto.refrescaGrid()
                        End If

                    End If

                        Dim foundRows() As DataRow
                    foundRows = dtDetalle.Select("nvo = 1 ")
                        If foundRows.GetLength(0) > 0 Then
                            Dim i As Integer
                            For i = 0 To foundRows.GetUpperBound(0)
                                ' Agrega
                            ModPOS.Ejecuta("sp_inserta_gastodetalle", _
                                                   "@GASClave", GASClave, _
                                                   "@GADClave", foundRows(i)("id"), _
                                                   "@Motivo", foundRows(i)("Motivo"), _
                                                   "@Fecha", foundRows(i)("Fecha"), _
                                                   "@Referencia", foundRows(i)("Referencia"), _
                                                   "@Importe", foundRows(i)("Importe"))


                            Next
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


    Private Sub UiTab_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs)
        If e.Page.Name = "UiTabCombustible" Then
            If bMotivo = False Then
                cargaDetalle()
            End If

        End If
    End Sub

    Private Sub BtnAddGasto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddGasto.Click
        If validaGasto() Then


            'Agrega a dtDetalle

            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("id") = dtDetalle.Rows.Count + 1
            row1.Item("Motivo") = CmbMotivo.SelectedValue
            row1.Item("Fecha") = dtFechaEvento.Value
            row1.Item("Referencia") = TxtReferencia.Text
            row1.Item("Importe") = TxtImporte.Text
            row1.Item("nvo") = 1
            dtDetalle.Rows.Add(row1)


            TxtReferencia.Text = ""
            TxtImporte.Text = 0

            Dim dTotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
            TxtTotal.Text = Format(CStr(ModPOS.Redondear(dTotal, 2)), "Currency")

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDelCombustible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelGasto.Click
        If dtDetalle.Rows.Count > 0 Then

            If MessageBox.Show("¿Esta seguro de remover el id " & CStr(dtDetalle.Rows.Count) & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim foundRows() As System.Data.DataRow



                'Elimina Detalle
                If Padre <> "Agregar" Then
                    ModPOS.Ejecuta("sp_elimina_gastodetalle", "@GADClave", dtDetalle.Rows.Count, "@GASClave", GASClave)
                End If

                foundRows = dtDetalle.Select("id = " & CStr(dtDetalle.Rows.Count))

                If foundRows.GetLength(0) > 0 Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        dtDetalle.Rows.Remove(foundRows(i))
                    Next

                End If

                Dim dTotal As Double = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
                TxtTotal.Text = Format(CStr(ModPOS.Redondear(dTotal, 2)), "Currency")

                bError = True

            End If

        Else
            MessageBox.Show("No se encontro registro para ser eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargaDatosEmpleado(ByVal sEMPClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_empleado", "@EMPClave", sEMPClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            EMPClave = dt.Rows(0)("EMPClave")
            TxtEmpleado.Text = dt.Rows(0)("NumEmpleado")
            lblNomOperador.Text = dt.Rows(0)("NombreCompleto")
            dt.Dispose()
        Else
            EMPClave = ""
            TxtEmpleado.Text = ""
            lblNomOperador.Text = ""
            MessageBox.Show("La información del empleado no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnOperador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOperador.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_empleado"
        a.TablaCmb = "Empleado"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.NumColDes = 1
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = "%"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Descripcion Is Nothing Then
                CargaDatosEmpleado(a.valor)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtEmpleado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEmpleado.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtEmpleado.Text <> "" Then
                    Dim dtEmpleado As DataTable
                    dtEmpleado = ModPOS.SiExisteRecupera("sp_consulta_empleado", "@NumEmpleado", TxtEmpleado.Text, "@COMClave", ModPOS.CompanyActual)
                    If Not dtEmpleado Is Nothing AndAlso dtEmpleado.Rows.Count > 0 Then
                        Dim sEMPClave As String = dtEmpleado.Rows(0)("EMPClave")
                        dtEmpleado.Dispose()
                        CargaDatosEmpleado(sEMPClave)


                    Else
                        EMPClave = ""
                        TxtEmpleado.Text = ""
                        lblNomOperador.Text = ""

                        MessageBox.Show("No se encontraron coincidencias para el Número de Empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_empleado"
                a.TablaCmb = "Empleado"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.NumColDes = 1
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = "%"
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Descripcion Is Nothing Then
                        CargaDatosEmpleado(a.valor)
                    End If
                End If
                a.Dispose()

        End Select

    End Sub
End Class
