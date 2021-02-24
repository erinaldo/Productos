import mx.elephantworks.iselling.Abono
import mx.elephantworks.iselling.Categoria
import mx.elephantworks.iselling.Impuesto
import mx.elephantworks.iselling.Producto
import mx.elephantworks.iselling.Rol
import mx.elephantworks.iselling.Staff
import mx.elephantworks.iselling.TipoAplicacion
import mx.elephantworks.iselling.TipoCuenta
import mx.elephantworks.iselling.ValoresImpuesto
import mx.elephantworks.iselling.Venta
import mx.elephantworks.iselling.Unidad
import mx.elephantworks.iselling.Usuario
import mx.elephantworks.iselling.Empresa
import mx.elephantworks.iselling.UsuarioRol
import mx.elephantworks.iselling.ProductoMaster
import mx.elephantworks.iselling.Pais
import mx.elephantworks.iselling.Entidad
import mx.elephantworks.iselling.Ciudad
import mx.elephantworks.iselling.ImpresoraHomologadas
import mx.elephantworks.iselling.PuntoVenta
import mx.elephantworks.iselling.Cliente
import mx.elephantworks.iselling.Cobranza
import mx.elephantworks.iselling.Plan
import mx.elephantworks.iselling.ValoresReferencia
import mx.elephantworks.iselling.VentaDetalle

class BootStrap {
    def payuService

