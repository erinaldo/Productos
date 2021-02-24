package mx.elephantworks.iselling


import org.grails.databinding.BindUsing

class ImpuestoDetalle {

    @BindUsing({ object, source -> return new BigDecimal(source['precioBase']) })
    BigDecimal precioBase;
    @BindUsing({ object, source -> return new BigDecimal(source['tasa']) })
    BigDecimal tasa;
    @BindUsing({ object, source -> return new BigDecimal(source['importe']) })
    BigDecimal importe;

    static belongsTo = [ventaDetalle:VentaDetalle]

    static constraints = {
        precioBase nullable: true
        tasa nullable: true
        importe nullable: true
    }
}
