Imports System.Data.SqlServerCe
Imports Resco.Controls
Imports System.Xml
Imports System.IO
Imports System.Collections.Generic
Imports System.Net

Public Class Config
#If MOD_TERM = "HHP" Then
#If SO_WCE = 1 Then
    Dim hhpConn As New HHP.WinCE.Network.RAS
#End If
#End If

    'General
    Protected sRutaTrabajo As String
    Protected sTipoLenguaje As String
    Protected sServidor As String
    Protected sURL As String
    Protected oUsuario As Usuario
    Protected sContrasena As String
    Protected sFormatoFecha As String
    Protected sFormatoDinero As String
    Protected sClaveTerminal As String
    Protected sModeloTerminal As String
    Protected blnExigirSecuenciaClientes As Boolean
    Protected iAnchoTicket As Short
    Protected tTipoSeleccion As ItemActivation
    Protected iUsarBitacoraPromociones As Short
    Protected iMaximoVisitas As Integer
    Public Shared vcFechaHora As String
    Private Shared vcSemilla As Integer = 0
    Protected iTimeOut As Integer
    Protected bCalendarioMovil As Boolean
    Protected bUsarWireless As Boolean
    Protected sContraseniaAseguramiento As String
    Protected bAseguramientoVisita As Boolean
    Protected iTimeOutGPS As Integer 'Timeout para la conexion del GPS, en segundos
    Protected bHabilitarLog As Boolean
    Protected bClienteNuevo As Boolean

    'Conexiones 
    Protected bActivo As Boolean
    Protected sNombre As String
    Protected sUser As String
    Protected sPassword As String
    
    'WiFi
    Protected otipoEAP As OpenNETCF.Net.EAPType
    Protected oEAPflags As OpenNETCF.Net.EAPFlags
    Protected bautent8021x As Boolean
    Protected oautentModo As OpenNETCF.Net.AuthenticationMode
    Protected oautent As OpenNETCF.Net.WEPStatus
    Protected ossid As String
    Protected opwd As String
    Protected ozeroconfig As Boolean

    'Puertos 
    Protected tPuertos As DataTable ' Tabla con los modelos de impresoras y su puerto asignado


    Public Property WiFiTipoEAP() As String
        Get
            Select Case otipoEAP
                Case OpenNETCF.Net.EAPType.MD5
                    Return "MD5"
                Case OpenNETCF.Net.EAPType.MSCHAPv2
                    Return "MSCHAPv2"
                Case OpenNETCF.Net.EAPType.PEAP
                    Return "PEAP"
                Case OpenNETCF.Net.EAPType.TLS
                    Return "TLS"
            End Select
            Return ""
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "MD5"
                    otipoEAP = OpenNETCF.Net.EAPType.MD5
                Case "MSCHAPv2"
                    otipoEAP = OpenNETCF.Net.EAPType.MSCHAPv2
                Case "PEAP"
                    otipoEAP = OpenNETCF.Net.EAPType.PEAP
                Case "TLS"
                    otipoEAP = OpenNETCF.Net.EAPType.TLS
            End Select
        End Set
    End Property

    Public Property WiFiEAPflags() As String
        Get
            Select Case oEAPflags
                Case OpenNETCF.Net.EAPFlags.DefaultGuestAuthentication
                    Return "DefaultGuestAuthentication"
                Case OpenNETCF.Net.EAPFlags.DefaultMachineAuthentication
                    Return "DefaultMachineAuthentication"
                Case OpenNETCF.Net.EAPFlags.DefaultState
                    Return "DefaultState"
                Case OpenNETCF.Net.EAPFlags.DefaultWZCFlags
                    Return "DefaultWZCFlags"
                Case OpenNETCF.Net.EAPFlags.Disabled
                    Return "Disabled"
                Case OpenNETCF.Net.EAPFlags.Enabled
                    Return "Enabled"
                Case OpenNETCF.Net.EAPFlags.GuestAuthenticationDisabled
                    Return "GuestAuthenticationDisabled"
                Case OpenNETCF.Net.EAPFlags.GuestAuthenticationEnabled
                    Return "GuestAuthenticationEnabled"
                Case OpenNETCF.Net.EAPFlags.MachineAuthenticationDisabled
                    Return "MachineAuthenticationDisabled"
                Case OpenNETCF.Net.EAPFlags.MachineAuthenticationEnabled
                    Return "MachineAuthenticationEnabled"
            End Select
            Return ""
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "DefaultGuestAuthentication"
                    oEAPflags = OpenNETCF.Net.EAPFlags.DefaultGuestAuthentication
                Case "DefaultMachineAuthentication"
                    oEAPflags = OpenNETCF.Net.EAPFlags.DefaultMachineAuthentication
                Case "DefaultState"
                    oEAPflags = OpenNETCF.Net.EAPFlags.DefaultState
                Case "DefaultWZCFlags"
                    oEAPflags = OpenNETCF.Net.EAPFlags.DefaultWZCFlags
                Case "DefaultWZCFlags"
                    oEAPflags = OpenNETCF.Net.EAPFlags.DefaultWZCFlags
                Case "Disabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.Disabled
                Case "Enabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.Enabled
                Case "GuestAuthenticationDisabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.GuestAuthenticationDisabled
                Case "GuestAuthenticationEnabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.GuestAuthenticationEnabled
                Case "MachineAuthenticationDisabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.MachineAuthenticationDisabled
                Case "MachineAuthenticationEnabled"
                    oEAPflags = OpenNETCF.Net.EAPFlags.MachineAuthenticationEnabled
            End Select
        End Set
    End Property

    Public Property WiFiAutent8021x() As Boolean
        Get
            Return bautent8021x
        End Get
        Set(ByVal value As Boolean)
            bautent8021x = value
        End Set
    End Property
    Public Property WiFiAutentModo() As String
        Get
            Select Case oautentModo
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeAutoSwitch
                    Return "AutoSwitch"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeMax
                    Return "Max"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeOpen
                    Return "Open"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeShared
                    Return "Shared"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPA
                    Return "WPA"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPANone
                    Return "WPANone"
                Case OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPAPSK
                    Return "WPAPSK"
            End Select
            Return ""
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "AutoSwitch"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeAutoSwitch
                Case "Max"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeMax
                Case "Open"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeOpen
                Case "Shared"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeShared
                Case "WPA"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPA
                Case "WPANone"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPANone
                Case "WPAPSK"
                    oautentModo = OpenNETCF.Net.AuthenticationMode.Ndis802_11AuthModeWPAPSK
            End Select
        End Set
    End Property
    Public Property WiFiAutent() As String
        Get
            Select Case oautent
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption1Enabled
                    Return "Encryption1Enabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption1KeyAbsent
                    Return "Encryption1KeyAbsent"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption2Enabled
                    Return "Encryption2Enabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption2KeyAbsent
                    Return "Encryption2KeyAbsent"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption3Enabled
                    Return "Encryption3Enabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11Encryption3KeyAbsent
                    Return "Encryption3KeyAbsent"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11EncryptionDisabled
                    Return "EncryptionDisabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11EncryptionNotSupported
                    Return "EncryptionNotSupported"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11WEPDisabled
                    Return "WEPDisabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11WEPEnabled
                    Return "WEPEnabled"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11WEPKeyAbsent
                    Return "WEPKeyAbsent"
                Case OpenNETCF.Net.WEPStatus.Ndis802_11WEPNotSupported
                    Return "WEPNotSupported"
            End Select
            Return ""
        End Get
        Set(ByVal value As String)
            Select Case value
                Case "Encryption1Enabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption1Enabled
                Case "Encryption1KeyAbsent"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption1KeyAbsent
                Case "Encryption2Enabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption2Enabled
                Case "Encryption2KeyAbsent"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption2KeyAbsent
                Case "Encryption3Enabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption3Enabled
                Case "Encryption3KeyAbsent"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11Encryption3KeyAbsent
                Case "EncryptionDisabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11EncryptionDisabled
                Case "EncryptionNotSupported"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11EncryptionNotSupported
                Case "WEPDisabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11WEPDisabled
                Case "WEPEnabled"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11WEPEnabled
                Case "WEPKeyAbsent"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11WEPKeyAbsent
                Case "WEPNotSupported"
                    oautent = OpenNETCF.Net.WEPStatus.Ndis802_11WEPNotSupported
            End Select
        End Set
    End Property

    Public Property SSID() As String
        Get
            Return ossid
        End Get
        Set(ByVal value As String)
            ossid = value
        End Set
    End Property

    Public Property PWD() As String
        Get
            Return opwd
        End Get
        Set(ByVal value As String)
            opwd = value
        End Set
    End Property

    'General
    Public Property RutaTrabajo() As String
        Get
            Return sRutaTrabajo
        End Get
        Set(ByVal Value As String)
            sRutaTrabajo = Value
        End Set
    End Property
    Public Property TipoLenguaje() As String
        Get
            Return sTipoLenguaje
        End Get
        Set(ByVal Value As String)
            sTipoLenguaje = Value
        End Set
    End Property
    Public Property Servidor() As String
        Get
            Return sServidor.Trim
        End Get
        Set(ByVal Value As String)
            sServidor = Value
        End Set
    End Property
    Public Property URL() As String
        Get
            Return sURL
        End Get
        Set(ByVal Value As String)
            sURL = Value
        End Set
    End Property
    Public Property Usuario() As Usuario
        Get
            Return oUsuario
        End Get
        Set(ByVal Value As Usuario)
            oUsuario = Value
        End Set
    End Property
    Public Property Contrasena() As String
        Get
            Return sContrasena
        End Get
        Set(ByVal Value As String)
            sContrasena = Value
        End Set
    End Property
    Public Property FormatoFecha() As String
        Get
            Return sFormatoFecha
        End Get
        Set(ByVal Value As String)
            sFormatoFecha = Value
        End Set
    End Property
    Public Property FormatoDinero() As String
        Get
            Return sFormatoDinero
        End Get
        Set(ByVal Value As String)
            sFormatoDinero = Value
        End Set
    End Property
    Public Property ClaveTerminal() As String
        Get
            Return sClaveTerminal
        End Get
        Set(ByVal Value As String)
            sClaveTerminal = Value
        End Set
    End Property
    Public Property TipoSeleccion() As ItemActivation
        Get
            Return tTipoSeleccion
        End Get
        Set(ByVal Value As ItemActivation)
            tTipoSeleccion = Value
        End Set
    End Property
    Public Property UsarBitacoraPromociones() As Short
        Get
            Return iUsarBitacoraPromociones
        End Get
        Set(ByVal Value As Short)
            iUsarBitacoraPromociones = Value
        End Set
    End Property

    Public Property ModeloTerminal() As String
        Get
            Return sModeloTerminal
        End Get
        Set(ByVal Value As String)
            sModeloTerminal = Value
        End Set
    End Property

    Public Property ExigirSecuenciaClientes() As Boolean
        Get
            Return blnExigirSecuenciaClientes
        End Get
        Set(ByVal value As Boolean)
            blnExigirSecuenciaClientes = value
        End Set
    End Property

    Public Property AnchoTicket() As Short
        Get
            Return iAnchoTicket
        End Get
        Set(ByVal value As Short)
            iAnchoTicket = value
        End Set
    End Property
    Public Property MaximoVisitas() As Integer
        Get
            Return iMaximoVisitas
        End Get
        Set(ByVal Value As Integer)
            iMaximoVisitas = Value
        End Set
    End Property

    Public Property TimeOut() As Integer
        Get
            Return iTimeOut
        End Get
        Set(ByVal Value As Integer)
            iTimeOut = Value
        End Set
    End Property

    Public Property CalendarioMovil() As Boolean
        Get
            Return bCalendarioMovil
        End Get
        Set(ByVal value As Boolean)
            bCalendarioMovil = value
        End Set
    End Property

    Public Property UsarWireless() As Boolean
        Get
            Return bUsarWireless
        End Get
        Set(ByVal value As Boolean)
            bUsarWireless = value
        End Set
    End Property
    Public Property ContraseniaAseguramiento() As String
        Get
            Return sContraseniaAseguramiento
        End Get
        Set(ByVal value As String)
            sContraseniaAseguramiento = value
        End Set
    End Property

    Public Property AseguramientoVisita() As Boolean
        Get
            Return bAseguramientoVisita
        End Get
        Set(ByVal value As Boolean)
            bAseguramientoVisita = value
        End Set
    End Property
    Public Property TimeOutGPS() As Integer
        Get
            Return iTimeOutGPS
        End Get
        Set(ByVal value As Integer)
            iTimeOutGPS = value
        End Set
    End Property
    Public Property HabilitarLog() As Boolean
        Get
            Return bHabilitarLog
        End Get
        Set(ByVal value As Boolean)
            bHabilitarLog = value
        End Set
    End Property
    Public Property ClienteNuevo()
        Get
            Return bClienteNuevo
        End Get
        Set(ByVal value)
            bClienteNuevo = value
        End Set
    End Property
    
    'Conexiones
    Public Property Activo() As String
        Get
            Return bActivo
        End Get
        Set(ByVal Value As String)
            bActivo = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property

    Public Property User() As String
        Get
            Return sUser
        End Get
        Set(ByVal Value As String)
            sUser = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return sPassword
        End Get
        Set(ByVal Value As String)
            sPassword = Value
        End Set
    End Property
    'Puertos
    Public Property Puertos() As DataTable
        Get
            Return tPuertos
        End Get
        Set(ByVal value As DataTable)
            tPuertos = value
        End Set
    End Property

    Public Sub New()
        'General
        TipoSeleccion = ItemActivation.OneClick
        Servidor = "192.168.0.1"
        URL = "ServicesCentral2005"
        Usuario = New Usuario
        Usuario.Clave = "1"
        Contrasena = String.Empty
        ClaveTerminal = "1"
        TipoLenguaje = "EM"
        'RutaTrabajo = "\Application\Route"
        RutaTrabajo = "\IPSM\Route"
        FormatoFecha = "dd/MM/yyyy"
        FormatoDinero = "$###,##0.00"
        UsarBitacoraPromociones = 1
        ModeloTerminal = "Generico"
        'Lo del keygen
        If (IsNothing(vcFechaHora) = True) Then
            vcFechaHora = Now.ToString("yyyyMMddHHmmssff")
        End If
        ExigirSecuenciaClientes = False
        AnchoTicket = 2
        MaximoVisitas = 0
        TimeOut = 5
        CalendarioMovil = True
        UsarWireless = False
        TimeOutGPS = 60
        HabilitarLog = False
        ClienteNuevo = True

        Puertos = New DataTable("Puertos")

        'Conexiones
        bActivo = False
        Nombre = "BT"
        User = "1"
        Password = "1"

        'WiFi
        WiFiAutent = "Encryption2Enabled"
        WiFiAutent8021x = "True"
        WiFiAutentModo = "WPAPSK"
        WiFiEAPflags = "DefaultState"
        WiFiTipoEAP = "TLS"
        SSID = "amesol"
        PWD = "amesol"

    End Sub

    Public Function RecuperarConfiguracion() As Boolean
        Dim res As Boolean = True
        If Not File.Exists(PubcArchivoConfig) Then
            ' Crearlo con los valores por defecto
            res = PedirDatosServidor()
        Else
            ' Existe, abrirlo y recuperar los valores
            LeerConfiguracion()
        End If
        If (res) Then
            CopiarAFlash()
        End If
        Return res
    End Function

    Public Function conectarRAS() As Boolean
        Dim res As Boolean = False
#If MOD_TERM = "HHP" Then
#If SO_WCE = 0 Then

#Else
        ' Usar un DataSet para leer el contenido del archivo XML
        Dim DataSetConfig As New DataSet("Config")
        Dim refDataTableConfig As DataTable
        Dim refDataRowActual As DataRow

        DataSetConfig.ReadXml(PubcArchivoConfig)
        refDataTableConfig = DataSetConfig.Tables("Conexiones")

        If Not IsNothing(refDataTableConfig) Then
            For Each refDataRowActual In refDataTableConfig.Rows
                Try
                    If Convert.ToBoolean(refDataRowActual.Item("Activo")) Then
                        If hhpConn.EntryExists(refDataRowActual.Item("Nombre").ToString()) Then
                            hhpConn.Dial(refDataRowActual.Item("Nombre").ToString(), refDataRowActual("User"), refDataRowActual("Password"))
                            Dim intentos As Integer = 0
                            Application.DoEvents()
                            System.Threading.Thread.Sleep(5000)
                            Do
                                Application.DoEvents()
                                System.Threading.Thread.Sleep(3000)
                                If hhpConn.GetStatus() = HHP.WinCE.Network.RAS.ConnState.RASCS_Connected Then
                                    res = True
                                    Application.DoEvents()
                                    System.Threading.Thread.Sleep(5000)
                                    ProbarServicioR(3)
                                    Exit For
                                End If
                                intentos = intentos + 1
                            Loop Until intentos >= 3
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
        refDataTableConfig.Clear()
        refDataTableConfig.Dispose()
#End If
#End If
        Return res
    End Function

    Public Function desconectarRAS() As Boolean
        Dim res As Boolean = False
#If MOD_TERM = "HHP" Then
#If SO_WCE = 0 Then

#Else
        Try
            If hhpConn.GetStatus() = HHP.WinCE.Network.RAS.ConnState.RASCS_Connected Then
                hhpConn.HangUp()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
