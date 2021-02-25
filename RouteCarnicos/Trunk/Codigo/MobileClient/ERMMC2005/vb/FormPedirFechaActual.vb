Public Class FormPedirFechaActual
    Dim dFechaActual As DateTime
    Dim blnManual As Boolean = False
    Private refaVista As Vista

    Public Property FechaActual() As DateTime
        Get
            Return dFechaActual
        End Get
        Set(ByVal value As DateTime)
            dFechaActual = value
        End Set
    End Property

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        dFechaActual = New DateTime(mcFechaActual.SelectionStart.Year, mcFechaActual.SelectionStart.Month, mcFechaActual.SelectionStart.Day, Me.dtpHora.Value.Hour, Me.dtpHora.Value.Minute, Me.dtpHora.Value.Second)
        oFormCargando.Informar(1, "GR", "Amesol ROUTE")
        Me.Close()
    End Sub

    Private Sub mcFechaActual_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcFechaActual.DateChanged
        If mcFechaActual.SelectionStart <> mcFechaActual.SelectionEnd Then
            Me.mcFechaActual.SelectionStart = Me.mcFechaActual.SelectionEnd
        End If
        If blnManual Then Exit Sub
        blnManual = True
        dtpFecha.Value = mcFechaActual.SelectionStart
        blnManual = False
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If blnManual Then Exit Sub
        blnManual = True
        mcFechaActual.SelectionStart = dtpFecha.Value
        mcFechaActual.SelectionEnd = dtpFecha.Value
        blnManual = False
    End Sub

    Private Sub FormPedirFechaActual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        Me.mcFechaActual.Left = (Me.Width / 2) - (Me.mcFechaActual.Width / 2)
        Me.dtpFecha.Width = Me.mcFechaActual.Width
        Me.dtpFecha.Left = Me.mcFechaActual.Left
        Me.dtpHora.Width = Me.mcFechaActual.Width
        Me.dtpHora.Left = Me.mcFechaActual.Left
        If Not Vista.Buscar("FormPedirFechaActual", refaVista) Then
            Me.LabelMensaje.Text = "Modificar Fecha Actual"
            Me.ButtonContinuar.Text = "Continuar"
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
    End Sub
End Class