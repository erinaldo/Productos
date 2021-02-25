'Imports Microsoft.VisualBasic

'Public Class CConexion
'    Public Shared Sub chkConexion()
'        If LbConexion.cConexion.Instancia.Estado = System.Data.ConnectionState.Open Then
'            LbConexion.cConexion.Instancia.Desconectar()
'        End If
'        If Not LbConexion.cConexion.Instancia.Estado = System.Data.ConnectionState.Open Then
'            LbConexion.cConexion.Instancia.Conectar(ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString)
'        End If
'    End Sub
'    Public Shared Sub Desconectar()
'        If LbConexion.cConexion.Instancia.Estado = System.Data.ConnectionState.Open Then
'            LbConexion.cConexion.Instancia.Desconectar()
'        End If
'    End Sub
'    Public Shared Function EjecutarComandoScalar(ByVal strSQL As String) As Object
'        Dim res As Object = Nothing
'        Using cnn As New System.Data.OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString)
'            cnn.Open()
'            Dim cmd As New Data.OleDb.OleDbCommand()
'            cmd.Connection = cnn
'            cmd.CommandText = strSQL
'            res = cmd.ExecuteScalar()
'            If IsDBNull(res) Then
'                res = Nothing
'            End If
'        End Using
'        EjecutarComandoScalar = res
'    End Function
'End Class
