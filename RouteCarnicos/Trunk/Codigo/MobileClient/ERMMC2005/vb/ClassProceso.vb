Public Class ClassProceso

    Public FormProceso As FormProceso

    Public Sub New()
        FormProceso = New FormProceso
    End Sub

    Public Sub PubSubInformar(ByVal parsMensaje As String, ByVal parsEstado As String)
        FormProceso.Visible = True
        FormProceso.LabelProceso.Text = parsMensaje
        FormProceso.LabelProceso.Refresh()
        FormProceso.LabelEstado.Text = parsEstado
        FormProceso.ProgressBarAvance.Visible = False
        FormProceso.Refresh()
    End Sub

    Public Sub PubSubTitulo(ByVal parsTitulo As String)
        FormProceso.LabelTitulo.Text = parsTitulo
        FormProceso.LabelTitulo.Refresh()
    End Sub

    Public Sub PubSubInformar(ByVal parsMensaje As String)
        FormProceso.Visible = True
        FormProceso.LabelProceso.Text = parsMensaje
        FormProceso.LabelProceso.Refresh()
        FormProceso.LabelEstado.Text = ""
        FormProceso.ProgressBarAvance.Visible = False
        FormProceso.Refresh()
    End Sub

    Public Sub PubSubInformar(ByVal pariValor As Integer)
        FormProceso.Visible = True
        If Not FormProceso.ProgressBarAvance.Visible Then
            FormProceso.ProgressBarAvance.Visible = True
        End If
        FormProceso.ProgressBarAvance.Value = pariValor
        FormProceso.Refresh()
    End Sub

    Public Sub PubSubEstado(ByVal parsEstado As String)
        FormProceso.Visible = True
        FormProceso.LabelEstado.Text = parsEstado
        FormProceso.Refresh()
    End Sub

    Public Sub PubSubProceso(ByVal parsProceso As String)
        FormProceso.Visible = True
        FormProceso.LabelProceso.Text = parsProceso
        FormProceso.LabelProceso.Refresh()
        FormProceso.Refresh()
    End Sub

    Public Sub PubSubInformar()
        If FormProceso.Visible Then
            FormProceso.Visible = False
        Else
            FormProceso.Visible = True
        End If
        FormProceso.Refresh()
    End Sub

End Class
