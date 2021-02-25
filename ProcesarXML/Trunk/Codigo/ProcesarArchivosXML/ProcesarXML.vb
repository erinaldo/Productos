Imports BASMENLOG
Imports ERMINVESC
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class ProcesadorXML
    'Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

    Public FolderMonitorear As String = ""
    Public Directorio As String = ""


    Private Sub ProcesadorXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load


#If DEBUG Then
        ' oConexion.Conectar("Provider=SQLOLEDB;Data Source=25.87.120.159\SQL2016;user id=sa;password=dbsa.DBSA;initial catalog=SierraNorteCH42001_1809")
        lbGeneral.cParametros.UsuarioID = "Admin"
#End If
        'Dim CnxExitosa As Boolean = True
        'Dim El_Archivo As String
        'Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        'Dim dir As String = DirActual.FullName()

        btnStart.Enabled = False
        Dim sConsulta As String = ""
        'sConsulta = "select top 1 DirInterfaz from CONHist order by CONHistFechaInicio Desc"
        'Directorio = oConexion.EjecutarComandoScalar(sConsulta)
        Directorio = RutadeXML()
        'MsgBox(Directorio)
        ' If Not Directory.Exists(Directorio & "\XML") Then
        'Directory.CreateDirectory(Directorio & "\XML")
        'End If
        'If Not Directory.Exists(Directorio & "\XML\ERROR") Then
        'Directory.CreateDirectory(Directorio & "\XML\ERROR")
        'End If
        'If Not Directory.Exists(Directorio & "\XML\PROCESADAS") Then
        'Directory.CreateDirectory(Directorio & "\XML\PROCESADAS")
        'End If

        If Not Directory.Exists(Directorio & "\ERROR") Then
            Directory.CreateDirectory(Directorio & "\ERROR")
        End If

        If Not Directory.Exists(Directorio & "\PROCESADAS") Then
            Directory.CreateDirectory(Directorio & "\PROCESADAS")
        End If

        If Not Directory.Exists(Directorio & "\PROCESANDO") Then
            Directory.CreateDirectory(Directorio & "\PROCESANDO")
        End If

        'FolderMonitorear = Directorio & "\XML"
        FolderMonitorear = Directorio & "\"
        ' MsgBox(FolderMonitorear.ToString())
        Timer1.Start()

        Label1.Text = "Buscando"
    End Sub


    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        Timer1.Stop()
        btnStart.Enabled = True
        Label1.Text = "Detenido"
        btnPause.Enabled = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim strfilename As String
        Dim SUCCESS As Boolean = False
        Dim Archivo As String = ""

        Label1.Text = "Buscando"
        pbProcesados.Minimum = 0
        pbProcesados.Value = 0

        'CAI 6073

        Dim oConexion = New LbConexion.cConexion()
#If DEBUG Then

        oConexion.Conectar("Provider=SQLOLEDB;Data Source=.\\;user id=sa;password=dbsa.DBSA;initial catalog=Route_Aurora")
#Else
        oConexion.Conectar(ObtieneCadenaConexion())
