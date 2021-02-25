Public Class FrmTarifa
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
    Friend WithEvents btnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemover As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpTarifa As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtClave As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents LblSerie As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtModificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTarifa))
        Me.btnCerrar = New Janus.Windows.EditControls.UIButton
        Me.btnAceptar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.txtModificar = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.btnRemover = New Janus.Windows.EditControls.UIButton
        Me.btnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpTarifa = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.TxtRFC = New System.Windows.Forms.TextBox
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtClave = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.LblSerie = New System.Windows.Forms.Label
        Me.GrpDetalle.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTarifa.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(639, 345)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 37)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "&Salir"
        Me.btnCerrar.ToolTipText = "Cancelar y cerrar ventana"
        Me.btnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.Location = New System.Drawing.Point(735, 345)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.ToolTipText = "Guardar cambios"
        Me.btnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.Transparent
        Me.GrpDetalle.Controls.Add(Me.txtModificar)
        Me.GrpDetalle.Controls.Add(Me.PictureBox2)
        Me.GrpDetalle.Controls.Add(Me.btnRemover)
        Me.GrpDetalle.Controls.Add(Me.btnAgregar)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(3, 119)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(828, 220)
        Me.GrpDetalle.TabIndex = 10
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Trayectos"
        '
        'txtModificar
        '
        Me.txtModificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtModificar.Icon = CType(resources.GetObject("txtModificar.Icon"), System.Drawing.Icon)
        Me.txtModificar.Location = New System.Drawing.Point(708, 13)
        Me.txtModificar.Name = "txtModificar"
        Me.txtModificar.Size = New System.Drawing.Size(34, 30)
        Me.txtModificar.TabIndex = 30
        Me.txtModificar.ToolTipText = "Modifia Trayecto Seleccionado"
        Me.txtModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 29
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnRemover
        '
        Me.btnRemover.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemover.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnRemover.Icon = CType(resources.GetObject("btnRemover.Icon"), System.Drawing.Icon)
        Me.btnRemover.Location = New System.Drawing.Point(786, 13)
        Me.btnRemover.Name = "btnRemover"
        Me.btnRemover.Size = New System.Drawing.Size(35, 30)
        Me.btnRemover.TabIndex = 10
        Me.btnRemover.ToolTipText = "Remueve el trayecto seleccionado"
        Me.btnRemover.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnAgregar.Icon = CType(resources.GetObject("btnAgregar.Icon"), System.Drawing.Icon)
        Me.btnAgregar.Location = New System.Drawing.Point(747, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(34, 30)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.ToolTipText = "Agrega nuevo Trayecto"
        Me.btnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 48)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(815, 163)
        Me.GridDetalle.TabIndex = 6
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpTarifa
        '
        Me.GrpTarifa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTarifa.BackColor = System.Drawing.Color.Transparent
        Me.GrpTarifa.Controls.Add(Me.Label1)
        Me.GrpTarifa.Controls.Add(Me.TxtRazonSocial)
        Me.GrpTarifa.Controls.Add(Me.TxtRFC)
        Me.GrpTarifa.Controls.Add(Me.BtnBuscaCte)
        Me.GrpTarifa.Controls.Add(Me.ChkEstado)
        Me.GrpTarifa.Controls.Add(Me.PictureBox1)
        Me.GrpTarifa.Controls.Add(Me.txtClave)
        Me.GrpTarifa.Controls.Add(Me.LblClave)
        Me.GrpTarifa.Controls.Add(Me.LblSerie)
        Me.GrpTarifa.Location = New System.Drawing.Point(3, 6)
        Me.GrpTarifa.Name = "GrpTarifa"
        Me.GrpTarifa.Size = New System.Drawing.Size(828, 107)
        Me.GrpTarifa.TabIndex = 9
        Me.GrpTarifa.TabStop = False
        Me.GrpTarifa.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "RFC"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(90, 70)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(657, 24)
        Me.TxtRazonSocial.TabIndex = 95
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(90, 44)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(142, 21)
        Me.TxtRFC.TabIndex = 94
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(215, 19)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(27, 22)
        Me.BtnBuscaCte.TabIndex = 31
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(614, 12)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(58, 22)
        Me.ChkEstado.TabIndex = 30
        Me.ChkEstado.Text = "Activo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(67, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(90, 19)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(120, 20)
        Me.txtClave.TabIndex = 1
        Me.txtClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(8, 23)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Clave"
        '
        'LblSerie
        '
        Me.LblSerie.Location = New System.Drawing.Point(8, 73)
        Me.LblSerie.Name = "LblSerie"
        Me.LblSerie.Size = New System.Drawing.Size(72, 15)
        Me.LblSerie.TabIndex = 26
        Me.LblSerie.Text = "Razón Social"
        '
        'FrmTarifa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(834, 388)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpTarifa)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(602, 338)
        Me.Name = "FrmTarifa"
        Me.Text = "Tarifa"
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTarifa.ResumeLayout(False)
        Me.GrpTarifa.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String

    Public TARClave As String
    Public CTEClave As String

    Public Clave, RazonSocial, RFC As String

    Public Estado As Integer = 1

    Private dtTarifas As DataTable
    Private sTarifaSelected, sClienteSelected, sNombre, sOrigen, sDestino As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private ClienteEdited As Boolean = False

    Private guardado As Boolean = False
    Private bLoad As Boolean = False

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.txtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If dtTarifas.Rows.Count = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If



        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Tarifa", "@clave", CTEClave, "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("El Cliente seleccionado ya cuenta con una Tarifa previamente registrada en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub FrmTransporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        txtClave.Text = Clave
        TxtRazonSocial.Text = RazonSocial
        ChkEstado.Estado = Estado

        If Padre = "Agregar" Then

            dtTarifas = ModPOS.CrearTabla("Tarifas", _
            "DTARClave", "System.String", _
            "estadoOrigen", "System.String", _
            "mnpioOrigen", "System.String", _
            "Origen", "System.String", _
            "estadoDestino", "System.String", _
            "mnpioDestino", "System.String", _
            "Destino", "System.String", _
            "IMPClave", "System.String", _
            "ISR", "System.Double", _
            "Tasa", "System.Double", _
            "Tarifa", "System.Double", _
            "TarifaR", "System.Double", _
            "Seco", "System.Double", _
            "Refrigerado", "System.Double", _
            "Nuevo", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")

           
        Else
            txtClave.Enabled = False
            Me.BtnBuscaCte.Enabled = False

            AddCliente(CTEClave, Clave, RazonSocial, RFC)
            dtTarifas = ModPOS.Recupera_Tabla("sp_muestra_tarifa_detalle", "@TARClave", TARClave)
        End If

        GridDetalle.DataSource = dtTarifas
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DTARClave").Visible = False
        GridDetalle.RootTable.Columns("estadoOrigen").Visible = False
        GridDetalle.RootTable.Columns("mnpioOrigen").Visible = False
        GridDetalle.RootTable.Columns("Origen").Selectable = False
        GridDetalle.RootTable.Columns("Destino").Selectable = False
        GridDetalle.RootTable.Columns("estadoDestino").Visible = False
        GridDetalle.RootTable.Columns("mnpioDestino").Visible = False
        GridDetalle.RootTable.Columns("Tasa").Visible = False
        GridDetalle.RootTable.Columns("IMPClave").Visible = False
        GridDetalle.RootTable.Columns("ISR").Visible = False
        GridDetalle.RootTable.Columns("Tarifa").Visible = False
        GridDetalle.RootTable.Columns("TarifaR").Visible = False
        GridDetalle.RootTable.Columns("Seco").Selectable = False
        GridDetalle.RootTable.Columns("Refrigerado").Selectable = False
        GridDetalle.RootTable.Columns("Update").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Baja").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc)

    End Sub

    'Public Sub reinicializar()
    '    Clave = ""
    '    Descripcion = ""
    '    Estado = 1
    '    txtClave.Text = Clave
    '    txtDescripcion.Text = Descripcion
    '    ChkEstado.Estado = Estado

    'End Sub

    Private Sub FrmTarifa_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Padre = "Agregar" AndAlso guardado Then
            If Not ModPOS.MtoTarifa Is Nothing Then
                ModPOS.ActualizaGrid(True, ModPOS.MtoTarifa.GridTarifas, "sp_muestra_tarifas", "@COMClave", ModPOS.CompanyActual)
                ModPOS.MtoTarifa.GridTarifas.RootTable.Columns("TARClave").Visible = False
            End If
        End If
        ModPOS.Tarifa.Dispose()
        ModPOS.Tarifa = Nothing
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If validaForm() Then
            Dim foundRows() As System.Data.DataRow

            
            Select Case Me.Padre
                Case "Agregar"
                    TARClave = ModPOS.obtenerLlave

                    Estado = ChkEstado.GetEstado

                    ModPOS.Ejecuta("sp_inserta_tarifa", _
                        "@TARClave", TARClave, _
                        "@CTEClave", CTEClave, _
                        "@Estado", Estado, _
                        "@COMClave", ModPOS.CompanyActual, _
                        "@Usuario", ModPOS.UsuarioActual)


                    foundRows = dtTarifas.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        Dim z As Integer
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_tarifa_detatalle", _
                            "@TARClave", TARClave, _
                            "@DTARClave", foundRows(z)("DTARClave"), _
                            "@estadoOrigen", foundRows(z)("estadoOrigen"), _
                            "@mnpioOrigen", foundRows(z)("mnpioOrigen"), _
                            "@estadoDestino", foundRows(z)("estadoDestino"), _
                            "@mnpioDestino", foundRows(z)("mnpioDestino"), _
                            "@Tarifa", foundRows(z)("Tarifa"), _
                            "@TarifaR", foundRows(z)("TarifaR"), _
                            "@IMPClave", foundRows(z)("IMPClave"), _
                            "@Tasa", foundRows(z)("Tasa"), _
                            "@ISR", foundRows(z)("ISR"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    guardado = True

                    Me.Close()

                Case "Modificar"


                    If Not (Estado = ChkEstado.GetEstado) Then


                        Estado = ChkEstado.GetEstado


                        ModPOS.Ejecuta("sp_modificar_tarifa", _
                        "@TARClave", TARClave, _
                        "@Estado", Estado, _
                        "@Usuario", ModPOS.UsuarioActual)


                        If Not ModPOS.MtoTarifa Is Nothing Then
                            ModPOS.ActualizaGrid(True, ModPOS.MtoTarifa.GridTarifas, "sp_muestra_tarifas", "@COMClave", ModPOS.CompanyActual)
                            ModPOS.MtoTarifa.GridTarifas.RootTable.Columns("TARClave").Visible = False
                        End If

                    End If

                    foundRows = dtTarifas.Select(" Nuevo = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_tarifa_detatalle", _
                            "@TARClave", TARClave, _
                            "@DTARClave", foundRows(z)("DTARClave"), _
                            "@estadoOrigen", foundRows(z)("estadoOrigen"), _
                            "@mnpioOrigen", foundRows(z)("mnpioOrigen"), _
                            "@estadoDestino", foundRows(z)("estadoDestino"), _
                            "@mnpioDestino", foundRows(z)("mnpioDestino"), _
                            "@Tarifa", foundRows(z)("Tarifa"), _
                            "@TarifaR", foundRows(z)("TarifaR"), _
                            "@IMPClave", foundRows(z)("IMPClave"), _
                            "@Tasa", foundRows(z)("Tasa"), _
                            "@ISR", foundRows(z)("ISR"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtTarifas.Select(" Nuevo = 0 and Update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_tarifa_detatalle", _
                            "@DTARClave", foundRows(z)("DTARClave"), _
                            "@Tarifa", foundRows(z)("Tarifa"), _
                            "@TarifaR", foundRows(z)("TarifaR"), _
                            "@IMPClave", foundRows(z)("IMPClave"), _
                            "@Tasa", foundRows(z)("Tasa"), _
                            "@ISR", foundRows(z)("ISR"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtTarifas.Select(" Nuevo = 0 and Baja = 1 ")

                    If foundRows.Length <> 0 Then

                        Dim z As Integer

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_tarifa_detatalle", _
                            "@DTARClave", foundRows(z)("DTARClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
        If Me.sTarifaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el trayecto " & sOrigen & "\" & sDestino, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtTarifas.Select("DTARClave Like '" & sTarifaSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        modificar()
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        If Not Me.GridDetalle.GetValue(0) Is Nothing Then
            Me.btnRemover.Enabled = True
            Me.sTarifaSelected = GridDetalle.GetValue("DTARClave")
            sOrigen = GridDetalle.GetValue("Origen")
            sDestino = GridDetalle.GetValue("Destino")
        Else
            Me.sTarifaSelected = ""
            sOrigen = ""
            sDestino = ""
            Me.btnRemover.Enabled = False
        End If
    End Sub

    Public Function AddTarifa( _
    ByVal Padre As String, _
    ByVal sDTARClave As String, _
    ByVal sEntidadOrigen As String, _
    ByVal sLocalidadOrigen As String, _
    ByVal sOrigen As String, _
    ByVal sEntidadDestino As String, _
    ByVal sLocalidadDestino As String, _
    ByVal sDestino As String, _
    ByVal sIMPClave As String, _
    ByVal dISR As Double, _
    ByVal dTasa As Double, _
    ByVal dTarifa As Double, _
    ByVal dTarifaR As Double, _
    ByVal dTotal As Double, _
    ByVal dTotalR As Double) As Boolean

        Dim foundRows() As Data.DataRow

        If Padre = "Agregar" Then
            foundRows = dtTarifas.Select("estadoOrigen = '" & sEntidadOrigen & "' and mnpioOrigen = '" & sLocalidadOrigen & "' and estadoDestino = '" & sEntidadDestino & "' and  mnpioDestino = '" & sLocalidadDestino & "' and Baja = 0")

            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtTarifas.NewRow()
                'declara el nombre de la fila

                row1.Item("DTARClave") = sDTARClave
                row1.Item("estadoOrigen") = sEntidadOrigen
                row1.Item("mnpioOrigen") = sLocalidadOrigen
                row1.Item("Origen") = sOrigen
                row1.Item("estadoDestino") = sEntidadDestino
                row1.Item("mnpioDestino") = sLocalidadDestino
                row1.Item("Destino") = sDestino
                row1.Item("IMPClave") = sIMPClave
                row1.Item("ISR") = dISR
                row1.Item("Tasa") = dTasa
                row1.Item("Tarifa") = dTarifa
                row1.Item("TarifaR") = dTarifaR
                row1.Item("Seco") = dTotal
                row1.Item("Refrigerado") = dTotalR
                row1.Item("Nuevo") = 1
                row1.Item("Update") = 0
                row1.Item("Baja") = 0


                dtTarifas.Rows.Add(row1)
                'agrega la fila completo a la tabla
                Return True
            Else
                Beep()
                MessageBox.Show("¡El trayecto (origen/destino) que intenta agregar ya tiene una tarifa asignada para el listado actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If
        Else

            foundRows = dtTarifas.Select("DTARClave = '" & sDTARClave & "'")
            If foundRows.Length = 1 Then
                foundRows(0)("IMPClave") = sIMPClave
                foundRows(0)("ISR") = dISR
                foundRows(0)("Tasa") = dTasa
                foundRows(0)("Tarifa") = dTarifa
                foundRows(0)("TarifaR") = dTarifaR
                foundRows(0)("Seco") = dTotal
                foundRows(0)("Refrigerado") = dTotalR
                foundRows(0)("Update") = 1
            End If
            End If
    End Function

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim a As New FrmAddTarifa
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Public Function AddCliente(ByVal sCTEClave As String, ByVal sClave As String, ByVal sRazonSocial As String, ByVal sRFC As String) As Boolean
        CTEClave = sCTEClave
        txtClave.Text = sClave
        TxtRFC.Text = sRFC
        TxtRazonSocial.Text = sRazonSocial
    End Function

    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                AddCliente(a.valor, a.Descripcion, a.Descripcion2, a.Descripcion3)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub txtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtClave.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", txtClave.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        AddCliente(dtCliente.Rows(0)("CTEClave"), dtCliente.Rows(0)("Clave"), dtCliente.Rows(0)("RazonSocial"), dtCliente.Rows(0)("id_Fiscal"))
                        dtCliente.Dispose()
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = txtClave.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        AddCliente(a.valor, a.Descripcion, a.Descripcion2, a.Descripcion3)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub


    Private Sub modificar()
        Dim a As New FrmAddTarifa
        a.Padre = "Modificar"
        a.DTARClave = sTarifaSelected
        a.estadoOrigen = GridDetalle.GetValue("estadoOrigen")
        a.mnpioOrigen = GridDetalle.GetValue("mnpioOrigen")
        a.estadoDestino = GridDetalle.GetValue("estadoDestino")
        a.mnpioDestino = GridDetalle.GetValue("mnpioDestino")
        a.ImpuestoActual = GridDetalle.GetValue("IMPClave")
        a.dISR = GridDetalle.GetValue("ISR")
        a.Tasa = GridDetalle.GetValue("Tasa")
        a.dTarifa = GridDetalle.GetValue("Tarifa")
        a.dTarifaR = GridDetalle.GetValue("TarifaR")
        a.ShowDialog()
    End Sub

    Private Sub txtModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModificar.Click
        modificar()
    End Sub
End Class
