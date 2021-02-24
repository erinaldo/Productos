Imports Microsoft.VisualBasic
Imports System.Data.SqlServerCe
Imports System.Data.SqLite
Imports System.Data
Imports System.Web
Public Class General
    Public Const PubcArchivoConfig = "MobileClientConfig.xml"
    Public Const PubcArchivoDatosApp = "MobileDBApp.sdf"
    Public Const PubcArchivoDatosUsr = "MobileDBUsr.sdf"
    Public Const PubcArchivoDatosDia = "MobileDBDia.sdf"
    Public Const PubcArchivoEsquema = "MobileDBConfig.xml"
    Public Const PubcServiceMobileClient = "ServiceMobileClient.asmx"

    Public Shared Function LoadBinaryDataBY(ByVal path As String) As Byte()

        ' Open a file stream for input
        Using fs As IO.FileStream = New IO.FileStream(ServicesCentral.Configuracion.Directorio & "\" & path, IO.FileMode.Open)
            ' Create a binary formatter for this stream
            Dim br As IO.BinaryReader
            br = New IO.BinaryReader(fs)
            Dim bytesRead As Byte() = br.ReadBytes(fs.Length)
            fs.Close()
            Return bytesRead
        End Using

    End Function

    '--Especial para descargar la version del CAB
    Public Shared Function LoadBinaryData(ByVal path As String) As Byte()

        ' Open a file stream for input
        Using fs As IO.FileStream = New IO.FileStream(path, IO.FileMode.Open)
            ' Create a binary formatter for this stream
            Dim br As IO.BinaryReader
            br = New IO.BinaryReader(fs)
            Dim bytesRead As Byte() = br.ReadBytes(fs.Length)
            fs.Close()
            Return bytesRead
        End Using

    End Function

    Public Shared Function NumeroDiasAño(ByVal pariAño As Integer) As Short
        If Date.IsLeapYear(pariAño) Then
            Return 366
        Else
            Return 365
        End If
    End Function

    Public Shared Function UniFechaSQL(ByVal pardFecha As Date, Optional ByVal optsTipoDatoDestino As String = "DATETIME", Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss", Optional ByVal optsEstilo As String = "103") As String
        'Dim s As String = "CONVERT(" & optsTipoDatoDestino & ",'" & Fecha24Horas(pardFecha, optsFormato) & "'," & optsEstilo & ")"
        Dim s As String = "'" & pardFecha.ToString("s") & "'"
        Return s
    End Function

    Public Shared Function UltimaHora(ByVal parFecha As Date) As Date
        Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 23, 59, 59)
        Return f2
    End Function

    Public Shared Function PrimeraHora(ByVal parFecha As Date) As Date
        Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 0, 0, 0)
        Return f2
    End Function

    Public Shared Function ObtenerNumeroDiaSemana(ByVal dFechaDia As Date) As Short
        Dim iDia As Short = 0
        Select Case dFechaDia.DayOfWeek
            Case DayOfWeek.Sunday
                iDia = 1
            Case DayOfWeek.Monday
                iDia = 2
            Case DayOfWeek.Tuesday
                iDia = 3
            Case DayOfWeek.Wednesday
                iDia = 4
            Case DayOfWeek.Thursday
                iDia = 5
            Case DayOfWeek.Friday
                iDia = 6
            Case DayOfWeek.Saturday
                iDia = 7
        End Select
        Return iDia
    End Function

    Public Shared Sub SerializeDataSet(ByVal filename As String)
        Dim ser As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
        ' Creates a DataSet; adds a table, column, and ten rows.
        Dim ds As DataSet = New DataSet("myDataSet")
        Dim t As DataTable = New DataTable("table1")
        Dim c As DataColumn = New DataColumn("thing")
        t.Columns.Add(c)
        ds.Tables.Add(t)
        Dim r As DataRow
        Dim i As Integer
        For i = 0 To 10
            r = t.NewRow()
            r(0) = "Thing " & i
            t.Rows.Add(r)
        Next
        Dim writer As System.IO.TextWriter = New System.IO.StreamWriter(filename)
        ser.Serialize(writer, ds)
        writer.Close()
    End Sub

    Public Shared Function ComprimirArchivo(ByVal sNombreArchivo As String, ByVal sExtension As String) As Boolean
        ' get the name of file
        Dim sFile As String = ServicesCentral.Configuracion.Directorio + "\" + sNombreArchivo
        'Dim sFile As String = sNombreArchivo
        'Dim zipArchive As New Resco.IO.Zip.ZipArchive(sFile.Replace(".sdf", ".zip"), Resco.IO.Zip.ZipArchiveMode.Create, IO.FileShare.Write)
        Dim zipArchive As New C1.C1Zip.C1ZipFile(sFile.Replace(sExtension, ".zip"), True)
        ' check if we still have archive opened
        If zipArchive Is Nothing Then
            Return False
        End If

        ' show dialog
        'Try
        'zipArchive.Add(sFile, "", True, Nothing)
        'zipArchive.Add(sFile.Replace(".sdf", ".xml"), "", True, Nothing)
        zipArchive.Entries.Add(sFile)
        zipArchive.Entries.Add(sFile.Replace(sExtension, ".xml"))
        'Catch 'ex As Exception
        ' we got error, during adding.
        'End Try
        ' clear name
        zipArchive.Close()
    End Function

    'Ady
    Public Shared Function ComprimirArchivo(ByVal sNombreArchivo As String, ByVal sExtension As String, ByVal sRuta As String, ByVal parbIncluirXml As Boolean) As Boolean
        ' get the name of file
        Dim sFile As String = ServicesCentral.Configuracion.Directorio + "\" + sNombreArchivo
        
        Dim zipArchive As New C1.C1Zip.C1ZipFile(sRuta, True)
        ' check if we still have archive opened
        If zipArchive Is Nothing Then
            Return False
        End If

        zipArchive.Entries.Add(sFile)
        If parbIncluirXml Then
            zipArchive.Entries.Add(sFile.Replace(sExtension, ".xml"))
        End If
       
        zipArchive.Close()
    End Function

    Public Shared Function RecuperaVEF() As String
        Dim dtFechaVencimiento As DataTable
        Try
            Dim consulta As New Text.StringBuilder
            consulta.AppendLine("IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)")
            consulta.AppendLine("BEGIN")
            consulta.AppendLine("CREATE MASTER KEY ENCRYPTION BY ")
            consulta.AppendLine("PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'")
            consulta.AppendLine("CREATE CERTIFICATE Arrendamiento")
            consulta.AppendLine("WITH SUBJECT = 'Fecha de Arrendamiento Route';")
            consulta.AppendLine("CREATE SYMMETRIC KEY Arrendamiento_Key")
            consulta.AppendLine("WITH ALGORITHM = AES_256")
            consulta.AppendLine("ENCRYPTION BY CERTIFICATE Arrendamiento;")
            consulta.AppendLine("END")
            consulta.AppendLine(" ")
            consulta.AppendLine("OPEN SYMMETRIC KEY Arrendamiento_Key")
            consulta.AppendLine("DECRYPTION BY CERTIFICATE Arrendamiento;")
            consulta.AppendLine(" ")
            consulta.AppendLine("SELECT CONVERT(varchar,DecryptByKey(VEF,1,HashBytes('SHA1',CONVERT(varbinary, RFC)))) as FechaVencimiento")
            consulta.AppendLine("FROM Configuracion;")
            dtFechaVencimiento = MobileClient.ConexionSQL.RealizarConsulta(consulta.ToString)
        Catch ex As Exception
            If ex.Message = 15581 Then
                Dim consulta As New Text.StringBuilder
                consulta.AppendLine("OPEN MASTER KEY DECRYPTION BY PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'")
                consulta.AppendLine("ALTER MASTER KEY ADD ENCRYPTION BY SERVICE MASTER KEY")
                MobileClient.ConexionSQL.EjecutarComando(consulta.ToString)
                Return RecuperaVEF()
            Else
                Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End If
        End Try

        Return dtFechaVencimiento.Rows(0)("FechaVencimiento").ToString
    End Function

    Public Shared Function GuardaVEF(ByVal FechaVencimiento As String)
        Try
            Dim consulta As New Text.StringBuilder
            consulta.AppendLine("IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101)")
            consulta.AppendLine("BEGIN")
            consulta.AppendLine("CREATE MASTER KEY ENCRYPTION BY ")
            consulta.AppendLine("PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'")
            consulta.AppendLine("CREATE CERTIFICATE Arrendamiento")
            consulta.AppendLine("WITH SUBJECT = 'Fecha de Arrendamiento Route';")
            consulta.AppendLine("CREATE SYMMETRIC KEY Arrendamiento_Key")
            consulta.AppendLine("WITH ALGORITHM = AES_256")
            consulta.AppendLine("ENCRYPTION BY CERTIFICATE Arrendamiento;")
            consulta.AppendLine("END")
            consulta.AppendLine(" ")
            consulta.AppendLine("OPEN SYMMETRIC KEY Arrendamiento_Key")
            consulta.AppendLine("DECRYPTION BY CERTIFICATE Arrendamiento;")
            consulta.AppendLine("UPDATE Configuracion")
            consulta.AppendLine("SET VEF = EncryptByKey(Key_GUID('Arrendamiento_Key'),'" & FechaVencimiento & "',1,HashBytes('SHA1',CONVERT(varbinary,RFC)));")
            MobileClient.ConexionSQL.EjecutarComando(consulta.ToString)
        Catch ex As Exception
            If ex.Message = 15581 Then
                Dim consulta As New Text.StringBuilder
                consulta.AppendLine("OPEN MASTER KEY DECRYPTION BY PASSWORD = '23987hxJKL95QYV4369#ghf0%lekjg5k3fd117r$$#1946kcj$n44ncjhdlj'")
                consulta.AppendLine("ALTER MASTER KEY ADD ENCRYPTION BY SERVICE MASTER KEY")
                MobileClient.ConexionSQL.EjecutarComando(consulta.ToString)
                GuardaVEF(FechaVencimiento)
            Else
                Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End If
        End Try

    End Function