#End If
#End If
        Return res
    End Function

    Public Function RevisarServidor() As Boolean
        Dim a As New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
        Select Case ModeloTerminal
            Case "SymbolMC35"
                a = New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
            Case "IntermecCN3"
                a = New PhoneRadio(PhoneRadio.TipoTerminal.IntermecCN3)
        End Select
        Dim res As Boolean = False
        Dim intentos As Integer = 0
        Do
            If (a.HayWiFi()) Then
                ActivarWiFi(a)
                res = ProbarServicioR(3)
            Else
                res = ProbarServicioR(3)
                If (Not res) Then
                    ActivarWiFi(a)
                    res = ProbarServicioR(3)
                End If
            End If
            If Not res Then
                System.Threading.Thread.Sleep(5000)
            End If
            intentos = intentos + 1
        Loop While res = False And intentos < 3
        a.Dispose()
        Return res
    End Function
    Public Sub ActivarWiFi()
        If oApp.UsarWireless Then
            Dim a As PhoneRadio
            Select Case ModeloTerminal
                Case "SymbolMC35"
                    a = New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
                Case "IntermecCN3"
                    a = New PhoneRadio(PhoneRadio.TipoTerminal.IntermecCN3)
            End Select
            If Not IsNothing(a) Then
                ActivarWiFi(a)
                a.Dispose()
            End If
        End If
    End Sub

    Private Function ActivarWiFi(ByVal a As PhoneRadio) As Boolean
        Dim res As Boolean = False
        Select Case ModeloTerminal
            Case "SymbolMC35"
                If (Not a.HayWiFi()) Then
                    a.HabilitarWiFi()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    a.WiFi(PhoneRadio.PowerState.D0)
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    a.HabilitarWiFi()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(20000)
                End If
                If (Not a.WiFiConectado()) Then
                    If a.WiFiConf(SSID, PWD, otipoEAP, oEAPflags, bautent8021x, oautentModo, oautent) Then
                        res = True
                    End If
                Else
                    res = True
                End If
            Case "IntermecCN3"
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(2000)
                If (Not a.HayWiFi()) Then
                    a.HabilitarWiFi()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    a.WiFi(PhoneRadio.PowerState.D0)
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    a.HabilitarWiFi()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(20000)
                End If

                
                res = True
        End Select

        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(2000)

        Return res
    End Function
    Public Sub DesactivarWiFi()
        If oApp.UsarWireless Then
            Dim a As PhoneRadio
            Select Case ModeloTerminal
                Case "SymbolMC35"
                    a = New PhoneRadio(PhoneRadio.TipoTerminal.SymbolMC35)
                    'Case "HHP7600"
                    '    HHP.Network.RadioMgr.RadioMgrServices.SetRadioMode(HHP.Network.RadioMgr.RadioMgrServices.RadioOPMode.OP_NONE)
                    'Case "HHP7600"
                    '    HHP.Network.RadioMgr.RadioMgrServices.SetRadioMode(HHP.Network.RadioMgr.RadioMgrServices.RadioOPMode.OP_NONE)
                Case "IntermecCN3"
                    a = New PhoneRadio(PhoneRadio.TipoTerminal.IntermecCN3)
            End Select
            If Not IsNothing(a) Then
                If (a.HayWiFi()) Then
                    a.WiFi(PhoneRadio.PowerState.D4)
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(500)
                    a.DeshabilitarWiFi()
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(500)
                End If
                a.Dispose()
            End If
        End If
    End Sub


    'Private Function ProbarServicio(ByVal servicio As ServicesCentral.ServiceMobileClient) As Boolean
    '    Dim intentos As Byte = 0
    '    Dim timeout As Integer = servicio.Timeout
    '    servicio.Timeout = 3000
    '    Dim si As Boolean = False
    '    Do
    '        Try
    '            servicio.WSAuditoriaVerificar()
    '            si = True
    '        Catch ex As Exception
    '        End Try
    '        intentos += 1
    '        If Not si Then
    '            System.Windows.Forms.Application.DoEvents()
    '            System.Threading.Thread.Sleep(1000)
    '        Else
    '            Exit Do
    '        End If
    '    Loop While si = False And intentos < 10
    '    servicio.Timeout = timeout
    '    Return si
    'End Function
    Public Function ProbarServicioR(ByVal NumeroIntentos As Integer) As Boolean
        Dim intentos As Byte = 0
        Dim si As Boolean = False
        Do
            Try
                si = IsWebAccessible("http://" & oApp.Servidor & "/" & oApp.URL & "/" & PubcServiceMobileClient)
            Catch ex As Exception
            End Try
            intentos += 1
            If Not si Then
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
            Else
                Exit Do
            End If

       Loop While si = False And intentos < NumeroIntentos
        Return si
    End Function

    Private Function IsWebAccessible(ByVal servidor As String) As Boolean
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse
        Try
            request = CType(WebRequest.Create(servidor), HttpWebRequest)
            response = CType(request.GetResponse(), HttpWebResponse)
            If response.StatusCode = HttpStatusCode.OK Then
                IsWebAccessible = True
            End If
            response.Close()
        Catch weberrt As WebException
            IsWebAccessible = False
        Catch except As Exception
            IsWebAccessible = False
        Finally
            request = Nothing
            response = Nothing
        End Try
    End Function
    Private Sub CopiarAFlash()

        Dim ruta = GetStorageCard()
        Dim Directorio As String = "\Autoinstall"
        If ModeloTerminal = "IntermecCN3" Then
            Directorio = "\SSPB"
        End If
        If (ruta <> "") Then
            If (Directory.Exists(ruta + Directorio)) Then
                Dim arch As New FileInfo(PubcArchivoConfig)
                arch.CopyTo(ruta & Directorio & "\" & arch.Name, True)
            End If
        End If
    End Sub
    Private Function GetStorageCard() As String
        Dim firstCard As String = ""
        Dim di As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("\")
        Dim fsi As DirectoryInfo() = di.GetDirectories()
        For x As Integer = 0 To fsi.Length - 1
            If ((fsi(x).Attributes And FileAttributes.Temporary) = FileAttributes.Temporary) Then
                firstCard = fsi(x).FullName
            End If
        Next
        Return firstCard
    End Function

    Public Function LeerConfiguracion() As Boolean
        Try

            ' Usar un DataSet para leer el contenido del archivo XML
            Dim DataSetConfig As New DataSet("Config")
            ' Leer el archivo XML con el esquema
            DataSetConfig.ReadXml(PubcArchivoConfig)

            Dim refDataRowActual As DataRow
            'General
            Dim refDataTableConfig As DataTable
            refDataTableConfig = DataSetConfig.Tables("General")
            refDataRowActual = refDataTableConfig.Rows(0)
            ' Recuperar los valores del archivo XML
            Servidor = refDataRowActual("Servidor")
            URL = refDataRowActual("URL")
            Usuario.Clave = refDataRowActual("Usuario")
            Contrasena = refDataRowActual("Contrasena")
            ClaveTerminal = refDataRowActual("ClaveTerminal")
            TipoLenguaje = refDataRowActual("TipoLenguaje")
            RutaTrabajo = refDataRowActual("RutaTrabajo")
            FormatoFecha = refDataRowActual("FormatoFecha")
            FormatoDinero = refDataRowActual("FormatoDinero")
            UsarBitacoraPromociones = refDataRowActual("UsarBitacoraPromociones")
            ModeloTerminal = refDataRowActual("ModeloTerminal")
            ExigirSecuenciaClientes = refDataRowActual("ExigirSecuenciaClientes")
            AnchoTicket = refDataRowActual("AnchoTicket")

            If refDataRowActual.Table.Columns.Contains("ContraseniaAseguramiento") Then
                Me.ContraseniaAseguramiento = refDataRowActual("ContraseniaAseguramiento")
            Else
                Me.ContraseniaAseguramiento = "123"
            End If

            If refDataRowActual.Table.Columns.Contains("AseguramientoVisita") Then
                Me.AseguramientoVisita = refDataRowActual("AseguramientoVisita")
            Else
                Me.AseguramientoVisita = True
            End If

            If refDataRowActual.Table.Columns.Contains("MaximoVisitas") Then
                MaximoVisitas = refDataRowActual("MaximoVisitas")
            End If
            If refDataRowActual.Table.Columns.Contains("TimeOut") Then
                TimeOut = refDataRowActual("TimeOut")
            End If
            If refDataRowActual.Table.Columns.Contains("CalendarioMovil") Then
                CalendarioMovil = refDataRowActual("CalendarioMovil")
            End If
            If refDataRowActual.Table.Columns.Contains("UsarWireless") Then
                UsarWireless = refDataRowActual("UsarWireless")
            End If
            If refDataRowActual.Table.Columns.Contains("TimeOutGPS") Then
                TimeOutGPS = refDataRowActual("TimeOutGPS")
            End If
            If refDataRowActual.Table.Columns.Contains("HabilitarLog") Then
                HabilitarLog = refDataRowActual("HabilitarLog")
            End If
            If refDataRowActual.Table.Columns.Contains("ClienteNuevo") Then
                ClienteNuevo = refDataRowActual("ClienteNuevo")
            End If
            refDataTableConfig.Dispose()

            'Conexiones
            Dim refDataTableConexiones As DataTable = DataSetConfig.Tables("Conexiones")
            If Not IsNothing(refDataTableConexiones) Then
                refDataRowActual = refDataTableConexiones.Rows(0)
                If refDataRowActual.Table.Columns.Contains("Activo") Then
                    Activo = refDataRowActual("Activo")
                End If
                Nombre = refDataRowActual("Nombre")
                User = refDataRowActual("User")
                Password = refDataRowActual("Password")
                refDataTableConexiones.Dispose()
            End If

            'WiFi
            Dim refDataTableWiFi As DataTable = DataSetConfig.Tables("WiFi")
            If Not IsNothing(refDataTableWiFi) Then
                refDataRowActual = refDataTableWiFi.Rows(0)
                WiFiTipoEAP = refDataRowActual("EAPType")
                WiFiEAPflags = refDataRowActual("EAPFlags")
                WiFiAutent8021x = Convert.ToBoolean(refDataRowActual("Autentificacion802.1x"))
                WiFiAutentModo = refDataRowActual("ModoAutentifiacion")
                WiFiAutent = refDataRowActual("Encriptacion")
                SSID = refDataRowActual("SSID")
                PWD = refDataRowActual("PWD")
            End If

            'Puertos
            Dim refDataTablePuertos As DataTable = DataSetConfig.Tables("Puertos")
            If Not IsNothing(refDataTablePuertos) Then
                Puertos.Columns.Add("Impresora")
                Puertos.Columns.Add("Puerto")
                For Each fila As DataRow In refDataTablePuertos.Rows
                    Puertos.Rows.Add(New Object() {fila("Impresora"), fila("Puerto")})
                Next
            End If

            Return True
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Leer")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Leer")
        End Try
        Return False
    End Function

    Public Function GuardarConfiguracion() As Boolean
        Try
            Dim DataSetConfig As New DataSet("Config")
            ' Crear las tablas 
            'General
            Dim DataTableGeneral As New DataTable("General")
            ' Agregar las columnas
            DataTableGeneral.Columns.Add("Servidor", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("URL", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("Usuario", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("Contrasena", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("ClaveTerminal", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("TipoLenguaje", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("RutaTrabajo", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("FormatoFecha", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("FormatoDinero", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("UsarBitacoraPromociones", System.Type.GetType("System.Int32"))
            DataTableGeneral.Columns.Add("ModeloTerminal", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("ExigirSecuenciaClientes", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("AnchoTicket", System.Type.GetType("System.Int16"))
            DataTableGeneral.Columns.Add("MaximoVisitas", System.Type.GetType("System.Int16"))
            DataTableGeneral.Columns.Add("TimeOut", System.Type.GetType("System.Int16"))
            DataTableGeneral.Columns.Add("CalendarioMovil", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("UsarWireless", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("ContraseniaAseguramiento", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("AseguramientoVisita", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("TimeOutGPS", System.Type.GetType("System.Int16"))
            DataTableGeneral.Columns.Add("HabilitarLog", System.Type.GetType("System.String"))
            DataTableGeneral.Columns.Add("ClienteNuevo", System.Type.GetType("System.String"))
            ' Adjuntar la tabla al dataset
            DataSetConfig.Tables.Add(DataTableGeneral)
            ' Agregar un renglón con los valores por defecto
            Dim refDataRowNueva As DataRow
            refDataRowNueva = DataTableGeneral.NewRow()
            refDataRowNueva("Servidor") = Servidor
            refDataRowNueva("URL") = URL
            refDataRowNueva("Usuario") = Usuario.Clave
            refDataRowNueva("Contrasena") = Contrasena
            refDataRowNueva("ClaveTerminal") = ClaveTerminal
            refDataRowNueva("TipoLenguaje") = TipoLenguaje
            refDataRowNueva("RutaTrabajo") = RutaTrabajo
            refDataRowNueva("FormatoFecha") = FormatoFecha
            refDataRowNueva("FormatoDinero") = FormatoDinero
            refDataRowNueva("UsarBitacoraPromociones") = UsarBitacoraPromociones

            'Revisamos si no trae nada y asignamos generico
            If ModeloTerminal = String.Empty Then
                refDataRowNueva("ModeloTerminal") = "Generico"
            Else
                refDataRowNueva("ModeloTerminal") = ModeloTerminal
            End If
            refDataRowNueva("ExigirSecuenciaClientes") = ExigirSecuenciaClientes
            refDataRowNueva("AnchoTicket") = AnchoTicket
            refDataRowNueva("MaximoVisitas") = MaximoVisitas
            refDataRowNueva("TimeOut") = TimeOut
            refDataRowNueva("CalendarioMovil") = CalendarioMovil
            refDataRowNueva("UsarWireless") = UsarWireless
            refDataRowNueva("ContraseniaAseguramiento") = Me.ContraseniaAseguramiento
            refDataRowNueva("AseguramientoVisita") = Me.AseguramientoVisita
            refDataRowNueva("TimeOutGPS") = TimeOutGPS
            refDataRowNueva("HabilitarLog") = HabilitarLog
            refDataRowNueva("ClienteNuevo") = ClienteNuevo

            DataTableGeneral.Rows.Add(refDataRowNueva)


            'Conexiones
            Dim DataTableConexiones As New DataTable("Conexiones")
            DataTableConexiones.Columns.Add("Activo", System.Type.GetType("System.String"))
            DataTableConexiones.Columns.Add("Nombre", System.Type.GetType("System.String"))
            DataTableConexiones.Columns.Add("User", System.Type.GetType("System.String"))
            DataTableConexiones.Columns.Add("Password", System.Type.GetType("System.String"))
            DataSetConfig.Tables.Add(DataTableConexiones)

            refDataRowNueva = DataTableConexiones.NewRow()
            refDataRowNueva("Activo") = Activo
            refDataRowNueva("Nombre") = IIf(Nombre = String.Empty, "BT", Nombre)
            refDataRowNueva("User") = IIf(User = String.Empty, "1", User)
            refDataRowNueva("Password") = IIf(Password = String.Empty, "1", Password)

            DataTableConexiones.Rows.Add(refDataRowNueva)

            'Conexiones
            Dim DataTableWiFi As New DataTable("WiFi")
            DataTableWiFi.Columns.Add("EAPType", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("EAPFlags", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("Autentificacion802.1x", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("ModoAutentifiacion", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("Encriptacion", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("SSID", System.Type.GetType("System.String"))
            DataTableWiFi.Columns.Add("PWD", System.Type.GetType("System.String"))

            DataSetConfig.Tables.Add(DataTableWiFi)

            refDataRowNueva = DataTableWiFi.NewRow()

            refDataRowNueva("EAPType") = WiFiTipoEAP
            refDataRowNueva("EAPFlags") = WiFiEAPflags
            refDataRowNueva("Autentificacion802.1x") = WiFiAutent8021x
            refDataRowNueva("ModoAutentifiacion") = WiFiAutentModo
            refDataRowNueva("Encriptacion") = WiFiAutent
            refDataRowNueva("SSID") = SSID
            refDataRowNueva("PWD") = PWD
            DataTableWiFi.Rows.Add(refDataRowNueva)

            'Puertos
            Dim DS As DataSet = Puertos.DataSet
            If Not DS Is Nothing Then
                DS.Tables.Remove(Puertos)
                DS.Dispose()
            End If
            DS = Nothing
            DataSetConfig.Tables.Add(Puertos)

            ' Verificar que exista el directorio
            If Not Directory.Exists(RutaTrabajo) Then
                Directory.CreateDirectory(RutaTrabajo)
            End If
            ' Escribir el contenido del dataset en XML 
            Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(PubcArchivoConfig, System.Text.Encoding.Unicode)
            ' Escribir en el archivo XML
            DataSetConfig.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
            ' Cerrar el flujo XML
            XmlTextWriterDicc.Close()
            DataTableGeneral.Dispose()
            DataTableConexiones.Dispose()
            DataSetConfig.Dispose()
            Return True
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Guardar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Guardar")
        End Try
        Return False
    End Function

    Public Shared Function KEYGEN(ByVal pariSemilla As Integer) As String
        Dim length As Integer = 16

        Dim guidResult As String = String.Empty
        While guidResult.Length < length

            ' Get the GUID.        
            guidResult += Guid.NewGuid().ToString().GetHashCode().ToString("x")
        End While

        ' Make sure length is valid.    
        If (length <= 0 Or length > guidResult.Length) Then
            Throw New ArgumentException("Length must be between 1 and " + guidResult.Length)
        End If
        ' Return the first length bytes.    
        Return guidResult.Substring(0, length)
    End Function

    Public Function SimpleCrypt(ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using 
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String = "", i As Integer
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function

End Class

Public Class Conexion

    Public oConexion As SqlCeConnection

    Protected sNombreArchivoSDF As String
    Protected tTipoTablas As ServicesCentral.TiposBase
    Protected dFechaIni As Date
    Protected dFechaFin As Date
    Protected iGrupo As Integer
    Protected bObligarCargarInformacion As Boolean
    Protected oTransaccion As SqlCeTransaction

    Dim bEnProceso As Boolean = False
    Dim bDescompactando As Boolean
    Dim bFinalizoCorrecto As Boolean
    Dim timeout As Integer
    Dim dsGeneral As DataSet
    Dim blnActualizacionCatalogos As Boolean
    Dim blnRecarga As Boolean

    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oTransaccion
        End Get
        Set(ByVal value As SqlCeTransaction)
            oTransaccion = value
        End Set
    End Property

    Public Property NombreArchivoSDF() As String
        Get
            Return sNombreArchivoSDF
        End Get
        Set(ByVal Value As String)
            sNombreArchivoSDF = Value
        End Set
    End Property
    Public Property TipoTablas() As ServicesCentral.TiposBase
        Get
            Return tTipoTablas
        End Get
        Set(ByVal Value As ServicesCentral.TiposBase)
            tTipoTablas = Value
        End Set
    End Property

    Public Property FechaIni() As Date
        Get
            Return dFechaIni
        End Get
        Set(ByVal Value As Date)
            dFechaIni = Value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return dFechaFin
        End Get
        Set(ByVal Value As Date)
            dFechaFin = Value
        End Set
    End Property

    Public Property Grupo() As Integer
        Get
            Return iGrupo
        End Get
        Set(ByVal Value As Integer)
            iGrupo = Value
        End Set
    End Property

    Public Property ObligarCargarInformacion() As Boolean
        Get
            Return bObligarCargarInformacion
        End Get
        Set(ByVal Value As Boolean)
            bObligarCargarInformacion = Value
        End Set
    End Property
    Public Sub New(ByVal parsNombreArchivoSDF As String, ByVal pareTipoTablas As ServicesCentral.TiposBase)
        sNombreArchivoSDF = parsNombreArchivoSDF
        tTipoTablas = pareTipoTablas

    End Sub
    Public Sub New(ByVal pareTipoTablas As ServicesCentral.TiposBase)
        sNombreArchivoSDF = ""
        tTipoTablas = pareTipoTablas

    End Sub

    Public Function Abrir(ByVal parbPreguntar As Boolean, Optional ByVal optparsCondicion As String = "*") As Boolean
        Try
            If Not File.Exists(PubcArchivoConfig) Then
                ' No existe, requiere conectarse al servidor para crear el esquema y luego la Base de datos (no existe ni el .sdf ni el .xml)
                If Not PedirDatosConexion() Then
                    Return False
                End If
            End If
            Dim blnCanjes As Boolean = False
            Dim blnRecienCreadoVendedor As Boolean = False
            bFinalizoCorrecto = True
            If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                FormProcesando.PubSubInformar("Checking files", NombreArchivoSDF)
                If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoSDF) Then
                    'Revisar la licencia inicial
                    FormProcesando.PubSubInformar("Conectando", "Checking Connection")

                    Dim bDisponible As Boolean = True
                    If (Not oApp.ProbarServicioR(3)) Then
                        bDisponible = False
                        If oApp.UsarWireless Then
                            bDisponible = oApp.RevisarServidor()
                        End If
                        If Not bDisponible Then
                            If oApp.conectarRAS() Then
                                If oApp.ProbarServicioR(3) Then
                                    bDisponible = True
                                End If
                            End If
                        End If
                        If Not bDisponible Then
                            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
                            Return False
                        End If
                    End If

                    FormProcesando.PubSubInformar("Creating database", "Checking License Key")

                    Dim oLicencia As New VersionesLicencias
                    If Not oLicencia.Revisar_Licencia() Then
                        Return False
                    End If

                    If Not oServicioWeb.WSAuditoriaVerificar Then
                        'El mensaje esta manual porque todavia no estan cargados los mensajes a la terminal en este punto
                        MsgBox("[E0562] El resultado de la auditoria de la información refleja que existen datos incorrectos o existen Objetos que no han sido Auditados.", MsgBoxStyle.Information, "Abrir")
                        Return False
                    End If

                    FormProcesando.PubSubInformar("Creating database", "Creating tables")
                    Dim bObtenerBD As Boolean = True
                    Dim sMensaje As String = String.Empty
                    While bObtenerBD
                        bEnProceso = True
                        bFinalizoCorrecto = False
                        Try
                            [Global].IniciarWS()
                            oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000
                            timeout = oServicioWeb.Timeout

                            Dim res As Byte() = oServicioWeb.WSAplicacionObtenerBD(CDevice.GetDeviceID(), oApp.Usuario.Clave, "*", sMensaje)
                            'oServicioWeb.TerminarSession()
                            EndObtenerAplicacionBD(res, sMensaje)
                            bObtenerBD = False
                        Catch ex As System.Net.WebException
                            If MsgBox("[P0102] No se puede establecer conexión con el Servidor ¿Desea intentarlo nuevamente?'", MsgBoxStyle.YesNo, "Abrir") = MsgBoxResult.No Then
                                bObtenerBD = False
                            End If
                            Application.DoEvents()
                            bDescompactando = False
                        End Try
                        oServicioWeb.Timeout = timeout
                        While bDescompactando
                        End While
                    End While
                End If
            Else
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "VerificandoArchivos"), NombreArchivoSDF)
                If Not System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoSDF) Then
                    'Revisar la licencia inicial

                    FormProcesando.PubSubInformar("Conectando", "Checking Connection")
                    Dim bDisponible As Boolean = True
                    If (Not oApp.ProbarServicioR(3)) Then
                        bDisponible = False
                        If oApp.UsarWireless Then
                            bDisponible = oApp.RevisarServidor()
                        End If
                        If Not bDisponible Then
                            If oApp.conectarRAS() Then
                                If oApp.ProbarServicioR(3) Then
                                    bDisponible = True
                                End If
                            End If
                        End If
                        If Not bDisponible Then
                            MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "F0008"), MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
                            Return False
                        End If
                    End If

                    FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "CreandoBaseDeDatos"), "Checking License Key")
                    Dim oLicencia As New VersionesLicencias
                    If Not oLicencia.Revisar_Licencia() Then
                        Return False
                    End If

                    If Not oServicioWeb.WSAuditoriaVerificar Then
                        'El mensaje esta manual porque todavia no estan cargados los mensajes a la terminal en este punto
                        MsgBox("[E0562] El resultado de la auditoria de la información refleja que existen datos incorrectos o existen Objetos que no han sido Auditados.", MsgBoxStyle.Information, "Abrir")
                        Return False
                    End If

                    Dim sNombreArchivoZip As String = NombreArchivoSDF.Replace(".sdf", ".zip")
                    Dim blnFacturas As Boolean = False
                    Dim sRespuesta As String = String.Empty
                    If Not oServicioWeb.WSVendedorObtenerAcceso(oApp.Usuario.Clave, oApp.Contrasena, oApp.ClaveTerminal, sRespuesta) Then
                        MsgBox(sRespuesta, MsgBoxStyle.Exclamation Or MsgBoxStyle.SystemModal)
                        Return False
                    End If

                    Dim oFormFiltroAgenda As New FormFiltroAgenda(True)
                    If oFormFiltroAgenda.ShowDialog() <> DialogResult.OK Then
                        oFormFiltroAgenda.Dispose()
                        Return False
                    End If

                    blnCanjes = oFormFiltroAgenda.CheckBoxCanjes.Checked
                    oFormFiltroAgenda.Dispose()

                    Dim sTipoConsultas As String = String.Empty
                    If blnCanjes = True Then
                        sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Canjes & ","
                    End If
                    sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Prestamos & ","
                    sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Cargas & ","
                    sTipoConsultas = sTipoConsultas & ServicesCentral.TiposConsulta.Consignacion

                    FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "CreandoBaseDeDatos"), gVista.BuscarMensaje("MsgBoxConexion", "CreandoTablas"))
                    '[Global].ActualizarURLWebService()
                    Dim bObtenerBD As Boolean = True
                    Dim sMensaje As String = String.Empty
                    While bObtenerBD
                        bEnProceso = True
                        bFinalizoCorrecto = False
                        Try
                            [Global].IniciarWS()
                            oServicioWeb.Timeout = (oApp.TimeOut * 60) * 1000
                            timeout = oServicioWeb.Timeout
                            Dim Mensaje As String = ""
                            Dim Verificar As String = oServicioWeb.WSVerificarVendedorObtenerBD(Mensaje)
                            If Verificar = "" Then
                                Dim res As Byte() = oServicioWeb.WSVendedorObtenerBD(oApp.ClaveTerminal, oApp.Usuario.Clave, oApp.Contrasena, PrimeraHora(oDBVen.FechaIni), UltimaHora(oDBVen.FechaFin), sTipoConsultas, sMensaje)
                                'oServicioWeb.TerminarSession()
                                EndObtenerVendedorBD(res, sMensaje)
                                bObtenerBD = False
                            Else
                                If Verificar = "P0202" Then
                                    If MsgBox(Mensaje, MsgBoxStyle.YesNo, Verificar) = MsgBoxResult.Yes Then
                                        Application.DoEvents()
                                        Dim res As Byte() = oServicioWeb.WSVendedorObtenerBD(oApp.ClaveTerminal, oApp.Usuario.Clave, oApp.Contrasena, PrimeraHora(oDBVen.FechaIni), UltimaHora(oDBVen.FechaFin), sTipoConsultas, sMensaje)
                                        'oServicioWeb.TerminarSession()
                                        EndObtenerVendedorBD(res, sMensaje)

                                    Else
                                        Application.DoEvents()
                                        bDescompactando = False

                                    End If
                                    bObtenerBD = False
                                End If
                            End If

                        Catch ex As System.Net.WebException
                            If MsgBox("[P0102] No se puede establecer conexión con el Servidor ¿Desea intentarlo nuevamente?", MsgBoxStyle.YesNo, "Abrir") = MsgBoxResult.No Then
                                bObtenerBD = False
                            End If
                            Application.DoEvents()
                            bDescompactando = False
                        End Try
                        oServicioWeb.Timeout = timeout
                        While bDescompactando

                        End While
                        If bFinalizoCorrecto Then
                            bObtenerBD = False
                            blnRecienCreadoVendedor = True
                        Else
                            If Not bEnProceso Then
                                bObtenerBD = False
                            End If
                        End If
                    End While
                End If
            End If

            If bFinalizoCorrecto Then
                If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                    FormProcesando.PubSubInformar("Opening database", NombreArchivoSDF)
                Else
                    FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "AbriendoDB"), NombreArchivoSDF)
                End If

                oConexion = New SqlCeConnection("Data Source = " & oApp.RutaTrabajo & "\" & NombreArchivoSDF)

                If blnRecienCreadoVendedor Then
                    oVendedor.RecuperarParametros(True)
                    'Reparto
                    SKUInventario.CargarSKUInventarioReparto()
                    'Cargas
                    SKUInventario.CargarSKUInventarioCargas()
                    oVendedor.ActualizarFecha()

                End If
                
                ''oConexion.Open()
                Return True
            Else
                Return False
            End If

        Catch ex As SqlCeException
            MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        Catch ex As System.Net.WebException
            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico.", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        Catch ex As System.Net.Sockets.SocketException
            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico.", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        Catch ex As System.Web.Services.Protocols.SoapException
            If ex.Code.Name = "SINSDF" Or ex.Code.Name = "LLENARTABLA" Or ex.Code.Name = "Server" OrElse ex.Code.Name = "SQLCON" Then
                MsgBox(" '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Else
                MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrr")
            End If

            Return False
        Catch ex As System.InvalidOperationException
            MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        Catch ex As Exception
            MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        End Try
    End Function

    Public Sub EndObtenerVendedorBD(ByVal byteArchivo As Byte(), ByVal sMensaje As String)
        Try
            Dim NombreArchivoSDF As String = oVendedor.UsuarioId & ".sdf"
            Dim sNombreArchivoZip As String = NombreArchivoSDF.Replace(".sdf", ".zip")
            bEnProceso = False
            bDescompactando = True
            If byteArchivo Is Nothing Or sMensaje <> "" Then
                MsgBox(sMensaje, MsgBoxStyle.Critical)
                Application.DoEvents()
                bDescompactando = False
                bFinalizoCorrecto = False
                Exit Sub
            End If
            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            End If

            Dim fsBD As FileStream
            fsBD = New FileStream(oApp.RutaTrabajo & "\" & sNombreArchivoZip, FileMode.CreateNew, FileAccess.Write)
            fsBD.Write(byteArchivo, 0, byteArchivo.Length)
            fsBD.Close()

            Dim zipC1 As Resco.IO.Zip.ZipArchive
            zipC1 = New Resco.IO.Zip.ZipArchive(oApp.RutaTrabajo & "\" & sNombreArchivoZip, Resco.IO.Zip.ZipArchiveMode.Open, System.IO.FileShare.None)
            zipC1.Extract("\", oApp.RutaTrabajo, Nothing)
            zipC1.Close()

            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            End If
            bDescompactando = False
            bFinalizoCorrecto = True
        Catch ex As System.Net.WebException
            bDescompactando = False
            bFinalizoCorrecto = False
        End Try
    End Sub

    Public Sub EndObtenerAplicacionBD(ByVal byteArchivo As Byte(), ByVal sMensaje As String)
        Try
            'Dim NombreArchivoSDF As String = oVendedor.UsuarioId & ".sdf"
            Dim sNombreArchivoZip As String = NombreArchivoSDF.Replace(".sdf", ".zip")
            bEnProceso = False
            bDescompactando = True

            If byteArchivo Is Nothing Or sMensaje <> "" Then
                MsgBox(sMensaje, MsgBoxStyle.Critical)
                Application.DoEvents()
                bDescompactando = False
                bFinalizoCorrecto = False
                Exit Sub
            End If
            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            Else
                If Not System.IO.Directory.Exists(oApp.RutaTrabajo) Then
                    System.IO.Directory.CreateDirectory(oApp.RutaTrabajo)
                End If
            End If

            Dim fsBD As FileStream
            fsBD = New FileStream(oApp.RutaTrabajo & "\" & sNombreArchivoZip, FileMode.CreateNew, FileAccess.Write)
            fsBD.Write(byteArchivo, 0, byteArchivo.Length)
            fsBD.Close()

            'Descompactar el archivo zip ups ver cuanto se tarda.
            Dim zipArchive As Resco.IO.Zip.ZipArchive

            zipArchive = New Resco.IO.Zip.ZipArchive(oApp.RutaTrabajo & "\" & sNombreArchivoZip, Resco.IO.Zip.ZipArchiveMode.Open, System.IO.FileShare.None)
            zipArchive.Extract("\", oApp.RutaTrabajo, Nothing)
            zipArchive.Close()

            If System.IO.File.Exists(oApp.RutaTrabajo & "\" & sNombreArchivoZip) Then
                System.IO.File.Delete(oApp.RutaTrabajo & "\" & sNombreArchivoZip)
            End If

            bDescompactando = False
            bFinalizoCorrecto = True
        Catch ex As System.Net.WebException
            MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EndObtenerAplicacionBD")
            bDescompactando = False
            bFinalizoCorrecto = False
        Catch ex1 As Exception
            MsgBox(ex1.GetBaseException.GetType.ToString() & " '" & ex1.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EndObtenerAplicacionBD")
        End Try
    End Sub

    Public Function CargarInformacion(ByVal pariGrupo As Integer, Optional ByVal optparsCondicion As String = "*") As Boolean
        Try
            'If (Me.TipoTablas = ServicesCentral.TiposBase.Dia And Me.ObligarCargarInformacion) Then
            'FormProcesando.PubSubInformar("Cargando datos", "De " & oApp.Servidor & " a " & NombreArchivoSDF)
            ' Cambios 08 Mayo 2006
            If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                FormProcesando.PubSubInformar("Downloading data", oApp.Servidor)
            Else
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "RecuperandoDatos"), oApp.Servidor)
            End If
            ' / Cambios 08 Mayo 2006
            If Not LlenarTablas(optparsCondicion, False) Then
                Return False
            End If
            ' La base de datos y el esquema existen, continuar normalmente
            FormProcesando.PubSubInformar()
            'End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Abrir")
            Return False
        End Try
    End Function

    Public Sub Cerrar()
        Try
            If oConexion Is Nothing Then
                Exit Sub
            End If
            If oConexion.State = ConnectionState.Open Then
                ' Cambios 08 Mayo 2006
                FormProcesando.PubSubTitulo(gVista.BuscarMensaje("MsgBoxConexion", "CerrandoConexion"))
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "CerrandoDB"), oConexion.Database)
                ' / Cambios 08 Mayo 2006
                oConexion.Close()
                oConexion.Dispose()
                oConexion = Nothing

            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Cerrar")
        End Try
    End Sub

    Public Function EjecutarComandoSQL(ByVal parsComandoSQL As String) As Integer
        Try
            Dim sqlComando As SqlCeCommand
            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL
            ' LMFM Agregado para liberar la memoria usada

            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim iResultado As Integer = sqlComando.ExecuteNonQuery
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            sqlComando.Dispose()
            Return iResultado
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsComandoSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsComandoSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return 0
    End Function

    Public Function EjecutarComandoSQLParams(ByVal parsComandoSQL As String, ByVal parhtParams As Hashtable) As Integer
        Try
            Dim sqlComando As SqlCeCommand
            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            sqlComando.CommandText = parsComandoSQL
            For Each sParam As String In parhtParams.Keys
                Dim aParam As ArrayList
                Dim tTipo As Integer
                aParam = parhtParams(sParam)
                tTipo = aParam(0)
                sqlComando.Parameters.Add(sParam, tTipo)
                sqlComando.Parameters(sqlComando.Parameters.Count - 1).Value = aParam(1)
            Next
            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim iResultado As Integer = sqlComando.ExecuteNonQuery
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            sqlComando.Dispose()
            Return iResultado
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsComandoSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsComandoSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
    End Function

    Public Function EjecutarCmdScalarIntSQL(ByVal parsComandoSQL As String) As Integer
        Try
            Dim sqlComando As SqlCeCommand
            Dim intResultado As Integer = 0
            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            sqlComando.CommandText = parsComandoSQL

            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim oRes As Object = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If

            If Not IsDBNull(oRes) Then
                intResultado = oRes
            Else
                intResultado = -99999
            End If

            ' LMFM Agregado para liberar la memoria usada
            sqlComando.Dispose()
            Return intResultado

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return 0
    End Function

    Public Function EjecutarCmdScalardblSQL(ByVal parsComandoSQL As String) As Double
        Try
            Dim sqlComando As SqlCeCommand
            Dim dblResultado As Double = 0
            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL
            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim oRes As Object = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            If Not IsDBNull(oRes) Then
                dblResultado = oRes
            End If

            ' LMFM Agregado para liberar la memoria usada
            sqlComando.Dispose()
            Return dblResultado

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return 0
    End Function
    Public Function EjecutarCmdScalardblSQLSinTransaccion(ByVal parsComandoSQL As String) As Double
        Try
            Dim sqlComando As SqlCeCommand
            Dim dblResultado As Double = 0
            sqlComando = oConexion.CreateCommand()
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL
            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim oRes As Object = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            If Not IsDBNull(oRes) Then
                dblResultado = oRes
            End If

            ' LMFM Agregado para liberar la memoria usada
            sqlComando.Dispose()
            Return dblResultado

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return 0
    End Function

    Public Function EjecutarCmdScalardblSQL(ByVal parsComandoSQL As String, ByRef pardResultado As Double) As Boolean
        Try
            Dim sqlComando As SqlCeCommand
            pardResultado = 0
            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL
            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            Dim oRes As Object = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            If ((Not IsDBNull(oRes)) And (Not IsNothing(oRes))) Then
                pardResultado = oRes
            Else
                sqlComando.Dispose()
                Return False
            End If

            sqlComando.Dispose()
            Return True

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return False
    End Function

    Public Function EjecutarCmdScalarStrSQL(ByVal parsComandoSQL As String) As String
        Try
            Dim sqlComando As SqlCeCommand
            Dim strResultado As String

            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL

            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            strResultado = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            ' LMFM Agregado para liberar la memoria usada
            sqlComando.Dispose()

            Return strResultado

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return ""

    End Function

    Public Function EjecutarCmdScalarObjSQL(ByVal parsComandoSQL As String) As Object
        Try
            Dim sqlComando As SqlCeCommand
            Dim objResultado As Object

            sqlComando = oConexion.CreateCommand()
            If Not IsNothing(Me.Transaccion) Then
                sqlComando.Transaction = Me.Transaccion
            End If
            'sqlComando.Connection = oConexion
            sqlComando.CommandText = parsComandoSQL

            If oConexion.State = ConnectionState.Closed Then
                oConexion.Open()
            End If
            objResultado = sqlComando.ExecuteScalar()
            If IsNothing(Me.Transaccion) Then
                oConexion.Close()
            End If
            ' LMFM Agregado para liberar la memoria usada
            sqlComando.Dispose()

            Return objResultado

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "EjecutarComandoSQL")
        End Try
        Return ""

    End Function

    Public Function RealizarConsultaSQL(ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String) As DataTable
        Dim DataSetRetorno As New DataSet
        Try
            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            'Dim handler As SqlCeFlushFailureEventHandler

            If Not IsNothing(Me.Transaccion) Then
                DataAdapterBase.SelectCommand.Transaction = Me.Transaccion
                DataAdapterBase.SelectCommand.CommandText = parsConsultaSQL
            End If
            DataAdapterBase.Fill(DataSetRetorno, parsNombreTabla)
            DataAdapterBase.SelectCommand.Dispose()
            DataAdapterBase.Dispose()

            Dim dtRes As DataTable = DataSetRetorno.Tables(0)
            DataSetRetorno.Tables.Clear()
            DataSetRetorno.Dispose()
            DataAdapterBase = Nothing
            DataSetRetorno = Nothing
            Return dtRes
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return Nothing
    End Function
    Public Function RealizarConsultaSQLSinTransaction(ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String) As DataTable
        Dim DataSetRetorno As New DataSet
        Try
            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            'Dim handler As SqlCeFlushFailureEventHandler



            DataAdapterBase.Fill(DataSetRetorno, parsNombreTabla)
            DataAdapterBase.SelectCommand.Dispose()
            DataAdapterBase.Dispose()

            Dim dtRes As DataTable = DataSetRetorno.Tables(0)
            DataSetRetorno.Tables.Clear()
            DataSetRetorno.Dispose()
            DataAdapterBase = Nothing
            DataSetRetorno = Nothing
            Return dtRes
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return Nothing
    End Function

    Public Function RealizarReaderSQL(ByVal parsConsultaSQL As String) As List(Of Object)
        Dim lista As New List(Of Object)()
        Try
            Using cnn As New SqlCeConnection(oConexion.ConnectionString)
                cnn.Open()
                Dim cmd As New SqlCeCommand
                cmd.Connection = cnn
                cmd.CommandText = parsConsultaSQL
                Using dr As SqlCeDataReader = cmd.ExecuteReader()
                    If (dr.Read()) Then
                        Dim aInt As Integer = dr.FieldCount
                        For i As Integer = 0 To aInt - 1
                            lista.Add(dr.GetValue(i))
                        Next
                    End If
                End Using
            End Using
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return lista
    End Function

    Public Function RealizarReaderSQLconCampos(ByVal parsConsultaSQL As String) As Dictionary(Of String, Object)
        Dim lista As New Dictionary(Of String, Object)()
        Try
            Dim bCerrar As Boolean = False
            Using cmd As New SqlCeCommand
                cmd.Connection = oConexion
                If Not IsNothing(Me.Transaccion) Then
                    cmd.Transaction = Me.Transaccion
                End If
                If oConexion.State <> ConnectionState.Open Then
                    oConexion.Open()
                    bCerrar = True
                End If
                cmd.CommandText = parsConsultaSQL
                Using dr As SqlCeDataReader = cmd.ExecuteReader()
                    If (dr.Read()) Then
                        Dim aInt As Integer = dr.FieldCount
                        For i As Integer = 0 To aInt - 1
                            lista.Add(dr.GetName(i), dr.GetValue(i))
                        Next
                    End If
                End Using
            End Using
            If bCerrar Then
                oConexion.Close()
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return lista
    End Function

    Public Function RealizarScalarSQL(ByVal parsConsultaSQL As String) As Object
        Dim resul As Object = Nothing
        Try

            Using cnn As New SqlCeConnection(oConexion.ConnectionString)
                cnn.Open()
                Dim cmd As New SqlCeCommand
                cmd.Connection = cnn
                cmd.CommandText = parsConsultaSQL
                resul = cmd.ExecuteScalar()
            End Using
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        If (Not resul Is Nothing) And (resul Is DBNull.Value) Then
            resul = Nothing
        End If
        Return resul
    End Function


    Public Function RealizarConsultaSQLParam(ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String) As DataTable
        Dim DataSetRetorno As New DataSet
        Try
            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            If Not IsNothing(Me.Transaccion) Then
                DataAdapterBase.SelectCommand.Transaction = Me.Transaccion
            End If

            DataAdapterBase.SelectCommand.Parameters.Add(New SqlCeParameter("@FechaIni", 4, 0))
            DataAdapterBase.SelectCommand.Parameters.Add(New SqlCeParameter("@FechaFin", 4, 0))
            DataAdapterBase.SelectCommand.Parameters(0).Value = UltimaHora(Now)
            DataAdapterBase.SelectCommand.Parameters(1).Value = PrimeraHora(Now)

            DataAdapterBase.Fill(DataSetRetorno, parsNombreTabla)
            ' LMFM Agregado para liberar la memoria usada
            DataAdapterBase.SelectCommand.Dispose()
            DataAdapterBase.Dispose()

            Dim dtRes As DataTable = DataSetRetorno.Tables(0)
            DataSetRetorno.Tables.Clear()
            DataSetRetorno.Dispose()
            DataAdapterBase = Nothing
            DataSetRetorno = Nothing
            Return dtRes
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return Nothing
    End Function

    Public Function RealizarConsultaSQL(ByRef refparDataSetResultado As DataSet, ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String) As Boolean
        Try
            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            If Not IsNothing(Me.Transaccion) Then
                DataAdapterBase.SelectCommand.Transaction = Me.Transaccion
            End If
            DataAdapterBase.Fill(refparDataSetResultado, parsNombreTabla)
            ' LMFM Agregado para liberar la memoria usada
            DataAdapterBase.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return False
    End Function

    Public Function RealizarConsultaSQLIncluyeLlaves(ByRef refparDataSetResultado As DataSet, ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String) As Integer
        Dim iRegistros As Integer = 0
        Try
            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            If Not IsNothing(Me.Transaccion) Then
                DataAdapterBase.SelectCommand.Transaction = Me.Transaccion
            End If
            DataAdapterBase.MissingSchemaAction = MissingSchemaAction.AddWithKey
            iRegistros = DataAdapterBase.Fill(refparDataSetResultado, parsNombreTabla)
            ' LMFM Agregado para liberar la memoria usada
            DataAdapterBase.Dispose()
            Return iRegistros
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return iRegistros
    End Function

    Private Function PedirDatosConexion() As Boolean
        Dim sUrl As String = ""
        Try
            'FormProcesando.PubSubInformar("Preparando conexión", "Creando pantalla de conexión")
            ' Cambios 08 Mayo 2006
            If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                FormProcesando.PubSubInformar("Preparing connection", "Creating connection screen")
            Else
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "PreparandoConexion"), gVista.BuscarMensaje("MsgBoxConexion", "CreandoPantalla"))
            End If
            ' / Cambios 08 Mayo 2006
            Dim FormVerificacion As New FormVerificacion
            Dim sRespuesta As String = ""
            Dim wsServicioGeneral As New ServicesCentral.ServiceMobileClient

            ' Presentar la forma y solicitar los datos para conectarse al servidor

            While FormVerificacion.ShowDialog() = DialogResult.Yes
                ' Usar un dataset para recibir la información desde el servicio web
                'FormProcesando.PubSubInformar("Conectándose al servidor", oApp.Servidor)
                ' Cambios 08 Mayo 2006
                If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                    FormProcesando.PubSubInformar("Connecting to server", oApp.Servidor)
                Else
                    FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "ConectandoServidor"), oApp.Servidor)
                End If
                ' / Cambios 08 Mayo 2006
                Try
                    wsServicioGeneral.Url = "http://" & oApp.Servidor & "/" & oApp.URL & "/" & PubcServiceMobileClient
                    'wsServicioGeneral.Timeout = 15000

                    wsServicioGeneral.Timeout = (oApp.TimeOut * 60) * 1000
                    sUrl = wsServicioGeneral.Url

                    Dim bDisponible As Boolean = True
                    If (Not oApp.ProbarServicioR(3)) Then
                        bDisponible = False
                        If oApp.UsarWireless Then
                            bDisponible = oApp.RevisarServidor()
                        End If
                        If Not bDisponible Then
                            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "PedirDatosConexion")
                            FormVerificacion.PanelConexion.Visible = True
                            Continue While
                        End If
                    End If

                    If Not wsServicioGeneral.WSVendedorObtenerAcceso(oApp.Usuario.Clave, oApp.Contrasena, oApp.ClaveTerminal, sRespuesta) Then
                        'MsgBox("Error: " & sRespuesta, MsgBoxStyle.Exclamation Or MsgBoxStyle.SystemModal)
                        ' Cambios 08 Mayo 2006
                        MsgBox(sRespuesta, MsgBoxStyle.Exclamation Or MsgBoxStyle.SystemModal)
                        ' / Cambios 08 Mayo 2006
                        FormVerificacion.PanelConexion.Visible = True
                    Else
                        ' Llamar el web service para recuperar el dataset con la información de la base de datos
                        If RecuperarEstructura() Then
                            ' Se recuperó la estructura desde el servidor 
                            oApp.GuardarConfiguracion()
                            Return True
                        End If
                    End If
                Catch ExcA As Exception
                    If MsgBox(ExcA.GetBaseException.GetType.ToString() & " '" & ExcA.GetBaseException.Message & "'" & ": " & sUrl, MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel Or MsgBoxStyle.SystemModal) <> MsgBoxResult.Retry Then
                        Exit While
                        'Exit Function
                    End If
                    FormVerificacion.PanelConexion.Visible = True
                End Try
            End While
            With FormVerificacion
                .Dispose()
                .DetailViewDatosConexion = Nothing
                .PictureBoxLogoERM.Dispose()
                .PictureBoxLogoERM = Nothing
                FormVerificacion = Nothing
            End With
        Catch ExcB As Exception
            MsgBox(ExcB.GetBaseException.GetType.ToString() & " '" & ExcB.GetBaseException.Message & "': " & sUrl, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "PedirDatosConexion")
        End Try
        ' No desea conectarse con ServicesCentral, continuar
        Return False
    End Function

    Private Function RecuperarEstructura() As Boolean
        Try
            ' Obtener un dataset de un servicio web y guardarlo en archivo xml
            Dim DataSetEsquema As New DataSet
            ' Cambios 08 Mayo 2006
            'Dim FormAvance As New ClassProceso

            FormProcesando.PubSubTitulo("Installing base system")
            FormProcesando.PubSubInformar("Retrieving information", "Database structure")
            ' / Cambios 08 Mayo 2006

            [Global].IniciarWS()
            ' Obtener el dataset con las tablas que contienen la estructura de la base de datos            
            DataSetEsquema = oServicioWeb.WSObtenerEstructura()
            Dim archive As Resco.IO.Zip.ZipArchive = Resco.IO.Zip.ZipArchive.Create(oApp.RutaTrabajo & "\" & PubcArchivoEsquema.Replace(".xlm", ".zip"), False)

            ' open file for add/replace
            Dim stream As Resco.IO.Zip.ZipStream = archive.OpenFile(PubcArchivoEsquema, Resco.IO.Zip.ZipFileMode.AddReplace)
            ' create xml text writer from stream, we must there also specifiy text encoding
            Dim xml As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(stream, System.Text.Encoding.Unicode)
            ' get dataset from data grid, DataSource is DataTable which has reference to parent DataSet
            Dim dataset As System.Data.DataSet = DataSetEsquema
            ' write xml with schema
            dataset.WriteXml(xml, XmlWriteMode.WriteSchema)

            ' close stream
            stream.Close()
            ' close xml
            xml.Close()
            ' close archive
            archive.Close()
            Return True
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RecuperarEstructura")
        End Try
        Return False
    End Function

    Private Function CrearArchivoSDF() As Boolean
        Try
            ' Verificar que exista la base de datos
            If Not Directory.Exists(oApp.RutaTrabajo) Then
                Directory.CreateDirectory(oApp.RutaTrabajo)
            End If
            If File.Exists(oApp.RutaTrabajo & "\" & NombreArchivoSDF) Then
                Return True
            End If
            ' No existe, crear la base de datos, conectarse a SC para obtener la estructura de la BDD
            Dim SqlCeEngineSQL As New SqlCeEngine("Data Source = " & oApp.RutaTrabajo & "\" & NombreArchivoSDF)
            SqlCeEngineSQL.CreateDatabase()
            SqlCeEngineSQL.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "CrearArchivoSDF")
        End Try
        Return False
    End Function
    Private Function LoadDataSet() As DataSet

        ' open archive
        Dim archive As Resco.IO.Zip.ZipArchive = Resco.IO.Zip.ZipArchive.Open(oApp.RutaTrabajo & "\" & PubcArchivoEsquema.Replace(".xlm", ".zip"))

        ' open file for extract
        Dim stream As Resco.IO.Zip.ZipStream = archive.OpenFile(PubcArchivoEsquema, Resco.IO.Zip.ZipFileMode.Extract)
        ' create xml text reader from stream
        Dim xml As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(stream)
        ' create new dataset
        Dim dataset As New System.Data.DataSet '= New DataSet("customers")
        ' read xml to dateset
        dataset.ReadXml(xml)
        ' bind datatable to data grid

        ' close stream
        stream.Close()
        ' close xml
        xml.Close()
        ' close archive
        archive.Close()

        Return dataset
    End Function


    Private Sub ObtenerListaLlaves(ByRef refparoConexion As SqlCeConnection, ByVal parsRelacionId As String, ByRef refparsLlaveForanea As String, ByRef refparsLlavePrimaria As String)
        Dim sConsultaSQL As New System.Text.StringBuilder
        sConsultaSQL.Append("SELECT CampoNombrePrimario, CampoNombreForaneo, RelacionCampo.RelacionId FROM RelacionCampo ")
        sConsultaSQL.Append("WHERE RelacionCampo.RelacionId='" & parsRelacionId & "' ")
        sConsultaSQL.Append("ORDER BY RelacionCampo.Orden")
        Dim DataAdapterBase As SqlCeDataAdapter
        Dim DataTableActual As New DataTable
        DataAdapterBase = New SqlCeDataAdapter(sConsultaSQL.ToString, refparoConexion)
        sConsultaSQL = Nothing
        DataAdapterBase.Fill(DataTableActual)
        Dim refDataRow As DataRow
        refparsLlaveForanea = ""
        refparsLlavePrimaria = ""
        For Each refDataRow In DataTableActual.Rows
            With refDataRow
                refparsLlaveForanea &= .Item("CampoNombreForaneo") & ","
                refparsLlavePrimaria &= .Item("CampoNombrePrimario") & ","
            End With
        Next
        ' Quitar la ultima coma
        If refparsLlaveForanea <> "" Then
            refparsLlaveForanea = Mid(refparsLlaveForanea, 1, Len(refparsLlaveForanea) - 1)
        End If
        If refparsLlavePrimaria <> "" Then
            refparsLlavePrimaria = Mid(refparsLlavePrimaria, 1, Len(refparsLlavePrimaria) - 1)
        End If
    End Sub

    Private Function VerificarDatosVendedor() As Boolean
        Dim conConexion As SqlCeConnection
        Try
            'FormProcesando.PubSubInformar("Revisando base de datos", NombreArchivoSDF)
            ' Cambios 08 Mayo 2006
            If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                FormProcesando.PubSubInformar("Checking database", NombreArchivoSDF)
            Else
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "RevisandoBaseDeDatos"), NombreArchivoSDF)
            End If
            ' / Cambios 08 Mayo 2006
            FormProcesando.FormProceso.ProgressBarAvance.Visible = False
            ' Abrir una conexión a la base de datos
            conConexion = New SqlCeConnection("Data Source = " & oApp.RutaTrabajo & "\" & NombreArchivoSDF)
            Dim DataTableVendedor As DataTable
            conConexion.Open()
            DataTableVendedor = Me.RealizarConsultaSQL("SELECT USUId FROM Vendedores WHERE USUId='" & oApp.Usuario.Clave & "'", "Vendedores")
            If DataTableVendedor.Rows.Count > 0 Then
                DataTableVendedor.Dispose()
                conConexion.Close()
                conConexion.Dispose()
                Return True
            End If
            DataTableVendedor.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "VerificarDatosVendedor")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "VerificarDatosVendedor")
        End Try
        conConexion.Close()
        conConexion.Dispose()
        Return False
    End Function

    Public Function RegresaArchivoUltimaActualizacion() As String
        Dim stream As New System.IO.FileStream(oApp.RutaTrabajo & "\" & NombreArchivoSDF.Replace(".sdf", ".xml"), IO.FileMode.Open)
        Dim XmlTextReaderTablas As New System.Xml.XmlTextReader(oApp.RutaTrabajo & "\" & NombreArchivoSDF.Replace(".sdf", ".xml"), stream)
        ' Escribir en el archivo XML
        XmlTextReaderTablas.WhitespaceHandling = System.Xml.WhitespaceHandling.None
        '' Cerrar el flujo XML
        XmlTextReaderTablas.Read()
        Dim s As String = "<ds>" & XmlTextReaderTablas.ReadInnerXml & "</ds>"
        XmlTextReaderTablas.Close()
        stream.Close()
        Return s

    End Function

    Private Function RegresaTipoDatoSQL(ByVal parTipo As System.Type) As Integer
        Select Case parTipo.Name
            Case "String"
                Return 12
            Case "Boolean"
                Return 2
            Case "DateTime"
                Return 4
            Case "Int32"
                Return 8
            Case "Int16"
                Return 16
            Case "Single"
                Return 13
            Case "Double"
                Return 6
            Case Else
                Return 0
        End Select
    End Function
#Region "Ahora"
    Private Sub LlenarTabla(ByRef refparDataTable As DataTable, ByVal refConnectionSQL As SqlCeConnection, ByVal pariGrupo As Integer, ByVal parbBorrarInactivos As Boolean, ByVal parbRecargas As Boolean)
        Dim dt As New DataTable
        Dim da As New SqlCeDataAdapter("Select * from " & refparDataTable.TableName, refConnectionSQL)
        Try
            If (parbRecargas = False And pariGrupo = 2) Then
                Dim cmdComando As SqlCeCommand = refConnectionSQL.CreateCommand()
                cmdComando.Connection = refConnectionSQL
                cmdComando.CommandText = "Delete from " & refparDataTable.TableName
                cmdComando.ExecuteNonQuery()
            End If
            If refparDataTable.Rows.Count <= 0 Then Exit Sub
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            da.Fill(dt)

            Dim sCampos As String = String.Empty
            Dim sParametros As String = String.Empty
            Dim sAsignaciones As String = String.Empty
            Dim sComparaLlavesPrimarias As String = String.Empty

            Dim aParametrosInsert(refparDataTable.Columns.Count - 1) As SqlCeParameter
            Dim aParametrosUpdate(refparDataTable.Columns.Count - 1) As SqlCeParameter
            Dim aParameterLlavesUpdate(dt.PrimaryKey.Length - 1) As SqlCeParameter
            Dim aParameterLlavesDelete(dt.PrimaryKey.Length - 1) As SqlCeParameter

            Dim k As System.Type
            Dim sLlavePrimaria As String
            For i As Integer = 0 To dt.PrimaryKey.Length - 1
                sLlavePrimaria = dt.PrimaryKey(i).ColumnName
                sComparaLlavesPrimarias &= sLlavePrimaria & "=" & "@Original_" & sLlavePrimaria
                If i < dt.PrimaryKey.Length - 1 Then
                    sComparaLlavesPrimarias &= " AND "
                End If
                k = refparDataTable.Columns(i).DataType
                aParameterLlavesUpdate(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
                aParameterLlavesDelete(i) = New SqlCeParameter("@Original_" & sLlavePrimaria, RegresaTipoDatoSQL(k), 0, ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), sLlavePrimaria, DataRowVersion.Original, Nothing)
            Next

            Dim sNombreCampo As String
            For j As Integer = 0 To refparDataTable.Columns.Count - 1
                sNombreCampo = refparDataTable.Columns(j).ColumnName
                sCampos &= sNombreCampo
                sParametros &= "@" & sNombreCampo
                sAsignaciones &= sNombreCampo & "=" & "@" & sNombreCampo
                k = refparDataTable.Columns(j).DataType
                aParametrosInsert(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
                aParametrosUpdate(j) = New SqlCeParameter("@" & sNombreCampo, RegresaTipoDatoSQL(k), 0, sNombreCampo)
                If j < refparDataTable.Columns.Count - 1 Then
                    sCampos &= ","
                    sParametros &= ","
                    sAsignaciones &= ","
                End If
            Next

            Dim insCmd As SqlCeCommand = New SqlCeCommand("insert into " & refparDataTable.TableName & "(" & sCampos & ")  values(" & sParametros & ")", refConnectionSQL)
            insCmd.Parameters.AddRange(aParametrosInsert)
            da.InsertCommand = insCmd
            Dim UpdCmd As SqlCeCommand = New SqlCeCommand("UPDATE " & refparDataTable.TableName & " SET " & sAsignaciones & " WHERE (" & sComparaLlavesPrimarias & ")", refConnectionSQL)
            UpdCmd.Parameters.AddRange(aParametrosUpdate)
            UpdCmd.Parameters.AddRange(aParameterLlavesUpdate)
            If parbRecargas Then
                UpdCmd.CommandText = "select getdate()"
                UpdCmd.Parameters.Clear()
            End If
            da.UpdateCommand = UpdCmd

            dt.Merge(refparDataTable)
            da.Update(dt)

            If parbBorrarInactivos Then
                Dim sFiltroBorrar As String = String.Empty
                If dt.Columns.Contains("TipoEstado") Then
                    sFiltroBorrar &= " TipoEstado=0 "
                ElseIf dt.Columns.Contains("Estado") Then
                    sFiltroBorrar &= " Estado=0 "
                ElseIf dt.Columns.Contains("TipoFase") And dt.TableName <> "TransProd" Then
                    sFiltroBorrar &= " TipoFase<>1 "
                End If
                If dt.Columns.Contains("Baja") Then
                    If sFiltroBorrar <> String.Empty Then
                        sFiltroBorrar &= " OR "
                    End If
                    sFiltroBorrar &= " Baja=1 "
                End If
                If sFiltroBorrar <> String.Empty Then
                    Dim BorrarCmd As New SqlCeCommand("Delete FROM " & refparDataTable.TableName & " WHERE " & sFiltroBorrar, refConnectionSQL)
                    BorrarCmd.ExecuteNonQuery()
                Else

                End If
            End If

            insCmd.Dispose()
            UpdCmd.Dispose()
            'DelCmd.Dispose()
            dt.Dispose()
            'If Not IsNothing(dtEliminados) Then dtEliminados.Dispose()
            da.Dispose()


        Catch ex As SqlCeException
            'MsgBox(ex.Message)
        Catch ex1 As Exception
            'MsgBox(ex1.Message)
        End Try
    End Sub

    Private Sub EndLlenarTablasRecargas(ByVal parsCondicionTablas As String)
        Try
            bFinalizoCorrecto = False
            dsGeneral = New DataSet
            dsGeneral = oServicioWeb.WSVendedorObtenerRecargas(RegresaArchivoUltimaActualizacion, oVendedor.UsuarioId, parsCondicionTablas)
            blnRecarga = True
            blnActualizacionCatalogos = True
            bEnProceso = False
            bFinalizoCorrecto = True
        Catch ex As Exception
            bFinalizoCorrecto = False
            Throw ex
        End Try
    End Sub

    Private Sub EndLlenarTablasActualizacion(ByVal parsCondicionTablas As String)
        Try
            bFinalizoCorrecto = False
            dsGeneral = New DataSet
            dsGeneral = oServicioWeb.WSAplicacionObtenerActualizacion(RegresaArchivoUltimaActualizacion, parsCondicionTablas)
            blnActualizacionCatalogos = True
            bEnProceso = False
            bFinalizoCorrecto = True
        Catch ex As Exception
            bFinalizoCorrecto = False
            Throw ex
        End Try
    End Sub
    Public Function LlenarTablas(ByVal parsCondicionTablas As String, ByVal parbRecienCreado As Boolean) As Boolean
        Dim conConexion As SqlCeConnection
        blnActualizacionCatalogos = False
        blnRecarga = False
        'FormProcesando.PubSubInformar("Abriendo base de datos", NombreArchivoSDF)
        ' Cambios 08 Mayo 2006
        If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
            FormProcesando.PubSubInformar("Opening database", NombreArchivoSDF)
        Else
            FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "AbriendoDB"), NombreArchivoSDF)
        End If
        ' / Cambios 08 Mayo 2006
        FormProcesando.FormProceso.ProgressBarAvance.Visible = False
        ' Abrir una conexión a la base de datos
        conConexion = New SqlCeConnection("Data Source = " & oApp.RutaTrabajo & "\" & NombreArchivoSDF)
        '       Dim DataSetLocal As New DataSet
        Dim refDataTable As DataTable
        conConexion.Open()
        ' Actualizar la referencia del Web Service
        [Global].IniciarWS()
        timeout = oServicioWeb.Timeout
        ' Recuperar los datos
        'FormProcesando.PubSubInformar("Recibiendo datos", "Servidor en " & oApp.Servidor)
        ' Cambios 08 Mayo 2006
        Dim bReintentar As Boolean = True
        Dim sMensajeError As String = ""
        While bReintentar
            If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                FormProcesando.PubSubInformar("Receiving data", oApp.Servidor)
                sMensajeError = "[P0102] No se puede establecer conexión con el Servidor ¿Desea intentarlo nuevamente? "
            Else
                FormProcesando.PubSubInformar(gVista.BuscarMensaje("MsgBoxConexion", "RecibiendoDatos"), oApp.Servidor)
                sMensajeError = gVista.BuscarMensaje("MsgBoxConexion", "P0102")
            End If
            'oServicioWeb.Timeout = timeout
            Try
                Select Case TipoTablas
                    Case ServicesCentral.TiposBase.Vendedor
                        'Recargas
                        bEnProceso = True
                        EndLlenarTablasRecargas(parsCondicionTablas)
                    Case ServicesCentral.TiposBase.Aplicacion
                        bEnProceso = True
                        EndLlenarTablasActualizacion(parsCondicionTablas)
                End Select
                'oServicioWeb.TerminarSession()
                bReintentar = False
            Catch ex As System.Net.WebException
                If MsgBox(sMensajeError, MsgBoxStyle.YesNo, "LlenarTablas") = MsgBoxResult.No Then
                    bFinalizoCorrecto = False
                    conConexion.Close()
                    conConexion.Dispose()
                    bReintentar = False
                End If
            Catch ex As System.InvalidOperationException
                MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "I0167"), MsgBoxStyle.Critical, "LlenarTablas")
            Catch ex As System.Web.Services.Protocols.SoapException
                If ex.Code.Name = "SQLCON" Then
                    MsgBox("ERROR SQL'" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical, "LlenarTablas")
                Else
                    MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "I0167"), MsgBoxStyle.Critical, "LlenarTablas")
                End If
                conConexion.Close()
                conConexion.Dispose()
                Return False
            Catch ex As Exception
                FormProcesando.PubSubInformar()
                MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "LlenarTablas")
                conConexion.Close()
                conConexion.Dispose()
                Return False
            End Try
        End While

        ' Quitar las relaciones solo si la base de datos no ha sido recien creada
        'If Not parbRecienCreado Then
        '    ' Quitar las relaciones antes de actualizar las tablas
        '    If Not EstablecerRelaciones(False, conConexion) Then
        '        conConexion.Close()
        '        conConexion.Dispose()
        '        Return False
        '    End If
        'End If
        If bFinalizoCorrecto Then
            Dim i As Integer = 1
            Dim sAvance As String
            Try
                FormProcesando.FormProceso.ProgressBarAvance.Maximum = dsGeneral.Tables.Count
                FormProcesando.PubSubInformar(1)
                Dim ldtTransProdDetalle As New DataTable
                Dim ldtCliCap As New DataTable
                Dim ldtCadPro As New DataTable

                Dim dsUltimosCambios As New DataSet
                dsUltimosCambios.ReadXml(oApp.RutaTrabajo & "\" & NombreArchivoSDF.Replace(".sdf", ".xml"))
                dsUltimosCambios.Tables("T").PrimaryKey = New DataColumn() {dsUltimosCambios.Tables("T").Columns("I")}
                Dim dsTablas As DataTable
                If TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                    dsTablas = RealizarConsultaSQL("Select distinct Nombre,Grupo from Tabla where TipoBase =" & Me.TipoTablas, "Tablas")
                Else
                    dsTablas = oDBApp.RealizarConsultaSQL("Select distinct Nombre,Grupo from Tabla where TipoBase =" & Me.TipoTablas, "Tablas")
                End If

                dsTablas.PrimaryKey = New DataColumn() {dsTablas.Columns("Nombre")}
                For Each refDataTable In dsGeneral.Tables
                    'TODO: Revisar si hay otra forma de LlenarTabla
                    If Me.TipoTablas = ServicesCentral.TiposBase.Aplicacion Then
                        sAvance = "Filling table " & refDataTable.TableName
                    Else
                        sAvance = gVista.BuscarMensaje("MsgBoxConexion", "LlenandoTabla") & " " & refDataTable.TableName
                    End If
                    FormProcesando.PubSubEstado(sAvance)
                    If Not (blnActualizacionCatalogos And refDataTable.Rows.Count <= 0) Then
                        Dim drGrupo As DataRow = dsTablas.Rows.Find(refDataTable.TableName)
                        LlenarTabla(refDataTable, conConexion, drGrupo("Grupo"), blnActualizacionCatalogos, blnRecarga)
                        Dim dr As DataRow = dsUltimosCambios.Tables("T").Rows.Find(refDataTable.TableName)
                        dr("F") = Now.ToString("s")
                    End If
                    FormProcesando.PubSubInformar(i)
                    i += 1
                    refDataTable.Dispose()
                Next
                dsTablas.Dispose()
                Dim XmlTextWriterDicc As New System.Xml.XmlTextWriter(oApp.RutaTrabajo & "\" & NombreArchivoSDF.Replace(".sdf", ".xml"), System.Text.Encoding.Unicode)
                ' Escribir en el archivo XML
                dsUltimosCambios.WriteXml(XmlTextWriterDicc, XmlWriteMode.IgnoreSchema)
                ' Cerrar el flujo XML
                XmlTextWriterDicc.Close()
                If blnRecarga Then
                    Me.oConexion = conConexion
                    SKUInventario.CargarSKUInventarioCargas()
                End If
                dsGeneral.Dispose()
               
            Catch ex As System.InvalidOperationException
                MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "I0167"), MsgBoxStyle.Critical, "LlenarTablas")
            Catch ex As Exception
                MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "LlenarTablas")
            End Try
            conConexion.Close()
            conConexion.Dispose()
            FormProcesando.FormProceso.ProgressBarAvance.Visible = False
            Return True
        Else
            Return False
        End If
    End Function
#End Region


End Class

Public Class Usuario
    Inherits ServicesCentral.Usuario
    Implements ERM.Aplicacion.Usuario

    Private m_Perfil As String

    Public ReadOnly Property Perfil() As String
        Get
            Return m_Perfil
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsId As String, ByVal parsClave As String, ByVal parsNombre As String)
        UsuarioId = parsId
        Clave = parsClave
        Nombre = parsNombre
    End Sub

    Public Function Pedir() As Boolean Implements ERM.Aplicacion.Usuario.Pedir

        Dim bSalir As Boolean
        Dim bDialogResult As DialogResult

        While Not bSalir
            Dim oFormUsuario As New FormUsuario
            bDialogResult = oFormUsuario.ShowDialog()

            If bDialogResult = DialogResult.Yes Then
                If Recuperar(oFormUsuario.Clave, oFormUsuario.Contrasena) Then
                    'oFormUsuario.LabelVersion.Text = Nombre
                    'oFormUsuario.LabelVersion.Refresh()
                    oApp.Contrasena = oFormUsuario.Contrasena
                    FormProcesando.PubSubEstado(oFormUsuario.refaVista.BuscarMensaje("ProcesandoRegistro", "Entrando"))
                    With oFormUsuario
                        .Dispose()
                        oFormUsuario = Nothing
                    End With
                    Return True
                Else
                    MsgBox(oFormUsuario.refaVista.BuscarMensaje("MsgBox", "NoValido"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal)
                    FormProcesando.PubSubInformar()
                End If
            Else
                Dim sPerfil As String = String.Empty
                sPerfil = VerificarPerfil(oFormUsuario.Clave, oFormUsuario.Contrasena)
                If Not IsNothing(sPerfil) Then
                    '--Verificar si tiene permisos para salir
                    If (Not sPerfil.ToUpper = "ADMIN") And (_ReIniciarRoute = False) Then
                        MsgBox("No se permite salir solo un administrador puede hacerlo", MsgBoxStyle.Critical)
                        With oFormUsuario
                            .Dispose()
                            oFormUsuario = Nothing
                        End With
                        Continue While
                    Else
                        With oFormUsuario
                            .Dispose()
                            oFormUsuario = Nothing
                        End With
                        Return False
                    End If
                Else
                    MsgBox(oFormUsuario.refaVista.BuscarMensaje("MsgBox", "NoValido"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal)
                    FormProcesando.PubSubInformar()
                End If
            End If
        End While

        Return False
    End Function

    Public Function Recuperar(ByVal parsUsuario As String, ByVal parsContrasena As String) As Boolean Implements ERM.Aplicacion.Usuario.Recuperar
        Try
            Dim DataTableDatos As DataTable
            Dim sContrasena As String = oApp.SimpleCrypt(parsContrasena)
            ' Ejecutar la consulta para verificar el usuario y contraseña
            DataTableDatos = oDBApp.RealizarConsultaSQL("SELECT * FROM Usuario WHERE Clave='" & parsUsuario & "' AND ClaveAcceso='" & sContrasena & "'", "Usuario")
            If DataTableDatos.Rows.Count = 1 Then
                With DataTableDatos.Rows(0)
                    Me.Nombre = .Item("Nombre")
                    Me.ClaveEmpleado = .Item("PERClave")
                    Me.ClaveAcceso = .Item("ClaveAcceso")
                    Me.UsuarioId = .Item("USUId")
                    Me.Clave = .Item("Clave")
                    Me.Nombre = .Item("Nombre")
                    Me.m_Perfil = .Item("PERClave")
                End With
                DataTableDatos.Dispose()
                Return True
            End If
            DataTableDatos.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Verificar")
        End Try
        Return False
    End Function

    Public Function VerificarPerfil(ByVal parsUsuario As String, ByVal parsContrasena As String) As String
        Try
            Dim sContrasena As String = oApp.SimpleCrypt(parsContrasena)
            Dim sPerfil As String = oDBApp.EjecutarCmdScalarStrSQL("SELECT PERClave FROM Usuario WHERE Clave='" & parsUsuario & "' AND ClaveAcceso='" & sContrasena & "'")
            Return sPerfil
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Verificar")
        End Try
        Return Nothing
    End Function

End Class
Public Class CliDom
    Implements IDisposable


    Protected sRazonSocial As String
    Protected sIdFiscal As String
    Protected sCalle As String
    Protected sExterior As String
    Protected sInterior As String
    Protected sColonia As String
    Protected sEntidad As String
    Protected sMunicipio As String
    Protected sPais As String
    Protected sCodigoPostal As String
    Protected sReferencia As String
    'Protected nCoordenadaX As Decimal
    'Protected nCoordenadaY As Decimal

    Public Property IdFiscal() As String
        Get
            Return sIdFiscal
        End Get
        Set(ByVal Value As String)
            sIdFiscal = Value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return sRazonSocial
        End Get
        Set(ByVal Value As String)
            sRazonSocial = Value
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return sCalle
        End Get
        Set(ByVal Value As String)
            sCalle = Value
        End Set
    End Property
    Public Property Exterior() As String
        Get
            Return sExterior
        End Get
        Set(ByVal Value As String)
            sExterior = Value
        End Set
    End Property
    Public Property Interior() As String
        Get
            Return sInterior
        End Get
        Set(ByVal Value As String)
            sInterior = Value
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return sColonia
        End Get
        Set(ByVal Value As String)
            sColonia = Value
        End Set
    End Property
    Public Property Entidad() As String
        Get
            Return sEntidad
        End Get
        Set(ByVal Value As String)
            sEntidad = Value
        End Set
    End Property
    Public Property Municipio() As String
        Get
            Return sMunicipio
        End Get
        Set(ByVal Value As String)
            sMunicipio = Value
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return sPais
        End Get
        Set(ByVal Value As String)
            sPais = Value
        End Set
    End Property
    Public Property CodigPostal() As String
        Get
            Return sCodigoPostal
        End Get
        Set(ByVal Value As String)
            sCodigoPostal = Value
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return sReferencia
        End Get
        Set(ByVal Value As String)
            sReferencia = Value
        End Set
    End Property
    'Public Property CoordenadaX() As Decimal
    '    Get
    '        Return nCoordenadaX
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nCoordenadaX = value
    '    End Set
    'End Property
    'Public Property CoordenadaY() As Decimal
    '    Get
    '        Return nCoordenadaY
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nCoordenadaY = value
    '    End Set
    'End Property
    Public Sub New()

    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
Public Class Cliente
    'Inherits ServicesCentral.Cliente
    Protected sClienteClave As String
    Protected sCNPId As String
    Protected sClave As String
    Protected sIdElectronico As String
    Protected sIdFiscal As String
    Protected sRazonSocial As String
    Protected tTipoFiscal As Integer
    Protected iTipoImpuesto As Integer
    Protected sNombreContacto As String
    Protected sTelefonoContacto As String
    Protected dFechaRegistroSistema As Date
    Protected dFechaNacimiento As Date
    Protected fLimiteCreditoDinero As Decimal
    Protected sNombreCorto As String
    Protected tTipoEstado As TiposEstadosClientes
    Protected fLimiteDescuento As Decimal
    Protected iSaldoEnvase As Integer
    Protected fSaldoEfectivo As Decimal
    Protected fSaldoEfectivoCarga As Decimal
    Protected bCriterioCredito As Boolean

    Protected bExclusividad As Boolean
    Protected dVigExclusividad As DateTime
    Protected bConfiguracionPuntos As Boolean = False
    Private _actualizaSaldoCheq As Boolean = False
    Private _vencimientoVenta As Boolean = False
    Private _diasVenc As Integer = 0
    Private _desgloseImp As Boolean = False
    Private _Prestamo As Boolean
    Private _ExigirOrdenCompra As Boolean
    Private _capturaDatosFacturacion As Boolean = False
    Private _ImprimirPagare As Boolean = False

    Public Property ClienteClave() As String
        Get
            Return sClienteClave
        End Get
        Set(ByVal Value As String)
            sClienteClave = Value
        End Set
    End Property

    Public Property CNPId() As String
        Get
            Return sCNPId
        End Get
        Set(ByVal Value As String)
            sCNPId = Value
        End Set
    End Property
    Public Property Clave() As String
        Get
            Return sClave
        End Get
        Set(ByVal Value As String)
            sClave = Value
        End Set
    End Property
    Public Property IdElectronico() As String
        Get
            Return sIdElectronico
        End Get
        Set(ByVal Value As String)
            sIdElectronico = Value
        End Set
    End Property
    Public Property IdFiscal() As String
        Get
            Return sIdFiscal
        End Get
        Set(ByVal Value As String)
            sIdFiscal = Value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return sRazonSocial
        End Get
        Set(ByVal Value As String)
            sRazonSocial = Value
        End Set
    End Property
    Public Property TipoFiscal() As Integer
        Get
            Return tTipoFiscal
        End Get
        Set(ByVal Value As Integer)
            tTipoFiscal = Value
        End Set
    End Property
    Public Property TipoImpuesto() As Integer
        Get
            Return iTipoImpuesto
        End Get
        Set(ByVal Value As Integer)
            iTipoImpuesto = Value
        End Set
    End Property
    Public Property NombreContacto() As String
        Get
            Return sNombreContacto
        End Get
        Set(ByVal Value As String)
            sNombreContacto = Value
        End Set
    End Property
    Public Property TelefonoContacto() As String
        Get
            Return sTelefonoContacto
        End Get
        Set(ByVal Value As String)
            sTelefonoContacto = Value
        End Set
    End Property
    Public Property FechaRegistroSistema() As Date
        Get
            Return dFechaRegistroSistema
        End Get
        Set(ByVal Value As Date)
            dFechaRegistroSistema = Value
        End Set
    End Property
    Public Property FechaNacimiento() As Date
        Get
            Return dFechaNacimiento
        End Get
        Set(ByVal Value As Date)
            dFechaNacimiento = Value
        End Set
    End Property
    Public Property LimiteCreditoDinero() As Decimal
        Get
            Return fLimiteCreditoDinero
        End Get
        Set(ByVal Value As Decimal)
            fLimiteCreditoDinero = Value
        End Set
    End Property
    Public Property NombreCorto() As String
        Get
            Return sNombreCorto
        End Get
        Set(ByVal Value As String)
            sNombreCorto = Value
        End Set
    End Property
    Public Property TipoEstado() As TiposEstadosClientes
        Get
            Return tTipoEstado
        End Get
        Set(ByVal Value As TiposEstadosClientes)
            tTipoEstado = Value
        End Set
    End Property
    Public Property LimiteDescuento() As Decimal
        Get
            Return fLimiteDescuento
        End Get
        Set(ByVal Value As Decimal)
            fLimiteDescuento = Value
        End Set
    End Property
    Public Property SaldoEnvase() As Integer
        Get
            Return iSaldoEnvase
        End Get
        Set(ByVal Value As Integer)
            iSaldoEnvase = Value
        End Set
    End Property
    Public Property SaldoEfectivo() As Decimal
        Get
            Return fSaldoEfectivo
        End Get
        Set(ByVal Value As Decimal)
            fSaldoEfectivo = Value
        End Set
    End Property
    Public Property SaldoEfectivoCarga() As Decimal
        Get
            Return fSaldoEfectivoCarga
        End Get
        Set(ByVal Value As Decimal)
            fSaldoEfectivoCarga = Value
        End Set
    End Property
    Public Property Prestamo() As Boolean
        Get
            Return _Prestamo
        End Get
        Set(ByVal value As Boolean)
            _Prestamo = value
        End Set
    End Property

    Public Property Exclusividad() As Boolean
        Get
            Return bExclusividad
        End Get
        Set(ByVal Value As Boolean)
            bExclusividad = Value
        End Set
    End Property

    Public Property VigExclusividad() As DateTime
        Get
            Return dVigExclusividad
        End Get
        Set(ByVal Value As DateTime)
            dVigExclusividad = Value
        End Set
    End Property

    Public Property ConfiguracionPuntos() As Boolean
        Get
            Return bConfiguracionPuntos
        End Get
        Set(ByVal value As Boolean)
            bConfiguracionPuntos = value
        End Set
    End Property

    Public Property ActualizaSaldoCheque() As Boolean
        Get
            Return _actualizaSaldoCheq
        End Get
        Set(ByVal value As Boolean)
            _actualizaSaldoCheq = value
        End Set
    End Property

    Public Property VencimientoVenta() As Boolean
        Get
            Return _vencimientoVenta
        End Get
        Set(ByVal value As Boolean)
            _vencimientoVenta = value
        End Set
    End Property

    Public Property DiasVencimiento() As Integer
        Get
            Return _diasVenc
        End Get
        Set(ByVal value As Integer)
            _diasVenc = value
        End Set
    End Property
    Public Property DesgloseImpuesto() As Boolean
        Get
            Return _desgloseImp
        End Get
        Set(ByVal value As Boolean)
            _desgloseImp = value
        End Set
    End Property

    Public Property CriterioCredito() As Boolean
        Get
            Return bCriterioCredito
        End Get
        Set(ByVal value As Boolean)
            bCriterioCredito = value
        End Set
    End Property

    Public Property CapturaDatosFacturacion() As Boolean
        Get
            Return _capturaDatosFacturacion
        End Get
        Set(ByVal value As Boolean)
            _capturaDatosFacturacion = value
        End Set
    End Property
    Public Property ExigirOrdenCompra() As Boolean
        Get
            Return _ExigirOrdenCompra
        End Get
        Set(ByVal Value As Boolean)
            _ExigirOrdenCompra = Value
        End Set
    End Property

    Public Property ImprimirPagare() As Boolean
        Get
            Return _ImprimirPagare
        End Get
        Set(ByVal value As Boolean)
            _ImprimirPagare = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsClienteClave As String)
        Me.ClienteClave = parsClienteClave
    End Sub

    Public Function Recuperar() As Boolean
        Dim DataTableConsulta As DataTable
        DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT * FROM Cliente WHERE ClienteClave='" & Me.ClienteClave & "'", "Cliente")
        If DataTableConsulta.Rows.Count > 0 Then
            With DataTableConsulta.Rows(0)
                If Not IsDBNull(.Item("CNPId")) Then
                    Me.CNPId = .Item("CNPId")
                End If
                Me.Clave = .Item("Clave")
                Me.IdElectronico = IIf(IsDBNull(.Item("IdElectronico")), Nothing, .Item("IdElectronico"))
                Me.IdFiscal = IIf(IsDBNull(.Item("IdFiscal")), Nothing, .Item("IdFiscal"))
                Me.RazonSocial = .Item("RazonSocial")
                Me.TipoFiscal = .Item("TipoFiscal")
                Me.TipoImpuesto = .Item("TipoImpuesto")
                Me.NombreContacto = IIf(IsDBNull(.Item("NombreContacto")), Nothing, .Item("NombreContacto"))
                Me.TelefonoContacto = IIf(IsDBNull(.Item("TelefonoContacto")), Nothing, .Item("TelefonoContacto"))
                Me.FechaRegistroSistema = .Item("FechaRegistroSistema")
                Me.FechaNacimiento = IIf(IsDBNull(.Item("FechaNacimiento")), Nothing, .Item("FechaNacimiento"))
                Me.LimiteCreditoDinero = IIf(IsDBNull(.Item("LimiteCreditoDinero")), Nothing, .Item("LimiteCreditoDinero"))
                Me.NombreCorto = IIf(IsDBNull(.Item("NombreCorto")), Nothing, .Item("NombreCorto"))
                Me.TipoEstado = .Item("TipoEstado")
                Me.LimiteDescuento = .Item("LimiteDescuento")
                Me.Exclusividad = .Item("Exclusividad")
                Me.VigExclusividad = IIf(IsDBNull(.Item("VigExclusividad")), DateSerial(1900, 1, 1), .Item("VigExclusividad"))
                Me.SaldoEfectivo = .Item("SaldoEfectivo")
                Me.SaldoEfectivoCarga = .Item("SaldoEfectivoCarga")
                Me.ActualizaSaldoCheque = .Item("ActualizaSaldoCheque")
                Me.VencimientoVenta = .Item("VencimientoVenta")
                Me.DiasVencimiento = .Item("DiasVencimiento")
                Me.DesgloseImpuesto = .Item("DesgloseImpuesto")
                Me.Prestamo = .Item("Prestamo")
                Me.CriterioCredito = .Item("CriterioCredito")
                Me.CapturaDatosFacturacion = .Item("CapturaDatosFacturacion")
                Me.ExigirOrdenCompra = .Item("ExigirOrdenCompra")
                Me.ImprimirPagare = .Item("ImprimirPagare")
                'Me.FondoCristal = IIf(IsDBNull(.Item("FondoCristal")), False, .Item("FondoCristal"))
            End With
            DataTableConsulta.Dispose()

            Me.ConfiguracionPuntos = FormasCanjes.ExisteRegistroCaducidad(Me.ClienteClave)
            Return True
        End If
        DataTableConsulta.Dispose()
        Return False
    End Function

    Public Function RecuperarEsquemas(ByRef refparoDataViewEsquemas As DataView, ByRef refparoDataTableEsquemasClientes As DataTable) As Boolean
        Try
            Dim sConsultaSQL As String = "SELECT EsquemaID FROM ClienteEsquema WHERE ClienteClave='" & Me.ClienteClave & "'"
            ' Crear los DataTables y DataViews para buscar los esquemas
            refparoDataTableEsquemasClientes = oDBVen.RealizarConsultaSQL(sConsultaSQL, "ClienteEsquema")
            If refparoDataTableEsquemasClientes.Rows.Count = 0 Then
                ' El cliente no pertenece al menos a un esquema de clientes
                Return False
            End If
            ' DataTable de Esquemas (para buscar ascendentemente)
            Dim dtEsquemas As DataTable
            sConsultaSQL = "SELECT EsquemaID,EsquemaIDPadre FROM Esquema WHERE Tipo=" & ServicesCentral.TiposEsquemas.Clientes
            dtEsquemas = oDBVen.RealizarConsultaSQL(sConsultaSQL, "Esquema")
            If dtEsquemas.Rows.Count = 0 Then
                ' No hay esquemas de clientes definidos
                dtEsquemas.Dispose()
                Return False
            End If
            ' Crear el DataView de busqueda de esquemas
            refparoDataViewEsquemas = New DataView(dtEsquemas, "", "EsquemaID", DataViewRowState.CurrentRows)
            dtEsquemas.Dispose()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Sub RecuperarEsquemasCliente(ByRef refDataViewEsquemas As DataView, ByRef refparsEsquemasCliente As String, ByVal parsNodo As String)
        Try
            If parsNodo = String.Empty Then Exit Sub
            Dim sNodo As String = String.Empty
            Dim iPos As Integer = refDataViewEsquemas.Find(parsNodo)
            If iPos > -1 Then
                If Not IsDBNull(refDataViewEsquemas(iPos)("EsquemaIDPadre")) Then
                    refparsEsquemasCliente &= "'" & refDataViewEsquemas(iPos)("EsquemaIDPadre") & "',"
                    RecuperarEsquemasCliente(refDataViewEsquemas, refparsEsquemasCliente, refDataViewEsquemas(iPos)("EsquemaIDPadre"))
                Else
                    Exit Sub
                End If
            End If
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodosArbol")
        End Try
    End Sub

    Public Function ExisteFormaVenta() As Boolean
        Dim iRes As Integer = 0
        iRes = oDBVen.EjecutarCmdScalarIntSQL("select count(*) from CLIFormaVenta where Estado = 1 and ClienteClave='" & Me.ClienteClave & "'")
        Return iRes > 0
    End Function

    Public Function RecuperarTipoPago() As DataTable
        Dim DataTableConsulta As DataTable
        DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT Tipo,TipoBanco,Cuenta FROM ClientePago WHERE ClienteClave='" & Me.ClienteClave & "'", "ClientePago")
        Return DataTableConsulta
    End Function

    Public Function ActualizarSaldo(ByVal pariIP_Saldo As Decimal) As Boolean
        Try
            Dim i As Integer
            i = oDBVen.EjecutarComandoSQL("UPDATE Cliente Set SaldoEfectivo=Round(SaldoEfectivo + " & pariIP_Saldo & ",2) , Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave='" & Me.ClienteClave & "'")
            Me.SaldoEfectivo = Math.Round(Me.SaldoEfectivo + pariIP_Saldo, 2)
            If i > 0 Then
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        Return False
    End Function

    Public Enum TiposEstadosClientes
        NoDefinido = 0
        ClienteVisitado = 1
        ClienteNoVisitado = 2
    End Enum

End Class

Public Class Folio

    Protected sFolioID As String
    Protected sModuloMovDetalleClave As String
    Protected sDescripcion As String
    Protected sValorInicial As String
    Protected tTipoAccionReiniciar As ServicesCentral.TiposAccionReiniciarFolios
    Protected tTipoReinicio As ServicesCentral.TiposReinicioFolios

    Public Property FolioID() As String
        Get
            Return sFolioID
        End Get
        Set(ByVal Value As String)
            sFolioID = Value
        End Set
    End Property
    Public Property ModuloMovDetalleClave() As String
        Get
            Return sModuloMovDetalleClave
        End Get
        Set(ByVal Value As String)
            sModuloMovDetalleClave = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return sDescripcion
        End Get
        Set(ByVal Value As String)
            sDescripcion = Value
        End Set
    End Property
    Public Property ValorInicial() As String
        Get
            Return sValorInicial
        End Get
        Set(ByVal Value As String)
            sValorInicial = Value
        End Set
    End Property

    Public Function Recuperar() As Boolean
        Dim DataTableConsulta As DataTable
        DataTableConsulta = odbVen.RealizarConsultaSQL("SELECT * FROM Folio WHERE FolioID='" & Me.FolioID & "'", "Folio")
        If DataTableConsulta.Rows.Count > 0 Then
            With DataTableConsulta.Rows(0)
                Me.FolioID = .Item("FolioID")
                Me.ModuloMovDetalleClave = .Item("ModuloMovDetalleClave")
                Me.Descripcion = .Item("Descripcion")
                Me.ValorInicial = .Item("ValorInicial")
            End With
            DataTableConsulta.Dispose()
            Return True
        End If
        DataTableConsulta.Dispose()
        Return False
    End Function

    Public Shared Function Obtener(Optional ByVal optparsModuloMovDetClave As String = "", Optional ByVal optpareTipoModuloMovDet As ServicesCentral.TiposModulosMovDet = ServicesCentral.TiposModulosMovDet.NoDefinido) As String
        Dim iConsecutivo As Integer = 1
        Dim sFolio As String = ""
        ' Si es el módulo de Ventas
        Dim bUsarFolioProvisional As Boolean = True
        Try
            Dim DataTableFolioRes As DataTable
            If ObtenerPropiedadesFolio(DataTableFolioRes, True, optparsModuloMovDetClave, optpareTipoModuloMovDet) Then
                Dim refDataRow As DataRow = DataTableFolioRes.Rows(0)
                Dim sFolioId As String = refDataRow("FolioId")
                Dim iInicio As Integer = refDataRow("Inicio")
                Dim iFin As Integer = refDataRow("Fin")
                Dim iUsados As Integer = refDataRow("Usados")
                Dim eTipoContenido As ServicesCentral.TiposContenidoFolios
                Dim sContenido As String
                iConsecutivo = iInicio + iUsados
                ' Cambios 23 Abril
                'If iConsecutivo = iFin Then
                '    MsgBox("No existen más folios para el movimiento seleccionado", MsgBoxStyle.Exclamation)
                '    Exit Try
                'End If
                ' /Cambios 23 Abril
                Dim DataTableFoliosDet As DataTable = oDBVen.RealizarConsultaSQL("SELECT TipoContenido,Formato FROM FolioDetalle WHERE FolioId='" & sFolioId & "' ORDER BY FolioDetClave", "FolioDetalle")
                If DataTableFoliosDet.Rows.Count = 0 Then
                    'MsgBox("No está definido el formato del folio para el tipo de movimiento", MsgBoxStyle.Exclamation)
                    ' Cambios 08 Mayo 2006
                    MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "NoDefinidos"), MsgBoxStyle.Exclamation)
                    ' / Cambios 08 Mayo 2006
                    DataTableFoliosDet.Dispose()
                    Exit Try
                End If
                ' Conformar el nuevo folio
                For Each refDataRow In DataTableFoliosDet.Rows
                    eTipoContenido = refDataRow("TipoContenido")
                    sContenido = refDataRow("Formato")
                    Select Case eTipoContenido
                        Case ServicesCentral.TiposContenidoFolios.Constante
                            sFolio &= sContenido
                        Case ServicesCentral.TiposContenidoFolios.Incremental
                            sFolio &= Format(iConsecutivo, sContenido)
                    End Select
                Next
                DataTableFoliosDet.Dispose()
                bUsarFolioProvisional = False
                If sFolio = "" Then
                    'MsgBox("No se pudo obtener un folio para el movimiento, se usará uno temporal", MsgBoxStyle.Exclamation)
                    ' Cambios 08 Mayo 2006
                    MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "FolioTemporal"), MsgBoxStyle.Exclamation)
                    ' / Cambios 08 Mayo 2006
                    bUsarFolioProvisional = True
                End If
                If bUsarFolioProvisional Then
                    ' Usar un folio provisional
                    sFolio = Format(Now, "hhmmss")
                End If
            End If
            DataTableFolioRes.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerFolio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerFolio")
        End Try
        Return sFolio
    End Function

    Public Shared Sub Confirmar(Optional ByVal optparsModuloMovDetClave As String = "", Optional ByVal optpareTipoModuloMovDet As ServicesCentral.TiposModulosMovDet = ServicesCentral.TiposModulosMovDet.NoDefinido)
        Try
            Dim DataTableFolioRes As DataTable
            If ObtenerPropiedadesFolio(DataTableFolioRes, False, optparsModuloMovDetClave, optpareTipoModuloMovDet) Then
                ' Considerar solo el primer registro del folio
                Dim refDataRow As DataRow = DataTableFolioRes.Rows(0)
                ' Indicar que se ha obtenido el folio, reducir el número de disponibles
                Dim iUsados As Integer = refDataRow("Usados")
                ' Cambios 23 Abril
                ' Buscar cual es el primer rango para afectar
                'Dim iRangoMenor As Integer = oDBVen.EjecutarCmdScalarIntSQL("SELECT MIN(Rango) AS MinRango FROM FolioReservacion WHERE FolioId='" & refDataRow("FolioId") & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo)
                Dim dtRangos As DataTable = oDBVen.RealizarConsultaSQL("SELECT RangoId FROM FolioReservacion WHERE FolioId='" & refDataRow("FolioId") & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " AND Usados < ((Fin - Inicio) + 1) ORDER BY Inicio", "Rangos")
                Dim sRangoId As String = dtRangos.Rows(0)("RangoId")
                iUsados += 1
                Dim sConsultaSQL As String = "UPDATE FolioReservacion SET Usados=" & iUsados & " "
                If refDataRow("Fin") - refDataRow("Inicio") + 1 = iUsados Then
                    sConsultaSQL &= ",TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Inactivo & " "
                End If
                sConsultaSQL &= ",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado = 0  WHERE FolioId='" & refDataRow("FolioId") & "' AND RangoId='" & sRangoId & "'"
                oDBVen.EjecutarComandoSQL(sConsultaSQL)
                ' /Cambios 23 Abril
            End If
            DataTableFolioRes.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ConfirmarFolio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ConfirmarFolio")
        End Try
    End Sub

    Public Shared Function ObtenerVarios(Optional ByVal optparsModuloMovDetClave As String = "", Optional ByVal optpareTipoModuloMovDet As ServicesCentral.TiposModulosMovDet = ServicesCentral.TiposModulosMovDet.NoDefinido, Optional ByVal numObtener As Integer = 2) As String()
        Dim iConsecutivo As Integer = 1
        Dim sFolio(numObtener - 1) As String

        ' Si es el módulo de Ventas

        Dim bUsarFolioProvisional As Boolean = True
        Try
            Dim DataTableFolioRes As DataTable
            If ObtenerPropiedadesFolio(DataTableFolioRes, True, optparsModuloMovDetClave, optpareTipoModuloMovDet) Then
                Dim refDataRowFolioRes As DataRow = DataTableFolioRes.Rows(0)
                Dim sFolioId As String = refDataRowFolioRes("FolioId")
                'Dim iInicio As Integer = refDataRow("Inicio")
                'Dim iFin As Integer = refDataRow("Fin")
                'Dim iUsados As Integer = refDataRow("Usados")
                Dim eTipoContenido As ServicesCentral.TiposContenidoFolios
                Dim sContenido As String
                'iConsecutivo = iInicio + iUsados
                ' Cambios 23 Abril
                'If iConsecutivo = iFin Then
                '    MsgBox("No existen más folios para el movimiento seleccionado", MsgBoxStyle.Exclamation)
                '    Exit Try
                'End If
                ' /Cambios 23 Abril
                Dim DataTableFoliosDet As DataTable = oDBVen.RealizarConsultaSQL("SELECT TipoContenido,Formato FROM FolioDetalle WHERE FolioId='" & sFolioId & "' ORDER BY FolioDetClave", "FolioDetalle")
                If DataTableFoliosDet.Rows.Count = 0 Then
                    'MsgBox("No está definido el formato del folio para el tipo de movimiento", MsgBoxStyle.Exclamation)
                    ' Cambios 08 Mayo 2006
                    MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "NoDefinidos"), MsgBoxStyle.Exclamation)
                    ' / Cambios 08 Mayo 2006
                    DataTableFoliosDet.Dispose()
                    Exit Try
                End If
                ' Conformar los nuevos folios
                For i As Integer = 0 To numObtener - 1
                    iConsecutivo = -1
                    If (refDataRowFolioRes("Inicio") + refDataRowFolioRes("Usados")) <= refDataRowFolioRes("Fin") Then
                        iConsecutivo = refDataRowFolioRes("Inicio") + refDataRowFolioRes("Usados")
                    Else
                        Dim aDataRows() As DataRow = DataTableFolioRes.Select("Usados < ((Fin - Inicio) + 1)", "Inicio")
                        If Not IsNothing(aDataRows) AndAlso aDataRows.Length > 0 Then
                            refDataRowFolioRes = aDataRows(0)
                            iConsecutivo = refDataRowFolioRes("Inicio") + refDataRowFolioRes("Usados")
                        End If
                    End If
                    If iConsecutivo >= 0 Then
                        For Each oDataRow As DataRow In DataTableFoliosDet.Rows

                            eTipoContenido = oDataRow("TipoContenido")
                            sContenido = oDataRow("Formato")
                            Select Case eTipoContenido
                                Case ServicesCentral.TiposContenidoFolios.Constante
                                    sFolio(i) &= sContenido
                                Case ServicesCentral.TiposContenidoFolios.Incremental
                                    sFolio(i) &= Format(iConsecutivo, sContenido)
                            End Select
                        Next
                    End If
                    If sFolio(i) <> "" Then 'Si se uso el consecutivo
                        refDataRowFolioRes("Usados") += 1
                    End If

                    DataTableFoliosDet.Dispose()
                    bUsarFolioProvisional = False
                    If sFolio(i) = "" Then
                        'MsgBox("No se pudo obtener un folio para el movimiento, se usará uno temporal", MsgBoxStyle.Exclamation)
                        ' Cambios 08 Mayo 2006
                        MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "FolioTemporal"), MsgBoxStyle.Exclamation)
                        ' / Cambios 08 Mayo 2006
                        bUsarFolioProvisional = True
                    End If
                    If bUsarFolioProvisional Then
                        ' Usar un folio provisional
                        sFolio(i) = Format(Now, "hhmmss")
                    End If
                Next
            End If
            DataTableFolioRes.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerFolio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerFolio")
        End Try
        Return sFolio
    End Function

    Private Shared Function ObtenerPropiedadesFolio(ByRef refDataTable As DataTable, ByVal parbMostrarMensajeError As Boolean, Optional ByVal optparsModuloMovDetClave As String = "", Optional ByVal optpareTipoModuloMovDet As ServicesCentral.TiposModulosMovDet = ServicesCentral.TiposModulosMovDet.NoDefinido) As Boolean
        Dim sModuloMovDetClave As String = optparsModuloMovDetClave
        Dim sConsultaSQL As String = "SELECT Folio.FolioId, FolioReservacion.Inicio, FolioReservacion.Fin, FolioReservacion.Usados FROM FolioReservacion "
        sConsultaSQL &= "INNER JOIN Folio ON FolioReservacion.FolioID = Folio.FolioID "

        ' Primero, siempre se debe pasar el tipo de folio
        ' Segundo. si el Id del modulo se pasa, se buscara el Id del folio usando el Id. del modulomovdetalle y el tipo
        ' Tercero, si no se pasa el Id del modulo, entonces se debera pasar el TipoModuloMovDet, para buscar asi primero el ModuloMovDetalleClave asociado al TipoModuloMovDet
        ' Al final, se debera tener el TipoFolio y el ModuloMovDetalleClave para buscar el FolioId correspondiente

        If sModuloMovDetClave = "" Then
            ' Obtener el ModuloMovDetalleClave dependiendo del tipo de pareTipoModuloMovDet
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloMovDetalleClave FROM ModuloMovDetalle WHERE TipoIndice=" & optpareTipoModuloMovDet, "ModuloMovDetalle")
            If DataTableMod.Rows.Count > 0 Then
                ' Usar el primer elemento
                sModuloMovDetClave = DataTableMod.Rows(0).Item("ModuloMovDetalleClave")
            End If
            DataTableMod.Dispose()
        End If
        sConsultaSQL &= "WHERE Folio.ModuloMovDetalleClave = '" & sModuloMovDetClave & "' "
        ' Cambios 23 Abril
        sConsultaSQL &= "AND FolioReservacion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " "
        sConsultaSQL &= "AND Usados < ((Fin - Inicio) + 1) "
        sConsultaSQL &= "ORDER BY Inicio "
        ' /Cambios 23 Abril
        refDataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL, "FolioReservacion")
        If refDataTable.Rows.Count = 0 Then
            If parbMostrarMensajeError Then
                MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "NoHayFolios"), MsgBoxStyle.Exclamation)
            End If
            Return False
        End If
        Return True
    End Function

    Public Shared Function ObtenerNumeroDisponibles(Optional ByVal optparsModuloMovDetClave As String = "", Optional ByVal optpareTipoModuloMovDet As ServicesCentral.TiposModulosMovDet = ServicesCentral.TiposModulosMovDet.NoDefinido) As Integer
        Dim sModuloMovDetClave As String = optparsModuloMovDetClave
        Dim sConsultaSQL As String = "SELECT sum((fin-inicio)-Usados) as Disponibles FROM FolioReservacion "
        sConsultaSQL &= "INNER JOIN Folio ON FolioReservacion.FolioID = Folio.FolioID "

        ' Primero, siempre se debe pasar el tipo de folio
        ' Segundo. si el Id del modulo se pasa, se buscara el Id del folio usando el Id. del modulomovdetalle y el tipo
        ' Tercero, si no se pasa el Id del modulo, entonces se debera pasar el TipoModuloMovDet, para buscar asi primero el ModuloMovDetalleClave asociado al TipoModuloMovDet
        ' Al final, se debera tener el TipoFolio y el ModuloMovDetalleClave para buscar el FolioId correspondiente

        If sModuloMovDetClave = "" Then
            ' Obtener el ModuloMovDetalleClave dependiendo del tipo de pareTipoModuloMovDet
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloMovDetalleClave FROM ModuloMovDetalle WHERE TipoIndice=" & optpareTipoModuloMovDet, "ModuloMovDetalle")
            If DataTableMod.Rows.Count > 0 Then
                ' Usar el primer elemento
                sModuloMovDetClave = DataTableMod.Rows(0).Item("ModuloMovDetalleClave")
            End If
            DataTableMod.Dispose()
        End If
        sConsultaSQL &= "WHERE  Folio.ModuloMovDetalleClave = '" & sModuloMovDetClave & "' "
        sConsultaSQL &= "AND FolioReservacion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo

        Return oDBVen.EjecutarCmdScalarIntSQL(sConsultaSQL)
    End Function
    Public Shared Function ObtenerTransProdId(ByRef refparTransProdId As String) As Boolean
        refparTransProdId = oApp.KEYGEN(100)
        Return True
    End Function

    Public Shared Function ObtenerTransProdDetalleId(ByVal parsTransProdId As String, ByRef refparsTransProdDetalleId As String) As Boolean
        refparsTransProdDetalleId = ""
        Try
            Dim DataTableIds As DataTable = odbVen.RealizarConsultaSQL("SELECT MAX(TransProdDetalleID) AS ""UltimoID"" FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "'", "TransProdDetalle")
            If DataTableIds.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTableIds.Rows(0)
                refparsTransProdDetalleId = "001"
                If Not refDataRow.IsNull("UltimoID") Then
                    refparsTransProdDetalleId = Format(CInt(refDataRow("UltimoID")) + 1, "000")
                End If
                DataTableIds.Dispose()
                Return True
            End If
            DataTableIds.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleId")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleId")
        End Try
        Return False
    End Function

    Public Shared Function ObtenerTransProdDetalleId(ByVal parsTransProdId As String, ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer, ByRef refparsTransProdDetalleId As String) As Boolean
        refparsTransProdDetalleId = ""
        Try
            Dim DataTableIds As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' and ProductoClave='" & parsProductoClave & "' and TipoUnidad=" & pariTipoUnidad, "TransProdDetalle")
            If DataTableIds.Rows.Count > 0 Then
                refparsTransProdDetalleId = DataTableIds.Rows(0)(0)
                DataTableIds.Dispose()
                Return True
            End If
            DataTableIds.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleId")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleId")
        End Try
        Return False
    End Function

    Public Shared Function ObtenerTransProdDetalleImpuestoId(ByVal parsTransProdId As String, ByVal parsTransProdDetalleId As String, ByRef refparsTPDImpuestoId As String) As Boolean
        refparsTPDImpuestoId = ""
        Try
            Dim DataTableIds As DataTable = odbVen.RealizarConsultaSQL("SELECT MAX(TPDImpuestoID) AS ""UltimoID"" FROM TPDImpuesto WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID='" & parsTransProdDetalleId & "'", "TPDImpuesto")
            If DataTableIds.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTableIds.Rows(0)
                refparsTPDImpuestoId = "001"
                If Not refDataRow.IsNull("UltimoID") Then
                    refparsTPDImpuestoId = Format(CInt(refDataRow("UltimoID")) + 1, "000")
                End If
                DataTableIds.Dispose()
                Return True
            End If
            DataTableIds.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleImpuestosId")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerTransProdDetalleImpuestosId")
        End Try
        Return False
    End Function

    Public Shared Function ObtenerTransProdPartida(ByVal parsTransProdId As String, ByVal parsProductoClave As String, ByRef refpariPartida As Integer) As Boolean
        Try
            refpariPartida = 1
            Dim DataTableIds As DataTable = odbVen.RealizarConsultaSQL("SELECT MAX(Partida) AS ""UltimaPartida"" FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "'", "TransProdDetalle")
            If DataTableIds.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTableIds.Rows(0)
                If Not refDataRow.IsNull("UltimaPartida") Then
                    refpariPartida = refDataRow("UltimaPartida") + 1
                End If
                DataTableIds.Dispose()
                Return True
            End If
            DataTableIds.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerTransProdPartida")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerTransProdPartida")
        End Try
        Return False
    End Function

