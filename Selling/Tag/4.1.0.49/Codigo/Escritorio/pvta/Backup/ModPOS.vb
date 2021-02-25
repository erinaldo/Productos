
Module ModPOS

    Public Function imprimeTicketApertura(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        Dim dApertura As DateTime
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("APERTURA DE CAJA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(" ", 0, Imprimir.Alinear.Izquierda)

        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Tickets.AddHeaderLine("*** DETALLE REGISTRADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                Tickets.AddHeaderItem("CANT. ", "DENOMINACION", "IMPORTE", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    Tickets.AddHeaderItem(CStr(IIf(dtDetalle.Rows(i)("Cantidad").GetType.Name = "DBNull", 1, dtDetalle.Rows(i)("Cantidad"))), CStr(IIf(dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull", "Efectivo", dtDetalle.Rows(i)("Denominacion"))), Strings.Format(Redondear(dtDetalle.Rows(i)("Importe"), 2).ToString, "Currency"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
                Next
            End If
            dtDetalle.Dispose()
        End If
        Tickets.AddHeaderItem("", "TOTAL", Strings.Format(Redondear(dSaldoApertura, 2).ToString, "Currency"), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 15, 0)

    End Function

    Public Sub ImprimirSurtido(ByVal iTipo As Integer, ByVal sDocumento As String, ByVal sPrinter As String)
        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Imprimiendo...")
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_surtidodetalle", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_envio", "@Tipo", iTipo, "@DOCClave", sDocumento))
        pvtaDataSet.DataSetName = "pvtaDataSet"
        OpenReport.Print("CRSurtidoDetalle.rpt", pvtaDataSet, "", sPrinter)
        frmStatusMessage.Dispose()
    End Sub

    Public Function imprimeTicketCierre(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        Dim sCierre As String = ""
        Dim dApertura As DateTime
        Dim dCierre As DateTime
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim dSaldoCierre As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                sCierre = dtObjetos.Rows(0)("Cierre")
                dCierre = dtObjetos.Rows(0)("FechaCierre")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
                dSaldoCierre = dtObjetos.Rows(0)("SaldoCierre")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("*** CORTE DE CAJA *** ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("CIERRE: " & sCierre, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.CIERRE: " & dCierre.ToShortDateString & " " & dCierre.ToShortTimeString, 0, 3)

        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        Dim fila As Integer = 0
        Dim foundRows() As DataRow
        Dim sConcepto As String = ""
        Dim dImporte As Double = 0.0
        Dim dTotalIngresos As Double = 0.0
        Dim dTotalEgresos As Double = 0.0
        Dim dTotalEfectivoCaja As Double = 0.0

        Tickets.AddHeaderLine("INGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_ingreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalPagos As Double = 0

        'If dSaldoApertura > 0 Then
        '    Tickets.AddHeaderLineDetalle("S. INICIAL", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        '    dTotalPagos += dSaldoApertura
        'End If

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))

                        If sConcepto = "EFECTIVO" Then
                            dTotalEfectivoCaja += dImporte
                        End If

                        dTotalPagos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                End If
            End If
            dtObjetos.Dispose()
        End If

        Tickets.AddHeaderLineDetalle("TOTAL", dTotalPagos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_egreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("EGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalEgresos += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        dTotalIngresos = dTotalPagos - dTotalEgresos
        'Tickets.AddHeaderLineDetalle("TOTAL EN CAJA", dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        '--- Fin Corte


        Tickets.AddHeaderLine("*** VENTAS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_credito", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalVta As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CREDITO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalVta += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalVta, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

                End If
            End If
            dtObjetos.Dispose()
        End If

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_contado", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalContado As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CONTADO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalContado += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        If (dTotalVta > 0 AndAlso dTotalContado > 0) OrElse (dTotalVta = 0 AndAlso dTotalContado = 0) Then
            Tickets.AddHeaderLineDetalle("TOTAL VENTAS", dTotalVta + dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
            Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        End If

        dTotalVta += dTotalContado

        Tickets.AddHeaderLine("*** CARGOS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cargo", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalCargos As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalCargos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCargos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        Dim dTotalCobranza As Double = 0


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cobranza", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("*** COBRANZA DEL DIA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalCobranza += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCobranza, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        '----- Corte

        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull" OrElse IsNumeric(dtDetalle.Rows(i)("Denominacion")) Then
                        dTotalEfectivoCaja += CDbl(dtDetalle.Rows(i)("Importe"))
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If


        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 2, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Tickets.AddHeaderLine("*** DETALLE REGISTRADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                Tickets.AddHeaderItem("CANT. ", "DENOMINACION", "IMPORTE", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    Tickets.AddHeaderItem(CStr(IIf(dtDetalle.Rows(i)("Cantidad").GetType.Name = "DBNull", 1, dtDetalle.Rows(i)("Cantidad"))), CStr(IIf(dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull", "Efectivo", dtDetalle.Rows(i)("Denominacion"))), Strings.Format(Redondear(dtDetalle.Rows(i)("Importe"), 2).ToString, "Currency"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
                Next

                Tickets.AddHeaderItem("", "TOTAL", Strings.Format(Redondear(dSaldoCierre, 2).ToString, "Currency"), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

            End If
            dtDetalle.Dispose()

        End If

        Tickets.AddHeaderLine("*** RESUMEN ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        'Ciclo de llenado AddHeaderLineDetalle
        Tickets.AddHeaderLineDetalle("S. APERTURA", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO AL CORTE", dSaldoApertura + dTotalIngresos, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO REGISTRADO", dSaldoCierre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SOBRANTE(FALTANTE)", dSaldoCierre - (dSaldoApertura + dTotalIngresos), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("T.EFECTIVO EN CAJA", dTotalEfectivoCaja - dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Public Function imprimeTicketPreCorte(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        'Dim sCierre As String = ""
        Dim dApertura As DateTime
        Dim dCierre As DateTime = DateTime.Now
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim dSaldoCierre As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("*** PRE-CORTE DE CAJA *** ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.CIERRE  : " & dCierre.ToShortDateString & " " & dCierre.ToShortTimeString, 0, 3)

        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        Dim fila As Integer = 0
        Dim foundRows() As DataRow
        Dim sConcepto As String = ""
        Dim dImporte As Double = 0.0
        Dim dTotalIngresos As Double = 0.0
        Dim dTotalEgresos As Double = 0.0
        Dim dTotalEfectivoCaja As Double = 0.0

        Tickets.AddHeaderLine("INGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_ingreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalPagos As Double = 0

        'If dSaldoApertura > 0 Then
        '    Tickets.AddHeaderLineDetalle("S. INICIAL", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        '    dTotalPagos += dSaldoApertura
        'End If

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))

                        If sConcepto = "EFECTIVO" Then
                            dTotalEfectivoCaja += dImporte
                        End If

                        dTotalPagos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

                    Next
                End If
            End If
            dtObjetos.Dispose()
        End If

        Tickets.AddHeaderLineDetalle("TOTAL", dTotalPagos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_egreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("EGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalEgresos += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        dTotalIngresos = dTotalPagos - dTotalEgresos
        'Tickets.AddHeaderLineDetalle("TOTAL EN CAJA", dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        '--- Fin Corte


        Tickets.AddHeaderLine("*** VENTAS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_credito", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalVta As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CREDITO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalVta += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalVta, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

                End If
            End If
            dtObjetos.Dispose()
        End If

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_contado", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalContado As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CONTADO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalContado += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        If (dTotalVta > 0 AndAlso dTotalContado > 0) OrElse (dTotalVta = 0 AndAlso dTotalContado = 0) Then
            Tickets.AddHeaderLineDetalle("TOTAL VENTAS", dTotalVta + dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
            Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        End If

        dTotalVta += dTotalContado

        Tickets.AddHeaderLine("*** CARGOS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cargo", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalCargos As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalCargos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCargos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        Dim dTotalCobranza As Double = 0


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cobranza", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("*** COBRANZA DEL DIA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalCobranza += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCobranza, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        'Corte
        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull" OrElse IsNumeric(dtDetalle.Rows(i)("Denominacion")) Then
                        dTotalEfectivoCaja += CDbl(dtDetalle.Rows(i)("Importe"))
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If

        Tickets.AddHeaderLine("*** RESUMEN ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        'Ciclo de llenado AddHeaderLineDetalle
        Tickets.AddHeaderLineDetalle("S. APERTURA", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO AL CORTE", dSaldoApertura + dTotalIngresos, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("T.EFECTIVO EN CAJA", dTotalEfectivoCaja - dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        'Tickets.AddHeaderLineDetalle("SALDO REGISTRADO", dSaldoCierre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderLineDetalle("SOBRANTE(FALTANTE)", dSaldoCierre - dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        'Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Public Function crearQR(ByVal eRFC As String, ByVal RFC As String, ByVal total As Double, ByVal uuid As String) As Byte()
        Dim CBB() As Byte = Nothing
        Try
            Dim encoderQR As New ThoughtWorks.QRCode.Codec.QRCodeEncoder

            '122 bytes de datos en este encode!!
            encoderQR.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            encoderQR.QRCodeScale = 3
            encoderQR.QRCodeVersion = 7
            encoderQR.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M

            Dim imagen As System.Drawing.Bitmap
            're	RFC del Emisor, a 12/13 posiciones, precedido por el texto ”?re=”--------------------------------------------------------------------------------------- 17
            'rr	RFC del Receptor, a 12/13 posiciones, precedido por el texto “&rr=” ------------------------------------------------------------------------------------ 17
            'tt	Total del comprobante a 17 posiciones (10 para los enteros, 1 para carácter “.”, 6 para los decimales), precedido por el texto “&tt=” ---------21
            'id	UUID del comprobante, precedido por el texto “&id=”------------------------------------------------------------------------------------------------------- 40

            Dim sTotal As String = cFormat(CStr(Redondear(CDbl(total), 6)))

            If sTotal.Split(".").Length >= 1 Then

                sTotal = Right("0000000000" & sTotal.Split(".")(0), 10) & "." & Left(sTotal.Split(".")(1) & "000000", 6)
             
            End If

            imagen = encoderQR.Encode("?re=" & eRFC & "&rr=" & RFC & "&tt=" & sTotal & "&id=" & uuid)

            CBB = ModPOS.ConvertBitmapToByteArray(imagen)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al generar QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CBB
    End Function

    Public Function cancelarXML(ByVal dtPAC As DataTable, ByVal sFolio As String, ByVal UUID As String, ByVal eRFC As String) As Boolean
        Dim dt As DataTable
        Dim LlaveFile, CertificadoFile, ContrasenaClave, pfx As String

        dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            LlaveFile = dt.Rows(0)("Llave")
            CertificadoFile = IIf(dt.Rows(0)("urlCertificado").GetType.Name = "DBNull", "", dt.Rows(0)("urlCertificado"))
            ContrasenaClave = dt.Rows(0)("Password")
            dt.Dispose()
        Else
            MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If

        pfx = ModPOS.generaPFX(LlaveFile, CertificadoFile, ContrasenaClave)

        If pfx = "" Then
            Return False
            Exit Function
        End If

        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Solicitado Cancelación...")
        Dim j As Integer
        For j = 0 To dtPAC.Rows.Count - 1
            If dtPAC.Rows(j)("TipoPAC") = 1 Then ' Tralix

                Dim oCfdi As New LibCFDiTralix.CFDiTralix()
                Try
                    If oCfdi.CancelarCFDi(pfx, ContrasenaClave, UUID, eRFC, dtPAC.Rows(j)("Customerkey"), dtPAC.Rows(j)("ServerCancel")) = False Then
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                            frmStatusMessage.Close()
                            Return False
                            Exit Function

                        End If
                    End If
                    Exit For
                Catch ex As System.Net.WebException
                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                End Try
            ElseIf dtPAC.Rows(j)("TipoPAC") = 2 Then 'iTimbres
                Dim aUUID As String() = {UUID}
                Dim sResult As String
                Try
                    sResult = ModPOS.CancelarFacturaiTimbre(sFolio, eRFC, dtPAC.Rows(j)("UserId"), dtPAC.Rows(j)("CustomerKey"), aUUID, ContrasenaClave, pfx, dtPAC.Rows(j)("ServerCancel"))
                    If sResult <> "" Then
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox(sResult)
                            frmStatusMessage.Close()
                            Return False
                            Exit Function
                        End If

                    End If
                Catch ex As System.Net.WebException
                    MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                End Try

            ElseIf dtPAC.Rows(j)("TipoPAC") = 4 Then 'DigitalInvoice


            End If
        Next

        frmStatusMessage.Close()

        Return True
    End Function

    Public Sub actualizaEdoCFD(ByVal sTipoComprobante As String, ByVal sDOCClave As String, ByVal iEstado As Integer, ByVal iTipoComprobante As Integer)
        If sTipoComprobante = "ingreso" Then
            If iTipoComprobante = 6 Then
                ModPOS.Ejecuta("sp_actualiza_edo_cargo", "@CARClave", sDOCClave, "@Estado", iEstado)
            Else
                ModPOS.Ejecuta("sp_actualiza_edo_fac", "@FACClave", sDOCClave, "@Estado", iEstado)
            End If
        Else
            ModPOS.Ejecuta("sp_actualiza_edo_nc", "@NCClave", sDOCClave, "@Estado", iEstado)
        End If
    End Sub

    Public Function soloLetras(ByVal KeyChar As Char) As Boolean
        If Char.IsDigit(KeyChar) Then
            Return False
        ElseIf Char.IsControl(KeyChar) Then
            Return False
        ElseIf Char.IsSymbol(KeyChar) Then
            Return False
        ElseIf Char.IsSeparator(KeyChar) Then
            Return False
        ElseIf Char.IsWhiteSpace(KeyChar) Then
            Return False
        ElseIf Char.IsPunctuation(KeyChar) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function crearXMLNomina(ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal sTipoComprobante As String, Optional ByVal oCFD As eCFD = Nothing, Optional ByVal dtConcepto As DataTable = Nothing, Optional ByVal dtImpuesto As DataTable = Nothing) As Integer
        Dim i As Integer
        Dim FileXML, oFileXML As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0

        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim VersionSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim eRFC As String = ""
        Dim RFC As String = ""


        Dim fechaTimbrado As Date
        Dim total As Double

        Dim CBB() As Byte

        FileXML = pathActual & "CFD\" & sFolio & ".xml"

        Dim sTipoDeduccion, sTipoPercepcion, sTipoBanco As String

        If PathXML.Length <= 3 Then
            oFileXML = PathXML & sFolio & ".xml"
        ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
            oFileXML = PathXML & sFolio & ".xml"
        Else
            oFileXML = PathXML & "\" & sFolio & ".xml"
        End If

        'Si existe el archivo previamente lo borra
        If System.IO.File.Exists(FileXML) Then
            System.IO.File.Delete(FileXML)
        End If

        'Crea por primera vez el XML o regenerar xml

        sPre = "cfdi:"

        Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
        textWriter.Formatting = System.Xml.Formatting.None
        ' Opens the document
        textWriter.WriteStartDocument()

        ' Write first element

        textWriter.WriteStartElement(sPre & "Comprobante")
        textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
        textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
        textWriter.WriteAttributeString("xmlns:nomina", "http://www.sat.gob.mx/nomina")
        textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/nomina http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd")

        textWriter.WriteAttributeString("version", oCFD.VersionCF)

        If oCFD.Serie <> "" Then
            textWriter.WriteAttributeString("serie", oCFD.Serie)
        End If

        textWriter.WriteAttributeString("folio", oCFD.Folio)
        textWriter.WriteAttributeString("fecha", String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha))
        textWriter.WriteAttributeString("sello", oCFD.sello)

        textWriter.WriteAttributeString("formaDePago", oCFD.formaDePago)
        textWriter.WriteAttributeString("noCertificado", oCFD.noCertificado)
        textWriter.WriteAttributeString("certificado", oCFD.Certificado64)
        textWriter.WriteAttributeString("subTotal", oCFD.subtotal)
        textWriter.WriteAttributeString("descuento", QuitarCeros(oCFD.descuento))

        If oCFD.descuento > 0 Then
            textWriter.WriteAttributeString("motivoDescuento", "Deducciones nómina")
        End If

        textWriter.WriteAttributeString("TipoCambio", QuitarCeros(oCFD.TipoCambio))
        textWriter.WriteAttributeString("Moneda", oCFD.Moneda)

        textWriter.WriteAttributeString("total", oCFD.total)
        textWriter.WriteAttributeString("tipoDeComprobante", "egreso")

        textWriter.WriteAttributeString("metodoDePago", spaceFormat(oCFD.metodoDePago))
        textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.LugarExpedicion))

        If oCFD.NumCtaPago <> "" Then
            textWriter.WriteAttributeString("NumCtaPago", spaceFormat(oCFD.NumCtaPago))
        End If

        textWriter.WriteStartElement(sPre & "Emisor")
        textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.eRFC))
        textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.eRazonSocial))
        textWriter.WriteStartElement(sPre & "DomicilioFiscal")
        textWriter.WriteAttributeString("calle", spaceFormat(oCFD.eCalle))
        textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.enoExterior))

        If oCFD.benoInterior Then
            textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.enoInterior))
        End If

        textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.eColonia))
        textWriter.WriteAttributeString("localidad", IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)))
        textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.eReferencia))
        textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.eMnpio))
        textWriter.WriteAttributeString("estado", spaceFormat(oCFD.eEntidad))
        textWriter.WriteAttributeString("pais", spaceFormat(oCFD.ePais))
        textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.eCodigoPostal))
        'Cierre de Domicilio
        textWriter.WriteEndElement()

        If oCFD.iTipoSucursal <> 1 Then
            textWriter.WriteStartElement(sPre & "ExpedidoEn")
            textWriter.WriteAttributeString("calle", spaceFormat(oCFD.sCalle))
            textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.snoExterior))

            If oCFD.bsnoInterior Then
                textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.snoInterior))
            End If

            textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.sColonia))
            textWriter.WriteAttributeString("localidad", IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)))
            textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.sReferencia))
            textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.sMnpio))
            textWriter.WriteAttributeString("estado", spaceFormat(oCFD.sEntidad))
            textWriter.WriteAttributeString("pais", spaceFormat(oCFD.sPais))
            textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.sCodigoPostal))
            'Cierre de centro de expedición
            textWriter.WriteEndElement()
        End If

        textWriter.WriteStartElement(sPre & "RegimenFiscal")
        textWriter.WriteAttributeString("Regimen", oCFD.regimenFiscal)
        textWriter.WriteEndElement()

        'Cierre de Emisor
        textWriter.WriteEndElement()

        textWriter.WriteStartElement(sPre & "Receptor")
        textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.RFC))
        textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.RazonSocial))
        textWriter.WriteStartElement(sPre & "Domicilio")
        textWriter.WriteAttributeString("calle", spaceFormat(oCFD.Calle))
        textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.noExterior))

        If oCFD.brnoInterior Then
            textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.noInterior))
        End If

        textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.Colonia))
        textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.Mnpio))
        textWriter.WriteAttributeString("estado", spaceFormat(oCFD.Entidad))
        textWriter.WriteAttributeString("pais", spaceFormat(oCFD.Pais))
        textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.codigoPostal))
        'Cierre de Domicilioi
        textWriter.WriteEndElement()
        'Cierre de Receptor
        textWriter.WriteEndElement()


        textWriter.WriteStartElement(sPre & "Conceptos")
        'Inicia for para llenar detalle
        Dim foundRows() As DataRow

        foundRows = dtConcepto.Select("RENClave = '" & oCFD.RENClave & "'")

        If foundRows.GetLength(0) > 0 Then
            For i = 0 To foundRows.GetUpperBound(0)
                textWriter.WriteStartElement(sPre & "Concepto")
                textWriter.WriteAttributeString("cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                textWriter.WriteAttributeString("unidad", foundRows(i)("Unidad"))
                textWriter.WriteAttributeString("noIdentificacion", foundRows(i)("Clave"))
                textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                textWriter.WriteAttributeString("valorUnitario", QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio))
                textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)))
                textWriter.WriteEndElement()

            Next
            'Fin de ciclo
        End If
        'Cierre de Conceptos
        textWriter.WriteEndElement()

        ' Write one more element
        textWriter.WriteStartElement(sPre & "Impuestos")
        textWriter.WriteAttributeString("totalImpuestosRetenidos", QuitarCeros(oCFD.impuestos))

        textWriter.WriteStartElement(sPre & "Retenciones")

        foundRows = dtImpuesto.Select("RENClave = '" & oCFD.RENClave & "'")

        'Inicio ciclo de impuestos
        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                textWriter.WriteStartElement(sPre & "Retencion")
                textWriter.WriteAttributeString("impuesto", foundRows(i)("Impuesto"))
                textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio))
                textWriter.WriteEndElement()
            Next
        End If
        'fin de ciclo de impuestos

        'Cierre de Traslados
        textWriter.WriteEndElement()
        'Cierre de Impuesto
        textWriter.WriteEndElement()

        'Complemento Nomina
        textWriter.WriteStartElement(sPre & "Complemento")
        textWriter.WriteStartElement("nomina:" & "Nomina")

        textWriter.WriteAttributeString("Version", "1.1")

        If oCFD.RegistroPatronal <> "" Then
            textWriter.WriteAttributeString("RegistroPatronal", oCFD.RegistroPatronal)
        End If

        textWriter.WriteAttributeString("NumEmpleado", oCFD.NumEmpleado)
        textWriter.WriteAttributeString("CURP", oCFD.CURP)
        textWriter.WriteAttributeString("TipoRegimen", oCFD.TipoRegimen)

        If oCFD.NumSeguridadSocial <> "" Then
            textWriter.WriteAttributeString("NumSeguridadSocial", oCFD.NumSeguridadSocial)
        End If
        textWriter.WriteAttributeString("FechaPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago))
        textWriter.WriteAttributeString("FechaInicialPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago))
        textWriter.WriteAttributeString("FechaFinalPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago))
        textWriter.WriteAttributeString("NumDiasPagados", oCFD.NumDiasPagados)

        If oCFD.Departamento <> "" Then
            textWriter.WriteAttributeString("Departamento", oCFD.Departamento)
        End If

        If oCFD.CLABE <> "" Then
            textWriter.WriteAttributeString("CLABE", oCFD.CLABE)
        End If

        If oCFD.Banco > 0 Then
            sTipoBanco = "00" & CStr(oCFD.Banco)
            textWriter.WriteAttributeString("Banco", sTipoBanco.Substring(sTipoBanco.Length - 3, 3))
        End If

        textWriter.WriteAttributeString("FechaInicioRelLaboral", oCFD.FechaInicioRelLaboral)

        If oCFD.Puesto <> "" Then
            textWriter.WriteAttributeString("Puesto", oCFD.Puesto)
        End If

        If oCFD.TipoContrato <> "" Then
            textWriter.WriteAttributeString("TipoContrato", oCFD.TipoContrato)
        End If

        If oCFD.TipoJornada <> "" Then
            textWriter.WriteAttributeString("TipoJornada", oCFD.TipoJornada)
        End If

        textWriter.WriteAttributeString("PeriodicidadPago", oCFD.PeriodicidadPago)

        If oCFD.SalarioBaseCotApor > 0 Then
            textWriter.WriteAttributeString("SalarioBaseCotApor", QuitarCeros(oCFD.SalarioBaseCotApor))
        End If

        If oCFD.RiesgoPuesto > 0 Then
            textWriter.WriteAttributeString("RiesgoPuesto", oCFD.RiesgoPuesto)
        End If

        If oCFD.SalarioDiarioIntegrado > 0 Then
            textWriter.WriteAttributeString("SalarioDiarioIntegrado", QuitarCeros(oCFD.SalarioDiarioIntegrado))
        End If

        Dim dtConceptos As DataTable


        dtConceptos = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", oCFD.RENClave)

        foundRows = dtConceptos.Select("Tipo = 1")

        If foundRows.GetLength(0) > 0 Then


            ' Percepciones  

            textWriter.WriteStartElement("nomina:" & "Percepciones")
            textWriter.WriteAttributeString("TotalGravado", QuitarCeros(oCFD.TotalGravadoP))
            textWriter.WriteAttributeString("TotalExento", QuitarCeros(oCFD.TotalExentoP))

            For i = 0 To foundRows.GetUpperBound(0)
                textWriter.WriteStartElement("nomina:" & "Percepcion")
                sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                textWriter.WriteAttributeString("TipoPercepcion", sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3))
                textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                textWriter.WriteAttributeString("ImporteGravado", QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio))
                textWriter.WriteAttributeString("ImporteExento", QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio))
                textWriter.WriteEndElement()
            Next
            'Cierre de Percepciones
            textWriter.WriteEndElement()

        End If

        foundRows = dtConceptos.Select("Tipo = 2")


        If foundRows.GetLength(0) > 0 Then
            ' Deducciones  

            textWriter.WriteStartElement("nomina:" & "Deducciones")
            textWriter.WriteAttributeString("TotalGravado", QuitarCeros(oCFD.TotalGravadoD))
            textWriter.WriteAttributeString("TotalExento", QuitarCeros(oCFD.TotalExentoD))


            For i = 0 To foundRows.GetUpperBound(0)
                textWriter.WriteStartElement("nomina:" & "Deduccion")
                sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                textWriter.WriteAttributeString("TipoDeduccion", sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3))
                textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                textWriter.WriteAttributeString("ImporteGravado", QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio))
                textWriter.WriteAttributeString("ImporteExento", QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio))
                textWriter.WriteEndElement()
            Next

            'Cierre de Deducciones
            textWriter.WriteEndElement()

        End If

        dtConceptos.Dispose()

        Dim dtIncapacidad As DataTable = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", oCFD.RENClave)
        ' Incapacidades


        If dtIncapacidad.Rows.Count() > 0 Then
            textWriter.WriteStartElement("nomina:" & "Incapacidades")

            For i = 0 To dtIncapacidad.Rows.Count() - 1
                textWriter.WriteStartElement("nomina:" & "Incapacidad")
                textWriter.WriteAttributeString("DiasIncapacidad", dtIncapacidad.Rows(i)("Dias"))
                textWriter.WriteAttributeString("TipoIncapacidad", dtIncapacidad.Rows(i)("TipoIncapacidad"))
                textWriter.WriteAttributeString("Descuento", QuitarCeros(dtIncapacidad.Rows(i)("Descuento")))
                textWriter.WriteEndElement()
            Next
            textWriter.WriteEndElement()

        End If

        dtIncapacidad.Dispose()

        Dim dtHorasExtra As DataTable = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", oCFD.RENClave)

        ' Horas Extra

        If dtHorasExtra.Rows.Count() > 0 Then
            textWriter.WriteStartElement("nomina:" & "HorasExtras")
            For i = 0 To dtHorasExtra.Rows.Count() - 1
                textWriter.WriteStartElement("nomina:" & "HorasExtra")
                textWriter.WriteAttributeString("Dias", dtHorasExtra.Rows(i)("Dias"))
                textWriter.WriteAttributeString("TipoHoras", dtHorasExtra.Rows(i)("Tipo"))
                textWriter.WriteAttributeString("HorasExtra", dtHorasExtra.Rows(i)("HorasExtra"))
                textWriter.WriteAttributeString("ImportePagado", QuitarCeros(dtHorasExtra.Rows(i)("ImportePagado")))
                textWriter.WriteEndElement()
            Next
            textWriter.WriteEndElement()

        End If

        dtHorasExtra.Dispose()
        'Cierre de Nomina
        textWriter.WriteEndElement()

        'Cierre de Complemento
        textWriter.WriteEndElement()

        'Cierre de Comprobante
        textWriter.WriteEndElement()
        ' Ends the document.
        textWriter.WriteEndDocument()
        ' close writer
        textWriter.Close()


        eRFC = oCFD.eRFC
        RFC = oCFD.RFC
        total = oCFD.total
        sello = oCFD.sello


        Dim oXml As New Xml.XmlDocument()
        oXml.Load(FileXML)

        Dim frmStatusMessage As New frmStatus

        For i = 0 To dtPAC.Rows.Count - 1


            If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                frmStatusMessage.BringToFront()

                Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                'https://pruebastfd.tralix.com:7070
                Try
                    oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                    If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                        '  actualizaEdoCFD(sTipoComprobante, sDOCClave, 2)
                        MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                        iTipoPAC = 0
                        fechaTimbrado = Date.Now
                    ElseIf Not oTimbre Is Nothing Then
                        UUID = oTimbre.UUID
                        SelloSAT = oTimbre.selloSAT
                        CertificadoSAT = oTimbre.noCertificadoSAT
                        fechaTimbrado = oTimbre.FechaTimbrado
                        VersionSAT = oTimbre.version
                        iTipoPAC = 1
                        ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                        ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                        Exit For
                    End If

                Catch ex As System.Net.WebException
                    MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                    iTipoPAC = 0
                    fechaTimbrado = Date.Now
                End Try
            ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                frmStatusMessage.BringToFront()

                Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                peticion.Method = "POST"
                peticion.ContentType = "application/x-www-form-urlencoded"
                peticion.ContentLength = content.Length

                Try
                    Dim requestStream As System.IO.Stream = peticion.GetRequestStream()
                    requestStream.Write(content, 0, content.Length)
                    requestStream.Close()

                    Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                    Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                    Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                    If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                        If respJson.Item("result").item("retcode").Value = 1 Then

                            UUID = respJson.Item("result").item("UUID").Value

                            Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                            For Each sElementos As String In Elementos
                                If sElementos.Contains("FechaTimbrado=") Then
                                    fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("noCertificadoSAT=") Then
                                    CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                End If
                                'If sElementos.Contains("selloCFD=") Then
                                '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                'End If
                                If sElementos.Contains("selloSAT=") Then
                                    SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("version=") Then
                                    VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                End If
                            Next
                            iTipoPAC = 2
                            'actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For

                        Else
                            frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                            ' Si ya fue timbrado entonces
                            Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                            UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                            UUID = UUID.Replace("UUID", "").Trim

                            consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                            Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                            Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                            peticion2.Method = "POST"
                            peticion2.ContentType = "application/x-www-form-urlencoded"
                            peticion2.ContentLength = content2.Length


                            Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                            requestStream2.Write(content2, 0, content2.Length)
                            requestStream2.Close()

                            Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                            Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                            Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                            Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                            Dim Elementos As Xml.XmlDocument = New Xml.XmlDocument()

                            Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                            Dim oXmlNodos As Xml.XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                            Dim o As Integer

                            For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                    Case Is = "FechaTimbrado"
                                        fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                    Case Is = "noCertificadoSAT"
                                        CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                    Case Is = "selloSAT"
                                        SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                    Case Is = "version"
                                        VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                End Select

                            Next

                            iTipoPAC = 2
                            'actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For


                        End If


                    ElseIf i = dtPAC.Rows.Count - 1 Then
                        'actualizaEdoCFD(sTipoComprobante, sDOCClave, 2)
                        MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                        fechaTimbrado = Date.Now
                        iTipoPAC = 0
                    End If
                Catch ex As System.Net.WebException
                    MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                    iTipoPAC = 0
                    fechaTimbrado = Date.Now
                End Try
            ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'MasterEdi

                frmStatusMessage.Show("Solicitado Timbre Fiscal...MasterEdi")
                frmStatusMessage.BringToFront()

                Dim strResultado As String

                Dim wsTimbre As WSTimbrado.TimbradoCFDServiceExternal

                'Se genera la instancia del servicio, que se agrego como referencia web desde el proyecto
                wsTimbre = New WSTimbrado.TimbradoCFDServiceExternal

                'Se utiliza el método TimbradoCFDStrXML, en donde se le pasa el xml como cadena de string, junto con el usuario y password
                'asignado por MasterEdi
                'El resultado es el XML timbrado en formato de string
                Try
                    strResultado = wsTimbre.TimbradoCFDStrXML(oXml.InnerXml, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("Customerkey"))

                    'Si el resultado se quiere pasar a formato XML se crea un nuevo objeto
                    Dim xmlTimbre As New Xml.XmlDocument
                    'Se carga el resultado XML con el Timbre
                    xmlTimbre.LoadXml(strResultado)

                    'Se busca si existo algun mensaje de error al generar el timbrado
                    Dim XmlNode As Xml.XmlNodeList
                    XmlNode = xmlTimbre.GetElementsByTagName("Mensaje", xmlTimbre.DocumentElement.NamespaceURI)
                    'Si existe entra a ver cual es el mensaje de error
                    If (XmlNode.Count > 0) Then
                        If i = dtPAC.Rows.Count - 1 Then
                            Dim strError As String = XmlNode(0).InnerText
                            'Si la variable strError esta vacía es que se genero el timbre sin problemas y regresa el tag del timbre Fiscal

                            'actualizaEdoCFD(sTipoComprobante, sDOCClave, 2)
                            MsgBox("Se tuvo el siguiente error [" + strError + "] ")
                            UUID = "NO_VALIDO_FOLIO_FISCAL"
                            SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                            fechaTimbrado = Date.Now
                            iTipoPAC = 0
                        End If
                    Else

                        Dim Elementos As String() = strResultado.Split()

                        For Each sElementos As String In Elementos
                            If sElementos.Contains("UUID=") Then
                                UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                            End If
                            If sElementos.Contains("FechaTimbrado=") Then
                                fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                            End If
                            If sElementos.Contains("noCertificadoSAT=") Then
                                CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                            End If

                            If sElementos.Contains("selloSAT=") Then
                                SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                            End If
                            If sElementos.Contains("version=") Then
                                VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                            End If
                        Next

                        iTipoPAC = 3
                        ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                        ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                        Exit For

                    End If
                Catch ex As System.Net.WebException
                    MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                    iTipoPAC = 0
                    fechaTimbrado = Date.Now
                End Try

            ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'DigitalInvoice

                frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                frmStatusMessage.BringToFront()

               
            End If

        Next

        ' Inicia Timbrado

        frmStatusMessage.Dispose()

        CBB = ModPOS.crearQR(eRFC, RFC, total, UUID)

        If iTipoPAC = 0 Then
            oXml.Save(FileXML)
        Else

            Dim newElem As Xml.XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

            Dim newEle1 As Xml.XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
            ' 1. Create a new Book element.


            Dim newAttr As Xml.XmlAttribute

            newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
            newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd"
            newEle1.Attributes.Append(newAttr)

            newAttr = oXml.CreateAttribute("selloCFD")
            newAttr.Value = sello
            newEle1.Attributes.Append(newAttr)

            newAttr = oXml.CreateAttribute("selloSAT")
            newAttr.Value = SelloSAT
            newEle1.Attributes.Append(newAttr)

            newAttr = oXml.CreateAttribute("UUID")
            newAttr.Value = UUID
            newEle1.Attributes.Append(newAttr)


            newAttr = oXml.CreateAttribute("FechaTimbrado")
            newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
            newEle1.Attributes.Append(newAttr)


            newAttr = oXml.CreateAttribute("version")
            newAttr.Value = VersionSAT
            newEle1.Attributes.Append(newAttr)

            newAttr = oXml.CreateAttribute("noCertificadoSAT")
            newAttr.Value = CertificadoSAT
            newEle1.Attributes.Append(newAttr)

            newElem.AppendChild(newEle1)
            oXml.DocumentElement.AppendChild(newElem)
            oXml.Save(FileXML)


            ' actualiza timbrado
            ModPOS.Ejecuta("sp_act_timbrado_nomina", "@RENClave", oCFD.RENClave, "@fechaRecibo", oCFD.Fecha, "@noCertificado", oCFD.noCertificado, "@TipoEstado", 1, "@Usuario", ModPOS.UsuarioActual)
            ModPOS.Ejecuta("sp_inserta_selloREC", "@RENClave", oCFD.RENClave, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC)

        End If


        'Verifica que exista el path
        If iTipoPAC <> 0 Then
            Try
                If System.IO.Directory.Exists(PathXML) Then
                    If System.IO.File.Exists(oFileXML) Then
                        If FileXML <> oFileXML Then
                            System.IO.File.Delete(oFileXML)
                        End If
                    End If
                    If FileXML <> oFileXML Then
                        System.IO.File.Copy(FileXML, oFileXML)
                    End If
                Else
                    MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
            End Try

        End If

        Return iTipoPAC

    End Function


    

    Public Function crearXML(ByVal TipoAccion As Integer, ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal sTipoComprobante As String, Optional ByVal oCFD As CFD = Nothing, Optional ByVal dtConcepto As DataTable = Nothing, Optional ByVal dtImpuesto As DataTable = Nothing, Optional ByVal iTipoComprobante As Integer = 0) As Integer
        Dim i As Integer
        Dim FileXML, oFileXML As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0
        Dim dIVA, dIEPS, dOtros As Double

        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim VersionSAT As String = ""

        Dim fechaTimbrado As Date
        Dim total As Double

        Dim CBB() As Byte = Nothing

        FileXML = pathActual & "CFD\" & sFolio & ".xml"


        If PathXML.Length <= 3 Then
            oFileXML = PathXML & sFolio & ".xml"
        ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
            oFileXML = PathXML & sFolio & ".xml"
        Else
            oFileXML = PathXML & "\" & sFolio & ".xml"
        End If


        If TipoAccion = 1 OrElse TipoAccion = 3 Then 'Crea por primera vez el XML o regenerar xml

            If oCFD.TipoCF = 2 Then
                sPre = "cfdi:"
            End If

            Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
            textWriter.Formatting = System.Xml.Formatting.None
            ' Opens the document
            textWriter.WriteStartDocument()

            ' Write comments

            'If oCFD.extra <> "" Then
            '    textWriter.WriteComment(oCFD.extra.Trim)
            'End If

            ' Write first element

            textWriter.WriteStartElement(sPre & "Comprobante")

            If oCFD.VersionCF = "2.0" OrElse oCFD.VersionCF = "2.2" Then
                textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
            ElseIf oCFD.VersionCF = "3.0" OrElse oCFD.VersionCF = "3.2" Then
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")

            End If

            textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

            Select Case oCFD.VersionCF
                Case Is = "2.0"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd")
                Case Is = "2.2"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd")
                Case Is = "3.0"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv3.xsd")
                Case Is = "3.2"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd")
            End Select

            textWriter.WriteAttributeString("version", oCFD.VersionCF)

            If oCFD.Serie <> "" Then
                textWriter.WriteAttributeString("serie", oCFD.Serie)
            End If

            textWriter.WriteAttributeString("folio", oCFD.Folio)
            textWriter.WriteAttributeString("fecha", oCFD.Fecha)
            textWriter.WriteAttributeString("sello", oCFD.sello)
            If oCFD.TipoCF = 1 Then
                textWriter.WriteAttributeString("noAprobacion", oCFD.noAprobacion)
                textWriter.WriteAttributeString("anoAprobacion", oCFD.anoAprobacion)
            End If
            textWriter.WriteAttributeString("formaDePago", oCFD.formaDePago)
            textWriter.WriteAttributeString("noCertificado", oCFD.noCertificado)
            textWriter.WriteAttributeString("certificado", oCFD.Certificado64)
            textWriter.WriteAttributeString("subTotal", oCFD.subtotal)
            textWriter.WriteAttributeString("descuento", QuitarCeros(oCFD.descuento))
            If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                textWriter.WriteAttributeString("TipoCambio", QuitarCeros(oCFD.TipoCambio))
                textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
            End If
            textWriter.WriteAttributeString("total", oCFD.total)
            textWriter.WriteAttributeString("tipoDeComprobante", oCFD.tipoDeComprobante)

            If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                textWriter.WriteAttributeString("metodoDePago", spaceFormat(oCFD.metodoDePago))
                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.LugarExpedicion))
                If oCFD.NumCtaPago <> "" Then
                    textWriter.WriteAttributeString("NumCtaPago", spaceFormat(oCFD.NumCtaPago))
                End If
            End If

            textWriter.WriteStartElement(sPre & "Emisor")
            textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.eRFC))
            textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.eRazonSocial))
            textWriter.WriteStartElement(sPre & "DomicilioFiscal")
            textWriter.WriteAttributeString("calle", spaceFormat(oCFD.eCalle))
            textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.enoExterior))

            If oCFD.benoInterior Then
                textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.enoInterior))
            End If

            textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.eColonia))
            textWriter.WriteAttributeString("localidad", IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)))
            textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.eReferencia))
            textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.eMnpio))
            textWriter.WriteAttributeString("estado", spaceFormat(oCFD.eEntidad))
            textWriter.WriteAttributeString("pais", spaceFormat(oCFD.ePais))
            textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.eCodigoPostal))
            'Cierre de Domicilio
            textWriter.WriteEndElement()

            If oCFD.iTipoSucursal <> 1 Then
                textWriter.WriteStartElement(sPre & "ExpedidoEn")
                textWriter.WriteAttributeString("calle", spaceFormat(oCFD.sCalle))
                textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.snoExterior))

                If oCFD.bsnoInterior Then
                    textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.snoInterior))
                End If

                textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.sColonia))
                textWriter.WriteAttributeString("localidad", IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)))
                textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.sReferencia))
                textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.sMnpio))
                textWriter.WriteAttributeString("estado", spaceFormat(oCFD.sEntidad))
                textWriter.WriteAttributeString("pais", spaceFormat(oCFD.sPais))
                textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.sCodigoPostal))
                'Cierre de centro de expedición
                textWriter.WriteEndElement()
            End If

            If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                textWriter.WriteStartElement(sPre & "RegimenFiscal")
                textWriter.WriteAttributeString("Regimen", oCFD.regimenFiscal)
                textWriter.WriteEndElement()
            End If

            'Cierre de Emisor
            textWriter.WriteEndElement()

            textWriter.WriteStartElement(sPre & "Receptor")
            textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.RFC))
            textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.RazonSocial))
            textWriter.WriteStartElement(sPre & "Domicilio")
            textWriter.WriteAttributeString("calle", spaceFormat(oCFD.Calle))
            textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.noExterior))

            If oCFD.brnoInterior Then
                textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.noInterior))
            End If

            textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.Colonia))
            textWriter.WriteAttributeString("localidad", IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)))
            textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.Referencia))
            textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.Mnpio))
            textWriter.WriteAttributeString("estado", spaceFormat(oCFD.Entidad))
            textWriter.WriteAttributeString("pais", spaceFormat(oCFD.Pais))
            textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.codigoPostal))
            'Cierre de Domicilioi
            textWriter.WriteEndElement()
            'Cierre de Receptor
            textWriter.WriteEndElement()


            textWriter.WriteStartElement(sPre & "Conceptos")
            'Inicia for para llenar detalle
            Dim foundRows() As DataRow

            Select Case iTipoComprobante
                Case Is = 1
                    foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Case Is = 6
                    foundRows = dtConcepto.Select("CARClave = '" & oCFD.DOCClave & "'")
                Case Is = 7
                    foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                Case Else
                    If oCFD.tipoDeComprobante = "ingreso" Then
                        foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                    Else
                        foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                    End If
            End Select
            
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)
                    textWriter.WriteStartElement(sPre & "Concepto")
                    textWriter.WriteAttributeString("cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                    textWriter.WriteAttributeString("unidad", foundRows(i)("Unidad"))
                    If foundRows(i)("Clave") <> "NotaCargo" Then
                        textWriter.WriteAttributeString("noIdentificacion", foundRows(i)("Clave"))
                    End If
                    textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                    textWriter.WriteAttributeString("valorUnitario", QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio))
                    textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)))
                    textWriter.WriteEndElement()
                Next
                'Fin de ciclo
            End If
            'Cierre de Conceptos
            textWriter.WriteEndElement()

            ' Write one more element
            textWriter.WriteStartElement(sPre & "Impuestos")
            textWriter.WriteAttributeString("totalImpuestosTrasladados", QuitarCeros(oCFD.impuestos))

            textWriter.WriteStartElement(sPre & "Traslados")

            Select Case iTipoComprobante
                Case Is = 1
                    foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Case Is = 6
                    foundRows = dtImpuesto.Select("CARClave = '" & oCFD.DOCClave & "'")
                Case Is = 7
                    foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                Case Else
                    If oCFD.tipoDeComprobante = "ingreso" Then
                        foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                    Else
                        foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                    End If
            End Select

            'Inicio ciclo de impuestos
            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    textWriter.WriteStartElement(sPre & "Traslado")
                    textWriter.WriteAttributeString("impuesto", foundRows(i)("Impuesto"))
                    textWriter.WriteAttributeString("tasa", QuitarCeros(foundRows(i)("Tasa") * 100))
                    textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio))
                    textWriter.WriteEndElement()

                    If oCFD.tieneAddenda = True Then
                        If foundRows(i)("Impuesto") = "IVA" Then
                            dIVA = +foundRows(i)("Importe") / oCFD.TipoCambio
                        ElseIf foundRows(i)("Impuesto") = "IEPS" Then
                            dIEPS = +foundRows(i)("Importe") / oCFD.TipoCambio
                        Else
                            dOtros = +foundRows(i)("Importe") / oCFD.TipoCambio
                        End If
                    End If
                Next

            End If
            'fin de ciclo de impuestos

            'Cierre de Traslados
            textWriter.WriteEndElement()
            'Cierre de Impuesto
            textWriter.WriteEndElement()

            If oCFD.tieneAddenda = True AndAlso iTipoComprobante <> 6 Then
                If oCFD.Tipo = 1 Then

                    Dim iMoneda As Integer

                    Select Case oCFD.Moneda
                        Case Is = "MXN"
                            iMoneda = 1
                        Case Is = "USD"
                            iMoneda = 2
                        Case Is = "EUR"
                            iMoneda = 3
                    End Select

                    textWriter.WriteStartElement(sPre & "Addenda")
                    textWriter.WriteStartElement("DSCargaRemisionProv")
                    If oCFD.VersionCF = "2.0" OrElse oCFD.VersionCF = "2.2" Then
                        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
                    ElseIf oCFD.VersionCF = "3.0" OrElse oCFD.VersionCF = "3.2" Then
                        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/3")
                    End If

                    textWriter.WriteStartElement("Remision")
                    textWriter.WriteAttributeString("Id", oCFD.Serie & oCFD.Folio)
                    textWriter.WriteAttributeString("RowOrder", 1)
                    textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                    textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                    textWriter.WriteElementString("FechaRemision", oCFD.Fecha)
                    textWriter.WriteElementString("Tienda", oCFD.GLN)
                    textWriter.WriteElementString("TipoMoneda", iMoneda)
                    textWriter.WriteElementString("TipoBulto", 2)
                    textWriter.WriteElementString("EntregaMercancia", 1)
                    textWriter.WriteElementString("CumpleReqFiscales", True)
                    textWriter.WriteElementString("CantidadBultos", oCFD.CantBultos)
                    textWriter.WriteElementString("Subtotal", oCFD.subtotal)
                    textWriter.WriteElementString("Descuentos", oCFD.descuento)
                    textWriter.WriteElementString("IEPS", dIEPS)
                    textWriter.WriteElementString("IVA", dIVA)
                    textWriter.WriteElementString("OtrosImpuestos", dOtros)
                    textWriter.WriteElementString("Total", oCFD.total)
                    textWriter.WriteElementString("CantidadPedidos", oCFD.CantPedidos)
                    textWriter.WriteElementString("FechaEntregaMercancia", oCFD.FechaEntrega)
                    textWriter.WriteElementString("Cita", oCFD.NoCita)
                    textWriter.WriteElementString("FolioNotaEntrada", oCFD.NotaEntrada)
                    'Cierre de Remision
                    textWriter.WriteEndElement()

                    ModPOS.Ejecuta("sp_upd_complemento", _
                                           "@FACClave", oCFD.FACClave, _
                                           "@TipoAddenda", oCFD.Tipo, _
                                           "@FechaEntrega", oCFD.FechaEntrega, _
                                           "@NotaEntrada", oCFD.NotaEntrada, _
                                           "@Cita", oCFD.NoCita, _
                                           "@IVA", dIVA, _
                                           "@IEPS", dIEPS, _
                                           "@Otros", dOtros, _
                                           "@CantidadPedidos", oCFD.CantPedidos, _
                                           "@CantidadBultos", oCFD.CantBultos)


                    Dim dtPedidos, dtArticulos As DataTable

                    Dim x As Integer

                    dtPedidos = ModPOS.SiExisteRecupera("sp_recupera_pedidos", "@FACClave", oCFD.FACClave)

                    If Not dtPedidos Is Nothing Then
                        For i = 0 To dtPedidos.Rows.Count - 1

                            textWriter.WriteStartElement("Pedidos")
                            textWriter.WriteAttributeString("Id", dtPedidos.Rows(i)("Folio"))
                            textWriter.WriteAttributeString("RowOrder", i + 1)
                            textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                            textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                            textWriter.WriteElementString("FolioPedido", dtPedidos.Rows(i)("Folio"))
                            textWriter.WriteElementString("Tienda", oCFD.GLN)
                            textWriter.WriteElementString("CantidadArticulos", dtPedidos.Rows(i)("Cantidad"))
                            textWriter.WriteElementString("PedidoEmitidoProveedor", "No")
                            'Cierre de Pedidos
                            textWriter.WriteEndElement()


                            dtArticulos = ModPOS.SiExisteRecupera("sp_recupera_articulos", "@VENClave", dtPedidos.Rows(i)("VENClave"))

                            If Not dtArticulos Is Nothing Then
                                For x = 0 To dtArticulos.Rows.Count - 1

                                    textWriter.WriteStartElement("Articulos")
                                    textWriter.WriteAttributeString("Id", dtArticulos.Rows(x)("GTIN"))
                                    textWriter.WriteAttributeString("RowOrder", x + 1)

                                    textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                                    textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                                    textWriter.WriteElementString("FolioPedido", dtArticulos.Rows(x)("Folio"))
                                    textWriter.WriteElementString("Tienda", oCFD.GLN)

                                    textWriter.WriteElementString("Codigo", dtArticulos.Rows(x)("GTIN"))
                                    textWriter.WriteElementString("CantidadUnidadCompra", dtArticulos.Rows(x)("Cantidad"))

                                    textWriter.WriteElementString("CostoNetoUnidadCompra", dtArticulos.Rows(x)("Subtotal"))

                                    textWriter.WriteElementString("PorcentajeIEPS", IIf(dtArticulos.Rows(x)("IEPS").GetType.Name = "DBNull", 0, dtArticulos.Rows(x)("IEPS")))
                                    textWriter.WriteElementString("PorcentajeIVA", IIf(dtArticulos.Rows(x)("IVA").GetType.Name = "DBNull", 0, dtArticulos.Rows(x)("IVA")))

                                    'Cierre de articulos
                                    textWriter.WriteEndElement()
                                Next
                            End If
                        Next
                    End If

                    'Cierre de DSCargaRemisionProv
                    textWriter.WriteEndElement()
                    'Cierre de Addenda
                    textWriter.WriteEndElement()
                End If
            End If


            'Cierre de Comprobante
            textWriter.WriteEndElement()
            ' Ends the document.
            textWriter.WriteEndDocument()
            ' close writer
            textWriter.Close()


            eRFC = oCFD.eRFC
            RFC = oCFD.RFC
            total = oCFD.total
            sello = oCFD.sello

        End If 'Finaliza Creacion del XML

        If TipoAccion = 2 Then ' Si es un reintento de timbrado
            If Not System.IO.File.Exists(FileXML) Then
                If System.IO.File.Exists(oFileXML) Then
                    System.IO.File.Copy(oFileXML, FileXML)
                Else
                    MessageBox.Show("El archivo " & PathXML & "\" & sFolio & ".xml no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                End If
            End If

            Dim dt As DataTable

            If sTipoComprobante = "ingreso" Then
                If iTipoComprobante = 6 Then
                    dt = ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sDOCClave)
                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                    dt.Dispose()

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sDOCClave)
                    eRFC = dt.Rows(0)("cRFC")
                    RFC = dt.Rows(0)("id_Fiscal")
                    total = dt.Rows(0)("Total")
                Else
                    dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sDOCClave)
                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                    dt.Dispose()

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sDOCClave)
                    eRFC = dt.Rows(0)("cRFC")
                    RFC = dt.Rows(0)("id_Fiscal")
                    total = dt.Rows(0)("Total")
                End If
                dt.Dispose()
            Else

                dt = ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", sDOCClave)
                sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                dt.Dispose()

                dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sDOCClave)
                eRFC = dt.Rows(0)("cRFC")
                RFC = dt.Rows(0)("id_Fiscal")
                total = dt.Rows(0)("Total")
                dt.Dispose()


            End If

        End If ' Finaliza reintento 

        If TipoAccion <> 3 Then
            If TipoAccion = 2 OrElse oCFD.TipoCF = 2 Then ' Inicia timbrado


                Dim oXml As New Xml.XmlDocument()
                oXml.Load(FileXML)

                Dim frmStatusMessage As New frmStatus

                For i = 0 To dtPAC.Rows.Count - 1
                    If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                        frmStatusMessage.BringToFront()

                        Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                        'https://pruebastfd.tralix.com:7070
                        Try
                            oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                            If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                iTipoPAC = 0
                                fechaTimbrado = Date.Now
                            ElseIf Not oTimbre Is Nothing Then
                                UUID = oTimbre.UUID
                                SelloSAT = oTimbre.selloSAT
                                CertificadoSAT = oTimbre.noCertificadoSAT
                                fechaTimbrado = oTimbre.FechaTimbrado
                                VersionSAT = oTimbre.version
                                iTipoPAC = 1
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For
                            End If

                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                        frmStatusMessage.BringToFront()

                        Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                        Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion.Method = "POST"
                        peticion.ContentType = "application/x-www-form-urlencoded"
                        peticion.ContentLength = content.Length

                        Try
                            Dim requestStream As System.IO.Stream = peticion.GetRequestStream()

                            requestStream.Write(content, 0, content.Length)
                            requestStream.Close()

                            Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                            Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                            Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                            If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                                If respJson.Item("result").item("retcode").Value = 1 Then
                                    UUID = respJson.Item("result").item("UUID").Value

                                    Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If
                                        'If sElementos.Contains("selloCFD=") Then
                                        '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                        'End If
                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    iTipoPAC = 2
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                    ' Si ya fue timbrado entonces
                                    Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                    UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                    UUID = UUID.Replace("UUID", "").Trim

                                    consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                    peticion2.Method = "POST"
                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                    peticion2.ContentLength = content2.Length


                                    Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                    requestStream2.Write(content2, 0, content2.Length)
                                    requestStream2.Close()

                                    Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                    Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As Xml.XmlDocument = New Xml.XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                    Dim oXmlNodos As Xml.XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                    Dim o As Integer

                                    For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                        Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                            Case Is = "FechaTimbrado"
                                                fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "noCertificadoSAT"
                                                CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "selloSAT"
                                                SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "version"
                                                VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                        End Select

                                    Next
                                 
                                    iTipoPAC = 2
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For


                                End If
                            ElseIf i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'MasterEdi

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...MasterEdi")
                        frmStatusMessage.BringToFront()

                        Dim strResultado As String

                        Dim wsTimbre As WSTimbrado.TimbradoCFDServiceExternal

                        'Se genera la instancia del servicio, que se agrego como referencia web desde el proyecto
                        wsTimbre = New WSTimbrado.TimbradoCFDServiceExternal

                        'Se utiliza el método TimbradoCFDStrXML, en donde se le pasa el xml como cadena de string, junto con el usuario y password
                        'asignado por MasterEdi
                        'El resultado es el XML timbrado en formato de string
                        Try
                            strResultado = wsTimbre.TimbradoCFDStrXML(oXml.InnerXml, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("Customerkey"))

                            'Si el resultado se quiere pasar a formato XML se crea un nuevo objeto
                            Dim xmlTimbre As New Xml.XmlDocument
                            'Se carga el resultado XML con el Timbre
                            xmlTimbre.LoadXml(strResultado)

                            'Se busca si existo algun mensaje de error al generar el timbrado
                            Dim XmlNode As Xml.XmlNodeList
                            XmlNode = xmlTimbre.GetElementsByTagName("Mensaje", xmlTimbre.DocumentElement.NamespaceURI)
                            'Si existe entra a ver cual es el mensaje de error
                            If (XmlNode.Count > 0) Then
                                If i = dtPAC.Rows.Count - 1 Then
                                    Dim strError As String = XmlNode(0).InnerText
                                    'Si la variable strError esta vacía es que se genero el timbre sin problemas y regresa el tag del timbre Fiscal

                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                    MsgBox("Se tuvo el siguiente error [" + strError + "] ")
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                End If
                            Else

                                Dim Elementos As String() = strResultado.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next

                                iTipoPAC = 3
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión de internet] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If
                        End Try
                    ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'DigitalInvoice

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                        frmStatusMessage.BringToFront()



                    End If
                Next


                ' Area comun de timbrado

                frmStatusMessage.Dispose()

                CBB = ModPOS.crearQR(eRFC, RFC, total, UUID)

                If iTipoPAC = 0 Then
                    oXml.Save(FileXML)
                Else
                    Dim newElem As Xml.XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

                    Dim newEle1 As Xml.XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
                    ' 1. Create a new Book element.


                    Dim newAttr As Xml.XmlAttribute

                    newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                    newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd"
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("selloCFD")
                    newAttr.Value = sello
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("selloSAT")
                    newAttr.Value = SelloSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("UUID")
                    newAttr.Value = UUID
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("FechaTimbrado")
                    newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("version")
                    newAttr.Value = VersionSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("noCertificadoSAT")
                    newAttr.Value = CertificadoSAT
                    newEle1.Attributes.Append(newAttr)

                    newElem.AppendChild(newEle1)
                    oXml.DocumentElement.AppendChild(newElem)
                    oXml.Save(FileXML)

                End If
            End If
        End If

        If TipoAccion = 1 Then
            If iTipoPAC = 0 Then
                fechaTimbrado = CDate(oCFD.Fecha)
            End If

            If sTipoComprobante = "ingreso" Then
                If iTipoComprobante = 6 Then
                    ModPOS.Ejecuta("sp_inserta_sellocargo", "@CARClave", sDOCClave, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC)
                Else
                    ModPOS.Ejecuta("sp_inserta_sello", "@FACClave", sDOCClave, "@noAprobacion", oCFD.noAprobacion, "@anoAprobacion", oCFD.anoAprobacion, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC)
                End If
            Else
                ModPOS.Ejecuta("sp_inserta_sellonc", "@NCClave", sDOCClave, "@noAprobacion", oCFD.noAprobacion, "@anoAprobacion", oCFD.anoAprobacion, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC)
            End If

        ElseIf TipoAccion = 2 Then
            ModPOS.Ejecuta("sp_actualiza_timbrado", "@Tipo", sTipoComprobante, "@DOCClave", sDOCClave, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@TipoComprobante", iTipoComprobante)
        ElseIf TipoAccion = 3 Then
            ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", sTipoComprobante, "@DOCClave", sDOCClave, "@CBB", CBB, "@TipoComprobante", iTipoComprobante)
        End If

        'Verifica que exista el path
        Try
            If System.IO.Directory.Exists(PathXML) Then
                If System.IO.File.Exists(oFileXML) Then
                    If FileXML <> oFileXML Then
                        System.IO.File.Delete(oFileXML)
                    End If
                End If
                If FileXML <> oFileXML Then
                    System.IO.File.Copy(FileXML, oFileXML)
                End If
            Else
                MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try


        Return iTipoPAC

    End Function

    Public Function ObtenerConsultaiTimbre(ByVal Id As String, ByVal RFC As String, ByVal User As String, ByVal Pass As String, ByVal RutaXML As String) As String
        Dim lector As System.IO.StreamReader = New System.IO.StreamReader(RutaXML)
        Dim xml As Object = lector.ReadToEnd()
        lector.Close()

        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("method", "cfd2cfdi"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("xmldata", xml))))

        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())

        My.Computer.FileSystem.DeleteFile(RutaXML)

        Return consulta
    End Function

    Public Function BuscarCFDiTimbre(ByVal User As String, ByVal Pass As String, ByVal RFC As String, ByVal Id As String, ByVal UUID As String) As String
        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("method", "buscarCFDI"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("UUID", UUID))))
        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())
        Return consulta
    End Function

    Public Function CancelarFacturaiTimbre(ByVal Id As String, ByVal RFC As String, ByVal User As String, ByVal Pass As String, ByVal UUID As Array, ByVal pfx_pass As String, ByVal pfx_pem As String, ByVal ServidorTimbre As String) As String
        Dim sResult As String = ""
        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("method", "cancelarCFDI"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("pfx_pass", pfx_pass), New Newtonsoft.Json.Linq.JProperty("pfx_pem", pfx_pem), New Newtonsoft.Json.Linq.JProperty("folios", UUID))))

        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())

        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

        Dim url As String = ServidorTimbre
        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

        peticion.Method = "POST"
        peticion.ContentType = "application/x-www-form-urlencoded"
        peticion.ContentLength = content.Length

        Dim requestStream As System.IO.Stream = peticion.GetRequestStream()
        requestStream.Write(content, 0, content.Length)
        requestStream.Close()

        Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
        Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

        Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

        If respJson.Item("result").item("retcode").Value <> 1 Then
            sResult = "Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "], " + respJson.Item("result").Item("error").Value.ToString()
        End If
        Return sResult
    End Function

    Public Function generarCadenaOriginal(ByVal oCFD As CFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoConcepto As String = ""

        Dim foundRows() As DataRow

        If oCFD.tipoDeComprobante = "ingreso" Then
            foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
        Else
            foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
        End If

        If foundRows.GetLength(0) > 0 Then


            Dim dSubtotal As Double = 0
            Dim dTotal As Double = 0

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)) & "|"
                dSubtotal += foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)
            Next
            oCFD.subtotal = QuitarCeros(dSubtotal)
        End If


        Dim sNodoImpuestosTrasladado As String = ""


        If oCFD.tipoDeComprobante = "ingreso" Then
            foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
        Else
            foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
        End If

        oCFD.impuestos = 0

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & foundRows(i)("Impuesto")
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(foundRows(i)("Tasa") * 100)
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio) & "|"
                oCFD.impuestos += foundRows(i)("Importe") / oCFD.TipoCambio
            Next
        End If

        oCFD.total = QuitarCeros(CDbl(oCFD.subtotal) - (oCFD.descuento / oCFD.TipoCambio) + oCFD.impuestos)

        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & QuitarCeros(oCFD.impuestos) & "||"

        Dim sNodoEncabezado As String = "||" & oCFD.VersionCF & "|" & IIf(oCFD.TipoCF = 2, "", IIf(oCFD.Serie = "", "", oCFD.Serie & "|") & oCFD.Folio & "|") & oCFD.Fecha & "|" & IIf(oCFD.TipoCF = 2, "", oCFD.noAprobacion & "|" & oCFD.anoAprobacion & "|") & oCFD.tipoDeComprobante & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(QuitarCeros(oCFD.descuento)) & "|" & oCFD.total & "|"

        Dim sNodoRegimenFiscal As String = ""

        If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

            sNodoEncabezado &= spaceFormat(oCFD.metodoDePago) & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "") & QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|"

            sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

        End If

        Dim sNodoEmisor As String = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & oCFD.enoExterior & IIf(oCFD.benoInterior, "|" & oCFD.enoInterior, "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & oCFD.eMnpio & "|" & oCFD.eEntidad & "|" & oCFD.ePais & "|" & oCFD.eCodigoPostal & "|"
        Dim sNodoExpedicion As String = spaceFormat(oCFD.sCalle) & "|" & oCFD.snoExterior & IIf(oCFD.bsnoInterior, "|" & oCFD.snoInterior, "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & oCFD.sMnpio & "|" & oCFD.sEntidad & "|" & oCFD.sPais & "|" & oCFD.sCodigoPostal & "|"
        Dim sNodoReceptor As String = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & oCFD.noExterior & IIf(oCFD.brnoInterior, "|" & oCFD.noInterior, "") & "|" & oCFD.Colonia & "|" & IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)) & "|" & IIf(oCFD.Referencia = "", "SIN REFERENCIA", spaceFormat(oCFD.Referencia)) & "|" & oCFD.Mnpio & "|" & oCFD.Entidad & "|" & oCFD.Pais & "|" & oCFD.codigoPostal & "|"

        If oCFD.iTipoSucursal = 1 Then
            sNodoExpedicion = ""
        End If

        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosTrasladado


        Return sCadenaOriginal

    End Function

    Public Function generarCadenaOriginalCFDI(ByVal oCFD As CFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable, ByVal TipoComprobante As Integer) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoConcepto As String = ""

        Dim foundRows() As DataRow


        Select Case TipoComprobante
            Case Is = 1 'Factura
                foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
            Case Is = 6 ' Nota de Cargo
                foundRows = dtConcepto.Select("CARClave = '" & oCFD.DOCClave & "'")
            Case Is = 7 ' Nota de Credito
                foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
            Case Else
                If oCFD.tipoDeComprobante = "ingreso" Then
                    foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Else
                    foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                End If
        End Select

        If foundRows.GetLength(0) > 0 Then

            Dim dSubtotal As Double = 0
            Dim dTotal As Double = 0

            For i = 0 To foundRows.GetUpperBound(0)
                If foundRows(i)("Clave") = "NotaCargo" Then
                    sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)) & "|"
                Else
                    sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)) & "|"
                End If
                dSubtotal += foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)
            Next
            oCFD.subtotal = QuitarCeros(dSubtotal)
        End If


        Dim sNodoImpuestosTrasladado As String = ""



        Select Case TipoComprobante
            Case Is = 1 'Factura
                foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
            Case Is = 6 ' Nota de Cargo
                foundRows = dtImpuesto.Select("CARClave = '" & oCFD.DOCClave & "'")
            Case Is = 7 ' Nota de Credito
                foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
            Case Else
                If oCFD.tipoDeComprobante = "ingreso" Then
                    foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Else
                    foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                End If
        End Select

        oCFD.impuestos = 0

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & foundRows(i)("Impuesto")
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(foundRows(i)("Tasa") * 100)
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio) & "|"
                oCFD.impuestos += foundRows(i)("Importe") / oCFD.TipoCambio
            Next
        End If

        oCFD.total = QuitarCeros(CDbl(oCFD.subtotal) - (oCFD.descuento / oCFD.TipoCambio) + oCFD.impuestos)

        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & QuitarCeros(oCFD.impuestos) & "||"

        Dim sNodoEncabezado As String = "||" & oCFD.VersionCF & "|" & oCFD.Fecha & "|" & oCFD.tipoDeComprobante & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(QuitarCeros(oCFD.descuento)) & "|" & IIf(oCFD.TipoCF = 2, QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|", "") & oCFD.total & "|"

        Dim sNodoRegimenFiscal As String = ""

        If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

            sNodoEncabezado &= spaceFormat(oCFD.metodoDePago) & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "")

            sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

        End If

        Dim sNodoEmisor As String = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & spaceFormat(oCFD.enoExterior) & IIf(oCFD.benoInterior, "|" & spaceFormat(oCFD.enoInterior), "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & spaceFormat(oCFD.eMnpio) & "|" & spaceFormat(oCFD.eEntidad) & "|" & spaceFormat(oCFD.ePais) & "|" & spaceFormat(oCFD.eCodigoPostal) & "|"
        Dim sNodoExpedicion As String = spaceFormat(oCFD.sCalle) & "|" & spaceFormat(oCFD.snoExterior) & IIf(oCFD.bsnoInterior, "|" & spaceFormat(oCFD.snoInterior), "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & spaceFormat(oCFD.sMnpio) & "|" & spaceFormat(oCFD.sEntidad) & "|" & spaceFormat(oCFD.sPais) & "|" & spaceFormat(oCFD.sCodigoPostal) & "|"
        Dim sNodoReceptor As String = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & spaceFormat(oCFD.noExterior) & IIf(oCFD.brnoInterior, "|" & spaceFormat(oCFD.noInterior), "") & "|" & spaceFormat(oCFD.Colonia) & "|" & IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)) & "|" & IIf(oCFD.Referencia = "", "SIN REFERENCIA", spaceFormat(oCFD.Referencia)) & "|" & spaceFormat(oCFD.Mnpio) & "|" & spaceFormat(oCFD.Entidad) & "|" & spaceFormat(oCFD.Pais) & "|" & spaceFormat(oCFD.codigoPostal) & "|"

        If oCFD.iTipoSucursal = 1 Then
            sNodoExpedicion = ""
        End If

        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosTrasladado


        Return sCadenaOriginal

    End Function

    Public Function generaCadenaOriginalComplemento(ByVal oCFD As eCFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable) As String
        'Complemento Nomina

        Dim sCadenaOriginal As String

        sCadenaOriginal = "1.1|"

        If oCFD.RegistroPatronal <> "" Then
            sCadenaOriginal &= oCFD.RegistroPatronal & "|"
        End If

        sCadenaOriginal &= oCFD.NumEmpleado & "|"
        sCadenaOriginal &= oCFD.CURP & "|"
        sCadenaOriginal &= CStr(oCFD.TipoRegimen) & "|"

        If oCFD.NumSeguridadSocial <> "" Then
            sCadenaOriginal &= oCFD.NumSeguridadSocial & "|"
        End If

        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago) & "|"
        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago) & "|"
        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago) & "|"
        sCadenaOriginal &= CStr(oCFD.NumDiasPagados) & "|"

        If oCFD.Departamento <> "" Then
            sCadenaOriginal &= oCFD.Departamento & "|"
        End If

        If oCFD.CLABE <> "" Then
            sCadenaOriginal &= oCFD.CLABE & "|"
        End If

        If oCFD.Banco > 0 Then
            Dim sTipoBanco As String = "00" & CStr(oCFD.Banco)
            sCadenaOriginal &= sTipoBanco.Substring(sTipoBanco.Length - 3, 3) & "|"
        End If
        'op
        sCadenaOriginal &= oCFD.FechaInicioRelLaboral & "|"

        If oCFD.Puesto <> "" Then
            sCadenaOriginal &= oCFD.Puesto & "|"
        End If

        If oCFD.TipoContrato <> "" Then
            sCadenaOriginal &= oCFD.TipoContrato & "|"
        End If

        If oCFD.TipoJornada <> "" Then
            sCadenaOriginal &= oCFD.TipoJornada & "|"
        End If

        sCadenaOriginal &= oCFD.PeriodicidadPago & "|"

        If oCFD.SalarioBaseCotApor > 0 Then
            sCadenaOriginal &= QuitarCeros(oCFD.SalarioBaseCotApor) & "|"
        End If

        If oCFD.RiesgoPuesto > 0 Then
            sCadenaOriginal &= CStr(oCFD.RiesgoPuesto) & "|"
        End If

        If oCFD.SalarioDiarioIntegrado > 0 Then
            sCadenaOriginal &= QuitarCeros(oCFD.SalarioDiarioIntegrado) & "|"
        End If

        Dim dtConceptos As DataTable
        Dim foundRows() As DataRow
        Dim i As Integer
        Dim sTipoPercepcion, sTipoDeduccion As String

        dtConceptos = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", oCFD.RENClave)

        foundRows = dtConceptos.Select("Tipo = 1")

        If foundRows.GetLength(0) > 0 Then


            ' Percepciones  

            sCadenaOriginal &= QuitarCeros(oCFD.TotalGravadoP) & "|"
            sCadenaOriginal &= QuitarCeros(oCFD.TotalExentoP) & "|"

            For i = 0 To foundRows.GetUpperBound(0)

                sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                sCadenaOriginal &= sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3) & "|"

                sCadenaOriginal &= foundRows(i)("Clave") & "|"
                sCadenaOriginal &= foundRows(i)("Concepto") & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio) & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio) & "|"

            Next
            'Cierre de Percepciones

        End If

        foundRows = dtConceptos.Select("Tipo = 2")


        If foundRows.GetLength(0) > 0 Then
            ' Deducciones  

            sCadenaOriginal &= QuitarCeros(oCFD.TotalGravadoD) & "|"
            sCadenaOriginal &= QuitarCeros(oCFD.TotalExentoD) & "|"


            For i = 0 To foundRows.GetUpperBound(0)

                sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                sCadenaOriginal &= sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3) & "|"
                sCadenaOriginal &= foundRows(i)("Clave") & "|"
                sCadenaOriginal &= foundRows(i)("Concepto") & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio) & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio) & "|"

            Next

            'Cierre de Deducciones


        End If

        dtConceptos.Dispose()

        Dim dtIncapacidad As DataTable = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", oCFD.RENClave)
        ' Incapacidades


        If dtIncapacidad.Rows.Count() > 0 Then

            For i = 0 To dtIncapacidad.Rows.Count() - 1

                sCadenaOriginal &= CStr(dtIncapacidad.Rows(i)("Dias")) & "|"
                sCadenaOriginal &= CStr(dtIncapacidad.Rows(i)("TipoIncapacidad")) & "|"
                sCadenaOriginal &= QuitarCeros(dtIncapacidad.Rows(i)("Descuento")) & "|"
            Next

        End If

        dtIncapacidad.Dispose()

        Dim dtHorasExtra As DataTable = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", oCFD.RENClave)

        ' Horas Extra

        If dtHorasExtra.Rows.Count() > 0 Then
            For i = 0 To dtHorasExtra.Rows.Count() - 1
                sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("Dias")) & "|"
                sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("Tipo")) & "|"
                sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("HorasExtra")) & "|"
                sCadenaOriginal &= QuitarCeros(dtHorasExtra.Rows(i)("ImportePagado")) & "|"
            Next

        End If

        dtHorasExtra.Dispose()


        Return sCadenaOriginal & "|"

    End Function

    Public Function generarCadenaOriginalNomina(ByVal oCFD As eCFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoConcepto As String = ""

        Dim foundRows() As DataRow

        foundRows = dtConcepto.Select("RENClave = '" & oCFD.RENClave & "'")
      
        If foundRows.GetLength(0) > 0 Then
            Dim dSubtotal As Double = 0
            Dim dTotal As Double = 0

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)) & "|"
                dSubtotal += foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)
            Next
            oCFD.subtotal = QuitarCeros(dSubtotal)
        End If


        Dim sNodoImpuestosRetenidos As String = ""


        foundRows = dtImpuesto.Select("RENClave = '" & oCFD.RENClave & "'")
      
        oCFD.impuestos = 0

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & foundRows(i)("Impuesto")
                sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio) & "|"
                oCFD.impuestos += foundRows(i)("Importe") / oCFD.TipoCambio
            Next
        End If

        oCFD.total = QuitarCeros(CDbl(oCFD.subtotal) - (oCFD.descuento / oCFD.TipoCambio) - oCFD.impuestos)

        sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & QuitarCeros(oCFD.impuestos) & "|"

        Dim sNodoEncabezado As String = "||" & oCFD.VersionCF & "|" & String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha) & "|" & "egreso" & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(QuitarCeros(oCFD.descuento)) & "|" & IIf(oCFD.TipoCF = 2, QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|", "") & oCFD.total & "|"

        Dim sNodoRegimenFiscal As String = ""

        If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

            sNodoEncabezado &= spaceFormat(oCFD.metodoDePago) & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "")

            sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

        End If

        Dim sNodoEmisor As String = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & spaceFormat(oCFD.enoExterior) & IIf(oCFD.benoInterior, "|" & spaceFormat(oCFD.enoInterior), "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & spaceFormat(oCFD.eMnpio) & "|" & spaceFormat(oCFD.eEntidad) & "|" & spaceFormat(oCFD.ePais) & "|" & spaceFormat(oCFD.eCodigoPostal) & "|"
        Dim sNodoExpedicion As String = spaceFormat(oCFD.sCalle) & "|" & spaceFormat(oCFD.snoExterior) & IIf(oCFD.bsnoInterior, "|" & spaceFormat(oCFD.snoInterior), "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & spaceFormat(oCFD.sMnpio) & "|" & spaceFormat(oCFD.sEntidad) & "|" & spaceFormat(oCFD.sPais) & "|" & spaceFormat(oCFD.sCodigoPostal) & "|"
        Dim sNodoReceptor As String = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & spaceFormat(oCFD.noExterior) & IIf(oCFD.brnoInterior, "|" & spaceFormat(oCFD.noInterior), "") & "|" & spaceFormat(oCFD.Colonia) & "|" & spaceFormat(oCFD.Mnpio) & "|" & spaceFormat(oCFD.Entidad) & "|" & spaceFormat(oCFD.Pais) & "|" & spaceFormat(oCFD.codigoPostal) & "|"

        If oCFD.iTipoSucursal = 1 Then
            sNodoExpedicion = ""
        End If

        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosRetenidos




        Return sCadenaOriginal

    End Function

    Public Function generarSelloDigital(ByVal scadenaOriginal As String, ByVal Serie As String, ByVal Folio As String, ByVal LlaveFile As String, ByVal ContrasenaClave As String) As String
        Dim FileName As String

        FileName = Serie & Folio

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
            End If
        Catch ex As Exception
        End Try

        Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(LlaveFile)

        If Not System.IO.File.Exists(DirSello) Then
            If System.IO.File.Exists(LlaveFile) Then
                System.IO.File.Copy(LlaveFile, DirSello)
            Else
                Return ""
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
        End If

        Dim cadenaOriginal As String = "C:\SelladoDigital\" & FileName & ".txt"

        Dim file_stream As New System.IO.FileStream(cadenaOriginal, System.IO.FileMode.Create)
        Dim bytes As Byte() = New System.Text.UTF8Encoding().GetBytes(scadenaOriginal)

        file_stream.Write(bytes, 0, bytes.Length)
        file_stream.Close()


        'Donde
        'cadenaOriginal: es el directorio donde se creara el archivo que contiene la cadena original

        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Generando Sello Digital...")


        Dim dir As String
        Dim DirArchivoPEM As String = DirSello & ".pem"

        dir = "C:\OpenSSL\bin\openssl.exe"

        Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


        'Donde
        'DirSello: es el directorio donde se encuentra el archivo.key
        'ContrasenaClave: es la contraseña

        Dim sello As String = "C:\SelladoDigital\" & FileName & "_sello.txt"
        ' Dim digestioncadena As String = "C:\" & "digestioncadena.txt"




        'Donde 
        'cadenaOriginal : es el directorio deonde se creo el archivo que contiene la cadenaOriginal
        'Sello: es el directorio donde se realizara el sellado del archivo donde se realizo la digestion de la cadena original
        'DirArchivoPEM: es el directorio y archivo .key.pem

        Shell(dir & " dgst -sha1 -out " & sello & " -sign " & DirArchivoPEM & " " & cadenaOriginal, AppWinStyle.Hide, True)


        Dim sello64 As String = "C:\SelladoDigital\" & FileName & "_sello64.txt"



        'Donde
        'Sello: nombre del archivo.txt donde fue creado el sellado de la digestion de la cadena original
        'Sello64: nombre del archivo.txt donde se creara el sello en caracteres imprimibles


        Shell(dir & " enc -base64 -in " & sello & " -out " & sello64 & " -A", AppWinStyle.Hide, True)


        Dim elsello As String

        Dim file As New System.IO.StreamReader(sello64)
        elsello = file.ReadLine()

        file.Close()

        frmStatusMessage.Dispose()

        If elsello = "" Then
            MessageBox.Show("Error al generar el sello digital, verifique que la contraseña del Certificado de Sello Digital que ingreso en la configuración de la compañia sea la correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Try
            My.Computer.FileSystem.DeleteFile(cadenaOriginal, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(sello, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(sello64, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return elsello

    End Function

    Public Function generaPFX(ByVal LlaveFile As String, ByVal CertificadoFile As String, ByVal ContrasenaClave As String) As String

        Dim FilePFX As String = System.IO.Path.GetFileName(LlaveFile).Replace(".key", ".pfx")


        'Verifica que exista el path del .Key
        Try
            If Not System.IO.File.Exists(LlaveFile) Then
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        Catch ex As Exception
        End Try


        'Verifica que exista el path del .Cer
        Try
            If Not System.IO.File.Exists(CertificadoFile) Then
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        Catch ex As Exception
        End Try

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
            End If
        Catch ex As Exception
        End Try



        Dim DirKey As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(LlaveFile)
        Dim DirCer As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(CertificadoFile)

        If Not System.IO.File.Exists(DirKey) Then
            If System.IO.File.Exists(LlaveFile) Then
                System.IO.File.Copy(LlaveFile, DirKey)
            Else
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        End If


        If Not System.IO.File.Exists(DirCer) Then
            If System.IO.File.Exists(CertificadoFile) Then
                System.IO.File.Copy(CertificadoFile, DirCer)
            Else
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        End If



        Dim dir As String
        Dim DirArchivoPEM As String = DirKey & ".pem"
        Dim DirCERPEM As String = DirCer & ".pem"
        Dim DirPFX As String = "C:\SelladoDigital\" & FilePFX

        dir = "C:\OpenSSL\bin\openssl.exe"

        If Not System.IO.File.Exists(DirPFX) Then
            Shell(dir & " pkcs8 -inform DER -in " & DirKey & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)
            Shell(dir & " x509  -inform DER -in " & DirCer & " -out " & DirCERPEM, AppWinStyle.Hide, True)
            Shell(dir & " pkcs12 -export -out " & DirPFX & " -inkey  " & DirArchivoPEM & " -in  " & DirCERPEM & " -passout pass:" & ContrasenaClave, AppWinStyle.Hide, True)
        End If

        Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirPFX)


        If fi1.Length = 0 Then
            MessageBox.Show("No fue posible acceder al archivo .pfx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
            Exit Function
        End If

        Dim leer_archivo As New System.IO.FileStream(DirPFX, IO.FileMode.Open)
        Dim bytesLeidos(leer_archivo.Length) As Byte
        leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
        leer_archivo.Close()

        Dim AchivoPFX64 As String = Convert.ToBase64String(bytesLeidos)


        Return AchivoPFX64

    End Function

    Public Function ConvertBitmapToByteArray(ByVal imageIn As System.Drawing.Bitmap) As Byte()
        Return DirectCast(System.ComponentModel.TypeDescriptor.GetConverter(imageIn).ConvertTo(imageIn, GetType(Byte())), Byte())
    End Function

    Public Function ReadFile(ByVal strArchivo As String) As Byte()

        Dim f As New System.IO.FileStream(strArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        Dim size As Integer = CInt(f.Length)

        Dim data As Byte() = New Byte(size - 1) {}

        size = f.Read(data, 0, size)

        f.Close()

        Return data

    End Function

    Public Function GeneraCertificadoX64(ByVal ArchivodeCertificado As String) As String
        'Dim SArchivos As String
        Dim CerBase64 As String

        'SArchivos = System.IO.Directory.GetFiles(DirArchivosFacElec, "*.cer")



        Dim certEmisor As New System.Security.Cryptography.X509Certificates.X509Certificate2()

        ' Generas un objeto del tipo de certificado

        Dim byteCertData As Byte() = ReadFile(ArchivodeCertificado)

        ' Manda llamar la funcion Readfile para cargar el ar.cer 

        certEmisor.Import(byteCertData)

        ' Importa los datos del certificado qeu acabas de leer

        CerBase64 = Convert.ToBase64String(certEmisor.GetRawCertData())

        ' Conviertelos a Base64
        Return CerBase64
    End Function

    Public Function ReadCSV(ByVal Filename As String, ByVal iColumnas As Integer) As DataTable
        Dim strfilename As String
        Dim dt As DataTable = Nothing

        ' Load the file.
        strfilename = Filename

        'Check if file exist
        If System.IO.File.Exists(strfilename) Then
            Dim tmpstream As System.IO.StreamReader = System.IO.File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String

            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)


            Select Case iColumnas
                Case Is = 3
                    dt = ModPOS.CrearTabla("TablaTemporal", _
                                                                     "UBCClave", "System.String", _
                                                                     "GTIN", "System.String", _
                                                                     "Cantidad", "System.String")
                Case Is = 2
                    dt = ModPOS.CrearTabla("TablaTemporal", _
                                                                     "GTIN", "System.String", _
                                                                     "Cantidad", "System.String")
            End Select



            Dim x As Integer

            For x = 0 To strlines.Length - 1
                strline = strlines(x).Split(",")
                If iColumnas = 3 Then
                    If strline.Length = 3 Then
                        If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty AndAlso strline(2) <> String.Empty Then
                            Dim row1 As DataRow
                            row1 = dt.NewRow()
                            'declara el nombre de la fila
                            row1.Item("UBCClave") = strline(0)
                            row1.Item("GTIN") = strline(1)
                            row1.Item("Cantidad") = strline(2)
                            dt.Rows.Add(row1)
                        End If
                    End If
                ElseIf iColumnas = 2 Then
                    If strline.Length = 3 Then
                        If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty Then
                            Dim row1 As DataRow
                            row1 = dt.NewRow()
                            'declara el nombre de la fila
                            row1.Item("GTIN") = strline(0)
                            row1.Item("Cantidad") = strline(1)
                            dt.Rows.Add(row1)
                        End If
                    End If
                End If
            Next

        End If
        Return dt

    End Function

    Public Function LeerCSV(ByVal Filename As String) As DataTable
        Dim strfilename As String
        Dim dt As DataTable = Nothing

        ' Load the file.
        strfilename = Filename

        'Check if file exist
        If System.IO.File.Exists(strfilename) Then
            Dim tmpstream As System.IO.StreamReader = System.IO.File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String

            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)


            dt = ModPOS.CrearTabla("TablaTemporal", _
                                                 "GTIN", "System.String", _
                                                 "Cantidad", "System.String")

            Dim x As Integer

            For x = 0 To strlines.Length - 1
                strline = strlines(x).Split(",")
                If strline.Length = 2 Then
                    If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty Then
                        Dim row1 As DataRow
                        row1 = dt.NewRow()
                        'declara el nombre de la fila
                        row1.Item("GTIN") = strline(0)
                        row1.Item("Cantidad") = strline(1)
                        dt.Rows.Add(row1)
                    End If
                End If
            Next

        End If
        Return dt

    End Function

    Public Sub AbrirCajon(ByVal PrinterName As String)
        Dim ESC, p, m, t1, t2 As Integer
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_impresora", "@Printer", PrinterName)
        ESC = IIf(dt.Rows(0)("ESC").GetType.Name = "DBNull", 27, dt.Rows(0)("ESC"))
        p = IIf(dt.Rows(0)("p").GetType.Name = "DBNull", 112, dt.Rows(0)("p"))
        m = IIf(dt.Rows(0)("m").GetType.Name = "DBNull", 0, dt.Rows(0)("m"))
        t1 = IIf(dt.Rows(0)("t1").GetType.Name = "DBNull", 20, dt.Rows(0)("t1"))
        t2 = IIf(dt.Rows(0)("t2").GetType.Name = "DBNull", 20, dt.Rows(0)("t2"))
        dt.Dispose()
        Dim drawer As String = Chr(ESC) & Chr(p) & Chr(m) & Chr(t1) & Chr(t2)
        RawPrinterHelper.SendStringToPrinter(PrinterName, drawer)
    End Sub

    Public Function RecuperaImpuesto(ByVal sSUCClave As String, ByVal sPROClave As String, ByVal iTImpuesto As Integer) As Double
        Dim dtImpuesto As DataTable
        Dim i As Integer
        Dim PorcImp As Double = 0
        dtImpuesto = ModPOS.SiExisteRecupera("sp_obtenerimpuesto", "@SUCClave", sSUCClave, "@PROClave", sPROClave, "@TImpuesto", iTImpuesto)
        PorcImp = dtImpuesto.Rows(i)("PorcImp")
        dtImpuesto.Dispose()
        Return Redondear(PorcImp, 4)
    End Function

    Public Sub InsertaComandaImpuesto(ByVal PartidaId As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                End If
                ModPOS.Ejecuta("sp_inserta_ComandaImpuesto", "@DCMClave", PartidaId, "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@PorcImp", dtImpuesto.Rows(i)("Valor"), "@Importe", ImpImporte, "@Usuario", ModPOS.UsuarioActual)
                PrecioImp += ImpImporte
            Next
            dtImpuesto.Dispose()
        End If
    End Sub


    Public Sub InsertaImpuesto(ByVal PartidaId As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                End If
                ModPOS.Ejecuta("sp_inserta_detalle_impuesto", "@DVEClave", PartidaId, "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@PorcImp", dtImpuesto.Rows(i)("Valor"), "@Importe", ImpImporte, "@Usuario", ModPOS.UsuarioActual)
                PrecioImp += ImpImporte
            Next
            dtImpuesto.Dispose()
        End If
    End Sub

    Public Sub RecalculaImpuesto(ByVal dtDetalle As DataTable, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim x As Integer
        For x = 0 To dtDetalle.Rows.Count() - 1
            Dim PrecioImp As Double = dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")
            Dim ImpImporte As Double = 0
            Dim dtImpuesto As DataTable
            Dim i As Integer
            dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", dtDetalle.Rows(x)("PROClave"), "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
            If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
                For i = 0 To dtImpuesto.Rows.Count() - 1
                    If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                            ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    Else
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                            ImpImporte = (dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")) * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    End If
                    ModPOS.Ejecuta("sp_actualiza_detalle_impuesto", "DVEClave", dtDetalle.Rows(x)("DVEClave"), "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Importe", ImpImporte)
                    PrecioImp += ImpImporte
                Next
                dtImpuesto.Dispose()
            End If
        Next
    End Sub


    Public Sub RecalculaImpuestoComanda(ByVal dtDetalle As DataTable, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim x As Integer
        For x = 0 To dtDetalle.Rows.Count() - 1
            Dim PrecioImp As Double = dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")
            Dim ImpImporte As Double = 0
            Dim dtImpuesto As DataTable
            Dim i As Integer
            dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", dtDetalle.Rows(x)("PROClave"), "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
            If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
                For i = 0 To dtImpuesto.Rows.Count() - 1
                    If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                            ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    Else
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                            ImpImporte = (dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")) * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    End If
                    ModPOS.Ejecuta("sp_act_detalle_impuesto_comanda", "DCMClave", dtDetalle.Rows(x)("DCMClave"), "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Importe", ImpImporte)
                    PrecioImp += ImpImporte
                Next
                dtImpuesto.Dispose()
            End If
        Next
    End Sub

    Function DesEncripta(ByVal Pass As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Dim j As Integer

        Clave = "%ü&/@#$A"
        Pass2 = ""
        j = 1
        For i = 1 To Len(Pass) Step 2
            CAR = Mid(Pass, i, 2)
            Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))
            j = j + 1
        Next i
        DesEncripta = Pass2
    End Function

    Public Function EncryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)

        'Encrypt string
        If Len(strPwd) Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C = C + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If

        Return strBuff
    End Function

    Public Function DecryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)

        'Decrypt string
        If Len(strPwd) Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C = C - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If

        Return strBuff
    End Function

#Region "Variables de Ventanas"

    Public MetodoPago As FrmMetodoPago

    Public MtoLiquid As FrmMtoLiquid
    Public Liquid As FrmLiquid

    Public MtoVenta As FrmMtoVenta

    Public Restaurar As FrmRestaurar
    Public myTimeOut As Integer = 30
    Public ipageSize As Integer = 100
    Public Version As String = "Versión 3.6.0.1"
    Public AddProd As FrmAddProd
    Public ReiniciaInv As FrmReiniciaInv
    Public RegeneraCFD As FrmRegeneraCFD
    Public AddUnidad As FrmAddUnidad
    Public RepMensual As FrmRepMensual
    Public actCosto As FrmActCosto
    Public MtoNC As FrmMtoNC
    Public MtoCertificado As FrmMtoCertificado
    Public Certificado As FrmCertificado
    Public MtoFolios As FrmMtoFolios
    Public MtoAddenda As FrmMtoAddenda
    Public Addenda As FrmAddenda
    Public Folio As FrmFolio
    Public Sucursal As FrmSucursal
    Public MtoSucursales As FrmMtoSucursales
    Public MtoTransferencia As FrmMtoMOVALM
    Public Transferencia As FrmMOVALM

    Public MtoTraslados As FrmMtoTraslados
    Public Traslado As Frmtraslado


    Public AddAccesos As FrmAddAccesos

    Public Apartados As FrmCancelApartado
    Public PrvProd As FrmPrvProd
    Public Corte As FrmCorte
    Public Sync As FrmSync
    Public Ajustar As FrmAjustar
    Public Contar As FrmContar
    Public ContarProducto As FrmContarProducto
    Public Conteo As FrmConteos
    Public MtoOrdenes As FrmMtoOrdenes
    Public Orden As FrmOrden
    Public MtoCompras As FrmMtoCompras
    Public Compras As FrmCompra
    Public MtoIngresos As FrmMtoIngreso
    Public Ingreso As FrmIngreso
    Public CxP As FrmCXP
    'Public Cancelacion As FrmCancelacion
    Public Reubicacion As FrmReubicacion
    Public ReubicaArchivo As FrmReubicaArchivo
    Public MtoProveedor As FrmMtoProveedor
    Public Proveedor As FrmProveedor
    Public NC As FrmNC
    Public Devolucion As FrmDevolucion
    Public MtoCajas As FrmMtoCaja

    Public MtoContenedor As FrmMtoContenedor
    Public Contenedor As FrmContenedor

    Public MtoTransporte As FrmMtoTransporte
    Public Transporte As FrmTransporte
    Public Tarifa As FrmTarifa

    Public MtoEmpleados As FrmMtoEmpleados
    Public Caja As FrmCaja
    Public MPrincipal As FrmMain
    Public Splash As FrmSplash
    Public Login As FrmLogin
    Public Barra As FrmMenu
    Public Compania As FrmCompania
    Public Backup As FrmBackUp
    Public MtoGeografia As FrmMtoGeografia
    Public Geografia As FrmGeografia
    Public MtoUnidades As FrmMtoUnidades
    Public Unidad As FrmUnidad

    Public MtoPortafolio As FrmMtoPortafolio
    Public Portafolio As FrmPortafolio
    Public AddPortafolio As FrmAddPortafolio

    Public MtoModificadores As FrmMtoModificadores
    Public Modificador As FrmModificador
    Public AddModificador As FrmAddModificador
    Public ProdMod As FrmProdMod
    Public AddProdMod As FrmAddProdMod

    Public Clase As FrmClass
    Public MtoClass As FrmMtoClass


    Public MtoCompania As FrmMtoCompania


    Public Autoriza As FrmAutoriza
    Public MtoPDV As FrmMtoPDV
    Public PDV As FrmPDV
    Public Venta As FrmTPDV
    Public Touch As FrmTouch
    Public Plano As FrmPlano
    Public SplashVenta As FrmSplashVenta
    Public Factura As FrmFactura
    Public Viaje As FrmViaje
    Public MtoViaje As FrmMtoViaje
    Public AddCaja As FrmAddCaja

    Public Estrategia As FrmEstrategia



    Public ComisionVta As FrmComisionVta
    Public MtoFacturas As FrmMtoFacturas
    Public MtoNotaCargo As FrmMtoNotaCargo
    Public NotaCargo As FrmNotaCargo

    Public MtoExcepcion As FrmMtoExcepcion
    Public Excepcion As FrmExcepcion

    Public MtoConteo As FrmMtoConteo
    Public MtoCXC As FrmTCaja
    Public MtoImp As FrmMtoImp
    Public Surtido As FrmSurtido
    Public Recibo As FrmRecibo
    Public Pedidos As FrmPedidos
    Public Recorte As FrmRecorte

    Public MtoAcondicionado As FrmMtoAcondicionado
    Public Acondicionado As FrmAcondicionado

    Public Impuesto As FrmImpuesto
    Public MtoMon As FrmMtoMon
    Public Moneda As FrmMoneda
    Public MtoPrinter As FrmMtoPrinter
    Public Printer As FrmPrinter
    Public MtoUsuario As FrmMtoUsuario
    Public Usuarios As FrmUsuarios
    Public MtoPerfil As FrmMtoPerfil
    Public Perfil As FrmPerfil
    Public MtoModulos As FrmMtoModulos
    Public Modulo As FrmGrupo
    Public Actividad As FrmActividad
    Public MtoProductos As FrmMtoProducto
    Public MtoExistencia As FrmMtoExistencia
    Public Producto As FrmProducto
    Public ProdDet As FrmProdDet

    Public Aplicacion As FrmAplicacion
    Public ProductoEquivalente As FrmAddEquivalente
    Public Cliente As FrmCliente
    Public Empleado As FrmEmpleado
    Public MtoCliente As FrmMtoCliente

    Public Picking As FrmPicking
    Public Confirmacion As FrmConfirmacion

    Public MtoConceptos As FrmMtoConceptos
    Public Concepto As FrmConcepto
    Public MtoNomina As FrmMtoNomina
    Public Nomina As FrmNomina
    Public ReciboNomina As FrmReciboNomina
    Public AddConcepto As FrmAddConcepto

  
    Public MtoValor As FrmMtoValor
    Public Valores As FrmValores
    Public MtoGasto As FrmMtoGasto
    Public Gasto As FrmGasto

    Public Bancos As FrmBank
    Public MtoBancos As FrmMtoBank
    Public Pisos As FrmPisos
    Public MtoPisos As FrmMtoPisos
    Public MtoPrecio As FrmMtoPrecio

    Public MtoTarifa As FrmMtoTarifa

    Public Precio As FrmPrecio
    Public AddPrecio As FrmAddPrecio
    Public ModPrecio As FrmModPrecio
    Public PrintLabel As FrmPrintLabel
    Public LabelSheet As FrmLabelSheet
    Public MtoLabelSheet As FrmMtoLabelSheet
    Public Ticket As FrmTicket
    Public MtoTicket As FrmMtoTicket
    Public Texto As FrmTextoTicket
    Public BuscaTicket As FrmBuscaTicket
    Public MtoDesCte As FrmMtoDesCte
    Public DesCte As FrmDesCte
    Public AddCtes As FrmAddCtes
    Public AddClasPrint As FrmAddClasPrint
    Public MtoPromocion As FrmMtoPromocion
    Public Promocion As FrmPromocion
    Public AddCteProm As FrmAddCteProm
    Public AddPro As FrmAddPro
    Public MtoComision As FrmMtoComision
    Public Comision As FrmComision
    Public PreVenta As FrmTPV
    Public Entrada As FrmEntrada

#End Region

#Region "Variables de Conexión"

    Public BDConexion As String = ""
    Public UsuarioActual As String = ""
    Public UsuarioLogin As String = ""

    Public Licencias As Integer
    Public Candado As String = ""
    Public AccesoAutorizado As Boolean = True
    Public SucursalPredeterminada As String = ""
    Public AplicacionAutomotriz As Integer = 0

    Public AlmacenPredeterminado As String = ""

    Public pathActual As String = ""

    Public CompanyActual As String = ""
    Public TituloMain As String = ""
    Public CompanyName As String = ""


#End Region

#Region "Procedimientos y Funciones Generales"

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean

        If A Is DBNull.Value AndAlso B Is DBNull.Value Then
            Return True
        ElseIf A Is DBNull.Value OrElse B Is DBNull.Value Then
            Return False
        Else
            Return A = B
        End If

    End Function


    Public Function SelectDistinc(ByVal Tabla As String, ByVal TablaOrigen As DataTable, ByVal Campo As String) As DataTable

        Dim dt As New DataTable(Tabla)
        dt.Columns.Add(Campo, TablaOrigen.Columns(Campo).DataType)

        Dim dr As DataRow, LastValue As Object
        LastValue = Nothing
        For Each dr In TablaOrigen.Select("", Campo)
            If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(Campo)) Then
                LastValue = dr(Campo)
                dt.Rows.Add(New Object() {LastValue})
            End If
        Next

        Return dt
    End Function



    Public Sub imprimirTicketTraslado(ByVal Ticket As String, ByVal Generic As Boolean, ByVal sTRSClave As String)
        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim Impresora As String

        Dim lineasImpresas As Integer = 19

        Dim pd As New System.Drawing.Printing.PrintDocument
        Impresora = pd.PrinterSettings.PrinterName
        pd.Dispose()

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If

        Dim dtTraslado As DataTable

        dtTraslado = ModPOS.SiExisteRecupera("sp_rep_traslado", "@TRSClave", sTRSClave)

        Dim sEstatus As String = ""
        Dim sFolio As String = ""
        Dim sSucursalO As String = ""
        Dim sSucursalD As String = ""
        Dim sMotivo As String = ""
        Dim sNota As String = ""
        Dim usuRealiza As String = ""
        Dim usuAutoriza As String = ""
        Dim sSolicita As String = ""

        If Not dtTraslado Is Nothing AndAlso dtTraslado.Rows.Count > 0 Then
            sEstatus = dtTraslado.Rows(0)("CEstado")
            sFolio = dtTraslado.Rows(0)("Folio")
            sSucursalO = dtTraslado.Rows(0)("CSucursalO")
            sSucursalD = dtTraslado.Rows(0)("CSucursalD")
            sMotivo = dtTraslado.Rows(0)("Motivo")
            sSolicita = dtTraslado.Rows(0)("Solicita")
            sNota = dtTraslado.Rows(0)("Notas")
            usuRealiza = dtTraslado.Rows(0)("CRegistro")
            usuAutoriza = dtTraslado.Rows(0)("CAutorizo")
            dtTraslado.Dispose()
        End If


        Tickets.AddHeaderLine("TRASLADO DE MERCANCIA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("FOLIO: " & sFolio, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("SALIDA DE: " & sSucursalO, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("ENTRADA A: " & sSucursalD, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("MOTIVO: " & sMotivo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("SOLICITA: " & sSolicita, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("NOTA: " & sNota, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("ESTATUS: " & sEstatus, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("REALIZA: " & usuRealiza, 0, 1)
        Tickets.AddHeaderLine("AUTORIZA: " & usuAutoriza, 0, 1)
        Tickets.AddSubHeaderLine("FECHA: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)


        Dim dtTrasladoDetalle As DataTable
        dtTrasladoDetalle = ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", sTRSClave)

        lineasImpresas += (dtTrasladoDetalle.Rows.Count * 2)
        Dim dTotalTransferencia As Double = 0
        If Not dtTrasladoDetalle Is Nothing AndAlso dtTrasladoDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtTrasladoDetalle.Rows.Count() - 1
                Dim sGTIN As String = dtTrasladoDetalle.Rows(i)("Clave")
                Dim sUnidad As String = dtTrasladoDetalle.Rows(i)("Unidad")
                Dim sNombre As String = dtTrasladoDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtTrasladoDetalle.Rows(i)("Cantidad")
                Dim dCosto As Double = dtTrasladoDetalle.Rows(i)("Costo")
                Dim dCostoTotal As Double = dtTrasladoDetalle.Rows(i)("Total")
                dTotalTransferencia += dCostoTotal
                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemTransferencia(sGTIN, sNombre, dCantidad, dCosto, dCostoTotal)
            Next
            dtTrasladoDetalle.Dispose()
        End If
        lineasImpresas += 1
        Tickets.AddTotalTicket(dTotalTransferencia, Imprimir.FontEstilo.Negrita)

        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("ENTREGO", 0, 3)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("RECIBIO", 0, 3)

        Tickets.PrintTicket(Impresora, 28, lineasImpresas)

    End Sub

    Public Sub imprimirTicketTransferencia(ByVal Ticket As String, ByVal Generic As Boolean, ByVal sMVAClave As String)
        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim Impresora As String

        Dim lineasImpresas As Integer = 19

        Dim pd As New System.Drawing.Printing.PrintDocument
        Impresora = pd.PrinterSettings.PrinterName
        pd.Dispose()

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If

        Dim dtMOVALM As DataTable

        dtMOVALM = ModPOS.SiExisteRecupera("sp_rep_transferencia", "@MVAClave", sMVAClave)

        Dim sEstatus As String = ""
        Dim sFolio As String = ""
        Dim sALMSalida As String = ""
        Dim sALMEntrada As String = ""
        Dim sTipo As String = ""
        Dim sMotivo As String = ""
        Dim sSolicita As String = ""
        Dim sNota As String = ""
        Dim usuRealiza As String = ""
        Dim usuAutoriza As String = ""

        If Not dtMOVALM Is Nothing AndAlso dtMOVALM.Rows.Count > 0 Then
            sEstatus = dtMOVALM.Rows(0)("CEstado")
            sFolio = dtMOVALM.Rows(0)("Folio")
            sALMSalida = dtMOVALM.Rows(0)("CAlmacenO")
            sALMEntrada = dtMOVALM.Rows(0)("CAlmacenD")
            sTipo = dtMOVALM.Rows(0)("CTipo")
            sMotivo = dtMOVALM.Rows(0)("Motivo")
            sSolicita = dtMOVALM.Rows(0)("Solicita")
            sNota = dtMOVALM.Rows(0)("Notas")
            usuRealiza = dtMOVALM.Rows(0)("CRegistro")
            usuAutoriza = dtMOVALM.Rows(0)("CAutorizo")
            dtMOVALM.Dispose()
        End If


        Tickets.AddHeaderLine("TRASPASO DE MERCANCIA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("FOLIO: " & sFolio, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("SALIDA DE: " & sALMSalida, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("ENTRADA A: " & sALMEntrada, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("TIPO: " & sTipo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("MOTIVO: " & sMotivo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("SOLICITA: " & sSolicita, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("NOTA: " & sNota, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("ESTATUS: " & sEstatus, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("REALIZA: " & usuRealiza, 0, 1)
        Tickets.AddHeaderLine("AUTORIZA: " & usuAutoriza, 0, 1)
        Tickets.AddSubHeaderLine("FECHA: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)


        Dim dtMOVALMDetalle As DataTable
        dtMOVALMDetalle = ModPOS.SiExisteRecupera("sp_detalle_transferencia", "@MVAClave", sMVAClave)

        lineasImpresas += (dtMOVALMDetalle.Rows.Count * 2)
        Dim dTotalTransferencia As Double = 0
        If Not dtMOVALMDetalle Is Nothing AndAlso dtMOVALMDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtMOVALMDetalle.Rows.Count() - 1
                Dim sGTIN As String = dtMOVALMDetalle.Rows(i)("Clave")
                Dim sUnidad As String = dtMOVALMDetalle.Rows(i)("Unidad")
                Dim sNombre As String = dtMOVALMDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtMOVALMDetalle.Rows(i)("Cantidad")
                Dim dCosto As Double = dtMOVALMDetalle.Rows(i)("Costo")
                Dim dCostoTotal As Double = dtMOVALMDetalle.Rows(i)("Total")
                dTotalTransferencia += dCostoTotal
                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemTransferencia(sGTIN, sNombre, dCantidad, dCosto, dCostoTotal)
            Next
            dtMOVALMDetalle.Dispose()
        End If
        lineasImpresas += 1
        Tickets.AddTotalTicket(dTotalTransferencia, Imprimir.FontEstilo.Negrita)

        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("ENTREGO", 0, 3)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("RECIBIO", 0, 3)

        Tickets.PrintTicket(Impresora, 28, lineasImpresas)

    End Sub

    Public Sub imprimirReporteTransferencia(ByVal MVAClave As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", MVAClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", MVAClave))
        OpenReport.PrintPreview("Transferencia de Almacén", "CRTransferencia.rpt", pvtaDataSet, "")
    End Sub


    Public Sub imprimirReporteTraslado(ByVal TRSClave As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_traslado", "@TRSClave", TRSClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", TRSClave))
        OpenReport.PrintPreview("Traslado", "CRTraslado.rpt", pvtaDataSet, "")

    End Sub

    Public Function recuperaValorRef(ByVal tabla As String, ByVal Campo As String, ByVal valor As Integer) As String
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_valorref", "@estado", valor, "@tabla", tabla, "@campo", Campo)

        Return dt.Rows(0)("descripcion")

    End Function

    Public Function ValidaLicencia() As Boolean
        Dim CandadoActual As String

        Dim dtCompania As DataTable
        dtCompania = ModPOS.Recupera_Consulta("SELECT SERVERPROPERTY('ServerName')")

        Candado = ModPOS.encriptarSHA(dtCompania.Rows(0)(0)).Substring(0, 25)

        dtCompania.Dispose()

        dtCompania = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        CandadoActual = IIf(dtCompania.Rows(0)("Logo1") Is System.DBNull.Value, "", dtCompania.Rows(0)("Logo1"))

        Dim Llave As String

        Llave = IIf(dtCompania.Rows(0)("CodigoPostal1") Is System.DBNull.Value, "", dtCompania.Rows(0)("CodigoPostal1"))
        dtCompania.Dispose()

        If Candado = CandadoActual Then
            If Llave.Length = 9 AndAlso Llave = "395656927" Then
                Licencias = 1
                Return True
            ElseIf ModPOS.encriptarSHA(Candado).Substring(0, 10) = Llave.Substring(0, 10) Then
                If IsNumeric(ModPOS.DesEncripta(Llave.Substring(10, Llave.Length - 10))) Then
                    Licencias = CInt(ModPOS.DesEncripta(Llave.Substring(10, Llave.Length - 10)))
                    Return True
                Else
                    Dim a As New Licencia
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        Return a.Pass
                    Else
                        Return False
                    End If
                    a.Dispose()
                End If
            End If

        Else

            Dim a As New Licencia
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Return a.Pass
            Else
                Return False
            End If
            a.Dispose()
        End If
    End Function

    Public Function GetProcessorId() As String
        Dim manClass As System.Management.ManagementClass = New System.Management.ManagementClass("Win32_Processor")
        Dim manObjCol As System.Management.ManagementObjectCollection = manClass.GetInstances()
        Dim ProcessorId As String = String.Empty
        Dim DiscoId As String = String.Empty

        Try
            For Each manObj As System.Management.ManagementObject In manObjCol
                If Not manObj.Properties("ProcessorId").Value Is Nothing Then
                    ProcessorId = manObj.Properties("ProcessorId").Value.ToString()
                End If
            Next
        Catch e As Management.ManagementException
            ProcessorId = "ERR"
        End Try

        DiscoId = ModPOS.SerialNumber

        If ProcessorId = "" Then
            ProcessorId = "NR"
        End If

        Return ProcessorId & "-" & DiscoId.Trim

    End Function


    Public Function obtenerLlave() As String
        Dim dt As DataTable
        Dim Llave As String

        dt = Recupera_Tabla("sp_obtenerLlave")
        If dt Is Nothing Then
            Llave = ""
        Else
            Llave = dt.Rows(0)("Llave")
            dt.Dispose()
        End If
        Return Llave
    End Function

    Public Sub ActualizaExistAlm(ByVal TipoMov As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String)
        ModPOS.Ejecuta("sp_actualiza_existencia", "@TipoMov", TipoMov, "@TipoDoc", TipoDoc, "@Documento", Documento, "@ALMClave", Almacen)
        ModPOS.Ejecuta("sp_actualiza_existencia_cont", "@TipoMov", TipoMov, "@TipoDoc", TipoDoc, "@Documento", Documento, "@ALMClave", Almacen)
    End Sub


    Public Sub ActualizaExistUbcProducto(ByVal TipoMov As Integer, ByVal TProducto As Integer, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Almacen As String)
        If TProducto <= 2 Then
            Dim x As Integer

            For x = 1 To CInt(Math.Abs(Cantidad))
                ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", PROClave)
            Next

            If Math.Abs(Cantidad) > CInt(Math.Abs(Cantidad)) Then
                ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", PROClave, "@Cantidad", Math.Abs(Cantidad) - CInt(Math.Abs(Cantidad)))
            End If

        ElseIf TProducto = 3 Then

            Dim x, fila As Integer
            Dim dtContenido As DataTable


            dtContenido = ModPOS.SiExisteRecupera("sp_recupera_contenido", "@PROClave", PROClave, "@Cantidad", Cantidad)
            If Not dtContenido Is Nothing Then
                For fila = 0 To dtContenido.Rows.Count - 1
                    For x = 1 To CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad")))
                        ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"))
                    Next

                    If Math.Abs(dtContenido.Rows(fila)("Cantidad")) > CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))) Then
                        ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Cantidad", Math.Abs(dtContenido.Rows(fila)("Cantidad")) - CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))))
                    End If
                Next
            End If

        End If

    End Sub

    Public Function ValidaEnvio(ByVal Picking As Boolean, ByVal VENClave As String, ByVal CTEClaveActual As String, ByVal VentaCerrada As Boolean, ByVal ALMClave As String) As Boolean
        If Picking = True Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

            If dt.Rows.Count = 0 Then
                'Inicio

                Dim a As New FrmEnvio
                a.VENClave = VENClave
                a.CTEClave = CTEClaveActual
                a.VentaCerrada = VentaCerrada
                a.ALMClave = ALMClave
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()

                If a.DialogResult <> DialogResult.OK Then
                    a.Dispose()
                    MessageBox.Show("!Debe completar los datos de Entrega¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt.Dispose()
                    Return False
                Else
                    a.Dispose()
                    dt.Dispose()
                    Return True
                End If
            Else
                dt.Dispose()
                Return True
            End If
        Else
            Return True
        End If
    End Function


    Public Sub calculaRecoleccion(ByVal TipoDocumento As Integer, ByVal DOCClave As String, ByVal ALMClave As String)
        Dim i, x As Integer
        Dim foundRows() As DataRow
        Dim dtDetalle, dtUbicacion As DataTable

        dtDetalle = Nothing

        If TipoDocumento = 1 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_VentaDet", "@VENClave", DOCClave)
        ElseIf TipoDocumento = 6 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", DOCClave)

        ElseIf TipoDocumento = 8 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", DOCClave)
        End If

        If dtDetalle.Rows.Count > 0 Then

            foundRows = dtDetalle.Select("TProducto <= 3")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)
                    dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"))
                    Dim Cantidad As Double = foundRows(i)("Cantidad")
                    For x = 0 To dtUbicacion.Rows.Count - 1
                        If dtUbicacion.Rows(x)("Existencia") >= Cantidad Then
                            ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                            Exit For
                        Else
                            Cantidad -= dtUbicacion.Rows(x)("Existencia")
                            ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(x)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    Next
                Next
            End If

            'foundRows = dtDetalle.Select("TProducto = 3")
            'If foundRows.GetLength(0) > 0 Then
            '    Dim j As Integer
            '    Dim dtContenido As DataTable
            '    For i = 0 To foundRows.GetUpperBound(0)
            '        dtContenido = ModPOS.Recupera_Tabla("sp_recupera_contenido", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"))
            '        If dtContenido.Rows.Count > 0 Then
            '            For j = 0 To dtContenido.Rows.Count - 1
            '                dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", dtContenido.Rows(j)("PROClave"))
            '                Dim Cantidad As Double = dtContenido.Rows(j)("Cantidad")
            '                For x = 0 To dtUbicacion.Rows.Count - 1
            '                    If dtUbicacion.Rows(x)("Existencia") >= Cantidad Then
            '                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@DEVClave", foundRows(i)("DVEClave"), "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", dtContenido.Rows(j)("PROClave"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
            '                        Exit For
            '                    Else
            '                        Cantidad -= dtUbicacion.Rows(x)("Existencia")
            '                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@DEVClave", foundRows(i)("DVEClave"), "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", dtContenido.Rows(j)("PROClave"), "@Cantidad", dtUbicacion.Rows(x)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
            '                    End If
            '                Next
            '            Next
            '        End If
            '    Next


            'End If


        End If

    End Sub

    Public Function ActualizaExistUbc(ByVal TipoMov As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String, Optional ByVal Ubicacion As String = Nothing) As Integer

        'TipoDOc 1: Venta, 2:Factura, 3:Devolución,4:Nota Credito, 5:Compra, 6:Transferencia, 7:Ingreso
        'TipoMov 1: Entrada , 2: Salida

        Dim dtDetalle As DataTable = Nothing

        Select Case TipoDoc
            Case Is = 1
                dtDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_apartado", "@VENClave", Documento)
            Case Is = 2
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_fac", "@FACClave", Documento)
            Case Is = 3
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_devolucion", "@DEVClave", Documento)
            Case Is = 4
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_notacredito", "@NCClave", Documento)
            Case Is = 5
                dtDetalle = ModPOS.SiExisteRecupera("sp_compra_detalle", "@COMClave", Documento)
            Case Is = 6
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_transferencia", "@MVAClave", Documento)
            Case Is = 7
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_ingreso", "@INGClave", Documento)
            Case Is = 8
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_traslado", "@INGClave", Documento)

        End Select


        If Not dtDetalle Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtDetalle.Select("TProducto <= 2")
            If foundRows.GetLength(0) > 0 Then
                Dim i, x As Integer
                Dim sProducto As String
                Dim dCantidad As Double

                For i = 0 To foundRows.GetUpperBound(0)
                    ' For i = 0 To numArt - 1
                    sProducto = foundRows(i)("PROClave")
                    dCantidad = foundRows(i)("Cantidad")
                    For x = 1 To CInt(Math.Abs(dCantidad))
                        ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", sProducto, "@Ubicacion", Ubicacion)
                    Next

                    If Math.Abs(dCantidad) > CInt(Math.Abs(dCantidad)) Then
                        ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", sProducto, "@Cantidad", Math.Abs(dCantidad) - CInt(Math.Abs(dCantidad)), "@Ubicacion", Ubicacion)
                    End If

                Next
            End If


            foundRows = dtDetalle.Select("TProducto = 3")
            If foundRows.GetLength(0) > 0 Then
                Dim i, x, fila As Integer
                Dim dtContenido As DataTable

                For i = 0 To foundRows.GetUpperBound(0)
                    dtContenido = ModPOS.SiExisteRecupera("sp_recupera_contenido", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"))
                    If Not dtContenido Is Nothing Then
                        For fila = 0 To dtContenido.Rows.Count - 1
                            For x = 1 To CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad")))
                                ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Ubicacion", Ubicacion)
                            Next

                            If Math.Abs(dtContenido.Rows(fila)("Cantidad")) > CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))) Then
                                ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Cantidad", Math.Abs(dtContenido.Rows(fila)("Cantidad")) - CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))), "@Ubicacion", Ubicacion)
                            End If
                        Next
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If
        Return 1
    End Function

    Public Sub GeneraMovInv(ByVal TipoMov As Integer, ByVal Motivo As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String, ByVal Referencia As String, ByVal Autorizo As String)
        ModPOS.Ejecuta("sp_genera_movimiento", "@TipoMov", TipoMov, "@Motivo", Motivo, "@ALMClave", Almacen, "@Documento", Documento, "@TipoDoc", TipoDoc, "@Referencia", Referencia, "@Autorizo", Autorizo, "@Usuario", ModPOS.UsuarioActual)
        ModPOS.Ejecuta("sp_genera_movimiento_cont", "@TipoMov", TipoMov, "@Motivo", Motivo, "@ALMClave", Almacen, "@Documento", Documento, "@TipoDoc", TipoDoc, "@Referencia", Referencia, "@Autorizo", Autorizo, "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Function QuitarCeros(ByVal num As Double) As String
        Dim n As String
        n = CStr(Redondear(num, 6))

        If CDbl(n) > 0 AndAlso n.IndexOf(".") > -1 Then
            If Mid(n, n.Length, 1) = "0" Then
                Dim i As Integer
                For i = n.Length To 0 Step -1
                    n = Mid(n, 1, i - 1)
                    If Mid(n, n.Length, 1) <> "0" Then
                        Exit For
                    End If
                Next
            End If
        End If

        If Mid(n, n.Length, 1) = "." Then
            n = Mid(n, 1, n.Length - 1)
        End If

        Return n
    End Function

    Public Function IsVocal(ByVal s As String) As Boolean
        Dim c As String
        c = Mid(s, s.Length, 1)

        If Not InStr(1, "aeiouAEIOU", c) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim centavos As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '******+******Genera la parte decimal********************
            For y = Len(dec) To 1 Step -1
                num = Len(dec) - (y - 1)
                Select Case y
                    Case 2, 5, 8
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    flag = "S"
                                    centavos = centavos & "diez "
                                End If
                                If Mid(dec, num + 1, 1) = "1" Then
                                    flag = "S"
                                    centavos = centavos & "once "
                                End If
                                If Mid(dec, num + 1, 1) = "2" Then
                                    flag = "S"
                                    centavos = centavos & "doce "
                                End If
                                If Mid(dec, num + 1, 1) = "3" Then
                                    flag = "S"
                                    centavos = centavos & "trece "
                                End If
                                If Mid(dec, num + 1, 1) = "4" Then
                                    flag = "S"
                                    centavos = centavos & "catorce "
                                End If
                                If Mid(dec, num + 1, 1) = "5" Then
                                    flag = "S"
                                    centavos = centavos & "quince "
                                End If
                                If Mid(dec, num + 1, 1) > "5" Then
                                    flag = "N"
                                    centavos = centavos & "dieci"
                                End If
                            Case "2"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "treinta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cuarenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cincuenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "sesenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "setenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "ochenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "noventa "
                                    flag = "S"
                                Else
                                    centavos = centavos & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If flag = "N" Then centavos = centavos & "un "
                            Case "2"
                                If flag = "N" Then centavos = centavos & "dos "
                            Case "3"
                                If flag = "N" Then centavos = centavos & "tres "
                            Case "4"
                                If flag = "N" Then centavos = centavos & "cuatro "
                            Case "5"
                                If flag = "N" Then centavos = centavos & "cinco "
                            Case "6"
                                If flag = "N" Then centavos = centavos & "seis "
                            Case "7"
                                If flag = "N" Then centavos = centavos & "siete "
                            Case "8"
                                If flag = "N" Then centavos = centavos & "ocho "
                            Case "9"
                                If flag = "N" Then centavos = centavos & "nueve "
                        End Select
                End Select

            Next y


            '**********Une la parte entera y la parte decimal*************

            If Val(numero) >= 1 AndAlso Val(numero) < 2 Then
                palabras = palabras & " PESO "
            Else
                If palabras <> "" Then
                    palabras = palabras & " PESOS "
                Else
                    palabras = "CERO PESOS "
                End If
            End If

            If dec <> "" Then
                If CInt(dec) = 1 Then
                    '       Letras = palabras & "CON " & centavos & " CENTAVO"
                    Letras = palabras & dec & "/100 M.N."
                Else
                    'Letras = palabras & "CON " & centavos & " CENTAVOS"
                    Letras = palabras & dec & "/100 M.N."
                End If
            Else
                'Letras = palabras & " CON CERO CENTAVOS"
                Letras = palabras & " 00/100 M.N."
            End If

        Else
            Letras = ""
        End If
    End Function

    Public Function LetrasM(ByVal numero As String, ByVal MonDesc As String, ByVal MonRef As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim centavos As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '******+******Genera la parte decimal********************
            For y = Len(dec) To 1 Step -1
                num = Len(dec) - (y - 1)
                Select Case y
                    Case 2, 5, 8
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    flag = "S"
                                    centavos = centavos & "diez "
                                End If
                                If Mid(dec, num + 1, 1) = "1" Then
                                    flag = "S"
                                    centavos = centavos & "once "
                                End If
                                If Mid(dec, num + 1, 1) = "2" Then
                                    flag = "S"
                                    centavos = centavos & "doce "
                                End If
                                If Mid(dec, num + 1, 1) = "3" Then
                                    flag = "S"
                                    centavos = centavos & "trece "
                                End If
                                If Mid(dec, num + 1, 1) = "4" Then
                                    flag = "S"
                                    centavos = centavos & "catorce "
                                End If
                                If Mid(dec, num + 1, 1) = "5" Then
                                    flag = "S"
                                    centavos = centavos & "quince "
                                End If
                                If Mid(dec, num + 1, 1) > "5" Then
                                    flag = "N"
                                    centavos = centavos & "dieci"
                                End If
                            Case "2"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "veinte "
                                    flag = "S"
                                Else
                                    centavos = centavos & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "treinta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cuarenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cincuenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "sesenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "setenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "ochenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "noventa "
                                    flag = "S"
                                Else
                                    centavos = centavos & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If flag = "N" Then centavos = centavos & "un "
                            Case "2"
                                If flag = "N" Then centavos = centavos & "dos "
                            Case "3"
                                If flag = "N" Then centavos = centavos & "tres "
                            Case "4"
                                If flag = "N" Then centavos = centavos & "cuatro "
                            Case "5"
                                If flag = "N" Then centavos = centavos & "cinco "
                            Case "6"
                                If flag = "N" Then centavos = centavos & "seis "
                            Case "7"
                                If flag = "N" Then centavos = centavos & "siete "
                            Case "8"
                                If flag = "N" Then centavos = centavos & "ocho "
                            Case "9"
                                If flag = "N" Then centavos = centavos & "nueve "
                        End Select
                End Select

            Next y


            '**********Une la parte entera y la parte decimal*************


            If Val(numero) >= 1 AndAlso Val(numero) < 2 Then
                palabras = palabras & " " & MonDesc & " "
            Else
                Dim final As String
                If IsVocal(MonDesc) = True Then
                    final = "S "
                Else
                    final = "ES "
                End If

                If palabras <> "" Then

                    palabras = palabras & " " & MonDesc.Trim & final
                Else
                    palabras = "CERO " & MonDesc.Trim & final
                End If
            End If

            If dec <> "" Then
                If CInt(dec) = 1 Then
                    '       Letras = palabras & "CON " & centavos & " CENTAVO"
                    LetrasM = palabras & dec & "/100 " & MonRef
                Else
                    'Letras = palabras & "CON " & centavos & " CENTAVOS"
                    LetrasM = palabras & dec & "/100 " & MonRef
                End If
            Else
                'Letras = palabras & " CON CERO CENTAVOS"
                LetrasM = palabras & " 00/100 " & MonRef
            End If

        Else
            LetrasM = ""
        End If
    End Function

    'Public Function spaceFormat(ByVal atributo As String) As String
    '    atributo = atributo.Replace("  ", " ")
    '    atributo = atributo.Replace("  ", " ")
    '    atributo = atributo.Replace("&", "&amp;")
    '    atributo = atributo.Replace("""", "&quot;")
    '    atributo = atributo.Replace("<", "&lt;")
    '    atributo = atributo.Replace(">", "&gt;")
    '    atributo = atributo.Replace("'", "&apos;")
    '    Return (atributo)
    'End Function

    Private Function sValido(ByVal pvCadena As String) As String

        Dim strValido As String

        If pvCadena.Trim() = "" Then Return ""

        strValido = pvCadena.Replace("|", "/")

        strValido = strValido.Replace(ControlChars.Tab, " "c)

        strValido = strValido.Replace(ControlChars.Lf, " "c)

        Dim Arreglo As String() = strValido.Split(" "c)

        strValido = ""

        For Each a As String In Arreglo

            If a <> "" Then strValido += a & " "

        Next

        Return strValido.Trim() & "|"

    End Function




    Public Function spaceFormat(ByVal atributo As String) As String
        If atributo Is Nothing Then
            atributo = ""
        Else
            atributo = atributo.Trim
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
        End If
        Return (atributo)
    End Function


    Public Function cFormat(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim y As Integer

        '*********Dividir parte entera y decimal************

        flag = "N"

        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 0 Then dec = "00"

        If Len(dec) = 1 Then dec = dec & "0"

        '**********Une la parte entera y la parte decimal*************

        Return entero & "." & dec

    End Function


    Public Function FormateaCadena(ByVal Inicio As Boolean, ByVal s As String, ByVal length As Integer) As String
        Dim CadenaVacia As String = "                                                           "
        If Inicio Then
            Dim CadenaNueva As String = s & CadenaVacia
            Return CadenaNueva.Substring(0, length)
        Else
            Dim CadenaNueva As String = CadenaVacia & s
            Return CadenaNueva.Substring(CadenaNueva.Length - length, length)
        End If
    End Function


    ' Al estar declarado como Shared, podemos usarlo sin crear
    ' una instancia de la clase
    Public Sub CambiarEstilo(ByVal tControl As Control)
        ' Cambiar el estilo del control...
        ' sólo si es uno de los indicados
        Select Case tControl.GetType.Name
            Case "Label"
                CType(tControl, Label).FlatStyle = FlatStyle.System
            Case "CheckBox"
                CType(tControl, CheckBox).FlatStyle = FlatStyle.System
            Case "RadioButton"
                CType(tControl, RadioButton).FlatStyle = FlatStyle.System
            Case "Button"
                ' Si el botón tiene asignada la propiedad Image     (11/Oct/02)
                ' no cambiarlo...
                Dim tButton As Button = CType(tControl, Button)
                If tButton.Image Is Nothing Then
                    tButton.FlatStyle = FlatStyle.System
                End If
            Case "GroupBox"
                CType(tControl, GroupBox).FlatStyle = FlatStyle.System
        End Select
        '
        ' Cambiar también los controles contenidos en cada control...
        If tControl.Controls.Count > 0 Then
            Dim tControl2 As Control
            '
            For Each tControl2 In tControl.Controls
                CambiarEstilo(tControl2)
            Next
        End If
    End Sub

    Public Function encriptarSHA(ByVal sPass As String) As String


        Dim hashValue As System.Security.Cryptography.HashAlgorithm

        hashValue = New System.Security.Cryptography.SHA1CryptoServiceProvider

        Dim byteValue As Byte() = System.Text.Encoding.UTF8.GetBytes(sPass)

        Dim byteHash As Byte() = hashValue.ComputeHash(byteValue)

        hashValue.Clear()

        Return (Convert.ToBase64String(byteHash))

    End Function

    Public Function RecuperaIcono(ByVal bits As Byte()) As Bitmap
        Dim memorybits As New System.IO.MemoryStream(bits)
        Dim bitmap As New Bitmap(memorybits)
        Return (bitmap)
    End Function

    Public Function Redondear(ByVal dNumero As Double, ByVal iDecimales As Integer) As Decimal
        'Dim lMultiplicador As Long
        'Dim dRetorno As Double

        'If iDecimales > 9 Then iDecimales = 9
        'lMultiplicador = 10 ^ iDecimales
        'dRetorno = CDbl(CLng(dNumero * lMultiplicador)) / lMultiplicador

        'Redondear = dRetorno

        Return Math.Round(CDec(dNumero), iDecimales)
    End Function

    Public Function CrearTabla(ByVal TableName As String, ByVal ParamArray Columnas() As String) As DataTable
        Dim Table1 As DataTable

        Table1 = New DataTable(TableName)

        If Not Columnas Is Nothing Then
            Dim i As Integer
            For i = 0 To Columnas.Length - 1 Step 2
                Try
                    Dim Columna As DataColumn = New DataColumn(Columnas(i))
                    'declaring a column named Name
                    Columna.DataType = System.Type.GetType(Columnas(i + 1))
                    'setting the datatype for the column
                    Table1.Columns.Add(Columna)
                    'adding the column to table
                Catch

                End Try
            Next
        End If
        Return Table1
    End Function

    Function Recupera_Tabla_No_Msg(ByVal sp As String, ByVal ParamArray Parametros() As Object) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Information, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            '   MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dtu

    End Function

    Function Recupera_Tabla(ByVal sp As String, ByVal ParamArray Parametros() As Object) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Information, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        dtu.TableName = sp
        Return dtu

    End Function

    Function recuperaTabla_DTS(ByVal sp As String, ByVal Tabla As String, ByVal ParamArray Parametros() As Object) As DataSet
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dts As DataSet

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dts = New DataSet

        Try
            du.Fill(dts, Tabla)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dts

    End Function

    Public Sub ActualizaGrid(ByVal Estado As Boolean, ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal sp As String, ByVal ParamArray Parametros() As Object)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With



        Catch ex As Exception
            MsgBox("No se puede conectar con la base de datos", MsgBoxStyle.Critical, "Error")
        End Try
        Dim ds As DataTable = New DataTable
        Try
            da.Fill(ds)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        Grid.DataSource = ds
        Grid.RetrieveStructure(True)
        Grid.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."
        da.Dispose()
        Cnx.Close()

        If Estado AndAlso Grid.RowCount > 0 Then
            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(Grid.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Inactivo")

            fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            Grid.RootTable.FormatConditions.Add(fc)
        End If
        Grid.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Lavender
        Grid.AlternatingColors = True
        'Grid.AutoSizeColumns()


    End Sub


    Public Function SiExite(ByVal Con As String, ByVal sp As String, ByVal ParamArray Parametros() As Object) As Integer
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim Result As Integer

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = Con
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se pudo establecer conexión con el Servidor", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With

        Catch e As System.Data.SqlClient.SqlException
            Beep()
            MsgBox(e.Message, MsgBoxStyle.Critical, "Error")
        End Try

        dt = New DataTable

        Try
            da.Fill(dt)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        Result = dt.Rows.Count()

        dt.Dispose()
        da.Dispose()
        Cnx.Close()

        Return Result
    End Function


    Public Function SiExisteRecuperaT(ByVal Con As String, ByVal sp As String, ByVal ParamArray Parametros() As Object) As Object
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = Con
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()

        If dtu.Rows.Count > 0 Then

            Return dtu
        Else
            dtu.Dispose()
            Return Nothing
        End If

    End Function


    Public Function SiExisteRecupera(ByVal sp As String, ByVal ParamArray Parametros() As Object) As Object
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()

        If dtu.Rows.Count > 0 Then

            Return dtu
        Else
            dtu.Dispose()
            Return Nothing
        End If

    End Function

    Public Sub Ejecuta(ByVal sp As String, ByVal ParamArray Parametros() As Object)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure

            Dim i As Integer

            With MyComand
                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        If Not Parametros(i + 1) Is Nothing Then
                            Select Case Parametros(i + 1).GetType.Name
                                Case "String"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                                Case "Int32"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                                Case "Double"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                                Case "Decimal"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Float).Value = Parametros(i + 1)
                                Case "Byte"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                                Case "Byte[]"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                                Case "DateTime"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                                Case "Boolean"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                            End Select
                        Else
                            If Parametros(i) = "@Logo" OrElse Parametros(i) = "@Publicidad" Then
                                MyComand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = DBNull.Value
                            End If
                        End If
                    Next
                End If
            End With

            MyComand.ExecuteNonQuery()
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Function Recupera_Consulta(ByVal sp As String) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            If e.ErrorCode = -2146232060 Then
                Ejecuta_Consulta("sp_configure 'show advanced options', 1;")
                Ejecuta_Consulta("RECONFIGURE;")
                Ejecuta_Consulta("sp_configure 'Ad Hoc Distributed Queries', 1;")
                Ejecuta_Consulta("RECONFIGURE;")
                MsgBox("No fue posible procesar el archivo, intentelo nuevamente")
            Else
                MsgBox(e.Message)
            End If

        End Try

        du.Dispose()
        Cnx.Close()
        Return dtu

    End Function

    Public Sub Ejecuta_Consulta(ByVal sp As String)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try


            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.ExecuteNonQuery()
            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        Cnx.Close()

    End Sub

    Public Function RecuperaImagen(ByVal File As String) As Image
        'Generar un bitmap para el origen
        Dim SourceImage As Bitmap
        Dim SourceToImage As Bitmap
        Dim ImgEncabezado As Image
        Try
            SourceImage = New Bitmap(File)


            ' Generar un bitmap para el resultado
            SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

            ' Generar un objeto Gráfico para el Bitmap resultante
            Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

            ' Copiar la imagen origen al Bitmap destino
            gr_source.DrawImage(SourceImage, 0, 0, _
                SourceToImage.Width, _
                SourceToImage.Height)


            'Muestra imagen origen
            ImgEncabezado = CType(SourceToImage, Image)

            'Liberar recursos
            gr_source.Dispose()

            SourceImage.Dispose()

            Return ImgEncabezado

        Catch ex As Exception
            MessageBox.Show("No se pudo recuperar la imagen del producto", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function


#End Region

#Region "Almacenes"


    ' Declaraciones del API para 32 bits
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer, _
         ByVal dwNewLong As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" _
        (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, _
         ByVal X As Integer, ByVal Y As Integer, _
         ByVal cX As Integer, ByVal cY As Integer, _
         ByVal wFlags As Integer) As Integer


    ' Constantes para usar con el API
    Const GWL_STYLE As Integer = (-16)
    Const WS_THICKFRAME As Integer = &H40000 ' Con borde redimensionable
    Const SWP_DRAWFRAME As Integer = &H20
    Const SWP_NOMOVE As Integer = &H2
    Const SWP_NOSIZE As Integer = &H1
    Const SWP_NOZORDER As Integer = &H4


    'variables de Ventanas

    Public Buscar As FrmBuscar
    Public Principal As FrmLayout
    Public Almacenes As FrmAlmacenes
    Public Superficie As FrmCanvas
    Public CrearAlm As FrmCrearAlm
    Public Zoom As FrmZoom
    Public Duplicar As FrmDuplicarEst

    Public MtoArea As FrmMtoArea
    Public Areas As FrmArea
    Public AsignarEstructura As FrmAsignarEstructura

    Public MtoEstructura As FrmMtoEstructura
    Public Estructuras As FrmEstructura
    Public LargoColumna As FrmLargo
    Public Hueco As FrmHueco

    Public AsignarZona As FrmAsginarZona

    Public MtoPasillo As FrmMtoPasillo
    Public Pasillo As FrmPasillo
    Public AjustarExist As FrmAjustarExist


    Public Almacen_Activo As String

    'Variables para dibujos
    Public vector(1) As Estructura
    Public CpyVector(1) As Estructura
    Public numEst_Vector As Integer = 0
    Public numEst_CpyVector As Integer = -1
    Public EscalaActual As Integer = 1
    Public Est_Selected As Integer = -1
    'Public Ult_Cve_Est As Integer

    Public Sub CambiarEstilo(ByVal est As Estructura)
        ' Hacer este control redimensionable, usando el API
        ' Pone o quita el estilo dimensionable
        Dim Style As Integer

        Style = GetWindowLong(est.Handle.ToInt32, GWL_STYLE)
        If (Style And WS_THICKFRAME) = WS_THICKFRAME Then
            ' Si ya lo tiene, lo quita
            Style = Style Xor WS_THICKFRAME
        Else
            ' Si no lo tiene, lo pone
            Style = Style Or WS_THICKFRAME
        End If
        SetWindowLong(est.Handle.ToInt32, GWL_STYLE, Style)
        SetWindowPos(est.Handle.ToInt32, Superficie.Handle.ToInt32, 0, 0, 0, 0, SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_DRAWFRAME)

    End Sub

    Public Sub CopiaEstructura(ByVal Original As Estructura, ByVal Cant As Integer)
        Dim i As Integer = 0
        Dim ESTClave As String


        While i < Cant

            'ModPOS.Ult_Cve_Est += 1
            ESTClave = ModPOS.obtenerLlave

            ModPOS.numEst_CpyVector += 1

            If ModPOS.numEst_CpyVector >= 2 Then
                ReDim Preserve ModPOS.CpyVector(ModPOS.CpyVector.Length)
            End If


            ModPOS.CpyVector(ModPOS.numEst_CpyVector) = New Estructura(ESTClave, Original.Width, Original.Height)

            With ModPOS.CpyVector(ModPOS.numEst_CpyVector)
                .BackColor = Original.BackColor
                .AREClave = Original.AREClave
                .TSTClave = Original.TSTClave
                .Clave = "Copia " & CStr(ModPOS.numEst_CpyVector + 1)
                .PasilloColoca = Original.PasilloColoca
                .PasilloRecoge = Original.PasilloRecoge
                .TipoRotacion = Original.TipoRotacion
                .Color = Original.Color
                .Alto = Original.Alto
                .Ancho = Original.Ancho
                .Largo = Original.Largo
                .Columnas = Original.Columnas
                .Niveles = Original.Niveles
                .Rotada = Original.Rotada
                .Estado = Original.Estado

            End With

            'ModPOS.redrawClave(ModPOS.CpyVector(ModPOS.numEst_CpyVector), ModPOS.CpyVector(ModPOS.numEst_CpyVector).Clave)

            i += 1


        End While


    End Sub

    Public Sub PegaEstructura2(ByVal p As Point)
        Dim i As Integer = 0
        While i <= ModPOS.numEst_CpyVector

            If ModPOS.numEst_Vector >= 2 Then
                ReDim Preserve vector(vector.Length)
            End If

            ModPOS.vector(ModPOS.numEst_Vector) = New Estructura(ModPOS.CpyVector(i).Name, ModPOS.CpyVector(i).Width, ModPOS.CpyVector(i).Height)

            ModPOS.Superficie.Controls.Add(ModPOS.vector(ModPOS.numEst_Vector))

            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseDown, AddressOf ModPOS.Superficie.Control_MouseDown
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseMove, AddressOf ModPOS.Superficie.Control_MouseMove
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseEnter, AddressOf ModPOS.Superficie.Control_MouseEnter
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).SizeChanged, AddressOf ModPOS.Superficie.Control_SizeChanged
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).DoubleClick, AddressOf ModPOS.Superficie.Control_DoubleClick
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseLeave, AddressOf ModPOS.Superficie.Control_MouseLeave

            With ModPOS.vector(ModPOS.numEst_Vector)
                .Location = p
                .OrigenX = CDbl(p.X / ModPOS.EscalaActual)
                .OrigenY = CDbl(p.Y / ModPOS.EscalaActual)
                .Indice = ModPOS.numEst_Vector
                .BackColor = ModPOS.CpyVector(i).BackColor
                .AREClave = ModPOS.CpyVector(i).AREClave
                .TSTClave = ModPOS.CpyVector(i).TSTClave
                .Clave = ModPOS.CpyVector(i).Clave
                .PasilloColoca = ModPOS.CpyVector(i).PasilloColoca
                .PasilloRecoge = ModPOS.CpyVector(i).PasilloRecoge
                .TipoRotacion = ModPOS.CpyVector(i).TipoRotacion
                .Color = ModPOS.CpyVector(i).Color
                .Alto = ModPOS.CpyVector(i).Alto
                .Ancho = ModPOS.CpyVector(i).Ancho
                .Largo = ModPOS.CpyVector(i).Largo
                .Columnas = ModPOS.CpyVector(i).Columnas
                .Niveles = ModPOS.CpyVector(i).Niveles
                ' .CapacidadCarga = ModPOS.CpyVector(i).CapacidadCarga
                .Rotada = ModPOS.CpyVector(i).Rotada
                .Estado = ModPOS.CpyVector(i).Estado
            End With
            ModPOS.Graba_Estructura(ModPOS.vector(ModPOS.numEst_Vector))
            ModPOS.numEst_Vector += 1
            i += 1
        End While



        Dim k As Integer = ModPOS.numEst_CpyVector
        If ModPOS.numEst_CpyVector > -1 Then
            While k >= 0
                ModPOS.CpyVector(k).Dispose()
                k -= 1
            End While
            ReDim ModPOS.CpyVector(1)
            ModPOS.numEst_CpyVector = -1
        End If


    End Sub


    Public Sub PegaEstructura(ByVal p As Point)
        Dim i As Integer = 0
        While i <= ModPOS.numEst_CpyVector
            Dim Punto2 As New Point(p.X + ModPOS.CpyVector(i).Width, p.Y + ModPOS.CpyVector(i).Height)
            ModPOS.Superficie.NuevaEstructura(p, Punto2)
            'Se actualiza el indice que indica la estructura seleccionada.
            ModPOS.Est_Selected = ModPOS.numEst_Vector - 1

            ModPOS.Estructuras = New FrmEstructura

            With ModPOS.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabPageUbc.Enabled = False
                .Text = "Nueva Estructura de Almacenaje"
                .StartPosition = FormStartPosition.CenterScreen
                .sAlmacen = ModPOS.Almacen_Activo
                .sArea = ModPOS.CpyVector(i).AREClave
                .sTESTClave = ModPOS.CpyVector(i).TSTClave
                .Clave = ModPOS.CpyVector(i).Clave
                .sColoca = ModPOS.CpyVector(i).PasilloColoca
                .sRecoge = ModPOS.CpyVector(i).PasilloRecoge
                .iRotacion = ModPOS.CpyVector(i).TipoRotacion
                .iColor = ModPOS.CpyVector(i).Color
                .dAlto = ModPOS.CpyVector(i).Alto
                .dAncho = ModPOS.CpyVector(i).Ancho
                .dLargo = ModPOS.CpyVector(i).Largo
                .iColumna = ModPOS.CpyVector(i).Columnas
                .iNiveles = ModPOS.CpyVector(i).Niveles
                .Rotada = ModPOS.CpyVector(i).Rotada
                .iEstado = ModPOS.CpyVector(i).Estado
                .dX = CDbl(p.X / ModPOS.EscalaActual)
                .dY = CDbl(p.Y / ModPOS.EscalaActual)
                .ShowDialog()
            End With

            i += 1
        End While


        Dim k As Integer = ModPOS.numEst_CpyVector
        If ModPOS.numEst_CpyVector > -1 Then
            While k >= 0
                ModPOS.CpyVector(k).Dispose()
                k -= 1
            End While
            ReDim ModPOS.CpyVector(1)
            ModPOS.numEst_CpyVector = -1
        End If


    End Sub



    Public Sub RotarEstructura(ByVal Est As Estructura)
        Dim NvoWidth, NvoHeight As Integer
        Dim Rotar As Boolean
        NvoHeight = Est.Width()
        NvoWidth = Est.Height()
        Rotar = Est.Rotada
        If Rotar Then
            Est.Rotada = False
        Else
            Est.Rotada = True
        End If
        Est.Width = NvoWidth
        Est.Height = NvoHeight


    End Sub

    Public Sub Graba_Layout_Activo()
        If Not ModPOS.Superficie Is Nothing Then
            Dim MyTrans As System.Data.SqlClient.SqlTransaction
            Dim MyComand As System.Data.SqlClient.SqlCommand
            Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

            Try
                Cnx = New System.Data.SqlClient.SqlConnection
                Cnx.ConnectionString = ModPOS.BDConexion
                Cnx.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cnx.BeginTransaction
            MyComand = Cnx.CreateCommand()
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            Try
                If ModPOS.Superficie.CambioTamaño Then
                    MyComand.CommandText = "update Almacen set Escala=" & CStr(ModPOS.Superficie.Escala) & ",Width=" & CStr(ModPOS.Superficie.Width) & ",Height=" & CStr(ModPOS.Superficie.Height) & "where ALMClave=" & "'" & CStr(ModPOS.Superficie.ALMClave) & "'"
                    MyComand.ExecuteNonQuery()
                End If

                Dim i As Integer = 0

                While i < ModPOS.numEst_Vector

                    If ModPOS.vector(i).CambioPosicion Then
                        MyComand.CommandText = "update Estructura set OrigenX=" & CStr(ModPOS.vector(i).OrigenX) & ",OrigenY=" & CStr(ModPOS.vector(i).OrigenY) & "where ESTClave=" & "'" & ModPOS.vector(i).Name & "'"
                        MyComand.ExecuteNonQuery()
                    End If
                    If ModPOS.vector(i).CambioTamaño Then
                        MyComand.CommandText = "update Estructura set Escala=" & CStr(ModPOS.vector(i).Escala) & ",Largo=" & CStr(ModPOS.vector(i).Largo) & ",Ancho=" & CStr(ModPOS.vector(i).Ancho) & ",Width=" & CStr(ModPOS.vector(i).Width) & ",Height=" & CStr(ModPOS.vector(i).Height) & "where ESTClave=" & "'" & ModPOS.vector(i).Name & "'"
                        MyComand.ExecuteNonQuery()
                    End If
                    i += 1
                End While
                MyTrans.Commit()

            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cnx.Close()

            Dim k As Integer = ModPOS.numEst_Vector - 1
            If ModPOS.numEst_Vector > 0 Then
                While k >= 0
                    ModPOS.vector(k).Dispose()
                    k -= 1
                End While
                ReDim ModPOS.vector(1)
                ModPOS.numEst_Vector = 0
            End If


            'ModPOS.Superficie.Close()
            If ModPOS.Est_Selected > -1 Then
                ModPOS.Est_Selected = -1
            End If
        End If
    End Sub

    Public Sub Graba_Area(ByVal Are As FrmArea)

        ModPOS.Ejecuta("sp_inserta_area", _
                        "@AREClave", Are.AREClave, _
                        "@Clave", Are.Referencia, _
                        "@Nombre", Are.Nombre, _
                        "@Tipo", Are.Tipo, _
                        "@Color", Are.Color, _
                        "@Estado", Are.Estado, _
                        "@ALMClave", Are.ALMClave, _
                        "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Area(ByVal Are As FrmArea, ByVal Est As Boolean)
        Dim iEst As Integer

        If Est Then
            iEst = 1
        Else
            iEst = 0
        End If

        ModPOS.Ejecuta("sp_actualiza_area", _
                          "@AREClave", Are.AREClave, _
                          "@Nombre", Are.Nombre, _
                          "@Tipo", Are.Tipo, _
                          "@Color", Are.Color, _
                          "@Estado", Are.Estado, _
                        "@Estructura", iEst, _
                        "@ALMClave", Are.ALMClave, _
                          "@Usuario", ModPOS.UsuarioActual)


    End Sub

    Public Sub Update_AREEstructura(ByVal Clave As String, ByVal Color As Integer, ByVal Estructura As String)
        ModPOS.Ejecuta("sp_actualiza_AREEstructura", _
                "@Clave", Clave, _
                "@Color", Color, _
                "@Estructura", Estructura, _
                "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Zona(ByVal Est As String, ByVal Pos As String, ByVal Zon As Integer)
        ModPOS.Ejecuta("sp_actualiza_zona", _
                        "@Estructura", Est, _
                        "@Posicion", Pos, _
                        "@Zona", Zon)
    End Sub

    Public Sub Graba_Estructura(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3 As Integer
        Dim Porc As Double
        Dim rotada As Int16
        Dim Level As String

        If Est.Rotada Then
            rotada = 1
        Else : rotada = 0
        End If

        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable


        Posicion = 0

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")

        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_estructura", Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure
            MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
            MyComand.Parameters.Add("@ALMClave", SqlDbType.VarChar).Value = Est.ALMClave
            MyComand.Parameters.Add("@AREClave", SqlDbType.VarChar).Value = Est.AREClave
            MyComand.Parameters.Add("@TESTClave", SqlDbType.VarChar).Value = Est.TSTClave
            MyComand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Est.Clave
            MyComand.Parameters.Add("@Color", SqlDbType.Int).Value = Est.Color
            MyComand.Parameters.Add("@Escala", SqlDbType.Int).Value = Est.Escala
            MyComand.Parameters.Add("@OrigenX", SqlDbType.Float).Value = Est.OrigenX
            MyComand.Parameters.Add("@OrigenY", SqlDbType.Float).Value = Est.OrigenY
            MyComand.Parameters.Add("@Width", SqlDbType.Int).Value = Est.Width
            MyComand.Parameters.Add("@Height", SqlDbType.Int).Value = Est.Height
            MyComand.Parameters.Add("@Largo", SqlDbType.Float).Value = Est.Largo
            MyComand.Parameters.Add("@Ancho", SqlDbType.Float).Value = Est.Ancho
            MyComand.Parameters.Add("@Alto", SqlDbType.Float).Value = Est.Alto
            MyComand.Parameters.Add("@Columnas", SqlDbType.Int).Value = Est.Columnas
            MyComand.Parameters.Add("@Niveles", SqlDbType.Int).Value = Est.Niveles
            ' MyComand.Parameters.Add("@CapacidadCarga", SqlDbType.Float).Value = Est.CapacidadCarga
            MyComand.Parameters.Add("@TipoRotacion", SqlDbType.Int).Value = Est.TipoRotacion
            MyComand.Parameters.Add("@PasilloColoca", SqlDbType.VarChar).Value = Est.PasilloColoca
            MyComand.Parameters.Add("@PasilloRecoge", SqlDbType.VarChar).Value = Est.PasilloRecoge
            MyComand.Parameters.Add("@Rotada", SqlDbType.Bit).Value = rotada
            MyComand.Parameters.Add("@Estado", SqlDbType.SmallInt).Value = Est.Estado
            MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

            MyComand.ExecuteNonQuery()


            For i = 1 To Est.Niveles
                Level = Chr(i + 64)
                For j = 1 To Est.Columnas
                    Posicion += 1
                    'inserta posiciones
                    MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_hueco", Cnx)
                    MyComand.Transaction = MyTrans
                    MyComand.CommandTimeout = ModPOS.myTimeOut
                    MyComand.CommandType = CommandType.StoredProcedure
                    MyComand.Parameters.Add("@HUEClave", SqlDbType.VarChar).Value = CStr(Posicion)
                    MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
                    MyComand.Parameters.Add("@Columna", SqlDbType.Int).Value = j
                    MyComand.Parameters.Add("@Nivel", SqlDbType.Int).Value = i
                    MyComand.Parameters.Add("@Largo", SqlDbType.Float).Value = Est.Largo / Est.Columnas
                    MyComand.Parameters.Add("@Ancho", SqlDbType.Float).Value = Est.Ancho
                    MyComand.Parameters.Add("@Alto", SqlDbType.Float).Value = Est.Alto / Est.Niveles
                    'MyComand.Parameters.Add("@Volumen", SqlDbType.Float).Value = (Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho
                    ' MyComand.Parameters.Add("@CapacidadCarga", SqlDbType.Float).Value = Est.CapacidadCarga / (Est.Niveles * Est.Columnas)
                    MyComand.Parameters.Add("@Porcentaje", SqlDbType.Float).Value = Porc
                    MyComand.Parameters.Add("@cNivel", SqlDbType.VarChar).Value = Level
                    MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

                    MyComand.ExecuteNonQuery()

                    For k = 1 To ubicaciones

                        'inserta ubicaciones 
                        MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_ubicacion", Cnx)
                        MyComand.Transaction = MyTrans
                        MyComand.CommandTimeout = ModPOS.myTimeOut
                        MyComand.CommandType = CommandType.StoredProcedure
                        MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
                        MyComand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Est.Clave
                        MyComand.Parameters.Add("@HUEClave", SqlDbType.VarChar).Value = CStr(Posicion)
                        MyComand.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = CStr(k)
                        MyComand.Parameters.Add("@len1", SqlDbType.Int).Value = len1
                        MyComand.Parameters.Add("@len2", SqlDbType.Int).Value = len2
                        MyComand.Parameters.Add("@len3", SqlDbType.Int).Value = len3
                        MyComand.Parameters.Add("@cNivel", SqlDbType.VarChar).Value = Level
                        MyComand.Parameters.Add("@Columna", SqlDbType.Int).Value = j
                        MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual
                        MyComand.ExecuteNonQuery()



                    Next
                Next
            Next
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub Graba_Superficie(ByVal Sup As FrmCanvas)
        ModPOS.Ejecuta("sp_inserta_almacen", _
                    "@ALMClave", Sup.ALMClave, _
                    "@Clave", Sup.Referencia, _
                    "@Nombre", Sup.Nombre, _
                    "@Escala", Sup.Escala, _
                    "@Width", Sup.Width, _
                    "@Height", Sup.Height, _
                    "@Largo", Sup.Largo, _
                    "@Ancho", Sup.Ancho, _
                    "@Alto", Sup.Alto, _
                    "@SUCClave", Sup.SUCClave, _
                    "@BloqueoVta", Sup.BloqueoVta, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Almacen(ByVal Alm As FrmCrearAlm)
        ModPOS.Ejecuta("sp_actualiza_almacen", _
                  "@ALMClave", Alm.ALMClave, _
                   "@Nombre", Alm.sCpyNombre, _
                    "@Largo", Alm.dCpyLargo, _
                    "@Ancho", Alm.dCpyAncho, _
                    "@Alto", Alm.dCpyAlto, _
                    "@Width", CInt(Alm.dCpyLargo * Alm.iCpyEscala), _
                    "@Height", CInt(Alm.dCpyAncho * Alm.iCpyEscala), _
                    "@Estado", Alm.iCpyEstado, _
                    "@SUCClave", Alm.sCpySucursal, _
                    "@BloqueoVta", Alm.bCpyBloqueoVta, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Estructura(ByVal Est As FrmEstructura, ByVal Clave As String, ByVal Ancho As Boolean)
        Dim Rotar, Huecos As Integer

        If Est.Rotada Then
            Rotar = 1
        Else
            Rotar = 0
        End If


        If Ancho Then
            Huecos = 1
        Else
            Huecos = 0
        End If


        ModPOS.Ejecuta("sp_actualiza_estructura", _
                    "@ESTClave", Clave, _
                    "@Rotada", Rotar, _
                    "@WidthHeight", CInt(Est.dAncho * ModPOS.EscalaActual), _
                    "@AREClave", Est.sArea, _
                    "@Color", Est.iColor, _
                    "@Clave", Est.ID, _
                    "@PasilloColoca", Est.sColoca, _
                    "@PasilloRecoge", Est.sRecoge, _
                    "@TipoRotacion", Est.iRotacion, _
                    "@Ancho", Est.dAncho, _
                    "@OrigenX", Est.dX, _
                    "@OrigenY", Est.dY, _
                    "@Hueco", Huecos, _
                    "@Usuario", ModPOS.UsuarioActual)

    End Sub

    Public Function RecuperaPosiciones(ByVal Est As String) As Integer
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim iPosiciones As Integer


        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try
            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand("sp_recupera_posiciones", Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure
                .SelectCommand.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Est

            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dt = New DataTable

        Try
            da.Fill(dt)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        iPosiciones = dt.Rows(0)("Posiciones")

        dt.Dispose()
        da.Dispose()
        Cnx.Close()
        Return iPosiciones

    End Function


    Public Sub InsertaUbicacion(ByVal sESTClave As String, ByVal sClave As String, ByVal sHUEClave As String, ByVal sTipo As String)
        Dim len1, len2, len3 As Integer
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", sTipo)

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")

        dt.Dispose()

        Dim iUltimaUbicacion As Integer
        Dim iColumna As Integer
        Dim sNivel As String
        If sHUEClave = "" Then
            iColumna = 0
            sNivel = ""
        Else
            iColumna = CInt(Split(sHUEClave, "-")(0))
            sNivel = Split(sHUEClave, "-")(1)
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_hueco", "@ESTClave", sESTClave, "@Columna", iColumna, "@cNivel", sNivel)
        If dt.Rows.Count = 1 Then
            sHUEClave = dt.Rows(0)("HUEClave")
        End If
        dt.Dispose()

        iUltimaUbicacion = ModPOS.SiExite(ModPOS.BDConexion, "sp_ultima_ubicacion", "@Estructura", sESTClave, "@Columna", iColumna, "@cNivel", sNivel)
        iUltimaUbicacion += 1

        ModPOS.Ejecuta("sp_inserta_ubicacion", _
        "@Clave", sClave, _
        "@HUEClave", sHUEClave, _
        "@ESTClave", sESTClave, _
        "@Ubicacion", iUltimaUbicacion, _
        "@len1", len1, _
        "@len2", len2, _
        "@len3", len3, _
        "@cNivel", sNivel, _
        "@Columna", iColumna, _
        "@Usuario", ModPOS.UsuarioActual)


    End Sub

    Public Sub Graba_Pasillo(ByVal Pas As FrmPasillo)

        ModPOS.Ejecuta("sp_inserta_pasillo", _
                    "@PASClave", Pas.PASClave, _
                    "@Clave", Pas.Referencia, _
                    "@Nombre", Pas.Nombre, _
                    "@Largo", Pas.Largo, _
                    "@Ancho", Pas.Ancho, _
                    "@Estado", Pas.Estado, _
                    "@Almacen", Pas.ALMClave, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub


    Public Sub Update_Pasillo(ByVal Pas As FrmPasillo)
        ModPOS.Ejecuta("sp_actualiza_pasillo", _
                    "@PASClave", Pas.PASClave, _
                    "@Nombre", Pas.Nombre, _
                    "@Largo", Pas.Largo, _
                    "@Ancho", Pas.Ancho, _
                    "@Estado", Pas.Estado, _
                    "@Almacen", Pas.ALMClave, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub


    Public Sub Update_Hueco(ByVal Hue As FrmHueco)

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        Try
            '            MyComand.CommandText = "Update Hueco set CapacidadCarga=" & CStr(Hue.dCarga) & ", CargaDisponible=" & CStr(Hue.dCarga) & ", Alto=" & CStr(Hue.dAlto) & ", Volumen= Largo*Ancho*" & CStr(Hue.dAlto) & ", VolumenDisponible=Largo*Ancho*" & CStr(Hue.dAlto) & ",Porc_Apro_Vol=" & CStr(Hue.iPorc) & ",Estado=" & CStr(Hue.iEstado) & " , MFechaHora= getdate(), MUsuarioId='" & ModPOS.UsuarioActual & "'where HueClave='" & Hue.sHueco & "' and ESTClave='" & Hue.sEstructura & "'"
            MyComand.CommandText = "Update Hueco set Alto=" & CStr(Hue.dAlto) & ",Porcentaje=" & CStr(Hue.iPorc) & ",Estado=" & CStr(Hue.iEstado) & " , MFechaHora= getdate(), MUsuarioId='" & ModPOS.UsuarioActual & "'where HueClave='" & Hue.sHueco & "' and ESTClave='" & Hue.sEstructura & "'"

            MyComand.ExecuteNonQuery()

            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub InsertaFila(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3, Porc As Integer

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable

        Posicion = RecuperaPosiciones(Est.Name)

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")
        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        'Dim NuevaCarga As Double
        Dim NuevaAltura As Double

        'NuevaCarga = Est.CapacidadCarga + (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Columnas
        NuevaAltura = Est.Alto + (Est.Alto / Est.Niveles)

        Try
            MyComand.CommandText = "update Estructura set Niveles =" & CStr(Est.Niveles + 1) & ",Alto=" & CStr(NuevaAltura) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
            MyComand.ExecuteNonQuery()


            i = Est.Niveles + 1
            For j = 1 To Est.Columnas
                Posicion += 1
                'inserta posiciones
                ' MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Volumen,CapacidadCarga,CargaDisponible,VolumenDisponible,Porc_Apro_Vol,Estado,Baja,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) & "," & CStr(Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Porc) & ",1,0,getdate()," & "'" & ModPOS.UsuarioActual & "')"
                MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Porcentaje,Estado,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & Porc & ",1,getdate()," & "'" & ModPOS.UsuarioActual & "')"

                MyComand.ExecuteNonQuery()

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    'MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,NumeroPosiciones,Num_Pos_Disponible,Estado,Baja,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "'," & CStr(posiciones_ubc) & "," & CStr(posiciones_ubc) & ",1,0,getdate(),'" & ModPOS.UsuarioActual & "')"

                    MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,Estado,Fase,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "',1,1,getdate(),'" & ModPOS.UsuarioActual & "')"
                    MyComand.ExecuteNonQuery()

                Next
            Next

            Est.Niveles += 1
            '       Est.CapacidadCarga = NuevaCarga
            Est.Alto = NuevaAltura

            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub InsertaColumna(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3, Porc As Integer

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable


        Posicion = RecuperaPosiciones(Est.Name)

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")

        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        ' Dim NuevaCarga As Double
        Dim NuevoLargo As Double



        'NuevaCarga = Est.CapacidadCarga + (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Niveles
        NuevoLargo = Est.Largo + (Est.Largo / Est.Columnas)

        Try
            If Est.Rotada Then
                Est.Height = CInt(NuevoLargo * Est.Escala)
                MyComand.CommandText = "update Estructura set Columnas =" & CStr(Est.Columnas + 1) & ",Largo=" & CStr(NuevoLargo) & ", Heigth=" & CStr(Est.Height) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
                MyComand.ExecuteNonQuery()

            Else
                Est.Width = CInt(NuevoLargo * Est.Escala)
                MyComand.CommandText = "update Estructura set Columnas =" & CStr(Est.Columnas + 1) & ",Largo=" & CStr(NuevoLargo) & ", Width=" & CStr(Est.Width) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
                MyComand.ExecuteNonQuery()

            End If


            j = Est.Columnas + 1
            For i = 1 To Est.Niveles
                Posicion += 1
                'inserta posiciones
                'MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Volumen,VolumenDisponible,Porc_Apro_Vol,Estado,Baja,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Porc) & ",1,0,getdate()," & "'" & ModPOS.UsuarioActual & "')"
                MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Porcentaje,Estado,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & Porc & ",1,getdate()," & "'" & ModPOS.UsuarioActual & "')"

                MyComand.ExecuteNonQuery()

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    'MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,NumeroPosiciones,Num_Pos_Disponible,Estado,Baja,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "'," & CStr(posiciones_ubc) & "," & CStr(posiciones_ubc) & ",1,0,getdate(),'" & ModPOS.UsuarioActual & "')"
                    MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,Estado,Fase,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "',1,1,getdate(),'" & ModPOS.UsuarioActual & "')"

                    MyComand.ExecuteNonQuery()

                Next
            Next
            Est.Columnas += 1
            '   Est.CapacidadCarga = NuevaCarga
            Est.Largo = NuevoLargo
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub EliminaFila(ByVal Est As Estructura)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cn As System.Data.SqlClient.SqlConnection = Nothing
        Dim Con As String = ModPOS.BDConexion

        If ModPOS.SiExite(Con, "sp_fila_vacia", "@Estructura", Est.Name, "@Fila", CStr(Est.Niveles)) = 0 Then

            Try
                Cn = New System.Data.SqlClient.SqlConnection
                Cn.ConnectionString = ModPOS.BDConexion
                Cn.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cn.BeginTransaction
            MyComand = Cn.CreateCommand()
            MyComand.Transaction = MyTrans

            Try
                MyComand.CommandText = "update Ubicacion set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where Estado=1 and ESTClave ='" & Est.Name & "' and HueClave in (select HueClave from Hueco where Estado= 1 and ESTClave='" & Est.Name & "' and Nivel=" & CStr(Est.Niveles) & ")"
                MyComand.ExecuteNonQuery()

                MyComand.CommandText = "update Hueco set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where Estado=1 and ESTClave='" & Est.Name & "' and Nivel=" & CStr(Est.Niveles)
                MyComand.ExecuteNonQuery()

                ' Dim NuevaCarga As Double
                Dim NuevaAltura As Double

                'NuevaCarga = Est.CapacidadCarga - (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Columnas
                NuevaAltura = Est.Alto - (Est.Alto / Est.Niveles)

                Est.Niveles -= 1

                MyComand.CommandText = "Update Estructura set Niveles =" & CStr(Est.Niveles) & ",Alto=" & CStr(NuevaAltura) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                MyComand.ExecuteNonQuery()

                'Est.CapacidadCarga = NuevaCarga
                Est.Alto = NuevaAltura

                MyTrans.Commit()

            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cn.Close()

        Else
            MsgBox("No es posible eliminar la columna debido a que existen ubicaciones ocupadas", MessageBoxButtons.OK)
        End If
    End Sub

    Public Sub EliminaColumna(ByVal Est As Estructura)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cn As System.Data.SqlClient.SqlConnection = Nothing
        Dim Con As String = ModPOS.BDConexion
        If ModPOS.SiExite(Con, "sp_columna_vacia", "@Estructura", Est.Name, "@Columna", CStr(Est.Columnas)) = 0 Then

            Try
                Cn = New System.Data.SqlClient.SqlConnection
                Cn.ConnectionString = ModPOS.BDConexion
                Cn.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cn.BeginTransaction
            MyComand = Cn.CreateCommand()
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            Try
                MyComand.CommandText = "update Ubicacion set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where Estado=1 and ESTClave ='" & Est.Name & "' and HueClave in (select HueClave from Hueco where Estado= 1 and ESTClave='" & Est.Name & "' and Columna=" & CStr(Est.Columnas) & ")"
                MyComand.ExecuteNonQuery()

                MyComand.CommandText = "update Hueco set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where Estado=1 and ESTClave='" & Est.Name & "' and Columna=" & CStr(Est.Columnas)
                MyComand.ExecuteNonQuery()

                '      Dim NuevaCarga As Double
                Dim NuevoLargo As Double

                '     NuevaCarga = Est.CapacidadCarga - (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Niveles
                NuevoLargo = Est.Largo - (Est.Largo / Est.Columnas)
                Est.Columnas -= 1

                If Est.Rotada Then

                    Est.Height = CInt(NuevoLargo * Est.Escala)
                    MyComand.CommandText = "update estructura set columnas =" & CStr(Est.Columnas) & ",Largo=" & CStr(NuevoLargo) & ", Height=" & CStr(Est.Height) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                    MyComand.ExecuteNonQuery()
                Else
                    Est.Width = CInt(NuevoLargo * Est.Escala)
                    MyComand.CommandText = "update estructura set columnas =" & CStr(Est.Columnas) & ",Largo=" & CStr(NuevoLargo) & ", Width=" & CStr(Est.Width) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                    MyComand.ExecuteNonQuery()

                End If



                'Est.CapacidadCarga = NuevaCarga
                Est.Largo = NuevoLargo
                MyTrans.Commit()

            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cn.Close()

        Else
            MsgBox("No es posible eliminar la columna debido a que existen ubicaciones ocupadas", MessageBoxButtons.OK)
        End If
    End Sub

    Public Sub Elimina_Pasillo(ByVal Pas As String)
        ModPOS.Ejecuta("sp_elimina_pasillo", _
                "@Pasillo", Pas, _
                "@Usuario", ModPOS.UsuarioActual)
    End Sub
    Public Sub Elimina_Area(ByVal Are As String)
        ModPOS.Ejecuta("sp_elimina_area", _
          "@Area", Are, _
           "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Elimina_Estructura(ByVal Est As String)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand("sp_elimina_estructura", Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure
            MyComand.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Est
            MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

            MyComand.ExecuteNonQuery()
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Function ImageAddText(ByVal foto As PictureBox, ByVal texto As String) As Image
        Dim ret As Bitmap = New Bitmap(foto.Width, foto.Height)
        Dim g As Graphics = Graphics.FromImage(ret)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim font1 As New Font("Century Gothic", 8, FontStyle.Regular, GraphicsUnit.Point)
        Dim rect1 As New Rectangle(0, 0, foto.Width, foto.Height)
        g.DrawString(texto, font1, Brushes.Black, rect1, stringFormat)
        g.Dispose()
        Return ret

    End Function

    'Public Sub redrawClave(ByVal Pic As PictureBox, ByVal text1 As String)
    '    Dim grpDraw As Graphics = Pic.CreateGraphics()

    '    Dim font1 As New Font("Century Gothic", 10, FontStyle.Bold, GraphicsUnit.Point)
    '    Try
    '        Dim rect1 As New Rectangle(0, 0, Pic.Width, Pic.Height)

    '        Dim stringFormat As New StringFormat()
    '        stringFormat.Alignment = StringAlignment.Center
    '        stringFormat.LineAlignment = StringAlignment.Center

    '        grpDraw.DrawString(text1, font1, Brushes.Black, rect1, stringFormat)

    '    Finally
    '        font1.Dispose()
    '    End Try

    'End Sub

#End Region

    Public ReadOnly Property SerialNumber() As String
        Get
            Const query As String = "SerialNumber"
            Try
                Dim moc As System.Management.ManagementObjectCollection = InitManagement()
                If moc IsNot Nothing Then
                    For Each mo As System.Management.ManagementObject In moc
                        If mo.Properties(query).Value.ToString() IsNot Nothing Then
                            Return mo.Properties(query).Value.ToString()
                        Else
                            Return "NR"
                        End If
                    Next
                Else
                    Return "NRR"
                End If
            Catch
            End Try
            Return "ERR"
        End Get
    End Property

    Public Function InitManagement() As System.Management.ManagementObjectCollection
        Try
            Dim query As String = "Select * from Win32_PhysicalMedia"
            Dim mos As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(query)
            Dim moc As System.Management.ManagementObjectCollection = mos.Get()
            Return moc
        Catch
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Function recuperaParametro(ByVal param As String) As Object
        Dim dt As DataTable
        Dim result As Object = Nothing
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)

        For i = 0 To dt.Rows.Count - 1
            Select Case CStr(dt.Rows(i)("PARClave"))
                Case param
                    result = dt.Rows(i)("Valor")
                    Exit For
            End Select
        Next

        dt.Dispose()

        Return result

    End Function


End Module
