﻿Public Class clsModulo
    Inherits clsName
    Implements iNuevoEditable


#Region "Metodos"
    Public Sub New(ByVal cadenaConexion As String)
        MyBase.New(cadenaConexion)
    End Sub
    ''' <summary>
    ''' Edita el registro que corresponda al id del objeto instanciado con los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EditarRegistro() As Boolean Implements iNuevoEditable.EditarRegistro
        Try
            With DB
                .AddParameter("@Nombre", SqlDbType.VarChar, Nombre.Trim)
                .AddParameter("@ID", SqlDbType.Int, ID)
                .ExecuteCmd("EditaModulo", CommandType.StoredProcedure)
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
                .ExecuteCmd("EliminaModulo", CommandType.StoredProcedure)
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
                .AddParameter("@Nombre", SqlDbType.VarChar, Nombre.Trim)
                .ExecuteCmd("InsertaModulo", CommandType.StoredProcedure)
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
                dt = .ToDatatable("obtenDatosModulo", CommandType.StoredProcedure)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDatos(ByVal ID As Integer) As DataTable
        Try
            Dim dt As DataTable
            With DB
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                dt = .ToDatatable("obtenDatosModulo", CommandType.StoredProcedure)
            End With
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