End Class

Public Class Modulos

    Public Class GrupoModulo

        Protected sModuloClave As String
        Protected sNombre As String
        Public Property ModuloClave() As String
            Get
                Return sModuloClave
            End Get
            Set(ByVal Value As String)
                sModuloClave = Value
            End Set
        End Property
        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property

        Private tTipoModulo As ServicesCentral.TiposModulos
        Public Property TipoModulo() As ServicesCentral.TiposModulos
            Get
                Return tTipoModulo
            End Get
            Set(ByVal Value As ServicesCentral.TiposModulos)
                tTipoModulo = Value
            End Set
        End Property

        Public Overridable Function Recuperar() As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave,Nombre,TipoIndice FROM ModuloTerm WHERE ModuloClave='" & Me.ModuloClave & "'", "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                Me.ModuloClave = DataTableMod.Rows(0).Item("ModuloClave")
                Me.Nombre = DataTableMod.Rows(0).Item("Nombre")
                Me.TipoModulo = DataTableMod.Rows(0).Item("TipoIndice")
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function
    End Class

    Public Class GrupoModuloMov
        Inherits GrupoModulo

        Protected sModuloMovClave As String
        Protected tTipoModuloMov As ServicesCentral.TiposModulosMov
        Public Property ModuloMovClave() As String
            Get
                Return sModuloMovClave
            End Get
            Set(ByVal Value As String)
                sModuloMovClave = Value
            End Set
        End Property
        Public Property TipoModuloMov() As ServicesCentral.TiposModulosMov
            Get
                Return tTipoModuloMov
            End Get
            Set(ByVal Value As ServicesCentral.TiposModulosMov)
                tTipoModuloMov = Value
            End Set
        End Property

        Public Overloads Function Recuperar() As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT Nombre,TipoIndice FROM ModuloMov WHERE ModuloClave='" & Me.ModuloClave & "' AND ModuloMovClave='" & Me.ModuloMovClave & "'", "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                Me.Nombre = DataTableMod.Rows(0).Item("Nombre")
                Me.TipoModuloMov = DataTableMod.Rows(0).Item("TipoIndice")
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function

        Public Overloads Function Recuperar(ByVal partTipoModuloMov As ServicesCentral.TiposModulosMov) As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave,ModuloMovClave,Nombre,TipoIndice FROM ModuloMov WHERE TipoIndice='" & partTipoModuloMov & "'", "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                With DataTableMod.Rows(0)
                    Me.ModuloClave = DataTableMod.Rows(0).Item("ModuloClave")
                    Me.ModuloMovClave = DataTableMod.Rows(0).Item("ModuloMovClave")
                    Me.Nombre = DataTableMod.Rows(0).Item("Nombre")
                    Me.TipoModuloMov = DataTableMod.Rows(0).Item("TipoIndice")
                End With
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function

        Public Overloads Function Recuperar(ByVal parsModuloMovClave As String) As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave,Nombre,TipoIndice FROM ModuloMov WHERE ModuloMovClave='" & parsModuloMovClave & "'", "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                With DataTableMod.Rows(0)
                    Me.ModuloClave = DataTableMod.Rows(0).Item("ModuloClave")
                    Me.ModuloMovClave = parsModuloMovClave
                    Me.Nombre = DataTableMod.Rows(0).Item("Nombre")
                    Me.TipoModuloMov = DataTableMod.Rows(0).Item("TipoIndice")
                End With
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function
    End Class

    Public Class GrupoModuloMovDetalle
        Inherits GrupoModuloMov

        Protected sModuloMovDetalleClave As String
        Protected tTipoModuloMovDetalle As ServicesCentral.TiposModulosMovDet
        Protected tTipoTransProd As ServicesCentral.TiposTransProd
        Protected tTipoPedido As ServicesCentral.TiposPedidos
        Protected tTipoMovimiento As ServicesCentral.TiposMovimientos

        Public Property ModuloMovDetalleClave() As String
            Get
                Return sModuloMovDetalleClave
            End Get
            Set(ByVal Value As String)
                sModuloMovDetalleClave = Value
            End Set
        End Property
        Public Property TipoModuloMovDetalle() As ServicesCentral.TiposModulosMovDet
            Get
                Return tTipoModuloMovDetalle
            End Get
            Set(ByVal Value As ServicesCentral.TiposModulosMovDet)
                tTipoModuloMovDetalle = Value
            End Set
        End Property
        Public Property TipoTransProd() As ServicesCentral.TiposTransProd
            Get
                Return tTipoTransProd
            End Get
            Set(ByVal Value As ServicesCentral.TiposTransProd)
                tTipoTransProd = Value
            End Set
        End Property
        Public Property TipoPedido() As ServicesCentral.TiposPedidos
            Get
                Return tTipoPedido
            End Get
            Set(ByVal Value As ServicesCentral.TiposPedidos)
                tTipoPedido = Value
            End Set
        End Property
        Public Property TipoMovimiento() As ServicesCentral.TiposMovimientos
            Get
                Return tTipoMovimiento
            End Get
            Set(ByVal Value As ServicesCentral.TiposMovimientos)
                tTipoMovimiento = Value
            End Set
        End Property

        Public Overloads Function Recuperar(ByVal parsModuloMovDetalleClave As String) As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave, ModuloMovClave, ModuloMovDetalleClave, Nombre, TipoIndice, TipoTransProd, TipoMovimiento, TipoPedido FROM ModuloMovDetalle WHERE ModuloMovDetalleClave='" & parsModuloMovDetalleClave & "'", "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                With DataTableMod.Rows(0)
                    Me.ModuloClave = .Item("ModuloClave")
                    Me.ModuloMovClave = .Item("ModuloMovClave")
                    Me.ModuloMovDetalleClave = .Item("ModuloMovDetalleClave")
                    Me.Nombre = .Item("Nombre")
                    Me.TipoModuloMovDetalle = .Item("TipoIndice")
                    Me.TipoTransProd = .Item("TipoTransProd")
                    Me.TipoMovimiento = .Item("TipoMovimiento")
                    Me.TipoPedido = .Item("TipoPedido")
                End With
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function

        Public Overloads Function Recuperar(ByVal partTipoModuloMovDetalle As ServicesCentral.TiposModulosMovDet) As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave, ModuloMovClave, ModuloMovDetalleClave, Nombre, TipoIndice, TipoTransProd, TipoMovimiento, TipoPedido FROM ModuloMovDetalle WHERE TipoIndice=" & CInt(partTipoModuloMovDetalle), "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                With DataTableMod.Rows(0)
                    Me.ModuloClave = .Item("ModuloClave")
                    Me.ModuloMovClave = .Item("ModuloMovClave")
                    Me.ModuloMovDetalleClave = .Item("ModuloMovDetalleClave")
                    Me.Nombre = .Item("Nombre")
                    Me.TipoModuloMovDetalle = .Item("TipoIndice")
                    Me.TipoTransProd = .Item("TipoTransProd")
                    Me.TipoMovimiento = .Item("TipoMovimiento")
                    Me.TipoPedido = .Item("TipoPedido")
                End With
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function

        Public Overloads Function Recuperar(ByVal partTipoModuloMovDetalle As ServicesCentral.TiposModulosMovDet, ByVal partTipoTransProd As ServicesCentral.TiposTransProd) As Boolean
            Dim DataTableMod As DataTable
            DataTableMod = oDBVen.RealizarConsultaSQL("SELECT ModuloClave, ModuloMovClave, ModuloMovDetalleClave, Nombre, TipoIndice, TipoTransProd, TipoMovimiento, TipoPedido FROM ModuloMovDetalle WHERE TipoIndice=" & CInt(partTipoModuloMovDetalle) & " AND TipoTransProd=" & CInt(partTipoTransProd), "Modulo")
            If DataTableMod.Rows.Count > 0 Then
                With DataTableMod.Rows(0)
                    Me.ModuloClave = .Item("ModuloClave")
                    Me.ModuloMovClave = .Item("ModuloMovClave")
                    Me.ModuloMovDetalleClave = .Item("ModuloMovDetalleClave")
                    Me.Nombre = .Item("Nombre")
                    Me.TipoModuloMovDetalle = .Item("TipoIndice")
                    Me.TipoTransProd = .Item("TipoTransProd")
                    Me.TipoMovimiento = .Item("TipoMovimiento")
                    Me.TipoPedido = .Item("TipoPedido")
                End With
                DataTableMod.Dispose()
                Return True
            End If
            DataTableMod.Dispose()
            Return False
        End Function
    End Class


