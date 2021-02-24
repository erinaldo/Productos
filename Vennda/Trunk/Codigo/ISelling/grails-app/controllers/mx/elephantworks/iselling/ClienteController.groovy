package mx.elephantworks.iselling



import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class ClienteController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def springSecurityService, payuService


    def index(Integer max) {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def respuesta = payuService.validarPagosTransaccion(empresaInstance.idTransaccionPAYU)
        if(!respuesta.toString().equals("APPROVED"))
        {
            flash.error = "Su cuenta esta inactiva hasta que realice el pago en efectivo."
            redirect controller: 'Empresa', action: 'edit', id: empresaInstance.id
        }

        respond Cliente.filtroEmpresa(params.usuario).list(params)
    }

    def show(Cliente clienteInstance) {
        respond clienteInstance
    }

    def create() {
        respond new Cliente(params)
    }

    @Transactional
    def save(Cliente clienteInstance) {
        if (clienteInstance == null) {
            notFound()
            return
        }

        if (clienteInstance.hasErrors()) {

            respond clienteInstance.errors, view:'create'
            return
        }

        clienteInstance.pais = Pais.get(params.pais)
        clienteInstance.entidad = Entidad.get(params.entidad)
        clienteInstance.ciudad = Ciudad.get(params.ciudad)
        clienteInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'cliente.label', default: 'Cliente'), clienteInstance.razonSocial])
                redirect action:"index"
            }
            '*' { respond clienteInstance, [status: CREATED] }
        }
    }

    def edit(Cliente clienteInstance) {
        def entidades = Entidad.findAllByPais(Pais.get(clienteInstance.pais.id))
        def ciudades = Ciudad.findAllByEntidad(Entidad.get(clienteInstance.entidad.id))
        respond clienteInstance, model: [entidades: entidades, ciudades: ciudades]
    }

    @Transactional
    def update(Cliente clienteInstance) {
        if (clienteInstance == null) {
            notFound()
            return
        }

        if (clienteInstance.hasErrors()) {
            def entidades = Entidad.findAllByPais(Pais.get(clienteInstance.pais.id))
            def ciudades = Ciudad.findAllByEntidad(Entidad.get(clienteInstance.entidad.id))
            respond clienteInstance.errors, view:'edit', model: [entidades: entidades, ciudades: ciudades]
            return
        }

        clienteInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Cliente.label', default: 'Cliente'), clienteInstance.razonSocial])
                redirect action:"index"
            }
            '*'{ respond clienteInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Cliente clienteInstance) {

        if (clienteInstance == null) {
            notFound()
            return
        }

        clienteInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Cliente.label', default: 'Cliente'), clienteInstance.razonSocial])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'cliente.label', default: 'Cliente'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
