package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class Abono {

    int metodoPago
    String referencia
    @BindUsing({ object, source -> return new BigDecimal(source['monto']) })
    BigDecimal monto

    static constraints = {
        metodoPago nullable: false
        referencia nullable:true
        monto nullable:false
    }
}
