' --------------------------------------------------------------------
'  FILENAME: Conn.cs
' 
'  Copyright(c) 2005 Symbol Technologies Inc. All rights reserved.
' 
'  DESCRIPTION:		This file provides wrapper calls for using.
' 					connection manager.
' 
'  NOTES:			Refer to the readme.txt file for a description 
' 					of using this file to create a WAN application.
' --------------------------------------------------------------------

' ------------------------------------------------------------------------------------
' 		I M P O R T A N T   D I S C L A I M E R
' 
'  This Software comes "as is", with no warranties. None whatsoever. This means no 
'  express, implied or statutory warranty, including without limitation, warranties 
'  of merchantability or fitness for a particular purpose or any warranty of title 
'  or non-infringement. Also, you must pass this disclaimer on whenever you 
'  distribute the Software or derivative works. 

'  Neither Symbol nor any contributor to the Software will be liable for any of 
'  those types of damages known as indirect, special, consequential, or incidental 
'  related to the Software or this license, to the maximum extent the law permits, 
'  no matter what legal theory it’s based on. Also, you must pass this limitation of 
'  liability on whenever you distribute the Software or derivative works. 
' ------------------------------------------------------------------------------------
Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Diagnostics

namespace WANSample
    Public Class Conn
        Implements IDisposable

#Region "IDisposable requirements"
        ''' <summary>
        ''' Boolean used to indicate if the object has been disposed
        ''' </summary>
        Private bDisposed As Boolean = False

        ' Use C# destructor syntax for finalization code.
        ' This destructor will run only if the Dispose method 
        ' does not get called.
        ' It gives your base class the opportunity to finalize.
        ' Do not provide destructors in types derived from this class.
        Protected Overrides Sub Finalize()
            ' Do not re-create Dispose clean-up code here.
            ' Calling Dispose() is optimal in terms of
            ' readability and maintainability.
            Dispose()
        End Sub


        ''' <summary>
        ''' Releases the resources used by the object.
        ''' </summary>
        Sub Dispose() Implements IDisposable.Dispose
            If (Not bDisposed) Then
                bDisposed = True

                ' SupressFinalize to take this object off the finalization queue 
                ' and prevent finalization code for this object from executing a second time.
                GC.SuppressFinalize(Me)
            End If
        End Sub

#End Region ' IDisposable requirements

