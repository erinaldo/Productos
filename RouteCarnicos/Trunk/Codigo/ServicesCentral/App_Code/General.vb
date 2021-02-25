Imports Microsoft.VisualBasic
Imports System.Data.SqlServerCe
Imports System.Data
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

    Public Shared Function ComprimirArchivo(ByVal sNombreArchivo As String) As Boolean
        ' get the name of file
        Dim sFile As String = ServicesCentral.Configuracion.Directorio + "\" + sNombreArchivo
        'Dim sFile As String = sNombreArchivo
        'Dim zipArchive As New Resco.IO.Zip.ZipArchive(sFile.Replace(".sdf", ".zip"), Resco.IO.Zip.ZipArchiveMode.Create, IO.FileShare.Write)
        Dim zipArchive As New C1.C1Zip.C1ZipFile(sFile.Replace(".sdf", ".zip"), True)
        ' check if we still have archive opened
        If zipArchive Is Nothing Then
            Return False
        End If

        ' show dialog
        'Try
        'zipArchive.Add(sFile, "", True, Nothing)
        'zipArchive.Add(sFile.Replace(".sdf", ".xml"), "", True, Nothing)
        zipArchive.Entries.Add(sFile)
        zipArchive.Entries.Add(sFile.Replace(".sdf", ".xml"))
        'Catch 'ex As Exception
        ' we got error, during adding.
        'End Try
        ' clear name
        zipArchive.Close()
    End Function


    Public Shared Function VerificaAuditoria() As Boolean
        Dim blnAuditarCarga As Boolean = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select Top 1 AuditarCarga from conhist order by CONHistFechaInicio desc  ")
        Dim sFiltroCargas As String = String.Empty
        If Not blnAuditarCarga Then
            sFiltroCargas = " AOB.AOBTipoObjeto <> 14 "
        End If
        Dim iRegistros As Integer = MobileClient.ConexionSQL.EjecutarConsultaObjeto("Select count(*) from AuditoriaObjeto AOB " & IIf(sFiltroCargas <> String.Empty, " where " & sFiltroCargas, String.Empty))
        If iRegistros = 0 Then Return True
        Dim iAuditoriasIncorrectas = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select count(*) from AuditoriaObjeto AOB where AOB.Correcto = 0 " & IIf(sFiltroCargas <> String.Empty, " and " & sFiltroCargas, String.Empty))
        Try
            If iAuditoriasIncorrectas > 0 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Class
