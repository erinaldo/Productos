package mx.elephantworks.iselling

class Ciudad {

    String nombreCiudad

    static belongsTo = [entidad: Entidad]

    static constraints = {
        nombreCiudad nullable: false, blank: false
        entidad nullable: false
    }
}
