
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Data
Imports LibreriaInterfazSalidaFirebird

<WebService(Namespace:="http://tempuri.org/services/MobileClient")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ServiceMobileClient
    Inherits System.Web.Services.WebService

#Region " Estructura de base de datos movil "

    <WebMethod()> Public Function WSObtenerEstructura() As Data.DataSet
        Dim oEstructura As New MobileClient.EstructuraDB
        Return oEstructura.ObtenerEstructura()
    End Function
#End Region

#Region "Session"
    'Solo se utiliza para lanzar una exepción y poder obtener la uri Absoluta de la sesion
    '<WebMethod()> Public Function RegresarSession() As Boolean
    '    Return True
    'End Function

    '<WebMethod()> Public Function TerminarSession() As Boolean
    '    Return True
    'End Function
#End Region

#Region " Aplicacion "

    <WebMethod()> Public Function WSAplicacionObtenerActualizacion(ByVal parsXMLUltActualizacion As String, ByVal parsCondicionTablas As String) As DataSet
        Dim oAplicacion As New MobileClient.Aplicacion
        Dim ds As DataSet = oAplicacion.ObtenerActualizacion(parsXMLUltActualizacion, parsCondicionTablas)
        Return ds
    End Function

    <WebMethod()> Public Function WSAplicacionPedirActualizacionHTTP(ByVal parsTerminalNumeroSerie As String, ByVal parsXMLUltActualizacion As String, ByVal parsCondicionTablas As String) As String
        'Dim oVendedor As New MobileClient.Vendedor
        'Dim oUsuario As New MobileClient.Usuario
        'oUsuario.Recuperar(parsUsuarioClave)
        'oVendedor.RecuperarConUsuario(oUsuario.UsuarioId)
        'If oVendedor.TerminalClave = "" Then
        '    Throw New System.Web.Services.Protocols.SoapException(MobileClient.Aplicacion.ObtenerMensaje("E0414"), New System.Xml.XmlQualifiedName("Valida", "ServiceCentral"))
        'End If

        'Dim sNombreTerminal As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select Descripcion from Terminal where TerminalClave='" & parsUsuarioClave & "'")
        'If sNombreTerminal = "" Then
        '    Throw New System.Web.Services.Protocols.SoapException(MobileClient.Aplicacion.ObtenerMensaje("E0414"), New System.Xml.XmlQualifiedName("Valida", "ServiceCentral"))
        'End If
        Dim sNombreTarea As String = String.Empty
        Try
            Dim dt As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select '" & parsTerminalNumeroSerie & "' as NumeroSerieTerminal ,'' as Clave, '' as Nombre,'" & parsXMLUltActualizacion & "' as XMLUltActualizacion,'" & parsCondicionTablas & "' as CondicionTablas, '' as Error ", "Tarea")
            sNombreTarea = "TPAR" & parsTerminalNumeroSerie & "-" & Now.ToString("yyyyMMddhhmmss") & ".xml"
            dt.WriteXml(ServicesCentral.Configuracion.Directorio & "\" & sNombreTarea)
        Catch ex As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("Valida", "ServiceCentral"))
        End Try

        Try
            Dim pvSC As New System.ServiceProcess.ServiceController("RouteDBService")
            pvSC.ExecuteCommand(190)
        Catch ex As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("ServicioWindows", "ServiceCentral"))
        End Try

        Return sNombreTarea

        'Dim oAplicacion As New MobileClient.Aplicacion
        'Dim ds As DataSet = oAplicacion.ObtenerActualizacion(parsXMLUltActualizacion, parsCondicionTablas)
        'Return ds
    End Function

    <WebMethod()> Public Function WSAplicacionObtenerBD(ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String, ByVal parsCondicionTablas As String, ByRef refparsMensaje As String) As Byte()
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        oUsuario.Recuperar(parsUsuarioClave)
        oVendedor.RecuperarConUsuario(oUsuario.UsuarioId)
        If oVendedor.TerminalClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0414")
            Return Nothing
        End If

        If oVendedor.MCNClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0702")
            Return Nothing
        End If

        Dim sNumeroSerie As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select isnull(NumeroSerie,'') from Terminal where TerminalClave='" & oVendedor.TerminalClave & "'")
        If sNumeroSerie = "" Then
            oVendedor.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf sNumeroSerie <> parsTerminalNumeroSerie Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0415")
            Return Nothing
        End If

        Dim oAplicacion As New MobileClient.Aplicacion
        Dim sNombreArchivo As String = String.Empty
        sNombreArchivo = oAplicacion.CrearBD(parsTerminalNumeroSerie)
        General.ComprimirArchivo(sNombreArchivo)
        Return General.LoadBinaryDataBY(sNombreArchivo.Replace(".sdf", ".zip"))
    End Function

    <WebMethod()> Public Function WSAplicacionObtenerBDHTTP(ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String, ByVal parsCondicionTablas As String, ByRef refparsMensaje As String) As String
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        oUsuario.Recuperar(parsUsuarioClave)
        oVendedor.RecuperarConUsuario(oUsuario.UsuarioId)
        If oVendedor.TerminalClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0414")
            Return String.Empty
        End If

        If oVendedor.MCNClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0702")
            Return String.Empty
        End If

        Dim dtTerminal As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select isnull(NumeroSerie,'') as NumeroSerie, Descripcion from Terminal where TerminalClave='" & oVendedor.TerminalClave & "'")
        Dim sNumeroSerie As String = dtTerminal.Rows(0)("NumeroSerie")
        Dim sNombreTerminal As String = dtTerminal.Rows(0)("Descripcion")
        dtTerminal.Dispose()
        If sNumeroSerie = "" Then
            oVendedor.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf sNumeroSerie <> parsTerminalNumeroSerie Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0415")
            Return String.Empty
        End If

        Dim sNombreTarea As String = String.Empty
        Try
            Dim dt As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select '" & parsTerminalNumeroSerie & "' as NumeroSerieTerminal ,'" & oVendedor.TerminalClave & "' as Clave, '" & sNombreTerminal & "' as Nombre,'' as Error ", "Tarea")
            sNombreTarea = "TENT" & parsTerminalNumeroSerie & "-" & Now.ToString("yyyyMMddhhmmss") & ".xml"
            dt.WriteXml(ServicesCentral.Configuracion.Directorio & "\" & sNombreTarea)

        Catch ex As Exception
            refparsMensaje = ex.Message
            Return sNombreTarea
        End Try

        Try
            Dim pvSC As New System.ServiceProcess.ServiceController("RouteDBService")
            pvSC.ExecuteCommand(190)
        Catch ex As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("ServicioWindows", "ServiceCentral"))
        End Try

        Return sNombreTarea
    End Function

    <WebMethod()> Public Function WSAplicacionObtenerBDPrueba(ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String, ByVal parsCondicionTablas As String) As Byte()
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        oUsuario.Recuperar(parsUsuarioClave)
        oVendedor.RecuperarConUsuario(oUsuario.UsuarioId)
        If oVendedor.TerminalClave = "" Then
            Return Nothing
        End If
        If oVendedor.MCNClave = "" Then
            Return Nothing
        End If

        Dim sNumeroSerie As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select isnull(NumeroSerie,'') from Terminal where TerminalClave='" & oVendedor.TerminalClave & "'")
        If sNumeroSerie = "" Then
            oVendedor.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf sNumeroSerie <> parsTerminalNumeroSerie Then
            Return Nothing
        End If

        Dim oAplicacion As New MobileClient.Aplicacion
        Dim sNombreArchivo As String = String.Empty
        sNombreArchivo = oAplicacion.CrearBD(parsTerminalNumeroSerie)
        General.ComprimirArchivo(sNombreArchivo)
        Return General.LoadBinaryDataBY(sNombreArchivo.Replace(".sdf", ".zip"))
    End Function
