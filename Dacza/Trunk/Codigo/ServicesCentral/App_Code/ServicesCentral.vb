Imports System.IO
Imports System.Data
Imports System.Xml
Imports System.Web.Services.Protocols
Namespace ServicesCentral

    Public Class Configuracion

        Public Const ArchivoConfig = "ServicesCentral.xml"

        Public Shared CadenaConexionSQL As String

        Public Shared CadenaConexionFirebird As String

        Public Shared CadenaConexionMySQL As String

        Public Shared Version As String = "2.6.0"

        Public Shared Directorio As String

        Public Shared ServidorVinculado As String
        Public Shared BDInterfaces As String


    End Class

    Public Class General

        Public Shared Function Fecha() As String
            Return Format(Now, "dd/MM/yyyy")
        End Function

        Public Shared Function Hora() As String
            Return Format(Now, "hh:mm:ss")
        End Function

        Public Shared Function StringADate(ByVal parsFecha As String) As Date
            Dim dFecha As New Date(CInt(Mid(parsFecha, 1, 4)), CInt(Mid(parsFecha, 5, 2)), CInt(Mid(parsFecha, 7, 2)))
            Return dFecha
        End Function


    End Class

End Namespace
