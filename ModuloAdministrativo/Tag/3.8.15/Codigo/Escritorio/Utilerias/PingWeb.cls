VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "PingWeb"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Copyright ©1996-2011 VBnet/Randy Birch, All Rights Reserved.
' Some pages may also contain other copyrights by the author.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' Distribution: You can freely use this code in your own
'               applications, but you may not reproduce
'               or publish this code on any web site,
'               online service, or distribute as source
'               on any media without express permission.
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Const IP_SUCCESS As Long = 0
Private Const IP_STATUS_BASE As Long = 11000
Private Const IP_BUF_TOO_SMALL As Long = (IP_STATUS_BASE + 1)
Private Const IP_DEST_NET_UNREACHABLE As Long = (IP_STATUS_BASE + 2)
Private Const IP_DEST_HOST_UNREACHABLE As Long = (IP_STATUS_BASE + 3)
Private Const IP_DEST_PROT_UNREACHABLE As Long = (IP_STATUS_BASE + 4)
Private Const IP_DEST_PORT_UNREACHABLE As Long = (IP_STATUS_BASE + 5)
Private Const IP_NO_RESOURCES As Long = (IP_STATUS_BASE + 6)
Private Const IP_BAD_OPTION As Long = (IP_STATUS_BASE + 7)
Private Const IP_HW_ERROR As Long = (IP_STATUS_BASE + 8)
Private Const IP_PACKET_TOO_BIG As Long = (IP_STATUS_BASE + 9)
Private Const IP_REQ_TIMED_OUT As Long = (IP_STATUS_BASE + 10)
Private Const IP_BAD_REQ As Long = (IP_STATUS_BASE + 11)
Private Const IP_BAD_ROUTE As Long = (IP_STATUS_BASE + 12)
Private Const IP_TTL_EXPIRED_TRANSIT As Long = (IP_STATUS_BASE + 13)
Private Const IP_TTL_EXPIRED_REASSEM As Long = (IP_STATUS_BASE + 14)
Private Const IP_PARAM_PROBLEM As Long = (IP_STATUS_BASE + 15)
Private Const IP_SOURCE_QUENCH As Long = (IP_STATUS_BASE + 16)
Private Const IP_OPTION_TOO_BIG As Long = (IP_STATUS_BASE + 17)
Private Const IP_BAD_DESTINATION As Long = (IP_STATUS_BASE + 18)
Private Const IP_ADDR_DELETED As Long = (IP_STATUS_BASE + 19)
Private Const IP_SPEC_MTU_CHANGE As Long = (IP_STATUS_BASE + 20)
Private Const IP_MTU_CHANGE As Long = (IP_STATUS_BASE + 21)
Private Const IP_UNLOAD As Long = (IP_STATUS_BASE + 22)
Private Const IP_ADDR_ADDED As Long = (IP_STATUS_BASE + 23)
Private Const IP_GENERAL_FAILURE As Long = (IP_STATUS_BASE + 50)
Private Const MAX_IP_STATUS As Long = (IP_STATUS_BASE + 50)
Private Const IP_PENDING As Long = (IP_STATUS_BASE + 255)
Private Const PING_TIMEOUT As Long = 60000
Private Const WS_VERSION_REQD As Long = &H101
Private Const MIN_SOCKETS_REQD As Long = 1
Private Const SOCKET_ERROR As Long = -1
Private Const INADDR_NONE As Long = &HFFFFFFFF
Private Const MAX_WSADescription As Long = 256
Private Const MAX_WSASYSStatus As Long = 128

Private Type WSADATA
   wVersion As Integer
   wHighVersion As Integer
   szDescription(0 To MAX_WSADescription) As Byte
   szSystemStatus(0 To MAX_WSASYSStatus) As Byte
   wMaxSockets As Long
   wMaxUDPDG As Long
   dwVendorInfo As Long
End Type

Private Type ICMP_OPTIONS
   Ttl             As Byte
   Tos             As Byte
   Flags           As Byte
   OptionsSize     As Byte
   OptionsData     As Long