#Region "CONN enums, classes, structs"

        Public Enum CONNECTIONPRIORITY As Integer
            Voice = &H20000
            UserInteractive = &H8000
            UserBackground = &H2000
            UserIdle = &H800
            HighPriorityBackground = &H200
            IdleBackground = &H80
            ExternalInteractive = &H20
            LowBackground = &H8
            Cached = &H2
        End Enum
        Public Enum CONNECTIONSTATUS As Integer
            CONNMGR_STATUS_UNKNOWN = &H0                    '  Unknown status
            CONNMGR_STATUS_CONNECTED = &H10                 '  Connection is up
            CONNMGR_STATUS_DISCONNECTED = &H20              '  Connection is disconnected
            CONNMGR_STATUS_CONNECTIONFAILED = &H21          '  Connection failed and cannot not be reestablished
            CONNMGR_STATUS_CONNECTIONCANCELED = &H22        '  User aborted connection
            CONNMGR_STATUS_CONNECTIONDISABLED = &H23        '  Connection is ready to connect but disabled
            CONNMGR_STATUS_NOPATHTODESTINATION = &H24       '  No path could be found to destination
            CONNMGR_STATUS_WAITINGFORPATH = &H25            '  Waiting for a path to the destination
            CONNMGR_STATUS_WAITINGFORPHONE = &H26           '  Voice call is in progress
            CONNMGR_STATUS_WAITINGCONNECTION = &H40         '  Attempting to connect
            CONNMGR_STATUS_WAITINGFORRESOURCE = &H41        '  Resource is in use by another connection
            CONNMGR_STATUS_WAITINGFORNETWORK = &H42         '  No path could be found to destination
            CONNMGR_STATUS_WAITINGDISCONNECTION = &H80      '  Connection is being brought down
            CONNMGR_STATUS_WAITINGCONNECTIONABORT = &H81    '  Aborting connection attempt
        End Enum

        Friend Structure CONNMGR_DESTINATION_INFO
            Public guid As Guid
            Public szDescription As String
        End Structure
        
        Friend Structure CONNMGR_CONNECTIONINFO
            Public cbSize As Integer
            Public dwParams As Integer
            Public dwFlags As Integer
            Public dwPriority As Integer
            Public bExclusive As Boolean
            Public bDisabled As Boolean
            Public guidDestNet As Guid
            Public hWnd As IntPtr
            Public uMsg As Integer
            Public lParam As Integer
            Private ulMaxCost As Integer
            Private ulMinRcvBw As Integer
            Private ulMaxConnLatency As Integer

            ''' <summary>
            ''' Writes the ConnectionInfo data to unmanaged memory.
            ''' </summary>
            ''' <returns>A pointer to the unmanaged memory block storing the ConnectionInfo data</returns>
            Public Function StructureToPtr() As IntPtr
                ulMaxCost = 0
                ulMinRcvBw = 0
                ulMaxConnLatency = 0
                Dim offset As Integer = 0
                Dim ptr As IntPtr = myCommon.AllocHGlobal(Marshal.SizeOf(GetType(CONNMGR_CONNECTIONINFO)))
                If ptr = IntPtr.Zero Then
                    Return ptr
                End If
                Marshal.WriteInt32(ptr, offset, Me.cbSize)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.dwParams)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.dwFlags)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.dwPriority)
                offset += Marshal.SizeOf(GetType(Integer))
                WriteBool(ptr, offset, Me.bExclusive)
                offset += Marshal.SizeOf(GetType(Integer))
                WriteBool(ptr, offset, Me.bDisabled)
                offset += Marshal.SizeOf(GetType(Integer))
                WriteByteArray(ptr, offset, Me.guidDestNet.ToByteArray)
                offset += Marshal.SizeOf(GetType(Guid))
                Marshal.WriteInt32(ptr, offset, Me.hWnd.ToInt32)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.uMsg)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.lParam)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.ulMaxCost)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.ulMinRcvBw)
                offset += Marshal.SizeOf(GetType(Integer))
                Marshal.WriteInt32(ptr, offset, Me.ulMaxConnLatency)
                Return ptr
            End Function

            Public Shared Sub WriteBool(ByVal ptr As IntPtr, ByVal offset As Integer, ByVal val As Boolean)
                Dim data As Byte() = BitConverter.GetBytes(val)
                Marshal.Copy(data, 0, New IntPtr(ptr.ToInt32 + offset), data.Length)
            End Sub

            Public Shared Sub WriteByteArray(ByVal ptr As IntPtr, ByVal offset As Integer, ByVal val As Byte())
                Marshal.Copy(val, 0, New IntPtr(ptr.ToInt32 + offset), val.Length)
            End Sub

            ''' <summary>
            ''' Disposes of the ConnectionInfo object.
            ''' </summary>
            Public Sub Dispose(ByVal ptr As IntPtr)
                myCommon.FreeHGlobal(ptr)
                ptr = IntPtr.Zero
            End Sub

        End Structure

        Public Structure CONNCURRENTDEVICE
            Public connHandle As IntPtr
        End Structure

#End Region '//CONN enums, classes, structs


#Region "Declarations"

        Private conCurrentDevice As CONNCURRENTDEVICE
        Private Shared myCommon As WANSample.Common

#End Region ' Declarations

#Region "CONN low level calls"

        Public Function CONN_IsConnected() As Integer
            Dim thisConnectionStatus As Integer = CType(CONNECTIONSTATUS.CONNMGR_STATUS_UNKNOWN, Integer)
            ConnMgrConnectionStatus(conCurrentDevice.connHandle, thisConnectionStatus)
            Return thisConnectionStatus
        End Function

        Public Function RetriveDestinations() As Boolean
            '// Enumerate Destinations
            Dim nIndex As Integer = 0
            Dim hr As Long = 0


            Dim DestInfo As New CONNMGR_DESTINATION_INFO
            MsgBox("Aqui1")

            While (hr = 0)

                hr = ConnMgrEnumDestinations(nIndex, DestInfo)
                MsgBox(DestInfo)
                MsgBox("Aqui2")
                'MsgBox(DestInfo.szDescription)

                nIndex += 1

            End While


        End Function


        Public Function CONN_Connect(ByVal Guid As Guid) As Integer
            Const CONNMGR_PARAM_GUIDDESTNET As Integer = (&H1)
            Const WM_APP_CONNMGR As Integer = &H400 + 0
            Const CONNMGR_CONNECTION_TIMEOUT_MSECS As Integer = 60000
            Dim uConnectionStatus As Integer = CONNECTIONSTATUS.CONNMGR_STATUS_UNKNOWN
            Dim thisConnectionInfo As CONNMGR_CONNECTIONINFO = New CONNMGR_CONNECTIONINFO
            thisConnectionInfo.cbSize = Marshal.SizeOf(thisConnectionInfo)
            thisConnectionInfo.dwParams = CONNMGR_PARAM_GUIDDESTNET
            thisConnectionInfo.dwPriority = CType(CONNECTIONPRIORITY.Voice, Integer)
            thisConnectionInfo.dwFlags = 0
            thisConnectionInfo.bExclusive = True
            thisConnectionInfo.bDisabled = False

            Dim IID_DestNetInternet As Guid = Guid
            thisConnectionInfo.guidDestNet = IID_DestNetInternet
            thisConnectionInfo.hWnd = IntPtr.Zero
            thisConnectionInfo.uMsg = WM_APP_CONNMGR
            thisConnectionInfo.lParam = 0
            myCommon = New WANSample.Common

            Dim pConnectionInfo As IntPtr = thisConnectionInfo.StructureToPtr

            ConnMgrEstablishConnectionSync(pConnectionInfo, conCurrentDevice.connHandle, CONNMGR_CONNECTION_TIMEOUT_MSECS, uConnectionStatus)

            thisConnectionInfo.Dispose(pConnectionInfo)
            Return uConnectionStatus
        End Function

        Public Sub CONN_Disconnect()
            ConnMgrReleaseConnection(conCurrentDevice.connHandle, 0)
            'Convert.ToInt32(False)
            conCurrentDevice.connHandle = IntPtr.Zero
        End Sub

#End Region         ' CONN Low Level Calls

#Region "P/Invoke API Calls"

        <DllImport("cellcore.dll")> Friend Shared Function ConnMgrEnumDestinations(ByVal DestIndex As Integer, ByRef DestInfo As CONNMGR_DESTINATION_INFO) As Integer
        End Function
      

        <DllImport("cellcore.dll")> _
        Friend Shared Function ConnMgrConnectionStatus(ByVal hConnection As IntPtr, ByRef pdwStatus As Integer) As Integer
        End Function

        <DllImport("cellcore.dll")> _
        Friend Shared Function ConnMgrEstablishConnectionSync(ByVal pConnInfo As IntPtr, ByRef phConnection As IntPtr, ByVal dwTimeout As Integer, ByRef dwStatus As Integer) As Integer
        End Function

        <DllImport("cellcore.dll")> _
        Friend Shared Sub ConnMgrReleaseConnection(ByVal hConnection As IntPtr, ByVal bCache As Integer)
        End Sub
#End Region ' P/Invoke API Calls

    End Class
End Namespace