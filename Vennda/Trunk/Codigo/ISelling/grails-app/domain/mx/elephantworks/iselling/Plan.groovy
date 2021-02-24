package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class Plan {
    String identificador
    String idPlanPayu
    @BindingFormat('dd-mm-yyyy')
    Date fechaInicio
    @BindingFormat('dd-mm-yyyy')
    Date fechaFin
    @BindUsing({ object, source -> return new BigDecimal(source['precio']) })
    BigDecimal precio
    Boolean cobroTarjeta
    Boolean impresionTicket
    Boolean inventario
    Boolean autoFactura

    //Otros Datos
    String color
    String descripcion

    static hasMany = [codigo:Descuento]

    static constraints = {
        identificador nullable: false,blank: false,maxSize: 50
        fechaInicio nullable: false,blank:false
        fechaFin nullable: false,blank:false
        precio nullable: false,blank:false
        cobroTarjeta nullable: false
        impresionTicket nullable:false
        inventario nullable: false
        autoFactura nullable: false
        color nullable: true, blank: false
        descripcion nullable: false, blank: false
        idPlanPayu nullable: true
    }
}
