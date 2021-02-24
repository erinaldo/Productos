Imports Microsoft.VisualBasic
Imports System.Threading

Public Class HiloEjecutaInterfaces
    Private _vendedorid As String
    Private _fechainicio As DateTime
    Private _fechaprimerdia As DateTime
    Private _hiloejecuta As Thread
    Public Sub New(ByVal vendedorid As String, ByVal fechainicio As DateTime, ByVal fechaprimerdia As DateTime)
        _vendedorid = vendedorid
        _fechainicio = fechainicio
        _fechaprimerdia = fechaprimerdia
        _hiloejecuta = New Thread(AddressOf Ejecutar)
    End Sub
    Private Sub Ejecutar()
        Dim servicio As New ServiceMobileClient
        servicio.WSEjecutarInterfaces(_vendedorid, _fechainicio, _fechaprimerdia, "", False)
    End Sub
    Public Sub EjecutarInterfaces()
        _hiloejecuta.Start()
        Thread.Sleep(1000)
    End Sub
End Class
