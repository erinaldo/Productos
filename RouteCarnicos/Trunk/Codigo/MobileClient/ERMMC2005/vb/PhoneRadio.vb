Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports OpenNETCF.Net

Public Class PhoneRadio
    Implements IDisposable

    Public Enum TipoTerminal
        SymbolMC35
        IntermecCN3
    End Enum

    Private hLine As IntPtr = IntPtr.Zero

    Private hLineApp As IntPtr = IntPtr.Zero

    Private disposed As Boolean = False

    Private _wifiRegistro As String
    Private _wifiRegistroT As TipoTerminal

    Private _estado As String = ""
    'used in lineInitializeEx function 

    Private Structure LINEINITIALIZEEXPARAMS

        Public dwTotalSize As Integer

        Public dwNeededSize As Integer

        Public dwUsedSize As Integer

        Public dwOptions As Integer

        Public hEvent As IntPtr

        Public dwCompletionKey As Integer

    End Structure

    Private Enum LINEINITIALIZEEXOPTION As Integer

        LINEINITIALIZEEXOPTION_USEHIDDENWINDOW = 1

        LINEINITIALIZEEXOPTION_USEEVENT = 2

        LINEINITIALIZEEXOPTION_USECOMPLETIONPORT = 3

    End Enum

    Private Enum LineErrReturn As UInteger

        LINE_OK = 0

        LINEERR_INVALAPPNAME = 2147483669

        LINEERR_OPERATIONFAILED = 2147483720

        LINEERR_INIFILECORRUPT = 2147483662

        LINEERR_INVALPOINTER = 2147483701

        LINEERR_REINIT = 2147483730

        LINEERR_NOMEM = 2147483716

        LINEERR_INVALPARAM = 2147483698

    End Enum



    'Used in lineNegotiateAPIVersion function 

    Private Structure LINEEXTENSIONID

        Public dwExtensionID0 As IntPtr

        Public dwExtensionID1 As IntPtr

        Public dwExtensionID2 As IntPtr

        Public dwExtensionID3 As IntPtr

    End Structure

    'Used in lineSetEquipmentState function 

    Private Enum LINEEQUIPSTATE As Integer

        LINEEQUIPSTATE_MINIMUM = 1

        LINEEQUIPSTATE_RXONLY = 2

        LINEEQUIPSTATE_TXONLY = 3

        LINEEQUIPSTATE_NOTXRX = 4

        LINEEQUIPSTATE_FULL = 5

    End Enum

    'Used in LineRegister function 

    Private Enum LINEREGMODE As Integer

        LINEREGMODE_AUTOMATIC = 1

        LINEREGMODE_MANUAL = 2

        LINEREGMODE_MANAUTO = 3

    End Enum

    Private Enum LINEOPFORMAT As Integer

        LINEOPFORMAT_NONE = 0

        LINEOPFORMAT_ALPHASHORT = 1

        LINEOPFORMAT_ALPHALONG = 2

        LINEOPFORMAT_NUMERIC = 4

    End Enum

    <DllImport("coredll.dll", SetLastError:=True)> _
    Private Shared Function lineInitializeEx(ByRef hLineApp As IntPtr, ByVal hAppHandle As IntPtr, ByVal lCallBack As IntPtr, ByVal FriendlyAppName As String, ByRef NumDevices As UInteger, ByRef APIVersion As UInteger, _
    ByRef lineExInitParams As LINEINITIALIZEEXPARAMS) As LineErrReturn
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function lineNegotiateAPIVersion(ByVal lphLineApp As IntPtr, ByVal dwDeviceID As Integer, ByVal dwAPILowVersion As Integer, ByVal dwAPIHighVersion As Integer, ByRef lpdwAPIVersion As Integer, ByRef lpExtensionID As LINEEXTENSIONID) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function lineOpen(ByVal hLineApp As IntPtr, ByVal dwDeviceID As Integer, ByRef hLine As IntPtr, ByVal dwAPIVersion As Integer, ByVal dwExtVersion As Integer, ByVal dwCallbackInstance As Integer, _
    ByVal dwPrivileges As Integer, ByVal dwMediaModes As Integer, ByVal lpCallParams As IntPtr) As Integer
    End Function

    <DllImport("cellcore.dll")> _
    Private Shared Function lineSetEquipmentState(ByVal hLine As IntPtr, ByVal dwState As Integer) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function lineClose(ByVal hLine As IntPtr) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function lineShutdown(ByVal hLine As IntPtr) As Integer
    End Function

    <DllImport("cellcore.dll")> _
    Private Shared Function lineRegister(ByVal hLine As IntPtr, ByVal dwRegisterMode As Integer, ByVal lpszOperator As String, ByVal dwOperatorFormat As Integer) As Integer

    End Function



    Public Sub New(ByVal wifiReg As TipoTerminal)
        _wifiRegistro = ""
        _wifiRegistroT = wifiReg
        Select Case (wifiReg)
            Case TipoTerminal.SymbolMC35
                _wifiRegistro = "{98C5250D-C29A-4985-AE5F-AFE5367E5006}\CF8385PN1"
            Case TipoTerminal.IntermecCN3
                _wifiRegistro = "{98C5250D-C29A-4985-AE5F-AFE5367E5006}\BCMCF1"
        End Select
        Dim dwNumDev As UInteger

        Dim dwApiVersion As UInteger = 131072

        Dim initParams As New LINEINITIALIZEEXPARAMS()

        initParams.hEvent = IntPtr.Zero

        initParams.dwTotalSize = Marshal.SizeOf(initParams)

        initParams.dwNeededSize = initParams.dwTotalSize

        initParams.dwUsedSize = initParams.dwTotalSize

        initParams.hEvent = System.IntPtr.Zero

        initParams.dwOptions = CInt(LINEINITIALIZEEXOPTION.LINEINITIALIZEEXOPTION_USEEVENT)


        Dim Ret As LineErrReturn = lineInitializeEx(hLineApp, IntPtr.Zero, IntPtr.Zero, "deltaProfile", dwNumDev, dwApiVersion, _
        initParams)

        Dim dwLineApiVersion As Integer

        Dim dummy As LINEEXTENSIONID

        Dim iRetLineNegotiateAPIVersion As Integer = lineNegotiateAPIVersion(hLineApp, 0, 65540, 131072, dwLineApiVersion, dummy)

        Dim iRetLineOpen As Integer = lineOpen(hLineApp, 0, hLine, dwLineApiVersion, 0, 0, _
        4, 16, IntPtr.Zero)

    End Sub
    Protected Overrides Sub Finalize()
        Try


            'This part of code will be called by the GC 


            Dispose(False)
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    ''' <summary> 

    ''' Will turn OFF the FlightMode profile. 

    ''' GSM signal will be immediately turned ON, while GPRS signal will take around 60 seconds 

    ''' </summary> 

    Public Sub PhoneSwitchOn()

        Dim iRetLineSetEquipmentState As Integer = lineSetEquipmentState(hLine, CInt(LINEEQUIPSTATE.LINEEQUIPSTATE_FULL))

        Dim iRetLineRegister As Integer = lineRegister(hLine, CInt(LINEREGMODE.LINEREGMODE_AUTOMATIC), Nothing, CInt(LINEOPFORMAT.LINEOPFORMAT_NONE))

    End Sub

    ''' <summary> 

    ''' Will turn ON the FlightMode profile 

    ''' </summary> 

    Public Sub PhoneSwitchOff()

        Dim iRetLineSetEquipmentState As Integer = lineSetEquipmentState(hLine, CInt(LINEEQUIPSTATE.LINEEQUIPSTATE_NOTXRX))

        'int iRetLineRegister = lineRegister(hLine, (int)LINEREGMODE.LINEREGMODE_AUTOMATIC, null, (int)LINEOPFORMAT.LINEOPFORMAT_NONE); 

    End Sub

    ''' <summary> 

    ''' Cleans up the resources used by this object. 

    ''' </summary> 

    Public Overloads Sub Dispose() Implements IDisposable.Dispose

        Dispose(True)

        ' Take off the Finalization queue 

        ' to prevent finalization code for this object 

        ' from executing a second time. 

        GC.SuppressFinalize(Me)

    End Sub

    ' Dispose(bool disposing) executes in two distinct scenarios. 

    ' If disposing equals true, the method has been called directly 

    ' or indirectly by a user's code. Managed and unmanaged resources 

    ' can be disposed. 

    ' If disposing equals false, the method has been called by the 

    ' runtime from inside the finalizer(destructor) and you should not reference 

    ' other objects. Only unmanaged resources can be disposed. 

    Protected Overloads Sub Dispose(ByVal disposing As Boolean)

        If Not Me.disposed Then


            'User-initiated dispose. Cleans up managed code. 

            If disposing Then
            End If

            lineClose(hLine)

            hLine = IntPtr.Zero

            lineShutdown(hLineApp)

            hLineApp = IntPtr.Zero


            disposed = True
        End If

    End Sub

    <DllImport("BthUtil.dll")> _
    Private Shared Function BthSetMode(ByVal dwMode As RadioMode) As Integer
    End Function

    <DllImport("BthUtil.dll")> _
    Private Shared Function BthGetMode(ByRef dwMode As RadioMode) As Integer
    End Function

    Public Sub BlueToothEstado(ByVal estado As RadioMode)
        Dim i As Integer = BthSetMode(estado)
    End Sub

    ''' Bluetooth states. 
    Public Enum RadioMode
        ''' Bluetooth off. 
        Off
        ''' Bluetooth is on but not discoverable. 
        [On]
        ''' Bluetooth is on and discoverable. 
        Discoverable
    End Enum

    Public Enum PowerState
        PwrDeviceUnspecified = -1
        D0 = 0
        ' Full On: full power, full functionality 
        D1 = 1
        ' Low Power On: fully functional at low power/performance 
        D2 = 2
        ' Standby: partially powered with automatic wake 
        D3 = 3
        ' Sleep: partially powered with device initiated wake 
        D4 = 4
        ' Off: unpowered 
        PwrDeviceMaximum = 5
    End Enum


    <DllImport("coredll")> _
    Private Shared Function SetDevicePower(ByVal pvDevice As String, ByVal Flags As Integer, ByVal state As PowerState) As Integer
    End Function

    <DllImport("coredll")> _
    Private Shared Function DevicePowerNotify(ByVal name As String, ByVal state As PowerState, ByVal flags As Integer) As Integer
    End Function

    <DllImport("coredll.dll", SetLastError:=True)> _
    Public Shared Function ActivateDevice(ByVal lpszDevKey As String, ByVal dwClientInfo As Integer) As IntPtr
    End Function

    <DllImport("Coredll.dll", EntryPoint:="ActivateDeviceEx", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Private Shared Function ActivateDeviceEx(ByVal lpszDevKey As String, ByVal lpRegEnts As IntPtr, ByVal cRegEnts As UInt32, ByVal lpvParam As IntPtr) As IntPtr
    End Function

    <DllImport("CoreDll.dll")> _
    Private Shared Function GetLastError() As Integer
    End Function

    <DllImport("coredll.dll", SetLastError:=True, CallingConvention:=CallingConvention.Winapi, CharSet:=CharSet.Auto)> _
    Public Shared Function CreateEvent(ByVal lpEventAttributes As IntPtr, <[In](), MarshalAs(UnmanagedType.Bool)> _
        ByVal bManualReset As Boolean, <[In](), MarshalAs(UnmanagedType.Bool)> _
        ByVal bIntialState As Boolean, <[In](), MarshalAs(UnmanagedType.BStr)> _
        ByVal lpName As String) As IntPtr
    End Function


    <DllImport("coredll.dll", EntryPoint:="EventModify", SetLastError:=True)> _
    Private Shared Function CEEventModify(ByVal hEvent As IntPtr, ByVal [function] As UInteger) As Integer
    End Function
    Private Enum EventFlags
        EVENT_PULSE = 1
        EVENT_RESET = 2
        EVENT_SET = 3
    End Enum
    Public Shared Function SetEvent(ByVal hEvent As IntPtr) As Boolean
        Return Convert.ToBoolean(CEEventModify(hEvent, CInt(EventFlags.EVENT_SET)))
    End Function

    Private Function getKey() As String

        Dim OurKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
        Dim subkey As String() = OurKey.OpenSubKey("System\CurrentControlSet\Control\Power\State").GetSubKeyNames()

        Return subkey.GetValue(0).ToString()
    End Function

    Public Function HabilitarWiFi() As Boolean
        Dim res As Boolean = True
        CambiarEstadoWiFi(1)
        Return res
    End Function
    Public Function DeshabilitarWiFi() As Boolean
        Dim res As Boolean = True
        CambiarEstadoWiFi(0)
        Return res
    End Function

    Private Sub CambiarEstadoWiFi(ByVal valor As Integer)
        Dim evento As IntPtr = CreateEvent(IntPtr.Zero, False, False, "StatusChangeEvent")
        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(500)
        CambiarRegis(valor)
        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(500)
        SetEvent(evento)
    End Sub
    Public Function obtenerEstadoWiFi() As Integer
        Dim valor As Integer
        If _wifiRegistroT = TipoTerminal.SymbolMC35 Then
            Dim Llave As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
            Llave = Microsoft.Win32.Registry.LocalMachine
            Llave = Llave.OpenSubKey("Drivers\BuiltIn\PCMCIA")
            valor = Convert.ToInt32(Llave.GetValue("nCF_CD"))
        Else
            valor = 1
        End If
        Return valor
    End Function

    Public Function WiFiEstaOn() As Integer
        Dim Llave As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
        Llave = Microsoft.Win32.Registry.LocalMachine
        Llave = Llave.OpenSubKey("System\CurrentControlSet\Control\Power\State")
        Dim valor As Integer = Convert.ToInt32(Llave.GetValue(_wifiRegistro))
        Return valor
    End Function
    Public Function HayWiFi() As Boolean
        Dim resul As Boolean = False
        Dim c As OpenNETCF.Net.AdapterCollection = OpenNETCF.Net.Networking.GetAdapters()
        For Each ad As OpenNETCF.Net.Adapter In c
            If (ad.IsWireless) Then
                resul = True
            End If
        Next
        Return resul
    End Function
    Public Function WiFiConectado() As Boolean
        Dim resul As Boolean = False
        Dim c As OpenNETCF.Net.AdapterCollection = OpenNETCF.Net.Networking.GetAdapters()
        For Each ad As OpenNETCF.Net.Adapter In c
            If (ad.IsWireless) Then
                Dim intervalo As Integer = 0
                Do
                    If (ad.CurrentIpAddress <> "0.0.0.0") Then
                        resul = True
                        Exit For
                    End If
                    intervalo += 1
                    System.Threading.Thread.Sleep(1000)
                Loop While resul = False And intervalo < 30
            End If
        Next
        Return resul
    End Function
    Private Function CambiarRegis(ByVal valor As Integer) As Boolean
        Dim res As Boolean = True
        Dim Llave As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
        Llave = Llave.OpenSubKey("System\CurrentControlSet\Control\Power\State", True)
        If (Not IsNothing(Llave)) Then
            Llave.SetValue(_wifiRegistro, valor)
        End If
        If _wifiRegistroT = TipoTerminal.SymbolMC35 Then
            Llave = Microsoft.Win32.Registry.LocalMachine
            Llave = Llave.OpenSubKey("Drivers\BuiltIn\PCMCIA", True)
            If (Not IsNothing(Llave)) Then
                Llave.SetValue("nCF_CD", valor)
            End If
        End If
        Return res
    End Function
    Public Function WiFiConf(ByVal Red As String, ByVal pass As String, ByVal _EAPType As OpenNETCF.Net.EAPType, ByVal _EAPFlags As OpenNETCF.Net.EAPFlags, ByVal _Enable8021x As Boolean, ByVal _AuthenticationMode As OpenNETCF.Net.AuthenticationMode, ByVal _WEPStatus As OpenNETCF.Net.WEPStatus) As Boolean
        Dim resul As Boolean = False
        Dim c As OpenNETCF.Net.AdapterCollection = OpenNETCF.Net.Networking.GetAdapters()
        For Each ad As OpenNETCF.Net.Adapter In c
            If (ad.IsWireless) Then
                Dim acc As OpenNETCF.Net.AccessPointCollection = ad.NearbyAccessPoints
                For Each ac As AccessPoint In acc
                    Try

                        ad.RemoveWirelessSettings(ac.Name)
                    Catch ex As Exception

                    End Try
                Next
                For Each ac As AccessPoint In acc
                    If (ac.Name = Red) Then
                        Dim myEAPOLParams As New OpenNETCF.Net.EAPParameters
                        myEAPOLParams.AuthData = IntPtr.Zero
                        myEAPOLParams.AuthDataLen = 0
                        myEAPOLParams.EapType = _EAPType
                        myEAPOLParams.Enable8021x = _Enable8021x
                        myEAPOLParams.EapFlags = _EAPFlags
                        Dim b As Boolean = ad.SetWirelessSettingsAddEx(ac.Name, True, pass, 1, _AuthenticationMode, _WEPStatus, myEAPOLParams)
                        resul = EsperarConexionWiFi()
                        Exit For
                    End If
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                Next
            End If
        Next
        Return resul
    End Function

    Public Function WiFi(ByVal estado As PowerState) As Boolean
        Dim resul As Boolean = False
        System.Windows.Forms.Application.DoEvents()
        Dim c As OpenNETCF.Net.AdapterCollection = OpenNETCF.Net.Networking.GetAdapters()

        DevicePowerNotify(_wifiRegistro, estado, 1)
        SetDevicePower(_wifiRegistro, 1, estado)

        If (estado = PowerState.D0 Or estado = PowerState.D1) Then
            resul = EsperarConexionWiFi()
        End If

        Return resul
    End Function

    Private Function EsperarConexionWiFi() As Boolean
        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(1000)
        Dim c As Global.OpenNETCF.Net.AdapterCollection = Global.OpenNETCF.Net.Networking.GetAdapters()
        Dim servicio As Boolean = False
        Try

            AddHandler Global.OpenNETCF.Net.AdapterStatusMonitor.NDISMonitor.AdapterNotification, AddressOf tig_Device
            Global.OpenNETCF.Net.AdapterStatusMonitor.NDISMonitor.StartStatusMonitoring()


            Dim tiempo As System.DateTime = System.DateTime.Now
            Dim intervalo As System.TimeSpan
            Do
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                If _estado = "CONECTADO" Then
                    servicio = True
                End If

                intervalo = System.DateTime.Now.Subtract(tiempo)
            Loop While servicio = False And intervalo.Seconds < 10
            If Global.OpenNETCF.Net.AdapterStatusMonitor.NDISMonitor.Active Then
                Global.OpenNETCF.Net.AdapterStatusMonitor.NDISMonitor.StopStatusMonitoring()
                RemoveHandler Global.OpenNETCF.Net.AdapterStatusMonitor.NDISMonitor.AdapterNotification, AddressOf tig_Device
            End If
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)

            servicio = False
            tiempo = System.DateTime.Now
            Do
                c = Global.OpenNETCF.Net.Networking.GetAdapters()
                For Each ad As Global.OpenNETCF.Net.Adapter In c
                    If ad.IsWireless And ad.CurrentIpAddress <> "" And ad.CurrentIpAddress <> "127.0.0.1" Then
                        If (ad.AssociatedAccessPoint <> "") Then
                            For Each ap As AccessPoint In ad.NearbyAccessPoints
                                If (ap.Name = ad.AssociatedAccessPoint) Then
                                    servicio = True
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(5000)
                                End If
                            Next
                        End If

                    End If
                Next
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                intervalo = System.DateTime.Now.Subtract(tiempo)
            Loop While servicio = False And intervalo.Seconds < 10
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        Return servicio
    End Function

    Public Sub tig_Device(ByVal o As Object, ByVal e As Global.OpenNETCF.Net.AdapterNotificationArgs)
        If (e.NotificationType = NdisNotificationType.NdisBind) Or (e.NotificationType = NdisNotificationType.NdisMediaConnect) Then
            _estado = "CONECTADO"
        End If
    End Sub

End Class

