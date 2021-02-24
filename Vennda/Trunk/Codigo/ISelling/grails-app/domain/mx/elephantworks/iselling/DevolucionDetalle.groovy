package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class DevolucionDetalle {
    String listaPrecio
    @BindUsing({ object, source -> return new BigDecimal(source['cantidadProducto']) })
    BigDecimal cantidadProducto
    @BindUsing({ object, source -> return new BigDecimal(source['precioUnitario']) })
    BigDecimal precioUnitario
    @BindUsing({ object, source -> return new BigDecimal(source['impuestoUnitario']) })
    BigDecimal impuestoUnitario
    @BindUsing({ object, source -> return new BigDecimal(source['impuestoTotal']) })
    BigDecimal impuestoTotal
    @BindUsing({ object, source -> return new BigDecimal(source['subtotal']) })
    BigDecimal subtotal
    @BindUsing({ object, source -> return new BigDecimal(source['total']) })
    BigDecimal total
    @BindUsing({ object, source -> return new BigDecimal(source['descuento']) })
    BigDecimal descuento
    @BindUsing({ object, source -> return new BigDecimal(source['catidadDevuelta']) })
    BigDecimal catidadDevuelta


    @BindingFormat('dd-mm-yyyy hh:mm:ss')
    Date mFechaHora
    String mUsuario

    static belongsTo = [devolucion: Devolucion,
                        producto: Producto]

    static constraints = {
        //TODO: cambiar a false cuando sea lo del android
        listaPrecio nullable: true
        cantidadProducto nullable:false
        precioUnitario nullable: false
        impuestoUnitario nullable: true
        impuestoTotal nullable:true
        subtotal nullable:false
        total nullable:false
        descuento nullable:false
        //TODO: cambiar a false cuando sea lo del android
        mFechaHora nullable: true
        //TODO: cambiar a false cuando sea lo del android
        mUsuario nullable: true
    }
}
