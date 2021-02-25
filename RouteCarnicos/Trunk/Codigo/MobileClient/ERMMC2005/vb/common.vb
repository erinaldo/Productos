'--------------------------------------------------------------------
' FILENAME: Common.cs
'
' Copyright(c) 2005 Symbol Technologies Inc. All rights reserved.
'
' DESCRIPTION:		This file contains common calls.
'
' NOTES:			Refer to the readme.txt file for a description 
'					of using this file to create a WAN application.
'--------------------------------------------------------------------

'------------------------------------------------------------------------------------
'		I M P O R T A N T   D I S C L A I M E R
'
' This Software comes "as is", with no warranties. None whatsoever. This means no 
' express, implied or statutory warranty, including without limitation, warranties 
' of merchantability or fitness for a particular purpose or any warranty of title 
' or non-infringement. Also, you must pass this disclaimer on whenever you 
' distribute the Software or derivative works. 

' Neither Symbol nor any contributor to the Software will be liable for any of 
' those types of damages known as indirect, special, consequential, or incidental 
' related to the Software or this license, to the maximum extent the law permits, 
' no matter what legal theory it’s based on. Also, you must pass this limitation of 
' liability on whenever you distribute the Software or derivative works. 
'------------------------------------------------------------------------------------
Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Namespace WANSample
    Public Class Common
#Region "COMMON Enums,Classes,Structures "
        Public Enum StringFormat As Integer
            STRINGFORMAT_ASCII = &H1
            STRINGFORMAT_DBCS = &H2
            STRINGFORMAT_UNICODE = &H3
            STRINGFORMAT_BINARY = &H4
        End Enum
#End Region ' SMS enums, classes, structs

#Region "Declarations"

        Const LMEM_FIXED As Integer = &H0
        Const LMEM_ZEROINIT As Integer = &H40
        Const LPTR As Integer = (LMEM_FIXED Or LMEM_ZEROINIT)

#End Region ' Declarations

#Region "COMMON workhorse calls"
        'Create wrappers for the memory API's similar to 
        'Marshal.AllocHGlobal and Marshal.FreeHGlobal 
        Public Function AllocHGlobal(ByVal cb As Integer) As IntPtr
            Dim hMemory As IntPtr = New IntPtr
            hMemory = LocalAlloc(LPTR, cb)
            Return hMemory
        End Function

        Public Function FreeHGlobal(ByVal hMemory As IntPtr) As IntPtr
            Dim pRet As IntPtr = CType(1, IntPtr)
            If Not (hMemory = IntPtr.Zero) Then
                pRet = LocalFree(hMemory)
            End If
            Return pRet
        End Function

        Public Sub PlaySound(ByVal lpszName As String, ByVal hModule As IntPtr)
            PlaySoundW(lpszName, hModule, 0)
        End Sub
#End Region     ' COMMON workhorse calls

#Region "P/Invoke API Calls"

        <DllImport("coredll.dll")> _
        Friend Shared Function LocalAlloc(ByVal uFlags As Integer, ByVal uBytes As Integer) As IntPtr
        End Function

        <DllImport("coredll.dll")> _
        Friend Shared Function LocalFree(ByVal hMem As IntPtr) As IntPtr
        End Function

        <DllImport("coredll")> _
        Public Shared Function PlaySoundW(ByVal lpszName As String, ByVal hModule As IntPtr, ByVal dwFlags As Integer) As Boolean
        End Function

#End Region 'P/Invoke API Calls

    End Class

End Namespace
