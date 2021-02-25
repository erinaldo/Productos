Public Class Resumen
    Implements ERM.Dia.Agenda.Visita.Resumen

    Protected oCliente As Cliente
    Protected sVisitaClave As String

    Private Property Cliente() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
        End Set
    End Property
    Private Property VisitaClave() As String
        Get
            Return sVisitaClave
        End Get
        Set(ByVal Value As String)
            sVisitaClave = Value
        End Set
    End Property

    Public Function Mostrar() As Boolean Implements ERM.Dia.Agenda.Visita.Resumen.Mostrar
        Dim oFormResumen As New FormResumen(Me.Cliente, Me.VisitaClave)
        If oFormResumen.ShowDialog() = DialogResult.OK Then
            oFormResumen.Dispose()
            oFormResumen = Nothing
            Return True
        Else
            oFormResumen.Dispose()
            oFormResumen = Nothing
            Return False
        End If
    End Function

    Public Function ObtenerTotales(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.Resumen.ObtenerTotales
        Me.Cliente = paroCliente
        Me.VisitaClave = parsVisitaClave
        Return True
    End Function

End Class

