Public Class FrmCantSurtida
    Public Cantidad, Surtido As Decimal
    Private bError As Boolean = False
    Private Sub FrmTallaColor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmCantSurtida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCantidad.Text = CStr(Cantidad)
        txtSurtido.Text = CStr(Surtido)
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        bError = False
        Me.Close()
    End Sub

    Private Sub cmbColor_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbTalla_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If CDec(txtSurtido.Text) > Cantidad Then
            bError = True
            Beep()
            MessageBox.Show("¡La cantidad surtida es mayor a la solicitada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ElseIf CDec(txtSurtido.Text) < 0 Then
            bError = True
            Beep()
            MessageBox.Show("¡La cantidad surtida no puede ser menor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        ElseIf CDec(txtSurtido.Text) > Surtido Then
            bError = True
            Beep()
            MessageBox.Show("¡No se puede aumentar la cantidad surtida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            bError = False
            Surtido = CDec(txtSurtido.Text)
        End If
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub txtSurtido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSurtido.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BtnGuardar.PerformClick()
        End If
    End Sub
End Class