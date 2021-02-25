Imports System.IO
Imports System.Runtime.InteropServices

'    For a standard cash drawer, there's a physical cable that runs from the cash drawer and plugs into the receipt printer.  
'•    To open the drawer, you issue a command to the printer. The printer will send a signal to the cash drawer that kicks open the drawer.  
'•    For a standard epson receipt printer such as the Epson TM-T88III receipt printer, the command is: 
'fwrite($handle, chr(27). chr(112). chr(0). chr(100). chr(250));  
'•    For other receipt printers, you should be able to find the command in their user's manual. (Try the above code first. Most probably it will work. Receipt printers have been in existence for a long time. They have more or less adopted the same standard.)  
'•    A standard receipt printer such as the Epson TM-T88III receipt printer uses the parallel port.  
'•    To print to the parallel-port receipt printer, you print through port PRN (exactly the same as printing from DOS prompt).  
'•    From within PHP-GTK2, you need to first establish the connection with the printer by using  
'$handle = fopen("PRN", "w");  
'•    Thereafter, to print anything to the printer, you just "write" to it like the file handle: fwrite($handle, 'text to printer');  
'•    There are newer receipt printer that uses USB. I believe you should be able to print to such printers through PRN too.  
'

Public Class RawPrinterHelper
    ' Structure and API declarions: 
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Class DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDataType As String
    End Class
    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, <[In](), MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function
    <DllImport("kernel32.dll", EntryPoint:="GetLastError", SetLastError:=False, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function GetLastError() As Int32
    End Function
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As New IntPtr(0)
        Dim di As New DOCINFOA()
        Dim bSuccess As Boolean = False
        ' Assume failure unless you specifically succeed. 
        di.pDocName = "My C#.NET RAW Document"
        di.pDataType = "RAW"
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        If bSuccess = False Then
            dwError = GetLastError()
        End If
        Return bSuccess
    End Function

    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        Dim fs As New FileStream(szFileName, FileMode.Open)
        Dim br As New BinaryReader(fs)
        Dim bytes As [Byte]() = New [Byte](fs.Length - 1) {}
        Dim bSuccess As Boolean = False
        Dim pUnmanagedBytes As New IntPtr(0)
        Dim nLength As Integer
        nLength = Convert.ToInt32(fs.Length)
        bytes = br.ReadBytes(nLength)
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength)
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength)
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength)
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        dwCount = szString.Length
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return True
    End Function
    Public Shared Function OpenCashDrawer1(ByVal szPrinterName As String) As Boolean
        '27,112,48,55,121 
        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As New IntPtr(0)
        Dim di As New DOCINFOA()
        Dim bSuccess As Boolean = False
        di.pDocName = "OpenDrawer"
        di.pDataType = "RAW"
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    Dim nLength As Integer
                    Dim DrawerOpen As Byte() = New Byte() {7}
                    nLength = DrawerOpen.Length
                    Dim p As IntPtr = Marshal.AllocCoTaskMem(nLength)
                    Marshal.Copy(DrawerOpen, 0, p, nLength)
                    bSuccess = WritePrinter(hPrinter, p, DrawerOpen.Length, dwWritten)
                    EndPagePrinter(hPrinter)
                    Marshal.FreeCoTaskMem(p)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        If bSuccess = False Then
            dwError = GetLastError()
        End If
        Return bSuccess
    End Function
    Public Shared Function FullCut(ByVal szPrinterName As String) As Boolean
        '27, 109 
        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As New IntPtr(0)
        Dim di As New DOCINFOA()
        Dim bSuccess As Boolean = False
        di.pDocName = "FullCut"
        di.pDataType = "RAW"
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    Dim nLength As Integer
                    Dim DrawerOpen As Byte() = New Byte() {27, 100, 51}
                    nLength = DrawerOpen.Length
                    Dim p As IntPtr = Marshal.AllocCoTaskMem(nLength)
                    Marshal.Copy(DrawerOpen, 0, p, nLength)
                    bSuccess = WritePrinter(hPrinter, p, DrawerOpen.Length, dwWritten)
                    EndPagePrinter(hPrinter)
                    Marshal.FreeCoTaskMem(p)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        If bSuccess = False Then
            dwError = GetLastError()
        End If
        Return bSuccess
    End Function
End Class
