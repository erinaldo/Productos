Imports Microsoft.VisualBasic
Imports System.Data

Namespace DBConexion

    Public Class cConexionSQL

        Public Function EjecutarConsultaDataSet(ByVal parsConsultaSQL As String, Optional ByVal parsTabla As String = "Table") As DataSet
            Try
                ' Crear la conexion
                Dim oConnection As New SqlClient.SqlConnection
                oConnection.ConnectionString = ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString
                oConnection.Open()
                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                'oConnection.BeginTransaction(IsolationLevel.ReadUncommitted)
                Dim DataSetRetorno As New DataSet
                oCommand.CommandText = parsConsultaSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")

                Dim SqlDataAdapter As SqlClient.SqlDataAdapter
                SqlDataAdapter = New SqlClient.SqlDataAdapter(oCommand) '(parsConsultaSQL, oConnection)
                SqlDataAdapter.Fill(DataSetRetorno, parsTabla)
                SqlDataAdapter.Dispose()
                oConnection.Close()
                Return DataSetRetorno
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

        Public Function EjecutarConsulta(ByVal parsConsultaSQL As String, Optional ByVal parsTabla As String = "Table") As DataTable
            Return EjecutarConsultaDataSet(parsConsultaSQL, parsTabla).Tables(0)
        End Function
        Public Function EjecutarComandoStringScalar(ByVal parsComandoSQL As String) As String
            Try
                Dim oConnection As New SqlClient.SqlConnection
                oConnection.ConnectionString = ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString
                oConnection.Open()

                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
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
        End Function

        Public Function EjecutarComandoScalar(ByVal parsComandoSQL As String) As Object
            Try
                Dim oConnection As New SqlClient.SqlConnection
                oConnection.ConnectionString = ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString
                oConnection.Open()

                Dim oCommand As New SqlClient.SqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ", oConnection)
                oCommand.ExecuteNonQuery()
                oCommand.CommandText = parsComandoSQL
                oCommand.CommandTimeout = System.Configuration.ConfigurationManager.AppSettings("CommandTimeout")

                Dim strResultado As Object = oCommand.ExecuteScalar
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
        End Function

        Public Function ObtenerFecha() As Date
            Dim cCon As New cConexionSQL
            Dim dt As DataTable = cCon.EjecutarConsulta("Select GetDate()", "ObtenerDia")

            Return CType(dt.Rows(0).Item(0).ToString, Date)
        End Function

        Public Shared Function UniFechaSQL(ByVal pardFecha As Date, Optional ByVal optsTipoDatoDestino As String = "DATETIME", Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss", Optional ByVal optsEstilo As String = "103") As String
            Return "CONVERT(" & optsTipoDatoDestino & ",'" & Fecha24Horas(pardFecha, optsFormato) & "'," & optsEstilo & ")"
        End Function

        Private Shared Function Fecha24Horas(ByVal pardFecha As Date, Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss") As String
            Return Format(pardFecha, optsFormato)
        End Function

    End Class

    Public Class cError
        Inherits ApplicationException

#Region "Variables"
        Private vcCodigo As String
        Private vcCadenas() As cParametroMSG
        Private vcMensaje As String
        Private vcMSGProveedor As String = ""
        Private vcTipo As String
#End Region

        Public Sub New(ByVal pvCodigo As String, Optional ByVal pvCadenas() As cParametroMSG = Nothing, Optional ByVal pvSource As String = "", Optional ByVal pvMSGProveedor As String = Nothing)
            MyBase.New(pvMSGProveedor)
            vcCodigo = pvCodigo
            vcCadenas = pvCadenas
            Me.Source = pvSource
            Me.vcMSGProveedor = pvMSGProveedor
            Traducir()
        End Sub

#Region "Funciones"
        Private Sub Traducir()
            Dim n As Integer
            If vcCodigo = "" Then
                vcMensaje = ""
                Exit Sub
            End If
            Dim lMensaje As New DBConexion.cMensaje
            If IsNothing(vcCadenas) = True Then

                vcMensaje = lMensaje.RecuperarDescripcion(vcCodigo)
            Else
                For n = 0 To vcCadenas.GetUpperBound(0)
                    If vcCadenas(n).Buscar = True Then
                        vcCadenas(n).Mensaje = lMensaje.RecuperarDescripcion(vcCadenas(n).Mensaje)
                    End If
                Next
                Dim vlMGS(vcCadenas.GetUpperBound(0) + 1) As String
                For n = 0 To vcCadenas.GetUpperBound(0)
                    vlMGS(n) = vcCadenas(n).Mensaje
                Next
                vcMensaje = lMensaje.RecuperarDescripcion(vcCodigo, vlMGS)
            End If
        End Sub
#End Region

    End Class

    Public Class cParametroMSG
        Public Mensaje As String
        Public Buscar As Boolean = False

        Public Sub New(ByVal pvMensaje As String, Optional ByVal pvBuscar As Boolean = False)
            Mensaje = pvMensaje
            Buscar = pvBuscar
        End Sub

    End Class

    Public Class cMensaje

        Public Shared DbMensaje As System.Collections.Generic.Dictionary(Of String, String)
        Public Shared Function ObtenerLenguaje()
            Dim ins As New DBConexion.cConexionSQL
            Return ins.EjecutarComandoScalar("Select dbo.FNObtenerLenguaje()")
        End Function

        Public Shared Function ObtenerMensaje(ByVal pvMENClave As String, ByVal pvLenguaje As String)
            Dim ins As New DBConexion.cConexionSQL
            pvMENClave = pvMENClave.ToUpper()
            If DbMensaje Is Nothing Then
                DbMensaje = New System.Collections.Generic.Dictionary(Of String, String)()
                Dim tabla As DataTable = ins.EjecutarConsulta("SELECT MENClave, Descripcion FROM MENDetalle WHERE MEDTipoLenguaje = '" + pvLenguaje + "'")
                For Each f As DataRow In tabla.Rows
                    DbMensaje.Add(f("MENClave").ToString().ToUpper(), f("Descripcion"))
                Next
                tabla.Dispose()
            End If
            Dim res As String
            If DbMensaje.ContainsKey(pvMENClave) Then
                res = DbMensaje.Item(pvMENClave)
            Else
                res = pvMENClave & " NE"
            End If
            Return res 'ins.EjecutarCmdScalarStrSQL("select dbo.FNObtenerMensaje ('" & pvMENClave & "','" & pvLenguaje & "')")
        End Function

        Public Function RecuperarDescripcion(ByVal pvMENClave As String, Optional ByVal pvValores() As String = Nothing) As String
            Dim vlMENDataTable As New DataTable
            Dim vlMEDDataTable As New DataTable
            Dim vlDescripcion As String
            Dim vlNum As Integer
            Dim vlPos As Integer
            Dim vlLenguaje As String

            vlLenguaje = ObtenerLenguaje()
            vlDescripcion = ObtenerMensaje(pvMENClave, vlLenguaje)

            If vlDescripcion.Contains("[BF0002]") Then
                Return vlDescripcion
                Exit Function
            End If

            If vlDescripcion.Contains("BF0003") Then
                Return vlDescripcion.Replace("$0$", pvMENClave).Replace("$1$", vlLenguaje)
                Exit Function
            End If

            If (IsNothing(pvValores) = False) Then
                vlNum = 0
                For Each vlCadena As String In pvValores
                    If (IsNothing(vlCadena) = False) Then
                        vlPos = vlDescripcion.IndexOf("$" + Trim(Str(vlNum)) + "$")
                        While vlPos >= 0
                            vlDescripcion = vlDescripcion.Substring(0, vlPos) + vlCadena + vlDescripcion.Substring(vlPos + 3)
                            vlPos = vlDescripcion.IndexOf("$" + Trim(Str(vlNum)) + "$")
                        End While
                    End If
                    vlNum = vlNum + 1
                Next
            End If

            Return vlDescripcion
        End Function

    End Class

End Namespace
