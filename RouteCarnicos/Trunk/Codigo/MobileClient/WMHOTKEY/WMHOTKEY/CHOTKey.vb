Imports System
Imports Microsoft.WindowsCE.Forms
Imports System.Data
Imports System.Runtime.InteropServices

Public Enum SO
    PocketPC = 1
    WindowsMobile5 = 2
    SymbolWMobile5_MC9090 = 3
    SymbolPCMC50 = 4
    HHP7900 = 5
    HHP9500 = 6
    HHP7600 = 7
    SymbolMC35 = 8
    IntermecCN3 = 9
    HHPWM6 = 10
    Palm = 11
    SymbolMC55 = 12
End Enum


Public Class CHOTKey

    Private vSelectedSO As SO
    Private WithEvents oMessageWin As CMessageWin
#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then
    Private Symbolkeypad As Symbol.Keyboard.KeyPad
#End If
    Event HotKeyPressed()

    Public Sub SetUpKeyBoard(ByVal pvSelectSO As SO)

        vSelectedSO = pvSelectSO

        Select Case vSelectedSO
            Case SO.PocketPC, SO.HHP7600
                oMessageWin = New CMessageWin
            Case SO.SymbolWMobile5_MC9090
#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then

                Try
                    Symbolkeypad = New Symbol.Keyboard.KeyPad
                Catch ex As Exception
                    Throw ex
                End Try
                Try
                    AddHandler Symbolkeypad.KeyStateNotify, New Symbol.Keyboard.KeyPad.KeyboardEventHandler(AddressOf Me.Symbolkeypad_KeyStateNotify)
                    'AddHandler Symbolkeypad.AlphaNotify, New Symbol.Keyboard.KeyPad.KeyboardEventHandler(AddressOf Me.Symbolkeypad_AlphaNotify)

                Catch
                End Try
#End If
        End Select

    End Sub
#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then

    Private Sub Symbolkeypad_KeyStateNotify(ByVal sender As Object, ByVal e As Symbol.Keyboard.KeyboardEventArgs)

        'checkBoxUnShift.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT)
        'checkBoxShift.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_SHIFT)
        'checkBoxCtrl.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_CTRL)
        'checkBoxAlt.Checked = 

        '//ALT Checked

        If CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_CTRL) Then
            RaiseEvent HotKeyPressed()
        End If

        'checkBoxNum.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_NUMLOCK)
        'checkBoxCaps.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_CAPSLOCK)
        'checkBoxFunc.Checked = CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_FUNC)
        Dim modifierIndex As Integer = -1
        Dim temp As Integer = e.ActiveModifier
        While temp <> 0
            modifierIndex += 1
            If (temp And 1) <> 0 Then
                Exit While
            End If
            temp >>= 1
        End While
    End Sub
#End If
    'Funcion: Para cachar un HOTKEY, y mostrar la lista de precios
    'Author: Julio Pacheco
    'Comentarios: Funciona solamente con Pocket PC 2003
    Private Class CMessageWin
        Inherits MessageWindow

        Public HomeKeyPress As System.EventHandler

        Private Const VK_LWIN = &H5B
        Private Const WM_HOTKEY = &H312

        Private Const KeyD4 As Integer = 52
        Private Const KeyF4 As Integer = 115


        Public Declare Function RegisterHotKey Lib "coredll.dll" (ByVal hWnd As IntPtr, ByVal id As Integer, ByVal Modifiers As Integer, ByVal key As Integer) As Boolean

        Public Function UnregisterHotKey(ByRef hWnd As System.IntPtr, ByVal id As Integer) As Integer
        End Function


        'event for client

        Public Sub New()
            'Register to listen for home key

            Call RegisterHotKey(Me.Hwnd, VK_LWIN, 8, VK_LWIN)
            Call RegisterHotKey(Me.Hwnd, KeyD4, &H2, KeyD4)
            Call RegisterHotKey(Me.Hwnd, KeyF4, 0, KeyF4)

        End Sub


        Public Event Evento()

        Public Sub DesRegistrar()
            UnregisterHotKey(Me.Hwnd, VK_LWIN)
            UnregisterHotKey(Me.Hwnd, KeyD4)
            UnregisterHotKey(Me.Hwnd, KeyF4)
        End Sub

        Protected Overrides Sub Finalize()


        End Sub


        Protected Overrides Sub WndProc(ByRef m As Message)

            'Dim TeclaCTRL4 As New System.IntPtr(Keys.D4)
            'Dim TeclaF4 As New System.IntPtr(Keys.F4)

            If (m.Msg = WM_HOTKEY) Then

                'If (CType(m.WParam.ToInt32 = VK_LWIN, Integer)) Or m.WParam.Equals(TeclaCTRL4) Or m.WParam.Equals(TeclaF4) Or (m.Msg = 26) Then
                RaiseEvent Evento()

                'End If

                MyBase.WndProc(m)

            End If


        End Sub

    End Class

    Private Sub oMessageWin_Evento() Handles oMessageWin.Evento
        RaiseEvent HotKeyPressed()
    End Sub

    Public Sub DesRegistrar()

        If vSelectedSO = SO.PocketPC Then
            oMessageWin.DesRegistrar()
            oMessageWin.Dispose()
            oMessageWin = Nothing
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
