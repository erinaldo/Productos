Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.Web.Script.Services

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<System.Web.Script.Services.ScriptService()> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Autocomplete
    Inherits System.Web.Services.WebService
    <WebMethod()> _
   Public Function ObtenerCasoUso(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT vchNombre + ' |' + cast(iCasoUsoID as varchar) from CasoUso where vchNombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)

            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    <WebMethod()> _
    Public Function ObtenerCasoPrueba(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT vchNombre + ' |' + cast(iCasoPruebaID as varchar)  from CasoPrueba where vchNombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)
            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    <WebMethod()> _
    Public Function ObtenerComponente(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT vchNombre + ' |' + cast(iComponenteID as varchar) from Componente where vchNombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)
            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    <WebMethod()> _
    Public Function ObtenerEspecificacion(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT vchNombre + ' |' + cast(iEspecificacionID as varchar)  from Especificacion where vchNombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)
            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    <WebMethod()> _
       Public Function ObtenerCliente(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT Nombre + ' |' + cast(iClienteID as varchar)  from Cliente where Nombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)
            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    <WebMethod()> _
           Public Function ObtenerModulo(ByVal prefixText As String, ByVal count As Integer) As String()
        Try
            Dim DB As New AmesolREQMLog.clsDB(ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString())
            DB.CommandText = "SELECT vchNombre + ' |' + cast(iModuloID as varchar)  from Modulo where vchNombre like '" & prefixText & "%' "
            DB.CommandType = CommandType.Text
            Dim dt As New DataTable
            dt = DB.ToDatatable()
            Dim lista As New List(Of String)
            For Each r As DataRow In dt.Rows
                lista.Add(r(0))
            Next
            Return lista.ToArray
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class