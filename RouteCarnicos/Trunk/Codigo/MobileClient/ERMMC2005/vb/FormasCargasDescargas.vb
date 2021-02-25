Public Class FormasCargasDescargas
    Implements ERM.Dia.CargasDescargas

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle) As Boolean Implements ERM.Dia.CargasDescargas.Capturar
        Dim oFormCargasDescargas As New FormCargasDescargas(paroModuloMovDetActual)

        If oFormCargasDescargas.ShowDialog() = DialogResult.OK Then
            oFormCargasDescargas.Dispose()
            oFormCargasDescargas = Nothing
            'System.GC.Collect()
            Return True
        End If
        oFormCargasDescargas.Dispose()
        oFormCargasDescargas = Nothing
        'System.GC.Collect()
        Return False
    End Function

    Public Shared Function RecuperarTransProd(ByVal parsTransProdID As String) As DataSet
        Try
            Dim dsRes As New DataSet

            oDBVen.RealizarConsultaSQL(dsRes, "Select * from TransProd where TransProdID='" & parsTransProdID & "'", "TransProd")
            oDBVen.RealizarConsultaSQL(dsRes, "Select * from TransProdDetalle where TransProdID='" & parsTransProdID & "'", "TransProdDetalle")

            Return dsRes

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function RegistroEnviado(ByVal parsTransProdID As String, ByVal parsPartida As Integer, ByVal parsProductoClave As String) As Boolean
        Dim dtEnviado As DataTable

        dtEnviado = oDBVen.RealizarConsultaSQL("Select Enviado from TransProd where TransProdID='" & parsTransProdID & "' ", "Transprod")
        If dtEnviado.Rows.Count > 0 And dtEnviado.Rows(0).Item("Enviado").ToString <> "" Then
            If dtEnviado.Rows(0).Item("Enviado") Then
                Return True
            End If
        End If

        dtEnviado = oDBVen.RealizarConsultaSQL("Select Enviado from TransProdDetalle where TransProdID='" & parsTransProdID & "' and partida=" & parsPartida & " and productoclave='" & parsProductoClave & "' ", "TransprodDetalle")
        If dtEnviado.Rows.Count > 0 And dtEnviado.Rows(0).Item("Enviado").ToString <> "" Then
            If dtEnviado.Rows(0).Item("Enviado") Then
                Return True
            End If
        End If

        Return False
    End Function

    Public Shared Function ExistenVisitas() As Boolean
        Dim iNum As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) as total from Visita where TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " AND RUTClave in (select rutclave from ruta)")
        Return iNum > 0
    End Function

    Public Shared Function ExistenPedidosActivos() As Boolean
        Dim iNum As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) as total from TransProd where Tipo=" & ServicesCentral.TiposTransProd.Pedido & " and TipoFase=" & ServicesCentral.TiposFasesPedidos.Captura)
        Return iNum > 0
    End Function

    'Public Shared Function CargasFaseTransferir(ByVal pvdtMovimientos As DataTable) As Boolean
    '    Try
    '        If pvdtMovimientos.Rows.Count > 0 Then
    '            Dim oArr As New ArrayList
    '            Dim sTransProdId As String = String.Empty
    '            For Each oDr As DataRow In pvdtMovimientos.Rows
    '                SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, oDr("CodigoSKU"), oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"))
    '                If Not oArr.Contains(oDr("TransProdId")) Then
    '                    oArr.Add(oDr("TransProdId"))
    '                    sTransProdId &= "'" & oDr("TransProdId") & "',"
    '                End If
    '            Next
    '            If sTransProdId <> String.Empty Then
    '                sTransProdId = Microsoft.VisualBasic.Left(sTransProdId, sTransProdId.Length - 1)
    '                oDBVen.EjecutarComandoSQL("Update TransProd Set TipoFase=1, Notas = null, Enviado=0 where TransProdId in(" & sTransProdId & ")")
    '                oDBVen.EjecutarComandoSQL("Update TransProdDetalle Set Enviado=0 where TransProdId in(" & sTransProdId & ")")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return False
    '    End Try
    '    Return True
    'End Function
End Class
