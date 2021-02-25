Public Class FormasCanjes
    Implements ERM.Dia.Agenda.Visita.ModuloMov.Canjes

    Public Function Capturar(ByVal paroCliente As Cliente) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.Canjes.Capturar

        Dim oFormCanjes As New FormCanjes(paroCliente)

        If oFormCanjes.ShowDialog() = DialogResult.OK Then
            oFormCanjes.Dispose()
            oFormCanjes = Nothing
            Return True
        End If
        oFormCanjes.Dispose()
        oFormCanjes = Nothing
        Return False
    End Function
    Public Shared Function PuntosCliente(ByVal parsClienteClave As String, ByRef pardCaducidad As Date) As Integer
        Dim nPuntos As Integer = 0

        Dim dtPuntos As DataTable
        dtPuntos = oDBVen.RealizarConsultaSQL("Select Saldo,Caducidad from Punto where ClienteClave='" & parsClienteClave & "'", "Puntos")

        If dtPuntos.Rows.Count > 0 Then
            pardCaducidad = dtPuntos.Rows(0)("Caducidad")
            If PrimeraHora(pardCaducidad) < PrimeraHora(Now) Then
                nPuntos = 0
            Else
                nPuntos = dtPuntos.Rows(0)("Saldo")
            End If
        End If

        dtPuntos.Dispose()
        Return nPuntos
    End Function

    Public Shared Function ExisteRegistroCaducidad(ByVal parsClienteClave As String) As Boolean
        Dim iNumReg As Integer = 0

        iNumReg = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from Punto where ClienteClave='" & parsClienteClave & "'")

        Return iNumReg > 0
    End Function

    Public Shared Function InsertarCliCap(ByVal parsCANClave As String, ByVal pardFechaInicial As Date, ByVal pariRango1 As Integer, ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Integer, ByVal parsClienteClave As String, ByVal blnFechaCanje As Boolean) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        sComandoSQL.Append("INSERT INTO CliCap(CLAId,CANClave,FechaInicial,Rango1,ProductoClave,PRUTipoUnidad,ClienteClave,FechaCanje,MFechaHora,MUsuarioID,Enviado ) VALUES (")
        sComandoSQL.Append("'" & oApp.KEYGEN(1) & "',")
        sComandoSQL.Append("'" & parsCANClave & "',")
        sComandoSQL.Append(UniFechaSQL(pardFechaInicial) & ",")
        sComandoSQL.Append(pariRango1 & ",")
        sComandoSQL.Append("'" & parsProductoClave & "',")
        sComandoSQL.Append(pariPRUTipoUnidad & ",")
        sComandoSQL.Append("'" & parsClienteClave & "',")
        If blnFechaCanje Then
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
        Else
            sComandoSQL.Append("null,")
        End If

        sComandoSQL.Append(UniFechaSQL(Now) & ",")
        sComandoSQL.Append("'" & oVendedor.UsuarioId & "',")
        sComandoSQL.Append("0)")

        Dim iRes As Integer = oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

        If iRes <= 0 Then
            Return False
        End If

        Return True
    End Function

    Public Shared Function ActualizaFechaCanje(ByVal parsCANClave As String, ByVal pardFechaInicial As Date, ByVal pariRango1 As Integer, ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Integer, ByVal parsClienteClave As String, ByVal parsCLAId As String) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        sComandoSQL.Append("UPDATE CliCap Set ")
        sComandoSQL.Append("FechaCanje=" & UniFechaSQL(Now) & ",")
        sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
        sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
        sComandoSQL.Append("Enviado=0 ")
        sComandoSQL.Append("WHERE CANClave = '" & parsCANClave & "' and FechaInicial=" & UniFechaSQL(pardFechaInicial) & " ")
        sComandoSQL.Append("AND Rango1=" & pariRango1 & " AND ProductoClave='" & parsProductoClave & "' AND PRUTipoUnidad=" & pariPRUTipoUnidad & " and ClienteClave ='" & parsClienteClave & "' AND CLAId='" & parsCLAId & "'")

        Dim iRes As Integer = oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

        If iRes <= 0 Then
            Return False
        End If

        Return True
    End Function

    Public Shared Function RestarSaldo(ByVal parsCANClave As String, ByVal pardFechaInicial As Date, ByVal pariRango1 As Integer, ByVal parsClaveCliente As String) As Boolean
        Dim iCADRango_Cantidad As Integer
        Dim iPunto_Saldo As Integer
        Dim iRes As Integer = 0

        iCADRango_Cantidad = oDBVen.EjecutarCmdScalarIntSQL("Select Cantidad from CADRango where CANCLave ='" & parsCANClave & "' and FechaInicial=" & UniFechaSQL(pardFechaInicial) & " And Rango1=" & pariRango1)

        iPunto_Saldo = oDBVen.EjecutarCmdScalarIntSQL("Select Saldo from Punto where ClienteClave ='" & parsClaveCliente & "'")

        If iCADRango_Cantidad > iPunto_Saldo Then
            iRes = oDBVen.EjecutarComandoSQL("UPDATE Punto set Saldo = 0 ,Enviado = 0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' where ClienteClave ='" & parsClaveCliente & "'")
        Else
            iRes = oDBVen.EjecutarComandoSQL("UPDATE Punto set Saldo = Saldo-" & iCADRango_Cantidad & ",Enviado = 0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' where ClienteClave ='" & parsClaveCliente & "'")
        End If

        If iRes <= 0 Then
            Return False
        End If

        Return True
    End Function

    Public Shared Sub CargasPorCanje(ByVal pvdtCliCap As DataTable, ByVal pvdtCadPro As DataTable)
        Try
            If pvdtCliCap.Rows.Count > 0 Then
                Dim oTRP As New TransProd
                With oTRP
                    oTRP.Reiniciar(True)
                    .TransProdId = oApp.KEYGEN(1)
                    Dim oModuloMovDetalle As New Modulos.GrupoModuloMovDetalle
                    oModuloMovDetalle.Recuperar(ServicesCentral.TiposModulosMovDet.Cargas, ServicesCentral.TiposTransProd.CargaPorCanje)
                    .FolioActual = Folio.Obtener(oModuloMovDetalle.ModuloMovDetalleClave)
                    .Tipo = ServicesCentral.TiposTransProd.CargaPorCanje
                    .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada
                    .FechaCaptura = PrimeraHora(Now)
                    Dim oModuloMovDet As New Modulos.GrupoModuloMovDetalle
                    oModuloMovDet.Recuperar(ServicesCentral.TiposModulosMovDet.Cargas)
                    .ModuloMovDetalle = oModuloMovDet
                    .Actualizar()
                    Folio.Confirmar(oModuloMovDetalle.ModuloMovDetalleClave)
                End With

                For Each ldr As DataRow In pvdtCliCap.Rows
                    Dim oTRPDetalle As New TransProdDetalle(oTRP.TransProdId, ldr("ProductoClave"), 0)
                    oTRPDetalle = TransProdDetalle.Buscar(oTRP.TransProdId, ldr("ProductoClave"), 1)
                    If oTRPDetalle Is Nothing Then
                        oTRPDetalle = New TransProdDetalle(oTRP.TransProdId, ldr("ProductoClave"), 0)
                        oTRPDetalle.Cantidad = 0
                        oTRPDetalle.TipoUnidad = ldr("PRUTipoUnidad")
                    End If
                    Dim ldr2 As DataRow = pvdtCadPro.Select("CANclave ='" & ldr("CANClave") & "' and FechaInicial ='" & ldr("FechaInicial") & "' and Rango1=" & ldr("Rango1") & " and ProductoClave ='" & ldr("ProductoClave") & "' and PRUTipoUnidad=" & ldr("PRUTipoUnidad"))(0)
                    oTRPDetalle.ActualizarCargaRepartoDec(oTRPDetalle.TransProdDetalleID, ldr2("Cantidad"), 0, ServicesCentral.TiposTransProd.CargaPorCanje)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
