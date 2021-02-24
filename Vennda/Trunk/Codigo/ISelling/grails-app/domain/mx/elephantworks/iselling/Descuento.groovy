package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class Descuento {

    String codigo
    @BindUsing({ object, source -> return new BigDecimal(source['porcentajeDescuento']) })
    BigDecimal porcentajeDescuento
    @BindUsing({ object, source -> return new BigDecimal(source['cantidad']) })
    BigDecimal cantidad
    @BindUsing({ object, source -> return new BigDecimal(source['utilidades']) })
    BigDecimal utilidades
    @BindingFormat('dd-mm-yyyy')
    Date vigenciaInicio
    @BindingFormat('dd-mm-yyyy')
    Date vigenciaFin

    static constraints = {
        codigo nullable: false,blank: false,maxSize: 50
        porcentajeDescuento nullable: false,blank: false
        cantidad nullable: false,blank: false
        utilidades nullable: false,blank: false
        vigenciaInicio nullable: false,blank: false
        vigenciaFin nullable: false,blank: false
    }
}
