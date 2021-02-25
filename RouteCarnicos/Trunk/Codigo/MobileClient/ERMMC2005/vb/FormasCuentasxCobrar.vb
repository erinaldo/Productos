Public Class FormasCuentasxCobrar
    'Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasCuentasxCobrar

    Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
        Dim reiniciar As Boolean
        If paroModuloMovDetActual.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cobranza Then
            Do
                reiniciar = False
                Dim FormCobranzaBackus As New FormCobranzaBackus(paroCliente, parsVisitaClave)
                Dim resul As DialogResult = FormCobranzaBackus.ShowDialog()

                If resul = DialogResult.OK Or resul = DialogResult.Retry Then
                    Dim cnhist As CONHist = New CONHist()
                    Dim cobrarventa As Boolean = Convert.ToBoolean(cnhist.Campos("CobrarVentas"))
                    cnhist.Campos.Clear()
                    cnhist.Dispose()
                    Dim numReg As Integer
                    If cobrarventa Then
                        numReg = oDBVen.EjecutarCmdScalarIntSQL("SELECT count(*) FROM TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave where VIS.Clienteclave = '" & paroCliente.ClienteClave & "' AND TRP.tipo = 1 and TRP.tipofase = 2 AND TRP.saldo > 0")
                        numReg += oDBVen.EjecutarCmdScalarIntSQL("SELECT count(*) FROM TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave where VIS.Clienteclave = '" & paroCliente.ClienteClave & "' AND TRP.tipo = 24 AND TRP.saldo > 0")
                    Else
                        numReg = oDBVen.EjecutarCmdScalarIntSQL("SELECT count(*) FROM TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave where VIS.Clienteclave = '" & paroCliente.ClienteClave & "' AND TRP.tipo = 8 and TRP.tipofase = 1 AND TRP.saldo > 0")
                    End If
                    If numReg > 0 Then
                        reiniciar = True
                    Else
                        reiniciar = False
                    End If
                ElseIf resul = DialogResult.Cancel Then
                    reiniciar = False
                End If

                FormCobranzaBackus.Dispose()
                FormCobranzaBackus = Nothing
            Loop While reiniciar
            Return True
        ElseIf paroModuloMovDetActual.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.CuentasPorCobrar Then
            Dim FormCuentasxCobrar As New FormCuentasxCobrar(paroCliente, parsVisitaClave)
            If FormCuentasxCobrar.ShowDialog() = DialogResult.OK Then
                FormCuentasxCobrar.Dispose()
                FormCuentasxCobrar = Nothing
                Return True
            End If
            FormCuentasxCobrar.Dispose()
            FormCuentasxCobrar = Nothing
            Return True
        End If

        Return False
    End Function

End Class
