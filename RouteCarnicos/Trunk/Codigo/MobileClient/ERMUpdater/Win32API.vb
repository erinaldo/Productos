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
