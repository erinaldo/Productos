Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Configuration.Install

Public Class Installer1
    Enum TipoConexion
        SQLAutenticacion = 1
        WindowsAutentication = 2
    End Enum

    Private algo() As Object
    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()

        'Add initialization code after the call to InitializeComponent
    End Sub

    Private Sub Installer1_Committed(ByVal sender As Object, ByVal e As System.Configuration.Install.InstallEventArgs) Handles Me.Committed
        Dim t As New DataTable
        'For Each s As String In Context.Parameters.Keys
        'MsgBox(s)
        'MsgBox(Context.Parameters(s))

        'Next
        modificarWebConfig(Context.Parameters("ruta"), Context.Parameters("nomServ"), Context.Parameters("bd"), Context.Parameters("usr"), Context.Parameters("pwd"), Context.Parameters("timeout"), Context.Parameters("autenticacion"))
        'MsgBox(t.Rows(0)(0).ToString())

    End Sub
    Private Sub probarConexionWindows(ByVal servidor As String, ByVal basedatos As String, ByVal timeout As String)
        Dim oConnection As New SqlClient.SqlConnection
        oConnection.ConnectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=" & basedatos & ";server=" & servidor & " "
        oConnection.Open()
        oConnection.Close()

    End Sub

    Private Sub probarConexionSQL(ByVal servidor As String, ByVal basedatos As String, ByVal timeout As String, ByVal usrId As String, ByVal pwd As String)
        Dim conexion As String = "Provider=SQLOLEDB;Connection Timeout=30;Data Source=" & servidor & ";Initial Catalog=" & basedatos & ";User ID=" & usrId & ";Password=" & pwd
        Dim con As New System.Data.OleDb.OleDbConnection(conexion)
        con.Open()
        con.Close()

    End Sub

    Private Sub modificarWebConfig(ByVal ruta As String, ByVal servidor As String, ByVal basedatos As String, ByVal usrId As String, ByVal pwd As String, ByVal timeout As String, ByVal parAutenticacion As String)
        Dim segundos As Integer
        Dim autenticacion As TipoConexion
        Try

            Integer.TryParse(parAutenticacion, autenticacion)
            If Integer.TryParse(timeout, segundos) Then
                Select Case autenticacion
                    Case TipoConexion.SQLAutenticacion : probarConexionSQL(servidor, basedatos, timeout, usrId, pwd)
                    Case TipoConexion.WindowsAutentication : probarConexionWindows(servidor, basedatos, timeout)
                End Select

                segundos = segundos * 60
                Dim conexion As String
                ruta = ruta & "Web.Config"
                Dim doc As New System.Xml.XmlDocument()
                doc.Load(ruta)
                Dim nodo As Xml.XmlNodeList = doc.GetElementsByTagName("connectionStrings")
                If Not IsNothing(nodo) AndAlso nodo.Count > 0 Then
                    For Each n As Xml.XmlNode In nodo(0).ChildNodes
                        If n.Name = "add" Then
                            If n.Attributes.GetNamedItem("name").Value.ToUpper().Trim = "ROUTE" Then
                                Select Case autenticacion
                                    Case TipoConexion.SQLAutenticacion
                                        conexion = "server=" & servidor & ";database=" & basedatos & ";uid=" & usrId & ";pwd=" & pwd & ";timeout=30"
                                    Case TipoConexion.WindowsAutentication
                                        conexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=" & basedatos & ";server=" & servidor & " "
                                End Select
                            Else
                                Select Case autenticacion
                                    Case TipoConexion.SQLAutenticacion
                                        conexion = "Connection Timeout=30;Data Source=" & servidor & ";Initial Catalog=" & basedatos & ";User ID=" & usrId & ";Password=" & pwd
                                    Case TipoConexion.WindowsAutentication
                                        conexion = "Persist Security Info=False;Integrated Security=true;Initial Catalog=" & basedatos & ";server=" & servidor & " "
                                End Select

                            End If
                            n.Attributes.GetNamedItem("connectionString").Value = conexion
                        End If
                    Next
                Else
                    Throw New Exception("no se encuentra el nodo connectionStrings")
                End If

                nodo = doc.GetElementsByTagName("appSettings")
                If Not IsNothing(nodo) AndAlso nodo.Count > 0 Then
                    Dim bEncontrado As Boolean = False
                    For Each n As Xml.XmlNode In nodo(0).ChildNodes
                        If n.Name = "add" Then
                            If n.Attributes.GetNamedItem("key").Value.ToUpper().Trim = "COMMANDTIMEOUT" Then
                                n.Attributes.GetNamedItem("value").Value = segundos.ToString
                            End If
                        End If
                    Next

                Else
                    Throw New Exception("no se encuentra el nodo appSettings")
                End If


                nodo = doc.GetElementsByTagName("sessionState")
                If Not IsNothing(nodo) AndAlso nodo.Count > 0 Then
                    nodo(0).Attributes.GetNamedItem("timeout").Value = timeout
                Else
                    Throw New Exception("no se encuentra el nodo sessionState")
                End If
                nodo = doc.GetElementsByTagName("authentication")
                If Not IsNothing(nodo) AndAlso nodo.Count > 0 Then
                    For Each n As Xml.XmlNode In nodo(0).ChildNodes
                        If n.Name = "forms" Then
                            n.Attributes.GetNamedItem("timeout").Value = timeout
                        End If
                    Next
                    Select Case autenticacion
                        Case TipoConexion.WindowsAutentication
                            nodo(0).Attributes.GetNamedItem("mode").Value = "Windows"
                    End Select
                Else
                    Throw New Exception("no se encuentra el nodo authentication")
                End If
                nodo = doc.GetElementsByTagName("httpRuntime")
                If Not IsNothing(nodo) AndAlso nodo.Count > 0 Then
                    nodo(0).Attributes.GetNamedItem("executionTimeout").Value = segundos.ToString()
                End If
                doc.Save(ruta)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
End Class
