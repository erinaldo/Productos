Imports Microsoft.VisualBasic
Imports System.Data
Imports system
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Xml
Imports LibreriaInterfazSalidaFirebird
Imports system.Diagnostics

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

        'Public Function ObtenerDatos(ByVal parsCondicionTablas As String, ByVal pareTipoTablas As DBCentral.TiposBase, Optional ByVal parsDiaClave As String = "", Optional ByVal parsUsuarioClave As String = "") As DataSet
        '    Dim DataSetRetorno As New DataSet
        '    Dim sConsultaSQL As String = String.Empty
        '    Dim sNombreTabla As String = String.Empty
        '    Dim sIDTabla As String
        '    Try
        '        ' La información se obtiene de la tabla
        '        Dim DataTableTablas As New DataTable
        '        Dim refDataRow As DataRow
        '        Dim DataTableNueva As DataTable
        '        Dim sIndicacionSQL As String
        '        Dim iPosicion As Integer

        '        ' Si el tipo de tablas es del dia, generar la tabla de agendas
        '        If pareTipoTablas = DBCentral.TiposBase.Dia Then
        '            ' Cambios 23 Abril
        '            If CrearAgendaVendedor(parsDiaClave, parsUsuarioClave) Then
        '                VerificarReservacionFolios(parsUsuarioClave)
        '            End If
        '            ' /Cambios 23 Abril
        '        End If

        '        ' Ejecutar la consulta, recuperar la información de la tabla en especial o de todas
        '        If parsCondicionTablas = "*" Or parsCondicionTablas = "" Then
        '            sConsultaSQL = "SELECT * FROM Tabla WHERE TipoBase = " & pareTipoTablas
        '        Else
        '            ' Extraer la lista de tablas
        '            Dim sComandoTablas As String = ""
        '            ' Variables para recuperar el contenido en varios campos
        '            Dim sDelimitadores As String = ","
        '            Dim cDelimitador As Char() = sDelimitadores.ToCharArray()
        '            Dim asCadenas As String() = Nothing
        '            Dim iColumna As Integer
        '            asCadenas = parsCondicionTablas.Split(cDelimitador)
        '            For iColumna = 0 To asCadenas.Length - 1
        '                sComandoTablas &= ("'" & asCadenas(iColumna) & "'")
        '                If iColumna <> (asCadenas.Length - 1) Then
        '                    sComandoTablas &= ","
        '                End If
        '            Next
        '            sConsultaSQL = "SELECT * FROM Tabla WHERE TipoBase=" & pareTipoTablas & " AND Nombre IN (" & sComandoTablas & ")"
        '        End If
        '        DataTableTablas = ConexionSQL.RealizarConsulta(sConsultaSQL)
        '        ' Para cada tabla, recuperar los datos y colocarlos a un dataset con el nombre de la tabla
        '        For Each refDataRow In DataTableTablas.Rows
        '            sIDTabla = refDataRow("TablaID")
        '            sNombreTabla = refDataRow("Nombre")
        '            DataTableNueva = New DataTable(sNombreTabla)
        '            sIndicacionSQL = ""
        '            If refDataRow.IsNull("ConsultaSQL") Then
        '                sIndicacionSQL = "*"
        '            Else
        '                sIndicacionSQL = RTrim(LTrim(refDataRow("ConsultaSQL")))
        '            End If
        '            If sIndicacionSQL = "<!>" Or sIndicacionSQL = "" Then
        '                ' La consulta no arrojó elementos, crear la nueva tabla vacía
        '                DataTableNueva = New DataTable
        '                ' Asignarle el nombre a la tabla
        '                DataTableNueva.TableName = sNombreTabla
        '            Else
        '                If sIndicacionSQL = "*" Then
        '                    sConsultaSQL = "SELECT " & ObtenerListaCampos(sNombreTabla, sIDTabla, False) & " FROM " & sNombreTabla
        '                Else
        '                    iPosicion = InStr(sIndicacionSQL, "<*>", CompareMethod.Text)
        '                    If iPosicion <> 0 Then
        '                        sConsultaSQL = Mid(sIndicacionSQL, 1, iPosicion - 1) & ObtenerListaCampos(sNombreTabla, sIDTabla, False) & Mid(sIndicacionSQL, iPosicion + 3)
        '                        'sConsultaSQL = sConsultaSQL.Replace("<*>", ObtenerListaCampos(sNombreTabla, sIDTabla, False))
        '                    Else
        '                        sConsultaSQL = refDataRow("ConsultaSQL")
        '                    End If
        '                    iPosicion = InStr(sConsultaSQL, "<.*>", CompareMethod.Text)
        '                    If iPosicion <> 0 Then
        '                        sConsultaSQL = Mid(sIndicacionSQL, 1, iPosicion - 1) & ObtenerListaCampos(sNombreTabla, sIDTabla, True) & Mid(sIndicacionSQL, iPosicion + 4)
        '                        'sConsultaSQL = sConsultaSQL.Replace("<.*>", ObtenerListaCampos(sNombreTabla, sIDTabla, True))
        '                    End If
        '                    iPosicion = InStr(sConsultaSQL, "<u>", CompareMethod.Text)
        '                    If iPosicion <> 0 Then
        '                        'sConsultaSQL = Mid(sConsultaSQL, 1, iPosicion - 1) & "'" & parsUsuarioClave & "'" & Mid(sConsultaSQL, iPosicion + 3)
        '                        sConsultaSQL = sConsultaSQL.Replace("<u>", "'" & parsUsuarioClave & "'")
        '                    End If
        '                    iPosicion = InStr(sConsultaSQL, "<dd>", CompareMethod.Text)
        '                    If iPosicion <> 0 Then
        '                        sConsultaSQL = sConsultaSQL.Replace("<dd>", "'" & parsDiaClave & "'")
        '                        'sConsultaSQL = Mid(sConsultaSQL, 1, iPosicion - 1) & "'" & parsDiaClave & "'" & Mid(sConsultaSQL, iPosicion + 4)
        '                    End If
        '                    iPosicion = InStr(sConsultaSQL, "<vrol>", CompareMethod.Text)
        '                    If iPosicion <> 0 Then
        '                        Dim oVendedor As New MobileClient.Vendedor(parsUsuarioClave)
        '                        oVendedor.Recuperar()
        '                        If oVendedor.ClaveModulo <> "" Then
        '                            Dim iTipoIndice As Integer = oVendedor.RecuperarTipoIndice
        '                            sConsultaSQL = sConsultaSQL.Replace("<vrol>", iTipoIndice)
        '                        End If
        '                    End If
        '                End If
        '                DataTableNueva = ConexionSQL.RealizarConsulta(sConsultaSQL, sNombreTabla)
        '            End If
        '            ' Agregar la tabla al dataset
        '            DataSetRetorno.Tables.Add(DataTableNueva.Copy)
        '        Next
        '    Catch ExcW As Exception
        '        Throw New Exception("Error: " & ExcW.Message & "Tabla " & sNombreTabla & ", Consulta SQL: " & sConsultaSQL)
        '    End Try
        '    Return DataSetRetorno
        'End Function

        ' Cambios 23 Abril
        Private Function VerificarReservacionFolios(ByVal parsVendedorId As String) As Boolean
            Try
                ' Obtener los detalles del día a abrir
                Dim DataTableFolios As DataTable
                DataTableFolios = ConexionSQL.RealizarConsulta("SELECT FolioUsuario.FolioID, FolioUsuario.CantidadDia, Folio.ValorInicial FROM FolioUsuario INNER JOIN Folio ON FolioUsuario.FolioID = Folio.FolioID WHERE FolioUsuario.VendedorID='" & parsVendedorId & "'")
                If DataTableFolios.Rows.Count = 0 Then
                    Return False
                End If
                ' Obtener el Id del usuario (dado que el que se pasa es el del vendedor). Se usa para crear nuevos registros en FolioReservacion
                Dim DataTableId As DataTable
                Dim sUsuarioID As String = String.Empty
                DataTableId = ConexionSQL.RealizarConsulta("SELECT USUId FROM Vendedor WHERE VendedorID='" & parsVendedorId & "'")
                If DataTableId.Rows.Count = 1 Then
                    sUsuarioID = DataTableId.Rows(0).Item("USUId")
                End If
                ' Obtener la cantidad de folios a reservar
                Dim sFolioId As String
                Dim iCantidadDia As Integer
                Dim iValorInicial As Integer
                For Each refDataRow As DataRow In DataTableFolios.Rows
                    sFolioId = refDataRow("FolioID")
                    iCantidadDia = refDataRow("CantidadDia")
                    iValorInicial = refDataRow("ValorInicial")
                    ' Recuperar la cantidad de folios reservados actualmente en FolioReservacion
                    Dim DataTableRes As DataTable = ConexionSQL.RealizarConsulta("SELECT SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "') AND (VendedorID='" & parsVendedorId & "')", "Reservados")
                    If DataTableRes.Rows.Count = 1 Then
                        Dim iTotalFolios As Integer = 0
                        If Not DataTableRes.Rows(0).IsNull("TotalFolios") Then
                            iTotalFolios = DataTableRes.Rows(0).Item("TotalFolios")
                        End If
                        ' Si la cantidad de folios reservados es menor a la cuota de folios por vendedor 
                        If iTotalFolios < iCantidadDia Then
                            ' Obtener ahora los consecutivos generales (sin considerar el vendedor)
                            Dim DataTableFoliosGlobales As DataTable = ConexionSQL.RealizarConsulta("SELECT MAX(Fin) AS MaxFin, SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "')", "ReservadosGlobales")
                            If DataTableFoliosGlobales.Rows.Count = 1 Then
                                Dim refDataRowRes As DataRow = DataTableFoliosGlobales.Rows(0)
                                Dim iMaxFin As Integer = 0
                                If refDataRowRes.IsNull("MaxFin") Then
                                    ' No hay folios reservados, iniciar el primer rango con el valor inicial del folio
                                    iMaxFin = iValorInicial
                                Else
                                    ' Ya hay folios, iniciar el siguiente rango con el valor máximo más 1
                                    iMaxFin = refDataRowRes.Item("MaxFin") + 1
                                End If
                                ' Obtener el ID del rango maximo (considerando los Activos o Inactivos, y sin considerar al vendedor)

                                ' Dim DataTableRango As DataTable
                                'DataTableRango = ConexionSQL.RealizarConsulta("SELECT top 1 RangoId FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "') order by Inicio desc")
                                'If Not DataTableRango.Rows(0).IsNull("RangoId") Then
                                'sRangoId = DataTableRango.Rows(0).Item("RangoId")
                                'End If
                                ' Reservar los que faltan
                                Dim sComandoSQL As New Text.StringBuilder
                                Dim oKeyGen As New lbGeneral.cKeyGen
                                Dim sRangoId As String = ""
                                sRangoId = oKeyGen.KEYGEN(1)
                                sComandoSQL.Append("INSERT INTO FolioReservacion (FolioID, VendedorID, RangoId, FechaHora, Inicio, Fin, Usados, TipoEstado, MFechaHora, MUsuarioID) VALUES (")
                                sComandoSQL.Append("'" & sFolioId & "',")
                                sComandoSQL.Append("'" & parsVendedorId & "',")
                                sComandoSQL.Append("'" & sRangoId & "',")
                                sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
                                sComandoSQL.Append(iMaxFin & ",")
                                sComandoSQL.Append(iMaxFin + (iCantidadDia - iTotalFolios - 1) & ",")
                                sComandoSQL.Append("0,")
                                sComandoSQL.Append(DBCentral.TiposEstadosRegistros.Activo & ",")
                                sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
                                sComandoSQL.Append("'" & sUsuarioID & "')")
                                ConexionSQL.EjecutarComando(sComandoSQL.ToString)
                            End If
                        End If
                    End If
                Next
                Return True
            Catch ExcW As Exception
                Throw New Exception("Error: " & ExcW.Message)
            End Try
            Return False
        End Function
        ' /Cambios 23 Abril


    End Class

    Public Class Aplicacion

        Public Sub New()

        End Sub

        Public Shared Function ObtenerMensaje(ByVal parsMENClave As String) As String
            'Try
            Dim sLenguaje As String = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select top 1 TipoLenguaje from dbo.ConHist order by CONHistFechaInicio desc")
            Dim sRes As String = MobileClient.ConexionSQL.EjecutarConsultaObjeto("select descripcion from mendetalle where MENClave ='" & parsMENClave & "' and MEDTipoLenguaje='" & sLenguaje & "'")

            Return sRes
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            Return String.Empty
        End Function
        '<2005>
        Public Function ObtenerDatos(ByVal parsCondicionTablas As String) As DataSet
            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasAplicacion '" & parsCondicionTablas & "'")
            Dim dtNombres As DataTable = ds.Tables(0)
            For i As Integer = 1 To ds.Tables.Count - 1
                ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
            Next
            ds.Tables.Remove("Table")
            Return ds
        End Function
        Public Function ObtenerActualizacion(ByVal parsDocXML As String, ByVal parsCondicionTablas As String) As DataSet
            'Solo consulta = 4 (Actualizacion)
            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasActualizacion '" & parsDocXML & "','','" & parsCondicionTablas & "'," & DBCentral.TiposBase.Aplicacion & "," & DBCentral.TiposConsulta.Actualizacion)
            Dim dtNombres As DataTable = ds.Tables(0)
            For i As Integer = 1 To ds.Tables.Count - 1
                ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
            Next
            ds.Tables.Remove("Table")
            Return ds
        End Function
        '<2005>

        Public Function CrearBD(ByVal parsTerminalNumeroSerie As String, Optional ByVal optparsCondicionTablas As String = "*") As String
            Dim bNuevo As Boolean = False
            ' Verificar que exista el archivo de base de datos SQLCE

            Dim oArchivoSDF As New ArchivoSDF

            oArchivoSDF.NombreArchivo = parsTerminalNumeroSerie & ".sdf"
            oArchivoSDF.TipoTablas = DBCentral.TiposBase.Aplicacion

            If Not System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSDF.NombreArchivo) Then
                ' / Cambios 08 Mayo 2006
                'FormProcesando.PubSubInformar("Creando archivos", "Archivo " & NombreArchivoSDF)
                ' Existe el Esquema MobileDB, pero no la base de datos, crearla
                Dim bTablasCreadas As Boolean = False
                If oArchivoSDF.CrearArchivoSDF() Then
                    bTablasCreadas = oArchivoSDF.CrearTablas()
                    If Not bTablasCreadas Then
                        ' / Cambios 08 Mayo 2006
                        Return String.Empty
                    End If
                End If
                bNuevo = True
            Else
                bNuevo = False
            End If

            If Not IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSDF.NombreArchivo.Replace(".sdf", ".xml")) Then
                oArchivoSDF.CrearArchivoUltimaActualizacion(DBCentral.TiposBase.Aplicacion)
            End If

            If bNuevo Then
                Dim lds As DataSet = ObtenerDatos(optparsCondicionTablas)
                If Not oArchivoSDF.LlenarTablas(lds, bNuevo, parsTerminalNumeroSerie) Then
                    Return String.Empty
                End If
            Else
                Dim ldsCatalogos As DataSet = ObtenerActualizacion(oArchivoSDF.RegresaArchivoUltimaActualizacion, "*")
                If Not oArchivoSDF.LlenarTablas(ldsCatalogos, bNuevo, parsTerminalNumeroSerie, True) Then
                    Return String.Empty
                End If
            End If

            Return oArchivoSDF.NombreArchivo

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

        Public Function VerificarAcceso(ByVal parsClaveUsuario As String, ByVal parsContrasena As String, ByVal parsTerminalClave As String, ByRef refparsMensaje As String) As Boolean
            Try
                ' Buscar el nombre de usuario y su contraseña
                Dim DataTable As DataTable
                Dim oConSQL As New ConexionSQL
                ' Encriptar la contrasena

                Dim sContrasena As String = Me.SimpleCrypt(parsContrasena)
                DataTable = MobileClient.ConexionSQL.RealizarConsulta("SELECT USUId, Nombre, ClaveAcceso,Tipo FROM Usuario WHERE Clave='" & parsClaveUsuario & "'")

                If DataTable Is Nothing Then
                    refparsMensaje = Aplicacion.ObtenerMensaje("F0006")
                    'refparsMensaje =  "Error al obtener datos del servidor"
                ElseIf DataTable.Rows.Count = 0 Then
                    ' El usuario no existe
                    refparsMensaje = Aplicacion.ObtenerMensaje("BE0003").Replace("$0$", Aplicacion.ObtenerMensaje("CUsuario"))
                    'refparsMensaje = "El usuario " & parsClaveUsuario & " no existe"
                ElseIf DataTable.Rows(0).Item("ClaveAcceso") <> sContrasena Then
                    ' La contraseña no es correcta
                    refparsMensaje = Aplicacion.ObtenerMensaje("E0210")
                Else 'If DataTable.Rows(0).Item("Tipo") = DBCentral.TiposUsuarios.Vendedor Then
                    ' Buscar el nombre de usuario y su terminal
                    Dim sUsuarioId As String = DataTable.Rows(0).Item("USUId")
                    Dim oVendedor As New Vendedor(sUsuarioId)
                    If oVendedor.RecuperarConUsuario(sUsuarioId) Then
                        'If oVendedor.VerificarTerminal(parsTerminalClave) Then
                        '    Return True
                        'End If
                        'refparsMensaje = "El vendedor " & parsClaveUsuario & " tiene asignada otra terminal"
                        If oVendedor.MCNClave = "" Then
                            refparsMensaje = Aplicacion.ObtenerMensaje("E0702")
                            Return False
                        End If
                        Return True
                    Else
                        If oVendedor.MCNClave = "" Then
                            refparsMensaje = Aplicacion.ObtenerMensaje("E0702")
                        Else
                            refparsMensaje = Aplicacion.ObtenerMensaje("E0211").Replace("$0$", parsClaveUsuario)
                        End If
                        'refparsMensaje = "El vendedor " & parsClaveUsuario & " no existe"
                    End If
                    End If
            Catch ExcW As Exception
                Throw New Exception(ExcW.Message)
            End Try
            Return False
        End Function

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
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Usuario WHERE USUID='" & UsuarioId & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.Nombre = .Item("Nombre")
                    Me.ClaveEmpleado = .Item("PERClave")
                    Me.Clave = .Item("Clave")
                    Me.ClaveAcceso = .Item("ClaveAcceso")
                    Me.DiasLimite = .Item("DiasLimite")
                    If Not .IsNull("FechaMod") Then
                        Me.FechaModificacion = .Item("FechaMod")
                    End If
                    Me.Activo = .Item("Activo")
                    Me.Tipo = .Item("Tipo")
                End With
                Return True
            End If
            Return False
        End Function

        Public Overridable Function Recuperar(ByVal sUsuarioClave) As Boolean
            Dim DataTableUsuario As DataTable
            DataTableUsuario = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Usuario WHERE Clave='" & sUsuarioClave & "'")
            If DataTableUsuario.Rows.Count > 0 Then
                With DataTableUsuario.Rows(0)
                    Me.UsuarioId = .Item("USUId")
                    Me.Nombre = .Item("Nombre")
                    Me.ClaveEmpleado = .Item("PERClave")
                    Me.Clave = .Item("Clave")
                    Me.ClaveAcceso = .Item("ClaveAcceso")
                    Me.DiasLimite = .Item("DiasLimite")
                    If Not .IsNull("FechaMod") Then
                        Me.FechaModificacion = .Item("FechaMod")
                    End If
                    Me.Activo = .Item("Activo")
                    Me.Tipo = .Item("Tipo")
                End With
                Return True
            End If
            Return False
        End Function
    End Class

    Public Class Vendedor
        Inherits Usuario

        Protected sVendedorId As String
        Protected tTipoEstado As DBCentral.TiposEstadosRegistros
        Protected sClaveModulo As String
        Protected sMCNClave As String
        Protected tNivel As DBCentral.TiposNivelesVendedores
        Protected fLimiteDescuento As Decimal
        Protected sTerminalClave As String
        Protected sAlmacenId As String
        Protected bCapturaFolioFac As Boolean

        Public Property VendedorId() As String
            Get
                Return sVendedorId
            End Get
            Set(ByVal Value As String)
                sVendedorId = Value
            End Set
        End Property
        Public Property TipoEstado() As DBCentral.TiposEstadosRegistros
            Get
                Return tTipoEstado
            End Get
            Set(ByVal Value As DBCentral.TiposEstadosRegistros)
                tTipoEstado = Value
            End Set
        End Property

        Public Property ClaveModulo() As String
            Get
                Return sClaveModulo
            End Get
            Set(ByVal Value As String)
                sClaveModulo = Value
            End Set
        End Property
        Public Property MCNClave() As String
            Get
                Return sMCNClave
            End Get
            Set(ByVal value As String)
                sMCNClave = value
            End Set
        End Property
        Public Property Nivel() As DBCentral.TiposNivelesVendedores
            Get
                Return tNivel
            End Get
            Set(ByVal Value As DBCentral.TiposNivelesVendedores)
                tNivel = Value
            End Set
        End Property
        Public Property LimiteDescuento() As Decimal
            Get
                Return fLimiteDescuento
            End Get
            Set(ByVal Value As Decimal)
                fLimiteDescuento = Value
            End Set
        End Property
        Public Property TerminalClave() As String
            Get
                Return sTerminalClave
            End Get
            Set(ByVal Value As String)
                sTerminalClave = Value
            End Set
        End Property
        Public Property AlmacenId() As String
            Get
                Return sAlmacenId
            End Get
            Set(ByVal Value As String)
                sAlmacenId = Value
            End Set
        End Property
        Public Property CapturaFolioFac() As Boolean
            Get
                Return bCapturaFolioFac
            End Get
            Set(ByVal Value As Boolean)
                bCapturaFolioFac = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal parsVendedorId As String)
            Me.VendedorId = parsVendedorId
        End Sub

        Public Overloads Overrides Function Recuperar() As Boolean
            Dim DataTableVendedor As DataTable
            Dim oConSQL As New ConexionSQL
            DataTableVendedor = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Vendedor WITH (NOLOCK) WHERE VendedorId='" & VendedorId & "'")
            If DataTableVendedor.Rows.Count > 0 Then
                With DataTableVendedor.Rows(0)
                    Me.UsuarioId = .Item("USUID")
                    If MyBase.Recuperar() Then
                        Me.TipoEstado = .Item("TipoEstado")
                        'Me.TipoCapturaProductos = .Item("TipoCapturaProductos")
                        Me.MCNClave = .Item("MCNClave").ToString
                        Me.ClaveModulo = .Item("ModuloClave").ToString
                        Me.Nivel = .Item("Nivel")
                        Me.LimiteDescuento = .Item("LimiteDescuento")
                        Me.TerminalClave = .Item("TerminalClave")
                        Me.AlmacenId = .Item("AlmacenID")
                        Me.CapturaFolioFac = .Item("CapturaFolioFac")
                    End If
                End With
                Return True
            End If
            Return False
        End Function
        '<26-Abril-06>
        Public Function RecuperarConUsuario(ByVal sUSUId As String) As Boolean
            Dim DataTableVendedor As DataTable
            DataTableVendedor = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Vendedor WHERE USUId='" & sUSUId & "' AND Baja<>1 and TipoEstado=1")
            If DataTableVendedor.Rows.Count > 0 Then
                With DataTableVendedor.Rows(0)
                    Me.VendedorId = .Item("VendedorID")
                    Me.UsuarioId = .Item("USUID")
                    If MyBase.Recuperar() Then
                        Me.TipoEstado = .Item("TipoEstado")
                        Me.MCNClave = .Item("MCNClave").ToString
                        Me.ClaveModulo = .Item("ModuloClave").ToString
                        Me.Nivel = .Item("Nivel")
                        Me.LimiteDescuento = .Item("LimiteDescuento")
                        Me.TerminalClave = .Item("TerminalClave")
                        Me.AlmacenId = .Item("AlmacenID")
                        Me.CapturaFolioFac = .Item("CapturaFolioFac")
                    End If
                End With
                Return True
            End If
            Return False
        End Function
        '\<26-Abril-06>
        Public Function VerificarTerminal(ByVal parsTerminalClave As String) As Boolean
            Try
                Dim sConsultaSQL As String
                If VendedorId = "" Then
                    sConsultaSQL = "SELECT TerminalClave FROM Terminal WHERE TerminalClave='" & parsTerminalClave & "'"
                Else
                    sConsultaSQL = "SELECT Vendedor.TerminalClave, Usuario.USUId FROM Vendedor INNER JOIN Usuario ON Vendedor.USUId = Usuario.USUId "
                    sConsultaSQL &= "WHERE Vendedor.TerminalClave = '" & parsTerminalClave & "' AND Usuario.Clave = '" & Clave & "'"
                End If
                Dim DataTableConsulta As DataTable
                DataTableConsulta = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL)
                ' Si la consulta arrojó algún resultado
                If DataTableConsulta.Rows.Count = 0 Then
                    ' Es correcto, el usuario y su contraseña son correctos, ejecutar la consulta SQL
                    Return False
                End If
            Catch ExcW As Exception
                Throw New Exception("Error: " & ExcW.Message & "Terminal " & parsTerminalClave & ", Vendedor " & Me.Clave)
            End Try
            Return True
        End Function

        Public Function RecuperarTipoIndice() As Integer
            Try
                Dim sConsultaSQL As String
                If Me.ClaveModulo = "" Then
                    Return 0
                Else
                    sConsultaSQL = "SELECT TipoIndice FROM ModuloTerm WHERE ModuloClave=(select moduloclave from motconfiguracion where mcnclave = '" & Me.MCNClave & "')"
                End If

                Dim DataTableConsulta As DataTable
                DataTableConsulta = MobileClient.ConexionSQL.RealizarConsulta(sConsultaSQL)
                ' Si la consulta arrojó algún resultado
                If DataTableConsulta.Rows.Count > 0 Then
                    ' Regresar el tipo Indice del ModuloTerm del Vendedor
                    Return DataTableConsulta.Rows(0)("TipoIndice")
                End If
            Catch ExcW As Exception
                Throw New Exception("Error: " & ExcW.Message & "Configuracion Modulos " & Me.MCNClave & ", Vendedor " & Me.Clave)
            End Try
            Return True
        End Function

        Public Function CrearBD(ByVal parsTerminalClave As String, ByVal parsVendedorID As String, ByVal pardFechaIni As DateTime, ByVal pardFechaFin As DateTime, ByVal parsTiposConsulta As String, ByRef bGeneroAgenda As Boolean) As String
            'Try
            Dim bNuevo As Boolean = False
            Dim oArchivoSDF As New ArchivoSDF

            ' / Cambios 08 Mayo 2006
            'FormProcesando.PubSubInformar("Creando archivos", "Archivo " & NombreArchivoSDF)
            ' Existe el Esquema MobileDB, pero no la base de datos, crearla
            oArchivoSDF.NombreArchivo = Me.UsuarioId & ".sdf"
            oArchivoSDF.TipoTablas = DBCentral.TiposBase.Vendedor

            If Not System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & Me.UsuarioId & ".sdf") Then
                Dim bTablasCreadas As Boolean = False
                If oArchivoSDF.CrearArchivoSDF() Then
                    bTablasCreadas = oArchivoSDF.CrearTablas()
                    If Not bTablasCreadas Then
                        ' / Cambios 08 Mayo 2006
                        Return String.Empty
                    End If
                End If
                bNuevo = True
            Else
                bNuevo = False
            End If

            If Not IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\" & oArchivoSDF.NombreArchivo.Replace(".sdf", ".xml")) Then
                oArchivoSDF.CrearArchivoUltimaActualizacion(DBCentral.TiposBase.Vendedor)
            End If

            If bNuevo Then
                Dim lds As DataSet = ObtenerAgenda(parsTerminalClave, 0, parsVendedorID, pardFechaIni, pardFechaFin, "*", parsTiposConsulta, bGeneroAgenda)
                If Not lds Is Nothing Then
                    If Not oArchivoSDF.LlenarTablas(lds, bNuevo, Me.UsuarioId) Then
                        Return String.Empty
                    End If
                Else
                    Return String.Empty
                End If
            Else
                Dim ldsCatalogos As DataSet = ObtenerCatalogos(oArchivoSDF.RegresaArchivoUltimaActualizacion, parsVendedorID, "*")
                If Not oArchivoSDF.LlenarTablas(ldsCatalogos, bNuevo, Me.UsuarioId, True) Then
                    Return String.Empty
                End If
                Dim ldsAgenda As DataSet = ObtenerAgenda(parsTerminalClave, 2, parsVendedorID, pardFechaIni, pardFechaFin, "*", parsTiposConsulta, bGeneroAgenda)
                If Not ldsAgenda Is Nothing Then
                    If Not oArchivoSDF.LlenarTablas(ldsAgenda, bNuevo, Me.UsuarioId) Then
                        Return String.Empty
                    End If
                Else
                    Return String.Empty
                End If
            End If
            oArchivoSDF.CompactarBD()
            Return oArchivoSDF.NombreArchivo
        End Function

        Public Function ObtenerAgenda(ByVal parsTerminalNumeroSerie As String, ByVal pariGrupo As Integer, ByVal parsVendedorID As String, ByVal pardFechaIni As DateTime, ByVal pardFechaFin As DateTime, ByVal parsCondicionTablas As String, ByVal parsTiposConsulta As String, ByRef bGeneroAgenda As Boolean) As DataSet
            Dim dFechaIniOriginal, dFechaFinOriginal As Date
            dFechaIniOriginal = pardFechaIni
            dFechaFinOriginal = pardFechaFin
            Dim dtDiasAntPos As DataTable = ConexionSQL.RealizarConsulta("select Top 1 DiasAnteriores, DiasPosteriores from conhist where ConHistFechaInicio <=getdate() order by ConHistFechaInicio desc ")
            If dtDiasAntPos.Rows.Count > 0 Then
                If dtDiasAntPos.Rows(0)("DiasAnteriores") > 0 Then
                    pardFechaIni = DateAdd(DateInterval.Day, dtDiasAntPos.Rows(0)("DiasAnteriores") * -1, pardFechaIni)
                End If
                If dtDiasAntPos.Rows(0)("DiasPosteriores") > 0 Then
                    pardFechaFin = DateAdd(DateInterval.Day, dtDiasAntPos.Rows(0)("DiasPosteriores"), pardFechaFin)
                End If
            End If
            dtDiasAntPos.Dispose()

            If CrearAgendaVendedor(pardFechaIni, pardFechaFin, parsVendedorID, dFechaIniOriginal, dFechaFinOriginal) Then
                VerificarReservacionFolios(parsVendedorID)

                Dim ds As DataSet
                Try
                    ds = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasVendedor " & pariGrupo & ",'" & parsVendedorID & "','" & pardFechaIni.ToString("s") & "','" & pardFechaFin.ToString("s") & "','" & parsCondicionTablas & "','" & parsTiposConsulta & "'")
                Catch ex As Exception
                    Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                End Try

                Dim dtNombres As DataTable = ds.Tables(0)
                For i As Integer = 1 To ds.Tables.Count - 1
                    ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
                Next
                If (dFechaIniOriginal <> pardFechaIni) OrElse (dFechaFinOriginal <> pardFechaFin) Then
                    Dim drFueraFrecuencia() As DataRow = ds.Tables("Dia").Select("FechaCaptura<'" & dFechaIniOriginal.ToString("s") & "' or FechaCaptura>'" & dFechaFinOriginal.ToString("s") & "'")
                    For Each dr As DataRow In drFueraFrecuencia
                        dr("FueraFrecuencia") = 1
                    Next
                End If

                ds.Tables.Remove("Table")
                bGeneroAgenda = True
                Return ds
            Else
                bGeneroAgenda = False
                Return Nothing
            End If

        End Function

        Public Sub ActualizaNumeroSerie(ByVal parsTerminalNumeroSerie As String)
            ConexionSQL.EjecutarComando("UPDATE Terminal Set NumeroSerie='" & parsTerminalNumeroSerie & "' where TerminalClave='" & Me.TerminalClave & "'")
        End Sub

        Public Function ObtenerCatalogos(ByVal sDocXML As String, ByVal parsVendedorID As String, ByVal parsCondicionTablas As String) As DataSet
            'Solo consultas tipo 4 (Actualizacion)
            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasActualizacion '" & sDocXML & "','" & parsVendedorID & "','" & parsCondicionTablas & "'," & DBCentral.TiposBase.Vendedor & "," & DBCentral.TiposConsulta.Actualizacion)
            Dim dtNombres As DataTable = ds.Tables(0)
            For i As Integer = 1 To ds.Tables.Count - 1
                ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
            Next
            ds.Tables.Remove("Table")
            Return ds
        End Function

        Public Function ObtenerRecargas(ByVal sDocXML As String, ByVal parsVendedorID As String, ByVal parsCondicionTablas As String) As DataSet
            'Solo consultas tipo 4 (Actualizacion)
            Dim ds As DataSet = ConexionSQL.RealizarConsultaDataSetSinAcceptChange("spObtenerTablasActualizacion '" & sDocXML & "','" & parsVendedorID & "','" & parsCondicionTablas & "'," & DBCentral.TiposBase.Vendedor & "," & DBCentral.TiposConsulta.Recargas)
            Dim dtNombres As DataTable = ds.Tables(0)
            For i As Integer = 1 To ds.Tables.Count - 1
                ds.Tables(i).TableName = dtNombres.Rows(i - 1)("Nombre")
            Next
            ds.Tables.Remove("Table")
            Return ds
        End Function

        Private Function CrearAgendaVendedor(ByVal pardFechaini As Date, ByVal pardFechaFin As Date, ByVal parsVendedorID As String, ByVal pardFechaIniOrig As Date, ByVal pardFechaFinOrig As Date) As Boolean
            Dim bGeneroAgenda As Boolean = False
            ConexionSQL.EjecutarComando("DELETE FROM Agenda WHERE VendedorID='" & parsVendedorID & "'")
            Dim dFecha As Date = pardFechaini
            While dFecha <= pardFechaFin
                Dim oDia As New Dia(Format(dFecha, "dd/MM/yyyy"), "", dFecha)
                oDia.Guardar(Me.UsuarioId)
                dFecha = dFecha.AddDays(1)
            End While

            Dim dtDias As DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select *,FueraFrecuencia = case When (FechaCaptura between " & General.UniFechaSQL(pardFechaIniOrig) & " and " & General.UniFechaSQL(pardFechaFinOrig) & ") Then 0 Else 1 End from dia where (FechaCaptura between " & General.UniFechaSQL(pardFechaini) & " and " & General.UniFechaSQL(pardFechaFin) & ") and Estado=1 order by FechaCaptura asc")
            For Each dr As DataRow In dtDias.Rows
                If dr("FueraFrecuencia") = 0 Then
                    ConexionSQL.EjecutarComando("DELETE FROM AgendaVendedor WHERE VendedorID='" & parsVendedorID & "' and DiaClave='" & dr("DiaClave") & "' ")
                End If
                ' Generar los catálogos de clientes
                Dim sListaFrecuencias As String = String.Empty
                dFecha = Convert.ToDateTime(dr("FechaCaptura"))
                ' Recuperar las frecuencias en las que se incluye el día actual
                If (Convert.ToInt32(ConexionSQL.EjecutarConsultaObjeto("select Count(*) from frecuenciaexcep where Dia = " & dFecha.Day.ToString() & " AND Mes =" & dFecha.Month.ToString() & " AND Anio =" & dFecha.Year.ToString())) = 0) Then
                    If ObtenerFrecuenciasClientes(sListaFrecuencias, dr("DiaClave")) Then
                        bGeneroAgenda = bGeneroAgenda Or LlenarAgendaVendedor(sListaFrecuencias, dr("DiaClave"), parsVendedorID, IIf(dr("FueraFrecuencia") = 0, False, True))
                    End If
                End If

                ' Generar los clientes a visitar este día, para todos los usuarios, según las secuencias
            Next
            Return bGeneroAgenda
        End Function
        Private Function VerificarReservacionFolios(ByVal parsVendedorId As String) As Boolean
            Try
                ' Obtener los detalles del día a abrir
                Dim DataTableFolios As DataTable
                DataTableFolios = ConexionSQL.RealizarConsulta("SELECT FolioUsuario.FolioID, FolioUsuario.CantidadDia, Folio.ValorInicial FROM FolioUsuario INNER JOIN Folio ON FolioUsuario.FolioID = Folio.FolioID WHERE FolioUsuario.VendedorID='" & parsVendedorId & "'")
                If DataTableFolios.Rows.Count = 0 Then
                    Return False
                End If
                ' Obtener el Id del usuario (dado que el que se pasa es el del vendedor). Se usa para crear nuevos registros en FolioReservacion
                Dim DataTableId As DataTable
                Dim sUsuarioID As String = String.Empty
                DataTableId = ConexionSQL.RealizarConsulta("SELECT USUId FROM Vendedor WHERE VendedorID='" & parsVendedorId & "'")
                If DataTableId.Rows.Count = 1 Then
                    sUsuarioID = DataTableId.Rows(0).Item("USUId")
                End If
                ' Obtener la cantidad de folios a reservar
                Dim sFolioId As String
                Dim iCantidadDia As Integer
                Dim iValorInicial As Integer
                For Each refDataRow As DataRow In DataTableFolios.Rows
                    sFolioId = refDataRow("FolioID")
                    iCantidadDia = refDataRow("CantidadDia")
                    iValorInicial = refDataRow("ValorInicial")
                    ' Recuperar la cantidad de folios reservados actualmente en FolioReservacion
                    Dim DataTableRes As DataTable = ConexionSQL.RealizarConsulta("SELECT SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "') AND (VendedorID='" & parsVendedorId & "')", "Reservados")
                    If DataTableRes.Rows.Count = 1 Then
                        Dim iTotalFolios As Integer = 0
                        If Not DataTableRes.Rows(0).IsNull("TotalFolios") Then
                            iTotalFolios = DataTableRes.Rows(0).Item("TotalFolios")
                        End If
                        ' Si la cantidad de folios reservados es menor a la cuota de folios por vendedor 
                        If iTotalFolios < iCantidadDia Then
                            ' Obtener ahora los consecutivos generales (sin considerar el vendedor)
                            Dim DataTableFoliosGlobales As DataTable = ConexionSQL.RealizarConsulta("SELECT MAX(Fin) AS MaxFin, SUM(Fin - Inicio - Usados + 1) AS TotalFolios FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "')", "ReservadosGlobales")
                            If DataTableFoliosGlobales.Rows.Count = 1 Then
                                Dim refDataRowRes As DataRow = DataTableFoliosGlobales.Rows(0)
                                Dim iMaxFin As Integer = 0
                                If refDataRowRes.IsNull("MaxFin") Then
                                    ' No hay folios reservados, iniciar el primer rango con el valor inicial del folio
                                    iMaxFin = iValorInicial
                                Else
                                    ' Ya hay folios, iniciar el siguiente rango con el valor máximo más 1
                                    iMaxFin = refDataRowRes.Item("MaxFin") + 1
                                End If
                                ' Obtener el ID del rango maximo (considerando los Activos o Inactivos, y sin considerar al vendedor)
                                'Dim iMaxRango As Integer = 0
                                'Dim DataTableRango As DataTable
                                'DataTableRango = ConexionSQL.RealizarConsulta("SELECT MAX(Rango) AS MaxRango FROM FolioReservacion WHERE (FolioID = '" & refDataRow("FolioID") & "')")
                                'If Not DataTableRango.Rows(0).IsNull("MaxRango") Then
                                '    iMaxRango = DataTableRango.Rows(0).Item("MaxRango")
                                'End If
                                ' Reservar los que faltan
                                Dim sComandoSQL As New Text.StringBuilder
                                Dim oKeyGen As New lbGeneral.cKeyGen
                                Dim sRangoId As String = ""
                                sRangoId = oKeyGen.KEYGEN(1)
                                sComandoSQL.Append("INSERT INTO FolioReservacion (FolioID, VendedorID, RangoId, FechaHora, Inicio, Fin, Usados, TipoEstado, MFechaHora, MUsuarioID) VALUES (")
                                sComandoSQL.Append("'" & sFolioId & "',")
                                sComandoSQL.Append("'" & parsVendedorId & "',")
                                sComandoSQL.Append("'" & sRangoId & "',")
                                sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
                                sComandoSQL.Append(iMaxFin & ",")
                                sComandoSQL.Append(iMaxFin + (iCantidadDia - iTotalFolios - 1) & ",")
                                sComandoSQL.Append("0,")
                                sComandoSQL.Append(DBCentral.TiposEstadosRegistros.Activo & ",")
                                sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
                                sComandoSQL.Append("'" & sUsuarioID & "')")
                                ConexionSQL.EjecutarComando(sComandoSQL.ToString)
                            End If
                        End If
                    End If
                Next
                Return True
            Catch ExcW As Exception
                Throw New Exception("Error: " & ExcW.Message)
            End Try
            Return False
        End Function
        Private Function ObtenerFrecuenciasClientes(ByRef refparsListaFrecuencias As String, ByVal parsDiaClave As String) As Boolean
            Try
                ' Obtener los detalles del día a abrir
                Dim DataTableDia As DataTable
                DataTableDia = ConexionSQL.RealizarConsulta("SELECT * FROM Dia WHERE Dia.DiaClave ='" & parsDiaClave & "'")
                If DataTableDia.Rows.Count = 0 Then
                    Return False
                End If
                ' Identificar los componentes de la fecha para comparar
                Dim dFechaDia As Date = DataTableDia.Rows(0).Item("FechaCaptura")
                Dim iDiaSemana As Short = General.ObtenerNumeroDiaSemana(dFechaDia)
                Dim iDiaAnyo As Short = dFechaDia.DayOfYear
                Dim iDia As Short = dFechaDia.Day
                Dim iMes As Integer = dFechaDia.Month
                Dim iAño As Integer = dFechaDia.Year
                ' Obtener las frecuencias vigentes hasta el dia de hoy
                Dim DataTableFrec As DataTable
                DataTableFrec = ConexionSQL.RealizarConsulta("SELECT * FROM Frecuencia WHERE " & General.UniFechaSQL(dFechaDia) & ">=FechaInicio AND " & General.UniFechaSQL(dFechaDia) & "<=FechaFinal")
                If DataTableFrec.Rows.Count = 0 Then
                    Return False
                End If
                ' Recorrer las frecuencias e identificar aquellas en las que se incluya el día actual 
                Dim eTipoFrecuencia As DBCentral.TiposFrecuencias
                Dim refDataRow As DataRow
                Dim iUnidadInicio As Short
                Dim iIntervalo As Short
                Dim iRepeticion As Short
                Dim bConsiderar As Boolean
                Dim sFrecuencia As String
                Dim iCiclo As Integer
                Dim iIteraciones As Integer
                For Each refDataRow In DataTableFrec.Rows
                    eTipoFrecuencia = refDataRow("Tipo")
                    sFrecuencia = refDataRow("FrecuenciaClave")
                    iUnidadInicio = refDataRow("UnidadInicio")
                    iIntervalo = refDataRow("Intervalo")
                    iRepeticion = refDataRow("Repeticion")
                    bConsiderar = False
                    Select Case eTipoFrecuencia
                        Case DBCentral.TiposFrecuencias.Semana
                            If iUnidadInicio = 0 Then
                                iUnidadInicio = 1
                            End If
                            If iUnidadInicio > 7 Then
                                iUnidadInicio = 7
                            End If
                            If iIntervalo = 0 Then
                                If iDiaSemana = iUnidadInicio Then
                                    bConsiderar = True
                                End If
                            Else
                                iCiclo = iUnidadInicio
                                For iIteraciones = 0 To iRepeticion
                                    If iDiaSemana = iCiclo Then
                                        bConsiderar = True
                                        Exit For
                                    End If
                                    iCiclo += iIntervalo
                                Next
                            End If
                        Case DBCentral.TiposFrecuencias.Mes
                            If iUnidadInicio = 0 Then
                                iUnidadInicio = 1
                            End If
                            If iUnidadInicio > Date.DaysInMonth(iAño, iMes) Then
                                iUnidadInicio = Date.DaysInMonth(iAño, iMes)
                            End If
                            If iIntervalo = 0 Then
                                If iDia = iUnidadInicio Then
                                    bConsiderar = True
                                End If
                            Else
                                iCiclo = iUnidadInicio
                                For iIteraciones = 0 To iRepeticion
                                    If iDia = iCiclo Then
                                        bConsiderar = True
                                        Exit For
                                    End If
                                    iCiclo += iIntervalo
                                Next
                            End If
                        Case DBCentral.TiposFrecuencias.Año
                            If iUnidadInicio = 0 Then
                                iUnidadInicio = 1
                            End If
                            If iUnidadInicio > General.NumeroDiasAño(iAño) Then
                                iUnidadInicio = General.NumeroDiasAño(iAño)
                            End If
                            If iIntervalo = 0 Then
                                If iDiaAnyo = iUnidadInicio Then
                                    bConsiderar = True
                                End If
                            Else
                                iCiclo = iUnidadInicio
                                For iIteraciones = 0 To iRepeticion
                                    If iDiaAnyo = iCiclo Then
                                        bConsiderar = True
                                        Exit For
                                    End If
                                    iCiclo += iIntervalo
                                Next
                            End If
                    End Select
                    If bConsiderar Then
                        refparsListaFrecuencias &= "'" & sFrecuencia.Replace("'", "''") & "',"
                    End If
                Next
                If refparsListaFrecuencias <> "" Then
                    refparsListaFrecuencias = Mid(refparsListaFrecuencias, 1, Len(refparsListaFrecuencias) - 1)
                End If
                Return (refparsListaFrecuencias <> "")
            Catch ExcW As Exception
                Throw New Exception("Error: " & ExcW.Message)
            End Try
            Return False
        End Function

        Private Function LlenarAgendaVendedor(ByVal parsListaFrecuencias As String, ByVal parsDiaClave As String, ByVal parsVendedorID As String, ByVal parbFueraFrecuencia As Boolean) As Boolean
            'Dim sEsquemas = RegresaEsquemasVendedor(parsVendedorID)
            ' Generar el contenido de la tabla de Agenda
            Dim sComandoSQL As New Text.StringBuilder
            Dim bGenero As Boolean = False
            ' Recuperar los clientes a visitar para el vendedor actual, en el orden de Secuencia
            sComandoSQL.Append("create table #TmpEsquemas(EsquemaID varchar(16) COLLATE database_default) ")
            sComandoSQL.Append("insert #TmpEsquemas exec spEsquemasVendedorAgenda '" & parsVendedorID & "' ")
            sComandoSQL.Append("INSERT INTO Agenda (DiaClave,VendedorID,FrecuenciaClave,RUTClave,Orden,ClienteClave,Visitado) ")
            sComandoSQL.Append("SELECT DISTINCT '" & parsDiaClave & "' AS DiaClave, '" & parsVendedorID & "' as VendedorID, Secuencia.FrecuenciaClave, Secuencia.RUTClave, Secuencia.Orden, Secuencia.ClienteClave, 2 AS Visitado ")
            sComandoSQL.Append("FROM Esquema INNER JOIN ClienteEsquema ON Esquema.EsquemaID = ClienteEsquema.EsquemaID ")
            sComandoSQL.Append("and Esquema.EsquemaID in(select EsquemaId from #TmpEsquemas) and Esquema.TipoEstado=1 ")
            sComandoSQL.Append("INNER JOIN Secuencia ON ClienteEsquema.ClienteClave = Secuencia.ClienteClave and ((not Secuencia.RUTClave is null) and (not Secuencia.Orden is null)) and Secuencia.Orden>0 ")
            sComandoSQL.Append("inner join Ruta on Ruta.RUTClave  = Secuencia.RUTClave and Ruta.TipoEstado = 1 ")
            sComandoSQL.Append("inner join VenRut on Ruta.RUTClave = VenRut.RUTClave and  VenRut.VendedorID = '" & parsVendedorID & "' and VenRut.TipoEstado = 1 ")
            sComandoSQL.Append("inner join Vendedor on Vendedor.VendedorID = VenRut.VendedorID ")
            sComandoSQL.Append("inner join ModuloTerm on dbo.FNObtenerModuloClave(vendedor.MCNClave) =ModuloTerm.ModuloClave ")
            sComandoSQL.Append("inner join (select Top 1 VendedorID,AlmacenID from VENCentroDistHist where VENCentroDistHist.VendedorID= '" & parsVendedorID & "' order by VCHFechaInicial desc) as  VENCentroDistHist on Vendedor.VendedorID = VENCentroDistHist.VendedorID ")
            sComandoSQL.Append("inner join Almacen on VENCentroDistHist.AlmacenID = Almacen.AlmacenID  and Almacen.Tipo =1 ")
            sComandoSQL.Append("INNER JOIN Cliente ON ClienteEsquema.ClienteClave = Cliente.ClienteClave and Cliente.TipoEstado = 1 ")
            sComandoSQL.Append("WHERE (Secuencia.FrecuenciaClave IN (" & parsListaFrecuencias & "))  and RUTA.Tipo = ModuloTerm.TipoIndice ")
            If Not parbFueraFrecuencia Then
                sComandoSQL.Append(" UNION ")
                sComandoSQL.Append("SELECT SECT.DiaClave, '" & parsVendedorID & "',SECT.FrecuenciaClave, SECT.RUTClave, SECT.Orden,SECT.ClienteClave, 2 as Visitado ")
                sComandoSQL.Append("FROM SecuenciaTemporal SECT ")
                sComandoSQL.Append("INNER JOIN  VenRut VER ON VER.VendedorID = '" & parsVendedorID & "' and SECT.RUTClave = VER.RUTClave ")
                sComandoSQL.Append("WHERE DiaClave='" & parsDiaClave & "' ")
            End If

            sComandoSQL.Append("drop table #TmpEsquemas ")
            ConexionSQL.EjecutarComando(sComandoSQL.ToString)

            If parbFueraFrecuencia Then
                Return False
            End If

            'Llenar la tabla AgendaVendedor
            sComandoSQL = New Text.StringBuilder
            ' Recuperar los clientes a visitar para el vendedor actual, en el orden de Secuencia
            sComandoSQL.Append("create table #TmpEsquemas(EsquemaID varchar(16) COLLATE database_default) ")
            sComandoSQL.Append("insert #TmpEsquemas exec spEsquemasVendedorAgenda '" & parsVendedorID & "' ")
            sComandoSQL.Append("INSERT INTO AgendaVendedor (DiaClave,VendedorID,FrecuenciaClave,RUTClave,Orden,ClienteClave,ClaveCEDI) ")
            sComandoSQL.Append("SELECT DISTINCT '" & parsDiaClave & "' AS DiaClave, '" & parsVendedorID & "' as VendedorID, Secuencia.FrecuenciaClave, Secuencia.RUTClave, Secuencia.Orden, Secuencia.ClienteClave, Almacen.Clave ")
            sComandoSQL.Append("FROM Esquema INNER JOIN ClienteEsquema ON Esquema.EsquemaID = ClienteEsquema.EsquemaID ")
            sComandoSQL.Append("and Esquema.EsquemaID in(select EsquemaId from #TmpEsquemas) and Esquema.TipoEstado=1 ")
            sComandoSQL.Append("INNER JOIN Secuencia ON ClienteEsquema.ClienteClave = Secuencia.ClienteClave and ((not Secuencia.RUTClave is null) and (not Secuencia.Orden is null)) and Secuencia.Orden>0 ")
            sComandoSQL.Append("inner join Ruta on Ruta.RUTClave  = Secuencia.RUTClave and Ruta.TipoEstado = 1 ")
            sComandoSQL.Append("inner join VenRut on Ruta.RUTClave = VenRut.RUTClave and  VenRut.VendedorID = '" & parsVendedorID & "' and VenRut.TipoEstado = 1 ")
            sComandoSQL.Append("inner join Vendedor on Vendedor.VendedorID = VenRut.VendedorID ")
            sComandoSQL.Append("inner join ModuloTerm on dbo.FNObtenerModuloClave(vendedor.MCNClave) =ModuloTerm.ModuloClave ")
            sComandoSQL.Append("inner join (select Top 1 VendedorID,AlmacenID from VENCentroDistHist where VENCentroDistHist.VendedorID= '" & parsVendedorID & "' order by VCHFechaInicial desc) as  VENCentroDistHist on Vendedor.VendedorID = VENCentroDistHist.VendedorID ")
            sComandoSQL.Append("inner join Almacen on VENCentroDistHist.AlmacenID = Almacen.AlmacenID  and Almacen.Tipo =1 ")
            sComandoSQL.Append("INNER JOIN Cliente ON ClienteEsquema.ClienteClave = Cliente.ClienteClave and Cliente.TipoEstado = 1 ")
            sComandoSQL.Append("WHERE (Secuencia.FrecuenciaClave IN (" & parsListaFrecuencias & "))  and RUTA.Tipo = ModuloTerm.TipoIndice ORDER BY Secuencia.Orden ")
            sComandoSQL.Append("drop table #TmpEsquemas ")
            ConexionSQL.EjecutarComando(sComandoSQL.ToString)

            'Revisar si se generó agenda para el día y vendedor
            sComandoSQL = New Text.StringBuilder
            sComandoSQL.Append("select count(*) from AgendaVendedor where DiaClave = '" & parsDiaClave & "' and VendedorId = '" & parsVendedorID & "' ")
            bGenero = (ConexionSQL.EjecutarConsultaObjeto(sComandoSQL.ToString) > 0)
            Return bGenero
        End Function

        Public Function RegresaEsquemasVendedor(ByVal parsVendedorId As String) As String
            Dim dt As DataTable = ConexionSQL.RealizarConsulta("Select EsquemaID from VendedorEsquema where VendedorID='" & parsVendedorId & "' and TipoEstado = 1")
            Dim sNodoPadre As String = String.Empty
            Dim sEsquemas As String = String.Empty

            For Each dr As DataRow In dt.Rows
                sNodoPadre = dr(0)
                sEsquemas &= "'" & sNodoPadre & "',"
                BuscarNodosArbol(sEsquemas, sNodoPadre)
            Next
            sEsquemas = Left(sEsquemas, sEsquemas.Length - 1)
            Return sEsquemas
        End Function
        'Regresa los esquemas separados por comas
        Private Function BuscarNodosArbol(ByRef refsEsquemas As String, ByVal parsNodo As String) As Boolean
            'Try
            Dim sNodo As String = String.Empty
            Dim dt As DataTable = ConexionSQL.RealizarConsulta("Select EsquemaID from Esquema where EsquemaIDPadre='" & parsNodo & "'")
            For Each dr As DataRow In dt.Rows
                sNodo = dr("EsquemaID")
                If Not refsEsquemas.Contains("'" & sNodo & "'") Then
                    refsEsquemas &= "'" & sNodo & "',"
                    BuscarNodosArbol(refsEsquemas, sNodo)
                End If
            Next
            Return True
            'Catch ExcA As Exception
            '    MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodosArbol")
            'End Try
            Return False
        End Function

        Public Function ActualizarCaptura(ByVal paroDataSet As DataSet, ByVal pardFechaIni As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String, ByRef refReintentar As Boolean) As Boolean
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
                Dim dtTransProd As DataTable
                For Each refDataTable As DataTable In paroDataSet.Tables
                    sTabla = refDataTable.TableName.ToUpper()
                    'Cambio para solucionar problema de ALEN cuando la terminal cambia la fecha incorrecta en la preliquidación
                    If refDataTable.TableName.ToUpper = "PRELIQUIDACION" Then
                        Dim drIncorrectos As DataRow() = refDataTable.Select("FechaPreLiquidacion< " & General.UniFechaSQL(pardFechaPrimerDia) & " or FechaPreLiquidacion> " & General.UniFechaSQL(UltimaHora(pardFechaPrimerDia)))
                        If drIncorrectos.Length > 0 Then
                            For Each dr As DataRow In drIncorrectos
                                dr("FechaPreLiquidacion") = pardFechaPrimerDia
                            Next
                        End If
                    End If

                    If refDataTable.TableName.ToUpper <> "FOLIOFISCAL" Then
                        If Not Me.ActualizarTabla(Me.UsuarioId, refDataTable, oCommand, refparsMensaje) Then
                            'refparsMensaje &= sMensaje & vbLf & vbCr
                        End If
                    End If
                    If refDataTable.TableName.ToUpper = "TRANSPROD" Then
                        dtTransProd = refDataTable
                    ElseIf refDataTable.TableName.ToUpper = "TRANSPRODDETALLE" Then
                        ActivarProductos(refDataTable, oCommand, dtTransProd)
                        ActualizarCargas(refDataTable, oCommand, dtTransProd)
                    ElseIf refDataTable.TableName.ToUpper = "CLICAP" Then
                        ActivarProductos(refDataTable, oCommand)
                    ElseIf refDataTable.TableName.ToUpper = "PUNTO" Then
                        oCommand.Parameters.Clear()
                        oCommand.CommandText = "Update punto WITH (ROWLOCK) set Saldo = CASE When Saldo<0 Then 0 Else Saldo End, Saldo1 = case When Saldo1<0 Then 0 else Saldo1 end, Venta = case When Venta<0 Then 0 Else Venta End where Saldo<0 or Saldo1<0 or Venta<0 "
                        oCommand.ExecuteNonQuery()
                    ElseIf refDataTable.TableName.ToUpper = "FOLIOFISCAL" Then
                        ActualizarFoliosFiscales(refDataTable, dtTransProd, oCommand, refparsMensaje)
                    End If
                Next
                oTransaccion.Commit()

             
                oCommand.Parameters.Clear()
                oCommand.CommandText = "Insert into tmp_EnvioVendedor values('" & Me.VendedorId & "',getdate()) "
                oCommand.ExecuteNonQuery()
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
                        refparsMensaje = Aplicacion.ObtenerMensaje("P0101")
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

        Public Function EjecutarInterfaces(ByVal pardFechaIni As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String, ByRef refReintentar As Boolean) As Boolean
            Dim oConnection As SqlClient.SqlConnection
            Dim oTransaccion As SqlClient.SqlTransaction
            Dim oCommand As SqlClient.SqlCommand
            Dim oLog As New cLog(Me.VendedorId, Me.Clave, pardFechaIni, pardFechaPrimerDia)
            Dim correcto As Boolean = True
            Try
                oConnection = New SqlClient.SqlConnection
                oConnection.ConnectionString = ServicesCentral.Configuracion.CadenaConexionSQL
                oConnection.Open()
                oTransaccion = oConnection.BeginTransaction(IsolationLevel.ReadUncommitted)
                oCommand = New SqlClient.SqlCommand
                oCommand.Connection = oConnection
                oCommand.Transaction = oTransaccion
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")

                Try
                    'dtTransProd = ConexionSQL.RealizarConsulta("select tra.TransProdId,tra.folio from trpdatofiscal trp inner join transprod tra on tra.transprodid=trp.transprodid where  tra.mfechahora between '" & pardFechaIni.ToString("s") & "' and getdate() and tra.musuarioid='" & Me.UsuarioId & "'", "TransProd")
                    Dim dtTransProd As DataTable = ConexionSQL.RealizarConsulta("select tra.TransProdId,tra.folio,tra.SubEmpresaID from trpdatofiscal trp inner join transprod tra on tra.transprodid=trp.transprodid where (tra.tipomotivo not in (10,11) or tra.tipomotivo is null) and  tra.tipofase<>0 and  tra.mfechahora between '" & pardFechaIni.ToString("s") & "' and '" & Now.ToString("s") & "' and tra.musuarioid='" & Me.UsuarioId & "'", "TransProd")
                    If dtTransProd.Rows.Count > 0 Then
                        oLog.Agregar("Inicia Generacion XML's", False, "", False)
                        oLog.Guardar()
                    End If
                    For i As Integer = 0 To dtTransProd.Rows.Count - 1
                        GenerarXML(dtTransProd.Rows(i)("TransProdId"), dtTransProd.Rows(i)("Folio"), dtTransProd.Rows(i)("SubEmpresaID"))
                    Next
                    If dtTransProd.Rows.Count > 0 Then
                        oLog.Agregar("Finaliza Generacion XML's", False, "", False)
                    End If
                Catch ex As Exception
                    oLog.Agregar("Error Generacion XML's", False, ex.Message, True)
                    correcto = False
                    Throw New System.Web.Services.Protocols.SoapException("Error al Generar los Archivos XML", New System.Xml.XmlQualifiedName("GenerarXML", "ServiceCentral"))
                End Try

                Try
                    oLog.Agregar("Inicia Interfaces de Salida", False, "", False)
                    oLog.Guardar()
                    'If ConexionSQL.EjecutarCmdScalarStrSQL("select top 1 InterfazTXT from Conhist with (NOLOCK) order by ConHistFechaInicio desc") = "1" Then
                    '    DispararDTSExportacion(pardFechaIni, refparsMensaje)
                    'Else
                    correcto = DispararStoreProceduresExportacion(pardFechaIni, pardFechaPrimerDia, refparsMensaje)
                    'End If
                    If correcto Then
                        oLog.Agregar("Finaliza Interfaces de Salida", True, "", False)
                    Else
                        oLog.Agregar("Error Interfaces de Salida", False, refparsMensaje, True)
                    End If
                Catch ex As Exception
                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427")
                    oLog.Agregar("Error Interfaces de Salida", False, ex.Message, True)
                    correcto = False
                End Try
                oCommand.Parameters.Clear()
                oCommand.CommandText = "Insert into tmp_EnvioVendedor values('" & Me.VendedorId & "',getdate()) "
                oCommand.ExecuteNonQuery()
                oTransaccion.Commit()
            Catch ex As SqlClient.SqlException
                Select Case ex.Number
                    Case 2
                        oLog.Agregar("Error", False, "No se pudo establecer conexión con el servidor de SQL.", True)
                        oLog.Guardar()
                        oConnection.Close()
                        Throw New System.Web.Services.Protocols.SoapException("No se pudo establecer conexión con el servidor de SQL.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 17142
                        oLog.Agregar("Error", False, "El servicio de SQL ha sido pausado.", True)
                        oLog.Guardar()
                        oConnection.Close()
                        Throw New System.Web.Services.Protocols.SoapException("El servicio de SQL ha sido pausado.", New System.Xml.XmlQualifiedName("SQLCON", "ServiceCentral"))
                    Case 1205
                        refReintentar = True
                        refparsMensaje = Aplicacion.ObtenerMensaje("P0101")
                    Case Else
                        refReintentar = False
                        refparsMensaje &= ex.Message
                End Select
                oLog.Agregar("Error", False, refparsMensaje, True)
                oTransaccion.Rollback()
                correcto = False
            Catch ex As Exception
                refReintentar = False
                refparsMensaje &= ex.Message
                oLog.Agregar("Error", False, refparsMensaje, True)
                oTransaccion.Rollback()
                correcto = False
            Finally
                oLog.Guardar()
                oCommand.Dispose()
                oConnection.Close()
            End Try
            Return correcto
        End Function

        Public Function ActualizarCapturaHTTP(ByVal pardFechaIni As Date, ByVal pardFechaPrimerDia As Date, ByVal parsNombreArchivo As String) As String
            If Not System.IO.Directory.Exists(ServicesCentral.Configuracion.Directorio) Then
                Throw New System.Web.Services.Protocols.SoapException("No existe el directorio " & ServicesCentral.Configuracion.Directorio, New System.Xml.XmlQualifiedName("General", "ServiceCentral"))
            End If

            Dim dt As DataTable = ConexionSQL.RealizarConsulta("Select '" & Me.UsuarioId & "' as Usuario, '" & Me.Clave & "' as Clave, '" & Me.Nombre & "' as Nombre, " & General.UniFechaSQL(pardFechaIni).ToString & " as FechaIni," & General.UniFechaSQL(pardFechaPrimerDia).ToString & " as FechaPrimerDia, " & General.UniFechaSQL(Now).ToString & " as FechaFin, '" & parsNombreArchivo & "' as NombreArchivo, '' as Error", "Tarea")
            Dim sNombreTarea As String = "VSAL" & Me.UsuarioId & "-" & Now.ToString("yyyyMMddhhmmss") & ".xml"
            dt.WriteXml(ServicesCentral.Configuracion.Directorio & "\" & sNombreTarea)
            Try
                Dim pvSC As New System.ServiceProcess.ServiceController("RouteDBService")
                pvSC.ExecuteCommand(150)
                Return sNombreTarea
            Catch ex As Exception
                Throw New System.Web.Services.Protocols.SoapException(ex.Message, New System.Xml.XmlQualifiedName("ServicioWindows", "ServiceCentral"))
            End Try
            Return String.Empty
        End Function

        'Public Sub DispararDTSExportacion(ByVal pardFechaIni As Date, ByRef refparsMensaje As String)
        '    Dim sDirDocumentos As String = String.Empty
        '    Try
        '        sDirDocumentos = ConexionSQL.EjecutarCmdScalarStrSQL("Select Top 1 DirInterfaz from CONHist where CONHistFechaInicio <= getdate() order by CONHistFechaInicio desc ")
        '    Catch ex As Exception

        '    End Try

        '    If sDirDocumentos <> String.Empty Then
        '        sDirDocumentos &= "\DTS"

        '        Dim sDestinoArchivos As String = String.Empty
        '        Dim dt As DataTable = ConexionSQL.RealizarConsulta("Select DirInterfazSalida from Vendedor where VendedorID = '" & Me.VendedorId & "'")
        '        If dt.Rows.Count > 0 Then
        '            sDestinoArchivos = IIf(IsDBNull(dt.Rows(0)(0)), String.Empty, dt.Rows(0)(0))
        '            If sDestinoArchivos <> String.Empty Then
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Activos.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Activos.dts")
        '                'End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Cuentas X Cobrar.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Cuentas X Cobrar.dts")
        '                End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Clientes.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Clientes.dts")
        '                End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Cuotas.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Cuotas.dts")
        '                'End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Depositos.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Depositos.dts")
        '                End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar DevCliente.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar DevCliente.dts")
        '                End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Encuesta.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Encuesta.dts")
        '                'End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Gastos.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Gastos.dts")
        '                'End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Improductividad Venta.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Improductividad Venta.dts")
        '                'End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar ImproductividadProd.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar ImproductividadProd.dts")
        '                'End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Pagos.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Pagos.dts")
        '                End Try
        '                Try
        '                    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Pedidos.dts", sDestinoArchivos, pardFechaIni)
        '                Catch ex As Exception
        '                    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Pedidos.dts")
        '                End Try
        '                'Try
        '                '    EjecutarDTS(sDirDocumentos & "\ROUTE_Exportar Solicitudes.dts", sDestinoArchivos, pardFechaIni)
        '                'Catch ex As Exception
        '                '    refparsMensaje &= Aplicacion.ObtenerMensaje("E0427").Replace("$0$", "ROUTE_Exportar Solicitudes")
        '                'End Try
        '            Else
        '                refparsMensaje &= Aplicacion.ObtenerMensaje("E0426")
        '            End If
        '        End If

        '    End If
        'End Sub

        Public Function DispararStoreProceduresExportacion(ByVal pardFechaIni As Date, ByVal pardFechaPrimerDia As Date, ByRef refparsMensaje As String) As Boolean

            'Ejecutar todos los Store Procedures activos
            Dim dtINTSAL As DataTable = ConexionSQL.RealizarConsulta("Select procedimiento,tipofecha from InterfazSalida where TipoEstado = 1 ")
            Try

                For Each dr As DataRow In dtINTSAL.Rows
                    If dr("tipofecha") = 1 Then
                        'Todas con excepciones
                        ConexionSQL.EjecutarComando(String.Format("{0} '{1}','{2}','{3}'", dr("Procedimiento"), pardFechaIni.ToString("s"), Now.ToString("s"), Me.Clave))
                    ElseIf dr("tipofecha") = 2 Then
                        'Jornadas TRabajo
                        ConexionSQL.EjecutarComando(String.Format("{0} '{1}','{2}','{3}'", dr("Procedimiento"), pardFechaPrimerDia.ToString("s"), UltimaHora(DateTime.Now).ToString("s"), Me.Clave))
                    ElseIf dr("tipofecha") = 3 Then
                        '(Dia de Trabajo) BajoCero
                        ConexionSQL.EjecutarComando(String.Format("{0} '{1}','{2}','{3}'", dr("Procedimiento"), New Date(9999, 12, 31).ToString("s"), Now.ToString("s"), Me.Clave))
                    End If
                Next
                dtINTSAL.Dispose()
            Catch ex As Exception

                refparsMensaje += ex.Message
                dtINTSAL.Dispose()
                Return False

            End Try
            Return True

        End Function

        Public Function UltimaHora(ByVal parFecha As Date) As Date
            Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 23, 59, 59)
            Return f2
        End Function

        'Public Sub EjecutarDTS(ByVal parsPathDTS As String, ByVal parsPathDestino As String, ByVal pardFechaIni As Date)
        '    Dim oDTS As New SQLServerServices.CDTS

        '    Dim oParams As ArrayList
        '    oParams = oDTS.ListofParams(parsPathDTS)

        '    Dim oParam As SQLServerServices.Parametros
        '    oParam = oParams(0)
        '    oParam.Valor = pardFechaIni

        '    oParam = oParams(1)
        '    oParam.Valor = Now

        '    oParam = oParams(2)
        '    oParam.Valor = Me.Clave

        '    oDTS.ExecutePackage(parsPathDTS, parsPathDestino, oParams)
        '    oDTS = Nothing
        'End Sub
        Private Sub ActivarProductos(ByVal parDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, Optional ByVal pardtTransProd As DataTable = Nothing)
            Dim drs() As DataRow
            Dim sProductoClave As String = String.Empty
            Select Case parDataTable.TableName.ToUpper
                Case "TRANSPRODDETALLE"
                    Dim sTransProdIds As String = String.Empty
                    If Not IsNothing(pardtTransProd) Then
                        Dim drTransProd() As DataRow
                        drTransProd = pardtTransProd.Select(" Tipo in(1,8,16) ")
                        For Each dr As DataRow In drTransProd
                            sTransProdIds &= "'" & dr("TransProdID") & "',"
                        Next
                        If sTransProdIds <> String.Empty Then
                            sTransProdIds = Left(sTransProdIds, sTransProdIds.Length - 1)
                            drs = parDataTable.Select(" TransProdID in(" & sTransProdIds & ") ")
                        End If
                    End If
                Case "CLICAP"
                    drs = parDataTable.Select(" FechaCanje is null ")
            End Select
            If Not IsNothing(drs) Then
                For Each dr As DataRow In drs
                    sProductoClave &= "'" & dr("ProductoClave") & "',"
                Next
                If sProductoClave <> String.Empty Then
                    sProductoClave = Left(sProductoClave, sProductoClave.Length - 1)
                    refparoComando.Parameters.Clear()
                    refparoComando.CommandText = "Update Producto WITH (ROWLOCK) set TipoFase=1, MFechaHora= " & General.UniFechaSQL(Now) & " , MUsuarioID='" & Me.UsuarioId & "' where ProductoClave in(" & sProductoClave & ") and TipoFase<>1"
                    refparoComando.ExecuteNonQuery()
                End If
            End If
        End Sub

        Private Sub ActualizarCargas(ByVal parDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, Optional ByVal pardtTransProd As DataTable = Nothing)
            Dim drs() As DataRow
            Dim sTransProdDetalleID As String = String.Empty
            Dim sTransProdIds As String = String.Empty
            Select Case parDataTable.TableName.ToUpper
                Case "TRANSPRODDETALLE"

                    If Not IsNothing(pardtTransProd) Then
                        Dim drTransProd() As DataRow
                        drTransProd = pardtTransProd.Select(" Tipo = 2 ")
                        For Each dr As DataRow In drTransProd
                            sTransProdIds &= "'" & dr("TransProdID") & "',"
                        Next
                        If sTransProdIds <> String.Empty Then
                            sTransProdIds = Left(sTransProdIds, sTransProdIds.Length - 1)
                            drs = parDataTable.Select(" TransProdID in(" & sTransProdIds & ") ")
                        End If
                    End If
            End Select
            If Not IsNothing(drs) Then
                For Each dr As DataRow In drs
                    sTransProdDetalleID &= "'" & dr("TransProdDetalleID") & "',"
                Next
                If sTransProdDetalleID <> String.Empty Then
                    sTransProdDetalleID = Left(sTransProdDetalleID, sTransProdDetalleID.Length - 1)
                    refparoComando.Parameters.Clear()
                    refparoComando.CommandText = "Update TransProdDetalle WITH (ROWLOCK) set TransProdDetalle.Cantidad=0, TransProdDetalle.MFechaHora= " & General.UniFechaSQL(Now) & " , TransProdDetalle.MUsuarioID='" & Me.UsuarioId & "' from TransProdDetalle  inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID where TransProd.Tipo = 2 and TransProdDetalle.TransProdDetalleID not in(" & sTransProdDetalleID & ") and TransProdDetalle.TransProdID in(" & sTransProdIds & ")"
                    refparoComando.ExecuteNonQuery()
                End If
            End If
        End Sub


        Private Function ActualizarTabla(ByVal parsUsuarioClave As String, ByRef refparDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, ByRef refparsMensaje As String) As Boolean
            Dim sComandoUpdate As String = String.Empty
            Dim sComandoInsert As String = String.Empty
            Dim sComandoInsertValores As String = String.Empty
            ' Cambios 23 Abril - Quitar esta variable
            'Dim sLlave As String
            ' /Cambios 23 Abril
            Dim sNombreTabla As String = refparDataTable.TableName
            Dim blnSaldos As Boolean = False
            If Not refparDataTable.PrimaryKey Is Nothing Then
                ' Agregar los parametros
                Dim refDataColumn As DataColumn
                refparoComando.Parameters.Clear()

                If sNombreTabla.Contains("Eliminar") Then
                    Return EliminarRegistros(refparDataTable, refparoComando)

                End If
                If sNombreTabla.ToUpper = "TRANSPROD" OrElse sNombreTabla.ToUpper = "PRODUCTOPRESTAMO" OrElse sNombreTabla.ToUpper = "ABONO" OrElse sNombreTabla.ToUpper = "ABNDETALLE" OrElse sNombreTabla.ToUpper = "PUNTO" OrElse sNombreTabla.ToUpper = "CLIENTE" OrElse sNombreTabla.ToUpper = "ABONOPROGRAMADO" Then
                    blnSaldos = True
                End If



                
                ' Insertar los registros del Dataset en la base de datos
                Dim refDataRow As DataRow
                For Each refDataRow In refparDataTable.Rows
                    sComandoUpdate = ""
                    sComandoInsert = ""
                    For Each refDataColumn In refparDataTable.Columns
                        'No agregar SaldoCarga porque no existe en la Tabla PRODUCTOPRESTAMOCLI del escritorio 
                        If sNombreTabla.ToUpper <> "PRODUCTOPRESTAMOCLI" Or (sNombreTabla.ToUpper = "PRODUCTOPRESTAMOCLI" And refDataColumn.ColumnName.ToUpper <> "SALDOCARGA") Then
                            If sComandoUpdate = "" Then

                                sComandoUpdate = "UPDATE " & sNombreTabla & " SET "
                                sComandoInsert = "INSERT INTO " & sNombreTabla & " ("
                            Else
                                sComandoInsert &= ", "
                            End If
                            sComandoInsert &= refDataColumn.ColumnName
                        End If
                    Next

                    sComandoInsert &= ") VALUES (" '& sComandoInsertValores & ")"

                    If sNombreTabla.ToUpper = "TRANSPROD" OrElse sNombreTabla.ToUpper = "TRANSPRODDETALLE" OrElse sNombreTabla.ToUpper = "ABNTRP" Then
                        sComandoInsert = sComandoInsert.Replace(") VALUES (", ",TipoFaseIntSal) VALUES (")
                        sComandoUpdate &= "TipoFaseIntSal=2,"
                    End If
                    ' Buscar primero si el registro ya existe
                    refparoComando.Parameters.Clear()
                    ' Cambios 23 Abril
                    refparoComando.CommandText = "SELECT COUNT(*) AS TotalRegistros FROM " & sNombreTabla & " WHERE "
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
                    Dim iNumRegs As Integer
                    Try
                        iNumRegs = refparoComando.ExecuteScalar()
                    Catch ex As Exception
                        MsgBox("Error")
                    End Try
                    refparoComando.Parameters.Clear()
                    ' Colocar los valores del registro en los parametros
                    Dim sDatos As String = String.Empty
                    For Each refDataColumn In refparDataTable.Columns
                        If iNumRegs = 0 Then
                            ' No existe, agregarlo
                            Select Case refDataColumn.DataType.Name.ToUpper
                                Case "STRING"
                                    If sNombreTabla.ToUpper = "ENPRESPIMAGEN" And refDataColumn.ColumnName.ToUpper = "IMAGEN" Then
                                        If refDataRow.IsNull(refDataColumn.ColumnName) OrElse refDataColumn.ColumnName = "" Then
                                            sDatos &= "0x0" & ","
                                        ElseIf Not System.IO.File.Exists(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta\" & RTrim(refDataRow(refDataColumn.ColumnName)) & ".jpg") Then
                                            sDatos &= "0x0" & ","
                                        Else
                                            Dim oImagen As System.Drawing.Bitmap
                                            Dim msImagen As New System.IO.MemoryStream

                                            oImagen = New System.Drawing.Bitmap(ServicesCentral.Configuracion.Directorio & "\ImagenEncuesta\" & RTrim(refDataRow(refDataColumn.ColumnName)) & ".jpg")
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
                                    'Dim vlBit As Byte
                                    'If Not IsArray(refDataRow(refDataColumn.ColumnName)) OrElse CType(refDataRow(refDataColumn.ColumnName), Array).GetUpperBound(0) < 0 OrElse Not TypeOf CType(refDataRow(refDataColumn.ColumnName), Array)(0) Is Byte Then
                                    '    sDatos &= "0x0"
                                    'Else
                                    '    Dim vlHex As String = ""
                                    '    For Each vlBit In refDataRow(refDataColumn.ColumnName)
                                    '        vlHex &= vlBit.ToString("X2")
                                    '    Next
                                    '    sDatos &= "0x" & vlHex.ToString & ","
                                    'End If
                                Case Else
                                    If sNombreTabla.ToUpper <> "PRODUCTOPRESTAMOCLI" Or (sNombreTabla.ToUpper = "PRODUCTOPRESTAMOCLI" And refDataColumn.ColumnName.ToUpper <> "SALDOCARGA") Then
                                        If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                            sDatos &= "NULL" & ","
                                        Else
                                            Dim sValor As New Text.StringBuilder(RTrim(refDataRow(refDataColumn.ColumnName)))
                                            ' Cambiar las comas decimales por los puntos decimales
                                            sValor.Replace(",", ".")
                                            sDatos &= sValor.ToString & ","
                                        End If
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
                                    'Dim vlBit As Byte
                                    'If Not IsArray(refDataRow(refDataColumn.ColumnName)) OrElse CType(refDataRow(refDataColumn.ColumnName), Array).GetUpperBound(0) < 0 OrElse Not TypeOf CType(refDataRow(refDataColumn.ColumnName), Array)(0) Is Byte Then
                                    '    sDatos &= refDataColumn.ColumnName & "=0x0"
                                    'Else
                                    '    Dim vlHex As String = ""
                                    '    For Each vlBit In refDataRow(refDataColumn.ColumnName)
                                    '        vlHex &= vlBit.ToString("X2")
                                    '    Next
                                    '    sDatos &= refDataColumn.ColumnName & "=0x" & vlHex.ToString & ","
                                    'End If
                                Case Else
                                    If sNombreTabla.ToUpper <> "PRODUCTOPRESTAMOCLI" Or (sNombreTabla.ToUpper = "PRODUCTOPRESTAMOCLI" And refDataColumn.ColumnName.ToUpper <> "SALDOCARGA") Then
                                        If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                            sDatos &= refDataColumn.ColumnName & "=" & "NULL" & ","
                                        Else
                                            Dim sValor As Text.StringBuilder
                                            If (sNombreTabla.ToUpper = "PRODUCTOPRESTAMOCLI" And refDataColumn.ColumnName.ToUpper = "SALDO") Then
                                                refparoComando.CommandText = "SELECT Saldo FROM " & sNombreTabla & " WHERE " & sFiltro
                                                Dim lSaldoServidor As Integer = refparoComando.ExecuteScalar()
                                                sValor = New Text.StringBuilder((lSaldoServidor + CDec(refDataRow(refDataColumn.ColumnName)) - CDec(refDataRow("SaldoCarga"))).ToString)
                                            Else
                                                sValor = New Text.StringBuilder(RTrim(refDataRow(refDataColumn.ColumnName)))
                                            End If
                                            ' Cambiar las comas decimales por los puntos decimales
                                            sValor.Replace(",", ".")

                                            If blnSaldos Then
                                                If (refDataColumn.ColumnName.Contains("Saldo") OrElse refDataColumn.ColumnName.Contains("Cantidad") OrElse refDataColumn.ColumnName.ToUpper = "VENTA" OrElse (sNombreTabla.ToUpper = "ABONOPROGRAMADO" And refDataColumn.ColumnName.ToUpper = "IMPORTE")) Then
                                                    sDatos &= refDataColumn.ColumnName & " = Round(" & refDataColumn.ColumnName & " + " & sValor.ToString + ",2),"
                                                Else
                                                    sDatos &= refDataColumn.ColumnName & "=" & sValor.ToString & ","
                                                End If
                                            Else
                                                sDatos &= refDataColumn.ColumnName & "=" & sValor.ToString & ","
                                            End If
                                        End If
                                    End If
                            End Select
                        End If

                    Next

                    If iNumRegs = 0 Then
                        ' No existe, agregarlo
                        If sNombreTabla.ToUpper = "TRANSPROD" OrElse sNombreTabla.ToUpper = "TRANSPRODDETALLE" OrElse sNombreTabla.ToUpper = "ABNTRP" Then
                            refparoComando.CommandText = sComandoInsert & Left(sDatos, sDatos.Length - 1) & ",0)"
                        Else
                            refparoComando.CommandText = sComandoInsert & Left(sDatos, sDatos.Length - 1) & ")"
                        End If


                    Else
                        ' Ya existe, actualizarlo
                        refparoComando.CommandText = sComandoUpdate & Left(sDatos, sDatos.Length - 1) & " WHERE " & sFiltro
                    End If

                    ' Agregar los datos 
                    refparoComando.ExecuteNonQuery()
                Next
            End If
            Return True
        End Function


        Private Function EliminarRegistros(ByRef refparDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand) As Boolean

            For Each refDataRow As DataRow In refparDataTable.Rows
                refparoComando.Parameters.Clear()
                Dim sCondicion As String = ""

                For Each refDataColumn As DataColumn In refparDataTable.PrimaryKey
                    If sCondicion <> "" Then
                        sCondicion &= " AND "
                    End If
                    sCondicion &= refDataColumn.ColumnName & " = @@" & refDataColumn.ColumnName

                    Dim oParam As New SqlClient.SqlParameter("@@" & refDataColumn.ColumnName, refDataRow.Item(refDataColumn.ColumnName))
                    refparoComando.Parameters.Add(oParam)
                Next
                refparoComando.CommandText = "DELETE FROM " & refparDataTable.TableName.Substring(8, refparDataTable.TableName.Length - 8) & " WHERE "
                refparoComando.CommandText &= sCondicion
                refparoComando.ExecuteNonQuery()
            Next

            Return True
        End Function

        Private Function ActualizarFoliosFiscales(ByVal dtFolios As DataTable, ByVal dtTransProd As DataTable, ByRef refparoComando As SqlClient.SqlCommand, ByRef sMensaje As String) As Boolean
            'Dim sConsulta As String = ""
            Dim bHayDiferencias As Boolean = False
            Dim sTransProd As String = ""
            refparoComando.Parameters.Clear()
            For Each drFolio As DataRow In dtFolios.Rows
                refparoComando.CommandText = "select top 1 FSHFechaInicio from FOSHist where FolioId = '" & drFolio("FolioId") & "' and FOSId = '" & drFolio("FOSId") & "' order by FSHFechaInicio desc"
                Dim dFechaInicio As Date = refparoComando.ExecuteScalar
                refparoComando.CommandText = "update FolioSolicitado set Usados = Usados + " & drFolio("Usados") & ", MFechaHora = " & General.UniFechaSQL(Now) & ", MUsuarioId = '" & Me.UsuarioId & "' where FolioId = '" & drFolio("FolioId") & "' and FOSId = '" & drFolio("FOSId") & "'"
                refparoComando.ExecuteNonQuery()

             
                If dFechaInicio <> drFolio("FSHFechaInicio") Then
                    For Each drTransProd As DataRow In dtTransProd.Select("Tipo in(8,10)")
                        sTransProd &= "'" & drTransProd("TransProdId") & "',"
                    Next
                    sTransProd = Left(sTransProd, sTransProd.Length - 1)
                    bHayDiferencias = True
                    refparoComando.CommandText = "update TransProd set TipoMotivo = 11 where tipomotivo is null and TransProdId in(" + sTransProd + ") and  TransProdId in (select TransProdId from TRPDatoFiscal where FolioId = '" & drFolio("FolioId") & "' and FOSId = '" & drFolio("FOSId") & "')"
                    refparoComando.ExecuteNonQuery()

                End If
            Next
            If bHayDiferencias Then
                sMensaje &= MobileClient.Aplicacion.ObtenerMensaje("I0179")
            End If
            Return True
        End Function
        Public Function ObtenerDescuentosFactura(ByVal Facturaid As String) As Double

            Dim vlConsulta As String = "select sum(descuento) as descuento " & _
            "from(select t.DescuentoImp + t.DescuentoVendedor + sum(d.descuentoimp) as descuento from transprod t " & _
            "inner join transproddetalle d on t.transprodid = d.transprodid where t.facturaid='" & Facturaid & "' group by  t.DescuentoImp, t.DescuentoVendedor) as t"
            Dim vlDT As DataTable = MobileClient.ConexionSQL.RealizarConsulta(vlConsulta)
            If vlDT Is Nothing OrElse vlDT.Rows.Count = 0 Then Return 0
            If IsDBNull(vlDT.Rows(0).Item("descuento")) Then Return 0

            Return vlDT.Rows(0).Item("descuento")

        End Function

        Public Function GenerarXML(ByVal pvTRP As String, ByVal Folio As String, ByVal parsSubEmpresaID As String) As Boolean
            Dim pObj As Process = New Process()
            Dim RutaXML As String = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("select Top 1 dirdocxml from SEMHist where SEMHistFechaInicio <=getdate() and SubEmpresaID='" & parsSubEmpresaID & "' order by  SEMHistFechaInicio desc")
            Dim sDirCFDADM As String = System.Configuration.ConfigurationManager.AppSettings("RutaCFDADM")
            Dim sCFDADMexe As String = System.IO.Path.Combine(sDirCFDADM, "CFDADM.exe")
            If System.IO.File.Exists(sCFDADMexe) Then
                pObj.StartInfo.FileName = sCFDADMexe
                pObj.StartInfo.WorkingDirectory = sDirCFDADM
                pObj.StartInfo.RedirectStandardOutput = True
                pObj.StartInfo.CreateNoWindow = True
                pObj.StartInfo.UseShellExecute = False
                pObj.StartInfo.Arguments = "5 " & pvTRP & " """ & RutaXML & """"
                pObj.Start()
                pObj.WaitForExit()
                If pObj.ExitCode <> 0 Then
                    Throw New Exception(pObj.StandardError.ReadToEnd())
                End If
                Dim NombreBitacora As String = "Err_5_" + pvTRP + ".txt"
                Dim RutaArchivo As String = System.IO.Path.Combine(System.IO.Path.GetFullPath(RutaXML), NombreBitacora)
                If System.IO.File.Exists(RutaArchivo) Then
                    Dim s As String = LeerBitacora(RutaArchivo)
                    System.IO.File.Delete(RutaArchivo)
                    Throw New Exception(s)
                Else
                    Return True
                End If
            Else
                Throw New Exception("No se generó la factura electronica " + sVendedorId + ". No se encontró el archivo " + sCFDADMexe)
            End If
            Return False
        End Function
        Private Function LeerBitacora(ByVal RutaArchivo As String) As String
            Dim stream As System.IO.FileStream = New System.IO.FileStream(RutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(stream)
            Dim sError As String = reader.ReadToEnd()
            reader.Close()
            reader.Dispose()
            Return sError
        End Function
        Private Function dValido(ByVal pvCadena As Object) As String
            If pvCadena.ToString = "" Then Return ""

            Return Format(pvCadena, "0.##")
        End Function

        Public Sub ImpuestosConDesc(ByVal IP_TransProdID As ArrayList, ByRef OP_Impuesto As ArrayList, ByRef OP_Tasa As ArrayList, ByRef OP_Importe As ArrayList)
            Dim vlconsulta As New System.Text.StringBuilder
            Dim vldt As DataTable
            OP_Impuesto = New ArrayList
            OP_Tasa = New ArrayList
            OP_Importe = New ArrayList

            vlconsulta.Append("select abreviatura, impuestopor as tasa, " & _
            " sum(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*isnull(td.DesPor,0)/100))-(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*(isnull(td.DesPor,0)/100)))*(trp.DescVendPor / 100))) AS importe " & _
            "from transprod trp " & _
            "inner join transproddetalle tpd on trp.transprodid =tpd.transprodid " & _
            "inner join tpdimpuesto tpi on tpi.transprodid =tpd.transprodid and tpi.transproddetalleid =tpd.transproddetalleid " & _
            "inner join impuesto imp on tpi.impuestoclave = imp.impuestoclave " & _
            "LEFT OUTER JOIN tpddes td on td.transprodid=tpd.transprodid and td.transproddetalleid = tpd.transproddetalleid ")
            If IP_TransProdID.Count > 0 Then
                vlconsulta.Append("where ")

                For i As Integer = 0 To IP_TransProdID.Count - 1
                    vlconsulta.Append(" trp.transprodid ='" & IP_TransProdID.Item(i) & "'")
                    If i = IP_TransProdID.Count - 1 Then Exit For

                    vlconsulta.Append(" or ")
                Next
            End If
            vlconsulta.Append("group by abreviatura,impuestopor")

            Try
                vldt = ConexionSQL.RealizarConsulta(vlconsulta.ToString, "Impuestos")
                For Each row As DataRow In vldt.Rows
                    OP_Impuesto.Add(row("abreviatura"))
                    OP_Tasa.Add(row("tasa"))
                    OP_Importe.Add(row("importe"))
                Next
                vldt.Dispose()
                vldt = Nothing
                vlconsulta = Nothing

            Catch ex As Exception

            End Try


        End Sub
        Private Const amp = "&amp;" '&
        Private Const quot = "&quot;" '"
        Private Const lt = "&lt;" '<
        Private Const gt = "&gt;" '>
        Private Const apos = "&#36;" ''
        Private Sub NuevoAtributo(ByRef parsAtribto As String, ByVal pvCadena As String, ByRef xml As XmlTextWriter)

            If pvCadena.Trim = "" Then Exit Sub

            pvCadena = pvCadena.Replace("&", amp).Trim()
            pvCadena = pvCadena.Replace("<", lt).Trim()
            pvCadena = pvCadena.Replace(">", gt).Trim()
            pvCadena = pvCadena.Replace("'", apos).Trim()
            pvCadena = pvCadena.Replace("""", quot).Trim()

            xml.WriteAttributeString(parsAtribto, pvCadena)

        End Sub
    End Class

    'Public Class Cliente
    '    Inherits DBCentral.CCliente

    '    Public Sub New()

    '    End Sub

    '    Public Sub New(ByVal parsClienteClave As String)
    '        Me.ClienteClave = parsClienteClave
    '    End Sub

    '    Public Function Recuperar() As Boolean
    '        Dim DataTableConsulta As DataTable
    '        DataTableConsulta = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Cliente WHERE ClienteClave='" & Me.ClienteClave & "'")
    '        If DataTableConsulta.Rows.Count > 0 Then
    '            With DataTableConsulta.Rows(0)
    '                Me.IdElectronico = .Item("IdElectronico")
    '                Me.IdFiscal = .Item("IdFiscal")
    '                Me.RazonSocial = .Item("RazonSocial")
    '                Me.TipoFiscal = .Item("TipoFiscal")
    '                Me.TipoImpuesto = .Item("TipoImpuesto")
    '                Me.NombreContacto = .Item("NombreContacto")
    '                Me.TelefonoContacto = .Item("TelefonoContacto")
    '                Me.FechaRegistroSistema = .Item("FechaRegistroSistema")
    '                Me.FechaNacimiento = .Item("FechaNacimiento")
    '                Me.LimiteCreditoDinero = .Item("LimiteCreditoDinero")
    '                Me.NombreCorto = .Item("NombreCorto")
    '                Me.TipoEstado = .Item("TipoEstado")
    '                Me.LimiteDescuento = .Item("LimiteDescuento")
    '                Me.SaldoEnvase = .Item("SaldoEnvase")
    '            End With
    '            Return True
    '        End If
    '        Return False
    '    End Function

    'End Class

    'Public Class Producto
    '    Inherits DBCentral.CProducto

    '    Public Sub New()

    '    End Sub

    '    Public Sub New(ByVal parsProductoClave As String)
    '        Me.ProductoClave = parsProductoClave
    '    End Sub

    '    Public Function Recuperar() As Boolean
    '        Dim DataTableConsulta As DataTable
    '        DataTableConsulta = MobileClient.ConexionSQL.RealizarConsulta("SELECT * FROM Producto WHERE ProductoClave='" & Me.ProductoClave & "'")
    '        If DataTableConsulta.Rows.Count > 0 Then
    '            With DataTableConsulta.Rows(0)
    '                Me.Nombre = .Item("Nombre")
    '                Me.NombreLargo = .Item("NombreLargo")
    '                Me.Id = .Item("Id")
    '                Me.Tipo = .Item("Tipo")
    '                Me.CodigoBarras = .Item("CodigoBarras")
    '                Me.LimiteDescuento = .Item("LimiteDescuento")
    '                Me.TipoFase = .Item("TipoFase")
    '            End With
    '            Return True
    '        End If
    '        Return False
    '    End Function

    'End Class
    Public Class TiposTmp

        Public Property TiposVistasAgendas() As DBCentral.TiposVistasAgendas
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposVistasAgendas)

            End Set
        End Property
        Public Property OpcionesMenuDias() As DBCentral.TiposOpcionesMenuDia
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposOpcionesMenuDia)

            End Set
        End Property

        Public Property TiposReinicioFolios() As DBCentral.TiposReinicioFolios
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposReinicioFolios)

            End Set
        End Property
        Public Property TiposAccionReiniciarFolios() As DBCentral.TiposAccionReiniciarFolios
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposAccionReiniciarFolios)

            End Set
        End Property

        Public Property TiposModulos() As DBCentral.TiposModulos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposModulos)

            End Set
        End Property
        Public Property TiposAmbitosModulos() As DBCentral.TiposAmbitosModulos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposAmbitosModulos)

            End Set
        End Property
        Public Property TiposModulosMov() As DBCentral.TiposModulosMov
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposModulosMov)

            End Set
        End Property
        Public Property TiposModulosMovDet() As DBCentral.TiposModulosMovDet
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposModulosMovDet)

            End Set
        End Property
        Public Property TiposImpuestos() As DBCentral.TiposValoresAplicacionImpuestos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposValoresAplicacionImpuestos)

            End Set
        End Property

        Public Property TiposEsquemas() As DBCentral.TiposEsquemas
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposEsquemas)

            End Set
        End Property
        Public Property TiposValoresAplicacionImpuestos() As DBCentral.TiposValoresAplicacionImpuestos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposValoresAplicacionImpuestos)

            End Set
        End Property
        Public Property TiposAplicacionImpuestos() As DBCentral.TiposAplicacionImpuestos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposAplicacionImpuestos)

            End Set
        End Property
        Public Property TiposDescuentos() As DBCentral.TiposDescuentos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposDescuentos)

            End Set
        End Property

        Public Property TiposAplicacionDescuentos() As DBCentral.TiposAplicacionDescuentos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposAplicacionDescuentos)

            End Set
        End Property

        Public Property TiposValoresDescuentos() As DBCentral.TiposValoresDescuentos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposValoresDescuentos)

            End Set
        End Property

        Public Property TiposInspeccionDescuentos() As DBCentral.TiposInspeccionDescuentos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposInspeccionDescuentos)

            End Set
        End Property

        Public Property TiposPromociones() As DBCentral.TiposPromociones
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposPromociones)

            End Set
        End Property

        Public Property TiposAplicacionPromociones() As DBCentral.TiposAplicacionPromociones
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposAplicacionPromociones)

            End Set
        End Property

        Public Property TiposRangosPromociones() As DBCentral.TiposRangosPromociones
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposRangosPromociones)

            End Set
        End Property

        Public Property TiposContenidoFolios() As DBCentral.TiposContenidoFolios
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposContenidoFolios)

            End Set
        End Property

        Public Property OpcionesMenuVendedor() As DBCentral.TiposOpcionesMenuVendedor
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposOpcionesMenuVendedor)

            End Set
        End Property

        Public Property TiposBase() As DBCentral.TiposBase
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposBase)

            End Set
        End Property

        Public Property TiposConsulta() As DBCentral.TiposConsulta
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposConsulta)

            End Set
        End Property

        Public Property Dia() As Dia
            Get

            End Get
            Set(ByVal Value As Dia)

            End Set
        End Property

        Public Property Vista() As DBCentral.CVista
            Get

            End Get
            Set(ByVal Value As DBCentral.CVista)

            End Set
        End Property

        Public Property VistaElemento() As DBCentral.CVistaElemento
            Get

            End Get
            Set(ByVal Value As DBCentral.CVistaElemento)

            End Set
        End Property

        Public Property VistaelementoDet() As DBCentral.CVistaElementoDet
            Get

            End Get
            Set(ByVal Value As DBCentral.CVistaElementoDet)

            End Set
        End Property

        Public Property Vendedor() As MobileClient.Vendedor
            Get

            End Get
            Set(ByVal Value As MobileClient.Vendedor)

            End Set
        End Property

        Public Property TiposTransProd() As DBCentral.TiposTransProd
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposTransProd)

            End Set
        End Property

        Public Property TiposFasesPedidos() As DBCentral.TiposFasesPedidos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposFasesPedidos)

            End Set
        End Property

        Public Property TiposPedidos() As DBCentral.TiposPedidos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposPedidos)

            End Set
        End Property

        Public Property TiposMovimientosTransProd() As DBCentral.TiposMovimientos
            Get

            End Get
            Set(ByVal Value As DBCentral.TiposMovimientos)

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

