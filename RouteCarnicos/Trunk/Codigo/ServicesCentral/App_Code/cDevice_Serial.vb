Imports Microsoft.VisualBasic
Public Class CDevice_Serial

    Private sDispositivoID As String = String.Empty
    Private sNombre_Dispositivo As String = String.Empty
    Private sTipoLicencia As String = String.Empty
    Private sLlaveHost As String = String.Empty
    Private dFechaActivacion As Date
    Private dFechaSolicitud As Date
    Private iIntentosRestantes As Int32

    Protected Property DispositivoID() As String
        Get
            Return sDispositivoID
        End Get
        Set(ByVal Value As String)
            sDispositivoID = Value
        End Set
    End Property

    Protected Property Nombre_Dispositivo() As String
        Get
            Return sNombre_Dispositivo
        End Get
        Set(ByVal Value As String)
            sNombre_Dispositivo = Value
        End Set
    End Property

    Protected Property TipoLicencia() As String
        Get
            Return sTipoLicencia
        End Get
        Set(ByVal Value As String)
            sTipoLicencia = Value
        End Set
    End Property

    Protected Property LlaveHost() As String
        Get
            Return sLlaveHost
        End Get
        Set(ByVal Value As String)
            sLlaveHost = Value
        End Set
    End Property

    Protected Property IntentosRestantes() As Int32
        Get
            Return iIntentosRestantes
        End Get
        Set(ByVal Value As Int32)
            iIntentosRestantes = Value
        End Set
    End Property

    Protected Property FechaActivacion() As Date
        Get
            Return dFechaActivacion
        End Get
        Set(ByVal Value As Date)
            dFechaActivacion = Value
        End Set
    End Property

    Protected Property FechaSolicitud() As Date
        Get
            Return dFechaSolicitud
        End Get
        Set(ByVal Value As Date)
            dFechaSolicitud = Value
        End Set
    End Property

    Public Function GetTipoLicencia(ByVal pvDispositivoID As String, ByVal pvDeviceName As String) As Registro
        Try
            If Existe(pvDispositivoID) Then
                Recuperar(pvDispositivoID)
                If Not GetSerialType() = Registro.Definitivo Then
                    Dim dUltimaFechaActivacion As Date = DateSerial(1900, 1, 1)
                    Dim UltimaFechaSolicitud As Date
                    Dim sLlaveGen As String = String.Empty
                    sLlaveGen = GetOneKey(pvDispositivoID, dUltimaFechaActivacion, UltimaFechaSolicitud)

                    If sLlaveGen.Length > 0 Then
                        Me.LlaveHost = sLlaveGen
                        Me.FechaActivacion = dUltimaFechaActivacion
                        Me.FechaSolicitud = UltimaFechaSolicitud
                        Me.TipoLicencia = Registro.Definitivo
                        Modificar()
                    End If
                End If
            Else
                Try
                    Dim oTipoLicencia As Registro = Registro.Pendiente
                    Dim dUltimaFechaActivacion As Date = DateSerial(1900, 1, 1)
                    Dim UltimaFechaSolicitud As Date
                    Dim sLlaveGen As String = String.Empty

                    sLlaveGen = GetOneKey(pvDispositivoID, dUltimaFechaActivacion, UltimaFechaSolicitud)

                    If sLlaveGen.Length > 0 Then
                        oTipoLicencia = Registro.Definitivo
                    End If

                    Dim oDevice_Serial As New CDevice_Serial
                    With oDevice_Serial
                        .DispositivoID = pvDispositivoID
                        .Nombre_Dispositivo = pvDeviceName
                        .TipoLicencia = oTipoLicencia
                        .LlaveHost = sLlaveGen
                        .IntentosRestantes = 0
                        .FechaActivacion = dUltimaFechaActivacion
                        .FechaSolicitud = UltimaFechaSolicitud
                        .Insertar()
                    End With

                    Return oTipoLicencia

                Catch ex As Exception
                    Return Registro.ErrorRegistro
                End Try

            End If

            Return GetSerialType()

        Catch ex As Exception

            'Si ocurre algun error se regresa el codigo de error
            Return Registro.ErrorRegistro
        End Try

    End Function

    Private Function Existe(ByVal pvDispositivoID As String) As Boolean
        Return MobileClient.ConexionSQL.EjecutarConsultaObjeto("select count(*) from TerminalSerial where DispositivoID ='" & pvDispositivoID & "'") > 0
    End Function

    Private Sub Recuperar(ByVal pvDispositivoID As String)
        Dim dtDispositivo As Data.DataTable = MobileClient.ConexionSQL.RealizarConsulta("Select * from TerminalSerial where DispositivoID='" & pvDispositivoID & "'")
        Me.DispositivoID = dtDispositivo.Rows(0)("DispositivoID")
        If dtDispositivo.Rows.Count > 0 Then
            Me.Nombre_Dispositivo = dtDispositivo.Rows(0)("Nombre_Dispositivo")
            Me.TipoLicencia = dtDispositivo.Rows(0)("TipoLicencia")
            Me.LlaveHost = dtDispositivo.Rows(0)("LlaveHost")
            Me.IntentosRestantes = dtDispositivo.Rows(0)("IntentosRestantes")
            Me.FechaActivacion = dtDispositivo.Rows(0)("FechaActivacion")
            Me.FechaSolicitud = dtDispositivo.Rows(0)("FechaSolicitud")
        End If
    End Sub

    Private Sub Modificar()

        Dim sConsulta As New Text.StringBuilder
        sConsulta.Append("UPDATE TerminalSerial set ")
        sConsulta.Append("Nombre_Dispositivo='" & Me.Nombre_Dispositivo & "',")
        sConsulta.Append("TipoLicencia=" & Me.TipoLicencia & ",")
        sConsulta.Append("LlaveHost='" & Me.LlaveHost & "',")
        sConsulta.Append("IntentosRestantes=" & Me.IntentosRestantes & ",")
        sConsulta.Append("FechaActivacion=" & General.UniFechaSQL(Me.FechaActivacion) & ",")
        sConsulta.Append("FechaSolicitud=" & General.UniFechaSQL(Me.FechaSolicitud) & ",")
        sConsulta.Append("Comentarios='-',")
        sConsulta.Append("MFechaHora=getdate(),")
        sConsulta.Append("MUsuarioID='Admin' ")
        sConsulta.Append("Where DispositivoID='" & Me.DispositivoID & "'")

        MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
    End Sub

    Private Sub Insertar()

        Dim sConsulta As New Text.StringBuilder
        sConsulta.Append("INSERT TerminalSerial (DispositivoID,Nombre_dispositivo,TipoLicencia, LlaveHost, IntentosRestantes, FechaActivacion, FechaSolicitud,MFechaHora,MUsuarioID) VALUES (")
        sConsulta.Append("'" & Me.DispositivoID & "',")
        sConsulta.Append("'" & Me.Nombre_Dispositivo & "',")
        sConsulta.Append(Me.TipoLicencia & ",")
        sConsulta.Append("'" & Me.LlaveHost & "',")
        sConsulta.Append(Me.IntentosRestantes & ",")
        sConsulta.Append(General.UniFechaSQL(Me.FechaActivacion) & ",")
        sConsulta.Append(General.UniFechaSQL(Me.FechaSolicitud) & ",")
        sConsulta.Append("getdate(),")
        sConsulta.Append("'Admin')")

        MobileClient.ConexionSQL.EjecutarComando(sConsulta.ToString)
    End Sub

    Private Function GetSerialType() As Registro

        Dim oEncrypt As New CEncrypt.CEncrypt
        Dim sSerial As String
        Dim sTipo As String
        oEncrypt.KeyString = Format(Me.FechaSolicitud, "ssmm") & DispositivoID.Trim.Replace("-", "0").Substring(DispositivoID.Trim.Length - 12)

        If Me.LlaveHost.Trim.Length > 2 Then
            sSerial = oEncrypt.Encrypt(Me.LlaveHost.Trim)
            Try
                sTipo = sSerial.Substring(sSerial.Length - 3, 1)
                Dim oResult As CDevice_Serial.Registro

                Me.IntentosRestantes = sSerial.Substring(sSerial.Length - 2)
                oResult = sTipo

                '//Verificar que el Serial de la terminal sea el mismo
                If Not Me.DispositivoID.Substring(0, 20).Replace("-", "0") = sSerial.Substring(0, 20) Then
                    Return Registro.ErrorRegistro
                End If

                '//Verificar que todavia tenga acceso la terminal
                If oResult = Registro.Trial Then

                    If Me.IntentosRestantes - 1 <= 0 Then

                        Return Registro.TrialTerminado

                    Else
                        'Grabar el serial con un intento menos
                        Dim claveInicial As String
                        claveInicial = String.Format("{0}.{1}{2}", DispositivoID.Substring(0, 20), CType(oResult, Integer), Format(IntentosRestantes - 1, "00"))
                        Me.LlaveHost = oEncrypt.Encrypt(claveInicial)
                        Me.Modificar()

                        Return oResult

                    End If

                Else
                    Return oResult
                End If

            Catch ex As Exception
                Return Registro.ErrorRegistro
            End Try

        Else
            Return Registro.Pendiente
        End If

    End Function

    Private Function GetOneKey(ByVal pvDispositivoID As String, ByRef dUltimaFechaActivacion As Date, ByRef UltimaFechaSolicitud As Date) As String

        '--Revisar la tabla de licencias para ver si tiene para asignarle una
        Dim KeyNumbers As String = String.Empty
        Dim sLLaveGen As String = String.Empty
        Dim sNewKeyNumber As String = String.Empty
        Dim nLLaves As Integer
        Dim dFechaActivacion As Date

        Dim oEncrypt As New CEncrypt.CEncrypt

        KeyNumbers = MobileClient.ConexionSQL.EjecutarCmdScalarStrSQL("Select Top 1 KeyNumber from TerminalLicencias ")
        '--Se obtiene la ultima fecha de Activacion para desenllavar el KeyNumber
        dFechaActivacion = MobileClient.ConexionSQL.EjecutarConsultaObjeto("Select isnull(Max(FechaActivacion),'1900-01-01T00:00:00.000') as FechaActivacion from TerminalSerial ")

        '--Verificar si tiene llaves para generar 
        If dFechaActivacion = DateSerial(1900, 1, 1) Then
            oEncrypt.KeyString = "0130120059"
        Else
            oEncrypt.KeyString = Format(dFechaActivacion, "ssmmhhMMdd")
        End If

        '--Validar que la llave sea una llave Valida
        Dim tmpValidarLlave As String = String.Empty
        tmpValidarLlave = oEncrypt.Encrypt(KeyNumbers)

        Try
            '--Asignarle una LLave                    
            UltimaFechaSolicitud = Now.Now

            '--Validar que la llave tenga el mismo keyString
            If Not tmpValidarLlave.Substring(6, 10) = oEncrypt.KeyString Then
                Throw New Exception("")
            End If

            nLLaves = tmpValidarLlave.Substring(1, 3)

            'Si tiene llaves asignarle una
            If nLLaves > 0 Then

                oEncrypt.KeyString = Format(UltimaFechaSolicitud, "ssmm") & pvDispositivoID.Trim.Replace("-", "0").Substring(pvDispositivoID.Trim.Length - 12)
                sLLaveGen = String.Format("{0}.300", pvDispositivoID.Substring(0, 20))

                'Fix la llave no debe de tener -
                sLLaveGen = sLLaveGen.Replace("-", "0")
                sLLaveGen = oEncrypt.Encrypt(sLLaveGen)

                dUltimaFechaActivacion = Now.Now

                '--Volver a Guardar la llave                        
                oEncrypt.KeyString = Format(dUltimaFechaActivacion, "ssmmhhMMdd")
                sNewKeyNumber = oEncrypt.Encrypt(String.Format("A{0}LL{1}", Format(nLLaves - 1, "00#"), oEncrypt.KeyString))

                MobileClient.ConexionSQL.EjecutarComando(String.Format("Update TerminalLicencias set KeyNumber='{0}'", sNewKeyNumber))

                Return sLLaveGen

            Else
                Return ""
            End If

        Catch ex As Exception
            'No Validar nada no es necesario
            Return ""
        End Try

    End Function


    Public Enum Registro
        ErrorRegistro = -1
        Nuevo = 0
        Pendiente = 1
        Trial = 2
        Definitivo = 3
        TrialTerminado = 4
    End Enum
End Class
