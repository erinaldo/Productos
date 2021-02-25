Public Class FormFiltroAgenda

    Private refaVista As Vista

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If Me.DateTimeFechaInicio.Value > Me.DateTimeFechaFin.Value Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0008"))
            Exit Sub
        End If
        oDBVen.Grupo = 0
        oDBVen.FechaIni = Me.DateTimeFechaInicio.Value
        oDBVen.FechaFin = Me.DateTimeFechaFin.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub FormFiltroAgenda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Recuperar los demás componentes de la forma
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormFiltroAgenda", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        DateTimeFechaInicio.Value = PrimeraHora(Now)
        DateTimeFechaFin.Value = PrimeraHora(Now)

        DateTimeFechaInicio.Focus()
    End Sub

   
End Class