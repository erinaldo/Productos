Public Class clsVersion
    Implements iNuevoEditable

#Region "Privado"
    Private _ID As Integer
    Private _Version As String
    Private DB As clsDB
#End Region

#Region "Propiedades"
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property Version() As String
        Get
            Return _Version

        End Get
        Set(ByVal value As String)
            _Version = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Sub New(ByVal cadenaConexion As String)
        DB = New clsDB(cadenaConexion)
    End Sub
    ''' <summary>
    ''' Edita el registro que corresponda al id del objeto instanciado con los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EditarRegistro() As Boolean Implements iNuevoEditable.EditarRegistro
        Try
            With DB
                .AddParameter("@Version", SqlDbType.VarChar, Version.Trim)
                .AddParameter("@ID", SqlDbType.Int, ID)
                .ExecuteCmd("EditaVersion", CommandType.StoredProcedure)
            End With

            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' Elimina el Registro del objeto instanciado
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EliminarRegistro() As Boolean Implements iNuevoEditable.EliminarRegistro
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                .ExecuteCmd("EliminaVersion", CommandType.StoredProcedure)
            End With
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    ''' <summary>
    ''' Crea un nuevo registro con la informacion del nuevo objeto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NuevoRegistro() As Boolean Implements iNuevoEditable.NuevoRegistro
        Try
            With DB
                .AddParameter("@Version", SqlDbType.VarChar, Version.Trim)
                .ExecuteCmd("InsertaVersion", CommandType.StoredProcedure)
            End With
            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ObtenerDatos() As DataTable
        Try
            Dim dt As DataTable
            With DB
                dt = .ToDatatable("obtenDatosVersion", CommandType.StoredProcedure)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerVersiones(ByVal productID As Integer, Optional ByVal ReqID As Integer = 0) As DataTable
        Try
            With DB
                .AddParameter("@REQID", SqlDbType.Int, ReqID)
                .AddParameter("@ProductoID", SqlDbType.Int, productID)
                Return .ToDatatable("VersionesProducto", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerVersionesActivas(ByVal productID As Integer, ByVal ReqID As Integer) As DataTable
        Try
            With DB
                .AddParameter("@ReqID", SqlDbType.Int, ReqID)
                .AddParameter("@ID", SqlDbType.Int, productID)
                Return .ToDatatable("VersionesRequerimiento", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class
