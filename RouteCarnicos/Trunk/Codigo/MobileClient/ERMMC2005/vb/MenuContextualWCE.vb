Namespace InTheHand.Windows.Forms


    Public Class ContextMenuHelper


        Private Shared mousedelegate As System.Windows.Forms.MouseEventHandler = New System.Windows.Forms.MouseEventHandler(AddressOf ControlMouseDown)

        Public Shared Sub HookAllControls(ByVal thecontrols As Control.ControlCollection)

            'attach to the mousedown event on all controls with a context menu
            For Each thiscontrol As Control In thecontrols

                If Not thiscontrol.ContextMenu Is Nothing Then

                    AddHandler thiscontrol.MouseDown, mousedelegate

                End If

                HookAllControls(thiscontrol.Controls)
            Next

        End Sub


        Private Shared Sub ControlMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

            Dim senderctrl As Control = CType(sender, Control)

            'if theres no context menu do nothing
            If Not senderctrl.ContextMenu Is Nothing Then

                Dim shrgi As New SHRGINFO
                shrgi.cbSize = 20
                shrgi.hwndClient = senderctrl.Handle
                shrgi.dwFlags = 3
                shrgi.ptDownx = e.X
                shrgi.ptDowny = e.Y
                Dim result As Integer = SHRecognizeGesture(shrgi)
                If result = 1000 Then

                    senderctrl.ContextMenu.Show(senderctrl, New System.Drawing.Point(e.X, e.Y))
                End If
            End If

        End Sub

        <System.Runtime.InteropServices.DllImport("aygshell.dll")> _
        Private Shared Function SHRecognizeGesture(ByRef shrg As SHRGINFO) As Integer
        End Function

        Public Structure SHRGINFO
            Public cbSize As Integer
            Public hwndClient As IntPtr
            Public ptDownx As Integer
            Public ptDowny As Integer
            Public dwFlags As Integer
        End Structure

    End Class

End Namespace