End Type

Private Type ICMP_ECHO_REPLY
   Address         As Long
   status          As Long
   RoundTripTime   As Long
   DataSize        As Long
  'Reserved        As Integer
   DataPointer     As Long
   Options         As ICMP_OPTIONS
   Data            As String * 250
End Type

Private Declare Function gethostbyname Lib "wsock32" _
  (ByVal hostname As String) As Long
  
Private Declare Sub CopyMemory Lib "kernel32" _
   Alias "RtlMoveMemory" _
  (xDest As Any, _
   xSource As Any, _
   ByVal nbytes As Long)

Private Declare Function lstrlenA Lib "kernel32" _
  (lpString As Any) As Long

Private Declare Function WSAStartup Lib "wsock32" _
   (ByVal wVersionRequired As Long, _
    lpWSADATA As WSADATA) As Long
    
Private Declare Function WSACleanup Lib "wsock32" () As Long

Private Declare Function IcmpCreateFile Lib "icmp.dll" () As Long

Private Declare Function IcmpCloseHandle Lib "icmp.dll" _
   (ByVal IcmpHandle As Long) As Long
   
Private Declare Function IcmpSendEcho Lib "icmp.dll" _
   (ByVal IcmpHandle As Long, _
    ByVal DestinationAddress As Long, _
    ByVal RequestData As String, _
    ByVal RequestSize As Long, _
    ByVal RequestOptions As Long, _
    ReplyBuffer As ICMP_ECHO_REPLY, _
    ByVal ReplySize As Long, _
    ByVal Timeout As Long) As Long
    
Private Declare Function inet_addr Lib "wsock32" _
   (ByVal s As String) As Long
   
Private Declare Function inet_ntoa Lib "wsock32.dll" _
  (ByVal addr As Long) As Long

Private Declare Function lstrcpyA Lib "kernel32" _
  (ByVal RetVal As String, _
   ByVal Ptr As Long) As Long
   


'Private Sub Form_Load()
'
'   Text1.Text = "www.yahoo.com"
'   Text2.Text = ""
'   Text3.Text = "Echo this"
'
'End Sub


'Private Sub Command1_Click()
'
'   Dim ECHO As ICMP_ECHO_REPLY
'   Dim pos As Long
'   Dim success As Long
'   Dim sIPAddress As String
'
'   If SocketsInitialize() Then
'
'     'convert the host name into an IP address
'      sIPAddress = GetIPFromHostName(Text1.Text)
'      Text2.Text = sIPAddress
'
'     'ping the ip passing the address, text
'     'to use, and the ECHO structure
'      success = Ping(sIPAddress, (Text3.Text), ECHO)
'
'     'display the results
'      Text4(0).Text = GetStatusCode(success)
'      Text4(1).Text = ECHO.Address
'      Text4(2).Text = ECHO.RoundTripTime & " ms"
'      Text4(3).Text = ECHO.DataSize & " bytes"
'
'      If Left$(ECHO.Data, 1) <> Chr$(0) Then
'         pos = InStr(ECHO.Data, Chr$(0))
'         Text4(4).Text = Left$(ECHO.Data, pos - 1)
'      End If
'
'      Text4(5).Text = ECHO.DataPointer
'
'      SocketsCleanup
'
'   Else
'        MsgBox "Windows Sockets for 32 bit Windows " & _
'               "is not successfully responding."
'   End If
'
'End Sub


