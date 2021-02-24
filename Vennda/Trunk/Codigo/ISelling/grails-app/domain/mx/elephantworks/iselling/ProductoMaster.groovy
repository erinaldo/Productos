package mx.elephantworks.iselling

class ProductoMaster {
    String codigoBarras
    String nombre
    String descripcion

    static constraints = {
        codigoBarras nullable: false, blank: false, unique: true
        nombre nullable: false, blank: false
        descripcion nullable: false, blank: false
    }
}
