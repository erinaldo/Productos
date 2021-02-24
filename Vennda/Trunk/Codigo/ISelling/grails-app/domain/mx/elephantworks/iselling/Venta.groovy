package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class Venta {

    int tipo // si es acredito = 2 o contado = 1
    int formaPago
    @BindingFormat('dd-mm-yyyy hh:mm:ss')
    Date fechaCreacion
    String folio
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
    @BindUsing({ object, source -> return new BigDecimal(source['recibido']) })
    BigDecimal recibido
    @BindUsing({ object, source -> return new BigDecimal(source['cambio']) })
    BigDecimal cambio

    //Datos Cancelacion
    @BindingFormat('dd-mm-yyyy hh:mm:ss')
    Date fechaCancelacion
    String motivoCancelacion

    //Datos ventas credito
    @BindingFormat('dd-mm-yyyy hh:mm:ss')
    Date fechaVencimiento

    static mapping = {
        id generator: 'assigned'
    }


    static belongsTo = [staff:Staff,
                        staffCancelacion: Staff,
                        cliente: Cliente,
                        puntoVenta: PuntoVenta,
                        empresa: Empresa]

    static constraints = {
        tipo nullable:false
        fechaCreacion nullable:false
        folio nullable: false,maxSize: 20
        subtotal nullable: false
        impuestos nullable: false
        total nullable:false
        //TODO: cambiar a false cuando sea lo del android
        cliente nullable: true

        fechaVencimiento nullable: true
        fechaCancelacion nullable: true
        motivoCancelacion nullable: true, blank: false
        staffCancelacion nullable: true
        descuento nullable: true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
        saldo {gt 'saldo', 0.0}
    }
}
