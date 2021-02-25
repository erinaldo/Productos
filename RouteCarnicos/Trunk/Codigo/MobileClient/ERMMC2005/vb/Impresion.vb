Imports FieldSoftware.PrinterCE_NetCF
Imports System.IO
'Imports Serial

Module Impresion
#Region "VARIABLES"
    Private iLongTot As Integer = 48
    Private tTipoPapel As TipoPapel
    Private dtCOTCampo, dtCORTabla As DataTable
    Private blnMostrarLogo As Boolean = False
    Private blnAgruparPorPrecio As Boolean = False
    Private blnMostrarEquivalencia As Boolean = False
    Private bImpresionEtiquetas As Boolean = False
    Private bTieneDetalle As Boolean
#End Region

#Const Ascii = True
#Region "Impresión Ticket"
#Region "Variables"
    Private htTamanio As Hashtable
    Private iTamanio As Integer = 50
    Private iAlto As Integer = 0
    Private bCambiarTam As Boolean
    Private iTamanioAnt, iAnchoCol, XMax As Integer
    Private nTotalPreliquidado As Integer
#End Region

    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBApp.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBApp.Transaccion = Value
        End Set
    End Property

    Public Sub LlenaTamanios()
        htTamanio = New Hashtable
        'Extech Termica 2"
        AgregarTamanio(1, 53, 48)
        AgregarTamanio(2, 52, 42)
        AgregarTamanio(3, 51, 38)
        AgregarTamanio(4, 50, 32)
        AgregarTamanio(5, 49, 24)
        'Extech Termica 3"
        AgregarTamanio(6, 53, 72)
        AgregarTamanio(7, 52, 64)
        AgregarTamanio(8, 51, 57)
        AgregarTamanio(9, 50, 48)
        AgregarTamanio(10, 49, 36)
        'Extech Impacto 2"
        AgregarTamanio(11, 14, 20)
        AgregarTamanio(12, 28, 40)
        AgregarTamanio(13, 0, 20) '14 + 28
        AgregarTamanio(14, 20, 40)
        'Zebra Termica 2"
        AgregarTamanio(15, 0, 48, 9)
        AgregarTamanio(16, 1, 24, 9)
        AgregarTamanio(17, 2, 48, 18)
        AgregarTamanio(18, 3, 24, 18)
        AgregarTamanio(19, 4, 12, 18)
        AgregarTamanio(20, 5, 24, 36)
        AgregarTamanio(21, 6, 12, 36)
        'Tec Termica 2"
        AgregarTamanio(22, 0, 24)
        AgregarTamanio(23, 1, 32)
    End Sub
    Private Sub RecuperaTamanio(ByVal pvTipoLetra As Integer)
        If htTamanio.Contains(pvTipoLetra) Then
            Dim aTamanio As ArrayList
            aTamanio = htTamanio(pvTipoLetra)
            iTamanio = aTamanio(0)
            iLongTot = aTamanio(1)
            iAlto = aTamanio(2)
            bCambiarTam = (iTamanioAnt <> iTamanio)
            iTamanioAnt = iTamanio
        End If
    End Sub
    Private Sub AgregarTamanio(ByVal pvTipoLetra As Integer, ByVal pvEquivalente As Integer, ByVal pvLongitud As Integer, Optional ByVal pvAlto As Integer = 0)
        Dim aTamanio As New ArrayList
        aTamanio.Add(pvEquivalente)
        aTamanio.Add(pvLongitud)
        aTamanio.Add(pvAlto)
        htTamanio.Add(pvTipoLetra, aTamanio)
    End Sub
    Private Function TamanioDefault() As Integer
        Select Case tTipoPapel
            Case TipoPapel.ExtechTermica2
                Return 1
            Case TipoPapel.ExtechTermica3
                Return 6
            Case TipoPapel.ExtechImpacto2
                Return 11
            Case TipoPapel.ZebraTermica2
                Return 15
            Case TipoPapel.TecTermica2
                Return 22
        End Select
    End Function
    Public Sub ImprimirTicket(ByVal sId As String, ByVal iTipoMov As Integer, ByVal iTipoRec As Integer, ByVal parsArchivo As String, ByVal paroModoImpresion As ModoImpresion, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)
        ImprimirTicket(New String() {sId}, iTipoMov, iTipoRec, parsArchivo, paroModoImpresion, paroCliente, parsVisitaClave, paroVista, parbPreguntarReimpresion)
    End Sub

    Public Sub ImprimirTicket(ByVal sIds As String(), ByVal iTipoMov As Integer, ByVal iTipoRec As Integer, ByVal parsArchivo As String, ByVal paroModoImpresion As ModoImpresion, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)
        Dim Sw As IO.StreamWriter
        If oDBApp.oConexion.State = ConnectionState.Closed Then
            oDBApp.oConexion.Open()
        End If
        Transaccion = oDBApp.oConexion.BeginTransaction()
        Cursor.Current = Cursors.WaitCursor
        'Valores por default
        iTamanio = 50
        iAlto = 0
        bCambiarTam = False
        iAnchoCol = 0
        XMax = 0
        iTamanioAnt = -1
        iLongTot = 48

        Try
            Dim mTickets As ArrayList = ValorReferencia.RecuperaVARVGrupo("MTICKET", New ArrayList(New String() {iTipoRec.ToString()}))

            Dim nTicketConfigurado As Integer = oConHist.Campos("TicketConfigurado")
            Dim sClienteClave As String = String.Empty
            If Not IsNothing(paroCliente) Then
                sClienteClave = paroCliente.ClienteClave
            End If
            If iTipoMov = 8 Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirFactura1(parsArchivo, sIds, Sw, paroVista, paroCliente, parbPreguntarReimpresion)
                Sw.Flush()
                Sw.Close()
                ImprimirArchivo(7, False, parsArchivo, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
            ElseIf iTipoMov = 10 Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirNotaCredito1(parsArchivo, sIds, Sw, paroVista, paroCliente, parbPreguntarReimpresion, False)
                Sw.Flush()
                Sw.Close()
                ImprimirArchivo(7, False, parsArchivo, True, oVendedor.TipoModImp, parbPreguntarReimpresion)

            ElseIf iTipoMov = -1 Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirFactura1(parsArchivo, New String() {sIds(0)}, Sw, paroVista, paroCliente, parbPreguntarReimpresion)
                ImprimirNotaCredito1(parsArchivo, New String() {sIds(1)}, Sw, paroVista, paroCliente, parbPreguntarReimpresion, True)
                Sw.Flush()
                Sw.Close()
                ImprimirArchivo(7, False, parsArchivo, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
            ElseIf nTicketConfigurado = 2 And ((iTipoMov = 1) Or (iTipoMov = 8) Or (iTipoMov = 21)) Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirVenta1(parsArchivo, sIds(0), iTipoMov, Sw, paroCliente, paroVista, parbPreguntarReimpresion)
            ElseIf nTicketConfigurado = 3 And iTipoMov = 1 Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirVenta2(parsArchivo, sIds(0), Sw, paroCliente, paroVista, parbPreguntarReimpresion)
            ElseIf nTicketConfigurado = 4 And iTipoMov = 1 Then
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                ImprimirVenta3(parsArchivo, sIds, Sw, paroCliente, paroVista, parbPreguntarReimpresion)
            ElseIf iTipoMov = 0 And mTickets.Count > 0 Then
                Dim varDesc As ValorReferencia.Descripcion = DirectCast(mTickets(0), ValorReferencia.Descripcion)
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                Select Case Trim(varDesc.Id)
                    Case "1"
                        ImprimirPago1(parsArchivo, sIds(0), Sw, paroCliente, paroVista, parbPreguntarReimpresion)

                End Select
            Else
                Dim RecId As String = ObtenerRECId(iTipoRec)
                If RecId = "NADA" Then
                    MsgBox(paroVista.BuscarMensaje("MsgBox", "E0492").Replace("$0$", ValorReferencia.BuscarEquivalente("TRECIBO", iTipoRec.ToString)))
                    Exit Try
                End If

                Dim dtConfiguracionRecibo As DataTable = oDBApp.RealizarConsultaSQL("Select CORId from ConfiguracionRecibo where TipoRecibo='" & iTipoRec & "' and TipoEstado=1 ", "ConfiguracionRecibo")
                If dtConfiguracionRecibo.Rows.Count <= 0 Then
                    MsgBox(paroVista.BuscarMensaje("MsgBox", "E0492").Replace("$0$", ValorReferencia.BuscarEquivalente("TRECIBO", iTipoRec.ToString)))
                    Exit Try
                End If

                'Crea o limpia el archivo que se va a imprimir
                If Not CreaArchivo(Sw, parsArchivo) Then Exit Sub
                Dim sCampoTemporal As String
                If paroModoImpresion = ModoImpresion.ConVisita AndAlso iTipoMov = "0" Then
                    sCampoTemporal = "ABNId"
                ElseIf iTipoMov = "13" Then
                    sCampoTemporal = "PLIId"
                Else
                    sCampoTemporal = "TransProdId"
                End If
                'Dim Sw As IO.StreamWriter = IO.File.AppendText(Archivo)
                dtCOTCampo = oDBApp.RealizarConsultaSQL("select CORId,COTId,COCId,Nombre,Descripcion from COTCampo where CORId='" & dtConfiguracionRecibo.Rows(0)("CORId") & "' ", "COTCampo")
                dtCORTabla = oDBApp.RealizarConsultaSQL("select CORId,COTId,Nombre from CORTabla where CORId='" & dtConfiguracionRecibo.Rows(0)("CORId") & "' ", "CORTabla")
                If (iTipoMov = 8 And iTipoRec = 24) Then
                    If Not IsNothing(oDBVen.RealizarScalarSQL("select tipofase from transprod where transprodid='" & sIds(0) & "'")) AndAlso oDBVen.RealizarScalarSQL("select tipofase from transprod where transprodid='" & sIds(0) & "'") = 0 Then
                        Sw.WriteLine()
                        Dim Linea As String = ""
                        For i As Integer = 1 To iLongTot
                            If i = Math.Round(iLongTot / 2, 0) - Math.Round((paroVista.BuscarMensaje("MsgBox", "XCancelada").Length + 2) / 2, 0) Then
                                Linea &= " " & paroVista.BuscarMensaje("MsgBox", "XCancelada").ToUpper & " "
                                i = i + paroVista.BuscarMensaje("MsgBox", "XCancelada").Length + 2
                            Else
                                Linea &= "*"
                            End If
                        Next

                        Sw.WriteLine(Linea)

                    End If
                End If
                CreaEncabezadoPie(RecId, Sw, 1, sIds(0), iTipoRec, paroCliente, paroVista) 'Encabezado y notas de encabezado
                CreaGenerales(sIds(0), RecId, Sw, sCampoTemporal) 'Detalle Generales
                CreaDetalle(sIds(0), RecId, Sw, iTipoMov, sCampoTemporal, paroVista) 'Detalle Contenido (titulos y la info en sí)
                CreaEncabezadoPie(RecId, Sw, 2, sIds(0), iTipoRec, paroCliente, paroVista) 'Pié de página y notas de encabezado
                dtCOTCampo.Dispose()
                dtCOTCampo = Nothing
                dtCORTabla.Dispose()
                dtCORTabla = Nothing
                dtConfiguracionRecibo.Dispose()
                Sw.Flush()
                Sw.Close()

                ImprimirArchivo(7, False, parsArchivo, blnMostrarLogo, tTipoPapel, parbPreguntarReimpresion)
            End If

        Catch ex As SqlServerCe.SqlCeException
            Sw.Flush()
            Sw.Close()
            MsgBox("SQL Error: " & ex.Message, MsgBoxStyle.Information, "Imprimir")
        Catch ex As Exception
            Sw.Flush()
            Sw.Close()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Information, "Imprimir")
        End Try
        Cursor.Current = Cursors.Default
        Transaccion.Rollback()
        Transaccion.Dispose()
        Transaccion = Nothing
        If oDBApp.oConexion.State = ConnectionState.Open Then
            oDBApp.oConexion.Close()
        End If
    End Sub
    Private Sub ImprimeEquivalencia(ByVal nTipoAlineacion As Integer, ByVal sCadena As String, ByRef SW As IO.StreamWriter)
        AlineaCadena(nTipoAlineacion, sCadena)
        If bCambiarTam Or tTipoPapel = TipoPapel.ExtechImpacto2 Then
            If tTipoPapel = TipoPapel.ZebraTermica2 Then
                sCadena = "{" & iTamanio & " " & iAlto & "}" & sCadena
            ElseIf tTipoPapel = TipoPapel.TecTermica2 Then
                If iTamanio = 0 Then
                    sCadena = Chr(27) & "KVA016016" & "sCadena"
                ElseIf iTamanio = 1 Then
                    sCadena = Chr(27) & "KA" & "sCadena"
                End If

            Else
                sCadena = "{" & iTamanio & "}" & sCadena
            End If
        End If
        SW.WriteLine(sCadena)
    End Sub
    Private Function ObtenerRECId(ByVal sTipo As Integer) As String
        'TODO: Probar cambio BD
        Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select RECId, AgruparPorPrecio, MostrarLogo, MostrarEquivalencia, TipoPapel from Recibo where Tipo=" & sTipo & " and Predeterminado=1", "RECId")
        Dim sRECId As String
        If Dt.Rows.Count > 0 Then
            sRECId = Dt.Rows(0)("RECId")
            blnAgruparPorPrecio = Dt.Rows(0)("AgruparPorPrecio")
            blnMostrarLogo = Dt.Rows(0)("MostrarLogo")
            blnMostrarEquivalencia = Dt.Rows(0)("MostrarEquivalencia")
            tTipoPapel = Dt.Rows(0)("TipoPapel")
            Dt.Dispose()
            Return sRECId
        Else
            Dt.Dispose()
            Return "NADA"
        End If
    End Function
    Public Sub ImprimirTicketSinForma(ByVal paroModoImpresion As ModoImpresion, ByVal sId As String, ByVal iTipoMov As Integer, ByVal iTipoRec As Integer, Optional ByVal paroCliente As Cliente = Nothing, Optional ByVal parsVisitaClave As String = "", Optional ByVal parbPreguntarReimpresion As Boolean = True)
        Dim oVista As Vista
        If Not Vista.Buscar("FormImpresionTickets", oVista) Then
            Exit Sub
        End If
        LlenaTamanios()
        ImprimirTicket(New String() {sId}, iTipoMov, iTipoRec, "\Impresion.txt", paroModoImpresion, paroCliente, parsVisitaClave, oVista, parbPreguntarReimpresion)
    End Sub

    Public Sub ImprimirTicketSinForma(ByVal paroModoImpresion As ModoImpresion, ByVal sIds As String(), ByVal iTipoMov As Integer, ByVal iTipoRec As Integer, Optional ByVal paroCliente As Cliente = Nothing, Optional ByVal parsVisitaClave As String = "", Optional ByVal parbPreguntarReimpresion As Boolean = True)
        Dim oVista As Vista
        If Not Vista.Buscar("FormImpresionTickets", oVista) Then
            Exit Sub
        End If
        LlenaTamanios()
        ImprimirTicket(sIds, iTipoMov, iTipoRec, "\Impresion.txt", paroModoImpresion, paroCliente, parsVisitaClave, oVista, parbPreguntarReimpresion)
    End Sub

    Private Sub CreaDetalle(ByVal sId As String, ByVal sRecId As String, ByRef Sw As IO.StreamWriter, ByVal pvTipoMov As Integer, ByVal parsCampoTemporal As String, ByVal paroVista As Vista)
        If pvTipoMov <> 13 Then
            ObtieneTitulos(sId, sRecId, Sw)
            If Not bTieneDetalle Then Exit Sub
            If bImpresionEtiquetas Then
                ImprimeLineaPunteada(Sw, iLongTot)
            End If
        End If

        ObtieneDetalles(sId, sRecId, Sw, pvTipoMov, parsCampoTemporal, paroVista)

        If pvTipoMov = 1 And blnAgruparPorPrecio Then
            Dim Q As System.Text.StringBuilder = New System.Text.StringBuilder
            Q.Append("select TPD.TipoUnidad, TPD.Precio, sum(TPD.Cantidad * PRD.Factor) as CantidadProducto ")
            Q.Append("from TransProdDetalle TPD ")
            Q.Append("inner join ProductoDetalle PRD on TPD.ProductoClave = PRD.ProductoClave and TPD.TipoUnidad = PRD.PRUTipoUnidad ")
            Q.Append("where TPD.TransProdId = '" & sId & "' ")
            Q.Append("group by TPD.TipoUnidad, TPD.Precio ")
            Q.Append("order by TPD.TipoUnidad, TPD.Precio ")
            Dim dtDetUnidad As DataTable = oDBVen.RealizarConsultaSQL(Q.ToString, "DetUnidad")
            Q = Nothing
            'Total de Productos por Precio
            ImprimeLineaPunteada(Sw, iLongTot)
            Sw.WriteLine(paroVista.BuscarMensaje("MsgBox", "XTotalPrecio"))
            For Each dr As DataRow In dtDetUnidad.Rows
                Dim Cad As String = CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 22, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(FormatNumber(Math.Round(Double.Parse(dr("Precio")), 2), 2), 11, Alineacion.Derecha, False)
                Cad &= " = " & CompletaHasta(dr("CantidadProducto"), 5, Alineacion.Derecha, True)
                Sw.WriteLine(Cad)
            Next
        End If
    End Sub
    Private Sub ObtieneDetalles(ByVal sId As String, ByVal sRecId As String, ByRef sw As IO.StreamWriter, ByVal pvTipo As Integer, ByVal parsCampoTemporal As String, ByVal paroVista As Vista)
        Try
            Dim NombreTabla, NombreCampo, NombresCampos As String
            Dim htCampos As New Hashtable
            NombresCampos = ""
            'TODO: Probar cambio BD
            Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select corid, cotid, cocid, TipoAlineacion, TipoSeparador, Tamanio, CantidadEspacio, TipoEspacio, TipoFormato, OrdenY from REODetalle where RECId='" & sRecId & "' order by ordeny, ordenx", "ObtieneDetalle")
            Dim n As Integer = Dt.Rows.Count
            Dim ArrTablas As New ArrayList
            Dim Tablas As String
            'Dim nRenglon As Integer
            'If Dt.Rows.Count > 0 Then
            '    nRenglon = Dt.Rows(0)("OrdenY")
            'End If
            For Each Dr As DataRow In Dt.Rows
                Dim aConfig As New ArrayList
                '*****************
                NombreTabla = ObtieneTablaNombre(Dr("corid"), Dr("cotid"))
                NombreCampo = ObtieneCampoNombre(Dr("corid"), Dr("cotid"), Dr("cocid"))
                NombresCampos &= NombreTabla & "." & NombreCampo & ","
                aConfig.Add(Dr("TipoAlineacion"))
                aConfig.Add(Dr("TipoSeparador"))
                If pvTipo = 13 Then
                    Select Case NombreCampo.ToUpper
                        Case "FECHADEPOSITO"
                            aConfig.Add(10)
                        Case "TIPOBANCO"
                            aConfig.Add(9)
                        Case "REFERENCIA"
                            aConfig.Add(12)
                        Case "TOTAL"
                            aConfig.Add(7)
                        Case "FICHA"
                            aConfig.Add(6)
                        Case "TIPOEFECTIVO"
                            aConfig.Add(20)
                        Case Else
                            aConfig.Add(Dr("Tamanio"))
                    End Select
                Else
                    aConfig.Add(Dr("Tamanio"))
                End If
                aConfig.Add(Dr("CantidadEspacio"))
                aConfig.Add(Dr("TipoEspacio"))
                aConfig.Add(IIf(IsDBNull(Dr("TipoFormato")), 0, Dr("TipoFormato")))
                aConfig.Add(Dr("OrdenY"))
                'aConfig.Add(Dr("TipoLetra"))
                If Not htCampos.Contains(NombreCampo.ToUpper) Then
                    htCampos.Add(NombreCampo.ToUpper, aConfig)
                End If
                If Not ArrTablas.Contains(NombreTabla) Then
                    ArrTablas.Add(NombreTabla)
                End If
                '*****************
            Next
            Dt.Dispose()
            If NombresCampos.Length > 0 Then
                NombresCampos = Microsoft.VisualBasic.Left(NombresCampos, NombresCampos.Length - 1)
            End If
            'Saco las tablas que se usaron
            Tablas = ""
            For i As Integer = 0 To ArrTablas.Count - 1
                Tablas &= ArrTablas(i) & ","
            Next
            Tablas = Microsoft.VisualBasic.Left(Tablas, Tablas.Length - 1)
            'Veo de donde tengo que tomar el detalle
            If pvTipo = 13 Then
                GuardaDetallesPreliquidacion(NombresCampos, Tablas, parsCampoTemporal, sId, sw, htCampos, sRecId, paroVista)
            Else
                GuardaDetalles(NombresCampos, Tablas, parsCampoTemporal, sId, sw, n, pvTipo, htCampos)
            End If

            '*********************
            'If YActual <> -1 Then
            '    sw.WriteLine(Cadena)
            'End If
            '*********************
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneDetalles")
        End Try
    End Sub
    Private Sub GuardaDetallesPreliquidacion(ByVal Campos As String, ByVal Tabla As String, ByVal CampoTemporal As String, ByVal sId As String, ByRef Sw As IO.StreamWriter, ByRef pvHTCampos As Hashtable, ByVal sRecId As String, ByVal paroVista As Vista)
        Dim Query As String
        Dim dtDetalle As DataTable
        Dim sCadena As String = ""
        Dim sCadenaTmp As String
        Dim bTipoEfectivo As Boolean = True
        Dim nTotalTipo As Double
        nTotalPreliquidado = 0

        If InStr(Campos, "TipoEfectivo", CompareMethod.Text) = 0 Then
            bTipoEfectivo = False
            Campos &= ",PLBPLE.TipoEfectivo"
        End If

        Query = "select " & Campos & " from " & Tabla & " where " & CampoTemporal & "='" & sId & "'"
        dtDetalle = oDBVen.RealizarConsultaSQL(Query, "PLBPLE")
        Dim drDetalles() As DataRow

        'Titulos para depositos
        Sw.WriteLine()
        ObtieneTitulos(sId, sRecId, Sw, True, True)
        If bImpresionEtiquetas Then
            ImprimeLineaPunteada(Sw, iLongTot)
        End If
        nTotalTipo = 0
        If dtDetalle.Columns.Contains("TipoBanco") Then
            drDetalles = dtDetalle.Select("not TipoBanco is null")
            For Each drDetalle As DataRow In drDetalles
                sCadena = ""
                For Each dcDetalle As DataColumn In dtDetalle.Columns
                    If InStr("FechaPreliquidacion, FechaDeposito, TipoBanco, Referencia, Total, Ficha", dcDetalle.ColumnName, CompareMethod.Text) > 0 Then
                        If dcDetalle.ColumnName = "TipoBanco" Then
                            sCadenaTmp = Trim(ValorReferencia.BuscarEquivalente("TBANCO", drDetalle(dcDetalle.Ordinal)))
                        Else
                            sCadenaTmp = Trim(drDetalle(dcDetalle.Ordinal))
                            If dcDetalle.ColumnName = "Total" Then
                                nTotalTipo += Decimal.Parse(drDetalle(dcDetalle.Ordinal))
                            End If
                        End If
                        ConfiguraColumnaDetalle(pvHTCampos, dcDetalle.ColumnName.ToUpper, sCadenaTmp)
                        sCadena &= sCadenaTmp
                    End If
                Next
                If sCadena <> "" Then
                    Sw.WriteLine(sCadena)
                End If
            Next
        End If
        nTotalPreliquidado += nTotalTipo
        sCadena = paroVista.BuscarMensaje("MsgBox", "XTotalDeposito") & " = " & nTotalTipo.ToString("#,##0.00")
        TextoDerecha(sCadena, iLongTot)
        Sw.WriteLine(sCadena)


        'Titulos para efectivo
        Sw.WriteLine()
        ObtieneTitulos(sId, sRecId, Sw, True, False)
        If bImpresionEtiquetas Then
            ImprimeLineaPunteada(Sw, iLongTot)
        End If
        nTotalTipo = 0
        If dtDetalle.Columns.Contains("TipoEfectivo") Then
            drDetalles = dtDetalle.Select("not TipoEfectivo is null")
            For Each drDetalle As DataRow In drDetalles
                sCadena = ""
                Dim sGrupo As String = ""
                Dim sValor As String = ""
                Dim sTotal As String = ""
                Dim nValor As Decimal = 0
                Dim nTotal As Decimal = 0
                Dim nCant As Integer = 0
                For Each dcDetalle As DataColumn In dtDetalle.Columns
                    If InStr("FechaPreliquidacion, TipoEfectivo, Total", dcDetalle.ColumnName, CompareMethod.Text) > 0 Then
                        If dcDetalle.ColumnName = "TipoEfectivo" Then
                            If nCant = 0 Then
                                nCant = Integer.Parse(drDetalle("Total"))
                            End If
                            If bTipoEfectivo Then
                                sGrupo = Trim(ValorReferencia.RecuperaGrupo("DENOMINA", drDetalle(dcDetalle.Ordinal)))
                                Select Case sGrupo
                                    Case "1"
                                        sGrupo = paroVista.BuscarMensaje("MsgBox", "XBillete")
                                    Case "2"
                                        sGrupo = paroVista.BuscarMensaje("MsgBox", "XMonedas")
                                End Select
                            End If
                            If sValor = "" Then
                                sValor = Trim(ValorReferencia.BuscarEquivalente("DENOMINA", drDetalle(dcDetalle.Ordinal)))
                            End If
                            sCadenaTmp = sValor
                        ElseIf dcDetalle.ColumnName = "Total" Then
                            If sValor = "" Then
                                sValor = Trim(ValorReferencia.BuscarEquivalente("DENOMINA", drDetalle("TipoEfectivo")))
                            End If
                            If sValor <> "" Then
                                nValor = Decimal.Parse(sValor)
                                If nCant = 0 Then
                                    nCant = Integer.Parse(drDetalle(dcDetalle.Ordinal))
                                End If
                                nTotal = nCant * nValor
                                sTotal = nTotal.ToString
                                nTotalTipo += nTotal
                            End If
                            sCadenaTmp = sTotal
                        Else
                            sCadenaTmp = Trim(drDetalle(dcDetalle.Ordinal))
                        End If
                        If dcDetalle.ColumnName = "TipoEfectivo" And bTipoEfectivo Then
                            sTotal = nCant.ToString
                            CompletaColumna(sTotal, 3, 3, 0, 0)
                            CompletaColumna(sGrupo, 8, 1, 0, 0)
                            CompletaColumna(sCadenaTmp, 7, 3, 0, 0)
                            sCadenaTmp = sTotal & " " & sGrupo & " " & sCadenaTmp
                        End If
                        ConfiguraColumnaDetalle(pvHTCampos, dcDetalle.ColumnName.ToUpper, sCadenaTmp)
                        sCadena &= sCadenaTmp
                    End If
                Next
                If sCadena <> "" Then
                    Sw.WriteLine(sCadena)
                End If
            Next
        End If
        nTotalPreliquidado += nTotalTipo
        sCadena = paroVista.BuscarMensaje("MsgBox", "XTotalEfectivo") & " = " & nTotalTipo.ToString("#,##0.00")
        TextoDerecha(sCadena, iLongTot)
        Sw.WriteLine(sCadena)

        dtDetalle.Dispose()
    End Sub
    Private Sub ConfiguraColumnaDetalle(ByVal htCampos As Hashtable, ByVal sColumnName As String, ByRef sCadenaTmp As String)
        Dim aConfig As ArrayList
        If htCampos.Contains(sColumnName) Then
            aConfig = htCampos(sColumnName)
            'RecuperaTamanio(aConfig(5))
            CompletaColumna(sCadenaTmp, aConfig(2), aConfig(0), aConfig(1), aConfig(5))
            If aConfig(3) > 0 Then
                AgregaEspaciosColumna(aConfig(4), sCadenaTmp, aConfig(3))
            End If
        End If
    End Sub
    Private Function ObtieneCampoNombre(ByVal CORId As String, ByVal COTId As String, ByVal COCId As String) As String
        Try
            Return dtCOTCampo.Select("CORId='" & CORId & "' and COTId='" & COTId & "' and COCId='" & COCId & "'")(0)("Nombre")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return String.Empty
    End Function
    Private Function ObtieneTablaNombre(ByVal CORId As String, ByVal COTId As String) As String
        Try
            Return dtCORTabla.Select("CORId='" & CORId & "' and COTId='" & COTId & "'")(0)("Nombre")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return String.Empty
    End Function
    Private Sub CreaEncabezadoPie(ByVal sRecId As String, ByRef SW As IO.StreamWriter, ByVal iTipo As Integer, ByVal sId As String, ByVal iTipoRec As Integer, ByVal paroCliente As Cliente, ByVal paroVista As Vista)
        Try
            Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select * from RECEncabezadoPie where RECid='" & sRecId & "' and Tipo=" & iTipo & " order by Orden", "Encabezado1")
            Dim cadena As String
            SW.WriteLine()
            Dim nTipoAlineacion As Integer = 1
            Dim nTipoLetra As Integer = TamanioDefault()
            Dim nTipoSeparador As Integer = 1
            Dim nTipoFormato As Integer
            Dim lCadenas As New System.Collections.Generic.Queue(Of String)()

            For Each Dr As DataRow In Dt.Rows
                RecuperaTamanio(Dr("TipoLetra"))
                nTipoFormato = IIf(IsDBNull(Dr("TipoFormato")), 0, Dr("TipoFormato"))
                cadena = ObtieneCadena(Dr, sId, iTipoRec, nTipoFormato, paroCliente, lCadenas)
                Do
                    If lCadenas.Count > 0 Then
                        cadena = lCadenas.Dequeue()
                    End If
                    AlineaCadena(Dr("tipoalineacion"), cadena)
                    If bCambiarTam Or tTipoPapel = TipoPapel.ExtechImpacto2 Then
                        If tTipoPapel = TipoPapel.ZebraTermica2 Then
                            cadena = "{" & iTamanio & " " & iAlto & "}" & cadena

                        ElseIf tTipoPapel = TipoPapel.TecTermica2 Then
                            cadena = "{" & iTamanio & "}" & cadena
                        Else
                            cadena = "{" & iTamanio & "}" & cadena
                        End If
                    End If
                    SW.WriteLine(cadena)
                Loop While lCadenas.Count > 0

                nTipoAlineacion = Dr("TipoAlineacion")
                nTipoLetra = Dr("TipoLetra")
                nTipoSeparador = Dr("TipoSeparador")

            Next
            Dt.Dispose()
            'Espacio en blanco
            SW.WriteLine()

            'Mostrar equivalencia para pedido y pagos
            If iTipo = 2 And blnMostrarEquivalencia Then
                CreaEquivalencias(sId, nTipoAlineacion, nTipoLetra, nTipoSeparador, SW, paroVista)
            End If

            'Nota(s) del encabezado
            ObtieneNotas(sRecId, SW, iTipo, paroVista)
            If iTipo = 2 Then
                For k As Integer = 1 To 8
                    SW.WriteLine()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "CreaEncabezado")
        End Try
    End Sub
    Private Sub CreaGenerales(ByVal sId As String, ByVal sRecId As String, ByRef SW As IO.StreamWriter, ByVal parsCampoTemporal As String)
        Dim YActual As Integer
        Dim sCadena = "", TmpCad As String
        'TODO: Probar cambio BD
        Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select max(ordenx) from RECContenido where RECId='" & sRecId & "'", "Generales")
        If Not IsDBNull(Dt.Rows(0).Item(0)) Then
            XMax = Dt.Rows(0).Item(0)
            YActual = -1
            'TODO: Probar cambio BD
            Dt = oDBApp.RealizarConsultaSQL("select * from RECContenido where RECId='" & sRecId & "' order by ordeny, ordenx", "Generales")
            For Each Dr As DataRow In Dt.Rows
                If YActual <> Dr("ordenY") Then
                    If YActual <> -1 Then
                        SW.WriteLine(sCadena)
                    End If
                    YActual = Dr("ordeny")
                    sCadena = ""
                End If
                RecuperaTamanio(Dr("TipoLetra"))
                iAnchoCol = Int(iLongTot / XMax)
                TmpCad = ObtieneCadenaGenerales(sId, Dr, parsCampoTemporal)
                CompletaColumna(TmpCad, iAnchoCol)
                If bCambiarTam Or tTipoPapel = TipoPapel.ExtechImpacto2 Then
                    If tTipoPapel = TipoPapel.ZebraTermica2 Then
                        sCadena = "{" & iTamanio & " " & iAlto & "}" & sCadena
                        'sCadena = "! U1 SETLP 0 " & Tamanio & " " & Alto & sCadena
                    Else
                        sCadena = "{" & iTamanio & "}" & sCadena
                    End If
                End If
                sCadena &= TmpCad
            Next
            If YActual <> -1 Then
                SW.WriteLine(sCadena)
            End If
        End If
        Dt.Dispose()
        SW.WriteLine()
    End Sub
    Private Sub CreaEquivalencias(ByVal sTransProdId As String, ByVal nTipoAlineacion As Integer, ByVal nTipoLetra As Integer, ByVal nTipoSeparador As Integer, ByRef SW As IO.StreamWriter, ByVal paroVista As Vista)
        Dim sConsulta As String
        Dim dtMonedas As DataTable
        Dim sEtiqueta As String
        Dim sDato As String
        Dim sSeparador As String = ""
        Dim sSimbolo As String

        Dim aGrupo As New ArrayList()
        aGrupo.Add("E")
        Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
        If sVarCodigos.Length <= 0 Then Exit Sub

        sConsulta = "select MON.Simbolo, MON.TipoCodigo, MON.Valor, sum(ABD.Importe) as Importe "
        sConsulta &= "from ABNDetalle ABD "
        sConsulta &= "inner join AbnTrp ABT on ABD.ABNId = ABT.ABNId and ABT.TransProdId = '" & sTransProdId & "' "
        sConsulta &= "inner join Moneda MON on ABD.MonedaId = MON.MonedaId "
        sConsulta &= "where ABD.TipoPago in(" & sVarCodigos & ") and not ABD.MonedaId is null "
        sConsulta &= "and ABD.MonedaID <> '" & oConHist.Campos("MonedaID") & "' "
        sConsulta &= "group by ABD.MonedaId, MON.Simbolo, MON.TipoCodigo, MON.Valor "
        dtMonedas = oDBVen.RealizarConsultaSQL(sConsulta, "Monedas")

        sConsulta = "select case when Simbolo is null then '' else Simbolo end as Simbolo from Moneda where MonedaId = '" & oConHist.Campos("MonedaID") & "'"
        sSimbolo = oDBVen.RealizarScalarSQL(sConsulta)

        RecuperaTamanio(nTipoLetra)
        If nTipoSeparador <> 0 Then
            sSeparador = ValorReferencia.BuscarEquivalente("SEPARADO", nTipoSeparador)
        End If

        For Each drMoneda As DataRow In dtMonedas.Rows
            'Equivalencia
            sEtiqueta = paroVista.BuscarMensaje("MsgBox", "XEquivalencia")
            sEtiqueta = CompletaHasta(sEtiqueta, 14, Alineacion.Derecha, True)
            sEtiqueta &= sSeparador & " "

            sDato = drMoneda("Simbolo")
            If drMoneda("Valor") > 0 Then
                sDato &= Double.Parse(drMoneda("Importe") / drMoneda("Valor")).ToString("#,##0.00") & " "
            Else
                sDato &= "0.00 "
            End If
            sDato &= ValorReferencia.BuscarEquivalente("CDGOMON", drMoneda("TipoCodigo"))
            sDato = CompletaHasta(sDato, 12, Alineacion.Derecha, True)
            ImprimeEquivalencia(nTipoAlineacion, sEtiqueta & sDato, SW)

            'Tipo de cambio
            sEtiqueta = paroVista.BuscarMensaje("MsgBox", "XTipoDeCambio")
            sEtiqueta = CompletaHasta(sEtiqueta, 14, Alineacion.Derecha, True)
            sEtiqueta &= sSeparador & " "
            sDato = sSimbolo & Double.Parse(drMoneda("Valor")).ToString("#,##0.00")
            sDato = CompletaHasta(sDato, 12, Alineacion.Derecha, True)
            ImprimeEquivalencia(nTipoAlineacion, sEtiqueta & sDato, SW)
        Next
        SW.WriteLine()
    End Sub
    Private Sub AlineaCadena(ByVal IdAli As Integer, ByRef cadena As String)
        Select Case IdAli
            Case 0, 1 'No definido e izquierda
                'En teoría no hago nada, así viene por default
            Case 2 'Centro
                cadena = TextoCentrado(cadena, iLongTot)
            Case 3 'Derecha
                TextoDerecha(cadena, iLongTot)
        End Select
    End Sub
    Private Sub ObtieneTitulos(ByVal sId As String, ByVal sRecId As String, ByRef sw As IO.StreamWriter, Optional ByVal bPreliquidacion As Boolean = False, Optional ByVal bDeposito As Boolean = True)
        Try
            Dim YActual As Integer
            Dim iContCol As Integer = 1
            Dim iCaracteres As Integer = 0
            Dim sCadena = "", TmpCad As String
            'TODO: Probar cambio BD
            Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select max(ordenx) from REODetalle where RECId='" & sRecId & "'", "MaxTitulos")
            Dim bPrimerCol As Boolean = True
            If IsDBNull(Dt.Rows(0).Item(0)) Then
                bTieneDetalle = False
                Exit Sub
            Else
                bTieneDetalle = True
            End If
            XMax = Dt.Rows(0).Item(0)
            'AnchoCol = Int(LongTot / XMax)
            YActual = -1
            'TODO: Probar cambio BD
            Dt = oDBApp.RealizarConsultaSQL("select * from REODetalle where RECId='" & sRecId & "' order by ordeny, ordenx", "Titulos")
            For Each Dr As DataRow In Dt.Rows
                If YActual <> Dr("ordenY") Then
                    If YActual <> -1 Then
                        sw.WriteLine(sCadena)
                    End If
                    YActual = Dr("ordeny")
                    sCadena = ""
                End If
                If bPrimerCol Then
                    RecuperaTamanio(Dr("TipoLetra"))
                    bPrimerCol = False
                Else
                    bCambiarTam = False
                End If
                iAnchoCol = Int(iLongTot / XMax)
                TmpCad = ObtieneCadenaDetallesT(sId, Dr, bPreliquidacion, bDeposito)
                If bCambiarTam Or tTipoPapel = TipoPapel.ExtechImpacto2 Then
                    If tTipoPapel = TipoPapel.ZebraTermica2 Then
                        TmpCad = "{" & iTamanio & " " & iAlto & "}" & TmpCad
                        'TmpCad = "! U1 SETLP 0 " & Tamanio & " " & Alto & TmpCad
                    Else
                        TmpCad = "{" & iTamanio & "}" & TmpCad
                    End If
                End If
                sCadena &= TmpCad
                iContCol += 1
            Next
            Dt.Dispose()
            If YActual <> -1 Then
                sw.WriteLine(sCadena)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ObtieneTitulos")
        End Try
    End Sub
    Private Sub GuardaDetalles(ByVal Campos As String, ByVal Tabla As String, ByVal CampoTemporal As String, ByVal sId As String, ByRef Sw As IO.StreamWriter, ByVal n As Integer, ByVal pvTipo As Integer, ByVal pvHTCampos As Hashtable)
        Dim Query, Cadena, TmpCad As String
        Dim aConfig As ArrayList
        If pvTipo = 8 Then
            Query = "select " & Campos & " from " & Tabla & " where " & CampoTemporal & " in (" & ObtenerIdsPedidosDeFactura(sId) & ")"
        ElseIf pvTipo = 0 And InStr(Tabla.ToUpper, "TRANSPROD", CompareMethod.Text) Then
            Tabla = Tabla.ToUpper.Replace(",TRANSPROD", "")
            Tabla = Tabla.ToUpper.Replace("TRANSPROD,", "")
            Query = "select " & Campos & " from " & Tabla & " left join abntrp on abntrp.abnid=abndetalle.abnid left join transprod on transprod.transprodid=abntrp.transprodid where abndetalle.abnid='" & sId & "'"
        ElseIf pvTipo = 24 And InStr(Tabla.ToUpper, "TRPTPD", CompareMethod.Text) Then
            Tabla = Tabla.ToUpper.Replace(",TRANSPRODDETALLE", "")
            Tabla = Tabla.ToUpper.Replace("TRANSPRODDETALLE,", "")
            Campos = Campos.ToUpper().Replace("TRPTPD.CLAVEPRODUCTO", "Producto.ProductoClave as ClaveProducto")
            Campos = Campos.ToUpper().Replace("TRPTPD.NOMBREPRODUCTO", "Producto.Nombre as NombreProducto")
            Campos = Campos.ToUpper().Replace("TRPTPD.DEVOLUCION", " (CASE IsNull(TrpTpd.cantidad) WHEN 1 THEN 0 ELSE TrpTpd.cantidad END) AS Devolucion ")
            Campos = Campos.ToUpper().Replace("TRANSPRODDETALLE.LIQUIDAR", " (TransProdDetalle.cantidad - (CASE ISNULL(TRPTPD.CANTIDAD) WHEN 1 THEN 0 ELSE TRPTPD.CANTIDAD END)) AS Liquidar ")
            Campos = Campos.ToUpper.Replace("TRANSPRODDETALLE.IMPORTE", "(TransProdDetalle.Total/TransProdDetalle.Cantidad) as importe ")
            Query = "select " & Campos & " from  TransProdDetalle LEFT JOIN TrpTpd ON TransProdDetalle.TransProdDetalleId = TrpTpd.TransProdDetalleId AND TransProdDetalle.TransProdId = TrpTpd.TransProdId1 INNER JOIN Producto on TransProdDetalle.ProductoClave = Producto.ProductoClave WHERE TransProdDetalle.TransProdId='" & sId & "'"
        ElseIf pvTipo = 1 Or pvTipo = 24 Or pvTipo = 19 Or pvTipo = 21 Then 'Pedido, Consignacion,  Mov Sin Inv S/Visita, Mov Sin Inv C/Visita
            Campos = Campos.ToUpper().Replace("TRANSPRODDETALLE.IMPORTE", "(TransProdDetalle.Total/TransProdDetalle.Cantidad) as importe ")
            Query = "select " & Campos & " from " & Tabla & " where " & CampoTemporal & "='" & sId & "'"
        Else
            Query = "select " & Campos & " from " & Tabla & " where " & CampoTemporal & "='" & sId & "'"
        End If
        If InStr(Campos, "producto.nombre", CompareMethod.Text) <> 0 And Not (InStr(Tabla.ToUpper, "TRPTPD", CompareMethod.Text) = 1 And pvTipo = 24) Then
            Query &= " and producto.productoclave=transproddetalle.productoclave"
        End If
        Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Query, "DetalleTicket")
        For Each Dr As DataRow In Dt2.Rows
            Cadena = ""
            'TODO: Parche jpacheco
            'Dim iContCol As Integer = 1
            Dim iCaracteres As Integer = 1

            Dim nRenglon As Integer
            If Dt2.Columns.Count > 0 Then
                aConfig = pvHTCampos(Dt2.Columns(0).ColumnName.ToUpper)
                nRenglon = aConfig(6)
            End If
            For Each Dc As DataColumn In Dt2.Columns

                If CampoTemporal = "TransProdId" AndAlso Dc.ColumnName = "TipoUnidad" Then
                    TmpCad = Trim(ValorReferencia.BuscarEquivalente("UNIDADV", Dr(Dc.Ordinal)))
                ElseIf CampoTemporal = "ABNId" AndAlso Dc.ColumnName = "TipoPago" Then
                    TmpCad = Trim(ValorReferencia.BuscarEquivalente("PAGO", Dr(Dc.Ordinal)))
                ElseIf CampoTemporal = "ABNId" AndAlso Dc.ColumnName = "TipoBanco" Then
                    TmpCad = ""
                    If Not IsDBNull(Dr(Dc.Ordinal)) Then
                        TmpCad = Trim(ValorReferencia.BuscarEquivalente("TBANCO", Dr(Dc.Ordinal)))
                    End If
                Else
                    If IsDBNull(Dr(Dc.Ordinal)) Then
                        TmpCad = ""
                    Else
                        TmpCad = Trim(Dr(Dc.Ordinal))
                    End If

                End If
                If pvHTCampos.Contains(Dc.ColumnName.ToUpper) Then
                    aConfig = pvHTCampos(Dc.ColumnName.ToUpper)
                    'RecuperaTamanio(aConfig(5))
                    CompletaColumna(TmpCad, aConfig(2), aConfig(0), aConfig(1), aConfig(5))
                    If aConfig(3) > 0 Then
                        AgregaEspaciosColumna(aConfig(4), TmpCad, aConfig(3))
                    End If
                    'If bCambiarTam Then
                    '    TmpCad = "{" & Tamanio & "}" & TmpCad
                    'End If
                    If nRenglon <> aConfig(6) Then
                        Sw.WriteLine(Cadena)
                        Cadena = ""
                    End If
                    nRenglon = aConfig(6)
                End If
                Cadena &= TmpCad
                'iContCol += 1
            Next
            Sw.WriteLine(Cadena)
        Next
        Dt2.Dispose()
    End Sub
    Private Sub TextoDerecha(ByRef cadena As String, ByVal pariLongTotal As Integer)
        Dim espacios As String = ""
        Dim ls As Integer = cadena.Length
        Dim i As Integer
        For i = 1 To (pariLongTotal - ls)
            espacios &= " "
        Next
        cadena = espacios & cadena
    End Sub
    Private Sub AgregaEspaciosColumna(ByVal pvTipoEspacio As Integer, ByRef pvCadena As String, ByVal pvCantidadEspacio As Integer)
        If pvCantidadEspacio > 0 Then
            Select Case pvTipoEspacio
                Case 1 'Antes
                    pvCadena = pvCadena.PadLeft(pvCadena.Length + pvCantidadEspacio, " ")
                Case 2 'Despues
                    pvCadena = pvCadena.PadRight(pvCadena.Length + pvCantidadEspacio, " ")
                Case 3 'Ambos
                    pvCadena = pvCadena.PadLeft(pvCadena.Length + pvCantidadEspacio, " ")
                    pvCadena = pvCadena.PadRight(pvCadena.Length + pvCantidadEspacio, " ")
            End Select
        End If
    End Sub
    Private Function ObtenerIdsPedidosDeFactura(ByVal pvFacturaId As String) As String
        Dim sIds As String = ""
        Dim lsQuery As String = "select transprodid from transprod where facturaid='" & pvFacturaId & "' and tipo=1"
        Dim lDt As DataTable = oDBVen.RealizarConsultaSQL(lsQuery, "Mexicanada")
        For Each lDr As DataRow In lDt.Rows
            sIds &= "'" & lDr("transprodid") & "',"
        Next
        lDt.Dispose()
        If sIds.Length > 0 Then
            sIds = Microsoft.VisualBasic.Left(sIds, sIds.Length - 1)
        Else
            sIds = "''"
        End If
        Return sIds
    End Function
    Private Sub ObtieneCampo(ByVal CORId As String, ByVal COTId As String, ByVal COCId As String, ByRef parsDescripcion As String, ByRef parsNombreCampo As String)
        Try
            Dim dr As DataRow = dtCOTCampo.Select("CORId='" & CORId & "' and COTId='" & COTId & "' and COCId='" & COCId & "'")(0)
            parsDescripcion = IIf(IsDBNull(dr("Descripcion")), String.Empty, dr("Descripcion"))
            parsNombreCampo = dr("Nombre")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function ObtieneCadena(ByVal Dr As DataRow, ByVal sId As String, ByVal iTipoRec As Integer, ByVal nTipoFormato As Integer, ByVal paroCliente As Cliente, Optional ByVal lCadena As System.Collections.Generic.Queue(Of String) = Nothing) As String
        Dim sCadena As String = String.Empty, Query As String = String.Empty
        Dim blnObtenerBonificaciones As Boolean = False
        Dim blnAplicacion As Boolean = False
        Dim sDescripcion As String = String.Empty, sNombreCampo As String = String.Empty
        Dim sNombreTabla As String = String.Empty
        ObtieneCampo(Dr("corid"), Dr("cotid"), Dr("cocid"), sDescripcion, sNombreCampo)
        sNombreTabla = ObtieneTablaNombre(Dr("corid"), Dr("cotid"))
        If Dr("tipoetiqueta") = 1 Then
            sCadena = sDescripcion
            If Dr("tiposeparador") <> 0 Then
                sCadena &= ValorReferencia.BuscarEquivalente("SEPARADO", Dr("tiposeparador")) & " "
            End If
        End If
        If sNombreTabla.ToUpper = "PRELIQUIDACION" And sNombreCampo.ToUpper = "PRELIQUIDACION" Then
            sCadena &= nTotalPreliquidado.ToString("#,##0.00")
        ElseIf iTipoRec = 24 And sNombreTabla.ToUpper = "TRANSPROD" And sNombreCampo.ToUpper() = "IMPUESTO" And Not paroCliente Is Nothing AndAlso paroCliente.DesgloseImpuesto Then
            Dim oTrp As New TransProd()
            Dim lImp As New ArrayList()
            Dim lImporte As New ArrayList()
            Dim lTasa As New ArrayList()
            oTrp.ImpuestosConDesc(sId, paroCliente.ClienteClave, lImp, lTasa, lImporte)
            For i As Integer = 0 To lImp.Count - 1
                Query = lImp(i).ToString() + " " + lTasa(i).ToString() + "% "
                Dim cadTmp As String = lImporte(i).ToString()
                Select Case nTipoFormato
                    Case 1
                        cadTmp = Double.Parse(cadTmp).ToString("#,##0")
                    Case 2
                        cadTmp = Double.Parse(cadTmp).ToString("#,##0.00")
                End Select
                cadTmp = cadTmp.Replace(vbCrLf, " ")
                Query += cadTmp
                lCadena.Enqueue(Query)
            Next
            oTrp.Dispose()
            lImp.Clear()
            lImporte.Clear()
            lTasa.Clear()
            Query = ""
            sCadena = ""
        Else
            If sNombreTabla.ToUpper = "FOLIOFISCAL" And iTipoRec = 24 Then
                Dim dtFolio As DataTable
                Query = "select FolioId, FOSId from TRPDatoFiscal where TransProdId = '" & sId & "'"
                dtFolio = oDBVen.RealizarConsultaSQL(Query, "FolioFiscal")
                If dtFolio.Rows.Count > 0 Then
                    Dim sFolioId As String = dtFolio.Rows(0)("FolioId")
                    Dim sFOSId As String = dtFolio.Rows(0)("FOSId")
                    Query = "select " & sNombreCampo & " from FolioFiscal where FolioId = '" & sFolioId & "' and FOSId = '" & sFOSId & "'"
                End If
            ElseIf (sNombreTabla.ToUpper = "TPDDES" Or sNombreTabla.ToUpper = "TPDDESVENDEDOR") And sNombreCampo.ToUpper = "DESIMPORTE" And iTipoRec = 24 Then
                Query = "select round(sum(DesImporte),2) from " & sNombreTabla & " where TransProdId in (" & ObtenerIdsPedidosDeFactura(sId) & ")"
            ElseIf sNombreTabla.ToUpper = "TRANSPROD" And iTipoRec = 26 And sNombreCampo.ToUpper() <> "SALDO" Then
                Dim sTempCampo As String = sNombreCampo
                Select Case sNombreCampo.ToUpper()
                    Case "TOTALLIQUIDAR"
                        sTempCampo = "SUM(TransProdDetalle.Total - (CASE ISNULL(TRPTPD.Total) WHEN 1 THEN 0 ELSE TRPTPD.Total END)) as TOTALLIQUIDAR"
                    Case "TOTALDEVOLUCION"
                        sTempCampo = "SUM(CASE ISNULL(TRPTPD.Total) WHEN 1 THEN 0 ELSE TRPTPD.Total END)as TOTALDEVOLUCION"
                End Select
                Query = "select " + sTempCampo + " from Transprod INNER JOIN TransProdDetalle ON  TransProdDetalle.TransProdId = TransProd.TransProdId LEFT JOIN TrpTpd ON TransProdDetalle.TransProdDetalleId = TrpTpd.TransProdDetalleId AND TransProdDetalle.TransProdId = TrpTpd.TransProdId1  where TransProd.TransProdId = '" + sId + "'"
            Else
                Query = "select " & sNombreCampo
                Query &= " from " & sNombreTabla
                If InStr(Query, "transprod", CompareMethod.Text) <> 0 Then
                    If iTipoRec = 10 Then
                        Query = Query.Replace("select ", "select t.TransProdID,t.")
                        Query &= " t  inner join abntrp a on a.transprodid=t.transprodid where a.abnid='" & sId & "'"
                        blnObtenerBonificaciones = True
                    Else
                        Query &= " where transprodid='" & sId & "'"
                    End If
                ElseIf InStr(Query, "TRPDatoFiscal", CompareMethod.Text) <> 0 Then
                    Query &= " where TransProdid='" & sId & "'"
                ElseIf InStr(Query, "Abono", CompareMethod.Text) <> 0 Then
                    Query &= " where abnid='" & sId & "'"
                ElseIf InStr(Query, "Cliente", CompareMethod.Text) <> 0 Then
                    Query &= " where ClienteClave='" & paroCliente.ClienteClave & "'"
                ElseIf InStr(Query, "Configuracion", CompareMethod.Text) <> 0 Then
                    blnAplicacion = True
                ElseIf InStr(Query, "Preliquidacion", CompareMethod.Text) <> 0 Then
                    Query &= " where PLIId = '" & sId & "'"
                End If
            End If

            Dim Dt2 As DataTable
            If blnAplicacion Then
                Dt2 = oDBApp.RealizarConsultaSQL(Query, "ValorCampo")
            Else
                Dt2 = oDBVen.RealizarConsultaSQL(Query, "ValorCampo")
            End If

            If Dt2.Rows.Count > 0 Then
                Dim cadTmp As String

                If blnObtenerBonificaciones Then
                    If sNombreCampo.ToUpper = "TOTAL" Then
                        cadTmp = IIf(IsDBNull(Dt2.Rows(0).Item(sNombreCampo)), "", Dt2.Rows(0).Item(sNombreCampo))
                        cadTmp = (CDec(cadTmp) - oDBVen.EjecutarCmdScalardblSQL("Select total from TransProd where FacturaID='" & Dt2.Rows(0).Item("TransProdID") & "' and Tipo = 12 ")).ToString
                    Else
                        cadTmp = IIf(IsDBNull(Dt2.Rows(0).Item(sNombreCampo)), "", Dt2.Rows(0).Item(sNombreCampo))
                    End If
                Else
                    cadTmp = IIf(IsDBNull(Dt2.Rows(0).Item(0)), "", Dt2.Rows(0).Item(0))
                End If

                Select Case nTipoFormato
                    Case 1
                        cadTmp = Double.Parse(cadTmp).ToString("#,##0")
                    Case 2
                        cadTmp = Double.Parse(cadTmp).ToString("#,##0.00")
                End Select
                cadTmp = cadTmp.Replace(vbCrLf, " ")
                sCadena &= cadTmp
            End If

            Dt2.Dispose()
        End If

        Return sCadena
    End Function
    Private Sub ObtieneNotas(ByVal sRECId As String, ByRef SW As IO.StreamWriter, ByVal iTipo As Integer, ByVal paroVista As Vista)
        Dim Nota As String, i As Integer
        'TODO: Probar cambio BD
        Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select texto, renglonblanco, tipoalineacion, TipoLetra from  RECNota where RECId='" & sRECId & "' and tipo=" & iTipo & " order by orden", "Notas")
        For Each Dr As DataRow In Dt.Rows
            Nota = Dr("texto")
            RecuperaTamanio(Dr("TipoLetra"))
            AlineaCadena(Dr("tipoalineacion"), Nota)
            If bCambiarTam Or tTipoPapel = TipoPapel.ExtechImpacto2 Then
                If tTipoPapel = TipoPapel.ZebraTermica2 Then
                    Nota = "{" & iTamanio & " " & iAlto & "}" & Nota
                    'Nota = "! U1 SETLP 0 " & Tamanio & " " & Alto & Nota
                Else
                    Nota = "{" & iTamanio & "}" & Nota
                End If
            End If

            SW.WriteLine(Nota)


            For i = 0 To Dr("renglonblanco") - 1
                SW.WriteLine()
            Next
        Next
        If iTipo = 1 Then
            SW.WriteLine(TextoCentrado(paroVista.BuscarMensaje("MsgBox", "Ximpresion") + ": " + Now.ToString("dd/MM/yy HH:mm:ss"), iLongTot))
        End If
        Dt.Dispose()
    End Sub
    Private Function ObtieneCadenaGenerales(ByVal sId As String, ByVal Dr As DataRow, ByVal parsCampoTemporal As String) As String
        Dim Cadena As String = String.Empty, Query As String = String.Empty
        Dim sDescripcion As String = String.Empty, sNombreCampo As String = String.Empty
        ObtieneCampo(Dr("corid"), Dr("cotid"), Dr("cocid"), sDescripcion, sNombreCampo)
        If Dr("tipoetiqueta") = 1 Then
            Cadena = sDescripcion
            If Dr("tiposeparador") <> 0 Then
                Cadena &= ValorReferencia.BuscarEquivalente("SEPARADO", Dr("tiposeparador"))
            End If
        End If

        Query = "select " & sNombreCampo
        Query &= " from " & ObtieneTablaNombre(Dr("corid"), Dr("cotid"))
        Query &= " where " & parsCampoTemporal & "='" & sId & "'"
        Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL(Query, "ValorCampo")
        'Para ver si tengo que obtener los valores por referencia
        If parsCampoTemporal = "TransProdId" AndAlso sNombreCampo = "TipoMotivo" Then
            Cadena &= ValorReferencia.BuscarEquivalente("TRPMOT", Dt2.Rows(0).Item(0))
        ElseIf parsCampoTemporal = "TransProdId" AndAlso sNombreCampo = "TipoFase" Then
            Cadena &= ValorReferencia.BuscarEquivalente("TRPFASE", Dt2.Rows(0).Item(0))
        Else
            Cadena &= Dt2.Rows(0).Item(0)
        End If
        Dt2.Dispose()
        Return Cadena
    End Function
    Private Function ObtieneCadenaDetallesT(ByVal sId As String, ByVal Dr As DataRow, Optional ByVal bPreliquidacion As Boolean = False, Optional ByVal bDeposito As Boolean = True) As String
        Dim Cadena As String = String.Empty
        Dim Query As String = String.Empty
        Dim bRecuperar As Boolean = True
        If Dr("TipoEtiqueta") = 1 Then
            Dim sDescripcion As String = String.Empty, sNombreCampo As String = String.Empty
            ObtieneCampo(Dr("CORId"), Dr("COTId"), Dr("COCId"), sDescripcion, sNombreCampo)
            If bPreliquidacion Then
                If bDeposito Then
                    bRecuperar = (InStr("FechaPreliquidacion, FechaDeposito, TipoBanco, Referencia, Total, Ficha", sNombreCampo, CompareMethod.Text) > 0)
                Else
                    bRecuperar = (InStr("FechaPreliquidacion, TipoEfectivo, Total", sNombreCampo, CompareMethod.Text) > 0)
                End If
            End If
            If bRecuperar Then
                Dim nTamanio As Integer
                Cadena = Trim(sDescripcion)
                If bPreliquidacion Then
                    Select Case sNombreCampo
                        Case "FechaDeposito"
                            nTamanio = 10
                        Case "TipoBanco"
                            nTamanio = 9
                        Case "Referencia"
                            nTamanio = 12
                        Case "Total"
                            nTamanio = 7
                        Case "Ficha"
                            nTamanio = 6
                        Case "TipoEfectivo"
                            nTamanio = 19
                        Case Else
                            nTamanio = Dr("Tamanio")
                    End Select
                Else
                    nTamanio = Dr("Tamanio")
                End If
                CompletaColumna(Cadena, nTamanio)
                If Dr("TipoSeparador") <> 0 Then
                    Cadena = String.Concat(Cadena, ValorReferencia.BuscarEquivalente("SEPARADO", Dr("TipoSeparador")))
                End If
                AgregaEspaciosColumna(Dr("TipoEspacio"), Cadena, Dr("CantidadEspacio"))
            End If
            bImpresionEtiquetas = True
        End If
        Return Cadena
    End Function
    Private Sub CompletaColumna(ByRef Cadena As String, ByVal AnchoCol As Integer, ByVal Alineacion As Integer, ByVal Separador As Integer, ByVal TipoFormato As Integer)
        Dim nTamanioSep As Integer
        Select Case TipoFormato
            Case 1
                Cadena = Double.Parse(Cadena).ToString("#,##0")
            Case 2
                Cadena = Double.Parse(Cadena).ToString("#,##0.00")
        End Select
        If Cadena.Length > AnchoCol Then
            Cadena = Microsoft.VisualBasic.Left(Cadena, AnchoCol)
        End If
        If Separador <> 0 Then
            nTamanioSep = Len(ValorReferencia.BuscarEquivalente("SEPARADO", Separador))
        End If
        Select Case Alineacion
            Case 0, 1 'Ninguna o izquierda
                Cadena = Cadena.PadRight(AnchoCol + nTamanioSep, " ")
            Case 2 'Centrado
                Dim nTamDerecho As Integer
                Dim nTamIzquierdo As Integer
                nTamIzquierdo = Math.Ceiling(((AnchoCol + nTamanioSep) - Cadena.Length) / 2)
                nTamDerecho = Math.Floor(((AnchoCol + nTamanioSep) - Cadena.Length) / 2)
                Cadena = Cadena.PadLeft(Cadena.Length + nTamIzquierdo, " ")
                Cadena = Cadena.PadRight(Cadena.Length + nTamDerecho, " ")
            Case 3 'Derecha
                Cadena = Cadena.PadLeft(AnchoCol + nTamanioSep, " ")
        End Select
    End Sub
    Private Sub CompletaColumna(ByRef Cadena As String, ByVal AnchoCol As Integer)
        Dim lon As Integer = Cadena.Length
        If lon >= AnchoCol Then
            Cadena = Microsoft.VisualBasic.Left(Cadena, AnchoCol)
        Else
            Cadena = Cadena.PadRight(AnchoCol, " ")
        End If
    End Sub
