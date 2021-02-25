Public Class FormasPrestamos
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasPrestamos

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd "
        sConsulta &= "inner join Visita on TransProd.VisitaClave = Visita.VisitaClave "
        sConsulta &= "where TransProd.Tipo = 1 and TransProd.TipoPedido <> 0 and TransProd.TipoPedido <> 2 and TransProd.TipoFase <> 0 "
        sConsulta &= "and Visita.ClienteClave = '" & paroCliente.ClienteClave & "' and Visita.VisitaClave = '" & parsVisitaClave & "' "
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasPrestamos.Capturar
        If ExistenMovimientos(paroCliente, parsVisitaClave) Then
            Dim oFormPrestamos As New FormPrestamos(paroModuloMovDetActual, paroCliente, parsVisitaClave)
            If oFormPrestamos.ShowDialog() = DialogResult.OK Then
                oFormPrestamos.Dispose()
                oFormPrestamos = Nothing
                Return True
            End If
            oFormPrestamos.Dispose()
            oFormPrestamos = Nothing
            Return False
        Else
            MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0557"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal, "Capturar")
            Return False
        End If
    End Function
End Class