End Class

Public Class Almacen

    Protected sAlmacenID As String
    Protected sNombre As String

    Public Property AlmacenID() As String
        Get
            Return sAlmacenID
        End Get
        Set(ByVal Value As String)
            sAlmacenID = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property

    Public Overridable Function Recuperar() As Boolean
        Dim DataTableALM As DataTable
        DataTableALM = oDBVen.RealizarConsultaSQL("SELECT AlmacenID,Nombre FROM Almacen WHERE AlmacenID='" & Me.AlmacenID & "'", "Almacen")
        If DataTableALM.Rows.Count > 0 Then
            Me.AlmacenID = DataTableALM.Rows(0).Item("AlmacenID")
            Me.Nombre = DataTableALM.Rows(0).Item("Nombre")
            DataTableALM.Dispose()
            Return True
        End If
        DataTableALM.Dispose()
        Return False
    End Function

End Class

Public Class Ruta

    Protected sRUTClave As String
    Protected sDescripcion As String
    Protected bInventario As Boolean

    Public Property RUTClave() As String
        Get
            Return sRUTClave
        End Get
        Set(ByVal Value As String)
            sRUTClave = Value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return sDescripcion
        End Get
        Set(ByVal Value As String)
            sDescripcion = Value
        End Set
    End Property
    Public Property Inventario() As Boolean
        Get
            Return bInventario
        End Get
        Set(ByVal Value As Boolean)
            bInventario = Value
        End Set
    End Property
    'Public Property Tipo() As Integer
    '    Get
    '        Return iTipo
    '    End Get
    '    Set(ByVal Value As Integer)
    '        iTipo = Value
    '    End Set
    'End Property

    Public Overridable Function Recuperar() As Boolean
        Dim DataTableRUT As DataTable
        DataTableRUT = oDBVen.RealizarConsultaSQL("SELECT RUTClave,Descripcion,Inventario FROM Ruta WHERE RUTClave='" & Me.RUTClave & "'", "Ruta")
        If DataTableRUT.Rows.Count > 0 Then
            Me.RUTClave = DataTableRUT.Rows(0).Item("RUTClave")
            Me.Descripcion = DataTableRUT.Rows(0).Item("Descripcion")
            Me.Inventario = DataTableRUT.Rows(0).Item("Inventario")
            'Me.Tipo = DataTableRUT.Rows(0).Item("Tipo")
            DataTableRUT.Dispose()
            Return True
        End If
        DataTableRUT.Dispose()
        Return False
    End Function

