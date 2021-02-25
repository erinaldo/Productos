Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Net

Public Class TarjetaAmiga
    Public Const Compra As String = "compra"
    Public Const Disposicion As String = "disposicion"
    Public Const Pago As String = "pago"
    Public Const EstadoCuenta As String = "estadoCuenta"
    Public Const Confirmacion As String = "confirmacion"
    Public Const Cancelacion As String = "cancelacion"

    Private proxy As WebClient
    Public urlServicio As String = "https://serviciosdemo.tarjetaamiga.com.mx/WSTransaccion/service/principal/"
    Public referencia As String
    Public idTransaccion As String
    Public plazo As String

    Public Property movimiento As String
    Public Property mensaje As String
    Public Property codigo As Int32
    Public Property idComercio As String
    Public Property empresa As String
    Public Property idTerminal As String
    Public Property nombreTerminal As String
    Public Property clave As String
    Public Property fecha As String
    Public Property hora As String
    Public Property monto As Double
    Public Property tarjeta As String
    Public Property nombre As String
    Public Property disponibleCompra As Double
    Public Property disponibleDisposicion As Double
    Public Property deudaTotal As Double
    Public Property leyenda As String
    Public Property mensajeTicket As String
    Public Property promesas As List(Of Promesas)


    Public Sub New()
        'infTarjetaAmiga = New TarjetaAmiga()
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        Dim i As Integer
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "urlServicioTA"
                        urlServicio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()
    End Sub

    Public Function consulta(ByVal mov As String) As TarjetaAmiga
        proxy = New WebClient()
        proxy.Headers.Add("Accept", "application/json;charset=utf-8")
        proxy.Headers.Add("tarjeta", tarjeta)
        proxy.Headers.Add("monto", monto.ToString())
        proxy.Headers.Add("idComercio", idComercio)
        proxy.Headers.Add("referencia", referencia)
        proxy.Headers.Add("idTerminal", idTerminal)
        proxy.Headers.Add("plazo", plazo)
        proxy.Headers.Add("idTransaccion", idTransaccion)

        Dim result As String = proxy.UploadString(urlServicio + mov, "")

        Return JsonConvert.DeserializeObject(Of TarjetaAmiga)(result)

    End Function

    Public Function ObtenerFolio(ByVal CAJClave As String) As String
        Dim Folio, Periodo, Mes As Integer
        Dim Clave As String
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 6, "@PDVClave", CAJClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 6, "@PDVClave", CAJClave)
            Folio = 1
            Periodo = Today.Year
            Mes = Today.Month
        Else

            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            'ModPOS.Ejecuta("sp_act_folio", "@Tipo", 6, "@PDVClave", CAJClave, "@Incremento", 1)

            dt.Dispose()
        End If

        Clave = "TA" & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)

        Return Clave
    End Function

    Public Function imprimirTicketPago(ByVal Impresora As String, ByVal Generic As Boolean, ByVal mov As String) As Boolean
        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtCompania As DataTable
        dtCompania = ModPOS.SiExisteRecupera("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        Dim encabezado As String = ""
        'Encabezado

        Dim impresiones As Integer = 2
        Select Case mov
            Case TarjetaAmiga.Compra
                encabezado = "CARGO"
            Case TarjetaAmiga.Pago
                encabezado = "ABONO"
            Case TarjetaAmiga.EstadoCuenta
                encabezado = "ESTADO DE CUENTA"
                impresiones = 1
        End Select
        'For i As Integer = 1 To impresiones

        Tickets.AddHeaderLine("*** " & encabezado & " TARJETA AMIGA *** ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine(empresa, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dtCompania.Rows(0)("Nombre"), 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dtCompania.Rows(0)("Calle") & " " & dtCompania.Rows(0)("noExterior"), 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(dtCompania.Rows(0)("Colonia") & ", " & dtCompania.Rows(0)("CodigoPostal") & " " & dtCompania.Rows(0)("Municipio"), 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Fecha: " & fecha & " Hora: " & hora, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Terminal: " & idTerminal & " " & nombreTerminal, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Cliente: " & nombre, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Cuenta: " & tarjeta, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Importe cargado: " & Strings.Format(TruncateToDecimal(monto, 2).ToString, "Currency"), 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("Disponible: " & Strings.Format(TruncateToDecimal(disponibleCompra, 2).ToString, "Currency"), 0, Imprimir.Alinear.Izquierda)
        If mov = TarjetaAmiga.EstadoCuenta Then
            Tickets.AddHeaderLine("Adeudo total: " & Strings.Format(TruncateToDecimal(deudaTotal, 2).ToString, "Currency"), 0, Imprimir.Alinear.Derecha)
        End If
        Tickets.AddHeaderLine("Autorizacion: " & clave, 0, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddHeaderLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddHeaderLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)

        If mov = TarjetaAmiga.Pago Then
            Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
            Tickets.AddFooterLine("FIRMA DEL CAJERO(A)", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        ElseIf mov = TarjetaAmiga.Compra Then
            Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
            Tickets.AddFooterLine("FIRMA DEL CLIENTE", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

            Tickets.AddHeaderLine("   ", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
            Tickets.AddHeaderLine("   ", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
            Tickets.AddHeaderLine("   ", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
            Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
            Tickets.AddFooterLine("NUM DE TELEFONO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        End If

        Tickets.AddHeaderLine("Pagos programados:", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        For Each prom As Promesas In promesas
            Tickets.AddHeaderLine(prom.fecha & " " & Strings.Format(TruncateToDecimal(prom.monto, 2).ToString, "Currency"), 0, Imprimir.Alinear.Izquierda)
        Next

        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine(leyenda, 0, Imprimir.Alinear.Izquierda)

        Tickets.PrintTicket(Impresora, 70, 0)
        'Next
    End Function

End Class


Public Class Promesas
    Public Property fecha As String
    Public Property monto As Double
End Class
