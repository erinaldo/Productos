
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

    '<WebMethod()> Public Function WSAplicacionObtenerActualizacionSQLite(ByVal parsXMLUltActualizacion As DataSet, ByVal parsCondicionTablas As String) As String
    '    Dim oAplicacion As New MobileClient.Aplicacion
    '    Dim ds As DataSet = oAplicacion.ObtenerActualizacion(parsXMLUltActualizacion.GetXml, parsCondicionTablas, DBCentral.TiposBase.Aplicacion)

    '    If ds.Tables.Count <= 0 Then
    '        Return ""
    '    End If
    '    Dim oguid As Guid = Guid.NewGuid
    '    If Not (System.IO.Directory.Exists(ServicesCentral.Configuracion.Directorio)) Then
    '        '[E0690] El directorio "$0$" no existe o no tiene permisos de escritura
    '        Throw New System.Web.Services.Protocols.SoapException("El directorio " & ServicesCentral.Configuracion.Directorio & " no existe o no tiene permisos de escritura", New System.Xml.XmlQualifiedName("SINSDF", "ServiceCentral"))
    '    End If

    '    Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & oguid.ToString + ".xml", System.Text.Encoding.UTF8)
    '    ' Escribir en el archivo XML
    '    ds.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
    '    ' Cerrar el flujo XML
    '    XmlTextWriterDicc.Close()

    '    General.ComprimirArchivo(oguid.ToString() + ".xml", ".xml", Context.Server.MapPath("~\Bases\" & oguid.ToString() & ".zip"), True)

    '    System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & oguid.ToString + ".xml")

    '    Return oguid.ToString
    'End Function

    '<WebMethod()> Public Function WSAplicacionObtenerActualizacionSQLiteMetodo2(ByVal parsNumeroSerie As String, ByVal parsCondicionTablas As String) As String
    '    Dim oAplicacion As New MobileClient.Aplicacion
    '    Dim ds As DataSet = oAplicacion.ObtenerActualizacionMetodo2(parsNumeroSerie, parsCondicionTablas, DBCentral.TiposBase.Aplicacion & "," & DBCentral.TiposBase.AplSQLite)

    '    If ds.Tables.Count <= 0 Then
    '        Return ""
    '    End If
    '    Dim oguid As Guid = Guid.NewGuid

    '    Dim oArchivoSQLite As New ArchivoSQLite

    '    oArchivoSQLite.NombreArchivo = oguid.ToString & ".db"
    '    oArchivoSQLite.TipoTablas = DBCentral.TiposBase.Aplicacion & "," & DBCentral.TiposBase.AplSQLite

    '    If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSQLite.NombreArchivo) Then
    '        System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSQLite.NombreArchivo)
    '    End If

    '    ' Existe el Esquema MobileDB, pero no la base de datos, crearla
    '    Dim bTablasCreadas As Boolean = False
    '    If oArchivoSQLite.CrearArchivoSQLite Then
    '        bTablasCreadas = oArchivoSQLite.CrearTablas(parsCondicionTablas, ds)
    '        If Not bTablasCreadas Then
    '            Return String.Empty
    '        End If
    '    End If

    '    oArchivoSQLite.LlenarTablas(ds, , False)

    '    General.ComprimirArchivo(oguid.ToString() + ".db", ".db", Context.Server.MapPath("~\Bases\" & oguid.ToString() & ".zip"), False)

    '    System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & oguid.ToString + ".db")

    '    Return oguid.ToString
    'End Function

    '<WebMethod()> Public Function WSAplicacionObtenerActualizacion(ByVal parsXMLUltActualizacion As String, ByVal parsCondicionTablas As String) As DataSet
    '    Dim oAplicacion As New MobileClient.Aplicacion
    '    Dim ds As DataSet = oAplicacion.ObtenerActualizacion(parsXMLUltActualizacion, parsCondicionTablas, DBCentral.TiposBase.Aplicacion & "," & DBCentral.TiposBase.AplSQLCE)
    '    Return ds
    'End Function

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

    'Ady
    <WebMethod()> Public Function WSAplicacionObtenerBDSqLite(ByVal parsTallerClave As String, ByVal parsUsuarioClave As String, ByVal parsTerminalNumeroSerie As String, ByRef refparsMensaje As String) As String

        Dim oTaller As New MobileClient.Taller
        If Not oTaller.Recuperar(parsTallerClave) Then
            refparsMensaje = "No existe el taller o no se encuentra activo"
            Return String.Empty
        End If
        If Not oTaller.Activo Then
            refparsMensaje = "No existe el taller o no se encuentra activo"
            Return String.Empty
        End If

        Dim oUsuario As New MobileClient.Usuario
        If Not oUsuario.Recuperar(parsUsuarioClave) Then
            refparsMensaje = "No existe el usuario o no se encuentra activo"
            Return String.Empty
        End If
        If Not oUsuario.Activo Then
            refparsMensaje = "No existe el usuario o no se encuentra activo"
            Return String.Empty
        End If

        If oTaller.TallerId <> oUsuario.TallerId Then
            refparsMensaje = "El Taller no corresponde al asignado al Agente"
            Return String.Empty
        End If

        If oTaller.NoSerieTerminal = "" Then
            oTaller.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf oTaller.NoSerieTerminal <> parsTerminalNumeroSerie Then
            refparsMensaje = "La Terminal no corresponde a la asignada al Taller"
            Return String.Empty
        End If

        Dim oAplicacion As New MobileClient.Aplicacion
        Dim sNombreArchivo As String = String.Empty
        sNombreArchivo = oAplicacion.CrearBDSQLite(oTaller.TallerId, parsTerminalNumeroSerie)

        Dim oguid As Guid = Guid.NewGuid

        General.ComprimirArchivo(sNombreArchivo, ".db", Context.Server.MapPath("~\Bases\" & oguid.ToString() & ".zip"), True)

        'SincronizacionTerminal.TipoActualizacion = SincronizacionTerminal.eTipoActualizacion.CargaConfiguracion
        'SincronizacionTerminal.Tablas = DBCentral.TiposBase.Aplicacion
        'SincronizacionTerminal.NumeroSerie = parsTerminalNumeroSerie
        'Dim hiloActualizacion = New Threading.Thread(AddressOf SincronizacionTerminal.ActualizaSincronizacionTerminal)
        'hiloActualizacion.Start()

        Return oguid.ToString


    End Function

    'Ady
    <WebMethod()> Public Function WSAplicacionObtenerBDSqLitePrueba(ByVal parsTallerClave As String, ByVal parsTerminalNumeroSerie As String, ByVal parsUsuarioClave As String) As String
        Dim oTaller As New MobileClient.Taller
        If Not oTaller.Recuperar(parsTallerClave) Then
            'refparsMensaje = "No existe el taller o no se encuentra activo"
            Return String.Empty
        End If
        If Not oTaller.Activo Then
            'refparsMensaje = "No existe el taller o no se encuentra activo"
            Return String.Empty
        End If

        Dim oUsuario As New MobileClient.Usuario
        If Not oUsuario.Recuperar(parsUsuarioClave) Then
            'refparsMensaje = "No existe el usuario o no se encuentra activo"
            Return String.Empty
        End If
        If Not oUsuario.Activo Then
            'refparsMensaje = "No existe el usuario o no se encuentra activo"
            Return String.Empty
        End If

        If oTaller.TallerId <> oUsuario.TallerId Then
            'refparsMensaje = "El Taller no corresponde al asignado al Agente"
            Return String.Empty
        End If

        If oTaller.NoSerieTerminal = "" Then
            oTaller.ActualizaNumeroSerie(parsTerminalNumeroSerie)
        ElseIf oTaller.NoSerieTerminal <> parsTerminalNumeroSerie Then
            'refparsMensaje = "La Terminal no corresponde a la asignada al Taller"
            Return String.Empty
        End If

        Dim oAplicacion As New MobileClient.Aplicacion
        Dim sNombreArchivo As String = String.Empty
        sNombreArchivo = oAplicacion.CrearBDSQLite(oTaller.TallerId, parsTerminalNumeroSerie)

        Dim oguid As Guid = Guid.NewGuid

        General.ComprimirArchivo(sNombreArchivo, ".db", Context.Server.MapPath("~\Bases\" & oguid.ToString() & ".zip"), True)

        'SincronizacionTerminal.TipoActualizacion = SincronizacionTerminal.eTipoActualizacion.CargaConfiguracion
        'SincronizacionTerminal.Tablas = DBCentral.TiposBase.Aplicacion
        'SincronizacionTerminal.NumeroSerie = parsTerminalNumeroSerie
        'Dim hiloActualizacion = New Threading.Thread(AddressOf SincronizacionTerminal.ActualizaSincronizacionTerminal)
        'hiloActualizacion.Start()

        Return oguid.ToString
    End Function

    'Ady
    <WebMethod()> Public Sub WSEliminarArchivoBases(ByVal parsNombreArchivo As String)

        If System.IO.File.Exists(Context.Server.MapPath("~\Bases\" & parsNombreArchivo)) Then
            System.IO.File.Delete(Context.Server.MapPath("~\Bases\" & parsNombreArchivo))
        End If

    End Sub

    <WebMethod()> Public Function WSActualizarCapturaSQLite(ByVal bytes As Byte(), ByVal parsNombreZip As String, ByRef refparsMensaje As String, ByRef refparbReintentar As Boolean) As Boolean
        Dim bResult As Boolean

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip) Then
            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip)
        End If

        Dim fsBD As IO.FileStream
        fsBD = New IO.FileStream(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip, IO.FileMode.CreateNew, IO.FileAccess.Write)
        fsBD.Write(bytes, 0, bytes.Length)
        fsBD.Close()

        Dim z As New C1.C1Zip.C1ZipFile(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip)
        z.Entries.ExtractFolder(ServicesCentral.Configuracion.Directorio)

        System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip)

        Dim paroDataSet As DataSet
        Try
            Dim oTaller As MobileClient.Taller = New MobileClient.Taller()

            Dim oArchivoSQLite As New ArchivoSQLite
            paroDataSet = oArchivoSQLite.ObtenerDataSet_BDSQLite(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip.Replace(".zip", ".db"))

            bResult = oTaller.ActualizarCaptura(paroDataSet, refparsMensaje, refparbReintentar)

            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip.Replace(".zip", ".db"))


        Catch ex As Exception
            Dim error2 As String = ""
            Try
                System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip.Replace(".zip", ".db"))
            Catch ex2 As Exception
                error2 = ex2.Message
            End Try
            Throw New Exception(ex.Message + " - " + error2)

        End Try

        Return bResult
    End Function

    <WebMethod()> Public Function WSActualizarCapturaSQLitePrueba(ByVal parsNombreBD As String) As Boolean
        Dim bResult As Boolean

        Dim paroDataSet As DataSet
        Try
            Dim oTaller As MobileClient.Taller = New MobileClient.Taller()

            Dim oArchivoSQLite As New ArchivoSQLite
            paroDataSet = oArchivoSQLite.ObtenerDataSet_BDSQLite(ServicesCentral.Configuracion.Directorio & "\" & parsNombreBD)

            bResult = oTaller.ActualizarCaptura(paroDataSet, "", False)

            'System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip.Replace(".zip", ".db"))


        Catch ex As Exception
            Dim error2 As String = ""
            Try
                'System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & parsNombreZip.Replace(".zip", ".db"))
            Catch ex2 As Exception
                error2 = ex2.Message
            End Try
            Throw New Exception(ex.Message + " - " + error2)

        End Try

        Return bResult
    End Function

    <WebMethod()> Public Function WSTallerObtenerTraspasos(ByVal parsTallerId As String, ByVal parsFechaInicio as String) As String

        Dim ds As DataSet = MobileClient.Taller.ObtenerTraspasos(parsTallerId, parsFechaInicio)

        Dim oguid As Guid = Guid.NewGuid
        Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & oguid.ToString + ".xml", System.Text.Encoding.UTF8)
        ' Escribir en el archivo XML
        ds.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
        ' Cerrar el flujo XML
        XmlTextWriterDicc.Close()

        General.ComprimirArchivo(oguid.ToString() + ".xml", ".xml", Context.Server.MapPath("~\Bases\" & oguid.ToString() & ".zip"), True)

        System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & oguid.ToString + ".xml")

        If ds.Tables(0).Rows.Count > 0 Then
            ''actualizar la tabla sincronizacionvendedor
            'SincronizacionVendedor.TipoActualizacion = SincronizacionVendedor.eTipoActualizacion.Actualizacion
            'SincronizacionVendedor.Tablas = "Traspaso, TRPDetalle"
            'SincronizacionVendedor.VendedorID = parsVendedorID
            'Dim hiloActualizacion = New Threading.Thread(AddressOf SincronizacionVendedor.ActualizaSincronizacionVendedor)
            'hiloActualizacion.Start()

            Return oguid.ToString
        Else
            System.IO.File.Delete(Context.Server.MapPath("~\Bases\" & "\" & oguid.ToString + ".zip"))
            Return ""
        End If

    End Function

    <WebMethod()> Public Sub WSTallerMarcarTraspasosEnviados(ByVal parsTallerId As String, ByVal parsFechaInicio As String, ByVal parsUsuarioId As String)

        MobileClient.Taller.MarcarTraspasosEnviados(parsTallerId, parsFechaInicio, parsUsuarioId)

    End Sub

    'Se usa para android porque ya tiene la carpeta incluida en el .zip
    <WebMethod()> Public Function WSObtenerArchivoZipAndroid(ByVal parByteArchivo As Byte()) As Boolean
        Dim bResult As Boolean

        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga.zip") Then
            System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga.zip")
        End If

        Dim fsBD As IO.FileStream
        fsBD = New IO.FileStream(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga.zip", IO.FileMode.CreateNew, IO.FileAccess.Write)
        fsBD.Write(parByteArchivo, 0, parByteArchivo.Length)
        fsBD.Close()

        Dim z As New C1.C1Zip.C1ZipFile(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga.zip")
        z.Entries.ExtractFolder(ServicesCentral.Configuracion.Directorio)

        System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga.zip")

        Return bResult
    End Function

#End Region

#Region " Usuario "

    'Ady
    <WebMethod()> Public Function WSObtenerUsuarioContrasena(ByVal pvTaller As String, ByVal pvUsuario As String, ByVal pvContrasena As String, ByVal pvNoSerieTerminal As String, ByRef prMensaje As String) As Boolean
        Dim oUsuario As New MobileClient.Usuario
        Return oUsuario.VerificarAcceso(pvTaller, pvUsuario, pvContrasena, pvNoSerieTerminal, prMensaje)
    End Function

    <WebMethod()> Public Function WSObtenerUsuarioContrasenaPrueba(ByVal pvTaller As String, ByVal pvUsuario As String, ByVal pvContrasena As String, ByVal pvNoSerieTerminal As String) As Boolean
        Dim oUsuario As New MobileClient.Usuario
        Return oUsuario.VerificarAcceso(pvTaller, pvUsuario, pvContrasena, pvNoSerieTerminal, "")
    End Function

#End Region

    <WebMethod()> Public Function WSVersion() As String
        Return "1.0.0.0"
    End Function

    <WebMethod()> Public Function WSPrueba() As String
        MobileClient.ConexionSQL.RealizarConsultaDataSetSinAcceptChange("Select * from Usuario", "Usuario")
        Return "1.0.0.0"
    End Function



End Class
