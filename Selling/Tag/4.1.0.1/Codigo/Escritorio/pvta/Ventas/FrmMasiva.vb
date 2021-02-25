

Public Class FrmMasiva
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents chkIncluir As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCaja As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMasiva))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.chkIncluir = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(758, 519)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(662, 519)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.chkIncluir)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.TxtFolio)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(3, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(845, 510)
        Me.GrpTickets.TabIndex = 121
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Documentos"
        '
        'chkIncluir
        '
        Me.chkIncluir.Location = New System.Drawing.Point(256, 18)
        Me.chkIncluir.Name = "chkIncluir"
        Me.chkIncluir.Size = New System.Drawing.Size(133, 19)
        Me.chkIncluir.TabIndex = 89
        Me.chkIncluir.Text = "Incluir cobrados"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(629, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(691, 15)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(145, 22)
        Me.dtPicker.TabIndex = 85
        Me.dtPicker.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(106, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox2.TabIndex = 84
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(224, 17)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(26, 21)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(9, 20)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(134, 17)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(84, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(87, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio"
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 44)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(830, 460)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.Location = New System.Drawing.Point(9, 531)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 15)
        Me.Label12.TabIndex = 102
        Me.Label12.Text = "Caja"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 527)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbCaja
        '
        Me.CmbCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbCaja.Location = New System.Drawing.Point(43, 526)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(200, 21)
        Me.CmbCaja.TabIndex = 101
        '
        'FrmMasiva
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(853, 561)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbCaja)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GrpTickets)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmMasiva"
        Me.Text = "Selección de Documentos"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String


    Private dtCxC As DataTable
    Private CAJClave As String = ""

    Private alerta(1) As PictureBox
    Private reloj As parpadea


    Private TipoCambio, dSaldo, dSaldoAnticipo As Double
    Private bload As Boolean = False
    Private dtPAC, dtPendientes, dtAnticipos, dtContrarecibos As DataTable
    Private cobranzaGeneral As Boolean = True
    Private CTEClave As String = ""
    Private sRazonSocial As String = ""
    Private MailSSL As Boolean
    Private TipoCF, Periodo, PeriodoContra, Mes, MesContra, MailPort As Integer
  
    Private Moneda, MonedaDesc, MonedaRef, CTEClaveActual, CTENombreActual, ServidorCancelacion, Autoriza, PathXML, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF, regimenFiscal As String
    Private InterfazSalida As String = ""
    Private iRegimenFiscal As Integer


 
    Private Sub FrmMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
      
        dtPicker.Value = Today

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month

       

        With CmbCaja
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_caja"
            .NombreParametro1 = "Sucursal"
            .Parametro1 = SUCClave
            .llenar()
        End With

        Dim dtmsg As DataTable
        Dim dtParam, dt As DataTable
        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatCargo"
                        FormatCargo = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "VersionCF"

                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                          iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
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

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If VersionCF = "3.3" Then
            regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        bload = True

        AgregarFolio()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.CmbCaja.SelectedValue Is Nothing Then
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

    Public Sub AgregarFolio()
        If bload Then
            If validaForm() Then

                If Not dtCxC Is Nothing Then
                    dtCxC.Dispose()
                End If

                dtCxC = ModPOS.Recupera_Tabla("sp_recupera_cxc", "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Tipo", 1, "@COMClave", ModPOS.CompanyActual, "@Cobrados", chkIncluir.Checked)
                GridCxC.DataSource = dtCxC
                GridCxC.RetrieveStructure()
                GridCxC.AutoSizeColumns()

                GridCxC.RootTable.Columns("ID").Visible = False
                GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False
                GridCxC.CurrentTable.Columns("CTEClave").Visible = False
                GridCxC.CurrentTable.Columns("DevTipo").Visible = False
                GridCxC.CurrentTable.Columns("TipoCF").Visible = False
                GridCxC.CurrentTable.Columns("Email").Visible = False
                GridCxC.CurrentTable.Columns("TipoNC").Visible = False

                GridCxC.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                GridCxC.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

                GridCxC.RootTable.Columns("Folio").Width = 45
                GridCxC.RootTable.Columns("Cve. Cte.").Width = 45

                ChkMarcaTodos.Enabled = True

            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim impresora As String
            Dim NumCopias As Integer
            'Inicia Sección de Validaciones 
            CAJClave = CmbCaja.SelectedValue

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            NumCopias = IIf(dt.Rows(0)("copiaCredito").GetType.Name = "DBNull", 0, dt.Rows(0)("copiaCredito"))
            impresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()


            Dim foundRows() As DataRow
            foundRows = dtCxC.Select("Marca ='True' ")
            If foundRows.GetLength(0) > 0 Then

                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se re generaran una Factura por cada documento marcado, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim iTipoPac, i, iCredito As Integer
                        Dim Vencimiento As DateTime
                        Dim dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable
                        Dim oCFD As New CFD
                        Dim ImprimeFactura As Boolean = False
                        Dim EnviaFactura As Boolean = False
                        Dim FacturaId As String = ""
                        Dim FACClave As String


                        oCFD.TipoCF = TipoCF
                        oCFD.VersionCF = VersionCF
                        oCFD.regimenFiscal = regimenFiscal

                      
                        If oCFD.VersionCF = "3.3" Then
                            oCFD.tipoDeComprobante = "I"
                        Else
                            oCFD.tipoDeComprobante = "ingreso"
                        End If


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

                      
                        If MessageBox.Show("¿Desea imprimir los documento(s)?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            ImprimeFactura = True
                        End If

                        If MessageBox.Show("¿Desea enviar los documento(s) por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                            EnviaFactura = True
                        End If

                        Dim frmStatusMessage As New frmStatus

                        Dim sFormatoFactura As String
                        Dim Referencia As String
                        Dim Banco As String
                        Dim Tipo As String
                        Dim SAT As String

                        For i = 0 To foundRows.GetUpperBound(0)

                            frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales " & CStr(i + 1) & "/" & CStr(foundRows.GetLength(0)))

                            sFormatoFactura = FormatoFactura

                            'Carga datos Receptor
                            Dim SaldoCliente As Double
                            dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("CTEClave"))

                            
                            oCFD.CTEClave = dt.Rows(0)("CTEClave")
                            oCFD.CURP = dt.Rows(0)("CURP")
                            oCFD.Clave = dt.Rows(0)("Clave")
                            oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")
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

                            SaldoCliente = dt.Rows(0)("Disponible")
                            oCFD.UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))


                            dt.Dispose()
                            'Fin receptor

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
                                sFormatoFactura = dt.Rows(0)("FormatoFactura")
                            End If



                            If VerificaDatoFiscalCte(oCFD) = True Then

                                'Valida credito
                                If foundRows(i)("Tipo") = "Credito" Then
                                    Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                                    If Not dtVencimiento Is Nothing Then
                                        Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                                        dtVencimiento.Dispose()
                                    End If
                                    iCredito = 1

                                    oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
                                Else
                                    iCredito = 0
                                    Vencimiento = Today.Date
                                    oCFD.CondicionesDePago = "Contado"
                                End If


                                'metodo de pago
                                If oCFD.VersionCF = "3.3" Then
                                    If iCredito = 1 Then
                                        oCFD.formaDePago = "PPD"
                                        oCFD.metodoDePago = "99"
                                    Else
                                        oCFD.formaDePago = "PUE"
                                    End If
                                Else
                                    oCFD.formaDePago = "Pago en una sola exhibición"
                                End If


                                    FacturaId = ModPOS.obtenerLlave
                                    FACClave = ModPOS.obtenerLlave





                                    ' Graba factura y detalle

                                NumFacturas -= 1

                                    oCFD.DOCClave = FACClave

                                ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)

                                ModPOS.Ejecuta("st_venta_factura", _
                                               "@idFactura", FacturaId, _
                                               "@FACClave", FACClave, _
                                               "@VENClave", foundRows(i)("ID"), _
                                               "@CAJClave", CAJClave, _
                                               "@tipo", oCFD.tipoDeComprobante, _
                                               "@TipoCF", oCFD.TipoCF, _
                                               "@VersionCF", oCFD.VersionCF, _
                                               "@RegimenFiscal", oCFD.regimenFiscal, _
                                               "@fechaAprobacion", oCFD.fechaAprobacion, _
                                               "@Serie", oCFD.Serie, _
                                               "@Folio", oCFD.Folio, _
                                               "@CTEClave", oCFD.CTEClave, _
                                               "@Credito", iCredito, _
                                               "@DiasCredito", oCFD.DiasCredito, _
                                               "@FechaVencimiento", Vencimiento, _
                                               "@Desglosar", oCFD.NoDesglosaIEPS, _
                                               "@formaDePago", oCFD.formaDePago, _
                                               "@MONClave", Moneda, _
                                               "@TipoCambio", TipoCambio, _
                                               "@Formato", sFormatoFactura, _
                                               "@Nota", foundRows(i)("Nota"), _
                                               "@UsoCFDI", oCFD.UsoCFDI, _
                                               "@Usuario", ModPOS.UsuarioActual)



                                If oCFD.VersionCF = "3.3" AndAlso iCredito = 1 Then

                                    ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                     "@FacturaID", FacturaId, _
                                     "@MetodoPago", 0, _
                                     "@Banco", "", _
                                     "@Referencia", "", _
                                     "@SAT", "99")
                                Else

                                    'Seccion para agregar multiples metodos de pago

                                    Dim dtMetodosPago As DataTable = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", oCFD.CTEClave)

                                    If dtMetodosPago.Rows.Count <> 1 Then
                                        If ModPOS.MetodoPago Is Nothing Then
                                            ModPOS.MetodoPago = New FrmMetodoPago
                                            With ModPOS.MetodoPago
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
                                    Else
                                        Dim x As Integer
                                        oCFD.metodoDePago = ""
                                        oCFD.NumCtaPago = ""
                                        For x = 0 To dtMetodosPago.Rows.Count - 1

                                            Referencia = IIf(dtMetodosPago.Rows(x)("Referencia").GetType.Name <> "DBNull", CStr(dtMetodosPago.Rows(x)("Referencia")).Trim.ToUpper, "")
                                            Banco = IIf(dtMetodosPago.Rows(x)("Banco").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Banco"), "")
                                            Tipo = IIf(dtMetodosPago.Rows(x)("Tipo").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Tipo"), "")
                                            SAT = IIf(dtMetodosPago.Rows(x)("SAT").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("SAT"), "99")


                                            ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                                   "@FacturaID", FacturaId, _
                                                   "@MetodoPago", Tipo, _
                                                   "@Banco", Banco, _
                                                   "@Referencia", Referencia, _
                                                   "@SAT", SAT)

                                            If oCFD.VersionCF <> "3.3" Then
                                                If SAT <> "" Then
                                                    If oCFD.metodoDePago = "" Then
                                                        oCFD.metodoDePago = SAT
                                                    Else
                                                        oCFD.metodoDePago &= "," & SAT
                                                    End If
                                                End If

                                                If Referencia <> "" Then
                                                    If oCFD.NumCtaPago = "" Then
                                                        oCFD.NumCtaPago = Referencia
                                                    Else
                                                        oCFD.NumCtaPago &= "," & Referencia
                                                    End If
                                                End If
                                            ElseIf oCFD.metodoDePago = "" And SAT <> "" Then
                                                oCFD.metodoDePago = SAT
                                                If Referencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                                                    oCFD.NumCtaPago = Referencia
                                                End If
                                                Exit For
                                            End If
                                        Next
                                    End If

                                    dtMetodosPago.Dispose()

                                End If

                                
                                'valida addenda  soriana
                                If oCFD.tieneAddenda = True Then
                                    If oCFD.Tipo = 1 Then
                                        'abrir cuadro de dialogo para registro de 
                                        Dim a As New FrmComplemento
                                        a.FacturaId = FacturaId
                                        a.ShowDialog()

                                        If a.DialogResult = DialogResult.OK Then
                                            If a.Autorizado Then
                                                oCFD.FechaEntrega = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", a.FechaEntrega)
                                                oCFD.NotaEntrada = a.NotaEntrada
                                                oCFD.NoCita = a.NoCita
                                                oCFD.FACClave = FACClave
                                            Else
                                                a.Dispose()
                                                frmStatusMessage.Dispose()
                                                Exit Sub
                                            End If
                                        ElseIf a.DialogResult = DialogResult.Cancel Then
                                            a.Dispose()
                                            frmStatusMessage.Dispose()
                                            Exit Sub
                                        End If
                                        a.Dispose()
                                    End If
                                End If


                                'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
                                dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaId)

                                dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaId)

                                dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaId)

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
                                        dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 1, "@Clave", oCFD.DOCClave)
                                    End If

                                    If oCFD.TipoCF = 1 Then
                                        oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                    Else
                                        oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto)
                                    End If

                                    oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                                    iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto)

                                Else
                                    actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
                                End If


                                If oCFD.tieneAddenda = True Then
                                    If oCFD.Tipo = 1 Then

                                        Dim NombreArchivo As String = oCFD.Serie & oCFD.Folio & ".xml"

                                        Try
                                            'Dim osvSoriana As New com.soriana.www.wseDocRecibo()
                                            'osvSoriana.Url = oCFD.Firma
                                            'osvSoriana.Timeout = 50000

                                            Dim xmlDoc As New System.Xml.XmlDocument()
                                            xmlDoc.Load(System.IO.Path.Combine(PathXML, NombreArchivo))

                                            ' Now create StringWriter object to get data from xml document.
                                            Dim sw As New System.IO.StringWriter()
                                            Dim xw As New System.Xml.XmlTextWriter(sw)
                                            xmlDoc.WriteTo(xw)

                                            Dim res As String ' = osvSoriana.RecibeCFD(sw.ToString())

                                            Dim dsRes As New System.Data.DataSet()
                                            Dim ms As System.IO.MemoryStream
                                            Dim buf As [Byte]()

                                            buf = System.Text.ASCIIEncoding.ASCII.GetBytes(res)
                                            ms = New System.IO.MemoryStream(buf)
                                            dsRes.ReadXml(ms)

                                            If dsRes.Tables("AckErrorApplication").Rows(0)("documentStatus").ToString().ToUpper() = "ACCEPTED" Then
                                                Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                                Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                    ms.WriteTo(fs)
                                                    ms.Dispose()
                                                End Using
                                                dsRes.Dispose()


                                                ModPOS.Ejecuta("sp_upd_complemento_envio", "@FACClave", oCFD.FACClave)

                                                MessageBox.Show("XML Aceptado : FACTURA " & oCFD.Serie & oCFD.Folio & ": Revisar " & sAPERAK, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Else
                                                Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                                Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                    ms.WriteTo(fs)
                                                    ms.Dispose()
                                                End Using
                                                Throw New Exception("XML Rechazado: Revisar " & sAPERAK)
                                            End If
                                        Catch ex As System.Exception
                                            MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        End Try

                                    End If
                                End If

                                dt.Dispose()
                                dtConcepto.Dispose()
                                dtImpuesto.Dispose()

                            End If


                                If ImprimeFactura = True Then
                                    If oCFD.ImprimirFac = True Then
                                        Dim sImpresora As String
                                        Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", impresora)
                                        sImpresora = dtPrinter.Rows(0)("Referencia")
                                        dtPrinter.Dispose()


                                        ModPOS.imprimirFacturas(oCFD.TipoCF, FacturaId, SUCClave, TipoCambio, MonedaDesc, MonedaRef, sImpresora, IIf(iCredito = 1, NumCopias + 1, 1), oCFD.VersionCF)
                                    End If
                                End If

                                If EnviaFactura = True Then
                                    If oCFD.email <> "" Then
                                        ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, sFormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef)
                                    End If
                                End If

                                System.Threading.Thread.Sleep(1000)

                        Next
                        frmStatusMessage.Dispose()
                End Select
                Cursor.Current = Cursors.Default
                Me.Close()
            Else
                MessageBox.Show("Debe seleccionar por lo menos un documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una caja valida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
           
            AgregarFolio()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Me.AgregarFolio()
    End Sub

    Private Sub chkIncluir_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluir.CheckedChanged
        AgregarFolio()
    End Sub

    Private Sub TxtFolio_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtFolio.KeyUp
        If TxtFolio.Text <> "" Then
            AgregarFolio()
        End If

    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                dSaldo = 0
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtCxC.AcceptChanges()

            GridCxC.Refresh()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

 End Class
