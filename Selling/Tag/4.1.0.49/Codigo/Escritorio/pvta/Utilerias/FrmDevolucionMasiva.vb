

Public Class FrmDevolucionMasiva
    Inherits System.Windows.Forms.Form

    Private bError As Boolean = False
    Private bPause As Boolean = False
    Private MailSSL As Boolean
    Private CTEClaveActual, CTENombreActual, ServidorCancelacion, Autoriza, PathXML, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF, regimenFiscal, PrinterInvoice As String
    Private InterfazSalida As String = ""
    Private iRegimenFiscal As Integer
    Private MailPort, TipoCF, Logo As Integer
    Private dFechaActual As Date = Today.Date.Date
    Private fechaFactura As Date
    Private dFechaVerificacion As Date = #1/1/2017#
    Private CAJClave As String = ""
    Private NCClave, ALMClave, SUCClave, Stage As String
    Private TallaColor As Integer = 0
    Private iTipoPac, i, iCredito, NumFacturas As Integer
    Private Vencimiento As DateTime
    Private dtVenta, dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto, dtRetencion, dtRetencionDet, dtImpuestodet As DataTable
    Private oCFD As CFD
    Private FACClave, folioFactura, formaPagoFactura, Moneda, MonRefBase, MonedaRef, MonedaDesc, MonedaDescBase, MonedaBase As String
    Private FacturaId As String = ""
    Private SubtotalFactura, SaldoFactura, CostoTotal, ImpuestoNC, DescuentoNC, SubtotalNC, TotalFactura, TipoCambio, TipoCambioBase, ImpuestoFactura, TotalNC As Decimal

    Private EstadoUBC, EstadoPEU As Integer

    Private bLoad As Boolean = False
    Private dtDetalle As DataTable
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUsoCFDI As Selling.StoreCombo
    Friend WithEvents CmbCaja As Selling.StoreCombo



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
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucionMasiva))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbCaja = New Selling.StoreCombo()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUsoCFDI = New Selling.StoreCombo()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.cmbUsoCFDI)
        Me.GrpGeneral.Controls.Add(Me.btnImportar)
        Me.GrpGeneral.Controls.Add(Me.Label7)
        Me.GrpGeneral.Controls.Add(Me.CmbCaja)
        Me.GrpGeneral.Controls.Add(Me.PictureBox12)
        Me.GrpGeneral.Controls.Add(Me.CmbSucursal)
        Me.GrpGeneral.Controls.Add(Me.Label12)
        Me.GrpGeneral.Controls.Add(Me.LblMessage)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 5)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(639, 133)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportar.Location = New System.Drawing.Point(472, 79)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(161, 37)
        Me.btnImportar.TabIndex = 159
        Me.btnImportar.Text = "Importar facturas"
        Me.btnImportar.ToolTipText = "Importar facturas"
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(352, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Caja"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbCaja
        '
        Me.CmbCaja.Location = New System.Drawing.Point(406, 19)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(227, 21)
        Me.CmbCaja.TabIndex = 119
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(63, 22)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(17, 16)
        Me.PictureBox12.TabIndex = 118
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'CmbSucursal
        '
        Me.CmbSucursal.ItemHeight = 13
        Me.CmbSucursal.Location = New System.Drawing.Point(86, 19)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(266, 21)
        Me.CmbSucursal.TabIndex = 116
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 17)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Sucursal"
        '
        'LblMessage
        '
        Me.LblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblMessage.Location = New System.Drawing.Point(25, 106)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(608, 22)
        Me.LblMessage.TabIndex = 24
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(7, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 14)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "Uso de CFDI"
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUsoCFDI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUsoCFDI.ItemHeight = 13
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(86, 49)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(266, 21)
        Me.cmbUsoCFDI.TabIndex = 160
        '
        'FrmDevolucionMasiva
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(657, 142)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDevolucionMasiva"
        Me.Text = "Devolución Masiva"
        Me.GrpGeneral.ResumeLayout(False)
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmDevolucionMasiva_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        Else
            ModPOS.DevolucionMasiva.Dispose()
            ModPOS.DevolucionMasiva = Nothing
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        bError = False
        Clock.Stop()
        Me.Close()
    End Sub

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

    Private Sub FrmDevolucionMasiva_Load(sender As Object, e As EventArgs) Handles Me.Load

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

      

        With cmbUsoCFDI
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_UsoCFDI"
            .NombreParametro1 = "Grupo"
            .Parametro1 = 2
            .llenar()
        End With

        bLoad = True


        If Not CmbSucursal.SelectedValue Is Nothing Then
            With CmbCaja
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If


        oCFD = New CFD

        Dim dtmsg As DataTable
        Dim dtParam As DataTable
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
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()


        dtmsg = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        MonedaBase = Moneda
        TipoCambioBase = dtmsg.Rows(0)("TipoCambio")
        MonRefBase = dtmsg.Rows(0)("Referencia")
        MonedaDescBase = dtmsg.Rows(0)("Descripcion")
        dtmsg.Dispose()

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)

        If VersionCF = "3.3" Then
            regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()

        oCFD.VersionCF = VersionCF


        If TipoCF = 2 Then
            dtPac = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            If dtPac Is Nothing OrElse dtPac.Rows.Count <= 0 Then
                MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End If

      
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            oCFD.noCertificado = dt.Rows(0)("Serie")
            oCFD.Certificado64 = dt.Rows(0)("Certificado")
            oCFD.LlaveFile = dt.Rows(0)("Llave")
            oCFD.ContrasenaClave = dt.Rows(0)("Password")
            dt.Dispose()
        Else
            MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists(PathXML) Then
                MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
        End Try

        'Verifica que exista el path del .Key
        Try
            If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
        End Try



    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If Not CmbSucursal.SelectedValue Is Nothing AndAlso bLoad Then
            With CmbCaja
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_caja"
                .NombreParametro1 = "Sucursal"
                .Parametro1 = CmbSucursal.SelectedValue
                .llenar()
            End With
        End If
    End Sub


    Private Function recuperaFolio(ByVal Caja As String, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable
        Dim FOLClave As String
       
        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 7, "@SUCClave", SUCClave, "@CAJClave", CAJClave)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= NumFolios Then
                FOLClave = dt.Rows(0)("FOLClave")
                oCFD.noAprobacion = dt.Rows(0)("NoAprobacion")
                oCFD.anoAprobacion = CStr(dt.Rows(0)("AnoAprobacion"))
                oCFD.Serie = dt.Rows(0)("Serie")
                oCFD.Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                oCFD.fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                    oCFD.CBB = CType(dt.Rows(0)("CBB"), Byte())
                End If

                dt.Dispose()

                ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", FOLClave)

                Return True
            Else
                MessageBox.Show("No existen suficientes folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("No existen folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function


    Private Function crearCF(ByVal NCClave As String, ByRef sFolio As String) As Boolean

        'Recupera Información del Centro de Expedición

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

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


        'Receptor

        If oCFD.Referencia = "" Then
            oCFD.Referencia = "SIN REFERENCIA"
        End If

        If oCFD.noInterior <> "" Then
            oCFD.brnoInterior = True
        Else
            oCFD.brnoInterior = False
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_nc", "@NCClave", NCClave)

        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_conceptonc", "@Clave", NCClave)
        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestosnc", "@Clave", NCClave)


        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")

        sFolio = oCFD.Serie & oCFD.Folio

        oCFD.descuento = IIf(dt.Rows(0)("DescuentoTot").GetType.ToString = "System.DBNull", 0, dt.Rows(0)("DescuentoTot"))

        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fecha"))


        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = TipoCambio

        If oCFD.TipoCF <= 2 Then

            oCFD.DOCClave = NCClave

            If oCFD.VersionCF = "3.3" Then
                dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 7, "@Clave", oCFD.DOCClave)
            End If


            If oCFD.TipoCF = 1 Then
                oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
            Else
                oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 7, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
            End If

            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)



            iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 7, InterfazSalida, dtDetalleImpuesto, dtRetencionDet, dtRetencion)

        Else
            actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 7)
        End If


        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()

        Return True
    End Function


    Private Sub TimbraDocumento(ByVal iMotivo As Integer, ByRef sFolio As String, ByRef sNota As String)
        Dim i As Integer
        Dim foundRows() As DataRow
        Dim foundImp() As DataRow
        Dim AplicaReembolso As Boolean = False

        Dim dtBloqueados As DataTable = ModPOS.CrearTabla("Bloqueados", _
                                          "PROClave", "System.String", _
                                          "Bloquear", "System.Double")


        foundRows = dtDetalle.Select("[Dev.] > 0 and [Disp.] >= [Dev.]")

        If foundRows.GetLength(0) > 0 Then



            SubtotalNC = dtDetalle.Compute("SUM(Subtotal)", "")
            DescuentoNC = dtDetalle.Compute("SUM(Descuento)", "")
            ImpuestoNC = dtDetalle.Compute("SUM(Impuesto)", "")
            TotalNC = dtDetalle.Compute("SUM(Total)", "")
            CostoTotal = dtDetalle.Compute("SUM(Total)", "")



            If Not recuperaFolio(CAJClave, 1) Then
                Exit Sub
            End If

            'Recupera información del Emisor

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

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

            oCFD.regimenFiscal = regimenFiscal
            oCFD.UsoCFDI = cmbUsoCFDI.SelectedValue
            oCFD.tipoNC = 1
            oCFD.TipoCF = TipoCF

            If oCFD.VersionCF = "3.3" Then
                oCFD.tipoDeComprobante = "E"
                oCFD.CondicionesDePago = ""
            Else
                oCFD.tipoDeComprobante = "egreso"
            End If

            dtImpuestodet = ModPOS.Recupera_Tabla("sp_impuestos_nc", "@FACClave", FACClave)

            NCClave = ModPOS.obtenerLlave

            Dim msgSQL As String

            msgSQL = ModPOS.Ejecuta("sp_crea_nc", _
            "@NCClave", NCClave, _
            "@FACClave", FACClave, _
            "@folioFactura", folioFactura, _
            "@fechaFactura", fechaFactura, _
            "@CTEClave", oCFD.CTEClave, _
            "@TipoImpuesto", oCFD.TImpuesto, _
            "@TipoCF", oCFD.TipoCF, _
            "@VersionCF", oCFD.VersionCF, _
            "@RegimenFiscal", oCFD.regimenFiscal, _
            "@Serie", oCFD.Serie, _
            "@Folio", oCFD.Folio, _
            "@CAJClave", CAJClave, _
            "@Atendio", oCFD.Atendio, _
            "@fechaAprobacion", oCFD.fechaAprobacion, _
            "@formaDePago", oCFD.formaDePago, _
            "@Motivo", iMotivo, _
            "@Observacion", sNota, _
            "@Costo", CostoTotal, _
            "@Subtotal", SubtotalNC, _
            "@ImpuestoTot", ImpuestoNC, _
            "@DescuentoTot", DescuentoNC, _
            "@Total", TotalNC, _
            "@tipoCertificado", oCFD.tipoDeComprobante, _
            "@Tipo", 1, _
            "@MONClave", Moneda, _
            "@TipoCambio", TipoCambio, _
            "@UsoCFDI", oCFD.UsoCFDI, _
            "@Logo", Logo, _
            "@Usuario", ModPOS.UsuarioActual)

            Dim DNCClave As String
            Dim Referencia As String = NCClave
            Dim CambioEstado As Boolean = False
            dtBloqueados.Clear()


            For i = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 2, "@Documento", FACClave, "@Partida", foundRows(i)("DFAClave"), "@Cantidad", foundRows(i)("Dev."))

                DNCClave = ModPOS.obtenerLlave

                msgSQL = ModPOS.Ejecuta("sp_inserta_ncdetalle", _
                                "@DNCClave", DNCClave, _
                                "@NCClave", NCClave, _
                                "@Partida", (i + 1) * 10, _
                                "@PROClave", foundRows(i)("PROClave"), _
                                "@TProducto", foundRows(i)("TProducto"), _
                                "@Costo", foundRows(i)("Costo"), _
                                "@Precio", foundRows(i)("Precio Unitario"), _
                                "@Subtotal", foundRows(i)("Subtotal"), _
                                "@Cantidad", foundRows(i)("Dev."), _
                                "@Descuento", foundRows(i)("Descuento"), _
                                "@Impuesto", foundRows(i)("Impuesto"), _
                                "@Total", foundRows(i)("Total"), _
                                "@Puntos", foundRows(i)("PuntosImp"), _
                                "@PartidaFactura", foundRows(i)("PartidaFactura"))


                If foundRows(i)("TProducto") = 4 AndAlso oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                    'Calcula retencion
                    ModPOS.calculaRetencion("N", DNCClave, foundRows(i)("PROClave"), foundRows(i)("Subtotal") - foundRows(i)("Descuento"), oCFD.TImpuesto, SUCClave)

                End If

                'SI REQUIERE SEGUIMIENTO DE SERIAL
                If foundRows(i)("Seguimiento") = 2 Then
                    Dim SerialReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = foundRows(i)("Dev.")
                    Do
                        Dim b As New FrmSerial
                        b.DOCClave = FACClave
                        b.PROClave = foundRows(i)("PROClave")
                        b.Clave = foundRows(i)("Clave")
                        b.Nombre = foundRows(i)("Nombre")
                        b.Cantidad = PorRegistrar
                        b.Dias = foundRows(i)("DiasGarantia")
                        b.TipoDoc = 4
                        b.TipoMov = 1
                        b.ShowDialog()
                        SerialReg = SerialReg + b.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                        b.Dispose()
                    Loop Until SerialReg = foundRows(i)("Dev.") OrElse PorRegistrar = 0
                End If

                'SI REQUIERE SEGUIMIENTO DE LOTE
                If foundRows(i)("Seguimiento") = 3 Then
                    Dim LoteReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = foundRows(i)("Dev.")
                    Do
                        Dim b As New FrmLote
                        b.DOCClave = FACClave
                        b.PROClave = foundRows(i)("PROClave")
                        b.Clave = foundRows(i)("Clave")
                        b.Nombre = foundRows(i)("Nombre")
                        b.CantXRegistrar = PorRegistrar
                        b.TipoDoc = 4
                        b.TipoMov = 1
                        b.ShowDialog()
                        LoteReg = LoteReg + b.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                        b.Dispose()
                    Loop Until LoteReg = foundRows(i)("Dev.") OrElse PorRegistrar = 0
                End If


                foundImp = dtImpuestodet.Select("DFAClave = '" & foundRows(i)("DFAClave") & "'")

                If foundImp.GetLength(0) > 0 Then
                    Dim y As Integer

                    For y = 0 To foundImp.GetUpperBound(0)

                        msgSQL = ModPOS.Ejecuta("sp_inserta_ncimpuesto", _
                                        "@DNCClave", DNCClave, _
                                        "@IMPClave", foundImp(y)("IMPClave"), _
                                        "@Base", foundImp(y)("Base") * foundRows(i)("Dev."), _
                                        "@PorcImp", foundImp(y)("PorcImp"), _
                                        "@Importe", foundImp(y)("Importe") * foundRows(i)("Dev."), _
                                        "@Usuario", ModPOS.UsuarioActual)

                    Next
                End If

                If Stage <> "" Then
                    dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(i)("PROClave"), "@UBCClave", Stage)
                    If dt.Rows.Count = 1 Then
                        EstadoPEU = CInt(dt.Rows(0)("Estado"))
                        If CDbl(dt.Rows(0)("Existencia")) <= 0 Then
                            EstadoPEU = EstadoUBC
                        End If
                    Else
                        EstadoPEU = EstadoUBC
                    End If
                    dt.Dispose()

                    If EstadoPEU <> 1 Then


                        Dim row1 As DataRow
                        row1 = dtBloqueados.NewRow()
                        'declara el nombre de la fila
                        row1.Item("PROClave") = foundRows(i)("PROClave")
                        row1.Item("Bloquear") = foundRows(i)("Dev.")
                        dtBloqueados.Rows.Add(row1)

                        CambioEstado = True
                    End If

                End If

            Next
            dtDetalle.Dispose()


            ModPOS.Ejecuta("st_actualiza_nc", _
                             "@NCClave", NCClave)


            If Stage = "" Then
                ModPOS.GeneraMovInv(1, 3, 4, NCClave, ALMClave, oCFD.Serie & oCFD.Folio, Autoriza, False)

            Else
                ModPOS.GeneraMovInv(1, 3, 4, NCClave, ALMClave, oCFD.Serie & oCFD.Folio, Autoriza, False, 1, Stage)


                If CambioEstado = True AndAlso InterfazSalida <> "" Then

                    For i = 0 To dtBloqueados.Rows.Count - 1

                        ModPOS.Ejecuta("st_act_bloqueado_ubc", _
                                   "@UBCClave", Stage, _
                                   "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                   "@Cantidad", dtBloqueados.Rows(i)("Bloquear"))

                        ModPOS.Ejecuta("st_cambio_estado", _
                                    "@SUCClave", SUCClave, _
                                    "@ALMClave", ALMClave, _
                                    "@UBCClave", Stage, _
                                    "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                    "@Cantidad", dtBloqueados.Rows(i)("Bloquear"), _
                                    "@Estado", EstadoPEU, _
                                    "@Referencia", Referencia, _
                                    "@Actualiza", 1, _
                                    "@Usuario", ModPOS.UsuarioActual)

                    Next



                End If

            End If

            'Agregar el actualizar saldo de NC

            If oCFD.eTPersona = 1 AndAlso oCFD.TPersona = 2 Then
                Dim dRetenciones As Decimal = 0
                dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
                dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", "E", "@Tipo", 7, "@Clave", NCClave)
                If dtRetencion.Rows.Count > 0 Then
                    dRetenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & NCClave & "'")

                    TotalNC -= dRetenciones

                    ModPOS.Ejecuta("st_aplica_retencion", "@Clave", NCClave, "@Tipo", "N", "@Retencion", dRetenciones)
                End If
            End If


            Dim dReembolso, dAplicar As Double
            If TruncateToDecimal(SaldoFactura, 2) > 0 Then
                If TruncateToDecimal(SaldoFactura, 2) >= TruncateToDecimal(TotalNC, 2) Then
                    ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", TotalNC * TipoCambio)
                    dReembolso = 0
                    dAplicar = TotalNC
                Else
                    ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 2, "@Documento", FACClave, "@Importe", (TotalNC - SaldoFactura) * TipoCambio)
                    dReembolso = TruncateToDecimal(TotalNC - SaldoFactura, 2)
                    dAplicar = SaldoFactura
                End If
                ModPOS.Ejecuta("sp_vincula_fac", "@NCClave", NCClave, "@FACClave", FACClave, "@Importe", dAplicar, "@CAJClave", CAJClave, "@Usuario", ModPOS.UsuarioActual)
            Else
                dReembolso = TruncateToDecimal(TotalNC, 2)
            End If


            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", oCFD.CTEClave, "@Importe", TotalNC * TipoCambio)


            If dReembolso > 0 AndAlso AplicaReembolso = True Then

                dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

                Dim IDCorte As String = ""
                Dim dEfectivo As Decimal

                If dt.Rows.Count > 0 Then
                    IDCorte = dt.Rows(0)("ID")
                End If
                dt.Dispose()

                dt = Recupera_Tabla("st_recupera_efectivo_mon", "@IDCorte", IDCorte, "@COMClave", ModPOS.CompanyActual, "@MONClave", Moneda)

                If dt.Rows.Count > 0 Then
                    dEfectivo = dt.Rows(0)("Efectivo")
                End If
                dt.Dispose()

                If dEfectivo >= dReembolso Then

                    Select Case MessageBox.Show("¿Desea aplicar un reembolso por " & Format(CStr(TruncateToDecimal(dReembolso, 2)) & " " & MonedaRef, "Currency") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.Ejecuta("st_aplica_reembolso", _
                                           "@CTEClave", oCFD.CTEClave, _
                                           "@DOCClave", NCClave, _
                                           "@TipoDocumento", 4, _
                                           "@CAJClave", CAJClave, _
                                           "@Moneda", Moneda, _
                                           "@TipoCambio", TipoCambio, _
                                           "@Saldo", dReembolso, _
                                           "@Usuario", ModPOS.UsuarioActual)

                    End Select
                End If

            End If

            Dim j As Integer

            Dim sMetodoPago, sBanco, sReferencia, sSAT As String

            oCFD.metodoDePago = ""
            oCFD.NumCtaPago = ""


            If oCFD.VersionCF = "3.3" AndAlso formaPagoFactura = "PPD" Then

                sMetodoPago = "Condonación"
                sBanco = ""
                sSAT = "15"
                sReferencia = ""


                ModPOS.Ejecuta("sp_agregar_metodopagonc", _
                  "@NCClave", NCClave, _
                  "@MetodoPago", sMetodoPago, _
                  "@Banco", sBanco, _
                  "@SAT", sSAT, _
                  "@Referencia", sReferencia)

                oCFD.metodoDePago = sSAT
                If sReferencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                    oCFD.NumCtaPago = sReferencia
                End If
            Else

                Dim dtMetodosPago As DataTable = ModPOS.Recupera_Tabla("st_recupera_metodopago_fac", "@FacturaID", FacturaId)

                Dim frMetodoPagos() As System.Data.DataRow

                Dim foundRows1() As System.Data.DataRow
                foundRows1 = dtMetodosPago.Select()
                frMetodoPagos = foundRows1
                'End If
                dtMetodosPago.Dispose()

                For j = 0 To frMetodoPagos.GetUpperBound(0)

                    sMetodoPago = IIf(frMetodoPagos(j)("Tipo").GetType.Name = "DBNull", "", frMetodoPagos(j)("Tipo"))
                    sBanco = IIf(frMetodoPagos(j)("Banco").GetType.Name = "DBNull", "", frMetodoPagos(j)("Banco"))
                    sReferencia = IIf(frMetodoPagos(j)("Referencia").GetType.Name = "DBNull", "", CStr(frMetodoPagos(j)("Referencia")).Trim.ToUpper)
                    sSAT = IIf(frMetodoPagos(j)("SAT").GetType.Name = "DBNull", "99", frMetodoPagos(j)("SAT"))



                    ModPOS.Ejecuta("sp_agregar_metodopagonc", _
                    "@NCClave", Me.NCClave, _
                    "@MetodoPago", sMetodoPago, _
                    "@Banco", sBanco, _
                    "@SAT", sSAT, _
                    "@Referencia", sReferencia)

                    If oCFD.VersionCF <> "3.3" Then
                        If j > 0 Then
                            oCFD.metodoDePago &= ", "
                            If oCFD.NumCtaPago <> "" AndAlso sReferencia <> "" Then
                                oCFD.NumCtaPago &= ", "
                            End If
                        End If

                        oCFD.metodoDePago &= sSAT
                        oCFD.NumCtaPago &= sReferencia
                    ElseIf oCFD.metodoDePago = "" And sSAT <> "" Then
                        oCFD.metodoDePago = sSAT
                        If sReferencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                            oCFD.NumCtaPago = sReferencia
                        End If
                        Exit For
                    End If

                Next



            End If

            oCFD.total = TotalNC


            If crearCF(NCClave, sFolio) = False Then
                Exit Sub
            End If

            If oCFD.email.Trim <> "" Then
                ModPOS.SendMailNC(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatNC, CDate(oCFD.Fecha), sFolio, NCClave, TotalNC, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo, True)
            End If
        End If
    End Sub


    Private Function CargaDatosCliente(ByVal CTEClave As String) As String
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            CTEClave = dt.Rows(0)("CTEClave")
            oCFD.CURP = dt.Rows(0)("CURP")
            oCFD.Clave = dt.Rows(0)("Clave")

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


            dt.Dispose()

            Return "OK"

        Else
            Return "La información del cliente no exite o se encuentra incompleta"
        End If

    End Function


    Private Function CargaDatosFactura(ByVal Serie As String, ByVal Folio As Integer) As String
        'Valida que el campo Ticket no se encuentre vacio
        Dim dtFactura As DataTable = ModPOS.SiExisteRecupera("st_busca_factura", "@Serie", Serie, "@Folio", Folio, "@COMClave", ModPOS.CompanyActual)
        If Not dtFactura Is Nothing AndAlso dtFactura.Rows.Count > 0 Then

            Dim TipoCF_fac As Integer = dtFactura.Rows(0)("TipoCF")
            Dim Estado_fac As Integer = dtFactura.Rows(0)("Estado")

            oCFD.TImpuesto = dtFactura.Rows(0)("TipoImpuesto")
            oCFD.Atendio = IIf(dtFactura.Rows(0)("Vendio").GetType.Name = "DBNull", ModPOS.UsuarioActual, dtFactura.Rows(0)("Vendio"))
            FacturaId = dtFactura.Rows(0)("FacturaID")
            folioFactura = CStr(dtFactura.Rows(0)("Serie")) & CStr(dtFactura.Rows(0)("Folio"))
            fechaFactura = CDate(dtFactura.Rows(0)("fechaFactura"))
            FACClave = dtFactura.Rows(0)("FACClave")
            SaldoFactura = dtFactura.Rows(0)("Saldo")
            SubtotalFactura = dtFactura.Rows(0)("Subtotal")
            ImpuestoFactura = dtFactura.Rows(0)("ImpuestoTot")
            TotalFactura = dtFactura.Rows(0)("Total")
            oCFD.CTEClave = dtFactura.Rows(0)("CTEClave")
            Moneda = IIf(dtFactura.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtFactura.Rows(0)("MONClave"))
            TipoCambio = IIf(dtFactura.Rows(0)("TipoCambio").GetType.Name = "DBNull", 1, dtFactura.Rows(0)("TipoCambio"))
            formaPagoFactura = IIf(dtFactura.Rows(0)("formaDePago").GetType.Name = "DBNull", "Pago en una sola exhibición", dtFactura.Rows(0)("formaDePago"))
            Logo = IIf(dtFactura.Rows(0)("Logo").GetType.Name = "DBNull", 1, dtFactura.Rows(0)("Logo"))

            oCFD.formaDePago = formaPagoFactura

            If oCFD.VersionCF = "3.3" Then
                oCFD.formaDePago = "PUE"
                oCFD.CondicionesDePago = "Contado"
            End If

            dtFactura.Dispose()

            If TipoCF_fac = 2 AndAlso Estado_fac = 2 Then
                Return "No es posible realizar la NC de una factura que aun no ha sido certificada por el PAC (Timbrada)"
            End If

            If Moneda <> MonedaBase Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
                If dt.Rows.Count > 0 Then
                    MonedaRef = dt.Rows(0)("Referencia")
                    MonedaDesc = dt.Rows(0)("Descripcion")
                End If

                dt.Dispose()
            Else
                MonedaRef = MonRefBase
                MonedaDesc = MonedaDescBase
            End If


            Dim msg As String = CargaDatosCliente(oCFD.CTEClave)

            If msg = "OK" Then
                If Not dtDetalle Is Nothing Then
                    dtDetalle.Dispose()
                End If

                dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_nc", "@FACClave", FACClave)
            End If

            Return msg
        Else
            Return "No se encontro documento o se encuentra cancelado"
        End If

    End Function



    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        If Not (CmbSucursal.SelectedValue Is Nothing AndAlso CmbCaja.SelectedValue Is Nothing) Then
            If cmbUsoCFDI.SelectedValue Is Nothing Then
                MessageBox.Show("Debe seleccionar una opcion Uso del Comprobante", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            SUCClave = CmbSucursal.SelectedValue
            CAJClave = CmbCaja.SelectedValue

            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
            ALMClave = IIf(dt.Rows(0)("ALMClave").GetType.Name = "DBNull", "", dt.Rows(0)("ALMClave"))
            dt.Dispose()



            If Stage <> "" Then

                Dim dtU As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", Stage)
                If dtU.Rows.Count > 0 Then
                    EstadoUBC = CInt(dtU.Rows(0)("Estado"))
                Else
                    dtU.Dispose()
                    MessageBox.Show("No se encontro la ubicación del almacén para realizar las cancelaciones y devoluciones de productos", "Error", MessageBoxButtons.OK)
                    Exit Sub
                End If
                dtU.Dispose()
            End If

            Dim curFileName As String = ""
            'buscamos la imagen a grabar
            Try
                Dim openDlg As OpenFileDialog = New OpenFileDialog
                openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
                ' Dim filter As String = openDlg.Filter
                openDlg.Title = "Abrir un Archivo de CSV o TXT"
                If (openDlg.ShowDialog() = DialogResult.OK) Then
                    curFileName = openDlg.FileName

                    Dim dtTemporal As DataTable = ReadCSV(curFileName, 6)

                    If dtTemporal.Rows.Count > 1 Then


                        Dim dtMotivo As DataTable
                        dtMotivo = ModPOS.Recupera_Tabla("sp_muestra_valores", "@Tabla", "NC", "@Campo", "Motivo")



                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.BringToFront()
                        Dim i As Integer
                        Dim idMotivo As Decimal

                        Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                                  "Fila", "System.String", _
                                                  "Serie", "System.String", _
                                                  "Folio", "System.String", _
                                                  "Error", "System.String")

                        Dim dtFactura As DataTable = ModPOS.CrearTabla("Factura", _
                                                 "Serie", "System.String", _
                                                 "Folio", "System.String", _
                                                 "Nota", "System.String")


                        Dim frMotivo() As System.Data.DataRow
                        Dim frFactura() As System.Data.DataRow
                        Dim frProducto() As System.Data.DataRow
                        Dim frDetalle() As System.Data.DataRow

                        Dim msg As String

                        For i = 1 To dtTemporal.Rows.Count - 1
                            frmStatusMessage.Show("Procesando " & CStr(i) & " de " & CStr(dtTemporal.Rows.Count - 1) & " registros")
                          
                            'Valida si Existe la Factura
                            If dtTemporal.Rows(i)("Serie").GetType.FullName <> "System.DBNull" OrElse dtTemporal.Rows(i)("Serie").GetType.FullName <> "System.DBNull" Then
                                'Valida si el idMotivo existe
                                If dtTemporal.Rows(i)("IdMotivo").GetType.FullName <> "System.DBNull" Then
                                    frMotivo = dtMotivo.Select("Clave = '" & CStr(dtTemporal.Rows(i)("IdMotivo")) & "'")
                                    If frMotivo.Length = 1 Then

                                        If IsNumeric(dtTemporal.Rows(i)("Folio")) = True Then

                                            idMotivo = frMotivo(0)("Valor")
                                            frFactura = dtFactura.Select("Serie = '" & CStr(dtTemporal.Rows(i)("Serie")) & "' and Folio='" & CStr(dtTemporal.Rows(i)("Folio")) & "'")
                                            If frFactura.Length = 0 Then

                                                'Agrega la Factura a la tabla de control
                                                Dim row1 As DataRow
                                                row1 = dtFactura.NewRow()
                                                row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                row1.Item("Folio") = dtTemporal.Rows(i)("Folio").ToString
                                                row1.Item("Nota") = IIf(dtTemporal.Rows(i)("Nota").GetType.FullName = "System.DBNull", "", dtTemporal.Rows(i)("Nota"))
                                                dtFactura.Rows.Add(row1)

                                                'Valida si existe la Factura
                                                msg = CargaDatosFactura(CStr(dtTemporal.Rows(i)("Serie")), CInt(dtTemporal.Rows(i)("Folio")))
                                                If msg = "OK" Then
                                                    frProducto = dtTemporal.Select("Serie = '" & CStr(dtTemporal.Rows(i)("Serie")) & "' and Folio='" & CStr(dtTemporal.Rows(i)("Folio")) & "'")
                                                    If frProducto.Length > 0 Then
                                                        Dim j As Integer
                                                        Dim bError As Boolean = False
                                                        For j = 0 To frProducto.GetUpperBound(0)
                                                            'Valida si el Producto existe,
                                                            If frProducto(j)("ClaveProducto").GetType.FullName <> "System.DBNull" Then
                                                                frDetalle = dtDetalle.Select("Clave = '" & CStr(frProducto(j)("ClaveProducto")) & "' and [Disp.] > [Dev.]")
                                                                If frDetalle.Length > 0 Then
                                                                    If frProducto(j)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                                                        'Valida si la cantidad esta disponible a devolver
                                                                        If IsNumeric(frProducto(j)("Cantidad")) = True Then
                                                                            If CDec(frProducto(j)("Cantidad")) <= CDec(frDetalle(0)("Disp.")) Then
                                                                                frDetalle(0)("Dev.") = CDec(frDetalle(0)("Dev.")) + CDec(frProducto(j)("Cantidad"))

                                                                                Dim Subtotal, IVAtotal, Desctotal, Costo, Total, Cant As Decimal

                                                                                Cant = frDetalle(0)("Dev.")
                                                                                Costo = Math.Round(Cant * frDetalle(0)("Costo"), 2)
                                                                                Subtotal = Math.Round(Cant * frDetalle(0)("Precio Unitario"), 2)
                                                                                Desctotal = Math.Round(frDetalle(0)("PorcDesc") * Subtotal, 2)
                                                                                IVAtotal = Math.Round(frDetalle(0)("PorcImp") * (Subtotal - Desctotal), 2)
                                                                                Total = Subtotal - Desctotal + IVAtotal

                                                                                frDetalle(0)("CostoTotal") = Costo
                                                                                frDetalle(0)("Subtotal") = Subtotal
                                                                                frDetalle(0)("Descuento") = Desctotal
                                                                                frDetalle(0)("Impuesto") = IVAtotal
                                                                                frDetalle(0)("Total") = Total

                                                                            Else
                                                                                bError = True
                                                                                row1 = dtError.NewRow()
                                                                                'declara el nombre de la fila
                                                                                row1.Item("Fila") = i + 1
                                                                                row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                                                row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                                                row1.Item("Error") = "La cantidad excede el disponible a devolver de la factura"
                                                                                dtError.Rows.Add(row1)
                                                                                Exit For

                                                                            End If
                                                                        Else
                                                                            bError = True
                                                                            row1 = dtError.NewRow()
                                                                            'declara el nombre de la fila
                                                                            row1.Item("Fila") = i + 1
                                                                            row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                                            row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                                            row1.Item("Error") = "La cantidad debe ser numerica"
                                                                            dtError.Rows.Add(row1)
                                                                            Exit For
                                                                        End If
                                                                    Else
                                                                        bError = True
                                                                        row1 = dtError.NewRow()
                                                                        'declara el nombre de la fila
                                                                        row1.Item("Fila") = i + 1
                                                                        row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                                        row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                                        row1.Item("Error") = "La cantidad no puede ser NULL"
                                                                        dtError.Rows.Add(row1)
                                                                        Exit For
                                                                    End If

                                                                Else
                                                                    bError = True
                                                                    row1 = dtError.NewRow()
                                                                    'declara el nombre de la fila
                                                                    row1.Item("Fila") = i + 1
                                                                    row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                                    row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                                    row1.Item("Error") = "Clave de Producto " & CStr(frProducto(j)("ClaveProducto")) & " no pertenece a la factura o no cuenta con disponible para devolución"
                                                                    dtError.Rows.Add(row1)
                                                                    Exit For
                                                                End If

                                                            Else
                                                                bError = True
                                                                row1 = dtError.NewRow()
                                                                'declara el nombre de la fila
                                                                row1.Item("Fila") = i + 1
                                                                row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                                row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                                row1.Item("Error") = "Clave de Producto no puede ser NULL"
                                                                dtError.Rows.Add(row1)
                                                                Exit For
                                                            End If

                                                        Next

                                                        If bError = False Then
                                                            TimbraDocumento(idMotivo, dtTemporal.Rows(i)("Serie").ToString & dtTemporal.Rows(i)("Folio").ToString, dtTemporal.Rows(i)("Nota").ToString)
                                                        End If


                                                    End If

                                                Else
                                                    row1 = dtError.NewRow()
                                                    'declara el nombre de la fila
                                                    row1.Item("Fila") = i + 1
                                                    row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                                    row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                                    row1.Item("Error") = "Factura no existe o no se encuentra activa"
                                                    dtError.Rows.Add(row1)
                                                End If
                                            End If

                                        Else
                                            Dim row1 As DataRow
                                            row1 = dtError.NewRow()
                                            'declara el nombre de la fila
                                            row1.Item("Fila") = i + 1
                                            row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                            row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                            row1.Item("Error") = "El Folio no es numerico"
                                            dtError.Rows.Add(row1)
                                        End If
                                    Else
                                        Dim row1 As DataRow
                                        row1 = dtError.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("Fila") = i + 1
                                        row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                        row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                        row1.Item("Error") = "El IdMotivo es No existe"
                                        dtError.Rows.Add(row1)
                                    End If
                                Else
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("Serie") = dtTemporal.Rows(i)("Serie").ToString
                                    row1.Item("Folio") = dtTemporal.Rows(i)("Folio")
                                    row1.Item("Error") = "El IdMotivo es NULL"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Serie") = ""
                                row1.Item("Folio") = ""
                                row1.Item("Error") = "La Serie y/o Foliio son NULL"
                                dtError.Rows.Add(row1)
                            End If


                        Next

                        frmStatusMessage.Close()

                        If dtError.Rows.Count > 0 Then
                            MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Dim b As New FrmConsultaGen
                            b.Text = "Errores"
                            b.GridConsultaGen.DataSource = dtError
                            b.GridConsultaGen.RetrieveStructure(True)
                            b.GridConsultaGen.GroupByBoxVisible = False
                            b.ShowDialog()
                            b.Dispose()
                            dtError.Dispose()
                        Else
                            MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                    Else
                        MessageBox.Show("El archivo no cuenta con el formato: Serie,Folio,ClaveProducto,Cantidad,IdMotivo,Nota o se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Debe seleccionar Sucursal y Caja validas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
