package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class Inventario {

    @BindUsing({ object, source -> return new BigDecimal(source['cantidad']) })
    BigDecimal cantidad
    boolean activo = true

    static belongsTo = [empresa: Empresa,
                        puntoVenta: PuntoVenta,
                        producto: Producto]

    static constraints = {
        cantidad nullable: false
        empresa nullable: false
        puntoVenta nullable: false
        producto nullable: false
        activo default:true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
        filtroPuntoVenta { PuntoVenta puntoVenta ->
            eq 'puntoVenta', puntoVenta
        }
    }
}