Private Function Ping(sAddress As String, _
                      sDataToSend As String, _
                      ECHO As ICMP_ECHO_REPLY) As Long

  'If Ping succeeds :
  '.RoundTripTime = time in ms for the ping to complete,
  '.Data is the data returned (NULL terminated)
  '.Address is the IP address that actually replied
  '.DataSize is the size of the string in .Data
  '.Status will be 0
  '
  'If Ping fails .Status will be the error code
   
   Dim hPort As Long
   Dim dwAddress As Long
   
  'convert the address into a long representation
   dwAddress = inet_addr(sAddress)
   
  'if dwAddress is valid
   If dwAddress <> INADDR_NONE Then
   
     'open a port
      hPort = IcmpCreateFile()
      
     'and if successful,
      If hPort Then
      
        'ping it.
         Call IcmpSendEcho(hPort, _
                           dwAddress, _
                           sDataToSend, _
                           Len(sDataToSend), _
                           0, _
                           ECHO, _
                           Len(ECHO), _
                           PING_TIMEOUT)

        'return the status as ping success
         Ping = ECHO.status

        'close the port handle
         Call IcmpCloseHandle(hPort)
      
      End If  'If hPort
      
   Else
   
        'the address format was probably invalid
         Ping = INADDR_NONE
         
   End If
  
End Function


Private Function GetStatusCode(status As Long) As String

   Dim msg As String
   
   Select Case status
      Case IP_SUCCESS:               msg = "ip success"
      Case INADDR_NONE:              msg = "inet_addr: bad IP format"
      Case IP_BUF_TOO_SMALL:         msg = "ip buf too_small"
      Case IP_DEST_NET_UNREACHABLE:  msg = "ip dest net unreachable"
      Case IP_DEST_HOST_UNREACHABLE: msg = "ip dest host unreachable"
      Case IP_DEST_PROT_UNREACHABLE: msg = "ip dest prot unreachable"
      Case IP_DEST_PORT_UNREACHABLE: msg = "ip dest port unreachable"
      Case IP_NO_RESOURCES:          msg = "ip no resources"
      Case IP_BAD_OPTION:            msg = "ip bad option"
      Case IP_HW_ERROR:              msg = "ip hw_error"
      Case IP_PACKET_TOO_BIG:        msg = "ip packet too_big"
      Case IP_REQ_TIMED_OUT:         msg = "ip req timed out"
      Case IP_BAD_REQ:               msg = "ip bad req"
      Case IP_BAD_ROUTE:             msg = "ip bad route"
      Case IP_TTL_EXPIRED_TRANSIT:   msg = "ip ttl expired transit"
      Case IP_TTL_EXPIRED_REASSEM:   msg = "ip ttl expired reassem"
      Case IP_PARAM_PROBLEM:         msg = "ip param_problem"
      Case IP_SOURCE_QUENCH:         msg = "ip source quench"
      Case IP_OPTION_TOO_BIG:        msg = "ip option too_big"
      Case IP_BAD_DESTINATION:       msg = "ip bad destination"
      Case IP_ADDR_DELETED:          msg = "ip addr deleted"
      Case IP_SPEC_MTU_CHANGE:       msg = "ip spec mtu change"
      Case IP_MTU_CHANGE:            msg = "ip mtu_change"
      Case IP_UNLOAD:                msg = "ip unload"
      Case IP_ADDR_ADDED:            msg = "ip addr added"
      Case IP_GENERAL_FAILURE:       msg = "ip general failure"
      Case IP_PENDING:               msg = "ip pending"
      Case PING_TIMEOUT:             msg = "ping timeout"
      Case Else:                     msg = "unknown  msg returned"
   End Select
   
   GetStatusCode = CStr(status) & "   [ " & msg & " ]"
   
End Function


Private Function GetIPFromHostName(ByVal sHostName As String) As String

  'converts a host name to an IP address
   Dim ptrHosent As Long  'address of HOSENT structure
   Dim ptrName As Long    'address of name pointer
   Dim ptrAddress As Long 'address of address pointer
   Dim ptrIPAddress As Long
   Dim ptrIPAddress2 As Long

    sHostName = RemoverProtocoloPuerto(sHostName)

   ptrHosent = gethostbyname(sHostName & vbNullChar)

   If ptrHosent <> 0 Then

     'assign pointer addresses and offset
     
     'ptrName is the official name of the host (PC).
     'If using the DNS or similar resolution system,
     'it is the Fully Qualified Domain Name (FQDN)
     'that caused the server to return a reply.
     'If using a local hosts file, it is the first
     'entry after the IP address.
      ptrName = ptrHosent
      
     'Null-terminated list of addresses for the host.
     'The Address is offset 12 bytes from the start of
     'the HOSENT structure. Note: Here we are retrieving
     'only the first address returned. To return more than
     'one, define sAddress as a string array and loop through
     'the 4-byte ptrIPAddress members returned. The last
     'item is a terminating null. All addresses are returned
     'in network byte order.
      ptrAddress = ptrHosent + 12
      
     'get the IP address
      CopyMemory ptrName, ByVal ptrName, 4
      CopyMemory ptrAddress, ByVal ptrAddress, 4
      CopyMemory ptrIPAddress, ByVal ptrAddress, 4
      CopyMemory ptrIPAddress2, ByVal ptrIPAddress, 4

      GetIPFromHostName = GetInetStrFromPtr(ptrIPAddress2)

   End If
   
