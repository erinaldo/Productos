Imports Microsoft.Office.Interop
Module ModPOS
#Region "Variables de Conexión"

    Public BDConexion As String = ModPOS.ObtieneCadenaConexion
    Public RutaExcel As String = ModPOS.Ruta
    Public TimeOut As String = ModPOS.Desconeccion
    Public Registros As String = ModPOS.NoLineas

#End Region

    ' '' Hacemos esta hoja la visible en pantalla
    ' '' (como seleccionamos la primera esto no es necesario
    ' '' si seleccionamos una diferente a la primera si lo
    ' '' necesitaríamos, esto lo hacemos como forma de mostrar como
    ' '' cambiar de entre hojas en un documento Excel).
    'Dim m_Excel As Excel.Application
    ' '' Creamos un objeto WorkBook
    'Dim objLibroExcel As Excel.Workbook
    ' '' Creamos un objeto WorkSheet
    'Dim objHojaExcel As Excel.Worksheet


    Function recuperaTabla_DTS(ByVal sp As String, ByVal Tabla As String, ByVal ParamArray Parametros() As Object) As DataSet
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dts As DataSet

        Cnx = New System.Data.SqlClient.SqlConnection
        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try
        du = New System.Data.SqlClient.SqlDataAdapter
        Try
            Dim i As Integer
            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.TimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure
                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With
        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try
        dts = New DataSet
        Try
            du.Fill(dts, Tabla)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try
        du.Dispose()
        Cnx.Close()
        Return dts
    End Function

    Function ObtieneCadenaConexion() As String
        Dim Servidor As String, BaseDatos As String, Usuario As String, Contrasena As String, CadenaConexion As String
        Dim ds As DataSet = New DataSet

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Excel.xml")
        Servidor = ds.Tables.Item("CadenaConexion").Rows(0).Item("ServerSQL")
        BaseDatos = ds.Tables.Item("CadenaConexion").Rows(0).Item("BaseDatos")
        Usuario = ds.Tables.Item("CadenaConexion").Rows(0).Item("Usuario")
        Contrasena = ds.Tables.Item("CadenaConexion").Rows(0).Item("Contraseña")
        CadenaConexion = "data Source=" + Servidor + "; initial catalog=" + BaseDatos + "; user id=" + Usuario + "; password=" + Contrasena + "; TimeOut=30;"

        Return CadenaConexion
    End Function

    Function Ruta() As String
        Dim Cadena As String
        Dim ds As DataSet = New DataSet

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Excel.xml")
        Cadena = ds.Tables.Item("Configuracion").Rows(0).Item("Ruta")

        Return Cadena
    End Function

    Function Desconeccion() As String
        Dim Cadena As String
        Dim ds As DataSet = New DataSet

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Excel.xml")
        Cadena = ds.Tables.Item("Configuracion").Rows(0).Item("TimeOut")

        Return Cadena
    End Function

    Function NoLineas() As String
        Dim Cadena As String
        Dim ds As DataSet = New DataSet

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Excel.xml")
        Cadena = ds.Tables.Item("Configuracion").Rows(0).Item("Lineas")

        Return Cadena
    End Function


End Module
