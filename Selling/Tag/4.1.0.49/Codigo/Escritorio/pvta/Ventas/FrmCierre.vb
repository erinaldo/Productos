
Public Class FrmCierre
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpCortes As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCortes As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCierre))
        Me.GrpCortes = New System.Windows.Forms.GroupBox()
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCortes = New Janus.Windows.GridEX.GridEX()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.GrpCortes.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCortes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCortes
        '
        Me.GrpCortes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCortes.Controls.Add(Me.cmbFechaInicio)
        Me.GrpCortes.Controls.Add(Me.BtnGuardar)
        Me.GrpCortes.Controls.Add(Me.Label3)
        Me.GrpCortes.Controls.Add(Me.PictureBox1)
        Me.GrpCortes.Controls.Add(Me.CmbSucursal)
        Me.GrpCortes.Controls.Add(Me.BtnSalir)
        Me.GrpCortes.Controls.Add(Me.Label1)
        Me.GrpCortes.Controls.Add(Me.GridCortes)
        Me.GrpCortes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCortes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCortes.ForeColor = System.Drawing.Color.Black
        Me.GrpCortes.Location = New System.Drawing.Point(0, 0)
        Me.GrpCortes.Name = "GrpCortes"
        Me.GrpCortes.Size = New System.Drawing.Size(742, 473)
        Me.GrpCortes.TabIndex = 1
        Me.GrpCortes.TabStop = False
        Me.GrpCortes.Text = "Aperturas de Caja"
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(610, 15)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 22)
        Me.cmbFechaInicio.TabIndex = 69
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.Icon = CType(resources.GetObject("BtnGuardar.Icon"), System.Drawing.Icon)
        Me.BtnGuardar.Location = New System.Drawing.Point(646, 430)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 24
        Me.BtnGuardar.Text = "&Cerrar"
        Me.BtnGuardar.ToolTipText = "Cierra las Operaciones de Cajas"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Apertura"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(402, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 18)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(550, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridCortes
        '
        Me.GridCortes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCortes.ColumnAutoResize = True
        Me.GridCortes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCortes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCortes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCortes.Location = New System.Drawing.Point(7, 45)
        Me.GridCortes.Name = "GridCortes"
        Me.GridCortes.RecordNavigator = True
        Me.GridCortes.Size = New System.Drawing.Size(728, 379)
        Me.GridCortes.TabIndex = 2
        Me.GridCortes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(81, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(315, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'FrmCierre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpCortes)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmCierre"
        Me.Text = "Cierre de Operaciones de Caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpCortes.ResumeLayout(False)
        Me.GrpCortes.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCortes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private bLoad As Boolean = False
    Private sSUCClave As String

    Private dtApertura As DataTable
    Private InterfazSalida As String = ""

    Private oCFD As Selling.CFD
    Private FACClave As String
    Private FacturarValido As Boolean = True
    Private tImpuesto As Integer
    Private VersionCF As String
    Private iRegimenFiscal As Integer
    Private CobranzaVenta As Boolean = False
    Private TallaColor As Integer = 0
    Private CAJClave As String
    Private PathXML As String
    Private TipoCF, MailPort As Integer
    Private FormatoFactura As String
    Private MailSSL As Boolean
    Private MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, Moneda, MonedaDesc, MonedaRef As String
    Private TipoCambio As Decimal
    Private dPorc As Decimal = 0

    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtApertura Is Nothing Then
            dtApertura.Dispose()
        End If

        Dim FechaIni As Date = cmbFechaInicio.Value
        Dim FechaFin As Date = cmbFechaInicio.Value.AddHours(23.9999)

        dtApertura = ModPOS.Recupera_Tabla("st_muestra_cortes_caja", "@SUCClave", sSUCClave, "@Inicial", FechaIni, "@Final", FechaFin)
        GridCortes.DataSource = dtApertura
        GridCortes.RetrieveStructure()
        GridCortes.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."
        Me.GridCortes.RootTable.Columns("ID").Visible = False
        Me.GridCortes.RootTable.Columns("CAJClave").Visible = False
        '  GridCortes.RootTable.Columns("ImporteEntregado").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.GridCortes.RootTable.Columns("ImporteTransferido").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

    End Sub

    Private Sub FrmCierre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

        Dim dtParam As DataTable
        Dim i As Integer
        Dim dtmsg As DataTable


        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))

                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "VersionCF"
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
                    Case "CobranzaVenta"
                        CobranzaVenta = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", False, dtParam.Rows(i)("Valor"))
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                End Select
            Next
        End With
        dtParam.Dispose()



        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        Me.cmbFechaInicio.Value = Today

        refrescaGrid()

        Cursor.Current = Cursors.Default
        bLoad = True

    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0



        If Me.CmbSucursal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Private Sub FrmCierre_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Cierre.Dispose()
        ModPOS.Cierre = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub


    Private Sub GridNC_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridCortes.CurrentCellChanged
        If Not GridCortes.CurrentColumn Is Nothing Then
                GridCortes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim foundRows() As DataRow
        Dim mensaje As String
        foundRows = dtApertura.Select("Corte='Abierto'")

        If foundRows.GetLength(0) > 0 Then
                Beep()
            MessageBox.Show("¡Alguna de las cajas se encuentra Abierta, debe cerrarla para continuar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
        End If

        Dim z As Integer

        foundRows = dtApertura.Select("Corte='Cerrado' and  Estatus='Pendiente'")

        If foundRows.GetLength(0) > 0 Then
            Dim IdGlobal As String = ModPOS.obtenerLlave

            For z = 0 To foundRows.GetUpperBound(0)
                mensaje = ModPOS.Ejecuta("st_act_corte_global", "@ID", foundRows(z)("ID"), "@IdGlobal", IdGlobal, "@Usuario", ModPOS.UsuarioActual)
                If mensaje <> "OK" Then
                    MessageBox.Show(mensaje, "Interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next

            Dim dtVentas As DataTable = ModPOS.Recupera_Tabla("st_valida_ventas_cierre", "@IdGlobal", IdGlobal)

            If dtVentas.Rows.Count > 0 Then

                For z = 0 To foundRows.GetUpperBound(0)
                    mensaje = ModPOS.Ejecuta("st_act_corte_global", "@ID", foundRows(z)("ID"), "@IdGlobal", Nothing, "@Usuario", ModPOS.UsuarioActual)
                    If mensaje <> "OK" Then
                        MessageBox.Show(mensaje, "Interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next


                MessageBox.Show("Se encontraron ventas de contado pendientes de cobro. Cancele las ventas o realice el cobro en una caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                Dim b As New FrmConsultaGen
                b.Text = "Errores"
                b.GridConsultaGen.DataSource = dtVentas
                b.GridConsultaGen.RetrieveStructure(True)
                b.GridConsultaGen.GroupByBoxVisible = False
                b.ShowDialog()
                b.Dispose()
                dtVentas.Dispose()

                Exit Sub
            End If

            If InterfazSalida <> "" Then

                Dim frmstatusmessage As frmStatus = Nothing

                frmstatusmessage = New frmStatus
                frmstatusmessage.Show("Ejecutando Interfaz Traspaso a Banco...")

                Dim sFolio, sFecha As String
                Dim dtInterfaz As DataTable
                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                sFolio = IdGlobal

                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "TraspasoBanco", "@COMClave", ModPOS.CompanyActual)
                If dtInterfaz.Rows.Count > 0 Then
                    mensaje = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", -1)
                    If mensaje <> "OK" Then
                        MessageBox.Show(mensaje, "Interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If

                'genera interfaz al cierre de dia

                sFolio = DateTime.Now.ToString("yyyyMMdd")

                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "", "@COMClave", ModPOS.CompanyActual, "@Cierre", 1)
                If dtInterfaz.Rows.Count > 0 Then
                    Dim i As Integer
                    For i = 0 To dtInterfaz.Rows.Count - 1

                        frmstatusmessage.Show("Ejecutando..." & CStr(dtInterfaz.Rows(i)("sp")))
                        mensaje = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(i)("sp")), "@Folio", sFolio, "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", -1)
                        If mensaje <> "OK" Then
                            MessageBox.Show(mensaje, "Interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Next
                End If

                frmstatusmessage.Close()

            End If

            Dim frmMessage As frmStatus = New frmStatus
            frmMessage.Show("Generando factura global...")
            generaFacturaGlobal()
            frmMessage.Close()

            Me.refrescaGrid()

        Else
            MessageBox.Show("!No se encontraron registros Pendientes de procesar para la sucursal y fecha seleccionada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If


    End Sub

    Private Sub cmbFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles cmbFechaInicio.ValueChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub generaFacturaGlobal()

        Dim FechaIni As Date = cmbFechaInicio.Value
        FechaIni = FechaIni + dtApertura.Compute("MIN(HoraApertura)", "")
        Dim FechaFin As Date = cmbFechaInicio.Value.AddHours(23.9999)
        Dim SUCClave As String
        Dim dtCxC As DataTable
        If CmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("Se debe seleccionar una sucursal para poder generar la factura global", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            SUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtCxC Is Nothing Then
            dtCxC.Dispose()
        End If

        Dim dtmsg As DataTable
        oCFD = New CFD
        oCFD.UsoCFDI = "P01"
        oCFD.tipoDeComprobante = "ingreso"

        FACClave = ModPOS.obtenerLlave
        CAJClave = dtApertura.Rows(0)("CAJClave")
        If CAJClave <> "" Then

            dtmsg = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            oCFD.CTEClave = IIf(dtmsg.Rows(0)("Mostrador").GetType.Name <> "DBNull", dtmsg.Rows(0)("Mostrador"), "")
            dtmsg.Dispose()

            If CargaDatosCliente(oCFD.CTEClave) = False Then
                Exit Sub
            End If

        End If

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If VersionCF = "3.3" Then
            oCFD.regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            oCFD.regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()


        dtCxC = ModPOS.Recupera_Tabla("st_recupera_global", "@SUCClave", SUCClave, "@Inicio", FechaIni, "@Fin", FechaFin, "@CobranzaVenta", CobranzaVenta, "@TipoImpuesto", tImpuesto, "@TallaColor", TallaColor)

        Dim impresora As String
        'Inicia Sección de Validaciones 

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        impresora = dt.Rows(0)("ImpresoraFac")
        dt.Dispose()



        Dim foundRows() As DataRow
        Dim fr() As DataRow

        foundRows = dtCxC.Select("")
        If foundRows.GetLength(0) > 0 Then


            fr = dtCxC.Select("MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes Monedas en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de Tipo de Cambio Diferente en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Cursor.Current = Cursors.WaitCursor
            'Select Case MessageBox.Show("Se generara una Factura Global con todos los documentos del día para el Cliente: " & oCFD.RazonSocial & ", esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            '   Case DialogResult.Yes

            Dim iTipoPac As Integer
            Dim Vencimiento As DateTime
            Dim dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable

            Dim ImprimeFactura As Boolean = False
            Dim EnviaFactura As Boolean = False
            Dim FacturaId As String = ""
            Dim FACClave As String
            Dim Logo As Integer = 1
            oCFD.VersionCF = VersionCF

            If oCFD.VersionCF = "3.3" Then
                oCFD.tipoDeComprobante = "I"
            Else
                oCFD.tipoDeComprobante = "ingreso"
            End If

            oCFD.TipoCF = TipoCF

            'Verifica Timbres
            If oCFD.TipoCF = 2 Then
                dtPac = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                If dtPac Is Nothing OrElse dtPac.Rows.Count <= 0 Then
                    MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            ' Verifica Certificado
            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Dim NumFacturas As Integer = foundRows.GetLength(0)
            If Not ModPOS.validaFolio(SUCClave, CAJClave, 1, NumFacturas) Then
                Exit Sub
            End If

            'Recupera la llave 
            Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(oCFD.LlaveFile)

            If Not System.IO.File.Exists(DirSello) Then
                If System.IO.File.Exists(oCFD.LlaveFile) Then
                    System.IO.File.Copy(oCFD.LlaveFile, DirSello)
                Else
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim dir As String
            Dim DirArchivoPEM As String = DirSello & ".pem"

            dir = "C:\OpenSSL\bin\openssl.exe"

            Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)



            'Recupera información del Emisor

            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

            oCFD.eRazonSocial = dt.Rows(0)("Nombre")
            oCFD.eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
            oCFD.eRFC = dt.Rows(0)("id_Fiscal")
            oCFD.ePais = dt.Rows(0)("Pais")
            oCFD.eEntidad = dt.Rows(0)("Estado")
            oCFD.eMnpio = dt.Rows(0)("Municipio")
            oCFD.eColonia = dt.Rows(0)("Colonia")
            oCFD.eCalle = dt.Rows(0)("Calle")
            oCFD.eCodigoPostal = dt.Rows(0)("CodigoPostal")
            oCFD.eReferencia = dt.Rows(0)("Referencia")
            oCFD.eLocalidad = dt.Rows(0)("Localidad")
            oCFD.enoExterior = dt.Rows(0)("noExterior")
            oCFD.enoInterior = dt.Rows(0)("noInterior")

            dt.Dispose()


            If oCFD.eReferencia = "" Then
                oCFD.eReferencia = "SIN REFERENCIA"
            End If

            If oCFD.enoInterior <> "" Then
                oCFD.benoInterior = True
            Else
                oCFD.benoInterior = False
            End If

            'Recupera Información del Centro de Expedición


            dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

            oCFD.iTipoSucursal = dt.Rows(0)("Tipo")
            oCFD.sPais = dt.Rows(0)("Pais")
            oCFD.sEntidad = dt.Rows(0)("Entidad")
            oCFD.sMnpio = dt.Rows(0)("Municipio")
            oCFD.sColonia = dt.Rows(0)("Colonia")
            oCFD.sCalle = dt.Rows(0)("Calle")
            oCFD.sCodigoPostal = dt.Rows(0)("CodigoPostal")
            oCFD.sReferencia = dt.Rows(0)("Referencia")
            oCFD.sLocalidad = dt.Rows(0)("Localidad")
            oCFD.snoExterior = dt.Rows(0)("noExterior")
            oCFD.snoInterior = dt.Rows(0)("noInterior")
            dt.Dispose()

            If oCFD.sReferencia = "" Then
                oCFD.sReferencia = "SIN REFERENCIA"
            End If

            If oCFD.snoInterior <> "" Then
                oCFD.bsnoInterior = True
            Else
                oCFD.bsnoInterior = False
            End If

            oCFD.LugarExpedicion = oCFD.sCalle & " " & oCFD.snoExterior & IIf(oCFD.bsnoInterior, " INT " & oCFD.snoInterior, "") & "," & oCFD.sMnpio & "," & oCFD.sEntidad


            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            MonedaRef = dt.Rows(0)("Referencia")
            MonedaDesc = dt.Rows(0)("Descripcion")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()


            If MessageBox.Show("¿Desea imprimir el documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                ImprimeFactura = True
            End If

            If MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                EnviaFactura = True
            End If


            If VerificaDatoFiscalCte(oCFD) = True Then

                Vencimiento = Today.Date
                FacturaId = ModPOS.obtenerLlave
                FACClave = ModPOS.obtenerLlave
                oCFD.DOCClave = FACClave
                FormatoFactura = "Global"

                If oCFD.VersionCF = "3.3" Then
                    oCFD.formaDePago = "PUE"
                Else
                    oCFD.formaDePago = "Pago en una sola exhibición"
                End If


                ModPOS.Ejecuta("sp_crea_factura", _
                                  "@FACClave", FACClave, _
                                  "@idFactura", FacturaId, _
                                  "@CAJClave", CAJClave, _
                                  "@tipo", oCFD.tipoDeComprobante, _
                                  "@Usuario", ModPOS.UsuarioActual)

                'Carga Folios
                Dim i As Integer

                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_agrega_tickfac", "@idFactura", FacturaId, "@VENClave", foundRows(i)("ID"))

                    'recalcula impuesto detalle de la venta

                    ModPOS.Ejecuta("st_recalcula_imp_venta", "@VENClave", foundRows(i)("ID"))


                Next


                Dim dtDetalle As DataTable = ModPOS.Recupera_Tabla("sp_muestra_detallefactura", "@idFactura", FacturaId, "@TallaColor", TallaColor)

                Dim fila As Integer
                Dim contador As Integer = 0

                'Recalcula decimales de porcentaje de descuento

                'If dPorc > 0 Then
                '   dPorc = (dDesc * 100) / dSubtotal
                'End If

                Dim iPartida As Integer
                Dim sDFAClave As String

                Dim dPorcDesc, dDescImp, dImpuestoImp As Decimal

                For fila = 0 To dtDetalle.Rows.Count - 1


                    If dPorc > 0 Then
                        dDescImp = dtDetalle.Rows(fila)("Dscto") + Redondear(((dtDetalle.Rows(fila)("Subtotal") - dtDetalle.Rows(fila)("Dscto")) * (dPorc / 100)), 2)
                    Else
                        dDescImp = dtDetalle.Rows(fila)("Dscto")
                    End If

                    If dDescImp > 0 Then
                        dPorcDesc = dDescImp / dtDetalle.Rows(fila)("Subtotal")
                    Else
                        dPorcDesc = 0
                    End If

                    dImpuestoImp = Math.Round((dtDetalle.Rows(fila)("Subtotal") - dDescImp) * dtDetalle.Rows(fila)("PorcImp"), 2)

                    iPartida = (contador + 1) * 10

                    sDFAClave = ModPOS.obtenerLlave


                    ModPOS.Ejecuta("sp_inserta_detallefactura", _
                                   "@DFAClave", sDFAClave, _
                                   "@FACClave", FACClave, _
                                   "@Partida", iPartida, _
                                   "@Producto", dtDetalle.Rows(fila)("PROClave"), _
                                   "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                                   "@Costo", dtDetalle.Rows(fila)("Costo"), _
                                   "@PrecioBruto", dtDetalle.Rows(fila)("Precio Unitario"), _
                                   "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                   "@Subtotal", dtDetalle.Rows(fila)("SubTotal"), _
                                   "@PorcDesc", dPorcDesc, _
                                   "@DescuentoImp", dDescImp, _
                                   "@PorcImp", dtDetalle.Rows(fila)("PorcImp"), _
                                   "@ImpuestoImp", dImpuestoImp, _
                                   "@PuntosImp", dtDetalle.Rows(fila)("PuntosImp"), _
                                   "@ZDGE", dtDetalle.Rows(fila)("ZDGE"), _
                                   "@Und", dtDetalle.Rows(fila)("UndKilo"), _
                                   "@PREClave", dtDetalle.Rows(fila)("PREClave"), _
                                   "@Total", dtDetalle.Rows(fila)("SubTotal") - dDescImp + dImpuestoImp)


                    ' recalculaImpuestos(FACClave, sDFAClave, dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("Subtotal") - dDescImp, oCFD.TImpuesto, SUCClave)


                    contador += 1
                Next
                dtDetalle.Dispose()

                ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)


                Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave)
                Logo = dtLogo.Rows(0)("Logo")
                dtLogo.Dispose()

                ModPOS.Ejecuta("sp_actualiza_factura", _
                                "@FACClave", FACClave, _
                                "@TipoImpuesto", oCFD.TImpuesto, _
                                "@TipoCF", oCFD.TipoCF, _
                                "@VersionCF", oCFD.VersionCF, _
                                "@RegimenFiscal", oCFD.regimenFiscal, _
                                "@fechaAprobacion", oCFD.fechaAprobacion, _
                                "@Serie", oCFD.Serie, _
                                "@Folio", oCFD.Folio, _
                                "@CTEClave", oCFD.CTEClave, _
                                "@Credito", 0, _
                                "@DiasCredito", oCFD.DiasCredito, _
                                "@FechaVencimiento", Vencimiento, _
                                "@CAJClave", CAJClave, _
                                "@Vendio", ModPOS.UsuarioActual, _
                                "@Facturo", ModPOS.UsuarioActual, _
                                "@Desglosar", oCFD.NoDesglosaIEPS, _
                                "@formaDePago", oCFD.formaDePago, _
                                "@MONClave", Moneda, _
                                "@TipoCambio", TipoCambio, _
                                "@Formato", FormatoFactura, _
                                "@UsoCFDI", oCFD.UsoCFDI, _
                                "@Nota", "", _
                                "@Logo", Logo, _
                                "@fechaFactura", Now)


                Dim FolioInicial As String


                FolioInicial = oCFD.Serie & CStr(oCFD.Folio)


                If oCFD.VersionCF = "3.3" Then
                    ModPOS.Ejecuta("st_crea_detalleGlobal", "@FacturaId", FacturaId, "@FACClave", FACClave, "@Desc", IIf(dPorc > 0, dPorc / 100, 0), "@TallaColor", TallaColor)
                    Dim dtm As DataTable = Recupera_Tabla("st_metodopago_global", "@FacturaId", FacturaId, "@Desc", IIf(dPorc > 0, dPorc / 100, 0))
                    oCFD.metodoDePago = dtm.Rows(0)("MetodoPagoSAT")

                    ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                   "@FacturaID", FacturaId, _
                                   "@MetodoPago", dtm.Rows(0)("Tipo"), _
                                   "@Banco", "", _
                                   "@SAT", dtm.Rows(0)("MetodoPagoSAT"), _
                                   "@Referencia", "")
                    dtm.Dispose()
                Else

                    If ModPOS.MetodoPago Is Nothing Then
                        ModPOS.MetodoPago = New FrmMetodoPago
                        With ModPOS.MetodoPago
                            .bGlobal = True
                            .CTEClave = oCFD.CTEClave
                            .FacturaId = FacturaId
                            .VersionCF = oCFD.VersionCF
                        End With
                    End If

                    ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

                    If ModPOS.MetodoPago.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                        If ModPOS.MetodoPago.MetodoDePago <> "" Then
                            oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                            oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago

                        End If
                    End If

                    ModPOS.MetodoPago.Dispose()
                    ModPOS.MetodoPago = Nothing

                End If

                ModPOS.Ejecuta("st_actualiza_facglobal", "@FacturaID", FacturaId)

                'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
                dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaId)

                If oCFD.VersionCF = "3.3" Then

                    dtConcepto = ModPOS.Recupera_Tabla("st_recupera_concepto_global", "@FACClave", oCFD.DOCClave)
                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", oCFD.DOCClave)
                    dtImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_global", "@FACClave", oCFD.DOCClave)


                Else
                    dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaId)
                    dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaId)
                End If




                oCFD.Serie = dt.Rows(0)("Serie")
                oCFD.Folio = dt.Rows(0)("Folio")
                oCFD.descuento = dt.Rows(0)("descuentoTot")
                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fechaFactura"))
                oCFD.Moneda = dt.Rows(0)("Moneda")
                oCFD.TipoCambio = dt.Rows(0)("TipoCambio")
                oCFD.total = dt.Rows(0)("Total")



                If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then

                    oCFD.DOCClave = dt.Rows(0)("FACClave")

                    If oCFD.VersionCF = "3.3" Then

                        ' dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", "I", "@Tipo", 1, "@Clave", oCFD.DOCClave)

                        oCFD.cadenaOriginal = generarCadenaOriginalGlobal(oCFD, dtConcepto, dtImpuesto, dtDetalleImpuesto)
                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                        iTipoPac = crearXMLGlobal(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, dtConcepto, dtImpuesto, dtDetalleImpuesto, oCFD, InterfazSalida)

                    Else
                        If oCFD.TipoCF = 1 Then
                            oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                        Else
                            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto)
                        End If

                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                        iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto)

                    End If



                Else
                    actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
                End If


                dt.Dispose()
                dtConcepto.Dispose()
                dtImpuesto.Dispose()


                If CobranzaVenta = True AndAlso iTipoPac <> 0 Then
                    Dim dtDevolucion As DataTable = ModPOS.Recupera_Tabla("st_nc_pendientes", "@DOCClave", oCFD.DOCClave)
                    If dtDevolucion.Rows.Count > 0 Then
                        Dim frmStatusMessage As New frmStatus
                        For i = 0 To dtDevolucion.Rows.Count - 1
                            frmStatusMessage.Show("Generando CFD: " & dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")) & ". Procesando: " & CStr(i + 1) & "/" & CStr(dtDevolucion.Rows.Count))
                            frmStatusMessage.BringToFront()

                            ModPOS.regenerarCFD(dtDevolucion.Rows(i)("TipoCF"), dtDevolucion.Rows(i)("NCClave"), SUCClave)

                            ModPOS.crearXML(2, dtPac, PathXML, dtDevolucion.Rows(i)("Serie") & CStr(dtDevolucion.Rows(i)("Folio")), dtDevolucion.Rows(i)("NCClave"), dtDevolucion.Rows(i)("tipoCertificado"), Nothing, Nothing, Nothing, dtDevolucion.Rows(i)("Tipo"), InterfazSalida)
                        Next
                        frmStatusMessage.Dispose()
                    End If
                End If

                If ImprimeFactura = True Then

                    Dim sImpresora As String
                    Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", impresora)
                    sImpresora = dtPrinter.Rows(0)("Referencia")
                    dtPrinter.Dispose()

                    ModPOS.imprimirFactura(oCFD.TipoCF, FormatoFactura, FACClave, oCFD.total, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, 1, oCFD.VersionCF, Logo)

                End If

                If EnviaFactura = True Then
                    If oCFD.email <> "" Then
                        ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo)
                    End If
                End If

                System.Threading.Thread.Sleep(1000)



            End If
            'End Select
            Cursor.Current = Cursors.Default
            Me.Close()
        Else
            MessageBox.Show("Debe seleccionar por lo menos un documento a facturar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Function CargaDatosCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            sCTEClave = dt.Rows(0)("CTEClave")
            oCFD.CTEClave = sCTEClave
            oCFD.CURP = dt.Rows(0)("CURP")
            oCFD.Clave = dt.Rows(0)("Clave")
            tImpuesto = dt.Rows(0)("TImpuesto")
            oCFD.TImpuesto = tImpuesto
            oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
            oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
            oCFD.TPersona = dt.Rows(0)("TPersona")
            oCFD.RFC = dt.Rows(0)("id_Fiscal")
            oCFD.LCredito = dt.Rows(0)("LimiteCredito")
            oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
            oCFD.Contacto = dt.Rows(0)("Contacto")
            oCFD.Tel1 = dt.Rows(0)("Tel1")
            oCFD.Tel2 = dt.Rows(0)("Tel2")
            oCFD.email = dt.Rows(0)("Email")
            oCFD.listaPrecio = dt.Rows(0)("PREClave")
            oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
            oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

            oCFD.GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))

            oCFD.FechaReg = dt.Rows(0)("FechaRegistro")
            oCFD.Estado = dt.Rows(0)("Estado")
            oCFD.DCTEClave = dt.Rows(0)("DCTEClave")

            oCFD.Pais = dt.Rows(0)("Pais")
            oCFD.Entidad = dt.Rows(0)("Entidad")
            oCFD.Mnpio = dt.Rows(0)("Municipio")
            oCFD.Colonia = dt.Rows(0)("Colonia")
            oCFD.Calle = dt.Rows(0)("Calle")
            oCFD.Localidad = dt.Rows(0)("Localidad")
            oCFD.Referencia = dt.Rows(0)("referencia")
            oCFD.noExterior = dt.Rows(0)("noExterior")
            oCFD.noInterior = dt.Rows(0)("noInterior")
            oCFD.codigoPostal = dt.Rows(0)("codigoPostal")

            If oCFD.Referencia = "" Then
                oCFD.Referencia = "SIN REFERENCIA"
            End If

            If oCFD.noInterior <> "" Then
                oCFD.brnoInterior = True
            Else
                oCFD.brnoInterior = False
            End If

            'SaldoCliente = dt.Rows(0)("Disponible")


            dt.Dispose()

            dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

            If Not dt Is Nothing Then
                oCFD.tieneAddenda = True
                oCFD.Tipo = dt.Rows(0)("Tipo")
                oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                oCFD.FTP = dt.Rows(0)("FTP")
                oCFD.Firma = dt.Rows(0)("FirmaWeb")
                oCFD.emailAdd = dt.Rows(0)("email")
                oCFD.NoProveedor = dt.Rows(0)("NoProveedor")
                'FormatoFactura = dt.Rows(0)("FormatoFactura")
            End If


            Return True
        Else
            MessageBox.Show("La información del cliente para crear la factura global no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If
    End Function

    Private Function VerificaDatoFiscalCte(ByVal oCFD As CFD) As Boolean
        Dim Cadena As String = ""
        Dim Valido As Boolean = True

        If oCFD.Pais = "" Then
            Cadena &= "Pais,"
        End If

        If oCFD.Entidad = "" Then
            Cadena &= "Entidad,"
        End If

        If oCFD.Mnpio = "" Then
            Cadena &= "Municipio,"
        End If
        If oCFD.Colonia = "" Then
            Cadena &= "Colonia,"
        End If

        If oCFD.Calle = "" Then
            Cadena &= "Calle,"
        End If

        If oCFD.noExterior = "" Then
            Cadena &= "No. Exterior,"
        End If

        If oCFD.codigoPostal = "" Then
            Cadena &= "Código Postal,"
        End If

        If oCFD.RazonSocial = "" Then
            Cadena &= "Razón Social,"
        End If


        If oCFD.RFC <> "" AndAlso oCFD.RFC.Length >= 12 AndAlso oCFD.RFC.Length <= 13 Then
            If oCFD.TPersona = 1 Then
                If ModPOS.soloLetras(oCFD.RFC.Substring(3, 1)) = False Then
                    Cadena &= "RFC,"
                End If
            End If
        Else
            Cadena &= "RFC,"
        End If


        If Cadena = "" Then
            Valido = True
        Else
            '      MessageBox.Show("La siguiente información del cliente No es valida ó es requerida para facturar: " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Valido = False
        End If

        Return Valido
    End Function
End Class
