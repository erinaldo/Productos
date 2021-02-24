Imports Microsoft.VisualBasic
Imports System.Data
Imports system
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Xml
Imports LibreriaInterfazSalidaFirebird
Imports system.Diagnostics
Imports LibreriaInterfazSalidaFirebirdMich

Namespace MobileClient

    Public Class ConexionSQL

        Public Shared Function RealizarConsulta(ByVal parsConsultaSQL As String, Optional ByVal parsTabla As String = "Table") As DataTable
            Try
                ' Crear la conexion
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                'oConnection.BeginTransaction(IsolationLevel.ReadUncommitted)
                Dim DataSetRetorno As New DataSet
                Dim SqlDataAdapter As SqlClient.SqlDataAdapter
                oCommand.CommandText = parsConsultaSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                SqlDataAdapter = New SqlClient.SqlDataAdapter(oCommand) '(parsConsultaSQL, oConnection)
                SqlDataAdapter.Fill(DataSetRetorno, parsTabla)
                SqlDataAdapter.Dispose()
                oConnection.Close()
                Return DataSetRetorno.Tables(0)
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 15581
                        Throw New System.Web.Services.Protocols.SoapException(ex.Number, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try

        End Function

        Public Shared Function RealizarConsultaDataSet(ByVal parsConsultaSQL As String, Optional ByVal parsTabla As String = "Table") As DataSet
            Dim DataSetRetorno As New DataSet
            Try
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                Dim SqlDataAdapter As SqlClient.SqlDataAdapter
                SqlDataAdapter = New SqlClient.SqlDataAdapter(parsConsultaSQL, oConnection)
                'SqlDataAdapter.Fill(DataSetRetorno, parsTabla)
                SqlDataAdapter.SelectCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                SqlDataAdapter.Fill(DataSetRetorno)
                SqlDataAdapter.Dispose()
                oConnection.Close()
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try

            Return DataSetRetorno
        End Function

        Public Shared Sub CrearEstructuraTabla(ByVal parsConsultaSQL As String, ByVal parsTabla As String, ByRef paroDataSet As DataSet)
            Try
                ' Crear la conexion
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                'oConnection.BeginTransaction(IsolationLevel.ReadUncommitted)
                Dim SqlDataAdapter As SqlClient.SqlDataAdapter
                oCommand.CommandText = parsConsultaSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                SqlDataAdapter = New SqlClient.SqlDataAdapter(oCommand) '(parsConsultaSQL, oConnection)
                SqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                SqlDataAdapter.FillSchema(paroDataSet, SchemaType.Mapped, parsTabla)
                SqlDataAdapter.Dispose()
                oConnection.Close()
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try
        End Sub

        Public Shared Function RealizarConsultaDataSetSinAcceptChange(ByVal parsConsultaSQL As String, Optional ByVal parsTabla As String = "Table") As DataSet
            Dim DataSetRetorno As New DataSet
            Try
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                Dim SqlDataAdapter As SqlClient.SqlDataAdapter
                SqlDataAdapter = New SqlClient.SqlDataAdapter(parsConsultaSQL, oConnection)
                SqlDataAdapter.AcceptChangesDuringFill = False
                'SqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                SqlDataAdapter.SelectCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                SqlDataAdapter.Fill(DataSetRetorno)
                SqlDataAdapter.Dispose()
                oConnection.Close()
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2, 233
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try

            Return DataSetRetorno
        End Function

        Public Shared Function EjecutarComando(ByVal parsComandoSQL As String) As Integer
            Try
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                ' Dim sqlComando As SqlClient.SqlCommand
                oCommand = oConnection.CreateCommand()
                oCommand.Connection = oConnection
                oCommand.CommandText = parsComandoSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                Dim iRetorno As Integer = oCommand.ExecuteNonQuery()
                oCommand.Dispose()
                oConnection.Close()
                Return iRetorno
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 15581
                        Throw New System.Web.Services.Protocols.SoapException(ex.Number, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try

            Return -1
        End Function

        Public Shared Function EjecutarCmdScalarStrSQL(ByVal parsComandoSQL As String) As String
            Try
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()

                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                'Dim sqlComando As SqlClient.SqlCommand
                'sqlComando = oConnection.CreateCommand()
                'sqlComando.Connection = oConnection
                oCommand.CommandText = parsComandoSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                Dim strResultado As String = oCommand.ExecuteScalar
                oCommand.Dispose()
                oConnection.Close()
                Return strResultado
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try
            Return String.Empty

        End Function

        Public Shared Function EjecutarConsultaObjeto(ByVal parsConsultaSQL As String) As Object
            Try
                Dim oConnection As SqlClient.SqlConnection
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                Dim sqlComando As SqlClient.SqlCommand
                sqlComando = oConnection.CreateCommand()
                sqlComando.Connection = oConnection
                sqlComando.CommandText = parsConsultaSQL
                sqlComando.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                Dim oRetorno As Object = sqlComando.ExecuteScalar()
                oCommand.Dispose()
                sqlComando.Dispose()
                oConnection.Close()
                Return oRetorno
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try

            Return Nothing
        End Function

    End Class

    Public Class ConexionSQLite
        Public Shared Sub RealizarConsultaDataSet(ByVal parsConsultaSQL As String, ByRef paroSQLiteConnection As SQLite.SQLiteConnection, ByRef paroDataSet As DataSet, ByVal parsTabla As String)
            Dim SqlDataAdapter As SQLite.SQLiteDataAdapter
            Try
                SqlDataAdapter = New SQLite.SQLiteDataAdapter(parsConsultaSQL, paroSQLiteConnection)
                SqlDataAdapter.SelectCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                'SqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                SqlDataAdapter.Fill(paroDataSet, parsTabla)
                SqlDataAdapter.Dispose()
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Try
                    SqlDataAdapter.Dispose()
                Catch ex1 As Exception

                End Try
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try
        End Sub
        Public Shared Function RealizarConsultaString(ByVal parsConsultaSQL As String, ByVal paroSQLiteConnection As SQLite.SQLiteConnection) As String
            Dim sqlCommand As SQLite.SQLiteCommand = New SQLite.SQLiteCommand(parsConsultaSQL, paroSQLiteConnection)
            Dim sResult As String = ""
            Try
                Dim objResult As Object = sqlCommand.ExecuteScalar
                If Not objResult.Equals(System.DBNull.Value) Then
                    sResult = objResult.ToString
                End If
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case Else
                        Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Select
            Catch Ex As Exception
                Try
                    sqlCommand.Dispose()
                Catch ex1 As Exception

                End Try
                Throw New System.Web.Services.Protocols.SoapException(Ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
            End Try
            Return sResult
        End Function

    End Class
    Public Class EstructuraDB

        Public Function ObtenerListaCampos(ByVal parsTablaNombre As String, ByVal parsTablaClave As String, Optional ByVal bColocarPrefijo As Boolean = False) As String
            Dim DataTableTablas As DataTable
            Dim refDataRow As DataRow
            Dim sConsultaSQL As String = "SELECT Campo.Nombre FROM TablaCampo "
            sConsultaSQL &= "INNER JOIN Campo ON TablaCampo.CampoID = Campo.CampoID "
            sConsultaSQL &= "WHERE (TablaCampo.TablaID = '" & parsTablaClave & "') "
            sConsultaSQL &= "ORDER BY TablaCampo.Orden"
            DataTableTablas = ConexionSQL.RealizarConsulta(sConsultaSQL)
            ' Para cada tabla, recuperar los datos y colocarlos a un dataset con el nombre de la tabla
            sConsultaSQL = ""
            For Each refDataRow In DataTableTablas.Rows
                If bColocarPrefijo Then
                    sConsultaSQL &= parsTablaNombre & "."
                End If
                sConsultaSQL &= refDataRow("Nombre") & ","
            Next
            sConsultaSQL = Mid(sConsultaSQL, 1, Len(sConsultaSQL) - 1)
            Return sConsultaSQL
        End Function
        Public Function ObtenerEstructura() As DataSet
            Dim DataSetRetorno As New DataSet
            ' Usar dos tablas para guardar la información de las Tablas y los Campos a crear en MobileDB
            Dim DataTableTablas As DataTable
            'DataTableTablas = oConSQL.RealizarConsulta("SELECT TipoBase, TablaID, Nombre, Descripcion FROM Tabla ORDER BY TipoBase, TablaID", "Tablas")
            DataTableTablas = MobileClient.ConexionSQL.RealizarConsulta("SELECT TipoBase, TablaID, Nombre FROM Tabla where Tabla.TipoBase<>0 ORDER BY TipoBase, TablaID", "Tablas")
            Dim DataTableCampos As DataTable
            Dim sConsultaSQL As String
            sConsultaSQL = "SELECT Tabla.Nombre AS TablaNombre, Campo.Nombre AS CampoNombre, Campo.Tipo, Campo.Longitud, TablaCampo.Tipo AS TablaCampoTipo, TablaCampo.VARCodigo "
            sConsultaSQL &= "FROM TablaCampo "
            sConsultaSQL &= "INNER JOIN Campo ON TablaCampo.CampoID = Campo.CampoID "
            sConsultaSQL &= "INNER JOIN Tabla ON TablaCampo.TablaID = Tabla.TablaID "
            sConsultaSQL &= "WHERE Tabla.TipoBase<>0 "
            sConsultaSQL &= "ORDER BY TablaCampo.TablaID, TablaCampo.Orden"
            DataTableCampos = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL, "Campos")
            DataSetRetorno.Tables.Add(DataTableTablas.Copy)
            DataSetRetorno.Tables.Add(DataTableCampos.Copy)
            Return DataSetRetorno
        End Function


        ' Cambios 23 Abril
        'Private Function VerificarReservacionFolios(ByVal parsVendedorId As String) As Boolean
        '    Try
        '        ' Obtener los detalles del día a abrir
        '        Dim DataTableFolios As DataTable
        '        DataTableFolios = ConexionSQL.RealizarConsulta("SELECT FolioUsuario.FolioID, FolioUsuario.CantidadDia, Folio.ValorInicial FROM FolioUsuario INNER JOIN Folio ON FolioUsuario.FolioID = Folio.FolioID WHERE FolioUsuario.VendedorID='" & parsVendedorId & "'")
        '        If DataTableFolios.Rows.Count = 0 Then
        '            Return False
        '        End If
        '        ' Obtener el Id del usuario (dado que el que se pasa es el del vendedor). Se usa para crear nuevos registros en FolioReservacion
        '        Dim DataTableId As DataTable
        '        Dim sUsuarioID As String = String.Empty
        '        DataTableId = ConexionSQL.RealizarConsulta("SELECT USUId FROM Vendedor WHERE VendedorID='" & parsVendedorId & "'")
        '        If DataTableId.Rows.Count = 1 Then
        '            sUsuarioID = DataTableId.Rows(0).Item("USUId")
        '        End If
        '        ' Obtener la cantidad de folios a reservar
        '        Dim sFolioId As String
        '        Dim iCantidadDia As Integer
        '        Dim iValorInicial As Integer
        '        For Each refDataRow As DataRow In DataTableFolios.Rows
        '            sFolioId = refDataRow("FolioID")
        '            iCantidadDia = refDataRow("CantidadDia")
        '            iValorInicial = refDataRow("ValorInicial")
        '            ' Recuperar la cantidad de folios reservados actualmente en FolioReservacion
        '            Dim DataTableRes As DataTable = ConexionSQL.RealizarConsulta("SELECT SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "') AND (VendedorID='" & parsVendedorId & "')", "Reservados")
        '            If DataTableRes.Rows.Count = 1 Then
        '                Dim iTotalFolios As Integer = 0
        '                If Not DataTableRes.Rows(0).IsNull("TotalFolios") Then
        '                    iTotalFolios = DataTableRes.Rows(0).Item("TotalFolios")
        '                End If
        '                ' Si la cantidad de folios reservados es menor a la cuota de folios por vendedor 
        '                If iTotalFolios < iCantidadDia Then
        '                    ' Obtener ahora los consecutivos generales (sin considerar el vendedor)
        '                    Dim DataTableFoliosGlobales As DataTable = ConexionSQL.RealizarConsulta("SELECT MAX(Fin) AS MaxFin, SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "')", "ReservadosGlobales")
        '                    If DataTableFoliosGlobales.Rows.Count = 1 Then
        '                        Dim refDataRowRes As DataRow = DataTableFoliosGlobales.Rows(0)
        '                        Dim iMaxFin As Integer = 0
        '                        If refDataRowRes.IsNull("MaxFin") Then
        '                            ' No hay folios reservados, iniciar el primer rango con el valor inicial del folio
        '                            iMaxFin = iValorInicial
        '                        Else
        '                            ' Ya hay folios, iniciar el siguiente rango con el valor máximo más 1
        '                            iMaxFin = refDataRowRes.Item("MaxFin") + 1
        '                        End If
        '                        ' Obtener el ID del rango maximo (considerando los Activos o Inactivos, y sin considerar al vendedor)

        '                        ' Dim DataTableRango As DataTable
        '                        'DataTableRango = ConexionSQL.RealizarConsulta("SELECT top 1 RangoId FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "') order by Inicio desc")
        '                        'If Not DataTableRango.Rows(0).IsNull("RangoId") Then
        '                        'sRangoId = DataTableRango.Rows(0).Item("RangoId")
        '                        'End If
        '                        ' Reservar los que faltan
        '                        Dim sComandoSQL As New Text.StringBuilder
        '                        Dim oKeyGen As New lbGeneral.cKeyGen
        '                        Dim sRangoId As String = ""
        '                        sRangoId = oKeyGen.KEYGEN(1)
        '                        sComandoSQL.Append("INSERT INTO FolioReservacion (FolioID, VendedorID, RangoId, FechaHora, Inicio, Fin, Usados, TipoEstado, MFechaHora, MUsuarioID) VALUES (")
        '                        sComandoSQL.Append("'" & sFolioId & "',")
        '                        sComandoSQL.Append("'" & parsVendedorId & "',")
        '                        sComandoSQL.Append("'" & sRangoId & "',")
        '                        sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
        '                        sComandoSQL.Append(iMaxFin & ",")
        '                        sComandoSQL.Append(iMaxFin + (iCantidadDia - iTotalFolios - 1) & ",")
        '                        sComandoSQL.Append("0,")
        '                        sComandoSQL.Append(DBCentral.TiposEstadosRegistros.Activo & ",")
        '                        sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
        '                        sComandoSQL.Append("'" & sUsuarioID & "')")
        '                        ConexionSQL.EjecutarComando(sComandoSQL.ToString)
        '                    End If
        '                End If
        '            End If
        '        Next
        '        Return True
        '    Catch ExcW As Exception
        '        Throw New Exception("Error: " & ExcW.Message)
        '    End Try
        '    Return False
        'End Function
        ' /Cambios 23 Abril


    End Class

    Public Class Aplicacion

        Public Sub New()

        End Sub

        'Ady
        Public Function ObtenerDatos(ByVal parsTallerId As String, ByVal parsCondicionTablas As String, ByVal parsTiposBases As String) As DataSet
            ConexionSQL.EjecutarComando("exec sp_Sync_Inventario '" + ServicesCentral.Configuracion.ServidorVinculado + "', '" + ServicesCentral.Configuracion.BDInterfaces + "', '" & parsTallerId & "'")

            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("SPObtenerTablasTaller '" & parsTallerId & "','" & parsCondicionTablas & "','" & parsTiposBases & "'")
            Dim dtNombres As DataTable = ds.Tables(0)
            For i As Integer = 1 To ds.Tables.Count - 1
                ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
            Next
            ds.Tables.Remove("Table")
            Return ds
        End Function

        'Public Function ObtenerActualizacion(ByVal parsDocXML As String, ByVal parsCondicionTablas As String, ByVal parsTiposBases As String) As DataSet
        '    'Solo consulta = 4 (Actualizacion)
        '    Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasActualizacion '" & parsDocXML & "','','" & parsCondicionTablas & "','" & parsTiposBases & "'," & DBCentral.TiposConsulta.Actualizacion & ",'" & Now.ToString("s") & "','" & Now.ToString("s") & "'")
        '    Dim dtNombres As DataTable = ds.Tables(0)
        '    Dim aTablasSinDatos As Collections.ArrayList = New Collections.ArrayList
        '    For i As Integer = 1 To ds.Tables.Count - 1
        '        If ds.Tables(i).Rows.Count <= 0 Then
        '            aTablasSinDatos.Add(dtNombres.Rows(i - 1)("Nombre"))
        '        End If
        '        ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
        '    Next
        '    For Each nombreTabla As String In aTablasSinDatos
        '        ds.Tables.Remove(nombreTabla)
        '    Next
        '    ds.Tables.Remove("Table")
        '    Return ds
        'End Function

        'Public Function ObtenerActualizacionMetodo2(ByVal NumeroSerie As String, ByVal parsCondicionTablas As String, ByVal parsTiposBases As String) As DataSet
        '    'Solo consulta = 4 (Actualizacion)
        '    Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("SPObtenerTablasActualizacionMetodo2 '','" & NumeroSerie & "','" & parsCondicionTablas & "','" & parsTiposBases & "'," & DBCentral.TiposConsulta.Actualizacion & ",'" & Now.ToString("s") & "','" & Now.ToString("s") & "'")
        '    Dim dtNombres As DataTable = ds.Tables(0)
        '    Dim aTablasSinDatos As Collections.ArrayList = New Collections.ArrayList
        '    For i As Integer = 1 To ds.Tables.Count - 1
        '        If ds.Tables(i).Rows.Count <= 0 Then
        '            aTablasSinDatos.Add(dtNombres.Rows(i - 1)("Nombre"))
        '        End If
        '        ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
        '    Next
        '    For Each nombreTabla As String In aTablasSinDatos
        '        ds.Tables.Remove(nombreTabla)
        '    Next
        '    ds.Tables.Remove("Table")
        '    Return ds
        'End Function
        '<2005>        

        'Ady
        Public Function CrearBDSQLite(ByVal parsTallerId As String, ByVal parsTerminalNumeroSerie As String, Optional ByVal optparsCondicionTablas As String = "*") As String
            Dim bNuevo As Boolean = False
            ' Verificar que exista el archivo de base de datos SQLCE

            Dim oArchivoSQLite As New ArchivoSQLite

            oArchivoSQLite.NombreArchivo = parsTerminalNumeroSerie & ".db"
            oArchivoSQLite.TipoTablas = DBCentral.TiposBase.Aplicacion & "," & DBCentral.TiposBase.AplSQLite

            If System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSQLite.NombreArchivo) Then
                System.IO.File.Delete(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSQLite.NombreArchivo)
            End If

            ' Existe el Esquema MobileDB, pero no la base de datos, crearla
            Dim bTablasCreadas As Boolean = False
            If oArchivoSQLite.CrearArchivoSQLite Then
                bTablasCreadas = oArchivoSQLite.CrearTablas()
                If Not bTablasCreadas Then
                    Return String.Empty
                End If
            End If
            bNuevo = True

            If Not IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSQLite.NombreArchivo.Replace(".db", ".xml")) Then
                oArchivoSQLite.CrearArchivoUltimaActualizacion(DBCentral.TiposBase.Aplicacion)
            End If

            Dim lds As DataSet = ObtenerDatos(parsTallerId, optparsCondicionTablas, DBCentral.TiposBase.Aplicacion)
            If Not oArchivoSQLite.LlenarTablas(lds) Then
                Return String.Empty
            End If

            Return oArchivoSQLite.NombreArchivo

        End Function
        Public Shared Function KEYGEN(ByVal pvSemilla As Integer) As String
            Dim vlDateTime As String
            Dim vlNumeric As Decimal
            Dim vlString As String
            Dim vlString1 As String
            Dim vlTimeNow As String = String.Empty
            Dim vlKey As String
            Dim vlBase As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ+"
            Dim vlModulo As Integer
            Dim vcFechaHora As String = Now.ToString("yyyyMMddHHmmssff")

            vlDateTime = vcFechaHora
            vlNumeric = Int(vlDateTime)
            vlNumeric = vlNumeric - 1899000000000000
            vlDateTime = CStr(vlNumeric)
            vlDateTime = vlDateTime.Substring(1, 13)

            vlNumeric = Now.Hour
            vlNumeric = vlNumeric + 100
            vlString = CStr(vlNumeric)
            vlTimeNow = vlTimeNow + vlString.Substring(1)

            vlNumeric = Now.Minute
            vlNumeric = vlNumeric + 100
            vlString = CStr(vlNumeric)
            vlTimeNow = vlTimeNow + vlString.Substring(1)

            vlNumeric = Now.Second
            vlNumeric = vlNumeric + 100
            vlString = CStr(vlNumeric)
            vlTimeNow = vlTimeNow + vlString.Substring(1)

            vlNumeric = pvSemilla + 10
            vlString = CStr(vlNumeric)
            vlKey = vlDateTime + vlTimeNow + vlString

            vlNumeric = vlKey
            vlString = ""

            While vlNumeric > 0
                vlModulo = (vlNumeric Mod 36) + 1
                vlNumeric = vlNumeric / 36
                vlNumeric = Int(vlNumeric)
                vlString1 = vlBase.Substring(vlModulo, 1)
                vlString = vlString1 + vlString
            End While
            Return vlString
        End Function
    End Class

    Public Class Usuario
        Inherits DBCentral.CUsuario

        Public Sub New()

        End Sub

        Public Sub New(ByVal parsUsuarioId As String, ByVal parsClave As String, ByVal parsNombre As String)
            Me.UsuarioId = parsUsuarioId
            Me.Clave = parsClave
            Me.Nombre = parsNombre
        End Sub

        Public Sub New(ByVal parsUsuarioId As String)
            Me.UsuarioId = parsUsuarioId
        End Sub

        Public Function VerificarAcceso(ByVal parsClaveTaller As String, ByVal parsClaveUsuario As String, ByVal parsContrasena As String, ByVal parsTerminalNumeroSerie As String, ByRef refparsMensaje As String) As Boolean
            Try
                ' Buscar el nombre de usuario y su contraseña
                Dim DataTable As DataTable
                Dim oConSQL As New ConexionSQL
                ' Encriptar la contrasena

                Dim sContrasena As String = Me.SimpleCrypt(parsContrasena)
                DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT TallerId, isnull(NoSerieTerminal, '') as NoSerieTerminal FROM Taller WHERE Clave='" & parsClaveTaller & "' AND Activo = 1")
                If DataTable Is Nothing Then
                    refparsMensaje = "Error al obtener datos del servidor"
                    Return False
                Else
                    If DataTable.Rows.Count = 0 Then
                        refparsMensaje = "El taller " & parsClaveTaller & " no existe o no se encuentra activo"
                        Return False
                    End If

                    Dim sNoSerieTerminal As String = DataTable.Rows(0).Item("NoSerieTerminal")
                    Dim sTallerId As String = DataTable.Rows(0).Item("TallerId")
                    If sNoSerieTerminal <> "" And sNoSerieTerminal <> parsTerminalNumeroSerie Then
                        refparsMensaje = "La Terminal no corresponde a la asignada al Taller " & parsClaveTaller
                        Return False
                    End If

                    DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT UsuarioId, ClaveAcceso, TallerId FROM Usuario WHERE Clave='" & parsClaveUsuario & "' AND Activo = 1")

                    If DataTable.Rows.Count = 0 Then
                        refparsMensaje = "El usuario " & parsClaveUsuario & " no existe o no se encuentra activo"
                    ElseIf DataTable.Rows(0).Item("ClaveAcceso") <> sContrasena Then
                        refparsMensaje = "La contraseña no es válida"
                    ElseIf DataTable.Rows(0).Item("TallerId") <> sTallerId Then
                        refparsMensaje = "El taller " & parsClaveTaller & " no corresponde al asignado al usuario " & parsClaveUsuario
                    Else
                        refparsMensaje = "Usuario y Contraseña valida"
                        Return True
                    End If
                End If

            Catch ExcW As Exception
                refparsMensaje = ExcW.Message
                'Throw New Exception(ExcW.Message)
            End Try
            Return False
        End Function

        'Public Function VerificarAcceso(ByVal parsClaveUsuario As String, ByVal parsContrasena As String, ByRef refparsMensaje As String, ByRef refparsVendedor As Boolean, ByRef refparsModulo As Boolean) As Boolean
        '    Try
        '        ' Buscar el nombre de usuario y su contraseña
        '        Dim DataTable As DataTable
        '        Dim oConSQL As New ConexionSQL
        '        ' Encriptar la contrasena

        '        Dim sContrasena As String = Me.SimpleCrypt(parsContrasena)
        '        DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT USUId, Nombre, ClaveAcceso,Tipo FROM Usuario WHERE Clave='" & parsClaveUsuario & "'")

        '        If DataTable Is Nothing Then
        '            '"Error al obtener datos del servidor"
        '            refparsMensaje = Aplicacion.ObtenerMensaje("F0006")
        '        ElseIf DataTable.Rows.Count = 0 Then
        '            ' El usuario no existe
        '            refparsMensaje = Aplicacion.ObtenerMensaje("MDB050601")
        '        ElseIf DataTable.Rows(0).Item("ClaveAcceso") <> sContrasena Then
        '            ' La contraseña no es correcta
        '            refparsMensaje = Aplicacion.ObtenerMensaje("MDB050601")
        '        Else
        '            refparsMensaje = "Usuario y Contraseña valida"
        '            ' Buscar el nombre de usuario y su terminal
        '            Dim sUsuarioId As String = DataTable.Rows(0).Item("USUId")
        '            Dim oVendedor As New Vendedor(sUsuarioId)
        '            If oVendedor.RecuperarConUsuario(sUsuarioId) Then
        '                If oVendedor.MCNClave = "" Then 'no tiene modulo asignado
        '                    refparsMensaje = Aplicacion.ObtenerMensaje("E0484") '"E0702")
        '                    Return False
        '                End If
        '                refparsVendedor = True
        '                refparsModulo = True
        '                Return True
        '            Else
        '                refparsMensaje = Aplicacion.ObtenerMensaje("E0648")
        '                'If oVendedor.MCNClave = "" Then 'no tiene modulo asignado
        '                'refparsMensaje = Aplicacion.ObtenerMensaje("E0484") '"E0702")
        '                'Else 'no existe vendedor
        '                ''refparsModulo = True
        '                'refparsMensaje = Aplicacion.ObtenerMensaje("E0648") 'E0211").Replace("$0$", parsClaveUsuario)
        '                'End If
        '            End If
        '        End If
        '    Catch ExcW As Exception
        '        Throw New Exception(ExcW.Message)
        '    End Try
        '    Return False
        'End Function

        Public Function SimpleCrypt(ByVal Text As String) As String
            ' Encrypts/decrypts the passed string using 
            ' a simple ASCII value-swapping algorithm
            Dim strTempChar As String = String.Empty, i As Integer
            For i = 1 To Len(Text)
                If Asc(Mid$(Text, i, 1)) < 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) + 128, String)
                ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) - 128, String)
                End If
                Mid$(Text, i, 1) = Chr(CType(strTempChar, Integer))
            Next i
            Return Text
        End Function

        Public Overridable Function Recuperar() As Boolean
            Dim DataTableUsuario As DataTable
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Usuario WHERE UsuarioId='" & UsuarioId & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.TallerId = .Item("TallerId")
                    Me.Clave = .Item("Clave")
                    Me.ClaveAcceso = .Item("ClaveAcceso")
                    Me.Nombre = .Item("Nombre")
                    Me.Tipo = .Item("Tipo")
                    Me.Activo = .Item("Activo")
                End With
                Return True
            End If
            Return False
        End Function

        Public Overridable Function Recuperar(ByVal sUsuarioClave As String) As Boolean
            Dim DataTableUsuario As DataTable
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Usuario WHERE Clave='" & sUsuarioClave & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.UsuarioId = .Item("UsuarioId")
                    Me.TallerId = .Item("TallerId")
                    Me.Clave = .Item("Clave")
                    Me.ClaveAcceso = .Item("ClaveAcceso")
                    Me.Nombre = .Item("Nombre")
                    Me.Tipo = .Item("Tipo")
                    Me.Activo = .Item("Activo")
                End With
                Return True
            End If
            Return False
        End Function
    End Class

    Public Class Taller
        Inherits DBCentral.CTaller

        Public Sub New()

        End Sub

        Public Sub New(ByVal parsTallerId As String)
            Me.TallerId = parsTallerId
        End Sub

        Public Overridable Function Recuperar() As Boolean
            Dim DataTableUsuario As DataTable
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Taller WHERE TallerId='" & TallerId & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.AlmacenId = .Item("AlmacenId")
                    Me.Clave = .Item("Clave")
                    Me.Descripcion = .Item("Descripcion")
                    Me.NoSerieTerminal = IIf(.Item("NoSerieTerminal").IsNullOrEmpty, "", .Item("NoSerieTerminal"))
                    Me.Activo = .Item("Activo")
                End With
                Return True
            End If
            Return False
        End Function

        Public Overridable Function Recuperar(sTallerClave as String) As Boolean
            Dim DataTableUsuario As DataTable
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("select TallerId, AlmacenId, Clave, Descripcion, isnull(NoSerieTerminal, '') NoSerieTerminal, Activo from Taller WHERE Clave='" & sTallerClave & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.TallerId = .Item("TallerId")
                    Me.AlmacenId = .Item("AlmacenId")
                    Me.Clave = .Item("Clave")
                    Me.Descripcion = .Item("Descripcion")
                    Me.NoSerieTerminal = .Item("NoSerieTerminal")
                    Me.Activo = .Item("Activo")
                End With
                Return True
            End If
            Return False
        End Function

        Public Sub ActualizaNumeroSerie(ByVal parsTerminalNumeroSerie As String)
            ConexionSQL.EjecutarComando("UPDATE Taller SET NoSerieTerminal='" & parsTerminalNumeroSerie & "' WHERE TallerId='" & Me.TallerId & "'")
        End Sub

        Public Function ActualizarCaptura(ByVal paroDataSet As DataSet, ByRef refparsMensaje As String, ByRef refReintentar As Boolean) As Boolean
            Dim oConnection As SqlClient.SqlConnection
            Dim oTransaccion As SqlClient.SqlTransaction
            Dim oCommand As SqlClient.SqlCommand
            Dim sTabla As String = ""
            Try
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                oTransaccion = oConnection.BeginTransaction(IsolationLevel.ReadUncommitted)
                oCommand = New SqlClient.SqlCommand
                oCommand.Connection = oConnection
                oCommand.Transaction = oTransaccion
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")
                ' Para cada tabla
                Dim sMensaje As String = String.Empty

                Dim dtTablas As DataTable = MobileClient.ConexionSQL.RealizarConsulta("select Tabla from OrdenActualizacion order by Orden")

                For Each drTabla As DataRow In dtTablas.Rows
                    If paroDataSet.Tables.Contains(drTabla("Tabla")) Then
                        Dim refDataTable As DataTable = paroDataSet.Tables(drTabla("Tabla"))
                        sTabla = refDataTable.TableName.ToUpper()
                        Me.ActualizarTabla(refDataTable, oCommand, refparsMensaje)
                    End If
                Next

                'Actualizar la fase de Pedidos planificados para el Ruteo dinámico
                'oCommand.Parameters.Clear()
                'oCommand.CommandText = "exec SPActualizarPedidoPlanificado '" & Me.VendedorId & "'"
                'oCommand.ExecuteNonQuery()

                oTransaccion.Commit()

                ConexionSQL.EjecutarComando("exec sp_Sync_Ordenes '" + ServicesCentral.Configuracion.ServidorVinculado + "', '" + ServicesCentral.Configuracion.BDInterfaces + "'")

                refReintentar = False
                Return True
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 1205
                        refReintentar = True
                        refparsMensaje = "Servidor ocupado ¿Desea intentarlo nuevamente?"
                    Case Else
                        refReintentar = False
                        refparsMensaje &= sTabla & ":" & ex.Message
                End Select
                oTransaccion.Rollback()
            Catch ex As Exception
                refReintentar = False
                refparsMensaje &= sTabla & ":" & ex.Message
                oTransaccion.Rollback()
            Finally
                oCommand.Dispose()
                oConnection.Close()
            End Try
            Return False
        End Function

        Private Function ActualizarTabla(ByRef refparDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, ByRef refparsMensaje As String) As Boolean
            Dim sComandoUpdate As String = String.Empty
            Dim sComandoInsert As String = String.Empty
            Dim sComandoInsertValores As String = String.Empty
           
            Dim sNombreTabla As String = refparDataTable.TableName


            If Not refparDataTable.PrimaryKey Is Nothing Then
                ' Agregar los parametros
                Dim refDataColumn As DataColumn
                refparoComando.Parameters.Clear()

                ' Insertar los registros del Dataset en la base de datos
                Dim refDataRow As DataRow
                For Each refDataRow In refparDataTable.Rows
                    sComandoUpdate = ""
                    sComandoInsert = ""
                    For Each refDataColumn In refparDataTable.Columns
                        If sComandoUpdate = "" Then
                            sComandoUpdate = "UPDATE " & sNombreTabla & " SET "
                            sComandoInsert = "INSERT INTO " & sNombreTabla & " ("
                        Else
                            sComandoInsert &= ", "
                        End If
                        sComandoInsert &= refDataColumn.ColumnName
                    Next

                    sComandoInsert &= ") VALUES ("

                    ' Buscar primero si el registro ya existe
                    refparoComando.Parameters.Clear()

                    If refparDataTable.Columns.Contains("MFechaHora") Then
                        refparoComando.CommandText = "SELECT MFechaHora AS TotalRegistros FROM " & sNombreTabla & " WHERE "
                    Else
                        refparoComando.CommandText = "SELECT COUNT(*) AS TotalRegistros FROM " & sNombreTabla & " WHERE "
                    End If

                    ' /Cambios 23 Abril
                    Dim sFiltro As String = String.Empty
                    For Each refDataColumn In refparDataTable.PrimaryKey
                        If sFiltro <> String.Empty Then
                            sFiltro &= " AND "
                        End If

                        If refDataColumn.DataType.Name.ToUpper = "DATETIME" Then
                            sFiltro &= refDataColumn.ColumnName & "=" & General.UniFechaSQL(refDataRow(refDataColumn.ColumnName))
                        Else
                            sFiltro &= refDataColumn.ColumnName & "='" & refDataRow(refDataColumn.ColumnName) & "'"
                        End If
                    Next
                    Dim DataSetExiste As New DataSet
                    refparoComando.CommandText &= sFiltro
                    Dim iNumRegs As Integer = 0
                    Dim oMFechaHora As Object = Nothing
                    Dim bMFechaHora As Boolean = False

                    Try
                        oMFechaHora = refparoComando.ExecuteScalar()
                    Catch ex As Exception
                        MsgBox("Error")
                    End Try

                    If oMFechaHora <> Nothing AndAlso oMFechaHora.GetType() Is GetType(Integer) Then
                        iNumRegs = Convert.ToInt32(oMFechaHora)
                    ElseIf oMFechaHora <> Nothing Then
                        bMFechaHora = True
                        iNumRegs = 1
                    End If

                    refparoComando.Parameters.Clear()

                    If bMFechaHora Then
                        If oMFechaHora = refDataRow("MFechaHora") Then
                            Continue For
                        End If
                    End If
                    refparoComando.Parameters.Clear()

                    ' Colocar los valores del registro en los parametros
                    Dim sDatos As String = String.Empty
                    For Each refDataColumn In refparDataTable.Columns
                        If iNumRegs = 0 Then
                            ' No existe, agregarlo
                            Select Case refDataColumn.DataType.Name.ToUpper
                                Case "STRING"
                                    If sNombreTabla.ToUpper = "RECDETALLE" And refDataColumn.ColumnName.ToUpper = "IMAGEN" Then
                                        If refDataRow.IsNull(refDataColumn.ColumnName) OrElse refDataColumn.ColumnName = "" Then
                                            sDatos &= "0x0" & ","
                                        ElseIf Not System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga\" & RTrim(refDataRow(refDataColumn.ColumnName)) & ".jpg") Then
                                            sDatos &= "0x0" & ","
                                        Else
                                            Dim oImagen As System.Drawing.Bitmap
                                            Dim msImagen As New System.IO.MemoryStream

                                            oImagen = New System.Drawing.Bitmap(ServicesCentral.Configuracion.Directorio & "\ImagenRecarga\" & RTrim(refDataRow(refDataColumn.ColumnName)) & ".jpg")
                                            oImagen.Save(msImagen, System.Drawing.Imaging.ImageFormat.Jpeg)

                                            refparoComando.Parameters.Add("@" & refDataColumn.ColumnName, SqlDbType.Image)
                                            refparoComando.Parameters("@" & refDataColumn.ColumnName).Value = msImagen.GetBuffer
                                            sDatos &= "@" & refDataColumn.ColumnName & ","

                                            msImagen.Close()
                                            msImagen = Nothing
                                            oImagen.Dispose()

                                        End If
                                    Else
                                        If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                            sDatos &= "NULL" & ","
                                        Else
                                            sDatos &= "'" & RTrim(refDataRow(refDataColumn.ColumnName)).Replace("'", "''") & "',"
                                        End If
                                    End If
                                Case "BOOLEAN"
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= "NULL" & ","
                                    Else
                                        If LCase(RTrim(refDataRow(refDataColumn.ColumnName))) = "true" Then
                                            sDatos &= "1" & ","
                                        Else
                                            sDatos &= "0" & ","
                                        End If
                                    End If
                                Case "DATETIME"
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= "NULL" & ","
                                    Else
                                        sDatos &= General.UniFechaSQL(refDataRow(refDataColumn.ColumnName)) & ","
                                    End If
                                Case "BYTE[]"
                                    If Not IsArray(refDataRow(refDataColumn.ColumnName)) OrElse CType(refDataRow(refDataColumn.ColumnName), Array).GetUpperBound(0) < 0 OrElse Not TypeOf CType(refDataRow(refDataColumn.ColumnName), Array)(0) Is Byte Then
                                        sDatos &= "0x0" & ","
                                    Else
                                        refparoComando.Parameters.Add("@" & refDataColumn.ColumnName, SqlDbType.Image)
                                        refparoComando.Parameters("@" & refDataColumn.ColumnName).Value = refDataRow(refDataColumn.ColumnName)
                                        sDatos &= "@" & refDataColumn.ColumnName & ","
                                    End If
                                Case Else
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= "NULL" & ","
                                    Else
                                        Dim sValor As New Text.StringBuilder(RTrim(refDataRow(refDataColumn.ColumnName)))
                                        ' Cambiar las comas decimales por los puntos decimales
                                        sValor.Replace(",", ".")
                                        sDatos &= sValor.ToString & ","
                                    End If
                            End Select

                        Else

                            Select Case refDataColumn.DataType.Name.ToUpper
                                Case "STRING"
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= refDataColumn.ColumnName & "=" & "NULL" & ","
                                    Else
                                        sDatos &= refDataColumn.ColumnName & "=" & "'" & RTrim(refDataRow(refDataColumn.ColumnName)).Replace("'", "''") & "',"
                                    End If
                                Case "BOOLEAN"
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= refDataColumn.ColumnName & "=" & "NULL" & ","
                                    Else
                                        If LCase(RTrim(refDataRow(refDataColumn.ColumnName))) = "true" Then
                                            sDatos &= refDataColumn.ColumnName & "=" & "1" & ","
                                        Else
                                            sDatos &= refDataColumn.ColumnName & "=" & "0" & ","
                                        End If
                                    End If
                                Case "DATETIME"
                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= refDataColumn.ColumnName & "=" & "NULL" & ","
                                    Else
                                        sDatos &= refDataColumn.ColumnName & "=" & General.UniFechaSQL(refDataRow(refDataColumn.ColumnName)) & ","
                                    End If
                                Case "BYTE[]"
                                    If Not IsArray(refDataRow(refDataColumn.ColumnName)) OrElse CType(refDataRow(refDataColumn.ColumnName), Array).GetUpperBound(0) < 0 OrElse Not TypeOf CType(refDataRow(refDataColumn.ColumnName), Array)(0) Is Byte Then
                                        sDatos &= refDataColumn.ColumnName & "=0x0" & ","
                                    Else
                                        refparoComando.Parameters.Add("@" & refDataColumn.ColumnName, SqlDbType.Image)
                                        refparoComando.Parameters("@" & refDataColumn.ColumnName).Value = refDataRow(refDataColumn.ColumnName)
                                        sDatos &= refDataColumn.ColumnName & "=@" & refDataColumn.ColumnName & ","
                                    End If
                                Case Else

                                    If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                        sDatos &= refDataColumn.ColumnName & "=" & "NULL" & ","
                                    Else
                                        Dim sValor As Text.StringBuilder
                                        sValor = New Text.StringBuilder(RTrim(refDataRow(refDataColumn.ColumnName)))
                                        ' Cambiar las comas decimales por los puntos decimales
                                        sValor.Replace(",", ".")
                                        sDatos &= refDataColumn.ColumnName & "=" & sValor.ToString & ","
                                    End If
                            End Select

                        End If

                    Next

                    If iNumRegs = 0 Then
                        ' No existe, agregarlo
                        If sDatos.Length > 0 Then
                            refparoComando.CommandText = sComandoInsert & Left(sDatos, sDatos.Length - 1) & ")"
                        End If
                    Else
                        If sDatos.Length > 0 Then
                            refparoComando.CommandText = sComandoUpdate & Left(sDatos, sDatos.Length - 1) & " WHERE " & sFiltro
                        End If
                        ' Ya existe, actualizarlo
                    End If

                    ' Agregar los datos 
                    refparoComando.ExecuteNonQuery()
                Next
            End If
            Return True
        End Function

        Public Shared Function ObtenerTraspasos(ByVal parsTallerId As String, byval parsFechaInicio as String) As DataSet
            Dim sComandoSQL As New Text.StringBuilder
            Dim sFecha As String() = parsFechaInicio.Split("/")
            Dim dFechaInicio As New Date(sFecha(0), sFecha(1), sFecha(2))

            ConexionSQL.EjecutarComando("exec sp_Sync_Traspaso '" + ServicesCentral.Configuracion.ServidorVinculado + "', '" + ServicesCentral.Configuracion.BDInterfaces + "', '" & parsTallerId & "', '" & dFechaInicio.ToString("s") & "'")

            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("SPObtenerTraspasos '" & parsTallerId & "', '" & dFechaInicio.ToString("s") & "'")
            ds.Tables(0).TableName = "Articulo"
            ds.Tables(1).TableName = "Traspaso"
            ds.Tables(2).TableName = "TRPDetalle"
            Return ds
        End Function

        Public Shared Sub MarcarTraspasosEnviados(ByVal parsTallerId As String, ByVal parsFechaInicio As String, ByVal parsUsuarioId As String)
            Dim sFecha As String() = parsFechaInicio.Split("/")
            Dim dFechaInicio As New Date(sFecha(0), sFecha(1), sFecha(2))

            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("SPMarcarTraspasosEnviados '" & parsTallerId & "', '" & dFechaInicio.ToString("s") & "', '" & parsUsuarioId & "'")
        End Sub

    End Class
   
    Public Class TiposTmp

        Public Property TiposContenidoFolios() As DBCentral.TiposContenidoFolios
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposContenidoFolios)

            End Set
        End Property

        Public Property TiposBase() As DBCentral.TiposBase
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposBase)

            End Set
        End Property

        Public Property TiposEstadosRegistros() As DBCentral.TiposEstadosRegistros
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposEstadosRegistros)

            End Set
        End Property

    End Class

    Public Class OrdenarFicheroPorFecha
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim File1 As System.IO.FileInfo
            Dim File2 As System.IO.FileInfo

            File1 = DirectCast(x, System.IO.FileInfo)
            File2 = DirectCast(y, System.IO.FileInfo)

            Compare = DateTime.Compare(File1.LastWriteTime, File2.LastWriteTime)
        End Function
    End Class
End Namespace