End Function

Private Function RemoverProtocoloPuerto(ByVal url As String) As String
    Dim sTemp As String
    url = RemoverProtocolo(url, "ftp://")
    url = RemoverProtocolo(url, "http://")
    url = RemoverProtocolo(url, "https://")
    url = RemoverPuerto(url)
    RemoverProtocoloPuerto = url
End Function

Private Function RemoverProtocolo(ByVal url As String, ByVal protocolo As String) As String
    Dim sTemp As String
    If Len(url) >= Len(protocolo) Then
        sTemp = Left(url, Len(protocolo))
        If UCase(sTemp) = UCase(protocolo) Then
            url = Mid(url, Len(protocolo) + 1)
        End If
    End If
    RemoverProtocolo = url
End Function
Private Function RemoverPuerto(ByVal url As String) As String
    Dim iTemp As Integer
    iTemp = InStr(url, ":")
    If iTemp <> 0 Then
        url = Mid(url, 1, iTemp - 1)
    End If
    RemoverPuerto = url
End Function



Private Function GetStrFromPtrA(ByVal lpszA As Long) As String

   GetStrFromPtrA = String$(lstrlenA(ByVal lpszA), 0)
   Call lstrcpyA(ByVal GetStrFromPtrA, ByVal lpszA)
   
End Function


Private Function GetInetStrFromPtr(Address As Long) As String
  
   GetInetStrFromPtr = GetStrFromPtrA(inet_ntoa(Address))

End Function


Private Sub SocketsCleanup()
   
   If WSACleanup() <> 0 Then
       MsgBox "Windows Sockets error occurred in Cleanup.", vbExclamation
   End If
    
End Sub


Private Function SocketsInitialize() As Boolean

   Dim WSAD As WSADATA
   
   SocketsInitialize = WSAStartup(WS_VERSION_REQD, WSAD) = IP_SUCCESS
    
End Function


Public Function RealizarPing(url As String, ByRef mensaje As String) As Boolean
   
   Dim ECHO As ICMP_ECHO_REPLY
   Dim pos As Long
   Dim success As Long
   Dim regreso As Boolean
   regreso = False
   Dim sIPAddress As String
   If SocketsInitialize() Then
   
    'convert the host name into an IP address
    sIPAddress = GetIPFromHostName(url)
   
     'ping the IP by passing the address,
     'text to send, and the ECHO structure.
      success = Ping(sIPAddress, "eco", ECHO)
      If success = IP_SUCCESS Then
        regreso = True
      End If
     'display the results
      mensaje = GetStatusCode(success)
      'direccion ECHO.Address
      'tiempo de viaje ECHO.RoundTripTime & " ms"
      'tamaño de datos ECHO.DataSize & " bytes"
      
      'Info de regreso
      'If Left$(ECHO.Data, 1) <> Chr$(0) Then
      '   pos = InStr(ECHO.Data, Chr$(0))
      '   Text3(4).Text = Left$(ECHO.Data, pos - 1)
      'End If
   
      'Data Pointer ECHO.DataPointer
      
      SocketsCleanup
      
   Else
   
        MsgBox "Windows Sockets for 32 bit Windows " & _
               "environments is not successfully responding."
   
   End If
   RealizarPing = regreso
End Function