#Region "Ticket no configurado"
    'GUAMAYA
    Private Sub ImprimirVenta1(ByVal parsArchivoNombre As String, ByVal parsTransProdId As String, ByVal pariTipoRecibo As Integer, ByRef refSW As IO.StreamWriter, ByVal paroCliente As Cliente, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)
        'Datos Empresa
        Dim dtConfig As DataTable = oDBApp.RealizarConsultaSQL("Select NombreEmpresa, Calle, Numero,Colonia,Ciudad,Region,RFC from Configuracion ", "Configuracion")
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("NombreEmpresa"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("Calle") & " " & dtConfig.Rows(0)("Numero"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("Colonia"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("Ciudad") & "," & dtConfig.Rows(0)("Region"), iLongTot))
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & dtConfig.Rows(0)("RFC"), iLongTot))
            .WriteLine()
        End With
        ImprimeLineaPunteada(refSW, iLongTot)

        'Datos Cliente
        Dim dtClienteDomicilio As DataTable = oDBVen.RealizarConsultaSQL("Select Calle, Numero, Poblacion, Pais, CodigoPostal,Entidad from ClienteDomicilio where clienteClave ='" & paroCliente.ClienteClave & "' and Tipo = " & IIf(pariTipoRecibo = 8, "1", "2"), "ClienteDomicilio")
        If dtClienteDomicilio.Rows.Count = 0 Then
            dtClienteDomicilio = oDBVen.RealizarConsultaSQL("Select Calle, Numero, Poblacion, Pais, CodigoPostal,Entidad from ClienteDomicilio where clienteClave ='" & paroCliente.ClienteClave & "' and Tipo = 2", "ClienteDomicilio")
        End If
        Dim dtTransProd As DataTable = oDBVen.RealizarConsultaSQL("Select Folio,Subtotal,Impuesto,Total,DescuentoVendedor from TransProd where TransProdID='" & parsTransProdId & "'", "TransProd")
        Dim dDescuentoVendedor As Double = 0
        Dim sTransProdIds As String = String.Empty
        If pariTipoRecibo = 8 Then
            Dim dtTransProdFactura As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdID, DescuentoVendedor from TransProd where FacturaID='" & parsTransProdId & "'", "TransProd")
            For Each dr As DataRow In dtTransProdFactura.Rows
                sTransProdIds &= "'" & dr("TransProdID") & "',"
                dDescuentoVendedor += IIf(IsDBNull(dr("DescuentoVendedor")), 0, dr("DescuentoVendedor"))
            Next
            If sTransProdIds.Length > 0 Then
                sTransProdIds = Microsoft.VisualBasic.Left(sTransProdIds, sTransProdIds.Length - 1)
            End If
        Else
            dDescuentoVendedor = IIf(IsDBNull(dtTransProd.Rows(0)("DescuentoVendedor")), 0, dtTransProd.Rows(0)("DescuentoVendedor"))
            sTransProdIds = "'" & parsTransProdId & "'"
        End If

        With refSW
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCliente") & ": " & paroCliente.Clave)
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XNombre") & ": " & paroCliente.RazonSocial)
            If dtClienteDomicilio.Rows.Count > 0 Then
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XDomicilio") & ": " & dtClienteDomicilio.Rows(0)("Calle") & " " & dtClienteDomicilio.Rows(0)("Numero"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XPARCiudad") & ": " & dtClienteDomicilio.Rows(0)("Poblacion").ToString.Trim & "," & dtClienteDomicilio.Rows(0)("Entidad").ToString.Trim & "," & dtClienteDomicilio.Rows(0)("Pais").ToString.Trim & "  " & paroVista.BuscarMensaje("MsgBox", "XCPostal") & dtClienteDomicilio.Rows(0)("CodigoPostal").ToString.Trim)
            End If
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & paroCliente.IdFiscal)
            .WriteLine(paroCliente.NombreContacto)
            .WriteLine()


            'Encabezado
            .WriteLine(CompletaHasta("", 21, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XFolio") & ": " & dtTransProd.Rows(0)("Folio"), 27, Alineacion.Izquierda, True))
            .WriteLine(CompletaHasta("", 21, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XFecha") & ": " & Format(Now, "dd/MMM/yyyy hh:mm:ss").ToUpper, 27, Alineacion.Derecha, True))

            .WriteLine()

            'Datos del vendedor
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XVendedor") & ": " & oVendedor.Nombre)
            ImprimeLineaPunteada(refSW, iLongTot)

            'Titulos
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XProducto"))
            .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XCant"), 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XUV"), 13, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XP.U"), 12, Alineacion.Izquierda, False) & CompletaHasta("Importe", 13, Alineacion.Derecha, True))
            ImprimeLineaPunteada(refSW, iLongTot)

            Dim dSubtotalProd As Double = 0
            Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL("Select TPD.TransProdDetalleID, PRO.ProductoClave, PRO.NombreLargo, TPD.Cantidad, TPD.TipoUnidad, TPD.Precio,TPD.Precio * TPD.Cantidad as Importe, DES.Nombre as DESNombre, TPD.DescuentoPor,TPD.Subtotal, TPD.Promocion from TransProdDetalle TPD inner join Producto PRO ON TPD.ProductoClave = PRO.ProductoClave left join Descuento DES ON TPD.DescuentoClave= DES.DescuentoClave where TransProdID in(" & sTransProdIds & ") order by TPD.ProductoClave, TPD.TipoUnidad", "Detalle")
            Dim dtTrpPrp As DataTable = oDBVen.RealizarConsultaSQL("select TrpPrp.TransProdDetalleID,PRM.Nombre,TrpPrp.PromocionImp,PRM.TipoAplicacion from TrpPrp inner join Promocion PRM on PRM.PromocionClave = TrpPrp.PromocionClave where TransProdID in (" & sTransProdIds & ")", "TrpPrp")
            Dim drPromociones As DataRow()
            Dim sProductoClave As String = String.Empty
            For Each dr As DataRow In dtDetalle.Rows
                'Excluir las promociones
                If Not (dr("Promocion") = 2) Then
                    If sProductoClave <> dr("ProductoClave") Then
                        .WriteLine(dr("NombreLargo"))
                        sProductoClave = dr("ProductoClave")
                    End If
                    .WriteLine(CompletaHasta(dr("Cantidad"), 10, Alineacion.Izquierda, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 13, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("Precio"), oApp.FormatoDinero), 12, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("Importe"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                    If Not IsDBNull(dr("DESNombre")) Then
                        .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(dr("DESNombre"), 25, Alineacion.Izquierda, False) & CompletaHasta(Decimal.Negate(dr("DescuentoPor")), 13, Alineacion.Derecha, True))
                    End If
                    drPromociones = dtTrpPrp.Select("TransProdDetalleID='" & dr("TransProdDetalleID") & "' and TipoAplicacion <> 4")
                    For Each drProm As DataRow In drPromociones
                        If Not IsDBNull(drProm("PromocionImp")) Then
                            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(drProm("Nombre"), 25, Alineacion.Derecha, False) & CompletaHasta(Decimal.Negate(drProm("PromocionImp")), 13, Alineacion.Derecha, True))
                        Else
                            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(drProm("Nombre"), 25, Alineacion.Derecha, False) & CompletaHasta("", 13, Alineacion.Derecha, True))
                        End If
                    Next
                    dSubtotalProd = dSubtotalProd + dr("Subtotal")
                End If
            Next
            dtDetalle.Dispose()

            .WriteLine()
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XProductosOtorgados"))
            Dim drRegalados() As DataRow = dtDetalle.Select("Promocion = 2 ")
            For Each dr As DataRow In drRegalados
                .WriteLine(dr("NombreLargo"))
                .WriteLine(CompletaHasta(dr("Cantidad"), 10, Alineacion.Izquierda, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 13, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("Precio"), oApp.FormatoDinero), 12, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("Importe"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            Next

            .WriteLine()

            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal") & ": ", 25, Alineacion.Derecha, False) & CompletaHasta(Format(dSubtotalProd, oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            'Descuentos del Cliente
            Dim dtDescCliente As DataTable = oDBVen.RealizarConsultaSQL("Select DES.Nombre,sum(TDE.DesImporte) as DesImporte from TpdDes TDE inner join Descuento DES on DES.DescuentoClave = TDE.DescuentoClave where TDE.TransProdID in (" & sTransProdIds & ") group by DES.DescuentoClave, DES.Nombre,TDE.Jerarquia  order by TDE.jerarquia ", "DescCliente")
            For Each dr As DataRow In dtDescCliente.Rows
                .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(dr("Nombre"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dr("DesImporte"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            Next
            dtDetalle.Dispose()
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XDesc.Vendedor"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dDescuentoVendedor, oApp.FormatoDinero), 13, Alineacion.Derecha, True))

            .WriteLine()

            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSuma"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Subtotal"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XI.V.A."), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Impuesto"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Total"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))

            '.WriteLine("{50}" & CompletaHasta("", 7, Alineacion.Izquierda, False) & CompletaHasta(oVista.BuscarMensaje("MsgBox", "XSuma"), 15, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Subtotal"), oApp.FormatoDinero), 10, Alineacion.Derecha, True))
            '.WriteLine(CompletaHasta("", 7, Alineacion.Izquierda, False) & CompletaHasta(oVista.BuscarMensaje("MsgBox", "XI.V.A."), 15, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Impuesto"), oApp.FormatoDinero), 10, Alineacion.Derecha, True))
            '.WriteLine(CompletaHasta("", 7, Alineacion.Izquierda, False) & CompletaHasta(oVista.BuscarMensaje("MsgBox", "XTotal"), 15, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Total"), oApp.FormatoDinero), 10, Alineacion.Derecha, True))

            .WriteLine()
            Dim oNumLetras As LUFERR.NumerosALetras
            oNumLetras = New LUFERR.NumerosALetras(True, 0, "pesos", "centavos")
            Try
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XSon") & ": " & oNumLetras.Aletras(CDbl(dtTransProd.Rows(0)("Total"))) & " " & Microsoft.VisualBasic.Right(Format(dtTransProd.Rows(0)("Total") - Math.Floor(dtTransProd.Rows(0)("Total")), "#.00"), 2) & "/100 m.n.")
            Catch ex As Exception

            End Try
            .WriteLine()

            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XEsteDoc"))
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XPagoen"))
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()

            .WriteLine("-------------------------------------------")
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XNombreFirma"))
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
        End With


        'Dr = oDBVen.RealizarConsultaSQL("SELECT Nombre FROM Vendedor WHERE VendedorID='" & oVendedor.VendedorId & "'", "Vendedor").Rows(0)
        'Sw.WriteLine(TextoCentrado(Dr.Item(0)))


        dtConfig.Dispose()
        dtClienteDomicilio.Dispose()
        dtTransProd.Dispose()

        refSW.Flush()
        refSW.Close()
        ImprimirArchivo(7, False, parsArchivoNombre, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
    End Sub
    'BAJO CERO
    Private Sub ImprimirVenta2(ByVal parsArchivoNombre As String, ByVal parsTransProdId As String, ByRef refSW As IO.StreamWriter, ByVal paroCliente As Cliente, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)
        tTipoPapel = oVendedor.TipoModImp
        'Datos Empresa
        Dim dtConfig As DataTable = oDBApp.RealizarConsultaSQL("Select NombreEmpresa, Calle, Numero,Colonia,Ciudad,Region,Telefono,RFC from Configuracion ", "Configuracion")
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("NombreEmpresa"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("Calle") & " " & dtConfig.Rows(0)("Numero"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XCol") & " " & dtConfig.Rows(0)("Colonia"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(dtConfig.Rows(0)("Ciudad") & "," & dtConfig.Rows(0)("Region"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XTel") & " " & dtConfig.Rows(0)("Telefono"), iLongTot))
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & ": " & dtConfig.Rows(0)("RFC"), iLongTot))
            .WriteLine()
        End With
        'dtConfig.Dispose()

        'Datos Almacen
        Dim dtAlmacen As DataTable = oDBVen.RealizarConsultaSQL("select Nombre, Domicilio, Telefono from Almacen where Tipo = 1", "Almacen")
        If dtAlmacen.Rows.Count > 0 Then
            With refSW
                .WriteLine()
                .WriteLine(dtAlmacen.Rows(0)("Nombre"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XDomicilio") & ": " & dtAlmacen.Rows(0)("Domicilio"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "MDBTelefono") & ": " & dtAlmacen.Rows(0)("Telefono"))
                .WriteLine()
            End With
        End If
        dtAlmacen.Dispose()

        'Titulo y Fecha/Hora
        refSW.WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XTicketVta"), iLongTot))
        refSW.WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XImpresion") & ": " & Now.ToString("dd/MM/yyy hh:mm:ss tt"), iLongTot))
        ImprimeLineaPunteada(refSW, iLongTot)

        'Datos de la venta
        Dim sConsulta As String
        sConsulta = "Select TRP.Folio, TRP.FechaHoraAlta, TRP.FechaCobranza, RUT.RutClave, RUT.Descripcion, TRP.SubTotal, TRP.Impuesto, TRP.Total, TRP.CFVTipo "
        sConsulta &= "from TransProd TRP "
        sConsulta &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
        sConsulta &= "inner join Ruta RUT on VIS.RutClave = RUT.RutClave "
        sConsulta &= "where TRP.TransProdID='" & parsTransProdId & "'"
        Dim dtTransProd As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "TransProd")
        If dtTransProd.Rows.Count > 0 Then
            With refSW
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XFolio") & ": " & dtTransProd.Rows(0)("Folio"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XFecha") & ": " & CDate(dtTransProd.Rows(0)("FechaHoraAlta")).ToString("dd/MM/yyy hh:mm:ss tt"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XRuta") & ": " & dtTransProd.Rows(0)("RutClave") & " - " & dtTransProd.Rows(0)("Descripcion"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XVendedor") & ": " & oVendedor.Clave & " - " & oVendedor.NombreVendedor)
                .WriteLine()
            End With
        End If

        'Datos del cliente
        Dim dtClienteDomicilio As DataTable = oDBVen.RealizarConsultaSQL("Select Calle, Numero, Colonia from ClienteDomicilio where clienteClave ='" & paroCliente.ClienteClave & "' and Tipo = 2", "ClienteDomicilio")
        With refSW
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCliente") & ": " & paroCliente.Clave)
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "TRPRazonSocial") & ": " & paroCliente.RazonSocial)
            If dtClienteDomicilio.Rows.Count > 0 Then
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XDomicilio") & ": " & dtClienteDomicilio.Rows(0)("Calle") & " " & dtClienteDomicilio.Rows(0)("Numero"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtClienteDomicilio.Rows(0)("Colonia").ToString.Trim)
            End If
            .WriteLine()
        End With
        dtClienteDomicilio.Dispose()

        'Titulos
        ImprimeLineaPunteada(refSW, iLongTot)
        refSW.WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XClave"), 6, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XProducto"), 12, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XCant"), 6, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XPrecio"), 12, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal"), 12, Alineacion.Derecha, True))
        ImprimeLineaPunteada(refSW, iLongTot)

        'Detalle
        sConsulta = "Select PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.Precio, TPD.Precio * TPD.Cantidad as SubTotal, TPD.Promocion "
        sConsulta &= "from TransProdDetalle TPD "
        sConsulta &= "inner join Producto PRO ON TPD.ProductoClave = PRO.ProductoClave "
        sConsulta &= "where TransProdID ='" & parsTransProdId & "' "
        sConsulta &= "order by TPD.ProductoClave, TPD.TipoUnidad "
        Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "Detalle")
        Dim nUnidades As Integer = 0
        Dim sPromocion As String
        If dtDetalle.Rows.Count > 0 Then
            For Each dr As DataRow In dtDetalle.Rows
                sPromocion = IIf(dr("Promocion") = 2, "*", "")
                refSW.WriteLine(CompletaHasta(dr("ProductoClave") & sPromocion, 6, Alineacion.Izquierda, False) & CompletaHasta(dr("Nombre"), 12, Alineacion.Izquierda, False) & CompletaHasta(dr("Cantidad"), 6, Alineacion.Derecha, False) & CompletaHasta(dr("Precio"), 12, Alineacion.Derecha, False) & CompletaHasta(dr("SubTotal"), 12, Alineacion.Derecha, True))
                nUnidades += dr("Cantidad")
            Next
        End If
        dtDetalle.Dispose()

        'Totales
        With refSW
            .WriteLine()
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XUnidades"), 25, Alineacion.Derecha, False) & CompletaHasta(nUnidades, 13, Alineacion.Derecha, True))
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Subtotal"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XI.V.A."), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Impuesto"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Total"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
            .WriteLine()
        End With

        'Equivalencia
        CreaEquivalencias(parsTransProdId, 3, TamanioDefault, 1, refSW, paroVista)

        'Total en letra
        Dim oNumLetras As LUFERR.NumerosALetras
        oNumLetras = New LUFERR.NumerosALetras(True, 0, "pesos", "centavos")
        Try
            refSW.WriteLine("(" & oNumLetras.Aletras(CDbl(dtTransProd.Rows(0)("Total"))) & " " & Microsoft.VisualBasic.Right(Format(dtTransProd.Rows(0)("Total") - Math.Floor(dtTransProd.Rows(0)("Total")), "#.00"), 2) & "/100 m.n.)")
            refSW.WriteLine()
        Catch ex As Exception
        End Try
        ImprimeLineaPunteada(refSW, iLongTot)

        'Terminos y condiciones
        With refSW
            .WriteLine()
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTermCond"))
            If dtTransProd.Rows(0)("CFVTipo") = 2 Then
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTerminosCred1").Replace("$0$", dtConfig.Rows(0)("NombreEmpresa")).Replace("$1$", FechaALetra(CDate(dtTransProd.Rows(0)("FechaCobranza")))) & " " & paroVista.BuscarMensaje("MsgBox", "XTerminosCred2").Replace("$2$", Format(dtTransProd.Rows(0)("Total"), oApp.FormatoDinero)))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTerminosCred3") & " " & paroVista.BuscarMensaje("MsgBox", "XTerminosCred4"))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XFirma"))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XRecibidoPor"))
                .WriteLine()
                CuadroFirma(refSW)
            End If
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
        End With

        dtConfig.Dispose()
        dtTransProd.Dispose()

        refSW.Flush()
        refSW.Close()
        ImprimirArchivo(7, False, parsArchivoNombre, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
    End Sub

    'FACTURA SUKARNE
    Private Sub ImprimirFactura1(ByVal parsArchivoNombre As String, ByVal parsTransProdIds As String(), ByRef refSW As IO.StreamWriter, ByVal paroVista As Vista, ByVal paroCliente As Cliente, ByVal parbPreguntarReimpresion As Boolean)
        Dim bPrimeraVez As Boolean = True
        For Each sTransProdId As String In parsTransProdIds
            If Not bPrimeraVez Then
                refSW.WriteLine("IMPRIME_LOGO")
            End If
            bPrimeraVez = False

            'Datos Empresa Emisora
            Dim dtDatoFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select * from TRPDatoFiscal where TransProdID='" & sTransProdId & "'", "TRPDatoFiscal")
            If dtDatoFiscal.Rows.Count <= 0 Then Exit Sub
            Dim dtFactura As DataTable = oDBVen.RealizarConsultaSQL("Select CFVTipo, Folio, FechaHoraAlta from TransProd where TransProdID ='" & sTransProdId & "'", "Factura")
            With refSW
                'Encabezado
                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(dtDatoFiscal.Rows(0)("NombreEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & dtDatoFiscal.Rows(0)("RFCEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("CalleEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & " " & dtDatoFiscal.Rows(0)("NumExtEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumIntEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("ColoniaEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("LocalidadEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("RegionEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostalEm").ToString, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("PaisEm").ToString, iLongTot))
                'Regimen Fiscal
                Dim dtRegimenFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select Descripcion from TRPRegimenFiscal where TransProdID ='" & sTransProdId & "'", "TRPRegimenFiscal")
                If dtRegimenFiscal.Rows.Count Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XRegimenFiscal").ToUpper, iLongTot))
                    For Each dr As DataRow In dtRegimenFiscal.Rows
                        .WriteLine(Impresion.FTextoDerecha(dr("Descripcion"), iLongTot))
                    Next
                End If
                dtRegimenFiscal.Dispose()

                'LugarExpedicion
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XLugarExpedicion").ToUpper)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("CalleEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & ": " & dtDatoFiscal.Rows(0)("NumExtEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumIntEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("ColoniaEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("MunicipioEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("EntidadEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostalEx").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("PaisEx").ToString)

                'Certificado de folios fiscales
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XAnio") & ": " & dtDatoFiscal.Rows(0)("AnioAprobacion"), iLongTot))
                If dtFactura.Rows.Count > 0 Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgBox", "XFolio") & " " & dtFactura.Rows(0)("Folio"), iLongTot))
                End If
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XAprobacion") & ": " & dtDatoFiscal.Rows(0)("Aprobacion"), iLongTot))
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XNumCertificado") & ": " & dtDatoFiscal.Rows(0)("NumCertificado"), iLongTot))
                If dtFactura.Rows.Count > 0 Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XFechaFactura") & ": " & CDate(dtFactura.Rows(0)("FechaHoraAlta")).ToString("dd/MM/yyyy HH:mm:ss"), iLongTot))
                End If

                Dim aMetodos As String()
                If Not IsDBNull(dtDatoFiscal.Rows(0)("MetodoPago")) Then
                    aMetodos = dtDatoFiscal.Rows(0)("MetodoPago").ToString.Split(",")
                End If

                Dim aBanco As String()
                If Not IsDBNull(dtDatoFiscal.Rows(0)("Banco")) Then
                    aBanco = dtDatoFiscal.Rows(0)("Banco").ToString.Split(",")
                Else

                End If
                Dim aNumCtaPago As String()
                If Not IsDBNull(dtDatoFiscal.Rows(0)("NumCtaPago")) Then
                    aNumCtaPago = dtDatoFiscal.Rows(0)("NumCtaPago").ToString.Split(",")
                End If
                Dim sBanco As String
                Dim sCuenta As String
                Dim indice As Integer = 0

                Dim sMetodoPago As String = String.Empty
                Dim sNumCtaPago As String = String.Empty

                If Not IsNothing(aMetodos) Then
                    For Each sMetodo As String In aMetodos
                        sBanco = String.Empty
                        sCuenta = String.Empty
                        If (Not IsNothing(aBanco) AndAlso indice < aBanco.Length) Then
                            sBanco = aBanco(indice)
                        End If
                        If (Not IsNothing(aNumCtaPago) AndAlso indice < aNumCtaPago.Length) Then
                            sCuenta = aNumCtaPago(indice)
                        End If
                        If sBanco.Length > 0 And sBanco <> "*" Then
                            sMetodoPago += sMetodo + " " + sBanco + ","
                        Else
                            sMetodoPago += sMetodo + ","
                        End If

                        If sCuenta.Length > 0 And sCuenta <> "*" Then
                            sNumCtaPago += sCuenta + ","
                        End If
                        indice += 1
                    Next
                    If sMetodoPago.Length > 0 Then
                        sMetodoPago = sMetodoPago.Substring(0, sMetodoPago.Length - 1)
                    End If
                    If sNumCtaPago.Length > 0 Then
                        sNumCtaPago = sNumCtaPago.Substring(0, sNumCtaPago.Length - 1)
                    End If

                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "TDFMetodoPago") & " " & sMetodoPago, iLongTot))
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "TDFNumerosCuenta") & " " & sNumCtaPago, iLongTot))
                End If
            
                'Datos del cliente
                .WriteLine(dtDatoFiscal.Rows(0)("RazonSocial"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & dtDatoFiscal.Rows(0)("RFC").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("Calle").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & ": " & dtDatoFiscal.Rows(0)("NumExt").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumInt").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("Colonia").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostal").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("Municipio").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("Localidad").ToString)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("Pais").ToString)

                'Titulo y FechaHora del documento
                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XFactura").ToUpper & " " & ValorReferencia.BuscarEquivalente("FVENTA", dtFactura.Rows(0)("CFVTipo").ToString), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XImpresion") & " " & Now.ToString("dd/MM/yyyy HH:mm:ss"), iLongTot))

                'Titulos del detalle
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XDescripcion"))
                .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XBultos"), 7, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XCantidad"), 10, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XUnidad"), 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XPrecio"), 10, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XImporte"), 11, Alineacion.Derecha, False))

            End With

            ImprimeLineaPunteada(refSW, iLongTot)

            With refSW
                'Detalles
                Dim sConsulta As Text.StringBuilder = New Text.StringBuilder
                sConsulta.Append("Select TRP.TransProdID, TRP.MonedaID, TRP.FechaCobranza, PRO.ProductoClave, PRO.Nombre, TRP.SubTotal, TRP.Total, sum(TPD.Cantidad) as Cantidad, sum(TPD.Cantidad1) as Cantidad1, TPD.TipoUnidad, TPD.Precio, sum(TPD.SubTotal) as Importe ")
                sConsulta.Append("from TransProd TRP inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
                sConsulta.Append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
                sConsulta.Append("where facturaID ='" & sTransProdId & "' and TRP.Tipo = 1 ")
                sConsulta.Append("group by TRP.TransProdID, TRP.MonedaID, TRP.FechaCobranza, PRO.ProductoClave, PRO.Nombre, TRP.SubTotal, TRP.Total, TPD.Precio, TPD.TipoUnidad ")
                Dim dtDetallesPed As DataTable = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Detalle")
                If dtDetallesPed.Rows.Count > 0 Then
                    Dim dtPedimentos As DataTable = oDBVen.RealizarConsultaSQL("Select ProductoClave, NumPedimento, Aduana, FechaIngreso from TRPPedimento where TransProdId = '" & dtDetallesPed.Rows(0)("TransProdID") & "' and Facturado = 1 ", "TRPPedimento")

                    For Each dr As DataRow In dtDetallesPed.Rows
                        .WriteLine(dr("ProductoClave") & " " & dr("Nombre"))
                        .WriteLine(CompletaHasta(dr("Cantidad1"), 7, Alineacion.Izquierda, False) & CompletaHasta(CDec(dr("Cantidad")).ToString("#,##0.00"), 10, Alineacion.Derecha, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 10, Alineacion.Izquierda, False) & CompletaHasta(CDec(dr("Precio")).ToString("#,##0.00"), 10, Alineacion.Derecha, False) & CompletaHasta(CDec(dr("Importe")).ToString("#,##0.00"), 11, Alineacion.Derecha, False))
                        If dtPedimentos.Rows.Count > 0 Then
                            For Each drPed As DataRow In dtPedimentos.Select("ProductoClave ='" & dr("ProductoClave") & "'")
                                .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XPedimento") & ": ", 12, Alineacion.Izquierda, False) & CompletaHasta(drPed("NumPedimento"), 10, Alineacion.Derecha, False) & CompletaHasta(drPed("Aduana"), 15, Alineacion.Izquierda, False) & CompletaHasta(CDate(drPed("FechaIngreso")).ToString("dd/MM/yyyy"), 11, Alineacion.Derecha, True))
                            Next

                        End If
                    Next
                    .WriteLine()

                    .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal") & " " & CDec(dtDetallesPed.Rows(0)("SubTotal")).ToString("#,##0.00"), 48, Alineacion.Derecha, True))

                    Dim vlImpuesto, vlTasa, vlImporte As ArrayList
                    Dim aId As New ArrayList()
                    aId.Add(dtDetallesPed.Rows(0)("TransProdID"))
                    TransProd.ImpuestosConDesc(aId, paroCliente.ClienteClave, vlImpuesto, vlTasa, vlImporte)

                    For i As Integer = 0 To vlImpuesto.Count - 1
                        .WriteLine(CompletaHasta(vlImpuesto.Item(i) & " " & Microsoft.VisualBasic.Strings.Format(vlTasa.Item(i), "0") & "% " & CDec(vlImporte.Item(i)).ToString("#,##0.00"), 48, Alineacion.Derecha, True))
                    Next

                    .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & CDec(dtDetallesPed.Rows(0)("Total")).ToString("#,##0.00"), 48, Alineacion.Derecha, True))
                End If


                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XPagoen").ToUpper, iLongTot))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCadenaOriginal") & ": " & dtDatoFiscal.Rows(0)("CadenaOriginal"))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XSelloDigital") & ": " & dtDatoFiscal.Rows(0)("SelloDigital"))

                If paroCliente.ImprimirPagare Then
                    .WriteLine()
                    Dim sPagare As String = paroVista.BuscarMensaje("MsgTicketFactura", "I0232") & vbCrLf & paroVista.BuscarMensaje("MsgTicketFactura", "I0234") & paroVista.BuscarMensaje("MsgTicketFactura", "I0235") & paroVista.BuscarMensaje("MsgTicketFactura", "I0236") & vbCrLf & paroVista.BuscarMensaje("MsgTicketFactura", "I0237") & paroVista.BuscarMensaje("MsgTicketFactura", "I0238") & paroVista.BuscarMensaje("MsgTicketFactura", "I0239") & paroVista.BuscarMensaje("MsgTicketFactura", "I0240") & vbCrLf & paroVista.BuscarMensaje("MsgTicketFactura", "I0241") & vbCrLf & paroVista.BuscarMensaje("MsgTicketFactura", "I0242") & vbCrLf & paroVista.BuscarMensaje("MsgTicketFactura", "I0243")
                    sPagare = sPagare.Replace("$0$", CType(SubEmpresa.aSubEmpresa(0), SubEmpresa.DatosEmpresa).NombreEmpresa)
                    'Si es crédito
                    'If dtFactura.Rows(0)("CFVTipo").ToString = "2" Then
                    'sPagare = sPagare.Replace("$1$", CDate(dtDetallesPed.Rows(0)("FechaHoraAlta")).AddDays(dtDetallesPed.Rows(0)("DiasCredito")).ToString("dd/MM/yyyy"))
                    ' Else
                    sPagare = sPagare.Replace("$1$", CDate(dtDetallesPed.Rows(0)("FechaCobranza")).ToString("dd/MM/yyyy"))
                    'End If
                    If dtDetallesPed.Rows.Count > 0 Then
                        Dim oNumLetras As LUFERR.NumerosALetras
                        Try
                            If Not IsDBNull(dtDetallesPed.Rows(0)("MonedaID")) AndAlso (dtDetallesPed.Rows(0)("MonedaID") = 1) Then
                                oNumLetras = New LUFERR.NumerosALetras(True, 0, "pesos", "centavos")
                                sPagare = sPagare.Replace("$2$", CDec(dtDetallesPed.Rows(0)("Total")).ToString("#,##0.00")).Replace("$3$", "(" & oNumLetras.Aletras(CDbl(dtDetallesPed.Rows(0)("Total"))) & " " & Microsoft.VisualBasic.Right(Format(dtDetallesPed.Rows(0)("Total") - Math.Floor(dtDetallesPed.Rows(0)("Total")), "#.00"), 2) & "/100 m.n.)")
                            Else
                                oNumLetras = New LUFERR.NumerosALetras(True, 0, "dolares", "centavos")
                                sPagare = sPagare.Replace("$2$", CDec(dtDetallesPed.Rows(0)("Total")).ToString("#,##0.00")).Replace("$3$", "(" & oNumLetras.Aletras(CDbl(dtDetallesPed.Rows(0)("Total"))) & " " & Microsoft.VisualBasic.Right(Format(dtDetallesPed.Rows(0)("Total") - Math.Floor(dtDetallesPed.Rows(0)("Total")), "#.00"), 2) & "/100 USD)")
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End If
                    sPagare = sPagare.Replace("$4$", oConHist.Campos("PorcentajeInteres") & "%").Replace("$5$", paroCliente.ClienteClave).Replace("$6$", dtDatoFiscal.Rows(0)("RazonSocial")).Replace("$7$", dtDatoFiscal.Rows(0)("Calle").ToString)
                    sPagare = sPagare.Replace("$8$", dtDatoFiscal.Rows(0)("NumExt").ToString).Replace("$9$", dtDatoFiscal.Rows(0)("NumInt").ToString).Replace("$10$", dtDatoFiscal.Rows(0)("Colonia").ToString).Replace("$11$", dtDatoFiscal.Rows(0)("Localidad").ToString)
                    sPagare = sPagare.Replace("$12$", dtDatoFiscal.Rows(0)("Entidad").ToString).Replace("$13$", dtDatoFiscal.Rows(0)("Pais").ToString).Replace("$14$", dtDatoFiscal.Rows(0)("LugarExpedicion").ToString)
                    sPagare = sPagare.Replace("$15$", CDate(dtFactura.Rows(0)("FechaHoraAlta")).ToString("dd")).Replace("$16$", MesALetra(CDate(dtFactura.Rows(0)("FechaHoraAlta")).Month)).Replace("$17$", CDate(dtFactura.Rows(0)("FechaHoraAlta")).ToString("yyyy"))
                    .WriteLine(sPagare)
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    .WriteLine()
                    ImprimeLineaPunteada(refSW, iLongTot)
                    refSW.WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XNombreFirma"), iLongTot))
                End If

                refSW.WriteLine()
                refSW.WriteLine()
                refSW.WriteLine()
                refSW.WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XLeyendaFiscalCFD"), iLongTot))
                EspaciosAlFinal(refSW, 8)
                dtDetallesPed.Dispose()
            End With

            dtDatoFiscal.Dispose()
            dtFactura.Dispose()
        Next

        'refSW.Flush()
        'refSW.Close()
    End Sub

    'NOTA CREDITO SUKARNE
    Private Sub ImprimirNotaCredito1(ByVal parsArchivoNombre As String, ByVal parsTransProdIds As String(), ByRef refSW As IO.StreamWriter, ByVal paroVista As Vista, ByVal paroCliente As Cliente, ByVal parbPreguntarReimpresion As Boolean, ByVal parbImprimirLogo As Boolean)
        For Each sTransProdId As String In parsTransProdIds
            If parbImprimirLogo Then
                refSW.WriteLine("IMPRIME_LOGO")
            End If

            'Datos Empresa Emisora
            Dim dtDatoFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select * from TRPDatoFiscal where TransProdID='" & sTransProdId & "'", "TRPDatoFiscal")
            If dtDatoFiscal.Rows.Count <= 0 Then Exit Sub
            Dim dtNota As DataTable = oDBVen.RealizarConsultaSQL("Select FacturaID, CFVTipo, Folio, FechaHoraAlta from TransProd where TransProdID ='" & sTransProdId & "'", "Nota")
            With refSW
                'Encabezado
                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(dtDatoFiscal.Rows(0)("NombreEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & dtDatoFiscal.Rows(0)("RFCEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("CalleEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & " " & dtDatoFiscal.Rows(0)("NumExtEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumIntEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("ColoniaEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("LocalidadEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("RegionEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostalEm"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("PaisEm"), iLongTot))
                'Regimen Fiscal
                Dim dtRegimenFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select Descripcion from TRPRegimenFiscal where TransProdID ='" & sTransProdId & "'", "TRPRegimenFiscal")
                If dtRegimenFiscal.Rows.Count Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XRegimenFiscal").ToUpper, iLongTot))
                    For Each dr As DataRow In dtRegimenFiscal.Rows
                        .WriteLine(Impresion.FTextoDerecha(dr("Descripcion"), iLongTot))
                    Next
                End If
                dtRegimenFiscal.Dispose()

                'LugarExpedicion
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XLugarExpedicion").ToUpper)
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("CalleEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & ": " & dtDatoFiscal.Rows(0)("NumExtEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumIntEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("ColoniaEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("MunicipioEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("EntidadEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostalEx"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("PaisEx"))

                'Certificado de folios fiscales
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XAnio") & ": " & dtDatoFiscal.Rows(0)("AnioAprobacion"), iLongTot))
                If dtNota.Rows.Count > 0 Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgBox", "XFolio") & " " & dtNota.Rows(0)("Folio"), iLongTot))
                End If
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XAprobacion") & ": " & dtDatoFiscal.Rows(0)("Aprobacion"), iLongTot))
                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XNumCertificado") & ": " & dtDatoFiscal.Rows(0)("NumCertificado"), iLongTot))
                If dtNota.Rows.Count > 0 Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XFechaFactura") & ": " & CDate(dtNota.Rows(0)("FechaHoraAlta")).ToString("dd/MM/yyyy HH:mm:ss"), iLongTot))
                End If

                If Not IsDBNull(dtDatoFiscal.Rows(0)("MetodoPago")) Then
                    .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "TDFMetodoPago") & " " & dtDatoFiscal.Rows(0)("MetodoPago"), iLongTot))
                End If

                Dim sFolioFactura As String = oDBVen.EjecutarCmdScalarStrSQL("Select Folio from TransProd where TransProdID ='" & dtNota.Rows(0)("FacturaID") & "'")

                .WriteLine(Impresion.FTextoDerecha(paroVista.BuscarMensaje("MsgTicketFactura", "XDocAplica") & ": " & sFolioFactura, iLongTot))

                'Datos del cliente
                .WriteLine(dtDatoFiscal.Rows(0)("RazonSocial"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & dtDatoFiscal.Rows(0)("RFC"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCalle") & ": " & dtDatoFiscal.Rows(0)("Calle"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XExterior") & ": " & dtDatoFiscal.Rows(0)("NumExt"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XInterior") & ": " & dtDatoFiscal.Rows(0)("NumInt"))
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "CLDColonia") & ": " & dtDatoFiscal.Rows(0)("Colonia"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCP") & ": " & dtDatoFiscal.Rows(0)("CodigoPostal"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XMunicipio") & ": " & dtDatoFiscal.Rows(0)("Municipio"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XEntidad") & ": " & dtDatoFiscal.Rows(0)("Localidad"))
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XPais") & ": " & dtDatoFiscal.Rows(0)("Pais"))

                'Titulo y FechaHora del documento
                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XNotaCredito").ToUpper, iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XImpresion") & " " & Now.ToString("dd/MM/yyyy HH:mm:ss"), iLongTot))

                'Titulos del detalle
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XDescripcion"))
                .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XBultos"), 7, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XCantidad"), 10, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgTicketFactura", "XUnidad"), 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XPrecio"), 10, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XImporte"), 11, Alineacion.Derecha, False))

            End With

            ImprimeLineaPunteada(refSW, iLongTot)

            With refSW
                'Detalles
                Dim sConsulta As Text.StringBuilder = New Text.StringBuilder
                sConsulta.Append("Select TRP.TransProdID, TRP.MonedaID, TRP.DiasCredito, PRO.ProductoClave, PRO.Nombre, TRP.SubTotal, TRP.Total, sum(TPD.Cantidad) as Cantidad, sum(TPD.Cantidad1) as Cantidad1, TPD.TipoUnidad, TPD.Precio, sum(TPD.SubTotal) as Importe ")
                sConsulta.Append("from TransProd TRP inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
                sConsulta.Append("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
                sConsulta.Append("where TRP.TransProdID ='" & sTransProdId & "' ")
                sConsulta.Append("group by TRP.TransProdID, TRP.MonedaID, TRP.DiasCredito, PRO.ProductoClave, PRO.Nombre, TRP.SubTotal, TRP.Total, TPD.Precio, TPD.TipoUnidad ")
                Dim dtDetallesNota As DataTable = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "Detalle")
                If dtDetallesNota.Rows.Count > 0 Then

                    For Each dr As DataRow In dtDetallesNota.Rows
                        .WriteLine(dr("ProductoClave") & " " & dr("Nombre"))
                        .WriteLine(CompletaHasta(dr("Cantidad1"), 7, Alineacion.Izquierda, False) & CompletaHasta(CDec(dr("Cantidad")).ToString("#,##0.00"), 10, Alineacion.Derecha, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad")), 10, Alineacion.Izquierda, False) & CompletaHasta(CDec(dr("Precio")).ToString("#,##0.00"), 10, Alineacion.Derecha, False) & CompletaHasta(CDec(dr("Importe")).ToString("#,##0.00"), 11, Alineacion.Derecha, False))
                    Next
                    .WriteLine()

                    .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal") & " " & CDec(dtDetallesNota.Rows(0)("SubTotal")).ToString("#,##0.00"), 48, Alineacion.Derecha, True))

                    Dim vlImpuesto, vlTasa, vlImporte As ArrayList
                    Dim aId As New ArrayList()
                    aId.Add(dtDetallesNota.Rows(0)("TransProdID"))
                    TransProd.ImpuestosConDesc(aId, paroCliente.ClienteClave, vlImpuesto, vlTasa, vlImporte)

                    For i As Integer = 0 To vlImpuesto.Count - 1
                        .WriteLine(CompletaHasta(vlImpuesto.Item(i) & " " & Microsoft.VisualBasic.Strings.Format(vlTasa.Item(i), "0") & "% " & CDec(vlImporte.Item(i)).ToString("#,##0.00"), 48, Alineacion.Derecha, True))
                    Next

                    .WriteLine(CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & CDec(dtDetallesNota.Rows(0)("Total")).ToString("#,##0.00"), 48, Alineacion.Derecha, True))
                End If

                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XPagoen").ToUpper, iLongTot))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XCadenaOriginal") & ": " & dtDatoFiscal.Rows(0)("CadenaOriginal"))
                .WriteLine()
                .WriteLine(paroVista.BuscarMensaje("MsgTicketFactura", "XSelloDigital") & ": " & dtDatoFiscal.Rows(0)("SelloDigital"))

                .WriteLine()
                .WriteLine()
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XLeyendaFiscalCFD"), iLongTot))
                .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketFactura", "XEfectosFiscales").ToUpper, iLongTot))
                EspaciosAlFinal(refSW, 8)
                dtDetallesNota.Dispose()
            End With

            dtDatoFiscal.Dispose()
            dtNota.Dispose()
        Next

        'refSW.Flush()
        'refSW.Close()
        'ImprimirArchivo(7, False, parsArchivoNombre, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
    End Sub
    Private Sub CuadroFirma(ByRef refSW As IO.StreamWriter)
        Dim sCadena As String
        Dim sLinea As String = ""
        sLinea = sLinea.PadRight(iLongTot, "-")

        sCadena = "|"
        CompletaColumna(sCadena, iLongTot - 1)
        sCadena &= "|"

        refSW.WriteLine(sLinea)
        For i As Integer = 0 To 4
            refSW.WriteLine(sCadena)
        Next
        refSW.WriteLine(sLinea)
    End Sub
    Private Sub ImprimirPago1(ByVal parsArchivoNombre As String, ByVal parsABNId As String, ByRef refSW As IO.StreamWriter, ByVal paroCliente As Cliente, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)

        Dim sFormato As String = "#,##0.00"
        tTipoPapel = oVendedor.TipoModImp
        'Datos Empresa
        Dim tConfig As Generic.Dictionary(Of String, Object) = oDBApp.RealizarReaderSQLconCampos("Select NombreEmpresa, Calle, Numero,Colonia,Ciudad,Region,Telefono,RFC from Configuracion ")
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(tConfig("NombreEmpresa").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(tConfig("Calle").ToString() & " " & tConfig("Numero").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XCol") & " " & tConfig("Colonia").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(tConfig("Ciudad").ToString() & "," & tConfig("Region").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XTel") & " " & tConfig("Telefono").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & " " & tConfig("RFC").ToString(), iLongTot))
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("msgTicketCobranza", "XTicketDeCobranza"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XImpresion") & ": " & Now.ToString("dd/MM/yyy hh:mm:ss tt"), iLongTot))
            .WriteLine()
        End With
        'dtConfig.Dispose()

        'Datos del cliente
        Dim tClienteDomicilio As Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("Select Calle, Numero, Colonia,CodigoPostal from ClienteDomicilio where clienteClave ='" & paroCliente.ClienteClave & "' and Tipo = 2")
        With refSW
            .WriteLine(paroCliente.Clave & " " & paroCliente.RazonSocial)
            If tClienteDomicilio.Count > 0 Then
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XDomicilio") & ": " & tClienteDomicilio("Calle").ToString() & " " & tClienteDomicilio("Numero").ToString())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCol") & ": " & tClienteDomicilio("Colonia").ToString().Trim())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCPostal") & ": " & tClienteDomicilio("CodigoPostal").ToString().Trim())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTel") & ": " & paroCliente.TelefonoContacto)

            End If
        End With
        Impresion.ImprimeLineaPunteada(refSW, iLongTot)

        'Datos de la venta

        Dim tTransProd As Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("SELECT TransProd.Folio, TransProd.Total, TransProd.Saldo, Moneda.Nombre FROM ABNTRP INNER JOIN TransProd ON TransProd.TransProdId = ABNTRP.TransProdId INNER JOIN Moneda ON Moneda.MonedaId = TransProd.MonedaId WHERE ABNTRP.ABNId = '" + parsABNId + "'")

        With refSW
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XFolio") & " " & paroVista.BuscarMensaje("msgTicketCobranza", "XVenta") & ": " & tTransProd("Folio").ToString())
            .WriteLine(paroVista.BuscarMensaje("msgTicketCobranza", "XMoneda") & ": " & tTransProd("Nombre").ToString())
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTotal") & ": " & Convert.ToDouble(tTransProd("Total")).ToString(sFormato))
            .WriteLine(paroVista.BuscarMensaje("msgTicketCobranza", "XSaldo") & ": " & Convert.ToDouble(tTransProd("Saldo")).ToString(sFormato))
        End With
        Impresion.ImprimeLineaPunteada(refSW, iLongTot)
        Dim tCobranza As Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("SELECT Folio, FechaAbono, Total FROM Abono WHERE Abono.ABNId = '" + parsABNId + "'")

        With refSW
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XFolio") & ": " & tCobranza("Folio").ToString() & "  " & paroVista.BuscarMensaje("msgTicketCobranza", "XFechaDePago") & ": " & Convert.ToDateTime(tCobranza("FechaAbono")).ToString("dd/MM/yyy"))
        End With

        Dim dtAbonoDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ABNDetalle.MonedaID, Moneda.Nombre, Moneda.Simbolo, TipoPago, Importe, TipoBanco, Referencia, TipoCambio FROM ABNDetalle INNER JOIN Moneda ON Moneda.MonedaID = ABNDetalle.MonedaID WHERE ABNId = '" + parsABNId + "' ORDER BY MonedaID", "ABNDetalle")
        Dim monedaActual As String = ""
        Dim nombreMonedaActual As String = ""
        Dim totalMoneda As Double = 0
        Dim sTemp As String = ""
        With refSW
            For Each fila As DataRow In dtAbonoDetalle.Rows
                If monedaActual <> fila("MonedaId").ToString() Then
                    If totalMoneda > 0 Then
                        sTemp = paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & nombreMonedaActual & ": " & totalMoneda.ToString(sFormato) & " "
                        Impresion.TextoDerecha(sTemp, iLongTot)
                        .WriteLine(sTemp)
                    End If
                    totalMoneda = 0
                    monedaActual = fila("MonedaId").ToString()
                    nombreMonedaActual = fila("Nombre").ToString()
                    .WriteLine()
                    .WriteLine(fila("Nombre").ToString() & IIf(Convert.ToDouble(fila("TipoCambio")) <> 1, " (" & fila("TipoCambio").ToString() & ")", ""))
                End If
                totalMoneda += Convert.ToDouble(fila("Importe"))
                .WriteLine(Impresion.CompletaHasta(" " & ValorReferencia.BuscarEquivalente("PAGO", fila("TipoPago").ToString()), Math.Ceiling((iLongTot / 3) * 2), Alineacion.Izquierda, False) & Impresion.CompletaHasta(" " & Convert.ToDouble(fila("Importe")).ToString(sFormato), Math.Ceiling(iLongTot / 3), Alineacion.Derecha, False))
                If (Not fila("TipoPago") Is DBNull.Value) AndAlso (Not fila("Referencia") Is DBNull.Value) AndAlso (fila("TipoPago").ToString() <> "") AndAlso (fila("Referencia").ToString() <> "") Then
                    .WriteLine("  " & ValorReferencia.BuscarEquivalente("TBANCO", fila("TipoBanco").ToString()) & "  " & fila("Referencia").ToString())
                End If
            Next
            If totalMoneda > 0 Then
                sTemp = paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & nombreMonedaActual & ": " & totalMoneda.ToString(sFormato) & " "
                Impresion.TextoDerecha(sTemp, iLongTot)
                .WriteLine(sTemp)
            End If
        End With
        Impresion.ImprimeLineaPunteada(refSW, iLongTot)
        refSW.WriteLine(paroVista.BuscarMensaje("msgTicketCobranza", "XTotalAbonos") & " " & tTransProd("Nombre").ToString() & ": " & Convert.ToDouble(tCobranza("Total")).ToString(sFormato))

        ''Terminos y condiciones
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XVendedor") & ": " & oVendedor.Nombre, iLongTot))
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
        End With

        tConfig.Clear()
        tClienteDomicilio.Clear()
        tTransProd.Clear()
        tCobranza.Clear()
        dtAbonoDetalle.Dispose()

        refSW.Flush()
        refSW.Close()
        ImprimirArchivo(7, False, parsArchivoNombre, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
    End Sub
    'SuKarne
    Private Sub ImprimirVenta3(ByVal parsArchivoNombre As String, ByVal parsTransProdIds As String(), ByRef refSW As IO.StreamWriter, ByVal paroCliente As Cliente, ByVal paroVista As Vista, ByVal parbPreguntarReimpresion As Boolean)
        Dim sFormato As String = "#,##0.00"
        tTipoPapel = oVendedor.TipoModImp
        'Datos Empresa
        Dim tConfig As Generic.Dictionary(Of String, Object) = oDBApp.RealizarReaderSQLconCampos("Select NombreEmpresa, Calle, Numero,Colonia,Ciudad,Region,Telefono,RFC from Configuracion ")
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(tConfig("NombreEmpresa").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(tConfig("Calle").ToString() & " " & tConfig("Numero").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XCol") & " " & tConfig("Colonia").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(tConfig("Ciudad").ToString() & "," & tConfig("Region").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XTel") & " " & tConfig("Telefono").ToString(), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XRFC") & tConfig("RFC").ToString(), iLongTot))
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgTicketVenta", "XVentaSukarne"), iLongTot))
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XImpresion") & ": " & Now.ToString("dd/MM/yyy hh:mm:ss tt"), iLongTot))
            .WriteLine()
        End With


        'Datos del cliente
        Dim tClienteDomicilio As Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("Select Calle, Numero, Colonia,CodigoPostal from ClienteDomicilio where clienteClave ='" & paroCliente.ClienteClave & "' and Tipo = 2")
        With refSW
            .WriteLine(paroCliente.Clave & " " & paroCliente.RazonSocial)
            If tClienteDomicilio.Count > 0 Then
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XDomicilio") & ": " & tClienteDomicilio("Calle").ToString() & " " & tClienteDomicilio("Numero").ToString())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCol") & ": " & tClienteDomicilio("Colonia").ToString().Trim())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XCPostal") & ": " & tClienteDomicilio("CodigoPostal").ToString().Trim())
                .WriteLine(paroVista.BuscarMensaje("MsgBox", "XTel") & ": " & paroCliente.TelefonoContacto)

            End If
        End With
        Dim blnDesgloseImpuesto As Boolean = paroCliente.IdFiscal <> "XAXX010101000"
        Dim aGranTotal As New Generic.Dictionary(Of String, Decimal)
        For Each sTransProdID As String In parsTransProdIds

            Impresion.ImprimeLineaPunteada(refSW, iLongTot)

            'Datos de la venta
            Dim sConsulta As String
            sConsulta = "Select TRP.Folio, TRP.VisitaClave1, MON.Nombre, MON.MonedaID, TRP.SubTotal, TRP.Impuesto, TRP.Total, TRP.CFVTipo "
            sConsulta &= "from TransProd TRP inner join Moneda MON on MON.MonedaID = TRP.MonedaID "
            If sTransProdID.IndexOf("'") = -1 Then
                sConsulta &= "where TRP.TransProdID='" & sTransProdID & "'"
            Else
                sConsulta &= "where TRP.TransProdID=" & sTransProdID
            End If

            Dim dtTransProd As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "TransProd")
            If dtTransProd.Rows.Count > 0 Then
                With refSW
                    'Titulo y Fecha/Hora
                    .WriteLine(paroVista.BuscarMensaje("MsgBox", "XNotaVenta") & ": " & dtTransProd.Rows(0)("Folio"))
                    .WriteLine(paroVista.BuscarMensaje("msgTicketCobranza", "XMoneda") & ": " & dtTransProd.Rows(0)("Nombre"))
                    '.WriteLine()
                End With
            End If

            'Titulos
            'ImprimeLineaPunteada(refSW, iLongTot)
            'refSW.WriteLine()
            refSW.WriteLine(CompletaHasta(Left(paroVista.BuscarMensaje("MsgBox", "XProducto"), 4), 6, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XCant"), 6, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgTicketVenta", "XUC"), 10, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XP.U"), 12, Alineacion.Derecha, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XImporte"), 14, Alineacion.Derecha, True))
            ImprimeLineaPunteada(refSW, iLongTot)

            'Detalle
            sConsulta = "Select TPD.TransProdDetalleID, PRO.ProductoClave, PRO.Nombre, TPD.Cantidad,TPD.Cantidad1,((TPD.Cantidad * TPD.Factor) +  (TPD.Cantidad1 * TPD.Factor1)) as CantidadCalculada,  TPD.UnidadCobranza, TPD.Precio, TPD.Total, TPD.Subtotal, TPD.DescuentoImp, TPD.DescuentoPor  "
            sConsulta &= "from TransProdDetalle TPD "
            sConsulta &= "inner join Producto PRO ON TPD.ProductoClave = PRO.ProductoClave "
            If sTransProdID.IndexOf("'") = -1 Then
                sConsulta &= "where TransProdID ='" & sTransProdID & "'"
            Else
                sConsulta &= "where TransProdID =" & sTransProdID
            End If
            sConsulta &= "order by TPD.ProductoClave "
            Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "Detalle")

            Dim dTotalBonificaciones As Decimal = 0
            If Not IsNothing(dtTransProd.Rows(0)("VisitaClave1")) AndAlso Not IsDBNull(dtTransProd.Rows(0)("VisitaClave1")) AndAlso dtTransProd.Rows(0)("VisitaClave1") <> "" Then
                Dim dtBonificaciones As DataTable = oDBVen.RealizarConsultaSQL("Select TPD.TransProdDetalleID, TPD.Cantidad, TPD.Cantidad1, TPD.Factor, TPD.Factor1, TPD.DescuentoImp, TPD.DescuentoPor,TPD.Total,TPD.Subtotal from TransProd TRP inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID WHERE TRP.FacturaID='" & sTransProdID & "'", "Bonificaciones")
                Dim nUnidades As Integer = 0
                If dtDetalle.Rows.Count > 0 Then
                    For Each dr As DataRow In dtDetalle.Rows
                        refSW.WriteLine(CompletaHasta(dr("ProductoClave") & " " & dr("Nombre"), 48, Alineacion.Izquierda, True))
                        refSW.WriteLine(CompletaHasta(Format(dr("CantidadCalculada"), "##0.00"), 12, Alineacion.Derecha, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UCOBRA", dr("UnidadCobranza")), 10, Alineacion.Izquierda, False) & CompletaHasta(Format(IIf(blnDesgloseImpuesto, dr("Precio"), dr("Total") / dr("CantidadCalculada")), oApp.FormatoDinero), 12, Alineacion.Derecha, False) & CompletaHasta(Format(IIf(blnDesgloseImpuesto, dr("Subtotal"), dr("Total")), oApp.FormatoDinero), 14, Alineacion.Derecha, True))
                        Dim drBon As DataRow() = dtBonificaciones.Select("TransProdDetalleID = '" & dr("TransProdDetalleID") & "'")
                        If drBon.Length > 0 Then
                            dTotalBonificaciones += drBon(0)("Total")
                            If Math.Round(CDec(drBon(0)("Cantidad")), 2) = Decimal.Round(CDec(dr("Cantidad")), 2) AndAlso Math.Round(CDec(drBon(0)("Cantidad1")), 2) = Math.Round(CDec(dr("Cantidad1")), 2) Then
                                refSW.WriteLine("        " & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XDevolucion"), 14, Alineacion.Izquierda, False) & CompletaHasta(Format(IIf(blnDesgloseImpuesto, (drBon(0)("SubTotal") * -1), (drBon(0)("Total") * -1)), oApp.FormatoDinero), 26, Alineacion.Derecha, True))
                            ElseIf Math.Round(CDec(drBon(0)("Cantidad")), 2) > 0 And (Math.Round(CDec(drBon(0)("Cantidad")), 2) < Math.Round(CDec(dr("Cantidad")), 2) OrElse Math.Round(CDec(drBon(0)("Cantidad1")), 2) < Math.Round(CDec(dr("Cantidad1")), 2)) Then
                                refSW.WriteLine("        " & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XPesoReal"), 14, Alineacion.Izquierda, False) & CompletaHasta(Format(((dr("Cantidad1") - drBon(0)("Cantidad1")) * drBon(0)("Factor1")) + ((dr("Cantidad") - drBon(0)("Cantidad")) * drBon(0)("Factor")), "##0.##"), 12, Alineacion.Derecha, False) & CompletaHasta(Format(IIf(blnDesgloseImpuesto, (drBon(0)("SubTotal") * -1), (drBon(0)("Total") * -1)), oApp.FormatoDinero), 14, Alineacion.Derecha, True))
                            ElseIf CDec(drBon(0)("Cantidad")) = 0 Then
                                refSW.WriteLine("        " & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XBonificacion"), 14, Alineacion.Izquierda, False) & CompletaHasta(Format(drBon(0)("DescuentoPor"), "##0.##") & "%", 8, Alineacion.Derecha, False) & CompletaHasta(Format(IIf(blnDesgloseImpuesto, (drBon(0)("SubTotal") * -1), (drBon(0)("Total") * -1)), oApp.FormatoDinero), 18, Alineacion.Derecha, True))
                            End If
                        End If
                        nUnidades += dr("Cantidad")
                    Next
                End If
                dtDetalle.Dispose()
                dtBonificaciones.Dispose()
            Else
                If blnDesgloseImpuesto Then
                    For Each dr As DataRow In dtDetalle.Rows
                        refSW.WriteLine(CompletaHasta(dr("ProductoClave") & " " & dr("Nombre"), 48, Alineacion.Izquierda, True))
                        refSW.WriteLine(CompletaHasta(Format(dr("CantidadCalculada"), "##0.00"), 12, Alineacion.Derecha, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UCOBRA", dr("UnidadCobranza")), 10, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("Precio"), oApp.FormatoDinero), 12, Alineacion.Derecha, False) & CompletaHasta(Format((dr("Subtotal") + dr("DescuentoImp")), oApp.FormatoDinero), 14, Alineacion.Derecha, True))
                        If dr("DescuentoPor") > 0 Then
                            refSW.WriteLine("        " & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XBonificacion"), 14, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("DescuentoPor"), "##0.##") & "%", 8, Alineacion.Derecha, False) & CompletaHasta(Format((dr("DescuentoImp") * -1), oApp.FormatoDinero), 18, Alineacion.Derecha, True))
                        End If
                    Next
                Else
                    For Each dr As DataRow In dtDetalle.Rows
                        refSW.WriteLine(CompletaHasta(dr("ProductoClave") & " " & dr("Nombre"), 48, Alineacion.Izquierda, True))
                        Dim dTotalOriginal As Decimal = RedondeoAritmetico((dr("Total") * 100) / (100 - dr("DescuentoPor")), 2)
                        Dim dDescuentoInicial As Decimal = RedondeoAritmetico(dTotalOriginal * (dr("DescuentoPor") / 100), 2)

                        refSW.WriteLine(CompletaHasta(Format(dr("CantidadCalculada"), "##0.00"), 12, Alineacion.Derecha, False) & CompletaHasta(ValorReferencia.BuscarEquivalente("UCOBRA", dr("UnidadCobranza")), 10, Alineacion.Izquierda, False) & CompletaHasta(Format(dTotalOriginal / dr("CantidadCalculada"), oApp.FormatoDinero), 12, Alineacion.Derecha, False) & CompletaHasta(Format(dTotalOriginal, oApp.FormatoDinero), 14, Alineacion.Derecha, True))
                        If dr("DescuentoPor") > 0 Then
                            refSW.WriteLine("        " & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XBonificacion"), 14, Alineacion.Izquierda, False) & CompletaHasta(Format(dr("DescuentoPor"), "##0.##") & "%", 8, Alineacion.Derecha, False) & CompletaHasta(Format((dDescuentoInicial * -1), oApp.FormatoDinero), 18, Alineacion.Derecha, True))
                        End If
                    Next
                End If
            End If

            'Totales
            With refSW
                .WriteLine()
                '.WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XDesc.Vendedor"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("DescuentoVendedor"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                If blnDesgloseImpuesto Then
                    .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XSubtotal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Subtotal"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                    .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XI.V.A."), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Impuesto"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                End If
                .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Total"), oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                If dTotalBonificaciones > 0 Then
                    .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XBonificacion"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dTotalBonificaciones, oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                    .WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XMontoReal"), 25, Alineacion.Derecha, False) & CompletaHasta(Format(dtTransProd.Rows(0)("Total") - dTotalBonificaciones, oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                End If
                .WriteLine()
            End With
            dtTransProd.Dispose()
            If parsTransProdIds.Length > 1 Then
                aGranTotal.Add(dtTransProd.Rows(0)("MonedaId"), 0)
            End If
        Next
        'IMPRIMIR TOTALES EN CADA MONEDA
        If aGranTotal.Count > 0 Then
            ImprimeLineaPunteada(refSW, iLongTot)
            refSW.WriteLine(paroVista.BuscarMensaje("MsgBox", "XTotales"))
            For Each sMonedaID As String In aGranTotal.Keys
                Dim sMonedaNombre As String = oDBVen.EjecutarCmdScalarStrSQL("Select Nombre from Moneda where MonedaID ='" & sMonedaID & "'")
                If sMonedaID = oConHist.Campos("MonedaID") Then
                    Dim dTotalMon As Decimal = 0
                    dTotalMon = oDBVen.EjecutarCmdScalardblSQL("Select sum(Total * TipoCambio) from TransProd where TransProdID in(" & String.Join(",", parsTransProdIds) & ")")
                    'aGranTotal(sMonedaID) = dTotalMon
                    refSW.WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & sMonedaNombre, 25, Alineacion.Derecha, False) & CompletaHasta(Format(dTotalMon, oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                Else
                    Dim dtTotales As DataTable = oDBVen.RealizarConsultaSQL("Select MonedaID, Total from TransProd where TransProdID in(" & String.Join(",", parsTransProdIds) & ")", "Totales")
                    Dim dTotalMon As Decimal = dtTotales.Select("MonedaID= '" & sMonedaID & "'")(0)("Total")
                    'SOLO FUNCIONA DE MONEDA BASE A OTRA MONEDA SI ES DE MNEXTRANJERA A MNEXTRANJERA FALLA
                    For Each dr As DataRow In dtTotales.Select("MonedaID <>'" & sMonedaID & "'")
                        Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select TipoCambio from TCMoneda where MonIni='" & sMonedaID & "' and MonFin='" & dr("MonedaID") & "'")
                        dTotalMon += dr("Total") / IIf(dTipoCambio = 0, 1, dTipoCambio)
                    Next
                    'aGranTotal(sMonedaID) = dTotalMon
                    refSW.WriteLine(CompletaHasta("", 10, Alineacion.Izquierda, False) & CompletaHasta(paroVista.BuscarMensaje("MsgBox", "XTotal") & " " & sMonedaNombre, 25, Alineacion.Derecha, False) & CompletaHasta(Format(dTotalMon, oApp.FormatoDinero), 13, Alineacion.Derecha, True))
                End If
            Next
            aGranTotal.Clear()
            aGranTotal = Nothing
        End If
        ''Terminos y condiciones
        With refSW
            .WriteLine()
            .WriteLine(Impresion.TextoCentrado(paroVista.BuscarMensaje("MsgBox", "XVendedor") & ": " & oVendedor.Nombre, iLongTot))
            .WriteLine(paroVista.BuscarMensaje("MsgBox", "XPiePagina1"))
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
            .WriteLine()
        End With

        'dtConfig.Dispose()

        refSW.Flush()
        refSW.Close()
        ImprimirArchivo(7, False, parsArchivoNombre, True, oVendedor.TipoModImp, parbPreguntarReimpresion)
    End Sub
#End Region
#End Region

#Region "Generales"
    Public Function CreaArchivo(ByRef Sw As StreamWriter, ByVal parsNombreArchivo As String) As Boolean
        Try
            If File.Exists(parsNombreArchivo) Then
                File.Delete(parsNombreArchivo)
            End If
            Sw = File.CreateText(parsNombreArchivo)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "CreaArchivo")
            Return False
        End Try
    End Function
    Public Sub CreaEncabezado(ByRef Sw As StreamWriter, ByVal pariLongTot As Integer)
        Try

            Dim Dr As DataRow = oDBApp.RealizarConsultaSQL("SELECT NombreEmpresa,Calle, RFC, Numero, Colonia, Ciudad, Region FROM Configuracion", "Encabezado").Rows(0)
            Sw.WriteLine(TextoCentrado(Dr("NombreEmpresa"), pariLongTot))
            Sw.WriteLine(TextoCentrado(Dr("RFC"), pariLongTot))
            Sw.WriteLine(TextoCentrado(Dr("Calle") & " " & Dr("Numero"), pariLongTot))
            Sw.WriteLine(TextoCentrado(Dr("Colonia"), pariLongTot))
            Sw.WriteLine(TextoCentrado(Dr("Ciudad"), pariLongTot))
            Sw.WriteLine(TextoCentrado(Dr("Region"), pariLongTot))
            Sw.WriteLine()
            Sw.WriteLine()
            Sw.WriteLine(TextoCentrado(oVendedor.NombreVendedor, pariLongTot))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "CreaEncabezado")
        End Try
    End Sub
    Public Function TextoCentrado(ByVal cadena As String, ByVal pariLongTotal As Integer) As String
        Dim espacios As String = ""
        Dim ls As Integer = cadena.Length
        Dim i As Integer
        For i = 1 To Int((pariLongTotal - ls) / 2) Step 1
            espacios &= " "
        Next
        Return espacios & cadena
    End Function

    Private Function FTextoDerecha(ByVal cadena As String, ByVal pariLongTotal As Integer) As String
        Dim espacios As String = ""
        Dim ls As Integer = cadena.Length
        Dim i As Integer
        For i = 1 To (pariLongTotal - ls)
            espacios &= " "
        Next
        Return espacios & cadena
    End Function

    Public Sub ImprimeLineaPunteada(ByRef Sw As IO.StreamWriter, ByVal pariLongTot As Integer)
        Dim i As Integer
        Dim Lin As String = ""
        For i = 1 To pariLongTot
            Lin &= "-"
        Next
        Sw.WriteLine(Lin)
    End Sub
    Public Function CompletaHasta(ByVal cadena As String, ByVal espacios As Integer, ByVal Alineado As Alineacion, ByVal UltimaColumna As Boolean) As String
        If cadena.Length >= espacios Then
            If UltimaColumna Then
                cadena = Microsoft.VisualBasic.Left(cadena, espacios)
            Else
                cadena = Microsoft.VisualBasic.Left(cadena, espacios - 1) & " "
            End If
        Else
            Dim i As Integer
            If Alineado = Alineacion.Izquierda Then
                For i = 1 To espacios - cadena.Length
                    cadena &= " "
                Next
            ElseIf Alineado = Alineacion.Derecha Then
                If UltimaColumna Then
                    For i = espacios - cadena.Length To 1 Step -1
                        cadena = " " & cadena
                    Next
                Else
                    For i = espacios - cadena.Length - 1 To 1 Step -1
                        cadena = " " & cadena
                    Next
                    cadena = cadena & " "
                End If
            End If
        End If
        Return cadena
    End Function
    Public Sub EspaciosAlFinal(ByRef Sw As StreamWriter, Optional ByVal Renglones As Integer = 16)
        For i As Integer = 1 To Renglones
            Sw.WriteLine()
        Next
    End Sub
    Public Function ImprimirArchivo(ByVal pariTamañoFuente As Integer, ByVal parbBold As Boolean, ByVal parsNombreArchivo As String, ByVal parbUsarLogo As Boolean, ByVal partTipoPapel As TipoPapel, ByVal parbPreguntarReimpresion As Boolean) As Boolean
        Dim PrCe As PrinterCE
        'Impresion Ascii
        Dim AsciiCE As AsciiCE
        Dim SrAD As StreamReader
        Dim oPort As FieldSoftware.PrinterCE_NetCF.AsciiCE.ASCIIPORT
        Dim sMensajeReimpresion As String = gVista.BuscarMensaje("MsgBoxGeneral", "P0208")
#If Ascii = True Then
        AsciiCE = New AsciiCE("139H9P113M")
#Else
        PrCe = New PrinterCE(PrinterCE_Base.EXCEPTION_LEVEL.ALL, "139H9P113M")
#End If
        Try
#If Ascii = True Then
            Dim bContinuar As Boolean = False
            If Not oApp.Puertos.Columns.Contains("Impresora") Then
                MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                Exit Function
            End If
            Select Case partTipoPapel
                Case TipoPapel.TecTermica2

                    Dim filas As Data.DataRow() = oApp.Puertos.Select("Impresora=" & partTipoPapel)
                    If filas.Length = 0 Then
                        MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                        Exit Function
                    Else
                        Dim blnReintentar As Boolean = False
                        Do
                            Try
                                oPort = ObtenerPuerto(filas(0)("Puerto"))
                                bContinuar = AsciiCE.SelectPort(oPort)
                                blnReintentar = False
                            Catch ex As Exception
                                If parbPreguntarReimpresion Then
                                    If MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                        AsciiCE = New AsciiCE("139H9P113M")
                                        blnReintentar = True
                                    Else
                                        Exit Function
                                    End If
                                Else
                                    Exit Function
                                End If
                            End Try
                        Loop While blnReintentar
                    End If

                Case TipoPapel.ExtechTermica2, TipoPapel.ExtechTermica3
                    Dim Puerto As String = ""
                    If partTipoPapel = TipoPapel.ExtechTermica2 Then
                        Dim filas As Data.DataRow() = oApp.Puertos.Select("Impresora=" & partTipoPapel)
                        If filas.Length = 0 Then
                            MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                            Exit Function
                        Else
                            Dim blnReintentar As Boolean = False
                            Do
                                Try
                                    oPort = ObtenerPuerto(filas(0)("Puerto"))
                                    bContinuar = AsciiCE.SelectPort(oPort)
                                    blnReintentar = False
                                Catch ex As Exception
                                    If parbPreguntarReimpresion Then
                                        If MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                            AsciiCE = New AsciiCE("139H9P113M")
                                            blnReintentar = True
                                        Else
                                            Exit Function
                                        End If
                                    Else
                                        Exit Function
                                    End If
                                End Try
                            Loop While blnReintentar
                        End If
                    Else
                        Dim filas As Data.DataRow() = oApp.Puertos.Select("Impresora=" & partTipoPapel)
                        If filas.Length = 0 Then
                            MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                            Exit Function
                        Else
                            Dim blnReintentar As Boolean = False
                            Do
                                Try
                                    oPort = ObtenerPuerto(filas(0)("Puerto"))
                                    bContinuar = AsciiCE.SelectPort(oPort)
                                    blnReintentar = False
                                Catch ex As Exception
                                    If parbPreguntarReimpresion Then
                                        If MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                            AsciiCE = New AsciiCE("139H9P113M")
                                            blnReintentar = True
                                        Else
                                            Exit Function
                                        End If
                                    Else
                                        Exit Function
                                    End If
                                End Try
                            Loop While blnReintentar
                        End If
                    End If

                    If bContinuar Then
                        Dim normal As Byte() = {29}
                        Dim Font2 As Byte() = {27, 107, 53} '2 pulgadas-Font5
                        Dim FontApex2 As Byte() = {27, 107, 53}

                        Dim Font3 As Byte() = {27, 107, 50} '3 pulgadas-Font1
                        If partTipoPapel = TipoPapel.ExtechTermica2 Then
                            AsciiCE.Write(Font2, 3)
                        Else
                            AsciiCE.Write(Font3, 3)
                        End If
                    End If
                Case TipoPapel.ExtechImpacto2
                    Dim filas As Data.DataRow() = oApp.Puertos.Select("Impresora=" & partTipoPapel)
                    If filas.Length = 0 Then
                        MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                        Exit Function
                    End If
                    Dim blnReintentar As Boolean = False
                    Do
                        Try
                            oPort = ObtenerPuerto(filas(0)("Puerto"))
                            If AsciiCE.SelectPort(oPort) Then
                                Dim normal As Byte() = {29}
                                Dim Font As Byte() = {27, 20}
                                AsciiCE.Write(Font, 2)

                            End If
                            blnReintentar = False
                        Catch ex As Exception
                            If parbPreguntarReimpresion Then
                                If MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                    AsciiCE = New AsciiCE("139H9P113M")
                                    blnReintentar = True
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End Try
                    Loop While blnReintentar

                Case TipoPapel.ZebraTermica2
                    Dim filas As Data.DataRow() = oApp.Puertos.Select("Impresora=" & partTipoPapel)
                    If filas.Length = 0 Then
                        MsgBox([Global].gVista.BuscarMensaje("MsgBoxGeneral", "E0708"))
                        Exit Function
                    End If
                    Dim blnReintentar As Boolean = False
                    Do
                        Try
                            oPort = ObtenerPuerto(filas(0)("Puerto"))
                            If AsciiCE.SelectPort(oPort) Then
                                AsciiCE.Text("! U1 SETLP 0 2 12 ")
                                AsciiCE.CrLf()
                                AsciiCE.Text("! U1 SETSP 0")
                                AsciiCE.CrLf()
                            End If
                            blnReintentar = False
                        Catch ex As Exception
                            If parbPreguntarReimpresion Then
                                If MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                    AsciiCE = New AsciiCE("139H9P113M")
                                    blnReintentar = True
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End Try
                    Loop While blnReintentar
            End Select
#Else
            '***********
            Dim PrSet As PrinterCE.PRINTER_SETUP
            PrSet = PrCe.SetupPrSettings_All
            PrSet.Printer = PrinterCE_Base.PRINTER.ZEBRA
            'PrSet.Port = PrinterCE_Base.PORT.COM7
            PrSet.Port = PrinterCE_Base.PORT.INFRARED
            PrSet.PortSpeed = PrinterCE_Base.PORT_SPEED.S_57600
            'prset.FormFeedScrollDistance
            PrCe.SetupPrSettings_All = PrSet
            '***********
            PrCe.SetupPrinter(PrinterCE_Base.PRINTER.ONEIL, PrinterCE_Base.PORT.COM5, PrinterCE_Base.PORT_SPEED.S_57600)
            'PrCe.SetupPrinter(PrinterCE_Base.PRINTER.EXTECH_3, PrinterCE_Base.PORT.COM5, PrinterCE_Base.PORT_SPEED.S_38400, True)
            'PrCe.SetupPrinter(PrinterCE_Base.PRINTER.ONEIL, PrinterCE_Base.PORT.COM8, PrinterCE_Base.PORT_SPEED.S_38400, True)
            'PrCe.SetupPrinter(PrinterCE_Base.PRINTER.ZEBRA, PrinterCE_Base.PORT.COM4, PrinterCE_Base.PORT_SPEED.S_57600, True)
            'PrCe.SetupPrinter(PrinterCE_Base.PRINTER.ONEIL, PrinterCE_Base.PORT.INFRARED, PrinterCE_Base.PORT_SPEED.S_9600, True)
            'PrCe.ScaleMode = PrinterCE_Base.MEASUREMENT_UNITS.CENTIMETERS
            PrCe.ScaleMode = PrinterCE_Base.MEASUREMENT_UNITS.INCHES
            PrCe.SetupPaperCustom(PrinterCE_Base.ORIENTATION.PORTRAIT, 2, 10)
            If File.Exists(Logo) Then
                Dim w, h As Double
                Dim Img As New Drawing.Bitmap(Logo)
                w = Img.Width
                h = Img.Height
                PrCe.ScaleMode = PrinterCE_Base.MEASUREMENT_UNITS.PIXELS
                w = (PrCe.PrPgWidth - w) / 2
                PrCe.DrawPicture(Logo, w, 0)
                PrCe.TextY = h + 10
                PrCe.ScaleMode = PrinterCE_Base.MEASUREMENT_UNITS.CENTIMETERS
            End If
            PrCe.FontBold = parbBold
            PrCe.FontSize = pariTamañoFuente
            PrCe.FontName = "Courier New"
            'PrCe.FontName = "26H"
#End If
            Do
#If Ascii = True Then
                If partTipoPapel = TipoPapel.ExtechTermica2 OrElse partTipoPapel = TipoPapel.ExtechTermica3 Then
                    If parbUsarLogo Then
                        Dim bLogo As Byte() = {27, 76, 103, 48}
                        AsciiCE.Write(bLogo, 4)
                    End If
                ElseIf partTipoPapel = TipoPapel.ZebraTermica2 Then
                    If parbUsarLogo Then
                        Dim sImagen As String
                        sImagen = "! 0 200 200 140 1" & vbCrLf
                        sImagen &= "PCX 0 0 !<LOGO.PCX " & vbCrLf
                        sImagen &= "PRINT "
                        AsciiCE.Text(sImagen)
                        AsciiCE.CrLf()
                    End If
                End If
#End If
                Dim line As String
                SrAD = New StreamReader(parsNombreArchivo)
                Dim nLinea As Integer = 0
                Dim sReporte As String = ""
                Do
                    line = SrAD.ReadLine()
#If Ascii = True Then
                    If Not IsNothing(line) Then
                        Dim sCadena As String = line
                        Dim aCadena As New ArrayList
                        Dim nUltimo As Integer
                        Dim sDato As String
                        nUltimo = 1
                        While nUltimo > 0
                            nUltimo = sCadena.LastIndexOf("{")
                            If nUltimo > 0 Then
                                sDato = sCadena.Substring(nUltimo, sCadena.Length - nUltimo)
                                sDato = sDato.Substring(sDato.IndexOf("}") + 1, sDato.Length - (sDato.IndexOf("}") + 1))
                                aCadena.Add(sDato)
                                sCadena = sCadena.Remove(nUltimo, sCadena.Length - nUltimo)
                            End If
                        End While
                        If sCadena <> "" Then
                            aCadena.Add(sCadena)
                        End If
                        aCadena.Reverse()
                        sCadena = ""
                        For Each sDato In aCadena
                            sCadena &= sDato
                        Next
                        line = sCadena
                        If line.StartsWith("{") Then
                            Select Case partTipoPapel
                                Case TipoPapel.ExtechTermica2, TipoPapel.ExtechTermica3
                                    Dim FontDef As Byte() = {27, 107, line.Substring(1, line.IndexOf("}") - 1)}
                                    AsciiCE.Write(FontDef, 3)
                                Case TipoPapel.ExtechImpacto2
                                    If line.Substring(1, line.IndexOf("}") - 1) = 0 Then
                                        Dim FontDef As Byte() = {27, 14}
                                        AsciiCE.Write(FontDef, 2)
                                        Dim FontDef1 As Byte() = {27, 28}
                                        AsciiCE.Write(FontDef1, 2)
                                    Else
                                        Dim FontDef As Byte() = {27, line.Substring(1, line.IndexOf("}") - 1)}
                                        AsciiCE.Write(FontDef, 2)
                                    End If
                                Case TipoPapel.TecTermica2
                                    If line.Substring(1, line.IndexOf("}") - 1) = 0 Then
                                        line = line.Remove(0, line.IndexOf("}") + 1)
                                        line = Chr(27) & "KVA016032" & line
                                    ElseIf line.Substring(1, line.IndexOf("}") - 1) = 1 Then
                                        line = line.Remove(0, line.IndexOf("}") + 1)
                                        line = Chr(27) & "KA" & line
                                    End If
                                Case TipoPapel.ZebraTermica2
                                    sReporte &= "! U1 SETLP 0 " & line.Substring(1, line.IndexOf("}") - 1)
                            End Select
                            line = line.Substring(line.IndexOf("}") + 1, line.Length - (line.IndexOf("}") + 1))
                        ElseIf line = "IMPRIME_LOGO" Then
                            If parbUsarLogo Then
                                If partTipoPapel = TipoPapel.ExtechTermica2 OrElse partTipoPapel = TipoPapel.ExtechTermica3 Then
                                    Dim bLogo As Byte() = {27, 76, 103, 48}
                                    AsciiCE.Write(bLogo, 4)
                                End If
                            End If
                            Continue Do
                        End If
                    End If
                    If partTipoPapel = TipoPapel.ZebraTermica2 Then
                        sReporte &= line & vbCrLf
                    Else
                        AsciiCE.Text(line)
                        AsciiCE.CrLf()
                    End If
#Else
                PrCe.DrawTextFlow(line)
#End If
                Loop Until line Is Nothing
                'End If

                If partTipoPapel = TipoPapel.ZebraTermica2 Then
                    AsciiCE.Text(sReporte)
                    AsciiCE.CrLf()
                End If

                SrAD.Close()
            Loop While parbPreguntarReimpresion AndAlso MsgBox(sMensajeReimpresion, MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes
#If Ascii = True Then
            AsciiCE.ClosePort()
            If Not IsNothing(AsciiCE) Then
                AsciiCE.ShutDown()
            End If
#Else
            PrCe.EndDoc()
#End If
            'Dim port As New Port("COM5:")
            'port.PortType = PortTypes.Bluetooth
            'System.Threading.Thread.Sleep(1000)
            'port.SendFile(Archivo)
        Catch PrCEex As PrinterCEException
            MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0058"), MsgBoxStyle.Exclamation, "PrinterCEException")
            Try
                If oApp.ModeloTerminal = "HHP7600" And oPort <> FieldSoftware.PrinterCE_NetCF.AsciiCE.ASCIIPORT.INFRARED Then
                    ApagarPrenderBlueTooth()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            If Not SrAD Is Nothing Then
                SrAD.Close()
            End If
#If Ascii = True Then
            AsciiCE.ClosePort()
#Else
            PrCe.EndDoc()
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
#If Ascii = True Then
            AsciiCE = Nothing
#Else
            If Not IsDBNull(PrCe) Then
                PrCe.ShutDown()
            End If
#End If
        End Try
    End Function
    Public Function ObtenerPuerto(ByVal NombrePuerto As String) As FieldSoftware.PrinterCE_NetCF.AsciiCE.ASCIIPORT
        If NombrePuerto.ToUpper = "COM1" Then
            Return AsciiCE.ASCIIPORT.COM1
        ElseIf NombrePuerto.ToUpper = "COM2" Then
            Return AsciiCE.ASCIIPORT.COM2
        ElseIf NombrePuerto.ToUpper = "COM3" Then
            Return AsciiCE.ASCIIPORT.COM3
        ElseIf NombrePuerto.ToUpper = "COM4" Then
            Return AsciiCE.ASCIIPORT.COM4
        ElseIf NombrePuerto.ToUpper = "COM5" Then
            Return AsciiCE.ASCIIPORT.COM5
        ElseIf NombrePuerto.ToUpper = "COM6" Then
            Return AsciiCE.ASCIIPORT.COM6
        ElseIf NombrePuerto.ToUpper = "COM7" Then
            Return AsciiCE.ASCIIPORT.COM7
        ElseIf NombrePuerto.ToUpper = "COM8" Then
            Return AsciiCE.ASCIIPORT.COM8
        ElseIf NombrePuerto.ToUpper = "COM9" Then
            Return AsciiCE.ASCIIPORT.COM9
        ElseIf NombrePuerto.ToUpper = "INFRAROJO" Then
            Return AsciiCE.ASCIIPORT.INFRARED
        End If
        Return AsciiCE.ASCIIPORT.ANYCOM_BT
    End Function
    Public Sub ApagarPrenderBlueTooth()
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
        HHP.Network.RadioMgr.RadioMgrServices.SetRadioMode(HHP.Network.RadioMgr.RadioMgrServices.RadioOPMode.OP_80211B)
        System.Threading.Thread.Sleep(4000)
        HHP.Network.RadioMgr.RadioMgrServices.SetRadioMode(HHP.Network.RadioMgr.RadioMgrServices.RadioOPMode.OP_80211B_BT)
#End If
    End Sub
#End Region

#Region "ENUMS"
    Public Enum Alineacion
        Izquierda = 0
        Derecha = 1
    End Enum
    Public Enum ModoImpresion
        ConVisita = 1
        SinVisita = 2
    End Enum
#End Region
End Module
