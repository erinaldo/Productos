

Public Class FrmInvoiceServer
    Inherits System.Windows.Forms.Form

    Private bError As Boolean = False
    Private bPause As Boolean = False
    Private MailSSL As Boolean
    Private Moneda, MonedaDesc, MonedaRef, CTEClaveActual, CTENombreActual, ServidorCancelacion, Autoriza, PathXML, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF, regimenFiscal, PrinterInvoice As String
    Private InterfazSalida As String = ""
    Private iRegimenFiscal As Integer
    Private MailPort, TipoCF As Integer
    Private TipoCambio As Decimal
    Private dFechaActual As Date = Today.Date.Date
    Private dFechaVerificacion As Date = #1/1/2017#
    Private CAJClave As String = ""
    Private SUCClave As String

    Private iTipoPac, i, iCredito, NumFacturas As Integer
    Private Vencimiento As DateTime
    Private dt, dtVenta, dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable
    Private oCFD As CFD

    Private FacturaId As String = ""
    Private FACClave As String
    

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
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnPausa As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEjecutar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvoiceServer))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.BtnPausa = New Janus.Windows.EditControls.UIButton()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.BtnEjecutar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.BtnPausa)
        Me.GrpGeneral.Controls.Add(Me.LblMessage)
        Me.GrpGeneral.Controls.Add(Me.lblDate)
        Me.GrpGeneral.Controls.Add(Me.BtnEjecutar)
        Me.GrpGeneral.Controls.Add(Me.BtnSalir)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 13)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(420, 125)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        '
        'BtnPausa
        '
        Me.BtnPausa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPausa.BackColor = System.Drawing.SystemColors.Control
        Me.BtnPausa.Icon = CType(resources.GetObject("BtnPausa.Icon"), System.Drawing.Icon)
        Me.BtnPausa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnPausa.Location = New System.Drawing.Point(158, 43)
        Me.BtnPausa.Name = "BtnPausa"
        Me.BtnPausa.Size = New System.Drawing.Size(90, 37)
        Me.BtnPausa.TabIndex = 25
        Me.BtnPausa.ToolTipText = "Detener ejecución del Print Server"
        Me.BtnPausa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblMessage
        '
        Me.LblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblMessage.Location = New System.Drawing.Point(15, 88)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(389, 22)
        Me.LblMessage.TabIndex = 24
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDate.Location = New System.Drawing.Point(6, 14)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(408, 22)
        Me.lblDate.TabIndex = 23
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnEjecutar
        '
        Me.BtnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEjecutar.Icon = CType(resources.GetObject("BtnEjecutar.Icon"), System.Drawing.Icon)
        Me.BtnEjecutar.Location = New System.Drawing.Point(298, 43)
        Me.BtnEjecutar.Name = "BtnEjecutar"
        Me.BtnEjecutar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEjecutar.TabIndex = 3
        Me.BtnEjecutar.ToolTipText = "Iniciar Ejecución del Print Server"
        Me.BtnEjecutar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSalir.Icon = CType(resources.GetObject("BtnSalir.Icon"), System.Drawing.Icon)
        Me.BtnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSalir.Location = New System.Drawing.Point(18, 43)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.ToolTipText = "Terminar proceso de Ejecución del Print Server"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'FrmInvoiceServer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(439, 150)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInvoiceServer"
        Me.Text = "Invoice Server"
        Me.GrpGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmInvoiceServer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        Else
            ModPOS.InvoiceServer.Dispose()
            ModPOS.InvoiceServer = Nothing
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
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

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        lblDate.Text = DateTime.Today.ToShortDateString & " " & DateTime.Now.ToShortTimeString
        LblMessage.Text = "Buscando.."
        Clock.Stop()

        dFechaActual = Today.Date

        dtVenta = ModPOS.Recupera_Tabla("st_recupera_ventas", Nothing)
        NumFacturas = dtVenta.Rows.Count

        If NumFacturas > 0 Then

            Dim sFormatoFactura As String
            Dim Referencia As String
            Dim Banco As String
            Dim Tipo As String
            Dim SAT As String


            oCFD.TipoCF = TipoCF
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

            If dFechaActual <> dFechaVerificacion Then

                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
                MonedaRef = dt.Rows(0)("Referencia")
                MonedaDesc = dt.Rows(0)("Descripcion")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()


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

                dFechaVerificacion = dFechaActual
            End If

            Dim dtCaja As DataTable
            Dim NumCopias As Integer
            Dim impresora As String
            For i = 0 To dtVenta.Rows.Count - 1

                ' recupera numero de copias de facturas a credito
                If dtVenta.Rows(i)("CAJClave") <> CAJClave Then
                    CAJClave = dtVenta.Rows(i)("CAJClave")
                    dtCaja = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
                    NumCopias = dtCaja.Rows(0)("copiaCredito")
                    impresora = dtCaja.Rows(0)("ImpresoraFac")
                    dtCaja.Dispose()

                    Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", impresora)
                    PrinterInvoice = dtPrinter.Rows(0)("Referencia")
                    dtPrinter.Dispose()
                End If

                'Recupera Información del Centro de Expedición

                If dtVenta.Rows(i)("SUCClave") <> SUCClave Then

                    SUCClave = dtVenta.Rows(i)("SUCClave")
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
                End If



                LblMessage.Text = "Generando Comprobantes Fiscales Digitales " & CStr(i + 1) & "/" & CStr(NumFacturas)

                sFormatoFactura = FormatoFactura

                'Carga datos Receptor
                Dim SaldoCliente As Double
                dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", dtVenta.Rows(i)("Cliente"))

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

                oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
                oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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

                'Valida MetodoPago
                Dim dtMetodosPago As DataTable = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", oCFD.CTEClave)
                If dtMetodosPago.Rows.Count <> 1 Then
                    ' Grabar en log de errores de faturacion 
                    ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 1, "@DOCClave", dtVenta.Rows(i)("VENClave"), "@Folio", dtVenta.Rows(i)("Folio"), "@Error", "El cliente " & oCFD.Clave & ", no cuenta con Metodo de Pago o cuenta con mas de uno", "@Usuario", ModPOS.UsuarioActual)
                Else

                    If VerificaDatoFiscalCte(oCFD) = True Then
                        'Valida credito
                        If dtVenta.Rows(i)("Tipo") = "Credito" Then
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


                        FacturaId = ModPOS.obtenerLlave
                        FACClave = ModPOS.obtenerLlave

                        ' Graba factura y detalle
                        oCFD.DOCClave = FACClave

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



                        If ModPOS.validaFolio(SUCClave, CAJClave, 1, 1) Then
                            Try

                                ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)

                                ModPOS.Ejecuta("st_venta_factura", _
                                               "@idFactura", FacturaId, _
                                               "@FACClave", FACClave, _
                                               "@VENClave", dtVenta.Rows(i)("VENClave"), _
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
                                               "@Nota", dtVenta.Rows(i)("Nota"), _
                                               "@UsoCFDI", oCFD.UsoCFDI, _
                                               "@Usuario", ModPOS.UsuarioActual)


                                ' Si es venta de contado. Verifica si tiene Anticipos por aplicar
                                If iCredito = 0 Then

                                    Dim dtAbnSaldo As DataTable = Recupera_Tabla("st_aplicar_abn", "@VENClave", dtVenta.Rows(i)("VENClave"))
                                    If dtAbnSaldo.Rows.Count > 0 Then
                                        Dim dtFacturas As DataTable = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", FacturaId)
                                        For Each row As DataRow In dtAbnSaldo.Select("", "Saldo ASC")
                                            ModPOS.Aplica_Pagos(dtFacturas, oCFD.CTEClave, row("ID"), row("TipoPago"), row("Saldo"), CAJClave, row("Tipo"))
                                            oCFD.AplicaAnticipo = True
                                        Next
                                        dtFacturas.Dispose()
                                        ModPOS.Ejecuta("st_elimina_pendiente", "@VENClave", dtVenta.Rows(i)("VENClave"))
                                    Else
                                        oCFD.AplicaAnticipo = False
                                    End If
                                    dtAbnSaldo.Dispose()
                                Else
                                    oCFD.AplicaAnticipo = False
                                End If

                                'Seccion para agregar multiples metodos de pago


                                If oCFD.VersionCF = "3.3" AndAlso iCredito = 1 Then

                                    ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                       "@FacturaID", FacturaId, _
                                       "@MetodoPago", 0, _
                                       "@Banco", "", _
                                       "@Referencia", "", _
                                       "@SAT", "99")
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
                                                Exit Sub
                                            End If
                                        ElseIf a.DialogResult = DialogResult.Cancel Then
                                            a.Dispose()
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


                                    iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto, Nothing, Nothing, False)

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

                                If iTipoPac <> 0 Then

                                    If oCFD.ImprimirFac = True Then
                                        ModPOS.imprimirFacturas(oCFD.TipoCF, FacturaId, SUCClave, TipoCambio, MonedaDesc, MonedaRef, PrinterInvoice, IIf(iCredito = 1, NumCopias + 1, 1), oCFD.VersionCF)
                                    End If

                                    If oCFD.email <> "" Then
                                        Dim sMsg As String
                                        sMsg = ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, sFormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, False)
                                        If sMsg <> "" Then
                                            ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 1, "@DOCClave", dtVenta.Rows(i)("VENClave"), "@Folio", dtVenta.Rows(i)("Folio"), "@Error", "Error de envio:" & sMsg, "@Usuario", ModPOS.UsuarioActual)
                                        End If
                                    End If
                                Else
                                    ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 1, "@DOCClave", dtVenta.Rows(i)("VENClave"), "@Folio", dtVenta.Rows(i)("Folio"), "@Error", "Error de Timbrado:", "@Usuario", ModPOS.UsuarioActual)
                                End If
                                System.Threading.Thread.Sleep(1000)

                            Catch ex As Exception
                                ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 1, "@DOCClave", dtVenta.Rows(i)("VENClave"), "@Folio", dtVenta.Rows(i)("Folio"), "@Error", IIf(ex.ToString.Length > 500, ex.ToString.Substring(0, 500), ex.ToString), "@Usuario", ModPOS.UsuarioActual)

                            End Try
                        Else
                            MessageBox.Show("No hay Folios disponibles para facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        ' Grabar en log de errores de faturacion 
                        ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 1, "@DOCClave", dtVenta.Rows(i)("VENClave"), "@Folio", dtVenta.Rows(i)("Folio"), "@Error", "El cliente " & oCFD.Clave & " No cuenta con domicilio fiscal valido", "@Usuario", ModPOS.UsuarioActual)
                    End If
                End If

            Next

            If bPause = False Then
                Clock.Start()
            End If

        Else
            If bPause = False Then
                Clock.Start()
            End If
        End If
    End Sub

    Private Sub FrmPrintServer_Load(sender As Object, e As EventArgs) Handles Me.Load
        LblMessage.Text = "Proceso Detenido"

        oCFD = New CFD

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

        oCFD.VersionCF = VersionCF

     


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

    End Sub

    Private Sub BtnEjecutar_Click(sender As Object, e As EventArgs) Handles BtnEjecutar.Click
        bError = True
        bPause = False
        LblMessage.Text = "Proceso en Ejecución"
        Clock.Start()

    End Sub

    Private Sub BtnPausa_Click(sender As Object, e As EventArgs) Handles BtnPausa.Click
        bError = True
        LblMessage.Text = "Proceso Detenido"
        bPause = True
        Clock.Stop()
    End Sub
End Class
