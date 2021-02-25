Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Data

Public Class clsDB


    'Inherits CConexion
    Private cmd As SqlCommand
    Private da As SqlDataAdapter
    Private ObjParameters As Object
    Dim ParamColl As New List(Of SqlParameter)

    Public WriteOnly Property CommandType() As CommandType
        Set(ByVal value As CommandType)
            cmd.CommandType = value
        End Set
    End Property
    Public WriteOnly Property CommandText() As String
        Set(ByVal value As String)
            cmd.CommandText = value
        End Set
    End Property
    Public WriteOnly Property TimeOut() As Int32
        Set(ByVal value As Int32)
            cmd.CommandTimeout = value
        End Set
    End Property

    Public Sub New(ByVal conexion As String)
        cmd = New SqlCommand
        cmd.Connection = New SqlConnection(conexion)
    End Sub

    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType)
        cmd.Parameters.Add(pParameterName, pDbType)
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pValue As Object)
        cmd.Parameters.Add(pParameterName, pDbType).Value = pValue        
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pValue As String, ByVal pParameterDirection As ParameterDirection)

        Dim NewParameter As New SqlParameter
        NewParameter.ParameterName = pParameterName
        NewParameter.Direction = pParameterDirection
        NewParameter.Value = pValue
        NewParameter.DbType = pDbType

        cmd.Parameters.Add(NewParameter)
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pSize As Int32, ByVal pValue As Object)

        cmd.Parameters.Add(pParameterName, pDbType, pSize).Value = pValue
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pParameterDirection As ParameterDirection)

        Dim NewParameter As New SqlParameter
        NewParameter.ParameterName = pParameterName
        NewParameter.Direction = pParameterDirection
        NewParameter.DbType = pDbType

        cmd.Parameters.Add(NewParameter)
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pSize As Int32, ByVal pParameterDirection As ParameterDirection)

        Dim NewParameter As New SqlParameter
        NewParameter.ParameterName = pParameterName
        NewParameter.Direction = pParameterDirection
        NewParameter.DbType = pDbType
        NewParameter.Size = pSize

        cmd.Parameters.Add(NewParameter)
    End Sub
    Public Sub AddParameter(ByVal pParameterName As String, ByVal pDbType As SqlDbType, ByVal pSize As Int32, ByVal pValue As String, ByVal pParameterDirection As ParameterDirection)

        Dim NewParameter As New SqlParameter
        NewParameter.ParameterName = pParameterName
        NewParameter.Direction = pParameterDirection
        NewParameter.Value = pValue
        NewParameter.DbType = pDbType
        NewParameter.Size = pSize

        cmd.Parameters.Add(NewParameter)
    End Sub
    Public Function ExecuteCmd() As Boolean
        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            SaveParameterCollection()
            CloseConnection()
        End Try

        Return True
    End Function
    Public Function ExecuteCmd(ByVal CommandName As String, ByVal CommandType As CommandType) As Boolean
        Try
            cmd.CommandType = CommandType
            cmd.CommandText = CommandName
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            SaveParameterCollection()
            CloseConnection()
        End Try

        Return True
    End Function
    Private Sub SaveParameterCollection()
        For Each Param As SqlParameter In cmd.Parameters
            ParamColl.Add(Param)
        Next

        cmd.Parameters.Clear()
    End Sub

    Public Function GetOutParameter(ByVal pParameterName As String) As Object
        Dim Value As New Object

        Dim i As Int32
        For i = 0 To ParamColl.Count - 1
            If (ParamColl.Item(i).ParameterName = pParameterName) Then
                Value = ParamColl.Item(i).Value
            End If
        Next

        Return Value
    End Function
    Public Function ExecuteScalar() As Object
        Dim Value As New Object
        Try
            cmd.Connection.Open()
            Value = cmd.ExecuteScalar
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return Value
    End Function
    Public Function ExecuteReader() As SqlDataReader
        Dim dr As SqlDataReader
        Try
            cmd.Connection.Open()
            dr = cmd.ExecuteReader()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return dr
    End Function
    Public Function ToDatatable(ByVal CommandName As String, ByVal CommandType As CommandType) As DataTable
        Dim dt As New DataTable
        Try
            cmd.CommandText = CommandName
            cmd.CommandType = CommandType
            cmd.Connection.Open()
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return dt
    End Function
    Public Function ToDatatable() As DataTable
        Dim dt As New DataTable
        Try
            cmd.Connection.Open()
            da = New SqlDataAdapter(cmd)
            da.Fill(dt)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return dt
    End Function
    Private Sub CloseConnection()
        If (cmd.Connection.State = ConnectionState.Open) Then
            cmd.Connection.Close()
        End If
    End Sub
    Public Function ToDataSet() As DataSet
        Dim ds As New DataSet
        Try
            cmd.Connection.Open()
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return ds
    End Function
    Public Function ToDataSet(ByVal CommandName As String, ByVal CommandType As CommandType) As DataSet
        Dim ds As New DataSet
        Try
            cmd.Connection.Open()
            da = New SqlDataAdapter(cmd)
            da.Fill(ds)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cmd.Parameters.Clear()
            CloseConnection()
        End Try

        Return ds
    End Function


End Class
