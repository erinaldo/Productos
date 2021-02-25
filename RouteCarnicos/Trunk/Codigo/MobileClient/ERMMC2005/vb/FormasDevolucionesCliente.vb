Public Class FormasDevolucionesCliente
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasDevolucionesCliente

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd "
        sConsulta &= "inner join Visita on TransProd.VisitaClave=Visita.VisitaClave "
        sConsulta &= "where Tipo=3 and visita.clienteclave='" & paroCliente.ClienteClave & "' and visita.visitaclave='" & parsVisitaClave & "'"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasDevolucionesCliente.Capturar
        If ExistenMovimientos(paroCliente, parsVisitaClave) Then
            Dim oFormDevCliente As New FormDevolucionCliente(paroModuloMovDetActual, paroCliente, parsVisitaClave)
            oFormDevCliente.ShowDialog()
            oFormDevCliente.Dispose()
            oFormDevCliente = Nothing
        Else
            Dim sFolioItem As String
            sFolioItem = Folio.Obtener(paroModuloMovDetActual.ModuloMovDetalleClave)
            If sFolioItem <> "" Then
                Dim oFDCD As New FormDevolucionClienteDetalle(sFolioItem, oApp.KEYGEN(2), parsVisitaClave, FormDevolucionClienteDetalle.Movimiento.Capturar, FormDevolucionClienteDetalle.Modo.Modificable, paroModuloMovDetActual, True, paroCliente)
                oFDCD.ShowDialog()
                oFDCD.Dispose()
                oFDCD = Nothing
            End If
        End If
    End Function
End Class
