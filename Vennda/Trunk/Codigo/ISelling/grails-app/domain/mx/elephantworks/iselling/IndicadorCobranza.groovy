package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class IndicadorCobranza {

    String fecha
    @BindUsing({ object, source -> return new BigDecimal(source['efectivo']) })
    BigDecimal efectivo;
    @BindUsing({ object, source -> return new BigDecimal(source['tarjeta']) })
    BigDecimal tarjeta;
    @BindUsing({ object, source -> return new BigDecimal(source['total']) })
    BigDecimal total;
    PuntoVenta puntoVenta

    static constraints = {
    }
}
