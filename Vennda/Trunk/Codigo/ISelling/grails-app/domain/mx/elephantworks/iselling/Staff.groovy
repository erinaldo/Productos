package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class Staff {

    String numEmpleado
    String nombre
    String apellidos
    String pin
    String email
    boolean activo = true
    boolean autorizaCancelacion
    @BindUsing({ object, source -> return new BigDecimal(source['porcentajeDescuento']) })
    BigDecimal porcentajeDescuento

    static belongsTo = [empresa:Empresa]

    static constraints = {
        numEmpleado nullable:false,blank:false,maxSize: 20
        nombre nullable:false, blank:false, maxSize: 100
        apellidos nullable:false, blank:false, maxSize: 100
        pin nullable:false, blank:false, maxSize: 4
        email nullable:false, blank:false,maxSize: 250
        activo nullable:true
        autorizaCancelacion nullable:true
        porcentajeDescuento nullable:true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()


    }

    def beforeDelete() {
        Staff.executeUpdate("update Staff c set activo = false where id = :id", [id: id])
        return false
    }


}