#End If
        Dim sConfig As String = ""
        sConfig = "select valor from configparametro where parametro = 'NoRepeticionesProcesamientoXML'"
        Dim Valor As String = oConexion.EjecutarComandoScalar(sConfig)

        Dim j As Integer = 0
        Dim Repeticiones As Integer = 0
        Dim Minutos As Integer = 5
        Dim Contador As Integer = 0
        Try
            Repeticiones = Integer.Parse(Valor)
        Catch exc As Exception
        End Try

        sConfig = "select valor from configparametro where parametro = 'TiempoRepeticionesProcesamientoXML'"
        Valor = oConexion.EjecutarComandoScalar(sConfig)
        Try
            Minutos = Integer.Parse(Valor)
        Catch exc As Exception
        End Try

        j = My.Computer.FileSystem.GetFiles(FolderMonitorear, FileIO.SearchOption.SearchTopLevelOnly, "*.xml").Count
        If j > 0 Then
            Timer1.Stop()

            Dim i As Integer = 1
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(FolderMonitorear, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")

                ' Bloquear Ejecucion para que continue solo cuando se termino de procesar correctamente un archivo, y no de manera asincrona
                SyncLock Me
                    strfilename = foundFile
                    Label2.Text = ""
                    Label2.Refresh()
                    Label1.Text = "Procesando " & CStr(i) & "\" & CStr(j)
                    Label1.Refresh()
                    Archivo = strfilename.Substring(strfilename.LastIndexOf("\") + 1).ToString 'Obtiene el nombre del archivo sin el PATH
                    If System.IO.File.Exists(strfilename) Then 'Revisa que el Archivo Exista
                        '--------------------------------------------------------------------------------------------------
                        Dim bError As Boolean = False
                        If strfilename = "" Or strfilename Is Nothing Then
                            Continue For
                        End If

                        Dim sw As Stream = Nothing, swWriter As StreamWriter = Nothing
                        Dim ArchivoLog As String = "\ProcesarArchivosLog_" + Archivo.Replace(".xml", "") + Now.ToString("s").Replace(":", "") + ".txt"
                        Dim PathLog As String = FolderMonitorear + ArchivoLog

                        If File.Exists(PathLog) Then
                            File.Delete(PathLog)
                            sw = File.Create(PathLog)
                        Else
                            sw = File.Create(PathLog)
                        End If

                        swWriter = New StreamWriter(sw, System.Text.Encoding.Default)
                        swWriter.WriteLine("Iniciando procesamiento de archivo: " + Archivo)

                        Try
                            If System.IO.File.Exists(strfilename) Then
                                System.IO.File.Move(strfilename, FolderMonitorear + "\PROCESANDO\" + Archivo)
                                strfilename = FolderMonitorear + "\PROCESANDO\" + Archivo
                            End If
                        Catch ex As Exception
                            swWriter.WriteLine("No se pudo mover el archivo")
                            swWriter.WriteLine(ex.Message())
                            swWriter.Close()
                            sw.Close()
                            Continue For
                        End Try

                        Dim DataSet As DataSet = New DataSet
                        Dim dataTable As DataTable

                        For Each dataTable In DataSet.Tables
                            dataTable.BeginLoadData()
                        Next

                        Try
                            DataSet.ReadXml(strfilename)
                        Catch ex As Exception
                            swWriter.WriteLine("Archivo mal formado")
                            swWriter.WriteLine(ex.Message())
                            swWriter.Close()
                            sw.Close()
                            System.IO.File.Move(strfilename, FolderMonitorear + "\ERROR\" + Archivo)
                            Continue For
                        End Try

                        For Each dataTable In DataSet.Tables
                            dataTable.EndLoadData()
                        Next

                        Dim VendedorId As String = ""
                        For Each refDataTable As DataTable In DataSet.Tables
                            If (refDataTable.TableName.ToUpper().Equals("FOLIORESERVACION")) Then
                                For Each refDataRow As DataRow In refDataTable.Select()
                                    VendedorId = refDataRow("VendedorId")
                                    Exit For
                                Next
                                Exit For
                            End If
                        Next

                        If VendedorId = "" Then
                            'MessageBox.Show("El xml selecionado no es válido, ya que no cuenta con la estructura adecuada.")
                            For Each refDataTable As DataTable In DataSet.Tables
                                If (refDataTable.TableName.ToUpper().Equals("TRANSPROD")) Then
                                    For Each refDataRow As DataRow In refDataTable.Select()
                                        VendedorId = refDataRow("MUsuarioID")
                                        Exit For
                                    Next
                                    Exit For
                                End If
                            Next

                            oConexion = New LbConexion.cConexion()
#If DEBUG Then

                        oConexion.Conectar("Provider=SQLOLEDB;Data Source=.\\;user id=sa;password=dbsa.DBSA;initial catalog=Route_Aurora")
#Else
                            oConexion.Conectar(ObtieneCadenaConexion())
#End If
                            Dim sCon As String = ""
                            sCon = "select top 1 VendedorID from Vendedor where USUId = '" + VendedorId + "'"
                            VendedorId = oConexion.EjecutarComandoScalar(sCon)
                            oConexion.Desconectar()

                            If VendedorId = "" Then
                                swWriter.WriteLine("No hay datos del vendedor del archivo, por lo que no se procesa.")
                                swWriter.Close()
                                sw.Close()
                                System.IO.File.Move(strfilename, FolderMonitorear + "\PROCESADAS\" + Archivo)
                                If System.IO.File.Exists(PathLog) Then
                                    System.IO.File.Delete(PathLog)
                                End If
                                Continue For
                            End If

                        End If

                        Try
#If DEBUG Then

                        Dim oCTI As New ERMINVLOG.cInventarioABordo("Provider=SQLOLEDB;Data Source=.\\;user id=sa;password=dbsa.DBSA;initial catalog=Route_Aurora")
#Else
                            Dim oCTI As New ERMINVLOG.cInventarioABordo(ObtieneCadenaConexion())
#End If
                            swWriter.WriteLine("Ir a ActualizarInventario")
                            SyncLock Me
                                SUCCESS = oCTI.ActualizarInventario(DataSet, VendedorId)
                                If SUCCESS = True Then
                                    swWriter.WriteLine("Se proceso correctamente")
                                    System.IO.File.Move(strfilename, FolderMonitorear + "\PROCESADAS\" + Archivo)
                                ElseIf SUCCESS = False Then
                                    swWriter.WriteLine("El procesamiento dió errores")
                                    If Repeticiones > 0 Then
                                        swWriter.WriteLine("Se reintentara procesar el archivo en breve.")
                                        System.IO.File.Move(strfilename, FolderMonitorear + "\" + Archivo)
                                        Thread.Sleep(60000 * Minutos)
                                    Else
                                        System.IO.File.Move(strfilename, FolderMonitorear + "\ERROR\" + Archivo)
                                    End If
                                End If

                                swWriter.Close()
                                sw.Close()
                                If SUCCESS = True Then
                                    If System.IO.File.Exists(PathLog) Then
                                        System.IO.File.Delete(PathLog)
                                    End If
                                End If
                            End SyncLock
                        Catch exConexion As Data.OleDb.OleDbException
                            Dim moverArchivosError As Boolean = True
                            swWriter.WriteLine("Error de conexión")
                            If (exConexion.Errors.Count > 0) Then
                                Select Case (exConexion.Errors(0).SQLState)
                                    Case "08001"
                                        swWriter.WriteLine("No se pudo conectar a SQL Server")
                                    Case "08S01"
                                        swWriter.WriteLine("Se perdió la conexion ")
                                        moverArchivosError = False
                                End Select
                            Else
                                swWriter.WriteLine(exConexion.Message)
                            End If
                            swWriter.Close()
                            sw.Close()
                            If (moverArchivosError) Then
                                If System.IO.File.Exists(strfilename) Then
                                    System.IO.File.Move(strfilename, FolderMonitorear + "\ERROR\" + Archivo)
                                End If
                            Else
                                If System.IO.File.Exists(strfilename) Then
                                    System.IO.File.Move(strfilename, FolderMonitorear + "\" + Archivo)
                                End If
                            End If

                            Continue For
                        Catch ex As Exception
                            swWriter.WriteLine("Error no controlado")
                            swWriter.WriteLine(ex.GetHashCode() & "-" & ex.Message())
                            swWriter.Close()
                            sw.Close()
                            If System.IO.File.Exists(strfilename) Then
                                System.IO.File.Move(strfilename, FolderMonitorear + "\ERROR\" + Archivo)
                            End If

                            Continue For
                        End Try

                        '--------------------------------------------------------------------------------------------------
                        pbProcesados.Refresh()

                    End If 'Valida que exista el Archivo

                    i = i + 1
                End SyncLock

            Next ' FoundFile
            Timer1.Start()
        End If
    End Sub

    Public Shared Function ObtieneCadenaConexion() As String
        Dim Servidor As String, BaseDatos As String, Usuario As String, Contrasena As String, CadenaConexion As String

        Dim ds As DataSet = New DataSet
        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Conexion.xml")

        Servidor = ds.Tables.Item("CadenaConexion").Rows(0).Item("ServerSQL")
        BaseDatos = ds.Tables.Item("CadenaConexion").Rows(0).Item("BaseDatos")
        Usuario = ds.Tables.Item("CadenaConexion").Rows(0).Item("Usuario")
        Contrasena = ds.Tables.Item("CadenaConexion").Rows(0).Item("Contraseña")

        ProcesadorXML.Text = BaseDatos

        CadenaConexion = "Provider=SQLOLEDB;Data Source=" + Servidor + ";user id=" + Usuario + ";password=" + Contrasena + ";initial catalog=" + BaseDatos + ";"

        Return CadenaConexion
    End Function

    Public Shared Function RutadeXML() As String
        Dim CadenaXML As String

        Dim ds As DataSet = New DataSet
        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + "Conexion.xml")

        CadenaXML = ds.Tables.Item("CadenaConexion").Rows(0).Item("Ruta")

        Return CadenaXML

    End Function



    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        Label1.Text = "Buscando"
        btnPause.Enabled = True
        Timer1.Start()
    End Sub

End Class
