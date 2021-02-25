Public Class FormasCambios
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasCambios

    Public Function capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasCambios.Capturar
        Dim oFormCambios As New FormCambioProductos(paroModuloMovDetActual, paroCliente, parsVisitaClave)

        If oFormCambios.ShowDialog() = DialogResult.OK Then
            oFormCambios.Dispose()
            Return True
        End If
        oFormCambios.Dispose()
        Return False
    End Function
End Class
