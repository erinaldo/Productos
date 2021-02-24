package mx.elephantworks.iselling

class Entidad {

    String nombreEntidad

    static belongsTo = [pais: Pais]
    static constraints = {
        nombreEntidad nullable: false, blank: false
        pais nullable: false
    }
}
