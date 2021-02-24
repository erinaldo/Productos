package mx.elephantworks.iselling



import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class CobranzaController {

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

        def clienteId = params.clienteId
        def ventasCobranza = ""
        if(clienteId){
            Cliente cliente = Cliente.get(clienteId as Long)
            ventasCobranza = Venta.findAllBySaldoGreaterThanAndEmpresaAndCliente(0.0, empresaInstance,cliente)
        }
        respond Venta.list(params), model:[cobranzaInstanceList: ventasCobranza]
    }

    def show(Venta ventaInstance) {

        def datosCliente = ventaInstance.cliente
        def abonos = Cobranza.findAllByVenta(ventaInstance)

        respond ventaInstance, model:[datosCliente: datosCliente, abonos: abonos]
    }

    def create() {
        respond new Cobranza(params)
    }

    @Transactional
    def save(Cobranza cobranzaInstance) {
        if (cobranzaInstance == null) {
            notFound()
            return
        }

        if (cobranzaInstance.hasErrors()) {
            respond cobranzaInstance.errors, view:'create'
            return
        }

        Empresa empresa = Empresa.get(params.empresa.id as Long)
        cobranzaInstance.empresa = empresa

        cobranzaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'cobranza.label', default: 'Cobranza'), cobranzaInstance.id])
                redirect cobranzaInstance
            }
            '*' { respond cobranzaInstance, [status: CREATED] }
        }
    }

    def edit(Cobranza cobranzaInstance) {
        respond cobranzaInstance
    }

    @Transactional
    def update(Cobranza cobranzaInstance) {
        if (cobranzaInstance == null) {
            notFound()
            return
        }

        if (cobranzaInstance.hasErrors()) {
            respond cobranzaInstance.errors, view:'edit'
            return
        }

        cobranzaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Cobranza.label', default: 'Cobranza'), cobranzaInstance.id])
                redirect cobranzaInstance
            }
            '*'{ respond cobranzaInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Cobranza cobranzaInstance) {

        if (cobranzaInstance == null) {
            notFound()
            return
        }

        cobranzaInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Cobranza.label', default: 'Cobranza'), cobranzaInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'cobranza.label', default: 'Cobranza'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
