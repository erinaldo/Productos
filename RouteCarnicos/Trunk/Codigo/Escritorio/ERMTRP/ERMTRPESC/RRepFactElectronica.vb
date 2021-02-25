Imports BASMENLOG
Imports ThoughtWorks.QRCode.Codec
Imports ThoughtWorks.QRCode.Codec.Data
Imports ThoughtWorks.QRCode.Codec.Util
Imports System.IO

Public Class RRepFactElectronica
    Inherits FormasBase.FrmBase

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Friend WithEvents rptFactElectronica1 As rptFactElectronica

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents rvwReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rvwReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.rptFactElectronica1 = New rptFactElectronica
        Me.SuspendLayout()
        '
        'rvwReporte
        '
        Me.rvwReporte.ActiveViewIndex = -1
        Me.rvwReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rvwReporte.DisplayGroupTree = False
        Me.rvwReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwReporte.Location = New System.Drawing.Point(0, 0)
        Me.rvwReporte.Name = "rvwReporte"
        Me.rvwReporte.ShowCloseButton = False
        Me.rvwReporte.ShowGroupTreeButton = False
        Me.rvwReporte.ShowRefreshButton = False
        Me.rvwReporte.Size = New System.Drawing.Size(754, 564)
        Me.rvwReporte.TabIndex = 1
        '
        'RRepFactElectronica
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(754, 564)
        Me.Controls.Add(Me.rvwReporte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RRepFactElectronica"
        Me.ShowInTaskbar = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RRepVentas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private oMensaje As CMensaje
    Private sProyecto As String = "ERMTRP"
    Dim sServidor As String
    Dim sBaseDatos As String
    Dim sUsuario As String
    Dim sPassword As String
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private bClienteCambio As Boolean = False
    Private oAcceso As LbAcceso.cAcceso
    Public Sub CONSULTAR(ByVal parsTransProdId As String)

        oMensaje = New CMensaje
        MostrarReporte(parsTransProdId)
        Me.Text = oMensaje.RecuperarDescripcion(sProyecto & "_RRepFacturacionElectronica")
        Me.ShowDialog()
    End Sub

    Public Function CrearReporte(ByVal parsTransProdId As String) As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim oReporte As New CrystalDecisions.CrystalReports.Engine.ReportClass
        oMensaje = New CMensaje

        Dim trp As New ERMTRPLOG.cTransProd
        Dim arrayTransProdID As New ArrayList
        Dim arrayImpuesto As New ArrayList
        Dim arrayTasa As New ArrayList
        Dim arrayImporte As New ArrayList
        Dim dtTrasnprod As DataTable
        Dim dtTipoFase As DataTable

        Dim sConsulta As New System.Text.StringBuilder

        sConsulta.AppendLine("select Tipo, TipoFase, TipoNotaCredito, FechaFacturacion, FechaHoraAlta, SubEmpresaID, FacturaId ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID ")
        sConsulta.AppendLine("where TRP.TransprodId = '" & parsTransProdId & "' ")

        dtTipoFase = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
        Dim tipoMov As Integer
        Dim tipofase As Integer
        Dim tipoNotaCredito As Integer
        Dim fechaHoraAlta As DateTime
        Dim subempresaId As String
        Dim facturaId As String

        If dtTipoFase Is Nothing Or dtTipoFase.Rows.Count < 0 Then
            Return Nothing
        Else
            tipoMov = dtTipoFase.Rows(0)("Tipo")
            tipofase = dtTipoFase.Rows(0)("TipoFase")
            tipoNotaCredito = dtTipoFase.Rows(0)("TipoNotaCredito")
            fechaHoraAlta = Convert.ToDateTime(dtTipoFase.Rows(0)("FechaHoraAlta"))
            subempresaId = Convert.ToString(dtTipoFase.Rows(0)("SubEmpresaID"))
            facturaId = Convert.ToString(dtTipoFase.Rows(0)("FacturaId"))
        End If

        Dim nFormatoFact As Int16
        nFormatoFact = 1 'LbConexion.cConexion.Instancia.EjecutarComandoScalar("select top 1 FormatoFactura from SEMHist where SubEmpresaId = '" + subempresaId + "' AND SEMHistFechaInicio < '" + fechaHoraAlta.ToString("yyyy-MM-ddTHH:mm:ss") + "' order by SEMHistFechaInicio desc ")
        Dim sVersionCFD As String
        'nVersionCFD = LbConexion.cConexion.Instancia.EjecutarComandoScalar("select top 1 VersionCFD from SEMHist where SubEmpresaId = '" + subempresaId + "' AND SEMHistFechaInicio < '" + fechaHoraAlta.ToString("yyyy-MM-ddTHH:mm:ss") + "' order by SEMHistFechaInicio desc ")

        If (tipoMov = 8) Then
            Select Case nFormatoFact
                Case 1
                    oReporte = New rptFactElectronica
                Case 2
                    oReporte = New rptFactElectronica2
                Case 3
                    oReporte = New rptFactElectronica3
                Case 4
                    oReporte = New rptFactElectronica4
                Case 5
                    oReporte = New rptCFDI
                Case 6
                    oReporte = New rptCFDI2
                Case 7
                    oReporte = New rptFactElecAltenia
            End Select
        ElseIf (tipoMov = 8 And nFormatoFact = 4) Then
            oReporte = New rptFactElectronica4
        Else 'Si es nota de credito
            If nFormatoFact = 5 Then
                oReporte = New rptCFDI
            ElseIf nFormatoFact = 6 Then
                oReporte = New rptCFDI2

            Else
                oReporte = New rptFactElectronica
                'Nota de credito siempre utiliza el formato generico si importar el que este configurado
                nFormatoFact = 1
            End If
        End If

        sConsulta = New System.Text.StringBuilder
        Dim bImpuestoGlb As Boolean = False

        sConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
        If tipoMov = 8 Then
            sConsulta.AppendLine("where TRP.FacturaID = '" & parsTransProdId & "' and TRP.Tipo = 1 ")
        Else
            sConsulta.AppendLine("where TRP.TransProdID = '" & parsTransProdId & "' and TRP.Tipo = 10 ")
        End If

        bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta.ToString) = 0)


        Dim sClienteClave As String
        Dim dFechaFactura As Date
        sConsulta = New System.Text.StringBuilder
        sConsulta.AppendLine("select VIS.ClienteClave, FAC.FechaHoraAlta ")
        sConsulta.AppendLine("from TransProd FAC ")
        sConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
        sConsulta.AppendLine("where FAC.TransProdID = '" & parsTransProdId & "'")
        Dim dtDatosFac As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
        sClienteClave = dtDatosFac.Rows(0)("ClienteClave")
        dFechaFactura = CType(dtDatosFac.Rows(0)("FechaHoraAlta"), Date)

        If tipoMov = 10 Then
            dtDatosFac = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & facturaId & "'")

            dFechaFactura = CType(dtDatosFac.Rows(0)("FechaHoraAlta"), Date)

            If Not dtDatosFac.Rows(0)!CadenaOriginal Is DBNull.Value Then
                Dim cadena As String() = dtDatosFac.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                Dim fechaCadena As String = cadena(5)
                Dim fechaCadenaDate As DateTime
                If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                    dFechaFactura = fechaCadenaDate
                End If
            End If
        End If



        Dim dtImpuestos As New DataTable
        dtImpuestos.Columns.Add("Impuesto")
        dtImpuestos.Columns.Add("Importe")

        If tipofase <> 0 Then
            If tipoMov = 8 Then 'Factura
                dtTrasnprod = LbConexion.cConexion.Instancia.EjecutarConsulta("select TransProdID from transprod where facturaid='" & parsTransProdId & "' and Tipo=1")
                For i As Integer = 0 To dtTrasnprod.Rows.Count - 1
                    arrayTransProdID.Add(dtTrasnprod.Rows(i)("TransProdID"))
                Next
                trp.ImpuestosConDesc(arrayTransProdID, sClienteClave, dFechaFactura, bImpuestoGlb, arrayImpuesto, arrayTasa, arrayImporte)

            Else
                arrayTransProdID.Add(parsTransProdId)
                trp.ImpuestosConDesc(parsTransProdId, sClienteClave, dFechaFactura, bImpuestoGlb, arrayImpuesto, arrayTasa, arrayImporte)
            End If

            For i As Integer = 0 To arrayImpuesto.Count - 1
                dtImpuestos.Rows.Add(New Object() {arrayImpuesto(i) & " " & arrayTasa(i) & "%", arrayImporte(i)})
            Next
        End If

        oReporte.OpenSubreport("Impuestos").Database.Tables("Impuestos").SetDataSource(dtImpuestos)


        Dim cmd As String
        If nFormatoFact = 6 Then 'CFDI Jersey
            cmd = "Select TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, TDF.Calle, TDF.NumExt, TDF.NumInt, TDF.Colonia, "
            cmd &= "TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, "
            cmd &= "TDF.LogotipoEm, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm, TDF.NumExtEm, TDF.NumIntEm, "
            cmd &= "TDF.ColoniaEm, TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, "
            cmd &= "TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, TDF.ColoniaEx, TDF.CodigoPostalEx, TDF.ReferenciaDomEx, "
            cmd &= "TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, "
            cmd &= "TRP.FechaHoraAlta as FechaExpedicion, TRP.Total as TotalFAC, '(' + dbo.fn_numeroletra(TRP.Total) + ')' as TotalLetra, "
            cmd &= "case when TRP.Tipo = 8 then TRP.Notas else (select UUID from TRPDatoFiscal where TransProdID = (select FacturaID from TransProd where TransProdID = '" & parsTransProdId & "')) end  as OrdenCompra, "
            cmd &= "isnull(TDF.UUID, '') as UUID, TDF.NoCertificadoSAT, TDF.FechaTimbrado, TDF.SelloDigital as SelloDigitalCFDI, "
            cmd &= "TDF.SelloSAT, TDF.CadenaOriginalTFD, convert(image, null) as CodigoBarras, TRP.Folio as Folio, "
            cmd &= "V.RUTClave as Ruta, C.Clave as Clave, TDF.MetodoPago, TDF.TipoVersion as VersionCFD "
            cmd &= "from TRPDatoFiscal TDF "
            cmd &= "inner join TransProd TRP on TRP.TransProdID = TDF.TransProdID "
            cmd &= "inner join Visita V on V.VisitaClave = TRP.VisitaClave and V.DiaClave=TRP.DiaClave "
            cmd &= "inner join Cliente C on C.ClienteClave = V.ClienteClave "
            cmd &= "inner join SubEmpresa SEM on TRP.SubEmpresaID = SEM.SubEmpresaId "
            cmd &= "where TDF.TransProdID = '" & parsTransProdId & "'"
        ElseIf nFormatoFact = 5 Then 'CFDI
            cmd = "Select TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, TDF.Calle, TDF.NumExt, TDF.NumInt, TDF.Colonia, "
            cmd &= "TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, "
            cmd &= "TDF.LogotipoEm, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm, TDF.NumExtEm, TDF.NumIntEm, "
            cmd &= "TDF.ColoniaEm, TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, "
            cmd &= "TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, TDF.ColoniaEx, TDF.CodigoPostalEx, TDF.ReferenciaDomEx, "
            cmd &= "TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, "
            cmd &= "TRP.FechaHoraAlta as FechaExpedicion, TRP.Total as TotalFAC, '(' + dbo.fn_numeroletra(TRP.Total) + ')' as TotalLetra, "
            cmd &= "case when TRP.Tipo = 8 then TRP.Notas else (select UUID from TRPDatoFiscal where TransProdID = (select FacturaID from TransProd where TransProdID = '" & parsTransProdId & "')) end  as OrdenCompra, "
            cmd &= "isnull(TDF.UUID, '') as UUID, TDF.NoCertificadoSAT, TDF.FechaTimbrado, TDF.SelloDigital as SelloDigitalCFDI, "
            cmd &= "TDF.SelloSAT, TDF.CadenaOriginalTFD, convert(image, null) as CodigoBarras,TRP.Folio as Folio, TDF.MetodoPago, TDF.TipoVersion as VersionCFD "
            cmd &= "from TRPDatoFiscal TDF "
            cmd &= "inner join TransProd TRP on TRP.TransProdID = TDF.TransProdID "
            cmd &= "inner join SubEmpresa SEM on TRP.SubEmpresaID = SEM.SubEmpresaId "
            cmd &= "where TDF.TransProdID = '" & parsTransProdId & "'"

        ElseIf nFormatoFact = 4 Then
            cmd = " select V.RutClave as Ruta, "
            cmd &= " C.Clave,TDF.NumCertificado, TDF.Aprobacion, TDF.AnioAprobacion, TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, TDF.Calle + ' ' + TDF.NumExt + ' ' + TDF.NumInt as Calle, "
            cmd &= "TDF.NumExt, TDF.NumInt, TDF.Colonia, TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, TDF.CadenaOriginal, TDF.SelloDigital, "
            cmd &= "TDF.LogotipoEm, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm + ' ' + TDF.NumExtEm + ' ' + TDF.NumIntEm as CalleEm, TDF.NumExtEm, TDF.NumIntEm, "
            cmd &= "TDF.ColoniaEm, TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, TDF.ColoniaEx, "
            cmd &= "TDF.CodigoPostalEx, TDF.ReferenciaDomEx, TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, TRP.Folio, TRP.FechaHoraAlta as MFechaHora, "
            cmd &= "TDF.LugarExpedicion as Expedida, TDF.MetodoPago, TDF.TipoVersion as VersionCFD "
            cmd &= " from TRPDatoFiscal TDF  "
            cmd &= " inner join TransProd TRP on  TDF.TransProdID = TRP.TransProdID  "
            cmd &= " inner join Visita V on V.VisitaClave = TRP.VisitaClave and V.DiaClave=TRP.DiaClave  "
            cmd &= " inner join Cliente C on C.ClienteClave = V.ClienteClave   "
            cmd &= " inner join SubEmpresa SEM on TRP.SubEmpresaID = SEM.SubEmpresaId "
            cmd &= " inner join (select distinct FolioID,Serie from FolioSolicitado )FS on FS.Serie=TDF.Serie  "
            cmd &= " inner join FolioDetalle FD on FD.FolioID=FS.FolioID and FD.TipoEstado=1 "
            cmd &= "where TDF.TransProdID = '" & parsTransProdId & "'"
        ElseIf nFormatoFact = 7 Then
            cmd = "select VIS.RutClave as Ruta, "
            cmd &= "CLI.Clave,TDF.NumCertificado, TDF.Aprobacion, TDF.AnioAprobacion, TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, TDF.Calle + ' ' + TDF.NumExt + ' ' + TDF.NumInt as Calle, "
            cmd &= "TDF.NumExt, TDF.NumInt, TDF.Colonia, TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, TDF.CadenaOriginal, TDF.SelloDigital, "
            cmd &= "TDF.LogotipoEm, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm + ' ' + TDF.NumExtEm + ' ' + TDF.NumIntEm as CalleEm, TDF.NumExtEm, TDF.NumIntEm, "
            cmd &= "TDF.ColoniaEm, TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, TDF.ColoniaEx, "
            cmd &= "TDF.CodigoPostalEx, TDF.ReferenciaDomEx, TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, TRP.Folio, TRP.FechaHoraAlta as MFechaHora, "
            cmd &= "TDF.LugarExpedicion as Expedida, TDF.MetodoPago, TDF.TipoVersion as VersionCFD "
            cmd &= "from TRPDatoFiscal TDF "
            cmd &= "inner join TransProd TRP on TRP.TransProdID = TDF.TransProdID "
            cmd &= "inner join Visita VIS on VIS.VisitaClave = TRP.VisitaClave AND VIS.DiaClave = TRP.DiaClave "
            cmd &= "inner join Cliente CLI on CLI.ClienteClave = VIS.ClienteClave "
            cmd &= "inner join SubEmpresa SEM on TRP.SubEmpresaID = SEM.SubEmpresaId "
            cmd &= "where TDF.TransProdID = '" & parsTransProdId & "'"
        Else
            cmd = "Select TDF.NumCertificado, TDF.Aprobacion, TDF.AnioAprobacion, TDF.RazonSocial, TDF.RFC, TDF.TelefonoContacto, TDF.Calle + ' ' + TDF.NumExt + ' ' + TDF.NumInt as Calle, "
            cmd &= "TDF.NumExt, TDF.NumInt, TDF.Colonia, TDF.CodigoPostal, TDF.ReferenciaDom, TDF.Localidad, TDF.Municipio, TDF.Entidad, TDF.Pais, TDF.CadenaOriginal, TDF.SelloDigital, "
            cmd &= "TDF.LogotipoEm, TDF.TelefonoEm, TDF.RFCEm, TDF.NombreEm, TDF.CalleEm + ' ' + TDF.NumExtEm + ' ' + TDF.NumIntEm as CalleEm, TDF.NumExtEm, TDF.NumIntEm, "
            cmd &= "TDF.ColoniaEm, TDF.LocalidadEm, TDF.ReferenciaDomEm, TDF.MunicipioEm, TDF.RegionEm, TDF.PaisEm, TDF.CodigoPostalEm, TDF.CalleEx, TDF.NumExtEx, TDF.NumIntEx, TDF.ColoniaEx, "
            cmd &= "TDF.CodigoPostalEx, TDF.ReferenciaDomEx, TDF.LocalidadEx, TDF.MunicipioEx, TDF.EntidadEx, TDF.PaisEx, TRP.Folio, TRP.FechaHoraAlta as MFechaHora, "
            cmd &= "TDF.LugarExpedicion  as Expedida, '' as Clave, '' as Ruta, TDF.MetodoPago, TDF.TipoVersion as VersionCFD "
            cmd &= "from TRPDatoFiscal TDF "
            cmd &= "inner join TransProd TRP on TRP.TransProdID = TDF.TransProdID "
            cmd &= "inner join SubEmpresa SEM on TRP.SubEmpresaID = SEM.SubEmpresaId "
            cmd &= "where TDF.TransProdID = '" & parsTransProdId & "'"
        End If

        Dim dtEncabezado As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(cmd)
        sVersionCFD = dtEncabezado.Rows(0)("VersionCFD")

        If nFormatoFact = 6 Then
            Dim oImagen As Image = GenerarCodigoBarras(dtEncabezado.Rows(0)("RFCEm"), dtEncabezado.Rows(0)("RFC"), dtEncabezado.Rows(0)("TotalFAC"), dtEncabezado.Rows(0)("UUID"))
            dtEncabezado.Rows(0)("CodigoBarras") = ConversionImagen(oImagen)
        ElseIf nFormatoFact = 5 Then
            Dim oImagen As Image = GenerarCodigoBarras(dtEncabezado.Rows(0)("RFCEm"), dtEncabezado.Rows(0)("RFC"), dtEncabezado.Rows(0)("TotalFAC"), dtEncabezado.Rows(0)("UUID"))
            dtEncabezado.Rows(0)("CodigoBarras") = ConversionImagen(oImagen)
        End If

        oReporte.Database.Tables(1).SetDataSource(dtEncabezado)

        Dim sFolioEntrega As String = ""
        Dim sFolioCliente As String = ""
        Dim sFolioRemision As String = ""
        Dim nCantPedidos As Integer = 0
        If nFormatoFact = 4 Or nFormatoFact = 6 Then
            cmd = "select TVA.FolioEntrega, TVA.FolioCliente, TVA.Remision "
            cmd &= "from TRPVtaAcreditada TVA "
            cmd &= "inner join TransProd TRP on TVA.TransProdID = TRP.TransProdID "
            cmd &= "where TRP.FacturaID = '" & parsTransProdId & "' and TRP.Tipo = 1 and TRP.TipoFase <> 0 "
            cmd &= "order by TRP.FechaHoraAlta "

            Dim dtVtaAcreditada As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(cmd)
            oReporte.Subreports("VentaAcreditada").Database.Tables("VentaAcreditada").SetDataSource(dtVtaAcreditada)

            If dtVtaAcreditada.Rows.Count > 0 Then
                sFolioEntrega = dtVtaAcreditada.Rows(0)("FolioEntrega")
                sFolioCliente = dtVtaAcreditada.Rows(0)("FolioCliente")
                sFolioRemision = dtVtaAcreditada.Rows(0)("Remision")
            End If
            nCantPedidos = dtVtaAcreditada.Rows.Count
        End If

        sConsulta = New System.Text.StringBuilder
        If (tipoMov = 10 And tipoNotaCredito = 1) Then bImpuestoGlb = False

        If bImpuestoGlb Then
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
            sConsulta.AppendLine("select * into #ImpNoDes from ( ")
            sConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, SUM(TDI.ImpuestoIMP) as ImpuestoIMP, SUM(TDI.ImpuestoPU) as ImpuestoPU, SUM(TDI.ImpDesGlb) as ImpDesGlb ")
            sConsulta.AppendLine("from TPDImpuesto TDI ")
            sConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            If tipoMov = 8 Then
                sConsulta.AppendLine("where TRP.FacturaId = '" & parsTransProdId & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
            Else
                sConsulta.AppendLine("where TRP.TransProdId = '" & parsTransProdId & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
            End If
            sConsulta.AppendLine("select ImpuestoClave ")
            sConsulta.AppendLine("from CLINoDesImp ")
            sConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            sConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            sConsulta.AppendLine(") as t ")
        End If

            If nFormatoFact = 6 Then
                If tipoMov = 8 Then
                    'Factura
                    sConsulta.AppendLine("select ProductoClave,CodigoBarras,Nombre,ProductoNota,Unidad,sum(cantidad)as cantidad,precio,sum(subtotal) as subtotal,sum(descuentoimp) as descuentoimp,formapago from (")
                    sConsulta.AppendLine("select N.Orden ,PU.KgLts, pro.PRODUCTOCLAVE, PRO.CodigoBarras, pro.nombre,  convert(varchar(200),pro.Nota) as ProductoNota, v2.descripcion as unidad,det.cantidad,")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("(det.precio + isnull(IMP.ImpuestoPU, 0)) as Precio, (det.precio + isnull(IMP.ImpuestoPU, 0)) * det.cantidad as subtotal, (det.descuentoimp + isnull(((det.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb), 0))  ")
                    Else
                        sConsulta.AppendLine("det.precio,det.precio*det.cantidad as subtotal, det.descuentoimp ")
                    End If
                    sConsulta.AppendLine("+isnull((select sum(desimporte) from tpddes des where des.transprodid = det.transprodid and des.transproddetalleid=det.transproddetalleid ),0) ")
                    sConsulta.AppendLine("+isnull((select sum(desv.desimporte) from tpddesvendedor desv where desv.transprodid=det.transprodid and desv.transproddetalleid=det.transproddetalleid),0) as descuentoimp ")
                    sConsulta.AppendLine(",v.descripcion as formapago ")
                    sConsulta.AppendLine("from transprod fac ")
                    sConsulta.AppendLine("inner join transprod Ven on fac.transprodid=ven.facturaid ")
                    sConsulta.AppendLine("inner join transproddetalle det on ven.transprodid=det.transprodid ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on det.TransProdID = IMP.TransProdId and det.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join producto pro on pro.productoclave=det.productoclave ")
                    sConsulta.AppendLine("inner join vavdescripcion v on  v.varcodigo ='FVENTA' and v.vavclave=ven.CFVTipo ")
                    sConsulta.AppendLine("inner join vavdescripcion v2 on  v2.varcodigo ='UnidadV' and v2.vavclave=det.tipounidad ")
                    sConsulta.AppendLine("inner join ProductoEsquema PE on PE.ProductoClave=pro.productoclave ")
                    sConsulta.AppendLine("inner join Esquema E on E.EsquemaID =PE.EsquemaID  ")
                    sConsulta.AppendLine("inner join (SELECT * FROM [Route].[dbo].[BuscaIdsEsquemaNivel]()) N on N.Ids =PE.EsquemaID  ")
                    sConsulta.AppendLine("inner join ProductoUnidad PU on PU.ProductoClave=det.ProductoClave and det.TipoUnidad=PRUTipoUnidad ")
                    sConsulta.AppendLine("where fac.transprodid= '" & parsTransProdId & "' and v.vadtipolenguaje='" + lbGeneral.cParametros.Lenguaje + "' and v.vadtipolenguaje =v2.vadtipolenguaje ")
                    sConsulta.AppendLine(") as t ")
                    sConsulta.AppendLine("group by ProductoClave,CodigoBarras,Nombre,ProductoNota,Unidad,formapago,precio,Orden,KgLts ")
                    sConsulta.AppendLine("order by Orden asc, KgLts desc ")
                Else
                    'Nota de crédito
                    sConsulta.AppendLine("select TPD.ProductoClave, PRO.CodigoBarras, PRO.Nombre, pro.Nota as ProductoNota, VAD.Descripcion as Unidad, ")
                    If bImpuestoGlb Then
                    sConsulta.AppendLine("TPD.Cantidad, (TPD.Precio  + isnull(IMP.ImpuestoPU, 0)) as Precio, TPD.Cantidad * (TPD.Precio  + isnull(IMP.ImpuestoPU, 0)) as Subtotal, TPD.DescuentoImp + (Cantidad * isnull(IMP.ImpuestoPU, 0) - isnull(IMP.ImpDesGlb, 0)) as DescuentoImp ")
                    Else
                        sConsulta.AppendLine("TPD.Cantidad, TPD.Precio, TPD.Cantidad * TPD.Precio as Subtotal, TPD.DescuentoImp ")
                    End If
                    sConsulta.AppendLine("from TransProd TRP ")
                    sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
                    sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" + lbGeneral.cParametros.Lenguaje + "' ")
                    sConsulta.AppendLine("where TRP.TransProdID = '" & parsTransProdId & "' ")
                End If
            ElseIf nFormatoFact = 5 Then
                If tipoMov = 8 Then
                    'Factura
                    sConsulta.AppendLine("select pro.PRODUCTOCLAVE, PRO.CodigoBarras, pro.nombre, pro.Nota as ProductoNota, v2.descripcion as unidad,det.cantidad, ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("(det.precio + isnull(IMP.ImpuestoPU, 0)) as Precio, (det.precio + isnull(IMP.ImpuestoPU, 0)) * det.cantidad as subtotal, (det.descuentoimp + isnull(((det.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb), 0))  ")
                    Else
                        sConsulta.AppendLine("det.precio,det.precio*det.cantidad as subtotal, det.descuentoimp ")
                    End If
                    sConsulta.AppendLine("+isnull((select sum(desimporte) from tpddes des where des.transprodid = det.transprodid and des.transproddetalleid=det.transproddetalleid ),0) ")
                    sConsulta.AppendLine("+isnull((select sum(desv.desimporte) from tpddesvendedor desv where desv.transprodid=det.transprodid and desv.transproddetalleid=det.transproddetalleid),0) as descuentoimp ")
                    sConsulta.AppendLine("from transprod fac ")
                    sConsulta.AppendLine("inner join transprod Ven on fac.transprodid=ven.facturaid ")
                    sConsulta.AppendLine("inner join transproddetalle det on ven.transprodid=det.transprodid ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on det.TransProdID = IMP.TransProdId and det.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join producto pro on pro.productoclave=det.productoclave ")
                    sConsulta.AppendLine("inner join vavdescripcion v on  v.varcodigo ='FVENTA' and v.vavclave=ven.CFVTipo ")
                    sConsulta.AppendLine("inner join vavdescripcion v2 on  v2.varcodigo ='UnidadV' and v2.vavclave=det.tipounidad ")
                    sConsulta.AppendLine("where fac.transprodid= '" & parsTransProdId & "' and v.vadtipolenguaje='" + lbGeneral.cParametros.Lenguaje + "' and v.vadtipolenguaje =v2.vadtipolenguaje ")
                Else
                    'Nota de crédito
                    sConsulta.AppendLine("select TPD.ProductoClave, PRO.CodigoBarras, PRO.Nombre, pro.Nota as ProductoNota, VAD.Descripcion as Unidad, ")
                    If bImpuestoGlb Then
                    sConsulta.AppendLine("TPD.Cantidad, (TPD.Precio  + isnull(IMP.ImpuestoPU, 0)) as Precio, TPD.Cantidad * (TPD.Precio  + isnull(IMP.ImpuestoPU, 0)) as Subtotal, TPD.DescuentoImp + (Cantidad * isnull(IMP.ImpuestoPU, 0) - isnull(IMP.ImpDesGlb, 0)) as DescuentoImp ")
                    Else
                        sConsulta.AppendLine("TPD.Cantidad, TPD.Precio, TPD.Cantidad * TPD.Precio as Subtotal, TPD.DescuentoImp ")
                    End If
                    sConsulta.AppendLine("from TransProd TRP ")
                    sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
                    sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" + lbGeneral.cParametros.Lenguaje + "' ")
                    sConsulta.AppendLine("where TRP.TransProdID = '" & parsTransProdId & "' ")
                End If
            Else
                If tipoMov = 8 Then
                    'Factura
                    'sConsulta.AppendLine("select t.Folio, t.FolioFactura, t.fechafacturacion, t.formapago, t.ProductoClave, t.CodigoBarras, t.Nombre, t.unidad, ")
                    'sConsulta.AppendLine("t.Cantidad, t.Precio, t.subtotal, case when t.descuentoimp < 0 then 0 else t.descuentoimp end as DescuentoImp, t.total, ")
                    'sConsulta.AppendLine("t.descuentovendedor, t.subtotalFac, t.impuesto, t.totalFac, t.TotalLetra, t.OrdenCompra, t.ProductoNota ")
                    'sConsulta.AppendLine("from ( ")
                    sConsulta.AppendLine("select fac.folio, '' as FolioFactura, convert(varchar(10), fac.FechaHoraAlta, 103) + ' ' + convert(varchar(10), fac.FechaHoraAlta, 108) as fechafacturacion,v.descripcion as formapago, ")
                    sConsulta.AppendLine("pro.PRODUCTOCLAVE, PRO.CodigoBarras, pro.nombre,v2.descripcion as unidad,det.cantidad, ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("(det.precio + isnull(IMP.ImpuestoPU, 0)) as Precio, (det.precio + isnull(IMP.ImpuestoPU, 0)) * det.cantidad as subtotal, (det.descuentoimp + isnull(((det.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb), 0))  ")
                    Else
                        sConsulta.AppendLine("det.precio,det.precio*det.cantidad as subtotal, det.descuentoimp ")
                    End If
                    sConsulta.AppendLine("+isnull((select sum(desimporte) from tpddes des where des.transprodid = det.transprodid and des.transproddetalleid=det.transproddetalleid ),0)  ")
                    sConsulta.AppendLine("+isnull((select sum(desv.desimporte) from tpddesvendedor desv where desv.transprodid=det.transprodid and desv.transproddetalleid=det.transproddetalleid),0) as descuentoimp, ")
                    sConsulta.AppendLine("0 as total, 0 as descuentovendedor, 0 as subtotalFac, 0 as impuesto, ")
                sConsulta.AppendLine("fac.total as totalFac,'(' + dbo.fn_numeroletraMON(fac.total,fac.MonedaId) + ')' as TotalLetra, fac.Notas as OrdenCompra, '' as ProductoNota  ")
                    sConsulta.AppendLine("from transprod fac  ")
                    sConsulta.AppendLine("inner join transprod Ven on fac.transprodid=ven.facturaid  ")
                    sConsulta.AppendLine("inner join transproddetalle det on ven.transprodid=det.transprodid  ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on det.TransProdID = IMP.TransProdId and det.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join producto pro on pro.productoclave=det.productoclave  ")
                    sConsulta.AppendLine("inner join vavdescripcion v on  v.varcodigo ='FVENTA' and v.vavclave=ven.CFVTipo  ")
                    sConsulta.AppendLine("inner join vavdescripcion v2 on  v2.varcodigo ='UnidadV' and v2.vavclave=det.tipounidad  ")
                    sConsulta.AppendLine("where fac.transprodid= '" & parsTransProdId & "' and v.vadtipolenguaje='" + lbGeneral.cParametros.Lenguaje + "' and v.vadtipolenguaje =v2.vadtipolenguaje ")
                    'sConsulta.AppendLine(")as t ")
                Else
                    'Nota de crédito
                    sConsulta.AppendLine("declare @ImpNoDesglosa as decimal ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("set @ImpNoDesglosa = (select SUM(ImpuestoIMP) from #ImpNoDes) ")
                    Else
                        sConsulta.AppendLine("set @ImpNoDesglosa = 0 ")
                    End If

                    sConsulta.AppendLine("select TRP.Folio, (select Folio from transprod where transprodid = TRP.FacturaID) as FolioFactura, ")
                    sConsulta.AppendLine("convert(varchar(10), TRP.FechaFacturacion, 103) + ' ' + convert(varchar(10), TRP.FechaFacturacion, 108) as FechaFacturacion, '' as FormaPago, ")
                    sConsulta.AppendLine("TPD.ProductoClave, PRO.CodigoBarras, PRO.Nombre, VAD.Descripcion as Unidad, TPD.Cantidad, ")
                    If bImpuestoGlb Then
                    sConsulta.AppendLine("(TPD.Precio  + isnull(IMP.ImpuestoPU, 0)) as Precio, TPD.Cantidad * (TPD.Precio + isnull(IMP.ImpuestoPU, 0)) as Subtotal, TPD.DescuentoImp + (Cantidad * isnull(IMP.ImpuestoPU, 0) - isnull(IMP.ImpDesGlb, 0)) as DescuentoImp, TPD.Cantidad * (TPD.Precio + isnull(IMP.ImpuestoPU, 0)) as Total, ")
                    Else
                        sConsulta.AppendLine("TPD.Precio, TPD.Cantidad * TPD.Precio as Subtotal, TPD.DescuentoImp, TPD.Subtotal as Total, ")
                    End If
                    sConsulta.AppendLine("0 as DescuentoVendedor, TRP.Subtotal + @ImpNoDesglosa as SubtotalFAC, TRP.Impuesto, TRP.Total as TotalFac, '(' + dbo.fn_numeroletra(TRP.Total) + ')' as TotalLetra, ")
                    'sConsulta.AppendLine("0 as DescuentoVendedor, TRP.Subtotal as SubtotalFAC, TRP.Impuesto, TRP.Total as TotalFac, '(' + dbo.fn_numeroletra(TRP.Total) + ')' as TotalLetra, ")
                    sConsulta.AppendLine("TRP.Notas as OrdenCompra, pro.Nota as ProductoNota ")
                    sConsulta.AppendLine("from TransProd TRP ")
                    sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
                    If bImpuestoGlb Then
                        sConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleID ")
                    End If
                    sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
                    sConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = '" + lbGeneral.cParametros.Lenguaje + "' ")
                    sConsulta.AppendLine("where TRP.TransProdID = '" & parsTransProdId & "' ")
                End If
            End If

            If bImpuestoGlb Then
                sConsulta.AppendLine("drop table #ImpNoDes ")
            End If

            Dim dtDetalle As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
            oReporte.Database.Tables(0).SetDataSource(dtDetalle)

        Dim dtTRPPedimento As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta("Select distinct TRPP.ProductoClave, TRPP.NumPedimento, TRPP.Aduana, TRPP.FechaIngreso as FechaEntrada from TRPPedimento TRPP inner join TransProd TRP on TRPP.TransProdID = TRP.TransProdId where TRP.Tipo = 1 and TRPP.Facturado = 1 and TRP.FacturaID='" & parsTransProdId & "'")
        oReporte.Subreports("TRPPedimento").SetDataSource(dtTRPPedimento)

            'If nFormatoFact = 5 Or nFormatoFact = 6 Then
            Dim dtRegimen As DataTable
        If sVersionCFD = "2.2" Then
            sConsulta = New System.Text.StringBuilder
            sConsulta.AppendLine("select Descripcion as Regimen ")
            sConsulta.AppendLine("from TRPRegimenFiscal ")
            sConsulta.AppendLine("where TransProdID = '" & parsTransProdId & "' ")
            dtRegimen = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
        Else
            dtRegimen = LbConexion.cConexion.Instancia.EjecutarConsulta("select top 0 '' as Regimen")
        End If

            oReporte.Subreports("RegimenFiscal").Database.Tables("RegimenFiscal").SetDataSource(dtRegimen)
            'End If

            'Dim s As String = String.Empty
            'Dim y As Integer = 0
            'For Each p As CrystalDecisions.Shared.ParameterField In oReporte.ParameterFields
            '    If Not p.HasCurrentValue AndAlso Not p.Name.StartsWith("Pm") Then
            '        'If Not p.HasCurrentValue Then
            '        y += 1
            '        s &= p.Name & vbLf
            '    End If
            'Next
            'If y > 0 Then
            '    MsgBox(y)
            '    MsgBox(s)
            'End If

            If 1 = LbConexion.cConexion.Instancia.EjecutarComandoScalar("select case when tipomotivo in(10,11) then 0 else 1 end as valida from transprod where transprodid='" & parsTransProdId & "'") Then
                If nFormatoFact = 5 Or nFormatoFact = 6 Then
                    oReporte.SetParameterValue("XLeyendaFiscal", oMensaje.RecuperarDescripcion("XLeyendaFiscalCFDI"))
                Else
                    oReporte.SetParameterValue("XLeyendaFiscal", oMensaje.RecuperarDescripcion("XLeyendaFiscal"))
                End If
            Else
                If nFormatoFact = 5 Or nFormatoFact = 6 Then
                    oReporte.SetParameterValue("XLeyendaFiscal", oMensaje.RecuperarDescripcion("XLeyendaNOFiscalCFDI"))
                Else
                    oReporte.SetParameterValue("XLeyendaFiscal", oMensaje.RecuperarDescripcion("XLeyendaNOFiscal"))
                End If
            End If

            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XNombre", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("XRFC", oMensaje.RecuperarDescripcion("CLDRFC"))
            oReporte.SetParameterValue("XProducto", oMensaje.RecuperarDescripcion("XProducto"))
            'oReporte.SetParameterValue("XNombreCorto", oMensaje.RecuperarDescripcion("CLINombreCorto"))
            oReporte.SetParameterValue("XNombreCorto", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("XUnidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            'oReporte.SetParameterValue("XUnitario", oMensaje.RecuperarDescripcion("XPrecioUnitario"))
            oReporte.SetParameterValue("XUnitario", oMensaje.RecuperarDescripcion("XPUnitario"))
        oReporte.SetParameterValue("XSubtotal", oMensaje.RecuperarDescripcion("XSubtotal"))
        oReporte.SetParameterValue("XPedimento", oMensaje.RecuperarDescripcion("XPedimento") + ":") 'oMensaje.RecuperarDescripcion("XPedimento"))
            If nFormatoFact = 7 Then
                oReporte.SetParameterValue("XDescuento", oMensaje.RecuperarDescripcion("XDescuento"))
            Else
                oReporte.SetParameterValue("XDescuento", oMensaje.RecuperarDescripcion("XDesc"))
            End If
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))

        oReporte.SetParameterValue("XMetodoPago", oMensaje.RecuperarDescripcion("TDFMetodoPago"))

        'Configuracion Metodo Pago  
        If sVersionCFD = "2.2" Then
            sConsulta = New System.Text.StringBuilder
            sConsulta.AppendLine("select dbo.FNObtieneCadenaConfNumCta('" & parsTransProdId & "')")
            Dim ConfNumCta As String = LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta.ToString())
            oReporte.SetParameterValue("ConfMetodoPago", ConfNumCta)
        Else
            oReporte.SetParameterValue("ConfMetodoPago", "")
        End If

        If nFormatoFact = 6 Or nFormatoFact = 3 Or nFormatoFact = 4 Then
            oReporte.SetParameterValue("XRegimenFiscal", oMensaje.RecuperarDescripcion("XRegimen"))
        Else
            oReporte.SetParameterValue("XRegimenFiscal", oMensaje.RecuperarDescripcion("XRegimenFiscal"))
        End If

            If tipoMov = 8 Then
                oReporte.SetParameterValue("XVieneDe", oMensaje.RecuperarDescripcion("XVieneDe", New String() {oMensaje.RecuperarDescripcion("XFactura")}))
            Else
                oReporte.SetParameterValue("XVieneDe", oMensaje.RecuperarDescripcion("XVieneDe", New String() {oMensaje.RecuperarDescripcion("XNotaCredito")}))
            End If

            If nFormatoFact = 5 Or nFormatoFact = 6 Then
                oReporte.SetParameterValue("XCadenaOriginalTFD", oMensaje.RecuperarDescripcion("XCadenaOriginalTFD"))
                oReporte.SetParameterValue("XSelloDigitalCFDI", oMensaje.RecuperarDescripcion("XSelloDigitalCFDI"))
                oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
                oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                oReporte.SetParameterValue("XEstado", oMensaje.RecuperarDescripcion("XEstado"))
                oReporte.SetParameterValue("XMunicipio", oMensaje.RecuperarDescripcion("XMunicipio"))
                oReporte.SetParameterValue("XCodigoPostal", oMensaje.RecuperarDescripcion("XCPostal"))
                oReporte.SetParameterValue("XCalle", oMensaje.RecuperarDescripcion("XCalle"))
                oReporte.SetParameterValue("XSelloSAT", oMensaje.RecuperarDescripcion("XSelloSAT"))
                oReporte.SetParameterValue("XFolioFiscal", oMensaje.RecuperarDescripcion("XFolioFiscal"))
                oReporte.SetParameterValue("XSerieCertificadoSAT", oMensaje.RecuperarDescripcion("XSerieCertificadoSAT"))
                oReporte.SetParameterValue("XFechaHoraCertificacion", oMensaje.RecuperarDescripcion("XFechaHoraCertificacion"))
                oReporte.SetParameterValue("XReceptor", oMensaje.RecuperarDescripcion("XReceptor"))
                oReporte.SetParameterValue("XLugarExpedicion", oMensaje.RecuperarDescripcion("XLugarExpedicion"))

            If tipoMov = 8 Then
                If nFormatoFact = 5 Then
                    Dim oTransprod As New ERMTRPLOG.cTransProd()
                    oTransprod.Recuperar(parsTransProdId)

                    oReporte.SetParameterValue("XTipoComprobante", oMensaje.RecuperarDescripcion("XFactura").ToUpper & " " & oTransprod.Folio & IIf(tipofase = 0, " " & oMensaje.RecuperarDescripcion("XCancelada").ToUpper, ""))
                Else
                    oReporte.SetParameterValue("XTipoComprobante", oMensaje.RecuperarDescripcion("XFactura").ToUpper & IIf(tipofase = 0, " " & oMensaje.RecuperarDescripcion("XCancelada").ToUpper, ""))
                End If

                oReporte.SetParameterValue("XOrdenCompra", oMensaje.RecuperarDescripcion("XOrdenCompra"))
            Else
                oReporte.SetParameterValue("XTipoComprobante", oMensaje.RecuperarDescripcion("XNotaCredito").ToUpper & IIf(tipofase = 0, " " & oMensaje.RecuperarDescripcion("XCancelada").ToUpper, ""))
                oReporte.SetParameterValue("XOrdenCompra", oMensaje.RecuperarDescripcion("XFolioFactura"))
            End If

                If Not IsDBNull(dtEncabezado.Rows(0)("FechaTimbrado")) Then
                    oReporte.SetParameterValue("FechaTimbrado", CDate(dtEncabezado.Rows(0)("FechaTimbrado")).ToString("dd/MM/yyyy HH:mm:ss"))
                Else
                    oReporte.SetParameterValue("FechaTimbrado", "")
                End If
                oReporte.SetParameterValue("FechaExpedicion", CDate(dtEncabezado.Rows(0)("FechaExpedicion")).ToString("dd/MM/yyyy HH:mm:ss"))

                If nFormatoFact = 6 Then
                    oReporte.SetParameterValue("XEfectosFiscales", oMensaje.RecuperarDescripcion("XEfectosFiscales"))
                    oReporte.SetParameterValue("XPagoExhibicion", oMensaje.RecuperarDescripcion("XPagoExhibicion"))
                    oReporte.SetParameterValue("XCodigoPostal", oMensaje.RecuperarDescripcion("XCPostal"))
                    oReporte.SetParameterValue("XVendidoA", oMensaje.RecuperarDescripcion("XVendidoA").ToUpper)
                    oReporte.SetParameterValue("XCodigoBarras", oMensaje.RecuperarDescripcion("PROCodigoBarras"))
                    oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("XCondicionesComerciales"))

                    oReporte.SetParameterValue("XTelefono", oMensaje.RecuperarDescripcion("CLITelefonoContacto"))
                    oReporte.SetParameterValue("XDomicilioFiscal", oMensaje.RecuperarDescripcion("XDomFiscal"))

                    oReporte.SetParameterValue("XFolioEntrega", oMensaje.RecuperarDescripcion("XFolioEntrega"))
                    oReporte.SetParameterValue("XFolioCliente", oMensaje.RecuperarDescripcion("XFolioCliente"))
                    oReporte.SetParameterValue("XFolioRemision", oMensaje.RecuperarDescripcion("XFolioRemision"))
                    oReporte.SetParameterValue("XFolioEntregaVA", oMensaje.RecuperarDescripcion("XFolioEntrega"))
                    oReporte.SetParameterValue("XFolioClienteVA", oMensaje.RecuperarDescripcion("XFolioCliente"))
                    oReporte.SetParameterValue("XFolioRemisionVA", oMensaje.RecuperarDescripcion("XFolioRemision"))
                    oReporte.SetParameterValue("XNoRuta", oMensaje.RecuperarDescripcion("XNoRuta"))
                    oReporte.SetParameterValue("XTotalProductos", oMensaje.RecuperarDescripcion("XTotalProductos"))
                    oReporte.SetParameterValue("XClaveCliente", oMensaje.RecuperarDescripcion("XClaveCliente"))

                    oReporte.SetParameterValue("FolioEntrega", sFolioEntrega)
                    oReporte.SetParameterValue("FolioCliente", sFolioCliente)
                    oReporte.SetParameterValue("FolioRemision", sFolioRemision)
                    oReporte.SetParameterValue("CantPedidos", nCantPedidos)

                    If tipoMov = 8 Then
                        oReporte.SetParameterValue("XFacturaNo", oMensaje.RecuperarDescripcion("XFacturaNo"))
                    Else
                        oReporte.SetParameterValue("XFacturaNo", oMensaje.RecuperarDescripcion("XNotaCreditoNo"))
                    End If

                End If

            Else

                oReporte.SetParameterValue("XCadenaOriginalT", dtEncabezado.Rows(0).Item("cadenaoriginal").ToString)
                If tipofase = 0 Then
                    oReporte.SetParameterValue("XCancelada", oMensaje.RecuperarDescripcion("XCancelada"))
                Else
                    oReporte.SetParameterValue("XCancelada", "")
                End If

                If tipoMov = 8 Then
                    oReporte.SetParameterValue("XFacturaNo", oMensaje.RecuperarDescripcion("XFacturaNo"))
                Else
                    oReporte.SetParameterValue("XFacturaNo", oMensaje.RecuperarDescripcion("XNotaCreditoNo"))
                End If

                oReporte.SetParameterValue("XNoCertificado", oMensaje.RecuperarDescripcion("XNoCertificado"))
                oReporte.SetParameterValue("XNoAprobacion", oMensaje.RecuperarDescripcion("XNoAprobacion"))
                oReporte.SetParameterValue("XAnioAprobacion", oMensaje.RecuperarDescripcion("XAnioAprobacion"))

                oReporte.SetParameterValue("XTelefono", oMensaje.RecuperarDescripcion("CLITelefonoContacto"))
                oReporte.SetParameterValue("XDomicilioFiscal", oMensaje.RecuperarDescripcion("XDomFiscal"))

                oReporte.SetParameterValue("FechaHoraAlta", dtEncabezado.Rows(0)("mFechaHora"))
                oReporte.SetParameterValue("XCadenaOriginal", oMensaje.RecuperarDescripcion("XCadenaOriginal"))
                oReporte.SetParameterValue("XSelloDigital", oMensaje.RecuperarDescripcion("XSelloDigital"))

                If tipoMov = 8 Then
                    If nFormatoFact = 1 Then
                        oReporte.SetParameterValue("XFolioFactura", "")
                        oReporte.SetParameterValue("XEfectosFiscales", oMensaje.RecuperarDescripcion("XEfectosFiscales"))
                        oReporte.SetParameterValue("XEfectosFiscales2", oMensaje.RecuperarDescripcion("XEfectosFiscales2"))
                        oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
                        oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                        oReporte.SetParameterValue("XEntidad", oMensaje.RecuperarDescripcion("XEntidad"))
                        oReporte.SetParameterValue("XLocalidad", oMensaje.RecuperarDescripcion("XLocalidad"))
                        oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                        oReporte.SetParameterValue("XExpedida", oMensaje.RecuperarDescripcion("XExpedida"))
                        oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("CLPTipoT"))
                    ElseIf nFormatoFact = 3 Then
                        oReporte.SetParameterValue("XEfectosFiscales", oMensaje.RecuperarDescripcion("XEfectosFiscales"))
                        oReporte.SetParameterValue("XPagoExhibicion", oMensaje.RecuperarDescripcion("XPagoExhibicion"))
                        oReporte.SetParameterValue("XCodigoPostal", oMensaje.RecuperarDescripcion("XCPostal"))
                        oReporte.SetParameterValue("XCalle", oMensaje.RecuperarDescripcion("XCalle"))
                        oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                        oReporte.SetParameterValue("XMunicipio", oMensaje.RecuperarDescripcion("XMunicipio"))
                        oReporte.SetParameterValue("XEstado", oMensaje.RecuperarDescripcion("XEstado"))
                        oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                        oReporte.SetParameterValue("XLugarExpedicion", oMensaje.RecuperarDescripcion("XLugarExpedicion"))
                        oReporte.SetParameterValue("XVendidoA", oMensaje.RecuperarDescripcion("XVendidoA").ToUpper)
                        oReporte.SetParameterValue("XCodigoBarras", oMensaje.RecuperarDescripcion("PROCodigoBarras"))
                        oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("XCondicionesComerciales"))
                    ElseIf nFormatoFact = 4 Then
                        oReporte.SetParameterValue("XEfectosFiscales", oMensaje.RecuperarDescripcion("XEfectosFiscales"))
                        oReporte.SetParameterValue("XPagoExhibicion", oMensaje.RecuperarDescripcion("XPagoExhibicion"))
                        oReporte.SetParameterValue("XCodigoPostal", oMensaje.RecuperarDescripcion("XCPostal"))
                        oReporte.SetParameterValue("XCalle", oMensaje.RecuperarDescripcion("XCalle"))
                        oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                        oReporte.SetParameterValue("XMunicipio", oMensaje.RecuperarDescripcion("XMunicipio"))
                        oReporte.SetParameterValue("XEstado", oMensaje.RecuperarDescripcion("XEstado"))
                        oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                        oReporte.SetParameterValue("XLugarExpedicion", oMensaje.RecuperarDescripcion("XLugarExpedicion"))
                        oReporte.SetParameterValue("XVendidoA", oMensaje.RecuperarDescripcion("XVendidoA").ToUpper)
                        oReporte.SetParameterValue("XCodigoBarras", oMensaje.RecuperarDescripcion("PROCodigoBarras"))
                        oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("XCondicionesComerciales"))

                        oReporte.SetParameterValue("XFolioEntrega", oMensaje.RecuperarDescripcion("XFolioEntrega"))
                        oReporte.SetParameterValue("XFolioCliente", oMensaje.RecuperarDescripcion("XFolioCliente"))
                        oReporte.SetParameterValue("XFolioRemision", oMensaje.RecuperarDescripcion("XFolioRemision"))
                        oReporte.SetParameterValue("XFolioEntregaVA", oMensaje.RecuperarDescripcion("XFolioEntrega"))
                        oReporte.SetParameterValue("XFolioClienteVA", oMensaje.RecuperarDescripcion("XFolioCliente"))
                        oReporte.SetParameterValue("XFolioRemisionVA", oMensaje.RecuperarDescripcion("XFolioRemision"))
                        oReporte.SetParameterValue("XNoRuta", oMensaje.RecuperarDescripcion("XNoRuta"))
                        oReporte.SetParameterValue("XTotalProductos", oMensaje.RecuperarDescripcion("XTotalProductos"))
                        oReporte.SetParameterValue("XClaveCliente", oMensaje.RecuperarDescripcion("XClaveCliente"))

                        oReporte.SetParameterValue("FolioEntrega", sFolioEntrega)
                        oReporte.SetParameterValue("FolioCliente", sFolioCliente)
                        oReporte.SetParameterValue("FolioRemision", sFolioRemision)
                        oReporte.SetParameterValue("CantPedidos", nCantPedidos)
                        oReporte.SetParameterValue("XSelloDigitalT", dtEncabezado.Rows(0).Item("SelloDigital").ToString)
                    ElseIf nFormatoFact = 7 Then
                        oReporte.SetParameterValue("FechaHoraAlta", Convert.ToDateTime(dtEncabezado.Rows(0)("mFechaHora")).ToString("s"))
                        oReporte.SetParameterValue("XFolioFactura", "")
                        oReporte.SetParameterValue("XFacturaNo", oMensaje.RecuperarDescripcion("XFolio").ToUpper())
                        oReporte.SetParameterValue("XNoCliente", oMensaje.RecuperarDescripcion("XNoCliente"))
                        oReporte.SetParameterValue("XFechaYHora", oMensaje.RecuperarDescripcion("XFechaYHora").ToUpper())
                        oReporte.SetParameterValue("XFacturaElectronica", oMensaje.RecuperarDescripcion("XFacturaElectronica").ToUpper())
                        oReporte.SetParameterValue("XEfectosFiscales", oMensaje.RecuperarDescripcion("XEfectosFiscales").ToUpper())
                        oReporte.SetParameterValue("XEfectosFiscales2", oMensaje.RecuperarDescripcion("XEfectosFiscales2").ToUpper())
                        oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia").ToUpper())
                        oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                        oReporte.SetParameterValue("XEntidad", oMensaje.RecuperarDescripcion("XEstado"))
                        oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                        oReporte.SetParameterValue("XExpedida", oMensaje.RecuperarDescripcion("XExpedida").ToUpper())
                        oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("CLPTipoT"))
                        oReporte.SetParameterValue("XCP", oMensaje.RecuperarDescripcion("XCP"))
                        oReporte.SetParameterValue("XCliente", oMensaje.RecuperarDescripcion("XCliente").ToUpper())
                        oReporte.SetParameterValue("XPagoen", oMensaje.RecuperarDescripcion("XPagoen"))
                        oReporte.SetParameterValue("XMunicipio", oMensaje.RecuperarDescripcion("XMunicipio"))
                        oReporte.SetParameterValue("XNoCertificado", DirectCast(oReporte.ParameterFields("XNoCertificado").CurrentValues(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value.ToString().ToUpper())
                        oReporte.SetParameterValue("XNoAprobacion", DirectCast(oReporte.ParameterFields("XNoAprobacion").CurrentValues(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value.ToString().ToUpper())
                        oReporte.SetParameterValue("XAnioAprobacion", DirectCast(oReporte.ParameterFields("XAnioAprobacion").CurrentValues(0), CrystalDecisions.Shared.ParameterDiscreteValue).Value.ToString().ToUpper())
                        oReporte.SetParameterValue("XDomicilioFiscal", oMensaje.RecuperarDescripcion("XDireccion"))
                    Else
                        oReporte.SetParameterValue("XFormaPago", oMensaje.RecuperarDescripcion("CLPTipoT"))
                    End If

                    oReporte.SetParameterValue("XOrdenCompra", oMensaje.RecuperarDescripcion("XOrdendecompra"))
                Else
                    oReporte.SetParameterValue("XFolioFactura", oMensaje.RecuperarDescripcion("XFolioFactura"))
                    oReporte.SetParameterValue("XOrdenCompra", "")
                    oReporte.SetParameterValue("XExpedida", oMensaje.RecuperarDescripcion("XExpedida"))
                    oReporte.SetParameterValue("XEfectosFiscales", "")
                    oReporte.SetParameterValue("XEfectosFiscales2", "")
                    oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
                    oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))
                    oReporte.SetParameterValue("XEntidad", oMensaje.RecuperarDescripcion("XEntidad"))
                    oReporte.SetParameterValue("XLocalidad", oMensaje.RecuperarDescripcion("XLocalidad"))
                    oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                End If

                If tipoMov = 8 And nFormatoFact = 2 Then
                    oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
                    oReporte.SetParameterValue("XCiudad", oMensaje.RecuperarDescripcion("XPARCiudad"))
                    oReporte.SetParameterValue("XEstado", oMensaje.RecuperarDescripcion("XEstado"))
                    oReporte.SetParameterValue("XPais", oMensaje.RecuperarDescripcion("XPais"))

                    oReporte.SetParameterValue("XAcepto", oMensaje.RecuperarDescripcion("XAcepto"))
                    oReporte.SetParameterValue("XPagare1", oMensaje.RecuperarDescripcion("XPagare1") & " " & oMensaje.RecuperarDescripcion("XPagare2"))
                    oReporte.SetParameterValue("XPagare3", oMensaje.RecuperarDescripcion("XPagare3"))
                    oReporte.SetParameterValue("XPagare4", oMensaje.RecuperarDescripcion("XPagare4"))
                    oReporte.SetParameterValue("XPagare5", oMensaje.RecuperarDescripcion("XPagare5") & " " & oMensaje.RecuperarDescripcion("XPagare6"))
                    oReporte.SetParameterValue("XPagare7", oMensaje.RecuperarDescripcion("XPagare7"))
                End If
            End If
            Return oReporte
    End Function
    Private Sub MostrarReporte(ByVal parsTransProdId As String)
        rvwReporte.ReportSource = CrearReporte(parsTransProdId)
    End Sub

    Private Function GenerarCodigoBarras(ByVal RFCEmisor As String, ByVal RFCReceptor As String, ByVal Total As Double, ByVal UUID As String) As Image
        'Dim qrCodeEncoder As QRCodeEncoder = New QRCodeEncoder()
        'qrCodeEncoder.QRCodeEncodeMode = qrCodeEncoder.ENCODE_MODE.BYTE
        'qrCodeEncoder.QRCodeScale = 3
        'qrCodeEncoder.QRCodeVersion = 11
        'qrCodeEncoder.QRCodeErrorCorrect = qrCodeEncoder.ERROR_CORRECTION.H

        'Dim sTotal As String() = Total.ToString("#########0.0######").Split(Char.Parse("."))
        'Dim sEntero As String = sTotal(0)
        'Dim sDecimal As String = sTotal(1)

        'sEntero = sEntero.PadLeft(10, Char.Parse("0"))
        'sDecimal = sDecimal.PadRight(6, Char.Parse("0"))

        'Dim sCodigoBarras As String
        'sCodigoBarras = "?re=" & RFCEmisor
        'sCodigoBarras &= "&rr=" & RFCReceptor
        'sCodigoBarras &= "&tt=" & sEntero & "." & sDecimal
        'sCodigoBarras &= "&id=" & UUID

        'Dim image As Image
        'image = qrCodeEncoder.Encode(sCodigoBarras, System.Text.Encoding.UTF8)
        'Return image
        Return Nothing
    End Function

    Private Function ConversionImagen(ByVal oImagen As Image) As Byte()
        Dim ms As MemoryStream = New MemoryStream()
        oImagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim imagen As Byte() = ms.GetBuffer()
        Return imagen
    End Function

End Class