End Class

Public Class SincronizacionVendedor
    'clase usada para el hilo que actualiza la tabla SincronizacionVendedor

    Enum eTipoActualizacion
        Ninguno = 0
        CargaAgenda = 1
        Actualizacion = 2
        DescargaDeInfo = 3
        CargaConfiguracion = 4
    End Enum

    Public Shared TipoActualizacion As eTipoActualizacion
    Public Shared Tablas As String
    Public Shared VendedorID As String
    Public Shared FechaIni As Date
 
    Public Shared Sub ActualizaSincronizacionVendedor()
        If TipoActualizacion = eTipoActualizacion.CargaAgenda Then
            ActualizaSincronizacionVendedor(Tablas, VendedorID)
        ElseIf TipoActualizacion = eTipoActualizacion.Actualizacion Then
            ActualizaSincronizacionVendedorPorNombre(Tablas, VendedorID)
        ElseIf TipoActualizacion = eTipoActualizacion.DescargaDeInfo Then
            ActualizaDescargaInfoVendedorPorFecha(VendedorID, FechaIni)
        End If
        TipoActualizacion = eTipoActualizacion.Ninguno
        Tablas = String.Empty
        VendedorID = String.Empty
    End Sub

    Private Shared Sub ActualizaSincronizacionVendedor(ByVal TipoTablas As String, ByVal VendedorID As String)
        Dim refDataTable As New DataTable
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select Nombre from tabla where TipoBase in (" & TipoTablas & ") order by orden ", "Tabla")
        For Each refDataRow As DataRow In refDataTable.Rows
            Dim sNombreTabla As String = RTrim(refDataRow("Nombre"))
            Dim sConsulta As New System.Text.StringBuilder
            sConsulta.AppendLine("IF EXISTS(SELECT Tabla FROM SincronizacionVendedor WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sNombreTabla & "')")
            sConsulta.AppendLine("UPDATE SincronizacionVendedor SET FechaHoraSincronizacion = GETDATE() WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sNombreTabla & "'")
            sConsulta.AppendLine("ELSE")
            sConsulta.AppendLine("INSERT SincronizacionVendedor VALUES('" & VendedorID & "','" & sNombreTabla & "',GETDATE())")
            MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
        Next
    End Sub

    Private Shared Sub ActualizaSincronizacionVendedorPorNombre(ByVal Tablas As String, ByVal VendedorID As String)
        Dim refDataTable As New DataTable
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select Nombre from tabla where Nombre in ('" & Tablas & "') order by orden ", "Tabla")
        For Each refDataRow As DataRow In refDataTable.Rows
            Dim sNombreTabla As String = RTrim(refDataRow("Nombre"))
            Dim sConsulta As New System.Text.StringBuilder
            sConsulta.AppendLine("IF EXISTS(SELECT Tabla FROM SincronizacionVendedor WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sNombreTabla & "')")
            sConsulta.AppendLine("UPDATE SincronizacionVendedor SET FechaHoraSincronizacion = GETDATE() WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sNombreTabla & "'")
            sConsulta.AppendLine("ELSE")
            sConsulta.AppendLine("INSERT SincronizacionVendedor VALUES('" & VendedorID & "','" & sNombreTabla & "',GETDATE())")
            MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
        Next
    End Sub

    Private Shared Sub ActualizaDescargaInfoVendedorPorFecha(ByVal VendedorID As String, ByVal fechaInicial As DateTime)
        Dim refDataTable As New DataTable
        Dim diasPosteriores As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 DiasPosteriores from conhist where ConHistFechaInicio <=getdate() order by ConHistFechaInicio desc ")
        Dim dFechaFin As DateTime
        dFechaFin = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select MAX(Dia.FechaCaptura) from Agenda AGE inner join Dia on Dia.DiaClave = AGE.DiaClave where AGE.VendedorID ='" + VendedorID + "' ")
        If diasPosteriores > 0 Then
            'checar si esta correcta esta operacion, esta restando los dias posteriores
            'y la fecha final puede ser menor a la fecha del dispositivo
            'y al hacer la siguiente consulta con el between no encuentra nada
            'ejemplo: fecha dispositivo = 03/11/2014, dias posteriores = 6, fecha final = 08/11/2014
            'operacion: fecha final - (dias posteriores * -1) = 08/11/2014 - 6 = 02/11/2014
            'consulta: el between busca entre 03/11/2014 y 02/11/2014
            dFechaFin = DateAdd(DateInterval.Day, diasPosteriores * -1, dFechaFin)
            If Date.Compare(dFechaFin, fechaInicial) < 0 Then
                'si la fecha final es menor, poner la fecha inicial como final y la final como inicial
                Dim dTmp As DateTime = dFechaFin
                dFechaFin = fechaInicial
                fechaInicial = dFechaFin
            End If
        End If
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select AGE.DiaClave from Agenda AGE inner join Dia on Dia.DiaClave = AGE.DiaClave where AGE.VendedorID ='" + VendedorID + "' and Dia.FechaCaptura between " + General.UniFechaSQL(General.PrimeraHora(fechaInicial)) + " and " + General.UniFechaSQL(General.UltimaHora(dFechaFin)) + " group by AGE.DiaClave", "Dias")
        For Each refDataRow As DataRow In refDataTable.Rows
            Dim sDiaClave As String = RTrim(refDataRow("DiaClave"))
            Dim sConsulta As New System.Text.StringBuilder
            sConsulta.AppendLine("IF EXISTS(SELECT Tabla FROM SincronizacionVendedor WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sDiaClave & "')")
            sConsulta.AppendLine("UPDATE SincronizacionVendedor SET FechaHoraSincronizacion = " & General.UniFechaSQL(fechaInicial) & " WHERE VendedorID = '" & VendedorID & "' AND Tabla = '" & sDiaClave & "'")
            sConsulta.AppendLine("ELSE")
            sConsulta.AppendLine("INSERT SincronizacionVendedor VALUES('" & VendedorID & "','" & sDiaClave & "'," & General.UniFechaSQL(fechaInicial) & ")")
            MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
        Next
    End Sub
End Class

Public Class SincronizacionTerminal
    'clase usada para el hilo que actualiza la tabla SincronizacionVendedor

    Enum eTipoActualizacion
        Ninguno = 0
        CargaConfiguracion = 1
        Actualizacion = 2
    End Enum

    Public Shared TipoActualizacion As eTipoActualizacion
    Public Shared Tablas As String
    Public Shared NumeroSerie As String
    Public Shared FechaIni As Date

    Public Shared Sub ActualizaSincronizacionTerminal()
        If TipoActualizacion = eTipoActualizacion.CargaConfiguracion Then
            ActualizaSincronizacionTerminal(Tablas, NumeroSerie)
        ElseIf TipoActualizacion = eTipoActualizacion.Actualizacion Then
            ActualizaSincronizacionTerminalPorNombre(Tablas, NumeroSerie)
        End If
        TipoActualizacion = eTipoActualizacion.Ninguno
        Tablas = String.Empty
        NumeroSerie = String.Empty
    End Sub

    Private Shared Sub ActualizaSincronizacionTerminal(ByVal TipoTablas As String, ByVal NumeroSerie As String)
        Dim refDataTable As New DataTable
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select Nombre from tabla where TipoBase in (" & TipoTablas & ") order by orden ", "Tabla")
        For Each refDataRow As DataRow In refDataTable.Rows
            Dim sNombreTabla As String = RTrim(refDataRow("Nombre"))
            Dim sConsulta As New System.Text.StringBuilder
            sConsulta.AppendLine("IF EXISTS(SELECT Tabla FROM SincronizacionTerminal WHERE NumeroSerie = '" & NumeroSerie & "' AND Tabla = '" & sNombreTabla & "')")
            sConsulta.AppendLine("UPDATE SincronizacionTerminal SET FechaHoraSincronizacion = GETDATE() WHERE NumeroSerie = '" & NumeroSerie & "' AND Tabla = '" & sNombreTabla & "'")
            sConsulta.AppendLine("ELSE")
            sConsulta.AppendLine("INSERT SincronizacionTerminal VALUES('" & NumeroSerie & "','" & sNombreTabla & "',GETDATE())")
            MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
        Next
    End Sub

    Private Shared Sub ActualizaSincronizacionTerminalPorNombre(ByVal Tablas As String, ByVal NumeroSerie As String)
        Dim refDataTable As New DataTable
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select Nombre from tabla where Nombre in ('" & Tablas & "') order by orden ", "Tabla")
        For Each refDataRow As DataRow In refDataTable.Rows
            Dim sNombreTabla As String = RTrim(refDataRow("Nombre"))
            Dim sConsulta As New System.Text.StringBuilder
            sConsulta.AppendLine("IF EXISTS(SELECT Tabla FROM SincronizacionTerminal WHERE NumeroSerie = '" & NumeroSerie & "' AND Tabla = '" & sNombreTabla & "')")
            sConsulta.AppendLine("UPDATE SincronizacionTerminal SET FechaHoraSincronizacion = GETDATE() WHERE NumeroSerie = '" & NumeroSerie & "' AND Tabla = '" & sNombreTabla & "'")
            sConsulta.AppendLine("ELSE")
            sConsulta.AppendLine("INSERT SincronizacionTerminal VALUES('" & NumeroSerie & "','" & sNombreTabla & "',GETDATE())")
            MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
        Next
    End Sub

End Class

'Public Class ArchivoSDF
'    Protected dFechaIni As Date
'    Protected dFechaFin As Date
'    Protected sNombreArchivo As String
'    Protected tTipoTablas As String

'    Public Property FechaIni() As Date
'        Get
'            Return dFechaIni
'        End Get
'        Set(ByVal value As Date)
'            dFechaIni = value
'        End Set
'    End Property

'    Public Property FechaFin() As Date
'        Get
'            Return dFechaFin
'        End Get
'        Set(ByVal value As Date)
'            dFechaFin = value
'        End Set
'    End Property

'    Public Property NombreArchivo() As String
'        Get
'            Return sNombreArchivo
'        End Get
'        Set(ByVal value As String)
'            sNombreArchivo = value
'        End Set
'    End Property

'    Public Property TipoTablas() As String
'        Get
'            Return tTipoTablas
'        End Get
'        Set(ByVal value As String)
'            tTipoTablas = value
'        End Set
'    End Property
'    Private Function ObtenerNombretipo(ByVal partTipoCampo As DBCentral.TiposCampos) As String
'        Dim sNombre As String = ""
'        Select Case partTipoCampo
'            Case DBCentral.TiposCampos.Bit
'                sNombre = "bit"
'            Case DBCentral.TiposCampos.Datetime
'                sNombre = "datetime"
'            Case DBCentral.TiposCampos.Int
'                sNombre = "int"
'            Case DBCentral.TiposCampos.Money
'                sNombre = "money"
'            Case DBCentral.TiposCampos.Ntext
'                sNombre = "ntext"
'            Case DBCentral.TiposCampos.Nvarchar
'                sNombre = "nvarchar"
'            Case DBCentral.TiposCampos.Real
'                sNombre = "real"
'            Case DBCentral.TiposCampos.Smallint
'                sNombre = "smallint"
'            Case DBCentral.TiposCampos.Image
'                sNombre = "image"
'            Case DBCentral.TiposCampos.Float
'                sNombre = "float"
'            Case DBCentral.TiposCampos.BigInt
'                sNombre = "bigint"
'            Case DBCentral.TiposCampos.Decimal_
'                sNombre = "numeric"
'        End Select
'        Return sNombre
'    End Function

'    'Public Function CrearArchivoSDF() As Boolean
'    '    'Try
'    '    ' Verificar que exista la base de datos
'    '    'If Not System.IO.Directory.Exists(General.sDirectorio) Then
'    '    '    System.IO.Directory.CreateDirectory(General.sDirectorio)
'    '    'End If
'    '    If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo) Then
'    '        'If System.IO.File.Exists(NombreArchivo) Then
'    '        Return True
'    '    End If
'    '    ' No existe, crear la base de datos, conectarse a SC para obtener la estructura de la BDD
'    '    Try


'    '        Dim SqlCeEngineSQL As New Data.SqlServerCe.SqlCeEngine("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
'    '        SqlCeEngineSQL.CreateDatabase()
'    '        SqlCeEngineSQL.Dispose()
'    '    Catch ex As Exception
'    '        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SINSDF", "ServiceCentral"))
'    '    End Try


'    '    Return True
'    '    'Catch ExcA As Data.SqlServerCe.SqlCeException
'    '    '    '            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
'    '    'Catch ExcB As Exception
'    '    '    '       MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
'    '    'End Try
'    '    Return False
'    'End Function

'    'Public Function CrearTablas() As Boolean
'    '    Dim conConexion As SqlCeConnection
'    '    Dim cmdComando As SqlCeCommand

'    '    ' Usar un DataSet para leer el contenido del archivo XML
'    '    Dim refDataTable As DataTable
'    '    Dim refDataRow As DataRow
'    '    Dim refDataTablaDet As DataTable
'    '    Dim refDataRowDet As DataRow
'    '    Dim sNombreTabla As String
'    '    ' Abrir una conexión a la base de datos
'    '    conConexion = New SqlCeConnection("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
'    '    'conConexion = New SqlCeConnection("Data Source = " & NombreArchivo)
'    '    conConexion.Open()

'    '    ' Crear un comando
'    '    cmdComando = conConexion.CreateCommand()
'    '    cmdComando.Connection = conConexion
'    '    ' Leer el archivo XML con el esquema
'    '    refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select TipoBase, TablaID, Nombre from tabla where TipoBase in (" & Me.TipoTablas & ")", "Tabla")
'    '    Dim sConsultaSQL As New System.Text.StringBuilder
'    '    sConsultaSQL.Append("SELECT Tabla.Nombre AS TablaNombre, Campo.Nombre AS CampoNombre, Campo.Tipo, Campo.Longitud, TablaCampo.Tipo AS TablaCampoTipo, TablaCampo.VARCodigo ")
'    '    sConsultaSQL.Append("FROM TablaCampo INNER JOIN Campo ON TablaCampo.CampoID = Campo.CampoID ")
'    '    sConsultaSQL.Append("INNER JOIN Tabla ON TablaCampo.TablaID = Tabla.TablaID WHERE Tabla.TipoBase in (" & Me.TipoTablas & ") ")
'    '    sConsultaSQL.Append("ORDER BY TablaCampo.TablaID, TablaCampo.Orden")
'    '    refDataTablaDet = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString, "Campos")

'    '    Dim j As Integer
'    '    Dim iNumCamposTabla As Short
'    '    Dim tTipoDato As DBCentral.TiposCampos
'    '    Dim sNombreCampo As String
'    '    Dim sLlavePrimaria As String
'    '    Dim tTipo As DBCentral.TiposTablasCampos = DBCentral.TiposTablasCampos.Nulos

'    '    j = 1
'    '    For Each refDataRow In refDataTable.Rows
'    '        Try
'    '            sNombreTabla = RTrim(refDataRow("Nombre"))
'    '            cmdComando.CommandText = "CREATE TABLE " & sNombreTabla & " ("
'    '            iNumCamposTabla = 0
'    '            sLlavePrimaria = ""
'    '            For Each refDataRowDet In refDataTablaDet.Rows
'    '                If refDataRowDet("TablaNombre").ToString = sNombreTabla Then
'    '                    sNombreCampo = refDataRowDet("CampoNombre").ToString
'    '                    tTipo = refDataRowDet("TablaCampoTipo").ToString
'    '                    cmdComando.CommandText &= sNombreCampo
'    '                    cmdComando.CommandText &= " "
'    '                    tTipoDato = refDataRowDet("Tipo").ToString
'    '                    cmdComando.CommandText &= ObtenerNombretipo(tTipoDato) & " "
'    '                    If tTipoDato = DBCentral.TiposCampos.Nvarchar Then
'    '                        cmdComando.CommandText &= "(" & refDataRowDet("Longitud").ToString & ") "
'    '                    ElseIf tTipoDato = DBCentral.TiposCampos.Decimal_ Then
'    '                        cmdComando.CommandText &= "(" & refDataRowDet("Longitud").ToString & ",0) "
'    '                    End If
'    '                    If tTipo = DBCentral.TiposTablasCampos.NoNulos Then
'    '                        cmdComando.CommandText &= "NOT NULL"
'    '                    End If
'    '                    cmdComando.CommandText &= ", "
'    '                    If tTipo = DBCentral.TiposTablasCampos.LlavePrimaria Or tTipo = DBCentral.TiposTablasCampos.LlavePrimariaForanea Then
'    '                        sLlavePrimaria &= sNombreCampo & ", "
'    '                    End If
'    '                    iNumCamposTabla += 1
'    '                End If
'    '            Next
'    '            If iNumCamposTabla > 0 Then
'    '                ' Si hay llave(s) primaria(s)
'    '                If sLlavePrimaria <> "" Then
'    '                    sLlavePrimaria = Mid(sLlavePrimaria, 1, Len(sLlavePrimaria) - 2)
'    '                    ' Agregarlas
'    '                    cmdComando.CommandText &= "CONSTRAINT PK_" & sNombreTabla & " PRIMARY KEY (" & sLlavePrimaria & ")"
'    '                Else
'    '                    ' Quitar la última coma
'    '                    cmdComando.CommandText = Mid(cmdComando.CommandText, 1, Len(cmdComando.CommandText) - 2)
'    '                End If
'    '                cmdComando.CommandText &= ")"

'    '                ' Ejecutar el comando
'    '                cmdComando.ExecuteNonQuery()

'    '            End If
'    '        Catch ExcA As SqlCeException
'    '            '                MsgBox(ExcA.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
'    '        Catch ExcB As System.Xml.XmlException
'    '            '               MsgBox(ExcB.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
'    '        Catch ExcC As Exception
'    '            '              MsgBox(ExcC.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
'    '        End Try
'    '        j += 1
'    '    Next
'    '    conConexion.Close()
'    '    conConexion.Dispose()
'    '    Return True
'    'End Function
'    'Public Sub CompactarBD()
'    '    Dim SqlCeEngineSQL As New Data.SqlServerCe.SqlCeEngine("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
'    '    SqlCeEngineSQL.Shrink()
'    '    SqlCeEngineSQL.Dispose()
'    'End Sub

'    'Public Sub CrearArchivoUltimaActualizacion(ByVal parsTiposBases As String)

'    '    Dim dt As DataTable
'    '    dt = MobileClient.ConexionSQL.RealizarConsulta("Select Distinct Nombre as I, convert(varchar(30),'1900-01-01T00:00:00',126) as F from Tabla where TipoBase in(" & parsTiposBases & ") ", "T")
'    '    Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), System.Text.Encoding.Unicode)
'    '    ' Escribir en el archivo XML
'    '    dt.DataSet.DataSetName = "ds"
'    '    dt.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
'    '    ' Cerrar el flujo XML
'    '    XmlTextWriterDicc.Close()
'    'End Sub

'    'Public Function RegresaArchivoUltimaActualizacion() As String
'    '    Dim stream As New System.IO.FileStream(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), IO.FileMode.Open)
'    '    Dim XmlTextReaderTablas As New System.Xml.XmlTextReader(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), stream)

'    '    ' Escribir en el archivo XML
'    '    XmlTextReaderTablas.WhitespaceHandling = System.Xml.WhitespaceHandling.None
'    '    'dsUltimosCambios.ReadXml(General.sDirectorio & "\" & NombreArchivo.Replace(".sdf", ".xml"))
'    '    '' Cerrar el flujo XML
'    '    'XmlTextWriterDicc.Close()
'    '    XmlTextReaderTablas.Read()
'    '    Dim s As String = "<ds>" & XmlTextReaderTablas.ReadInnerXml & "</ds>"
'    '    XmlTextReaderTablas.Close()
'    '    stream.Close()
'    '    Return s

'    'End Function

'    'Public Function LlenarTablas(ByVal parsDataSet As DataSet, ByVal parbRecienCreado As Boolean, ByVal parsExtension As String, Optional ByVal parbActualizacionCatalogos As Boolean = False) As Boolean
'    '    Dim conConexion As SqlCeConnection
'    '    ' / Cambios 08 Mayo 2006
'    '    conConexion = New SqlCeConnection("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
'    '    Dim refDataTable As DataTable
'    '    conConexion.Open()
'    '    ' Quitar las relaciones solo si la base de datos no ha sido recien creada
'    '    'If Not parbRecienCreado Then
'    '    '    ' Quitar las relaciones antes de actualizar las tablas
'    '    '    If Not EstablecerRelaciones(False, conConexion) Then
'    '    '        conConexion.Close()
'    '    '        conConexion.Dispose()
'    '    '        Return False
'    '    '    End If
'    '    'End If
'    '    Dim dsUltimosCambios As New DataSet
'    '    dsUltimosCambios.ReadXml(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"))
'    '    dsUltimosCambios.Tables("T").PrimaryKey = New DataColumn() {dsUltimosCambios.Tables("T").Columns("I")}
'    '    Dim i As Integer = 1
'    '    'Try
'    '    Dim ldtTransProdDetalle As New DataTable
'    '    Dim ldtCliCap As New DataTable
'    '    Dim ldtCadPro As New DataTable
'    '    Dim dsTablas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select distinct Nombre,Grupo from Tabla where TipoBase in(" & Me.TipoTablas & ")")
'    '    dsTablas.PrimaryKey = New DataColumn() {dsTablas.Columns("Nombre")}
'    '    Dim bProductoCarga As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("Select Top 1 ProductoCarga from ConHist where CONHistFechaInicio <= GETDATE() order by CONHistFechaInicio desc ")
'    '    For Each refDataTable In parsDataSet.Tables
'    '        'TODO: Revisar si hay otra forma de LlenarTabla
'    '        If Not (parbActualizacionCatalogos And refDataTable.Rows.Count <= 0) Then
'    '            Dim drGrupo As DataRow = dsTablas.Rows.Find(refDataTable.TableName)
'    '            LlenarTabla(refDataTable, conConexion, drGrupo("Grupo"), parbActualizacionCatalogos, bProductoCarga)
'    '            Dim dr As DataRow = dsUltimosCambios.Tables("T").Rows.Find(refDataTable.TableName)
'    '            dr("F") = Now.ToString("s")
'    '        End If
'    '        i += 1
'    '        refDataTable.Dispose()
'    '    Next
'    '    Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), System.Text.Encoding.Unicode)
'    '    ' Escribir en el archivo XML
'    '    dsUltimosCambios.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
'    '    ' Cerrar el flujo XML
'    '    XmlTextWriterDicc.Close()
'    '    parsDataSet.Dispose()

'    '    ' Poner las relaciones despues de actualizar las tablas
'    '    If parbRecienCreado Then
'    '        If Not EstablecerRelaciones(True, parsExtension, conConexion) Then
'    '            conConexion.Close()
'    '            conConexion.Dispose()
'    '            Return False
'    '        End If
'    '    End If
'    '    'Catch ex As Exception
'    '    '    MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenarTablas")
'    '    'End Try
'    '    conConexion.Close()
'    '    conConexion.Dispose()
'    '    Return True
'    'End Function

'    'Private Sub LlenarTabla(ByRef refparDataTable As DataTable, ByVal refConnectionSQL As SqlCeConnection, ByVal pariGrupo As Integer, ByVal parbBorrarInactivos As Boolean, ByVal parbProductosCarga As Boolean)
'    '    Dim dt As New DataTable
'    '    Dim da As New SqlCeDataAdapter("Select * from " & refparDataTable.TableName, refConnectionSQL)
'    '    Try
'    '        If pariGrupo = 2 OrElse (parbProductosCarga AndAlso pariGrupo = 1 AndAlso refparDataTable.TableName.Contains("Producto")) Then
'    '            Dim cmdComando As SqlCeCommand = refConnectionSQL.CreateCommand()
'    '            cmdComando.Connection = refConnectionSQL
'    '            cmdComando.CommandText = "Delete from " & refparDataTable.TableName
'    '            cmdComando.ExecuteNonQuery()
'    '        End If
'    '        If refparDataTable.Rows.Count <= 0 Then Exit Sub
'    '        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
'    '        da.Fill(dt)

'    '        Dim sCampos As String = String.Empty
'    '        Dim sParametros As String = String.Empty
'    '        Dim sAsignaciones As String = String.Empty
'    '        Dim sComparaLlavesPrimarias As String = String.Empty

'    '        Dim aParametrosInsert(refparDataTable.Columns.Count - 1) As SqlCeParameter
'    '        Dim aParametrosUpdate(refparDataTable.Columns.Count - 1) As SqlCeParameter
'    '        Dim aParameterLlavesUpdate(dt.PrimaryKey.Length - 1) As SqlCeParameter
'    '        Dim aParameterLlavesDelete(dt.PrimaryKey.Length - 1) As SqlCeParameter

'    '        Dim k As System.Type
'    '        Dim sLlavePrimaria As String
'    '        For i As Integer = 0 To dt.PrimaryKey.Length - 1
'    '            sLlavePrimaria = dt.PrimaryKey(i).ColumnName
'    '            sComparaLlavesPrimarias &= sLlavePrimaria & "=" & "@Original_" & sLlavePrimaria
'    '            If i < dt.PrimaryKey.Length - 1 Then
'    '                sComparaLlavesPrimarias &= " AND "
'    '            End If
'    '            k = refparDataTable.Columns(i).DataType
'    '            aParameterLlavesUpdate(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
'    '            aParameterLlavesDelete(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
'    '        Next

'    '        Dim sNombreCampo As String
'    '        For j As Integer = 0 To refparDataTable.Columns.Count - 1
'    '            sNombreCampo = refparDataTable.Columns(j).ColumnName
'    '            sCampos &= sNombreCampo
'    '            sParametros &= "@" & sNombreCampo
'    '            sAsignaciones &= sNombreCampo & "=" & "@" & sNombreCampo
'    '            k = refparDataTable.Columns(j).DataType
'    '            aParametrosInsert(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
'    '            aParametrosUpdate(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
'    '            If j < refparDataTable.Columns.Count - 1 Then
'    '                sCampos &= ","
'    '                sParametros &= ","
'    '                sAsignaciones &= ","
'    '            End If
'    '        Next

'    '        Dim insCmd As SqlCeCommand = New SqlCeCommand("insert into " & refparDataTable.TableName & "(" & sCampos & ")  values(" & sParametros & ")", refConnectionSQL)
'    '        insCmd.Parameters.AddRange(aParametrosInsert)
'    '        da.InsertCommand = insCmd

'    '        Dim UpdCmd As SqlCeCommand = New SqlCeCommand("UPDATE " & refparDataTable.TableName & " SET " & sAsignaciones & " WHERE (" & sComparaLlavesPrimarias & ")", refConnectionSQL)
'    '        UpdCmd.Parameters.AddRange(aParametrosUpdate)
'    '        UpdCmd.Parameters.AddRange(aParameterLlavesUpdate)
'    '        da.UpdateCommand = UpdCmd

'    '        'Dim DelCmd As SqlCeCommand = New SqlCeCommand("DELETE FROM " & refparDataTable.TableName & " WHERE (" & sComparaLlavesPrimarias & ")", refConnectionSQL)
'    '        'DelCmd.Parameters.AddRange(aParameterLlavesDelete)
'    '        'da.DeleteCommand = DelCmd
'    '        'da.ContinueUpdateOnError = True
'    '        dt.Merge(refparDataTable)
'    '        da.Update(dt)

'    '        If parbBorrarInactivos Then
'    '            Dim sFiltroBorrar As String = String.Empty
'    '            If dt.Columns.Contains("TipoEstado") Then
'    '                sFiltroBorrar &= " TipoEstado=0 "
'    '            ElseIf dt.Columns.Contains("Estado") Then
'    '                sFiltroBorrar &= " Estado=0 "
'    '            ElseIf dt.Columns.Contains("TipoFase") Then
'    '                sFiltroBorrar &= " TipoFase<>1 "
'    '            End If
'    '            If dt.Columns.Contains("Baja") Then
'    '                If sFiltroBorrar <> String.Empty Then
'    '                    sFiltroBorrar &= " OR "
'    '                End If
'    '                sFiltroBorrar &= " Baja=1 "
'    '            End If
'    '            If sFiltroBorrar <> String.Empty Then
'    '                Dim BorrarCmd As New SqlCeCommand("Delete FROM " & refparDataTable.TableName & " WHERE " & sFiltroBorrar, refConnectionSQL)
'    '                BorrarCmd.ExecuteNonQuery()
'    '            Else

'    '            End If
'    '        End If

'    '        insCmd.Dispose()
'    '        UpdCmd.Dispose()
'    '        'DelCmd.Dispose()
'    '        dt.Dispose()
'    '        'If Not IsNothing(dtEliminados) Then dtEliminados.Dispose()
'    '        da.Dispose()


'    '        'Catch ex As SqlCeException
'    '        '    MsgBox(ex.Message)
'    '    Catch ex1 As Exception
'    '        Throw New System.Web.Services.Protocols.SoapException(ex1.Message, New System.Xml.XmlQualifiedName("LLENARTABLA", "ServiceCentral"))
'    '    End Try
'    'End Sub
'    'Public Function EstablecerRelaciones(ByVal parbEstablecer As Boolean, ByVal parsExtension As String, ByRef refparoConexion As SqlCeConnection) As Boolean
'    '    Dim DataTableActual As New DataTable
'    '    Dim sConsultaSQL As New System.Text.StringBuilder
'    '    Dim cmdComando As SqlCeCommand
'    '    cmdComando = refparoConexion.CreateCommand()
'    '    ' Los comandos se aplican sobre la base de datos actual
'    '    cmdComando.Connection = refparoConexion

'    '    ' Recuperar las relaciones que aplican para el tipo de tablas actual
'    '    sConsultaSQL.Append("SELECT Relacion.RelacionId, Relacion.Nombre, Tabla.Nombre AS TablaNombre, Tabla_1.Nombre AS TablaNombreForanea,EliminarCascada FROM Relacion ")
'    '    sConsultaSQL.Append("INNER JOIN Tabla ON Relacion.TablaId = Tabla.TablaID ")
'    '    sConsultaSQL.Append("INNER JOIN Tabla Tabla_1 ON Relacion.TablaIdForanea = Tabla_1.TablaID ")
'    '    sConsultaSQL.Append("WHERE (Tabla.TipoBase in (" & Me.TipoTablas & ")) ")
'    '    sConsultaSQL.Append("ORDER BY Relacion.Nombre")
'    '    DataTableActual = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)
'    '    ' Recuperar los datos
'    '    Dim i As Integer = 1
'    '    Dim refDataRow As DataRow
'    '    Dim sAvance As String
'    '    Dim sRelacionId As String
'    '    Dim sLlaveForanea As String = ""
'    '    Dim sLlavePrimaria As String = ""

'    '    Dim oArchivoTexto As New IO.StreamWriter(ServicesCentral.Configuracion.Directorio & "\ErroresRelaciones_" & parsExtension & ".txt", False)

'    '    Dim bHaHabidoErrores As Boolean = False

'    '    For Each refDataRow In DataTableActual.Rows
'    '        ' Para cada relacion, buscar su detalle
'    '        With refDataRow
'    '            sAvance = .Item("Nombre")
'    '            sRelacionId = .Item("RelacionId")
'    '            If parbEstablecer Then
'    '                ObtenerListaLlaves(sRelacionId, sLlaveForanea, sLlavePrimaria)
'    '                ' Crear el comando
'    '                cmdComando.CommandText = "ALTER TABLE " & .Item("TablaNombre") & " "
'    '                cmdComando.CommandText &= "ADD CONSTRAINT " & sAvance & " FOREIGN KEY (" & sLlaveForanea & ") "
'    '                cmdComando.CommandText &= "REFERENCES " & .Item("TablaNombreForanea") & " (" & sLlavePrimaria & ") "
'    '                If .Item("EliminarCascada") Then
'    '                    cmdComando.CommandText &= " ON DELETE CASCADE"
'    '                End If
'    '            Else
'    '                ' Crear el comando
'    '                cmdComando.CommandText = "ALTER TABLE " & .Item("TablaNombre") & " "
'    '                cmdComando.CommandText &= "DROP CONSTRAINT " & sAvance
'    '            End If
'    '            Try
'    '                ' Ejecutar el comando
'    '                cmdComando.ExecuteNonQuery()
'    '            Catch ExcA As SqlCeException
'    '                If parbEstablecer Then
'    '                    oArchivoTexto.WriteLine(ExcA.Message & oArchivoTexto.NewLine & cmdComando.CommandText & oArchivoTexto.NewLine)
'    '                    bHaHabidoErrores = True
'    '                End If
'    '            Catch ExcB As Exception
'    '                If parbEstablecer Then
'    '                    oArchivoTexto.WriteLine(ExcB.Message & oArchivoTexto.NewLine & cmdComando.CommandText & oArchivoTexto.NewLine)
'    '                    bHaHabidoErrores = True
'    '                End If
'    '            End Try
'    '        End With
'    '        i += 1
'    '    Next
'    '    oArchivoTexto.Close()
'    '    cmdComando.Dispose()
'    '    Return True
'    'End Function

'    Private Sub ObtenerListaLlaves(ByVal parsRelacionId As String, ByRef refparsLlaveForanea As String, ByRef refparsLlavePrimaria As String)
'        Dim sConsultaSQL As New System.Text.StringBuilder
'        sConsultaSQL.Append("SELECT RelacionID,(Select Nombre from Campo Where Campo.CampoID=relacioncampo.CampoIDPrimario) as CampoNombrePrimario ,(Select Nombre from Campo Where Campo.CampoID=relacioncampo.CampoIDForaneo) as CampoNombreForaneo FROM RelacionCampo ")
'        sConsultaSQL.Append("WHERE RelacionCampo.RelacionId='" & parsRelacionId & "' ")
'        sConsultaSQL.Append("ORDER BY RelacionCampo.Orden")
'        Dim DataTableActual As DataTable = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)

'        Dim refDataRow As DataRow
'        refparsLlaveForanea = ""
'        refparsLlavePrimaria = ""
'        For Each refDataRow In DataTableActual.Rows
'            With refDataRow
'                refparsLlaveForanea &= .Item("CampoNombreForaneo") & ","
'                refparsLlavePrimaria &= .Item("CampoNombrePrimario") & ","
'            End With
'        Next
'        ' Quitar la ultima coma
'        If refparsLlaveForanea <> "" Then
'            refparsLlaveForanea = Mid(refparsLlaveForanea, 1, Len(refparsLlaveForanea) - 1)
'        End If
'        If refparsLlavePrimaria <> "" Then
'            refparsLlavePrimaria = Mid(refparsLlavePrimaria, 1, Len(refparsLlavePrimaria) - 1)
'        End If
'    End Sub
'    Private Function RegresaTipoDatoSQL(ByVal parTipo As System.Type) As System.Data.SqlDbType
'        Select Case parTipo.Name
'            Case "String"
'                Return SqlDbType.NVarChar
'            Case "Boolean"
'                Return SqlDbType.Bit
'            Case "DateTime"
'                Return SqlDbType.DateTime
'            Case "Int32"
'                Return SqlDbType.Int
'            Case "Int16"
'                Return SqlDbType.SmallInt
'            Case "Single"
'                Return SqlDbType.Real
'            Case "Double"
'                Return SqlDbType.Float
'            Case "Byte[]"
'                Return SqlDbType.Image
'            Case Else
'                Return 0
'        End Select
'    End Function

'End Class

Public Class ArchivoSQLite
    Protected dFechaIni As Date
    Protected dFechaFin As Date
    Protected sNombreArchivo As String
    Protected tTipoTablas As String

    Public Property FechaIni() As Date
        Get
            Return dFechaIni
        End Get
        Set(ByVal value As Date)
            dFechaIni = value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return dFechaFin
        End Get
        Set(ByVal value As Date)
            dFechaFin = value
        End Set
    End Property

    Public Property NombreArchivo() As String
        Get
            Return sNombreArchivo
        End Get
        Set(ByVal value As String)
            sNombreArchivo = value
        End Set
    End Property

    Public Property TipoTablas() As String
        Get
            Return tTipoTablas
        End Get
        Set(ByVal value As String)
            tTipoTablas = value
        End Set
    End Property
    Private Function ObtenerNombretipo(ByVal partTipoCampo As DBCentral.TiposCampos) As String
        Dim sNombre As String = ""
        Select Case partTipoCampo
            Case DBCentral.TiposCampos.Bit
                sNombre = "bit"
            Case DBCentral.TiposCampos.Datetime
                sNombre = "datetime"
            Case DBCentral.TiposCampos.Int
                sNombre = "int"
            Case DBCentral.TiposCampos.Money
                sNombre = "money"
            Case DBCentral.TiposCampos.Ntext
                sNombre = "ntext"
            Case DBCentral.TiposCampos.Nvarchar
                sNombre = "nvarchar"
            Case DBCentral.TiposCampos.Real
                sNombre = "real"
            Case DBCentral.TiposCampos.Smallint
                sNombre = "smallint"
            Case DBCentral.TiposCampos.Image
                sNombre = "image"
            Case DBCentral.TiposCampos.Float
                sNombre = "float"
        End Select
        Return sNombre
    End Function

    'Ady
    Public Function CrearArchivoSQLite() As Boolean
        
        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo) Then
            Return True
        End If
        Try
            If Not System.IO.Directory.Exists(ServicesCentral.Configuracion.Directorio) Then
                Throw New Exception("Directorio " & ServicesCentral.Configuracion.Directorio & " inexistente")
            End If
            SQLiteConnection.CreateFile(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
        Catch ex As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SINSDF", "ServiceCentral"))
        End Try

        Return True
    End Function

    'Ady
    Public Function CrearTablas(Optional ByVal sTablasIncluidas As String = "", Optional ByRef dsDatos As DataSet = Nothing) As Boolean
        Dim conConexion As SQLiteConnection
        Dim cmdComando As SQLiteCommand

        ' Usar un DataSet para leer el contenido del archivo XML
        Dim refDataTable As DataTable
        Dim refDataRow As DataRow
        Dim refDataTablaDet As DataTable
        Dim refDataRowDet As DataRow
        Dim sNombreTabla As String
        ' Abrir una conexión a la base de datos
        conConexion = New SQLiteConnection("Data Source=" & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo & ";Version=3;foreign keys=true;")
        conConexion.Open()

        ' Crear un comando
        cmdComando = New SQLiteCommand(conConexion)
        cmdComando.Connection = conConexion
        ' Leer el archivo XML con el esquema
        If sTablasIncluidas.Equals("") Then
            refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select TipoBase, TablaID, Nombre from tabla where TipoBase in (" & Me.TipoTablas & ") order by Orden ", "Tabla")
        Else
            refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select TipoBase, TablaID, Nombre from tabla where TipoBase in (" & Me.TipoTablas & ") and Nombre in(" & sTablasIncluidas.Replace("''", "'") & ") order by Orden ", "Tabla")
        End If
        Dim sConsultaSQL As New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT Tabla.Nombre AS TablaNombre, Campo.Nombre AS CampoNombre, Campo.Tipo, Campo.Longitud, TablaCampo.Tipo AS TablaCampoTipo ")
        sConsultaSQL.Append("FROM TablaCampo INNER JOIN Campo ON TablaCampo.CampoID = Campo.CampoID ")
        sConsultaSQL.Append("INNER JOIN Tabla ON TablaCampo.TablaID = Tabla.TablaID WHERE Tabla.TipoBase in (" & Me.TipoTablas & ") ")
        If Not sTablasIncluidas.Equals("") Then
            sConsultaSQL.Append(" and Tabla.Nombre in(" & sTablasIncluidas.Replace("''", "'") & ")")
        End If
        sConsultaSQL.Append("ORDER BY TablaCampo.TablaID, TablaCampo.Orden")
        refDataTablaDet = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString, "Campos")

        ' Recuperar las relaciones que aplican para el tipo de tablas actual
        sConsultaSQL = New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT Relacion.RelacionId, Relacion.Nombre, Tabla.Nombre AS TablaNombre, Tabla_1.Nombre AS TablaNombreForanea,EliminarCascada FROM Relacion ")
        sConsultaSQL.Append("INNER JOIN Tabla ON Relacion.TablaId = Tabla.TablaID ")
        sConsultaSQL.Append("INNER JOIN Tabla Tabla_1 ON Relacion.TablaIdForanea = Tabla_1.TablaID ")
        sConsultaSQL.Append("WHERE (Tabla.TipoBase in  (" & Me.TipoTablas & ")) ")
        If Not sTablasIncluidas.Equals("") Then
            sConsultaSQL.Append(" and Tabla.Nombre in(" & sTablasIncluidas.Replace("''", "'") & ") and Tabla_1.Nombre in(" & sTablasIncluidas.Replace("''", "'") & ") ")
        End If
        sConsultaSQL.Append("ORDER BY Relacion.Nombre")
        Dim dtRelaciones As DataTable = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)

        Dim j As Integer
        Dim iNumCamposTabla As Short
        Dim tTipoDato As DBCentral.TiposCampos
        Dim sNombreCampo As String
        Dim sLlavePrimaria As String
        Dim tTipo As DBCentral.TiposTablasCampos = DBCentral.TiposTablasCampos.Nulos
        Dim sLlaveForanea As String = String.Empty
        j = 1
        For Each refDataRow In refDataTable.Rows
            Try
                sNombreTabla = RTrim(refDataRow("Nombre"))
                If Not IsNothing(dsDatos) Then
                    If Not dsDatos.Tables.Contains(sNombreTabla) Then Continue For
                    If dsDatos.Tables(sNombreTabla).Rows.Count <= 0 Then Continue For
                End If
                cmdComando.CommandText = "CREATE TABLE " & sNombreTabla & " ("
                iNumCamposTabla = 0
                sLlavePrimaria = ""
                For Each refDataRowDet In refDataTablaDet.Rows
                    If refDataRowDet("TablaNombre").ToString = sNombreTabla Then
                        sNombreCampo = refDataRowDet("CampoNombre").ToString
                        If Not IsNothing(dsDatos) Then
                            If Not dsDatos.Tables(sNombreTabla).Columns.Contains(sNombreCampo) Then Continue For
                        End If
                        tTipo = refDataRowDet("TablaCampoTipo").ToString
                        cmdComando.CommandText &= sNombreCampo
                        cmdComando.CommandText &= " "
                        tTipoDato = refDataRowDet("Tipo").ToString
                        cmdComando.CommandText &= ObtenerNombretipo(tTipoDato) & " "
                        If tTipoDato = DBCentral.TiposCampos.Nvarchar Then
                            cmdComando.CommandText &= "(" & refDataRowDet("Longitud").ToString & ") "
                        End If
                        If tTipo = DBCentral.TiposTablasCampos.NoNulos Then
                            cmdComando.CommandText &= "NOT NULL"
                        End If
                        cmdComando.CommandText &= ", "
                        If tTipo = DBCentral.TiposTablasCampos.LlavePrimaria Or tTipo = DBCentral.TiposTablasCampos.LlavePrimariaForanea Then
                            sLlavePrimaria &= sNombreCampo & ", "
                        End If
                        iNumCamposTabla += 1
                    End If
                Next


                If iNumCamposTabla > 0 Then
                    ' Si hay llave(s) primaria(s)
                    If sLlavePrimaria <> "" Then
                        If IsNothing(dsDatos) Then 'Las relaciones se crean solo si la tabla no es creada para envío parcial
                            sLlavePrimaria = Mid(sLlavePrimaria, 1, Len(sLlavePrimaria) - 2)
                            ' Agregarlas
                            cmdComando.CommandText &= "CONSTRAINT PK_" & sNombreTabla & " PRIMARY KEY (" & sLlavePrimaria & ")"

                            Dim drRelaciones() As DataRow = dtRelaciones.Select("TablaNombre='" & sNombreTabla & "'")
                            For Each drRelacion As DataRow In drRelaciones
                                ObtenerListaLlaves(drRelacion("RelacionID"), sLlaveForanea, sLlavePrimaria)
                                cmdComando.CommandText &= " FOREIGN KEY (" & sLlaveForanea & ") REFERENCES " & drRelacion("TablaNombreForanea") & "(" & sLlavePrimaria & ") "
                                If drRelacion.Item("EliminarCascada") Then
                                    cmdComando.CommandText &= " ON DELETE CASCADE"
                                End If
                            Next
                        Else
                            ' Quitar la última coma
                            cmdComando.CommandText = Mid(cmdComando.CommandText, 1, Len(cmdComando.CommandText) - 2)
                        End If
                    Else
                        ' Quitar la última coma
                        cmdComando.CommandText = Mid(cmdComando.CommandText, 1, Len(cmdComando.CommandText) - 2)
                    End If
                    cmdComando.CommandText &= ")"

                    ' Ejecutar el comando
                    cmdComando.ExecuteNonQuery()
                End If

            Catch ExcA As SQLiteException
                '                MsgBox(ExcA.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            Catch ExcB As System.Xml.XmlException
                '               MsgBox(ExcB.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            Catch ExcC As Exception
                '              MsgBox(ExcC.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            End Try
            j += 1
        Next
        cmdComando.Dispose()
        conConexion.Close()
        conConexion.Dispose()
        Return True
    End Function
    'Public Sub CompactarBD()
    '    Dim SqlCeEngineSQL As New Data.SqlServerCe.SqlCeEngine("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
    '    SqlCeEngineSQL.Shrink()
    '    SqlCeEngineSQL.Dispose()
    'End Sub

    'Ady
    Public Sub CrearArchivoUltimaActualizacion(ByVal parsTiposBases As String)

        Dim dt As DataTable
        dt = MobileClient.ConexionSQL.RealizarConsulta("Select Distinct Nombre as I, convert(varchar(30),'1900-01-01T00:00:00',127) as F from Tabla where TipoBase in(" & parsTiposBases & ") ", "T")
        Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".db", ".xml"), System.Text.Encoding.UTF8)
        ' Escribir en el archivo XML
        'dt.DataSet.DataSetName = "ds"
        dt.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
        ' Cerrar el flujo XML
        XmlTextWriterDicc.Close()
    End Sub

    Public Function RegresaArchivoUltimaActualizacion() As String
        Dim stream As New System.IO.FileStream(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".db", ".xml"), IO.FileMode.Open)
        Dim XmlTextReaderTablas As New System.Xml.XmlTextReader(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".db", ".xml"), stream)

        ' Escribir en el archivo XML
        XmlTextReaderTablas.WhitespaceHandling = System.Xml.WhitespaceHandling.None
        'dsUltimosCambios.ReadXml(General.sDirectorio & "\" & NombreArchivo.Replace(".sdf", ".xml"))
        '' Cerrar el flujo XML
        'XmlTextWriterDicc.Close()
        XmlTextReaderTablas.Read()
        Dim s As String = "<ds>" & XmlTextReaderTablas.ReadInnerXml & "</ds>"
        XmlTextReaderTablas.Close()
        stream.Close()
        Return s

    End Function

    Public Function ObtenerDataSet_BDSQLite(ByVal parsArchivoSQLite As String) As DataSet
        Dim conConexion As SQLiteConnection
        ' Abrir una conexión a la base de datos
        Dim tablaActual As String = ""
        Dim dsCaptura As DataSet = New DataSet
        Dim dsTablas As New DataSet
        Dim tran As SQLiteTransaction
        Try
            conConexion = New SQLiteConnection("Data Source=" & parsArchivoSQLite & ";version=3;")

            conConexion.Open()
            tran = conConexion.BeginTransaction
            Dim tallerId As String = MobileClient.ConexionSQLite.RealizarConsultaString("select TallerId from Taller", conConexion)

            MobileClient.ConexionSQLite.RealizarConsultaDataSet("select name from sqlite_master where type = 'table'", conConexion, dsTablas, "Tablas")
            Dim dtTablas As DataTable = dsTablas.Tables("Tablas")
            If (dtTablas.Select("name = 'Folio'").Length > 0) Then
                tablaActual = "FolioTaller"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 FolioId, TallerId, Usados, MFechaHora, MUsuarioId from FolioTaller", "FolioTaller", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select FolioId, '" + tallerId + "' as TallerId, Usados, strftime('%Y-%m-%dT%H:%M:%f', MFechaHora) as MFechaHora, MUsuarioId FROM Folio where Enviado=0 or Enviado is null", conConexion, dsCaptura, "FolioTaller")
            End If
            If (dtTablas.Select("name = 'Inventario'").Length > 0) Then
                tablaActual = "InventarioTaller"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from InventarioTaller", "InventarioTaller", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select '" + tallerId + "' as TallerId, ArticuloId, Existencia, strftime('%Y-%m-%dT%H:%M:%f', MFechaHora) as MFechaHora, MUsuarioId FROM Inventario where Enviado=0 or Enviado is null", conConexion, dsCaptura, "InventarioTaller")
            End If
            If (dtTablas.Select("name = 'OrdenTrabajo'").Length > 0) Then
                tablaActual = "OrdenTrabajo"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from OrdenTrabajo", "OrdenTrabajo", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select OrdenId, '" + tallerId + "' as TallerId, AgenteId, ClienteId, VinId, Folio, FechaIni, FechaFin, Fase, Kilometraje, strftime('%Y-%m-%dT%H:%M:%f', MFechaHora) as MFechaHora, MUsuarioId from OrdenTrabajo where (Enviado=0 or Enviado is null)", conConexion, dsCaptura, "OrdenTrabajo")
                If (dtTablas.Select("name = 'ODTDetalle'").Length > 0) Then
                    tablaActual = "ODTDetalle"
                    MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from ODTDetalle", "ODTDetalle", dsCaptura)
                    MobileClient.ConexionSQLite.RealizarConsultaDataSet("select ODTDetalle.OrdenID, ArticuloId, Cantidad, Partida, strftime('%Y-%m-%dT%H:%M:%f', ODTDetalle.MFechaHora) as MFechaHora, ODTDetalle.MUsuarioId from ODTDetalle inner join OrdenTrabajo on ODTDetalle.OrdenId = OrdenTrabajo.OrdenId where OrdenTrabajo.Enviado=0 or OrdenTrabajo.Enviado is null", conConexion, dsCaptura, "ODTDetalle")
                End If
            End If
            If (dtTablas.Select("name = 'Recarga'").Length > 0) Then
                tablaActual = "Recarga"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from Recarga", "Recarga", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select RecargaId, '" + tallerId + "' as TallerId, AgenteId, Folio, FechaSolicitud, FechaSurtido, Fase, strftime('%Y-%m-%dT%H:%M:%f', MFechaHora) as MFechaHora, MUsuarioId from Recarga where (Enviado=0 or Enviado is null)", conConexion, dsCaptura, "Recarga")

                tablaActual = "RECDetalle"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 DetalleId, RecargaId, ArticuloId, ArticuloDesc, Cantidad, Partida, convert(varchar(32), '') as Imagen, MFechaHora, MUsuarioId from RECDetalle", "RECDetalle", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select DetalleId, RECDetalle.RecargaId, ArticuloId, ArticuloDesc, Cantidad, Partida, Imagen, strftime('%Y-%m-%dT%H:%M:%f', RECDetalle.MFechaHora) as MFechaHora, RECDetalle.MUsuarioId from RECDetalle inner join Recarga on RECDetalle.RecargaId = Recarga.RecargaId where Recarga.Enviado=0 or Recarga.Enviado is null", conConexion, dsCaptura, "RECDetalle")
            End If
            If (dtTablas.Select("name = 'Devolucion'").Length > 0) Then
                tablaActual = "Devolucion"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from Devolucion", "Devolucion", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select DevolucionId, '" + tallerId + "' as TallerId, AgenteId, Folio, Fecha, Fase, strftime('%Y-%m-%dT%H:%M:%f', MFechaHora) as MFechaHora, MUsuarioId from Devolucion where (Enviado=0 or Enviado is null)", conConexion, dsCaptura, "Devolucion")
                tablaActual = "DEVDetalle"
                MobileClient.ConexionSQL.CrearEstructuraTabla("select top 0 * from DEVDetalle", "DEVDetalle", dsCaptura)
                MobileClient.ConexionSQLite.RealizarConsultaDataSet("select DEVDetalle.DevolucionId, ArticuloId, Cantidad, Partida, strftime('%Y-%m-%dT%H:%M:%f', DEVDetalle.MFechaHora) as MFechaHora, DEVDetalle.MUsuarioId from DEVDetalle inner join Devolucion on DEVDetalle.DevolucionId = Devolucion.DevolucionId where Devolucion.Enviado=0 or Devolucion.Enviado is null", conConexion, dsCaptura, "DEVDetalle")
            End If

            tran.Commit()
            dsTablas.Dispose()
            conConexion.Close()
            conConexion.Dispose()
            Return dsCaptura
        Catch ex As Exception
            If conConexion.State = ConnectionState.Open Then
                If Not IsNothing(dsTablas) Then
                    dsTablas.Dispose()
                End If
                If Not IsNothing(dsCaptura) Then
                    dsCaptura.Dispose()
                End If
                If Not IsNothing(tran) Then
                    tran.Rollback()
                End If
                conConexion.Close()
                conConexion.Dispose()
            End If
            Throw New Exception("Crear DataSet tabla '" + tablaActual + "' " + ex.Message)
        End Try

        Return Nothing
    End Function

    'Ady
    Public Function LlenarTablas(ByVal parsDataSet As DataSet, Optional ByVal parbActualizacionCatalogos As Boolean = False, Optional ByVal parbActualizarFechaUltCambio As Boolean = True) As Boolean
        Dim sTabla As String = ""
        Dim sPuntoError As String = ""
        Try
            Dim conConexion As SQLiteConnection
            Dim cmdComando As SQLiteCommand
            ' Abrir una conexión a la base de datos
            conConexion = New SQLiteConnection("Data Source=" & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo & ";version=3;")
            Dim refDataTable As DataTable
            conConexion.Open()

            Dim dsUltimosCambios As New DataSet
            If parbActualizarFechaUltCambio Then
                dsUltimosCambios.ReadXml(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".db", ".xml"))
                dsUltimosCambios.Tables("T").PrimaryKey = New DataColumn() {dsUltimosCambios.Tables("T").Columns("I")}
            End If

            Dim i As Integer = 1

            Dim dsTablas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select distinct Nombre from Tabla where TipoBase in(" & Me.TipoTablas & ") ")
            dsTablas.PrimaryKey = New DataColumn() {dsTablas.Columns("Nombre")}
            For Each refDataTable In parsDataSet.Tables
                sTabla = refDataTable.TableName
                'TODO: Revisar si hay otra forma de LlenarTabla
                If Not (parbActualizacionCatalogos And refDataTable.Rows.Count <= 0) Then
                    'Dim drGrupo As DataRow = dsTablas.Rows.Find(refDataTable.TableName)
                    sPuntoError = "Antes de Llenar"
                    LlenarTabla(refDataTable, conConexion)
                    sPuntoError = "despues de Llenar"
                    If parbActualizarFechaUltCambio Then
                        sPuntoError = "actualizar fecha ult cambio"
                        Dim dr As DataRow = dsUltimosCambios.Tables("T").Rows.Find(refDataTable.TableName)
                        dr("F") = Now.ToString("yyyy-MM-ddThh:mm:ss.mmmZ")
                    End If
                    sPuntoError = "termino de actualizar"
                End If
                i += 1
                refDataTable.Dispose()
            Next
            sPuntoError = "terminamos de llenar tablas"
            ' Escribir en el archivo XML
            If parbActualizarFechaUltCambio Then
                Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".db", ".xml"), System.Text.Encoding.UTF8)

                dsUltimosCambios.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
                ' Cerrar el flujo XML
                XmlTextWriterDicc.Close()
            End If

            parsDataSet.Dispose()

            conConexion.Close()
            conConexion.Dispose()
            Return True
        Catch ex1 As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex1.Message + "-" + sTabla + "-" + sPuntoError, New System.Xml.XmlQualifiedName("LLENARTABLAS", "ServiceCentral"))
        End Try

        Return False

    End Function

    'Ady
    Private Sub LlenarTabla(ByRef refparDataTable As DataTable, ByVal refConnectionSQLite As SQLiteConnection) ', ByVal adaptarEstructura As Boolean)

        Dim puntoFallo As String = ""
        Try
            puntoFallo = "usando transaccion"
            Using tran As SQLiteTransaction = refConnectionSQLite.BeginTransaction
                puntoFallo = "iniciando el comando"
                Using cmd As SQLiteCommand = New SQLiteCommand(refConnectionSQLite)
                    puntoFallo = "limpiando la tabla"
                    Dim cmdLimpiarTabla As SQLiteCommand = New SQLiteCommand("Delete from " & refparDataTable.TableName, refConnectionSQLite)

                    cmdLimpiarTabla.ExecuteNonQuery()
                    cmdLimpiarTabla.Dispose()
                    If refparDataTable.Rows.Count <= 0 Then Exit Sub

                    Dim sCampos As String = String.Empty
                    Dim sParametros As String = String.Empty
                    puntoFallo = "llenando los parámetros"
                    Dim aParametros(refparDataTable.Columns.Count - 1) As SQLiteParameter

                    Dim sNombreCampo As String
                    For j As Integer = 0 To refparDataTable.Columns.Count - 1
                        sNombreCampo = refparDataTable.Columns(j).ColumnName
                        puntoFallo = "campo:" + sNombreCampo
                        sCampos &= sNombreCampo
                        sParametros &= "?"
                        'k = refparDataTable.Columns(j).DataType
                        aParametros(j) = New SQLiteParameter(sNombreCampo, DbType.Object, sNombreCampo)
                        If j < refparDataTable.Columns.Count - 1 Then
                            sCampos &= ","
                            sParametros &= ","
                        End If
                    Next

                    puntoFallo = "haciendo el insert"
                    cmd.CommandText = "INSERT INTO " & refparDataTable.TableName & "(" & sCampos & ") VALUES(" & sParametros & ")"
                    puntoFallo = "agregando los parámetros"
                    cmd.Parameters.AddRange(aParametros)

                    For Each fila As DataRow In refparDataTable.Rows
                        For Each sParam As SQLiteParameter In cmd.Parameters
                            sParam.Value = fila(sParam.ParameterName)
                        Next
                        cmd.ExecuteNonQuery()
                    Next
                    cmd.Dispose()
                End Using
                tran.Commit()
            End Using
        Catch ex1 As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex1.Message + ":" + puntoFallo, New System.Xml.XmlQualifiedName("LLENARTABLA", "ServiceCentral"))
        End Try
    End Sub
    Public Function EstablecerRelaciones(ByVal parbEstablecer As Boolean, ByVal parsNombreArchivo As String, ByRef refparoConexion As SQLiteConnection) As Boolean
        Dim DataTableActual As New DataTable
        Dim sConsultaSQL As New System.Text.StringBuilder
        Dim cmdComando As SQLiteCommand
        cmdComando = refparoConexion.CreateCommand()
        ' Los comandos se aplican sobre la base de datos actual
        cmdComando.Connection = refparoConexion

        ' Recuperar las relaciones que aplican para el tipo de tablas actual
        sConsultaSQL.Append("SELECT Relacion.RelacionId, Relacion.Nombre, Tabla.Nombre AS TablaNombre, Tabla_1.Nombre AS TablaNombreForanea,EliminarCascada FROM Relacion ")
        sConsultaSQL.Append("INNER JOIN Tabla ON Relacion.TablaId = Tabla.TablaID ")
        sConsultaSQL.Append("INNER JOIN Tabla Tabla_1 ON Relacion.TablaIdForanea = Tabla_1.TablaID ")
        sConsultaSQL.Append("WHERE (Tabla.TipoBase in (" & Me.TipoTablas & ")) ")
        sConsultaSQL.Append("ORDER BY Relacion.Nombre")
        DataTableActual = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)
        ' Recuperar los datos
        Dim i As Integer = 1
        Dim refDataRow As DataRow
        Dim sAvance As String
        Dim sRelacionId As String
        Dim sLlaveForanea As String = ""
        Dim sLlavePrimaria As String = ""

        Dim oArchivoTexto As New IO.StreamWriter(ServicesCentral.Configuracion.Directorio & "\ErroresRelaciones_" & parsNombreArchivo & ".txt", False)

        Dim bHaHabidoErrores As Boolean = False

        For Each refDataRow In DataTableActual.Rows
            ' Para cada relacion, buscar su detalle
            With refDataRow
                sAvance = .Item("Nombre")
                sRelacionId = .Item("RelacionId")
                If parbEstablecer Then
                    ObtenerListaLlaves(sRelacionId, sLlaveForanea, sLlavePrimaria)
                    ' Crear el comando
                    cmdComando.CommandText = "ALTER TABLE " & .Item("TablaNombre") & " "
                    cmdComando.CommandText &= "ADD FOREIGN KEY " & sAvance & " (" & sLlaveForanea & ") "
                    cmdComando.CommandText &= "REFERENCES " & .Item("TablaNombreForanea") & " (" & sLlavePrimaria & ") "
                    If .Item("EliminarCascada") Then
                        cmdComando.CommandText &= " ON DELETE CASCADE"
                    End If
                Else
                    ' Crear el comando
                    cmdComando.CommandText = "ALTER TABLE " & .Item("TablaNombre") & " "
                    cmdComando.CommandText &= "DROP CONSTRAINT " & sAvance
                End If
                Try
                    ' Ejecutar el comando
                    cmdComando.ExecuteNonQuery()
                Catch ExcA As SQLiteException
                    If parbEstablecer Then
                        oArchivoTexto.WriteLine(ExcA.Message & oArchivoTexto.NewLine & cmdComando.CommandText & oArchivoTexto.NewLine)
                        bHaHabidoErrores = True
                    End If
                Catch ExcB As Exception
                    If parbEstablecer Then
                        oArchivoTexto.WriteLine(ExcB.Message & oArchivoTexto.NewLine & cmdComando.CommandText & oArchivoTexto.NewLine)
                        bHaHabidoErrores = True
                    End If
                End Try
            End With
            i += 1
        Next
        oArchivoTexto.Close()
        cmdComando.Dispose()
        Return True
    End Function

    Private Sub ObtenerListaLlaves(ByVal parsRelacionId As String, ByRef refparsLlaveForanea As String, ByRef refparsLlavePrimaria As String)
        Dim sConsultaSQL As New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT RelacionID,(Select Nombre from Campo Where Campo.CampoID=relacioncampo.CampoIDPrimario) as CampoNombrePrimario ,(Select Nombre from Campo Where Campo.CampoID=relacioncampo.CampoIDForaneo) as CampoNombreForaneo FROM RelacionCampo ")
        sConsultaSQL.Append("WHERE RelacionCampo.RelacionId='" & parsRelacionId & "' ")
        sConsultaSQL.Append("ORDER BY RelacionCampo.Orden")
        Dim DataTableActual As DataTable = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)

        Dim refDataRow As DataRow
        refparsLlaveForanea = ""
        refparsLlavePrimaria = ""
        For Each refDataRow In DataTableActual.Rows
            With refDataRow
                refparsLlaveForanea &= .Item("CampoNombreForaneo") & ","
                refparsLlavePrimaria &= .Item("CampoNombrePrimario") & ","
            End With
        Next
        ' Quitar la ultima coma
        If refparsLlaveForanea <> "" Then
            refparsLlaveForanea = Mid(refparsLlaveForanea, 1, Len(refparsLlaveForanea) - 1)
        End If
        If refparsLlavePrimaria <> "" Then
            refparsLlavePrimaria = Mid(refparsLlavePrimaria, 1, Len(refparsLlavePrimaria) - 1)
        End If
    End Sub
    Private Function RegresaTipoDatoSQL(ByVal parTipo As System.Type) As System.Data.SqlDbType
        Select Case parTipo.Name
            Case "String"
                Return SqlDbType.NVarChar
            Case "Boolean"
                Return SqlDbType.Bit
            Case "DateTime"
                Return SqlDbType.DateTime
            Case "Int32"
                Return SqlDbType.Int
            Case "Int16"
                Return SqlDbType.SmallInt
            Case "Single"
                Return SqlDbType.Real
            Case "Double"
                Return SqlDbType.Float
            Case "Byte[]"
                Return SqlDbType.Image
            Case Else
                Return 0
        End Select
    End Function

End Class