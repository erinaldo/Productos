package mx.elephantworks.iselling

class PuntoVenta {

    String numeroNegocio
    String nombreNegocio
    String telefono
    String celular
    String correoElectronico

    String calle
    String noExterior
    String noInterior
    String colonia
    String codigoPostal
    Float latitud
    Float longitud

    /*Configuracion de Puntos de venta
    * estas configuraciones de subiran al movil*/
    Boolean cerrado = false
    Boolean inventario = false
    Boolean impresoraActivo = false
    Boolean activo = true

    static belongsTo = [impresora: ImpresoraHomologadas,
                        pais: Pais,
                        entidad: Entidad,
                        ciudad: Ciudad,
                        empresa: Empresa]


    static constraints = {
        numeroNegocio nullable: false, maxSize: 4
        nombreNegocio nullable: false, blank: false
        calle nullable: false
        noExterior nullable: false
        colonia nullable: false
        codigoPostal nullable: false
        pais nullable: false
        entidad nullable: false
        ciudad nullable: false
        latitud nullable: false
        longitud nullable: false

        noInterior nullable: true
        telefono nullable: true
        celular nullable: true
        correoElectronico nullable: true
        impresora nullable: true

        activo default:true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
    }
}
