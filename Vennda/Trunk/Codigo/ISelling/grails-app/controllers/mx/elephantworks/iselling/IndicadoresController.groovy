package mx.elephantworks.iselling

import grails.converters.JSON
import groovy.sql.Sql
import org.codehaus.groovy.grails.commons.GrailsApplication
import sun.jdbc.odbc.ee.DataSource

import java.text.SimpleDateFormat

class IndicadoresController {
    def springSecurityService, indicadoresService

    def index()
    {
        respond Venta.list(params)
    }

    //Total de Venta Diaria
    def TotalVentaDiaria(String id,String fechaInicio,String fechaFin) {
        //Esta grafica se genera con tres lineas una linea represetna la sumatoria
        // del total de ventas si importar si fueron credito o contado, otra linea
        // representa unicamente la sumatoria del total de ventas a credito y otra
        // linea uniamente la sumatoria del total de las ventas de contado.
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        if(id.equals("0")){

            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Primera linea: sumatoria del total de ventas sin importar si fueron credito o contado.
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            //def resultsTransaccion = Venta.findAllByPuntoVentaAndFechaCreacionBetween(puntoVenta,dateInicio,dateFin)
            def resultsTransaccion = indicadoresService.ventasCreditoContado(puntoVenta, dateInicio,dateFin.plus(1))

            def columns = []
            columns << [label: "Fecha", type: 'string']
            columns << [label: "Total de Ventas crédito y contado", type: 'number']
            columns << [label: "Ventas contado", type: 'number']
            columns << [label: "Ventas crédito", type: 'number']

            def rows = []
            def cells

            for(int x = 0; x < resultsTransaccion.size(); x++) {
                cells = []
                cells << [v: resultsTransaccion[x][0].toString()] << [v: resultsTransaccion[x][1]] << [v:resultsTransaccion[x][2]] << [v:resultsTransaccion[x][3]]
                rows << ['c':cells]
            }



            def table = [cols: columns, rows: rows]
            render table as JSON
        }else {
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            long idLng = Long.parseLong(id);

            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance,idLng)
            //def resultsTransaccion = Venta.findAllByPuntoVentaAndFechaCreacionBetween(puntoVenta, dateInicio, dateFin)
            def resultsTransaccion = indicadoresService.ventasCreditoContado(puntoVenta, dateInicio,dateFin)


            def columns = []
            columns << [label: "Fecha", type: 'string']
            columns << [label: "Total de Ventas crédito y contado", type: 'number']
            columns << [label: "Ventas contado", type: 'number']
            columns << [label: "Ventas crédito", type: 'number']

            def rows = []
            def cells

            for(int x = 0; x < resultsTransaccion.size(); x++) {
                cells = []
                cells << [v: resultsTransaccion[x][0].toString()] << [v: resultsTransaccion[x][1]] << [v:resultsTransaccion[x][2]] << [v:resultsTransaccion[x][3]]
                rows << ['c':cells]
            }


            def table = [cols: columns, rows: rows]
            render table as JSON
        }

    }

    //TOP 5
    def productosMasVendidos(String id,String fechaInicio, String fechaFin){
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        if(id.equals("0")){
            def columns = []
            columns << [label: "Columna1", type: "string"]
            columns << [label: "Productos más vendidos", type: 'number']
            columns << [type: "string", role: 'style']

            def rows = []
            def cells

            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)

            ArrayList<VentaDetalle> arrayVentaDetalle = new ArrayList<VentaDetalle>()
            ArrayList<String> arrayProductos = new ArrayList<String>()

            def contadorProductos = 0
            //Los productos que se repitan mas en las transacciones
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            def ventasDetalle = Venta.executeQuery("select vd.producto.nombre,sum(vd.cantidadProducto) from Venta v, VentaDetalle vd   where v.puntoVenta=:pvVar and vd.venta=v and v.fechaCreacion between :varInicio and :varFin group by vd.producto order by sum(vd.cantidadProducto) desc", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin.plus(1)])
            ventasDetalle.each {
                def cadenaColor = getRandomColor()
                cells = []
                cells << [v: it[0].toString()] << [v: it[1]] << [v:'color:' + cadenaColor]
                rows << ['c': cells]

            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }else {

            def columns = []
            columns << [label: "Columna1", type: "string"]
            columns << [label: "Productos más vendidos", type: 'number']
            columns << [type: "string", role: 'style']

            def rows = []
            def cells

            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)

            ArrayList<VentaDetalle> arrayVentaDetalle = new ArrayList<VentaDetalle>()
            ArrayList<String> arrayProductos = new ArrayList<String>()

            def contadorProductos = 0
            //Los productos que se repitan mas en las transacciones
            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance, id as Long)
            def ventasDetalle = Venta.executeQuery("select vd.producto.nombre,sum(vd.cantidadProducto) from Venta v, VentaDetalle vd   where v.puntoVenta=:pvVar and vd.venta=v and v.fechaCreacion between :varInicio and :varFin group by vd.producto order by sum(vd.cantidadProducto) desc", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin])
            ventasDetalle.each {
                def cadenaColor = getRandomColor()
                cells = []
                cells << [v: it[0].toString()] << [v: it[1]] << [v:'color:' + cadenaColor]
                rows << ['c': cells]

            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }

    }

    //Ventas por POS
    def VentasPorPOS(String id,String fechaInicio, String fechaFin) {
        if (id.equals("0")) {
            def columns = []
            columns << [label: "Ventas por POS", type: "string"]
            columns << [label: "Unidades", type: 'number']
            columns << [label: "Importe", type: 'number']

            def rows = []
            def cells

            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            def cantidadVentaTotal = Venta.executeQuery("select v.puntoVenta.nombreNegocio,sum(vd.cantidadProducto),sum(v.total) from Venta v, VentaDetalle vd   where v.puntoVenta=:pvVar and vd.venta=v and v.fechaCreacion between :varInicio and :varFin group by v.puntoVenta", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin.plus(1)])

            if (cantidadVentaTotal.size() == 0) {
                cells = []
                cells << [v: puntoVenta.nombreNegocio.toString()] << [v: 0] << [v: 0]
                rows << ['c': cells]
            } else {
                cantidadVentaTotal.each {
                    cells = []
                    cells << [v: it[0].toString()] << [v: it[1]] << [v: it[2]]
                    rows << ['c': cells]
                }
            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }else{
            def columns = []
            columns << [label: "Ventas por POS", type: "string"]
            columns << [label: "Unidades", type: 'number']
            columns << [label: "Importe", type: 'number']

            def rows = []
            def cells

            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            //PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresaAndId(empresaInstance).first()
            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance, id as Long)
            def cantidadVentaTotal = Venta.executeQuery("select v.puntoVenta.nombreNegocio,sum(vd.cantidadProducto),sum(v.total) from Venta v, VentaDetalle vd   where v.puntoVenta=:pvVar and vd.venta=v and v.fechaCreacion between :varInicio and :varFin group by v.puntoVenta", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin])

            if (cantidadVentaTotal.size() == 0) {
                cells = []
                cells << [v: puntoVenta.nombreNegocio.toString()] << [v: 0] << [v: 0]
                rows << ['c': cells]
            } else {
                cantidadVentaTotal.each {
                    cells = []
                    cells << [v: it[0].toString()] << [v: it[1]] << [v: it[2]]
                    rows << ['c': cells]
                }
            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }
    }

    //Ventas por Vendedor
    def VentasPorVendedor(String id,String fechaInicio, String fechaFin) {
        if (id.equals("0")) {
            def columns = []
            columns << [label: "Ventas por Vendedor", type: "string"]
            columns << [label: "Unidades", type: 'number']
            columns << [label: "Importe", type: 'number']

            def rows = []
            def cells

            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            //def cantidadVentaTotal = Venta.executeQuery("select v.puntoVenta.nombreNegocio,sum(vd.cantidadProducto),sum(v.total) from Venta v, VentaDetalle vd   where v.puntoVenta=:pvVar and vd.venta=v and v.fechaCreacion between :varInicio and :varFin group by v.puntoVenta", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin])
            def cantidadVentaTotal = Venta.executeQuery("select s.nombre,sum(vd.cantidadProducto),sum(v.total) from Venta v, Staff s, VentaDetalle  vd where v.puntoVenta=:pvVar and v.staff=s and vd.venta=v and  v.fechaCreacion between :varInicio and :varFin group by v.staff", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin.plus(1)])

            if (cantidadVentaTotal.size() == 0) {
                cells = []
                cells << [v: puntoVenta.nombreNegocio.toString()] << [v: 0] << [v: 0]
                rows << ['c': cells]
            } else {
                cantidadVentaTotal.each {
                    cells = []
                    cells << [v: it[0].toString()] << [v: it[1]] << [v: it[2]]
                    rows << ['c': cells]
                }
            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }else{
            def columns = []
            columns << [label: "Ventas por Vendedor", type: "string"]
            columns << [label: "Unidades", type: 'number']
            columns << [label: "Importe", type: 'number']

            def rows = []
            def cells

            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            //PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresaAndId(empresaInstance).first()
            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance, id as Long)
            def cantidadVentaTotal = Venta.executeQuery("select s.nombre,sum(vd.cantidadProducto),sum(v.total) from Venta v, Staff s, VentaDetalle  vd where v.puntoVenta=:pvVar and v.staff=s and vd.venta=v and  v.fechaCreacion between :varInicio and :varFin group by v.staff", [pvVar: puntoVenta, varInicio: dateInicio, varFin: dateFin])

            if (cantidadVentaTotal.size() == 0) {
                cells = []
                cells << [v: puntoVenta.nombreNegocio.toString()] << [v: 0] << [v: 0]
                rows << ['c': cells]
            } else {
                cantidadVentaTotal.each {
                    cells = []
                    cells << [v: it[0].toString()] << [v: it[1]] << [v: it[2]]
                    rows << ['c': cells]
                }
            }

            def table = [cols: columns, rows: rows]
            render table as JSON
        }
    }

    //Total de cobranza diaria por tipo de pago
    def TotalDeCobranzaDiariaPorTipoDePago(String id,String fechaInicio, String fechaFin){
        /*
         Grafica de Combo, donde la linea representa la suma de todos los abonos
         sin importar si fueron efectivo o tarjeta y Por cada dia mostraran dos
         barras una la sumatoria de todos los pagos  que se realizaron en Efectivo
         y otra  mostrara la suma de todos los pagos que se realizaron con Tarjeta.
         */
        def columns = []
        columns << [label: "Fecha de abono", type: "string"]
        columns << [label: "Efectivo", type: 'number']
        columns << [label: "Credito", type: 'number']
        columns << [label: "Total", type: 'number']

        def rows = []

        if (id.equals("0")) {


            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            def datos = indicadoresService.obtenerTotalesAbonos(puntoVenta, dateInicio,dateFin.plus(1))

            datos.each {
                def cells = []
                cells << [v: it.fecha] << [v: it.efectivo] << [v: it.tarjeta] << [v: it.total]
                rows << ['c': cells]
            }


        }else{

            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateInicio = sdf.parse(fechaInicio)
            Date dateFin = sdf.parse(fechaFin)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance, id as Long)
            def abonos = indicadoresService.obtenerTotalesAbonos(puntoVenta, dateInicio,dateFin)

            abonos.each {
                def cells = []
                cells << [v: it.fecha] << [v: it.efectivo] << [v: it.tarjeta] << [v: it.total]
                rows << ['c': cells]
            }
        }

        def table = [cols: columns, rows: rows]
        render table as JSON
    }

    //Total de cobranza diaria por tipo de pago
    def TotalCobranzaVencida(String id,String fechaInicio, String fechaFin){
        /*
         Grafica de Area, Esta grafica no depende de los rangos de fecha seleccionados:
          Es una grafica de Area donde el Area representa el Saldo de todas las ventas
          a credito (lo que se debe desde el origen de los tiempos a la fecha actual)
          y la segunda area representa el saldo de las ventas a credito pero cuya
          fecha de vencimiento es menor o igual a la fecha actual (lo vencido)
         */
        def columns = []
        columns << [label: "Mes", type: "string"]
        columns << [label: "Credito", type: 'number']
        columns << [label: "Saldo vencido", type: 'number']

        def rows = []

        if (id.equals("0")) {
            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateFin = sdf.parse(fechaFin)
            Calendar calendario = Calendar.getInstance()
            calendario.setTime(dateFin)
            calendario.add(Calendar.DAY_OF_YEAR, -90)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()

            def datos = indicadoresService.obtenerVentasCreditoYVencidas(puntoVenta, calendario.getTime(),dateFin.plus(1))

            datos.each {
                def cells = []
                cells << [v: it.mes] << [v: it.credito] << [v: it.vencidas]
                rows << ['c': cells]
            }

        }else{
            Empresa empresaInstance = springSecurityService.getCurrentUser()
            SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy")

            Date dateFin = sdf.parse(fechaFin)
            Calendar calendario = Calendar.getInstance()
            calendario.setTime(dateFin)
            calendario.add(Calendar.DAY_OF_YEAR, -90)
            //Obtener el total de las ventas
            PuntoVenta puntoVenta = PuntoVenta.findByEmpresaAndId(empresaInstance, id as Long)
            def datos = indicadoresService.obtenerVentasCreditoYVencidas(puntoVenta, calendario.getTime(),dateFin.plus(1))

            datos.each {
                def cells = []
                cells << [v: it.mes] << [v: it.credito] << [v: it.vencidas]
                rows << ['c': cells]
            }

        }

        def table = [cols: columns, rows: rows]
        render table as JSON
    }

    //Obtener diferentes colores para barChart
    public String getRandomColor() {
        String[] letters = ["0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F"]
        String color = "#"
        for(int i = 0; i < 6; i++ ) {
            color += letters[(int) Math.round(Math.random() * 15)];
        }
        return color;
    }
}