    def init = { servletContext ->

        def rolAdmin, rolEmpresa, rolVendedor
        def usuarioAdmin, usuarioEmpresa, usuarioEmpresa2
        def tipoImpuesto1, tipoImpuesto2
        def impuesto12, impuesto22
        def impuesto1, impuesto2
        def unidad1, unidad2
        def producto1, producto2,producto3,producto4,producto5,producto6
        def categoria1, categoria2, categoria3, categoria4, categoria5
        def cliente1, cliente2
        def cobranza1,cobranza2,cobranza3
        def puntoVenta1, puntoVenta2
        def plan1, plan2
        def transaccion1,transaccion2,transaccion3,transaccion4,transaccion5,transaccion6,transaccion7,transaccion8,transaccion9,transaccion10
        def ventaDetalle1,ventaDetalle2,ventaDetalle3,ventaDetalle4,ventaDetalle5,ventaDetalle6,ventaDetalle7,ventaDetalle8,ventaDetalle9,ventaDetalle10
        def staff1

        if(Rol.count() <= 0) {
            rolAdmin =  new Rol(authority: 'ROLE_SUPERADMIN').save(flush: true , failOnError: true)
            rolEmpresa =  new Rol(authority: 'ROLE_EMPRESA').save(flush: true , failOnError: true)
        }

        if(Plan.count() <= 0){

            plan1 = new Plan(identificador: 'FREE', fechaInicio:  new Date(), fechaFin: '31-12-9999', precio: 0.0, descripcion: 'ninguna', color: '#20B2AA', cobroTarjeta: false, impresionTicket: false, inventario: false, autoFactura: false).save(flush: true, failOnError: true)
            plan2 = new Plan(identificador: 'PREMIUM', fechaInicio:  new Date(), fechaFin: '31-12-9999', precio: 250.0, descripcion: 'ninguna', color: '#6495ED', cobroTarjeta: false, impresionTicket: false, inventario: false, autoFactura: false).save(flush: true, failOnError: true)
            // payuService.crearPlanPAYU(plan2)
        }

        if(Usuario.count() <= 0) {
            usuarioAdmin = new Usuario(
                    username: 'admin',
                    email:'a@a.com',
                    password: 'admin',
                    enabled: true,
                    accountExpired: false,
                    accountLocked: false,
                    passwordExpired: false
            )
            usuarioAdmin.save(flush: true , failOnError: true)

            usuarioEmpresa = new Empresa(
                    username: 'empresa',
                    email:'b@a.com',
                    rfc:'asdasfasf',
                    nombreEmpresa:'HAMG',
                    nombre: 'Luis',
                    apellidoPaterno: 'de la Torre',
                    apellidoMaterno: 'Flores',
                    password: 'empresa',
                    enabled: true,
                    accountExpired: false,
                    accountLocked: false,
                    passwordExpired: false,
                    plan: plan1
            ).save(flush: true , failOnError: true)
            usuarioEmpresa2 = new Empresa(
                    username: 'empresa2',
                    email:'c@d.com',
                    rfc:'asdasfasf2',
                    nombreEmpresa:'HAMG2',
                    nombre: 'Johana',
                    apellidoPaterno: 'Esqueda',
                    apellidoMaterno: 'Garcia',
                    password: 'empresa2',
                    enabled: true,
                    accountExpired: false,
                    accountLocked: false,
                    passwordExpired: false,
                    plan: plan1
            ).save(flush: true , failOnError: true)
        }




        if(UsuarioRol.count() <= 0) {
            UsuarioRol.create(usuarioAdmin,rolAdmin,true)
            UsuarioRol.create(usuarioEmpresa,rolEmpresa,true)
            UsuarioRol.create(usuarioEmpresa2,rolEmpresa,true)
        }

        if(Unidad.count() <= 0) {
            unidad1 = new Unidad(abreviatura: 'cj',descripcion: 'Caja').save(flush: true, failOnError: true)
            unidad2 = new Unidad(abreviatura: 'pza',descripcion: 'Pieza').save(flush: true, failOnError: true)
        }

        if(ValoresReferencia.count() <= 0){
            new ValoresReferencia(clave: 'MPAGO', valor: 1, descripcion: 'Efectivo').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'MPAGO', valor: 2, descripcion: 'Cheque').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'MPAGO', valor: 3, descripcion: 'T.Credito').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'MPAGO', valor: 4, descripcion: 'T.Debito').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'MPAGO', valor: 5, descripcion: 'T.Transferencia').save(flush: true, failOnError: true)

            /*Dinero*/
            new ValoresReferencia(clave: 'DINER', valor: 0, descripcion: 'Ninguno').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 1, descripcion: '50 centavos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 2, descripcion: '1 Peso').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 3, descripcion: '2 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 4, descripcion: '5 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 5, descripcion: '10 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 6, descripcion: '20 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 7, descripcion: '50 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 8, descripcion: '100 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 9, descripcion: '200 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 10, descripcion: '500 Pesos').save(flush: true, failOnError: true)
            new ValoresReferencia(clave: 'DINER', valor: 11, descripcion: '1000 Pesos').save(flush: true, failOnError: true)

        }

        if (Impuesto.count()<=0){
            impuesto1 = new Impuesto(
                    identificador:'IVA 1',
                    jerarquia:0,
                    tipoAplicacion: TipoAplicacion.IMPORTE
            ).save(flush: true, failOnError: true)
            impuesto2 = new Impuesto(
                    identificador:'IVA 2',
                    jerarquia:0,
                    tipoAplicacion: TipoAplicacion.IMPORTE
            ).save(flush: true, failOnError: true)


        }

        if(Categoria.count() <= 0) {
            categoria1 = new Categoria(nombre: 'Productos', identificador: 'cat1', empresa: usuarioEmpresa).save(flush: true, failOnError: true)
            categoria3 = new Categoria(nombre: 'Refrescos', identificador: 'cat2', empresa: usuarioEmpresa).save(flush: true, failOnError: true)
            categoria4 = new Categoria(nombre: 'Gamesa', identificador: 'cat3', empresa: usuarioEmpresa).save(flush: true, failOnError: true)
            categoria5 = new Categoria(nombre: 'Pan', identificador: 'cat4', empresa: usuarioEmpresa).save(flush: true, failOnError: true)
            categoria2 = new Categoria(nombre: 'Categoria 2', identificador: 'cat2', empresa: usuarioEmpresa2).save(flush: true, failOnError: true)
        }

        if(Producto.count() <= 0){
            producto1 = new Producto(
                    clave:"p1",
                    nombre: "nombre 1",
                    descripcion:"producto 1",
                    codigoBarras:"1",
                    imagen:"",
                    precio:new BigDecimal("15.6"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto1,
                    unidad:unidad1,
                    empresa:usuarioEmpresa,
                    categoria: categoria1
            ).save(flush: true, failOnError: true)
            producto2 = new Producto(
                    clave:"p2",
                    nombre: "nombre 2",
                    descripcion:"producto 2",
                    codigoBarras:"2",
                    imagen:"",
                    precio:new BigDecimal("26.5"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto2,
                    unidad:unidad2,
                    empresa:usuarioEmpresa,
                    categoria: categoria1
            ).save(flush: true, failOnError: true)
            producto3 = new Producto(
                    clave:"p3",
                    nombre: "nombre 3",
                    descripcion:"producto 3",
                    codigoBarras:"3",
                    imagen:"",
                    precio:new BigDecimal("26.5"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto2,
                    unidad:unidad2,
                    empresa:usuarioEmpresa,
                    categoria: categoria1
            ).save(flush: true, failOnError: true)
            producto4 = new Producto(
                    clave:"p4",
                    nombre: "nombre 4",
                    descripcion:"producto 4",
                    codigoBarras:"4",
                    imagen:"",
                    precio:new BigDecimal("26.5"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto2,
                    unidad:unidad2,
                    empresa:usuarioEmpresa,
                    categoria: categoria1
            ).save(flush: true, failOnError: true)

            new Producto(
                    clave:"p5",
                    nombre: "Emperador",
                    descripcion:"producto 5",
                    codigoBarras:"5",
                    imagen:"",
                    precio:new BigDecimal("26.5"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto2,
                    unidad:unidad2,
                    empresa:usuarioEmpresa,
                    categoria: categoria4
            ).save(flush: true, failOnError: true)

            producto1 = new Producto(
                    clave:"p1.2",
                    nombre: "nombre p1.2",
                    descripcion:"producto 1.2",
                    codigoBarras:"1.2",
                    imagen:"",
                    precio:new BigDecimal("1.2"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto1,
                    unidad:unidad1,
                    empresa:usuarioEmpresa2,
                    categoria: categoria2
            ).save(flush: true, failOnError: true)
            producto2 = new Producto(
                    clave:"p2.2",
                    nombre: "nombre p2.2",
                    descripcion:"producto 2.2",
                    codigoBarras:"2.2",
                    imagen:"",
                    precio:new BigDecimal("26.52"),
                    precio2:new BigDecimal("0.0"),
                    precio3:new BigDecimal("0.0"),
                    precio4:new BigDecimal("0.0"),
                    precio5:new BigDecimal("0.0"),
                    impuesto:impuesto2,
                    unidad:unidad2,
                    empresa:usuarioEmpresa2,
                    categoria: categoria2
            ).save(flush: true, failOnError: true)

        }

        if(TipoCuenta.count() <= 0){
            new TipoCuenta(descripcion: 'Persona Moral (S.A o S.R.L)').save(flush: true, failOnError: true)
            new TipoCuenta(descripcion: 'Persona Fisica o RIF').save(flush: true, failOnError: true)
            new TipoCuenta(descripcion: 'Personal').save(flush: true, failOnError: true)
        }


        if(ProductoMaster.count() <= 0){

            new ProductoMaster(codigoBarras: '00001', nombre: 'Coca-Cola', descripcion: 'Es un refresco').save(flush: true, failOnError: true)
            new ProductoMaster(codigoBarras: '00002', nombre: 'Gansito', descripcion: 'De la familia Marinela').save(flush: true, failOnError: true)
            new ProductoMaster(codigoBarras: '00003', nombre: 'Chicles', descripcion: 'Goma de mascar').save(flush: true, failOnError: true)
            new ProductoMaster(codigoBarras: '00004', nombre: 'Pepsi', descripcion: 'Es un refresco').save(flush: true, failOnError: true)
            new ProductoMaster(codigoBarras: '00005', nombre: 'Fanta', descripcion: 'Es un refresco').save(flush: true, failOnError: true)

        }

        if(ImpresoraHomologadas.count() <= 0){
            new ImpresoraHomologadas(nombreImpresora: 'PR3').save(flush: true, failOnError: true)
            new ImpresoraHomologadas(nombreImpresora: 'Sewoo').save(flush: true, failOnError: true)
            new ImpresoraHomologadas(nombreImpresora: 'Bixolon').save(flush: true, failOnError: true)
        }

        if(Pais.count() <= 0){
            new Pais(nombrePais: 'México').save(flush: true, failOnError: true)
        }

        if(Entidad.count() <= 0){
            Pais mexico = Pais.get(1)
            new Entidad(nombreEntidad: 'Jalisco', pais: mexico).save(flush: true, failOnError: true)
            new Entidad(nombreEntidad: 'Michoacán', pais: mexico).save(flush: true, failOnError: true)
            new Entidad(nombreEntidad: 'Colima', pais: mexico).save(flush: true, failOnError: true)
        }

        if(Ciudad.count() <= 0){
            Entidad jalisco = Entidad.get(1)
            Entidad michoacan = Entidad.get(2)
            Entidad colima = Entidad.get(3)

            new Ciudad(nombreCiudad: 'Guadalajara', entidad: jalisco).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'Zapopan', entidad: jalisco).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'Tlaquepaque', entidad: jalisco).save(flush: true, failOnError: true)

            new Ciudad(nombreCiudad: 'Morelia', entidad: michoacan).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'La Piedad', entidad: michoacan).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'Uruapan del Progreso', entidad: michoacan).save(flush: true, failOnError: true)

            new Ciudad(nombreCiudad: 'Manzanillo', entidad: colima).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'Colima', entidad: colima).save(flush: true, failOnError: true)
            new Ciudad(nombreCiudad: 'Tecoman', entidad: colima).save(flush: true, failOnError: true)


        }


        if(PuntoVenta.count() <= 0){

           puntoVenta1 = new PuntoVenta(numeroNegocio: '0001', nombreNegocio: 'Duxstar', calle: 'Vidrio', noExterior: '1872', colonia: 'lafayyette', codigoPostal: '44150',pais: Pais.get(1), entidad: Entidad.get(1), ciudad: Ciudad.get(1), latitud: 20.6678689, longitud: -103.3665254, empresa: usuarioEmpresa).save(flush: true, failOnError: true)
           puntoVenta2 = new PuntoVenta(numeroNegocio: '0002', nombreNegocio: 'Elephant Works', calle: 'Vidrio', noExterior: '1872', colonia: 'lafayyette', codigoPostal: '44150',pais: Pais.get(1), entidad: Entidad.get(1), ciudad: Ciudad.get(1), latitud: 20.6678689, longitud: -103.3665254, empresa: usuarioEmpresa).save(flush: true, failOnError: true)
        }


        if(Cliente.count() <= 0) {
            cliente1 = new Cliente(clave: '01',razonSocial: 'Luis Carlos De la Torre',
                    rfc: 'XAXX010101001',
                    domicilio: 'Calle vidrio #1872',
                    colonia: 'Lafayette',
                    cp: '44150',
                    listaPrecios: 1,
                    limiteCredito: 5000,
                    email: 'luis@gmail.com',
                    telefonoCelular: '3313670341',
                    pais: Pais.get(1), entidad: Entidad.get(1), ciudad: Ciudad.get(1), latitud: 20.6678689, longitud: -103.3665254, empresa: usuarioEmpresa
            ).save(flush: true , failOnError: true)

            cliente2 = new Cliente(
                    clave: '02',
                    razonSocial: 'Johana Esqueda García',
                    rfc: 'XAXX010101002',
                    domicilio: 'Calle vidrio #1872',
                    colonia: 'Lafayette',
                    cp: '44150',
                    listaPrecios: 1,
                    limiteCredito: 2000,
                    email: 'johana@gmail.com',
                    telefonoCelular: '3315730312',
                    pais: Pais.get(1), entidad: Entidad.get(1), ciudad: Ciudad.get(1), latitud: 20.6678689, longitud: -103.3665254, empresa: usuarioEmpresa
            ).save(flush: true , failOnError: true)
        }

        if(Staff.count() <= 0){

            staff1 = new Staff(numEmpleado: '0001', nombre: 'Jose Maria', apellidos: 'Alcala', pin: '1234', email: 'pruebas@gmail.com', autorizaCancelacion: true, empresa: usuarioEmpresa ).save(flush: true, failOnError: true)
            staff1 = new Staff(numEmpleado: '0002', nombre: 'Luis Carlos', apellidos: 'De la Torre Flores', pin: '1234', porcentajeDescuento: 10.00,  email: 'luis@gmail.com',empresa: usuarioEmpresa ).save(flush: true, failOnError: true)

        }

    }
    def destroy = {
    }
}
