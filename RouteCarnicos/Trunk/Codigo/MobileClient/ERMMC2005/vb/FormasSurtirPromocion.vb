Public Class FormasSurtirPromocion
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasSurtirPromocion

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd "
        sConsulta &= "inner join Visita on TransProd.VisitaClave = Visita.VisitaClave "
        sConsulta &= "where TransProd.Tipo=20 and Visita.ClienteClave='" & paroCliente.ClienteClave & "' "
        sConsulta &= "and Visita.VisitaClave='" & parsVisitaClave & "' and Visita.DiaClave='" & oDia.DiaActual & "' "
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasSurtirPromocion.Capturar
        If ExistenMovimientos(paroCliente, parsVisitaClave) Then
            Dim oFormSurtirPromocion As New FormSurtirPromocion(paroModuloMovDetActual, paroCliente, parsVisitaClave)
            If oFormSurtirPromocion.ShowDialog() = DialogResult.OK Then
                oFormSurtirPromocion.Dispose()
                oFormSurtirPromocion = Nothing
                Return True
            End If
            oFormSurtirPromocion.Dispose()
            oFormSurtirPromocion = Nothing
            Return False
        Else
            Dim oSurtirDetalle As New FormSurtirPromocionDetalle("", paroCliente, parsVisitaClave, paroModuloMovDetActual)
            oSurtirDetalle.Crear()
            oSurtirDetalle.Dispose()
            Return True
        End If
    End Function

End Class
