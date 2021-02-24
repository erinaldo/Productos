package mx.elephantworks.iselling

class Empresa extends Usuario{

    //Datos de la empresa
    String nombreEmpresa
    String direccion
    String cp
    String colonia
    String rfc

    //Datos del dueño
    String nombre
    String apellidoPaterno
    String apellidoMaterno
    String curp
    String pin
    int formaPago //1 = recurrente y 2 = efectivo
    String logo

    //ID PAYU
    //String idClientePAYU
    //String idSubscripcionPAYU
    //String tokenTarjetaPAYU
    String idTransaccionPAYU
    String urlPagoEfectivoPAYU

    Boolean activo = false
    int actualizaImgProductos = 0
    int actualizaImgCategorias = 0


    static hasOne = [tipoCuenta:TipoCuenta]

    static hasMany = [categorias:Categoria,
                      productos:Producto]

    static belongsTo = [pais: Pais,
                        entidad: Entidad,
                        ciudad: Ciudad,
                        plan: Plan]

    static constraints = {

        nombreEmpresa nullable: false

        tipoCuenta nullable: true
        direccion nullable: true
        cp nullable: true
        colonia nullable: true
        pais nullable: true
        entidad nullable: true
        ciudad nullable: true
        rfc nullable: true
        nombre nullable: true
        apellidoPaterno nullable: true
        apellidoMaterno nullable: true
        curp nullable: true
        pin nullable: true, maxSize: 4, minSize: 4
        plan nullable: true
        formaPago nullable: true
        logo nullable: true
        //idClientePAYU nullable: true
        //idSubscripcionPAYU nullable: true
        //tokenTarjetaPAYU nullable: true
        idTransaccionPAYU nullable: true
        urlPagoEfectivoPAYU nullable: true
        actualizaImgProductos nullable: false
        actualizaImgCategorias nullable: false
    }

    Empresa(String username, String password) {
        super(username, password)
    }
}
