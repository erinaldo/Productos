package mx.elephantworks.iselling

import org.grails.databinding.BindingFormat

class AperturaCierre {

    String usuarioAbre
    @BindingFormat('dd-mm-yyyy')
    Date fechaAbre
    BigDecimal montoAbre
    String usuarioCierra
    @BindingFormat('dd-mm-yyyy')
    Date fechaCierra
    BigDecimal montoCierra

    static constraints = {
        usuarioAbre nullable:false
        fechaAbre nullable: false
        montoAbre nullable: false
        usuarioCierra nullable: true
        fechaCierra nullable: true
        montoCierra nullable: true
    }
}
