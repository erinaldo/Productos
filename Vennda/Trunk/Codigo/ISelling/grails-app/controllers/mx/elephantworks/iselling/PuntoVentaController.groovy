package mx.elephantworks.iselling



import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class PuntoVentaController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def payuService, springSecurityService

    def index(Integer max) {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def respuesta = payuService.validarPagosTransaccion(empresaInstance.idTransaccionPAYU)
        if(!respuesta.toString().equals("APPROVED"))
        {
            flash.error = "Su cuenta esta inactiva hasta que realice el pago en efectivo."
            redirect controller: 'Empresa', action: 'edit', id: empresaInstance.id
        }

        respond PuntoVenta.filtroEmpresa(params.usuario).list()
    }

    def show(PuntoVenta puntoVentaInstance) {
        respond puntoVentaInstance
    }

    def create() {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def puntoVentas = PuntoVenta.findAllByEmpresa(empresaInstance)
        if(puntoVentas.size() >= 5){
            flash.error = "Solo es posible crear 5 Puntos de ventas"
            redirect controller: 'puntoVenta', action: 'index'
        }
        respond new PuntoVenta(params)
    }

    @Transactional
    def save(PuntoVenta puntoVentaInstance) {
        if (puntoVentaInstance == null) {
            notFound()
            return
        }

        if (puntoVentaInstance.hasErrors()) {
            respond puntoVentaInstance.errors, view:'create'
            return
        }

        Empresa empresa = Empresa.get(params.empresa.id as Long)
        puntoVentaInstance.empresa = empresa


        puntoVentaInstance.pais = Pais.get(params.pais)
        puntoVentaInstance.entidad = Entidad.get(params.entidad)
        puntoVentaInstance.ciudad = Ciudad.get(params.ciudad)
        puntoVentaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'puntoVenta.label', default: 'Punto de venta'), puntoVentaInstance.nombreNegocio])
                redirect action: 'index'
            }
            '*' { respond puntoVentaInstance, [status: CREATED] }
        }
    }

    def edit(PuntoVenta puntoVentaInstance) {

        def entidades = Entidad.findAllByPais(Pais.get(puntoVentaInstance.pais.id))
        def ciudades = Ciudad.findAllByEntidad(Entidad.get(puntoVentaInstance.entidad.id))
        respond puntoVentaInstance, model: [entidades: entidades, ciudades: ciudades]
    }

    @Transactional
    def update(PuntoVenta puntoVentaInstance) {
        if (puntoVentaInstance == null) {
            notFound()
            return
        }

        if (puntoVentaInstance.hasErrors()) {
            respond puntoVentaInstance.errors, view:'edit'
            return
        }

        puntoVentaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'PuntoVenta.label', default: 'Punto de venta'), puntoVentaInstance.nombreNegocio])
                redirect action: 'index'
            }
            '*'{ respond puntoVentaInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(PuntoVenta puntoVentaInstance) {

        if (puntoVentaInstance == null) {
            notFound()
            return
        }

        puntoVentaInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'PuntoVenta.label', default: 'Punto de venta'), puntoVentaInstance.nombreNegocio])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    @Transactional
    def guardarConfiguraciones(PuntoVenta puntoVentaInstance){
        if (puntoVentaInstance == null) {
            notFound()
            return
        }

        puntoVentaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'puntoVenta.configuraciones.guardadas.label', default: 'Las configuraciones han sido guardadas' )
                redirect action: 'edit', id: puntoVentaInstance.id
            }
            '*'{ respond puntoVentaInstance, [status: OK] }
        }

    }
    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'puntoVenta.label', default: 'Punto de venta'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
