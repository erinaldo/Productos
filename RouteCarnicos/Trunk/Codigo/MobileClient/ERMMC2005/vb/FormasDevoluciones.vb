Public Class FormasDevoluciones
    Implements ERM.Dia.Devoluciones

    Private Function ExistenMovimientos() As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd where Tipo=4"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Capturar() As Boolean Implements ERM.Dia.Devoluciones.Capturar
        If ExistenMovimientos() Then
            Dim oFormaDevolucion As New FormDevoluciones
            If oFormaDevolucion.ShowDialog = DialogResult.OK Then
                oFormaDevolucion.Dispose()
                Return True
            End If
            oFormaDevolucion.Dispose()
            Return False
        Else
            Dim sID As String = oApp.KEYGEN(1)
            Dim sFolio As String = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.DevolucionAlmacen)
            If sFolio <> "" Then
                Dim oFormaDetalle As New FormDevolucionDetalle(sFolio, sID, FormDevolucionDetalle.Modo.Capturar, FormDevolucionDetalle.Fase.Captura, True)
                oFormaDetalle.ShowDialog()
                oFormaDetalle.Dispose()
                Return True
            End If
            Return False
        End If
    End Function
End Class
