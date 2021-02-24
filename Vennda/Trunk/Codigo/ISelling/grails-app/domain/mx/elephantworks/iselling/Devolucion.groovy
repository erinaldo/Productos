package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class Devolucion {

    int tipo // si es acredito = 2 o contado = 1
    int formaPago
    @BindingFormat('dd-mm-yyyy hh:mm:ss')
    Date fechaCreacion
    String folio
    String motivo
    @BindUsing({ object, source -> return new BigDecimal(source['subtotal']) })
    BigDecimal subtotal
    @BindUsing({ object, source -> return new BigDecimal(source['impuestos']) })
    BigDecimal impuestos
    @BindUsing({ object, source -> return new BigDecimal(source['total']) })
    BigDecimal total
    @BindUsing({ object, source -> return new BigDecimal(source['saldo']) })
    BigDecimal saldo
    @BindUsing({ object, source -> return new BigDecimal(source['descuento']) })
    BigDecimal descuento


    static belongsTo = [staff:Staff,
                        cliente: Cliente,
                        puntoVenta: PuntoVenta,
                        venta: Venta,
                        empresa: Empresa]

    static constraints = {
        tipo nullable:false
        fechaCreacion nullable:false
        folio nullable: false,maxSize: 20
        subtotal nullable: false
        impuestos nullable: false
        total nullable:false
        descuento nullable: true
    }
}
