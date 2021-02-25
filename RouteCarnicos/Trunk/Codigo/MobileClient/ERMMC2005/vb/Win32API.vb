Imports System.Runtime.InteropServices
Imports System.Text

Public Class SHELLEXECUTEEX
    Public cbSize As UInt32
    Public fMask As UInt32
    Public hwnd As IntPtr
    Public lpVerb As IntPtr
    Public lpFile As IntPtr
    Public lpParameters As IntPtr
    Public lpDirectory As IntPtr

    Public nShow As Integer
    Public hInstApp As IntPtr
    ' Optional members
    Public lpIDList As IntPtr
    Public lpClass As IntPtr
    Public hkeyClass As IntPtr
    Public dwHotKey As UInt32
    Public hIcon As IntPtr
    Public hProcess As IntPtr
End Class 'SHELLEXECUTEEX

Public Class Memoria
    Public Structure MEMORYSTATUS
        Public dwLength As UInt32
        Public dwMemoryLoad As UInt32
        Public dwTotalPhys As UInt32
        Public dwAvailPhys As UInt32
        Public dwTotalPageFile As UInt32
        Public dwAvailPageFile As UInt32
        Public dwTotalVirtual As UInt32
        Public dwAvailVirtual As UInt32
    End Structure

    Public Declare Function GlobalMemoryStatus Lib "CoreDll.Dll" _
        (ByRef ms As MEMORYSTATUS) As Integer

    Public Declare Function GetSystemMemoryDivision Lib "CoreDll.Dll" _
        (ByRef lpdwStorePages As UInt32, _
        ByRef ldpwRamPages As UInt32, _
        ByRef ldpwPageSize As UInt32) As Integer

    Public Shared Function MemoriaTotal() As String
        Dim storePages As UInt32
        Dim ramPages As UInt32
        Dim pageSize As UInt32
        Dim res As Integer = _
            GetSystemMemoryDivision(storePages, ramPages, pageSize)

        ' Call the native GlobalMemoryStatus method
        ' with the defined structure.
        Dim memStatus As New MEMORYSTATUS
        GlobalMemoryStatus(memStatus)
        Dim memoria As Double = (memStatus.dwTotalPhys / 1024) / 1024

        Return memoria.ToString()
    End Function

    Public Shared Function MemoriaFree() As String
        Dim storePages As UInt32
        Dim ramPages As UInt32
        Dim pageSize As UInt32
        Dim res As Integer = _
            GetSystemMemoryDivision(storePages, ramPages, pageSize)

        ' Call the native GlobalMemoryStatus method
        ' with the defined structure.
        Dim memStatus As New MEMORYSTATUS
        GlobalMemoryStatus(memStatus)
        Dim memoria As Double = (memStatus.dwAvailPhys / 1024) / 1024

        Return memoria.ToString()
    End Function

    Public Shared Sub ShowMemory()
        Dim storePages As UInt32
        Dim ramPages As UInt32
        Dim pageSize As UInt32
        Dim res As Integer = _
            GetSystemMemoryDivision(storePages, ramPages, pageSize)

        ' Call the native GlobalMemoryStatus method
        ' with the defined structure.
        Dim memStatus As New MEMORYSTATUS
        GlobalMemoryStatus(memStatus)

        ' Use a StringBuilder for the message box string.
        Dim MemoryInfo As New Text.StringBuilder
        MemoryInfo.Append("Memory Load: " _
            & memStatus.dwMemoryLoad.ToString() & vbCrLf)
        MemoryInfo.Append("Total Physical: " _
            & memStatus.dwTotalPhys.ToString() & vbCrLf)
        MemoryInfo.Append("Avail Physical: " _
            & memStatus.dwAvailPhys.ToString() & vbCrLf)
        MemoryInfo.Append("Total Page File: " _
            & memStatus.dwTotalPageFile.ToString() & vbCrLf)
        MemoryInfo.Append("Avail Page File: " _
            & memStatus.dwAvailPageFile.ToString() & vbCrLf)
        MemoryInfo.Append("Total Virtual: " _
            & memStatus.dwTotalVirtual.ToString() & vbCrLf)
        MemoryInfo.Append("Avail Virtual: " _
            & memStatus.dwAvailVirtual.ToString() & vbCrLf)

        ' Show the available memory.
        MsgBox(MemoryInfo.ToString())

    End Sub
End Class

Module Win32API

    <DllImport("coredll.dll")> _
    Public Function FindWindowW( _
       ByVal lpClassName As String _
       , ByVal lpWindowName As String _
       ) As IntPtr
    End Function

    <DllImport("coredll.dll")> _
    Public Function MoveWindow( _
       ByVal hWnd As IntPtr _
       , ByVal X As Integer _
       , ByVal Y As Integer _
       , ByVal nWidth As Integer _
       , ByVal nHeight As Integer _
       , ByVal bRepaint As Integer _
       ) As Integer
    End Function

    <DllImport("coredll")> _
 Public Function ShellExecuteEx(ByVal ex As SHELLEXECUTEEX) As Integer
    End Function

    <DllImport("coredll")> _
    Public Function LocalAlloc(ByVal flags As Integer, ByVal size As Integer) As IntPtr
    End Function

    <DllImport("coredll")> Public Sub LocalFree(ByVal ptr As IntPtr)
    End Sub

    <DllImport("coredll")> _
    Public Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal WParam As UInteger, ByVal LParam As UInteger) As Integer
    End Function

    '--Funcion para ejecutar Applicaciones externas al route
    Public Function EjecutarApp(ByVal Archivo As String) As Boolean
        ' Code starts here
        Dim docname As String = Archivo
        Dim nSize As Integer = docname.Length * 2 + 2
        Dim pData As IntPtr = Win32API.LocalAlloc(&H40, nSize)
        Marshal.Copy(Encoding.Unicode.GetBytes(docname), 0, pData, nSize - 2)

        Dim see As New SHELLEXECUTEEX()
        see.cbSize = 60
        see.dwHotKey = 0
        see.fMask = 0
        see.hwnd = IntPtr.Zero
        see.hIcon = IntPtr.Zero
        see.hInstApp = IntPtr.Zero
        see.hProcess = IntPtr.Zero
        see.lpClass = IntPtr.Zero
        see.lpDirectory = IntPtr.Zero
        see.lpIDList = IntPtr.Zero
        see.lpParameters = IntPtr.Zero
        see.lpVerb = IntPtr.Zero
        see.nShow = 0
        see.lpFile = pData

        ShellExecuteEx(see)

        LocalFree(pData)

        Return True

    End Function
End Module


