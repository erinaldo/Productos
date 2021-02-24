Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO

Public Class cLog
    Private _claveVendedor As String
    Private _vendedorId As String
    Private _fechaInicio As DateTime
    Private _fechaPrimerDia As DateTime
    Private _tabla As DataTable
    Private _ruta As String
    Private _extension As String

    Public Sub New(ByVal vendedorid As String, ByVal clave As String, ByVal fechainicio As DateTime, ByVal fechaprimerdia As DateTime)
        _claveVendedor = clave
        _fechaInicio = fechainicio
        _fechaPrimerDia = fechaprimerdia
        _vendedorId = vendedorid

        Dim ruta As String = ServicesCentral.Configuracion.Directorio + "\LogInt"
        Try
            If Not Directory.Exists(ruta) Then
                Directory.CreateDirectory(ruta)
            End If
            ruta = ruta + "\" + Now.Date.ToString("yyyyMMdd")
            _ruta = ruta
            If Not Directory.Exists(ruta) Then
                Directory.CreateDirectory(ruta)
            End If
            _tabla = New DataTable("LOG")
            _extension = "pro"
            If File.Exists(ruta + "\" + _claveVendedor + ".bie") Then
                _extension = "bie"
            End If
            If File.Exists(ruta + "\" + _claveVendedor + ".err") Then
                _extension = "err"
            End If
            If File.Exists(ruta + "\" + _claveVendedor + ".pro") Then
                _extension = "pro"
            End If
            If Not File.Exists(ruta + "\" + _claveVendedor + "." + _extension) Then
                _tabla.Columns.Add("FechaHora", GetType(DateTime))
                _tabla.Columns.Add("Mensaje", GetType(String))
                _tabla.Columns.Add("FechaInicio", GetType(DateTime))
                _tabla.Columns.Add("FechaPrimerDia", GetType(DateTime))
                _tabla.Columns.Add("Notas", GetType(String))
                _tabla.Columns.Add("Finalizador", GetType(Boolean))
                _tabla.Columns.Add("Error", GetType(Boolean))
                _tabla.Columns.Add("VendedorId", GetType(String))
            Else
                _tabla.ReadXml(ruta + "\" + _claveVendedor + "." + _extension)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Agregar(ByVal mensaje As String, ByVal finaliza As Boolean, ByVal notas As String, ByVal hayerror As Boolean)
        If Not IsNothing(_tabla) Then
            Dim fila As DataRow = _tabla.NewRow()
            fila("FechaHora") = Now
            fila("Mensaje") = mensaje
            fila("FechaInicio") = _fechaInicio
            fila("FechaPrimerDia") = _fechaPrimerDia
            fila("Notas") = notas
            fila("Finalizador") = finaliza
            fila("Error") = hayerror
            fila("VendedorId") = _vendedorId
            If (hayerror) Then
                _extension = "err"
            ElseIf (finaliza) Then
                _extension = "bie"
            Else
                _extension = "pro"
            End If
            _tabla.Rows.Add(fila)
        End If
    End Sub
    Public Sub Guardar()
        If (_claveVendedor.Trim().Length > 0) Then
            Try

                Dim dir As New System.IO.DirectoryInfo(_ruta)
                Dim archs As FileInfo() = dir.GetFiles(_claveVendedor + ".*")
                For Each a As FileInfo In archs
                    a.Delete()
                Next

            Catch ex As Exception

            End Try
            Try
                _tabla.WriteXml(_ruta + "\" + _claveVendedor + "." + _extension, XmlWriteMode.WriteSchema)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
