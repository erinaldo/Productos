Public Class clsUtil

    Public Shared Function fillCombo(ByVal Table As String, ByVal TextValue As String, ByVal IDValue As String, ByVal cadenaConexion As String, ByVal OrderBY As String) As DataTable
        Try
            Dim DB As New clsDB(cadenaConexion)
            Dim dt As New DataTable
            With DB
                .AddParameter("@Table", SqlDbType.VarChar, Table)
                .AddParameter("@Text", SqlDbType.VarChar, TextValue)
                .AddParameter("@IDValue", SqlDbType.VarChar, IDValue)
                .AddParameter("@OrderBy", SqlDbType.VarChar, OrderBY)
                dt = .ToDatatable("FillCombo", CommandType.StoredProcedure)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function obtenerDatos(ByVal Tabla As String, ByVal cadenaConexion As String) As DataTable
        Try
            Dim DB As New clsDB(cadenaConexion)
            Dim dt As New DataTable
            With DB
                .AddParameter("@Tabla", SqlDbType.VarChar, Tabla)
                Return .ToDatatable("obtenerDatosAll", CommandType.StoredProcedure)
            End With
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

End Class
