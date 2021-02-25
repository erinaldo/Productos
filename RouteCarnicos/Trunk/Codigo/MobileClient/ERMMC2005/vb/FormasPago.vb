Public Class FormasPago
    Implements ERM.Dia.Agenda.Visita.FormasPago

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.FormasPago.Capturar
        Dim oFormPagos As New FormPagos(paroCliente, parsVisitaClave)

        If oFormPagos.ShowDialog() = DialogResult.OK Then
            oFormPagos.Dispose()
            Return True
        End If
        oFormPagos.Dispose()
        Return False
    End Function
    Public Shared Function GuardarAbono(ByVal pariConsecutivo As Integer, ByVal parsFolio As String, ByVal parsVisitaClave As String, ByVal parsDiaClave As String, ByVal pardFechaAbono As DateTime, ByVal pariTotal As Decimal, ByVal pardSaldo As Decimal, ByVal tfolio As ServicesCentral.TiposModulosMovDet) As String
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            Dim sABNId As String = oApp.KEYGEN(1)


            sComandoSQL.Append("INSERT INTO Abono(ABNId,Folio,FechaCreacion,VisitaClave,DiaClave, ")
            sComandoSQL.Append("FechaAbono,Total,Saldo,MFechaHora,MUsuarioID,Enviado) VALUES (")
            sComandoSQL.Append("'" & sABNId & "',")
            sComandoSQL.Append("'" & parsFolio & "',")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & parsVisitaClave & "',")
            sComandoSQL.Append("'" & parsDiaClave & "',")
            sComandoSQL.Append(UniFechaSQL(pardFechaAbono, , "dd/MM/yyyy") & ",")
            sComandoSQL.Append(Decimal.Round(pariTotal, 2) & ",")
            sComandoSQL.Append(Decimal.Round(pardSaldo, 2) & ",")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oApp.Usuario.UsuarioId & "',0)")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            sComandoSQL = Nothing
            Folio.Confirmar(, tfolio)

            Return sABNId
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Shared Function ModificarAbono(ByVal parsABNId As String, ByVal pariTotal As Decimal, ByVal pardSaldo As Decimal) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            sComandoSQL.Append("UPDATE Abono ")
            sComandoSQL.Append("SET Total=" & pariTotal & ",")
            sComandoSQL.Append("Saldo=" & Decimal.Round(pardSaldo, 2) & ",")
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
            sComandoSQL.Append("MUsuarioID='" & oApp.Usuario.UsuarioId & "', ")
            sComandoSQL.Append("Enviado=0 ")
            sComandoSQL.Append("WHERE ABNId='" & parsABNId & "'")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            sComandoSQL = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function EliminarAbono(ByVal parsABNId As String) As Boolean
        Try
            oDBVen.EjecutarComandoSQL("Delete from ABNDetalle where ABNId='" & parsABNId & "'")
            oDBVen.EjecutarComandoSQL("Delete from Abono where ABNId='" & parsABNId & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GuardarABNDetalle(ByVal parsABNId As String, ByVal parsABDId As String, ByVal pariTipoPago As Integer, ByVal pariImporte As Decimal, ByVal pardSaldoDeposito As Decimal, ByVal pariTipoBanco As Integer, ByVal parsReferencia As String, ByVal parsMonedaId As String, ByVal pardtipocambio As Decimal) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            sComandoSQL.Append("INSERT INTO ABNDetalle(ABNId,ABDId,TipoPago,Importe,SaldoDeposito,MonedaId,TipoCambio,TipoBanco, ")
            sComandoSQL.Append("Referencia,MFechaHora,MUsuarioID,Enviado) VALUES (")
            sComandoSQL.Append("'" & parsABNId & "',")
            sComandoSQL.Append("'" & parsABDId & "',")
            sComandoSQL.Append(pariTipoPago & ",")
            sComandoSQL.Append(Decimal.Round(pariImporte, 2) & ",")
            sComandoSQL.Append(Decimal.Round(pardSaldoDeposito, 2) & ",")
            sComandoSQL.Append(IIf(parsMonedaId = "", "null", "'" & parsMonedaId & "'") & ",")
            sComandoSQL.Append(pardtipocambio & ",")
            sComandoSQL.Append(IIf(pariTipoBanco = -1, "null", pariTipoBanco) & ",")
            sComandoSQL.Append("'" & parsReferencia & "',")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oApp.Usuario.UsuarioId & "',0)")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ModificarABNDetalle(ByVal parsABNId As String, ByVal parsABDId As String, ByVal pariTipoPago As Integer, ByVal pariImporte As Decimal, ByVal pardSaldoDeposito As Decimal, ByVal pariTipoBanco As Integer, ByVal pariReferencia As String, ByVal parsMonedaId As String, ByVal pardtipocambio As Decimal, Optional ByVal parbVerificarSaldo As Boolean = True) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            If parbVerificarSaldo Then
                If DiferenciasImporteSaldoABNDetalle(parsABNId, parsABDId) Then
                    Return False
                End If
            End If

            sComandoSQL.Append("UPDATE ABNDetalle ")
            sComandoSQL.Append("SET TipoPago=" & pariTipoPago & ",")
            sComandoSQL.Append("Importe=" & pariImporte & ",")
            sComandoSQL.Append("SaldoDeposito=" & Decimal.Round(pardSaldoDeposito, 2) & ",")
            sComandoSQL.Append("MonedaId = " & IIf(parsMonedaId = "", "null", "'" & parsMonedaId & "'") & ",")
            sComandoSQL.Append("TipoCambio = " & pardtipocambio & ",")
            sComandoSQL.Append("TipoBanco=" & IIf(pariTipoBanco = -1, "null", pariTipoBanco) & ",")
            sComandoSQL.Append("Referencia='" & pariReferencia & "',")
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
            sComandoSQL.Append("MUsuarioID='" & oApp.Usuario.UsuarioId & "',Enviado=0 ")
            sComandoSQL.Append("WHERE ABNId='" & parsABNId & "' and ABDId='" & parsABDId & "'")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            sComandoSQL = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function EliminarABNDetalle(ByVal parsABNId As String, ByVal parsABDId As String, Optional ByVal parbVerificarSaldo As Boolean = True) As Boolean
        Try

            If parbVerificarSaldo Then
                If DiferenciasImporteSaldoABNDetalle(parsABNId, parsABDId) Then
                    Return False
                End If
            End If

            oDBVen.EjecutarComandoSQL("Delete from ABNDetalle where ABNId='" & parsABNId & "' and ABDId='" & parsABDId & "' ")

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function GuardarABNTrp(ByVal parsABNId As String, ByVal parsTransProdId As String, ByVal pariImporte As Decimal, ByVal parsSerie As String, ByVal parsCorecibo As String) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            sComandoSQL.Append("INSERT INTO AbnTrp(ABNId,TransProdId,FechaHora,Importe,Serie,Corecibo, ")
            sComandoSQL.Append("MFechaHora,MUsuarioID,Enviado) VALUES (")
            sComandoSQL.Append("'" & parsABNId & "',")
            sComandoSQL.Append("'" & parsTransProdId & "',")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append(Decimal.Round(pariImporte, 2) & ",")
            sComandoSQL.Append("'" & parsSerie & "',")
            sComandoSQL.Append("'" & parsCorecibo & "',")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oApp.Usuario.UsuarioId & "',0)")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ModificarABNTrp(ByVal parsABNId As String, ByVal parsTransProdId As String, ByVal pardFechaHora As DateTime, ByVal pariImporte As Decimal, ByVal parsSerie As String, ByVal parsCorecibo As String) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder

            sComandoSQL.Append("UPDATE ABNTrp ")
            sComandoSQL.Append("SET Importe=" & pariImporte & ",")
            sComandoSQL.Append("Serie='" & parsSerie & "',")
            sComandoSQL.Append("Corecibo='" & parsCorecibo & "',")
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
            sComandoSQL.Append("MUsuarioID='" & oApp.Usuario.UsuarioId & "',Enviado=0 ")
            sComandoSQL.Append("WHERE ABNId='" & parsABNId & "' AND TransProdId='" & parsTransProdId & "' AND FechaHora = " & UniFechaSQL(pardFechaHora))

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            sComandoSQL = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function EliminarABNTrp(ByVal parsABNId As String, ByVal parsTransProdId As String, ByVal pardFechaHora As DateTime) As Boolean
        Try
            oDBVen.EjecutarComandoSQL("Delete from ABNTrp where ABNId='" & parsABNId & "' and TransProdId='" & parsTransProdId & "' AND FechaHora = " & UniFechaSQL(pardFechaHora))
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function RecuperarAbono(ByVal parsABNId As String) As DataSet
        Try
            Dim dsRes As New DataSet

            oDBVen.RealizarConsultaSQL(dsRes, "Select * from Abono where ABNId='" & parsABNId & "'", "Abono")
            oDBVen.RealizarConsultaSQL(dsRes, "Select * from ABNDetalle where ABNId='" & parsABNId & "'", "ABNDetalle")

            Return dsRes

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function DiferenciasImporteSaldoABNDetalle(ByVal parsABNId As String, ByVal parsABDId As String) As Boolean
        Dim dt As DataTable
        dt = oDBVen.RealizarConsultaSQL("Select Importe,SaldoDeposito from ABNDetalle where ABNId='" & parsABNId & "' AND ABDId='" & parsABDId & "'", "ABNDetalle")

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("Importe") <> dt.Rows(0)("SaldoDeposito") Then
                    Return True
                End If
            End If
        End If
        dt.Dispose()
        Return False
    End Function

End Class