Public Class ArchivoSDF
    Protected dFechaIni As Date
    Protected dFechaFin As Date
    Protected sNombreArchivo As String
    Protected tTipoTablas As DBCentral.TiposBase

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

    Public Property TipoTablas() As DBCentral.TiposBase
        Get
            Return tTipoTablas
        End Get
        Set(ByVal value As DBCentral.TiposBase)
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

    Public Function CrearArchivoSDF() As Boolean
        'Try
        ' Verificar que exista la base de datos
        'If Not System.IO.Directory.Exists(General.sDirectorio) Then
        '    System.IO.Directory.CreateDirectory(General.sDirectorio)
        'End If
        If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo) Then
            'If System.IO.File.Exists(NombreArchivo) Then
            Return True
        End If
        ' No existe, crear la base de datos, conectarse a SC para obtener la estructura de la BDD
        Try

            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", True)
            Dim SqlCeEngineSQL As New Data.SqlServerCe.SqlCeEngine("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
            SqlCeEngineSQL.CreateDatabase()
            SqlCeEngineSQL.Dispose()
        Catch ex As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SINSDF", "ServiceCentral"))
        End Try


        Return True
        'Catch ExcA As Data.SqlServerCe.SqlCeException
        '    '            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
        'Catch ExcB As Exception
        '    '       MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
        'End Try
        Return False
    End Function

    Public Function CrearTablas() As Boolean
        AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", True)
        Dim conConexion As SqlCeConnection
        Dim cmdComando As SqlCeCommand

        ' Usar un DataSet para leer el contenido del archivo XML
        Dim refDataTable As DataTable
        Dim refDataRow As DataRow
        Dim refDataTablaDet As DataTable
        Dim refDataRowDet As DataRow
        Dim sNombreTabla As String
        ' Abrir una conexión a la base de datos
        conConexion = New SqlCeConnection("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
        'conConexion = New SqlCeConnection("Data Source = " & NombreArchivo)
        conConexion.Open()

        ' Crear un comando
        cmdComando = conConexion.CreateCommand()
        cmdComando.Connection = conConexion
        ' Leer el archivo XML con el esquema
        refDataTable = MobileClient.ConexionSQL.RealizarConsulta("select TipoBase, TablaID, Nombre from tabla where TipoBase = " & Me.TipoTablas, "Tabla")
        Dim sConsultaSQL As New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT Tabla.Nombre AS TablaNombre, Campo.Nombre AS CampoNombre, Campo.Tipo, Campo.Longitud, TablaCampo.Tipo AS TablaCampoTipo, TablaCampo.VARCodigo ")
        sConsultaSQL.Append("FROM TablaCampo INNER JOIN Campo ON TablaCampo.CampoID = Campo.CampoID ")
        sConsultaSQL.Append("INNER JOIN Tabla ON TablaCampo.TablaID = Tabla.TablaID WHERE Tabla.TipoBase= " & Me.TipoTablas)
        sConsultaSQL.Append("ORDER BY TablaCampo.TablaID, TablaCampo.Orden")
        refDataTablaDet = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString, "Campos")

        Dim j As Integer
        Dim iNumCamposTabla As Short
        Dim tTipoDato As DBCentral.TiposCampos
        Dim sNombreCampo As String
        Dim sLlavePrimaria As String
        Dim tTipo As DBCentral.TiposTablasCampos = DBCentral.TiposTablasCampos.Nulos

        j = 1
        For Each refDataRow In refDataTable.Rows
            Try
                sNombreTabla = RTrim(refDataRow("Nombre"))
                cmdComando.CommandText = "CREATE TABLE " & sNombreTabla & " ("
                iNumCamposTabla = 0
                sLlavePrimaria = ""
                For Each refDataRowDet In refDataTablaDet.Rows
                    If refDataRowDet("TablaNombre").ToString = sNombreTabla Then
                        sNombreCampo = refDataRowDet("CampoNombre").ToString
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
                        sLlavePrimaria = Mid(sLlavePrimaria, 1, Len(sLlavePrimaria) - 2)
                        ' Agregarlas
                        cmdComando.CommandText &= "CONSTRAINT PK_" & sNombreTabla & " PRIMARY KEY (" & sLlavePrimaria & ")"
                    Else
                        ' Quitar la última coma
                        cmdComando.CommandText = Mid(cmdComando.CommandText, 1, Len(cmdComando.CommandText) - 2)
                    End If
                    cmdComando.CommandText &= ")"

                    ' Ejecutar el comando
                    cmdComando.ExecuteNonQuery()

                End If
            Catch ExcA As SqlCeException
                '                MsgBox(ExcA.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            Catch ExcB As System.Xml.XmlException
                '               MsgBox(ExcB.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            Catch ExcC As Exception
                '              MsgBox(ExcC.Message & ": " & cmdComando.CommandText, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearTablas")
            End Try
            j += 1
        Next
        conConexion.Close()
        conConexion.Dispose()
        Return True
    End Function
    Public Sub CompactarBD()
        Dim SqlCeEngineSQL As New Data.SqlServerCe.SqlCeEngine("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
        SqlCeEngineSQL.Shrink()
        SqlCeEngineSQL.Dispose()
    End Sub
    Public Sub CrearArchivoUltimaActualizacion(ByVal pariTipoBase As Integer)

        Dim dt As DataTable
        dt = MobileClient.ConexionSQL.RealizarConsulta("Select Distinct Nombre as I, convert(varchar(30),'1900-01-01T00:00:00',126) as F from Tabla where TipoBase=" & pariTipoBase, "T")
        Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), System.Text.Encoding.Unicode)
        ' Escribir en el archivo XML
        dt.DataSet.DataSetName = "ds"
        dt.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
        ' Cerrar el flujo XML
        XmlTextWriterDicc.Close()
    End Sub

    Public Function RegresaArchivoUltimaActualizacion() As String
        Dim stream As New System.IO.FileStream(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), IO.FileMode.Open)
        Dim XmlTextReaderTablas As New System.Xml.XmlTextReader(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), stream)

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

    Public Function LlenarTablas(ByVal parsDataSet As DataSet, ByVal parbRecienCreado As Boolean, ByVal parsExtension As String, Optional ByVal parbActualizacionCatalogos As Boolean = False) As Boolean
        AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", True)
        Dim conConexion As SqlCeConnection
        ' / Cambios 08 Mayo 2006
        conConexion = New SqlCeConnection("Data Source = " & ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo)
        Dim refDataTable As DataTable
        conConexion.Open()
        ' Quitar las relaciones solo si la base de datos no ha sido recien creada
        'If Not parbRecienCreado Then
        '    ' Quitar las relaciones antes de actualizar las tablas
        '    If Not EstablecerRelaciones(False, conConexion) Then
        '        conConexion.Close()
        '        conConexion.Dispose()
        '        Return False
        '    End If
        'End If
        Dim dsUltimosCambios As New DataSet
        dsUltimosCambios.ReadXml(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"))
        dsUltimosCambios.Tables("T").PrimaryKey = New DataColumn() {dsUltimosCambios.Tables("T").Columns("I")}
        Dim i As Integer = 1
        'Try
        Dim ldtTransProdDetalle As New DataTable
        Dim ldtCliCap As New DataTable
        Dim ldtCadPro As New DataTable
        Dim dsTablas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select distinct Nombre,Grupo from Tabla where TipoBase =" & Me.TipoTablas)
        dsTablas.PrimaryKey = New DataColumn() {dsTablas.Columns("Nombre")}
        For Each refDataTable In parsDataSet.Tables
            'TODO: Revisar si hay otra forma de LlenarTabla
            If Not (parbActualizacionCatalogos And refDataTable.Rows.Count <= 0) Then
                Dim drGrupo As DataRow = dsTablas.Rows.Find(refDataTable.TableName)
                LlenarTabla(refDataTable, conConexion, drGrupo("Grupo"), parbActualizacionCatalogos)
                Dim dr As DataRow = dsUltimosCambios.Tables("T").Rows.Find(refDataTable.TableName)
                dr("F") = Now.ToString("s")
            End If
            i += 1
            refDataTable.Dispose()
        Next
        Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(ServicesCentral.Configuracion.Directorio & "\" & NombreArchivo.Replace(".sdf", ".xml"), System.Text.Encoding.Unicode)
        ' Escribir en el archivo XML
        dsUltimosCambios.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
        ' Cerrar el flujo XML
        XmlTextWriterDicc.Close()
        parsDataSet.Dispose()

        ' Poner las relaciones despues de actualizar las tablas
        If parbRecienCreado Then
            If Not EstablecerRelaciones(True, parsExtension, conConexion) Then
                conConexion.Close()
                conConexion.Dispose()
                Return False
            End If
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "LlenarTablas")
        'End Try
        conConexion.Close()
        conConexion.Dispose()
        Return True
    End Function

    Private Sub LlenarTabla(ByRef refparDataTable As DataTable, ByVal refConnectionSQL As SqlCeConnection, ByVal pariGrupo As Integer, ByVal parbBorrarInactivos As Boolean)
        AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", True)
        Dim dt As New DataTable
        Dim da As New SqlCeDataAdapter("Select * from " & refparDataTable.TableName, refConnectionSQL)
        Try
            If pariGrupo = 2 Then
                Dim cmdComando As SqlCeCommand = refConnectionSQL.CreateCommand()
                cmdComando.Connection = refConnectionSQL
                cmdComando.CommandText = "Delete from " & refparDataTable.TableName
                cmdComando.ExecuteNonQuery()
            End If
            If refparDataTable.Rows.Count <= 0 Then Exit Sub
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            da.Fill(dt)

            Dim sCampos As String = String.Empty
            Dim sParametros As String = String.Empty
            Dim sAsignaciones As String = String.Empty
            Dim sComparaLlavesPrimarias As String = String.Empty

            Dim aParametrosInsert(refparDataTable.Columns.Count - 1) As SqlCeParameter
            Dim aParametrosUpdate(refparDataTable.Columns.Count - 1) As SqlCeParameter
            Dim aParameterLlavesUpdate(dt.PrimaryKey.Length - 1) As SqlCeParameter
            Dim aParameterLlavesDelete(dt.PrimaryKey.Length - 1) As SqlCeParameter

            Dim k As System.Type
            Dim sLlavePrimaria As String
            For i As Integer = 0 To dt.PrimaryKey.Length - 1
                sLlavePrimaria = dt.PrimaryKey(i).ColumnName
                sComparaLlavesPrimarias &= sLlavePrimaria & "=" & "@Original_" & sLlavePrimaria
                If i < dt.PrimaryKey.Length - 1 Then
                    sComparaLlavesPrimarias &= " AND "
                End If
                k = refparDataTable.Columns(i).DataType
                aParameterLlavesUpdate(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
                aParameterLlavesDelete(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
            Next

            Dim sNombreCampo As String
            For j As Integer = 0 To refparDataTable.Columns.Count - 1
                sNombreCampo = refparDataTable.Columns(j).ColumnName
                sCampos &= sNombreCampo
                sParametros &= "@" & sNombreCampo
                sAsignaciones &= sNombreCampo & "=" & "@" & sNombreCampo
                k = refparDataTable.Columns(j).DataType
                aParametrosInsert(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
                aParametrosUpdate(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
                If j < refparDataTable.Columns.Count - 1 Then
                    sCampos &= ","
                    sParametros &= ","
                    sAsignaciones &= ","
                End If
            Next

            Dim insCmd As SqlCeCommand = New SqlCeCommand("insert into " & refparDataTable.TableName & "(" & sCampos & ")  values(" & sParametros & ")", refConnectionSQL)
            insCmd.Parameters.AddRange(aParametrosInsert)
            da.InsertCommand = insCmd

            Dim UpdCmd As SqlCeCommand = New SqlCeCommand("UPDATE " & refparDataTable.TableName & " SET " & sAsignaciones & " WHERE (" & sComparaLlavesPrimarias & ")", refConnectionSQL)
            UpdCmd.Parameters.AddRange(aParametrosUpdate)
            UpdCmd.Parameters.AddRange(aParameterLlavesUpdate)
            da.UpdateCommand = UpdCmd

            'Dim DelCmd As SqlCeCommand = New SqlCeCommand("DELETE FROM " & refparDataTable.TableName & " WHERE (" & sComparaLlavesPrimarias & ")", refConnectionSQL)
            'DelCmd.Parameters.AddRange(aParameterLlavesDelete)
            'da.DeleteCommand = DelCmd
            'da.ContinueUpdateOnError = True
            dt.Merge(refparDataTable)
            da.Update(dt)

            If parbBorrarInactivos Then
                Dim sFiltroBorrar As String = String.Empty
                If dt.Columns.Contains("TipoEstado") Then
                    sFiltroBorrar &= " TipoEstado=0 "
                ElseIf dt.Columns.Contains("Estado") Then
                    sFiltroBorrar &= " Estado=0 "
                ElseIf dt.Columns.Contains("TipoFase") Then
                    sFiltroBorrar &= " TipoFase<>1 "
                End If
                If dt.Columns.Contains("Baja") Then
                    If sFiltroBorrar <> String.Empty Then
                        sFiltroBorrar &= " OR "
                    End If
                    sFiltroBorrar &= " Baja=1 "
                End If
                If sFiltroBorrar <> String.Empty Then
                    Dim BorrarCmd As New SqlCeCommand("Delete FROM " & refparDataTable.TableName & " WHERE " & sFiltroBorrar, refConnectionSQL)
                    BorrarCmd.ExecuteNonQuery()
                Else

                End If
            End If

            insCmd.Dispose()
            UpdCmd.Dispose()
            'DelCmd.Dispose()
            dt.Dispose()
            'If Not IsNothing(dtEliminados) Then dtEliminados.Dispose()
            da.Dispose()


            'Catch ex As SqlCeException
            '    MsgBox(ex.Message)
        Catch ex1 As Exception
            Throw New System.Web.Services.Protocols.SoapException(ex1.Message, New System.Xml.XmlQualifiedName("LLENARTABLA", "ServiceCentral"))
        End Try
    End Sub
    Public Function EstablecerRelaciones(ByVal parbEstablecer As Boolean, ByVal parsExtension As String, ByRef refparoConexion As SqlCeConnection) As Boolean
        Dim DataTableActual As New DataTable
        Dim sConsultaSQL As New System.Text.StringBuilder
        Dim cmdComando As SqlCeCommand
        cmdComando = refparoConexion.CreateCommand()
        ' Los comandos se aplican sobre la base de datos actual
        cmdComando.Connection = refparoConexion

        ' Recuperar las relaciones que aplican para el tipo de tablas actual
        sConsultaSQL.Append("SELECT Relacion.RelacionId, Relacion.Nombre, Tabla.Nombre AS TablaNombre, Tabla_1.Nombre AS TablaNombreForanea,EliminarCascada FROM Relacion ")
        sConsultaSQL.Append("INNER JOIN Tabla ON Relacion.TablaId = Tabla.TablaID ")
        sConsultaSQL.Append("INNER JOIN Tabla Tabla_1 ON Relacion.TablaIdForanea = Tabla_1.TablaID ")
        sConsultaSQL.Append("WHERE (Tabla.TipoBase = " & Me.TipoTablas & ") ")
        sConsultaSQL.Append("ORDER BY Relacion.Nombre")
        DataTableActual = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL.ToString)
        ' Recuperar los datos
        Dim i As Integer = 1
        Dim refDataRow As DataRow
        Dim sAvance As String
        Dim sRelacionId As String
        Dim sLlaveForanea As String = ""
        Dim sLlavePrimaria As String = ""

        Dim oArchivoTexto As New IO.StreamWriter(ServicesCentral.Configuracion.Directorio & "\ErroresRelaciones_" & parsExtension & ".txt", False)

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
                    cmdComando.CommandText &= "ADD CONSTRAINT " & sAvance & " FOREIGN KEY (" & sLlaveForanea & ") "
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
                Catch ExcA As SqlCeException
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
