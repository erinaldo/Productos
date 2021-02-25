Imports System.Runtime.InteropServices

Public Class FSEngine

#Region " WIN32API Function Prototype Declaration "

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Const SPI_SETWORKAREA As Integer = 47
    Private Const SPI_GETWORKAREA As Integer = 48
    Private Const SPIF_UPDATEINIFILE As Integer = &H1

    <DllImport("coredll.dll")> _
    Private Shared Function FindWindowW( _
       ByVal lpClassName As String _
       , ByVal lpWindowName As String _
       ) As IntPtr
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function MoveWindow( _
       ByVal hWnd As IntPtr _
       , ByVal X As Integer _
       , ByVal Y As Integer _
       , ByVal nWidth As Integer _
       , ByVal nHeight As Integer _
       , ByVal bRepaint As Integer _
       ) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function SetRect( _
       ByRef lprc As RECT _
       , ByVal xLeft As Integer _
       , ByVal yTop As Integer _
       , ByVal xRight As Integer _
       , ByVal yBottom As Integer _
       ) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Public Shared Function GetWindowRect( _
       ByVal hWnd As IntPtr _
       , ByRef lpRect As RECT _
       ) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function SystemParametersInfo( _
       ByVal uiAction As Integer _
       , ByVal uiParam As Integer _
       , ByRef pvParam As RECT _
       , ByVal fWinIni As Integer _
       ) As Integer
    End Function
#End Region

#Region " Full Screen Engine Intenal Variable Declaration "
    Private hWndInputPanel As IntPtr
    Private hWndSipButton As IntPtr
    Private hWndTaskBar As IntPtr

    Private rtDesktop As RECT
    Private rtNewDesktop As RECT
    Private rtInputPanel As RECT
    Private rtSipButton As RECT
    Private rtTaskBar As RECT
#End Region

    Public Function InitFullScreen() As Integer

        '// Declare & Instatiate local variable
        Dim Result As Integer = 0

        Try
            If SystemParametersInfo(SPI_GETWORKAREA, 0, rtDesktop, vbNullString) = 1 Then
                '// Successful obtain the system working area (Desktop)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                SetRect(rtNewDesktop, 0, 0, 480, 640)
#Else
                SetRect(rtNewDesktop, 0, 0, 240, 320)
#End If
            End If

            '// Find the Input panel window handle
            hWndInputPanel = FindWindowW("SipWndClass", vbNullString)
            '// Checking...
            If hWndInputPanel.ToInt64 <> 0 Then
                '// Get the original Input panel window size
                GetWindowRect(hWndInputPanel, rtInputPanel)
            End If

            '// Find the SIP Button window handle
            hWndSipButton = FindWindowW("MS_SIPBUTTON", vbNullString)
            '// Checking...
            If hWndSipButton.ToInt64 <> 0 Then
                '// Get the original Input panel window size
                GetWindowRect(hWndSipButton, rtSipButton)
            End If

            '// Find the Taskbar window handle
            hWndTaskBar = FindWindowW("HHTaskBar", vbNullString)
            '// Checking...
            If hWndTaskBar.ToInt64 <> 0 Then
                '// Get the original Input panel window size
                GetWindowRect(hWndTaskBar, rtTaskBar)
            End If

        Catch ex As Exception

            '// PUT YOUR ERROR LOG CODING HERE

            '// Set return value
            Result = 1

        End Try

        '// Return result code
        Return Result

    End Function

    Public Function DoFullScreen(ByVal mode As Boolean) As Integer

        '// Declare & Instatiate local variable
        Dim Result As Integer = 0

        Try

            If mode = True Then
                '// Update window working area size
                SystemParametersInfo(SPI_SETWORKAREA, 0, rtNewDesktop, SPIF_UPDATEINIFILE)

                If hWndTaskBar.ToInt64 <> 0 Then
                    '// Hide the TaskBar
                    MoveWindow(hWndTaskBar, _
                                0, _
                                rtNewDesktop.Bottom, _
                                rtTaskBar.Right - rtTaskBar.Left, _
                                rtTaskBar.Bottom - rtTaskBar.Top, _
                                False)
                End If

                'If hWndInputPanel.ToInt64 <> 0 Then
                '    '// Reposition the input panel 
                '    MoveWindow(hWndInputPanel, _
                '                0, _
                '                rtNewDesktop.Bottom - (rtInputPanel.Bottom - rtInputPanel.Top), _
                '                rtInputPanel.Right - rtInputPanel.Left, _
                '                rtInputPanel.Bottom - rtInputPanel.Top, _
                '                False)
                'End If

                'If hWndSipButton.ToInt64 <> 0 Then
                '    '// Hide the SIP button 
                '    MoveWindow(hWndSipButton, _
                '                0, _
                '                rtNewDesktop.Bottom, _
                '                rtSipButton.Right - rtSipButton.Left, _
                '                rtSipButton.Bottom - rtSipButton.Top, _
                '                False)
                'End If
            Else
                '// Update window working area size
                SystemParametersInfo(SPI_SETWORKAREA, 0, rtDesktop, SPIF_UPDATEINIFILE)

                '// Restore the TaskBar
                If hWndTaskBar.ToInt64 <> 0 Then
                    MoveWindow(hWndTaskBar, _
                                rtTaskBar.Left, _
                                rtTaskBar.Top, _
                                rtTaskBar.Right - rtTaskBar.Left, _
                                rtTaskBar.Bottom - rtTaskBar.Top, _
                                False)
                End If

                ''// Restore the input panel
                'If hWndInputPanel.ToInt64 <> 0 Then
                '    MoveWindow(hWndInputPanel, _
                '                rtInputPanel.Left, _
                '                rtDesktop.Bottom - (rtInputPanel.Bottom - rtInputPanel.Top) - (rtTaskBar.Bottom - rtTaskBar.Top), _
                '                rtInputPanel.Right - rtInputPanel.Left, _
                '                rtInputPanel.Bottom - rtInputPanel.Top, _
                '                False)
                'End If

                'If hWndSipButton.ToInt64 <> 0 Then
                '    '// Restore the SIP button 
                '    MoveWindow(hWndSipButton, _
                '                rtSipButton.Left, _
                '                rtSipButton.Top, _
                '                rtSipButton.Right - rtSipButton.Left, _
                '                rtSipButton.Bottom - rtSipButton.Top, _
                '                False)
                'End If
            End If

        Catch ex As Exception

            '// PUT YOUR ERROR LOG CODING HERE

            '// Set return value
            Result = 1

        End Try

        '// Return result code
        Return Result

    End Function

End Class
