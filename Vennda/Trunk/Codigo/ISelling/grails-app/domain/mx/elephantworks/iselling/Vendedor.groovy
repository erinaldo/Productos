package mx.elephantworks.iselling

class Vendedor extends Usuario{

    String nombre
    String apellidoPaterno
    String apellidoMaterno
    Float porcentajeMaxDescuento

    static belongsTo = [empresa:Empresa]

    static hasMany = [categorias:Categoria,
                      impuestos:Impuesto,
                      productos:Producto,
                      unidades:Unidad]

    static constraints = {

        nombre nullable: true
        apellidoPaterno nullable: true
        apellidoMaterno nullable: true
        porcentajeMaxDescuento nullable: false

    }

    Vendedor(String username, String password) {
        super(username, password)
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa2()
    }
}
