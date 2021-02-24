package mx.elephantworks.iselling

class ValoresReferencia {

    String clave
    int valor
    String descripcion

    static constraints = {
        clave maxSize: 10, nullable: false, blank: false
        valor nullable: false, blank: false
        descripcion maxSize: 50, nullable: false, blank: false
    }
}