End Class

Public Class CONHist
    Implements IDisposable
    Private _campos As Dictionary(Of String, Object)
    Private disposedValue As Boolean = False

    Public Property Campos() As Dictionary(Of String, Object)
        Get
            Return _campos
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _campos = value
        End Set
    End Property
    Public Sub New()
        _campos = oDBVen.RealizarReaderSQLconCampos("SELECT * FROM CONHist")
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                _campos.Clear()
                _campos = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class


Public Class VersionesLicencias

    Public Function RealizarConsultaSQL(ByVal parsConsultaSQL As String, ByVal parsNombreTabla As String, ByVal parsArchivoSDF As String) As DataTable
        Dim DataSetRetorno As New DataSet
        Try

            Dim oConexion As SqlCeConnection
            oConexion = New SqlCeConnection("Data Source = " & oApp.RutaTrabajo & "\" & parsArchivoSDF)

            Dim DataAdapterBase As SqlCeDataAdapter
            DataAdapterBase = New SqlCeDataAdapter(parsConsultaSQL, oConexion)
            DataAdapterBase.Fill(DataSetRetorno, parsNombreTabla)
            DataAdapterBase.Dispose()

            Dim dtRes As DataTable = DataSetRetorno.Tables(0)
            DataSetRetorno.Tables.Clear()
            DataSetRetorno.Dispose()
            DataAdapterBase = Nothing
            DataSetRetorno = Nothing
            oConexion.Dispose()

            Return dtRes
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & parsConsultaSQL, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "RealizarConsultaSQL")
        End Try
        Return Nothing
    End Function

    Public Function Revisar_Licencia() As Boolean

        Try
            Dim oLicencia As ServicesCentral.Registro
            Dim oDevice As New CDevice

            Dim bDisponible As Boolean = True
            If (Not oApp.ProbarServicioR(3)) Then
                bDisponible = False
                If oApp.UsarWireless Then
                    bDisponible = oApp.RevisarServidor()
                End If
                If Not bDisponible Then
                    MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Revisar_Licencia")
                    Return False
                End If
            End If

            If bDisponible Then
                oLicencia = oServicioWeb.WSTipo_Licencia(CDevice.GetDeviceID, oDevice.DeviceName)
                If Not oLicencia = ServicesCentral.Registro.Definitivo Then
                    MsgBox("El dispositivo no tiene una licencia válida", MsgBoxStyle.Critical)
                    Return False
                End If
                oLicencia = Nothing
            End If
        Catch ex As System.Net.WebException
            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico.", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Revisar_Licencia")
            Return False
        Catch ex As System.Net.Sockets.SocketException
            MsgBox("[F0008] No se puede establecer conexión de Área Local. Avisar a Soporte Técnico.", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Revisar_Licencia")
            Return False
        Catch ex As System.InvalidOperationException
            MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Revisar_Licencia")
            Return False
        Catch ex As Exception
            MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Revisar_Licencia")
            Return False
        End Try

        Return True
    End Function

    Public Shared Function ChecarConexion() As Boolean
        Dim iResult As Integer

        Dim ipAddress As System.Net.IPAddress
        Dim strAddress As String

        With System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            ipAddress = New System.Net.IPAddress(.AddressList(0).Address)
            strAddress = ipAddress.ToString
            If strAddress = "127.0.0.1" Then
                iResult = 1
            Else
                iResult = 0
            End If
        End With

        If iResult = 1 Then
            '--MessageBox.Show("Testing - Not Connected")
            Return False
        Else
            '--MessageBox.Show("Testing - Connected")
            Return True
        End If
    End Function

End Class

'--JPacheco 23 Marzo 07
'--Apagar y Prender el bluetooth
Public Class Symbol_Bluetooth
    <System.Runtime.InteropServices.DllImport("Symbol_Bluetooth.dll", _
           EntryPoint:="Bluetooth_On")> _
   Public Shared Function Bluetooth_On() As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("Symbol_Bluetooth.dll", _
          EntryPoint:="Bluetooth_Off")> _
   Public Shared Function Bluetooth_Off() As Boolean
    End Function
End Class


'--Verificar si se tiene una conexion, por ejemplo Active Sync
Public Class ConexionEnBase

    Public Shared Function ChecarConexion() As Boolean
        Dim iResult As Integer

        Dim ipAddress As System.Net.IPAddress
        Dim strAddress As String

        With System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            ipAddress = New System.Net.IPAddress(.AddressList(0).Address)
            strAddress = ipAddress.ToString
            If strAddress = "127.0.0.1" Then
                iResult = 1
            Else
                iResult = 0
            End If
        End With

        If iResult = 1 Then
            '--MessageBox.Show("Testing - Not Connected")
            Return False
        Else
            '--MessageBox.Show("Testing - Connected")
            Return True
        End If
    End Function

End Class