#End Region

#Region " Usuario "

    <WebMethod()> Public Function WSUsuarioRecuperar(ByVal parsUsuarioId As String) As MobileClient.Usuario
        Dim oUsuario As New MobileClient.Usuario(parsUsuarioId)
        If oUsuario.Recuperar() Then
            Return oUsuario
        End If
        Return Nothing
    End Function

#End Region

#Region " Vendedor "

    <WebMethod()> Public Function WSVendedorObtenerDatos(ByVal parsTerminalNumeroSerie As String, ByVal pariGrupo As Integer, ByVal parsUsuarioClave As String, ByVal pardFechaIni As Date, ByVal pardFechaFin As Date, ByVal parsCondicionTablas As String, ByVal parsTiposConsulta As String) As DataSet
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        Dim bGeneroAgenda As Boolean
        oUsuario.Recuperar(parsUsuarioClave)
        oVendedor.RecuperarConUsuario(oUsuario.UsuarioId)
        '<2005>
        Return oVendedor.ObtenerAgenda(parsTerminalNumeroSerie, pariGrupo, oVendedor.VendedorId, pardFechaIni, pardFechaFin, parsCondicionTablas, parsTiposConsulta, bGeneroAgenda)
        '<\2005>
    End Function

    <WebMethod()> Public Function WSVendedorObtenerRecargas(ByVal parsXMLUltActualizacion As String, ByVal parsUsuarioID As String, ByVal parsCondicionTablas As String) As DataSet
        Dim oVendedor As New MobileClient.Vendedor
        oVendedor.RecuperarConUsuario(parsUsuarioID)
        Dim ds As DataSet = oVendedor.ObtenerRecargas(parsXMLUltActualizacion, oVendedor.VendedorId, parsCondicionTablas)
        Return ds
    End Function
    <WebMethod()> Public Function WSVerificarVendedorObtenerBD(ByRef Mensaje As String) As String
        Dim vcError = ""
        Dim Tabla As DataTable = MobileClient.ConexionSQL.RealizarConsulta("select SubEmpresaID,NombreEmpresa from SubEmpresa where tipoestado=1 ", "SubEmpresa")
        Dim sSubEmpresas As String = ""

        For Each fila As DataRow In Tabla.Rows
            Dim SemHist As DataRow = MobileClient.ConexionSQL.RealizarConsulta("select Top 1 * from SemHist where SubEmpresaID='" + fila("SubEmpresaID") + "' order by SemHistFechaInicio desc").Rows(0)
            If SemHist("ComprobanteDig") = True Then
                If IsDBNull(SemHist("ArchivoPEM")) Then
                    sSubEmpresas += fila("NombreEmpresa") + ","
                End If
            End If
        Next

        If sSubEmpresas <> "" Then
            sSubEmpresas = sSubEmpresas.Substring(0, sSubEmpresas.Length - 1)
            vcError = "P0202"
            Mensaje = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select descripcion  from mendetalle where menclave ='P0202' and medtipolenguaje =(SELECT TOP 1 TIPOLENGUAJE FROM CONHIST ORDER BY CONHISTFECHAINICIO DESC )").ToString().Replace("$0$", sSubEmpresas)
            Mensaje += " " + MobileClient.ConexionSQL.EjecutarConsultaObjeto("select descripcion  from mendetalle where menclave ='P0203' and medtipolenguaje =(SELECT TOP 1 TIPOLENGUAJE FROM CONHIST ORDER BY CONHISTFECHAINICIO DESC )")
        End If

        Return vcError
    End Function
    <WebMethod()> Public Function WSVendedorObtenerBD(ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String, ByVal parsContrasena As String, ByVal pardFechaIni As Date, ByVal pardFechaFin As Date, ByVal parsTiposConsulta As String, ByRef refparsMensaje As String) As Byte()
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        Dim sTINDMMDConFolio As String = String.Empty
        Dim blnCanjes As Boolean = False
        'If Not Session("GenerandoBD") Then
        '    Session("GenerandoBD") = True
        'Else
        '    refparsMensaje = "Servidor ocupado, intente mas tarde"
        '    Return Nothing
        'End If
        If Not oUsuario.Recuperar(parsUsuarioClave) Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0425")
            'Session("GenerandoBD") = False
            Return Nothing
        End If

        parsContrasena = oUsuario.SimpleCrypt(parsContrasena)

        'If oUsuario.ClaveAcceso <> parsContrasena Then
        '    refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0210")
        '    Return Nothing
        'End If

        If Not oVendedor.RecuperarConUsuario(oUsuario.UsuarioId) Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0211").Replace("$0$", oUsuario.Nombre)
            'Session("GenerandoBD") = False
            Return Nothing
        End If

        If oVendedor.TerminalClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0414")
            'Session("GenerandoBD") = False
            Return Nothing
        End If
        If oVendedor.MCNClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0702")
            Return Nothing
        End If


        Dim sNumeroSerie As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select isnull(NumeroSerie,'') from Terminal where TerminalClave='" & oVendedor.TerminalClave & "'")
        If sNumeroSerie = "" Then
            oVendedor.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf sNumeroSerie <> parsTerminalNumeroSerie Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0415")
            'Session("GenerandoBD") = False
            Return Nothing
        End If

        Dim iEsquemas As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("SELECT Count(*) FROM VendedorEsquema WHERE VendedorID='" & oVendedor.VendedorId & "'")

        If iEsquemas <= 0 Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0512")
            'Session("GenerandoBD") = False
            Return Nothing
        End If

        Dim iCentrosDist As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("SELECT Count(*) FROM VENCentroDistHist WHERE VendedorID='" & oVendedor.VendedorId & "'")

        If iCentrosDist <= 0 Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0513")
            'Session("GenerandoBD") = False
            Return Nothing
        End If

        sTINDMMDConFolio = "2, 6, 8, 9, 10, 11, 13, 14, 15, 17, 18, 21, 22, 23, 24, 26"
        'Para pedir el folio de la carga por canje 
        If parsTiposConsulta.Contains("1") Then
            sTINDMMDConFolio &= ", 16"
        End If
        'Exigir el folio de facturación dependiendo del parametro CapturaFolioFac
        If oVendedor.CapturaFolioFac = False Then
            sTINDMMDConFolio &= ", 5"
        End If

        Dim dtModulos As DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT MMD.ModuloMovDetalleClave, MMD.Nombre FROM MOTConfiguracion MOT INNER JOIN MmdMcn MM ON MOT.MCNClave = MM.MCNClave INNER JOIN ModuloMovDetalle MMD ON MM.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave INNER JOIN ModuloMov MOD ON MMD.ModuloClave = MOD.ModuloClave AND MMD.ModuloMovClave = MOD.ModuloMovClave INNER JOIN ModuloTerm MT ON MOT.ModuloClave = MT.ModuloClave AND MOD.ModuloClave = MT.ModuloClave WHERE MOT.MCNClave = '" & oVendedor.MCNClave & "' and MT.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and MT.TipoEstado = 1 and MT.baja = 0 and MOD.TipoEstado = 1 AND MOD.Baja = 0 AND MMD.TipoEstado = 1 and (MMD.Baja=0) and MMD.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")
        Dim iCantFolios As Integer = 0
        For Each dr As DataRow In dtModulos.Rows
            iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select isnull(sum(Fin - Inicio -Usados),0) from FolioReservacion inner join folio on folio.FolioID=folioreservacion.FolioID where vendedorID='" & oVendedor.VendedorId & "' and ModuloMovDetalleClave = '" & dr("ModuloMovDetalleClave") & "' and folioreservacion.TipoEstado=1 and Folio.TipoEstado=1")
            If iCantFolios <= 0 Then
                refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0069").Replace("$0$", dr("Nombre")) & vbCrLf
            End If
        Next

        dtModulos = MobileClient.ConexionSQL.RealizarConsulta("Select * from ModuloMovDetalle MMD inner join ModuloMov MM on MMD.ModuloMovClave = MM.ModuloMovClave inner join ModuloTerm MT on MT.ModuloClave = MM.ModuloClave WHERE MT.tipo=2 and MT.TipoIndice =1 and MT.TipoEstado = 1 and MT.baja = 0 and MM.TipoEstado = 1 and MM.baja = 0 and MMD.TipoEstado = 1 and MMD.baja = 0  and MMD.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle2")
        iCantFolios = 0
        For Each dr As DataRow In dtModulos.Rows
            iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select isnull(sum(Fin - Inicio -Usados),0) from FolioReservacion inner join folio on folio.FolioID=folioreservacion.FolioID where vendedorID='" & oVendedor.VendedorId & "' and ModuloMovDetalleClave = '" & dr("ModuloMovDetalleClave") & "' and folioreservacion.TipoEstado=1 and Folio.TipoEstado=1")
            If iCantFolios <= 0 Then
                refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0069").Replace("$0$", dr("Nombre")) & vbCrLf
            End If
        Next

        Dim dtSubEmpresas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("select TOP 1 SubEmpresaID, NombreEmpresa from SubEmpresa where tipoestado=1 ", "SubEmpresa")
        Dim sActividades As String = ""

        For Each drSubEmpresa As DataRow In dtSubEmpresas.Rows
            Dim bComprobanteDig As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 ComprobanteDig from SEMHist where SubEmpresaID='" + drSubEmpresa("SubEmpresaID") + "' order by SemHistFechaInicio desc")
            If bComprobanteDig Then
                'sTINDMMDConFolio = "25"
                ''dtModulos = MobileClient.ConexionSQL.RealizarConsulta("Select ModuloMovDetalleClave, ModuloMovDetalle.Nombre from ModuloMovDetalle inner join ModuloMov on ModuloMovDetalle.ModuloMovClave = ModuloMov.ModuloMovClave inner join ModuloTerm on ModuloTerm.ModuloClave = ModuloMov.ModuloClave WHERE ModuloTerm.moduloClave= '" & oVendedor.ClaveModulo2 & "' and ModuloTerm.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and ModuloTerm.TipoEstado = 1 and ModuloTerm.baja = 0 and ModuloMov.TipoEstado = 1 and ModuloMov.baja = 0 and ModuloMovDetalle.TipoEstado = 1 and ModuloMovDetalle.baja = 0 and ModuloMovDetalle.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")
                'dtModulos = MobileClient.ConexionSQL.RealizarConsulta("SELECT MMD.ModuloMovDetalleClave, MMD.Nombre FROM MOTConfiguracion MOT INNER JOIN MmdMcn MM ON MOT.MCNClave = MM.MCNClave INNER JOIN ModuloMovDetalle MMD ON MM.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave INNER JOIN ModuloMov MOD ON MMD.ModuloClave = MOD.ModuloClave AND MMD.ModuloMovClave = MOD.ModuloMovClave INNER JOIN ModuloTerm MT ON MOT.ModuloClave = MT.ModuloClave AND MOD.ModuloClave = MT.ModuloClave WHERE MOT.MCNClave = '" & oVendedor.MCNClave & "' and MT.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and MT.TipoEstado = 1 and MT.baja = 0 and MOD.TipoEstado = 1 AND MOD.Baja = 0 AND MMD.TipoEstado = 1 and (MMD.Baja=0) and MMD.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")

                Dim sConsulta As String = ""
                'For Each dr As DataRow In dtModulos.Rows
                sConsulta = "declare @FoliosTerminal bit "
                sConsulta &= "set @Foliosterminal = (select top 1 FoliosTerminal from SEMHist where SubEmpresaID = '" & drSubEmpresa("SubEmpresaID") & "' order by SEMHistFechaInicio desc) "
                sConsulta &= "Select isnull(sum(FOS.CantSolicitada - FOS.Usados), 0) "
                sConsulta &= "from Folio FOL "
                sConsulta &= "inner join FolioSolicitado FOS on FOL.FolioId = FOS.FolioId and FOS.CantSolicitada > FOS.Usados "
                sConsulta &= "inner join FOSHist FSH on FSH.FolioId = FOS.FolioId and FSH.FOSId = FOS.FOSId and FSHFechaInicio = "
                sConsulta &= "(select top 1 FSH1.FSHFechaInicio from FOSHist FSH1 "
                sConsulta &= "where FSH.FolioId = FSH1.FolioId and FSH.FOSId = FSH1.FOSId "
                sConsulta &= "and ((FSH.VendedorId = '" & oVendedor.VendedorId & "' and @FoliosTerminal = 0) or (FSH.TerminalClave = '" & oVendedor.TerminalClave & "' and @FoliosTerminal = 1)) "
                sConsulta &= "order by FSHFechaInicio desc) "
                sConsulta &= "inner join centroexpedicion CEN on CEN.CentroExpID=FSH.CentroExpID and FSH.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 "
                sConsulta &= "where FOL.TipoEstado = 1 and FOL.Fiscal = 1 and FOL.SubEmpresaID='" & drSubEmpresa("SubEmpresaID") & "' and FOS.TipoComprobante = 1 "

                iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto(sConsulta)
                If iCantFolios <= 0 Then
                    sActividades &= "Facturas,"
                End If

                sConsulta = "declare @FoliosTerminal bit "
                sConsulta &= "set @Foliosterminal = (select top 1 FoliosTerminal from SEMHist where SubEmpresaID = '" & drSubEmpresa("SubEmpresaID") & "' order by SEMHistFechaInicio desc) "
                sConsulta &= "Select isnull(sum(FOS.CantSolicitada - FOS.Usados), 0) "
                sConsulta &= "from Folio FOL "
                sConsulta &= "inner join FolioSolicitado FOS on FOL.FolioId = FOS.FolioId and FOS.CantSolicitada > FOS.Usados "
                sConsulta &= "inner join FOSHist FSH on FSH.FolioId = FOS.FolioId and FSH.FOSId = FOS.FOSId and FSHFechaInicio = "
                sConsulta &= "(select top 1 FSH1.FSHFechaInicio from FOSHist FSH1 "
                sConsulta &= "where FSH.FolioId = FSH1.FolioId and FSH.FOSId = FSH1.FOSId "
                sConsulta &= "and ((FSH.VendedorId = '" & oVendedor.VendedorId & "' and @FoliosTerminal = 0) or (FSH.TerminalClave = '" & oVendedor.TerminalClave & "' and @FoliosTerminal = 1)) "
                sConsulta &= "order by FSHFechaInicio desc) "
                sConsulta &= "inner join centroexpedicion CEN on CEN.CentroExpID=FSH.CentroExpID and FSH.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 "
                sConsulta &= "where FOL.TipoEstado = 1 and FOL.Fiscal = 1 and FOL.SubEmpresaID='" & drSubEmpresa("SubEmpresaID") & "' and FOS.TipoComprobante = 2 "

                iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto(sConsulta)
                If iCantFolios <= 0 Then
                    sActividades &= "Notas de crédito,"
                End If
                'Next
            End If
        Next
        If sActividades <> "" Then
            sActividades = sActividades.Substring(0, sActividades.Length - 1)
            refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0251").Replace("$0$", sActividades) & vbCrLf
        End If

        'Validacion del Esquema 
        Dim dtEsquemasNvo As DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT EsquemaId FROM Esquema WHERE Clave='NVO001'", "EsquemaNuevo")
        If dtEsquemasNvo.Rows.Count <= 0 Then
            refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("E0473") & vbCrLf
        End If

        If refparsMensaje <> "" Then
            'Session("GenerandoBD") = False
            Return Nothing
        End If
        If oVendedor.RecuperarTipoIndice = DBCentral.TiposModulos.Distribucion Then
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.Reparto
        End If
        Dim blnCobrarVentas As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 CobrarVentas from conhist order by CONHistFechaInicio desc")

        If blnCobrarVentas Then 'Subir Pedidos con Saldo
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.PedidosConSaldo
        Else 'Subir facturas
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.Facturas
        End If


        Dim blnInventario As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 Inventario from conhist order by CONHistFechaInicio desc")
        If blnInventario Then 'Inventario a bordo
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.InventarioABordo
        End If


        Dim sNombreArchivo As String = String.Empty
        Dim bGeneroAgenda As Boolean
        'Session("GenerandoBD") = True
        sNombreArchivo = oVendedor.CrearBD(parsTerminalNumeroSerie, oVendedor.VendedorId, pardFechaIni, pardFechaFin, parsTiposConsulta, bGeneroAgenda)
        If sNombreArchivo <> String.Empty Then
            General.ComprimirArchivo(sNombreArchivo)
            'Session("GenerandoBD") = False
            Return General.LoadBinaryDataBY(sNombreArchivo.Replace(".sdf", ".zip"))
        Else
            If Not bGeneroAgenda Then
                refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("I0165") & vbCrLf
            End If
            Return Nothing
        End If
    End Function

    <WebMethod()> Public Function WSPedirVendedorBDHTTP(ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String, ByVal parsContrasena As String, ByVal pardFechaIni As Date, ByVal pardFechaFin As Date, ByVal parsTiposConsulta As String, ByRef refparsMensaje As String, ByRef parbGeneroBD As Boolean) As String
        Dim oVendedor As New MobileClient.Vendedor
        Dim oUsuario As New MobileClient.Usuario
        Dim sTINDMMDConFolio As String = String.Empty
        Dim blnCanjes As Boolean = False

        If Not oUsuario.Recuperar(parsUsuarioClave) Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0425")
            'Session("GenerandoBD") = False
            Return String.Empty
        End If

        parsContrasena = oUsuario.SimpleCrypt(parsContrasena)

        If Not oVendedor.RecuperarConUsuario(oUsuario.UsuarioId) Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0211").Replace("$0$", oUsuario.Nombre)
            'Session("GenerandoBD") = False
            Return String.Empty
        End If

        If oVendedor.TerminalClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0414")
            'Session("GenerandoBD") = False
            Return String.Empty
        End If
        If oVendedor.MCNClave = "" Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0702")
            Return String.Empty
        End If


        Dim sNumeroSerie As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select isnull(NumeroSerie,'') from Terminal where TerminalClave='" & oVendedor.TerminalClave & "'")
        If sNumeroSerie = "" Then
            oVendedor.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf sNumeroSerie <> parsTerminalNumeroSerie Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0415")
            'Session("GenerandoBD") = False
            Return String.Empty
        End If

        Dim iEsquemas As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("SELECT Count(*) FROM VendedorEsquema WHERE VendedorID='" & oVendedor.VendedorId & "'")

        If iEsquemas <= 0 Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0512")
            'Session("GenerandoBD") = False
            Return String.Empty
        End If

        Dim iCentrosDist As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("SELECT Count(*) FROM VENCentroDistHist WHERE VendedorID='" & oVendedor.VendedorId & "'")

        If iCentrosDist <= 0 Then
            refparsMensaje = MobileClient.Aplicacion.ObtenerMensaje("E0513")
            'Session("GenerandoBD") = False
            Return String.Empty
        End If

        sTINDMMDConFolio = "2, 6, 8, 9, 10, 11, 13, 14, 15, 17, 18, 21, 22, 23, 24, 26"
        'Para pedir el folio de la carga por canje 
        If parsTiposConsulta.Contains("1") Then
            sTINDMMDConFolio &= ", 16"
        End If
        'Exigir el folio de facturación dependiendo del parametro CapturaFolioFac
        If oVendedor.CapturaFolioFac = False Then
            sTINDMMDConFolio &= ", 5"
        End If
        'Dim dtModulos As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select ModuloMovDetalleClave, ModuloMovDetalle.Nombre from ModuloMovDetalle inner join ModuloMov on ModuloMovDetalle.ModuloMovClave = ModuloMov.ModuloMovClave inner join ModuloTerm on ModuloTerm.ModuloClave = ModuloMov.ModuloClave WHERE ModuloTerm.moduloClave= '" & oVendedor.ClaveModulo2 & "' and ModuloTerm.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and ModuloTerm.TipoEstado = 1 and ModuloTerm.baja = 0 and ModuloMov.TipoEstado = 1 and ModuloMov.baja = 0 and ModuloMovDetalle.TipoEstado = 1 and ModuloMovDetalle.baja = 0 and ModuloMovDetalle.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")
        Dim dtModulos As DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT MMD.ModuloMovDetalleClave, MMD.Nombre FROM MOTConfiguracion MOT INNER JOIN MmdMcn MM ON MOT.MCNClave = MM.MCNClave INNER JOIN ModuloMovDetalle MMD ON MM.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave INNER JOIN ModuloMov MOD ON MMD.ModuloClave = MOD.ModuloClave AND MMD.ModuloMovClave = MOD.ModuloMovClave INNER JOIN ModuloTerm MT ON MOT.ModuloClave = MT.ModuloClave AND MOD.ModuloClave = MT.ModuloClave WHERE MOT.MCNClave = '" & oVendedor.MCNClave & "' and MT.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and MT.TipoEstado = 1 and MT.baja = 0 and MOD.TipoEstado = 1 AND MOD.Baja = 0 AND MMD.TipoEstado = 1 and (MMD.Baja=0) and MMD.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")
        Dim iCantFolios As Integer = 0
        For Each dr As DataRow In dtModulos.Rows
            iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select isnull(sum(Fin - Inicio -Usados),0) from FolioReservacion inner join folio on folio.FolioID=folioreservacion.FolioID where vendedorID='" & oVendedor.VendedorId & "' and ModuloMovDetalleClave = '" & dr("ModuloMovDetalleClave") & "' and folioreservacion.TipoEstado=1 and Folio.TipoEstado=1")
            If iCantFolios <= 0 Then
                refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0069").Replace("$0$", dr("Nombre")) & vbCrLf
            End If
        Next

        Dim dtSubEmpresas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("select SubEmpresaID,NombreEmpresa from SubEmpresa where tipoestado=1 ", "SubEmpresa")
        Dim sSubEmpresas As String = ""

        For Each drSubEmpresa As DataRow In dtSubEmpresas.Rows
            Dim bComprobanteDig As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 ComprobanteDig from SEMHist where SubEmpresaID='" + drSubEmpresa("SubEmpresaID") + "' order by SemHistFechaInicio desc")
            If bComprobanteDig Then
                sTINDMMDConFolio = "25"
                'dtModulos = MobileClient.ConexionSQL.RealizarConsulta("Select ModuloMovDetalleClave, ModuloMovDetalle.Nombre from ModuloMovDetalle inner join ModuloMov on ModuloMovDetalle.ModuloMovClave = ModuloMov.ModuloMovClave inner join ModuloTerm on ModuloTerm.ModuloClave = ModuloMov.ModuloClave WHERE ModuloTerm.moduloClave= '" & oVendedor.ClaveModulo2 & "' and ModuloTerm.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and ModuloTerm.TipoEstado = 1 and ModuloTerm.baja = 0 and ModuloMov.TipoEstado = 1 and ModuloMov.baja = 0 and ModuloMovDetalle.TipoEstado = 1 and ModuloMovDetalle.baja = 0 and ModuloMovDetalle.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")
                dtModulos = MobileClient.ConexionSQL.RealizarConsulta("SELECT MMD.ModuloMovDetalleClave, MMD.Nombre FROM MOTConfiguracion MOT INNER JOIN MmdMcn MM ON MOT.MCNClave = MM.MCNClave INNER JOIN ModuloMovDetalle MMD ON MM.ModuloMovDetalleClave = MMD.ModuloMovDetalleClave INNER JOIN ModuloMov MOD ON MMD.ModuloClave = MOD.ModuloClave AND MMD.ModuloMovClave = MOD.ModuloMovClave INNER JOIN ModuloTerm MT ON MOT.ModuloClave = MT.ModuloClave AND MOD.ModuloClave = MT.ModuloClave WHERE MOT.MCNClave = '" & oVendedor.MCNClave & "' and MT.TipoIndice = " & oVendedor.RecuperarTipoIndice & " and MT.TipoEstado = 1 and MT.baja = 0 and MOD.TipoEstado = 1 AND MOD.Baja = 0 AND MMD.TipoEstado = 1 and (MMD.Baja=0) and MMD.TipoIndice in(" & sTINDMMDConFolio & ")", "ModuloMovDetalle")

                Dim sConsulta As String = ""
                For Each dr As DataRow In dtModulos.Rows
                    sConsulta = "declare @FoliosTerminal bit "
                    sConsulta &= "set @Foliosterminal = (select top 1 FoliosTerminal from SEMHist where SubEmpresaID = '" & drSubEmpresa("SubEmpresaID") & "' order by SEMHistFechaInicio desc) "
                    sConsulta &= "Select isnull(sum(FOS.CantSolicitada - FOS.Usados), 0) "
                    sConsulta &= "from Folio FOL "
                    sConsulta &= "inner join FolioSolicitado FOS on FOL.FolioId = FOS.FolioId and FOS.CantSolicitada > FOS.Usados "
                    sConsulta &= "inner join FOSHist FSH on FSH.FolioId = FOS.FolioId and FSH.FOSId = FOS.FOSId and FSHFechaInicio = "
                    sConsulta &= "(select top 1 FSH1.FSHFechaInicio from FOSHist FSH1 "
                    sConsulta &= "where FSH.FolioId = FSH1.FolioId and FSH.FOSId = FSH1.FOSId "
                    sConsulta &= "and ((FSH.VendedorId = '" & oVendedor.VendedorId & "' and @FoliosTerminal = 0) or (FSH.TerminalClave = '" & oVendedor.TerminalClave & "' and @FoliosTerminal = 1)) "
                    sConsulta &= "order by FSHFechaInicio desc) "
                    sConsulta &= "inner join centroexpedicion CEN on CEN.CentroExpID=FSH.CentroExpID and FSH.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 "
                    sConsulta &= "where FOL.ModuloMovDetalleClave = '" & dr("ModuloMovDetalleClave") & "' and FOL.TipoEstado = 1 and FOL.Fiscal = 1 and FOL.SubEmpresaID='" & drSubEmpresa("SubEmpresaID") & "' "

                    iCantFolios = MobileClient.ConexionSQL.EjecutarConsultaObjeto(sConsulta)
                    If iCantFolios <= 0 Then
                        sSubEmpresas &= drSubEmpresa("NombreEmpresa") & ","
                    End If
                Next
            End If
        Next
        If sSubEmpresas <> "" Then
            sSubEmpresas = sSubEmpresas.Substring(0, sSubEmpresas.Length - 1)
            refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0198").Replace("$0$", sSubEmpresas) & vbCrLf
        End If

        'Validacion del Esquema 
        Dim dtEsquemasNvo As DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT EsquemaId FROM Esquema WHERE Clave='NVO001'", "EsquemaNuevo")
        If dtEsquemasNvo.Rows.Count <= 0 Then
            refparsMensaje &= MobileClient.Aplicacion.ObtenerMensaje("E0473") & vbCrLf
        End If

        If refparsMensaje <> "" Then
            'Session("GenerandoBD") = False
            Return String.Empty
        End If
        If oVendedor.RecuperarTipoIndice = DBCentral.TiposModulos.Distribucion Then
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.Reparto
        End If
        Dim blnCobrarVentas As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 CobrarVentas from conhist order by CONHistFechaInicio desc")

        If blnCobrarVentas Then 'Subir Pedidos con Saldo
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.PedidosConSaldo
        Else 'Subir facturas
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.Facturas
        End If

        Dim blnInventario As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 Inventario from conhist order by CONHistFechaInicio desc")
        If blnInventario Then 'Inventario a bordo
            parsTiposConsulta = parsTiposConsulta & "," & DBCentral.TiposConsulta.InventarioABordo
        End If

        Dim blnParamGenerarBDAuto As Boolean = True

        Dim sNombreTarea As String = String.Empty
        If Not blnParamGenerarBDAuto Then
            Try
                Dim dt As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select '" & oVendedor.UsuarioId & "' as Usuario, '" & oVendedor.VendedorId & "' as Vendedor, '" & oUsuario.Clave & "' as Clave, '" & oUsuario.Nombre & "' as Nombre, " & General.UniFechaSQL(pardFechaIni).ToString & " as FechaIni," & General.UniFechaSQL(pardFechaFin).ToString & " as FechaFin, " & "'" & parsTiposConsulta & "' as TipoConsulta,'' as Error ", "Tarea")
                sNombreTarea = "VENT" & oVendedor.UsuarioId & "-" & Now.ToString("yyyyMMddhhmmss") & ".xml"
                dt.WriteXml(ServicesCentral.Configuracion.Directorio & "\" & sNombreTarea)

            Catch ex As Exception
                refparsMensaje = ex.Message
                Return sNombreTarea
            End Try

            Try
                Dim pvSC As New System.ServiceProcess.ServiceController("RouteDBService")
                pvSC.ExecuteCommand(160)
                parbGeneroBD = True
            Catch ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("ServicioWindows", "ServiceCentral"))
            End Try
        Else
            Dim directorio As System.IO.DirectoryInfo
            Dim fileEntries() As System.IO.FileInfo

            directorio = New System.IO.DirectoryInfo(ServicesCentral.Configuracion.Directorio & "\TareasProcesadas\")
            fileEntries = directorio.GetFiles("VENT" & oVendedor.UsuarioId & "*.xml")
            Array.Sort(fileEntries, New MobileClient.OrdenarFicheroPorFecha)
            Array.Reverse(fileEntries)
            Dim blnPrimeraTarea As Boolean = True
            For Each oFileInfo As IO.FileInfo In fileEntries
                Try
                    If Not blnPrimeraTarea Then
                        oFileInfo.Delete()
                        Continue For
                    End If
                    blnPrimeraTarea = False
                    Dim DataSetConfig As New DataSet("Tarea")
                    ' Leer el archivo XML con el esquema
                    DataSetConfig.ReadXml(ServicesCentral.Configuracion.Directorio & "\TareasProcesadas\" & oFileInfo.Name)
                    Dim refDataRowActual As DataRow
                    'General
                    Dim refDataTableConfig As DataTable
                    refDataTableConfig = DataSetConfig.Tables("Tarea")
                    refDataRowActual = refDataTableConfig.Rows(0)

                    Dim dFechaIni As Date, dFechaFin As Date
                    dFechaIni = refDataRowActual("FechaIni")
                    dFechaFin = refDataRowActual("FechaFin")
                    If General.PrimeraHora(dFechaIni) = General.PrimeraHora(pardFechaIni) AndAlso General.UltimaHora(dFechaFin) = General.UltimaHora(pardFechaFin) Then
                        sNombreTarea = oFileInfo.Name
                        DataSetConfig.Dispose()
                        refDataTableConfig.Dispose()
                        parbGeneroBD = False
                        'Exit For
                    End If
                    DataSetConfig.Dispose()
                    refDataTableConfig.Dispose()
                Catch ex As Exception
                    refparsMensaje = ex.Message
                    sNombreTarea = String.Empty
                End Try
            Next
            If sNombreTarea = String.Empty Then
                'Como no existió alguna tarea que coincidiera con los parámetros, se genera la tarea
                Try
                    Dim dt As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select '" & oVendedor.UsuarioId & "' as Usuario, '" & oVendedor.VendedorId & "' as Vendedor, '" & oUsuario.Clave & "' as Clave, '" & oUsuario.Nombre & "' as Nombre, " & General.UniFechaSQL(pardFechaIni).ToString & " as FechaIni," & General.UniFechaSQL(pardFechaFin).ToString & " as FechaFin, " & "'" & parsTiposConsulta & "' as TipoConsulta,'' as Error ", "Tarea")
                    sNombreTarea = "VENT" & oVendedor.UsuarioId & "-" & Now.ToString("yyyyMMddhhmmss") & ".xml"
                    dt.WriteXml(ServicesCentral.Configuracion.Directorio & "\" & sNombreTarea)

                Catch ex As Exception
                    refparsMensaje = ex.Message
                    Return sNombreTarea
                End Try

                Try
                    Dim pvSC As New System.ServiceProcess.ServiceController("RouteDBService")
                    pvSC.ExecuteCommand(160)
                    parbGeneroBD = True
                Catch ex As Exception
                    Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("ServicioWindows", "ServiceCentral"))
                End Try
            End If
        End If

        Return sNombreTarea

    End Function

    <WebMethod()> Public Function WSVerificarEstadoTarea(ByVal parsNombreTarea As String, ByRef parsMensajeError As String) As DBCentral.EstadoTarea

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\TareasProcesadas\" & parsNombreTarea) Then
            Return DBCentral.EstadoTarea.Procesada
        End If

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\TareasEnProceso\" & parsNombreTarea) Then
            Return DBCentral.EstadoTarea.EnProceso
        End If

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\TareasConError\" & parsNombreTarea) Then
            Dim DataSetConfig As New DataSet("Tarea")
            ' Leer el archivo XML con el esquema
            DataSetConfig.ReadXml(ServicesCentral.Configuracion.Directorio & "\TareasConError\" & parsNombreTarea)
            parsMensajeError = DataSetConfig.Tables(0).Rows(0)("Error")
            'parsMensajeError = "Ocurrio un error. Hacer bitacora"
            Return DBCentral.EstadoTarea.ConError
        End If

        Return DBCentral.EstadoTarea.NoDefinido
    End Function

    <WebMethod()> Public Sub WSTerminarTarea(ByVal parsNombreTarea As String, ByVal parsArchivoAEliminar As String)

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\TareasProcesadas\" & parsNombreTarea) Then
            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\TareasProcesadas\" & parsNombreTarea)
        End If

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & parsArchivoAEliminar) Then
            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & parsArchivoAEliminar)
        End If

    End Sub

    <WebMethod()> Public Function WSVendedorObtenerAcceso(ByVal parsUsuarioClave As String, ByVal parsContrasena As String, ByVal parsTerminalClave As String, ByRef refparsMensaje As String) As Boolean
        Dim oUsuario As New MobileClient.Usuario
        Return oUsuario.VerificarAcceso(parsUsuarioClave, parsContrasena, parsTerminalClave, refparsMensaje)
    End Function
    <WebMethod()> Public Function WSVendedorObtenerAccesoPrueba(ByVal parsUsuarioClave As String, ByVal parsContrasena As String, ByVal parsTerminalClave As String) As Boolean
        Dim oUsuario As New MobileClient.Usuario
        Dim s As String = String.Empty
        Return oUsuario.VerificarAcceso(parsUsuarioClave, parsContrasena, parsTerminalClave, s)
    End Function

    <WebMethod()> Public Function WSActualizarCaptura(ByVal parsVendedorID As String, ByVal paroDataSet As DataSet, ByVal pardFechaInicial As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String, ByRef refparbReintentar As Boolean) As Boolean
        Dim oVendedor As New MobileClient.Vendedor
        'Dim bReintentar As Boolean
        Dim nIntento As Integer
        Dim bResult As Boolean
        oVendedor.VendedorId = parsVendedorID
        oVendedor.Recuperar()
        refparbReintentar = True
        nIntento = 1
        While refparbReintentar And nIntento <= 4
            bResult = oVendedor.ActualizarCaptura(paroDataSet, pardFechaInicial, pardFechaPrimerDia, refparsMensaje, refparbReintentar)
            nIntento += 1
        End While
        Return bResult
    End Function
    <WebMethod()> Public Function WSEjecutarInterfaces(ByVal parsVendedorID As String, ByVal pardFechaInicial As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String, ByRef refparbReintentar As Boolean) As Boolean
        If Application("HiloGeneral") Is Nothing Then
            Dim hiloG As New HiloEjecutarInterfacesGeneral()
            Application("HiloGeneral") = hiloG
        End If
        Dim hg As HiloEjecutarInterfacesGeneral = DirectCast(Application("HiloGeneral"), HiloEjecutarInterfacesGeneral)
        hg.Agregar(parsVendedorID, pardFechaInicial, pardFechaPrimerDia)
        hg.EjecutarInterfaces()
        Return True
    End Function
    <WebMethod()> Public Function WSEjecutarInterfacesPrueba(ByVal parsVendedorID As String, ByVal pardFechaInicial As String, ByVal pardFechaPrimerDia As String) As Boolean
        Dim fechaini As Date = Convert.ToDateTime(pardFechaInicial)
        Dim fechaprimer As Date = Convert.ToDateTime(pardFechaPrimerDia)

        Return WSEjecutarInterfaces(parsVendedorID, fechaini, fechaprimer, "", False)

    End Function

    <WebMethod()> Public Sub WSCrearRutaHTTP(ByVal parsUsuarioID As String)
        IO.Directory.CreateDirectory(ServicesCentral.Configuracion.Directorio & "\" & parsUsuarioID & "\SAL")
    End Sub

    <WebMethod()> Public Function WSActualizarCapturaHTTP(ByVal parsVendedorID As String, ByVal pardFechaInicial As Date, ByVal pardFechaPrimerDia As Date, ByVal parsNombreArchivo As String) As String
        Dim oVendedor As New MobileClient.Vendedor
        oVendedor.VendedorId = parsVendedorID
        oVendedor.Recuperar()
        Return oVendedor.ActualizarCapturaHTTP(pardFechaInicial, pardFechaPrimerDia, parsNombreArchivo)
    End Function

    '<WebMethod()> Public Function WSDisparaDTS(ByVal parsVendedorID As String, ByVal pardFechaIni As Date) As Boolean
    '    Dim oVendedor As New MobileClient.Vendedor
    '    oVendedor.VendedorId = parsVendedorID
    '    oVendedor.Recuperar()
    '    Dim sMensaje As String = String.Empty
    '    oVendedor.DispararDTSExportacion(pardFechaIni, sMensaje)
    'End Function

    <WebMethod()> Public Function WSDisparaStoreProcedure(ByVal parsVendedorID As String, ByVal pardFechaIni As Date) As Boolean
        Dim oVendedor As New MobileClient.Vendedor
        oVendedor.VendedorId = parsVendedorID
        oVendedor.Recuperar()
        Dim sMensaje As String = String.Empty
        Return oVendedor.DispararStoreProceduresExportacion(pardFechaIni, pardFechaIni, sMensaje)
    End Function

    <WebMethod()> Public Function WSObtenerFoliosDuplicados(ByVal sFolios As String, ByVal sTransProdID As String, ByVal parsSubEmpresaID As String) As String
        Dim sConsulta As String
        Dim dtTransProd As DataTable
        Dim sFoliosDup As String = ""
        sConsulta = "select TRP.Folio from TransProd TRP inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID where TRP.transprodid not in (" & sTransProdID & ")  and TRP.Folio in (" & sFolios & ") and TRP.Tipo = 8 and TRP.SubEmpresaID='" & parsSubEmpresaID & "' "
        dtTransProd = MobileClient.ConexionSQL.RealizarConsulta(sConsulta, "TransProd")
        For Each drTransProd As DataRow In dtTransProd.Rows
            sFoliosDup &= "'" & drTransProd("Folio") & "',"
        Next
        If sFoliosDup.Length > 0 Then
            sFoliosDup = sFoliosDup.Remove(sFoliosDup.Length - 1, 1)
        End If
        Return sFoliosDup
    End Function

    <WebMethod()> Public Function WSObtenerArchivoZip(ByVal parByteArchivo As Byte()) As Boolean
        Dim bResult As Boolean

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta.zip") Then
            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta.zip")
        End If
        If System.IO.Directory.Exists(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta") Then
            System.IO.Directory.Delete(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta", True)
        End If

        Dim fsBD As IO.FileStream
        fsBD = New IO.FileStream(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta.zip", IO.FileMode.CreateNew, IO.FileAccess.Write)
        fsBD.Write(parByteArchivo, 0, parByteArchivo.Length)
        fsBD.Close()

        Dim z As New C1.C1Zip.C1ZipFile(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta.zip")
        z.Entries.ExtractFolder(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta")

        System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta.zip")

        Return bResult
    End Function
#End Region

#Region "Auditoría"

    <WebMethod()> Public Function WSAuditoriaVerificar() As Boolean

        Return General.VerificaAuditoria
    End Function

#End Region

#Region " Temporal "

    <WebMethod()> Public Function WSTemporal() As MobileClient.TiposTmp

    End Function

#End Region

#Region "Licencia Terminal"

    Private oDevice_Serial As CDevice_Serial
    Public intIntentos As Integer


    <WebMethod()> _
    Public Function WSTipo_Licencia(ByVal pvDeviceID As String, ByVal pvDeviceName As String) As CDevice_Serial.Registro

        Try
            pvDeviceID = pvDeviceID.ToUpper()
            pvDeviceName = pvDeviceName.ToUpper()
            oDevice_Serial = New CDevice_Serial

            '--Asignarle el usuario Admin por default
            Dim oResult As CDevice_Serial.Registro
            oResult = oDevice_Serial.GetTipoLicencia(pvDeviceID, pvDeviceName)

            Return oResult
            oDevice_Serial = Nothing

        Catch ex As Exception
            Return CDevice_Serial.Registro.ErrorRegistro
        End Try

    End Function


#End Region

#Region "Version Terminal"

    <WebMethod()> Public Function WSDatetime() As String
        Return Now
    End Function
    <WebMethod()> Public Function WSUltimaVersionTerminal() As String
        Return MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("select isnull(UltimaVersion,'') from TerminalVersion ")
    End Function
    <WebMethod()> Public Function WSObtenerUltimoCAB(ByVal OSMajor As Integer, ByVal OSMinor As Integer) As Byte()
        Try
            Dim sArchivoCAB As String = String.Empty
            '--Siempre se recupera el unico que debe de existir
            Dim sDireccionEjecutable As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("select isnull(DireccionEjecutable,'') from TerminalVersion ")

            If OSMajor = 5 And OSMinor = 0 Then
                '--Se trata de una version para windows CE                
                sArchivoCAB = String.Format("{0}wce5\AmesolRoute.CAB", sDireccionEjecutable)
            ElseIf OSMajor = 5 And OSMinor > 0 Then
                '--Se trata de una version para Windows Mobile 5
                sArchivoCAB = String.Format("{0}wm2005\AmesolRoute.CAB", sDireccionEjecutable)
            ElseIf OSMajor = 4 Then
                '--Se trata de una version para Pocket PC 2003
                sArchivoCAB = String.Format("{0}wm2003\AmesolRoute.CAB", sDireccionEjecutable)
            End If
            Return General.LoadBinaryData(sArchivoCAB)
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

    <WebMethod()> Public Function WSProbarConexionFireBird() As String
        Return ""
        'Return InterfazFirebird.ProbarConexion(ServicesCentral.Configuracion.CadenaConexionFirebird)
    End Function

    <WebMethod()> Public Function WSVersion() As String
        Return "1.5.0.0C"
    End Function

    <WebMethod()> Public Function WSPrueba() As String
        MobileClient.ConexionSQL.RealizarConsultaDataSetSinAcceptChange("Select * from transprod", "TransProd")
        Return "1.5.0.0C"
    End Function

End Class
