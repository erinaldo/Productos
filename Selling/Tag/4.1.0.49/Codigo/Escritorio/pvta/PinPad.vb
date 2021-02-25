Imports EglobalBBVA
Imports System.Text
Imports System.IO

Public Class PinPad
    Public Enum tipoOperacion As Integer
        VentaNormal = 1
        VentaForzada = 901
        VentaPuntos = 18
        DevolucionNormal = 2
        DevolucionForzada = 902
        CancelarVenta = 201
        CancelarDevolucion = 202
        ConsultaPuntos = 16
        PagosEfectivo = 28
        PagoConTarjeta = 40
        MultipagosEfectivo = 59
        MultipagosTarjeta = 50
        CashBackAdvance = 3
        CargarLlaves = 92
    End Enum

    Public Enum tipoPromo As Byte
        SinPromocion = 0
        SinIntereses = 3
        ConIntereses = 5
        PagueDespues = 7
    End Enum

    Public Enum tipoMoneda As Byte
        Pesos = 0
        Dolares = 1
    End Enum

    Public Enum lector As Byte
        Desconocido = 0
        NoTerminal = 2
        BandaMagnetica = 2
        CodigoBarras = 3
        OCR = 4
        BandaChip = 5
        EntradaManual = 6
        BandaManual = 7
        BandaManualChip = 8
        Chip = 9
    End Enum

    Public Enum CVV2 As Byte
        CVV2No = 0
        CVV1Si = 1
    End Enum

    Public Enum EMV As Byte
        PinPadNo = 0
        PinPadSi = 1
    End Enum

    'Variables Request(Envio)
    Public e01Transaccion As String = ""                    '01 (03) Codigo de transaccion
    Public e02Terminal As String = ""                       '02 (08) Numero de terminal
    Public e03Sesion As String = ""                         '03 (04) Numero de sesion
    Public e04Secuencia As String = ""                      '04 (04) Numero secuencia de transaccion
    Public e05Importe As String = ""                        '05 (12) Importe de transaccion
    Public e06Filler As String = StrDup(12, "0")            '06 (12) Filler
    Public e07Folio As String = StrDup(7, "0")              '07 (07) Folio
    Public e08EMV As String = EMV.PinPadSi                  '08 (01) Capacidad EMV
    Public e09Tipo As String = lector.BandaManualChip       '09 (01) Tipo de lector
    Public e10CapCVV2 As String = CVV2.CVV1Si               '10 (01) Capacidad CVV2
    Public e11Pagos As String = "00"                        '11 (02) Meses financiamiento
    Public e12Parciales As String = "00"                    '12 (02) Pagos parcializados
    Public e13Promocion As String = tipoPromo.SinPromocion  '13 (02) Promociones
    Public e14Moneda As String = tipoMoneda.Pesos           '14 (01) Tipo de moneda
    Public e15Autoriza As String = StrDup(6, " ")           '15 (06) Autorizacion
    Public e16Modo As String = StrDup(2, " ")               '16 (02) Modo ingreso tarjeta
    Public e17CVV2 As String = StrDup(4, " ")               '17 (04) CCV2/CVC2
    Public e18TrackII As String = StrDup(40, " ")           '18 (40) Track-II
    Public e19Numero As String = StrDup(3, " ")             '19 (03) Numero secuencial de tarjeta
    Public e20CashBack As String = StrDup(12, "0")          '20 (12) Importe CashBack
    Public e21FechaHora As String = ""                      '21 (12) Fecha Hora
    Public e22Comercio As String = StrDup(45, " ")          '22 (45) Referencia comercio
    Public e23OImporte As String = StrDup(12, "0")          '23 (12) Otro importe
    Public e24Operador As String = ""                       '24 (06) Clave operador
    Public e25Afiliacion As String = ""                     '25 (08) Afiliacion
    Public e26Filler As String = StrDup(4, "0")             '26 (04) Numero de cuarto
    Public e27Referencia As String = ""                     '27 (08) Referencia financiera
    Public e28Filler As String = "0"                        '28 (01) Codigo condicion del chip
    Public e29Filler As String = "000"                      '29 (03) Filler
    Public e30Filler As String = "000"                      '30 (03) Filler
    Public e31MultiPagos As String = "0000"                 '31 (04) Pagos y multipagos
    Public e32Id As String = ""                             '32 (02) Identificador

    'Variables Response (Respuesta)
    Public r01Transaccion As String = ""    '01 (03) Numero transaccion
    Public r02Terminal As String = ""       '02 (08) Numero terminal
    Public r03Sesion As String = ""         '03 (04) Numero sesion
    Public r04Secuencia As String = ""      '04 (04) Numero secuencial
    Public r05Respuesta As String = ""      '05 (02) Codigo respuesta
    Public r06Autoriza As String = ""       '06 (06) Numero autorizacion
    Public r07Afiliacion As String = ""     '07 (08) Afiliacion
    Public r08Filler As String = ""         '08 (12) Filler
    Public r09Importe As String = ""        '09 (12) Importe
    Public r10Filler As String = ""         '10 (12) Filler
    Public r11Tarjeta As String = ""        '11 (16) Tarjeta
    Public r12Operador As String = ""       '12 (06) Clave Operador
    Public r13Filler As String = ""         '13 (04) Filler
    Public r14Folio As String = ""          '14 (07) Folio
    Public r15LLeyenda As String = ""       '15 (02) Longitud Leyenda
    Public r16Leyenda As String = ""        '16 (LL) Leyenda respuesta
    Public r17RefFin As String = ""         '17 (08) Referencia financiera
    Public r18InfInt3 As String = ""        '18 (03) Informacion Interna
    Public r19InfInt255 As String = ""      '19 (HB) Informacion Interna
    Public r20LPuntos As String = ""        '20 (03) Mensaje para puntos
    Public r21DatPuntos As String = ""      '21 (VV) Datos de puntos
    Public r22Registro1 As String = ""      '22 (36) Datos de registro 1
    Public r23LMACADDR As String = ""       '23 (02) Longitud de MACADDR
    Public r24Registro2 As String = ""      '24 (36) Datos registro 2
    Public r25Registro3 As String = ""      '25 (36) Datos registro 3
    Public r26Registro4 As String = ""      '26 (36) Datos registro 4
    Public r27LMultipagos As String = ""    '27 (04) Longitud Pagos y Multipagos
    Public r28DMultipagos As String = ""    '28 (VV) Datos Pagos y Multipagos


    Public miPinPad As PinPadSC

    Public Sub New()
        miPinPad = New PinPadSC()
        miPinPad.SincronicacionInicial()
        r16Leyenda = miPinPad.Response
    End Sub

    Public Sub ImprimirTicket(ByVal Impresora As String, ByVal Generic As Boolean, ByVal VENClave As String)
        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_encabezado_venta", "@VENClave", VENClave)
        Dim encabezado As String = ""

        Tickets.AddHeaderLine("BBVA Bancomer", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(" ", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine(dt.Rows(0)("NomComercial"), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("Nombre"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("oDomicilio"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("oDomicilio2"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("id_fiscal"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("RegimenFiscal"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(" ", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("SUCURSAL " & dt.Rows(0)("sClave"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(dt.Rows(0)("sNombre"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dt.Rows(0)("sDomicilio"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dt.Rows(0)("sDomicilio2"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Fecha: " & Date.Now.ToShortDateString() & " Hora: " & Date.Now.ToShortTimeString(), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        Tickets.AddHeaderLine("CTE: " & dt.Rows(0)("Cliente"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dt.Rows(0)("RazonSocial"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("** TARJETA DECLINADA **", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(miPinPad.NombreAplicacion, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(miPinPad.NombreCliente, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("**** **** **** " & Mid(miPinPad.NumeroTarjeta, 13, 4), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Motivo: " & r16Leyenda, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.PrintTicket(Impresora, 70, 0)
    End Sub

    Public Function leerArchivo() As Boolean
        Dim El_Archivo As String
        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()
        El_Archivo = dir & "\PinpadConfig.txt"
        Try
            Dim lector As StreamReader = File.OpenText(El_Archivo)

            Do While lector.Peek() >= 0
                dir = lector.ReadLine
                If Mid(dir, 1, 8) = "TERMINAL" Then
                    e02Terminal = Mid(dir, 10, 8)
                ElseIf Mid(dir, 1, 10) = "CARGALLAVE" Then
                    lector.Close()
                    lector.Dispose()
                    Return IIf(Mid(dir, 12, 1) = "1", True, False)
                End If
            Loop
            lector.Close()
            lector.Dispose()
        Catch ex As Exception
            Return False
        End Try
        Return False

    End Function

    Public Function modificarPinPadConfig()
        Dim El_Archivo As String
        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()
        El_Archivo = dir & "\PinpadConfig.txt"
        Dim archivoCopia As String = dir & "\PinpadConfig1.txt"
        Try
            Dim lector As StreamReader = File.OpenText(El_Archivo)

            Do While lector.Peek() >= 0
                dir = lector.ReadLine

                Dim escritor As StreamWriter = File.AppendText(archivoCopia)
                If dir.Contains("CARGALLAVE:") Then
                    dir = dir.Replace("1", "0")
                End If
                escritor.WriteLine(dir)
                escritor.Flush()
                escritor.Close()
                escritor.Dispose()
            Loop
            lector.Close()
            lector.Dispose()
            File.Delete(El_Archivo)
            FileSystem.Rename(archivoCopia, El_Archivo)
        Catch ex As Exception

        End Try
    End Function

    Public Function crearArchivo() As Boolean
        Dim El_Archivo As String

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()
        Dim escritor As StreamWriter
        pathActual = dir & "\"

        El_Archivo = dir & "\ConcentradoCar.txt"
        If Not IO.File.Exists(El_Archivo) Then
            IO.File.Create(El_Archivo)
        End If


        El_Archivo = dir & "\CardTipo.txt"
        If Not IO.File.Exists(El_Archivo) Then
            'IO.File.Create(El_Archivo)
            escritor = File.AppendText(El_Archivo)
            escritor.WriteLine("CardTipo:1")
            escritor.WriteLine("CONCENTRADOCARD:0")
            escritor.Flush()
            escritor.Close()
            MessageBox.Show("Verificar el archivo de CardTipo " & El_Archivo, "PinPad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        El_Archivo = dir & "\PinpadConfig.txt"
        If Not IO.File.Exists(El_Archivo) Then
            escritor = File.AppendText(El_Archivo)
            escritor.WriteLine("IPHOST:127.0.0.1")
            escritor.WriteLine("SOCKETHOST:7392")
            escritor.WriteLine("PINPADTIMEOUT:40")
            escritor.WriteLine("NOMBREPUERTO: COM9")
            escritor.WriteLine("PINPADID:00000152")
            escritor.WriteLine("AFILIACION:00000000")
            escritor.WriteLine("TERMINAL:00000000")
            escritor.WriteLine("TIMEOUTHOST:40")
            escritor.WriteLine("NOMBRECOMERCIO: CKLASS")
            escritor.WriteLine("HEADERCONSECUTIVO:56")
            escritor.WriteLine("FOLIO:1")
            escritor.WriteLine("LOG:1")
            escritor.WriteLine("DIRUSERDB:")
            escritor.WriteLine("BINESCOMERCIO:")
            escritor.WriteLine("SESIONABRIR:0")
            escritor.WriteLine("CARGALLAVE:0")
            escritor.WriteLine("IMPRESIOND:")
            escritor.WriteLine("ACTUALIZACION:0")
            escritor.WriteLine("DIRACTPINPAD:C:\APLICATIVOPINPAD")
            escritor.WriteLine("CONAUX:0")
            escritor.WriteLine("CASH:0")
            escritor.WriteLine("TLS12:0")
            escritor.WriteLine("QPS:0")
            escritor.Flush()
            escritor.Close()
            escritor.Dispose()
            MessageBox.Show("Verificar el archivo de configuracion " & El_Archivo, "PinPad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        El_Archivo = dir & "\bines.txt"
        If Not IO.File.Exists(El_Archivo) Then
            IO.File.Create(El_Archivo)
        End If

        

        El_Archivo = dir & "\Promociones.txt"
        If Not IO.File.Exists(El_Archivo) Then
            IO.File.Create(El_Archivo)
        End If
        Return True

    End Function

    Public Function formatoImporte(ByVal importe As Double) As String
        Dim resultado As String = ""
        resultado = Format(Fix(importe), StrDup(10, "0")) & Format((importe - Fix(importe)) * 100, "00")
        Return resultado
    End Function

    Public Function Enviar() As PinPadSC
        Dim req As String = ""
        req += Format(Val(e01Transaccion), "000")
        req += Left(e02Terminal, 8).PadLeft(8, "0"c)
        req += Left(e03Sesion, 4).PadLeft(4, "0"c)
        req += Left(e04Secuencia, 4).PadLeft(4, "0"c)
        req += e05Importe
        req += e06Filler
        req += e07Folio
        req += "3" 'e08EMV
        req += e09Tipo
        req += e10CapCVV2
        req += Format(e11Pagos, "00")
        req += Format(e12Parciales, "00")
        req += Format(e13Promocion, "00")
        req += e14Moneda
        req += Left(e15Autoriza, 6).PadLeft(6, " "c)
        req += e16Modo
        req += e17CVV2
        req += e18TrackII
        req += e19Numero
        req += e20CashBack
        req += e21FechaHora
        req += e22Comercio
        req += e23OImporte
        req += Left(e24Operador, 6).PadLeft(6, " "c)
        req += Left(e25Afiliacion, 8).PadLeft(8, "0"c)
        req += e26Filler
        req += Format(Val(e27Referencia), StrDup(8, "0"))
        req += e28Filler
        req += e29Filler
        req += e30Filler
        req += e31MultiPagos
        req += e32Id

        miPinPad.fncEglobalBBVA(req, 0, "")
        Return miPinPad
    End Function

    Public Sub Recibir()
        r01Transaccion = Mid(miPinPad.Response, 1, 3)
        r02Terminal = Mid(miPinPad.Response, 4, 8)
        r03Sesion = Mid(miPinPad.Response, 12, 4)
        r04Secuencia = Mid(miPinPad.Response, 16, 4)
        r05Respuesta = Mid(miPinPad.Response, 20, 2)
        r06Autoriza = Mid(miPinPad.Response, 22, 6)
        r07Afiliacion = Mid(miPinPad.Response, 28, 8)
        r08Filler = Mid(miPinPad.Response, 36, 12)
        r09Importe = Mid(miPinPad.Response, 48, 12)
        r10Filler = Mid(miPinPad.Response, 60, 12)
        r11Tarjeta = Mid(miPinPad.Response, 72, 12)
        r12Operador = Mid(miPinPad.Response, 88, 6)
        r13Filler = Mid(miPinPad.Response, 94, 4)
        r14Folio = Mid(miPinPad.Response, 98, 7)
        r15LLeyenda = Mid(miPinPad.Response, 105, 2)
        r16Leyenda = Mid(miPinPad.Response, 107, Val(r15LLeyenda))
        Dim pos As Integer = 107 + Val(r15LLeyenda)
        r17RefFin = Mid(miPinPad.Response, pos, 8)
        r18InfInt3 = Mid(miPinPad.Response, pos + 8, 3)
        r19InfInt255 = Mid(miPinPad.Response, pos + 8 + 3, Val(r18InfInt3))
        Dim pos2 As Integer = pos + 8 + 3 + Val(r18InfInt3)
        r20LPuntos = Mid(miPinPad.Response, pos2, 3)
        Dim puntos As Integer = Val(r20LPuntos)
        r21DatPuntos = Mid(miPinPad.Response, pos2 + 3, puntos)
    End Sub

    Public Function imprimirPagare(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim Tickets As Imprimir = New Imprimir
        Tickets.Generic = Generic




        'ModPOS.ImprimirRecibo()

    End Function

End Class
