Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Namespace KeyboardClassLibrary
    Partial Public Class Keyboardcontrol
        Inherits UserControl

        Private shiftindicator As Boolean = False
        Private capslockindicator As Boolean = False
        Private pvtKeyboardKeyPressed As String = ""
        Private pvtKeyboardType As BoW = BoW.Standard

        Public Property KeyboardType As BoW
            Get
                Return pvtKeyboardType
            End Get
            Set(ByVal value As BoW)
                pvtKeyboardType = value

            End Set
        End Property

        <Category("Mouse"), Description("Return value of mouseclicked key")>
        Public Event UserKeyPressed As KeyboardDelegate

        Protected Overridable Sub OnUserKeyPressed(ByVal e As KeyboardEventArgs)
            RaiseEvent UserKeyPressed(Me, e)
        End Sub

        Public Sub LetraNueva(letra As String)
            Dim dea As KeyboardEventArgs = New KeyboardEventArgs(letra)
            OnUserKeyPressed(dea)
            SendKeys.Send(dea.KeyboardKeyPressed)
        End Sub

        Public Function HandleKidsMouseClick(ByVal x As Single, ByVal y As Single) As String
            Dim Keypressed As String = Nothing

            If y < 73 Then

                If x < 79 Then
                    Keypressed = "a"
                ElseIf x >= 79 AndAlso x < 147 Then
                    Keypressed = "b"
                ElseIf x >= 147 AndAlso x < 214 Then
                    Keypressed = "c"
                ElseIf x >= 214 AndAlso x < 281 Then
                    Keypressed = "d"
                ElseIf x >= 281 AndAlso x < 348 Then
                    Keypressed = "e"
                ElseIf x >= 348 AndAlso x < 416 Then
                    Keypressed = "f"
                ElseIf x >= 416 AndAlso x < 491 Then
                    Keypressed = "g"
                ElseIf x >= 491 AndAlso x < 672 Then
                    Keypressed = "{BACKSPACE}"
                ElseIf x >= 672 AndAlso x < 764 Then
                    Keypressed = "."
                ElseIf x >= 764 AndAlso x < 845 Then
                    Keypressed = "1"
                ElseIf x >= 845 AndAlso x < 912 Then
                    Keypressed = "2"
                ElseIf x >= 912 AndAlso x < 989 Then
                    Keypressed = "3"
                End If
            ElseIf y >= 73 AndAlso y < 141 Then

                If x < 79 Then
                    Keypressed = "h"
                ElseIf x >= 79 AndAlso x < 147 Then
                    Keypressed = "i"
                ElseIf x >= 147 AndAlso x < 214 Then
                    Keypressed = "j"
                ElseIf x >= 214 AndAlso x < 281 Then
                    Keypressed = "k"
                ElseIf x >= 281 AndAlso x < 348 Then
                    Keypressed = "l"
                ElseIf x >= 348 AndAlso x < 416 Then
                    Keypressed = "m"
                ElseIf x >= 416 AndAlso x < 491 Then
                    Keypressed = "n"
                ElseIf x >= 491 AndAlso x < 672 Then
                    HandleCapsLock()
                ElseIf x >= 672 AndAlso x < 764 Then
                    Keypressed = ","
                ElseIf x >= 764 AndAlso x < 845 Then
                    Keypressed = "4"
                ElseIf x >= 845 AndAlso x < 912 Then
                    Keypressed = "5"
                ElseIf x >= 912 AndAlso x < 989 Then
                    Keypressed = "6"
                End If
            ElseIf y >= 141 AndAlso y < 209 Then

                If x < 79 Then
                    Keypressed = "o"
                ElseIf x >= 79 AndAlso x < 147 Then
                    Keypressed = "p"
                ElseIf x >= 147 AndAlso x < 214 Then
                    Keypressed = "q"
                ElseIf x >= 214 AndAlso x < 281 Then
                    Keypressed = "r"
                ElseIf x >= 281 AndAlso x < 348 Then
                    Keypressed = "s"
                ElseIf x >= 348 AndAlso x < 416 Then
                    Keypressed = "t"
                ElseIf x >= 416 AndAlso x < 491 Then
                    Keypressed = "u"
                ElseIf x >= 491 AndAlso x < 672 Then
                    Keypressed = "{ENTER}"
                ElseIf x >= 672 AndAlso x < 764 Then
                    Keypressed = "?"
                ElseIf x >= 764 AndAlso x < 845 Then
                    Keypressed = "7"
                ElseIf x >= 845 AndAlso x < 912 Then
                    Keypressed = "8"
                ElseIf x >= 912 AndAlso x < 989 Then
                    Keypressed = "9"
                End If
            ElseIf y >= 209 AndAlso y < 277 Then

                If x >= 79 AndAlso x < 147 Then
                    Keypressed = "v"
                ElseIf x >= 147 AndAlso x < 214 Then
                    Keypressed = "w"
                ElseIf x >= 214 AndAlso x < 281 Then
                    Keypressed = "x"
                ElseIf x >= 281 AndAlso x < 348 Then
                    Keypressed = "y"
                ElseIf x >= 348 AndAlso x < 416 Then
                    Keypressed = "z"
                ElseIf x >= 491 AndAlso x < 672 Then
                    Keypressed = " "
                ElseIf x >= 672 AndAlso x < 764 Then
                    Keypressed = "!"
                ElseIf x >= 764 AndAlso x < 845 Then
                    Keypressed = "{+}"
                ElseIf x >= 845 AndAlso x < 912 Then
                    Keypressed = "0"
                ElseIf x >= 912 AndAlso x < 989 Then
                    Keypressed = "-"
                End If
            End If

            If capslockindicator AndAlso x < 491 Then
                Return "+" & Keypressed
            Else
                Return Keypressed
            End If
        End Function

        Private Function HandleTheMouseClick(ByVal x As Single, ByVal y As Single) As String
            Dim Keypressed As String = Nothing

            If x >= 4 AndAlso x < 815 AndAlso y >= 3 AndAlso y < 277 Then

                If y < 58 Then

                    If x >= 4 AndAlso x < 59 Then
                        Keypressed = HandleShiftableKey("`")
                    ElseIf x >= 67 AndAlso x < 112 Then
                        Keypressed = HandleShiftableKey("1")
                    ElseIf x >= 112 AndAlso x < 165 Then
                        Keypressed = HandleShiftableKey("2")
                    ElseIf x >= 165 AndAlso x < 220 Then
                        Keypressed = HandleShiftableKey("3")
                    ElseIf x >= 220 AndAlso x < 275 Then
                        Keypressed = HandleShiftableKey("4")
                    ElseIf x >= 275 AndAlso x < 328 Then
                        Keypressed = HandleShiftableKey("5")
                    ElseIf x >= 328 AndAlso x < 380 Then
                        Keypressed = HandleShiftableKey("6")
                    ElseIf x >= 380 AndAlso x < 435 Then
                        Keypressed = HandleShiftableKey("7")
                    ElseIf x >= 435 AndAlso x < 490 Then
                        Keypressed = HandleShiftableKey("8")
                    ElseIf x >= 490 AndAlso x < 545 Then
                        Keypressed = HandleShiftableKey("9")
                    ElseIf x >= 545 AndAlso x < 600 Then
                        Keypressed = HandleShiftableKey("0")
                    ElseIf x >= 600 AndAlso x < 655 Then
                        Keypressed = HandleShiftableKey("-")
                    ElseIf x >= 655 AndAlso x < 705 Then
                        Keypressed = HandleShiftableKey("=")
                    ElseIf x >= 705 AndAlso x < 815 Then
                        Keypressed = "{BACKSPACE}"
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 58 AndAlso y < 114 Then

                    If x >= 85 AndAlso x < 140 Then
                        Keypressed = HandleShiftableCaplockableKey("q")
                    ElseIf x >= 140 AndAlso x < 193 Then
                        Keypressed = HandleShiftableCaplockableKey("w")
                    ElseIf x >= 193 AndAlso x < 247 Then
                        Keypressed = HandleShiftableCaplockableKey("e")
                    ElseIf x >= 247 AndAlso x < 300 Then
                        Keypressed = HandleShiftableCaplockableKey("r")
                    ElseIf x >= 300 AndAlso x < 355 Then
                        Keypressed = HandleShiftableCaplockableKey("t")
                    ElseIf x >= 355 AndAlso x < 409 Then
                        Keypressed = HandleShiftableCaplockableKey("y")
                    ElseIf x >= 409 AndAlso x < 463 Then
                        Keypressed = HandleShiftableCaplockableKey("u")
                    ElseIf x >= 463 AndAlso x < 517 Then
                        Keypressed = HandleShiftableCaplockableKey("i")
                    ElseIf x >= 517 AndAlso x < 571 Then
                        Keypressed = HandleShiftableCaplockableKey("o")
                    ElseIf x >= 571 AndAlso x < 625 Then
                        Keypressed = HandleShiftableCaplockableKey("p")
                    ElseIf x >= 625 AndAlso x < 680 Then
                        Keypressed = HandleShiftableKey("{[}")
                    ElseIf x >= 680 AndAlso x < 733 Then
                        Keypressed = HandleShiftableKey("{]}")
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 114 AndAlso y < 168 Then

                    If x >= 4 AndAlso x < 113 Then
                        HandleCapsLock()
                    ElseIf x >= 113 AndAlso x < 167 Then
                        Keypressed = HandleShiftableCaplockableKey("a")
                    ElseIf x >= 167 AndAlso x < 221 Then
                        Keypressed = HandleShiftableCaplockableKey("s")
                    ElseIf x >= 221 AndAlso x < 275 Then
                        Keypressed = HandleShiftableCaplockableKey("d")
                    ElseIf x >= 275 AndAlso x < 330 Then
                        Keypressed = HandleShiftableCaplockableKey("f")
                    ElseIf x >= 330 AndAlso x < 383 Then
                        Keypressed = HandleShiftableCaplockableKey("g")
                    ElseIf x >= 383 AndAlso x < 437 Then
                        Keypressed = HandleShiftableCaplockableKey("h")
                    ElseIf x >= 437 AndAlso x < 491 Then
                        Keypressed = HandleShiftableCaplockableKey("j")
                    ElseIf x >= 491 AndAlso x < 545 Then
                        Keypressed = HandleShiftableCaplockableKey("k")
                    ElseIf x >= 545 AndAlso x < 599 Then
                        Keypressed = HandleShiftableCaplockableKey("l")
                    ElseIf x >= 599 AndAlso x < 653 Then
                        Keypressed = HandleShiftableKey(";")
                    ElseIf x >= 653 AndAlso x < 706 Then
                        Keypressed = HandleShiftableKey("'")
                    ElseIf x >= 706 AndAlso x < 815 Then
                        Keypressed = "{ENTER}"
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 168 AndAlso y < 221 Then

                    If x >= 4 AndAlso x < 140 Then
                        HandleShiftClick()
                    ElseIf x >= 140 AndAlso x < 194 Then
                        Keypressed = HandleShiftableCaplockableKey("z")
                    ElseIf x >= 194 AndAlso x < 248 Then
                        Keypressed = HandleShiftableCaplockableKey("x")
                    ElseIf x >= 248 AndAlso x < 302 Then
                        Keypressed = HandleShiftableCaplockableKey("c")
                    ElseIf x >= 302 AndAlso x < 356 Then
                        Keypressed = HandleShiftableCaplockableKey("v")
                    ElseIf x >= 356 AndAlso x < 410 Then
                        Keypressed = HandleShiftableCaplockableKey("b")
                    ElseIf x >= 410 AndAlso x < 464 Then
                        Keypressed = HandleShiftableCaplockableKey("n")
                    ElseIf x >= 464 AndAlso x < 518 Then
                        Keypressed = HandleShiftableCaplockableKey("m")
                    ElseIf x >= 518 AndAlso x < 572 Then
                        Keypressed = HandleShiftableKey(",")
                    ElseIf x >= 572 AndAlso x < 626 Then
                        Keypressed = HandleShiftableKey(".")
                    ElseIf x >= 626 AndAlso x < 680 Then
                        Keypressed = HandleShiftableKey("/")
                    ElseIf x >= 680 AndAlso x < 815 Then
                        HandleShiftClick()
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 221 AndAlso y < 277 Then

                    If x >= 218 AndAlso x < 597 Then
                        Keypressed = " "
                    Else
                        Keypressed = Nothing
                    End If
                End If
            ElseIf x >= 827 AndAlso x < 989 AndAlso y >= 27 AndAlso y < 193 Then

                If y < 83 Then

                    If x < 880 Then
                        Keypressed = "{INSERT}"
                    ElseIf x >= 880 AndAlso x < 934 Then
                        Keypressed = "{UP}"
                    ElseIf x >= 934 Then
                        Keypressed = HandleShiftableKey("{HOME}")
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 83 AndAlso y < 137 Then

                    If x < 880 Then
                        Keypressed = "{LEFT}"
                    ElseIf x >= 934 Then
                        Keypressed = "{RIGHT}"
                    Else
                        Keypressed = Nothing
                    End If
                ElseIf y >= 137 Then

                    If x < 880 Then
                        Keypressed = "{DELETE}"
                    ElseIf x >= 880 AndAlso x < 934 Then
                        Keypressed = "{DOWN}"
                    ElseIf x >= 934 Then
                        Keypressed = HandleShiftableKey("{END}")
                    Else
                        Keypressed = Nothing
                    End If
                Else
                    Keypressed = Nothing
                End If
            End If

            If Keypressed IsNot Nothing Then
                If shiftindicator Then HandleShiftClick()
                Return Keypressed
            Else
                Return Nothing
            End If
        End Function

        Private Function HandleShiftableKey(ByVal theKey As String) As String
            If shiftindicator Then
                Return "+" & theKey
            Else
                Return theKey
            End If
        End Function

        Private Function HandleShiftableCaplockableKey(ByVal theKey As String) As String
            If pvtKeyboardType <> BoW.Standard Then

                Select Case theKey
                    Case ("q")
                        theKey = "a"
                    Case ("w")
                        theKey = "b"
                    Case ("e")
                        theKey = "c"
                    Case ("r")
                        theKey = "d"
                    Case ("t")
                        theKey = "e"
                    Case ("y")
                        theKey = "f"
                    Case ("u")
                        theKey = "g"
                    Case ("i")
                        theKey = "h"
                    Case ("o")
                        theKey = "i"
                    Case ("p")
                        theKey = "j"
                    Case ("a")
                        theKey = "k"
                    Case ("s")
                        theKey = "l"
                    Case ("d")
                        theKey = "m"
                    Case ("f")
                        theKey = "n"
                    Case ("g")
                        theKey = "o"
                    Case ("h")
                        theKey = "p"
                    Case ("j")
                        theKey = "q"
                    Case ("k")
                        theKey = "r"
                    Case ("l")
                        theKey = "s"
                    Case ("z")
                        theKey = "t"
                    Case ("x")
                        theKey = "u"
                    Case ("c")
                        theKey = "v"
                    Case ("v")
                        theKey = "w"
                    Case ("b")
                        theKey = "x"
                    Case ("n")
                        theKey = "y"
                    Case ("m")
                        theKey = "z"
                End Select
            End If

            If capslockindicator Then
                Return "+" & theKey
            ElseIf shiftindicator Then
                Return "+" & theKey
            Else
                Return theKey
            End If
        End Function

        Private Sub HandleShiftClick()
            If shiftindicator Then
                shiftindicator = False
            Else
                shiftindicator = True
            End If
        End Sub

        Private Sub HandleCapsLock()
            If capslockindicator Then
                capslockindicator = False
            Else
                capslockindicator = True

            End If
        End Sub
    End Class

    Public Delegate Sub KeyboardDelegate(ByVal sender As Object, ByVal e As KeyboardEventArgs)

    Public Class KeyboardEventArgs
        Inherits EventArgs

        Private ReadOnly pvtKeyboardKeyPressed As String

        Public Sub New(ByVal KeyboardKeyPressed As String)
            Me.pvtKeyboardKeyPressed = KeyboardKeyPressed
        End Sub

        Public ReadOnly Property KeyboardKeyPressed As String
            Get
                Return pvtKeyboardKeyPressed
            End Get
        End Property
    End Class

    <Category("Keyboard Type"), Description("Type of keyboard to use")>
    Public Enum BoW
        Standard
        Alphabetical
        Kids
    End Enum
End Namespace
