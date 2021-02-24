package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class IndicadorCreditoVencidas {

    int mes
    @BindUsing({ object, source -> return new BigDecimal(source['efectivo']) })
    BigDecimal credito;
    @BindUsing({ object, source -> return new BigDecimal(source['tarjeta']) })
    BigDecimal vencidas;
    PuntoVenta puntoVenta

    static constraints = {
    }
}
