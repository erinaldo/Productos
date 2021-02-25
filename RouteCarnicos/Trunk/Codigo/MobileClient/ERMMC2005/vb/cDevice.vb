Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.VisualBasic

Public Class CDevice

#Region "API GetSerial Number"
    Declare Function KernelIoControl Lib "CoreDll.dll" _
            (ByVal dwIoControlCode As Int32, _
            ByVal lpInBuf As IntPtr, _
            ByVal nInBufSize As Int32, _
            ByVal lpOutBuf() As Byte, _
            ByVal nOutBufSize As Int32, _
            ByRef lpBytesReturned As Int32) As Boolean

    Private Declare Function KernelIoControl Lib "coredll.dll" (ByVal dwIoControlCode As Integer, ByVal lpInBuf As IntPtr, ByVal nInBufSize As Integer, ByVal lpOutBuf As IntPtr, ByVal nOutBufSize As Integer, ByRef lpBytesReturned As Integer) As Integer

    Private Declare Sub SetCleanRebootFlag Lib "coredll.dll" ()

    Private Shared METHOD_BUFFERED As Int32 = 0
    Private Shared FILE_ANY_ACCESS As Int32 = 0
    Private Shared FILE_DEVICE_HAL As Int32 = &H101

    Private Const ERROR_NOT_SUPPORTED As Int32 = &H32
    Private Const ERROR_INSUFFICIENT_BUFFER As Int32 = &H7A

    Private Shared IOCTL_HAL_GET_DEVICEID As Int32 = _
        (&H10000 * FILE_DEVICE_HAL) Or (&H4000 * FILE_ANY_ACCESS) _
        Or (&H4 * 21) Or METHOD_BUFFERED

    Public Shared Function GetDeviceID() As String

        ' Initialize the output buffer to the size of a
        ' Win32 DEVICE_ID structure
        Dim outbuff(19) As Byte
        Dim dwOutBytes As Int32
        Dim done As Boolean = False

        Dim nBuffSize As Int32 = outbuff.Length

        ' Set DEVICEID.dwSize to size of buffer.  Some platforms look at
        ' this field rather than the nOutBufSize param of KernelIoControl
        ' when determining if the buffer is large enough.
        BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0)
        dwOutBytes = 0

        ' Loop until the device ID is retrieved or an error occurs.
        While Not done
            If KernelIoControl(IOCTL_HAL_GET_DEVICEID, IntPtr.Zero, _
                0, outbuff, nBuffSize, dwOutBytes) Then
                done = True
            Else
                Dim errnum As Integer = Marshal.GetLastWin32Error()
                Select Case errnum
                    Case ERROR_NOT_SUPPORTED
                        Throw New NotSupportedException( _
                            "IOCTL_HAL_GET_DEVICEID is not supported on this device", _
                            New Win32Exception(errnum))

                    Case ERROR_INSUFFICIENT_BUFFER

                        ' The buffer is not big enough for the data.  The
                        ' required size is in the first 4 bytes of the output
                        ' buffer (DEVICE_ID.dwSize).
                        nBuffSize = BitConverter.ToInt32(outbuff, 0)
                        outbuff = New Byte(nBuffSize) {}

                        ' Set DEVICEID.dwSize to size of buffer.  Some
                        ' platforms look at this field rather than the
                        ' nOutBufSize param of KernelIoControl when
                        ' determining if the buffer is large enough.
                        BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0)

                    Case Else
                        Throw New Win32Exception(errnum, "Unexpected error")
                End Select
            End If
        End While

        ' Copy the elements of the DEVICE_ID structure.
        Dim dwPresetIDOffset As Int32 = BitConverter.ToInt32(outbuff, &H4)
        Dim dwPresetIDSize As Int32 = BitConverter.ToInt32(outbuff, &H8)
        Dim dwPlatformIDOffset As Int32 = BitConverter.ToInt32(outbuff, &HC)
        Dim dwPlatformIDSize As Int32 = BitConverter.ToInt32(outbuff, &H10)
        Dim sb As New StringBuilder
        Dim i As Integer
        For i = dwPresetIDOffset To (dwPresetIDOffset + dwPresetIDSize) - 1
            sb.Append(String.Format("{0:X2}", outbuff(i)))
        Next i

        sb.Append("-")

        For i = dwPlatformIDOffset To (dwPlatformIDOffset + dwPlatformIDSize) - 1
            sb.Append(String.Format("{0:X2}", outbuff(i)))
        Next i

#If MOD_TERM = "HHP" Or MOD_TERM = "HHPWM6" Then
#If SO_WCE = 0 And MOD_TERM = "HHP" Then
        Return sb.ToString()
#Else
        Dim aSerial As String()
        aSerial = sb.ToString.Split("-")
        Return (aSerial(0) & "-" & HANDHELD.CTerminal.NumeroSerie)
#End If
#Else
        Return sb.ToString()
#End If

    End Function

    Public Shared Function CTL_CODE( _
  ByVal DeviceType As Integer, _
  ByVal Func As Integer, _
  ByVal Method As Integer, _
  ByVal Access As Integer) As Integer

        Return (DeviceType << 16) Or (Access << 14) Or (Func << 2) Or Method

    End Function

#End Region

    Public Shared Sub SoftReset()
        Dim bytesReturned As Integer = 0
        Dim IOCTL_HAL_REBOOT As Integer = CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS)
        KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, bytesReturned)
    End Sub

    Public ReadOnly Property DeviceName()
        Get
            Return System.Net.Dns.GetHostName()
        End Get
    End Property

End Class